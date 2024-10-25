CREATE PROCEDURE [dbo].[ZManifestazionePlvUpdate]
(
	@IdPlv INT, 
	@IdImpresa INT, 
	@Anno INT, 
	@CodVarieta VARCHAR(3), 
	@CodProdotto VARCHAR(3), 
	@IdClasseAllevamento TINYINT, 
	@IdMateriaPrima INT, 
	@IdUnitaMisura INT, 
	@QuantitaReimpiego DECIMAL(15,2), 
	@ProduzioneUnitaria DECIMAL(18,4), 
	@PrezzoUnitario DECIMAL(18,4), 
	@Plv DECIMAL(15,2), 
	@Sau DECIMAL(15,2), 
	@IdAttivitaConnessa INT, 
	@Previsionale BIT, 
	@IdManifestazione INT, 
	@CodicePac CHAR(1), 
	@OreUnitarie DECIMAL(15,2), 
	@FlagBiologico BIT, 
	@FlagZonasvantaggiata BIT, 
	@FlagCommercializzazione BIT, 
	@FlagTrasformazione BIT
)
AS
	UPDATE MANIFESTAZIONE_PLV
	SET
		ID_IMPRESA = @IdImpresa, 
		ANNO = @Anno, 
		COD_VARIETA = @CodVarieta, 
		COD_PRODOTTO = @CodProdotto, 
		ID_CLASSE_ALLEVAMENTO = @IdClasseAllevamento, 
		ID_MATERIA_PRIMA = @IdMateriaPrima, 
		ID_UNITA_MISURA = @IdUnitaMisura, 
		QUANTITA_REIMPIEGO = @QuantitaReimpiego, 
		PRODUZIONE_UNITARIA = @ProduzioneUnitaria, 
		PREZZO_UNITARIO = @PrezzoUnitario, 
		PLV = @Plv, 
		SAU = @Sau, 
		ID_ATTIVITA_CONNESSA = @IdAttivitaConnessa, 
		PREVISIONALE = @Previsionale, 
		ID_MANIFESTAZIONE = @IdManifestazione, 
		CODICE_PAC = @CodicePac, 
		ORE_UNITARIE = @OreUnitarie, 
		FLAG_BIOLOGICO = @FlagBiologico, 
		FLAG_ZONASVANTAGGIATA = @FlagZonasvantaggiata, 
		FLAG_COMMERCIALIZZAZIONE = @FlagCommercializzazione, 
		FLAG_TRASFORMAZIONE = @FlagTrasformazione
	WHERE 
		(ID_PLV = @IdPlv)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazionePlvUpdate';

