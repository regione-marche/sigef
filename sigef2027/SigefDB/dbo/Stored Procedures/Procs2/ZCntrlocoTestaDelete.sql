CREATE PROCEDURE [dbo].[ZCntrlocoTestaDelete]
(
	@Idloco INT
)
AS
	DELETE CntrLoco_Testa
	WHERE 
		(IdLoco = @Idloco)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCntrlocoTestaDelete]
(
	@Idloco INT
)
AS
	DELETE CntrLoco_Testa
	WHERE 
		(IdLoco = @Idloco)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCntrlocoTestaDelete';

