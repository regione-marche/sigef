CREATE TABLE [dbo].[IGRUE_INVIO] (
    [ID_INVIO]          INT             IDENTITY (1, 1) NOT NULL,
    [ID_TICKET]         VARCHAR (50)    NULL,
    [DATA_INVIO]        DATETIME        NULL,
    [DATA_DA]           DATE            NULL,
    [DATA_A]            DATE            NULL,
    [FILE_INVIO]        VARBINARY (MAX) NULL,
    [ID_OPERATORE]      INT             NULL,
    [CODICE_ESITO]      INT             NULL,
    [DESCRIZIONE_ESITO] NVARCHAR (MAX)  NULL,
    [DETTAGLIO_ESITO]   NVARCHAR (MAX)  NULL,
    [TIMESTAMP_ESITO]   DATETIME        NULL,
    [TIPO_FILE]         VARCHAR (200)   NULL,
    CONSTRAINT [PK_IGRUE_INVIO] PRIMARY KEY CLUSTERED ([ID_INVIO] ASC)
);

