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


insert into seriesfoliacion values (1, 'solicitud','S',1,0,1,0);
insert into seriesfoliacion values (2, 'pedido','P',1,0,1,0);
insert into seriesfoliacion values (3, 'orden','O',1,0,1,0);
insert into seriesfoliacion values (4, 'gasolina','G',1,0,1,0);
insert into seriesfoliacion values (5, 'mantenimiento','M',1,0,1,0);
insert into seriesfoliacion values (6, 'constancia','C',1,0,1,0);
insert into seriesfoliacion values (7, 'informe','I',1,0,1,0);
insert into seriesfoliacion values (8, 'compra','COM',1,0,1,0);
insert into seriesfoliacion values (9, 'predial','PRE',1,0,1,0);
insert into seriesfoliacion values (10, 'agua','AGU',1,0,1,0);
insert into seriesfoliacion values (11, 'derecho','DER',1,0,1,0);
insert into seriesfoliacion values (12, 'licencia','LIC',1,0,1,0);
insert into seriesfoliacion values (13, 'multa','MUL',1,0,1,0);
insert into seriesfoliacion values (14, 'permiso','PER',1,0,1,0);
insert into seriesfoliacion values (15, 'cuota','CUO',1,0,1,0);


insert into formatos values (1,'recibidos','compra','solicitud','rptsolicitud.rpt',1,0)
insert into formatos values (2,'recibidos','compra','pedido','rptpedido.rpt',1,0)
insert into formatos values (3,'recibidos','compra','orden','rptorden.rpt',1,0)
insert into formatos values (4,'recibidos','compra','constancia','rptconstancia.rpt',1,0)
insert into formatos values (5,'recibidos','compra','informe','rptinforme.rpt',1,0)

insert into formatos values (6,'recibidos','gasto','solicitud','rptsolicitud.rpt',1,0)
insert into formatos values (7,'recibidos','gasto','pedido','rptpedido.rpt',1,0)
insert into formatos values (8,'recibidos','gasto','orden','rptorden.rpt',1,0)
insert into formatos values (9,'recibidos','gasto','constancia','rptconstancia.rpt',1,0)
insert into formatos values (10,'recibidos','gasto','informe','rptinforme.rpt',1,0)


insert into formatos values (11,'recibidos','combustible','solicitud','rptsolicitud.rpt',1,0)
insert into formatos values (12,'recibidos','combustible','pedido','rptpedido.rpt',1,0)
insert into formatos values (13,'recibidos','combustible','orden','rptorden.rpt',1,0)
insert into formatos values (14,'recibidos','combustible','gasolina','rptgasolina.rpt',1,0)
insert into formatos values (15,'recibidos','combustible','constancia','rptconstancia.rpt',1,0)
insert into formatos values (16,'recibidos','combustible','informe','rptinforme.rpt',1,0)

insert into formatos values (17,'recibidos','mantenimiento','solicitud','rptsolicitud.rpt',1,0)
insert into formatos values (18,'recibidos','mantenimiento','pedido','rptpedido.rpt',1,0)
insert into formatos values (19,'recibidos','mantenimiento','orden','rptorden.rpt',1,0)
insert into formatos values (20,'recibidos','mantenimiento','mantenimiento','rptmantenimiento.rpt',1,0)
insert into formatos values (21,'recibidos','mantenimiento','constancia','rptconstancia.rpt',1,0)
insert into formatos values (22,'recibidos','mantenimiento','informe','rptinforme.rpt',1,0)


insert into formatos values (30,'emitidos','activofijo','ninguno','rptactivofijo.rpt',1,0)



insert into tipoingresos values (1,'predial','admin',0)
insert into tipoingresos values (2,'agua','admin',0)
insert into tipoingresos values (3,'derecho','admin',0)
insert into tipoingresos values (4,'licencia','admin',0)
insert into tipoingresos values (5,'multa','admin',0)
insert into tipoingresos values (6,'permiso','admin',0)
insert into tipoingresos values (7,'cuota','admin',0)

insert into tipoapoyos values (1,'efectivo','admin',0)
insert into tipoapoyos values (2,'especie','admin',0)


insert into cfdiunidad values ('H87','Pieza',0)
insert into cfdiunidad values ('EA','Elemento',0)
insert into cfdiunidad values ('E48','Unidad de Servicio',0)
insert into cfdiunidad values ('ACT','Actividad',0)
insert into cfdiunidad values ('KGM','Kilogramo',0)
insert into cfdiunidad values ('E51','Trabajo',0)
insert into cfdiunidad values ('A9','Tarifa',0)
insert into cfdiunidad values ('MTR','Metro',0)
insert into cfdiunidad values ('AB','Paquete a granel',0)
insert into cfdiunidad values ('BB','Caja base',0)
insert into cfdiunidad values ('KT','Kit',0)
insert into cfdiunidad values ('SET','Conjunto',0)
insert into cfdiunidad values ('LTR','Litro',0)
insert into cfdiunidad values ('XBX','Caja',0)
insert into cfdiunidad values ('MON','Mes',0)
insert into cfdiunidad values ('HUR','Hora',0)
insert into cfdiunidad values ('MTK','Metro cuadrado',0)
insert into cfdiunidad values ('11','Equipos',0)
insert into cfdiunidad values ('XPK','Paquete',0)
insert into cfdiunidad values ('XKI','Kit (Conjunto de piezas)',0)
insert into cfdiunidad values ('AS','Variedad',0)
insert into cfdiunidad values ('GRM','Gramo',0)
insert into cfdiunidad values ('PR','Par',0)
insert into cfdiunidad values ('DPC','Docenas de piezas',0)
insert into cfdiunidad values ('xun','Unidad',0)
insert into cfdiunidad values ('DAY','Día',0)
insert into cfdiunidad values ('XLT','Lote',0)
insert into cfdiunidad values ('10','Grupos',0)
insert into cfdiunidad values ('MLT','Mililitro',0)
insert into cfdiunidad values ('E54','Viaje',0)




insert into unidades values (1,'Pieza','H87','H87',0,'admin',0)
insert into unidades values (2,'Elemento','EA','EA',0,'admin',0)
insert into unidades values (3,'Unidad de Servicio','E48','E48',0,'admin',0)
insert into unidades values (4,'Actividad','ACT','ACT',0,'admin',0)
insert into unidades values (5,'Kilogramo','KGM','KGM',0,'admin',0)
insert into unidades values (6,'Trabajo','E51','E51',0,'admin',0)
insert into unidades values (7,'Tarifa','A9','A9',0,'admin',0)
insert into unidades values (8,'Metro','MTR','MTR',0,'admin',0)
insert into unidades values (9,'Paquete a granel','AB','AB',0,'admin',0)
insert into unidades values (10,'Caja base','BB','BB',0,'admin',0)
insert into unidades values (11,'Kit','KT','KT',0,'admin',0)
insert into unidades values (12,'Conjunto','SET','SET',0,'admin',0)
insert into unidades values (13,'Litro','LTR','LTR',0,'admin',0)
insert into unidades values (14,'Caja','XBX','XBX',0,'admin',0)
insert into unidades values (15,'Mes','MON','MON',0,'admin',0)
insert into unidades values (16,'Hora','HUR','HUR',0,'admin',0)
insert into unidades values (17,'Metro cuadrado','MTK','MTK',0,'admin',0)
insert into unidades values (18,'Equipos','11','11',0,'admin',0)
insert into unidades values (19,'Paquete','XPK','XPK',0,'admin',0)
insert into unidades values (20,'Kit (Conjunto de piezas)','XKI','XKI',0,'admin',0)
insert into unidades values (21,'Variedad','AS','AS',0,'admin',0)
insert into unidades values (22,'Gramo','GRM','GRM',0,'admin',0)
insert into unidades values (23,'Par','PR','PR',0,'admin',0)
insert into unidades values (24,'Docenas de piezas','DPC','DPC',0,'admin',0)
insert into unidades values (25,'Unidad','xun','xun',0,'admin',0)
insert into unidades values (26,'Día','DAY','DAY',0,'admin',0)
insert into unidades values (27,'Lote','XLT','XLT',0,'admin',0)
insert into unidades values (28,'Grupos','10','10',0,'admin',0)
insert into unidades values (29,'Mililitro','MLT','MLT',0,'admin',0)
insert into unidades values (30,'Viaje','E54','E54',0,'admin',0)


insert into impuestos values (1,'trasladado','002','IVA',16.000000,0,'admin',0)
insert into impuestos values (2,'retenido','002','IVA',10.666700,0,'admin',0)
insert into impuestos values (3,'retenido','002','IVA',6.000000,0,'admin',0)
insert into impuestos values (4,'retenido','002','ISR',10.000000,0,'admin',0)


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