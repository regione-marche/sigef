﻿CREATE TABLE [dbo].[VLD_STEP] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [DESCRIZIONE]    VARCHAR (1000) NOT NULL,
    [AUTOMATICO]     BIT            NULL,
    [QUERY_SQL]      VARCHAR (3000) NULL,
    [QUERY_SQL_POST] VARCHAR (300)  NULL,
    [CODE_METHOD]    VARCHAR (30)   NULL,
    [URL]            VARCHAR (100)  NULL,
    [VAL_MINIMO]     VARCHAR (20)   NULL,
    [VAL_MASSIMO]    VARCHAR (20)   NULL,
    [MISURA]         VARCHAR (20)   NULL,
    CONSTRAINT [PK_VLD_STEP] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (FILLFACTOR = 80)
);

