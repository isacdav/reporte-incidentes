
CREATE PROCEDURE [dbo].[Pa_ConsultarUsuario]	
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
END