CREATE TABLE [dbo].[HELP] (
    [ID_HELP]               INT                 IDENTITY (1, 1) NOT NULL,
    [DESCRIZIONE]           NTEXT               NOT NULL,
    [CODICE]                [dbo].[DESCRIZIONE] NULL,
    [ID_BANDO]              INT                 NULL,
    [COD_TIPO_INVESTIMENTO] INT                 NULL,
    CONSTRAINT [PK_HELP] PRIMARY KEY CLUSTERED ([ID_HELP] ASC) WITH (FILLFACTOR = 100)
);

