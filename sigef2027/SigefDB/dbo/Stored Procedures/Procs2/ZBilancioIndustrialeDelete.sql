CREATE PROCEDURE [dbo].[ZBilancioIndustrialeDelete]
(
	@IdBilancioIndustriale INT
)
AS
	DELETE BILANCIO_INDUSTRIALE
	WHERE 
		(ID_BILANCIO_INDUSTRIALE = @IdBilancioIndustriale)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBilancioIndustrialeDelete]
(
	@IdBilancioIndustriale INT
)
AS
	DELETE BILANCIO_INDUSTRIALE
	WHERE 
		(ID_BILANCIO_INDUSTRIALE = @IdBilancioIndustriale)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBilancioIndustrialeDelete';

