CREATE PROCEDURE [dbo].[ZXconfigInsert]
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
	INSERT INTO XCONFIG
	(
		TIPO_CONFIGURAZIONE, 
		LOGIN, 
		PWD, 
		DOMINIO, 
		IP_INTERNO, 
		DEFAULT_DIRECTORY, 
		ATTIVO, 
		NOME, 
		COGNOME, 
		RUOLO, 
		CODICE_UO, 
		WS_BINDING, 
		DATA
	)
	VALUES
	(
		@TipoConfigurazione, 
		@Login, 
		@Pwd, 
		@Dominio, 
		@IpInterno, 
		@DefaultDirectory, 
		@Attivo, 
		@Nome, 
		@Cognome, 
		@Ruolo, 
		@CodiceUo, 
		@WsBinding, 
		@Data
	)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZXconfigInsert]
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
	INSERT INTO XCONFIG
	(
		TIPO_CONFIGURAZIONE, 
		LOGIN, 
		PWD, 
		DOMINIO, 
		IP_INTERNO, 
		DEFAULT_DIRECTORY, 
		ATTIVO, 
		NOME, 
		COGNOME, 
		RUOLO, 
		CODICE_UO
	)
	VALUES
	(
		@TipoConfigurazione, 
		@Login, 
		@Pwd, 
		@Dominio, 
		@IpInterno, 
		@DefaultDirectory, 
		@Attivo, 
		@Nome, 
		@Cognome, 
		@Ruolo, 
		@CodiceUo
	)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZXconfigInsert';

