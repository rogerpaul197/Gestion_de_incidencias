CREATE TABLE IF NOT EXISTS usuarios (
	id INTEGER PRIMARY KEY,
	nombre TEXT NOT NULL,
	apellido TEXT NOT NULL,
	rol TEXT NOT NULL CHECK (rol IN ('Administrador', 'Técnico', 'Usuario')),
	genero TEXT NOT NULL CHECK (genero IN ('Hombre', 'Mujer')),
	departamento TEXT,
	numero TEXT NULL,
	correo TEXT NOT NULL UNIQUE,
	contrasena TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS departamentos (
	id INTEGER PRIMARY KEY,
	nombre TEXT NOT NULL UNIQUE,
	miembros TEXT NULL
);

CREATE TABLE IF NOT EXISTS incidencias (
	id INTEGER PRIMARY KEY,
	titulo TEXT NOT NULL,
	descripcion TEXT NOT NULL,
	estado BOOLEAN NOT NULL,
	responsable TEXT NOT NULL,
	usuario_reportero TEXT NOT NULL,
	fecha_creacion TEXT NOT NULL,
	fecha_cierre TEXT NULL
);

CREATE TABLE IF NOT EXISTS slas (
	id INTEGER PRIMARY KEY,
	nombre TEXT NOT NULL,
	tiempo_primera_respuesta_horas INT NOT NULL,
	tiempo_resolucion_horas INT NOT NULL,
	descripcion TEXT NOT NULL
);