﻿CREATE TABLE [dbo].[ATTI] (
    [ID_ATTO]                  INT            IDENTITY (1, 1) NOT NULL,
    [COD_TIPO]                 CHAR (1)       NULL,
    [COD_DEFINIZIONE]          CHAR (1)       NOT NULL,
    [COD_ORGANO_ISTITUZIONALE] CHAR (2)       NOT NULL,
    [NUMERO]                   INT            NOT NULL,
    [DATA]                     DATETIME       NOT NULL,
    [DESCRIZIONE]              VARCHAR (3000) NULL,
    [DATA_BUR]                 DATETIME       NULL,
    [NUMERO_BUR]               INT            NULL,
    [SERVIZIO]                 VARCHAR (255)  NULL,
    [REGISTRO]                 VARCHAR (10)   NULL,
    [AW_DOCNUMBER]             VARCHAR (30)   NULL,
    [AW_DOCNUMBER_NUOVO]       INT            NULL,
    CONSTRAINT [ATTI_PK] PRIMARY KEY CLUSTERED ([ID_ATTO] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_ATTI_ORGANO_ISTITUZIONALE] FOREIGN KEY ([COD_ORGANO_ISTITUZIONALE]) REFERENCES [dbo].[ORGANO_ISTITUZIONALE] ([CODICE]),
    CONSTRAINT [FK_ATTI_TIPO_ATTO] FOREIGN KEY ([COD_TIPO]) REFERENCES [dbo].[TIPO_ATTO] ([CODICE]),
    CONSTRAINT [FK_ATTI_TIPO_DEFINIZIONE_ATTO] FOREIGN KEY ([COD_DEFINIZIONE]) REFERENCES [dbo].[TIPO_DEFINIZIONE_ATTO] ([CODICE])
);

