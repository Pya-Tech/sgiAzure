#!/bin/bash

set -e

ORACLE_CONTAINER_NAME=oracledb
DMP_PATH="./SgiDatabase/Backups/ACTPRU01/ACTPRU01.DMP"
SQL_PATH="./SgiDatabase/Backups/ACTPRU01/create.sql"
ORACLE_USER=system
ORACLE_PASSWORD=oracle
ORACLE_DB=ORCLCDB
ORACLE_PORT=1524

echo "🚀 Levantando servicios con Docker Compose..."
docker-compose up -d --build

echo "⏳ Esperando que Oracle esté disponible..."
until docker exec "$ORACLE_CONTAINER_NAME" bash -c "echo 'SELECT 1 FROM dual;' | sqlplus -s $ORACLE_USER/$ORACLE_PASSWORD@$ORACLE_DB" > /dev/null 2>&1
do
  printf "."
  sleep 5
done

echo ""
echo "📦 Copiando archivo DMP al contenedor..."
docker cp "$DMP_PATH" "$ORACLE_CONTAINER_NAME":/tmp/ACTPRU01.DMP

echo "📦 Copiando script SQL al contenedor..."
docker cp "$SQL_PATH" "$ORACLE_CONTAINER_NAME":/tmp/create.sql

echo "🛠️ Ejecutando impdp..."
docker exec -i "$ORACLE_CONTAINER_NAME" bash -c "impdp $ORACLE_USER/$ORACLE_PASSWORD@$ORACLE_DB full=yes DIRECTORY=DATA_PUMP_DIR DUMPFILE=ACTPRU01.DMP LOGFILE=import.log"

echo "📝 Ejecutando script SQL..."
docker exec -i "$ORACLE_CONTAINER_NAME" bash -c "echo exit | sqlplus $ORACLE_USER/$ORACLE_PASSWORD@$ORACLE_DB @/tmp/create.sql"

echo "✅ Proceso completado."
