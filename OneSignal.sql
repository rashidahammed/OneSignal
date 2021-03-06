USE [OneSignal]
GO
/****** Object:  User [test]    Script Date: 2020-10-21 12:25:57 AM ******/
CREATE USER [test] FOR LOGIN [test] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [test]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [test]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [test]
GO
ALTER ROLE [db_datareader] ADD MEMBER [test]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [test]
GO
/****** Object:  Table [dbo].[tbl_UserRole]    Script Date: 2020-10-21 12:25:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserRole](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Users]    Script Date: 2020-10-21 12:25:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[UserStatus] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_UserStatus]    Script Date: 2020-10-21 12:25:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserStatus](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbl_UserRole] ON 

INSERT [dbo].[tbl_UserRole] ([RoleID], [RoleName], [IsActive]) VALUES (1, N'Admin', 1)
INSERT [dbo].[tbl_UserRole] ([RoleID], [RoleName], [IsActive]) VALUES (2, N'Data Entry Operator', 1)
SET IDENTITY_INSERT [dbo].[tbl_UserRole] OFF
SET IDENTITY_INSERT [dbo].[tbl_Users] ON 

INSERT [dbo].[tbl_Users] ([UserID], [RoleID], [UserName], [Password], [FullName], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate]) VALUES (1, 1, N'Admin', N'12345', N'rashid', 1, N'SuperAdmin', N'SuperAdmin', CAST(N'2020-10-19T21:13:06.040' AS DateTime), CAST(N'2020-10-19T21:13:06.040' AS DateTime))
INSERT [dbo].[tbl_Users] ([UserID], [RoleID], [UserName], [Password], [FullName], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate]) VALUES (2, 2, N'DataEntryOperator', N'12345', N'Data Entry Operator', 1, N'SuperAdmin', N'SuperAdmin', CAST(N'2020-10-19T21:15:34.560' AS DateTime), CAST(N'2020-10-19T21:15:34.560' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_Users] OFF
SET IDENTITY_INSERT [dbo].[tbl_UserStatus] ON 

INSERT [dbo].[tbl_UserStatus] ([StatusId], [Status], [Description]) VALUES (1, N'Active', N'Active user')
INSERT [dbo].[tbl_UserStatus] ([StatusId], [Status], [Description]) VALUES (2, N'Inactive', N'inactive user')
INSERT [dbo].[tbl_UserStatus] ([StatusId], [Status], [Description]) VALUES (3, N'Deleted', N'Deleted user')
SET IDENTITY_INSERT [dbo].[tbl_UserStatus] OFF
/****** Object:  StoredProcedure [dbo].[sp_UserLogin]    Script Date: 2020-10-21 12:25:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UserLogin]
	@UserName nvarchar(50),
	@Password Nvarchar(50)
	AS
BEGIN

	SET NOCOUNT ON;
	select 
	   [UserID],
	   [RoleID]
      ,[UserName]
      ,[FullName]
      ,[UserStatus]
	  from [dbo].[tbl_Users] with(nolock) 
    where UserName=@UserName and Password=@Password and UserStatus=1
     
END

GO
