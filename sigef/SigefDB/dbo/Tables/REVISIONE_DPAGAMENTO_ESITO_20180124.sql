CREATE TABLE [dbo].[REVISIONE_DPAGAMENTO_ESITO_20180124] (
    [ID]                       INT            IDENTITY (1, 1) NOT NULL,
    [ID_LOTTO]                 INT            NOT NULL,
    [ID_DOMANDA_PAGAMENTO]     INT            NOT NULL,
    [ID_VLD_STEP]              INT            NOT NULL,
    [COD_ESITO]                CHAR (2)       NULL,
    [DATA]                     DATETIME       NOT NULL,
    [OPERATORE]                INT            NOT NULL,
    [NOTE]                     VARCHAR (5000) NULL,
    [ESCLUDI_DA_COMUNICAZIONE] BIT            NOT NULL
);

