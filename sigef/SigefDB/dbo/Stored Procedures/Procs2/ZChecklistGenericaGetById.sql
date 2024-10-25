CREATE PROCEDURE [dbo].[ZChecklistGenericaGetById]
(
	@IdChecklistGenerica INT
)
AS
	SELECT *
	FROM VCHECKLIST_GENERICA
	WHERE 
		(ID_CHECKLIST_GENERICA = @IdChecklistGenerica)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZChecklistGenericaGetById';

