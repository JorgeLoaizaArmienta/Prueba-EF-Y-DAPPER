# 🧪 Proyecto de Prueba - ASP.NET Core 8.0 Web API con EF Core y Dapper

Este proyecto es una base para pruebas y colaboración, utilizando **ASP.NET Core 8.0 Web API** con integración de **Entity Framework Core** y **Dapper** para acceso a datos.

---

## 📌 Objetivo

Crear una solución modular, limpia y bien estructurada que permita comparar y utilizar tanto EF Core como Dapper para acceder a datos, ideal para aprendizaje o pruebas de rendimiento.

---

## ⚙️ Tecnologías y Herramientas

- [.NET 8.0](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [Dapper](https://github.com/DapperLib/Dapper)
- SQL Server
- Visual Studio / Visual Studio Code
- Git / GitHub

---

## 📁 Estructura del Proyecto

```text
Prueba-EF-Y-DAPPER/
├── Prueba-EF-Y-DAPPER.sln
├── Prueba-EF-Y-DAPPER/                → Proyecto Web API principal
├── Application/        → Casos de uso, servicios y DTOs
├── Domain/             → Entidades y contratos
├── Infrastructure/     → Implementaciones de EF Core y Dapper
├── Persistence/        → Contexto EF Core y configuración DB
└── IOC/                → Dependencias.
