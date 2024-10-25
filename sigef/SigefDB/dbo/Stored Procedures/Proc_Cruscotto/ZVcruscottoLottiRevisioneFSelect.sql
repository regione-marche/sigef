CREATE PROCEDURE [dbo].[ZVcruscottoLottiRevisioneFSelect]
(
	@IdLottoE INT, 
	@IdBandoE INT, 
	@ProvinciaE VARCHAR(255), 
	@DataCreazioneE DATETIME, 
	@CfOperatoreE VARCHAR(255), 
	@DataModificaE DATETIME, 
	@NumeroEstrazioniE INT, 
	@RevisioneConclusaE BIT, 
	@DescrizioneE VARCHAR(2000), 
	@DataScadenzaE DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_LOTTO, ID_BANDO, PROVINCIA, DATA_CREAZIONE, CF_OPERATORE, DATA_MODIFICA, NUMERO_ESTRAZIONI, REVISIONE_CONCLUSA, DESCRIZIONE, DATA_SCADENZA FROM vCRUSCOTTO_LOTTI_REVISIONE WHERE 1=1';
	IF (@IdLottoE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOTTO = @IdLottoE)'; set @lensql=@lensql+len(@IdLottoE);end;
	IF (@IdBandoE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoE)'; set @lensql=@lensql+len(@IdBandoE);end;
	IF (@ProvinciaE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA = @ProvinciaE)'; set @lensql=@lensql+len(@ProvinciaE);end;
	IF (@DataCreazioneE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CREAZIONE = @DataCreazioneE)'; set @lensql=@lensql+len(@DataCreazioneE);end;
	IF (@CfOperatoreE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_OPERATORE = @CfOperatoreE)'; set @lensql=@lensql+len(@CfOperatoreE);end;
	IF (@DataModificaE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaE)'; set @lensql=@lensql+len(@DataModificaE);end;
	IF (@NumeroEstrazioniE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_ESTRAZIONI = @NumeroEstrazioniE)'; set @lensql=@lensql+len(@NumeroEstrazioniE);end;
	IF (@RevisioneConclusaE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (REVISIONE_CONCLUSA = @RevisioneConclusaE)'; set @lensql=@lensql+len(@RevisioneConclusaE);end;
	IF (@DescrizioneE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @DescrizioneE)'; set @lensql=@lensql+len(@DescrizioneE);end;
	IF (@DataScadenzaE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SCADENZA = @DataScadenzaE)'; set @lensql=@lensql+len(@DataScadenzaE);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdLottoE INT, @IdBandoE INT, @ProvinciaE VARCHAR(255), @DataCreazioneE DATETIME, @CfOperatoreE VARCHAR(255), @DataModificaE DATETIME, @NumeroEstrazioniE INT, @RevisioneConclusaE BIT, @DescrizioneE VARCHAR(2000), @DataScadenzaE DATETIME',@IdLottoE , @IdBandoE , @ProvinciaE , @DataCreazioneE , @CfOperatoreE , @DataModificaE , @NumeroEstrazioniE , @RevisioneConclusaE , @DescrizioneE , @DataScadenzaE ;
	else
		SELECT ID_LOTTO, ID_BANDO, PROVINCIA, DATA_CREAZIONE, CF_OPERATORE, DATA_MODIFICA, NUMERO_ESTRAZIONI, REVISIONE_CONCLUSA, DESCRIZIONE, DATA_SCADENZA
		FROM vCRUSCOTTO_LOTTI_REVISIONE
		WHERE 
			((@IdLottoE IS NULL) OR ID_LOTTO = @IdLottoE) AND 
			((@IdBandoE IS NULL) OR ID_BANDO = @IdBandoE) AND 
			((@ProvinciaE IS NULL) OR PROVINCIA = @ProvinciaE) AND 
			((@DataCreazioneE IS NULL) OR DATA_CREAZIONE = @DataCreazioneE) AND 
			((@CfOperatoreE IS NULL) OR CF_OPERATORE = @CfOperatoreE) AND 
			((@DataModificaE IS NULL) OR DATA_MODIFICA = @DataModificaE) AND 
			((@NumeroEstrazioniE IS NULL) OR NUMERO_ESTRAZIONI = @NumeroEstrazioniE) AND 
			((@RevisioneConclusaE IS NULL) OR REVISIONE_CONCLUSA = @RevisioneConclusaE) AND 
			((@DescrizioneE IS NULL) OR DESCRIZIONE = @DescrizioneE) AND 
			((@DataScadenzaE IS NULL) OR DATA_SCADENZA = @DataScadenzaE)