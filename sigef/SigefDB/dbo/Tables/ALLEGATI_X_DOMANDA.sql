﻿CREATE TABLE [dbo].[ALLEGATI_X_DOMANDA] (
    [ID_ALLEGATO] INT NOT NULL,
    [ID_DOMANDA]  INT NOT NULL,
    [ORDINE]      INT NULL,
    CONSTRAINT [PK_ALLEGATI_X_DOMANDA] PRIMARY KEY CLUSTERED ([ID_ALLEGATO] ASC, [ID_DOMANDA] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_ALLEGATI_X_DOMANDA_ALLEGATI] FOREIGN KEY ([ID_ALLEGATO]) REFERENCES [dbo].[ALLEGATI] ([ID_ALLEGATO]),
    CONSTRAINT [FK_ALLEGATI_X_DOMANDA_MODELLO_DOMANDA] FOREIGN KEY ([ID_DOMANDA]) REFERENCES [dbo].[MODELLO_DOMANDA] ([ID_DOMANDA])
);

