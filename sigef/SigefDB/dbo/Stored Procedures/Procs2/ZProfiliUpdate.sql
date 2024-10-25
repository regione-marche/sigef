CREATE PROCEDURE [dbo].[ZProfiliUpdate]
(
	@IdProfilo INT, 
	@Descrizione VARCHAR(255), 
	@CodTipoEnte VARCHAR(10), 
	@Ordine INT, 
	@AbilitaInserimentoUtenti BIT, 
	@Attivo BIT
)
AS
	UPDATE PROFILI
	SET
		DESCRIZIONE = @Descrizione, 
		COD_TIPO_ENTE = @CodTipoEnte, 
		ORDINE = @Ordine, 
		ABILITA_INSERIMENTO_UTENTI = @AbilitaInserimentoUtenti, 
		ATTIVO = @Attivo
	WHERE 
		(ID_PROFILO = @IdProfilo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZProfiliUpdate]
(
	@IdProfilo INT, 
	@Descrizione VARCHAR(255), 
	@CodTipoEnte VARCHAR(10), 
	@Ordine INT, 
	@AbilitaInserimentoUtenti BIT
)
AS
	UPDATE PROFILI
	SET
		DESCRIZIONE = @Descrizione, 
		COD_TIPO_ENTE = @CodTipoEnte, 
		ORDINE = @Ordine, 
		ABILITA_INSERIMENTO_UTENTI = @AbilitaInserimentoUtenti
	WHERE 
		(ID_PROFILO = @IdProfilo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProfiliUpdate';

