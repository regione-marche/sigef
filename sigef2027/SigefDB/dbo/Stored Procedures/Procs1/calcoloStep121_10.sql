﻿CREATE PROCEDURE [dbo].[calcoloStep121_10]
@IdProgetto int
AS
BEGIN

-- 121 - bloccare bilancio
--declare @IdProgetto int = 11127 

DECLARE @Result int, @TOT_IMPIEGHI decimal(10,2),@TOT_FONTI_FINANZIAMENTO decimal(10,2),  
	    @REDDITO_OPERATIVO decimal(10,2), @REDDITO_NETTO_PAC decimal(10,2),
		@anno char(4), @ID_IMPRESA INT, @ID_BANDO INT

SET @Result = 1 -- Impongo lo Step VERIFICATO
select @ID_BANDO = ID_BANDO from PROGETTO where ID_PROGETTO =@idProgetto 

IF(SELECT COUNT (*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO=@IdProgetto AND ID_PRIORITA = 151 ) =0
BEGIN
	SELECT  @ID_IMPRESA = ID_IMPRESA FROM  PROGETTO WHERE PROGETTO.ID_PROGETTO =@IdProgetto  

IF (@ID_BANDO in( 370, 385)) SET @anno = 2012 -- BANDO LIGHT DELLA 121 
ELSE BEGIN
	SELECT @anno = YEAR(DATA), @ID_BANDO = ID_BANDO FROM PROGETTO P INNER JOIN  PROGETTO_STORICO S ON  P.ID_PROGETTO = S.ID_PROGETTO 
	WHERE P.ID_PROGETTO = @IdProgetto AND COD_STATO IN ('P','L') ORDER BY S.ID DESC 
	SET @anno = @anno-1 
END


IF((SELECT COUNT(*) from BILANCIO_AGRICOLO WHERE ID_IMPRESA = @ID_IMPRESA AND PREVISIONALE=0 AND  ANNO =@anno ) >0)
	BEGIN 
	SET @TOT_IMPIEGHI = (SELECT sum ( ISNULL(CF_CF_TERRENI,0) + ISNULL(CF_CF_IMPIANTI,0)+ ISNULL(CF_CF_PIANTAGIONI,0) + ISNULL(CF_CF_MIGLIORAMENTI,0) + 
											ISNULL(CF_CA_MACCHINE,0) + ISNULL(CF_CA_BESTIAME,0) + ISNULL(CF_IF_PARTECIPAZIONI,0) +   
							ISNULL( CC_DF_RIMANENZE,0) + ISNULL( CC_DF_ANTICIPAZIONI,0)+ ISNULL( CC_LD_CREDITI,0) + ISNULL( CC_LI_BANCA,0) +ISNULL(CC_LI_CASSA,0) ) 
							FROM BILANCIO_AGRICOLO WHERE ID_IMPRESA = @ID_IMPRESA AND PREVISIONALE=0 and ANNO =@anno )


	SET @TOT_FONTI_FINANZIAMENTO = (SELECT sum (ISNULL( FF_PC_DEBITI_BREVE_TERMINE,0) + ISNULL( FF_PC_FORNITORI,0) + ISNULL( FF_PC_DEBITI,0) 
									     + ISNULL( FF_PC_MUTUI,0)  + ISNULL( FF_MP_CAPITALE,0) +
					                     ISNULL( FF_MP_RISERVE,0) + ISNULL( FF_MP_UTILE,0) )  
					                     FROM BILANCIO_AGRICOLO WHERE ID_IMPRESA = @ID_IMPRESA AND PREVISIONALE=0 and  ANNO =@anno  )
		
	IF( @TOT_IMPIEGHI < 0 OR  @TOT_IMPIEGHI <> @TOT_FONTI_FINANZIAMENTO )
		SET @Result = 0
		ELSE 
			BEGIN
				 

			 	SET @REDDITO_OPERATIVO = ( SELECT SUM( ISNULL( PLV_RICAVI_NETTI,0) + ISNULL( PLV_RICAVI_ATTIVITA,0) + ISNULL( PLV_RIMANENZE_FINALI,0) - ISNULL( PLV_RIMANENZE_INIZIALI,0) - ISNULL( VA_COSTI_MAT_PRIME,0) -
								ISNULL( VA_COSTI_ATT_CONNESSE,0) - ISNULL( VA_NOLEGGI,0) - ISNULL( VA_MANUTENZIONI,0) - ISNULL( VA_SPESE_GENERALI,0) - ISNULL( VA_AFFITTI,0) - ISNULL( VA_ALTRI_COSTI , 0) - ISNULL( PN_AMM_MACCHINE,0) - 
								ISNULL( PN_AMM_FABBRICATI,0)  - ISNULL( PN_AMM_PIANTAGIONI,0) - ISNULL( RO_SALARI,0) - ISNULL( RO_ONERI,0) )
								 FROM BILANCIO_AGRICOLO WHERE ID_IMPRESA = @ID_IMPRESA AND PREVISIONALE=0 and ANNO =@anno  )		
			 
				IF(@REDDITO_OPERATIVO)<>0
							BEGIN 
								 
						     SET @REDDITO_NETTO_PAC = @REDDITO_OPERATIVO + (SELECT  SUM ( ISNULL(RN_PAC_RICAVI,0) - ISNULL(RN_PAC_COSTI,0) + 
										ISNULL(RN_PAC_PROVENTI,0) - ISNULL(RN_PAC_PERDITE,0) + ISNULL(RN_PAC_INTERESSI_ATTIVI,0) -
										ISNULL(RN_PAC_INTERESSI_PASSIVI,0) - ISNULL(RN_PAC_IMPOSTE,0) + ISNULL(RN_PAC_CONTRIBUTI_PAC,0) )    
										 FROM BILANCIO_AGRICOLO WHERE ID_IMPRESA = @ID_IMPRESA AND PREVISIONALE=0 and ANNO =@anno )
								
									IF(@REDDITO_NETTO_PAC<0 )
												SET @Result = 0  
									ELSE 
										BEGIN
							
											IF(@REDDITO_NETTO_PAC<> (SELECT ISNULL(FF_MP_UTILE,0) 
															    	FROM BILANCIO_AGRICOLO WHERE ID_IMPRESA = @ID_IMPRESA AND PREVISIONALE=0 and  ANNO =@anno ) )SET @Result = 0			
										END			
							END
					ELSE 						
						SET @Result = 0
				END	
	END
	ELSE SET @Result = 0
END
SELECT @Result AS RESULT
END
