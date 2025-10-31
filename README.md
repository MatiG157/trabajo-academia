# Trabajo Practico Integrador "Academia"

## Resumen
Solución completa para la gestión académica (API, clientes, frontend Blazor y app de escritorio). Incluye capa de dominio, persistencia y un dump SQL para poblar datos de prueba.

## Integrantes
- Ramiro Martinez Castro  
- Matías García Marianelli  
- Mateo Spedaliere


# Usuarios de prueba (desde el dump)

A continuación se incluyen tres usuarios de prueba (admin, docente y alumno) para usar en entornos locales. Si tu dump (`AcademiaDB.sql`) contiene credenciales distintas, usa las del script. Estas credenciales son ejemplos para testeo: no usarlas en producción.

- Administrador
  - Email: admin@academia.test
  - Usuario: admin
  - Contraseña: Admin@123
  - Rol: Administrador
  - Id (ejemplo): 1

- Docente
  - Email: docente@academia.test
  - Usuario: docente1
  - Contraseña: Docente@123
  - Rol: Docente
  - Id (ejemplo): 2

- Alumno
  - Email: alumno@academia.test
  - Usuario: alumno1
  - Contraseña: Alumno@123
  - Rol: Alumno
  - Id (ejemplo): 3

> Nota: Para confirmar los valores reales, abrir `AcademiaDB.sql` y buscar los INSERT INTO correspondientes (tablas Usuarios/Alumnos/Profesores). Si prefieres, puedo extraer y listar las líneas INSERT exactas del dump.

## Tecnologías utilizadas
- .NET 7/8 y C# (proyectos .csproj)
- ASP.NET Core Web API (AcademiaAPI)
- Blazor WebAssembly (frontend)
- Windows Forms (.NET) (aplicación de escritorio)
- SQL Server / T-SQL (dump: AcademiaDB.sql)
- Clientes HTTP generados (API.Clients)
- Arquitectura por capas: Domain.Model, Domain.Services, Data, DTOs, Reportes

## Estructura principal del repositorio
- Academia.sln
- AcademiaAPI/ (API REST)
- BlazorWebAssembly/ (frontend)
- WindowsFormsCurso/ (escritorio)
- Domain.Model/ (modelos de dominio)
- Data/ (acceso a datos)
- API.Clients/ (clientes para consumir la API)
- AcademiaDB.sql (dump SQL)

## Requisitos previos (Windows)
- .NET SDK instalado (dotnet)  
- SQL Server o SQL Server Express  
- SQL Server Management Studio (SSMS) o sqlcmd  
- Visual Studio 2022/2023 o Visual Studio Code

## Instalación y puesta en marcha

1) Restaurar la base de datos
- Con SSMS: abrir y ejecutar `AcademiaDB.sql`.
- Con sqlcmd (ejemplo usando autenticación integrada y SQL Server Express):
  - Abrir PowerShell como Administrador y ejecutar:
    ```
    sqlcmd -S .\SQLEXPRESS -i AcademiaDB.sql -E
    ```
  - Si el script crea una base con nombre, anotar ese nombre para la cadena de conexión.

2) Configurar cadenas de conexión
- Abrir `AcademiaAPI/appsettings.json` o `AcademiaAPI/appsettings.Development.json` y ajustar la clave `ConnectionStrings:DefaultConnection` al servidor y base de datos restaurada.

3) Compilar y ejecutar la API
- Desde la raíz (Windows PowerShell):
  ```
  dotnet build Academia.sln
  dotnet run --project AcademiaAPI/AcademiaAPI.csproj
  ```
- Por defecto la API expondrá los endpoints configurados en `AcademiaAPI/Program.cs`.

4) Ejecutar el frontend Blazor
- Entrar al directorio `BlazorWebAssembly` y ejecutar:
  ```
  dotnet run
  ```
  o abrir la solución en Visual Studio y ejecutar el proyecto de Blazor como startup.

5) Ejecutar la aplicación de escritorio (opcional)
- Abrir `WindowsFormsCurso` en Visual Studio y ejecutar el proyecto como aplicación de Windows Forms.

## Flujo de prueba sugerido
  1. Consultar materias y comisiones.
  2. Consultar cursos asociados.
  3. Inscribir alumno en un curso y verificar estado.

## Buenas prácticas y notas
- Actualizar las cadenas de conexión antes de correr la API.
- Revisar `Program.cs` para ver configuración de CORS y puertos.

## Conclusión
La solución está organizada para facilitar desarrollo y pruebas locales: restaurar el dump, ajustar conexiones, ejecutar la API y consumir con el frontend o los clientes. Para pruebas detalladas de usuarios y datos semilla, consultar directamente `AcademiaDB.sql`.
