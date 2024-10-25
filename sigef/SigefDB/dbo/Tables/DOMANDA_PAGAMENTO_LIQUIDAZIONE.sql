﻿CREATE TABLE [dbo].[DOMANDA_PAGAMENTO_LIQUIDAZIONE] (
    [ID]                          INT             IDENTITY (1, 1) NOT NULL,
    [ID_DOMANDA_PAGAMENTO]        INT             NOT NULL,
    [ID_PROGETTO]                 INT             NOT NULL,
    [ID_IMPRESA_BENEFICIARIA]     INT             NOT NULL,
    [ID_DECRETO]                  INT             NULL,
    [RICHIESTA_MANDATO_IMPORTO]   DECIMAL (18, 2) NULL,
    [RICHIESTA_MANDATO_SEGNATURA] VARCHAR (100)   NULL,
    [RICHIESTA_MANDATO_DATA]      DATETIME        NULL,
    [MANDATO_NUMERO]              VARCHAR (10)    NULL,
    [MANDATO_DATA]                DATETIME        NULL,
    [MANDATO_IMPORTO]             DECIMAL (18, 2) NULL,
    [MANDATO_ID_FILE]             INT             NULL,
    [QUIETANZA_DATA]              DATETIME        NULL,
    [QUIETANZA_IMPORTO]           DECIMAL (18, 2) NULL,
    [LIQUIDATO]                   BIT             CONSTRAINT [DF_DOMANDA_PAGAMENTO_LIQUIDAZIONE_LIQUIDATO] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_DOMANDA_PAGAMENTO_LIQUIDAZIONE] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_DOMANDA_PAGAMENTO_LIQUIDAZIONE_DOMANDA_DI_PAGAMENTO_ESPORTAZIONE] FOREIGN KEY ([ID_DOMANDA_PAGAMENTO], [ID_PROGETTO]) REFERENCES [dbo].[DOMANDA_DI_PAGAMENTO_ESPORTAZIONE] ([ID_DOMANDA_PAGAMENTO], [ID_PROGETTO])
);

