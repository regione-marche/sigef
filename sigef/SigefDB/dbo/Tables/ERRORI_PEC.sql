﻿CREATE TABLE [dbo].[ERRORI_PEC] (
	[ID]					[INT]			IDENTITY(1,1) NOT NULL,
	[OPERATORE_INSERIMENTO] [varchar](max)	NULL,
	[DATA_INSERIMENTO]		[DATETIME]		CONSTRAINT [DF_ERRORI_PEC_DATA_INSERIMENTO] DEFAULT (getdate()) NULL,
	[OPERATORE_MODIFICA]	[VARCHAR](MAX)	NULL,
	[DATA_MODIFICA]			[DATETIME]		CONSTRAINT [DF_ERRORI_PEC_DATA_MODIFICA] DEFAULT (getdate()) NULL,
	[SEGNATURA]				[VARCHAR](MAX)	NOT NULL,
	[ID_STATO]				[INT]			NOT NULL,
	[STATO]					[VARCHAR](MAX)	NOT NULL,
	[DESTINATARIO]			[VARCHAR](MAX)	NULL,
	[EMAIL_DESTINATARIO]	[VARCHAR](MAX)	NULL,
	CONSTRAINT [PK_ERRORI_PEC] PRIMARY KEY CLUSTERED ([ID] ASC)
)
