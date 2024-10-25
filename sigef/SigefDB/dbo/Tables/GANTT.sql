﻿CREATE TABLE [dbo].[GANTT] (
    [ID_GANTT]            INT      IDENTITY (1, 1) NOT NULL,
    [ID_BANDO]            INT      NOT NULL,
    [ID_UO]               INT      NULL,
    [ID_STATO]            TINYINT  CONSTRAINT [DF_GANTT_ID_STATO] DEFAULT ((0)) NOT NULL,
    [ID_TIPOOP]           INT      NOT NULL,
    [DATA_CAMBIOSTATO]    DATETIME NULL,
    [DATA_LASTEDIT_STEPS] DATETIME NULL,
    CONSTRAINT [PK_GANTT_1] PRIMARY KEY CLUSTERED ([ID_GANTT] ASC),
    CONSTRAINT [FK_GANTT_GANTT_BANDO] FOREIGN KEY ([ID_BANDO]) REFERENCES [dbo].[GANTT_BANDO] ([ID_BANDO_GANTT]),
    CONSTRAINT [FK_GANTT_TIPO_GANTT_STATO] FOREIGN KEY ([ID_STATO]) REFERENCES [dbo].[TIPO_GANTT_STATO] ([ID_STATO]) ON UPDATE CASCADE,
    CONSTRAINT [FK_GANTT_TIPO_GANTT_TIPIOPERAZIONE] FOREIGN KEY ([ID_TIPOOP]) REFERENCES [dbo].[TIPO_GANTT_TIPIOPERAZIONE] ([ID_TIPOOP]) ON UPDATE CASCADE,
    CONSTRAINT [FK_GANTT_UO] FOREIGN KEY ([ID_UO]) REFERENCES [dbo].[UO] ([ID_UO]) ON UPDATE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'struttura (Unità Organizzativa) che deve eseguire lo step', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GANTT', @level2type = N'COLUMN', @level2name = N'ID_UO';

