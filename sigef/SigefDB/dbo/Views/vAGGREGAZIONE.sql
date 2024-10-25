﻿
CREATE VIEW dbo.vAGGREGAZIONE
AS
SELECT dbo.AGGREGAZIONE.ID, dbo.AGGREGAZIONE.DENOMINAZIONE, dbo.AGGREGAZIONE.COD_TIPO_AGGREGAZIONE, dbo.AGGREGAZIONE.DATA_INIZIO, 
                  dbo.AGGREGAZIONE.ATTIVO, dbo.AGGREGAZIONE.DATA_FINE, dbo.AGGREGAZIONE.OPERATORE_INIZIO, dbo.AGGREGAZIONE.OPERATORE_FINE, 
                  dbo.TIPO_AGGREGAZIONE.DESCRIZIONE AS DESCRIZIONE_TIPO_AGGREGAZIONE, dbo.IMPRESA_AGGREGAZIONE.ID_IMPRESA, 
                  dbo.IMPRESA_AGGREGAZIONE.ATTIVO AS IMPRESA_AGGREGAZIONE_ATTIVA
FROM     dbo.AGGREGAZIONE INNER JOIN
                  dbo.TIPO_AGGREGAZIONE ON dbo.AGGREGAZIONE.COD_TIPO_AGGREGAZIONE = dbo.TIPO_AGGREGAZIONE.CODICE INNER JOIN
                  dbo.IMPRESA_AGGREGAZIONE ON dbo.AGGREGAZIONE.ID = dbo.IMPRESA_AGGREGAZIONE.ID_AGGREGAZIONE

