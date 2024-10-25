CREATE PROCEDURE [dbo].[ZBandoValutatoriGetById]
(
	@IdValutatore INT
)
AS
	SELECT *
	FROM vBANDO_VALUTATORI
	WHERE 
		(ID_VALUTATORE = @IdValutatore)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZBandoValutatoriGetById]
(
	@IdValutatore INT
)
AS
	SELECT *
	FROM BANDO_VALUTATORI
	WHERE 
		(ID_VALUTATORE = @IdValutatore)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoValutatoriGetById';

