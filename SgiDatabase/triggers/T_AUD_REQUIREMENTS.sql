CREATE OR REPLACE NONEDITIONABLE TRIGGER T_AUD_REQUIREMENTS
AFTER INSERT ON REQUERIMIENTOS
FOR EACH ROW
DECLARE
  json_message CLOB;
  publish_result NUMBER;
BEGIN
  IF :NEW.is_queue = 1 THEN
    json_message := JSON_OBJECT(
      'numero_requerimiento' VALUE :NEW.numero_requerimiento,
      'estado' VALUE :NEW.estado,
      'user_reporta' VALUE :NEW.user_reporta,
      'fecha_reporta' VALUE TO_CHAR(:NEW.fecha_reporta, 'YYYY-MM-DD"T"HH24:MI:SS'),
      'comentario_reporta' VALUE :NEW.comentario_reporta,
      'sistema' VALUE :NEW.sistema,
      'tipo_tramite' VALUE :NEW.tipo_tramite,
      'horas_programadas' VALUE TO_CHAR(TO_NUMBER(:NEW.horas_programadas), 'FM9999999990.00'),
      'fecha_programada' VALUE TO_CHAR(:NEW.fecha_programada, 'YYYY-MM-DD"T"HH24:MI:SS'),
      'user_respuesta' VALUE :NEW.user_respuesta,
      'horas_reales' VALUE TO_CHAR(TO_NUMBER(:NEW.horas_reales), 'FM9999999990.00'),
      'tipo_respuesta' VALUE :NEW.tipo_respuesta,
      'prioridad' VALUE :NEW.prioridad,
      'satisfaccion' VALUE :NEW.satisfaccion,
      'sat_tecnica' VALUE :NEW.sat_tecnica,
      'sat_servicio' VALUE :NEW.sat_servicio,
      'sat_tiempo' VALUE :NEW.sat_tiempo,
      'tipo_reporta' VALUE :NEW.tipo_reporta,
      'empresa' VALUE :NEW.empresa,
      'proyecto' VALUE :NEW.proyecto,
      'modulo' VALUE :NEW.modulo,
      'fecha_programada_ini' VALUE TO_CHAR(:NEW.fecha_programada_ini, 'YYYY-MM-DD"T"HH24:MI:SS'),
      'user_programado' VALUE :NEW.user_programado,
      'user_responsable' VALUE :NEW.user_responsable,
      'fecha_fin_estado' VALUE TO_CHAR(:NEW.fecha_fin_estado, 'YYYY-MM-DD"T"HH24:MI:SS'),
      'horas_extras' VALUE TO_CHAR(TO_NUMBER(:NEW.horas_extras), 'FM9999999990.00'),
      'area' VALUE :NEW.area,
      'sub_area' VALUE :NEW.sub_area,
      'tema' VALUE :NEW.tema
    );

    publish_result := PK_AMQP.amqp_publish(
          brokerId => 1,
          exchange => 'oracle',
          routingKey => 'Insert',
          message => json_message
        );
    IF publish_result != 0 THEN
      RAISE_APPLICATION_ERROR(
        num => -20001,
        msg => 'Error al publicar el mensaje en la cola. Código de error: ' || publish_result
      );
    END IF;
  END IF;
END T_AUD_REQUIREMENTS;