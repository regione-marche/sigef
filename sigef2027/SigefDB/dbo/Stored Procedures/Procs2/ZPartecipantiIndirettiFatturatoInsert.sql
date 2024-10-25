CREATE PROCEDURE [dbo].[ZPartecipantiIndirettiFatturatoInsert]
(
	@CuaaPromotore VARCHAR(16), 
	@IdImpresa INT, 
	@Cuaa VARCHAR(16), 
	@CodProdotto VARCHAR(3), 
	@CodVarieta VARCHAR(3), 
	@ProduzioneTotale DECIMAL(18,2), 
	@PrezzoMedio DECIMAL(18,2), 
	@Fatturato DECIMAL(18,2), 
	@IdClasseAllevamento INT, 
	@IdAttivitaConnessa INT, 
	@CuaaTrasformatore VARCHAR(16), 
	@ProduzioneInFiliera DECIMAL(18,2), 
	@NumeroCapi INT
)
AS
	INSERT INTO PARTECIPANTI_INDIRETTI_FATTURATO
	(
		CUAA_PROMOTORE, 
		ID_IMPRESA, 
		CUAA, 
		COD_PRODOTTO, 
		COD_VARIETA, 
		PRODUZIONE_TOTALE, 
		PREZZO_MEDIO, 
		FATTURATO, 
		ID_CLASSE_ALLEVAMENTO, 
		ID_ATTIVITA_CONNESSA, 
		CUAA_TRASFORMATORE, 
		PRODUZIONE_IN_FILIERA, 
		NUMERO_CAPI
	)
	VALUES
	(
		@CuaaPromotore, 
		@IdImpresa, 
		@Cuaa, 
		@CodProdotto, 
		@CodVarieta, 
		@ProduzioneTotale, 
		@PrezzoMedio, 
		@Fatturato, 
		@IdClasseAllevamento, 
		@IdAttivitaConnessa, 
		@CuaaTrasformatore, 
		@ProduzioneInFiliera, 
		@NumeroCapi
	)
	SELECT SCOPE_IDENTITY() AS ID

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZPartecipantiIndirettiFatturatoInsert]
(
	@CuaaPromotore VARCHAR(16), 
	@IdImpresa INT, 
	@Cuaa VARCHAR(16), 
	@CodProdotto VARCHAR(3), 
	@CodVarieta VARCHAR(3), 
	@ProduzioneTotale DECIMAL(18,2), 
	@PrezzoMedio DECIMAL(18,2), 
	@Fatturato DECIMAL(18,2), 
	@IdClasseAllevamento INT, 
	@IdAttivitaConnessa INT, 
	@CuaaTrasformatore VARCHAR(16), 
	@ProduzioneInFiliera DECIMAL(18,2), 
	@NumeroCapi INT
)
AS
	INSERT INTO PARTECIPANTI_INDIRETTI_FATTURATO
	(
		CUAA_PROMOTORE, 
		ID_IMPRESA, 
		CUAA, 
		COD_PRODOTTO, 
		COD_VARIETA, 
		PRODUZIONE_TOTALE, 
		PREZZO_MEDIO, 
		FATTURATO, 
		ID_CLASSE_ALLEVAMENTO, 
		ID_ATTIVITA_CONNESSA, 
		CUAA_TRASFORMATORE, 
		PRODUZIONE_IN_FILIERA, 
		NUMERO_CAPI
	)
	VALUES
	(
		@CuaaPromotore, 
		@IdImpresa, 
		@Cuaa, 
		@CodProdotto, 
		@CodVarieta, 
		@ProduzioneTotale, 
		@PrezzoMedio, 
		@Fatturato, 
		@IdClasseAllevamento, 
		@IdAttivitaConnessa, 
		@CuaaTrasformatore, 
		@ProduzioneInFiliera, 
		@NumeroCapi
	)
	SELECT SCOPE_IDENTITY() AS ID

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPartecipantiIndirettiFatturatoInsert';

