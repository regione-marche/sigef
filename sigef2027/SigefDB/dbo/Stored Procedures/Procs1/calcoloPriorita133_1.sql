CREATE PROCEDURE [dbo].[calcoloPriorita133_1]
	@IdProgetto int, 
	@fase_istruttoria bit=0,
	@IdVariante INT =NULL
AS
BEGIN
--1129   A - Vino (hl) certificato come DOC o DOCG prodotto dai soci (media delle produzioni dichiarate e certificate dall’organismo di controllo per le campagne vitivinicole 2009/2010 – 2010/2011 – 2011/2012.)

DECLARE @HL_vino decimal(10,2)
SELECT @HL_vino=VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA =1129
	
DECLARE @Punteggio decimal(10,2)

IF(@HL_vino = 0 )SET @Punteggio = 0
ELSE IF (@HL_vino > (263332 * 0.4)) SET @Punteggio = 1 
ELSE IF (@HL_vino > (263332 * 0.2)) SET @Punteggio = 0.5
ELSE SET @Punteggio = 0

SELECT @Punteggio AS PUNTEGGIO	

END
