
CREATE VIEW [dbo].[vzPROGRAMMAZIONE_SANZIONI]
AS
SELECT	snz.ID,
		snz.ID_PROGRAMMAZIONE,
		snz.COD_SANZIONE,
		snz.ATTIVA,
		snz.DATA_INIZIO,
		snz.OPERATORE_INIZIO,
		snz.DATA_FINE,
		snz.OPERATORE_FINE,
		snz.ORDINE,
		tps.TITOLO			AS SANZIONE_TITOLO,
		tps.DESCRIZIONE		AS SANZIONE_DESCRIZIONE,
		OpInizio.NOMINATIVO AS OPINIZIO_NOMINATIVO,
		OpFine.NOMINATIVO   AS OPFINE_NOMINATIVO
FROM ZProgrammazione_Sanzioni AS snz
     LEFT JOIN
	 Tipo_Sanzioni AS tps ON snz.Cod_Sanzione = tps.Cod_Tipo
	 LEFT JOIN
	 vUTENTI AS OpInizio ON snz.Operatore_Inizio = OpInizio.Id_Utente
	 LEFT JOIN
	 vUTENTI AS OpFine ON snz.Operatore_Fine = OpFine.Id_Utente
