﻿CREATE PROCEDURE [dbo].[SpCalcoloSanzioneRD08032011]
(
	@ID_SANZIONE INT,
	@DURATA DECIMAL(18,2) =NULL,
	@GRAVITA DECIMAL(18,2) =NULL,
	@ENTITA DECIMAL(18,2)=NULL,
	@MOTIVAZIONE NTEXT =NULL
)
AS
	/*DECLARE @ID_SANZIONE INT
	SET @ID_SANZIONE=93*/

	-- LA SANZIONE VIENE CALCOLATA PER MISURA (ID_PROGETTO)

	DECLARE @CONTRIBUTO_AMMESSO DECIMAL(18,2),@AMMONTARE_SANZIONE DECIMAL(18,5)
	SELECT @CONTRIBUTO_AMMESSO=SUM(CONTRIBUTO_AMMESSO) FROM PAGAMENTI_RICHIESTI P
	INNER JOIN PIANO_INVESTIMENTI I ON P.ID_INVESTIMENTO=I.ID_INVESTIMENTO
	INNER JOIN SANZIONI S ON P.ID_DOMANDA_PAGAMENTO=S.ID_DOMANDA_PAGAMENTO
	WHERE ID_SANZIONE=@ID_SANZIONE AND S.ID_INVESTIMENTO IS NULL AND I.ID_PROGETTO=S.ID_PROGETTO
	
	-- SANZIONE PER IL PREMIO CC 112
	DECLARE @ID_DOMANDA_PAGAMENTO INT,@COD_TIPO_DPAGAMENTO CHAR(3),@ID_BANDO INT
	SELECT DISTINCT @ID_DOMANDA_PAGAMENTO=D.ID_DOMANDA_PAGAMENTO,@COD_TIPO_DPAGAMENTO=D.COD_TIPO,@ID_BANDO=P.ID_BANDO
	FROM SANZIONI S INNER JOIN DOMANDA_DI_PAGAMENTO D ON S.ID_DOMANDA_PAGAMENTO=D.ID_DOMANDA_PAGAMENTO
	INNER JOIN PROGETTO P ON S.ID_PROGETTO=P.ID_PROGETTO
	INNER JOIN BANDO_TIPO_INVESTIMENTI B ON P.ID_BANDO=B.ID_BANDO AND B.COD_TIPO_INVESTIMENTO=3
	WHERE S.ID_SANZIONE=@ID_SANZIONE
	IF @COD_TIPO_DPAGAMENTO='SLD' -- SE NON NULLO IL BANDO PREVEDE IL PREMIO CC
		SELECT @CONTRIBUTO_AMMESSO=dbo.calcoloPremioContoCapitaleSaldo(@ID_DOMANDA_PAGAMENTO,1)	

	SET @AMMONTARE_SANZIONE=ROUND(3*ISNULL(@CONTRIBUTO_AMMESSO,0)/100,2)	
	UPDATE SANZIONI SET DATA_APPLICAZIONE=GETDATE(),AMMONTARE=@AMMONTARE_SANZIONE,DURATA=@DURATA,GRAVITA=@GRAVITA,
		ENTITA=@ENTITA,MOTIVAZIONE=@MOTIVAZIONE WHERE ID_SANZIONE=@ID_SANZIONE
	SELECT * FROM VSANZIONI WHERE ID_SANZIONE=@ID_SANZIONE