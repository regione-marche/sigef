﻿CREATE TABLE [dbo].[BUSINESS_PLAN] (
    [ID_BANDO]  INT NOT NULL,
    [ID_QUADRO] INT NOT NULL,
    [ORDINE]    INT NULL,
    CONSTRAINT [PK_BUSINESS_PLAN] PRIMARY KEY CLUSTERED ([ID_BANDO] ASC, [ID_QUADRO] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_BUSINESS_PLAN_BANDO] FOREIGN KEY ([ID_BANDO]) REFERENCES [dbo].[BANDO] ([ID_BANDO]),
    CONSTRAINT [FK_BUSINESS_PLAN_QUADRI_BUSINESS_PLAN] FOREIGN KEY ([ID_QUADRO]) REFERENCES [dbo].[QUADRI_BUSINESS_PLAN] ([ID_QUADRO])
);
