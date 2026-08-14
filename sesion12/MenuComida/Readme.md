# crea la migración inicial
dotnet ef migrations add InicialMenu

# aplica la migración y crea la base de datos
dotnet ef database update

# si algo sale mal, se puede revertir
dotnet ef database update 0
dotnet ef migrations remove