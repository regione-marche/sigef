CREATE PROCEDURE [dbo].[ZVldCheckListStepUpdate]
(
	@IdVldCheckList INT, 
	@IdVldStep INT, 
	@Obbligatorio BIT, 
	@IncludiVerbaleVis BIT
)
AS
	UPDATE VLD_CHECK_LIST_STEP
	SET
		OBBLIGATORIO = @Obbligatorio, 
		INCLUDI_VERBALE_VIS = @IncludiVerbaleVis
	WHERE 
		(ID_VLD_CHECK_LIST = @IdVldCheckList) AND 
		(ID_VLD_STEP = @IdVldStep)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVldCheckListStepUpdate';

