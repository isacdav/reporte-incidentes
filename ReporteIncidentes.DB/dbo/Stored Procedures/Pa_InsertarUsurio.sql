
CREATE PROCEDURE [dbo].[Pa_InsertarUsurio]
	@Cedula VARCHAR(10), 
	@Nombre VARCHAR(100),
	@Apellidos VARCHAR(100),
	@Provincia VARCHAR(50),
	@Direccion VARCHAR(500),	
	@CorreoElectronico VARCHAR(100),
	@Telefono VARCHAR(15),
	@Contrasena VARCHAR(50),
	@CodigoActvacion INT 
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION InsertarUsuario
			
			INSERT INTO Usuarios(
				Cedula,
				Nombre,
				Apellidos,
				Provincia,
				Direccion,
				CorreoElectronico,
				Telefono,
				Contrasena,
				EstadoUsuario,
				CodigoActivacion
			)
			VALUES(
				@Cedula,
				@Nombre,
				@Apellidos,
				@Provincia,
				@Direccion,
				@CorreoElectronico,
				@Telefono,
				@Contrasena,
				'R',
				@CodigoActvacion
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