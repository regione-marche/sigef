﻿CREATE TABLE [dbo].[RNA_LOG_CONCESSIONI](
	[ID_RNA_LOG_CONCESSIONE] [int] IDENTITY(1,1) NOT NULL,
	[ID_PROGETTO] [int] NULL,
	[ID_PROGETTO_RNA] [varchar](255) NULL,
	[ID_IMPRESA] [int] NULL,
	[ID_FISCALE_IMPRESA] [varchar](16) NULL,
	[ID_RICHIESTA] [varchar](50) NULL,
	[DATA_RICHIESTA] [datetime] NULL,
	[ID_OPERATORE_REG_AIUTO] [int] NULL,
	[ISTANZA_RICHIESTA] [xml] NULL,
	[ISTANZA_RISPOSTA] [xml] NULL,
	[COR] [varchar](50) NULL,
	[CODICE_ESITO] [int] NULL,
	[DESCRIZIONE_ESITO] [nvarchar](max) NULL,
	[CODICE_ESITO_STATO_RICHIESTA] [int] NULL,
	[DESCRIZIONE_ESITO_STATO_RICHIESTA] [nvarchar](max) NULL,
	[ID_OPERATORE_STATO_RICHIESTA] [int] NULL,
	[DATA_STATO_RICHIESTA] [datetime] NULL,
	[ERRORE] [nvarchar](max) NULL,
	[DATA_INSERIMENTO] [datetime] NULL,
	[DATA_AGGIORNAMENTO] [datetime] NULL,
 CONSTRAINT [PK_RNA_LOG] PRIMARY KEY CLUSTERED 
(
	[ID_RNA_LOG_CONCESSIONE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[RNA_LOG_CONCESSIONI] ADD  CONSTRAINT [DF_RNA_LOG_CONCESSIONI_DATA_INSERIMENTO]  DEFAULT (getdate()) FOR [DATA_INSERIMENTO]
GO

ALTER TABLE [dbo].[RNA_LOG_CONCESSIONI] ADD  CONSTRAINT [DF_RNA_LOG_CONCESSIONI_DATA_AGGIORNAMENTO]  DEFAULT (getdate()) FOR [DATA_AGGIORNAMENTO]
GO


