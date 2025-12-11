#!/bin/bash

# Nombre del contenedor
CONTAINER_NAME="rabbitmq"

# Verifica si el contenedor ya existe
if [ "$(docker ps -aq -f name=${CONTAINER_NAME})" ]; then
    echo "El contenedor ${CONTAINER_NAME} ya existe. Eliminando..."
    docker rm -f ${CONTAINER_NAME}
fi

# Ejecuta el contenedor con las configuraciones dadas
docker run -d --name ${CONTAINER_NAME} \
  -p 5672:5672 \
  -p 15672:15672 \
  -v /opt/rabbitmq/data:/var/lib/rabbitmq \
  -v /opt/rabbitmq/logs:/var/log/rabbitmq \
  -v /home/actsis/docker/sgiazure/SgiAzure/RabbitMq/definitions.json:/etc/rabbitmq/definitions.json \
  -e RABBITMQ_DEFAULT_USER=admin \
  -e RABBITMQ_DEFAULT_PASS="N9v!rT6zQ4#xP2kD" \
  -e RABBITMQ_LOAD_DEFINITIONS=/etc/rabbitmq/definitions.json \
  --restart=always \
  rabbitmq:3-management


rabbitmqctl import_definitions /etc/rabbitmq/definitions.json
