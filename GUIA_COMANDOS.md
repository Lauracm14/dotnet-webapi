# Guía Rápida de Comandos MyVaccine

Este documento explica los comandos esenciales que se han utilizado para configurar tu proyecto.

## 1. Crear la Migración

**Comando:**

```bash
dotnet ef migrations add InitialCreate --project MyVaccine.Web --startup-project MyVaccine.Web
```

**¿Qué hace?**
Este comando compara tus clases de C# (Modelos) con el estado actual de la base de datos. Como es la primera vez, genera un conjunto de instrucciones (código C#) para crear todas las tablas necesarias desde cero. Es como dibujar el plano arquitectónico de tu base de datos.

## 2. Actualizar la Base de Datos

**Comando:**

```bash
dotnet ef database update --project MyVaccine.Web --startup-project MyVaccine.Web
```

**¿Qué hace?**
Toma el "plano" creado en el paso anterior y lo ejecuta realmente. En este caso, ha creado un archivo físico llamado `MyVaccine.db` (SQLite) y ha construido dentro de él las tablas para Usuarios, Vacunas y Centros de Vacunación.

## 3. Ejecutar la Aplicación

**Comando:**

```bash
dotnet run --project MyVaccine.Web
```

**¿Qué hace?**
Compila tu código, inicia el servidor web y pone tu aplicación en funcionamiento. Una vez ejecutado, puedes abrir tu navegador para interactuar con la API.
