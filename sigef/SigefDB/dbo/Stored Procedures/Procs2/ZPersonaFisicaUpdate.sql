CREATE PROCEDURE [dbo].[ZPersonaFisicaUpdate]
(
	@IdPersona INT, 
	@Nome VARCHAR(255), 
	@Cognome VARCHAR(255), 
	@CodiceFiscale VARCHAR(255), 
	@Sesso VARCHAR(255), 
	@DataNascita DATETIME, 
	@IdCittadinanza INT, 
	@IdComuneNascita INT
)
AS
	UPDATE PERSONA_FISICA
	SET
		NOME = @Nome, 
		COGNOME = @Cognome, 
		CODICE_FISCALE = @CodiceFiscale, 
		SESSO = @Sesso, 
		DATA_NASCITA = @DataNascita, 
		ID_CITTADINANZA = @IdCittadinanza, 
		ID_COMUNE_NASCITA = @IdComuneNascita
	WHERE 
		(ID_PERSONA = @IdPersona)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZPersonafisicaUpdate]
(
	@ID_PERSONA INT, 
	@NOME VARCHAR(255), 
	@COGNOME VARCHAR(255), 
	@CODICE_FISCALE VARCHAR(16), 
	@SESSO CHAR(1), 
	@DATA_NASCITA DATETIME, 
	@ID_CITTADINANZA INT, 
	@ID_COMUNE_NASCITA INT
)
AS
	UPDATE PERSONA_FISICA
	SET
		NOME = @NOME, 
		COGNOME = @COGNOME, 
		CODICE_FISCALE = @CODICE_FISCALE, 
		SESSO = @SESSO, 
		DATA_NASCITA = @DATA_NASCITA, 
		ID_CITTADINANZA = @ID_CITTADINANZA, 
		ID_COMUNE_NASCITA = @ID_COMUNE_NASCITA
	WHERE 
		(ID_PERSONA = @ID_PERSONA)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPersonaFisicaUpdate';

