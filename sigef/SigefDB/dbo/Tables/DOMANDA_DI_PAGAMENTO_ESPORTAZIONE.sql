﻿CREATE TABLE [dbo].[DOMANDA_DI_PAGAMENTO_ESPORTAZIONE] (
    [ID_DOMANDA_PAGAMENTO]      INT             NOT NULL,
    [ID_PROGETTO]               INT             NOT NULL,
    [BARCODE]                   CHAR (11)       NOT NULL,
    [MISURA_PREVALENTE]         BIT             NOT NULL,
    [IMPORTO_AMMISSIBILE]       DECIMAL (18, 2) NULL,
    [IMPORTO_SANZIONE]          DECIMAL (18, 2) NULL,
    [IMPORTO_RECUPERO_ANTICIPO] DECIMAL (18, 2) NULL,
    [IMPORTO_AMMESSO]           DECIMAL (18, 2) NULL,
    [IMPORTO_LIQUIDATO]         DECIMAL (18, 2) NULL,
    [FLAG_LIQUIDATO]            BIT             NULL,
    [ID_DECRETO]                INT             NULL,
    CONSTRAINT [PK_DOMANDA_DI_PAGAMENTO_BARCODE] PRIMARY KEY CLUSTERED ([ID_DOMANDA_PAGAMENTO] ASC, [ID_PROGETTO] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_DOMANDA_DI_PAGAMENTO_BARCODE_DOMANDA_DI_PAGAMENTO] FOREIGN KEY ([ID_DOMANDA_PAGAMENTO]) REFERENCES [dbo].[DOMANDA_DI_PAGAMENTO] ([ID_DOMANDA_PAGAMENTO])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_DOMANDA_DI_PAGAMENTO_ESPORTAZIONE]
    ON [dbo].[DOMANDA_DI_PAGAMENTO_ESPORTAZIONE]([BARCODE] ASC) WITH (FILLFACTOR = 80);

