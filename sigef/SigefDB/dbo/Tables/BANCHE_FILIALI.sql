CREATE TABLE [dbo].[BANCHE_FILIALI] (
    [ID]                   INT           IDENTITY (1, 1) NOT NULL,
    [ABI]                  CHAR (5)      NOT NULL,
    [CAB]                  CHAR (5)      NOT NULL,
    [NOTE]                 VARCHAR (100) NULL,
    [INDIRIZZO]            VARCHAR (100) NULL,
    [ID_COMUNE]            INT           NULL,
    [COMUNE]               VARCHAR (100) NULL,
    [PROVINCIA]            CHAR (2)      NULL,
    [CAP]                  CHAR (5)      NULL,
    [DATA_INIZIO_VALIDITA] DATETIME      NOT NULL,
    [DATA_FINE_VALIDITA]   DATETIME      NULL,
    [ATTIVO]               BIT           CONSTRAINT [DF_ELENCO_FILIALI_BANCHE_ATTIVO] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ELENCO_FILIALI_BANCHE] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (FILLFACTOR = 100)
);


GO
CREATE NONCLUSTERED INDEX [IX_BANCHE_FILIALI]
    ON [dbo].[BANCHE_FILIALI]([ABI] ASC, [CAB] ASC) WITH (FILLFACTOR = 100);

