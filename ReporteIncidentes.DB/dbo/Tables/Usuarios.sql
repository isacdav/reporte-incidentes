CREATE TABLE [dbo].[Usuarios] (
    [IdUsuario]         INT           IDENTITY (1, 1) NOT NULL,
    [Cedula]            VARCHAR (10)  NOT NULL,
    [Nombre]            VARCHAR (100) NOT NULL,
    [Apellidos]         VARCHAR (100) NOT NULL,
    [Provincia]         VARCHAR (50)  NOT NULL,
    [Direccion]         VARCHAR (500) NOT NULL,
    [CorreoElectronico] VARCHAR (100) NOT NULL,
    [Telefono]          VARCHAR (15)  NOT NULL,
    [Contrasena]        VARCHAR (200) NOT NULL,
    [EstadoUsuario]     CHAR (1)      NOT NULL,
    [CodigoActivacion]  INT           NOT NULL,
    CONSTRAINT [PK_URN_Correo] PRIMARY KEY CLUSTERED ([CorreoElectronico] ASC) WITH (IGNORE_DUP_KEY = ON)
);

