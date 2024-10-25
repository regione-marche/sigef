CREATE PROCEDURE [dbo].[calcoloPrioritaVariante112_4]
(
     @ID_VARIANTE INT,
	 @IdProgetto INT = NULL)
AS
--declare @ID_VARIANTE INT,
--  @IdProgetto INT  
--set @ID_VARIANTE = 1736
--set @IdProgetto = 5659

DECLARE @ID_PROG_CORRENTE_121 INT, @ID_PROG_INTEG_311 INT, @ID_PROG_INTEG_111 INT,@ID_PROG_INTEG_114 INT,
		@ID_BANDO_112 INT, @ID_BANDO_121 INT, @ID_BANDO_311 INT,@ID_BANDO_111 INT,@ID_BANDO_114 INT

SELECT DISTINCT @ID_PROG_CORRENTE_121 = p.ID_PROGETTO, @ID_BANDO_121=P.ID_BANDO FROM PROGETTO P
INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE = '1.2.1.'
WHERE ID_PROG_INTEGRATO = @IdProgetto

SELECT DISTINCT @ID_PROG_INTEG_311 = p.ID_PROGETTO , @ID_BANDO_311= P.ID_BANDO FROM PROGETTO P
INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE = '3.1.1.A'
WHERE ID_PROG_INTEGRATO = @IdProgetto

SELECT DISTINCT @ID_PROG_INTEG_111 = p.ID_PROGETTO , @ID_BANDO_111= P.ID_BANDO FROM PROGETTO P
INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE = '1.1.1.A'
WHERE ID_PROG_INTEGRATO = @IdProgetto

SELECT DISTINCT @ID_PROG_INTEG_114 = p.ID_PROGETTO , @ID_BANDO_114= P.ID_BANDO FROM PROGETTO P
INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE = '1.1.4.'
WHERE ID_PROG_INTEGRATO = @IdProgetto


---- CALCOLO PUNTEGGIO A - B - C
--A 121 - calcolo punteggio sulle priorità A-B-C 

DECLARE @IdSchedaValutazione int
DECLARE @PesoPrioritaA DECIMAL(10,2),@ValoreMAXPrioritaA DECIMAL(10,2),
		@PesoPrioritaB DECIMAL(10,2),@ValoreMAXPrioritaB DECIMAL(10,2),
		@PesoPrioritaC DECIMAL(10,2),@ValoreMAXPrioritaC DECIMAL(10,2),
		@PunteggioPrioritaA DECIMAL(10,6),@PunteggioPrioritaB DECIMAL(10,6), @PunteggioPrioritaC DECIMAL(10,6)

 
-- TROVO IL PROGETTO INTEGRATO
  
SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B WHERE ID_BANDO = @ID_BANDO_121 )
 
-- A: Investimenti relativi a tipologie indicate come priorità di settore
SET @PesoPrioritaA = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 22 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 22 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)

-- B: 121 - Investimenti di ammodernamento o ricostruzione con tecniche di risparmio energetico (escluso l`acquisto di macchine e attrezzature agricole)
SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 23 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 23 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)

-- C: 121 - investimenti realizzati per i settori prioritari ed in territori preferenziali
SET @PesoPrioritaC = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 112 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 112 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)

-----------------------------------------------------------------
-- CALCOLO PRIORITA'

-- 121 - Investimenti relativi a tipologie indicate come prioritarie dal PSR per i settori produttivi di cui al cap.5
EXEC @PunteggioPrioritaA = calcoloPrioritaVariante112_121_5  @ID_VARIANTE, @ID_PROG_CORRENTE_121 
-- 121 - Investimenti di ammodernamento o ricostruzione con tecniche di risparmio energetico (escluso l`acquisto di macchine e attrezzature agricole)
EXEC @PunteggioPrioritaB = calcoloPrioritaVariante112_121_6 @ID_VARIANTE, @ID_PROG_CORRENTE_121 
-- IF BANDO II SCADENZA E III SCADENZA
EXEC @PunteggioPrioritaC = calcoloPrioritaVariante112_121_8  @ID_VARIANTE, @ID_PROG_CORRENTE_121 
 
------------------ -------------------------------------------------

DECLARE @PUNTEGGIO_ABC DECIMAL (10,6)
SET @PUNTEGGIO_ABC = ((((@PunteggioPrioritaA/100) * @PesoPrioritaA) / @ValoreMAXPrioritaA)  
        + (((@PunteggioPrioritaB/100) * @PesoPrioritaB) / @ValoreMAXPrioritaB)  
        + (((@PunteggioPrioritaC/100) * @PesoPrioritaC) / @ValoreMAXPrioritaC))

-------------------------------------------------------------------

-- B Quota % degli investimenti per la misura 1.2.1. rispetto al totale della spesa strutturale

declare @COSTO_INVESTIMENTO_121  DECIMAL (10,2), @COSTO_INVESTIMENTO_311 DECIMAL (10,2)
set @COSTO_INVESTIMENTO_121= (SELECT ISNULL( SUM (COSTO_INVESTIMENTO),0) FROM PIANO_INVESTIMENTI PI 
								WHERE ID_PROGETTO=@ID_PROG_CORRENTE_121 AND COD_TIPO_INVESTIMENTO=1 AND PI.ID_VARIANTE = @ID_VARIANTE AND ISNULL(COD_VARIAZIONE,'x')!='A'  )

SET @COSTO_INVESTIMENTO_311 = (SELECT ISNULL(SUM (COSTO_INVESTIMENTO),0) FROM PIANO_INVESTIMENTI PI 
								WHERE id_progetto=@ID_PROG_INTEG_311 AND COD_TIPO_INVESTIMENTO=1 AND PI.ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x')!='A'  )

DECLARE @QUOTA DECIMAL (10,2)
IF (@COSTO_INVESTIMENTO_121 = 0) SET  @QUOTA = 0
ELSE SET @QUOTA = ((@COSTO_INVESTIMENTO_121) /(@COSTO_INVESTIMENTO_121 + @COSTO_INVESTIMENTO_311))
SET @PUNTEGGIO_ABC = isNull ((@PUNTEGGIO_ABC * @QUOTA),0)

--select @COSTO_INVESTIMENTO_121,@QUOTA
--------------------------------------------------------------------------------------------------------------

-- 311 - VERIFICA PUNTEGGIO MINIMO = 0,08 (CRITERI B-I-J-K)  
-- Presenza di investimenti finalizzabili con la misura 3.1.1

SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B where b.ID_BANDO =@ID_BANDO_311 )

-- Priorità B (112 - 311 - investimenti destinati a migliorare i servizi agrituristici delle aziende) ID: 104

DECLARE @PesoPrioritaB_311 DECIMAL(10,2),@ValoreMAXPrioritaB_311 DECIMAL(10,2)
DECLARE @ValorePrioritaB_311 DECIMAL(10,6), @PunteggioPrioritaB_311 DECIMAL(10,6)

SET @PesoPrioritaB_311 = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 104 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB_311 = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 104 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
EXEC @ValorePrioritaB_311 = calcoloPrioritaVariante112_311_2  @ID_VARIANTE, @ID_PROG_INTEG_311 
SET @PunteggioPrioritaB_311 = ((@ValorePrioritaB_311/100) * @PesoPrioritaB_311) / @ValoreMAXPrioritaB_311

-- Priorità I (112 - 311 - Investimenti strutturali realizzati con tecniche di bioedilizia) ID: 105
-- Priorità I ( Investimenti strutturali realizzati con tecniche di bioedilizia)  ID: 154  II SCADENZA

DECLARE @PesoPrioritaI DECIMAL(10,2)
DECLARE @ValoreMAXPrioritaI DECIMAL(10,2)
DECLARE @ValorePrioritaI DECIMAL(10,6)
DECLARE @PunteggioPrioritaI DECIMAL(10,6)

IF (@IdSchedaValutazione = 83 or  @IdSchedaValutazione  = 87 or  @IdSchedaValutazione  = 114) --SCHEDA VALUTAZIONE SECONDA SCADENZA e terza e quarta
BEGIN 
	SET @PesoPrioritaI = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 154 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
	SET @ValoreMAXPrioritaI = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 154 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
	EXEC @ValorePrioritaI = calcoloPrioritaVariante112_311_4  @ID_VARIANTE,  @ID_PROG_INTEG_311
	SET @PunteggioPrioritaI = ((@ValorePrioritaI/100) * @PesoPrioritaI) / @ValoreMAXPrioritaI
END
ELSE BEGIN
	SET @PesoPrioritaI = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 105 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
	SET @ValoreMAXPrioritaI = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 105 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
	SET @ValorePrioritaI = (SELECT VALORE = CASE WHEN COUNT(VP.PUNTEGGIO) > 0 THEN MAX(VP.PUNTEGGIO) ELSE 0 END 
								FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) 
								WHERE PP.ID_PRIORITA = 105 AND PP.ID_PROGETTO = @ID_PROG_INTEG_311)
	SET @PunteggioPrioritaI = (@ValorePrioritaI * @PesoPrioritaI) / @ValoreMAXPrioritaI

END

-- Priorità J (112 - 311 - investimenti con riqualificazione architettonica riguardanti tutto il patrimonio aziendale) ID: 106

DECLARE @PesoPrioritaJ DECIMAL(10,2),@ValoreMAXPrioritaJ DECIMAL(10,2)
DECLARE @ValorePrioritaJ DECIMAL(10,6),@PunteggioPrioritaJ DECIMAL(10,6)

SET @PesoPrioritaJ = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 106 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaJ = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 106 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaJ = (SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 106 AND ID_PROGETTO = @ID_PROG_INTEG_311)
SET @PunteggioPrioritaJ = (@ValorePrioritaJ * @PesoPrioritaJ) / @ValoreMAXPrioritaJ

-- Priorità K (311 - investimenti destinati all`utilizzo di fonti energetiche rinnovabili) ID: 107

DECLARE @PesoPrioritaK DECIMAL(10,2),@ValoreMAXPrioritaK DECIMAL(10,2)
DECLARE @ValorePrioritaK DECIMAL (10,6), @PunteggioPrioritaK DECIMAL (10,6)

SET @PesoPrioritaK = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 107 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaK = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 107 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaK = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 0.8 
                                                WHEN VP.CODICE = '2' THEN 1 
                                                WHEN VP.CODICE = '3' THEN 0.4 
                                                WHEN VP.CODICE = '4' THEN 0.6 
                                                ELSE 0 END 
                                           FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) 
                                           WHERE PP.ID_PROGETTO = @ID_PROG_INTEG_311 AND PP.ID_PRIORITA = 107)

SET @PunteggioPrioritaK = (@ValorePrioritaK * @PesoPrioritaK) / @ValoreMAXPrioritaK

DECLARE @PUNTEGGIO_311 DECIMAL(10,6)
SET @PUNTEGGIO_311 = ( ISNULL(@PunteggioPrioritaB_311,0) 
				   + ISNULL(@PunteggioPrioritaI,0) 
				   + ISNULL(@PunteggioPrioritaJ,0) 
				   + ISNULL(@PunteggioPrioritaK,0))

DECLARE @PUNTEGGIO_BIJK DECIMAL(10,2)
IF(@PUNTEGGIO_311 >= 0.08 ) SET @PUNTEGGIO_BIJK= 0.15  
ELSE SET @PUNTEGGIO_BIJK =0

--  111 -  formazione non obbligatoria  
 
-- BANDO III SCADENZA ID_CODIFICA = 311
-- modifica 24/06/2010 ---> codifica bando tipologia 04

DECLARE @PUNTEGGIO_111 DECIMAL(10,2) 

SET @PUNTEGGIO_111 =(SELECT 'PUNTEGGIO'= 
						CASE WHEN COUNT(*) >0 THEN 0.10 ELSE 0 END 
					FROM PROGETTO P INNER JOIN 
						PIANO_INVESTIMENTI PI ON P.ID_PROGETTO = PI.ID_PROGETTO 
					WHERE P.ID_PROGETTO =@ID_PROG_INTEG_111 AND ((ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO FROM CODIFICA_INVESTIMENTO 
																								WHERE ID_BANDO IN (110,139) AND DESCRIZIONE LIKE '04%')) OR 
																								(ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO 
																															  FROM CODIFICA_INVESTIMENTO WHERE ID_BANDO IN (139) AND CODICE ='2')) ) AND
						  PI.COSTO_INVESTIMENTO >0 AND   ID_VARIANTE  = @ID_VARIANTE AND  ISNULL(COD_VARIAZIONE,'X')!='A'
   )

--- 114 richiesta di consulenza 
DECLARE @PUNTEGGIO_114 DECIMAL (10,2)
set @PUNTEGGIO_114 = (SELECT  'Punteggio'= 
						case  when COUNT(*) >0 THEN 0.10 
							  else 0 END 
						FROM PROGETTO P INNER JOIN Piano_Investimenti PI on P.Id_Progetto = PI.Id_Progetto 
						WHERE P.ID_PROGETTO=@ID_PROG_INTEG_114 AND
							 PI.COSTO_INVESTIMENTO >0 AND   ID_VARIANTE  = @ID_VARIANTE AND  isnull(COD_VARIAZIONE,'x')!='A'   )

---- punteggio TOTALE Priorita BUSINESSPLAN
DECLARE @PUNTEGGIO112_TOTALE DECIMAL(10,6)
SET @PUNTEGGIO112_TOTALE = (isnull( @PUNTEGGIO_ABC,0) + isnull(@PUNTEGGIO_BIJK,0) +  isnull (@PUNTEGGIO_111,0) +isnull( @PUNTEGGIO_114,0)) 

return @PUNTEGGIO112_TOTALE * 100
