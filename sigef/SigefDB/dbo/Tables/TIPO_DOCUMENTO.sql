﻿CREATE TABLE [dbo].[TIPO_DOCUMENTO] (
    [CODICE]      VARCHAR (10)  NOT NULL,
    [FORMATO]     CHAR (1)      NOT NULL,
    [DESCRIZIONE] VARCHAR (250) NOT NULL,
    [ATTIVO]      BIT           CONSTRAINT [DF_TIPO_DOCUMENTO_ATTIVO] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_TIPO_DOCUMENTO] PRIMARY KEY CLUSTERED ([CODICE] ASC)
);
