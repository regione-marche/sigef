﻿CREATE TABLE [dbo].[SPESE_SOSTENUTE_FILE] (
    [ID_FILE_SPESE_SOSTENUTE] INT           IDENTITY (1, 1) NOT NULL,
    [ID_SPESA]                INT           NULL,
    [DATA_INSERIMENTO]        DATETIME      CONSTRAINT [DF_SPESE_SOSTENUTE_FILE_DATA_INSERIMENTO] DEFAULT (getdate()) NULL,
    [CF_INSERIMENTO]          VARCHAR (25)  NULL,
    [DATA_MODIFICA]           DATETIME      CONSTRAINT [DF_SPESE_SOSTENUTE_FILE_DATA_MODIFICA] DEFAULT (getdate()) NULL,
    [CF_MODIFICA]             VARCHAR (25)  NULL,
    [IN_INTEGRAZIONE]         BIT           CONSTRAINT [DF_SPESE_SOSTENUTE_FILE_IN_INTEGRAZIONE] DEFAULT ((0)) NULL,
    [DESCRIZIONE]             VARCHAR (100) NULL,
    [ID_FILE]                 INT           NULL,
    CONSTRAINT [PK_SPESE_SOSTENUTE_FILE] PRIMARY KEY CLUSTERED ([ID_FILE_SPESE_SOSTENUTE] ASC),
    CONSTRAINT [FK_SPESE_SOSTENUTE_FILE_SPESE_SOSTENUTE] FOREIGN KEY ([ID_SPESA]) REFERENCES [dbo].[SPESE_SOSTENUTE] ([ID_SPESA])
);
