CREATE PROCEDURE [dbo].[ZZprogrammazioneInsert]
(
	@CodTipo VARCHAR(255), 
	@Codice VARCHAR(255), 
	@Descrizione VARCHAR(2000), 
	@IdPadre INT, 
	@ImportoDotazione DECIMAL(18,2)
)
AS
	INSERT INTO zPROGRAMMAZIONE
	(
		COD_TIPO, 
		CODICE, 
		DESCRIZIONE, 
		ID_PADRE, 
		IMPORTO_DOTAZIONE
	)
	VALUES
	(
		@CodTipo, 
		@Codice, 
		@Descrizione, 
		@IdPadre, 
		@ImportoDotazione
	)
	SELECT SCOPE_IDENTITY() AS ID


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZprogrammazioneInsert]
(
	@CodTipo VARCHAR(255), 
	@Codice VARCHAR(255), 
	@Descrizione VARCHAR(2000), 
	@IdPadre INT
)
AS
	INSERT INTO zPROGRAMMAZIONE
	(
		COD_TIPO, 
		CODICE, 
		DESCRIZIONE, 
		ID_PADRE
	)
	VALUES
	(
		@CodTipo, 
		@Codice, 
		@Descrizione, 
		@IdPadre
	)
	SELECT SCOPE_IDENTITY() AS ID

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZprogrammazioneInsert';

