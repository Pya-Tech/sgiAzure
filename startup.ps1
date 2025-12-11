$ErrorActionPreference = "Stop"

# Oracle
$oracleContainer = "oracledb"
$dmpPath = ".\SgiDatabase\Backups\ACTPRU01\ACTPRU01.DMP"
$sqlPath = ".\SgiDatabase\Backups\ACTPRU01\create.sql"
$oracleUser = "system"
$oraclePassword = "oracle"
$oracleDb = "ORCLCDB"

# RabbitMQ
$rabbitContainer = "rabbitmq"
$containerDefinitionsPath = "/etc/rabbitmq/definitions.json"

Write-Host "Levantando servicios con Docker Compose..."
docker-compose up -d --build

# Esperar que Oracle esté disponible
Write-Host "Esperando que Oracle esté disponible..."
do {
    Start-Sleep -Seconds 5
    $output = docker exec $oracleContainer bash -c "echo 'SELECT 1 FROM dual;' | sqlplus -s $oracleUser/$oraclePassword@$oracleDb" 2>$null
    Write-Host -NoNewline "."
} while (-not $output)
Write-Host ""

# Copiar archivos a Oracle
Write-Host "Copiando archivo DMP al contenedor Oracle..."
docker cp $dmpPath "${oracleContainer}:/opt/oracle/admin/ORCLCDB/dpdump"

Write-Host "Copiando script SQL al contenedor Oracle..."
docker cp $sqlPath "${oracleContainer}:/tmp/create.sql"

# Ejecutar impdp y SQL
Write-Host "Ejecutando impdp..."
docker exec -i $oracleContainer bash -c "impdp $oracleUser/$oraclePassword@$oracleDb full=yes DIRECTORY=DATA_PUMP_DIR DUMPFILE=ACTPRU01.DMP LOGFILE=import.log"

Write-Host "Ejecutando script SQL..."
docker exec -i $oracleContainer bash -c "echo exit | sqlplus $oracleUser/$oraclePassword@$oracleDb @/tmp/create.sql"

# Esperar que RabbitMQ esté disponible
Write-Host "Esperando que RabbitMQ esté disponible..."
do {
    Start-Sleep -Seconds 5
    $rmqStatus = docker exec $rabbitContainer rabbitmqctl status 2>$null
    Write-Host -NoNewline "."
} while (-not $rmqStatus)
Write-Host ""

# Importar definiciones
Write-Host "Importando definiciones de RabbitMQ..."
docker exec $rabbitContainer rabbitmqctl import_definitions $containerDefinitionsPath

Write-Host "Proceso completado correctamente."
