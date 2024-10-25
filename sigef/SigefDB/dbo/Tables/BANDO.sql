﻿CREATE TABLE [dbo].[BANDO] (
    [ID_BANDO]               INT            IDENTITY (1, 1) NOT NULL,
    [COD_ENTE]               VARCHAR (10)   NOT NULL,
    [DESCRIZIONE]            VARCHAR (2000) NOT NULL,
    [PAROLE_CHIAVE]          VARCHAR (100)  NULL,
    [DATA_INSERIMENTO]       DATETIME       CONSTRAINT [DF__BANDO__DATA_INSE__10566F31] DEFAULT (getdate()) NOT NULL,
    [DATA_APERTURA]          DATETIME       NULL,
    [DISPOSIZIONI_ATTUATIVE] BIT            CONSTRAINT [DF_BANDO_DISPOSIZIONI_ATTUATIVE] DEFAULT ((0)) NOT NULL,
    [ID_SCHEDA_VALUTAZIONE]  INT            NULL,
    [ID_MODELLO_DOMANDA]     INT            NULL,
    [ID_PROGRAMMAZIONE]      INT            NOT NULL,
    [MULTIPROGETTO]          BIT            CONSTRAINT [DF_BANDO_MULTIPROGETTO] DEFAULT ((0)) NOT NULL,
    [MULTIMISURA]            BIT            CONSTRAINT [DF_BANDO_MULTIMISURA] DEFAULT ((0)) NOT NULL,
    [INTERESSE_FILIERA]      BIT            CONSTRAINT [DF_BANDO_INTERESSE_FILIERA] DEFAULT ((0)) NOT NULL,
    [FASCICOLO_RICHIESTO]    BIT            CONSTRAINT [DF_BANDO_FASCICOLO_RICHIESTO] DEFAULT ((1)) NOT NULL,
    [ID_STORICO_ULTIMO]      INT            NULL,
    [ID_INTEGRAZIONE_ULTIMA] INT            NULL,
    [FIRMA_RICHIESTA]        BIT            CONSTRAINT [DF_BANDO_FIRMA_RICHIESTA] DEFAULT ((1)) NOT NULL,
    [ABILITA_VALUTAZIONE]    BIT            CONSTRAINT [DF_BANDO_ABILITA_VALUTAZIONE] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [BANDO_PK] PRIMARY KEY CLUSTERED ([ID_BANDO] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_BANDO_MODELLO_DOMANDA] FOREIGN KEY ([ID_MODELLO_DOMANDA]) REFERENCES [dbo].[MODELLO_DOMANDA] ([ID_DOMANDA]),
    CONSTRAINT [FK_BANDO_SCHEDA_VALUTAZIONE] FOREIGN KEY ([ID_SCHEDA_VALUTAZIONE]) REFERENCES [dbo].[SCHEDA_VALUTAZIONE] ([ID_SCHEDA_VALUTAZIONE])
);


GO
CREATE NONCLUSTERED INDEX [IX_BANDO]
    ON [dbo].[BANDO]([ID_PROGRAMMAZIONE] ASC) WITH (FILLFACTOR = 80);

