CREATE PROCEDURE [dbo].[ZAnticipiRichiestiFindSelect]
(
	@IdAnticipoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdBandoequalthis INT, 
	@DataRichiestaequalthis DATETIME, 
	@ContributoRichiestoequalthis DECIMAL(18,2), 
	@ContributoAmmessoequalthis DECIMAL(18,2), 
	@Ammessoequalthis BIT, 
	@Istruttoreequalthis VARCHAR(255), 
	@DataValutazioneequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ANTICIPO, ID_DOMANDA_PAGAMENTO, ID_BANDO, DATA_RICHIESTA, CONTRIBUTO_RICHIESTO, CONTRIBUTO_AMMESSO, AMMESSO, ISTRUTTORE, DATA_VALUTAZIONE FROM ANTICIPI_RICHIESTI WHERE 1=1';
	IF (@IdAnticipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ANTICIPO = @IdAnticipoequalthis)'; set @lensql=@lensql+len(@IdAnticipoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@DataRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_RICHIESTA = @DataRichiestaequalthis)'; set @lensql=@lensql+len(@DataRichiestaequalthis);end;
	IF (@ContributoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_RICHIESTO = @ContributoRichiestoequalthis)'; set @lensql=@lensql+len(@ContributoRichiestoequalthis);end;
	IF (@ContributoAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_AMMESSO = @ContributoAmmessoequalthis)'; set @lensql=@lensql+len(@ContributoAmmessoequalthis);end;
	IF (@Ammessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AMMESSO = @Ammessoequalthis)'; set @lensql=@lensql+len(@Ammessoequalthis);end;
	IF (@Istruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ISTRUTTORE = @Istruttoreequalthis)'; set @lensql=@lensql+len(@Istruttoreequalthis);end;
	IF (@DataValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_VALUTAZIONE = @DataValutazioneequalthis)'; set @lensql=@lensql+len(@DataValutazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdAnticipoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdBandoequalthis INT, @DataRichiestaequalthis DATETIME, @ContributoRichiestoequalthis DECIMAL(18,2), @ContributoAmmessoequalthis DECIMAL(18,2), @Ammessoequalthis BIT, @Istruttoreequalthis VARCHAR(255), @DataValutazioneequalthis DATETIME',@IdAnticipoequalthis , @IdDomandaPagamentoequalthis , @IdBandoequalthis , @DataRichiestaequalthis , @ContributoRichiestoequalthis , @ContributoAmmessoequalthis , @Ammessoequalthis , @Istruttoreequalthis , @DataValutazioneequalthis ;
	else
		SELECT ID_ANTICIPO, ID_DOMANDA_PAGAMENTO, ID_BANDO, DATA_RICHIESTA, CONTRIBUTO_RICHIESTO, CONTRIBUTO_AMMESSO, AMMESSO, ISTRUTTORE, DATA_VALUTAZIONE
		FROM ANTICIPI_RICHIESTI
		WHERE 
			((@IdAnticipoequalthis IS NULL) OR ID_ANTICIPO = @IdAnticipoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@DataRichiestaequalthis IS NULL) OR DATA_RICHIESTA = @DataRichiestaequalthis) AND 
			((@ContributoRichiestoequalthis IS NULL) OR CONTRIBUTO_RICHIESTO = @ContributoRichiestoequalthis) AND 
			((@ContributoAmmessoequalthis IS NULL) OR CONTRIBUTO_AMMESSO = @ContributoAmmessoequalthis) AND 
			((@Ammessoequalthis IS NULL) OR AMMESSO = @Ammessoequalthis) AND 
			((@Istruttoreequalthis IS NULL) OR ISTRUTTORE = @Istruttoreequalthis) AND 
			((@DataValutazioneequalthis IS NULL) OR DATA_VALUTAZIONE = @DataValutazioneequalthis)
