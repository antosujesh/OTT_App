SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_loginDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_loginDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Movies]    Script Date: 02/02/2025 12:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Movies](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NULL,
	[Rating] [nchar](10) NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedDate] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Movies] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_loginDetails] ON 

INSERT [dbo].[tbl_loginDetails] ([ID], [Username], [Password]) VALUES (1, N'admin', N'admin@123')
INSERT [dbo].[tbl_loginDetails] ([ID], [Username], [Password]) VALUES (2, N'Anto', N'Anto@123')
SET IDENTITY_INSERT [dbo].[tbl_loginDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Movies] ON 

INSERT [dbo].[tbl_Movies] ([ID], [Type], [Rating], [Name], [CreatedDate]) VALUES (1, N'Movies', N'8         ', N'The Flash', N'20/11/2024')
INSERT [dbo].[tbl_Movies] ([ID], [Type], [Rating], [Name], [CreatedDate]) VALUES (2, N'Movies', N'7         ', N'Man of steel', N'20/11/2024')
INSERT [dbo].[tbl_Movies] ([ID], [Type], [Rating], [Name], [CreatedDate]) VALUES (3, N'Movies', N'9         ', N'Terminator', N'20/11/2024')
INSERT [dbo].[tbl_Movies] ([ID], [Type], [Rating], [Name], [CreatedDate]) VALUES (4, N'TV Shows', N'8         ', N'The Boys', N'20/11/2024')
INSERT [dbo].[tbl_Movies] ([ID], [Type], [Rating], [Name], [CreatedDate]) VALUES (5, N'TV Shows', N'9         ', N'Friends', N'20/11/2024')
INSERT [dbo].[tbl_Movies] ([ID], [Type], [Rating], [Name], [CreatedDate]) VALUES (6, N'TV Shows', N'8         ', N'The Office', N'20/11/2024')
INSERT [dbo].[tbl_Movies] ([ID], [Type], [Rating], [Name], [CreatedDate]) VALUES (7, N'TV Shows', N'9         ', N'Dexter', N'20/11/2024')
INSERT [dbo].[tbl_Movies] ([ID], [Type], [Rating], [Name], [CreatedDate]) VALUES (8, N'Movies', N'8         ', N'test Movie name ', NULL)
INSERT [dbo].[tbl_Movies] ([ID], [Type], [Rating], [Name], [CreatedDate]) VALUES (9, N'TV Shows', N'8         ', N'test TV Shows ', NULL)
INSERT [dbo].[tbl_Movies] ([ID], [Type], [Rating], [Name], [CreatedDate]) VALUES (10, N'TV Shows', N'8         ', N'test TV Shows ', NULL)
INSERT [dbo].[tbl_Movies] ([ID], [Type], [Rating], [Name], [CreatedDate]) VALUES (11, N'TV Shows', N'8         ', N'test TV Shows ', NULL)
SET IDENTITY_INSERT [dbo].[tbl_Movies] OFF
GO
