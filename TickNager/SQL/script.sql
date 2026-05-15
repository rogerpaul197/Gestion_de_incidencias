CREATE TABLE roles (
    id_rol INTEGER PRIMARY KEY AUTOINCREMENT,
    nombre TEXT NOT NULL UNIQUE
);

CREATE TABLE departamentos (
    id_departamento INTEGER PRIMARY KEY AUTOINCREMENT,
    nombre TEXT NOT NULL UNIQUE
);

CREATE TABLE usuarios (
    id_usuario INTEGER PRIMARY KEY AUTOINCREMENT,
    nombre TEXT NOT NULL,
    apellido TEXT NOT NULL,
    genero TEXT NOT NULL CHECK (genero IN ('Hombre', 'Mujer')),
    numero TEXT,
    correo TEXT NOT NULL UNIQUE,
    contrasena TEXT NOT NULL,
    id_rol INTEGER NOT NULL,
    id_departamento INTEGER,

    FOREIGN KEY (id_rol) REFERENCES roles(id_rol),
    FOREIGN KEY (id_departamento) REFERENCES departamentos(id_departamento)
);

CREATE TABLE categorias (
    id_categoria INTEGER PRIMARY KEY AUTOINCREMENT,
    nombre TEXT NOT NULL UNIQUE,
    descripcion TEXT,
    activo INTEGER NOT NULL DEFAULT 1,
    cantidad_incidencias INTEGER NOT NULL DEFAULT 0
);

CREATE TABLE incidencias (
    id_incidencia INTEGER PRIMARY KEY AUTOINCREMENT,
    titulo TEXT NOT NULL,
    descripcion TEXT NOT NULL,
    prioridad TEXT NOT NULL CHECK (prioridad IN ('Baja', 'Media', 'Alta')),
    estado TEXT NOT NULL DEFAULT 'Pendiente',
    fecha_creacion TEXT NOT NULL DEFAULT (date('now')),
    fecha_cierre TEXT,
    id_reportero INTEGER NOT NULL,
    id_tecnico INTEGER,
    id_categoria INTEGER,

    FOREIGN KEY (id_reportero) REFERENCES usuarios(id_usuario),
    FOREIGN KEY (id_tecnico) REFERENCES usuarios(id_usuario),
    FOREIGN KEY (id_categoria) REFERENCES categorias(id_categoria)
);

CREATE TABLE notificaciones (
    id_notificacion INTEGER PRIMARY KEY AUTOINCREMENT,
    mensaje TEXT NOT NULL,
    leido INTEGER NOT NULL DEFAULT 0,
    fecha TEXT NOT NULL DEFAULT (datetime('now')),
    id_usuario INTEGER NOT NULL,

    FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario)
);

CREATE TABLE comentarios (
    id_comentario INTEGER PRIMARY KEY AUTOINCREMENT,
    id_incidencia INTEGER NOT NULL,
    usuario TEXT NOT NULL,
    mensaje TEXT NOT NULL,
    fecha TEXT NOT NULL,

    FOREIGN KEY (id_incidencia)
    REFERENCES incidencias(id_incidencia)
);

-- INSERTS de pruebas
-- Por defecto cómo será el primer departamento ya creado, el ID será 1, este ID se le asignará en el campo id_departamento de la tabla de usuarios
INSERT INTO departamentos (nombre) VALUES ('Sistemas');

INSERT INTO roles (nombre) VALUES ('Administrador'), ('Técnico'), ('Usuario');

/* 
Esto será el usuario Administrador de prueba para poder trabajar con el sistema.
Credenciales para el inicio de sesión:
Correo: roger@gmail
Contraseña: tigrebailarin123
Para insertar la contraseña ya hasheada, se usó una herramienta web qué es un generador de contraseñas hasheadas usando SHA256 Base64
*/
INSERT INTO usuarios (nombre, apellido, genero, numero, correo, contrasena, id_rol, id_departamento) 
VALUES ('Royer', 'Cerna', 'Hombre', '612345678', 'roger@gmail.com', 'c6RN4GG5LSUBa92pbypwXmR3RIyXo4J2pn7w5Fwn7oU=', 1, 1);