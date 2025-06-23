-- Descripción general de la tabla
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Tabla que almacena los diferentes tipos de usuarios del sistema (roles o perfiles).',
    @level0type = N'SCHEMA',  @level0name = 'dbo',
    @level1type = N'TABLE',   @level1name = 'tabTIPO_USUARIOS';

-- Campo: Id
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Identificador único del tipo de usuario. Clave primaria autoincremental.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabTIPO_USUARIOS',
    @level2type = N'COLUMN', @level2name = 'Id';

-- Campo: Abreviatura
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Abreviatura única que representa el tipo de usuario (por ejemplo, ADM, CLI, etc.).',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabTIPO_USUARIOS',
    @level2type = N'COLUMN', @level2name = 'Abreviatura';

-- Campo: Nombre
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Nombre completo o formal del tipo de usuario.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabTIPO_USUARIOS',
    @level2type = N'COLUMN', @level2name = 'Nombre';

-- Campo: Descripcion
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Descripción detallada del tipo de usuario o su función en el sistema.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabTIPO_USUARIOS',
    @level2type = N'COLUMN', @level2name = 'Descripcion';

-- Campo: FechaCreacion
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Fecha en la que se creó el registro del tipo de usuario.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabTIPO_USUARIOS',
    @level2type = N'COLUMN', @level2name = 'FechaCreacion';

-- Campo: FechaModificacion
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Fecha de la última modificación del registro.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabTIPO_USUARIOS',
    @level2type = N'COLUMN', @level2name = 'FechaModificacion';

-- Campo: FechaDesactivacion
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Fecha en la que se desactivó el tipo de usuario, si corresponde.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabTIPO_USUARIOS',
    @level2type = N'COLUMN', @level2name = 'FechaDesactivacion';
