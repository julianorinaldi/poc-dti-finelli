# Projeto exemplo - Strangler Fig Application
Repositório para teste de recrutamento empresa DTI
- Objetivo demonstrar um monolito sendo "estrangulado"

# Dicas para executar container Docker

## Executando Docker
docker run -d -p 8889:80 --name finelli-vehicle julianorinaldi/dti-finelli-vehicle-service

## Verificando Log
docker logs -tf finelli-vehicle

## Acessando Instância do Container
docker exec -it finelli-vehicle /bin/bash