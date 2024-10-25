﻿CREATE TABLE [dbo].[ORGANISMO_PAGATORE] (
    [CODICE]         VARCHAR (5)         NULL,
    [DENIMINAZIONE]  [dbo].[DESCRIZIONE] NULL,
    [SIGLA]          VARCHAR (50)        NULL,
    [CODICE_ESTERNO] VARCHAR (4)         NOT NULL,
    CONSTRAINT [PK_ORGANISMO_PAGATORE_1] PRIMARY KEY CLUSTERED ([CODICE_ESTERNO] ASC) WITH (FILLFACTOR = 80)
);

