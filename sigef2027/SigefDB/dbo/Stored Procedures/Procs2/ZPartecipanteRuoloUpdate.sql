CREATE PROCEDURE [dbo].[ZPartecipanteRuoloUpdate]
(
	@IdPartcipanteRuolo INT, 
	@CodFiliera VARCHAR(10), 
	@Cuaa VARCHAR(16), 
	@FlagPartecipante BIT, 
	@CodRuoloSitra CHAR(3), 
	@CodRuoloPartecipante CHAR(1), 
	@OperatoreInserimento VARCHAR(16), 
	@DataModifica DATETIME, 
	@IdProgettoPif INT, 
	@CodSistemaQualita CHAR(1)
)
AS
 
	UPDATE PARTECIPANTE_RUOLO
	SET
 
		COD_FILIERA = @CodFiliera, 
		CUAA = @Cuaa, 
		FLAG_PARTECIPANTE = @FlagPartecipante, 
		COD_RUOLO_SITRA = @CodRuoloSitra, 
		COD_RUOLO_PARTECIPANTE = @CodRuoloPartecipante, 
		OPERATORE_INSERIMENTO = @OperatoreInserimento, 
		DATA_MODIFICA = @DataModifica, 
		ID_PROGETTO_PIF = @IdProgettoPif, 
		COD_SISTEMA_QUALITA = @CodSistemaQualita
	WHERE 
		(ID_PARTCIPANTE_RUOLO = @IdPartcipanteRuolo)  
	SELECT @DataModifica;

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPartecipanteRuoloUpdate';

