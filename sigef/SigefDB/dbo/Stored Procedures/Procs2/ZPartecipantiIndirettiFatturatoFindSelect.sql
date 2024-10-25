CREATE PROCEDURE [dbo].[ZPartecipantiIndirettiFatturatoFindSelect]
(
	@Idequalthis INT, 
	@CuaaPromotoreequalthis VARCHAR(16), 
	@IdImpresaequalthis INT, 
	@Cuaaequalthis VARCHAR(16), 
	@CodProdottoequalthis VARCHAR(3), 
	@CodVarietaequalthis VARCHAR(3), 
	@IdClasseAllevamentoequalthis INT, 
	@NumeroCapiequalthis INT, 
	@IdAttivitaConnessaequalthis INT, 
	@ProduzioneTotaleequalthis DECIMAL(18,2), 
	@ProduzioneInFilieraequalthis DECIMAL(18,2), 
	@PrezzoMedioequalthis DECIMAL(18,2), 
	@Fatturatoequalthis DECIMAL(18,2), 
	@CuaaTrasformatoreequalthis VARCHAR(16)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, CUAA_PROMOTORE, ID_IMPRESA, CUAA, COD_PRODOTTO, COD_VARIETA, PRODUZIONE_TOTALE, PREZZO_MEDIO, FATTURATO, VARIETA, PRODOTTO, CODICE_FISCALE, RAGIONE_SOCIALE, COD_FORMA_GIURIDICA, ID_DIMENSIONE, DIMENSIONE_IMPRESA, FORMA_GIURIDICA, ID_CLASSE_ALLEVAMENTO, ID_ATTIVITA_CONNESSA, CUAA_TRASFORMATORE, DESCRIZIONE, PREZZO_UNITARIO, ATTIVITA_CONNESSE, PREZZO_ATTIVITA, PRODUZIONE_IN_FILIERA, NUMERO_CAPI FROM vPARECIPANTI_INDIRETTI_FATTURATO WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@CuaaPromotoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA_PROMOTORE = @CuaaPromotoreequalthis)'; set @lensql=@lensql+len(@CuaaPromotoreequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA = @Cuaaequalthis)'; set @lensql=@lensql+len(@Cuaaequalthis);end;
	IF (@CodProdottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_PRODOTTO = @CodProdottoequalthis)'; set @lensql=@lensql+len(@CodProdottoequalthis);end;
	IF (@CodVarietaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_VARIETA = @CodVarietaequalthis)'; set @lensql=@lensql+len(@CodVarietaequalthis);end;
	IF (@IdClasseAllevamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CLASSE_ALLEVAMENTO = @IdClasseAllevamentoequalthis)'; set @lensql=@lensql+len(@IdClasseAllevamentoequalthis);end;
	IF (@NumeroCapiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_CAPI = @NumeroCapiequalthis)'; set @lensql=@lensql+len(@NumeroCapiequalthis);end;
	IF (@IdAttivitaConnessaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ATTIVITA_CONNESSA = @IdAttivitaConnessaequalthis)'; set @lensql=@lensql+len(@IdAttivitaConnessaequalthis);end;
	IF (@ProduzioneTotaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PRODUZIONE_TOTALE = @ProduzioneTotaleequalthis)'; set @lensql=@lensql+len(@ProduzioneTotaleequalthis);end;
	IF (@ProduzioneInFilieraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PRODUZIONE_IN_FILIERA = @ProduzioneInFilieraequalthis)'; set @lensql=@lensql+len(@ProduzioneInFilieraequalthis);end;
	IF (@PrezzoMedioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PREZZO_MEDIO = @PrezzoMedioequalthis)'; set @lensql=@lensql+len(@PrezzoMedioequalthis);end;
	IF (@Fatturatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FATTURATO = @Fatturatoequalthis)'; set @lensql=@lensql+len(@Fatturatoequalthis);end;
	IF (@CuaaTrasformatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA_TRASFORMATORE = @CuaaTrasformatoreequalthis)'; set @lensql=@lensql+len(@CuaaTrasformatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @CuaaPromotoreequalthis VARCHAR(16), @IdImpresaequalthis INT, @Cuaaequalthis VARCHAR(16), @CodProdottoequalthis VARCHAR(3), @CodVarietaequalthis VARCHAR(3), @IdClasseAllevamentoequalthis INT, @NumeroCapiequalthis INT, @IdAttivitaConnessaequalthis INT, @ProduzioneTotaleequalthis DECIMAL(18,2), @ProduzioneInFilieraequalthis DECIMAL(18,2), @PrezzoMedioequalthis DECIMAL(18,2), @Fatturatoequalthis DECIMAL(18,2), @CuaaTrasformatoreequalthis VARCHAR(16)',@Idequalthis , @CuaaPromotoreequalthis , @IdImpresaequalthis , @Cuaaequalthis , @CodProdottoequalthis , @CodVarietaequalthis , @IdClasseAllevamentoequalthis , @NumeroCapiequalthis , @IdAttivitaConnessaequalthis , @ProduzioneTotaleequalthis , @ProduzioneInFilieraequalthis , @PrezzoMedioequalthis , @Fatturatoequalthis , @CuaaTrasformatoreequalthis ;
	else
		SELECT ID, CUAA_PROMOTORE, ID_IMPRESA, CUAA, COD_PRODOTTO, COD_VARIETA, PRODUZIONE_TOTALE, PREZZO_MEDIO, FATTURATO, VARIETA, PRODOTTO, CODICE_FISCALE, RAGIONE_SOCIALE, COD_FORMA_GIURIDICA, ID_DIMENSIONE, DIMENSIONE_IMPRESA, FORMA_GIURIDICA, ID_CLASSE_ALLEVAMENTO, ID_ATTIVITA_CONNESSA, CUAA_TRASFORMATORE, DESCRIZIONE, PREZZO_UNITARIO, ATTIVITA_CONNESSE, PREZZO_ATTIVITA, PRODUZIONE_IN_FILIERA, NUMERO_CAPI
		FROM vPARECIPANTI_INDIRETTI_FATTURATO
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@CuaaPromotoreequalthis IS NULL) OR CUAA_PROMOTORE = @CuaaPromotoreequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis) AND 
			((@CodProdottoequalthis IS NULL) OR COD_PRODOTTO = @CodProdottoequalthis) AND 
			((@CodVarietaequalthis IS NULL) OR COD_VARIETA = @CodVarietaequalthis) AND 
			((@IdClasseAllevamentoequalthis IS NULL) OR ID_CLASSE_ALLEVAMENTO = @IdClasseAllevamentoequalthis) AND 
			((@NumeroCapiequalthis IS NULL) OR NUMERO_CAPI = @NumeroCapiequalthis) AND 
			((@IdAttivitaConnessaequalthis IS NULL) OR ID_ATTIVITA_CONNESSA = @IdAttivitaConnessaequalthis) AND 
			((@ProduzioneTotaleequalthis IS NULL) OR PRODUZIONE_TOTALE = @ProduzioneTotaleequalthis) AND 
			((@ProduzioneInFilieraequalthis IS NULL) OR PRODUZIONE_IN_FILIERA = @ProduzioneInFilieraequalthis) AND 
			((@PrezzoMedioequalthis IS NULL) OR PREZZO_MEDIO = @PrezzoMedioequalthis) AND 
			((@Fatturatoequalthis IS NULL) OR FATTURATO = @Fatturatoequalthis) AND 
			((@CuaaTrasformatoreequalthis IS NULL) OR CUAA_TRASFORMATORE = @CuaaTrasformatoreequalthis)
