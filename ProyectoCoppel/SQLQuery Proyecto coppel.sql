
-----------Crear Base de datos
create database bdProyecto

----------------USar base de datos
use bdProyecto


---------------------tabla usuario

 create table tblUsuarios
 (
 UsuarioId int identity (1,1) primary key not null,
 Clave varchar(3) not null,
 Nombre varchar(20) null,
 Apellido varchar(20) null,
 Fecha_N date null,
 Estatus Bit null 
 )

 ------------------------Tabla de Comentarios
 Create table tblComentarios
 (
 ComentarioId int identity(1,1) primary key not null,
 Descripcion varchar(50) null,
 UsuarioId int foreign key (UsuarioId) references tblUsuarios (UsuarioId),
 Estatus bit null
 )

 --------------Tabla de proveedores 

 Create table tblProveedores
 (
 ProveedorId int identity(1,1) primary key not null,
 RFC varchar(13) null check (RFC like '[A-Z][A-Z][A-Z][A-Z][0-9][0-9][0-9][0-9][0-9][0-9]%'),
 nombre varchar(20) null,
 Estatus bit null
 )

 -------------Table de prodcutos
 create table tblProductos
 (
 ProductoID int identity(1,1) primary key not null,
 Descripcion varchar (20) null,
 Estatus bit
 )

 
--------------- Tabla de registros proveedor_producto
 create table tblProveedorProducto
 (
 ProveedorId int foreign key (ProveedorId) references tblProveedores (ProveedorId),
 ProductoId int foreign key (ProductoId) references tblProductos (ProductoId)
 )

