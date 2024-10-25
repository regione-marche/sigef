--- Rispettare le disposizioni in tema “deminimis” (limitatamente alle risorse FEASR)  - GAL FLAMINIO CESANO
CREATE PROCEDURE [dbo].[calcoloStep413_MONF_3]
@IdProgetto int,
@fase_istruttoria int =0
AS
BEGIN
--

DECLARE @Result int,
		@id_impresa varchar(16),
		@CONTRIBUTI decimal(18,2) , 
		@CONTRIBUTO_CORRENTE decimal(18,2),
		@CONTRIBUTO_TOTALE decimal(18,2)

SET @Result = 1 -- Impongo lo Step  verificato


SELECT @id_impresa = ID_IMPRESA FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto

SELECT @CONTRIBUTI= SUM(ISNULL(CONTRIBUTO_TOTALE,0)) FROM GRADUATORIA_PROGETTI GP INNER JOIN vPROGETTO VSP ON GP.ID_PROGETTO = VSP.ID_PROGETTO WHERE
VSP.ID_IMPRESA = @id_impresa and VSP.ORDINE_FASE >= 4 and VSP.ORDINE_FASE < 90 and VSP.COD_STATO != 'N'


SELECT @CONTRIBUTO_CORRENTE = SUM(ISNULL(CONTRIBUTO_RICHIESTO,0)) FROM PIANO_INVESTIMENTI WHERE
ID_PROGETTO = @IDPROGETTO AND 
(
(@FASE_ISTRUTTORIA= 0 AND ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NULL)OR
(@FASE_ISTRUTTORIA= 1 AND ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL)
)
		  								   
IF( (@CONTRIBUTO_CORRENTE + @CONTRIBUTI)> 200000)
	SET @Result=0
  ELSE 
	SET @Result=1

SELECT @Result
END
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
