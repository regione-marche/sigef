CREATE PROCEDURE [dbo].[ZPersonaFisicaInsert]
(
	@Nome VARCHAR(255), 
	@Cognome VARCHAR(255), 
	@CodiceFiscale VARCHAR(255), 
	@Sesso VARCHAR(255), 
	@DataNascita DATETIME, 
	@IdCittadinanza INT, 
	@IdComuneNascita INT
)
AS
	INSERT INTO PERSONA_FISICA
	(
		NOME, 
		COGNOME, 
		CODICE_FISCALE, 
		SESSO, 
		DATA_NASCITA, 
		ID_CITTADINANZA, 
		ID_COMUNE_NASCITA
	)
	VALUES
	(
		@Nome, 
		@Cognome, 
		@CodiceFiscale, 
		@Sesso, 
		@DataNascita, 
		@IdCittadinanza, 
		@IdComuneNascita
	)
	SELECT SCOPE_IDENTITY() AS ID_PERSONA

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZPersonafisicaInsert]
(
	@NOME VARCHAR(255), 
	@COGNOME VARCHAR(255), 
	@CODICE_FISCALE VARCHAR(16), 
	@SESSO CHAR(1), 
	@DATA_NASCITA DATETIME, 
	@ID_CITTADINANZA INT, 
	@ID_COMUNE_NASCITA INT
)
AS
	INSERT INTO PERSONA_FISICA
	(
		NOME, 
		COGNOME, 
		CODICE_FISCALE, 
		SESSO, 
		DATA_NASCITA, 
		ID_CITTADINANZA, 
		ID_COMUNE_NASCITA
	)
	VALUES
	(
		@NOME, 
		@COGNOME, 
		@CODICE_FISCALE, 
		@SESSO, 
		@DATA_NASCITA, 
		@ID_CITTADINANZA, 
		@ID_COMUNE_NASCITA
	)
	SELECT SCOPE_IDENTITY() AS ID_PERSONA

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPersonaFisicaInsert';

