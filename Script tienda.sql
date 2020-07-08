drop database Tienda 

create database Tienda
go

use Tienda 
go

create schema factura
go


create table factura.cliente (
	id int primary key not null,
	nombre varchar(25),
	apellido varchar(25),
	direccion varchar(50),
)


create table factura.producto(
	idProd int primary key not null,
	nombreProducto varchar(40),
	descripcion varchar(50)
)

create table factura.Venta(
	idVenta int primary key not null,
	fechaVenta date,
	precio int,
	cantidad int,
	idCliente int foreign key references factura.Cliente(id),
	idProducto int foreign key references factura.producto(idProd)
)




-----------------------Procedimiento para Clientes---------------------
---------procedimiento agregar cliente---------------
Create procedure IngresarCliente(
@id int,
@nombre varchar(25),
@apellido varchar(25),
@direccion varchar(50)
)
AS
BEGIN
insert into factura.cliente(id, nombre, apellido, direccion)
values(@id,@nombre,@apellido,@direccion)
END


-----------Procedimiento Consultar Clientes-------------
CREATE PROCEDURE ConsultarClientes
AS
BEGIN
select id as 'Codigo Cliente', concat(nombre,' ',apellido) as 'Nombre Completo', direccion  from factura.cliente 
END



------------Procedimiento Buscar Cliente---------------
Create PROCEDURE BuscarCliente(@codigo int)
AS
BEGIN
select id as 'Codigo Cliente', concat(nombre,' ',apellido) as 'Nombre Completo', direccion   from factura.cliente where id = @codigo
END



------------Procedimiento Actualizar Cliente---------------
CREATE PROCEDURE ActualizarCliente(
@codigo int,
@nombre varchar(25),
@apellido varchar(25),
@direccion varchar(50)
)
AS
BEGIN
update factura.cliente 
set nombre = @nombre, apellido = @apellido, direccion = @direccion
where id = @codigo
END



---------Procedimiento para eliminar cliente------
CREATE PROCEDURE eliminarCliente(@codigo int)
AS
BEGIN
delete from factura.Venta where idCliente = @codigo
delete from factura.cliente where id = @codigo
END













----------------Procedimientos para Productos---------------
-------Procedimiento agregar producto---------
Create procedure IngresarProducto(
@idProd int,
@nombreProducto varchar(40),
@descripcion varchar(50)
)
AS
BEGIN
insert into factura.producto(idProd, nombreProducto,descripcion)
values(@idProd,@nombreProducto,@descripcion)
END



-------Procedimiento actualizar producto---------
CREATE PROCEDURE ActualizarProducto(
	@idProd int,
	@nombreProducto varchar(40),
	@descripcion varchar(50)
)
AS
BEGIN
update factura.producto
set nombreProducto = @nombreProducto , descripcion = @descripcion
where idProd = @idProd
END


-------Procedimiento consultar productos---------
CREATE PROCEDURE ConsultarProductos
AS
BEGIN
select * from factura.producto
END


-------Procedimiento buscar producto---------
CREATE PROCEDURE BuscarProductos(@codigo as int)
AS
BEGIN
select * from factura.producto where idProd = @codigo
END


-------Procedimiento Eliminar Producto---------
CREATE PROCEDURE eliminarProducto(@codigoProducto int)
AS
BEGIN
delete from factura.Venta where idProducto = @codigoProducto
delete from factura.producto where idProd = @codigoProducto
END










-----------------PROCEDIMIENTOS PARA VENTA----------------

---------procedimiento Ingresar Venta---------
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



---------Procedimiento Consultar Base de ventas---------
create procedure ConsultarBase
AS
BEGIN
select C.id as codigoCliente,concat(C.nombre, ' ', C.apellido) as NombreCliente, P.idProd as CodigoProducto, P.nombreProducto, cantidad, precio, fechaVenta from factura.Venta V
inner join factura.cliente C
on V.idCliente = C.id 
inner join factura.producto P
on V.idProducto = P.idProd
END




---------Procedimiento Consultar Venta---------

Create procedure ConsultarVenta(@codigo int)
AS
BEGIN
select C.id as codigoCliente,concat(C.nombre, ' ', C.apellido) as NombreCliente, P.idProd as CodigoProducto, P.nombreProducto, cantidad, precio, fechaVenta from factura.Venta V
inner join factura.cliente C
on V.idCliente = C.id
inner join factura.producto P
on V.idProducto = P.idProd
where idCliente = @codigo 
END




---------Procedimiento Modificar Venta---------
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
set  idProducto=@idproducto , precio = @precio, cantidad = @cantidad, fechaVenta = @fechaVenta
where idCliente = @idcliente
END



---------Procedimiento Eliminar Venta---------
CREATE PROCEDURE EliminarVenta(@codigoCliente int)
AS
BEGIN
delete from factura.Venta where idCliente = @codigoCliente 
end

