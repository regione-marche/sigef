CREATE PROCEDURE [dbo].[ZPianoDiSviluppoFindSelect]
(
	@IdPianoequalthis INT, 
	@Annoequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdProgettoequalthis INT, 
	@CostoInvestimentoequalthis DECIMAL(10,2), 
	@MezziPropriequalthis DECIMAL(10,2), 
	@RisorseTerziequalthis DECIMAL(10,2), 
	@ContributiPubbliciequalthis DECIMAL(10,2), 
	@SpeseGestioneequalthis DECIMAL(10,2), 
	@RimborsoDebitoequalthis DECIMAL(10,2), 
	@EntrataGestioneequalthis DECIMAL(10,2), 
	@AltreCopertureequalthis DECIMAL(10,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PIANO, ANNO, ID_IMPRESA, ID_PROGETTO, COSTO_INVESTIMENTO, MEZZI_PROPRI, RISORSE_TERZI, CONTRIBUTI_PUBBLICI, SPESE_GESTIONE, RIMBORSO_DEBITO, ENTRATA_GESTIONE, ALTRE_COPERTURE FROM PIANO_DI_SVILUPPO WHERE 1=1';
	IF (@IdPianoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PIANO = @IdPianoequalthis)'; set @lensql=@lensql+len(@IdPianoequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO = @Annoequalthis)'; set @lensql=@lensql+len(@Annoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CostoInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COSTO_INVESTIMENTO = @CostoInvestimentoequalthis)'; set @lensql=@lensql+len(@CostoInvestimentoequalthis);end;
	IF (@MezziPropriequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MEZZI_PROPRI = @MezziPropriequalthis)'; set @lensql=@lensql+len(@MezziPropriequalthis);end;
	IF (@RisorseTerziequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RISORSE_TERZI = @RisorseTerziequalthis)'; set @lensql=@lensql+len(@RisorseTerziequalthis);end;
	IF (@ContributiPubbliciequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTI_PUBBLICI = @ContributiPubbliciequalthis)'; set @lensql=@lensql+len(@ContributiPubbliciequalthis);end;
	IF (@SpeseGestioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SPESE_GESTIONE = @SpeseGestioneequalthis)'; set @lensql=@lensql+len(@SpeseGestioneequalthis);end;
	IF (@RimborsoDebitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RIMBORSO_DEBITO = @RimborsoDebitoequalthis)'; set @lensql=@lensql+len(@RimborsoDebitoequalthis);end;
	IF (@EntrataGestioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ENTRATA_GESTIONE = @EntrataGestioneequalthis)'; set @lensql=@lensql+len(@EntrataGestioneequalthis);end;
	IF (@AltreCopertureequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ALTRE_COPERTURE = @AltreCopertureequalthis)'; set @lensql=@lensql+len(@AltreCopertureequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPianoequalthis INT, @Annoequalthis INT, @IdImpresaequalthis INT, @IdProgettoequalthis INT, @CostoInvestimentoequalthis DECIMAL(10,2), @MezziPropriequalthis DECIMAL(10,2), @RisorseTerziequalthis DECIMAL(10,2), @ContributiPubbliciequalthis DECIMAL(10,2), @SpeseGestioneequalthis DECIMAL(10,2), @RimborsoDebitoequalthis DECIMAL(10,2), @EntrataGestioneequalthis DECIMAL(10,2), @AltreCopertureequalthis DECIMAL(10,2)',@IdPianoequalthis , @Annoequalthis , @IdImpresaequalthis , @IdProgettoequalthis , @CostoInvestimentoequalthis , @MezziPropriequalthis , @RisorseTerziequalthis , @ContributiPubbliciequalthis , @SpeseGestioneequalthis , @RimborsoDebitoequalthis , @EntrataGestioneequalthis , @AltreCopertureequalthis ;
	else
		SELECT ID_PIANO, ANNO, ID_IMPRESA, ID_PROGETTO, COSTO_INVESTIMENTO, MEZZI_PROPRI, RISORSE_TERZI, CONTRIBUTI_PUBBLICI, SPESE_GESTIONE, RIMBORSO_DEBITO, ENTRATA_GESTIONE, ALTRE_COPERTURE
		FROM PIANO_DI_SVILUPPO
		WHERE 
			((@IdPianoequalthis IS NULL) OR ID_PIANO = @IdPianoequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CostoInvestimentoequalthis IS NULL) OR COSTO_INVESTIMENTO = @CostoInvestimentoequalthis) AND 
			((@MezziPropriequalthis IS NULL) OR MEZZI_PROPRI = @MezziPropriequalthis) AND 
			((@RisorseTerziequalthis IS NULL) OR RISORSE_TERZI = @RisorseTerziequalthis) AND 
			((@ContributiPubbliciequalthis IS NULL) OR CONTRIBUTI_PUBBLICI = @ContributiPubbliciequalthis) AND 
			((@SpeseGestioneequalthis IS NULL) OR SPESE_GESTIONE = @SpeseGestioneequalthis) AND 
			((@RimborsoDebitoequalthis IS NULL) OR RIMBORSO_DEBITO = @RimborsoDebitoequalthis) AND 
			((@EntrataGestioneequalthis IS NULL) OR ENTRATA_GESTIONE = @EntrataGestioneequalthis) AND 
			((@AltreCopertureequalthis IS NULL) OR ALTRE_COPERTURE = @AltreCopertureequalthis)
