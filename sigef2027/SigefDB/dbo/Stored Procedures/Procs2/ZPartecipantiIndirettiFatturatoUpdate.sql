CREATE PROCEDURE [dbo].[ZPartecipantiIndirettiFatturatoUpdate]
(
	@Id INT, 
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
	UPDATE PARTECIPANTI_INDIRETTI_FATTURATO
	SET
		CUAA_PROMOTORE = @CuaaPromotore, 
		ID_IMPRESA = @IdImpresa, 
		CUAA = @Cuaa, 
		COD_PRODOTTO = @CodProdotto, 
		COD_VARIETA = @CodVarieta, 
		PRODUZIONE_TOTALE = @ProduzioneTotale, 
		PREZZO_MEDIO = @PrezzoMedio, 
		FATTURATO = @Fatturato, 
		ID_CLASSE_ALLEVAMENTO = @IdClasseAllevamento, 
		ID_ATTIVITA_CONNESSA = @IdAttivitaConnessa, 
		CUAA_TRASFORMATORE = @CuaaTrasformatore, 
		PRODUZIONE_IN_FILIERA = @ProduzioneInFiliera, 
		NUMERO_CAPI = @NumeroCapi
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZPartecipantiIndirettiFatturatoUpdate]
(
	@Id INT, 
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
	UPDATE PARTECIPANTI_INDIRETTI_FATTURATO
	SET
		CUAA_PROMOTORE = @CuaaPromotore, 
		ID_IMPRESA = @IdImpresa, 
		CUAA = @Cuaa, 
		COD_PRODOTTO = @CodProdotto, 
		COD_VARIETA = @CodVarieta, 
		PRODUZIONE_TOTALE = @ProduzioneTotale, 
		PREZZO_MEDIO = @PrezzoMedio, 
		FATTURATO = @Fatturato, 
		ID_CLASSE_ALLEVAMENTO = @IdClasseAllevamento, 
		ID_ATTIVITA_CONNESSA = @IdAttivitaConnessa, 
		CUAA_TRASFORMATORE = @CuaaTrasformatore, 
		PRODUZIONE_IN_FILIERA = @ProduzioneInFiliera, 
		NUMERO_CAPI = @NumeroCapi
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPartecipantiIndirettiFatturatoUpdate';

