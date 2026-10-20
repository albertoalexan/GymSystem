SET NOCOUNT ON;
SET XACT_ABORT ON;

-- Verificar que estamos trabajando sobre la base de datos correcta.
IF DB_NAME() <> N'GymsystemDB'
BEGIN
    THROW 51000, 'La base de datos seleccionada no es GymsystemDB.', 1;
END;

-- No continuar si faltan tablas o si otro proceso ya creó el historial.
IF OBJECT_ID(N'dbo.Clientes', N'U') IS NULL
    OR OBJECT_ID(N'dbo.Planes', N'U') IS NULL
    OR OBJECT_ID(N'dbo.Inscripciones', N'U') IS NULL
    OR OBJECT_ID(N'dbo.Pagos', N'U') IS NULL
    OR OBJECT_ID(N'dbo.Usuarios', N'U') IS NULL
BEGIN
    THROW 51001, 'Falta alguna de las cinco tablas esperadas.', 1;
END;

IF OBJECT_ID(N'dbo.__EFMigrationsHistory', N'U') IS NOT NULL
BEGIN
    THROW 51002, 'Ya existe __EFMigrationsHistory. Se cancela para evitar un registro duplicado.', 1;
END;

BEGIN TRY
    BEGIN TRANSACTION;

    ------------------------------------------------------------
    -- 1. CLIENTES: convertir restricciones UNIQUE en índices.
    ------------------------------------------------------------

    IF EXISTS
    (
        SELECT 1
        FROM sys.key_constraints
        WHERE parent_object_id = OBJECT_ID(N'dbo.Clientes')
          AND name = N'UQ_Clientes_Cedula'
          AND type = 'UQ'
    )
    BEGIN
        ALTER TABLE dbo.Clientes
            DROP CONSTRAINT UQ_Clientes_Cedula;
    END
    ELSE IF NOT EXISTS
    (
        SELECT 1
        FROM sys.indexes
        WHERE object_id = OBJECT_ID(N'dbo.Clientes')
          AND name = N'UQ_Clientes_Cedula'
          AND is_unique = 1
          AND is_disabled = 0
    )
    BEGIN
        THROW 51003, 'No se encontró la restricción o índice único de cédula esperado.', 1;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.indexes
        WHERE object_id = OBJECT_ID(N'dbo.Clientes')
          AND name = N'UQ_Clientes_Cedula'
          AND is_unique = 1
          AND is_disabled = 0
    )
    BEGIN
        CREATE UNIQUE INDEX UQ_Clientes_Cedula
            ON dbo.Clientes (NumeroCedula);
    END;

    IF EXISTS
    (
        SELECT 1
        FROM sys.key_constraints
        WHERE parent_object_id = OBJECT_ID(N'dbo.Clientes')
          AND name = N'UQ_Clientes_Correo'
          AND type = 'UQ'
    )
    BEGIN
        ALTER TABLE dbo.Clientes
            DROP CONSTRAINT UQ_Clientes_Correo;
    END
    ELSE IF NOT EXISTS
    (
        SELECT 1
        FROM sys.indexes
        WHERE object_id = OBJECT_ID(N'dbo.Clientes')
          AND name = N'UQ_Clientes_Correo'
          AND is_unique = 1
          AND is_disabled = 0
    )
    BEGIN
        THROW 51004, 'No se encontró la restricción o índice único de correo esperado.', 1;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.indexes
        WHERE object_id = OBJECT_ID(N'dbo.Clientes')
          AND name = N'UQ_Clientes_Correo'
          AND is_unique = 1
          AND is_disabled = 0
    )
    BEGIN
        CREATE UNIQUE INDEX UQ_Clientes_Correo
            ON dbo.Clientes (Correo);
    END;

    ------------------------------------------------------------
    -- 2. USUARIOS: mantener la unicidad del nombre de usuario.
    ------------------------------------------------------------

    IF EXISTS
    (
        SELECT 1
        FROM sys.key_constraints
        WHERE parent_object_id = OBJECT_ID(N'dbo.Usuarios')
          AND name = N'UQ_Usuarios_Usuario'
          AND type = 'UQ'
    )
    BEGIN
        ALTER TABLE dbo.Usuarios
            DROP CONSTRAINT UQ_Usuarios_Usuario;
    END
    ELSE IF NOT EXISTS
    (
        SELECT 1
        FROM sys.indexes
        WHERE object_id = OBJECT_ID(N'dbo.Usuarios')
          AND name = N'UQ_Usuarios_Usuario'
          AND is_unique = 1
          AND is_disabled = 0
    )
    BEGIN
        THROW 51005, 'No se encontró la restricción o índice único de usuario esperado.', 1;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.indexes
        WHERE object_id = OBJECT_ID(N'dbo.Usuarios')
          AND name = N'UQ_Usuarios_Usuario'
          AND is_unique = 1
          AND is_disabled = 0
    )
    BEGIN
        CREATE UNIQUE INDEX UQ_Usuarios_Usuario
            ON dbo.Usuarios (Usuario);
    END;

    ------------------------------------------------------------
    -- 3. CREAR LOS ÍNDICES DE CLAVES FORÁNEAS QUE FALTAN.
    ------------------------------------------------------------

    IF NOT EXISTS
    (
        SELECT 1 FROM sys.indexes
        WHERE object_id = OBJECT_ID(N'dbo.Inscripciones')
          AND name = N'IX_Inscripciones_IdCliente'
    )
    BEGIN
        CREATE INDEX IX_Inscripciones_IdCliente
            ON dbo.Inscripciones (IdCliente);
    END;

    IF NOT EXISTS
    (
        SELECT 1 FROM sys.indexes
        WHERE object_id = OBJECT_ID(N'dbo.Inscripciones')
          AND name = N'IX_Inscripciones_IdPlan'
    )
    BEGIN
        CREATE INDEX IX_Inscripciones_IdPlan
            ON dbo.Inscripciones (IdPlan);
    END;

    IF NOT EXISTS
    (
        SELECT 1 FROM sys.indexes
        WHERE object_id = OBJECT_ID(N'dbo.Pagos')
          AND name = N'IX_Pagos_IdCliente'
    )
    BEGIN
        CREATE INDEX IX_Pagos_IdCliente
            ON dbo.Pagos (IdCliente);
    END;

    IF NOT EXISTS
    (
        SELECT 1 FROM sys.indexes
        WHERE object_id = OBJECT_ID(N'dbo.Pagos')
          AND name = N'IX_Pagos_IdInscripcion'
    )
    BEGIN
        CREATE INDEX IX_Pagos_IdInscripcion
            ON dbo.Pagos (IdInscripcion);
    END;

    ------------------------------------------------------------
    -- 4. CREAR EL HISTORIAL DE MIGRACIONES DE EF CORE.
    ------------------------------------------------------------

    IF OBJECT_ID(N'dbo.__EFMigrationsHistory', N'U') IS NOT NULL
    BEGIN
        THROW 51006, 'El historial de migraciones ya existe.', 1;
    END;

    CREATE TABLE dbo.__EFMigrationsHistory
    (
        MigrationId nvarchar(150) NOT NULL,
        ProductVersion nvarchar(32) NOT NULL,
        CONSTRAINT PK___EFMigrationsHistory
            PRIMARY KEY (MigrationId)
    );

    ------------------------------------------------------------
    -- 5. REGISTRAR LA MIGRACIÓN SIN EJECUTAR SU MÉTODO Up.
    ------------------------------------------------------------

    INSERT INTO dbo.__EFMigrationsHistory
        (MigrationId, ProductVersion)
    VALUES
        (N'20261020201752_InitialCreate', N'10.0.13');

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
    BEGIN
        ROLLBACK TRANSACTION;
    END;

    THROW;
END CATCH;

------------------------------------------------------------
-- COMPROBACIÓN FINAL.
------------------------------------------------------------

SELECT
    MigrationId,
    ProductVersion
FROM dbo.__EFMigrationsHistory;

SELECT
    OBJECT_NAME(i.object_id) AS Tabla,
    i.name AS Indice,
    i.is_unique AS EsUnico
FROM sys.indexes AS i
WHERE i.name IN
(
    N'UQ_Clientes_Cedula',
    N'UQ_Clientes_Correo',
    N'UQ_Usuarios_Usuario',
    N'IX_Inscripciones_IdCliente',
    N'IX_Inscripciones_IdPlan',
    N'IX_Pagos_IdCliente',
    N'IX_Pagos_IdInscripcion'
)
ORDER BY Tabla, Indice;
