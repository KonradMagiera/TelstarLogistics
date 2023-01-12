USE [Telstar Logistics Database]
GO

/****** Object:  Table [dbo].[Booking]    Script Date: 12-01-2023 13:26:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Booking](
	[BookingId] [int] NOT NULL,
	[CustEmail] [text] NULL,
	[CustPhone] [int] NULL,
	[CustName] [text] NOT NULL,
	[ParcelType] [text] NOT NULL,
	[Weight] [decimal](18, 0) NOT NULL,
	[Height] [decimal](18, 0) NOT NULL,
	[Length] [decimal](18, 0) NOT NULL,
	[Width] [decimal](18, 0) NOT NULL,
	[Handover] [datetime] NOT NULL,
	[Recommended] [bit] NOT NULL,
	[CargoCenterLocations] [text] NOT NULL,
	[UserId] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


