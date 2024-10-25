CREATE FUNCTION [dbo].[ConvertNumberToDigit_Decine]
(
	@INDICE INT
)
RETURNS VARCHAR(10)
AS
BEGIN 
	RETURN CASE WHEN @INDICE=2 THEN 'venti' 
				WHEN @INDICE=3 THEN 'trenta' 
				WHEN @INDICE=4 THEN 'quaranta'
				WHEN @INDICE=5 THEN 'cinquanta'
				WHEN @INDICE=6 THEN 'sessanta'
				WHEN @INDICE=7 THEN 'settanta'
				WHEN @INDICE=8 THEN 'ottanta'
				WHEN @INDICE=9 THEN 'novanta'
				ELSE '' END
END
