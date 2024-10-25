﻿CREATE TABLE [dbo].[REVISIONE_DPAGAMENTO_ESITO] (
    [ID]                       INT            IDENTITY (1, 1) NOT NULL,
    [ID_LOTTO]                 INT            NOT NULL,
    [ID_DOMANDA_PAGAMENTO]     INT            NOT NULL,
    [ID_VLD_STEP]              INT            NOT NULL,
    [COD_ESITO]                CHAR (2)       NULL,
    [DATA]                     DATETIME       NOT NULL,
    [OPERATORE]                INT            NOT NULL,
    [NOTE]                     VARCHAR (5000) NULL,
    [ESCLUDI_DA_COMUNICAZIONE] BIT            CONSTRAINT [DF_REVISIONE_DPAGAMENTO_ESITO_ESCLUDI_DA_COMUNICAZIONE] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_REVISIONE_DPAGAMENTO_ESITO] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_REVISIONE_DPAGAMENTO_ESITO_ESITI_STEP] FOREIGN KEY ([COD_ESITO]) REFERENCES [dbo].[ESITI_STEP] ([COD_ESITO]),
    CONSTRAINT [FK_REVISIONE_DPAGAMENTO_ESITO_REVISIONE_DOMANDA_PAGAMENTO] FOREIGN KEY ([ID_LOTTO], [ID_DOMANDA_PAGAMENTO]) REFERENCES [dbo].[REVISIONE_DOMANDA_PAGAMENTO] ([ID_LOTTO], [ID_DOMANDA_PAGAMENTO])
);

