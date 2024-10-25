CREATE PROCEDURE [dbo].[calcoloStep133_15]
(
	@IdProgetto int,
	@FASE_ISTRUTTORIA INT =0
)
AS
BEGIN
--Verificato il rispetto del massimale di contributo previsto dal bando (1.100.000,00 euro/anno)
-- BUDGET PER IL 2013--> 825000 I 9/12 DI 1100000

DECLARE @RESULT INT, @contributo decimal(18,2)
		
--SET @IdProgetto = 9023
SET @RESULT =1 --PONGO LO STEP VERIFICATO

-- CONTROLLO L'ANNUALITA --> 1130
 
select @contributo= dbo.calcoloContributoTotaleProgetto (@IdProgetto,@FASE_ISTRUTTORIA, null)

if(@contributo >1400000) set @RESULT=0
 
SELECT @RESULT  
 
END
