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
└── README.md
```

## Sesiones disponibles

| Sesion | Contenido | Acceso |
| --- | --- | --- |
| Sesion 1 | Primera aplicación en .NET 10, estructura básica de proyecto y punto de partida del curso | [sesion1/MiPrimeraApp](./sesion1/MiPrimeraApp/) |
| Sesion 2 | Introducción a ASP.NET: Minimal APIs (endpoints con `MapGet`), controladores estilo MVC (`ProductosController`) y uso básico de logging (`ILogger`) | [sesion2/ejemplo1](./sesion2/ejemplo1/) |
| Sesion 3 | ASP.NET con Entity Framework Core: configuración de `DbContext`, base de datos en memoria (`UseInMemoryDatabase`) y CRUD completo de productos (GET, GET por id, POST, PUT, DELETE) | [sesion3/ejemplo1](./sesion3/ejemplo1/) |

## Ejemplos incorporados recientemente

- **Persistencia con EF Core en memoria**: configuración de `AppDbContext` y registro con `AddDbContext`.
- **Datos semilla**: carga inicial de productos al iniciar la aplicación.
- **API CRUD completa**: operaciones para listar, crear, actualizar y eliminar productos.
- **Validación y respuestas HTTP apropiadas**: uso de `Ok`, `CreatedAtAction`, `NoContent` y `NotFound`.