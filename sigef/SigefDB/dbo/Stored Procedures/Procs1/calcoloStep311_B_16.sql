CREATE  PROCEDURE [dbo].[calcoloStep311_B_16]
@IdProgetto int , @FASE_ISTRUTTORIA INT =0
AS
BEGIN

-- 311 B  AZIONE D - 2013 - controllo selezione corretta dei requisiti
DECLARE @Result int , 
		@Contributo_prog decimal(18,2),
		@C_passato decimal(18,2)
SET @Result = 1 -- Impongo lo Step  verificato
 -- contributo nella priorita Aiuto in DE MINIMIS percepito nelle 3 annualità previste dal bando (in €) ID = 600

select @C_passato= valore from PRIORITA_X_PROGETTO  where ID_PROGETTO = @IdProgetto and ID_PRIORITA = 600
SET @Contributo_prog   = (SELECT DBO.calcoloContributoTotaleProgetto (@IdProgetto,@FASE_ISTRUTTORIA, NULL))
 
IF(ISNULL(@C_passato,0)+ISNULL(@Contributo_prog,0) > 200000 ) SET @Result=0 

select @Result 
END
