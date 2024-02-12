CREATE TABLE Usuarios
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL,
    Apellido NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);

CREATE TABLE Productos
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(100) NOT NULL,
    Costo DECIMAL(18, 2) NOT NULL,
    PrecioVenta DECIMAL(18, 2) NOT NULL,
    Stock INT NOT NULL,
    IdUsuario INT NOT NULL,
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id)
);

CREATE TABLE Ventas
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    FechaVenta DATETIME NOT NULL,
    IdUsuario INT NOT NULL,
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id)
);

CREATE TABLE ProductosVendidos
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdVenta INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioVenta DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (IdVenta) REFERENCES Ventas(Id),
    FOREIGN KEY (IdProducto) REFERENCES Productos(Id)
);
