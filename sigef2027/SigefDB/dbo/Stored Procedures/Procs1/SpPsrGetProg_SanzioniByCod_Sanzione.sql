
CREATE PROCEDURE [dbo].[SpPsrGetProg_SanzioniByCod_Sanzione]
(
	@ID_PROGRAMMAZIONE INT,
	@COD_SANZIONE      VARCHAR(10)
)
AS
SELECT  TOP 1
		tps.COD_TIPO    AS COD_SANZIONE,
		tps.TITOLO      AS SANZIONE_TITOLO,
		tps.DESCRIZIONE AS SANZIONE_DESCRIZIONE,
		snz.ID,
		snz.ID_PROGRAMMAZIONE,
		snz.ORDINE,
		snz.DATA_INIZIO,
		snz.OPERATORE_INIZIO,
		snz.DATA_FINE,
		snz.OPERATORE_FINE,
		snz.ATTIVA,
		OpInizio.NOMINATIVO AS OPINIZIO_NOMINATIVO,
		OpFine.NOMINATIVO   AS OPFINE_NOMINATIVO
FROM Tipo_Sanzioni AS tps
     LEFT JOIN
	 ZProgrammazione_Sanzioni AS snz ON tps.Cod_Tipo = snz.Cod_Sanzione
									-- AND snz.Attiva = 1
									AND snz.Id_Programmazione = @ID_PROGRAMMAZIONE
									AND tps.Cod_Tipo          = @COD_SANZIONE
	 LEFT JOIN
	 vUTENTI AS OpInizio ON snz.Operatore_Inizio = OpInizio.Id_Utente
	 LEFT JOIN
	 vUTENTI AS OpFine ON snz.Operatore_Fine = OpFine.Id_Utente
ORDER BY snz.Data_Inizio DESC
