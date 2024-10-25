CREATE PROCEDURE [dbo].[ZNewsInsert]
(
	@Titolo VARCHAR(255), 
	@Testo NVARCHAR(max), 
	@Url VARCHAR(255), 
	@Data DATETIME, 
	@Operatore VARCHAR(16), 
	@InterruzioneSistema BIT, 
	@DataInizio DATETIME, 
	@DataFine DATETIME
)
AS
	INSERT INTO NEWS
	(
		TITOLO, 
		TESTO, 
		URL, 
		DATA, 
		OPERATORE, 
		INTERRUZIONE_SISTEMA, 
		DATA_INIZIO, 
		DATA_FINE
	)
	VALUES
	(
		@Titolo, 
		@Testo, 
		@Url, 
		@Data, 
		@Operatore, 
		@InterruzioneSistema, 
		@DataInizio, 
		@DataFine
	)
	SELECT SCOPE_IDENTITY() AS ID_NEWS

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZNewsInsert]
(
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
	INSERT INTO NEWS
	(
		TITOLO, 
		TESTO, 
		URL, 
		DATA, 
		OPERATORE, 
		INTERRUZIONE_SISTEMA, 
		DATA_INIZIO, 
		DATA_FINE
	)
	VALUES
	(
		@Titolo, 
		@Testo, 
		@Url, 
		@Data, 
		@Operatore, 
		@InterruzioneSistema, 
		@DataInizio, 
		@DataFine
	)
	SELECT SCOPE_IDENTITY() AS ID_NEWS

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZNewsInsert';

