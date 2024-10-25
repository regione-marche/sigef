CREATE PROCEDURE [dbo].[ZBancheIstitutiDelete]
(
	@Abi VARCHAR(255)
)
AS
	DELETE BANCHE_ISTITUTI
	WHERE 
		(ABI = @Abi)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBancheIstitutiDelete';

