-- Especialidades
SET IDENTITY_INSERT Especialidades ON;
INSERT INTO Especialidades (IdEspecialidad, Descripcion) VALUES 
(1, 'Ingeniería en Sistemas'), 
(2, 'Ingeniería Electrónica');
SET IDENTITY_INSERT Especialidades OFF;

-- Planes
SET IDENTITY_INSERT Planes ON;
INSERT INTO Planes (IdPlan, Descripcion, IdEspecialidad) VALUES 
(1, 'Plan 2025', 1), 
(2, 'Plan 2024', 2);
SET IDENTITY_INSERT Planes OFF;

-- Comisiones
SET IDENTITY_INSERT Comisiones ON;
INSERT INTO Comisiones (IdComision, AnioEspecialidad, Descripcion, IdPlan) VALUES 
(1, 1, 'Comisión A', 1), 
(2, 2, 'Comisión B', 2);
SET IDENTITY_INSERT Comisiones OFF;

-- Materias
SET IDENTITY_INSERT Materias ON;
INSERT INTO Materias (IdMateria, Descripcion, HsSemanales, HsTotales, IdPlan) VALUES 
(1, 'Programación', 6, 96, 1),
(2, 'Electrónica Básica', 4, 64, 2);
SET IDENTITY_INSERT Materias OFF;

-- Cursos
SET IDENTITY_INSERT Cursos ON;
INSERT INTO Cursos (IdCurso, IdMateria, IdComision, Descripcion, AnioCalendario, Cupo) VALUES 
(1, 1, 1, 'Programación 1', 2025, 30),
(2, 2, 2, 'Electrónica 1', 2025, 25);
SET IDENTITY_INSERT Cursos OFF;

-- Personas
SET IDENTITY_INSERT Personas ON;
INSERT INTO Personas (IdPersona, Direccion, FechaNacimiento, Legajo, Telefono, TipoPersona, IdPlan) VALUES
(1, 'Italia 123', '1980-01-01', 1001, '111111', 'Administrador', 1),
(2, 'España 456', '1982-02-02', 1002, '111112', 'Administrador', 2),
(3, 'Pte.Roca 789', '1985-03-03', 2001, '222221', 'Docente', 1),
(4, 'Pellegrini 012', '1986-04-04', 2002, '222222', 'Docente', 2),
(5, 'Ayacucho 345', '2000-05-05', 3001, '333331', 'Alumno', 1),
(6, 'Ocampo 678', '2001-06-06', 3002, '333332', 'Alumno', 2),
(7, 'Galvez 901', '2002-07-07', 3003, '333333', 'Alumno', 1);
SET IDENTITY_INSERT Personas OFF;

-- Usuarios
SET IDENTITY_INSERT Usuarios ON;
INSERT INTO Usuarios (IdUsuario, NombreUsuario, Clave, Habilitado, Nombre, Apellido, Email, CambiaClave, IdPersona) VALUES
(1, 'admin', '123', 1, 'Admin', 'Principal', 'admin@gmail.com', 0, 1),
(2, 'admin2', '123', 1, 'Admin', 'Secundario', 'admin2@gmail.com', 0, 2),
(3, 'profe', '123', 1, 'Profe', 'Uno', 'profe@gmail.com', 0, 3),
(4, 'profe2', '123', 1, 'Profe', 'Dos', 'profe2@gmail.com', 0, 4),
(5, 'alumno', '123', 1, 'Alumno', 'Uno', 'alumno@gmail.com', 0, 5),
(6, 'alumno2', '123', 1, 'Alumno', 'Dos', 'alumno2@gmail.com', 0, 6),
(7, 'alumno3', '123', 1, 'Alumno', 'Tres', 'alumno3@gmail.com', 0, 7);
SET IDENTITY_INSERT Usuarios OFF;

-- DocentesCursos (sin campo IdDocenteCurso, solo Cargo, IdCurso, IdDocente)
INSERT INTO DocentesCursos (Cargo, IdCurso, IdDocente) VALUES 
('Docente', 1, 3),
('Practica', 1, 4),
('Docente', 2, 4);

-- AlumnoInscripciones (condición "Cursando", nota NULL)
SET IDENTITY_INSERT AlumnosInscripciones ON;
INSERT INTO AlumnosInscripciones (IdInscripcion, Condicion, Nota, IdCurso, IdAlumno) VALUES 
(1, 'Cursando', NULL, 1, 5),
(2, 'Cursando', NULL, 1, 7),
(3, 'Cursando', NULL, 2, 6);
SET IDENTITY_INSERT AlumnosInscripciones OFF;