﻿CREATE PROCEDURE [dbo].[RptManifestazioneAccessoQMRinnovo]
	@IdManifestazione INT 
AS
BEGIN

--- SISTEMA DI QUALITà QM - PRIORITA
--- AGRITEST = 60
--- SIAR = 236
--- SIARTEST = 240


--- RILASCIO  - VALORI PRIORITA
--- AGRITEST = 40
--- SIAR = 383
--- SIARTEST = 411

--- RINNOVO  - VALORI PRIORITA
--- AGRITEST = 41
--- SIAR = 384
--- SIARTEST = 412


SELECT     PRIORITA_X_MANIFESTAZIONE.ID_MANIFESTAZIONE, PRIORITA_X_MANIFESTAZIONE.ID_PRIORITA, PRIORITA_X_MANIFESTAZIONE.ID_VALORE, 
                      PRIORITA_X_MANIFESTAZIONE.VALORE, PRIORITA_X_MANIFESTAZIONE.DATA_VALUTAZIONE, 
                      PRIORITA_X_MANIFESTAZIONE.OPERATORE_VALUTAZIONE, PRIORITA_X_MANIFESTAZIONE.MODIFICA_MANUALE, 
                      PRIORITA_X_MANIFESTAZIONE.PUNTEGGIO
FROM         PRIORITA_X_MANIFESTAZIONE INNER JOIN
                      PRIORITA ON PRIORITA_X_MANIFESTAZIONE.ID_PRIORITA = PRIORITA.ID_PRIORITA INNER JOIN
                      VALORI_PRIORITA ON PRIORITA_X_MANIFESTAZIONE.ID_VALORE = VALORI_PRIORITA.ID_VALORE
WHERE     (PRIORITA_X_MANIFESTAZIONE.ID_MANIFESTAZIONE = @IdManifestazione) 
AND (PRIORITA_X_MANIFESTAZIONE.ID_PRIORITA = 236)
AND PRIORITA_X_MANIFESTAZIONE.ID_VALORE = 384
END