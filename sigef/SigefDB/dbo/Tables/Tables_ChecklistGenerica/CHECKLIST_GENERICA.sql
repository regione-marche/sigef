﻿CREATE TABLE [dbo].[CHECKLIST_GENERICA] (
    [ID_CHECKLIST_GENERICA] INT                 IDENTITY (1, 1) NOT NULL,
    [DESCRIZIONE]           VARCHAR(MAX)        NOT NULL,
    [FLAG_TEMPLATE]         BIT                 NOT NULL,
    [DATA_INSERIMENTO]      DATETIME            CONSTRAINT [DF_CHECKLIST_GENERICA_DATA_INSERIMENTO] DEFAULT (getdate()) NULL,
    [CF_INSERIMENTO]        CHAR (16)           NULL,
    [DATA_MODIFICA]         DATETIME            CONSTRAINT [DF_CHECKLIST_GENERICA_DATA_MODIFICA] DEFAULT (getdate()) NULL,
    [CF_MODIFICA]           CHAR (16)           NULL,
    ID_TIPO                 INT                 NULL,
    ID_FILTRO               VARCHAR(200)        NULL,
    CONSTRAINT [PK_CHECKLIST_GENERICA] PRIMARY KEY CLUSTERED ([ID_CHECKLIST_GENERICA] ASC) WITH (FILLFACTOR = 80)
);

ALTER TABLE CHECKLIST_GENERICA  WITH CHECK ADD CONSTRAINT [FK_CHECKLIST_GENERICA_TIPO_CHECKLIST] FOREIGN KEY(ID_TIPO)
REFERENCES TIPO_CHECKLIST (ID_TIPO)
GO

ALTER TABLE CHECKLIST_GENERICA  WITH CHECK ADD CONSTRAINT [FK_CHECKLIST_GENERICA_FILTRO] FOREIGN KEY(ID_FILTRO)
REFERENCES FILTRO_CHECKLIST_VOCE (ID_FILTRO)
GO