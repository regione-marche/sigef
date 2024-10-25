CREATE PROCEDURE [dbo].[ZBancheIstitutiGetById]
(
	@Abi VARCHAR(255)
)
AS
	SELECT *
	FROM BANCHE_ISTITUTI
	WHERE 
		(ABI = @Abi)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBancheIstitutiGetById';

