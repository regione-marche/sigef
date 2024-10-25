
CREATE PROCEDURE [dbo].[ZBilancioIndustrialeGetById]
(
	@IdBilancioIndustriale INT
)
AS
	SELECT *
	FROM BILANCIO_INDUSTRIALE
	WHERE 
		(ID_BILANCIO_INDUSTRIALE = @IdBilancioIndustriale)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBilancioIndustrialeGetById]
(
	@IdBilancioIndustriale INT
)
AS
	SELECT *
	FROM BILANCIO_INDUSTRIALE
	WHERE 
		(ID_BILANCIO_INDUSTRIALE = @IdBilancioIndustriale)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBilancioIndustrialeGetById';

