﻿CREATE TABLE [dbo].[BANCHE_ISTITUTI] (
    [ABI]                  CHAR (5)      NOT NULL,
    [DENOMINAZIONE]        VARCHAR (100) NOT NULL,
    [DATA_INIZIO_VALIDITA] DATETIME      NOT NULL,
    [DATA_FINE_VALIDITA]   DATETIME      NULL,
    [ATTIVO]               BIT           CONSTRAINT [DF_BANCHE_ISTITUTI_ATTIVO] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_BANCHE_ISTITUTI] PRIMARY KEY CLUSTERED ([ABI] ASC) WITH (FILLFACTOR = 100)
);
