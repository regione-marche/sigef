﻿CREATE TABLE [dbo].[UTENTI] (
    [ID_UTENTE]         INT      IDENTITY (1, 1) NOT NULL,
    [ID_PERSONA_FISICA] INT      NOT NULL,
    [ID_STORICO_ULTIMO] INT      NULL,
    [ULTIMO_ACCESSO]    DATETIME NULL,
    CONSTRAINT [PK_UTENTI] PRIMARY KEY CLUSTERED ([ID_UTENTE] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_UTENTI_PERSONA_FISICA] FOREIGN KEY ([ID_PERSONA_FISICA]) REFERENCES [dbo].[PERSONA_FISICA] ([ID_PERSONA])
);

