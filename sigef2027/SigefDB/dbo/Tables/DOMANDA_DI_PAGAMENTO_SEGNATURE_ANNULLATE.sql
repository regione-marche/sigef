﻿CREATE TABLE [dbo].[DOMANDA_DI_PAGAMENTO_SEGNATURE_ANNULLATE] (
    [ID]                   INT           IDENTITY (1, 1) NOT NULL,
    [ID_DOMANDA_PAGAMENTO] INT           NULL,
    [COD_TIPO]             CHAR (3)      NULL,
    [DATA]                 DATETIME      NULL,
    [OPERATORE]            CHAR (16)     NULL,
    [SEGNATURA]            VARCHAR (100) NULL,
    [MOTIVAZIONE]          NTEXT         NULL,
    [RIAPRI_DOMANDA]       BIT           CONSTRAINT [DF_DOMANDA_DI_PAGAMENTO_SEGNATURE_ANNULLATE_RIAPRI_DOMANDA] DEFAULT ((0)) NULL,
    [DATA_ANNULLAMENTO]    DATETIME      CONSTRAINT [DF_DOMANDA_DI_PAGAMENTO_SEGNATURE_ANNULLATE_DATA_ANNULLAMENTO] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_DOMANDA_DI_PAGAMENTO_SEGNATURE_ANNULLATE] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (FILLFACTOR = 100)
);

