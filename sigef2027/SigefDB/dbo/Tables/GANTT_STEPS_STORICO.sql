CREATE TABLE [dbo].[GANTT_STEPS_STORICO] (
    [ID_STORICO]            INT             IDENTITY (1, 1) NOT NULL,
    [DATA_STORICO]          DATE            NOT NULL,
    [ID_STEP]               INT             NOT NULL,
    [ID_GNATT]              INT             NOT NULL,
    [ID_TIPO_PASSO]         INT             NULL,
    [ORDINE]                INT             NULL,
    [UO_PASSO]              INT             NOT NULL,
    [DATA_INIZIO_PREVISTA]  DATE            NULL,
    [DATA_INIZIO_EFFETTIVA] DATE            NULL,
    [DATA_FINE_PREVISTA]    DATE            NULL,
    [DATA_FINE_EFFETTIVA]   DATE            NULL,
    [NUM_GG_STANDARD]       INT             NULL,
    [VALORE_PREVISTO]       DECIMAL (18, 4) NULL,
    [VALORE_EFFETTIVO]      DECIMAL (18, 4) NULL,
    [NOTA_PREVISTO]         VARCHAR (2000)  NULL,
    [NOTA]                  VARCHAR (2000)  NULL,
    [IS_IN_DEFINIZIONE]     BIT             NOT NULL,
    [DATA_INSERT]           DATETIME        NULL,
    [DATA_LASTEDIT]         DATETIME        NULL,
    CONSTRAINT [PK_GANTT_STEPS_STORICO] PRIMARY KEY CLUSTERED ([ID_STORICO] ASC)
);

