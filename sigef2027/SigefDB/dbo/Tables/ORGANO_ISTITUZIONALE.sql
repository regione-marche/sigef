﻿CREATE TABLE [dbo].[ORGANO_ISTITUZIONALE] (
    [CODICE]      CHAR (2)      NOT NULL,
    [DESCRIZIONE] VARCHAR (100) NOT NULL,
    [ATTIVO]      BIT           NOT NULL,
    CONSTRAINT [PK_ORGANO_ISTITUZIONALE] PRIMARY KEY CLUSTERED ([CODICE] ASC) WITH (FILLFACTOR = 100)
);
