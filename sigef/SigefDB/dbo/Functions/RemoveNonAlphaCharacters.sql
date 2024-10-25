CREATE FUNCTION [dbo].[RemoveNonAlphaCharacters](@STR VARCHAR(1000))
RETURNS VARCHAR(1000)
AS
BEGIN
    DECLARE @CHARS as VARCHAR(50)
    SET @CHARS = '%[^a-z]%'
	--SET @CHARS = '%[^a-z - '']%'
    WHILE PATINDEX(@CHARS, @STR) > 0
        SET @STR = STUFF(@STR, PATINDEX(@CHARS, @STR), 1, '')
    RETURN @STR
END
