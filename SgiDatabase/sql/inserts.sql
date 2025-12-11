

insert into GEN.MULTITABLA (TABLA, CODIGO_CAR, CODIGO_NUM, DESCRIPCION, VALOR_CAR, VALOR_NUM, FECHA_DESACTIVACION_J, VALOR_1, VALOR_2, VALOR_3, VALOR_4, VALOR_5, VALOR_6, INDICADORES, SISTEMA, MODULO, SUBMODULO, LLAVE)
values ('BROKER_ORIGIN', 'SGI_BD', null, 'Origen desde SGI_BD', 'ACTSIS', 0.00, 2458780, null, 'ACTSIS', 'PSERRANO', null, null, null, null, 'SGI', '1', '99', '-');

insert into GEN.MULTITABLA (TABLA, CODIGO_CAR, CODIGO_NUM, DESCRIPCION, VALOR_CAR, VALOR_NUM, FECHA_DESACTIVACION_J, VALOR_1, VALOR_2, VALOR_3, VALOR_4, VALOR_5, VALOR_6, INDICADORES, SISTEMA, MODULO, SUBMODULO, LLAVE)
values ('BROKER_ORIGIN', 'SGI_CLIENT', null, 'Origen desde SGI cliente Servidor', 'ACTSIS', null, null, null, 'ACTSIS', 'PSERRANO', null, null, null, null, 'SGI', '1', '99', '-');

insert into GEN.MULTITABLA (TABLA, CODIGO_CAR, CODIGO_NUM, DESCRIPCION, VALOR_CAR, VALOR_NUM, FECHA_DESACTIVACION_J, VALOR_1, VALOR_2, VALOR_3, VALOR_4, VALOR_5, VALOR_6, INDICADORES, SISTEMA, MODULO, SUBMODULO, LLAVE)
values ('BROKER_ORIGIN', 'SGI_WEB', null, 'Origin desde SGI_WEB', 'ACTSIS', null, null, null, 'ACTSIS', 'PSERRANO', null, null, null, null, 'SGI', '1', '99', '-');
        


INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'DRONDON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EREYES', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAR', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'DRONDON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'SDBARON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAR', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'DRONDON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAF', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EMONTENEGRO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAF', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'SDBARON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EREYES', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EREYES', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAF', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EMONTENEGRO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAF', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'DRONDON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EREYES', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAF', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'SDBARON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAR', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EREYES', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAR', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'DRONDON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'SDBARON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'SDBARON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAF', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'DRONDON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAR', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAR', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EREYES', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'SDBARON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EMONTENEGRO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'SDBARON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAR', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'DRONDON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAF', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'SDBARON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAR', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'SDBARON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'SDBARON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAR', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'DRONDON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'DRONDON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAR', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'DRONDON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAF', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EREYES', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAF', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'SDBARON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAF', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EREYES', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'SDBARON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAF', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'SDBARON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EMONTENEGRO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAR', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EMONTENEGRO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EREYES', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAR', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'SDBARON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAR', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'DRONDON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAF', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EREYES', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAF', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EMONTENEGRO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'DRONDON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EMONTENEGRO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EREYES', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EMONTENEGRO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'SDBARON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAR', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EMONTENEGRO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EREYES', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAF', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EREYES', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EREYES', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'SDBARON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EREYES', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAR', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'DRONDON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAR', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EREYES', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAF', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'DRONDON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'SAF', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'SAC', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'DRONDON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'CELSIA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'MVANEGAS', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'DRONDON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'PSERRANO', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'SDBARON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'DRONDON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAR', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'SDBARON', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ABOGOTA', 'SAF', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );

        
INSERT INTO REQUERIMIENTOS (
            estado, user_reporta, fecha_reporta, comentario_reporta, sistema, 
            tipo_tramite, horas_programadas, fecha_programada, user_respuesta, horas_reales, 
            tipo_respuesta, prioridad, satisfaccion, sat_tecnica, sat_servicio, sat_tiempo, 
            tipo_reporta, empresa, proyecto, modulo, fecha_programada_ini, user_programado, 
            user_responsable, fecha_fin_estado, horas_extras, area, sub_area, tema, is_queue
        ) VALUES (
            'P', 'EREYES', SYSDATE, 'Descripción breve del requerimiento', 
            'SIST01', 'NORMAL', 5, SYSDATE + 7, 'user02', 4.5, 'FINALIZADO', 1, 95, 90, 85, 80, 
            'ADS', 'ESSA', 'GEN', 'MOD01', SYSDATE, 'user03', 'user04', SYSDATE + 7, 0, 
            'Área de Prueba', 'Subárea de Prueba', 'Tema del requerimiento', 1
        );
