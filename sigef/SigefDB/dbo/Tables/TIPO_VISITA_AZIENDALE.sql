﻿CREATE TABLE [dbo].[TIPO_VISITA_AZIENDALE] (
    [COD_TIPO]    CHAR (3)      NOT NULL,
    [DESCRIZIONE] VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_TIPO_VISITA_AZIENDALE] PRIMARY KEY CLUSTERED ([COD_TIPO] ASC) WITH (FILLFACTOR = 100)
);

