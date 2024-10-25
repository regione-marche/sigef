CREATE PROCEDURE [dbo].[ZImpresaSociInsert]
(
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
	SET @Attivo = ISNULL(@Attivo,((0)))
	INSERT INTO IMPRESA_SOCI
	(
		ID_IMPRESA, 
		ID_SOCIO, 
		ATTIVO, 
		DATA_INIZIO_VALIDITA, 
		DATA_FINE_VALIDITA, 
		ID_OPERATORE_INIZIO, 
		ID_OPERATORE_FINE, 
		COD_TIPO_SOCIO
	)
	VALUES
	(
		@IdImpresa, 
		@IdSocio, 
		@Attivo, 
		@DataInizioValidita, 
		@DataFineValidita, 
		@IdOperatoreInizio, 
		@IdOperatoreFine, 
		@CodTipoSocio
	)
	SELECT SCOPE_IDENTITY() AS ID, @Attivo AS ATTIVO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaSociInsert';

