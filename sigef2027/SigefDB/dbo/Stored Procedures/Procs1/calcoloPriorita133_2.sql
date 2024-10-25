CREATE PROCEDURE [dbo].[calcoloPriorita133_2]
	@IdProgetto int, 
	@fase_istruttoria bit=0,
	@IdVariante INT =NULL
AS
BEGIN
--1128   C.	Percentuale di produzione di uva rivendicata come DOC/DOCG rappresentata sulla produzione totale regionale rivendicata
-- MEDIA 244535 

DECLARE @KG_vino decimal(10,2)
SELECT @KG_vino=VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA =1128
	
DECLARE @Punteggio decimal(10,2)

IF(@KG_vino = 0 )SET @Punteggio = 0
ELSE IF (@KG_vino > (586030 * 0.4)) SET @Punteggio = 1 
ELSE IF (@KG_vino > (586030 * 0.2)) SET @Punteggio = 0.5
ELSE SET @Punteggio = 0

SELECT @Punteggio AS PUNTEGGIO	

END
