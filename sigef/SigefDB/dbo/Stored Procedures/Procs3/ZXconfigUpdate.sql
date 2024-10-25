CREATE PROCEDURE [dbo].[ZXconfigUpdate]
(
	@TipoConfigurazione VARCHAR(255), 
	@Login VARCHAR(255), 
	@Pwd VARCHAR(255), 
	@Dominio VARCHAR(255), 
	@IpInterno VARCHAR(255), 
	@DefaultDirectory VARCHAR(255), 
	@Attivo BIT, 
	@Nome VARCHAR(255), 
	@Cognome VARCHAR(255), 
	@Ruolo VARCHAR(255), 
	@CodiceUo VARCHAR(255), 
	@WsBinding VARCHAR(255), 
	@Data DATETIME
)
AS
	UPDATE XCONFIG
	SET
		LOGIN = @Login, 
		PWD = @Pwd, 
		DOMINIO = @Dominio, 
		IP_INTERNO = @IpInterno, 
		DEFAULT_DIRECTORY = @DefaultDirectory, 
		ATTIVO = @Attivo, 
		NOME = @Nome, 
		COGNOME = @Cognome, 
		RUOLO = @Ruolo, 
		CODICE_UO = @CodiceUo, 
		WS_BINDING = @WsBinding, 
		DATA = @Data
	WHERE 
		(TIPO_CONFIGURAZIONE = @TipoConfigurazione)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZXconfigUpdate]
(
	@TipoConfigurazione VARCHAR(50), 
	@Login VARCHAR(50), 
	@Pwd VARCHAR(50), 
	@Dominio VARCHAR(50), 
	@IpInterno VARCHAR(50), 
	@DefaultDirectory VARCHAR(50), 
	@Attivo BIT, 
	@Nome VARCHAR(50), 
	@Cognome VARCHAR(50), 
	@Ruolo VARCHAR(50), 
	@CodiceUo VARCHAR(50)
)
AS
	UPDATE XCONFIG
	SET
		LOGIN = @Login, 
		PWD = @Pwd, 
		DOMINIO = @Dominio, 
		IP_INTERNO = @IpInterno, 
		DEFAULT_DIRECTORY = @DefaultDirectory, 
		ATTIVO = @Attivo, 
		NOME = @Nome, 
		COGNOME = @Cognome, 
		RUOLO = @Ruolo, 
		CODICE_UO = @CodiceUo
	WHERE 
		(TIPO_CONFIGURAZIONE = @TipoConfigurazione)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZXconfigUpdate';

