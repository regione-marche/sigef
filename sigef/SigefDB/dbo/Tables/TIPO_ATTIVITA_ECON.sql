﻿CREATE TABLE [dbo].[TIPO_ATTIVITA_ECON] (
    [COD_ATTIVITA_ECON] CHAR (2)      NOT NULL,
    [Descrizione]       VARCHAR (250) NOT NULL,
    CONSTRAINT [PK_TIPO_ATTIVITA_ECON] PRIMARY KEY CLUSTERED ([COD_ATTIVITA_ECON] ASC)
);
