USE [Telstar Logistics Database]
GO

/****** Object:  Table [dbo].[Route]    Script Date: 12-01-2023 13:30:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Route](
	[RouteId] [int] NOT NULL,
	[StartCityId] [int] NOT NULL,
	[EndCityId] [int] NOT NULL,
	[TransportType] [text] NOT NULL,
	[Weight] [decimal](18, 0) NOT NULL,
	[Cost] [decimal](18, 0) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


