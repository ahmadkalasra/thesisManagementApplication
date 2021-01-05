USE [ShortURL]
GO
/****** Object:  Table [dbo].[url]    Script Date: 11/05/2009 12:50:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[url](
	[short_url] [varchar](5) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[created_by] [varchar](15) NOT NULL,
	[real_url] [varchar](200) NOT NULL,
 CONSTRAINT [PK_url] PRIMARY KEY CLUSTERED 
(
	[short_url] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_url_create_date]    Script Date: 11/05/2009 12:50:41 ******/
ALTER TABLE [dbo].[url] ADD  CONSTRAINT [DF_url_create_date]  DEFAULT (getdate()) FOR [create_date]
GO
