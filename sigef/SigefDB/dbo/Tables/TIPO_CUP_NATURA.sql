﻿CREATE TABLE [dbo].[TIPO_CUP_NATURA] (
    [COD_CUP_NATURA] CHAR (2)      NOT NULL,
    [Descrizione]    VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_TIPO_CUP_NATURA] PRIMARY KEY CLUSTERED ([COD_CUP_NATURA] ASC)
);
