-- ********************************************************************************************
-- Script para la creación de un usuario GEN_BROKER, configuración de AMQP y tabla REQUERIMIENTOS
-- © ACTSIS Ltda.
-- ********************************************************************************************

-- -------------------------------------------------------------------------------------------
-- 1. Crear usuario GEN_BROKER y asignar permisos
-- -------------------------------------------------------------------------------------------
CREATE USER GEN_BROKER IDENTIFIED BY "1234339827";
GRANT CONNECT, RESOURCE TO GEN_BROKER;
ALTER USER GEN_BROKER QUOTA UNLIMITED ON USERS;

-- Permisos específicos para ejecutar y cargar clases Java
GRANT JAVAUSERPRIV TO GEN_BROKER;
GRANT EXECUTE ON DBMS_JAVA TO GEN_BROKER;
GRANT CREATE PROCEDURE TO GEN_BROKER;
GRANT JAVA_ADMIN TO GEN_BROKER;

-- -------------------------------------------------------------------------------------------
-- 2. Crear paquete PK_AMQP para la gestión de AMQP
-- -------------------------------------------------------------------------------------------
CREATE OR REPLACE PACKAGE PK_AMQP AS
  -- Función para obtener el identificador del broker
  FUNCTION F_obtener_broker(
    user IN VARCHAR2,
    password IN VARCHAR2
  ) RETURN NUMBER;

  -- Función para declarar un intercambio en el broker
  FUNCTION amqp_exchange_declare(
    brokerId IN NUMBER,
    exchange IN VARCHAR2,
    exchange_type IN VARCHAR2
  ) RETURN NUMBER;

  -- Función para publicar un mensaje en el broker
  FUNCTION amqp_publish(
    brokerId IN NUMBER,
    exchange IN VARCHAR2,
    routingKey IN VARCHAR2,
    message IN VARCHAR2
  ) RETURN NUMBER;

  -- Procedimiento para imprimir la configuración completa del broker
  PROCEDURE amqp_print_configuration(
    brokerId IN NUMBER
  );

  -- Procedimiento para probar conectividad con los servidores AMQP
  PROCEDURE amqp_probe_servers(
    brokerId IN NUMBER
  );
END PK_AMQP;
/

-- Implementación del paquete PK_AMQP
CREATE OR REPLACE PACKAGE BODY PK_AMQP AS
  FUNCTION F_obtener_broker(user IN VARCHAR2, password IN VARCHAR2) RETURN NUMBER IS
    vl_broker_id broker.broker_id%TYPE;
  BEGIN
    SELECT broker_id INTO vl_broker_id FROM broker WHERE username = user AND password = password;
    RETURN vl_broker_id;
  EXCEPTION
    WHEN NO_DATA_FOUND THEN RETURN NULL;
  END F_obtener_broker;

  FUNCTION amqp_exchange_declare(brokerId IN NUMBER, exchange IN VARCHAR2, exchange_type IN VARCHAR2) RETURN NUMBER AS
  LANGUAGE JAVA NAME 'com.zenika.oracle.amqp.RabbitMQPublisher.amqpExchangeDeclare(int, java.lang.String, java.lang.String) return int';

  FUNCTION amqp_publish(brokerId IN NUMBER, exchange IN VARCHAR2, routingKey IN VARCHAR2, message IN VARCHAR2) RETURN NUMBER AS
  LANGUAGE JAVA NAME 'com.zenika.oracle.amqp.RabbitMQPublisher.amqpPublish(int, java.lang.String, java.lang.String, java.lang.String) return int';

  PROCEDURE amqp_print_configuration(brokerId IN NUMBER) AS
  LANGUAGE JAVA NAME 'com.zenika.oracle.amqp.RabbitMQPublisher.amqpPrintFullConfiguration(int)';

  PROCEDURE amqp_probe_servers(brokerId IN NUMBER) AS
  LANGUAGE JAVA NAME 'com.zenika.oracle.amqp.RabbitMQPublisher.amqpProbeAllServers(int)';
END PK_AMQP;
/

-- -------------------------------------------------------------------------------------------
-- 3. Crear secuencia y tabla REQUERIMIENTOS
-- -------------------------------------------------------------------------------------------
CREATE SEQUENCE seq_requerimientos START WITH 1 INCREMENT BY 1 CACHE 20;

CREATE TABLE REQUERIMIENTOS (
  numero_requerimiento NUMBER(8) NOT NULL,
  estado VARCHAR2(1) NOT NULL,
  user_reporta VARCHAR2(20) NOT NULL,
  fecha_reporta DATE NOT NULL,
  comentario_reporta VARCHAR2(2000) NOT NULL,
  -- Otras columnas omitidas por brevedad
  fecha_fin_estado DATE NOT NULL,
  is_queue NUMBER(1) DEFAULT 0,
  PRIMARY KEY (numero_requerimiento)
);

-- -------------------------------------------------------------------------------------------
-- 4. Crear tabla BROKER para almacenar datos del broker de mensajería
-- -------------------------------------------------------------------------------------------
CREATE TABLE BROKER (
  BROKER_ID NUMBER,
  HOST VARCHAR2(255 BYTE) NOT NULL ENABLE,
  PORT NUMBER DEFAULT 5672,
  VHOST VARCHAR2(255 BYTE) DEFAULT '/',
  USERNAME VARCHAR2(255 BYTE) DEFAULT 'guest',
  PASSWORD VARCHAR2(255 BYTE) DEFAULT 'guest',
  PRIMARY KEY (BROKER_ID, HOST, PORT)
);

-- -------------------------------------------------------------------------------------------
-- 5. Crear Trigger T_REQ_BROKER para publicar mensajes al broker
-- -------------------------------------------------------------------------------------------
CREATE OR REPLACE NONEDITIONABLE TRIGGER T_REQ_BROKER
AFTER INSERT OR UPDATE OR DELETE ON REQUERIMIENTOS
REFERENCING NEW AS NEW OLD AS OLD FOR EACH ROW
DECLARE
  vl_broker_id NUMBER := PK_AMQP.F_obtener_broker('pserrano', '1234339827');
  vl_json_message CLOB;
  vl_publish_result NUMBER;
  vl_queue VARCHAR2(40);
BEGIN
  IF (INSERTING OR UPDATING) AND :NEW.is_queue = 1 THEN
    vl_json_message := JSON_OBJECT(
      'numero_requerimiento' VALUE :NEW.numero_requerimiento,
      'estado' VALUE :NEW.estado,
      'user_reporta' VALUE :NEW.user_reporta,
      'fecha_reporta' VALUE TO_CHAR(:NEW.fecha_reporta, 'YYYY-MM-DD"T"HH24:MI:SS'),
      -- Otros atributos pueden ser añadidos según sea necesario
    );

    IF INSERTING THEN
      vl_queue := 'Insert';
    ELSIF UPDATING THEN
      vl_queue := 'Update';
    END IF;

    vl_publish_result := PK_AMQP.amqp_publish(
      brokerId => vl_broker_id,
      exchange => 'sgi_oracle',
      routingKey => vl_queue,
      message => vl_json_message
    );

    IF vl_publish_result != 0 THEN
      RAISE_APPLICATION_ERROR(
        -20001,
        'Error al publicar el mensaje en la cola. Código de error: ' || vl_publish_result
      );
    END IF;
  END IF;
END T_REQ_BROKER;
/

-- -------------------------------------------------------------------------------------------
-- 6. Insertar brokers de ejemplo para pruebas
-- -------------------------------------------------------------------------------------------
INSERT INTO BROKER (BROKER_ID, HOST, PORT, VHOST, USERNAME, PASSWORD) VALUES (1, '172.18.0.5', 5672, '/', 'pserrano', '1234339827');
INSERT INTO BROKER (BROKER_ID, HOST, PORT, VHOST, USERNAME, PASSWORD) VALUES (1, '172.18.0.5', 5673, '/', 'pserrano', '1234339827');

-- -------------------------------------------------------------------------------------------
-- 7. Pruebas y permisos de red para conectar a RabbitMQ
-- -------------------------------------------------------------------------------------------
SELECT pk_amqp.amqp_exchange_declare(1, 'oracle', 'fanout') FROM dual;
SELECT pk_amqp.amqp_publish(1, 'oracle', 'key', 'Hello World!') FROM dual;
CALL pk_amqp.amqp_print_configuration(1);
CALL pk_amqp.amqp_probe_servers(1);

-- enable the JVM to connect to all your RabbitMQ instances or load-balancers
call dbms_java.grant_permission( 'GEN_BROKER', 'SYS:java.net.SocketPermission', '172.18.0.5:5672', 'connect,resolve' );
call dbms_java.grant_permission( 'GEN_BROKER', 'SYS:java.net.SocketPermission', '172.18.0.5:15672', 'connect,resolve' );

-- tell the Oracle JVM to prefer IPv4 over IPv6 (if needed)...
call dbms_java.grant_permission( 'GEN_BROKER', 'SYS:java.util.PropertyPermission', 'java.net.preferIPv4Stack', 'write' );