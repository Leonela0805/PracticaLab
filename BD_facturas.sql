Create Database BD_Factura

use BD_Factura

CREATE TABLE ProductoVenta (
    ProductoVentaID INT PRIMARY KEY IDENTITY(1,1),   -- Identificador �nico del producto
    CodigoProducto NVARCHAR(50) NOT NULL,       -- C�digo del producto (ejemplo: CONTABILIDAD)
    Nombre NVARCHAR(255) NOT NULL,              -- Nombre del producto o servicio
    Descripcion NVARCHAR(255),                  -- Descripci�n del producto o servicio
    UnidadMedida NVARCHAR(50),                  -- Unidad de medida (ejemplo: UNIDAD)
    Precio DECIMAL(10,2) NOT NULL,  
	Stock INT
	
);


CREATE TABLE FacturaCabecera (
    FacturaID INT PRIMARY KEY IDENTITY(1,1),    -- Identificador �nico para la factura
    NumeroFactura NVARCHAR(20) NOT NULL,        -- N�mero de la factura (ejemplo: E001-1213)
    RUC NVARCHAR(15) NOT NULL,                  -- RUC del emisor (ejemplo: 20556106909)
    RazonSocial NVARCHAR(255) NOT NULL,         -- Raz�n Social del emisor (ejemplo: Noticiero del Contador S.A.C.)
    FechaEmision DATE NOT NULL,                 -- Fecha de emisi�n de la factura
    FechaVencimiento DATE,                      -- Fecha de vencimiento de la factura
    DireccionCliente NVARCHAR(255),             -- Direcci�n del cliente
    TipoMoneda NVARCHAR(10) NOT NULL,           -- Tipo de moneda (ejemplo: SOLES)
    FormaPago NVARCHARCHAR(10) CHECK (FormaPago IN ('Contado', 'Cr�dito')),                    -- Forma de pago (ejemplo: Cr�dito)
    Observacion NVARCHAR(255)                   -- Observaciones (ejemplo: DETRACCI�N 12%)
);


CREATE TABLE FacturaDetalle (
    DetalleID INT PRIMARY KEY IDENTITY(1,1),    -- Identificador �nico del detalle
    FacturaID INT NOT NULL,                     -- Relaci�n con la cabecera de la factura (FacturaCabecera)
    ProductoVentaID INT NOT NULL,                    -- Relaci�n con la tabla de productos (Producto)
    SubTotalVentas DECIMAL(10,2) NOT NULL,
	CantidaProducto INT NOT NULL,
	Anticipos DECIMAL(10,2) NOT NULL,  
	Descuentos DECIMAL(10,2) NOT NULL,  
	ValorVenta DECIMAL(10,2) NOT NULL,   
    IGV DECIMAL(10,2) NOT NULL,                 -- IGV del producto (SubTotal * 18%)
    Total DECIMAL(10,2) NOT NULL,               -- Total del producto (SubTotal + IGV)
    FOREIGN KEY (FacturaID) REFERENCES FacturaCabecera(FacturaID) ON DELETE CASCADE, -- Relaci�n con la cabecera
    FOREIGN KEY (ProductoVentaID) REFERENCES ProductoVenta(ProductoVentaID) ON DELETE CASCADE       -- Relaci�n con el producto
);
