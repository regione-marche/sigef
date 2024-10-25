CREATE PROCEDURE [dbo].[ZVldCheckListStepInsert]
(
	@IdVldCheckList INT, 
	@IdVldStep INT, 
	@Obbligatorio BIT, 
	@IncludiVerbaleVis BIT
)
AS
	SET @Obbligatorio = ISNULL(@Obbligatorio,((0)))
	SET @IncludiVerbaleVis = ISNULL(@IncludiVerbaleVis,((0)))
	INSERT INTO VLD_CHECK_LIST_STEP
	(
		ID_VLD_CHECK_LIST, 
		ID_VLD_STEP, 
		OBBLIGATORIO, 
		INCLUDI_VERBALE_VIS
	)
	VALUES
	(
		@IdVldCheckList, 
		@IdVldStep, 
		@Obbligatorio, 
		@IncludiVerbaleVis
	)
	SELECT @Obbligatorio AS OBBLIGATORIO, @IncludiVerbaleVis AS INCLUDI_VERBALE_VIS


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVldCheckListStepInsert';

