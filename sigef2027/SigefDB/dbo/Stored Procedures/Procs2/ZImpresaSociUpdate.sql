CREATE PROCEDURE [dbo].[ZImpresaSociUpdate]
(
	@Id INT, 
	@IdImpresa INT, 
	@IdSocio INT, 
	@Attivo BIT, 
	@DataInizioValidita DATETIME, 
	@DataFineValidita DATETIME, 
	@IdOperatoreInizio INT, 
	@IdOperatoreFine INT, 
	@CodTipoSocio VARCHAR(255)
)
AS
	UPDATE IMPRESA_SOCI
	SET
		ID_IMPRESA = @IdImpresa, 
		ID_SOCIO = @IdSocio, 
		ATTIVO = @Attivo, 
		DATA_INIZIO_VALIDITA = @DataInizioValidita, 
		DATA_FINE_VALIDITA = @DataFineValidita, 
		ID_OPERATORE_INIZIO = @IdOperatoreInizio, 
		ID_OPERATORE_FINE = @IdOperatoreFine, 
		COD_TIPO_SOCIO = @CodTipoSocio
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaSociUpdate';

