--- Il cuaa non risulta finanziabile per alcun bando PSR 2007/2013 Marche - Misure strutturali (limitatamente alle risorse FEASR)
--- GAL FLAMINIO CESANO
CREATE PROCEDURE [dbo].[calcoloStep413_MONF_2]
@IdProgetto int,
@fase_istruttoria int =0
AS
BEGIN
--

DECLARE @Result int,
		@CONTA int, 
		@id_impresa INT

SET @Result = 1 -- Impongo lo Step  verificato

 SELECT @id_impresa = ID_IMPRESA FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto

SELECT @CONTA= (SELECT COUNT(*) FROM GRADUATORIA_PROGETTI GP INNER JOIN vPROGETTO VSP ON GP.ID_PROGETTO = VSP.ID_PROGETTO 
				WHERE VSP.ID_IMPRESA  = @id_impresa  and VSP.ORDINE_FASE >= 4 and VSP.ORDINE_FASE < 90 and VSP.COD_STATO != 'N')
  								   
IF(ISNULL(@CONTA, 0) >0)
	SET @Result=0
  ELSE 
	SET @Result=1

SELECT @Result AS RESULT
END
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
