CREATE FUNCTION [dbo].[ConvertNumberToDigit_Unita]
(
	@INDICE INT
)
RETURNS VARCHAR(15)
AS
BEGIN		
	RETURN CASE WHEN @INDICE=1 THEN 'uno'
				WHEN @INDICE=2 THEN 'due'
				WHEN @INDICE=3 THEN 'tre'
				WHEN @INDICE=4 THEN 'quattro'
				WHEN @INDICE=5 THEN 'cinque'
				WHEN @INDICE=6 THEN 'sei'
				WHEN @INDICE=7 THEN 'sette'
				WHEN @INDICE=8 THEN 'otto'
				WHEN @INDICE=9 THEN 'nove'
				WHEN @INDICE=10 THEN 'dieci'
				WHEN @INDICE=11 THEN 'undici'
				WHEN @INDICE=12 THEN 'dodici'
				WHEN @INDICE=13 THEN 'tredici'
				WHEN @INDICE=14 THEN 'quattordici'
				WHEN @INDICE=15 THEN 'quindici'
				WHEN @INDICE=16 THEN 'sedici'
				WHEN @INDICE=17 THEN 'diciassette'
				WHEN @INDICE=18 THEN 'diciotto'
				WHEN @INDICE=19 THEN 'diciannove'
				ELSE '' END
END
