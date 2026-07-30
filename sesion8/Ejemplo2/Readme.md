# Code-First en EntityFrameworkCore

# Agregar al proyecto la librería de Diseño

dotnet add package Microsoft.EntityFrameworkCore.Design

# El conector para la base de datos a utilizar (MySQL)

dotnet add package MySql.EntityFrameworkCore

# Migraciones

## Mapeo de la creación de la base de datos:

dotnet ef migrations add InitialCreate

# Creación de base de datos y tablas iniciales
dotnet ef database update

# Nueva Migración

dotnet ef migrations add AddFecNacimientoAutor


dotnet ef database update

# Nueva Migración - Se agregan prestamos de libros

dotnet ef migrations add AddPrestamos


dotnet ef database update

# Revertir una migración

dotnet ef migrations remove