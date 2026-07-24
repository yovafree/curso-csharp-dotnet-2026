![Logo del curso](./img/logo.png)

# Curso de C# y .NET 10

Repositorio base del curso **C# y .NET 10: de los fundamentos al nivel intermedio**, con foco en el aprendizaje progresivo del desarrollo web con **ASP.NET**.

La idea de este repositorio es organizar el contenido por sesiones, de forma que cada carpeta represente una clase, práctica o bloque temático del curso.

## Objetivo del curso

Durante el curso se trabajará sobre los fundamentos de C#, el ecosistema de .NET 10 y la evolución hacia la construcción de aplicaciones web con ASP.NET.

Entre los temas que este repositorio irá cubriendo se encuentran:

- Sintaxis y fundamentos de C#
- Tipos, variables, condicionales y ciclos
- Métodos, clases y principios de programación orientada a objetos
- Estructura de proyectos en .NET 10
- Introducción al desarrollo web con ASP.NET
- Construcción progresiva de aplicaciones y ejercicios prácticos

## Requisitos recomendados

- .NET 10 SDK
- Visual Studio Code o Visual Studio
- Extensión C# para VS Code
- Git

## Estructura del repositorio

```text
curso-csharp-dotnet-2026/
├── img/
├── sesion1/
│   └── MiPrimeraApp/
├── sesion2/
│   └── ejemplo1/
├── sesion3/
│   ├── Sesion 3.json
│   └── ejemplo1/
├── sesion4/
│   └── TiendaWeb.Mvc/
│   └── mvcEjemplo1/
├── sesion6/
│   ├── docker-compose.yaml
│   ├── backup.sql
│   └── Ejemplo1/
├── sesion7/
│   ├── docker-compose.yaml
│   ├── backup.sql
│   └── Ejemplo1/
└── README.md
```

## Sesiones disponibles

| Sesion | Contenido | Acceso |
| --- | --- | --- |
| Sesion 1 | Primera aplicación en .NET 10, estructura básica de proyecto y punto de partida del curso | [sesion1/MiPrimeraApp](./sesion1/MiPrimeraApp/) |
| Sesion 2 | Introducción a ASP.NET: Minimal APIs (endpoints con `MapGet`), controladores estilo MVC (`ProductosController`) y uso básico de logging (`ILogger`) | [sesion2/ejemplo1](./sesion2/ejemplo1/) |
| Sesion 3 | ASP.NET con Entity Framework Core: configuración de `DbContext`, base de datos en memoria (`UseInMemoryDatabase`) y CRUD completo de productos (GET, GET por id, POST, PUT, DELETE) | [sesion3/ejemplo1](./sesion3/ejemplo1/) |
| Sesion 4 | ASP.NET Core MVC con vistas Razor: aplicación `TiendaWeb.Mvc`, `AppDbContext` con EF Core en memoria y CRUD web para Productos y Estudiantes | [sesion4/TiendaWeb.Mvc](./sesion4/TiendaWeb.Mvc/) |
| Sesion 5 | ASP.NET Core MVC: manejo de parámetros en rutas (búsqueda, ordenamiento, paginación), formularios con `ProductoViewModel`, validaciones con Data Annotations (`[Required]`, `[Range]`) y binding de modelo en vistas Razor | [sesion5/mvcEjemplo1](./sesion5/mvcEjemplo1/) |
| Sesion 6 | ASP.NET Core MVC con base de datos real (MySQL) usando EF Core: `docker-compose` para levantar MySQL, entidad `Curso` mapeada con `[Table]`/`[Column]` y `CursosController` para listar registros desde la base de datos | [sesion6/Ejemplo1](./sesion6/Ejemplo1/) |
| Sesion 7 | ASP.NET Core MVC + EF Core con MySQL: CRUD completo de `Curso` (Index, Create, Details, Edit, Delete), confirmación de eliminación (`DeleteConfirmed`) y relación `Estudiante`-`Curso` con carga de navegación usando `Include` | [sesion7/Ejemplo1](./sesion7/Ejemplo1/) |

## Ejemplos incorporados recientemente

- **Persistencia con EF Core en memoria**: configuración de `AppDbContext` y registro con `AddDbContext`.
- **Datos semilla**: carga inicial de productos al iniciar la aplicación.
- **API CRUD completa**: operaciones para listar, crear, actualizar y eliminar productos.
- **Validación y respuestas HTTP apropiadas**: uso de `Ok`, `CreatedAtAction`, `NoContent` y `NotFound`.
- **Aplicación MVC con Razor**: rutas por controlador/acción y páginas para listar, crear, editar, ver detalle y eliminar registros.
- **Gestión de dos entidades**: mantenimiento de Productos y Estudiantes con controladores y vistas independientes.
- **Parámetros en rutas MVC**: paso de parámetros opcionales (`search`, `sort`, `page`) desde la URL al controlador.
- **ViewModels con validación**: `ProductoViewModel` con Data Annotations para validar datos en formularios Razor.
- **Formularios con binding de modelo**: recepción y procesamiento de datos de formulario HTML mediante model binding en acciones `[HttpPost]`.
- **Conexión a base de datos real con MySQL**: uso de `docker-compose.yaml` para levantar un contenedor de MySQL y `UseMySQL` en el `DbContext` para reemplazar la base de datos en memoria.
- **Mapeo de entidades con EF Core**: entidad `Curso` mapeada a una tabla existente mediante `[Table]` y `[Column]`.
- **CRUD web completo de Cursos**: acciones y vistas para listar, crear, ver detalle, editar y eliminar (`DeleteConfirmed`) cursos.
- **Relación entre entidades en EF Core**: asociación `Curso (1) - Estudiante (N)` mediante navegación y llave foránea (`CodCurso`).
- **Consulta con carga de navegación**: listado de estudiantes con su curso asociado usando `Include(e => e.Curso)`.

## Cómo ejecutar cada sesión

1. Abre una terminal en la carpeta de la sesión que quieras ejecutar.
2. Restaura y ejecuta el proyecto:

```bash
dotnet restore
dotnet run
```

3. En proyectos web, abre en el navegador la URL mostrada en la salida de la consola.

## Últimos cambios del repositorio

- Se agregó la carpeta **sesion7/Ejemplo1** con ASP.NET Core MVC conectado a MySQL mediante EF Core.
- Se implementó el CRUD completo de **Cursos** (`Index`, `Create`, `Details`, `Edit`, `Delete`) incluyendo confirmación de eliminación por `POST` (`DeleteConfirmed`).
- Se incorporó la entidad **Estudiante** y su relación con **Curso** (`cod_curso`) para consultas relacionales.
- Se agregó `EstudiantesController` con listado usando `Include(e => e.Curso)` para mostrar datos relacionados.
- Se añadieron en **sesion7/** los archivos `docker-compose.yaml` y `backup.sql` para entorno y datos de práctica.
- Se agregó la carpeta **sesion6/Ejemplo1** con conexión a MySQL mediante EF Core y `docker-compose.yaml` para levantar la base de datos.
- Se incorporó la entidad `Curso` mapeada a la tabla `curso` y `CursosController` para listar registros desde la base de datos.
- Se agregó la carpeta **sesion5/mvcEjemplo1** con ejemplos de parámetros en rutas MVC, ViewModels y validación con Data Annotations.
- Se incorporó `ProductoViewModel` con validaciones `[Required]` y `[Range]` para formularios Razor.
- Se implementó binding de modelo en acciones `[HttpPost]` para recibir datos de formularios HTML.
- Se agregó la carpeta **sesion4/TiendaWeb.Mvc** con una aplicación MVC completa.
- Se incorporaron controladores y vistas para **Productos** y **Estudiantes**.
- Se mantiene el uso de **EF Core InMemory** para facilitar las prácticas sin configuración adicional de base de datos.