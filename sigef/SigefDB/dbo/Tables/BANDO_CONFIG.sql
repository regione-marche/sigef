﻿CREATE TABLE [dbo].[BANDO_CONFIG] (
    [ID]               INT          IDENTITY (1, 1) NOT NULL,
    [ID_BANDO]         INT          NOT NULL,
    [COD_TIPO]         VARCHAR (30) NOT NULL,
    [VALORE]           VARCHAR (50) NOT NULL,
    [ATTIVO]           BIT          CONSTRAINT [DF_BANDO_CONFIG_ATTIVO] DEFAULT ((1)) NOT NULL,
    [DATA_INIZIO]      DATETIME     NOT NULL,
    [OPERATORE_INIZIO] INT          NOT NULL,
    [DATA_FINE]        DATETIME     NULL,
    [OPERATORE_FINE]   INT          NULL,
    CONSTRAINT [PK_BANDO_CONFIG] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_BANDO_CONFIG_BANDO] FOREIGN KEY ([ID_BANDO]) REFERENCES [dbo].[BANDO] ([ID_BANDO]),
    CONSTRAINT [FK_BANDO_CONFIG_BANDO_CONFIG_TIPO] FOREIGN KEY ([COD_TIPO]) REFERENCES [dbo].[BANDO_CONFIG_TIPO] ([CODICE])
);
