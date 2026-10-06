CREATE DATABASE GymsystemDB;
GO

USE GymsystemDB;
GO

/* =====================================================
   USUARIOS
===================================================== */
CREATE TABLE Usuarios
(
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Usuario VARCHAR(50) NOT NULL,
    ClaveHash VARCHAR(255) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,

    CONSTRAINT UQ_Usuarios_Usuario
        UNIQUE (Usuario)
);
GO


/* =====================================================
   CLIENTES
===================================================== */
CREATE TABLE Clientes
(
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    NumeroCedula VARCHAR(20) NOT NULL,
    Correo VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20),
    Direccion VARCHAR(200),
    FechaNacimiento DATE,
    Activo BIT NOT NULL DEFAULT 1,

    CONSTRAINT UQ_Clientes_Cedula
        UNIQUE (NumeroCedula),

    CONSTRAINT UQ_Clientes_Correo
        UNIQUE (Correo)
);
GO


/* =====================================================
   PLANES
===================================================== */
CREATE TABLE Planes
(
    IdPlan INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    DuracionDias INT NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Descripcion VARCHAR(250),
    Activo BIT NOT NULL DEFAULT 1,

    CONSTRAINT CK_Planes_Duracion
        CHECK (DuracionDias > 0),

    CONSTRAINT CK_Planes_Precio
        CHECK (Precio > 0)
);
GO


/* =====================================================
   INSCRIPCIONES
===================================================== */
CREATE TABLE Inscripciones
(
    IdInscripcion INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL,
    IdPlan INT NOT NULL,
    FechaInicio DATE NOT NULL DEFAULT GETDATE(),
    FechaFin DATE NOT NULL,
    Estado VARCHAR(20) NOT NULL DEFAULT 'Activa',

    CONSTRAINT CK_Inscripciones_Estado
        CHECK (Estado IN ('Activa', 'Vencida', 'Cancelada')),

    CONSTRAINT FK_Inscripciones_Clientes
        FOREIGN KEY (IdCliente)
        REFERENCES Clientes(IdCliente),

    CONSTRAINT FK_Inscripciones_Planes
        FOREIGN KEY (IdPlan)
        REFERENCES Planes(IdPlan)
);
GO


/* =====================================================
   PAGOS
===================================================== */
CREATE TABLE Pagos
(
    IdPago INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL,
    IdInscripcion INT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    Fecha DATE NOT NULL DEFAULT GETDATE(),
    MetodoPago VARCHAR(20) NOT NULL,

    CONSTRAINT CK_Pagos_Monto
        CHECK (Monto > 0),

    CONSTRAINT CK_Pagos_Metodo
        CHECK (MetodoPago IN
        ('Efectivo', 'Tarjeta', 'Transferencia')),

    CONSTRAINT FK_Pagos_Clientes
        FOREIGN KEY (IdCliente)
        REFERENCES Clientes(IdCliente),

    CONSTRAINT FK_Pagos_Inscripciones
        FOREIGN KEY (IdInscripcion)
        REFERENCES Inscripciones(IdInscripcion)
);
GO