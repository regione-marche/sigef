﻿CREATE TABLE [dbo].[TIPO_COMUNICAZIONE] (
    [COD_TIPO]    CHAR (3)      NOT NULL,
    [DESCRIZIONE] VARCHAR (250) NOT NULL,
    [IN_ENTRATA]  BIT           NOT NULL,
    [IN_USCITA]   BIT           NOT NULL,
    CONSTRAINT [PK_TIPO_COMUNICAZIONE] PRIMARY KEY CLUSTERED ([COD_TIPO] ASC)
);

