﻿CREATE TABLE [dbo].[ALLEGATI] (
    [ID_ALLEGATO]              INT            IDENTITY (1, 1) NOT NULL,
    [DESCRIZIONE]              VARCHAR (1000) NOT NULL,
    [MISURA]                   VARCHAR (10)   NULL,
    [COD_TIPO]                 CHAR (1)       NOT NULL,
    [COD_TIPO_ENTE_EMETTITORE] CHAR (2)       NULL,
    CONSTRAINT [PK_ALLEGATI] PRIMARY KEY CLUSTERED ([ID_ALLEGATO] ASC) WITH (FILLFACTOR = 80)
);

