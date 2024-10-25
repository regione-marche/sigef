CREATE PROCEDURE [dbo].[ZImpresaXFilieraInsert]
(
	@IdFiliera INT, 
	@Cuaa VARCHAR(255), 
	@FlagPartecipante BIT, 
	@CodRuoloSitra VARCHAR(255), 
	@CodRuoloPartecipante VARCHAR(255), 
	@Quantita DECIMAL(10,2), 
	@UnitaMisura INT, 
	@SistemaQualita VARCHAR(255), 
	@CodificaInterventi NTEXT, 
	@Operatore VARCHAR(255), 
	@Ammesso BIT, 
	@IdProgrammazione INT
)
AS
	INSERT INTO IMPRESA_X_FILIERA
	(
		ID_FILIERA, 
		CUAA, 
		FLAG_PARTECIPANTE, 
		COD_RUOLO_SITRA, 
		COD_RUOLO_PARTECIPANTE, 
		QUANTITA, 
		UNITA_MISURA, 
		SISTEMA_QUALITA, 
		CODIFICA_INTERVENTI, 
		OPERATORE, 
		AMMESSO, 
		ID_PROGRAMMAZIONE
	)
	VALUES
	(
		@IdFiliera, 
		@Cuaa, 
		@FlagPartecipante, 
		@CodRuoloSitra, 
		@CodRuoloPartecipante, 
		@Quantita, 
		@UnitaMisura, 
		@SistemaQualita, 
		@CodificaInterventi, 
		@Operatore, 
		@Ammesso, 
		@IdProgrammazione
	)
	SELECT SCOPE_IDENTITY() AS ID_IMPRESA_X_FILIERA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZImpresaXFilieraInsert]
(
	@IdFiliera INT, 
	@Cuaa VARCHAR(16), 
	@FlagPartecipante BIT, 
	@CodRuoloSitra CHAR(3), 
	@CodRuoloPartecipante CHAR(1), 
	@Quantita DECIMAL(10,2), 
	@UnitaMisura INT, 
	@SistemaQualita CHAR(1), 
	@IdPsr INT, 
	@CodMisura INT, 
	@CodObiettivo INT, 
	@CodAsse INT, 
	@CodSubmisura CHAR(1), 
	@CodificaInterventi NTEXT, 
	@Operatore VARCHAR(16), 
	@Ammesso BIT
)
AS
	INSERT INTO IMPRESA_X_FILIERA
	(
		ID_FILIERA, 
		CUAA, 
		FLAG_PARTECIPANTE, 
		COD_RUOLO_SITRA, 
		COD_RUOLO_PARTECIPANTE, 
		QUANTITA, 
		UNITA_MISURA, 
		SISTEMA_QUALITA, 
		ID_PSR, 
		COD_MISURA, 
		COD_OBIETTIVO, 
		COD_ASSE, 
		COD_SUBMISURA, 
		CODIFICA_INTERVENTI, 
		OPERATORE, 
		AMMESSO
	)
	VALUES
	(
		@IdFiliera, 
		@Cuaa, 
		@FlagPartecipante, 
		@CodRuoloSitra, 
		@CodRuoloPartecipante, 
		@Quantita, 
		@UnitaMisura, 
		@SistemaQualita, 
		@IdPsr, 
		@CodMisura, 
		@CodObiettivo, 
		@CodAsse, 
		@CodSubmisura, 
		@CodificaInterventi, 
		@Operatore, 
		@Ammesso
	)
	SELECT SCOPE_IDENTITY() AS ID_IMPRESA_X_FILIERA
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaXFilieraInsert';

