CREATE TABLE IF NOT EXISTS usuarios (
	id INTEGER PRIMARY KEY AUTOINCREMENT,
	nombre TEXT NOT NULL,
	apellido TEXT NOT NULL,
	rol TEXT NOT NULL CHECK (rol IN ('Administrador', 'Técnico', 'Usuario')),
	genero TEXT NOT NULL CHECK (genero IN ('Hombre', 'Mujer')),
	departamento TEXT,
	numero TEXT,
	correo TEXT NOT NULL UNIQUE,
	contrasena TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS departamentos (
	id INTEGER PRIMARY KEY AUTOINCREMENT,
	nombre TEXT NOT NULL UNIQUE,
	miembros TEXT
);

CREATE TABLE IF NOT EXISTS incidencias (
	id INTEGER PRIMARY KEY AUTOINCREMENT,
	titulo TEXT NOT NULL,
	descripcion TEXT NOT NULL,
	categoria TEXT,
	id_categoria INTEGER,
	prioridad TEXT NOT NULL CHECK (prioridad IN ('Baja', 'Media', 'Alta')),
	estado TEXT NOT NULL DEFAULT 'Pendiente',
	responsable TEXT,
	id_usuario INTEGER,
	usuario_reportero TEXT,
	id_tecnico INTEGER,
	fecha_creacion TEXT NOT NULL DEFAULT (date('now')),
	fecha_cierre TEXT
);

CREATE TABLE IF NOT EXISTS categorias (
	id INTEGER PRIMARY KEY AUTOINCREMENT,
	nombre TEXT NOT NULL UNIQUE,
	descripcion TEXT,
	activo INTEGER NOT NULL DEFAULT 1,
	cantidad_incidencias INTEGER NOT NULL DEFAULT 0
);

CREATE TABLE IF NOT EXISTS slas (
	id INTEGER PRIMARY KEY AUTOINCREMENT,
	nombre TEXT NOT NULL,
	tiempo_primera_respuesta_horas INTEGER NOT NULL,
	tiempo_resolucion_horas INTEGER NOT NULL,
	descripcion TEXT NOT NULL
);