﻿CREATE PROCEDURE [dbo].[SpPsrCalcoloAmmontareAnticipo]
(
	@ID_BANDO INT,
	@ID_ANTICIPO INT -- ID_DOMANDA_PAGAMENTO RELATIVO ALL'ANTICIPO
)
AS
	
	--DECLARE @ID_BANDO INT,@ID_ANTICIPO INT
	--SET @ID_BANDO=218
	--SET @ID_ANTICIPO=383

	DECLARE @ID_VARIANTE INT,@ID_PROGETTO_INTEGRATO INT,@DATA_ANTICIPO DATETIME
	SELECT @ID_PROGETTO_INTEGRATO=ID_PROGETTO,@DATA_ANTICIPO=DATA_MODIFICA FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO=@ID_ANTICIPO
	SELECT TOP 1 @ID_VARIANTE=ID_VARIANTE FROM VARIANTI WHERE ID_PROGETTO=@ID_PROGETTO_INTEGRATO AND APPROVATA=1 
		AND DATA_MODIFICA<@DATA_ANTICIPO ORDER BY DATA_MODIFICA DESC
			
	SELECT B.ID_BANDO,q1.MISURA_PREVALENTE,R.TIPO+' '+R.CODICE AS MISURA,BT.COD_TIPO,QUOTA_MAX,QUOTA_MIN,IMPORTO_MAX,IMPORTO_MIN,
		BT.DESCRIZIONE,COD_FASE,FASE,BT.ORDINE,P.ID_PROGETTO,
		COSTO_DI_MISURA=CASE WHEN P.ID_PROGETTO IS NULL OR R.CODICE IN ('1.1.2.','M06.1.A') THEN 0 ELSE 
			CAST(dbo.SIAR_MIN(ISNULL(GF.COSTO_TOTALE,GP.COSTO_TOTALE),DBO.calcoloCostoTotaleProgettoCorrelato(P.ID_PROGETTO,1,@ID_VARIANTE)) 
			AS DECIMAL(18,2)) END,
		CONTRIBUTO_DI_MISURA=ISNULL(CASE WHEN P.ID_PROGETTO IS NULL THEN NULL WHEN R.CODICE IN ('1.1.2.','M06.1.A') THEN 
			DBO.calcoloPremioContoCapitale(P.ID_PROGETTO,1,@ID_VARIANTE) ELSE 
			CAST(dbo.SIAR_MIN(ISNULL(GF.CONTRIBUTO_DI_MISURA,GP.CONTRIBUTO_TOTALE),
			DBO.calcoloContributoTotaleProgettoCorrelato(P.ID_PROGETTO,1,@ID_VARIANTE)) AS DECIMAL(18,2)) END,0),
		ISNULL(AR.AMMESSO,0) AS AMMESSO,AR.CONTRIBUTO_RICHIESTO AS AMMONTARE_RICHIESTO,AR.CONTRIBUTO_AMMESSO AS AMMONTARE_AMMESSO
	FROM (
		SELECT DISTINCT ISNULL(ID_DISPOSIZIONI_ATTUATIVE,ID_BANDO) AS IDB,MISURA_PREVALENTE 
		FROM BANDO_PROGRAMMAZIONE WHERE ID_BANDO=@ID_BANDO) AS Q1
	INNER JOIN BANDO B ON Q1.IDB=B.ID_BANDO
	INNER JOIN VZPROGRAMMAZIONE R ON B.ID_PROGRAMMAZIONE=R.ID
	LEFT JOIN vBANDO_TIPO_PAGAMENTO BT ON Q1.IDB=BT.ID_BANDO AND BT.COD_TIPO='ANT'
	LEFT JOIN PROGETTO P ON BT.ID_BANDO=P.ID_BANDO AND ISNULL(P.ID_PROG_INTEGRATO,P.ID_PROGETTO)=@ID_PROGETTO_INTEGRATO
	LEFT JOIN ANTICIPI_RICHIESTI AR ON P.ID_BANDO=AR.ID_BANDO AND AR.ID_DOMANDA_PAGAMENTO=@ID_ANTICIPO
	LEFT JOIN GRADUATORIA_PROGETTI_FINANZIABILITA GF ON P.ID_BANDO=GF.ID_BANDO AND P.ID_PROGETTO=GF.ID_PROGETTO
	LEFT JOIN GRADUATORIA_PROGETTI GP ON P.ID_BANDO=GP.ID_BANDO AND P.ID_PROGETTO=GP.ID_PROGETTO
	ORDER BY Q1.MISURA_PREVALENTE DESC,R.TIPO+' '+R.CODICE