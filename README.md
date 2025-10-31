# Trabajo Practico Integrador "Academia"

## Resumen
Solución completa para la gestión académica (API, clientes, frontend Blazor y app de escritorio). Incluye capa de dominio, persistencia y un dump SQL para poblar datos de prueba.

## Integrantes
- Ramiro Martinez Castro  
- Matías García Marianelli  
- Mateo Spedaliere

# Usuarios de prueba (desde el dump)

A continuación se incluyen los usuarios de prueba que se crean con el dump (AcademiaDB.sql). Estos datos son ejemplos para testeo y no deben usarse en producción.

- *Administrador*
  - Email: admin@gmail.com
  - Usuario: admin
  - Contraseña: 123
  - Rol: Administrador
  - IdPersona: 1

- *Docente*
  - Email: profe@gmail.com
  - Usuario: profe
  - Contraseña: 123
  - Rol: Docente
  - IdPersona: 3

- *Alumno*
  - Email: alumno@gmail.com
  - Usuario: alumno
  - Contraseña: 123
  - Rol: Alumno
  - IdPersona: 5

> Nota: Para más usuarios y roles, consultar el dump SQL. Los docentes están asignados a cursos con los cargos "Docente" y "Practica". Los alumnos están inscriptos en cursos con condición "Cursando" y nota NULL.

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
1) Crear la base de datos
Lo primero que se debe hacer es ejecutar el programa, esto nos creará toda la base de datos con EF. Nosotros nos encargamos de dejar configurada la cadena de conexión con el mismo nombre que la base de datos, pero en caso de ser modificada, se debe también modificar la cadena.
Importante: Esta primera ejecución es unicamente para crear la base de datos, no se podra iniciar sesion hasta hacer el dump de la base de datos (paso 3)


2) Configurar cadena de conexión (importante)
Abrir el archivo AcademiaAPI/appsettings.json y ajustar la clave ConnectionStrings:DefaultConnection al servidor y base de datos restaurada.
El nombre del servidor lo podemos ver dentro de SQL Server, y debemos ponerlo en el connection string.

3) Ejecutar Dump de la base de datos (AcademiaDB.sql)

Copiar el código del dump de la base de datos, que se puede encontrar en el repositorio, pegarlo en SQLServer y ejecutarlo para crear los datos de prueba.

4) Compilar y ejecutar proyecto Academia
Primero debemos configurar los proyectos de inicio, dando click derecho sobre la solución. Debemos configurar como proyecto de inicio a los siguientes 3 proyectos:
AcademiaAPI
WindowsFormsCurso
BlazorWebAssembly
Luego le vamos a dar al F5, o al botón de compilar en el IDE.

## Flujo de prueba sugerido
  1. Consultar materias y comisiones.
  2. Consultar cursos asociados.
  3. Inscribir alumno en un curso y verificar estado.

## Buenas prácticas y notas
- Actualizar las cadenas de conexión antes de correr la API.
- Revisar Program.cs para ver configuración de CORS y puertos.
