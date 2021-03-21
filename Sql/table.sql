--USE [TCPtest]
--GO

/****** Object:  Table [dbo].[Vehicles]    Script Date: 3/21/2021 1:39:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vehicles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[make] [varchar](50) NOT NULL,
	[model] [varchar](50) NOT NULL,
	[year] [int] NOT NULL,
	[licenseplate] [varchar](50) NOT NULL,
	[color] [varchar](50) NULL
) ON [PRIMARY]
GO

