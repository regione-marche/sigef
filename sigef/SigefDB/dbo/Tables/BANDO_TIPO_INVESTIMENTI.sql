﻿CREATE TABLE [dbo].[BANDO_TIPO_INVESTIMENTI] (
    [ID_TIPO_INVESTIMENTO]  INT             IDENTITY (1, 1) NOT NULL,
    [ID_BANDO]              INT             NOT NULL,
    [COD_TIPO_INVESTIMENTO] INT             NOT NULL,
    [IMPORTO_MAX]           DECIMAL (15, 2) NULL,
    [IMPORTO_MIN]           DECIMAL (15, 2) NULL,
    [QUOTA_MAX]             DECIMAL (10, 2) NULL,
    [NOTE]                  VARCHAR (500)   NULL,
    [PREMIO]                BIT             CONSTRAINT [DF_BANDO_TIPO_INVESTIMENTI_PREMIO] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_BANDO_TIPO_INVESTIMENTI] PRIMARY KEY CLUSTERED ([ID_TIPO_INVESTIMENTO] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_BANDO_TIPO_INVESTIMENTI_BANDO] FOREIGN KEY ([ID_BANDO]) REFERENCES [dbo].[BANDO] ([ID_BANDO]),
    CONSTRAINT [FK_BANDO_TIPO_INVESTIMENTI_TIPO_INVESTIMENTO] FOREIGN KEY ([COD_TIPO_INVESTIMENTO]) REFERENCES [dbo].[TIPO_INVESTIMENTO] ([COD_TIPO_INVESTIMENTO])
);
