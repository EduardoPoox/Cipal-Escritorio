/*
Run this script on:

        (local)\SQLSERVER2012.basegeneral    -  This database will be modified

to synchronize it with:

        (local)\SQLSERVER2012.cipal_aaa010101aaa_municipio_de_merida

You are recommended to back up your database before running this script

Script created by SQL Compare version 11.1.0 from Red Gate Software Ltd at 10/06/2021 02:46:46 a. m.

*/
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[confdapempleados]'
GO
CREATE TABLE [dbo].[confdapempleados]
(
[idconfdapempleado] [int] NOT NULL,
[idempleado] [int] NULL,
[iddepartamento] [int] NULL,
[idpuesto] [int] NULL,
[estatus] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fecha] [datetime] NULL,
[observaciones] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_confdapempleados] on [dbo].[confdapempleados]'
GO
ALTER TABLE [dbo].[confdapempleados] ADD CONSTRAINT [PK_confdapempleados] PRIMARY KEY CLUSTERED  ([idconfdapempleado])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[vconfdapempleados]'
GO

CREATE VIEW [dbo].[vconfdapempleados]
AS
SELECT        idconfdapempleado, idempleado, ('') [nombrecompleto], iddepartamento, ('')[nombredepartamento], idpuesto, ('')[nombrepuesto], estatus, fecha, observaciones, usuario, baja
FROM            dbo.confdapempleados
WHERE dbo.confdapempleados.baja=0

GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[vehiculos]'
GO
CREATE TABLE [dbo].[vehiculos]
(
[idvehiculo] [int] NOT NULL,
[nombre] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[placa] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[marca] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[modelo] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[rendimiento] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_vehiculos] on [dbo].[vehiculos]'
GO
ALTER TABLE [dbo].[vehiculos] ADD CONSTRAINT [PK_vehiculos] PRIMARY KEY CLUSTERED  ([idvehiculo])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[puestos]'
GO
CREATE TABLE [dbo].[puestos]
(
[idpuesto] [int] NOT NULL,
[nombre] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_puestos] on [dbo].[puestos]'
GO
ALTER TABLE [dbo].[puestos] ADD CONSTRAINT [PK_puestos] PRIMARY KEY CLUSTERED  ([idpuesto])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[gasolinas]'
GO
CREATE TABLE [dbo].[gasolinas]
(
[idgasolina] [int] NOT NULL,
[folio] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fecha] [datetime] NULL,
[iddepartamento] [int] NULL,
[idvehiculo] [int] NULL,
[idempleado] [int] NULL,
[comentarios] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[iddocumentodigital] [int] NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechacreacion] [datetime] NULL CONSTRAINT [DF_gasolinas_fechacreacion] DEFAULT (getdate()),
[baja] [bit] NULL CONSTRAINT [DF_gasolinas_baja] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_gasolinas] on [dbo].[gasolinas]'
GO
ALTER TABLE [dbo].[gasolinas] ADD CONSTRAINT [PK_gasolinas] PRIMARY KEY CLUSTERED  ([idgasolina])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[empleados]'
GO
CREATE TABLE [dbo].[empleados]
(
[idempleado] [int] NOT NULL,
[nombres] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[apellidopaterno] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[apellidomaterno] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[rfc] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[curp] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[correo] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[telefono] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[movil] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[token] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_empleados] on [dbo].[empleados]'
GO
ALTER TABLE [dbo].[empleados] ADD CONSTRAINT [PK_empleados] PRIMARY KEY CLUSTERED  ([idempleado])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[departamentos]'
GO
CREATE TABLE [dbo].[departamentos]
(
[iddepartamento] [int] NOT NULL,
[nombre] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_departamentos] on [dbo].[departamentos]'
GO
ALTER TABLE [dbo].[departamentos] ADD CONSTRAINT [PK_departamentos] PRIMARY KEY CLUSTERED  ([iddepartamento])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[vgasolinas]'
GO




CREATE VIEW [dbo].[vgasolinas]
AS

SELECT        idgasolina, folio, fecha, iddepartamento, idvehiculo, idempleado, 
(select nombre from dbo.departamentos where dbo.departamentos.iddepartamento = dbo.gasolinas.iddepartamento) [nombredepartamento],
(select  nombres + ' ' + apellidopaterno + ' ' + apellidomaterno from dbo.empleados where
dbo.empleados.idempleado = dbo.gasolinas.idempleado) [nombrecompleto], 
(select nombre from dbo.puestos where dbo.puestos.idpuesto=
(select dbo.confdapempleados.idpuesto from dbo.confdapempleados where dbo.confdapempleados.idempleado = dbo.gasolinas.idempleado and dbo.confdapempleados.baja=0)) [puesto],
(select placa from dbo.vehiculos where dbo.vehiculos.idvehiculo = dbo.gasolinas.idvehiculo) [placa], 
(select marca from dbo.vehiculos where dbo.vehiculos.idvehiculo = dbo.gasolinas.idvehiculo) [marca], 
(select modelo from dbo.vehiculos where dbo.vehiculos.idvehiculo = dbo.gasolinas.idvehiculo) [modelo], 
(select rendimiento from dbo.vehiculos where dbo.vehiculos.idvehiculo = dbo.gasolinas.idvehiculo) [rendimiento],
comentarios, iddocumentodigital, usuario, fechacreacion, baja
FROM            gasolinas
where dbo.gasolinas.baja=0


GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[unidades]'
GO
CREATE TABLE [dbo].[unidades]
(
[idunidad] [int] NOT NULL,
[nombre] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[cveunidad] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[simbologia] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_unidades] on [dbo].[unidades]'
GO
ALTER TABLE [dbo].[unidades] ADD CONSTRAINT [PK_unidades] PRIMARY KEY CLUSTERED  ([idunidad])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[inventarios]'
GO
CREATE TABLE [dbo].[inventarios]
(
[idinventario] [int] NOT NULL,
[idconcepto] [int] NULL,
[existencia] [int] NULL,
[idunidad] [int] NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechacreacion] [datetime] NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_inventarios] on [dbo].[inventarios]'
GO
ALTER TABLE [dbo].[inventarios] ADD CONSTRAINT [PK_inventarios] PRIMARY KEY CLUSTERED  ([idinventario])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[conceptos]'
GO
CREATE TABLE [dbo].[conceptos]
(
[idconcepto] [int] NOT NULL,
[grupo] [varchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[tipoconcepto] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[nombre] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[idunidad] [int] NULL,
[inventario] [bit] NULL,
[cvesat] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_conceptos_1] on [dbo].[conceptos]'
GO
ALTER TABLE [dbo].[conceptos] ADD CONSTRAINT [PK_conceptos_1] PRIMARY KEY CLUSTERED  ([idconcepto])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[vinventarios]'
GO


CREATE VIEW [dbo].[vinventarios]
AS

SELECT        
idinventario, idconcepto, existencia, idunidad, 
(select nombre from dbo.conceptos where dbo.conceptos.idconcepto = dbo.inventarios.idconcepto)[nombreconcepto],
(select descripcion from dbo.conceptos where dbo.conceptos.idconcepto = dbo.inventarios.idconcepto)[descripcionconcepto],
(select grupo from dbo.conceptos where dbo.conceptos.idconcepto = dbo.inventarios.idconcepto)[grupoconcepto],
(select tipoconcepto from dbo.conceptos where dbo.conceptos.idconcepto = dbo.inventarios.idconcepto)[tipoconcepto],
(select cvesat from dbo.conceptos where dbo.conceptos.idconcepto = dbo.inventarios.idconcepto)[cvesat],

(select nombre from dbo.unidades where dbo.unidades.idunidad = dbo.inventarios.idunidad)[nombreunidad],
(select simbologia from dbo.unidades where dbo.unidades.idunidad = dbo.inventarios.idunidad)[simbologia],

usuario, fechacreacion, baja
FROM            inventarios
WHERE        (baja = 0)



GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[mantenimientos]'
GO
CREATE TABLE [dbo].[mantenimientos]
(
[idmantenimiento] [int] NOT NULL,
[folio] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fecha] [datetime] NULL,
[iddepartamento] [int] NULL,
[idvehiculo] [int] NULL,
[idempleado] [int] NULL,
[comentarios] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[iddocumentodigital] [int] NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechacreacion] [datetime] NULL CONSTRAINT [DF_mantenimientos_fechacreacion] DEFAULT (getdate()),
[baja] [bit] NULL CONSTRAINT [DF_mantenimientos_baja] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_mantenimientos] on [dbo].[mantenimientos]'
GO
ALTER TABLE [dbo].[mantenimientos] ADD CONSTRAINT [PK_mantenimientos] PRIMARY KEY CLUSTERED  ([idmantenimiento])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[vmantenimientos]'
GO




CREATE VIEW [dbo].[vmantenimientos]
AS

SELECT        idmantenimiento, folio, fecha, iddepartamento, idvehiculo, idempleado, 
(select nombre from dbo.departamentos where dbo.departamentos.iddepartamento = dbo.mantenimientos.iddepartamento) [nombredepartamento],
(select  nombres + ' ' + apellidopaterno + ' ' + apellidomaterno from dbo.empleados where
dbo.empleados.idempleado = dbo.mantenimientos.idempleado) [nombrecompleto], 
(select nombre from dbo.puestos where dbo.puestos.idpuesto=
(select dbo.confdapempleados.idpuesto from dbo.confdapempleados where dbo.confdapempleados.idempleado = dbo.mantenimientos.idempleado and dbo.confdapempleados.baja=0)) [puesto],
(select placa from dbo.vehiculos where dbo.vehiculos.idvehiculo = dbo.mantenimientos.idvehiculo) [placa], 
(select marca from dbo.vehiculos where dbo.vehiculos.idvehiculo = dbo.mantenimientos.idvehiculo) [marca], 
(select modelo from dbo.vehiculos where dbo.vehiculos.idvehiculo = dbo.mantenimientos.idvehiculo) [modelo], 
(select rendimiento from dbo.vehiculos where dbo.vehiculos.idvehiculo = dbo.mantenimientos.idvehiculo) [rendimiento],
comentarios, iddocumentodigital, usuario, fechacreacion, baja
FROM            mantenimientos
where dbo.mantenimientos.baja=0

GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[solicitudes]'
GO
CREATE TABLE [dbo].[solicitudes]
(
[idsolicitud] [int] NOT NULL,
[folio] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fecha] [datetime] NULL,
[iddepartamento] [int] NULL,
[idempleado] [int] NULL,
[comentarios] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[iddocumentodigital] [int] NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechacreacion] [datetime] NULL CONSTRAINT [DF_solicitudes_fechacreacion] DEFAULT (getdate()),
[baja] [bit] NULL CONSTRAINT [DF_solicitudes_baja] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_solicitudes] on [dbo].[solicitudes]'
GO
ALTER TABLE [dbo].[solicitudes] ADD CONSTRAINT [PK_solicitudes] PRIMARY KEY CLUSTERED  ([idsolicitud])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[vsolicitudes]'
GO







CREATE VIEW [dbo].[vsolicitudes]
AS

SELECT        idsolicitud, folio, fecha, idempleado, 
(select  nombres + ' ' + apellidopaterno + ' ' + apellidomaterno from dbo.empleados where
dbo.empleados.idempleado = dbo.solicitudes.idempleado) [nombrecompleto], 
(select nombre from dbo.puestos where dbo.puestos.idpuesto=
(select dbo.confdapempleados.idpuesto from dbo.confdapempleados where dbo.confdapempleados.idempleado = dbo.solicitudes.idempleado and dbo.confdapempleados.baja=0) ) [puesto], 
iddepartamento, 
(select nombre from dbo.departamentos where dbo.departamentos.iddepartamento = dbo.solicitudes.iddepartamento) [nombredepartamento], comentarios, iddocumentodigital, usuario, fechacreacion, baja
FROM      dbo.solicitudes
WHERE dbo.solicitudes.baja=0



GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[constancias]'
GO
CREATE TABLE [dbo].[constancias]
(
[idconstancia] [int] NOT NULL,
[folio] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fecha] [datetime] NULL,
[iddepartamento] [int] NULL,
[idempleado] [int] NULL,
[comentarios] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[iddocumentodigital] [int] NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechacreacion] [datetime] NULL CONSTRAINT [DF_constancias_fechacreacion] DEFAULT (getdate()),
[baja] [bit] NULL CONSTRAINT [DF_constancias_baja] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_constancias] on [dbo].[constancias]'
GO
ALTER TABLE [dbo].[constancias] ADD CONSTRAINT [PK_constancias] PRIMARY KEY CLUSTERED  ([idconstancia])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[vconstancias]'
GO




CREATE VIEW [dbo].[vconstancias]
AS

SELECT        idconstancia, folio, fecha, idempleado, 
(select  nombres + ' ' + apellidopaterno + ' ' + apellidomaterno from dbo.empleados where
dbo.empleados.idempleado = dbo.constancias.idempleado) [nombrecompleto], 
(select nombre from dbo.puestos where dbo.puestos.idpuesto=
(select dbo.confdapempleados.idpuesto from dbo.confdapempleados where dbo.confdapempleados.idempleado = dbo.constancias.idempleado and dbo.confdapempleados.baja=0)) [puesto], 
iddepartamento, 
(select nombre from dbo.departamentos where dbo.departamentos.iddepartamento = dbo.constancias.iddepartamento) [nombredepartamento], comentarios, iddocumentodigital, usuario, fechacreacion, baja
FROM            dbo.constancias
WHERE dbo.constancias.baja=0


GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[informes]'
GO
CREATE TABLE [dbo].[informes]
(
[idinforme] [int] NOT NULL,
[folio] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fecha] [datetime] NULL,
[iddepartamento] [int] NULL,
[idempleado] [int] NULL,
[comentarios] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[iddocumentodigital] [int] NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechacreacion] [datetime] NULL CONSTRAINT [DF_informes_fechacreacion] DEFAULT (getdate()),
[baja] [bit] NULL CONSTRAINT [DF_informes_baja] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_informe] on [dbo].[informes]'
GO
ALTER TABLE [dbo].[informes] ADD CONSTRAINT [PK_informe] PRIMARY KEY CLUSTERED  ([idinforme])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[vinformes]'
GO




CREATE VIEW [dbo].[vinformes]
AS

SELECT        idinforme, folio, fecha, idempleado, 
(select  nombres + ' ' + apellidopaterno + ' ' + apellidomaterno from dbo.empleados where
dbo.empleados.idempleado = dbo.informes.idempleado) [nombrecompleto], 
(select nombre from dbo.puestos where dbo.puestos.idpuesto=
(select dbo.confdapempleados.idpuesto from dbo.confdapempleados where dbo.confdapempleados.idempleado = dbo.informes.idempleado and dbo.confdapempleados.baja=0)) [puesto], 
iddepartamento, 
(select nombre from dbo.departamentos where dbo.departamentos.iddepartamento = dbo.informes.iddepartamento) [nombredepartamento], comentarios, iddocumentodigital, usuario, fechacreacion, baja
FROM            dbo.informes
WHERE dbo.informes.baja=0


GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[tipoapoyos]'
GO
CREATE TABLE [dbo].[tipoapoyos]
(
[idtipoapoyo] [int] NOT NULL,
[nombre] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_tipoapoyos] on [dbo].[tipoapoyos]'
GO
ALTER TABLE [dbo].[tipoapoyos] ADD CONSTRAINT [PK_tipoapoyos] PRIMARY KEY CLUSTERED  ([idtipoapoyo])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[beneficiarios]'
GO
CREATE TABLE [dbo].[beneficiarios]
(
[idbeneficiario] [int] NOT NULL,
[rfc] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[nombre] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[correo] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[telefono] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[contacto] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[movil] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[curp] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[ine] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[domicilio] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_beneficiarios] on [dbo].[beneficiarios]'
GO
ALTER TABLE [dbo].[beneficiarios] ADD CONSTRAINT [PK_beneficiarios] PRIMARY KEY CLUSTERED  ([idbeneficiario])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[apoyos]'
GO
CREATE TABLE [dbo].[apoyos]
(
[idapoyo] [int] NOT NULL,
[idtipoapoyo] [int] NULL,
[idbeneficiario] [int] NULL,
[folio] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechasolicitud] [datetime] NULL,
[fechaentrega] [datetime] NULL,
[comentarios] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[estatus] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechacreacion] [datetime] NULL CONSTRAINT [DF_apoyos_fechacreacion] DEFAULT (getdate()),
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_apoyos] on [dbo].[apoyos]'
GO
ALTER TABLE [dbo].[apoyos] ADD CONSTRAINT [PK_apoyos] PRIMARY KEY CLUSTERED  ([idapoyo])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[vapoyos]'
GO


CREATE VIEW [dbo].[vapoyos]
AS
SELECT      idapoyo, idtipoapoyo, idbeneficiario, folio, 
(select nombre from dbo.tipoapoyos where dbo.tipoapoyos.idtipoapoyo = dbo.apoyos.idtipoapoyo) [tipoapoyo], 
(select nombre from dbo.beneficiarios where dbo.beneficiarios.idbeneficiario = dbo.apoyos.idbeneficiario) [nombrecompleto], 
(select domicilio from dbo.beneficiarios where dbo.beneficiarios.idbeneficiario = dbo.apoyos.idbeneficiario) [domicilio], fechasolicitud, fechaentrega, comentarios, estatus, usuario, fechacreacion, baja
FROM            apoyos
where dbo.apoyos.baja=0
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[ingresos]'
GO
CREATE TABLE [dbo].[ingresos]
(
[idingreso] [int] NOT NULL,
[idtipoingreso] [int] NULL,
[tipoingreso] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[folio] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fecha] [datetime] NULL,
[idcontribuyente] [int] NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[importe] [decimal] (18, 6) NULL,
[idempleado] [int] NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_ingresos] on [dbo].[ingresos]'
GO
ALTER TABLE [dbo].[ingresos] ADD CONSTRAINT [PK_ingresos] PRIMARY KEY CLUSTERED  ([idingreso])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[contribuyentes]'
GO
CREATE TABLE [dbo].[contribuyentes]
(
[idcontribuyente] [int] NOT NULL,
[rfc] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[nombre] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[correo] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[telefono] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[contacto] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[movil] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[domicilio] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_contribuyente] on [dbo].[contribuyentes]'
GO
ALTER TABLE [dbo].[contribuyentes] ADD CONSTRAINT [PK_contribuyente] PRIMARY KEY CLUSTERED  ([idcontribuyente])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[vingresos]'
GO

CREATE VIEW [dbo].[vingresos]
AS

SELECT idingreso, 
idtipoingreso,
tipoingreso, 
folio, fecha, 
idcontribuyente,
(select rfc from dbo.contribuyentes where dbo.contribuyentes.idcontribuyente = dbo.ingresos.idcontribuyente ) [rfc],
(select nombre from dbo.contribuyentes where dbo.contribuyentes.idcontribuyente = dbo.ingresos.idcontribuyente ) [nombrecontribuyente],
(select correo from dbo.contribuyentes where dbo.contribuyentes.idcontribuyente = dbo.ingresos.idcontribuyente ) [correo],
(select telefono from dbo.contribuyentes where dbo.contribuyentes.idcontribuyente = dbo.ingresos.idcontribuyente ) [telefono],
(select movil from dbo.contribuyentes where dbo.contribuyentes.idcontribuyente = dbo.ingresos.idcontribuyente ) [movil],
(select domicilio from dbo.contribuyentes where dbo.contribuyentes.idcontribuyente = dbo.ingresos.idcontribuyente ) [domicilio],
 descripcion, importe, 
 idempleado, 
 (select nombres + ' ' + apellidopaterno +' '+ apellidomaterno from dbo.empleados where dbo.empleados.idempleado = dbo.ingresos.idempleado) [nombrecompleto],
 usuario, baja
FROM            ingresos

GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[ordenes]'
GO
CREATE TABLE [dbo].[ordenes]
(
[idorden] [int] NOT NULL,
[folio] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fecha] [datetime] NULL,
[iddepartamento] [int] NULL,
[idempleado] [int] NULL,
[comentarios] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[iddocumentodigital] [int] NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechacreacion] [datetime] NULL CONSTRAINT [DF_ordenes_fechacreacion] DEFAULT (getdate()),
[baja] [bit] NULL CONSTRAINT [DF_ordenes_baja] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_ordenes] on [dbo].[ordenes]'
GO
ALTER TABLE [dbo].[ordenes] ADD CONSTRAINT [PK_ordenes] PRIMARY KEY CLUSTERED  ([idorden])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[vordenes]'
GO




CREATE VIEW [dbo].[vordenes]
AS

SELECT        idorden, folio, fecha, idempleado, 
(select  nombres + ' ' + apellidopaterno + ' ' + apellidomaterno from dbo.empleados where
dbo.empleados.idempleado = dbo.ordenes.idempleado) [nombrecompleto], 
(select nombre from dbo.puestos where dbo.puestos.idpuesto=
(select dbo.confdapempleados.idpuesto from dbo.confdapempleados where dbo.confdapempleados.idempleado = dbo.ordenes.idempleado and dbo.confdapempleados.baja=0)) [puesto], iddepartamento, 
(select nombre from dbo.departamentos where dbo.departamentos.iddepartamento = dbo.ordenes.iddepartamento) [nombredepartamento], comentarios, iddocumentodigital, usuario, fechacreacion, baja
FROM            dbo.ordenes
WHERE dbo.ordenes.baja=0



GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[pedidos]'
GO
CREATE TABLE [dbo].[pedidos]
(
[idpedido] [int] NOT NULL,
[folio] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fecha] [datetime] NULL,
[iddepartamento] [int] NULL,
[idempleado] [int] NULL,
[idproveedor] [int] NULL,
[comentarios] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[subtotal] [decimal] (18, 6) NULL,
[impuestostrasladados] [decimal] (18, 6) NULL,
[impuestosretenidos] [decimal] (18, 6) NULL,
[impuestostrasladadoslocales] [decimal] (18, 6) NULL,
[impuestosretenidoslocales] [decimal] (18, 6) NULL,
[descuentos] [decimal] (18, 6) NULL,
[total] [decimal] (18, 6) NULL,
[iddocumentodigital] [int] NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechacreacion] [datetime] NULL CONSTRAINT [DF_compras_fechacreacion] DEFAULT (getdate()),
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_compras] on [dbo].[pedidos]'
GO
ALTER TABLE [dbo].[pedidos] ADD CONSTRAINT [PK_compras] PRIMARY KEY CLUSTERED  ([idpedido])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[vpedidos]'
GO





CREATE VIEW [dbo].[vpedidos]
AS

SELECT        idpedido, folio, fecha, iddepartamento, ('') [nombredepartamento], idempleado, ('') [nombrecompleto], ('') [puesto], 
idproveedor, ('') [rfcproveedor],('') [nombreproveedor], ('') [domicilio],  comentarios, subtotal, impuestostrasladados, impuestosretenidos, impuestostrasladadoslocales, impuestosretenidoslocales, descuentos, total, 
                         iddocumentodigital, usuario, fechacreacion, baja
FROM   pedidos
WHERE pedidos.baja=0



GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[empresa]'
GO
CREATE TABLE [dbo].[empresa]
(
[idempresa] [int] NOT NULL,
[rfc] [nvarchar] (15) COLLATE Modern_Spanish_CI_AS NULL,
[nombre] [nvarchar] (1000) COLLATE Modern_Spanish_CI_AS NULL,
[cp] [nvarchar] (5) COLLATE Modern_Spanish_CI_AS NULL,
[calle] [nvarchar] (1000) COLLATE Modern_Spanish_CI_AS NULL,
[nointerior] [nvarchar] (100) COLLATE Modern_Spanish_CI_AS NULL,
[noexterior] [nvarchar] (100) COLLATE Modern_Spanish_CI_AS NULL,
[cruzamientos] [nvarchar] (1000) COLLATE Modern_Spanish_CI_AS NULL,
[referencias] [nvarchar] (1000) COLLATE Modern_Spanish_CI_AS NULL,
[colonia] [nvarchar] (1000) COLLATE Modern_Spanish_CI_AS NULL,
[localidad] [nvarchar] (1000) COLLATE Modern_Spanish_CI_AS NULL,
[municipio] [nvarchar] (1000) COLLATE Modern_Spanish_CI_AS NULL,
[estado] [nvarchar] (1000) COLLATE Modern_Spanish_CI_AS NULL,
[pais] [nvarchar] (1000) COLLATE Modern_Spanish_CI_AS NULL CONSTRAINT [DF_empresa_pais] DEFAULT (N'México'),
[version] [nvarchar] (10) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (100) COLLATE Modern_Spanish_CI_AS NULL CONSTRAINT [DF_empresa_usuario] DEFAULT (N'admin'),
[fechacreacion] [datetime] NULL CONSTRAINT [DF_empresa_fechacreacion] DEFAULT (getdate()),
[baja] [bit] NULL CONSTRAINT [DF_empresa_baja] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_empresa] on [dbo].[empresa]'
GO
ALTER TABLE [dbo].[empresa] ADD CONSTRAINT [PK_empresa] PRIMARY KEY CLUSTERED  ([idempresa])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[cfditasaimpuesto]'
GO
CREATE TABLE [dbo].[cfditasaimpuesto]
(
[idtasaimpuesto] [int] NULL,
[tipoimpuesto] [nvarchar] (5) COLLATE Modern_Spanish_CI_AS NULL,
[tipofactor] [nvarchar] (5) COLLATE Modern_Spanish_CI_AS NULL,
[clave] [nvarchar] (3) COLLATE Modern_Spanish_CI_AS NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[tasacuota] [decimal] (18, 6) NULL,
[traslado] [bit] NOT NULL CONSTRAINT [DF__cfditasai__trasl__02925FBF] DEFAULT ((0)),
[baja] [bit] NOT NULL CONSTRAINT [DF__cfditasaim__baja__038683F8] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[cfditiporegimen]'
GO
CREATE TABLE [dbo].[cfditiporegimen]
(
[clave] [nvarchar] (3) COLLATE Modern_Spanish_CI_AS NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NOT NULL CONSTRAINT [DF__cfditipore__baja__056ECC6A] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[parametros]'
GO
CREATE TABLE [dbo].[parametros]
(
[idparametro] [int] NOT NULL,
[dirdefault] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[dirbackup] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[dirxml] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[dirpdf] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[dirinformes] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[dirrecursoscfdi] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[direxportaciones] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[archivocer] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[archivokey] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[efirmapassword] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[ciecpassword] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[dirtmp] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[dirpaquetes] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[diropenssl] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[presidente] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[tesorero] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[supervisor] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[responsable] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[leyenda1] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[leyenda2] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[leyenda3] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[leyenda4] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[logoizquierdo] [image] NULL,
[logoderecho] [image] NULL,
[marcadeagua] [image] NULL,
[idformatosolicitud] [int] NULL,
[idformatopedido] [int] NULL,
[idformatoorden] [int] NULL,
[idformatogasolina] [int] NULL,
[idformatomantenimiento] [int] NULL,
[idformatoconstancia] [int] NULL,
[idformatoinforme] [int] NULL,
[usuario] [nvarchar] (100) COLLATE Modern_Spanish_CI_AS NULL CONSTRAINT [DF_empresas_usuario] DEFAULT (N'admin'),
[fechacreacion] [datetime] NULL CONSTRAINT [DF_empresas_fechacreacion] DEFAULT (getdate()),
[baja] [bit] NULL CONSTRAINT [DF_empresas_baja] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_empresas] on [dbo].[parametros]'
GO
ALTER TABLE [dbo].[parametros] ADD CONSTRAINT [PK_empresas] PRIMARY KEY CLUSTERED  ([idparametro])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[cfditiponomina]'
GO
CREATE TABLE [dbo].[cfditiponomina]
(
[clave] [nvarchar] (3) COLLATE Modern_Spanish_CI_AS NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NOT NULL CONSTRAINT [DF__cfditipono__baja__075714DC] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[cfditipojornada]'
GO
CREATE TABLE [dbo].[cfditipojornada]
(
[clave] [nvarchar] (3) COLLATE Modern_Spanish_CI_AS NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NOT NULL CONSTRAINT [DF__cfditipojo__baja__093F5D4E] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[cfditipocontrato]'
GO
CREATE TABLE [dbo].[cfditipocontrato]
(
[clave] [nvarchar] (3) COLLATE Modern_Spanish_CI_AS NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NOT NULL CONSTRAINT [DF__cfditipoco__baja__0B27A5C0] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[cfdiriesgopuesto]'
GO
CREATE TABLE [dbo].[cfdiriesgopuesto]
(
[clave] [nvarchar] (3) COLLATE Modern_Spanish_CI_AS NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NOT NULL CONSTRAINT [DF__cfdiriesgo__baja__0D0FEE32] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[cfdiregimenfiscal]'
GO
CREATE TABLE [dbo].[cfdiregimenfiscal]
(
[clave] [nvarchar] (3) COLLATE Modern_Spanish_CI_AS NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NOT NULL CONSTRAINT [DF__cfdiregime__baja__0EF836A4] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[cfdiperiodicidad]'
GO
CREATE TABLE [dbo].[cfdiperiodicidad]
(
[clave] [nvarchar] (3) COLLATE Modern_Spanish_CI_AS NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NOT NULL CONSTRAINT [DF__cfdiperiod__baja__10E07F16] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[cfdiorigenrecurso]'
GO
CREATE TABLE [dbo].[cfdiorigenrecurso]
(
[clave] [nvarchar] (3) COLLATE Modern_Spanish_CI_AS NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NOT NULL CONSTRAINT [DF__cfdiorigen__baja__12C8C788] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[detsolicitudes]'
GO
CREATE TABLE [dbo].[detsolicitudes]
(
[idsolicitud] [int] NOT NULL,
[iddetsolicitud] [int] NOT NULL,
[idconcepto] [int] NULL,
[idunidad] [int] NULL,
[fecha] [datetime] NULL CONSTRAINT [DF_detsolicitudes_fecha] DEFAULT (((1)/(1))/(1900)),
[cantidad] [decimal] (18, 6) NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechacreacion] [datetime] NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_detsolicitudes] on [dbo].[detsolicitudes]'
GO
ALTER TABLE [dbo].[detsolicitudes] ADD CONSTRAINT [PK_detsolicitudes] PRIMARY KEY CLUSTERED  ([idsolicitud], [iddetsolicitud])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[detordenes]'
GO
CREATE TABLE [dbo].[detordenes]
(
[idorden] [int] NOT NULL,
[iddetorden] [int] NOT NULL,
[idconcepto] [int] NULL,
[idunidad] [int] NULL,
[fecha] [datetime] NULL CONSTRAINT [DF_detordenes_fecha] DEFAULT (((1)/(1))/(1900)),
[cantidad] [decimal] (18, 6) NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechacreacion] [datetime] NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_detordenes] on [dbo].[detordenes]'
GO
ALTER TABLE [dbo].[detordenes] ADD CONSTRAINT [PK_detordenes] PRIMARY KEY CLUSTERED  ([idorden], [iddetorden])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[detconstancias]'
GO
CREATE TABLE [dbo].[detconstancias]
(
[idconstancia] [int] NOT NULL,
[iddetconstancia] [int] NOT NULL,
[idconcepto] [int] NULL,
[idunidad] [int] NULL,
[fecha] [datetime] NULL CONSTRAINT [DF_detconstancias_fecha] DEFAULT (((1)/(1))/(1900)),
[cantidad] [decimal] (18, 6) NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechacreacion] [datetime] NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_detconstancias] on [dbo].[detconstancias]'
GO
ALTER TABLE [dbo].[detconstancias] ADD CONSTRAINT [PK_detconstancias] PRIMARY KEY CLUSTERED  ([idconstancia], [iddetconstancia])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[impdetpedidos]'
GO
CREATE TABLE [dbo].[impdetpedidos]
(
[idimpdetpedido] [int] NOT NULL,
[idpedido] [int] NOT NULL,
[iddetpedido] [int] NOT NULL,
[idimpuesto] [int] NULL,
[tasa] [decimal] (18, 6) NULL,
[importe] [decimal] (18, 6) NULL,
[cveimpuesto] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[nombre] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL CONSTRAINT [DF_impdetpedidos_baja] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_impdetcompras] on [dbo].[impdetpedidos]'
GO
ALTER TABLE [dbo].[impdetpedidos] ADD CONSTRAINT [PK_impdetcompras] PRIMARY KEY CLUSTERED  ([idimpdetpedido], [idpedido], [iddetpedido])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[detinformes]'
GO
CREATE TABLE [dbo].[detinformes]
(
[idinforme] [int] NOT NULL,
[iddetinforme] [int] NOT NULL,
[idconcepto] [int] NULL,
[idunidad] [int] NULL,
[fecha] [datetime] NULL CONSTRAINT [DF_detinformes_fecha] DEFAULT (((1)/(1))/(1900)),
[cantidad] [decimal] (18, 6) NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[destino01] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[destino02] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[destino03] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[destino04] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechacreacion] [datetime] NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_detinformes] on [dbo].[detinformes]'
GO
ALTER TABLE [dbo].[detinformes] ADD CONSTRAINT [PK_detinformes] PRIMARY KEY CLUSTERED  ([idinforme], [iddetinforme])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[detgasolinas]'
GO
CREATE TABLE [dbo].[detgasolinas]
(
[iddetgasolina] [int] NOT NULL,
[idgasolina] [int] NULL,
[fecha] [datetime] NULL,
[kminicial] [decimal] (18, 6) NULL,
[kmfinal] [decimal] (18, 6) NULL,
[origen] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[destino] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[kmrecorridos] [decimal] (18, 6) NULL,
[litros] [decimal] (18, 6) NULL,
[pesos] [decimal] (18, 6) NULL,
[motivoviaje] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[factor] [decimal] (18, 6) NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL CONSTRAINT [DF_detgasolinas_baja] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_detgasolinas] on [dbo].[detgasolinas]'
GO
ALTER TABLE [dbo].[detgasolinas] ADD CONSTRAINT [PK_detgasolinas] PRIMARY KEY CLUSTERED  ([iddetgasolina])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[detmantenimientos]'
GO
CREATE TABLE [dbo].[detmantenimientos]
(
[iddetmantenimiento] [int] NOT NULL,
[idmantenimiento] [int] NULL,
[idconcepto] [int] NULL,
[idunidad] [int] NULL,
[cantidad] [decimal] (18, 6) NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL CONSTRAINT [DF_detmantenimientos_baja] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_detmantenimientos] on [dbo].[detmantenimientos]'
GO
ALTER TABLE [dbo].[detmantenimientos] ADD CONSTRAINT [PK_detmantenimientos] PRIMARY KEY CLUSTERED  ([iddetmantenimiento])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[cfdiformapago]'
GO
CREATE TABLE [dbo].[cfdiformapago]
(
[clave] [nvarchar] (3) COLLATE Modern_Spanish_CI_AS NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NOT NULL CONSTRAINT [DF__cfdiformap__baja__7AF13DF7] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[cfdimetodopago]'
GO
CREATE TABLE [dbo].[cfdimetodopago]
(
[clave] [nvarchar] (3) COLLATE Modern_Spanish_CI_AS NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NOT NULL CONSTRAINT [DF__cfdimetodo__baja__7CD98669] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[cfdiuso]'
GO
CREATE TABLE [dbo].[cfdiuso]
(
[clave] [nvarchar] (3) COLLATE Modern_Spanish_CI_AS NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NOT NULL CONSTRAINT [DF__cfdiuso__baja__7EC1CEDB] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[cfditiporelacionfiscal]'
GO
CREATE TABLE [dbo].[cfditiporelacionfiscal]
(
[clave] [nvarchar] (3) COLLATE Modern_Spanish_CI_AS NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NOT NULL CONSTRAINT [DF__cfditipore__baja__00AA174D] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[cobropredial]'
GO
CREATE TABLE [dbo].[cobropredial]
(
[idcobropredial] [int] NOT NULL,
[idcontribuyente] [int] NULL,
[valorcatrastral] [decimal] (6, 4) NULL,
[limiteinferior] [decimal] (6, 4) NULL,
[factorexcedentelimite] [decimal] (6, 4) NULL,
[cuotafija] [decimal] (6, 4) NULL,
[total] [decimal] (6, 4) NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[contribuyentesapocrifos]'
GO
CREATE TABLE [dbo].[contribuyentesapocrifos]
(
[idcontribuyenteapocrifo] [int] NOT NULL,
[rfc] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[nombre] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[situacion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[oficiosat] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechasat] [datetime] NULL,
[oficiodof] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechadof] [datetime] NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_contribuyentesapocrifos] on [dbo].[contribuyentesapocrifos]'
GO
ALTER TABLE [dbo].[contribuyentesapocrifos] ADD CONSTRAINT [PK_contribuyentesapocrifos] PRIMARY KEY CLUSTERED  ([idcontribuyenteapocrifo])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[detapoyos]'
GO
CREATE TABLE [dbo].[detapoyos]
(
[idapoyo] [int] NOT NULL,
[iddetapoyo] [int] NOT NULL,
[idconcepto] [int] NULL,
[cantidad] [decimal] (18, 6) NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[idunidad] [int] NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechacreacion] [datetime] NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_detapoyos] on [dbo].[detapoyos]'
GO
ALTER TABLE [dbo].[detapoyos] ADD CONSTRAINT [PK_detapoyos] PRIMARY KEY CLUSTERED  ([idapoyo], [iddetapoyo])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[detpedidos]'
GO
CREATE TABLE [dbo].[detpedidos]
(
[idpedido] [int] NOT NULL,
[iddetdetpedido] [int] NOT NULL,
[idconcepto] [int] NULL,
[idunidad] [int] NULL,
[cantidad] [decimal] (18, 6) NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[preciounitario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[subtotal] [decimal] (18, 6) NULL,
[impuestostrasladados] [decimal] (18, 6) NULL,
[impuestosretenidos] [decimal] (18, 6) NULL,
[impuestostrasladadoslocales] [decimal] (18, 6) NULL,
[impuestosretenidoslocales] [decimal] (18, 6) NULL,
[descuentos] [decimal] (18, 6) NULL,
[total] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[comentarios] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[iddocumentodigital] [int] NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechacreacion] [datetime] NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_detcompras] on [dbo].[detpedidos]'
GO
ALTER TABLE [dbo].[detpedidos] ADD CONSTRAINT [PK_detcompras] PRIMARY KEY CLUSTERED  ([idpedido], [iddetdetpedido])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[documentosdigitales]'
GO
CREATE TABLE [dbo].[documentosdigitales]
(
[iddocumentodigital] [int] NOT NULL,
[tiposolicitud] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[ejercicio] [int] NULL,
[periodo] [int] NULL,
[serie] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[folio] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[tipoxml] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[uuid] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[rfcemisor] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[nombreemisor] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[rfcreceptor] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[nombrereceptor] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[rfcpac] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechaemision] [datetime] NULL,
[fechacertificacionsat] [datetime] NULL,
[subtotal] [decimal] (18, 6) NULL,
[totaltrasladados] [decimal] (18, 6) NULL,
[totalretenidos] [decimal] (18, 6) NULL,
[totaltrasladadoslocales] [decimal] (18, 6) NULL,
[totalretenidoslocales] [decimal] (18, 6) NULL,
[monto] [decimal] (18, 6) NULL,
[estatus] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechacancelacion] [datetime] NULL,
[xml] [varbinary] (max) NULL,
[codigoestatus] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[escancelable] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[estatuscancelacion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[validacionefos] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[clasificador] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[id] [int] NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_documentosdigitales] on [dbo].[documentosdigitales]'
GO
ALTER TABLE [dbo].[documentosdigitales] ADD CONSTRAINT [PK_documentosdigitales] PRIMARY KEY CLUSTERED  ([iddocumentodigital])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[documentosdigitalesconceptos]'
GO
CREATE TABLE [dbo].[documentosdigitalesconceptos]
(
[iddocumentodigitalconcepto] [int] NOT NULL,
[iddocumentodigital] [int] NULL,
[cantidad] [decimal] (18, 6) NULL,
[noidentificacion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[unidad] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[claveunidad] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[descripcion] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[valorunitario] [decimal] (18, 6) NULL,
[importe] [decimal] (18, 6) NULL,
[claveprodserv] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[destino01] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[destino02] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[destino03] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[destino04] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_documentosdigitalesconceptos] on [dbo].[documentosdigitalesconceptos]'
GO
ALTER TABLE [dbo].[documentosdigitalesconceptos] ADD CONSTRAINT [PK_documentosdigitalesconceptos] PRIMARY KEY CLUSTERED  ([iddocumentodigitalconcepto])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[documentosdigitalesimpuestos]'
GO
CREATE TABLE [dbo].[documentosdigitalesimpuestos]
(
[iddocumentodigitalimpuesto] [int] NOT NULL,
[iddocumentodigital] [int] NULL,
[iddocumentodigitalconcepto] [int] NULL,
[tipoimpuesto] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baseimpuesto] [decimal] (18, 6) NULL,
[impuesto] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[tipofactor] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[tasaocuota] [decimal] (18, 6) NULL,
[importe] [decimal] (18, 6) NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_impuestosdocumentosdigitales] on [dbo].[documentosdigitalesimpuestos]'
GO
ALTER TABLE [dbo].[documentosdigitalesimpuestos] ADD CONSTRAINT [PK_impuestosdocumentosdigitales] PRIMARY KEY CLUSTERED  ([iddocumentodigitalimpuesto])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[formatos]'
GO
CREATE TABLE [dbo].[formatos]
(
[idformato] [int] NOT NULL,
[tipogeneral] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[clasificador] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[tipo] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[nombre] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[vigente] [bit] NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_informes] on [dbo].[formatos]'
GO
ALTER TABLE [dbo].[formatos] ADD CONSTRAINT [PK_informes] PRIMARY KEY CLUSTERED  ([idformato])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[impuestos]'
GO
CREATE TABLE [dbo].[impuestos]
(
[idimpuesto] [int] NOT NULL,
[tipoimpuesto] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[cveimpuesto] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[nombre] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[tasa] [decimal] (18, 6) NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_impuestos] on [dbo].[impuestos]'
GO
ALTER TABLE [dbo].[impuestos] ADD CONSTRAINT [PK_impuestos] PRIMARY KEY CLUSTERED  ([idimpuesto])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[movinventarios]'
GO
CREATE TABLE [dbo].[movinventarios]
(
[idmovinventario] [int] NOT NULL,
[tipomovimiento] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[origen] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[idreferencia] [int] NULL,
[referencia] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[idconcepto] [int] NULL,
[anterior] [decimal] (18, 6) NULL,
[cantidad] [decimal] (18, 6) NULL,
[posterior] [decimal] (18, 6) NULL,
[idunidad] [int] NULL,
[fecha] [datetime] NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[fechacreacion] [datetime] NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_movinventarios] on [dbo].[movinventarios]'
GO
ALTER TABLE [dbo].[movinventarios] ADD CONSTRAINT [PK_movinventarios] PRIMARY KEY CLUSTERED  ([idmovinventario])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[proveedores]'
GO
CREATE TABLE [dbo].[proveedores]
(
[idproveedor] [int] NOT NULL,
[rfc] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[nombre] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[correo] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[telefono] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[contacto] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[movil] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[domicilio] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_proveedores] on [dbo].[proveedores]'
GO
ALTER TABLE [dbo].[proveedores] ADD CONSTRAINT [PK_proveedores] PRIMARY KEY CLUSTERED  ([idproveedor])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[seriesfoliacion]'
GO
CREATE TABLE [dbo].[seriesfoliacion]
(
[idseriefoliacion] [int] NOT NULL,
[tiposerie] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[serie] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[inicial] [int] NULL,
[actual] [int] NULL,
[vigente] [bit] NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_seriesfoliacion] on [dbo].[seriesfoliacion]'
GO
ALTER TABLE [dbo].[seriesfoliacion] ADD CONSTRAINT [PK_seriesfoliacion] PRIMARY KEY CLUSTERED  ([idseriefoliacion])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[solicitudesdescargas]'
GO
CREATE TABLE [dbo].[solicitudesdescargas]
(
[idsolicituddescarga] [int] NOT NULL,
[fechainicial] [datetime] NULL,
[fechafinal] [datetime] NULL,
[rfcemisor] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[rfcreceptor] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[rfcsolicitante] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[tiposolicitud] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[idsolicitud] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[estatus] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[mensaje] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[idpaquetes] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[numerocfdis] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_solicitudesdescargas] on [dbo].[solicitudesdescargas]'
GO
ALTER TABLE [dbo].[solicitudesdescargas] ADD CONSTRAINT [PK_solicitudesdescargas] PRIMARY KEY CLUSTERED  ([idsolicituddescarga])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[tipoingresos]'
GO
CREATE TABLE [dbo].[tipoingresos]
(
[idtipoingreso] [int] NOT NULL,
[nombre] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[usuario] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL,
[baja] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_tipoingresos] on [dbo].[tipoingresos]'
GO
ALTER TABLE [dbo].[tipoingresos] ADD CONSTRAINT [PK_tipoingresos] PRIMARY KEY CLUSTERED  ([idtipoingreso])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[valorpredial]'
GO
CREATE TABLE [dbo].[valorpredial]
(
[idvalorcatastral] [int] NOT NULL,
[limiteinferior] [decimal] (18, 6) NULL,
[limitesuperior] [decimal] (18, 6) NULL,
[cuotafijanual] [decimal] (18, 6) NULL,
[factorexcedentelimite] [decimal] (18, 6) NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_valorpredial] on [dbo].[valorpredial]'
GO
ALTER TABLE [dbo].[valorpredial] ADD CONSTRAINT [PK_valorpredial] PRIMARY KEY CLUSTERED  ([idvalorcatastral])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating extended properties'
GO
EXEC sp_addextendedproperty N'MS_Description', N'interno, externo', 'SCHEMA', N'dbo', 'TABLE', N'conceptos', 'COLUMN', N'grupo'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_Description', N'producto,servicio', 'SCHEMA', N'dbo', 'TABLE', N'conceptos', 'COLUMN', N'tipoconcepto'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_Description', N'Valor de fecha que se usará para capturas manuales que contengan varios comprobantes NO FACTURADOS', 'SCHEMA', N'dbo', 'TABLE', N'detconstancias', 'COLUMN', N'fecha'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_Description', N'Valor de fecha que se usará para capturas manuales que contengan varios comprobantes NO FACTURADOS', 'SCHEMA', N'dbo', 'TABLE', N'detinformes', 'COLUMN', N'fecha'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_Description', N'Valor de fecha que se usará para capturas manuales que contengan varios comprobantes NO FACTURADOS', 'SCHEMA', N'dbo', 'TABLE', N'detordenes', 'COLUMN', N'fecha'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_Description', N'Valor de fecha que se usará para capturas manuales que contengan varios comprobantes NO FACTURADOS', 'SCHEMA', N'dbo', 'TABLE', N'detsolicitudes', 'COLUMN', N'fecha'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_Description', N'idcompra', 'SCHEMA', N'dbo', 'TABLE', N'movinventarios', 'COLUMN', N'idreferencia'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_Description', N'compras,ajustes,apoyos,otros', 'SCHEMA', N'dbo', 'TABLE', N'movinventarios', 'COLUMN', N'origen'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_Description', N'folio de compra', 'SCHEMA', N'dbo', 'TABLE', N'movinventarios', 'COLUMN', N'referencia'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_Description', N'entrada,salida', 'SCHEMA', N'dbo', 'TABLE', N'movinventarios', 'COLUMN', N'tipomovimiento'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_Description', N'metadata o cfdi', 'SCHEMA', N'dbo', 'TABLE', N'solicitudesdescargas', 'COLUMN', N'tiposolicitud'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_DiagramPane1', N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[48] 2[6] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "apoyos"
            Begin Extent = 
               Top = 4
               Left = 472
               Bottom = 208
               Right = 642
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "beneficiarios"
            Begin Extent = 
               Top = 179
               Left = 154
               Bottom = 351
               Right = 324
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "tipoapoyos"
            Begin Extent = 
               Top = 9
               Left = 45
               Bottom = 139
               Right = 215
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2820
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', 'SCHEMA', N'dbo', 'VIEW', N'vapoyos', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
DECLARE @xp int
SELECT @xp=1
EXEC sp_addextendedproperty N'MS_DiagramPaneCount', @xp, 'SCHEMA', N'dbo', 'VIEW', N'vapoyos', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_DiagramPane1', N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[14] 4[16] 2[61] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "confdapempleados"
            Begin Extent = 
               Top = 25
               Left = 42
               Bottom = 155
               Right = 238
            End
            DisplayFlags = 280
            TopColumn = 6
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', 'SCHEMA', N'dbo', 'VIEW', N'vconfdapempleados', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
DECLARE @xp int
SELECT @xp=1
EXEC sp_addextendedproperty N'MS_DiagramPaneCount', @xp, 'SCHEMA', N'dbo', 'VIEW', N'vconfdapempleados', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_DiagramPane1', N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[32] 4[41] 2[10] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "departamentos"
            Begin Extent = 
               Top = 0
               Left = 64
               Bottom = 130
               Right = 238
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "gasolinas"
            Begin Extent = 
               Top = 4
               Left = 525
               Bottom = 165
               Right = 699
            End
            DisplayFlags = 280
            TopColumn = 8
         End
         Begin Table = "vehiculos"
            Begin Extent = 
               Top = 134
               Left = 66
               Bottom = 264
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "empleados"
            Begin Extent = 
               Top = 170
               Left = 306
               Bottom = 300
               Right = 482
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 3120
         Alias = 4005
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', 'SCHEMA', N'dbo', 'VIEW', N'vgasolinas', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
DECLARE @xp int
SELECT @xp=1
EXEC sp_addextendedproperty N'MS_DiagramPaneCount', @xp, 'SCHEMA', N'dbo', 'VIEW', N'vgasolinas', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_DiagramPane1', N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[30] 4[61] 2[6] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = -44
      End
      Begin Tables = 
         Begin Table = "contribuyentes"
            Begin Extent = 
               Top = 0
               Left = 139
               Bottom = 130
               Right = 312
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ingresos"
            Begin Extent = 
               Top = 18
               Left = 615
               Bottom = 148
               Right = 788
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tipoingresos"
            Begin Extent = 
               Top = 148
               Left = 142
               Bottom = 278
               Right = 312
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "empleados"
            Begin Extent = 
               Top = 194
               Left = 400
               Bottom = 324
               Right = 576
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 4890
         Alias = 2895
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', 'SCHEMA', N'dbo', 'VIEW', N'vingresos', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
DECLARE @xp int
SELECT @xp=1
EXEC sp_addextendedproperty N'MS_DiagramPaneCount', @xp, 'SCHEMA', N'dbo', 'VIEW', N'vingresos', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_DiagramPane1', N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[57] 4[33] 2[5] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "inventarios"
            Begin Extent = 
               Top = 47
               Left = 467
               Bottom = 177
               Right = 637
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "unidades"
            Begin Extent = 
               Top = 161
               Left = 145
               Bottom = 291
               Right = 315
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "conceptos"
            Begin Extent = 
               Top = 9
               Left = 150
               Bottom = 139
               Right = 320
            End
            DisplayFlags = 280
            TopColumn = 3
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', 'SCHEMA', N'dbo', 'VIEW', N'vinventarios', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
DECLARE @xp int
SELECT @xp=1
EXEC sp_addextendedproperty N'MS_DiagramPaneCount', @xp, 'SCHEMA', N'dbo', 'VIEW', N'vinventarios', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_DiagramPane1', N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[52] 4[30] 2[0] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "empleados"
            Begin Extent = 
               Top = 148
               Left = 197
               Bottom = 278
               Right = 373
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "mantenimientos"
            Begin Extent = 
               Top = 68
               Left = 475
               Bottom = 198
               Right = 656
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "vehiculos"
            Begin Extent = 
               Top = 11
               Left = 202
               Bottom = 141
               Right = 372
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', 'SCHEMA', N'dbo', 'VIEW', N'vmantenimientos', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
DECLARE @xp int
SELECT @xp=1
EXEC sp_addextendedproperty N'MS_DiagramPaneCount', @xp, 'SCHEMA', N'dbo', 'VIEW', N'vmantenimientos', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_DiagramPane1', N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[57] 4[35] 2[5] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "empleados"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 214
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ordenes"
            Begin Extent = 
               Top = 16
               Left = 388
               Bottom = 176
               Right = 628
            End
            DisplayFlags = 280
            TopColumn = 8
         End
         Begin Table = "departamentos"
            Begin Extent = 
               Top = 160
               Left = 40
               Bottom = 328
               Right = 214
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "areas"
            Begin Extent = 
               Top = 234
               Left = 409
               Bottom = 364
               Right = 579
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "proveedores"
            Begin Extent = 
               Top = 178
               Left = 666
               Bottom = 308
               Right = 836
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 4380
         Alias = 2895
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
      ', 'SCHEMA', N'dbo', 'VIEW', N'vordenes', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_DiagramPane2', N'   Or = 1350
      End
   End
End
', 'SCHEMA', N'dbo', 'VIEW', N'vordenes', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
DECLARE @xp int
SELECT @xp=2
EXEC sp_addextendedproperty N'MS_DiagramPaneCount', @xp, 'SCHEMA', N'dbo', 'VIEW', N'vordenes', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_DiagramPane1', N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[24] 4[68] 2[5] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "solicitudes"
            Begin Extent = 
               Top = 39
               Left = 178
               Bottom = 333
               Right = 435
            End
            DisplayFlags = 280
            TopColumn = 7
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 3000
         Alias = 3285
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', 'SCHEMA', N'dbo', 'VIEW', N'vsolicitudes', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
DECLARE @xp int
SELECT @xp=1
EXEC sp_addextendedproperty N'MS_DiagramPaneCount', @xp, 'SCHEMA', N'dbo', 'VIEW', N'vsolicitudes', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
COMMIT TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
DECLARE @Success AS BIT
SET @Success = 1
SET NOEXEC OFF
IF (@Success = 1) PRINT 'The database update succeeded'
ELSE BEGIN
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT 'The database update failed'
END
GO
