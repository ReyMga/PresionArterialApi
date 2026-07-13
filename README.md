# PresionArterialApi

API REST desarrollada con ASP.NET Core y Entity Framework Core para registrar y administrar mediciones de presión arterial.

## Tecnologías

- ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI

## Funcionalidades

- Obtener todas las mediciones
- Obtener una medición por ID
- Crear una medición
- Actualizar una medición
- Eliminar una medición

## Endpoints

- GET /api/Mediciones
- GET /api/Mediciones/{id}
- POST /api/Mediciones
- PUT /api/Mediciones/{id}
- DELETE /api/Mediciones/{id}
## Cómo ejecutar el proyecto

1. Clonar el repositorio

```bash
git clone https://github.com/ReyMga/PresionArterialApi.git
```

2. Restaurar paquetes

```bash
dotnet restore
```

3. Ejecutar las migraciones

```bash
dotnet ef database update
```

4. Ejecutar la API

```bash
dotnet run
```

5. Abrir Swagger

```
http://localhost:5222/swagger
```
