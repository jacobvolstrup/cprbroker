
/****** Object:  Table [dbo].[Application]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Application]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Application](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Token] [varchar](50) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[ApprovedDate] [datetime] NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ActorRef]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ActorRef]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ActorRef](
	[ActorRefId] [uniqueidentifier] NOT NULL,
	[Type] [int] NOT NULL,
	[Value] [varchar](50) NULL,
 CONSTRAINT [PK_ActorRef] PRIMARY KEY CLUSTERED 
(
	[ActorRefId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[LifecycleStatus]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LifecycleStatus]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LifecycleStatus](
	[LifecycleStatusId] [int] NOT NULL,
	[LifecycleStatusName] [varchar](50) NULL,
 CONSTRAINT [PK_LifecycleStatus] PRIMARY KEY CLUSTERED 
(
	[LifecycleStatusId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PersonMapping]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PersonMapping]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PersonMapping](
	[UUID] [uniqueidentifier] NOT NULL,
	[CprNumber] [varchar](10) NOT NULL,
 CONSTRAINT [PK_PersonMapping] PRIMARY KEY CLUSTERED 
(
	[UUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_PersonMapping] UNIQUE NONCLUSTERED 
(
	[CprNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Person]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Person]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Person](
	[UUID] [uniqueidentifier] NOT NULL,
	[UserInterfaceKeyText] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Object] PRIMARY KEY CLUSTERED 
(
	[UUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[LogType]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LogType](
	[LogTypeId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LogType] PRIMARY KEY CLUSTERED 
(
	[LogTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

/****** Object:  Table [dbo].[LogEntry]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogEntry]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LogEntry](
	[LogEntryId] [uniqueidentifier] NOT NULL,
	[LogTypeId] [int] NOT NULL,
	[ApplicationId] [uniqueidentifier] NULL,
	[UserToken] [varchar](250) NULL,
	[UserId] [varchar](250) NULL,
	[MethodName] [varchar](250) NULL,
	[Text] [nvarchar](max) NULL,
	[DataObjectType] [varchar](250) NULL,
	[DataObjectXml] [ntext] NULL,
	[LogDate] [datetime] NOT NULL,
	[ActivityId] [uniqueidentifier] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[LogEntry]') AND name = N'IX_LogEntry_LogDate')
CREATE CLUSTERED INDEX [IX_LogEntry_LogDate] ON [dbo].[LogEntry] 
(
	[LogDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[LogEntry]') AND name = N'PK_LogEntry')
CREATE UNIQUE NONCLUSTERED INDEX [PK_LogEntry] ON [dbo].[LogEntry] 
(
	[LogEntryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExtractPersonStaging]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExtractPersonStaging]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExtractPersonStaging](
	[ExtractPersonStagingId] [uniqueidentifier] NOT NULL,
	[ExtractId] [uniqueidentifier] NOT NULL,
	[PNR] [varchar](10) NOT NULL,
 CONSTRAINT [PK_ExtractPersonStaging] PRIMARY KEY CLUSTERED 
(
	[ExtractPersonStagingId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ExtractPersonStaging]') AND name = N'IX_ExtractPersonStaging_ExtractId')
CREATE NONCLUSTERED INDEX [IX_ExtractPersonStaging_ExtractId] ON [dbo].[ExtractPersonStaging] 
(
	[ExtractId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExtractItem]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExtractItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExtractItem](
	[ExtractItemId] [uniqueidentifier] NOT NULL,
	[ExtractId] [uniqueidentifier] NOT NULL,
	[PNR] [varchar](10) NOT NULL,
	[RelationPNR] [varchar](10) NULL,
	[RelationPNR2] [varchar](10) NULL,
	[DataTypeCode] [varchar](10) NOT NULL,
	[Contents] [nvarchar](max) NOT NULL,
 CONSTRAINT [UK_ExtractItem_ExtractItemId] UNIQUE NONCLUSTERED 
(
	[ExtractItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ExtractItem]') AND name = N'IX_ExtractItem_PNR_ExtractId')
CREATE CLUSTERED INDEX [IX_ExtractItem_PNR_ExtractId] ON [dbo].[ExtractItem] 
(
	[PNR] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ExtractItem]') AND name = N'IX_ExtractItem_ExtractId')
CREATE NONCLUSTERED INDEX [IX_ExtractItem_ExtractId] ON [dbo].[ExtractItem] 
(
	[ExtractId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ExtractItem]') AND name = N'IX_ExtractItem_RelationPNR')
CREATE NONCLUSTERED INDEX [IX_ExtractItem_RelationPNR] ON [dbo].[ExtractItem] 
(
	[RelationPNR] ASC
)
INCLUDE ( [DataTypeCode]) 
WHERE ([PNR] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExtractError]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExtractError]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExtractError](
	[ExtractErrorId] [uniqueidentifier] NOT NULL,
	[ExtractId] [uniqueidentifier] NOT NULL,
	[Contents] [nvarchar](157) NOT NULL,
 CONSTRAINT [PK_ExtractError] PRIMARY KEY CLUSTERED 
(
	[ExtractErrorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Default [DF_Application_ApplicationId]    Script Date: 11/21/2013 10:16:51 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Application_ApplicationId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Application]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Application_ApplicationId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_ApplicationId]  DEFAULT (newid()) FOR [ApplicationId]
END


End
GO
/****** Object:  Default [DF_Application_IsApproved]    Script Date: 11/21/2013 10:16:51 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Application_IsApproved]') AND parent_object_id = OBJECT_ID(N'[dbo].[Application]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Application_IsApproved]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_IsApproved]  DEFAULT ((0)) FOR [IsApproved]
END


End
GO
/****** Object:  Default [DF_ActorRef_ActorRefId]    Script Date: 11/21/2013 10:16:51 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ActorRef_ActorRefId]') AND parent_object_id = OBJECT_ID(N'[dbo].[ActorRef]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ActorRef_ActorRefId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ActorRef] ADD  CONSTRAINT [DF_ActorRef_ActorRefId]  DEFAULT (newid()) FOR [ActorRefId]
END


End
GO
/****** Object:  Default [DF_Person_UUID]    Script Date: 11/21/2013 10:16:51 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Person_UUID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Person]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Person_UUID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_UUID]  DEFAULT (newid()) FOR [UUID]
END


End
GO
/****** Object:  Default [DF_ExtractPersonStaging_ExtractPersonStagingId]    Script Date: 11/21/2013 10:16:51 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ExtractPersonStaging_ExtractPersonStagingId]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtractPersonStaging]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ExtractPersonStaging_ExtractPersonStagingId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ExtractPersonStaging] ADD  CONSTRAINT [DF_ExtractPersonStaging_ExtractPersonStagingId]  DEFAULT (newid()) FOR [ExtractPersonStagingId]
END


End
GO
/****** Object:  Default [DF_ExtractItem_ExtractItemId]    Script Date: 11/21/2013 10:16:51 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ExtractItem_ExtractItemId]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtractItem]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ExtractItem_ExtractItemId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ExtractItem] ADD  CONSTRAINT [DF_ExtractItem_ExtractItemId]  DEFAULT (newid()) FOR [ExtractItemId]
END


End
GO
/****** Object:  Default [DF__ExtractEr__Extra__75586032]    Script Date: 11/21/2013 10:16:51 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__ExtractEr__Extra__75586032]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtractError]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ExtractEr__Extra__75586032]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ExtractError] ADD  DEFAULT (newid()) FOR [ExtractErrorId]
END


End
GO
/****** Object:  ForeignKey [FK_LogEntry_Application]    Script Date: 11/21/2013 10:16:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LogEntry_Application]') AND parent_object_id = OBJECT_ID(N'[dbo].[LogEntry]'))
ALTER TABLE [dbo].[LogEntry]  WITH NOCHECK ADD  CONSTRAINT [FK_LogEntry_Application] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Application] ([ApplicationId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LogEntry_Application]') AND parent_object_id = OBJECT_ID(N'[dbo].[LogEntry]'))
ALTER TABLE [dbo].[LogEntry] NOCHECK CONSTRAINT [FK_LogEntry_Application]
GO
/****** Object:  ForeignKey [FK_LogEntry_LogType]    Script Date: 11/21/2013 10:16:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LogEntry_LogType]') AND parent_object_id = OBJECT_ID(N'[dbo].[LogEntry]'))
ALTER TABLE [dbo].[LogEntry]  WITH CHECK ADD  CONSTRAINT [FK_LogEntry_LogType] FOREIGN KEY([LogTypeId])
REFERENCES [dbo].[LogType] ([LogTypeId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LogEntry_LogType]') AND parent_object_id = OBJECT_ID(N'[dbo].[LogEntry]'))
ALTER TABLE [dbo].[LogEntry] CHECK CONSTRAINT [FK_LogEntry_LogType]
GO
/****** Object:  ForeignKey [FK_ExtractPersonStaging_Extract]    Script Date: 11/21/2013 10:16:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExtractPersonStaging_Extract]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtractPersonStaging]'))
ALTER TABLE [dbo].[ExtractPersonStaging]  WITH CHECK ADD  CONSTRAINT [FK_ExtractPersonStaging_Extract] FOREIGN KEY([ExtractId])
REFERENCES [dbo].[Extract] ([ExtractId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExtractPersonStaging_Extract]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtractPersonStaging]'))
ALTER TABLE [dbo].[ExtractPersonStaging] CHECK CONSTRAINT [FK_ExtractPersonStaging_Extract]
GO
/****** Object:  ForeignKey [FK_ExtractItem_Extract]    Script Date: 11/21/2013 10:16:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExtractItem_Extract]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtractItem]'))
ALTER TABLE [dbo].[ExtractItem]  WITH NOCHECK ADD  CONSTRAINT [FK_ExtractItem_Extract] FOREIGN KEY([ExtractId])
REFERENCES [dbo].[Extract] ([ExtractId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExtractItem_Extract]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtractItem]'))
ALTER TABLE [dbo].[ExtractItem] CHECK CONSTRAINT [FK_ExtractItem_Extract]
GO
/****** Object:  ForeignKey [FK_ExtractError_Extract]    Script Date: 11/21/2013 10:16:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExtractError_Extract]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtractError]'))
ALTER TABLE [dbo].[ExtractError]  WITH CHECK ADD  CONSTRAINT [FK_ExtractError_Extract] FOREIGN KEY([ExtractId])
REFERENCES [dbo].[Extract] ([ExtractId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExtractError_Extract]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtractError]'))
ALTER TABLE [dbo].[ExtractError] CHECK CONSTRAINT [FK_ExtractError_Extract]
GO
