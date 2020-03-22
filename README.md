**********************************************
**Run SQL Ducker Container**
**********************************************
docker pull mcr.microsoft.com/mssql/server:2017-latest-ubuntu
docker run -d --name sql_server_demo -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=reallyStrongPwd123' -p 1433:1433 mcr.microsoft.com/mssql/server:2017-latest-ubuntu
npm install -g sql-cli
mssql -u sa -p reallyStrongPwd123
*********************************************

**Migration**
- Add-Migration + name
- Update-Database
- Remove-Migration
- Update-Database [Last migration] "To revert to a last migration"
- script-migration => To generate sql script# DotNetApp
