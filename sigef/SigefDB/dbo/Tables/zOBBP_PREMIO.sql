﻿CREATE TABLE [dbo].[zOBBP_PREMIO] (
    [ID_OBIETTIVO]       INT             NOT NULL,
    [ID_VALORE_PRIORITA] INT             NOT NULL,
    [PUNTEGGIO]          DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_zOBBP_PREMIO] PRIMARY KEY CLUSTERED ([ID_OBIETTIVO] ASC, [ID_VALORE_PRIORITA] ASC),
    CONSTRAINT [FK_zOBBP_PREMIO_VALORI_PRIORITA] FOREIGN KEY ([ID_VALORE_PRIORITA]) REFERENCES [dbo].[VALORI_PRIORITA] ([ID_VALORE]),
    CONSTRAINT [FK_zOBBP_PREMIO_zOBBP_MISURA] FOREIGN KEY ([ID_OBIETTIVO]) REFERENCES [dbo].[zOBBP_MISURA] ([ID])
);

