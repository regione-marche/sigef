﻿CREATE TABLE [dbo].[SPECIFICA_INVESTIMENTI] (
    [ID_SPECIFICA_INVESTIMENTO] INT           IDENTITY (1, 1) NOT NULL,
    [ID_DETTAGLIO_INVESTIMENTO] INT           NOT NULL,
    [COD_SPECIFICA]             CHAR (2)      NOT NULL,
    [DESCRIZIONE]               VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_SPECIFICA_INVESTIMENTI] PRIMARY KEY CLUSTERED ([ID_SPECIFICA_INVESTIMENTO] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_SPECIFICA_INVESTIMENTI_DETTAGLIO_INVESTIMENTI] FOREIGN KEY ([ID_DETTAGLIO_INVESTIMENTO]) REFERENCES [dbo].[DETTAGLIO_INVESTIMENTI] ([ID_DETTAGLIO_INVESTIMENTO])
);

