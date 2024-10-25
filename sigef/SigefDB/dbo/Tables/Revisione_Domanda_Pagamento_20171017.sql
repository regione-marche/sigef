CREATE TABLE [dbo].[Revisione_Domanda_Pagamento_20171017] (
    [ID_LOTTO]                    INT           NOT NULL,
    [ID_DOMANDA_PAGAMENTO]        INT           NOT NULL,
    [DATA_INSERIMENTO]            DATETIME      NOT NULL,
    [DATA_MODIFICA]               DATETIME      NOT NULL,
    [CF_OPERATORE]                VARCHAR (16)  NOT NULL,
    [SELEZIONATA_X_REVISIONE]     BIT           NOT NULL,
    [APPROVATA]                   BIT           NULL,
    [NUMERO_ESTRAZIONE]           INT           NOT NULL,
    [ORDINE]                      INT           NOT NULL,
    [SEGNATURA_REVISIONE]         VARCHAR (100) NULL,
    [SEGNATURA_SECONDA_REVISIONE] VARCHAR (100) NULL
);

