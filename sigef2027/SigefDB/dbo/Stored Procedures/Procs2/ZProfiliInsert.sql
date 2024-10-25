CREATE PROCEDURE [dbo].[ZProfiliInsert]
(
	@Descrizione VARCHAR(255), 
	@CodTipoEnte VARCHAR(10), 
	@Ordine INT, 
	@AbilitaInserimentoUtenti BIT, 
	@Attivo BIT
)
AS
	SET @AbilitaInserimentoUtenti = ISNULL(@AbilitaInserimentoUtenti,((0)))
	SET @Attivo = ISNULL(@Attivo,((1)))
	INSERT INTO PROFILI
	(
		DESCRIZIONE, 
		COD_TIPO_ENTE, 
		ORDINE, 
		ABILITA_INSERIMENTO_UTENTI, 
		ATTIVO
	)
	VALUES
	(
		@Descrizione, 
		@CodTipoEnte, 
		@Ordine, 
		@AbilitaInserimentoUtenti, 
		@Attivo
	)
	SELECT SCOPE_IDENTITY() AS ID_PROFILO, @AbilitaInserimentoUtenti AS ABILITA_INSERIMENTO_UTENTI, @Attivo AS ATTIVO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZProfiliInsert]
(
	@Descrizione VARCHAR(255), 
	@CodTipoEnte VARCHAR(10), 
	@Ordine INT, 
	@AbilitaInserimentoUtenti BIT
)
AS
	SET @AbilitaInserimentoUtenti = ISNULL(@AbilitaInserimentoUtenti,((0)))
	INSERT INTO PROFILI
	(
		DESCRIZIONE, 
		COD_TIPO_ENTE, 
		ORDINE, 
		ABILITA_INSERIMENTO_UTENTI
	)
	VALUES
	(
		@Descrizione, 
		@CodTipoEnte, 
		@Ordine, 
		@AbilitaInserimentoUtenti
	)
	SELECT SCOPE_IDENTITY() AS ID_PROFILO, @AbilitaInserimentoUtenti AS ABILITA_INSERIMENTO_UTENTI

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProfiliInsert';

