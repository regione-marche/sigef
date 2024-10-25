CREATE PROCEDURE [dbo].[ZCheckListXStepInsert]
(
	@IdStep INT, 
	@Ordine INT, 
	@Obbligatorio BIT, 
	@Peso DECIMAL(10,2), 
	@IdCheckList INT, 
	@IncludiVerbaleVis BIT
)
AS
	SET @Obbligatorio = ISNULL(@Obbligatorio,((0)))
	SET @IncludiVerbaleVis = ISNULL(@IncludiVerbaleVis,((0)))
	INSERT INTO CHECK_LIST_X_STEP
	(
		ID_STEP, 
		ORDINE, 
		OBBLIGATORIO, 
		PESO, 
		ID_CHECK_LIST, 
		INCLUDI_VERBALE_VIS
	)
	VALUES
	(
		@IdStep, 
		@Ordine, 
		@Obbligatorio, 
		@Peso, 
		@IdCheckList, 
		@IncludiVerbaleVis
	)
SELECT @Obbligatorio AS OBBLIGATORIO, @IncludiVerbaleVis AS INCLUDI_VERBALE_VIS

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCheckListXStepInsert]
(
	@IdStep INT, 
	@Ordine INT, 
	@Obbligatorio BIT, 
	@Peso DECIMAL(10,2), 
	@IdCheckList INT
)
AS
	INSERT INTO CHECK_LIST_X_STEP
	(
		ID_STEP, 
		ORDINE, 
		OBBLIGATORIO, 
		PESO, 
		ID_CHECK_LIST
	)
	VALUES
	(
		@IdStep, 
		@Ordine, 
		@Obbligatorio, 
		@Peso, 
		@IdCheckList
	)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCheckListXStepInsert';

