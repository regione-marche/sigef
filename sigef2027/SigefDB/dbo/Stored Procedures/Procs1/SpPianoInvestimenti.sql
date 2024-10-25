﻿CREATE PROCEDURE [dbo].[SpPianoInvestimenti]
(
	@ID_PROGETTO INT,
	@COD_QUERY VARCHAR(30),
	@ID_VARIANTE_ATTUALE INT = NULL,
	@ID_DOMANDA_PAGAMENTO INT = NULL
)
AS

DECLARE @ID_VARIANTE INT,@DATA_MODIFICA_PAGAMENTO DATETIME,@COD_TIPO CHAR(3)

--QUERY UTILIZZATA IN PIANO_INVESTIMENTI.ASPX E IDENTICA PAGINA IN ISTRUTTORIA e IN PAGAMENTO
IF @COD_QUERY='PIANO_INVESTIMENTI' BEGIN
	SELECT @ID_VARIANTE=MAX(ID_VARIANTE) FROM VARIANTI WHERE ID_PROGETTO=@ID_PROGETTO AND APPROVATA=1 AND ANNULLATA=0
	SELECT I.* FROM vPROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON P.ID_PROGETTO=I.ID_PROGETTO
	WHERE ISNULL(P.ID_PROG_INTEGRATO,P.ID_PROGETTO)=@ID_PROGETTO AND ISNULL(I.COD_VARIAZIONE,'')!='A' AND
		((ORDINE_FASE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL) OR 
		(ORDINE_FASE<4 AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL) OR
		(ORDINE_FASE>=4  AND ((@ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL) OR
		 ID_VARIANTE=@ID_VARIANTE))) ORDER BY COD_TIPO_INVESTIMENTO,ID_INVESTIMENTO
END
IF @COD_QUERY='INVESTIMENTI_PROG_CORRELATO' BEGIN	
	SET @ID_VARIANTE =@ID_VARIANTE_ATTUALE
	SELECT I.* FROM vPROGETTO AS P INNER JOIN VPIANO_INVESTIMENTI AS I ON P.ID_PROGETTO=I.ID_PROGETTO
	WHERE ISNULL(P.ID_PROG_INTEGRATO,P.ID_PROGETTO)=@ID_PROGETTO AND
		((ORDINE_FASE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL) OR 
		(ORDINE_FASE<4 AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL) OR
		(ORDINE_FASE>=4  AND ((@ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL) OR
		 ID_VARIANTE=@ID_VARIANTE))) ORDER BY COD_TIPO_INVESTIMENTO,ID_INVESTIMENTO
END
ELSE IF @COD_QUERY='PIANO_INVESTIMENTI_ISTRUTTORIA' BEGIN
	SELECT I.* FROM PROGETTO AS P INNER JOIN VPIANO_INVESTIMENTI AS I ON P.ID_PROGETTO=I.ID_PROGETTO
	WHERE ISNULL(P.ID_PROG_INTEGRATO,P.ID_PROGETTO)=@ID_PROGETTO AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL
	ORDER BY COD_TIPO_INVESTIMENTO,ID_INVESTIMENTO
END
/*ELSE IF @COD_QUERY='SPESE_GENERALI' BEGIN -- NON USATA
	SET @ID_VARIANTE =(SELECT MAX(ID_VARIANTE) FROM VARIANTI WHERE ID_PROGETTO=@ID_PROGETTO AND APPROVATA=1 AND ANNULLATA=0)
	SELECT I.*,Q1.CODICE AS CODICE_MISURA FROM vPROGETTO AS P INNER JOIN PIANO_INVESTIMENTI AS I 
    ON P.ID_PROGETTO=I.ID_PROGETTO INNER JOIN(SELECT DISTINCT ID_BANDO ,CODICE FROM  PROGRAMMAZIONE_BANDO 
    AS PB INNER JOIN PROGRAMMAZIONE ON PB.ID_PROGRAMMAZIONE = PROGRAMMAZIONE.ID_PROGRAMMAZIONE INNER JOIN
    MISURA ON PROGRAMMAZIONE.ID_PSR = MISURA.ID_PSR AND PROGRAMMAZIONE.COD_OBIETTIVO = MISURA.COD_OBIETTIVO 
    AND PROGRAMMAZIONE.COD_ASSE = MISURA.COD_ASSE AND PROGRAMMAZIONE.COD_MISURA = MISURA.COD_MISURA
    WHERE PB.MISURA_PREVALENTE=1) AS Q1 ON P.ID_BANDO=Q1.ID_BANDO WHERE COD_TIPO_INVESTIMENTO IN (4,5) AND
		ISNULL(P.ID_PROG_INTEGRATO,P.ID_PROGETTO)=@ID_PROGETTO AND
		((ORDINE_FASE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL) OR 
		(ORDINE_FASE<4 AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL) OR
		(ORDINE_FASE>=4  AND ((@ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL) OR
		 ID_VARIANTE=@ID_VARIANTE))) ORDER BY COD_TIPO_INVESTIMENTO DESC,ID_INVESTIMENTO
END*/
ELSE IF @COD_QUERY='VARIANTE_ATTUALE' BEGIN
	SELECT I.* FROM PROGETTO AS P INNER JOIN VPIANO_INVESTIMENTI AS I ON P.ID_PROGETTO=I.ID_PROGETTO
	WHERE ISNULL(P.ID_PROG_INTEGRATO,P.ID_PROGETTO)=@ID_PROGETTO AND ID_VARIANTE=@ID_VARIANTE_ATTUALE
	ORDER BY COD_TIPO_INVESTIMENTO,ID_INVESTIMENTO
END
ELSE IF @COD_QUERY='VARIANTE_PRECEDENTE' BEGIN
	SET @ID_VARIANTE =(SELECT MAX(ID_VARIANTE) FROM VARIANTI WHERE ID_PROGETTO=@ID_PROGETTO AND APPROVATA=1 AND ANNULLATA=0 AND ID_VARIANTE<@ID_VARIANTE_ATTUALE)
	SELECT I.* FROM PROGETTO AS P INNER JOIN VPIANO_INVESTIMENTI AS I ON P.ID_PROGETTO=I.ID_PROGETTO
	WHERE ISNULL(P.ID_PROG_INTEGRATO,P.ID_PROGETTO)=@ID_PROGETTO AND
		((@ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL) OR ID_VARIANTE=@ID_VARIANTE) 
		ORDER BY COD_TIPO_INVESTIMENTO,ID_INVESTIMENTO
END
ELSE IF @COD_QUERY='INVESTIMENTI_DOMANDA_PAGAMENTO' BEGIN
	SELECT @DATA_MODIFICA_PAGAMENTO=DATA_MODIFICA,@COD_TIPO=COD_TIPO,@ID_VARIANTE=ID_VARIAZIONE_ACCERTATA FROM DOMANDA_DI_PAGAMENTO 
	WHERE ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO
	IF @ID_VARIANTE IS NULL
		SELECT @ID_VARIANTE=MAX(ID_VARIANTE) FROM VARIANTI WHERE ID_PROGETTO=@ID_PROGETTO AND APPROVATA=1 AND ANNULLATA=0 AND DATA_MODIFICA<@DATA_MODIFICA_PAGAMENTO
	SELECT I.*,dbo.calcoloImportoPagamentiRichiestiInvestimento(ID_INVESTIMENTO, @DATA_MODIFICA_PAGAMENTO) AS IMPORTO_PAGAMENTO_RICHIESTO
	FROM PROGETTO AS P INNER JOIN VPIANO_INVESTIMENTI AS I ON P.ID_PROGETTO=I.ID_PROGETTO
	WHERE ISNULL(P.ID_PROG_INTEGRATO,P.ID_PROGETTO)=@ID_PROGETTO AND
		((@ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL) OR
		 (ID_VARIANTE=@ID_VARIANTE AND ISNULL(COD_VARIAZIONE,'X')!='A')) ORDER BY COD_TIPO_INVESTIMENTO,ID_INVESTIMENTO
END/*
ELSE IF @COD_QUERY='SPESE_DOMANDA_PAGAMENTO' BEGIN -- DA RIFARE
	SELECT @DATA_MODIFICA_PAGAMENTO=DATA_MODIFICA,@COD_TIPO=COD_TIPO,@ID_VARIANTE=ID_VARIAZIONE_ACCERTATA FROM DOMANDA_DI_PAGAMENTO 
	WHERE ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO
	IF @ID_VARIANTE IS NULL
		SELECT @ID_VARIANTE=MAX(ID_VARIANTE) FROM VARIANTI WHERE ID_PROGETTO=@ID_PROGETTO AND APPROVATA=1 AND ANNULLATA=0 AND DATA_MODIFICA<@DATA_MODIFICA_PAGAMENTO
	SELECT I.*,Q1.CODICE AS CODICE_MISURA FROM PROGETTO AS P INNER JOIN PIANO_INVESTIMENTI AS I 
    ON P.ID_PROGETTO=I.ID_PROGETTO INNER JOIN(SELECT DISTINCT ID_BANDO ,CODICE FROM  PROGRAMMAZIONE_BANDO 
    AS PB INNER JOIN PROGRAMMAZIONE ON PB.ID_PROGRAMMAZIONE = PROGRAMMAZIONE.ID_PROGRAMMAZIONE INNER JOIN
    MISURA ON PROGRAMMAZIONE.ID_PSR = MISURA.ID_PSR AND PROGRAMMAZIONE.COD_OBIETTIVO = MISURA.COD_OBIETTIVO 
    AND PROGRAMMAZIONE.COD_ASSE = MISURA.COD_ASSE AND PROGRAMMAZIONE.COD_MISURA = MISURA.COD_MISURA
    WHERE PB.MISURA_PREVALENTE=1) AS Q1 ON P.ID_BANDO=Q1.ID_BANDO WHERE COD_TIPO_INVESTIMENTO IN (4,5) AND
		ISNULL(P.ID_PROG_INTEGRATO,P.ID_PROGETTO)=@ID_PROGETTO AND
		((@ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL) OR
		 (ID_VARIANTE=@ID_VARIANTE AND ISNULL(COD_VARIAZIONE,'X')!='A')) ORDER BY COD_TIPO_INVESTIMENTO DESC,ID_INVESTIMENTO
END*/
