﻿CREATE TABLE [dbo].[CAA_STORICO_OPERATORI] (
    [ID]           INT      IDENTITY (1, 1) NOT NULL,
    [ID_OPERATORE] INT      NOT NULL,
    [MANDATO_PSR]  BIT      NOT NULL,
    [MANDATO_UMA]  BIT      NOT NULL,
    [RESPONSABILE] BIT      NOT NULL,
    [COD_STATO]    CHAR (1) NOT NULL,
    [DATA]         DATETIME NOT NULL,
    [OPERATORE]    INT      NOT NULL,
    CONSTRAINT [PK_CAA_STORICO_OPERATORI] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_CAA_STORICO_OPERATORI_CAA_OPERATORI] FOREIGN KEY ([ID_OPERATORE]) REFERENCES [dbo].[CAA_OPERATORI] ([ID])
);

