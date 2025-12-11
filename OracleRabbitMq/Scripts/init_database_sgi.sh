docker cp D:\\GIT\\SgiAzure\\OracleRabbitMq\\Backups\\ACTPRU01\\ACTPRU01.DMP oracledb:/opt/oracle/admin/ORCLCDB/dpdump/

impdp system/oracle@localhost:1521/ORCLCDB full=yes DIRECTORY=DATA_PUMP_DIR DUMPFILE=ACTPRU01.DMP LOGFILE=ACTPRU01.log

