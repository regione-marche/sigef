﻿CREATE TABLE [dbo].[BANDO_REQUISITI_VARIANTE] (
    [ID_BANDO]                   INT      NOT NULL,
    [COD_TIPO]                   CHAR (2) NOT NULL,
    [ID_REQUISITO]               INT      NOT NULL,
    [OBBLIGATORIO]               BIT      CONSTRAINT [DF_BANDO_REQUISITI_VARIANTE_OBBLIGATORIO] DEFAULT ((0)) NOT NULL,
    [REQUISITO_DI_PRESENTAZIONE] BIT      CONSTRAINT [DF_BANDO_REQUISITI_VARIANTE_REQUISITO_DI_PRESENTAZIONE] DEFAULT ((0)) NOT NULL,
    [REQUISITO_DI_ISTRUTTORIA]   BIT      CONSTRAINT [DF_BANDO_REQUISITI_VARIANTE_REQUISITO_DI_ISTRUTTORIA] DEFAULT ((0)) NOT NULL,
    [ORDINE]                     INT      NULL,
    CONSTRAINT [PK_BANDO_VARIANTI_REQUISITI] PRIMARY KEY CLUSTERED ([ID_BANDO] ASC, [COD_TIPO] ASC, [ID_REQUISITO] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_BANDO_REQUISITI_VARIANTE_BANDO_TIPO_VARIANTI] FOREIGN KEY ([ID_BANDO], [COD_TIPO]) REFERENCES [dbo].[BANDO_TIPO_VARIANTI] ([ID_BANDO], [COD_TIPO]),
    CONSTRAINT [FK_BANDO_REQUISITI_VARIANTE_REQUISITI_VARIANTE] FOREIGN KEY ([ID_REQUISITO]) REFERENCES [dbo].[REQUISITI_VARIANTE] ([ID_REQUISITO])
);
