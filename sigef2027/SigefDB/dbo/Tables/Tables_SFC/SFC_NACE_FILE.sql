﻿SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- DROP TABLE SFC_NACE_FILE;
CREATE TABLE [dbo].[SFC_NACE_FILE](
	[ID_SFC_NACE] [int] IDENTITY(1,1) NOT NULL,
	[COD_ATECO_2007] [varchar](max) NULL,
	[DESCRIZIONE] [varchar](max) NULL,
	[CODICE_NACE] [int] NULL
 CONSTRAINT [PK_SFC_NACE] PRIMARY KEY CLUSTERED 
(
	[ID_SFC_NACE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO