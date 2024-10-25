CREATE TABLE [dbo].[PROGETTO] (
    [ID_PROGETTO]                INT           IDENTITY (1, 1) NOT NULL,
    [ID_BANDO]                   INT           NOT NULL,
    [COD_AGEA]                   VARCHAR (50)  NULL,
    [SEGNATURA_ALLEGATI]         VARCHAR (100) NULL,
    [ID_PROG_INTEGRATO]          INT           NULL,
    [FLAG_PREADESIONE]           BIT           NOT NULL,
    [FLAG_DEFINITIVO]            BIT           NOT NULL,
    [ID_FASCICOLO]               INT           NULL,
    [PROVINCIA_DI_PRESENTAZIONE] CHAR (2)      NULL,
    [SELEZIONATA_X_REVISIONE]    BIT           CONSTRAINT [DF_PROGETTO_SELEZIONATA_X_REVISIONE] DEFAULT ((0)) NULL,
    [ID_IMPRESA]                 INT           NOT NULL,
    [ID_STORICO_ULTIMO]          INT           NULL,
    [DATA_CREAZIONE]             DATETIME      NULL,
    [OPERATORE_CREAZIONE]        INT           NULL,
    [FIRMA_PREDISPOSTA]          BIT           CONSTRAINT [DF_PROGETTO_FIRMA_PREDISPOSTA] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PROGETTO_PK] PRIMARY KEY CLUSTERED ([ID_PROGETTO] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_PROGETTO_BANDO] FOREIGN KEY ([ID_BANDO]) REFERENCES [dbo].[BANDO] ([ID_BANDO])
);


GO
CREATE NONCLUSTERED INDEX [IX_PROGETTO]
    ON [dbo].[PROGETTO]([ID_IMPRESA] ASC) WITH (FILLFACTOR = 80);


GO
CREATE NONCLUSTERED INDEX [IX_PROGETTO_1]
    ON [dbo].[PROGETTO]([ID_BANDO] ASC) WITH (FILLFACTOR = 80);


GO
CREATE NONCLUSTERED INDEX [IX_PROGETTO_2]
    ON [dbo].[PROGETTO]([ID_PROG_INTEGRATO] ASC) WITH (FILLFACTOR = 80);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'NULL se a se stante, =ID_PROGETTO se  e'' un progetto integrato, =ID_PROGETTO del progetto integrato padre', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PROGETTO', @level2type = N'COLUMN', @level2name = N'ID_PROG_INTEGRATO';

