﻿CREATE TABLE [dbo].[GIUSTIFICATIVO_X_REGISTRO_IRREGOLARITA] (
    [ID_GIUSTIFICATIVO_X_IRREGOLARITA] INT          IDENTITY (1, 1) NOT NULL,
    [ID_GIUSTIFICATIVO]                INT          NOT NULL,
    [ID_REGISTRO_IRREGOLARITA]         INT          NOT NULL,
    [DATA_INSERIMENTO]                 DATETIME     NULL,
    [CF_INSERIMENTO]                   VARCHAR (16) NULL,
    [DATA_MODIFICA]                    DATETIME     NULL,
    [CF_MODIFICA]                      VARCHAR (16) NULL,
    CONSTRAINT [PK_GIUSTIFICATIVO_X_REGISTRO_IRREGOLARITA] PRIMARY KEY CLUSTERED ([ID_GIUSTIFICATIVO_X_IRREGOLARITA] ASC),
    CONSTRAINT [FK_GIUSTIFICATIVO_X_REGISTRO_IRREGOLARITA_GIUSTIFICATIVI] FOREIGN KEY ([ID_GIUSTIFICATIVO]) REFERENCES [dbo].[GIUSTIFICATIVI] ([ID_GIUSTIFICATIVO]),
    CONSTRAINT [FK_GIUSTIFICATIVO_X_REGISTRO_IRREGOLARITA_REGISTRO_IRREGOLARITA] FOREIGN KEY ([ID_REGISTRO_IRREGOLARITA]) REFERENCES [dbo].[REGISTRO_IRREGOLARITA] ([ID_IRREGOLARITA]),
    CONSTRAINT [UQ_GIUSTIFICATIVO_X_REGISTRO_IRREGOLARITA] UNIQUE NONCLUSTERED ([ID_GIUSTIFICATIVO] ASC, [ID_REGISTRO_IRREGOLARITA] ASC)
);
