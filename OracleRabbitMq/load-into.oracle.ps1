$USER_PASS = "GEN/PruGen3*24"
$SCHEMA = "GEN"
$HOST_ORACLE = "172.145.72.94" 
$PORT = "1521"
$SERVICE_NAME = "ACTPRU01.actsissrpriv.actsisqa.oraclevcn.com"
$CONNECTION_STRING = "${USER_PASS}@${HOST_ORACLE}:${PORT}/${SERVICE_NAME}"

# Compilar y preparar el proyecto
mvn clean package
mvn dependency:copy-dependencies

# Cargar la biblioteca log4j primero
loadjava -user $CONNECTION_STRING -resolve -resolver "((* $SCHEMA) (* PUBLIC) (* -))" "target/dependency/log4j-1.2.17.jar"
loadjava -user $CONNECTION_STRING -resolve -resolver "((* $SCHEMA) (* PUBLIC) (* -))" "target/dependency/javax.servlet-api-4.0.1.jar"

# Cargar dependencias usando loadjava
loadjava -user $CONNECTION_STRING -resolve -resolver "((* $SCHEMA) (* PUBLIC) (* -))" "target/dependency/commons-logging*.jar"
loadjava -user $CONNECTION_STRING -resolve -resolver "((* $SCHEMA) (* PUBLIC) (* -))" "target/dependency/amqp-client*.jar"

# Cargar las clases Java
loadjava -user $CONNECTION_STRING -resolve -resolver "((* $SCHEMA) (* PUBLIC) (* -))" "target/classes/com/zenika/oracle/amqp/*.class"

