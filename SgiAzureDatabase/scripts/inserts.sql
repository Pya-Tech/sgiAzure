-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: sgi_azure_db
-- ------------------------------------------------------
-- Server version	9.3.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (1,'CELSIA','https://sgi-azure','test\r ','CELSIA','CELSIA','sgiazure',NULL,'2025-07-22 14:57:16',NULL),(2,'ACTSIS','https://dev.azure.com','test\r','ACTSIS','DEVOPS','sistemas@actsis.com',NULL,'2025-07-22 14:57:17',NULL);
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `field_mappings`
--

LOCK TABLES `field_mappings` WRITE;
/*!40000 ALTER TABLE `field_mappings` DISABLE KEYS */;
/*!40000 ALTER TABLE `field_mappings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `field_parameters`
--

LOCK TABLES `field_parameters` WRITE;
/*!40000 ALTER TABLE `field_parameters` DISABLE KEYS */;
INSERT INTO `field_parameters` VALUES (1,'TitleField','/fields/System.Title','Campo de título en Azure','azure','string',1,'2025-07-22 14:57:39',NULL),(2,'DescriptionField','/fields/System.Description','Campo de descripción en Azure','azure','string',1,'2025-07-22 14:57:39',NULL),(3,'RequirementField','/fields/Custom.Requirement','Campo de requerimiento personalizado','azure','string',1,'2025-07-22 14:57:39',NULL),(4,'CreatedBy','/fields/Custom.CreatedBy','Campo de creador personalizado','azure','string',1,'2025-07-22 14:57:39',NULL),(5,'State','/fields/System.State','Estado del elemento','azure','string',1,'2025-07-22 14:57:39',NULL),(6,'Reason','/fields/System.Reason','Razón del estado','azure','string',1,'2025-07-22 14:57:39',NULL),(7,'CommentCount','/fields/System.CommentCount','Cantidad de comentarios','azure','int',1,'2025-07-22 14:57:39',NULL),(8,'ReportType','/fields/Custom.ReportType','Tipo de reporte personalizado','azure','string',1,'2025-07-22 14:57:39',NULL),(9,'ProcessingType','/fields/Custom.ProcessingType','Tipo de procesamiento personalizado','azure','string',1,'2025-07-22 14:57:39',NULL),(10,'CompanyField','/fields/Custom.Company','Campo de compañía personalizada','azure','string',1,'2025-07-22 14:57:39',NULL),(11,'SystemField','/fields/Custom.System','Campo de sistema personalizado','azure','string',1,'2025-07-22 14:57:39',NULL),(12,'AssignedUserField','/fields/Custom.AssignedUser','Usuario asignado personalizado','azure','string',1,'2025-07-22 14:57:39',NULL),(13,'AssignToField','/fields/System.AssignedTo','Usuario asignado del sistema','azure','string',1,'2025-07-22 14:57:39',NULL),(14,'PriorityField','/fields/Microsoft.VSTS.Common.Priority','Prioridad del sistema','azure','int',1,'2025-07-22 14:57:39',NULL),(15,'StartDateField','/fields/Microsoft.VSTS.Scheduling.StartDate','Fecha de inicio programada','azure','date',1,'2025-07-22 14:57:39',NULL),(16,'RequiredField','/fields/Custom.Required','Campo de requerido personalizado','azure','string',1,'2025-07-22 14:57:39',NULL),(17,'TargetDateField','/fields/Microsoft.VSTS.Scheduling.TargetDate','Fecha objetivo programada','azure','date',1,'2025-07-22 14:57:39',NULL),(18,'CommentField','/fields/System.History','Campo de comentarios del sistema','azure','string',1,'2025-07-22 14:57:39',NULL),(19,'RequirementId','NUMERO_REQUERIMIENTO','Identificador numérico del requerimiento.','sgi','int',1,'2025-07-22 14:57:39',NULL),(20,'Status','ESTADO','Estado actual del requerimiento.','sgi','string',1,'2025-07-22 14:57:39',NULL),(21,'CreatedBy','USER_REPORTA','Usuario que creó el requerimiento.','sgi','string',1,'2025-07-22 14:57:39',NULL),(22,'CreatedAt','FECHA_REPORTA','Fecha de creación del requerimiento.','sgi','datetime',1,'2025-07-22 14:57:39',NULL),(23,'ReportedComment','COMENTARIO_REPORTA','Comentario ingresado al reportar el requerimiento.','sgi','string',1,'2025-07-22 14:57:39',NULL),(24,'ErrorDescription','ERROR','Descripción del error reportado.','sgi','string',1,'2025-07-22 14:57:39',NULL),(25,'System','SISTEMA','Nombre del sistema involucrado.','sgi','string',1,'2025-07-22 14:57:39',NULL),(26,'Program','PROGRAMA','Programa relacionado al requerimiento.','sgi','string',1,'2025-07-22 14:57:39',NULL),(27,'RelatedRequirementId','REQUERIMIENTO_RELACIONADO','Identificador del requerimiento relacionado.','sgi','int',1,'2025-07-22 14:57:39',NULL),(28,'ProcessRequirementType','TIPO_TRAMITE','Tipo de trámite del requerimiento.','sgi','string',1,'2025-07-22 14:57:39',NULL),(29,'ScheduledHours','HORAS_PROGRAMADAS','Cantidad de horas programadas para el requerimiento.','sgi','int',1,'2025-07-22 14:57:39',NULL),(30,'ScheduledDate','FECHA_PROGRAMADA','Fecha inicialmente programada.','sgi','date',1,'2025-07-22 14:57:39',NULL),(31,'AdjustedDate','FECHA_AJUSTADA','Fecha ajustada de programación.','sgi','date',1,'2025-07-22 14:57:39',NULL),(32,'ResponseByUser','USER_RESPUESTA','Usuario que respondió el requerimiento.','sgi','string',1,'2025-07-22 14:57:39',NULL),(33,'ActualHours','HORAS_REALES','Cantidad de horas realmente trabajadas.','sgi','int',1,'2025-07-22 14:57:39',NULL),(34,'OfficialRequirementType','TIPO_RESPUESTA','Tipo oficial de respuesta del requerimiento.','sgi','string',1,'2025-07-22 14:57:39',NULL),(35,'HoursPerDay','HORAS_DIA','Horas estimadas por día.','sgi','int',1,'2025-07-22 14:57:39',NULL),(36,'StartDate','FECHA_INICIO','Fecha de inicio del trabajo.','sgi','date',1,'2025-07-22 14:57:39',NULL),(37,'Priority','PRIORIDAD','Nivel de prioridad del requerimiento.','sgi','string',1,'2025-07-22 14:57:39',NULL),(38,'SatisfactionLevel','SATISFACCION','Nivel general de satisfacción del cliente.','sgi','string',1,'2025-07-22 14:57:39',NULL),(39,'TechnicalSatisfactionLevel','SAT_TECNICA','Nivel de satisfacción técnica.','sgi','string',1,'2025-07-22 14:57:39',NULL),(40,'ServiceSatisfactionLevel','SAT_SERVICIO','Nivel de satisfacción del servicio recibido.','sgi','string',1,'2025-07-22 14:57:39',NULL),(41,'TimeSatisfactionLevel','SAT_TIEMPO','Nivel de satisfacción en tiempos de entrega.','sgi','string',1,'2025-07-22 14:57:39',NULL),(42,'ReportedRequirementType','TIPO_REPORTA','Tipo de requerimiento reportado.','sgi','string',1,'2025-07-22 14:57:39',NULL),(43,'Company','EMPRESA','Empresa solicitante.','sgi','string',1,'2025-07-22 14:57:39',NULL),(44,'Project','PROYECTO','Proyecto relacionado.','sgi','string',1,'2025-07-22 14:57:39',NULL),(45,'Module','MODULO','Módulo del sistema relacionado.','sgi','string',1,'2025-07-22 14:57:39',NULL),(46,'IsDisplaced','DESPLAZAR','Indica si se solicitó desplazamiento.','sgi','string',1,'2025-07-22 14:57:39',NULL),(47,'IsReprogrammed','REPROGRAMAR','Indica si fue necesario reprogramar.','sgi','string',1,'2025-07-22 14:57:39',NULL),(48,'AllowsHolidayScheduling','PRG_FESTIVOS','Permite programación en días festivos.','sgi','string',1,'2025-07-22 14:57:39',NULL),(49,'InitialScheduledDate','FECHA_PROGRAMADA_INI','Fecha de programación inicial.','sgi','date',1,'2025-07-22 14:57:39',NULL),(50,'Stage','ETAPA','Etapa actual del requerimiento.','sgi','string',1,'2025-07-22 14:57:39',NULL),(51,'ProgrammedByUser','USER_PROGRAMADO','Usuario que realizó la programación.','sgi','string',1,'2025-07-22 14:57:39',NULL),(52,'ResponsibleUser','USER_RESPONSABLE','Usuario responsable del requerimiento.','sgi','string',1,'2025-07-22 14:57:39',NULL),(53,'AdditionalComment','COMENTARIO','Comentario adicional sobre el requerimiento.','sgi','string',1,'2025-07-22 14:57:39',NULL),(54,'InitialScheduledHours','HORAS_PROGRAMADAS_INI','Horas programadas inicialmente.','sgi','int',1,'2025-07-22 14:57:39',NULL),(55,'ProjectStage','ETAPA_PROYECTO','Etapa del proyecto al que pertenece.','sgi','string',1,'2025-07-22 14:57:39',NULL),(56,'Contract','CONTRATO','Contrato relacionado.','sgi','string',1,'2025-07-22 14:57:39',NULL),(57,'ProjectNew','PROYECTO_NEW','Proyecto asociado (nuevo formato).','sgi','string',1,'2025-07-22 14:57:39',NULL),(58,'IsIncidentReported','INCIDENTE_REPORTA','Indica si el requerimiento corresponde a un incidente reportado.','sgi','string',1,'2025-07-22 14:57:39',NULL),(59,'IsIncidentResolved','INCIDENTE_RESPUESTA','Indica si el incidente fue resuelto.','sgi','string',1,'2025-07-22 14:57:39',NULL),(60,'IncidentType','TIPO_INCIDENTE','Tipo de incidente.','sgi','string',1,'2025-07-22 14:57:39',NULL),(61,'IncidentObservation','OBSERVACION_INCIDENTE','Observaciones relacionadas al incidente.','sgi','string',1,'2025-07-22 14:57:39',NULL),(62,'CorrectionId','ID_CORRECCION','Identificador de la corrección asociada.','sgi','int',1,'2025-07-22 14:57:39',NULL),(63,'Order','ORDEN','Orden en el listado o flujo.','sgi','int',1,'2025-07-22 14:57:39',NULL),(64,'CategoryId','CATEGORIA_ID','Identificador de la categoría.','sgi','int',1,'2025-07-22 14:57:39',NULL),(65,'CategoryIdResponse','CATEGORIA_ID_TRAMITE','Identificador de categoría del trámite.','sgi','int',1,'2025-07-22 14:57:39',NULL),(66,'DeliveryDate','FECHA_ENTREGA','Fecha de entrega estimada o real.','sgi','date',1,'2025-07-22 14:57:39',NULL),(67,'EndDate','FECHA_FIN','Fecha final del requerimiento.','sgi','date',1,'2025-07-22 14:57:39',NULL),(68,'AdditionalHours','HORAS_ADICIONALES','Horas adicionales a lo estimado.','sgi','int',1,'2025-07-22 14:57:39',NULL),(69,'ImpactLevel','IMPACTO','Nivel de impacto del requerimiento.','sgi','string',1,'2025-07-22 14:57:39',NULL),(70,'Type','TIPO','Tipo general del requerimiento.','sgi','string',1,'2025-07-22 14:57:39',NULL),(71,'UrgencyLevel','URGENCIA','Nivel de urgencia.','sgi','string',1,'2025-07-22 14:57:39',NULL),(72,'ValidityPeriod','VIGENCIA','Periodo de vigencia del requerimiento.','sgi','string',1,'2025-07-22 14:57:39',NULL),(73,'OptionId','OPCION_ID','Identificador de opción asociada.','sgi','int',1,'2025-07-22 14:57:39',NULL),(74,'CompanyCode','EMPRESA_CODIGO','Código interno de la empresa.','sgi','string',1,'2025-07-22 14:57:39',NULL),(75,'FinalStatusDate','FECHA_FIN_ESTADO','Fecha de cierre o estado final del requerimiento.','sgi','date',1,'2025-07-22 14:57:39',NULL),(76,'OvertimeHours','HORAS_EXTRAS','Cantidad de horas extra trabajadas.','sgi','int',1,'2025-07-22 14:57:39',NULL),(77,'TechnicalSatisfactionComment','SAT_COM_TECNICA','Comentario sobre la satisfacción técnica.','sgi','string',1,'2025-07-22 14:57:39',NULL),(78,'ServiceSatisfactionComment','SAT_COM_SERVICIO','Comentario sobre la satisfacción del servicio.','sgi','string',1,'2025-07-22 14:57:39',NULL),(79,'TimeSatisfactionComment','SAT_COM_TIEMPO','Comentario sobre satisfacción en tiempos.','sgi','string',1,'2025-07-22 14:57:39',NULL),(80,'PptType','PPT_TIPO','Tipo de presentación PPT o documento.','sgi','string',1,'2025-07-22 14:57:39',NULL),(81,'Area','AREA','Área funcional asociada al requerimiento.','sgi','string',1,'2025-07-22 14:57:39',NULL),(82,'SubArea','SUB_AREA','Subárea relacionada.','sgi','string',1,'2025-07-22 14:57:39',NULL),(83,'RequerimientTypeClient','TIPO_REQ_CLIENTE','Tipo de requerimiento según el cliente.','sgi','string',1,'2025-07-22 14:57:39',NULL),(84,'Topic','TEMA','Tema general del requerimiento.','sgi','string',1,'2025-07-22 14:57:39',NULL);
/*!40000 ALTER TABLE `field_parameters` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `field_value_mappings`
--

LOCK TABLES `field_value_mappings` WRITE;
/*!40000 ALTER TABLE `field_value_mappings` DISABLE KEYS */;
/*!40000 ALTER TABLE `field_value_mappings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `field_value_parameters`
--

LOCK TABLES `field_value_parameters` WRITE;
/*!40000 ALTER TABLE `field_value_parameters` DISABLE KEYS */;
/*!40000 ALTER TABLE `field_value_parameters` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `messages_processing`
--

LOCK TABLES `messages_processing` WRITE;
/*!40000 ALTER TABLE `messages_processing` DISABLE KEYS */;
/*!40000 ALTER TABLE `messages_processing` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `work_artifacts`
--

LOCK TABLES `work_artifacts` WRITE;
/*!40000 ALTER TABLE `work_artifacts` DISABLE KEYS */;
/*!40000 ALTER TABLE `work_artifacts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `work_artifacts_mappings`
--

LOCK TABLES `work_artifacts_mappings` WRITE;
/*!40000 ALTER TABLE `work_artifacts_mappings` DISABLE KEYS */;
/*!40000 ALTER TABLE `work_artifacts_mappings` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-11-25 14:59:49

INSERT INTO sgi_azure_db.field_mappings (field_source, field_mapped, customers_id) 
VALUES
(19,3,2),
(25,11,2),
(36,15,2),
(23,18,2),
(75,17,2 ),
(43,10,2),
(42,8,2),
(22,4,2),
(28,9,2),
(52,12,2),
(23,2,2),
(36,15,2)

INSERT INTO field_value_parameters (value_code, value_description, field_parameters_id)
VALUES
('0', 'Creado sin Aprobar', 20),
('A', 'Autorización', 20),
('C', 'Cancelado', 20),
('D', 'Para Envio', 20),
('E', 'Por Programar', 20),
('F', 'Finalizado', 20),
('G', 'Integración', 20),
('I', 'Ajuste Interno', 20),
('L', 'Liberación o Envio Inst.', 20),
('M', 'Mejora', 20),
('N', 'Análisis', 20),
('P', 'Pendiente', 20),
('Q', 'Inquietudes', 20),
('R', 'Devolución', 20),
('S', 'Especificación', 20),
('T', 'Trámite', 20),
('U', 'Pruebas', 20),
('V', 'Verificación', 20);

INSERT INTO field_value_parameters (value_code, value_description, field_parameters_id)
VALUES
('New', 'New', 5),
('Removed', 'Removed', 5),
('Resolved', 'Resolved', 5),
('Closed', 'Closed', 5),
('Active', 'Active', 5);

INSERT INTO field_value_parameters (value_code, value_description, is_active, created_at, updated_at, field_parameters_id) VALUES
('GTA', 'Garantía - Crítica', 1, NOW(), NULL, 8),
('GT2', 'Garantía - Parcial', 1, NOW(), NULL, 8),
('GT3', 'Garantía - Leve', 1, NOW(), NULL, 8),
('QJS', 'Quejas', 1, NOW(), NULL, 8),
('COM', 'Comercialización', 1, NOW(), NULL, 8),
('LEY', 'Actualizaciones de Ley', 1, NOW(), NULL, 8),
('MIG', 'Migración', 1, NOW(), NULL, 8),
('ACT', 'Actualizaciones Continuas', 1, NOW(), NULL, 8),
('ADD', 'Adicional Desarrollos', 1, NOW(), NULL, 8),
('ADS', 'Adicional Script Modif. Datos', 1, NOW(), NULL, 8),
('ADE', 'Adicional Horas Extras', 1, NOW(), NULL, 8),
('ADM', 'Administración', 1, NOW(), NULL, 8),
('AFN', 'Asesoría Funcional', 1, NOW(), NULL, 8),
('ATC', 'Asesoría Técnica', 1, NOW(), NULL, 8),
('CAP', 'Capacitaciones', 1, NOW(), NULL, 8),
('DBA', 'Administración Base de Datos', 1, NOW(), NULL, 8),
('DVO', 'Operaciones de Desarrollo', 1, NOW(), NULL, 8),
('IMP', 'Implantación', 1, NOW(), NULL, 8),
('INV', 'Investigación', 1, NOW(), NULL, 8),
('OPE', 'Operación Sistema', 1, NOW(), NULL, 8),
('PRU', 'Pruebas', 1, NOW(), NULL, 8),
('QA', 'Aseguramiento de Calidad', 1, NOW(), NULL, 8),
('SGC', 'Sistema de Gestión de la Calidad', 1, NOW(), NULL, 8),
('SST', 'Seguridad y Salud en el Trabajo', 1, NOW(), NULL, 8),
('BSG', 'Bolsa de Soporte General', 1, NOW(), NULL, 8),
('SP1', 'Soporte - Primer Nivel', 1, NOW(), NULL, 8),
('SP2', 'Soporte - Segundo Nivel', 1, NOW(), NULL, 8),
('SP3', 'Soporte - Tercer Nivel', 1, NOW(), NULL, 8),
('SCR', 'Script Modif. Datos', 1, NOW(), NULL, 8),
('ADL', 'Adicional Listados', 1, NOW(), NULL, 8),
('INS', 'Instalación - Actualización', 1, NOW(), NULL, 8),
('SIS', 'Infraestructura y Soporte Técnico', 1, NOW(), NULL, 8);

INSERT INTO field_value_parameters (value_code, value_description, is_active, created_at, updated_at, field_parameters_id) VALUES
('GTA', 'Garantía - Crítica', 1, NOW(), NULL, 9),
('GT2', 'Garantía - Parcial', 1, NOW(), NULL, 9),
('GT3', 'Garantía - Leve', 1, NOW(), NULL, 9),
('QJS', 'Quejas', 1, NOW(), NULL, 9),
('COM', 'Comercialización', 1, NOW(), NULL, 9),
('LEY', 'Actualizaciones de Ley', 1, NOW(), NULL, 9),
('MIG', 'Migración', 1, NOW(), NULL, 9),
('ACT', 'Actualizaciones Continuas', 1, NOW(), NULL, 9),
('ADD', 'Adicional Desarrollos', 1, NOW(), NULL, 9),
('ADS', 'Adicional Script Modif. Datos', 1, NOW(), NULL, 9),
('ADE', 'Adicional Horas Extras', 1, NOW(), NULL, 9),
('ADM', 'Administración', 1, NOW(), NULL, 9),
('AFN', 'Asesoría Funcional', 1, NOW(), NULL, 9),
('ATC', 'Asesoría Técnica', 1, NOW(), NULL, 9),
('CAP', 'Capacitaciones', 1, NOW(), NULL, 9),
('DBA', 'Administración Base de Datos', 1, NOW(), NULL, 9),
('DVO', 'Operaciones de Desarrollo', 1, NOW(), NULL, 9),
('IMP', 'Implantación', 1, NOW(), NULL, 9),
('INV', 'Investigación', 1, NOW(), NULL, 9),
('OPE', 'Operación Sistema', 1, NOW(), NULL, 9),
('PRU', 'Pruebas', 1, NOW(), NULL, 9),
('QA', 'Aseguramiento de Calidad', 1, NOW(), NULL, 9),
('SGC', 'Sistema de Gestión de la Calidad', 1, NOW(), NULL, 9),
('SST', 'Seguridad y Salud en el Trabajo', 1, NOW(), NULL, 9),
('BSG', 'Bolsa de Soporte General', 1, NOW(), NULL, 9),
('SP1', 'Soporte - Primer Nivel', 1, NOW(), NULL, 9),
('SP2', 'Soporte - Segundo Nivel', 1, NOW(), NULL, 9),
('SP3', 'Soporte - Tercer Nivel', 1, NOW(), NULL, 9),
('SCR', 'Script Modif. Datos', 1, NOW(), NULL, 9),
('ADL', 'Adicional Listados', 1, NOW(), NULL, 9),
('INS', 'Instalación - Actualización', 1, NOW(), NULL, 9),
('SIS', 'Infraestructura y Soporte Técnico', 1, NOW(), NULL, 9);
