CREATE TABLE usuarios (
	id INTEGER PRIMARY KEY,
	nombre TEXT NOT NULL,
	apellido TEXT NOT NULL,
	rol TEXT NOT NULL CHECK (rol IN ('Administrador', 'Técnico', 'Usuario')),
	departamento TEXT NOT NULL,
	genero TEXT NOT NULL CHECK (genero IN ('Hombre', 'Mujer')),
	numero TEXT NULL,
	correo TEXT NOT NULL UNIQUE,
	contrasena TEXT NOT NULL
);

CREATE TABLE departamentos (
	id INTEGER PRIMARY KEY,
	nombre TEXT NOT NULL UNIQUE,
	miembros TEXT NULL
);

CREATE TABLE incidencias (
	id INTEGER PRIMARY KEY,
	titulo TEXT NOT NULL,
	descripcion TEXT NOT NULL,
	estado BOOLEAN NOT NULL,
	responsable TEXT NOT NULL,
	usuario_reportero TEXT NOT NULL,
	fecha_creacion TEXT NOT NULL,
	fecha_cierre TEXT NULL
);

CREATE TABLE slas (
	id INTEGER PRIMARY KEY,
	nombre TEXT NOT NULL,
	tiempo_primera_respuesta_horas INT NOT NULL,
	tiempo_resolucion_horas INT NOT NULL,
	descripcion TEXT NOT NULL
);