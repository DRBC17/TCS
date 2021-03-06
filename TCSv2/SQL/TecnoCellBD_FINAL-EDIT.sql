USE [tempdb]
GO
/****** Object:  Database [TecnoCell]    Script Date: 16/6/2019 11:43:02 AM ******/
CREATE DATABASE [TecnoCell]
GO


USE [TecnoCell]
GO
/****** Object:  Table [dbo].[Acceso]    Script Date: 16/6/2019 11:43:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acceso](
	[Id_Acceso] INT IDENTITY(1,1) NOT NULL
	CONSTRAINT PK_Acceso_Id_Acceso PRIMARY KEY CLUSTERED, 
	[Cargos] [nchar](30) NOT NULL,
	[Fecha] [datetime] NULL DEFAULT GETDATE()
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articulo]    Script Date: 16/6/2019 11:43:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulo](
	[Id_Articulo] INT IDENTITY(1,1) NOT NULL
	CONSTRAINT PK_Articulo_Id_Articulo PRIMARY KEY CLUSTERED, 
	[Codigo] [nchar](10) NOT NULL,
	[Nombre] [nchar](20) NOT NULL,
	[Descripcion] TEXT NULL,
	[Id_Categoria] INT NOT NULL,
	[Fecha] [datetime] NULL DEFAULT GETDATE()
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 16/6/2019 11:43:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id_Categoria] INT IDENTITY(1,1) NOT NULL
	CONSTRAINT PK_Categoria_Id_Categoria PRIMARY KEY CLUSTERED, 
	[Nombre] [nchar](20) NOT NULL,
	[Descripcion] TEXT NULL,
	[Fecha] [datetime] NULL DEFAULT GETDATE()
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 16/6/2019 11:43:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id_Cliente] INT IDENTITY(1,1) NOT NULL
	CONSTRAINT PK_Cliente_Id_Cliente PRIMARY KEY CLUSTERED, 
	[Nombre] [nchar](20) NOT NULL,
	[Apellido] [nchar](20) NOT NULL,
	[Genero] [nchar](20) NOT NULL,
	[Direccion] TEXT NULL,
	[Telefono] [nchar](10) NULL,
	[Correo] [nchar](50) NULL,
	[Fecha_Nacimiento] [datetime] NULL,
	[Fecha] [datetime] NOT NULL DEFAULT GETDATE()
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 16/6/2019 11:43:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Compra](
	[Id_Compra] INT IDENTITY(1,1) NOT NULL
	CONSTRAINT PK_Compra_Id_Compra PRIMARY KEY CLUSTERED, 
	[Id_Proveedor] INT NULL,
	[Id_Comprobante] INT NULL,
	[Serie] [nchar](10) NULL,
	[Id_ISV] INT NULL,
	[Estado] [nchar](20) NULL,
	[Fecha] [datetime] NULL DEFAULT GETDATE()
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comprobante]    Script Date: 16/6/2019 11:43:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comprobante](
	[Id_Comprobante] INT IDENTITY (1,1) NOT NULL
	CONSTRAINT PK_Comprobante_Id_Comprobante PRIMARY KEY CLUSTERED, 
	[Tipo] [nchar](20) NOT NULL,
	[Fecha] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Compra]    Script Date: 16/6/2019 11:43:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[Detalle_Compra](
	[Id_Detalle_Compra] INT IDENTITY(1,1) NOT NULL
	CONSTRAINT PK_Detalle_Compra_Id_Detalle_Compra PRIMARY KEY CLUSTERED,
	[Id_Compra] INT NULL,
	[Id_Articulo] INT NULL,
	[Detalle] [nchar](20) NULL,
	[Precio_Compra] FLOAT NOT NULL,
	[Precio_Venta] FLOAT NOT NULL,
	[Stock] INT NOT NULL,
	[Fecha] [datetime] NULL DEFAULT GETDATE()
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Venta]    Script Date: 16/6/2019 11:43:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE TABLE [dbo].[Detalle_Venta](
	[Id_Detalle_Venta] INT IDENTITY (1,1) NOT NULL
	CONSTRAINT PK_Detalle_Venta_Id_Detalle_Venta PRIMARY KEY CLUSTERED, 
	[Id_Venta] INT NULL,
	[Id_Articulo] INT NOT NULL,
	[Detalle] [nchar](20) NULL,
	[Cantidad] INT NOT NULL,
	[Precio] FLOAT NOT NULL,
	[Descuento] FLOAT NULL,
	[Fecha] [datetime] NULL DEFAULT GETDATE()
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 16/6/2019 11:43:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Empleado](
	[Id_Empleado] INT IDENTITY(1,1) NOT NULL
	CONSTRAINT PK_Empleado_Id_Empleado PRIMARY KEY CLUSTERED, 
	[Nombre] [nchar](20) NOT NULL,
	[Apellido] [nchar](20) NOT NULL,
	[Genero] [nchar](20) NOT NULL,
	[Id_Acceso] INT NULL,
	[Id_Usuario] INT NULL,
	[Fecha] [datetime] NULL
) 
GO
/****** Object:  Table [dbo].[Foto]    Script Date: 16/6/2019 11:43:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[ISV](
	[Id_ISV] INT  IDENTITY (1,1) NOT NULL
	CONSTRAINT PK_ISV_Id_ISV PRIMARY KEY CLUSTERED, 
	[ISV] FLOAT NOT NULL,
	[Fecha] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 16/6/2019 11:43:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[Id_Proveedor] INT IDENTITY (1,1) NOT NULL
	CONSTRAINT PK_Proveedor_Id_Proveedor PRIMARY KEY CLUSTERED, 
	[Nombre] [nchar](20) NOT NULL,
	[Sector_Comercial] [nchar](20) NULL,
	[Tipo_Documento] [nchar](20) NULL,
	[Documento] [nchar](20) NULL,
	[Direccion] [nchar](30) NULL,
	[Telefono] [nchar](10) NULL,
	[Correo] [nchar](30) NULL,
	[Fecha] [datetime] NULL DEFAULT GETDATE()
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 16/6/2019 11:43:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id_Usuario] INT IDENTITY (1,1) NOT NULL
	CONSTRAINT PK_Usuario_Id_Usuario PRIMARY KEY CLUSTERED, 
	[Nombre] [nchar](20) NOT NULL,
	[Contraseña] [nchar](20) NOT NULL,
	[Fecha] [datetime] NULL DEFAULT GETDATE()
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 16/6/2019 11:43:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Venta](
	[Id_Venta] INT IDENTITY (1,1) NOT NULL
	CONSTRAINT PK_Venta_Id_Venta PRIMARY KEY CLUSTERED, 
	[Id_Empleado] INT NULL,
	[Id_Cliente] INT NULL,
	[Id_Comprobante] INT NULL,
	[Serie] [nchar](20) NULL,

	[Id_ISV] INT NULL,
	[Fecha] [datetime] DEFAULT GETDATE()
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Articulo]
	ADD CONSTRAINT FK_Articulo_Id_Categoria$Categoria_Id_Categoria
	FOREIGN KEY ([Id_Categoria]) REFERENCES [dbo].[Categoria]([Id_Categoria])
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
GO


ALTER TABLE [dbo].[Compra]
	ADD CONSTRAINT FK_Compra_Id_Proveedor$Proveedor_Id_Proveedor
	FOREIGN KEY ([Id_Proveedor]) REFERENCES [dbo].[Proveedor]([Id_Proveedor])
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Compra]
	ADD CONSTRAINT FK_Compra_Id_Comprobante$Comprobante_Id_Comprobante
	FOREIGN KEY ([Id_Comprobante]) REFERENCES [dbo].[Comprobante]([Id_Comprobante])
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Detalle_Compra]
	ADD CONSTRAINT FK_Compra_Id_Detalle_Compra$Detalle_Compra_Id_Detalle_Compra
	FOREIGN KEY ([Id_Compra]) REFERENCES [dbo].[Compra]([Id_Compra])
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Compra]
	ADD CONSTRAINT FK_Compra_Id_ISV$ISV_Id_ISV
	FOREIGN KEY ([Id_ISV]) REFERENCES [dbo].[ISV]([Id_ISV])
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
GO


ALTER TABLE [dbo].[Detalle_Compra]
	ADD CONSTRAINT FK_Detalle_Compra_Id_Articulo$Articulo_Id_Articulo
	FOREIGN KEY ([Id_Articulo]) REFERENCES [dbo].[Articulo]([Id_Articulo])
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
GO



ALTER TABLE [dbo].[Detalle_Venta]
	ADD CONSTRAINT FK_Detalle_venta_Id_Articulo$Articulo_Id_Articulo
	FOREIGN KEY ([Id_Articulo]) REFERENCES [dbo].[Articulo]([Id_Articulo])
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
GO




ALTER TABLE [dbo].[Empleado]
	ADD CONSTRAINT FK_Empleado_Id_Acceso$Acceso_Id_Acceso
	FOREIGN KEY ([Id_Acceso]) REFERENCES [dbo].[Acceso]([Id_Acceso])
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Empleado]
	ADD CONSTRAINT FK_Empleado_Id_Usuario$Usuario_Id_Usuario
	FOREIGN KEY ([Id_Usuario]) REFERENCES [dbo].[Usuario]([Id_Usuario])
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Venta]
	ADD CONSTRAINT FK_Venta_Id_Empleado$Empleado_Id_Empleado
	FOREIGN KEY ([Id_Empleado]) REFERENCES [dbo].[Empleado]([Id_Empleado])
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Venta]
	ADD CONSTRAINT FK_Venta_Id_Cliente$Cliente_Id_Cliente
	FOREIGN KEY ([Id_Cliente]) REFERENCES  [dbo].[Cliente]([Id_Cliente])
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Venta]
	ADD CONSTRAINT FK_Venta_Id_Comprobante$Comprobante_Id_Comprobante
	FOREIGN KEY ([Id_Comprobante]) REFERENCES  [dbo].[Comprobante]([Id_Comprobante])
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Detalle_Venta]
	ADD CONSTRAINT FK_Venta_Id_Detalle_Venta$Detalle_Venta_Id_Detalle_Venta
	FOREIGN KEY ([Id_Venta]) REFERENCES  [dbo].[Venta]([Id_Venta])
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Venta]
	ADD CONSTRAINT FK_Venta_Id_ISV$ISV_Id_ISV
	FOREIGN KEY ([Id_ISV]) REFERENCES  [dbo].[ISV]([Id_ISV])
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
GO

--Datos

INSERT INTO Usuario(Nombre,Contraseña,Fecha)
values('JuanH','123456',GETDATE()),
('admin','admin',GETDATE())
GO
INSERT INTO Acceso(Cargos)
VALUES('Cajero')

GO
INSERT INTO Proveedor(Nombre, Sector_Comercial, Tipo_Documento, Documento, Direccion, Telefono, Correo)
VALUES ('Will Lara','Informativo', 'DNI', '000333', 'barrio San Antonio','90032982', 'lwill2897@gmail.com'),
	   ('Danny Cantarero', 'Occidente', 'DNI', '333000', 'Barrio santa Martha', '98832982', 'lwill2897@gmail.com')
GO

INSERT INTO Categoria(Nombre, Descripcion, Fecha)
VALUES ('Samsung', 'S9', GETDATE()),
		('Smart Tv', 'TV PLASMAS', GETDATE())
GO
SELECT *FROM Categoria;
GO

INSERT INTO Articulo(Codigo, Nombre, Descripcion, Id_Categoria, Fecha)
VALUES ('00335566', 'Samsung', 'Samsung Galaxy S9', 1, GETDATE()),
		 ('00445566', 'Smart TV', 'Samsung Smart TV', 2, GETDATE())
GO

INSERT INTO ISV(ISV, Fecha)
VALUES ('0.15', GETDATE())
GO

INSERT INTO Comprobante(Tipo, Fecha)
VALUES ('Factura', GETDATE()),
	   ('Digital', GETDATE()),
	   ('Ninguno', GETDATE())
	   
GO

SELECT *FROM ISV;
GO
SELECT * FROM Acceso
GO
SELECT * FROM Empleado
GO
SELECT * FROM Usuario
GO
SELECT a.Cargos FROM Empleado b  INNER JOIN Acceso a  
ON b.Id_Acceso=a.Id_Acceso INNER JOIN Usuario c ON b.Id_Empleado=c.Id_Usuario
WHERE b.Id_Empleado=1
	
select * from Empleado
SELECT Nombre,Contraseña FROM Usuario
GO


SELECT c.Cargos FROM Acceso c INNER JOIN Empleado b ON c.Id_Acceso=b.Id_Acceso INNER JOIN Usuario a ON b.Id_Empleado=a.Id_Usuario WHERE a.Nombre='DannyH'
GO
SELECT a.Cargos FROM Empleado b  INNER JOIN Acceso a  
ON b.Id_Acceso=a.Id_Acceso
WHERE b.Id_Empleado=1
GO
--drop database TecnoCell
--GOw
