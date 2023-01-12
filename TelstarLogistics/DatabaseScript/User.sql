USE [Telstar Logistics Database]
GO

/****** Object:  Table [dbo].[User]    Script Date: 12-01-2023 13:30:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[UserId] [int] NOT NULL,
	[FirstName] [text] NOT NULL,
	[LastName] [text] NOT NULL,
	[UserName] [text] NOT NULL,
	[Password] [text] NOT NULL,
	[Role] [text] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


