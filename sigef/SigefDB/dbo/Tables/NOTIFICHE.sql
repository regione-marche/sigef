CREATE TABLE [dbo].[NOTIFICHE] (
    [ID_NOTIFICA]      INT           NOT NULL,
    [m]                VARCHAR (50)  CONSTRAINT [DF_NOTIFICHE_m] DEFAULT ('*') NOT NULL,
    [h]                VARCHAR (50)  CONSTRAINT [DF_NOTIFICHE_h] DEFAULT ('*') NOT NULL,
    [dom]              VARCHAR (50)  CONSTRAINT [DF_NOTIFICHE_dom] DEFAULT ('*') NOT NULL,
    [mon]              VARCHAR (50)  CONSTRAINT [DF_NOTIFICHE_mon] DEFAULT ('*') NOT NULL,
    [dow]              VARCHAR (50)  CONSTRAINT [DF_NOTIFICHE_dow] DEFAULT ('*') NOT NULL,
    [CLASSE_NOTIFICHE] VARCHAR (200) NULL,
    [ATTIVO]           BIT           CONSTRAINT [DF_NOTIFICHE_ATTIVO] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_NOTIFICHE] PRIMARY KEY CLUSTERED ([ID_NOTIFICA] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'minuti', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'NOTIFICHE', @level2type = N'COLUMN', @level2name = N'm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ora', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'NOTIFICHE', @level2type = N'COLUMN', @level2name = N'h';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'giorno del mese', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'NOTIFICHE', @level2type = N'COLUMN', @level2name = N'dom';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'mese da 1 a 12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'NOTIFICHE', @level2type = N'COLUMN', @level2name = N'mon';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'0 = domenica, 6 = sabato', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'NOTIFICHE', @level2type = N'COLUMN', @level2name = N'dow';

