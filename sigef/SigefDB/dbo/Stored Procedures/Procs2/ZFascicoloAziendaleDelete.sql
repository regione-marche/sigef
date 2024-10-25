CREATE PROCEDURE [dbo].[ZFascicoloAziendaleDelete]
(
	@IdFascicolo INT
)
AS
	DELETE FASCICOLO_AZIENDALE
	WHERE 
		(ID_FASCICOLO = @IdFascicolo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZFascicoloAziendaleDelete]
(
	@IdFascicolo INT
)
AS
	DELETE FASCICOLO_AZIENDALE
	WHERE 
		(ID_FASCICOLO = @IdFascicolo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFascicoloAziendaleDelete';

