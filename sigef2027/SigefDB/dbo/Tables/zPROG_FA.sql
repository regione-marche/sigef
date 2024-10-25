﻿CREATE TABLE [dbo].[zPROG_FA] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [ID_PROGRAMMAZIONE] INT             NOT NULL,
    [COD_FA]            VARCHAR (10)    NOT NULL,
    [TIPO_CONTRIBUTO]   CHAR (1)        NOT NULL,
    [DOT_FINANZIARIA]   DECIMAL (18, 2) CONSTRAINT [DF_zPROG_FA_DOT_FINANZIARIA] DEFAULT ((0)) NOT NULL,
    [ATTIVO]            BIT             CONSTRAINT [DF_zPROG_FA_ATTIVO] DEFAULT ((0)) NOT NULL,
    [DATA]              DATETIME        NOT NULL,
    [OPERATORE]         INT             NOT NULL,
    CONSTRAINT [PK_zPROG_FA] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_zPROG_FA_zFOCUS_AREA] FOREIGN KEY ([COD_FA]) REFERENCES [dbo].[zFOCUS_AREA] ([CODICE]),
    CONSTRAINT [FK_zPROG_FA_zPROGRAMMAZIONE] FOREIGN KEY ([ID_PROGRAMMAZIONE]) REFERENCES [dbo].[zPROGRAMMAZIONE] ([ID])
);

