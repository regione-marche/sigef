CREATE TABLE [dbo].[Lotto_di_Revisione_20171017] (
    [ID_LOTTO]           INT          IDENTITY (1, 1) NOT NULL,
    [ID_BANDO]           INT          NOT NULL,
    [PROVINCIA]          CHAR (2)     NOT NULL,
    [DATA_CREAZIONE]     DATETIME     NOT NULL,
    [CF_OPERATORE]       VARCHAR (16) NOT NULL,
    [DATA_MODIFICA]      DATETIME     NOT NULL,
    [NUMERO_ESTRAZIONI]  INT          NOT NULL,
    [REVISIONE_CONCLUSA] BIT          NOT NULL
);

