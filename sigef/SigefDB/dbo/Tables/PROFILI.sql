﻿CREATE TABLE [dbo].[PROFILI] (
    [ID_PROFILO]                 INT           IDENTITY (1, 1) NOT NULL,
    [DESCRIZIONE]                VARCHAR (255) NOT NULL,
    [COD_TIPO_ENTE]              VARCHAR (10)  NULL,
    [ORDINE]                     INT           NULL,
    [ABILITA_INSERIMENTO_UTENTI] BIT           CONSTRAINT [DF_PROFILI_ABILITA_INSERIMENTO_UTENTI] DEFAULT ((0)) NOT NULL,
    [ATTIVO]                     BIT           CONSTRAINT [DF_PROFILI_ATTIVO] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PROFILI_PK] PRIMARY KEY CLUSTERED ([ID_PROFILO] ASC) WITH (FILLFACTOR = 100),
    CONSTRAINT [FK_PROFILI_TIPO_ENTE] FOREIGN KEY ([COD_TIPO_ENTE]) REFERENCES [dbo].[TIPO_ENTE] ([COD_TIPO_ENTE])
);
