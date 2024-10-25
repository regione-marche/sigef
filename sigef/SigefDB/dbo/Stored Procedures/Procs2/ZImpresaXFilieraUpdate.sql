CREATE PROCEDURE [dbo].[ZImpresaXFilieraUpdate]
(
	@IdImpresaXFiliera INT, 
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
	UPDATE IMPRESA_X_FILIERA
	SET
		ID_FILIERA = @IdFiliera, 
		CUAA = @Cuaa, 
		FLAG_PARTECIPANTE = @FlagPartecipante, 
		COD_RUOLO_SITRA = @CodRuoloSitra, 
		COD_RUOLO_PARTECIPANTE = @CodRuoloPartecipante, 
		QUANTITA = @Quantita, 
		UNITA_MISURA = @UnitaMisura, 
		SISTEMA_QUALITA = @SistemaQualita, 
		CODIFICA_INTERVENTI = @CodificaInterventi, 
		OPERATORE = @Operatore, 
		AMMESSO = @Ammesso, 
		ID_PROGRAMMAZIONE = @IdProgrammazione
	WHERE 
		(ID_IMPRESA_X_FILIERA = @IdImpresaXFiliera)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZImpresaXFilieraUpdate]
(
	@IdImpresaXFiliera INT, 
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
	UPDATE IMPRESA_X_FILIERA
	SET
		ID_FILIERA = @IdFiliera, 
		CUAA = @Cuaa, 
		FLAG_PARTECIPANTE = @FlagPartecipante, 
		COD_RUOLO_SITRA = @CodRuoloSitra, 
		COD_RUOLO_PARTECIPANTE = @CodRuoloPartecipante, 
		QUANTITA = @Quantita, 
		UNITA_MISURA = @UnitaMisura, 
		SISTEMA_QUALITA = @SistemaQualita, 
		ID_PSR = @IdPsr, 
		COD_MISURA = @CodMisura, 
		COD_OBIETTIVO = @CodObiettivo, 
		COD_ASSE = @CodAsse, 
		COD_SUBMISURA = @CodSubmisura, 
		CODIFICA_INTERVENTI = @CodificaInterventi, 
		OPERATORE = @Operatore, 
		AMMESSO = @Ammesso
	WHERE 
		(ID_IMPRESA_X_FILIERA = @IdImpresaXFiliera)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaXFilieraUpdate';

