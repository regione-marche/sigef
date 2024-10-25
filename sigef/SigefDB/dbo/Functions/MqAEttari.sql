CREATE FUNCTION [dbo].[MqAEttari] 
(
	@mq INT 
)
RETURNS VARCHAR(20)
AS
BEGIN

  -- Restituisce una stringa contente il valore in ettari dato un int in metri quadri

DECLARE @ara VARCHAR(2), 
		@centiara VARCHAR(2),
		@ettaro VARCHAR(14),
        @stringamq VARCHAR(18),
		@lung INT,
		@risultato varchar(20)

SET @ara = '00'
SET @centiara = '00'
SET @ettaro = '00'

IF (@mq IS NULL)
	SET @risultato =  '00.00.00'

SET @stringamq = CAST (@mq as VARCHAR(18))
SET @lung = DATALENGTH(@stringamq)

IF (@lung >= 1)
	BEGIN
		begin
		if (@lung = 1)
			set @centiara = '0' + SUBSTRING (@stringamq, (@lung), (@lung))
		else
			SET @centiara = SUBSTRING (@stringamq, (@lung - 1), @lung)
		END

		IF (@lung >= 3)
			BEGIN
				if (@lung = 3)
					SET @ara ='0' +  SUBSTRING (@stringamq, (@lung - 2), (@lung - 2))
				ELSE 
					SET @ara = SUBSTRING (@stringamq, (@lung - 3), (@lung - 2))
			END

		IF (@lung > 4)
			SET @ettaro = SUBSTRING (@stringamq, 1, (@lung - 4))
			ELSE 
				SET @ettaro = '0'

	SET @risultato = @ettaro + '.' + @ara +'.'+ @centiara

	END
RETURN @risultato
END
