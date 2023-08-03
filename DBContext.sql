--Create Database	ABC	
--USE ABC 

----*********************************************************************

--Create Table USUARIO(
--	idUsuario int primary key identity(1,1),
--	Correo varchar(50),
--	Clave varchar(100)
--)

----*********************************************************************
--
--INSERT INTO USUARIO (Correo, Clave) values ('correodemo@gmail.com','a57b00c5d624241206dd201c13c27eb50e6b89d03cb5b0a6ee29990626ca81bf')


--SELECT *FROM USUARIO
----*********************************************************************

--CREATE TABLE TipoDistribucion	(
--	IdDist int primary key identity(1,1),
--	Nombre varchar(50)
--)

--CREATE TABLE Estibas (
--	IdEstiba int primary key identity(1,1),
--	Nombre varchar(50),
--	Cantidad int
--)

--CREATE TABLE TipoProducto(
--	IdTipoProd int primary key identity(1,1),
--	Descripcion varchar(50)
--)

--CREATE TABLE ProductoDistribucion(
--	IdProducto int primary key identity(1,1),
--	Nombre varchar(50),
--	Precio_Mayor int,
--	Precio_Menor int,
--	Cantidad int,
--	IdDist int,
--	IdEstiba int,
--	IdTipoProd int
--)
--Catalogo TipoDistribucion	
--INSERT INTO TipoDistribucion (Nombre) values ('Por Mayor')
--INSERT INTO TipoDistribucion (Nombre) values ('Al Detal')
--Catalogo Estibas	
--INSERT INTO Estibas (Nombre,Cantidad) values ('A1',0)
--INSERT INTO Estibas (Nombre,Cantidad) values ('A2',0)
--INSERT INTO Estibas (Nombre,Cantidad) values ('A3',0)
--Catalogo TipoProducto	
--INSERT INTO TipoProducto (Descripcion) values ('Gaseosa')
--INSERT INTO TipoProducto (Descripcion) values ('Refresco')


