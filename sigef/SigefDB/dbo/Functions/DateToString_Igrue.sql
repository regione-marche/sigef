
CREATE FUNCTION [dbo].[DateToString_Igrue] (@Data DATETIME)  
RETURNS VARCHAR(10) AS  
BEGIN 
IF @DATA IS NULL
  RETURN ''
DECLARE @Giorno VARCHAR(2)
SET @Giorno=CAST(DAY(@DATA) AS VARCHAR(2))
IF LEN(@Giorno)=1
  SET @Giorno='0'+@Giorno
DECLARE @Mese VARCHAR(2)
SET @Mese=CAST(MONTH(@DATA) AS VARCHAR(2))
IF LEN(@Mese)=1
  SET @Mese='0'+@Mese
RETURN @Giorno+'/'+@Mese+'/'+CAST(YEAR(@DATA) AS VARCHAR(4))
RETURN ''
END
