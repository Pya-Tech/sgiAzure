-- print System.{out|err} if debugging
SET SERVEROUTPUT ON
CALL dbms_java.set_output(5000);

-- define the broker instances
insert into broker (BROKER_ID,HOST,PORT,VHOST,USERNAME,PASSWORD) values (1,'172.18.0.3',5672,'/','pserrano','1234339827');
insert into broker (BROKER_ID,HOST,PORT,VHOST,USERNAME,PASSWORD) values (1,'172.18.0.3',15672,'/','pserrano','1234339827');

-- tests
select pk_amqp.amqp_exchange_declare(1, 'oracle', 'fanout') from dual;
select pk_amqp.amqp_publish(1, 'oracle', 'key', 'Hello World!') from dual;
call pk_amqp.amqp_print_configuration(1);
call pk_amqp.amqp_probe_servers(1);
