#  Employee Talent Management

## Project Structure

* Domain: Entities, Enums, Exceptions, Interfaces, ValuObjects
* Application
* Infraestructure
* WebAPI

## dotnet cli and NuGet commands

### EmployeePayroll.Domain Project
```
mkdir EmployeePayroll.Domain
cd EmployeePayroll.Domain

dotnet new classlib
```

### EmployeePayroll.Application Layer
```
mkdir EmployeePayroll.Application
cd EmployeePayroll.Application
dotnet new classlib

dotnet add package MediatR
dotnet add package MediatR.Extensions.Microsoft.DependencyInjection
dotnet add package AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

dotnet add reference ../EmployeePayroll.Domain
```

### EmployeePayroll.Infrastructure Layer
```
mkdir EmployeePayroll.Infrastructure
cd EmployeePayroll.Infrastructure
dotnet new classlib

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package MediatR
dotnet add package Microsoft.Extensions.Configuration.Binder
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package Microsoft.EntityFrameworkCore.Tools

dotnet add reference ../EmployeePayroll.Application
```

### EmployeePayroll.WebAPI Layer
```
mkdir EmployeePayroll.WebAPI
cd EmployeePayroll.WebAPI
dotnet new webapi

dotnet add package Microsoft.AspNetCore.App
dotnet add package MediatR.Extensions.Microsoft.DependencyInjection
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

dotnet add reference ../EmployeePayroll.Application
dotnet add reference ../EmployeePayroll.Infrastructure
```

### EmployeePayroll.Tests
```
mkdir EmployeePayroll.Tests
cd EmployeePayroll.Tests
dotnet new xunit
dotnet add package NSubstitute
dotnet add package FluentAssertions
dotnet add reference ../EmployeePayroll.Domain
dotnet add reference ../EmployeePayroll.Application
dotnet add reference ../EmployeePayroll.Infrastructure
dotnet add reference ../EmployeePayroll.WebAPI
```

## Create and apply data migrations

For this project is use PostgreSQL database and on free host is https://console.aiven.io/

For production, use Azure Pipelines or GitHub Actions to apply migrations during deployment.

### Bash
```
cd EmployeePayroll.Infrastructure
dotnet ef migrations add InitialCreate --startup-project ../EmployeePayroll.WebAPI
dotnet ef database update --startup-project ../EmployeePayroll.WebAPI
```

### Powershell

In the Package Manager Console, run the following following command to create an initial migration based on your entities and configurations:
```
Add-Migration InitialCreate
```
Generate the migration script. This command will generate a SQL script file containing the migration instructions to create the database schema. The script file will be located in the Migrations folder of the Infrastructure project.
```
Script-Migration
```
Update the database. If you want to apply the migration script to create or update the database schema, run the following command in the Package Manager Console:
```
Update-Database
```
