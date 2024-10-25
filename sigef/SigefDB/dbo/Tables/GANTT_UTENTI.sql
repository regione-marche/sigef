﻿CREATE TABLE [dbo].[GANTT_UTENTI] (
    [ID_UTENTE]        INT          NOT NULL,
    [CF]               VARCHAR (16) NOT NULL,
    [VEDE_TUTTO]       BIT          CONSTRAINT [DF_GANTT_UTENTI_VEDE_TUTTO] DEFAULT ((0)) NOT NULL,
    [MAIL_STATO_STEPS] BIT          CONSTRAINT [DF_GANTT_UTENTI_MAIL_STATO_STEPS] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_GANTT_USERS] PRIMARY KEY CLUSTERED ([ID_UTENTE] ASC)
);

