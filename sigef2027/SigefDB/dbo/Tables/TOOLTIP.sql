﻿CREATE TABLE [dbo].[TOOLTIP] (
    [CODICE] VARCHAR (50) NOT NULL,
    [TESTO]  NTEXT        NOT NULL,
    CONSTRAINT [PK_TOOLTIP] PRIMARY KEY CLUSTERED ([CODICE] ASC) WITH (FILLFACTOR = 100)
);
