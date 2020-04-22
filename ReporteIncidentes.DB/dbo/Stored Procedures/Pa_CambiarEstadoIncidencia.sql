
CREATE PROCEDURE [dbo].[Pa_CambiarEstadoIncidencia]
	@IdIncidencia INT,
	@EstadoIncidencia CHAR
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION ActualizarIncidencia
			
			UPDATE Incidencias
			SET Estado=@EstadoIncidencia
			WHERE IdIncidencia=@IdIncidencia

		COMMIT TRANSACTION ActualizarIncidencia

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
		WHERE IdIncidencia=@IdIncidencia
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION ActualizarIncidencia
		DECLARE @mensajeError VARCHAR(4000);  
		DECLARE @severidadError INT;  
		DECLARE @estadoError INT;  

		 SELECT   
			@mensajeError = ERROR_MESSAGE(),  
			@severidadError = ERROR_SEVERITY(),  
			@estadoError = ERROR_STATE(); 

		RAISERROR (@mensajeError, 
				   @severidadError,  
				   @estadoError);
	END CATCH
END