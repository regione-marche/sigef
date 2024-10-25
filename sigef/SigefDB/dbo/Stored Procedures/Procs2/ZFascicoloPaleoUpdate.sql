CREATE PROCEDURE [dbo].[ZFascicoloPaleoUpdate]
(
	@Id INT, 
	@Anno INT, 
	@CodTipo VARCHAR(255), 
	@Fascicolo VARCHAR(255), 
	@Provincia VARCHAR(255), 
	@CodEnte VARCHAR(255), 
	@Attivo BIT, 
	@DataInizioValidita DATETIME, 
	@DataFineValidita DATETIME, 
	@Note VARCHAR(1000)
)
AS
	UPDATE FASCICOLO_PALEO
	SET
		ANNO = @Anno, 
		COD_TIPO = @CodTipo, 
		FASCICOLO = @Fascicolo, 
		PROVINCIA = @Provincia, 
		COD_ENTE = @CodEnte, 
		ATTIVO = @Attivo, 
		DATA_INIZIO_VALIDITA = @DataInizioValidita, 
		DATA_FINE_VALIDITA = @DataFineValidita, 
		NOTE = @Note
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFascicoloPaleoUpdate';

