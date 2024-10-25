CREATE TABLE [dbo].[PROGETTO_STORICO_ANNULLATI] (
    [ID_ANNULLAMENTO]        INT           IDENTITY (1, 1) NOT NULL,
    [ID]                     INT           NOT NULL,
    [ID_PROGETTO]            INT           NOT NULL,
    [COD_STATO]              CHAR (1)      NOT NULL,
    [DATA]                   DATETIME      NOT NULL,
    [OPERATORE]              INT           NOT NULL,
    [SEGNATURA]              VARCHAR (100) NULL,
    [REVISIONE]              BIT           NOT NULL,
    [RIESAME]                BIT           NOT NULL,
    [RICORSO]                BIT           NOT NULL,
    [DATA_RI]                DATETIME      NULL,
    [OPERATORE_RI]           INT           NULL,
    [SEGNATURA_RI]           VARCHAR (100) NULL,
    [RIAPERTURA_PROVINCIALE] BIT           NULL,
    [ID_ATTO]                INT           NULL,
    [DATA_ANNULLAMENTO]      DATETIME      CONSTRAINT [DF_PROGETTO_STORICO_ANNULLATI_DATA_ANNULLAMENTO] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_PROGETTO_STORICO_ANNULLATI] PRIMARY KEY CLUSTERED ([ID_ANNULLAMENTO] ASC) WITH (FILLFACTOR = 80)
);

