﻿CREATE TABLE [dbo].[ENTE_STORICO] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL,
    [COD_ENTE]      VARCHAR (10)  NOT NULL,
    [DENOMINAZIONE] VARCHAR (255) NOT NULL,
    [ID_IMPRESA]    INT           NULL,
    [ATTIVO]        BIT           CONSTRAINT [DF_ENTE_STORICO_ATTIVO] DEFAULT ((0)) NOT NULL,
    [DATA]          DATETIME      NOT NULL,
    [OPERATORE]     INT           NOT NULL,
    CONSTRAINT [PK_ENTE_STORICO] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (FILLFACTOR = 80)
);

