﻿CREATE TABLE [dbo].[REGIONI] (
    [CODICE]        CHAR (2)     NOT NULL,
    [DENOMINAZIONE] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_REGIONI] PRIMARY KEY CLUSTERED ([CODICE] ASC) WITH (FILLFACTOR = 100)
);
