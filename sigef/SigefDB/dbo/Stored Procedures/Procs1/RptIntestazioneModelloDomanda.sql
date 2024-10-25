﻿CREATE PROCEDURE [dbo].[RptIntestazioneModelloDomanda]
(
	@ID_PROGETTO INT
)
AS
	
	DECLARE @STATO CHAR(1), @DATA_ULTIMA_MODIFICA DATETIME
	SELECT @STATO = COD_STATO FROM VPROGETTO WHERE ID_PROGETTO = @ID_PROGETTO
	IF @STATO = 'P' SET @DATA_ULTIMA_MODIFICA = GETDATE() 
	ELSE SET @DATA_ULTIMA_MODIFICA = (SELECT DATA FROM PROGETTO_STORICO WHERE ID_PROGETTO = @ID_PROGETTO and COD_STATO = 'L')
	
	SELECT P.ID_PROGETTO, P.ID_IMPRESA, P.COD_AGEA, P.PROVINCIA_DI_PRESENTAZIONE, PRO.DENOMINAZIONE AS PROVINCIA_ESTESA, 
	PS.NOMINATIVO AS OPERATORE_PRESENTAZIONE, PS.ENTE AS ENTE_OPERATORE_PRESENTAZIONE, 
	CONVERT(VARCHAR(16), @DATA_ULTIMA_MODIFICA, 103) AS DATA_ULTIMA_MODIFICA,
	B.ID_BANDO, B.DESCRIZIONE AS DESCRIZIONE_BANDO, B.COD_ENTE AS COD_ENTE_BANDO, 
	B.ENTE AS ENTE_BANDO, CONVERT(VARCHAR(16), B.DATA_SCADENZA, 103) AS DATA_SCADENZA_BANDO, 
	PR.CODICE AS COD_PROGRAMMAZIONE, PR.DESCRIZIONE AS PROGRAMMAZIONE, 
	PSR.CODICE AS COD_PSR, PSR.DESCRIZIONE AS DESCRIZIONE_PSR, ANNO_DA AS PSR_ANNO_DA, ANNO_A AS PSR_ANNO_A, 
	PS.SEGNATURA AS SEGNATURA_RILASCIO, 
	F.DATA_SCHEDA_VALIDAZIONE, F.BARCODE AS BARCODE_SCHEDA_VALIDAZIONE, F.DATA_VALIDAZIONE_FASCICOLO, 
	FP.FASCICOLO AS PROTOCOLLO_CLASSIFICAZIONE, 
	A.DATA AS DATA_DECRETO_APERTURA_BANDO, 
	A.NUMERO AS NUM_DECRETO_APERTURA_BANDO, 
	A.REGISTRO AS REGISTRO_DECRETO_APERTURA_BANDO, 
	A.NUMERO_BUR AS NUM_BUR_APERTURA_BANDO,
	A.DATA_BUR AS DATA_BUR_APERTURA_BANDO, 
	A.DEFINIZIONE_ATTO AS DEFINIZIONE_DECRETO_APERTURA_BANDO, 
	P.SEGNATURA_ALLEGATI AS SEGNATURA_ALLEGATI_AIUTO, 
	B.PAROLE_CHIAVE
	--BC.VALORE as StrutturaBando,
	--(Select VAL_TESTO From PRIORITA_X_PROGETTO PP Where PP.ID_PROGETTO = P.ID_PROGETTO and PP.ID_PRIORITA in (12, 9) and VAL_TESTO is not null) as BolloNumero,
	--(Select VAL_DATA From PRIORITA_X_PROGETTO PP Where PP.ID_PROGETTO = P.ID_PROGETTO and PP.ID_PRIORITA in (13, 10) and VAL_DATA is not null) as BolloData
	FROM PROGETTO P 
	INNER JOIN VPROGETTO_STORICO PS ON P.ID_PROGETTO = PS.ID_PROGETTO 
	INNER JOIN VBANDO B ON P.ID_BANDO = B.ID_BANDO
	INNER JOIN vzPROGRAMMAZIONE PR ON B.ID_PROGRAMMAZIONE = PR.ID
	INNER JOIN zPSR PSR ON PR.COD_PSR = PSR.CODICE
	LEFT JOIN PROVINCE PRO ON P.PROVINCIA_DI_PRESENTAZIONE = PRO.SIGLA 
	LEFT JOIN FASCICOLO_AZIENDALE F ON P.ID_FASCICOLO = F.ID_FASCICOLO
	LEFT JOIN FASCICOLO_PALEO FP ON PSR.CODICE = FP.COD_TIPO and P.PROVINCIA_DI_PRESENTAZIONE = FP.PROVINCIA 
	LEFT JOIN (SELECT  ID_BANDO, MIN(ID_ATTO) ID_ATTO-- MI PERMETTE DI PRENDERE IL PRIMO ATTO INSERITO PER LE COMUNICAZIONI
						FROM BANDO_INTEGRAZIONI WHERE ID_ATTO IS NOT NULL 
						GROUP BY ID_BANDO) AS BI ON B.ID_BANDO = BI.ID_BANDO
	LEFT JOIN vATTO A ON BI.ID_ATTO = A.ID_ATTO
	--LEFT JOIN BANDO_CONFIG BC  on (B.ID_BANDO = BC.ID_BANDO)
	WHERE P.ID_PROGETTO = @ID_PROGETTO AND ((PS.COD_STATO = 'P' AND @STATO = 'P') OR (PS.COD_STATO = 'L')) --AND BC.TIPO_CONFIG = 'StrutturaNome' 
