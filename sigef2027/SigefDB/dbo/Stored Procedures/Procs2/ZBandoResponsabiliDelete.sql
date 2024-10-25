CREATE PROCEDURE [dbo].[ZBandoResponsabiliDelete]
(
	@Id INT
)
AS
	DELETE BANDO_RESPONSABILI
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoResponsabiliDelete';

