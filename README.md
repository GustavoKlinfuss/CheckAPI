-- Rodar o Docker local  
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -e "MSSQL_PID=Express" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest

-- Rodar as migrations  
cd src\CheckAPI.Infrastructure\
dotnet ef database update

-- Alterar o IP da connection string do banco do arquivo CheckAPIContext para seu IP de rede  
optionsBuilder.UseSqlServer("Data Source={SEU-IP},1433;Initial Catalog=master;User ID=sa;Password=sEnh@ComPl&xa;TrustServerCertificate=True;");

-- Rodar o projeto da forma que preferir. Via Visual Studio ou linha de comando
