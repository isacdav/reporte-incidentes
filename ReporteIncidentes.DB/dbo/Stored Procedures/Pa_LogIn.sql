
CREATE PROCEDURE [dbo].[Pa_LogIn]
	@Contrasena VARCHAR(50), 	
	@CorreoElectronico VARCHAR(100)
AS
BEGIN
	SELECT
		IdUsuario,
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
	FROM Usuarios
	WHERE CorreoElectronico=@CorreoElectronico 
	AND Contrasena=@Contrasena
END