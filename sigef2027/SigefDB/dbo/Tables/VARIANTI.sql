﻿CREATE TABLE [dbo].[VARIANTI] (
    [ID_VARIANTE]               INT            IDENTITY (1, 1) NOT NULL,
    [ID_PROGETTO]               INT            NOT NULL,
    [COD_TIPO]                  CHAR (2)       NOT NULL,
    [DATA_INSERIMENTO]          DATETIME       NOT NULL,
    [COD_ENTE]                  VARCHAR (10)   NULL,
    [OPERATORE]                 VARCHAR (16)   NOT NULL,
    [DATA_MODIFICA]             DATETIME       NULL,
    [DESCRIZIONE]               VARCHAR (1000) NULL,
    [SEGNATURA]                 VARCHAR (100)  NULL,
    [SEGNATURA_ALLEGATI]        VARCHAR (100)  NULL,
    [SEGNATURA_APPROVAZIONE]    VARCHAR (100)  NULL,
    [APPROVATA]                 BIT            NULL,
    [DATA_APPROVAZIONE]         DATETIME       NULL,
    [ISTRUTTORE]                VARCHAR (16)   NULL,
    [NOTE_ISTRUTTORE]           NTEXT          NULL,
    [CUAA_ENTRANTE]             VARCHAR (16)   NULL,
    [ID_FASCICOLO_ENTRANTE]     INT            NULL,
    [CUAA_USCENTE]              VARCHAR (16)   NULL,
    [RAGSOC_USCENTE]            VARCHAR (255)  NULL,
    [ID_FASCICOLO_USCENTE]      INT            NULL,
    [ANNULLATA]                 BIT            CONSTRAINT [DF_VARIANTI_ANNULLATA] DEFAULT ((0)) NOT NULL,
    [SEGNATURA_ANNULLAMENTO]    VARCHAR (100)  NULL,
    [CF_OPERATORE_ANNULLAMENTO] VARCHAR (16)   NULL,
    [DATA_ANNULLAMENTO]         DATETIME       NULL,
    [ID_ATTO_APPROVAZIONE]      INT            NULL,
    CONSTRAINT [PK_VARIANTI] PRIMARY KEY NONCLUSTERED ([ID_VARIANTE] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_VARIANTI_ATTI] FOREIGN KEY ([ID_ATTO_APPROVAZIONE]) REFERENCES [dbo].[ATTI] ([ID_ATTO]),
    CONSTRAINT [FK_VARIANTI_PROGETTO] FOREIGN KEY ([ID_PROGETTO]) REFERENCES [dbo].[PROGETTO] ([ID_PROGETTO]),
    CONSTRAINT [FK_VARIANTI_TIPO_VARIANTE] FOREIGN KEY ([COD_TIPO]) REFERENCES [dbo].[TIPO_VARIANTE] ([COD_TIPO])
);


GO
CREATE CLUSTERED INDEX [IX_VARIANTI]
    ON [dbo].[VARIANTI]([ID_PROGETTO] ASC) WITH (FILLFACTOR = 80);

