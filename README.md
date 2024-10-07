# Projeto API - MiniBank

## Instruções para executar o projeto
 - Na raiz deste repositório tem uma pasta com o nome "**docker-mysql**". Pelo terminal navegue até esta pasta e digite o comando: "**docker-compose up -d**" para iniciar o container MySQL já com o banco e tabelas criados.
 - Se já possui algum MySQL instalado no computador ou em nuvem, basta executar o arquivo SQL que também está na pasta "**docker-mysql/db-init**". Após a execução do arquivo, será necessário ajustar a string de conexão com o banco de dados no projeto da API no seguinte caminho: "**src/MiniBankApp.Api/appsettings.json**"
 - Com o banco criado e devidamente configurado, abra o terminal, navegue até a pasta "**src/MiniBankApp.Api**" e excute o comando: "**dotnet run**"
 - Se prefirir, abra a solução pelo Visual Studio e pressione F5
 - Para interagir com os endpoints da API, acesse pelo navegador o Swagger: http://localhost:XXXX/swagger (altere o XXXX pela porta que subiu a API).
 - Link para o projeto front-end: https://github.com/dev-vinicius/mini-bank-app-web

   ![Estrutura](https://github.com/dev-vinicius/mini-bank-app-api/blob/main/api-web-estrutura.png)
