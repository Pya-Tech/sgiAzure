#!/bin/bash

# Inicia Oracle normalmente (background)
/opt/oracle/runOracle.sh &

# Esperar a que la BD esté disponible
echo "Esperando que Oracle arranque completamente..."
until echo "SELECT 1 FROM DUAL;" | sqlplus -s system/oracle@ORCLCDB > /dev/null 2>&1; do
  echo -n "."
  sleep 5
done

echo ""
echo "✔ Oracle está arriba"

# Ejecutar impdp si el archivo existe
if [ -f "/opt/oracle/admin/ORCLCDB/dpdump/ACTPRU01.DMP" ]; then
  echo "🚀 Ejecutando importación con impdp..."
  impdp system/oracle@ORCLCDB full=yes DIRECTORY=DATA_PUMP_DIR DUMPFILE=ACTPRU01.DMP LOGFILE=ACTPRU01.log
else
  echo "⚠️ Archivo ACTPRU01.DMP no encontrado, omitiendo impdp"
fi

# Ejecutar SQL adicional si existe
if [ -f "/opt/oracle/admin/ORCLCDB/dpdump/config.sql" ]; then
  echo "📜 Ejecutando script SQL adicional..."
  echo "exit" | sqlplus system/oracle@ORCLCDB @/opt/oracle/admin/ORCLCDB/dpdump/config.sql
else
  echo "⚠️ Archivo config.sql no encontrado, omitiendo script SQL"
fi

# Mantiene el contenedor vivo
tail -f /dev/null
