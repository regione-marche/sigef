CREATE PROCEDURE [dbo].[ZVoceXChecklistGenericaDelete]
(
	@IdVoceXChecklistGenerica INT
)
AS
	DELETE VOCE_X_CHECKLIST_GENERICA
	WHERE 
		(ID_VOCE_X_CHECKLIST_GENERICA = @IdVoceXChecklistGenerica)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVoceXChecklistGenericaDelete';

