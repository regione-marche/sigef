CREATE TABLE [dbo].[FUNZIONALITA] (
    [COD_FUNZIONE] INT                 IDENTITY (1, 1) NOT NULL,
    [DESCRIZIONE]  [dbo].[DESCRIZIONE] NULL,
    [FLAG_MENU]    BIT                 NULL,
    [DESC_MENU]    VARCHAR (50)        NULL,
    [LIVELLO]      INT                 NULL,
    [PADRE]        INT                 NULL,
    [LINK]         [dbo].[DESCRIZIONE] NULL,
    [ORDINE]       INT                 NULL,
    CONSTRAINT [FUNZIONALITA_PK] PRIMARY KEY CLUSTERED ([COD_FUNZIONE] ASC) WITH (FILLFACTOR = 80)
);

