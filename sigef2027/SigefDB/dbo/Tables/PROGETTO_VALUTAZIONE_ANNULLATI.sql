CREATE TABLE [dbo].[PROGETTO_VALUTAZIONE_ANNULLATI] (
    [ID_ANNULLAMENTO] INT           IDENTITY (1, 1) NOT NULL,
    [ID]              INT           NULL,
    [ID_PROGETTO]     INT           NULL,
    [ID_VARIANTE]     INT           NULL,
    [ID_FILE]         INT           NULL,
    [ORDINE_FIRMA]    INT           NULL,
    [SEGNATURA]       VARCHAR (100) NULL,
    [ID_NOTE]         INT           NULL,
    [OPERATORE]       INT           NULL,
    [DATA_MODIFICA]   DATETIME      NULL,
    CONSTRAINT [PK_PROGETTO_VALUTAZIONE_ANNULLATI] PRIMARY KEY CLUSTERED ([ID_ANNULLAMENTO] ASC)
);

