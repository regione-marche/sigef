CREATE TABLE [dbo].[CONTO_CORRENTE] (
    [ID_CONTO_CORRENTE]    INT                 IDENTITY (1, 1) NOT NULL,
    [ID_IMPRESA]           INT                 NULL,
    [ID_PERSONA]           INT                 NULL,
    [COD_PAESE]            CHAR (2)            NOT NULL,
    [CIN_EURO]             CHAR (2)            NOT NULL,
    [CIN]                  CHAR (1)            NOT NULL,
    [ABI]                  VARCHAR (5)         NOT NULL,
    [CAB]                  VARCHAR (5)         NOT NULL,
    [NUMERO]               VARCHAR (20)        NOT NULL,
    [NOTE]                 VARCHAR (500)       NULL,
    [DATA_INIZIO_VALIDITA] DATETIME            CONSTRAINT [DF_CONTO_CORRENTE_DATA_INIZIO_VALIDITA] DEFAULT (getdate()) NOT NULL,
    [DATA_FINE_VALIDITA]   DATETIME            NULL,
    [ISTITUTO]             [dbo].[DESCRIZIONE] NOT NULL,
    [AGENZIA]              [dbo].[DESCRIZIONE] NOT NULL,
    [ID_COMUNE]            INT                 NOT NULL,
    CONSTRAINT [PK_CONTO_CORRENTE] PRIMARY KEY CLUSTERED ([ID_CONTO_CORRENTE] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_CONTO_CORRENTE_IMPRESA] FOREIGN KEY ([ID_IMPRESA]) REFERENCES [dbo].[IMPRESA] ([ID_IMPRESA]),
    CONSTRAINT [FK_CONTO_CORRENTE_PERSONA_FISICA] FOREIGN KEY ([ID_PERSONA]) REFERENCES [dbo].[PERSONA_FISICA] ([ID_PERSONA])
);

