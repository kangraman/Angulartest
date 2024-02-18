USE [Angular]
GO
/****** Object:  Table [dbo].[table_Country]    Script Date: 18-02-2024 14:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_Country](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Countryname] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[table_State]    Script Date: 18-02-2024 14:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_State](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NULL,
	[Country] [varchar](20) NULL,
	[StateName] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[table_State]  WITH CHECK ADD  CONSTRAINT [FK_table_State_table_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[table_Country] ([ID])
GO
ALTER TABLE [dbo].[table_State] CHECK CONSTRAINT [FK_table_State_table_Country]
GO
