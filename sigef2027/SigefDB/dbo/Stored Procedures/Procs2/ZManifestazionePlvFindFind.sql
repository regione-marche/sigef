CREATE PROCEDURE [dbo].[ZManifestazionePlvFindFind]
(
	@IdPlvequalthis INT, 
	@IdImpresaequalthis INT, 
	@Annoequalthis INT, 
	@IdManifestazioneequalthis INT, 
	@Previsionaleequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PLV, ID_IMPRESA, ANNO, COD_VARIETA, COD_PRODOTTO, ID_CLASSE_ALLEVAMENTO, ID_MATERIA_PRIMA, ID_UNITA_MISURA, QUANTITA_REIMPIEGO, PRODUZIONE_UNITARIA, PREZZO_UNITARIO, PLV, VARIETA, CLASSE_ALLEVAMENTO, PRODOTTO, SAU, ID_ATTIVITA_CONNESSA, ATTIVITA_CONNESSA, PREVISIONALE, ID_MANIFESTAZIONE, CODICE_PAC, ORE_UNITARIE, UBA, ORE_ALLEVAMENTI, ORE_ALLEVAMENTI_SVANTAGGIO, PREZZO_UNITARIO_ALLEVAMENTI, ORE_ATTIVITA_CONNESSE, ORE_ATTIVITA_CONNESSE_SVANTAGGIO, PAC, ORE_COLTURA, ORE_COLTURA_SVANTAGGIO, PREZZO_COLTURA, RESA_COLTURA, COEFFICIENTE_ALLEVAMENTI, UNITA_MISURA_ALLEVAMENTI, COEFFICIENTE_PRODOTTO, UNITA_MISURA_PRODOTTO, PREZZO_ATTIVITA_CONNESSE, UNITA_MISURA_ATTIVITA_CONNESSE, PRODUZIONE_UNITARIA_ALLEVAMENTI, MATERIA_PRIMA, FLAG_BIOLOGICO, FLAG_ZONASVANTAGGIATA, FLAG_COMMERCIALIZZAZIONE, FLAG_TRASFORMAZIONE FROM vMANIFESTAZIONE_PLV WHERE 1=1';
	IF (@IdPlvequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PLV = @IdPlvequalthis)'; set @lensql=@lensql+len(@IdPlvequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO = @Annoequalthis)'; set @lensql=@lensql+len(@Annoequalthis);end;
	IF (@IdManifestazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_MANIFESTAZIONE = @IdManifestazioneequalthis)'; set @lensql=@lensql+len(@IdManifestazioneequalthis);end;
	IF (@Previsionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PREVISIONALE = @Previsionaleequalthis)'; set @lensql=@lensql+len(@Previsionaleequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPlvequalthis INT, @IdImpresaequalthis INT, @Annoequalthis INT, @IdManifestazioneequalthis INT, @Previsionaleequalthis BIT',@IdPlvequalthis , @IdImpresaequalthis , @Annoequalthis , @IdManifestazioneequalthis , @Previsionaleequalthis ;
	else
		SELECT ID_PLV, ID_IMPRESA, ANNO, COD_VARIETA, COD_PRODOTTO, ID_CLASSE_ALLEVAMENTO, ID_MATERIA_PRIMA, ID_UNITA_MISURA, QUANTITA_REIMPIEGO, PRODUZIONE_UNITARIA, PREZZO_UNITARIO, PLV, VARIETA, CLASSE_ALLEVAMENTO, PRODOTTO, SAU, ID_ATTIVITA_CONNESSA, ATTIVITA_CONNESSA, PREVISIONALE, ID_MANIFESTAZIONE, CODICE_PAC, ORE_UNITARIE, UBA, ORE_ALLEVAMENTI, ORE_ALLEVAMENTI_SVANTAGGIO, PREZZO_UNITARIO_ALLEVAMENTI, ORE_ATTIVITA_CONNESSE, ORE_ATTIVITA_CONNESSE_SVANTAGGIO, PAC, ORE_COLTURA, ORE_COLTURA_SVANTAGGIO, PREZZO_COLTURA, RESA_COLTURA, COEFFICIENTE_ALLEVAMENTI, UNITA_MISURA_ALLEVAMENTI, COEFFICIENTE_PRODOTTO, UNITA_MISURA_PRODOTTO, PREZZO_ATTIVITA_CONNESSE, UNITA_MISURA_ATTIVITA_CONNESSE, PRODUZIONE_UNITARIA_ALLEVAMENTI, MATERIA_PRIMA, FLAG_BIOLOGICO, FLAG_ZONASVANTAGGIATA, FLAG_COMMERCIALIZZAZIONE, FLAG_TRASFORMAZIONE
		FROM vMANIFESTAZIONE_PLV
		WHERE 
			((@IdPlvequalthis IS NULL) OR ID_PLV = @IdPlvequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis) AND 
			((@IdManifestazioneequalthis IS NULL) OR ID_MANIFESTAZIONE = @IdManifestazioneequalthis) AND 
			((@Previsionaleequalthis IS NULL) OR PREVISIONALE = @Previsionaleequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazionePlvFindFind';

