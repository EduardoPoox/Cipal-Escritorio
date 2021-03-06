/*
Run this script on:

        (local)\SQLSERVER2012.basegeneral    -  This database will be modified

to synchronize it with:

        (local)\SQLSERVER2012.default

You are recommended to back up your database before running this script

Script created by SQL Compare version 11.1.0 from Red Gate Software Ltd at 10/06/2021 10:55:38 a. m.

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
PRINT N'Creating [dbo].[usuarios]'
GO
CREATE TABLE [dbo].[usuarios]
(
[id] [int] NOT NULL IDENTITY(1, 1),
[username] [nvarchar] (100) COLLATE Modern_Spanish_CI_AS NULL,
[password] [nvarchar] (10) COLLATE Modern_Spanish_CI_AS NULL,
[fechacreacion] [datetime] NULL CONSTRAINT [DF_usuarios_fechacreacion] DEFAULT (getdate()),
[baja] [bit] NULL CONSTRAINT [DF_usuarios_baja] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_usuarios] on [dbo].[usuarios]'
GO
ALTER TABLE [dbo].[usuarios] ADD CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED  ([id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[empresas]'
GO
CREATE TABLE [dbo].[empresas]
(
[idbase] [int] NULL,
[prefix] [nvarchar] (10) COLLATE Modern_Spanish_CI_AS NULL,
[idempresa] [int] NULL,
[rfc] [nvarchar] (15) COLLATE Modern_Spanish_CI_AS NULL,
[nombre] [nvarchar] (1000) COLLATE Modern_Spanish_CI_AS NULL,
[dirbackup] [nvarchar] (1000) COLLATE Modern_Spanish_CI_AS NULL,
[dbname] [nvarchar] (1000) COLLATE Modern_Spanish_CI_AS NULL,
[version] [nvarchar] (10) COLLATE Modern_Spanish_CI_AS NULL
)
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
