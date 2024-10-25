--- verifica selezione dichiarazioni facoltative alterne e rispettivo allegato collegato - gal Piceno
CREATE PROCEDURE [dbo].[calcoloStep4131_b_AP]
@IdProgetto int,
@fase_istruttoria int =0
AS
BEGIN
--

DECLARE @Result int,
		@DICHIARAZIONE_12 INT,
		@DICHIARAZIONE_25 INT,
		@ALLEGATO INT


SET @Result = 1 -- Impongo lo Step  verificato

SELECT @DICHIARAZIONE_12 =(SELECT COUNT(*) as conta_dichiarazioni12 FROM DICHIARAZIONI_X_PROGETTO WHERE ID_PROGETTO=@IdProgetto AND ID_DICHIARAZIONE IN (868))
SELECT @DICHIARAZIONE_25 =(SELECT COUNT(*) as conta_dichiarazioni25 FROM DICHIARAZIONI_X_PROGETTO WHERE ID_PROGETTO=@IdProgetto AND ID_DICHIARAZIONE IN (869))

--- allegato giustificativo presentaz + di 12 camere

SELECT @ALLEGATO =(SELECT COUNT(*) as conta_allegato From ALLEGATI_X_PROGETTO WHERE ID_PROGETTO=@IdProgetto AND ID_allegato IN (1134))
  								   
IF((@DICHIARAZIONE_25 = 1 and @ALLEGATO = 1) or (@DICHIARAZIONE_12 = 1 and @ALLEGATO = 0))
	SET @Result=1
  ELSE 
	SET @Result=0

SELECT @Result
END
