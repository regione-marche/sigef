﻿CREATE TABLE [dbo].[SPESE_SOSTENUTE] (
    [ID_SPESA]                        INT             IDENTITY (1, 1) NOT NULL,
    [ID_DOMANDA_PAGAMENTO]            INT             NOT NULL,
    [ID_GIUSTIFICATIVO]               INT             NOT NULL,
    [COD_TIPO]                        CHAR (3)        NOT NULL,
    [ESTREMI]                         VARCHAR (255)   NOT NULL,
    [DATA]                            DATETIME        NOT NULL,
    [IMPORTO]                         DECIMAL (18, 2) NOT NULL,
    [NETTO]                           DECIMAL (18, 2) NOT NULL,
    [AMMESSO]                         BIT             CONSTRAINT [DF_SPESE_SOSTENUTE_AMMESSO] DEFAULT ((0)) NOT NULL,
    [DATA_APPROVAZIONE]               DATETIME        NULL,
    [OPERATORE_APPROVAZIONE]          INT             NULL,
    [ID_FILE]                         INT             NULL,
    [IN_INTEGRAZIONE]                 BIT             CONSTRAINT [DF_SPESE_SOSTENUTE_IN_INTEGRAZIONE] DEFAULT ((0)) NULL,
    [ID_FILE_MODIFICATO_INTEGRAZIONE] BIT             NULL,
    CONSTRAINT [PK_SPESE_SOSTENUTE] PRIMARY KEY CLUSTERED ([ID_SPESA] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_SPESE_SOSTENUTE_DOMANDA_DI_PAGAMENTO] FOREIGN KEY ([ID_DOMANDA_PAGAMENTO]) REFERENCES [dbo].[DOMANDA_DI_PAGAMENTO] ([ID_DOMANDA_PAGAMENTO]),
    CONSTRAINT [FK_SPESE_SOSTENUTE_GIUSTIFICATIVI] FOREIGN KEY ([ID_GIUSTIFICATIVO]) REFERENCES [dbo].[GIUSTIFICATIVI] ([ID_GIUSTIFICATIVO]),
    CONSTRAINT [FK_SPESE_SOSTENUTE_TIPO_GIUSTIFICATIVO] FOREIGN KEY ([COD_TIPO]) REFERENCES [dbo].[TIPO_GIUSTIFICATIVO] ([COD_TIPO])
);


GO
CREATE NONCLUSTERED INDEX [IX_SPESE_SOSTENUTE]
    ON [dbo].[SPESE_SOSTENUTE]([ID_DOMANDA_PAGAMENTO] ASC) WITH (FILLFACTOR = 80);


GO
CREATE NONCLUSTERED INDEX [IX_SPESE_SOSTENUTE_1]
    ON [dbo].[SPESE_SOSTENUTE]([ID_GIUSTIFICATIVO] ASC) WITH (FILLFACTOR = 80);
