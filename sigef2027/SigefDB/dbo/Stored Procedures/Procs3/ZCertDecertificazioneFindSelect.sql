CREATE PROCEDURE [dbo].[ZCertDecertificazioneFindSelect]
(
	@IdCertDecertificazioneequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdDecertificazioneequalthis INT, 
	@TipoDecertificazioneequalthis VARCHAR(255), 
	@ImportoDecertificazioneAmmessoequalthis DECIMAL(15,2), 
	@ImportoDecertificazioneConcessoequalthis DECIMAL(15,2), 
	@DataConstatazioneAmministrativaequalthis DATETIME, 
	@IdCertificazioneSpesaequalthis INT, 
	@IdCertificazioneContiequalthis INT, 
	@Assegnataequalthis BIT, 
	@Definitivaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_CERT_DECERTIFICAZIONE, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_DECERTIFICAZIONE, TIPO_DECERTIFICAZIONE, IMPORTO_DECERTIFICAZIONE_AMMESSO, IMPORTO_DECERTIFICAZIONE_CONCESSO, DATA_CONSTATAZIONE_AMMINISTRATIVA, ID_CERTIFICAZIONE_SPESA, ID_CERTIFICAZIONE_CONTI, ASSEGNATA, DEFINITIVA FROM CERT_DECERTIFICAZIONE WHERE 1=1';
	IF (@IdCertDecertificazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazioneequalthis)'; set @lensql=@lensql+len(@IdCertDecertificazioneequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdDecertificazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DECERTIFICAZIONE = @IdDecertificazioneequalthis)'; set @lensql=@lensql+len(@IdDecertificazioneequalthis);end;
	IF (@TipoDecertificazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_DECERTIFICAZIONE = @TipoDecertificazioneequalthis)'; set @lensql=@lensql+len(@TipoDecertificazioneequalthis);end;
	IF (@ImportoDecertificazioneAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DECERTIFICAZIONE_AMMESSO = @ImportoDecertificazioneAmmessoequalthis)'; set @lensql=@lensql+len(@ImportoDecertificazioneAmmessoequalthis);end;
	IF (@ImportoDecertificazioneConcessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DECERTIFICAZIONE_CONCESSO = @ImportoDecertificazioneConcessoequalthis)'; set @lensql=@lensql+len(@ImportoDecertificazioneConcessoequalthis);end;
	IF (@DataConstatazioneAmministrativaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CONSTATAZIONE_AMMINISTRATIVA = @DataConstatazioneAmministrativaequalthis)'; set @lensql=@lensql+len(@DataConstatazioneAmministrativaequalthis);end;
	IF (@IdCertificazioneSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CERTIFICAZIONE_SPESA = @IdCertificazioneSpesaequalthis)'; set @lensql=@lensql+len(@IdCertificazioneSpesaequalthis);end;
	IF (@IdCertificazioneContiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CERTIFICAZIONE_CONTI = @IdCertificazioneContiequalthis)'; set @lensql=@lensql+len(@IdCertificazioneContiequalthis);end;
	IF (@Assegnataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ASSEGNATA = @Assegnataequalthis)'; set @lensql=@lensql+len(@Assegnataequalthis);end;
	IF (@Definitivaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DEFINITIVA = @Definitivaequalthis)'; set @lensql=@lensql+len(@Definitivaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdCertDecertificazioneequalthis INT, @IdProgettoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdDecertificazioneequalthis INT, @TipoDecertificazioneequalthis VARCHAR(255), @ImportoDecertificazioneAmmessoequalthis DECIMAL(15,2), @ImportoDecertificazioneConcessoequalthis DECIMAL(15,2), @DataConstatazioneAmministrativaequalthis DATETIME, @IdCertificazioneSpesaequalthis INT, @IdCertificazioneContiequalthis INT, @Assegnataequalthis BIT, @Definitivaequalthis BIT',@IdCertDecertificazioneequalthis , @IdProgettoequalthis , @IdDomandaPagamentoequalthis , @IdDecertificazioneequalthis , @TipoDecertificazioneequalthis , @ImportoDecertificazioneAmmessoequalthis , @ImportoDecertificazioneConcessoequalthis , @DataConstatazioneAmministrativaequalthis , @IdCertificazioneSpesaequalthis , @IdCertificazioneContiequalthis , @Assegnataequalthis , @Definitivaequalthis ;
	else
		SELECT ID_CERT_DECERTIFICAZIONE, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_DECERTIFICAZIONE, TIPO_DECERTIFICAZIONE, IMPORTO_DECERTIFICAZIONE_AMMESSO, IMPORTO_DECERTIFICAZIONE_CONCESSO, DATA_CONSTATAZIONE_AMMINISTRATIVA, ID_CERTIFICAZIONE_SPESA, ID_CERTIFICAZIONE_CONTI, ASSEGNATA, DEFINITIVA
		FROM CERT_DECERTIFICAZIONE
		WHERE 
			((@IdCertDecertificazioneequalthis IS NULL) OR ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazioneequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdDecertificazioneequalthis IS NULL) OR ID_DECERTIFICAZIONE = @IdDecertificazioneequalthis) AND 
			((@TipoDecertificazioneequalthis IS NULL) OR TIPO_DECERTIFICAZIONE = @TipoDecertificazioneequalthis) AND 
			((@ImportoDecertificazioneAmmessoequalthis IS NULL) OR IMPORTO_DECERTIFICAZIONE_AMMESSO = @ImportoDecertificazioneAmmessoequalthis) AND 
			((@ImportoDecertificazioneConcessoequalthis IS NULL) OR IMPORTO_DECERTIFICAZIONE_CONCESSO = @ImportoDecertificazioneConcessoequalthis) AND 
			((@DataConstatazioneAmministrativaequalthis IS NULL) OR DATA_CONSTATAZIONE_AMMINISTRATIVA = @DataConstatazioneAmministrativaequalthis) AND 
			((@IdCertificazioneSpesaequalthis IS NULL) OR ID_CERTIFICAZIONE_SPESA = @IdCertificazioneSpesaequalthis) AND 
			((@IdCertificazioneContiequalthis IS NULL) OR ID_CERTIFICAZIONE_CONTI = @IdCertificazioneContiequalthis) AND 
			((@Assegnataequalthis IS NULL) OR ASSEGNATA = @Assegnataequalthis) AND 
			((@Definitivaequalthis IS NULL) OR DEFINITIVA = @Definitivaequalthis)