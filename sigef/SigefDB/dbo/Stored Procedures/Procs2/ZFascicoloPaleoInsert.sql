CREATE PROCEDURE [dbo].[ZFascicoloPaleoInsert]
(
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
	SET @Attivo = ISNULL(@Attivo,((0)))
	INSERT INTO FASCICOLO_PALEO
	(
		ANNO, 
		COD_TIPO, 
		FASCICOLO, 
		PROVINCIA, 
		COD_ENTE, 
		ATTIVO, 
		DATA_INIZIO_VALIDITA, 
		DATA_FINE_VALIDITA, 
		NOTE
	)
	VALUES
	(
		@Anno, 
		@CodTipo, 
		@Fascicolo, 
		@Provincia, 
		@CodEnte, 
		@Attivo, 
		@DataInizioValidita, 
		@DataFineValidita, 
		@Note
	)
	SELECT SCOPE_IDENTITY() AS ID, @Attivo AS ATTIVO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFascicoloPaleoInsert';

