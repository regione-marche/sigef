CREATE PROCEDURE [dbo].[ZCheckListXStepUpdate]
(
	@IdStep INT, 
	@Ordine INT, 
	@Obbligatorio BIT, 
	@Peso DECIMAL(10,2), 
	@IdCheckList INT, 
	@IncludiVerbaleVis BIT
)
AS
	UPDATE CHECK_LIST_X_STEP
	SET
		ORDINE = @Ordine, 
		OBBLIGATORIO = @Obbligatorio, 
		PESO = @Peso, 
		INCLUDI_VERBALE_VIS = @IncludiVerbaleVis
	WHERE 
		(ID_STEP = @IdStep) AND 
		(ID_CHECK_LIST = @IdCheckList)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCheckListXStepUpdate]
(
	@IdStep INT, 
	@Ordine INT, 
	@Obbligatorio BIT, 
	@Peso DECIMAL(10,2), 
	@IdCheckList INT
)
AS
	UPDATE CHECK_LIST_X_STEP
	SET
		ORDINE = @Ordine, 
		OBBLIGATORIO = @Obbligatorio, 
		PESO = @Peso
	WHERE 
		(ID_STEP = @IdStep) AND 
		(ID_CHECK_LIST = @IdCheckList)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCheckListXStepUpdate';

