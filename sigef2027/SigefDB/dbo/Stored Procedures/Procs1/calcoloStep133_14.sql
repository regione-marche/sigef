CREATE PROCEDURE [dbo].[calcoloStep133_14]
(
	@IdProgetto int 
)
AS
BEGIN
-- Verificato che il richiedente è un Consorzio volont. di tutela riconosciuto ai sensi dell’art.19 della Legge 164/92,che rappresenta almeno l’8% della produzione viticola regionale rivendicata come DOC/DOCG(media  campagne 2010/2011, 2011/2012 e 2012/2013)
-- 1235 C - Uva (100KG) rivendicata come DOC/DOCG prodotta dai soci (media produzioni dichiarate per le campagne vitivinicole 20010/2011 – 2011/2012 – 2012/2013.)
-- 1128 C - Uva (100KG) rivendicata come DOC/DOCG prodotta dai soci (media produzioni dichiarate per le campagne vitivinicole 2009/2010 – 2010/2011 – 2011/2012.)

DECLARE @KG_vino_1128 decimal(10,2),@KG_vino_1235 decimal(10,2)
SELECT @KG_vino_1235=VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 1235
SELECT @KG_vino_1128=VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 1128
DECLARE @PERCENTUALE decimal(10,2)

IF(@KG_vino_1235 IS NULL ) BEGIN SET @PERCENTUALE = ISNULL(@KG_vino_1128,0)*100 / 586030  END
ELSE BEGIN  SET @PERCENTUALE = ISNULL(@KG_vino_1235,0)*100 / 542436 END 

SELECT @PERCENTUALE AS RESULT	

END
