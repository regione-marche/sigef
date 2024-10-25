CREATE PROCEDURE [dbo].[ZManifestazionePlvInsert]
(
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
	INSERT INTO MANIFESTAZIONE_PLV
	(
		ID_IMPRESA, 
		ANNO, 
		COD_VARIETA, 
		COD_PRODOTTO, 
		ID_CLASSE_ALLEVAMENTO, 
		ID_MATERIA_PRIMA, 
		ID_UNITA_MISURA, 
		QUANTITA_REIMPIEGO, 
		PRODUZIONE_UNITARIA, 
		PREZZO_UNITARIO, 
		PLV, 
		SAU, 
		ID_ATTIVITA_CONNESSA, 
		PREVISIONALE, 
		ID_MANIFESTAZIONE, 
		CODICE_PAC, 
		ORE_UNITARIE, 
		FLAG_BIOLOGICO, 
		FLAG_ZONASVANTAGGIATA, 
		FLAG_COMMERCIALIZZAZIONE, 
		FLAG_TRASFORMAZIONE
	)
	VALUES
	(
		@IdImpresa, 
		@Anno, 
		@CodVarieta, 
		@CodProdotto, 
		@IdClasseAllevamento, 
		@IdMateriaPrima, 
		@IdUnitaMisura, 
		@QuantitaReimpiego, 
		@ProduzioneUnitaria, 
		@PrezzoUnitario, 
		@Plv, 
		@Sau, 
		@IdAttivitaConnessa, 
		@Previsionale, 
		@IdManifestazione, 
		@CodicePac, 
		@OreUnitarie, 
		@FlagBiologico, 
		@FlagZonasvantaggiata, 
		@FlagCommercializzazione, 
		@FlagTrasformazione
	)
	SELECT SCOPE_IDENTITY() AS ID_PLV

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazionePlvInsert';

