param (
    [string]$USER,
    [string]$USER_PASSWORD,
    [string]$SCHEMA,
    [string]$HOST_ORACLE,
    [string]$PORT,
    [string]$SERVICE_NAME
)

$CONNECTION_STRING = "${USER}/${USER_PASSWORD}@${HOST_ORACLE}:${PORT}/${SERVICE_NAME}"

# # Ir al directorio del proyecto
# $projectPath = Join-Path $PSScriptRoot "OracleRabbitMq"
# Write-Host $projectPath
# Push-Location $projectPath

# # Compilar y preparar el proyecto
# Write-Host "📦 Compilando proyecto Maven..."
mvn clean package
mvn dependency:copy-dependencies

# Cargar dependencias específicas (sin expandir wildcard, dejarlo como string)
Write-Host "📚 Cargando librerías específicas..."
# Cargar la biblioteca log4j primero
loadjava -user $CONNECTION_STRING -resolve -resolver "((* $SCHEMA) (* PUBLIC) (* -))" "target/dependency/log4j-1.2.17.jar"
loadjava -user $CONNECTION_STRING -resolve -resolver "((* $SCHEMA) (* PUBLIC) (* -))" "target/dependency/javax.servlet-api-4.0.1.jar"

# Cargar dependencias usando loadjava
loadjava -user $CONNECTION_STRING -resolve -resolver "((* $SCHEMA) (* PUBLIC) (* -))" "target/dependency/commons-logging*.jar"
loadjava -user $CONNECTION_STRING -resolve -resolver "((* $SCHEMA) (* PUBLIC) (* -))" "target/dependency/amqp-client*.jar"

# Cargar las clases Java
loadjava -user $CONNECTION_STRING -resolve -resolver "((* $SCHEMA) (* PUBLIC) (* -))" "target/classes/com/zenika/oracle/amqp/*.class"


Pop-Location

Write-Host "`n✅ Proceso finalizado correctamente"