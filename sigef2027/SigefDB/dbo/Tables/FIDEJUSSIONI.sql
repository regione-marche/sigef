﻿CREATE TABLE [dbo].[FIDEJUSSIONI] (
    [ID_FIDEJUSSIONE]           INT             IDENTITY (1, 1) NOT NULL,
    [NUMERO]                    VARCHAR (25)    NULL,
    [BARCODE]                   VARCHAR (11)    NOT NULL,
    [DATA_SOTTOSCRIZIONE]       DATETIME        NULL,
    [LUOGO_SOTTOSCRIZIONE]      VARCHAR (128)   NULL,
    [IMPORTO]                   DECIMAL (18, 2) NOT NULL,
    [AMMONTARE_RICHIESTO]       DECIMAL (18, 2) NOT NULL,
    [DATA_FINE_LAVORI]          DATETIME        NOT NULL,
    [DATA_SCADENZA]             DATETIME        NOT NULL,
    [PROROGA_SCADENZA]          BIT             CONSTRAINT [DF_FIDEJUSSIONI_PROROGA_SCADENZA] DEFAULT ((0)) NOT NULL,
    [PIVA_GARANTE]              VARCHAR (11)    NULL,
    [RAGIONE_SOCIALE_GARANTE]   VARCHAR (150)   NULL,
    [LOCALITA_GARANTE]          VARCHAR (128)   NULL,
    [NUMERO_REGISTRO_IMPRESE]   VARCHAR (10)    NULL,
    [COGNOME_RAPPLEGALE]        VARCHAR (30)    NULL,
    [NOME_RAPPLEGALE]           VARCHAR (20)    NULL,
    [CF_RAPPLEGALE]             VARCHAR (16)    NULL,
    [DATA_NASCITA_RAPPLEGALE]   DATETIME        NULL,
    [STAMPA_EFFETTUATA]         BIT             CONSTRAINT [DF_FIDEJUSSIONI_STAMPA_EFFETTUATA] DEFAULT ((0)) NOT NULL,
    [DATA_RICHIESTA_VALIDITA]   DATETIME        NULL,
    [DATA_RICEVIMENTO_VALIDITA] DATETIME        NULL,
    [PROTOCOLLO_FAX_VALIDITA]   VARCHAR (100)   NULL,
    [DATA_DECORRENZA_GARANZIA]  DATETIME        NULL,
    [CODICE_ABI_ENTE_GARANTE]   VARCHAR (5)     NULL,
    [CODICE_CAB_ENTE_GARANTE]   VARCHAR (5)     NULL,
    [BARCODE_CONFERMA_VALIDITA] VARCHAR (11)    NULL,
    [COD_TIPO]                  CHAR (3)        NOT NULL,
    [UFFICIO_APPROVAZIONE]      VARCHAR (120)   NULL,
    [NUM_DECRETO_APPROVAZIONE]  INT             NULL,
    [DATA_DECRETO_APPROVAZIONE] DATETIME        NULL,
    CONSTRAINT [PK_FIDEJUSSIONI] PRIMARY KEY CLUSTERED ([ID_FIDEJUSSIONE] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_FIDEJUSSIONI_TIPO_POLIZZA] FOREIGN KEY ([COD_TIPO]) REFERENCES [dbo].[TIPO_POLIZZA] ([COD_TIPO_POLIZZA])
);

