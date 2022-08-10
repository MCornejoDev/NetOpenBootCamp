# Guía básica de .NET 6

## Instalación de la herramienta dotnet ef para .NET 6

La instalación de la herramienta viene en el siguiente enlace [dotnet ef](https://docs.microsoft.com/es-es/ef/core/cli/dotnet).

##  Uso básico de dotnet ef para .NET 6

Para utilizar la tecnología ORM de .NET con EF es necesario en primer lugar crear dentro de nuestro proyecto
dos carpetas llamadas DataAccess y Models, esta ultima también almacenará una carpeta DataModels que contendrá 
las clases que se utilizará para la migración a la base de datos.

### Ejemplo

- **DataAccess**
  - **nombreDBContext.cs** 
    : Es el archivo principal que usará nuestro comando ef para añadir o actualizar nuestra base de datos.

```
//TODO: Add DbSets (Tables of our Data base)
public DbSet<User>? Users { get; set; }
public DbSet<Course>? Course { get; set; }
```

- **Models**
  - **DataModels**
    - **BaseEntity.cs** : Es una clase padre, se utilizará en las demas clases para que hereden unas propiedades comunes.
    - **Course.cs** : Es una clase hija, la cuál contendrá las propiedades de BaseEntity.cs y sus propiedades propias.
    - **User.cs** : Es una clase hija, la cuál contendrá las propiedades de BaseEntity.cs y sus propiedades propias.

Una vez que hemos añadido las carpetas y archivos necesarios, haremos uso del comando 
dotnet ef migrations add "Mensaje que aparecerá como nombre de la migración" , esto nos creará en nuestro proyecto una carpeta llamada Migrations
con diferentes archivos :

- **Migrations**
  - **20220809111312_Add User Table.cs** : Migración que creará la tabla User con las columnas que declaramos anteriormente.
  - **20220809111312_Add User Table.Designer.cs** : Migración Designer que creará la tabla User con las columnas que declaramos anteriormente.
  - **20220809112650_Add Course Table.cs** : Migración que creará la tabla User con las columnas que declaramos anteriormente.
  - **20220809112650_Add Course Table.Designer.cs** : Migración Designer que creará la tabla User con las columnas que declaramos anteriormente.
  - **UniversityDBContextModelSnapshot.cs** : El historial de migraciones de forma incremental que se han realizado en el proyecto

Ya creada la carpeta con las migraciones, solo nos quedará hacer uso del comando siguiente 
para ejecutar la migración con los cambios realizados.

```
dotnet ef database update 
```

## Uso básico de la herramienta dotnet-aspnet-codegenerator

El código de la herramienta dotnet-aspnet-codegenerator lo podemos encontrar en el siguiente
enlace [scaffolding](https://docs.microsoft.com/es-es/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio).
La versión actual es la .NET 6 pero podría cambiar en un futuro.

Para utilizar la herramienta de scaffolding de .NET, tendremos que añadir los siguientes
paquetes de generación de código.

```
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet tool install -g dotnet-aspnet-codegenerator
```

Para crear un controlador mediante scaffolding usando el motor de generación de código
de .NET 6 haremos uso del siguiente comando

```
dotnet aspnet-codegenerator controller -name nombreController -async -api -m nombreModelo -dc nombreDBContext -outDir Controllers
```