CREATE PROCEDURE [dbo].[ZStepxbandoInsert]
(
	@IdBando INT, 
	@IdCheckList INT, 
	@CodFase CHAR(1)
)
AS
	INSERT INTO STEP_X_BANDO
	(
		ID_BANDO, 
		ID_CHECK_LIST, 
		COD_FASE
	)
	VALUES
	(
		@IdBando, 
		@IdCheckList, 
		@CodFase
	)
