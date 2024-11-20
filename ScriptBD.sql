
CREATE DATABASE Taller;

Use Taller;

CREATE TABLE Cliente
 (
	idCliente INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	nombre VARCHAR(30) NOT NULL,
	apellidoPaterno VARCHAR (30) NOT NULL,
	apellidoMaterno VARCHAR (30) NOT NULL,
	edad INT NOT NULL,
	sexo VARCHAR (30) NOT NULL,
	direccion VARCHAR (120) NOT NULL,
	telefono VARCHAR(12) NOT NULL,
	correo VARCHAR(80) NOT NULL 
 );

CREATE TABLE Servicio
 (
	idServicio INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	tipo VARCHAR (200) NOT NULL,
	descripcion VARCHAR (200) NOT NULL,
	costo FLOAT NOT NULL,
	fechaServicio DATE NOT NULL,
	horaServicio TIME NOT NULL
 );


CREATE TABLE Refaccion
 (
	idRefaccion INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	tipo VARCHAR (150) NOT NULL,
	precio FLOAT NOT NULL,
	servicioId INT,
	FOREIGN KEY(servicioId) REFERENCES Servicio(idServicio)
 );


CREATE TABLE Coche
 (
	idCoche INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	placa VARCHAR(10) NOT NULL,
	marca VARCHAR(80) NOT NULL,
	modelo VARCHAR(80) NOT NULL,
	anio INT NOT NULL,
	color VARCHAR(60) NOT NULL,
	clienteId INT NOT NULL, 
	FOREIGN KEY (clienteId) REFERENCES Cliente(idCliente),
 );
 
 CREATE TABLE EstadoAuto
 (
	idEstadoAuto INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	condicion VARCHAR(120) NOT NULL,
	inventario VARCHAR(120) NOT NULL,
	FechaEdo DATE NOT NULL,
	cocheId INT NOT NULL, 
	FOREIGN KEY (cocheId) REFERENCES Coche(idCoche)
 );
 
 CREATE TABLE AutoServicio
 (
	servicioId INT NOT NULL, 
	FOREIGN KEY (servicioId) REFERENCES Servicio(idServicio),
	cocheId INT NOT NULL, 
	FOREIGN KEY (cocheId) REFERENCES Coche(idCoche)
 );
 
 CREATE TABLE HojaServicio
 (
	idHojaServicio INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Fecha DATE NOT NULL,
	FormaPago VARCHAR(50) NOT NULL,
	Total FLOAT NOT NULL,
	servicioId INT NOT NULL, 
	FOREIGN KEY (servicioId) REFERENCES SERVICIO(idServicio)
 );
