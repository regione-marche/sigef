CREATE PROCEDURE [dbo].[ZPartecipanteRuoloGetById]
(
	@IdPartcipanteRuolo INT
)
AS
	SELECT *
	FROM vPARTECIPANTE_RUOLO
	WHERE 
		(ID_PARTCIPANTE_RUOLO = @IdPartcipanteRuolo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPartecipanteRuoloGetById';

