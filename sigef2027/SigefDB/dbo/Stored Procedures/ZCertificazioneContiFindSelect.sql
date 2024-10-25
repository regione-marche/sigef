CREATE PROCEDURE [dbo].[ZCertificazioneContiFindSelect]
(
	@IdCertificazioneContiequalthis INT, 
	@AnnoContabileDaequalthis DATETIME, 
	@AnnoContabileAequalthis DATETIME, 
	@DataPresentazioneContiequalthis DATETIME, 
	@CfOperatoreequalthis VARCHAR(255), 
	@FlagDefinitivoequalthis BIT, 
	@DataInserimentoequalthis DATETIME, 
	@DataModificaequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_CERTIFICAZIONE_CONTI, ANNO_CONTABILE_DA, ANNO_CONTABILE_A, DATA_PRESENTAZIONE_CONTI, ISTANZA_CERTIFICAZIONE_CONTI, CF_OPERATORE, FLAG_DEFINITIVO, DATA_INSERIMENTO, DATA_MODIFICA FROM vCERTIFICAZIONE_CONTI WHERE 1=1';
	IF (@IdCertificazioneContiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CERTIFICAZIONE_CONTI = @IdCertificazioneContiequalthis)'; set @lensql=@lensql+len(@IdCertificazioneContiequalthis);end;
	IF (@AnnoContabileDaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO_CONTABILE_DA = @AnnoContabileDaequalthis)'; set @lensql=@lensql+len(@AnnoContabileDaequalthis);end;
	IF (@AnnoContabileAequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO_CONTABILE_A = @AnnoContabileAequalthis)'; set @lensql=@lensql+len(@AnnoContabileAequalthis);end;
	IF (@DataPresentazioneContiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_PRESENTAZIONE_CONTI = @DataPresentazioneContiequalthis)'; set @lensql=@lensql+len(@DataPresentazioneContiequalthis);end;
	IF (@CfOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_OPERATORE = @CfOperatoreequalthis)'; set @lensql=@lensql+len(@CfOperatoreequalthis);end;
	IF (@FlagDefinitivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_DEFINITIVO = @FlagDefinitivoequalthis)'; set @lensql=@lensql+len(@FlagDefinitivoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdCertificazioneContiequalthis INT, @AnnoContabileDaequalthis DATETIME, @AnnoContabileAequalthis DATETIME, @DataPresentazioneContiequalthis DATETIME, @CfOperatoreequalthis VARCHAR(255), @FlagDefinitivoequalthis BIT, @DataInserimentoequalthis DATETIME, @DataModificaequalthis DATETIME',@IdCertificazioneContiequalthis , @AnnoContabileDaequalthis , @AnnoContabileAequalthis , @DataPresentazioneContiequalthis , @CfOperatoreequalthis , @FlagDefinitivoequalthis , @DataInserimentoequalthis , @DataModificaequalthis ;
	else
		SELECT ID_CERTIFICAZIONE_CONTI, ANNO_CONTABILE_DA, ANNO_CONTABILE_A, DATA_PRESENTAZIONE_CONTI, ISTANZA_CERTIFICAZIONE_CONTI, CF_OPERATORE, FLAG_DEFINITIVO, DATA_INSERIMENTO, DATA_MODIFICA
		FROM vCERTIFICAZIONE_CONTI
		WHERE 
			((@IdCertificazioneContiequalthis IS NULL) OR ID_CERTIFICAZIONE_CONTI = @IdCertificazioneContiequalthis) AND 
			((@AnnoContabileDaequalthis IS NULL) OR ANNO_CONTABILE_DA = @AnnoContabileDaequalthis) AND 
			((@AnnoContabileAequalthis IS NULL) OR ANNO_CONTABILE_A = @AnnoContabileAequalthis) AND 
			((@DataPresentazioneContiequalthis IS NULL) OR DATA_PRESENTAZIONE_CONTI = @DataPresentazioneContiequalthis) AND 
			((@CfOperatoreequalthis IS NULL) OR CF_OPERATORE = @CfOperatoreequalthis) AND 
			((@FlagDefinitivoequalthis IS NULL) OR FLAG_DEFINITIVO = @FlagDefinitivoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis)
