﻿CREATE TABLE [dbo].[CONTROLLI_DOMANDE_PAGAMENTO_ESTRAZIONE_TEMP] (
    [ID_LOTTO]                 INT             NOT NULL,
    [ID_DOMANDA_PAGAMENTO]     INT             NOT NULL,
    [COD_TIPO]                 CHAR (3)        NOT NULL,
    [ESTRATTA]                 BIT             NOT NULL,
    [TIPO_ESTRAZIONE]          CHAR (1)        NULL,
    [VALORE_DI_RISCHIO]        DECIMAL (10, 4) NULL,
    [CLASSE_DI_RISCHIO]        CHAR (1)        NULL,
    [ORDINE_CLASSE_DI_RISCHIO] INT             NULL,
    [CONTRIBUTO_RICHIESTO]     DECIMAL (18, 2) NULL,
    [CUAA]                     VARCHAR (16)    NULL,
    [CUAA_SUB]                 CHAR (4)        NULL,
    [RAGIONE_SOCIALE]          VARCHAR (255)   NULL,
    CONSTRAINT [PK_CONTROLLI_DOMANDE_PAGAMENTO_ESTRAZIONE_TEMP] PRIMARY KEY CLUSTERED ([ID_LOTTO] ASC, [ID_DOMANDA_PAGAMENTO] ASC) WITH (FILLFACTOR = 80)
);

