# JiraSteroids API 🚀

JiraSteroids es un clon de Jira de alto rendimiento diseñado bajo los estándares arquitectónicos más exigentes de la industria de software. Este proyecto fue construido para demostrar el dominio de arquitecturas desacopladas, limpias y altamente escalables en el ecosistema de **.NET 10** y **Linux**.

## 🛠️ Tecnologías y Herramientas
* **Lenguaje:** C# (.NET 10)
* **Base de Datos:** PostgreSQL
* **Contenedores:** Docker & Docker Compose
* **ORM:** Entity Framework Core (EF Core)

## 📐 Patrones de Diseño y Arquitectura
* **Clean Architecture:** Separación estricta de responsabilidades en 4 capas independientes (Domain, Application, Infrastructure, API) garantizando portabilidad absoluta del núcleo de negocio.
* **CQRS (Command Query Responsibility Segregation):** División conceptual y física de las operaciones de lectura (Queries) y escritura (Commands).
* **MediatR:** Implementación del patrón *Mediator* para el desacoplamiento total entre la capa de presentación (API Controllers) y la lógica de aplicación (Handlers).
* **FluentValidation:** Validación de tubería (Pipeline) fuertemente tipada para asegurar la integridad de los datos antes de alcanzar las capas internas.

## 🚀 Cómo Ejecutar el Proyecto Localmente

### Requisitos Previos
* .NET 10 SDK instalado
* Docker y Docker Compose instalados y activos

### Pasos para el Arranque

1. **Clonar el repositorio:**
   ```bash
    git clone [https://github.com/TU_USUARIO/JiraSteroidsApi.git](https://github.com/TU_USUARIO/JiraSteroidsApi.git)
    cd JiraSteroidsApi
2. **Levantar la Base de Datos en Docker:**
docker compose up -d

3. **Ejecutar las Migraciones de la Base de Datos:**
dotnet new tool-manifest
dotnet tool install dotnet-ef
dotnet tool run dotnet-ef database update --project src/JiraSteroids.Infrastructure --startup-project src/JiraSteroids.Api

4. **Correr la API:**
cd src/JiraSteroids.Api
dotnet run

5. **Acceder a la documentación interactiva:**
   **Abre en tu navegador: http://localhost:5154/swagger**
