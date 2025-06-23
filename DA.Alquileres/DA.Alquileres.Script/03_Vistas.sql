CREATE VIEW visUSUARIOS
AS
	SELECT u.Id
		  ,u.Codigo
		  ,u.Nombre
		  ,u.Paterno
		  ,u.Materno
		  ,u.Correo
		  ,u.Clave
		  ,u.IdTipoUsuario
		  ,tu.Nombre 'TipoUsuario'
		  ,u.IdtipoDocumento
		  ,td.Nombre 'TipoDocumento'
		  ,u.NumeroDocumento
		  ,u.Direccion
		  ,u.Telefono
		  ,u.FechaCreacion
		  ,u.FechaModificacion
		  ,u.FechaDesactivacion
	  FROM dbALQUILERES.dbo.tabUSUARIOS u inner join tabTIPO_USUARIOS tu
				on u.IdTipoUsuario = tu.Id
			inner join tabTIPO_DOCUMENTOS td
				on u.IdtipoDocumento = td.Id
go
