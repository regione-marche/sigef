CREATE PROCEDURE [dbo].[ZManifestazionePlvFindSelect]
(
	@IdPlvequalthis INT, 
	@IdImpresaequalthis INT, 
	@Previsionaleequalthis BIT, 
	@Annoequalthis INT, 
	@IdManifestazioneequalthis INT, 
	@CodVarietaequalthis VARCHAR(3), 
	@CodProdottoequalthis VARCHAR(3), 
	@IdClasseAllevamentoequalthis TINYINT, 
	@IdMateriaPrimaequalthis INT, 
	@IdUnitaMisuraequalthis INT, 
	@IdAttivitaConnessaequalthis INT, 
	@CodicePacequalthis CHAR(1), 
	@QuantitaReimpiegoequalthis DECIMAL(15,2), 
	@ProduzioneUnitariaequalthis DECIMAL(18,4), 
	@PrezzoUnitarioequalthis DECIMAL(18,4), 
	@Plvequalthis DECIMAL(15,2), 
	@OreUnitarieequalthis DECIMAL(15,2), 
	@Sauequalthis DECIMAL(15,2), 
	@FlagBiologicoequalthis BIT, 
	@FlagZonasvantaggiataequalthis BIT, 
	@FlagTrasformazioneequalthis BIT, 
	@FlagCommercializzazioneequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PLV, ID_IMPRESA, ANNO, COD_VARIETA, COD_PRODOTTO, ID_CLASSE_ALLEVAMENTO, ID_MATERIA_PRIMA, ID_UNITA_MISURA, QUANTITA_REIMPIEGO, PRODUZIONE_UNITARIA, PREZZO_UNITARIO, PLV, VARIETA, CLASSE_ALLEVAMENTO, PRODOTTO, SAU, ID_ATTIVITA_CONNESSA, ATTIVITA_CONNESSA, PREVISIONALE, ID_MANIFESTAZIONE, CODICE_PAC, ORE_UNITARIE, UBA, ORE_ALLEVAMENTI, ORE_ALLEVAMENTI_SVANTAGGIO, PREZZO_UNITARIO_ALLEVAMENTI, ORE_ATTIVITA_CONNESSE, ORE_ATTIVITA_CONNESSE_SVANTAGGIO, PAC, ORE_COLTURA, ORE_COLTURA_SVANTAGGIO, PREZZO_COLTURA, RESA_COLTURA, COEFFICIENTE_ALLEVAMENTI, UNITA_MISURA_ALLEVAMENTI, COEFFICIENTE_PRODOTTO, UNITA_MISURA_PRODOTTO, PREZZO_ATTIVITA_CONNESSE, UNITA_MISURA_ATTIVITA_CONNESSE, PRODUZIONE_UNITARIA_ALLEVAMENTI, MATERIA_PRIMA, FLAG_BIOLOGICO, FLAG_ZONASVANTAGGIATA, FLAG_COMMERCIALIZZAZIONE, FLAG_TRASFORMAZIONE FROM vMANIFESTAZIONE_PLV WHERE 1=1';
	IF (@IdPlvequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PLV = @IdPlvequalthis)'; set @lensql=@lensql+len(@IdPlvequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Previsionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PREVISIONALE = @Previsionaleequalthis)'; set @lensql=@lensql+len(@Previsionaleequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO = @Annoequalthis)'; set @lensql=@lensql+len(@Annoequalthis);end;
	IF (@IdManifestazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_MANIFESTAZIONE = @IdManifestazioneequalthis)'; set @lensql=@lensql+len(@IdManifestazioneequalthis);end;
	IF (@CodVarietaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_VARIETA = @CodVarietaequalthis)'; set @lensql=@lensql+len(@CodVarietaequalthis);end;
	IF (@CodProdottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_PRODOTTO = @CodProdottoequalthis)'; set @lensql=@lensql+len(@CodProdottoequalthis);end;
	IF (@IdClasseAllevamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CLASSE_ALLEVAMENTO = @IdClasseAllevamentoequalthis)'; set @lensql=@lensql+len(@IdClasseAllevamentoequalthis);end;
	IF (@IdMateriaPrimaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_MATERIA_PRIMA = @IdMateriaPrimaequalthis)'; set @lensql=@lensql+len(@IdMateriaPrimaequalthis);end;
	IF (@IdUnitaMisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UNITA_MISURA = @IdUnitaMisuraequalthis)'; set @lensql=@lensql+len(@IdUnitaMisuraequalthis);end;
	IF (@IdAttivitaConnessaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ATTIVITA_CONNESSA = @IdAttivitaConnessaequalthis)'; set @lensql=@lensql+len(@IdAttivitaConnessaequalthis);end;
	IF (@CodicePacequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_PAC = @CodicePacequalthis)'; set @lensql=@lensql+len(@CodicePacequalthis);end;
	IF (@QuantitaReimpiegoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUANTITA_REIMPIEGO = @QuantitaReimpiegoequalthis)'; set @lensql=@lensql+len(@QuantitaReimpiegoequalthis);end;
	IF (@ProduzioneUnitariaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PRODUZIONE_UNITARIA = @ProduzioneUnitariaequalthis)'; set @lensql=@lensql+len(@ProduzioneUnitariaequalthis);end;
	IF (@PrezzoUnitarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PREZZO_UNITARIO = @PrezzoUnitarioequalthis)'; set @lensql=@lensql+len(@PrezzoUnitarioequalthis);end;
	IF (@Plvequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PLV = @Plvequalthis)'; set @lensql=@lensql+len(@Plvequalthis);end;
	IF (@OreUnitarieequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORE_UNITARIE = @OreUnitarieequalthis)'; set @lensql=@lensql+len(@OreUnitarieequalthis);end;
	IF (@Sauequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SAU = @Sauequalthis)'; set @lensql=@lensql+len(@Sauequalthis);end;
	IF (@FlagBiologicoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_BIOLOGICO = @FlagBiologicoequalthis)'; set @lensql=@lensql+len(@FlagBiologicoequalthis);end;
	IF (@FlagZonasvantaggiataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_ZONASVANTAGGIATA = @FlagZonasvantaggiataequalthis)'; set @lensql=@lensql+len(@FlagZonasvantaggiataequalthis);end;
	IF (@FlagTrasformazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_TRASFORMAZIONE = @FlagTrasformazioneequalthis)'; set @lensql=@lensql+len(@FlagTrasformazioneequalthis);end;
	IF (@FlagCommercializzazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_COMMERCIALIZZAZIONE = @FlagCommercializzazioneequalthis)'; set @lensql=@lensql+len(@FlagCommercializzazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPlvequalthis INT, @IdImpresaequalthis INT, @Previsionaleequalthis BIT, @Annoequalthis INT, @IdManifestazioneequalthis INT, @CodVarietaequalthis VARCHAR(3), @CodProdottoequalthis VARCHAR(3), @IdClasseAllevamentoequalthis TINYINT, @IdMateriaPrimaequalthis INT, @IdUnitaMisuraequalthis INT, @IdAttivitaConnessaequalthis INT, @CodicePacequalthis CHAR(1), @QuantitaReimpiegoequalthis DECIMAL(15,2), @ProduzioneUnitariaequalthis DECIMAL(18,4), @PrezzoUnitarioequalthis DECIMAL(18,4), @Plvequalthis DECIMAL(15,2), @OreUnitarieequalthis DECIMAL(15,2), @Sauequalthis DECIMAL(15,2), @FlagBiologicoequalthis BIT, @FlagZonasvantaggiataequalthis BIT, @FlagTrasformazioneequalthis BIT, @FlagCommercializzazioneequalthis BIT',@IdPlvequalthis , @IdImpresaequalthis , @Previsionaleequalthis , @Annoequalthis , @IdManifestazioneequalthis , @CodVarietaequalthis , @CodProdottoequalthis , @IdClasseAllevamentoequalthis , @IdMateriaPrimaequalthis , @IdUnitaMisuraequalthis , @IdAttivitaConnessaequalthis , @CodicePacequalthis , @QuantitaReimpiegoequalthis , @ProduzioneUnitariaequalthis , @PrezzoUnitarioequalthis , @Plvequalthis , @OreUnitarieequalthis , @Sauequalthis , @FlagBiologicoequalthis , @FlagZonasvantaggiataequalthis , @FlagTrasformazioneequalthis , @FlagCommercializzazioneequalthis ;
	else
		SELECT ID_PLV, ID_IMPRESA, ANNO, COD_VARIETA, COD_PRODOTTO, ID_CLASSE_ALLEVAMENTO, ID_MATERIA_PRIMA, ID_UNITA_MISURA, QUANTITA_REIMPIEGO, PRODUZIONE_UNITARIA, PREZZO_UNITARIO, PLV, VARIETA, CLASSE_ALLEVAMENTO, PRODOTTO, SAU, ID_ATTIVITA_CONNESSA, ATTIVITA_CONNESSA, PREVISIONALE, ID_MANIFESTAZIONE, CODICE_PAC, ORE_UNITARIE, UBA, ORE_ALLEVAMENTI, ORE_ALLEVAMENTI_SVANTAGGIO, PREZZO_UNITARIO_ALLEVAMENTI, ORE_ATTIVITA_CONNESSE, ORE_ATTIVITA_CONNESSE_SVANTAGGIO, PAC, ORE_COLTURA, ORE_COLTURA_SVANTAGGIO, PREZZO_COLTURA, RESA_COLTURA, COEFFICIENTE_ALLEVAMENTI, UNITA_MISURA_ALLEVAMENTI, COEFFICIENTE_PRODOTTO, UNITA_MISURA_PRODOTTO, PREZZO_ATTIVITA_CONNESSE, UNITA_MISURA_ATTIVITA_CONNESSE, PRODUZIONE_UNITARIA_ALLEVAMENTI, MATERIA_PRIMA, FLAG_BIOLOGICO, FLAG_ZONASVANTAGGIATA, FLAG_COMMERCIALIZZAZIONE, FLAG_TRASFORMAZIONE
		FROM vMANIFESTAZIONE_PLV
		WHERE 
			((@IdPlvequalthis IS NULL) OR ID_PLV = @IdPlvequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Previsionaleequalthis IS NULL) OR PREVISIONALE = @Previsionaleequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis) AND 
			((@IdManifestazioneequalthis IS NULL) OR ID_MANIFESTAZIONE = @IdManifestazioneequalthis) AND 
			((@CodVarietaequalthis IS NULL) OR COD_VARIETA = @CodVarietaequalthis) AND 
			((@CodProdottoequalthis IS NULL) OR COD_PRODOTTO = @CodProdottoequalthis) AND 
			((@IdClasseAllevamentoequalthis IS NULL) OR ID_CLASSE_ALLEVAMENTO = @IdClasseAllevamentoequalthis) AND 
			((@IdMateriaPrimaequalthis IS NULL) OR ID_MATERIA_PRIMA = @IdMateriaPrimaequalthis) AND 
			((@IdUnitaMisuraequalthis IS NULL) OR ID_UNITA_MISURA = @IdUnitaMisuraequalthis) AND 
			((@IdAttivitaConnessaequalthis IS NULL) OR ID_ATTIVITA_CONNESSA = @IdAttivitaConnessaequalthis) AND 
			((@CodicePacequalthis IS NULL) OR CODICE_PAC = @CodicePacequalthis) AND 
			((@QuantitaReimpiegoequalthis IS NULL) OR QUANTITA_REIMPIEGO = @QuantitaReimpiegoequalthis) AND 
			((@ProduzioneUnitariaequalthis IS NULL) OR PRODUZIONE_UNITARIA = @ProduzioneUnitariaequalthis) AND 
			((@PrezzoUnitarioequalthis IS NULL) OR PREZZO_UNITARIO = @PrezzoUnitarioequalthis) AND 
			((@Plvequalthis IS NULL) OR PLV = @Plvequalthis) AND 
			((@OreUnitarieequalthis IS NULL) OR ORE_UNITARIE = @OreUnitarieequalthis) AND 
			((@Sauequalthis IS NULL) OR SAU = @Sauequalthis) AND 
			((@FlagBiologicoequalthis IS NULL) OR FLAG_BIOLOGICO = @FlagBiologicoequalthis) AND 
			((@FlagZonasvantaggiataequalthis IS NULL) OR FLAG_ZONASVANTAGGIATA = @FlagZonasvantaggiataequalthis) AND 
			((@FlagTrasformazioneequalthis IS NULL) OR FLAG_TRASFORMAZIONE = @FlagTrasformazioneequalthis) AND 
			((@FlagCommercializzazioneequalthis IS NULL) OR FLAG_COMMERCIALIZZAZIONE = @FlagCommercializzazioneequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazionePlvFindSelect';

