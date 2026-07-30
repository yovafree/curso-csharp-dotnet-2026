# Database First con Entity Framework Core

# Instalación de Entity Framework Tools CLI

dotnet tool install --global dotnet-ef

# Agregar al proyecto la librería de Diseño

dotnet add package Microsoft.EntityFrameworkCore.Design

# El conector para la base de datos a utilizar (MySQL)

dotnet add package MySql.EntityFrameworkCore

# Ejecutar el Scaffold para el mapeo de la Base de Datos a nuestro programa.

dotnet ef dbcontext scaffold "Server=localhost;Database=curso_db;User=db_user;Password=Password1234;" MySql.EntityFrameworkCore -o Models