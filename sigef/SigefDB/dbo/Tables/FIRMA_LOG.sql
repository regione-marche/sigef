﻿CREATE TABLE [dbo].[FIRMA_LOG](
	[ID_FIRMA_LOG] [int] IDENTITY(1,1) NOT NULL,
	[TIPO_DOCUMENTO] [varchar](max) NULL,
	[PARAMETRI_DOCUMENTO] [varchar](max) NULL,
	[OPERATORE] [varchar](30) NULL,
	[DATA_FIRMA] [datetime] NULL,
	[TIPO_FIRMA] [varchar](100) NULL,
	[DOMINIO_FIRMA] [varchar](50) NULL,
	[ESITO] [varchar](50) NULL,
	[DETTAGLIO_ESITO] [nvarchar](max) NULL,
	[DATA_INSERIMENTO] [datetime] NULL,
	[DATA_AGGIORNAMENTO] [datetime] NULL,
 CONSTRAINT [PK_FIRMA_LOG] PRIMARY KEY CLUSTERED 
(
	[ID_FIRMA_LOG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[FIRMA_LOG] ADD  CONSTRAINT [DF_FIRMA_LOG_DATA_INSERIMENTO]  DEFAULT (getdate()) FOR [DATA_INSERIMENTO]
GO

ALTER TABLE [dbo].[FIRMA_LOG] ADD  CONSTRAINT [DF_FIRMA_LOG_DATA_AGGIORNAMENTO]  DEFAULT (getdate()) FOR [DATA_AGGIORNAMENTO]
GO
