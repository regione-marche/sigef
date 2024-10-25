﻿CREATE TABLE [dbo].[COMUNI_X_ZONA_ALTIMETRICA] (
    [ID]                      INT           IDENTITY (1, 1) NOT NULL,
    [CODICE_PROVINCIA]        CHAR (3)      NULL,
    [SIGLA_PROVINCIA]         CHAR (2)      NULL,
    [CODICE_COMUNE]           VARCHAR (6)   NULL,
    [COMUNE]                  VARCHAR (255) NULL,
    [CODICE_ZONA_ALTIMETRICA] INT           NULL,
    CONSTRAINT [PK_COMUNI_X_ZONA_ALTIMETRICA] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (FILLFACTOR = 100)
);

