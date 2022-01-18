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


/* CREATE TABLE [dbo].[cfditiporegimen](
	[clave] [nvarchar](3),
	[descripcion] [nvarchar](max) NULL,
	[baja] [bit] not null default 0,
)
 */

insert into cfditiporegimen (clave, descripcion) values ('02', 'Sueldos');
insert into cfditiporegimen (clave, descripcion) values ('03', 'Jubilados');
insert into cfditiporegimen (clave, descripcion) values ('04', 'Pensionados');
insert into cfditiporegimen (clave, descripcion) values ('05', 'Asimilados Miembros Sociedades Cooperativas Produccion');
insert into cfditiporegimen (clave, descripcion) values ('06', 'Asimilados Integrantes Sociedades Asociaciones Civiles');
insert into cfditiporegimen (clave, descripcion) values ('07', 'Asimilados Miembros consejos');
insert into cfditiporegimen (clave, descripcion) values ('08', 'Asimilados comisionistas');
insert into cfditiporegimen (clave, descripcion) values ('09', 'Asimilados Honorarios');
insert into cfditiporegimen (clave, descripcion) values ('10', 'Asimilados acciones');
insert into cfditiporegimen (clave, descripcion) values ('11', 'Asimilados otros');
insert into cfditiporegimen (clave, descripcion) values ('99', 'Otro Regimen');



/* CREATE TABLE [dbo].[cfditiponomina](
	[clave] [nvarchar](3),
	[descripcion] [nvarchar](max) NULL,
	[baja] [bit] not null default 0,
)
 */

insert into cfditiponomina (clave, descripcion) values ('O', 'Nómina ordinaria');
insert into cfditiponomina (clave, descripcion) values ('E', 'Nómina extraordinaria');



/* CREATE TABLE [dbo].[cfditipojornada](
	[clave] [nvarchar](3),
	[descripcion] [nvarchar](max) NULL,
	[baja] [bit] not null default 0,
)
 */
insert into cfditipojornada (clave, descripcion) values ('01', 'Diurna');
insert into cfditipojornada (clave, descripcion) values ('02', 'Nocturna');
insert into cfditipojornada (clave, descripcion) values ('03', 'Mixta');
insert into cfditipojornada (clave, descripcion) values ('04', 'Por hora');
insert into cfditipojornada (clave, descripcion) values ('05', 'Reducida');
insert into cfditipojornada (clave, descripcion) values ('06', 'Continuada');
insert into cfditipojornada (clave, descripcion) values ('07', 'Partida');
insert into cfditipojornada (clave, descripcion) values ('08', 'Por turnos');
insert into cfditipojornada (clave, descripcion) values ('99', 'Otra Jornada');


/* CREATE TABLE [dbo].[cfditipocontrato](
	[clave] [nvarchar](3),
	[descripcion] [nvarchar](max) NULL,
	[baja] [bit] not null default 0,
)

 */
insert into cfditipocontrato (clave, descripcion) values ('01', 'Contrato de trabajo por tiempo indeterminado');
insert into cfditipocontrato (clave, descripcion) values ('02', 'Contrato de trabajo para obra determinada');
insert into cfditipocontrato (clave, descripcion) values ('03', 'Contrato de trabajo por tiempo determinado');
insert into cfditipocontrato (clave, descripcion) values ('04', 'Contrato de trabajo por temporada');
insert into cfditipocontrato (clave, descripcion) values ('05', 'Contrato de trabajo sujeto a prueba');
insert into cfditipocontrato (clave, descripcion) values ('06', 'Contrato de trabajo con capacitación inicial');
insert into cfditipocontrato (clave, descripcion) values ('07', 'Modalidad de contratación por pago de hora laborada');
insert into cfditipocontrato (clave, descripcion) values ('08', 'Modalidad de trabajo por comisión laboral');
insert into cfditipocontrato (clave, descripcion) values ('09', 'Modalidades de contratación donde no existe relación de trabajo');
insert into cfditipocontrato (clave, descripcion) values ('10', 'Jubilación, pensión, retiro.');
insert into cfditipocontrato (clave, descripcion) values ('99', 'Otro contrato');



/* 
CREATE TABLE [dbo].[cfdiriesgopuesto](
	[clave] [nvarchar](3),
	[descripcion] [nvarchar](max) NULL,
	[baja] [bit] not null default 0,
)
 */
insert into cfdiriesgopuesto (clave, descripcion) values ('0', 'No clasificado');
insert into cfdiriesgopuesto (clave, descripcion) values ('1', 'Clase I');
insert into cfdiriesgopuesto (clave, descripcion) values ('2', 'Clase II');
insert into cfdiriesgopuesto (clave, descripcion) values ('3', 'Clase III');
insert into cfdiriesgopuesto (clave, descripcion) values ('4', 'Clase IV');
insert into cfdiriesgopuesto (clave, descripcion) values ('5', 'Clase V');


/* 
CREATE TABLE [dbo].[cfdiregimenfiscal](
	[clave] [nvarchar](3),
	[descripcion] [nvarchar](max) NULL,
	[baja] [bit] not null default 0,
)
 */
insert into cfdiregimenfiscal (clave, descripcion) values ('601', 'General de Ley Personas Morales');
insert into cfdiregimenfiscal (clave, descripcion) values ('603', 'Personas Morales con Fines no Lucrativos');
insert into cfdiregimenfiscal (clave, descripcion) values ('605', 'Sueldos y Salarios e Ingresos Asimilados a Salarios');
insert into cfdiregimenfiscal (clave, descripcion) values ('606', 'Arrendamiento');
insert into cfdiregimenfiscal (clave, descripcion) values ('608', 'Demás ingresos');
insert into cfdiregimenfiscal (clave, descripcion) values ('609', 'Consolidación');
insert into cfdiregimenfiscal (clave, descripcion) values ('610', 'Residentes en el Extranjero sin Establecimiento Permanente en México');
insert into cfdiregimenfiscal (clave, descripcion) values ('611', 'Ingresos por Dividendos (socios y accionistas)');
insert into cfdiregimenfiscal (clave, descripcion) values ('612', 'Personas Físicas con Actividades Empresariales y Profesionales');
insert into cfdiregimenfiscal (clave, descripcion) values ('614', 'Ingresos por intereses');
insert into cfdiregimenfiscal (clave, descripcion) values ('616', 'Sin obligaciones fiscales');
insert into cfdiregimenfiscal (clave, descripcion) values ('620', 'Sociedades Cooperativas de Producción que optan por diferir sus ingresos');
insert into cfdiregimenfiscal (clave, descripcion) values ('621', 'Incorporación Fiscal');
insert into cfdiregimenfiscal (clave, descripcion) values ('622', 'Actividades Agrícolas, Ganaderas, Silvícolas y Pesqueras');
insert into cfdiregimenfiscal (clave, descripcion) values ('623', 'Opcional para Grupos de Sociedades');
insert into cfdiregimenfiscal (clave, descripcion) values ('624', 'Coordinados');
insert into cfdiregimenfiscal (clave, descripcion) values ('628', 'Hidrocarburos');
insert into cfdiregimenfiscal (clave, descripcion) values ('607', 'Régimen de Enajenación o Adquisición de Bienes');
insert into cfdiregimenfiscal (clave, descripcion) values ('629', 'De los Regímenes Fiscales Preferentes y de las Empresas Multinacionales');
insert into cfdiregimenfiscal (clave, descripcion) values ('630', 'Enajenación de acciones en bolsa de valores');
insert into cfdiregimenfiscal (clave, descripcion) values ('615', 'Régimen de los ingresos por obtención de premios');


/* CREATE TABLE [dbo].[cfdiperiodicidad](
	[clave] [nvarchar](3),
	[descripcion] [nvarchar](max) NULL,
	[baja] [bit] not null default 0,
)
 */
insert into cfdiperiodicidad (clave, descripcion) values ('01', 'Diario');
insert into cfdiperiodicidad (clave, descripcion) values ('02', 'Semanal');
insert into cfdiperiodicidad (clave, descripcion) values ('03', 'Catorcenal');
insert into cfdiperiodicidad (clave, descripcion) values ('04', 'Quincenal');
insert into cfdiperiodicidad (clave, descripcion) values ('05', 'Mensual');
insert into cfdiperiodicidad (clave, descripcion) values ('06', 'Bimestral');
insert into cfdiperiodicidad (clave, descripcion) values ('07', 'Unidad obra');
insert into cfdiperiodicidad (clave, descripcion) values ('08', 'Comisión');
insert into cfdiperiodicidad (clave, descripcion) values ('09', 'Precio alzado');
insert into cfdiperiodicidad (clave, descripcion) values ('99', 'Otra Periodicidad');


/* 
CREATE TABLE [dbo].[cfdiorigenrecurso](
	[clave] [nvarchar](3),
	[descripcion] [nvarchar](max) NULL,
	[baja] [bit] not null default 0,
) */

insert into cfdiorigenrecurso (clave, descripcion) values ('IP', 'Ingresos propios');
insert into cfdiorigenrecurso (clave, descripcion) values ('IF', 'Ingreso federales');
insert into cfdiorigenrecurso (clave, descripcion) values ('IM', 'Ingresos mixtos');



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







