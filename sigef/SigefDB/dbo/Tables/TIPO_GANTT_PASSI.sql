CREATE TABLE [dbo].[TIPO_GANTT_PASSI] (
    [ID_PASSO]          INT           NOT NULL,
    [DESCRIZIONE]       VARCHAR (200) NOT NULL,
    [NUM_GG_STANDARD]   INT           NULL,
    [FLAG_VALORE]       BIT           CONSTRAINT [DF_TIPO_GANTT_PASSI_FLAG_FINANZIARIO] DEFAULT ((0)) NOT NULL,
    [ID_TIPO_VALORE]    TINYINT       NULL,
    [VALORE_AUTOMATICO] BIT           CONSTRAINT [DF_TIPO_GANTT_PASSI_VALORE_AUTOMATICO] DEFAULT ((0)) NOT NULL,
    [PROCEDURA_CALCOLO] VARCHAR (250) NULL,
    CONSTRAINT [PK_GANT_TIPI_PASSO] PRIMARY KEY CLUSTERED ([ID_PASSO] ASC),
    CONSTRAINT [FK_TIPO_GANTT_PASSI_TIPO_GANTT_VALORI] FOREIGN KEY ([ID_TIPO_VALORE]) REFERENCES [dbo].[TIPO_GANTT_VALORI] ([ID_TIPO_VALORE]) ON UPDATE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'= 1 se lo step prevede l''indicazione di un valore da raggiungere', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TIPO_GANTT_PASSI', @level2type = N'COLUMN', @level2name = N'FLAG_VALORE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'vero se il valore è calcolato in automatico dai dati del SIGEF', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TIPO_GANTT_PASSI', @level2type = N'COLUMN', @level2name = N'VALORE_AUTOMATICO';

