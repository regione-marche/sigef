﻿CREATE TABLE [dbo].[ENTE] (
    [COD_ENTE]        VARCHAR (10)  NOT NULL,
    [COD_TIPO_ENTE]   VARCHAR (10)  NOT NULL,
    [DESCRIZIONE]     VARCHAR (255) NOT NULL,
    [COD_SIAN]        VARCHAR (20)  NULL,
    [ATTIVO]          BIT           CONSTRAINT [DF_ENTE_ATTIVO] DEFAULT ((1)) NOT NULL,
    [EMISSIONE_BANDI] BIT           CONSTRAINT [DF_ENTE_EMISSIONE_BANDI] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ENTE] PRIMARY KEY CLUSTERED ([COD_ENTE] ASC) WITH (FILLFACTOR = 100),
    CONSTRAINT [FK_ENTE_TIPO_ENTE] FOREIGN KEY ([COD_TIPO_ENTE]) REFERENCES [dbo].[TIPO_ENTE] ([COD_TIPO_ENTE])
);

