CREATE PROCEDURE [dbo].[ZCertificazioneContiFindGetcertificazionecontibyid]
(
	@IdCertificazioneContiequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_CERTIFICAZIONE_CONTI, ANNO_CONTABILE_DA, ANNO_CONTABILE_A, DATA_PRESENTAZIONE_CONTI, ISTANZA_CERTIFICAZIONE_CONTI, CF_OPERATORE, FLAG_DEFINITIVO, DATA_INSERIMENTO, DATA_MODIFICA FROM vCERTIFICAZIONE_CONTI WHERE 1=1';
	IF (@IdCertificazioneContiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CERTIFICAZIONE_CONTI = @IdCertificazioneContiequalthis)'; set @lensql=@lensql+len(@IdCertificazioneContiequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdCertificazioneContiequalthis INT',@IdCertificazioneContiequalthis ;
	else
		SELECT ID_CERTIFICAZIONE_CONTI, ANNO_CONTABILE_DA, ANNO_CONTABILE_A, DATA_PRESENTAZIONE_CONTI, ISTANZA_CERTIFICAZIONE_CONTI, CF_OPERATORE, FLAG_DEFINITIVO, DATA_INSERIMENTO, DATA_MODIFICA
		FROM vCERTIFICAZIONE_CONTI
		WHERE 
			((@IdCertificazioneContiequalthis IS NULL) OR ID_CERTIFICAZIONE_CONTI = @IdCertificazioneContiequalthis)