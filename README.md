# poc-dti-finelli
Repositório para teste de recrutamento empresa DTI

## Executando Docker
docker run -d -p 8889:80 --name finelli-vehicle julianorinaldi/dti-finelli-vehicle-service

## Verificando Log
docker logs -tf finelli-vehicle

## Acessando Instância do Container
docker exec -it finelli-vehicle /bin/bash