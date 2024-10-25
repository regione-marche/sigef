CREATE TABLE [dbo].[GANTT_BANDO] (
    [ID_BANDO_GANTT]      INT             IDENTITY (1, 1) NOT NULL,
    [ID_PROGRAMMAZIONE]   INT             NOT NULL,
    [OGGETTO]             VARCHAR (500)   NOT NULL,
    [IMPORTO]             DECIMAL (18, 2) NULL,
    [IMPORTO_PREVISTO]    DECIMAL (18, 2) NULL,
    [IMPORTO_FINANZIATO]  DECIMAL (18, 2) NULL,
    [IMPORTO_CERTIFICATO] DECIMAL (18, 2) NULL,
    [ID_BANDO_BANDI]      INT             NULL,
    CONSTRAINT [PK_GANTT_BANDO] PRIMARY KEY CLUSTERED ([ID_BANDO_GANTT] ASC),
    CONSTRAINT [FK_GANTT_BANDO_BANDO] FOREIGN KEY ([ID_BANDO_BANDI]) REFERENCES [dbo].[BANDO] ([ID_BANDO]) ON UPDATE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ID del bando nella tabella BANDO (NULL se FSE o bando FESR non caricato in SIGEF)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GANTT_BANDO', @level2type = N'COLUMN', @level2name = N'ID_BANDO_BANDI';

