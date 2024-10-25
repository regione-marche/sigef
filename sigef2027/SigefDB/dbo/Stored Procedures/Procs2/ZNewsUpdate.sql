CREATE PROCEDURE [dbo].[ZNewsUpdate]
(
	@IdNews INT, 
	@Titolo VARCHAR(255), 
	@Testo NVARCHAR(MAX), 
	@Url VARCHAR(255), 
	@Data DATETIME, 
	@Operatore VARCHAR(16), 
	@InterruzioneSistema BIT, 
	@DataInizio DATETIME, 
	@DataFine DATETIME
)
AS
	UPDATE NEWS
	SET
		TITOLO = @Titolo, 
		TESTO = @Testo, 
		URL = @Url, 
		DATA = @Data, 
		OPERATORE = @Operatore, 
		INTERRUZIONE_SISTEMA = @InterruzioneSistema, 
		DATA_INIZIO = @DataInizio, 
		DATA_FINE = @DataFine
	WHERE 
		(ID_NEWS = @IdNews)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZNewsUpdate]
(
	@IdNews INT, 
	@Titolo VARCHAR(255), 
	@Testo NTEXT, 
	@Url VARCHAR(255), 
	@Data DATETIME, 
	@Operatore VARCHAR(16), 
	@InterruzioneSistema BIT, 
	@DataInizio DATETIME, 
	@DataFine DATETIME
)
AS
	UPDATE NEWS
	SET
		TITOLO = @Titolo, 
		TESTO = @Testo, 
		URL = @Url, 
		DATA = @Data, 
		OPERATORE = @Operatore, 
		INTERRUZIONE_SISTEMA = @InterruzioneSistema, 
		DATA_INIZIO = @DataInizio, 
		DATA_FINE = @DataFine
	WHERE 
		(ID_NEWS = @IdNews)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZNewsUpdate';

