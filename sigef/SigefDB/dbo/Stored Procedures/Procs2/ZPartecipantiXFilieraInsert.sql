CREATE PROCEDURE [dbo].[ZPartecipantiXFilieraInsert]
(
	@CodFiliera VARCHAR(10), 
	@Cuaa VARCHAR(16), 
	@IdProgettoValidato INT, 
	@CodRuoloSitra CHAR(3), 
	@Ammesso BIT, 
	@DataValidazione DATETIME, 
	@CfOperatore VARCHAR(16)
)
AS
	INSERT INTO PARTECIPANTI_X_FILIERA
	(
		COD_FILIERA, 
		CUAA, 
		ID_PROGETTO_VALIDATO, 
		COD_RUOLO_SITRA, 
		AMMESSO, 
		DATA_VALIDAZIONE, 
		CF_OPERATORE
	)
	VALUES
	(
		@CodFiliera, 
		@Cuaa, 
		@IdProgettoValidato, 
		@CodRuoloSitra, 
		@Ammesso, 
		@DataValidazione, 
		@CfOperatore
	)
	SELECT SCOPE_IDENTITY() AS ID_PARTECIPANTE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZPartecipantiXFilieraInsert]
(
	@CodFiliera VARCHAR(5), 
	@Cuaa VARCHAR(16), 
	@IdProgettoValidato INT, 
	@Ammesso BIT, 
	@DataValidazione DATETIME, 
	@CfOperatore VARCHAR(16)
)
AS
	INSERT INTO PARTECIPANTI_X_FILIERA
	(
		COD_FILIERA, 
		CUAA, 
		ID_PROGETTO_VALIDATO, 
		AMMESSO, 
		DATA_VALIDAZIONE, 
		CF_OPERATORE
	)
	VALUES
	(
		@CodFiliera, 
		@Cuaa, 
		@IdProgettoValidato, 
		@Ammesso, 
		@DataValidazione, 
		@CfOperatore
	)
	SELECT SCOPE_IDENTITY() AS ID_PARTECIPANTE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPartecipantiXFilieraInsert';

