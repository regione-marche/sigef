CREATE PROCEDURE [dbo].[ZPartecipanteRuoloDelete]
(
	@IdPartcipanteRuolo INT
)
AS
	DELETE PARTECIPANTE_RUOLO
	WHERE 
		(ID_PARTCIPANTE_RUOLO = @IdPartcipanteRuolo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPartecipanteRuoloDelete';

