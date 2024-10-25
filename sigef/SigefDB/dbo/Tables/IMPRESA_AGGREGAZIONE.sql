﻿CREATE TABLE [dbo].[IMPRESA_AGGREGAZIONE] (
    [ID]               INT             IDENTITY (1, 1) NOT NULL,
    [ID_AGGREGAZIONE]  INT             NOT NULL,
    [COD_RUOLO]        VARCHAR (10)    NOT NULL,
    [ID_IMPRESA]       INT             NOT NULL,
    [PERCENTUALE]      DECIMAL (10, 4) NULL,
    [DATA_INIZIO]      DATETIME        NOT NULL,
    [OPERATORE_INIZIO] INT             NOT NULL,
    [ATTIVO]           BIT             NOT NULL,
    [DATA_FINE]        DATETIME        NULL,
    [OPERATORE_FINE]   INT             NULL,
    CONSTRAINT [PK_IMPRESA_AGGREGAZIONE] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_IMPRESA_AGGREGAZIONE_AGGREGAZIONE] FOREIGN KEY ([ID_AGGREGAZIONE]) REFERENCES [dbo].[AGGREGAZIONE] ([ID]),
    CONSTRAINT [FK_IMPRESA_AGGREGAZIONE_IMPRESA] FOREIGN KEY ([ID_IMPRESA]) REFERENCES [dbo].[IMPRESA] ([ID_IMPRESA]),
    CONSTRAINT [FK_IMPRESA_AGGREGAZIONE_TIPO_AGGREGAZIONE_RUOLO] FOREIGN KEY ([COD_RUOLO]) REFERENCES [dbo].[TIPO_AGGREGAZIONE_RUOLO] ([CODICE])
);

