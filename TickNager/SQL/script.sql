CREATE TABLE usuarios (
	id INTEGER PRIMARY KEY,
	nombre TEXT NOT NULL,
	apellido TEXT NOT NULL,
	rol TEXT NOT NULL,
	departamento TEXT NOT NULL,
	numero TEXT NULL,
	correo TEXT NOT NULL,
	contrasena TEXT NOT NULL
); 

CREATE TABLE departamentos (
	id INTEGER PRIMARY KEY,
	nombre TEXT NOT NULL,
	miembros TEXT NULL,
); 

CREATE TABLE incidencias (
	id INTEGER PRIMARY KEY,
	titulo TEXT NOT NULL,
	descripcion TEXT NOT NULL,
	estado BOOLEAN NOT NULL,
	responsable TEXT NOT NULL,
	usuario_reportero TEXT NOT NULL,
	fecha_creacion TEXT NOT NULL
); 