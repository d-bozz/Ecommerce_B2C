
/****************************************************************************************************************************/
/*****************************           Creacion de la base de datos             *******************************************/
/****************************************************************************************************************************/

IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'Flowers_B2C')
BEGIN
    CREATE DATABASE Flowers_B2C;
END
GO

USE Flowers_B2C;
GO

/****************************************************************************************************************************/
/*********************************           Creacion de las tablas             *********************************************/
/****************************************************************************************************************************/


/**********************************                Categorias             ***************************************************/

create table Categorias(
id_categoria int primary key identity,
nombre varchar(255),
fecha_creacion datetime default getdate()
)
GO

/**********************************                Productos             ****************************************************/

create table Productos(
id_producto int primary key identity,
nombre varchar(255),
descripcion varchar(1000),
id_categoria int references Categorias(id_categoria),
precio decimal(10,2),
precio_oferta decimal(10,2),
cantidad int,
imagen varchar(max),
fecha_creacion datetime default getdate()
)
GO

/**********************************                Usuarios             *****************************************************/

create table Usuarios(
id_usuario int primary key identity,
nombre_completo varchar(50),
correo varchar(255),
clave varchar(255),
rol varchar(255),
fecha_creacion datetime default getdate()
)
GO

/**********************************                Ventas             *********************************************************/

create table Ventas(
id_venta int primary key identity,
id_usuario int references Usuarios(id_usuario),
total decimal(10,2),
fecha_creacion datetime default getdate()
)
GO

/**********************************                Detalle Venta             *************************************************/

create table Detalle_Venta
(
id_detalle_Venta int primary key identity,
id_venta int references Ventas(id_venta),
id_producto int references Productos(id_producto),
cantidad int,
total decimal(10,2)
)
GO


/****************************************************************************************************************************/
/*********************************           Indices             ************************************************************/
/****************************************************************************************************************************/

CREATE INDEX IX_Correo ON Usuarios (correo);


/****************************************************************************************************************************/
/*********************************           Insert de Datos             ****************************************************/
/****************************************************************************************************************************/

insert into Usuarios(nombre_completo,correo,clave,rol) values
('administrador','admin@example.com','123','Administrador')