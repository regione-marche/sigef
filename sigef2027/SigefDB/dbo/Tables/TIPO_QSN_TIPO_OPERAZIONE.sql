﻿CREATE TABLE [dbo].[TIPO_QSN_TIPO_OPERAZIONE] (
    [COD_TIPO_QSN_OPERAZIONE] INT            NOT NULL,
    [TipoOperazione]          CHAR (1)       NOT NULL,
    [DescrizioneTipologia]    NVARCHAR (100) NOT NULL,
    [ELIMINATO]               BIT            NOT NULL,
    CONSTRAINT [PK_TIPO_QSN_TIPO_OPERAZIONE] PRIMARY KEY CLUSTERED ([COD_TIPO_QSN_OPERAZIONE] ASC)
);

