CREATE TABLE [dbo].[TIPO_SANZIONI] (
    [COD_TIPO]            VARCHAR (10)  NOT NULL,
    [TITOLO]              VARCHAR (255) NOT NULL,
    [DESCRIZIONE]         NTEXT         NOT NULL,
    [QUERY_SQL]           VARCHAR (100) NULL,
    [LIVELLO]             CHAR (1)      NOT NULL,
    [ISTRUTTORIA]         BIT           NOT NULL,
    [CONTROLLO_IN_LOCO]   BIT           NOT NULL,
    [EX_POST]             BIT           NOT NULL,
    [DURATA_SELEZIONATO]  BIT           NOT NULL,
    [DURATA_NUMERICO]     BIT           NOT NULL,
    [DURATA_TOOLTIP]      VARCHAR (255) NULL,
    [GRAVITA_SELEZIONATO] BIT           NOT NULL,
    [GRAVITA_NUMERICO]    BIT           NOT NULL,
    [GRAVITA_TOOLTIP]     VARCHAR (255) NULL,
    [ENTITA_SELEZIONATO]  BIT           NOT NULL,
    [ENTITA_NUMERICO]     BIT           NOT NULL,
    [ENTITA_TOOLTIP]      VARCHAR (255) NULL,
    [AUTOMATICO]          BIT           NOT NULL,
    CONSTRAINT [PK_TIPO_SANZIONI] PRIMARY KEY CLUSTERED ([COD_TIPO] ASC) WITH (FILLFACTOR = 100)
);

