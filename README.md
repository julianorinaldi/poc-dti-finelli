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

# Desafio

## Introdução

Você deve propor uma solução para o problema que será apresentado abaixo. A entrega deve conter um desenho arquitetural (HLD) e uma POC com as funcionalidades que você julgue necessário para uma apresentação com o “cliente”. A apresentação será para a dti e será marcado com você e o RH.

## O Problema

A empresa Finelli S.A. tem um sistema de controle de frotas de ônibus, essa aplicação foi desenvolvida a alguns anos atrás e atualmente está produção com muitos problemas, porém atende o usuário. A Finelli procurou a dti para fazer um assessment arquitetural, visando a modernização desse sistema e uma possível migração para nuvem.

A dti levantou alguns pontos relevantes a serem considerados:

- O sistema é um feito em Java 8 com Spring Boot;
- Não é necessário mexer no frontend;
- A aplicação roda em "On Premises";
- Atualmente toda a publicação é feita por uma equipe que recebe o build feito por um desenvolvedor por e-mail e os coloca no servidor;
- Não existe padrão de versionamento código
- A Finelli já demonstrou muito interesse por devops e SRE
 
- Existem 4 módulos básicos e bem definidos dentro do monolito:
- Módulo de frota (somente leitura de dados)
- Módulo de rota (somente leitura de dados)
- Módulo de Relatório (somente leitura de dados)
- Módulo de cadastros (leitura e escrita de dados)
 
- Todos os dados dos módulos vêm do módulo de cadastro e de uma integração com sistema legado através de “remote views” do Oracle;
- Existe persistência de cache no servidor de aplicação;
- O sistema é acessado globalmente;
 
## Requerimentos da arquitetura

- O sistema não deve ser refeito, mas sim modernizado;
- Java ou .NET;    
- Deve ter abertura para escalabilidade horizontal;            
- Sem restrições de bancos de dados;      
- Sem restrições de provedores de nuvem;           
- A migração deve ser por módulos e incremental, ou seja, o monolito deve continuar acessível durante a migração de cada módulo;

## O que esperamos de você:

- HDL da Arquitetura; 
- POC da comunicação entre dois módulos e monolito;
- Comunicação entre um frontend simples (pode ser uma tabela) e o backend;
- Uma apresentação para a DTI;