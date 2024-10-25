CREATE PROCEDURE [dbo].[ZPartecipantiXFilieraUpdate]
(
	@IdPartecipante INT, 
	@CodFiliera VARCHAR(10), 
	@Cuaa VARCHAR(16), 
	@IdProgettoValidato INT, 
	@CodRuoloSitra CHAR(3), 
	@Ammesso BIT, 
	@DataValidazione DATETIME, 
	@CfOperatore VARCHAR(16)
)
AS
	UPDATE PARTECIPANTI_X_FILIERA
	SET
		COD_FILIERA = @CodFiliera, 
		CUAA = @Cuaa, 
		ID_PROGETTO_VALIDATO = @IdProgettoValidato, 
		COD_RUOLO_SITRA = @CodRuoloSitra, 
		AMMESSO = @Ammesso, 
		DATA_VALIDAZIONE = @DataValidazione, 
		CF_OPERATORE = @CfOperatore
	WHERE 
		(ID_PARTECIPANTE = @IdPartecipante)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZPartecipantiXFilieraUpdate]
(
	@IdPartecipante INT, 
	@CodFiliera VARCHAR(5), 
	@Cuaa VARCHAR(16), 
	@IdProgettoValidato INT, 
	@Ammesso BIT, 
	@DataValidazione DATETIME, 
	@CfOperatore VARCHAR(16)
)
AS
	UPDATE PARTECIPANTI_X_FILIERA
	SET
		COD_FILIERA = @CodFiliera, 
		CUAA = @Cuaa, 
		ID_PROGETTO_VALIDATO = @IdProgettoValidato, 
		AMMESSO = @Ammesso, 
		DATA_VALIDAZIONE = @DataValidazione, 
		CF_OPERATORE = @CfOperatore
	WHERE 
		(ID_PARTECIPANTE = @IdPartecipante)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPartecipantiXFilieraUpdate';

