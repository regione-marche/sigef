﻿CREATE TABLE [dbo].[REQUISITI_PAGAMENTO] (
    [ID_REQUISITO]   INT            IDENTITY (1, 1) NOT NULL,
    [DESCRIZIONE]    VARCHAR (500)  NULL,
    [PLURIVALORE]    BIT            CONSTRAINT [DF_REQUISITI_PAGAMENTO_PLURIVALORE] DEFAULT ((0)) NULL,
    [NUMERICO]       BIT            CONSTRAINT [DF_REQUISITI_PAGAMENTO_NUMERICO] DEFAULT ((0)) NULL,
    [DATETIME]       BIT            CONSTRAINT [DF_REQUISITI_PAGAMENTO_DATETIME] DEFAULT ((0)) NULL,
    [TESTO_SEMPLICE] BIT            CONSTRAINT [DF_REQUISITI_PAGAMENTO_TESTO_SEMPLICE] DEFAULT ((0)) NULL,
    [TESTO_AREA]     BIT            CONSTRAINT [DF_REQUISITI_PAGAMENTO_TESTO_AREA] DEFAULT ((0)) NULL,
    [URL]            VARCHAR (100)  NULL,
    [QUERY_EVAL]     VARCHAR (3000) NULL,
    [QUERY_INSERT]   VARCHAR (3000) NULL,
    [MISURA]         VARCHAR (10)   NULL,
    CONSTRAINT [PK_REQUISITI_PAGAMENTO] PRIMARY KEY CLUSTERED ([ID_REQUISITO] ASC) WITH (FILLFACTOR = 80)
);

