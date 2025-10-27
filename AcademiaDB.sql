

-- Especialidades
INSERT INTO Especialidades (IdEspecialidad, Descripcion) VALUES (1, 'Especialidad básica');
INSERT INTO Especialidades (IdEspecialidad, Descripcion) VALUES (2, 'Especialidad avanzada');

-- Planes
INSERT INTO Planes (IdPlan, Descripcion, IdEspecialidad) VALUES (1, 'Plan básico', 1);
INSERT INTO Planes (IdPlan, Descripcion, IdEspecialidad) VALUES (2, 'Plan avanzado', 2);

-- Comisiones
INSERT INTO Comisiones (IdComision, Descripcion, AnioEspecialidad, IdPlan) VALUES (1, 'Comisión A', 2023, 1);
INSERT INTO Comisiones (IdComision, Descripcion, AnioEspecialidad, IdPlan) VALUES (2, 'Comisión B', 2024, 2);

-- Materias 
INSERT INTO Materias (IdMateria, Descripcion, HsSemanales, HsTotales, IdPlan) VALUES (1, 'Matemática', 4, 64, 1);
INSERT INTO Materias (IdMateria, Descripcion, HsSemanales, HsTotales, IdPlan) VALUES (2, 'Programación', 6, 96, 2);

-- Personas 
INSERT INTO Personas (IdPersona, Apellido, Direccion, Email, FechaNacimiento, Legajo, Telefono, TipoPersona, IdPlan)
VALUES (1, 'Admin', 'Admin 123', 'admin@gmail.com', '2004-03-03', 1234, '3419999999', 'Administrador', 1);

INSERT INTO Personas (IdPersona, Apellido, Direccion, Email, FechaNacimiento, Legajo, Telefono, TipoPersona, IdPlan)
VALUES (2, 'Profe1', 'Profe1 123', 'profe1@gmail.com', '1980-05-10', 2001, '3411111111', 'Docente', 1);

INSERT INTO Personas (IdPersona, Apellido, Direccion, Email, FechaNacimiento, Legajo, Telefono, TipoPersona, IdPlan)
VALUES (3, 'Profe2', 'Profe2 123', 'profe2@gmail.com', '1982-07-15', 2002, '3412222222', 'Docente', 2);

INSERT INTO Personas (IdPersona, Apellido, Direccion, Email, FechaNacimiento, Legajo, Telefono, TipoPersona, IdPlan)
VALUES (4, 'Alumno1', 'Alumno1 123', 'alumno1@gmail.com', '2005-01-01', 3001, '3413333333', 'Alumno', 1);

INSERT INTO Personas (IdPersona, Apellido, Direccion, Email, FechaNacimiento, Legajo, Telefono, TipoPersona, IdPlan)
VALUES (5, 'Alumno2', 'Alumno2 123', 'alumno2@gmail.com', '2005-02-02', 3002, '3414444444', 'Alumno', 2);

INSERT INTO Personas (IdPersona, Apellido, Direccion, Email, FechaNacimiento, Legajo, Telefono, TipoPersona, IdPlan)
VALUES (6, 'Alumno3', 'Alumno3 123', 'alumno3@gmail.com', '2005-03-03', 3003, '3415555555', 'Alumno', 2);

-- Usuarios 
INSERT INTO Usuarios (IdUsuario, Apellido, Nombre, Clave, Email, Habilitado, NombreUsuario, IdPersona)
VALUES (1, 'Admin', 'Admin', '123', 'admin@gmail.com', 1, 'admin', 1);

INSERT INTO Usuarios (IdUsuario, Apellido, Nombre, Clave, Email, Habilitado, NombreUsuario, IdPersona)
VALUES (2, 'Profe1', 'Profe1', '123', 'profe1@gmail.com', 1, 'profe1', 2);

INSERT INTO Usuarios (IdUsuario, Apellido, Nombre, Clave, Email, Habilitado, NombreUsuario, IdPersona)
VALUES (3, 'Profe2', 'Profe2', '123', 'profe2@gmail.com', 1, 'profe2', 3);

INSERT INTO Usuarios (IdUsuario, Apellido, Nombre, Clave, Email, Habilitado, NombreUsuario, IdPersona)
VALUES (4, 'Alumno1', 'Alumno1', '123', 'alumno1@gmail.com', 1, 'alumno1', 4);

INSERT INTO Usuarios (IdUsuario, Apellido, Nombre, Clave, Email, Habilitado, NombreUsuario, IdPersona)
VALUES (5, 'Alumno2', 'Alumno2', '123', 'alumno2@gmail.com', 1, 'alumno2', 5);

INSERT INTO Usuarios (IdUsuario, Apellido, Nombre, Clave, Email, Habilitado, NombreUsuario, IdPersona)
VALUES (6, 'Alumno3', 'Alumno3', '123', 'alumno3@gmail.com', 1, 'alumno3', 6);

-- Cursos 
INSERT INTO Cursos (IdCurso, Descripcion, AnioCalendario, Cupo, IdMateria, IdComision)
VALUES (1, 'Curso Matemática 2023', 2023, 30, 1, 1);

INSERT INTO Cursos (IdCurso, Descripcion, AnioCalendario, Cupo, IdMateria, IdComision)
VALUES (2, 'Curso Programación 2024', 2024, 25, 2, 2);

INSERT INTO Cursos (IdCurso, Descripcion, AnioCalendario, Cupo, IdMateria, IdComision)
VALUES (3, 'Curso Matemática Avanzada', 2024, 20, 1, 2);

-- Inscripción de alumno 
INSERT INTO AlumnosInscripciones (IdInscripcion, Condicion, Nota, IdAlumno, IdCurso)
VALUES (1, 'Cursando', NULL, 4, 1);

-- DocenteCurso
INSERT INTO DocentesCursos (Cargo, IdDocente, IdCurso)
VALUES ("Teoria",2, 1);

INSERT INTO DocentesCursos (Cargo, IdDocente, IdCurso)
VALUES ("Teoria",2, 2);

INSERT INTO DocentesCursos (Cargo, IdDocente, IdCurso)
VALUES ("Practica", 3, 3);