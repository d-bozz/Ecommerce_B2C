-- Creacion de la base de datos

IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'Flowers_B2C')
BEGIN
    CREATE DATABASE Flowers_B2C;
END

USE Flowers_B2C;


-- Creacion de las tablas


/****************************************************************************************************************************/
/**********************************                Orden_Items             **************************************************/
/****************************************************************************************************************************/

CREATE TABLE Orden_Items (
    orden_item_id INT PRIMARY KEY IDENTITY(1,1),
    Orden_Item_cantidad INT NOT NULL,
    Orden_Item_precio DECIMAL(8, 2) CHECK(Orden_Item_precio > 0) NOT NULL,
    producto_id INT NOT NULL,
    orden_id INT NOT NULL,
    Orden_Items_created_at DATETIME DEFAULT GETDATE()
);


/****************************************************************************************************************************/
/**********************************                Categorias             ***************************************************/
/****************************************************************************************************************************/

CREATE TABLE Categorias (
    categoria_id INT PRIMARY KEY IDENTITY(1,1),
    categoria_nombre VARCHAR(255) NOT NULL,
    categoria_created_at DATETIME DEFAULT GETDATE()
);

/****************************************************************************************************************************/
/**********************************                Productos             ****************************************************/
/****************************************************************************************************************************/

CREATE TABLE Productos (
    producto_id INT PRIMARY KEY IDENTITY(1,1),
    producto_codigo VARCHAR(255) NOT NULL,
    producto_nombre VARCHAR(255) NOT NULL,
    producto_descripcion VARCHAR(1000) NOT NULL,
    producto_precio DECIMAL(8, 2) CHECK(producto_precio > 0) NOT NULL,
    producto_stock INT NOT NULL,
    categoria_id INT NOT NULL,
    producto_created_at DATETIME DEFAULT GETDATE()
);


/****************************************************************************************************************************/
/**********************************                Usuarios             *****************************************************/
/****************************************************************************************************************************/

CREATE TABLE Usuarios (
    usuario_id INT PRIMARY KEY IDENTITY(1,1),
    usuario_nombre VARCHAR(255) NOT NULL,
    usuario_apellido VARCHAR(255) NOT NULL,
    usuario_email VARCHAR(255) NOT NULL,
    usuario_password VARCHAR(255) NOT NULL,
    usuario_direccion VARCHAR(255) NOT NULL,
    usuario_telefono VARCHAR(255) NOT NULL,
    usuario_rol VARCHAR(255) NOT NULL,
    usuario_created_at DATETIME DEFAULT GETDATE()
);



/****************************************************************************************************************************/
/**********************************                Pago             *********************************************************/
/****************************************************************************************************************************/

CREATE TABLE Pago (
    pago_id INT PRIMARY KEY IDENTITY(1,1),
    pago_metodo VARCHAR(255) NOT NULL,
    pago_monto DECIMAL(8, 2) NOT NULL,
    usuario_id INT NOT NULL,
    pago_created_at DATETIME DEFAULT GETDATE(),
);


/****************************************************************************************************************************/
/**********************************                Lista_Deseos             *************************************************/
/****************************************************************************************************************************/

CREATE TABLE Lista_Deseos (
    lista_deseos_id INT PRIMARY KEY IDENTITY(1,1),
    usuario_id INT NOT NULL,
    producto_id INT NOT NULL,
    lista_deseos_created_at DATETIME DEFAULT GETDATE()
);


/****************************************************************************************************************************/
/**********************************                Carrito             ******************************************************/
/****************************************************************************************************************************/

CREATE TABLE Carrito (
    carrito_id INT PRIMARY KEY IDENTITY(1,1),
    carrito_cantidad INT NOT NULL,
    producto_id INT NOT NULL,
    usuario_id INT NOT NULL,
    carrito_created_at DATETIME DEFAULT GETDATE()
);


/****************************************************************************************************************************/
/**********************************                Envio             ********************************************************/
/****************************************************************************************************************************/

CREATE TABLE Envio (
    envio_id INT PRIMARY KEY IDENTITY(1,1),
    envio_direccion VARCHAR(255) NOT NULL,
    envio_ciudad VARCHAR(255) NOT NULL,
    envio_departamento VARCHAR(255) NOT NULL,
    envio_descripcion VARCHAR(1000) NOT NULL,
    usuario_id INT NOT NULL,
    envio_created_at DATETIME DEFAULT GETDATE()
);


/****************************************************************************************************************************/
/**********************************                Foto             *********************************************************/
/****************************************************************************************************************************/

CREATE TABLE Foto (
    foto_id INT PRIMARY KEY IDENTITY(1,1),
    foto_path VARCHAR(255) NOT NULL,
    producto_id INT NOT NULL,
    foto_created_at DATETIME DEFAULT GETDATE()
);


/****************************************************************************************************************************/
/**********************************                Orden             ********************************************************/
/****************************************************************************************************************************/

CREATE TABLE Orden (
    orden_id INT PRIMARY KEY IDENTITY(1,1),
    orden_precio DECIMAL(8, 2) NOT NULL,
    usuario_id INT NOT NULL,
    pago_id INT NOT NULL,
    envio_id INT NOT NULL,
    Orden_created_at DATETIME DEFAULT GETDATE()
);




/****************************************************************************************************************************/
/**********************************                CONSTRAINTs             **************************************************/
/****************************************************************************************************************************/


ALTER TABLE Orden_Items ADD CONSTRAINT orden_items_producto_id_foreign FOREIGN KEY(producto_id) REFERENCES Productos(producto_id);
ALTER TABLE Orden_Items ADD CONSTRAINT orden_items_orden_id_foreign FOREIGN KEY(orden_id) REFERENCES Orden(orden_id);
ALTER TABLE Productos ADD CONSTRAINT productos_categoria_id_foreign FOREIGN KEY(categoria_id) REFERENCES Categorias(categoria_id);
ALTER TABLE Productos ADD CONSTRAINT productos_stock_non_negative CHECK(producto_stock >= 0);
ALTER TABLE Usuarios ADD CONSTRAINT usuarios_email_unique UNIQUE(usuario_email);
ALTER TABLE Pago ADD CONSTRAINT pago_usuario_id_foreign FOREIGN KEY(usuario_id) REFERENCES Usuarios(usuario_id);
ALTER TABLE Lista_Deseos ADD CONSTRAINT lista_deseos_producto_id_foreign FOREIGN KEY(producto_id) REFERENCES Productos(producto_id);
ALTER TABLE Lista_Deseos ADD CONSTRAINT lista_deseos_usuario_id_foreign FOREIGN KEY(usuario_id) REFERENCES Usuarios(usuario_id);
ALTER TABLE Carrito ADD CONSTRAINT carrito_usuario_id_foreign FOREIGN KEY(usuario_id) REFERENCES Usuarios(usuario_id);
ALTER TABLE Carrito ADD CONSTRAINT carrito_producto_id_foreign FOREIGN KEY(producto_id) REFERENCES Productos(producto_id);
ALTER TABLE Envio ADD CONSTRAINT envio_usuario_id_foreign FOREIGN KEY(usuario_id) REFERENCES Usuarios(usuario_id);
ALTER TABLE Foto ADD CONSTRAINT foto_producto_id_foreign FOREIGN KEY(producto_id) REFERENCES Productos(producto_id);
ALTER TABLE Orden ADD CONSTRAINT orden_pago_id_foreign FOREIGN KEY(pago_id) REFERENCES Pago(pago_id);
ALTER TABLE Orden ADD CONSTRAINT orden_envio_id_foreign FOREIGN KEY(envio_id) REFERENCES Envio(envio_id);
ALTER TABLE Orden ADD CONSTRAINT orden_usuario_id_foreign FOREIGN KEY(usuario_id) REFERENCES Usuarios(usuario_id);

