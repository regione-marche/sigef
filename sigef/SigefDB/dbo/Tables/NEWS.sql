CREATE TABLE [dbo].[NEWS] (
    [ID_NEWS]              INT            IDENTITY (1, 1) NOT NULL,
    [TITOLO]               VARCHAR (255)  NOT NULL,
    [TESTO]                NVARCHAR (MAX) NOT NULL,
    [URL]                  VARCHAR (255)  NULL,
    [DATA]                 DATETIME       NOT NULL,
    [OPERATORE]            VARCHAR (16)   NOT NULL,
    [INTERRUZIONE_SISTEMA] BIT            NOT NULL,
    [DATA_INIZIO]          DATETIME       NULL,
    [DATA_FINE]            DATETIME       NULL,
    CONSTRAINT [PK_NEWS] PRIMARY KEY CLUSTERED ([ID_NEWS] ASC) WITH (FILLFACTOR = 80)
);

