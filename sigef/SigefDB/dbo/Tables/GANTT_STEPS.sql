CREATE TABLE [dbo].[GANTT_STEPS] (
    [ID_STEP]               INT             IDENTITY (1, 1) NOT NULL,
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
    [IS_IN_DEFINIZIONE]     BIT             CONSTRAINT [DF_GANTT_STEPS_IS_IN_DEFINIZIONE] DEFAULT ((0)) NOT NULL,
    [DATA_INSERT]           DATETIME        NULL,
    [DATA_LASTEDIT]         DATETIME        NULL,
    CONSTRAINT [PK_GANTT] PRIMARY KEY CLUSTERED ([ID_STEP] ASC),
    CONSTRAINT [FK_GANTT_STEPS_GANTT] FOREIGN KEY ([ID_GNATT]) REFERENCES [dbo].[GANTT] ([ID_GANTT]) ON UPDATE CASCADE,
    CONSTRAINT [FK_GANTT_STEPS_UO] FOREIGN KEY ([UO_PASSO]) REFERENCES [dbo].[UO] ([ID_UO]),
    CONSTRAINT [FK_GANTT_TIPO_GANTT_PASSI] FOREIGN KEY ([ID_TIPO_PASSO]) REFERENCES [dbo].[TIPO_GANTT_PASSI] ([ID_PASSO]) ON UPDATE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tipo passo da eseguire', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GANTT_STEPS', @level2type = N'COLUMN', @level2name = N'ID_TIPO_PASSO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'valore da raggiungere alla data fine', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GANTT_STEPS', @level2type = N'COLUMN', @level2name = N'VALORE_PREVISTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'valore raggiunto alla data fine', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GANTT_STEPS', @level2type = N'COLUMN', @level2name = N'VALORE_EFFETTIVO';

