﻿CREATE TABLE [dbo].[STEP] (
    [ID_STEP]        INT            IDENTITY (1, 1) NOT NULL,
    [COD_FASE]       CHAR (1)       NOT NULL,
    [DESCRIZIONE]    VARCHAR (300)  NOT NULL,
    [AUTOMATICO]     BIT            NULL,
    [QUERY_SQL]      VARCHAR (3000) NULL,
    [QUERY_SQL_POST] VARCHAR (300)  NULL,
    [CODE_METHOD]    VARCHAR (30)   NULL,
    [URL]            VARCHAR (100)  NULL,
    [VAL_MINIMO]     VARCHAR (20)   NULL,
    [VAL_MASSIMO]    VARCHAR (20)   NULL,
    [MISURA]         VARCHAR (20)   NULL,
    CONSTRAINT [PK_STEP] PRIMARY KEY CLUSTERED ([ID_STEP] ASC) WITH (FILLFACTOR = 80)
);
