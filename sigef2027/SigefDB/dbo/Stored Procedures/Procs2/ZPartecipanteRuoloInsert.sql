CREATE PROCEDURE [dbo].[ZPartecipanteRuoloInsert]
(
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
	INSERT INTO PARTECIPANTE_RUOLO
	(
		COD_FILIERA, 
		CUAA, 
		FLAG_PARTECIPANTE, 
		COD_RUOLO_SITRA, 
		COD_RUOLO_PARTECIPANTE, 
		OPERATORE_INSERIMENTO, 
		DATA_MODIFICA, 
		ID_PROGETTO_PIF, 
		COD_SISTEMA_QUALITA
	)
	VALUES
	(
		@CodFiliera, 
		@Cuaa, 
		@FlagPartecipante, 
		@CodRuoloSitra, 
		@CodRuoloPartecipante, 
		@OperatoreInserimento, 
		@DataModifica, 
		@IdProgettoPif, 
		@CodSistemaQualita
	)
	SELECT SCOPE_IDENTITY() AS ID_PARTCIPANTE_RUOLO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPartecipanteRuoloInsert';

