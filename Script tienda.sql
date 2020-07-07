drop database Tienda 
create database Tienda
go

create schema factura
go

use tienda 
go

create table factura.cliente (
	idCliente int primary key not null,
	nombre varchar(25),
	apellido varchar(25),
	direccion varchar(50),
)


create table factura.producto(
	idProducto int primary key not null,
	nombreProducto varchar(40),
	descripcion varchar(50)
)

create table factura.Venta(
	idVenta int primary key not null,
	fechaVenta date,
	precio int,
	cantidad int,
	idCliente int foreign key references factura.cliente(idCliente),
	idProducto int foreign key references factura.producto(idProducto)
)

--procedimiento agregar cliente--
Create procedure IngresarCliente(
@idCliente int,
@nombre varchar(25),
@apellido varchar(25),
@direccion varchar(50)
)
AS
BEGIN
insert into factura.cliente(idCliente, nombre, apellido, direccion)
values(@idCliente,@nombre,@apellido,@direccion)
END

exec IngresarCliente 1208, 'Hector', 'Osorio','Barrio la tejera'
select * from factura.cliente 

--Procedimiento agregar producto--
Create procedure IngresarProducto(
@idProducto int,
@nombreProducto varchar(40),
@descripcion varchar(50)
)
AS
BEGIN
insert into factura.producto(idProducto, nombreProducto,descripcion)
values(@idProducto,@nombreProducto,@descripcion)
END

exec IngresarProducto 035, 'Coca Cola 3 lts.', 'Refresco de soda'
select * from factura.producto

--procedimiento Ingresar Venta--
create procedure Ingresarventa(
@idVenta int,
@fechaVenta date,
@precio int,
@cantidad int,
@idcliente int,
@idproducto int
)
AS 
BEGIN
insert into factura.Venta(idVenta,fechaVenta,precio,cantidad,idCliente,idProducto)
values(@idVenta,@fechaVenta,@precio,@cantidad,@idcliente,@idproducto)
END

exec Ingresarventa 1,'2020-07-07', 48, 3, 1208, 035
select * from factura.Venta

--procedimiento consulta productos--
create procedure ConsultarBase
AS
BEGIN
select C.nombre, C.apellido, P.nombreProducto, cantidad, precio, fechaVenta from factura.Venta V
inner join factura.cliente C
on V.idCliente = C.idCliente
inner join factura.producto P
on V.idProducto = P.idProducto
END

exec ConsultarBase

Create procedure ConsultarVenta(@Nombre varchar (25))
AS
BEGIN
select C.nombre, C.apellido, P.nombreProducto, cantidad, precio, fechaVenta from factura.Venta V
inner join factura.cliente C
on V.idCliente = C.idCliente
inner join factura.producto P
on V.idProducto = P.idProducto
where nombre = @nombre
END

create procedure ModificarVenta(
@fechaVenta date,
@precio int,
@cantidad int,
@idcliente int,
@idproducto int
)
AS
BEGIN
update factura.Venta 
set  
END