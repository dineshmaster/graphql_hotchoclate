USE [DB_Cinema]
GO
/****** Object:  Table [dbo].[Cinemas]    Script Date: 02-04-2020 11:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cinemas](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NULL,
	[Description] [nvarchar](1000) NULL,
	[Duration] [numeric](6, 2) NULL,
 CONSTRAINT [PK_Cinema] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Cinemas] ON 

INSERT [dbo].[Cinemas] ([ID], [Title], [Description], [Duration]) VALUES (1, N'Avengers', N'Nice one', CAST(2.45 AS Numeric(6, 2)))
INSERT [dbo].[Cinemas] ([ID], [Title], [Description], [Duration]) VALUES (2, N'Big Brother', N'Good One', CAST(2.00 AS Numeric(6, 2)))
SET IDENTITY_INSERT [dbo].[Cinemas] OFF
