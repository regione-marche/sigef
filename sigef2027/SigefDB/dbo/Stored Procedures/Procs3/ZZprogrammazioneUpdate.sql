CREATE PROCEDURE [dbo].[ZZprogrammazioneUpdate]
(
	@Id INT, 
	@CodTipo VARCHAR(255), 
	@Codice VARCHAR(255), 
	@Descrizione VARCHAR(2000), 
	@IdPadre INT, 
	@ImportoDotazione DECIMAL(18,2)
)
AS
	UPDATE zPROGRAMMAZIONE
	SET
		COD_TIPO = @CodTipo, 
		CODICE = @Codice, 
		DESCRIZIONE = @Descrizione, 
		ID_PADRE = @IdPadre, 
		IMPORTO_DOTAZIONE = @ImportoDotazione
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZprogrammazioneUpdate]
(
	@Id INT, 
	@CodTipo VARCHAR(255), 
	@Codice VARCHAR(255), 
	@Descrizione VARCHAR(2000), 
	@IdPadre INT
)
AS
	UPDATE zPROGRAMMAZIONE
	SET
		COD_TIPO = @CodTipo, 
		CODICE = @Codice, 
		DESCRIZIONE = @Descrizione, 
		ID_PADRE = @IdPadre
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZprogrammazioneUpdate';

