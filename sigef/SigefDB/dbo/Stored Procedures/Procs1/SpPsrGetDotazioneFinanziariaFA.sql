﻿CREATE PROCEDURE [dbo].[SpPsrGetDotazioneFinanziariaFA]
(
	@COD_FA VARCHAR(10)
)
AS
	SELECT PF.ID,P.ID AS ID_PROGRAMMAZIONE,FA.CODICE AS COD_FA,PF.DOT_FINANZIARIA,PF.TIPO_CONTRIBUTO,
		FA.COD_PSR,FA.DESCRIZIONE AS FA_DESCRIZIONE,FA.DOT_FINANZIARIA AS FA_DOT_FINANZIARIA,FA.TRASVERSALE, 
		P.COD_TIPO AS PROG_COD_TIPO,P.CODICE AS PROG_CODICE,P.DESCRIZIONE AS PROG_DESCRIZIONE,P.ID_PADRE,P.TIPO AS PROG_TIPO, 
		P.LIVELLO,P.ATTIVAZIONE_BANDI,P.ATTIVAZIONE_FA,P.ATTIVAZIONE_OB_MISURA,PF.ATTIVO,PF.DATA,PF.OPERATORE,CF_UTENTE,NOMINATIVO,COD_ENTE
	FROM zFOCUS_AREA FA INNER JOIN vzPROGRAMMAZIONE P ON FA.COD_PSR=P.COD_PSR
	LEFT JOIN zPROG_FA PF ON P.ID=PF.ID_PROGRAMMAZIONE AND FA.CODICE=PF.COD_FA AND PF.ATTIVO=1
	LEFT JOIN vUTENTI U ON PF.OPERATORE=U.ID_UTENTE
	WHERE FA.CODICE=@COD_FA AND P.ATTIVAZIONE_FA=1
	ORDER BY P.CODICE,P.DESCRIZIONE
