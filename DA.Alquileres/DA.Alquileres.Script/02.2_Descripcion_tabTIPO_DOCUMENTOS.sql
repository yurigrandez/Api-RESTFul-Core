-- Descripción general de la tabla
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Tabla que almacena los tipos de documentos de identidad (DNI, RUC, pasaporte, etc.).',
    @level0type = N'SCHEMA',  @level0name = 'dbo',
    @level1type = N'TABLE',   @level1name = 'tabTIPO_DOCUMENTOS';

-- Campo: Id
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Identificador único del tipo de documento. Clave primaria autoincremental.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabTIPO_DOCUMENTOS',
    @level2type = N'COLUMN', @level2name = 'Id';

-- Campo: Abreviatura
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Abreviatura única del tipo de documento (ej. DNI, RUC, PAS).',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabTIPO_DOCUMENTOS',
    @level2type = N'COLUMN', @level2name = 'Abreviatura';

-- Campo: Nombre
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Nombre completo o formal del tipo de documento.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabTIPO_DOCUMENTOS',
    @level2type = N'COLUMN', @level2name = 'Nombre';

-- Campo: Descripcion
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Descripción detallada del tipo de documento.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabTIPO_DOCUMENTOS',
    @level2type = N'COLUMN', @level2name = 'Descripcion';

-- Campo: FechaCreacion
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Fecha en la que se creó el registro del tipo de documento.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabTIPO_DOCUMENTOS',
    @level2type = N'COLUMN', @level2name = 'FechaCreacion';

-- Campo: FechaModificacion
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Fecha de la última modificación del tipo de documento.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabTIPO_DOCUMENTOS',
    @level2type = N'COLUMN', @level2name = 'FechaModificacion';

-- Campo: FechaDesactivacion
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Fecha en la que el tipo de documento fue desactivado, si corresponde.',
    @level0type = N'SCHEMA', @level0name = 'dbo',
    @level1type = N'TABLE',  @level1name = 'tabTIPO_DOCUMENTOS',
    @level2type = N'COLUMN', @level2name = 'FechaDesactivacion';
