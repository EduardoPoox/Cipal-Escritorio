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


/* CREATE TABLE [dbo].[cfdiformapago](
	[clave] [nvarchar](3),
	[descripcion] [nvarchar](max) NULL,
	[baja] [bit] not null default 0,
) */


insert into cfdiformapago (clave, descripcion) values ('01', 'Efectivo');
insert into cfdiformapago (clave, descripcion) values ('02', 'Cheque nominativo');
insert into cfdiformapago (clave, descripcion) values ('03', 'Transferencia electrónica de fondos');
insert into cfdiformapago (clave, descripcion) values ('04', 'Tarjeta de crédito');
insert into cfdiformapago (clave, descripcion) values ('05', 'Monedero electrónico');
insert into cfdiformapago (clave, descripcion) values ('06', 'Dinero electrónico');
insert into cfdiformapago (clave, descripcion) values ('08', 'Vales de despensa');
insert into cfdiformapago (clave, descripcion) values ('12', 'Dación en pago');
insert into cfdiformapago (clave, descripcion) values ('13', 'Pago por subrogación');
insert into cfdiformapago (clave, descripcion) values ('14', 'Pago por consignación');
insert into cfdiformapago (clave, descripcion) values ('15', 'Condonación');
insert into cfdiformapago (clave, descripcion) values ('17', 'Compensación');
insert into cfdiformapago (clave, descripcion) values ('23', 'Novación');
insert into cfdiformapago (clave, descripcion) values ('24', 'Confusión');
insert into cfdiformapago (clave, descripcion) values ('25', 'Remisión de deuda');
insert into cfdiformapago (clave, descripcion) values ('26', 'Prescripción o caducidad');
insert into cfdiformapago (clave, descripcion) values ('27', 'A satisfacción del acreedor');
insert into cfdiformapago (clave, descripcion) values ('28', 'Tarjeta de débito');
insert into cfdiformapago (clave, descripcion) values ('29', 'Tarjeta de servicios');
insert into cfdiformapago (clave, descripcion) values ('99', 'Por definir');
insert into cfdiformapago (clave, descripcion) values ('30', 'Aplicación de anticipos');


/* CREATE TABLE [dbo].[cfdimetodopago](
	[clave] [nvarchar](3),
	[descripcion] [nvarchar](max) NULL,
	[baja] [bit] not null default 0,
) */


insert into cfdimetodopago (clave, descripcion) values ('PUE', 'Pago en una sola exhibición');
insert into cfdimetodopago (clave, descripcion) values ('PPD', 'Pago en parcialidades o diferido');


/* CREATE TABLE [dbo].[cfdiuso](
	[clave] [nvarchar](3),
	[descripcion] [nvarchar](max) NULL,
	[baja] [bit] not null default 0,
) */


insert into cfdiuso (clave, descripcion) values ('G01', 'Adquisición de mercancias');
insert into cfdiuso (clave, descripcion) values ('G02', 'Devoluciones, descuentos o bonificaciones');
insert into cfdiuso (clave, descripcion) values ('G03', 'Gastos en general');
insert into cfdiuso (clave, descripcion) values ('I01', 'Construcciones');
insert into cfdiuso (clave, descripcion) values ('I02', 'Mobilario y equipo de oficina por inversiones');
insert into cfdiuso (clave, descripcion) values ('I03', 'Equipo de transporte');
insert into cfdiuso (clave, descripcion) values ('I04', 'Equipo de computo y accesorios');
insert into cfdiuso (clave, descripcion) values ('I05', 'Dados, troqueles, moldes, matrices y herramental');
insert into cfdiuso (clave, descripcion) values ('I06', 'Comunicaciones telefónicas');
insert into cfdiuso (clave, descripcion) values ('I07', 'Comunicaciones satelitales');
insert into cfdiuso (clave, descripcion) values ('I08', 'Otra maquinaria y equipo');
insert into cfdiuso (clave, descripcion) values ('D01', 'Honorarios médicos, dentales y gastos hospitalarios.');
insert into cfdiuso (clave, descripcion) values ('D02', 'Gastos médicos por incapacidad o discapacidad');
insert into cfdiuso (clave, descripcion) values ('D03', 'Gastos funerales.');
insert into cfdiuso (clave, descripcion) values ('D04', 'Donativos.');
insert into cfdiuso (clave, descripcion) values ('D05', 'Intereses reales efectivamente pagados por créditos hipotecarios (casa habitación).');
insert into cfdiuso (clave, descripcion) values ('D06', 'Aportaciones voluntarias al SAR.');
insert into cfdiuso (clave, descripcion) values ('D07', 'Primas por seguros de gastos médicos.');
insert into cfdiuso (clave, descripcion) values ('D08', 'Gastos de transportación escolar obligatoria.');
insert into cfdiuso (clave, descripcion) values ('D09', 'Depósitos en cuentas para el ahorro, primas que tengan como base planes de pensiones.');
insert into cfdiuso (clave, descripcion) values ('D10', 'Pagos por servicios educativos (colegiaturas)');
insert into cfdiuso (clave, descripcion) values ('P01', 'Por definir');



/* CREATE TABLE [dbo].[cfditiporelacionfiscal](
	[clave] [nvarchar](3),
	[descripcion] [nvarchar](max) NULL,
	[baja] [bit] not null default 0,
)
 */
insert into cfditiporelacionfiscal (clave, descripcion) values ('01', 'Nota de crédito de los documentos relacionados');
insert into cfditiporelacionfiscal (clave, descripcion) values ('02', 'Nota de débito de los documentos relacionados');
insert into cfditiporelacionfiscal (clave, descripcion) values ('03', 'Devolución de mercancía sobre facturas o traslados previos');
insert into cfditiporelacionfiscal (clave, descripcion) values ('04', 'Sustitución de los CFDI previos');
insert into cfditiporelacionfiscal (clave, descripcion) values ('05', 'Traslados de mercancias facturados previamente');
insert into cfditiporelacionfiscal (clave, descripcion) values ('06', 'Factura generada por los traslados previos');
insert into cfditiporelacionfiscal (clave, descripcion) values ('07', 'CFDI por aplicación de anticipo');

/* 
CREATE TABLE [dbo].[cfditasaimpuesto](
    [idtasaimpuesto] [int],
	[tipoimpuesto] [nvarchar](5),
	[tipofactor] [nvarchar](5),
	[clave] [nvarchar](3),
	[descripcion] [nvarchar](max) NULL,
	[tasacuota] [decimal](18,6),
	[traslado] [bit] not null default 0,
	[baja] [bit] not null default 0,
) */

insert into cfditasaimpuesto (idtasaimpuesto, tipoimpuesto, tipofactor, clave, descripcion, tasacuota, traslado) values ('1', 'IVA', 'Tasa', '002', 'IVA 16%', '16.000000', '1');
insert into cfditasaimpuesto (idtasaimpuesto, tipoimpuesto, tipofactor, clave, descripcion, tasacuota, traslado) values ('2', 'IVA', 'Tasa', '002', 'IVA RET 2/3', '10.666700', '0');
insert into cfditasaimpuesto (idtasaimpuesto, tipoimpuesto, tipofactor, clave, descripcion, tasacuota, traslado) values ('3', 'IVA', 'Tasa', '002', 'IVA RET 6%', '6.000000', '0');
insert into cfditasaimpuesto (idtasaimpuesto, tipoimpuesto, tipofactor, clave, descripcion, tasacuota, traslado) values ('4', 'ISR', 'Tasa', '001', 'RET ISR', '10.000000', '0');


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