﻿CREATE TABLE [dbo].[AUT_MODIFICA_PERC_AIUTO] (
    [ID_AUTORIZZAZIONE]              INT             IDENTITY (1, 1) NOT NULL,
    [DATA_INSERIMENTO]               DATETIME        CONSTRAINT [DF_AUT_MODIFICA_PERC_AIUTO_DATA_INSERIMENTO] DEFAULT (getdate()) NULL,
    [CF_INSERIMENTO]                 VARCHAR (20)    NULL,
    [DATA_MODIFICA]                  DATETIME        CONSTRAINT [DF_AUT_MODIFICA_PERC_AIUTO_DATA_MODIFICA] DEFAULT (getdate()) NULL,
    [CF_MODIFICA]                    VARCHAR (20)    NULL,
    [ID_INVESTIMENTO]                INT             NULL,
    [COSTO_INVESTIMENTO_PRECEDENTE]  DECIMAL (18, 2) NULL,
    [COSTO_INVESTIMENTO_AUTORIZZATO] DECIMAL (18, 2) NULL,
    [QUANTITA_PRECEDENTE]            DECIMAL (10, 2) NULL,
    [QUANTITA_AUTORIZZATA]           DECIMAL (10, 2) NULL,
    [PERC_PRECEDENTE]                DECIMAL (10, 2) NULL,
    [PERC_AUTORIZZATA]               DECIMAL (10, 2) NULL,
    CONSTRAINT [PK_AUT_MODIFICA_PERC_AIUTO] PRIMARY KEY CLUSTERED ([ID_AUTORIZZAZIONE] ASC),
    CONSTRAINT [FK_AUT_MODIFICA_PERC_AIUTO_AUT_MODIFICA_PERC_AIUTO] FOREIGN KEY ([ID_INVESTIMENTO]) REFERENCES [dbo].[PIANO_INVESTIMENTI] ([ID_INVESTIMENTO])
);
