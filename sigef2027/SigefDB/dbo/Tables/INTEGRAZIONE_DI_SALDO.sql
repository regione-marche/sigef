CREATE TABLE [dbo].[INTEGRAZIONE_DI_SALDO] (
    [ID]                   INT             IDENTITY (1, 1) NOT NULL,
    [ID_PROGETTO]          INT             NOT NULL,
    [BARCODE]              CHAR (11)       NOT NULL,
    [ID_ELENCO]            INT             NOT NULL,
    [ID_INVESTIMENTO]      INT             NULL,
    [COSTO_RICHIESTO]      DECIMAL (18, 2) NULL,
    [CONTRIBUTO_RICHIESTO] DECIMAL (18, 2) NULL,
    [COSTO_AMMESSO]        DECIMAL (18, 2) NULL,
    [CONTRIBUTO_AMMESSO]   DECIMAL (18, 2) NULL,
    [TOT_LIQUIDATO]        DECIMAL (18, 2) NULL,
    [ID_ATTO]              INT             NULL,
    [NOTE]                 VARCHAR (255)   NULL,
    CONSTRAINT [PK_INTEGRAZIONE_DI_SALDO_1] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (FILLFACTOR = 80)
);

