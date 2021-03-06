-- ----------------------------
-- Table structure for Category
-- ----------------------------
DROP TABLE [dbo].[Category]
GO
CREATE TABLE [dbo].[Category] (
[Id] int NOT NULL IDENTITY(1,1) ,
[Name] varchar(100) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Category]', RESEED, 4)
GO

-- ----------------------------
-- Records of Category
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Category] ON
GO
INSERT INTO [dbo].[Category] ([Id], [Name]) VALUES (N'1', N'Category1')
GO
GO
INSERT INTO [dbo].[Category] ([Id], [Name]) VALUES (N'2', N'Category2')
GO
GO
INSERT INTO [dbo].[Category] ([Id], [Name]) VALUES (N'3', N'Category3')
GO
GO
INSERT INTO [dbo].[Category] ([Id], [Name]) VALUES (N'4', N'Category4')
GO
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO

-- ----------------------------
-- Indexes structure for table Category
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Category
-- ----------------------------
ALTER TABLE [dbo].[Category] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Table structure for Contact
-- ----------------------------
DROP TABLE [dbo].[Contact]
GO
CREATE TABLE [dbo].[Contact] (
[Id] int NOT NULL IDENTITY(1,1) ,
[Name] varchar(50) NOT NULL ,
[LastName] varchar(50) NOT NULL ,
[Email] varchar(100) NULL ,
[Phone] varchar(15) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Contact]', RESEED, 4)
GO

-- ----------------------------
-- Records of Contact
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Contact] ON
GO
INSERT INTO [dbo].[Contact] ([Id], [Name], [LastName], [Email], [Phone]) VALUES (N'1', N'Contact1', N'LastContat1', N'constact1@example.com', N'3199999999')
GO
GO
INSERT INTO [dbo].[Contact] ([Id], [Name], [LastName], [Email], [Phone]) VALUES (N'2', N'Contact2', N'LastContact2', N'contact2@example.com', N'31888888888')
GO
GO
INSERT INTO [dbo].[Contact] ([Id], [Name], [LastName], [Email], [Phone]) VALUES (N'3', N'Contact3', N'LastContact3', N'contact3@example.com', N'317777777777')
GO
GO
INSERT INTO [dbo].[Contact] ([Id], [Name], [LastName], [Email], [Phone]) VALUES (N'4', N'Contact4', N'LastContact4', N'contact4@example.com', N'31666666666666')
GO
GO
SET IDENTITY_INSERT [dbo].[Contact] OFF
GO

-- ----------------------------
-- Indexes structure for table Contact
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Contact
-- ----------------------------
ALTER TABLE [dbo].[Contact] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Table structure for Leads
-- ----------------------------
DROP TABLE [dbo].[Leads]
GO
CREATE TABLE [dbo].[Leads] (
[Id] uniqueidentifier NOT NULL ,
[CategoryId] int NOT NULL ,
[ContactId] int NOT NULL ,
[Suburb] varchar(100) NOT NULL ,
[Price] decimal(10,2) NOT NULL ,
[Description] text NULL ,
[DateCreated] datetime NOT NULL ,
[Status] varchar(1) NULL 
)


GO

-- ----------------------------
-- Records of Leads
-- ----------------------------
INSERT INTO [dbo].[Leads] ([Id], [CategoryId], [ContactId], [Suburb], [Price], [Description], [DateCreated], [Status]) VALUES (N'4CFC8160-6593-4713-54CB-08DA4CAC58DB', N'1', N'1', N'Rua A numero 10', N'10.00', N'Teste description', N'2022-06-12 00:00:00.000', N'A')
GO
GO
INSERT INTO [dbo].[Leads] ([Id], [CategoryId], [ContactId], [Suburb], [Price], [Description], [DateCreated], [Status]) VALUES (N'0EE9C361-E1F4-4144-B019-18873CCE5344', N'1', N'2', N'Rua A numero 10', N'10.00', N'Teste description', N'2022-06-12 00:00:00.000', N'')
GO
GO
INSERT INTO [dbo].[Leads] ([Id], [CategoryId], [ContactId], [Suburb], [Price], [Description], [DateCreated], [Status]) VALUES (N'8DFCCFF6-3F7D-4F91-9DE3-229AC79374FA', N'3', N'3', N'Rua A numero 12', N'12.00', N'Teste description3', N'2022-06-12 00:00:00.000', N'')
GO
GO
INSERT INTO [dbo].[Leads] ([Id], [CategoryId], [ContactId], [Suburb], [Price], [Description], [DateCreated], [Status]) VALUES (N'4DB04C5E-F382-4BA9-894B-AD847C926337', N'1', N'4', N'Rua A numero 10', N'10.00', N'Teste description', N'2022-06-12 00:00:00.000', N'')
GO
GO
INSERT INTO [dbo].[Leads] ([Id], [CategoryId], [ContactId], [Suburb], [Price], [Description], [DateCreated], [Status]) VALUES (N'318F5938-D413-4B35-8076-F60932739178', N'1', N'2', N'Rua A numero 10', N'10.00', N'Teste description', N'2022-06-12 00:00:00.000', null)
GO
GO

-- ----------------------------
-- Indexes structure for table Leads
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Leads
-- ----------------------------
ALTER TABLE [dbo].[Leads] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[Leads]
-- ----------------------------
ALTER TABLE [dbo].[Leads] ADD FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[Leads] ADD FOREIGN KEY ([ContactId]) REFERENCES [dbo].[Contact] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Table structure for StoredEvent
-- ----------------------------
DROP TABLE [dbo].[StoredEvent]
GO
CREATE TABLE [dbo].[StoredEvent] (
[Id] uniqueidentifier NOT NULL ,
[AggregateId] uniqueidentifier NOT NULL ,
[Data] nvarchar(MAX) NULL ,
[Action] varchar(100) NULL ,
[CreationDate] datetime2(7) NOT NULL ,
[User] nvarchar(MAX) NULL 
)


GO

-- ----------------------------
-- Indexes structure for table StoredEvent
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table StoredEvent
-- ----------------------------
ALTER TABLE [dbo].[StoredEvent] ADD PRIMARY KEY ([Id])
GO
