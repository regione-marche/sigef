﻿CREATE  PROCEDURE [dbo].[calcoloStep311_B_14]
@IdProgetto int , @FASE_ISTRUTTORIA INT =0
AS
BEGIN


-- 311 B  AZIONE D - 2013 - controllo selezione corretta dei requisiti

DECLARE @Result int , @C INT, @C_FO INT , @C_AM INT,@C_P INT, @ID_BANDO INT , @C_FOTOV INT
SET @Result = 1 -- Impongo lo Step  verificato
 
--- obbligo selezione delle priorita  1271-- conto energia / 1189 ritiro dedicato --BANDO 2014

SELECT @ID_BANDO = ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto
IF(@ID_BANDO =451) BEGIN 
		SELECT @C_FOTOV= COUNT(*)
		FROM vPIANO_INVESTIMENTI INV 
			LEFT JOIN PRIORITA_X_INVESTIMENTI PXI_RITIRO ON PXI_RITIRO.ID_INVESTIMENTO = INV.ID_INVESTIMENTO AND PXI_RITIRO.ID_PRIORITA = 1189
			LEFT JOIN PRIORITA_X_INVESTIMENTI PXI_CONTO ON PXI_CONTO.ID_INVESTIMENTO = INV.ID_INVESTIMENTO AND PXI_CONTO.ID_PRIORITA = 1271
		WHERE inv.CODICE IN ('FO') AND ID_PROGETTO=@IdProgetto AND (PXI_RITIRO.ID_PRIORITA IS NULL AND PXI_CONTO.ID_PRIORITA IS NULL)
			 AND((@FASE_ISTRUTTORIA =0 AND ID_INVESTIMENTO_ORIGINALE IS NULL)OR(@FASE_ISTRUTTORIA =1 AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))
		
		IF @C_FOTOV> 0 SET @Result =0
END
 
IF @Result =1 BEGIN  
	 -- priorita fotovoltaico
	SELECT @C=COUNT(*) FROM vPIANO_INVESTIMENTI INV 
		INNER JOIN PRIORITA_X_INVESTIMENTI PXI ON PXI.ID_INVESTIMENTO = INV.ID_INVESTIMENTO AND ID_PRIORITA = 1189
	WHERE inv.CODICE NOT IN ('FO') AND INV.ID_PROGETTO =@IdProgetto AND((@FASE_ISTRUTTORIA =0 AND ID_INVESTIMENTO_ORIGINALE IS NULL)OR(@FASE_ISTRUTTORIA =1 AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))
	IF(ISNULL(@C,0)>0) SET @Result =0 
	 
	 -- investimenti amianto
	SELECT @C_FO=COUNT(*) FROM vPIANO_INVESTIMENTI INV WHERE inv.CODICE IN ('FO' )AND INV.ID_PROGETTO =@IdProgetto AND((@FASE_ISTRUTTORIA =0 AND ID_INVESTIMENTO_ORIGINALE IS NULL)OR(@FASE_ISTRUTTORIA =1 AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))
	SELECT @C_AM=COUNT(*) FROM vPIANO_INVESTIMENTI INV WHERE inv.CODICE IN ('AM' )AND INV.ID_PROGETTO =@IdProgetto AND((@FASE_ISTRUTTORIA =0 AND ID_INVESTIMENTO_ORIGINALE IS NULL)OR(@FASE_ISTRUTTORIA =1 AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))
	IF (@C_FO =0 AND @C_AM >0) SET @Result =0 
	 
	 -- dichiarazione contributi pubblici precedenti 
	SELECT @C_P = COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 1183
	IF(ISNULL(@C_P,0) =0) SET @Result =0
END
select @Result 
END