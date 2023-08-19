
create database SeguimientoDNT;
use SeguimientoDNT;

create table Persona
(
	IdPersona int identity(1, 1) primary key,
	TipoIdentificacion varchar(2),
	NroIdentificacion varchar(17),
	PrimerNombre varchar(60),
	SegundoNombre varchar(60),
	PrimerApellido varchar(60),
	SegundoApellido varchar(60),
	Sexo varchar(2),
	FechaNacimiento date,
	CodMpioResidencia varchar(5),
	CodAsegurador varchar(6),
	fechaRegistro datetime default getdate()
);

create table Seguimiento
(
	IdSeguimiento int identity(1, 1) primary key,
	IdPersona int foreign key references Persona(IdPersona),
	EstadoVital varchar(24),
	FechaDefuncion date,
	UbicacionDefuncion varchar(1),
	CodLugarAtencion varchar(12),
	FechaAtencion datetime,
	PesoKg decimal(5, 2),
	TallaCm smallint,
	CodClasificacionNutricional varchar(2),
	CodManejoActual varchar(2),
	DesManejo varchar(250),
	CodUbicacion varchar(2),
	DesUbicacion varchar(250),
	CodTratamiento varchar(2),
	TotalSobresFTLC smallint,
	OtroTratamiento varchar(256),
	FechaRegistro datetime default getdate()
);

