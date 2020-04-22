CREATE TABLE [dbo].[Incidencias] (
    [IdIncidencia]      INT             IDENTITY (1, 1) NOT NULL,
    [IdUsuario]         INT             NOT NULL,
    [Categoria]         VARCHAR (25)    NOT NULL,
    [Empresa]           VARCHAR (50)    NOT NULL,
    [Provincia]         VARCHAR (50)    NOT NULL,
    [Canton]            VARCHAR (50)    NOT NULL,
    [Distrito]          VARCHAR (50)    NOT NULL,
    [DireccionExacta]   VARCHAR (500)   NOT NULL,
    [Latitud]           DECIMAL (12, 9) NOT NULL,
    [Longitud]          DECIMAL (12, 9) NOT NULL,
    [RutaImagen1]       VARCHAR (MAX)   NOT NULL,
    [RutaImagen2]       VARCHAR (MAX)   NOT NULL,
    [RutaImagen3]       VARCHAR (MAX)   NOT NULL,
    [RutaImagen4]       VARCHAR (MAX)   NOT NULL,
    [DetalleIncidencia] VARCHAR (500)   NOT NULL,
    [Estado]            CHAR (1)        NOT NULL
);

