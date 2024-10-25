﻿CREATE TABLE [dbo].[BANDO_CONFIG_TIPO] (
    [CODICE]        VARCHAR (30)  NOT NULL,
    [COD_MACROTIPO] VARCHAR (30)  NOT NULL,
    [FORMATO]       VARCHAR (50)  NOT NULL,
    [DESCRIZIONE]   VARCHAR (255) NOT NULL,
    [ATTIVO]        BIT           NOT NULL,
    [ORDINE]        INT           CONSTRAINT [DF_BANDO_CONFIG_TIPO_ORDINE] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_BANDO_CONFIG_TIPO] PRIMARY KEY CLUSTERED ([CODICE] ASC)
);

