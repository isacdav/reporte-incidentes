
CREATE PROCEDURE [dbo].[Pa_ActivarEstadousuario]	
	@CorreoElectronico VARCHAR(100),
	@CodigoActivacion INT
AS
BEGIN
	BEGIN TRY		
		
		IF EXISTS(SELECT 1 FROM Usuarios WHERE CorreoElectronico=@CorreoElectronico )
		BEGIN
			IF EXISTS(SELECT 1 FROM Usuarios WHERE CorreoElectronico=@CorreoElectronico AND CodigoActivacion=@CodigoActivacion )
			BEGIN 
				BEGIN TRANSACTION ModificarEstadoUsuario

					UPDATE Usuarios
					SET EstadoUsuario='A'
					WHERE CorreoElectronico=@CorreoElectronico 
					AND CodigoActivacion=@CodigoActivacion
			
				COMMIT TRANSACTION ModificarEstadoUsuario
			
				SELECT 'Usuario activado correctamente' AS 'Resultado'
			END
			ELSE
			BEGIN
				SELECT 'Código de activacion erroneo' AS 'Resultado'
			END			
		END
		ELSE
		BEGIN
			SELECT 'Usuario no existe' AS 'Resultado'
		END

	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION ModificarEstadoUsuario
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