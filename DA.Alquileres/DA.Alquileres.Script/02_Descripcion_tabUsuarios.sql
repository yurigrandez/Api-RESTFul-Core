EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = N'Información de usuarios del sistema',
    @level0type = N'SCHEMA',  @level0name = 'dbo',
    @level1type = N'TABLE',   @level1name = 'tabUSUARIOS';

-- Descripción por cada columna
EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = N'Identificador único del usuario (PK).',
    @level0type = N'SCHEMA',  @level0name = 'dbo',
    @level1type = N'TABLE',   @level1name = 'tabUSUARIOS',
    @level2type = N'COLUMN',  @level2name = 'Id';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = N'Código único del usuario dentro del sistema.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabUSUARIOS',
    @level2type = N'COLUMN', @level2name = 'Codigo';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = N'Nombres del usuario.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabUSUARIOS',
    @level2type = N'COLUMN', @level2name = 'Nombre';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = N'Apellido paterno del usuario.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabUSUARIOS',
    @level2type = N'COLUMN', @level2name = 'Paterno';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = N'Apellido materno del usuario.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabUSUARIOS',
    @level2type = N'COLUMN', @level2name = 'Materno';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = N'Correo electrónico del usuario.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabUSUARIOS',
    @level2type = N'COLUMN', @level2name = 'Correo';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = N'Contraseña del usuario.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabUSUARIOS',
    @level2type = N'COLUMN', @level2name = 'Clave';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = N'Referencia al tipo de usuario (rol).',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabUSUARIOS',
    @level2type = N'COLUMN', @level2name = 'IdTipoUsuario';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = N'Referencia al tipo de documento de identidad.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabUSUARIOS',
    @level2type = N'COLUMN', @level2name = 'IdtipoDocumento';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = N'Número del documento de identidad del usuario.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabUSUARIOS',
    @level2type = N'COLUMN', @level2name = 'NumeroDocumento';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = N'Dirección física del usuario.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabUSUARIOS',
    @level2type = N'COLUMN', @level2name = 'Direccion';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = N'Teléfono de contacto del usuario.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabUSUARIOS',
    @level2type = N'COLUMN', @level2name = 'Telefono';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = N'Fecha de creación del registro.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabUSUARIOS',
    @level2type = N'COLUMN', @level2name = 'FechaCreacion';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = N'Fecha de la última modificación del registro.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabUSUARIOS',
    @level2type = N'COLUMN', @level2name = 'FechaModificacion';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = N'Fecha en la que el usuario fue desactivado.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabUSUARIOS',
    @level2type = N'COLUMN', @level2name = 'FechaDesactivacion';