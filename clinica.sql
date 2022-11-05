CREATE DATABASE Clinica

GO 

Use Clinica

-- CREANDO LA TABLA DE DATOS--
GO
-- Se guardaran todos los clientes en este caso los pacientes de la clinica
CREATE TABLE Pacientes (
    ID_Pacientes INT NOT NULL PRIMARY KEY identity(1,1),
    Nombre VARCHAR(70) NOT NULL,
    Apellido VARCHAR(70) NOT NULL,
    Edad INT NOT NULL,
    Dui VARCHAR(10),
    Direccion VARCHAR(255),
	-- NOTA: (Borrado  en Paciente afectaria cascada a Expediente, Detalle Cita, Citas Medicas Actualizacion solo tabla Paciente)
)

GO
-- Se alojaran los expedientes asi como su fecha de creacion del expediente
CREATE TABLE Expedientes (
    ID_Expediente INT NOT NULL PRIMARY KEY identity(1,1),
	ID_Paciente INT unique NOT NULL,
    Afilacion DATETIME DEFAULT CURRENT_TIMESTAMP

)


GO
-- Se alojaran las citas medicas
CREATE TABLE Citas_Medicas (
    ID INT NOT NULL PRIMARY KEY identity(1,1),
    Tipo_Cita VARCHAR(70) NOT NULL,
    N_Consultorio INT NOT NULL,
    ID_Expediente INT NOT NULL,
    ID_Medico INT NOT NULL,
    Fecha_Cita DATETIME DEFAULT CURRENT_TIMESTAMP
)

GO
-- Se alojaran nombre de los doctors que atienden la clinica
CREATE TABLE Medicos (
    ID_Medicos INT NOT NULL PRIMARY KEY identity(1,1),
    Nombre VARCHAR(70) NOT NULL,
    Apellido VARCHAR(70) NOT NULL,
    Especialidad VARCHAR (70),
	ID_usuario int NOT NULL
)


GO
--Detalle cita
CREATE TABLE Detalle_Cita
(
ID_Detalle INT PRIMARY KEY IDENTITY(1,1),
ID_Cita INT NOT NULL,
ID_Medico INT NOT NULL,
ID_Expediente INT NOT NULL,

)



GO
-- Especialidad de medicos
CREATE TABLE Especialidad
(
ID_Especialidades INT PRIMARY KEY IDENTITY(1,1),
Nombre_Espe VARCHAR (70) NOT NULL
)


GO
--Detalle especialidad
CREATE TABLE Especialidad_Medico
(
ID_Espec_Medico INT PRIMARY KEY IDENTITY(1,1),
ID_MEDICO INT NOT NULL,
ID_ESPECIALIDAD INT NOT NULL

)

GO
-- Usuarios de la Base
CREATE TABLE Usuarios
(
ID_USER INT PRIMARY KEY IDENTITY(1,1),
Nombre_Apellido VARCHAR (80),
Alias VARCHAR (40),
Contra VARCHAR (20),
PUESTO VARCHAR (70),
ID_ROL INT NOT NULL,

)

GO

-- Roles de los Usuarios
CREATE TABLE Rol
(
ID_Rol  INT PRIMARY KEY IDENTITY (1,1),
Tipo_Rol VARCHAR(25) NOT NULL,

)

-- Colocando las relacioens de las Tablas
GO

-- Relacion EXPDIENTE - PACIENTES
ALTER TABLE Expedientes
ADD CONSTRAINT FK_Expediente_Paciente FOREIGN KEY (ID_Paciente ) REFERENCES Pacientes(ID_Pacientes)
ON DELETE CASCADE
ON UPDATE CASCADE


GO
--Relacion DETALLE CITA - EXPEDIENTE, CITAS MEDICAS, MEDICO
ALTER TABLE Detalle_Cita
ADD CONSTRAINT FK_DETALLECITA_TODO FOREIGN KEY (ID_Expediente) REFERENCES  Expedientes(ID_Expediente),
CONSTRAINT FK_DETALLECITA_CITA FOREIGN KEY (ID_Cita) REFERENCES  Citas_Medicas(ID),
CONSTRAINT FK_DETALLE_MEDICO FOREIGN KEY (ID_Medico) REFERENCES Medicos(ID_Medicos)
ON DELETE CASCADE
ON UPDATE CASCADE

GO
--Relacion ESPCIALIDAD MEDICOS - ESPECIALIDAD
ALTER TABLE Especialidad_Medico
ADD CONSTRAINT FK_Especiaildad_Medicos1 FOREIGN KEY (ID_MEDICO) REFERENCES Medicos (ID_Medicos ),
CONSTRAINT FK_Medisco_Especialidad FOREIGN KEY (ID_ESPECIALIDAD ) REFERENCES Especialidad (ID_Especialidades)

GO

ALTER TABLE Medicos
ADD CONSTRAINT FK_Medico_User FOREIGN KEY (ID_usuario) REFERENCES Usuarios (ID_USER)



GO
--Relacion Usuario
ALTER TABLE Usuarios
ADD CONSTRAINT FK_USER_ROLES FOREIGN KEY (ID_ROL )REFERENCES Rol (ID_Rol)








