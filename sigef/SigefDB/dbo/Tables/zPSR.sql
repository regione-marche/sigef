CREATE TABLE [dbo].[zPSR] (
    [CODICE]            VARCHAR (20)  NOT NULL,
    [DESCRIZIONE]       VARCHAR (255) NOT NULL,
    [ANNO_DA]           INT           NOT NULL,
    [ANNO_A]            INT           NOT NULL,
    [PROFONDITA_ALBERO] INT           NOT NULL,
    [CCI]               VARCHAR (50)  NULL,
    CONSTRAINT [PK_zPSR] PRIMARY KEY CLUSTERED ([CODICE] ASC)
);

