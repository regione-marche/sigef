﻿CREATE TABLE [dbo].[LIVELLO_PRIORITA] (
    [COD_LIVELLO] CHAR (1)            NOT NULL,
    [DESCRIZIONE] [dbo].[DESCRIZIONE] NULL,
    CONSTRAINT [PK_LIVELLO_PRIORITA] PRIMARY KEY CLUSTERED ([COD_LIVELLO] ASC) WITH (FILLFACTOR = 100)
);
