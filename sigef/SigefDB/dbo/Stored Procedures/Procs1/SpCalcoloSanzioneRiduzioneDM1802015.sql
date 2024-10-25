﻿CREATE PROCEDURE [dbo].[SpCalcoloSanzioneRiduzioneDM1802015]
(
	@ID_SANZIONE INT,
	@DURATA DECIMAL(18,2) =NULL,
	@GRAVITA DECIMAL(18,2) =NULL,
	@ENTITA DECIMAL(18,2)=NULL,
	@MOTIVAZIONE NTEXT =NULL
)
AS
	--DECLARE @ID_SANZIONE INT=286

	-- LA SANZIONE VIENE CALCOLATA PER MISURA (ID_PROGETTO)
	DECLARE @AMMONTARE_SANZIONE DECIMAL(18,5)
	SELECT @AMMONTARE_SANZIONE=SUM(CTR/100*QU_RID) FROM (
		SELECT ISNULL(PR.CONTRIBUTO_AMMESSO,0) AS CTR,QU_RID=CASE --WHEN ISNULL(PR.CONTRIBUTO_AMMESSO,0)=0 THEN 0
			WHEN Z.CODICE='1.1.1.a' THEN 40
			WHEN Z.CODICE='1.2.3.' THEN CASE WHEN I.QUOTA_CONTRIBUTO_RICHIESTO>20 THEN 37.5 ELSE 75 END
			WHEN Z.CODICE='1.3.2.' THEN 71.4
			WHEN Z.CODICE='1.3.3.' THEN 42.8
			WHEN Z.CODICE='3.1.1.B' THEN 33.3
			ELSE 0 END	
			--PR.CONTRIBUTO_AMMESSO,I.QUOTA_CONTRIBUTO_RICHIESTO,Z.CODICE
		FROM PAGAMENTI_RICHIESTI PR INNER JOIN PIANO_INVESTIMENTI I ON PR.ID_INVESTIMENTO=I.ID_INVESTIMENTO
		INNER JOIN PROGETTO P ON I.ID_PROGETTO=P.ID_PROGETTO
		INNER JOIN BANDO B ON P.ID_BANDO=B.ID_BANDO
		INNER JOIN zPROGRAMMAZIONE Z ON B.ID_PROGRAMMAZIONE=Z.ID
		INNER JOIN SANZIONI S ON PR.ID_DOMANDA_PAGAMENTO=S.ID_DOMANDA_PAGAMENTO
		WHERE ID_SANZIONE=@ID_SANZIONE
	) Q1
	
	UPDATE SANZIONI SET DATA_APPLICAZIONE=GETDATE(),AMMONTARE=ROUND(@AMMONTARE_SANZIONE,2),DURATA=@DURATA,GRAVITA=@GRAVITA,
		ENTITA=@ENTITA,MOTIVAZIONE=@MOTIVAZIONE WHERE ID_SANZIONE=@ID_SANZIONE
	SELECT * FROM VSANZIONI WHERE ID_SANZIONE=@ID_SANZIONE
