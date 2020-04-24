
CREATE PROCEDURE [dbo].[Pa_InsertarIncidencia]
	@IdUsuario INT,
	@Categoria VARCHAR(25),
	@Empresa VARCHAR(50),
	@Provincia VARCHAR(50),
	@Canton VARCHAR(50),
	@Distrito VARCHAR(50),
	@DireccionExacta VARCHAR(500),	
	@Latitud DECIMAL(12,9),
	@Longitud DECIMAL(12,9),
	@RutaImagen1 VARCHAR(MAX),
	@RutaImagen2 VARCHAR(MAX),
	@RutaImagen3 VARCHAR(MAX),
	@RutaImagen4 VARCHAR(MAX),
	@DetalleIncidencia VARCHAR (500)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION InsertarUsuario
			
			INSERT INTO Incidencias(
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
			)
			VALUES(
				@IdUsuario,
				@Categoria,
				@Empresa,
				@Provincia,
				@Canton,
				@Distrito,
				@DireccionExacta,	
				@Latitud,
				@Longitud,
				@RutaImagen1,
				@RutaImagen2,
				@RutaImagen3,
				@RutaImagen4,
				@DetalleIncidencia,
				'R'
			)

		COMMIT TRANSACTION InsertarUsuario
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION InsertarUsuario
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