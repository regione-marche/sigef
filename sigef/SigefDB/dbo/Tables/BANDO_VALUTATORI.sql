﻿CREATE TABLE [dbo].[BANDO_VALUTATORI] (
    [ID_VALUTATORE] INT      IDENTITY (1, 1) NOT NULL,
    [ID_BANDO]      INT      NOT NULL,
    [ID_UTENTE]     INT      NOT NULL,
    [PRESIDENTE]    BIT      NOT NULL,
    [ATTIVO]        BIT      NOT NULL,
    [DATA_INIZIO]   DATETIME NOT NULL,
    [DATA_FINE]     DATETIME NULL,
    [ORDINE]        INT      NOT NULL,
    CONSTRAINT [PK_BANDO_VALUTATORI] PRIMARY KEY CLUSTERED ([ID_VALUTATORE] ASC),
    CONSTRAINT [FK_BANDO_VALUTATORI_BANDO] FOREIGN KEY ([ID_BANDO]) REFERENCES [dbo].[BANDO] ([ID_BANDO])
);
