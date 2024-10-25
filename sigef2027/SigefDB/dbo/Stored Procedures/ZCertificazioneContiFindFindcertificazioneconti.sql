CREATE PROCEDURE [dbo].[ZCertificazioneContiFindFindcertificazioneconti]
(
	@IdCertificazioneContiequalthis INT, 
	@AnnoContabileDaequalthis DATETIME, 
	@AnnoContabileAequalthis DATETIME, 
	@FlagDefinitivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_CERTIFICAZIONE_CONTI, ANNO_CONTABILE_DA, ANNO_CONTABILE_A, DATA_PRESENTAZIONE_CONTI, ISTANZA_CERTIFICAZIONE_CONTI, CF_OPERATORE, FLAG_DEFINITIVO, DATA_INSERIMENTO, DATA_MODIFICA FROM vCERTIFICAZIONE_CONTI WHERE 1=1';
	IF (@IdCertificazioneContiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CERTIFICAZIONE_CONTI = @IdCertificazioneContiequalthis)'; set @lensql=@lensql+len(@IdCertificazioneContiequalthis);end;
	IF (@AnnoContabileDaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO_CONTABILE_DA = @AnnoContabileDaequalthis)'; set @lensql=@lensql+len(@AnnoContabileDaequalthis);end;
	IF (@AnnoContabileAequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO_CONTABILE_A = @AnnoContabileAequalthis)'; set @lensql=@lensql+len(@AnnoContabileAequalthis);end;
	IF (@FlagDefinitivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_DEFINITIVO = @FlagDefinitivoequalthis)'; set @lensql=@lensql+len(@FlagDefinitivoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdCertificazioneContiequalthis INT, @AnnoContabileDaequalthis DATETIME, @AnnoContabileAequalthis DATETIME, @FlagDefinitivoequalthis BIT',@IdCertificazioneContiequalthis , @AnnoContabileDaequalthis , @AnnoContabileAequalthis , @FlagDefinitivoequalthis ;
	else
		SELECT ID_CERTIFICAZIONE_CONTI, ANNO_CONTABILE_DA, ANNO_CONTABILE_A, DATA_PRESENTAZIONE_CONTI, ISTANZA_CERTIFICAZIONE_CONTI, CF_OPERATORE, FLAG_DEFINITIVO, DATA_INSERIMENTO, DATA_MODIFICA
		FROM vCERTIFICAZIONE_CONTI
		WHERE 
			((@IdCertificazioneContiequalthis IS NULL) OR ID_CERTIFICAZIONE_CONTI = @IdCertificazioneContiequalthis) AND 
			((@AnnoContabileDaequalthis IS NULL) OR ANNO_CONTABILE_DA = @AnnoContabileDaequalthis) AND 
			((@AnnoContabileAequalthis IS NULL) OR ANNO_CONTABILE_A = @AnnoContabileAequalthis) AND 
			((@FlagDefinitivoequalthis IS NULL) OR FLAG_DEFINITIVO = @FlagDefinitivoequalthis)
		
