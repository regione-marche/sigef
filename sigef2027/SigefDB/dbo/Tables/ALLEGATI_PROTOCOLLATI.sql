﻿CREATE TABLE [dbo].[ALLEGATI_PROTOCOLLATI] (
    [ID_ALLEGATO_PROTOCOLLATO] INT            IDENTITY (1, 1) NOT NULL,
    [ID_PROGETTO]              INT            NULL,
    [ID_DOMANDA_PAGAMENTO]     INT            NULL,
    [ID_VARIANTE]              INT            NULL,
    [ID_INTEGRAZIONE]          INT            NULL,
    [ID_COMUNICAZIONE]         INT            NULL,
    [ID_FILE]                  INT            NOT NULL,
    [PROTOCOLLATO]             BIT            CONSTRAINT [DF_ALLEGATI_PROTOCOLLATI_PROTOCOLLATO] DEFAULT ((0)) NOT NULL,
    [PROTOCOLLO]               NVARCHAR (100) NULL,
    [DATA_INSERIMENTO]         DATETIME       CONSTRAINT [DF_ALLEGATI_PROTOCOLLATI_DATA_INSERIMENTO] DEFAULT (getdate()) NULL,
    [DATA_MODIFICA]            DATETIME       CONSTRAINT [DF_ALLEGATI_PROTOCOLLATI_DATA_MODIFICA] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_ALLEGATI_PROTOCOLLATI] PRIMARY KEY CLUSTERED ([ID_ALLEGATO_PROTOCOLLATO] ASC)
);
