﻿CREATE TABLE [dbo].[TIPO_AGGREGAZIONE_RUOLO] (
    [CODICE]      VARCHAR (10)  NOT NULL,
    [DESCRIZIONE] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_TIPO_AGGREGAZIONE_RUOLO] PRIMARY KEY CLUSTERED ([CODICE] ASC)
);
