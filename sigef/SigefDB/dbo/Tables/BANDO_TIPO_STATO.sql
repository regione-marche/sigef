﻿CREATE TABLE [dbo].[BANDO_TIPO_STATO] (
    [CODICE]      CHAR (1)     NOT NULL,
    [DESCRIZIONE] VARCHAR (50) NOT NULL,
    [ORDINE]      INT          NOT NULL,
    CONSTRAINT [PK_BANDO_TIPO_STATO] PRIMARY KEY CLUSTERED ([CODICE] ASC) WITH (FILLFACTOR = 100)
);

