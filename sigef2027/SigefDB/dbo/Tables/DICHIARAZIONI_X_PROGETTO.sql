﻿CREATE TABLE [dbo].[DICHIARAZIONI_X_PROGETTO] (
    [ID_DICHIARAZIONE] INT NOT NULL,
    [ID_PROGETTO]      INT NOT NULL,
    CONSTRAINT [PK_DICHIARAZIONI_X_PROGETTO] PRIMARY KEY CLUSTERED ([ID_DICHIARAZIONE] ASC, [ID_PROGETTO] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_DICHIARAZIONI_X_PROGETTO_CATALOGO_DICHIARAZIONI] FOREIGN KEY ([ID_DICHIARAZIONE]) REFERENCES [dbo].[CATALOGO_DICHIARAZIONI] ([ID_DICHIARAZIONE]),
    CONSTRAINT [FK_DICHIARAZIONI_X_PROGETTO_PROGETTO] FOREIGN KEY ([ID_PROGETTO]) REFERENCES [dbo].[PROGETTO] ([ID_PROGETTO])
);
