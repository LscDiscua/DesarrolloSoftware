Use taller

SELECT * FROM detallecompra
        
SELECT idDetalleCompra, producto Producto, cantidad Cantidad , precio Precio , impuesto Impuesto,
		cantidad * precio subTotal, impuesto + subTotal total  FROM detallecompra
#-------------------------------------------------------------------------------
CREATE VIEW vista_producto_proveedor
AS
SELECT a.idProducto, a.nombre, b.nombre AS categoria, a.marca, a.año, c.nombre As proveedor
FROM producto As a
INNER JOIN categoria AS B
ON a.categoria = b.idCategoria INNER JOIN proveedor As c
ON a.proveedor = c.idProveedor

#-------------------------------------------------------------------------------
CREATE VIEW vista_productos_escasos_inventario
AS
SELECT a.nombre, b.nombre AS categoria, c.existencia, c.precio
FROM producto As a
INNER JOIN categoria AS B
ON a.categoria = b.idCategoria INNER JOIN inventario As c
ON a.idProducto = c.producto
WHERE c.existencia < 10

DROP VIEW vista_producto_proveedor
SHOW CREATE VIEW vista_producto_proveedor
SELECT * from vista_producto_proveedor
 
 SELECT * FROM taller.producto;
 #--------------------------------------------------------------------------
CREATE VIEW vista_de_compra
AS
SELECT distinct a.numeroFactura, a.fecha, b.nombre AS proveeedor, c.nombre , d.cantidad, d.precio, d.total
FROM encabezadoCompra As a
INNER JOIN proveedor AS b
ON a.proveedor = b.idProveedor INNER JOIN producto As c
ON b.idProveedor = c.proveedor INNER JOIN detalleCompra AS d
ON a.numeroFactura = d.encabezadoCompra


#----------------------------

CREATE VIEW vista_de_ventas
AS
SELECT distinct a.numeroFactura, a.fecha, a.cliente , b.nombre , c.cantidad, c.precio, c.total
FROM encabezadoVenta As a
INNER JOIN detalleVenta AS c
ON a.numeroFactura = c.encabezado INNER JOIN producto As b
ON c.producto = b.idProducto 


#-------------------------------

select * from proucto
DROP VIEW vista_producto_proveedor
SHOW CREATE VIEW vista_producto_proveedor
SELECT * from vista_producto_proveedor
 
 SELECT * FROM taller.inventario;
 
 
 #-----------------------------------------
CREATE FUNCTION `fn_menorCantidadEnInventario` (xCantidad INT)
RETURNS VARCHAR(100)
BEGIN

SELECT cantidad into @can
FROM inventario
if  @can < 10 THEN
	SET @mensaje= "Quedan menos de 10 articulos de este producto";
end if;

RETURN @mensaje;
END

 
 
 
 
 
 
 
 
 
 
 
 