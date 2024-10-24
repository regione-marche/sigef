﻿CREATE TABLE [dbo].[FATTURATO_AZIENDA] (
    [ID_FATTURATO]  INT             IDENTITY (1, 1) NOT NULL,
    [ID_IMPRESA]    INT             NULL,
    [DATA_MODIFICA] DATETIME        NULL,
    [ANNO]          INT             NULL,
    [ALIQUOTA]      DECIMAL (10, 2) NULL,
    [IMPORTO]       DECIMAL (18, 2) CONSTRAINT [DF_FATTURATO_AZIENDA_IMPORTO] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_FATTURATO_AZIENDA] PRIMARY KEY CLUSTERED ([ID_FATTURATO] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_FATTURATO_AZIENDA_IMPRESA] FOREIGN KEY ([ID_IMPRESA]) REFERENCES [dbo].[IMPRESA] ([ID_IMPRESA])
);

