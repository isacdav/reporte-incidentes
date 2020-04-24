
CREATE PROCEDURE [dbo].[Pa_ConsultarIncidenciasUsuario]
	@IdUsuario INT	
AS
BEGIN
	IF(@IdUsuario<>0)
	BEGIN
		SELECT 
			IdIncidencia,
			IdUsuario,
			Categoria,
			Empresa,
			Provincia,
			Canton,
			Distrito,
			DireccionExacta,
			Latitud,
			Longitud,
			RutaImagen1,
			RutaImagen2,
			RutaImagen3,
			RutaImagen4,
			DetalleIncidencia,
			Estado
		FROM Incidencias
		WHERE IdUsuario=@IdUsuario
		AND Estado!='F'
	END
	ELSE
	BEGIN
		SELECT 
			IdIncidencia,
			IdUsuario,
			Categoria,
			Empresa,
			Provincia,
			Canton,
			Distrito,
			DireccionExacta,
			Latitud,
			Longitud,
			RutaImagen1,
			RutaImagen2,
			RutaImagen3,
			RutaImagen4,
			DetalleIncidencia,
			Estado
		FROM Incidencias
		WHERE Estado!='F'
	END	
END