CREATE PROCEDURE [dbo].[ZIntegrazioneSingolaDiDomandaFindFind]
(
	@IdSingolaIntegrazioneequalthis INT, 
	@IdIntegrazioneDomandaequalthis INT, 
	@CodTipoIntegrazioneequalthis VARCHAR(255), 
	@SingolaIntegrazioneCompletataIstruttoreequalthis BIT, 
	@SingolaIntegrazioneCompletataBeneficiarioequalthis BIT, 
	@IntegrazioneCompletaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SINGOLA_INTEGRAZIONE, ID_INTEGRAZIONE_DOMANDA, COD_TIPO_INTEGRAZIONE, DATA_INSERIMENTO, DATA_MODIFICA, CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE, NOTE_INTEGRAZIONE_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE, DATA_CONCLUSIONE_ISTRUTTORE, SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE, CF_BENEFICIARIO_SINGOLA_INTEGRAZIONE, NOTE_INTEGRAZIONE_BENEFICIARIO, DATA_RILASCIO_INTEGRAZIONE_BENEFICIARIO, DATA_CONCLUSIONE_BENEFICIARIO, SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO, ID_DOMANDA_PAGAMENTO, DATA_INSERIMENTO_INTEGRAZIONE, DATA_MODIFICA_INTEGRAZIONE, ISTANZA_DOMANDA_PAGAMENTO, INTEGRAZIONE_COMPLETA, NOTE_INTEGRAZIONE_DOMANDA, CF_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_DOMANDA, SEGNATURA_ISTRUTTORE, CF_BENFICIARIO, SEGNATURA_BENEFICIARIO, DATA_CONCLUSIONE_INTEGRAZIONE, DESCRIZIONE_TIPO_INTEGRAZIONE, ID_SPESA, ID_GIUSTIFICATIVO FROM VINTEGRAZIONE_SINGOLA_DI_DOMANDA WHERE 1=1';
	IF (@IdSingolaIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SINGOLA_INTEGRAZIONE = @IdSingolaIntegrazioneequalthis)'; set @lensql=@lensql+len(@IdSingolaIntegrazioneequalthis);end;
	IF (@IdIntegrazioneDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INTEGRAZIONE_DOMANDA = @IdIntegrazioneDomandaequalthis)'; set @lensql=@lensql+len(@IdIntegrazioneDomandaequalthis);end;
	IF (@CodTipoIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_INTEGRAZIONE = @CodTipoIntegrazioneequalthis)'; set @lensql=@lensql+len(@CodTipoIntegrazioneequalthis);end;
	IF (@SingolaIntegrazioneCompletataIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE = @SingolaIntegrazioneCompletataIstruttoreequalthis)'; set @lensql=@lensql+len(@SingolaIntegrazioneCompletataIstruttoreequalthis);end;
	IF (@SingolaIntegrazioneCompletataBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO = @SingolaIntegrazioneCompletataBeneficiarioequalthis)'; set @lensql=@lensql+len(@SingolaIntegrazioneCompletataBeneficiarioequalthis);end;
	IF (@IntegrazioneCompletaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INTEGRAZIONE_COMPLETA = @IntegrazioneCompletaequalthis)'; set @lensql=@lensql+len(@IntegrazioneCompletaequalthis);end;
	set @sql = @sql + 'ORDER BY ID_SINGOLA_INTEGRAZIONE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdSingolaIntegrazioneequalthis INT, @IdIntegrazioneDomandaequalthis INT, @CodTipoIntegrazioneequalthis VARCHAR(255), @SingolaIntegrazioneCompletataIstruttoreequalthis BIT, @SingolaIntegrazioneCompletataBeneficiarioequalthis BIT, @IntegrazioneCompletaequalthis BIT',@IdSingolaIntegrazioneequalthis , @IdIntegrazioneDomandaequalthis , @CodTipoIntegrazioneequalthis , @SingolaIntegrazioneCompletataIstruttoreequalthis , @SingolaIntegrazioneCompletataBeneficiarioequalthis , @IntegrazioneCompletaequalthis ;
	else
		SELECT ID_SINGOLA_INTEGRAZIONE, ID_INTEGRAZIONE_DOMANDA, COD_TIPO_INTEGRAZIONE, DATA_INSERIMENTO, DATA_MODIFICA, CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE, NOTE_INTEGRAZIONE_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE, DATA_CONCLUSIONE_ISTRUTTORE, SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE, CF_BENEFICIARIO_SINGOLA_INTEGRAZIONE, NOTE_INTEGRAZIONE_BENEFICIARIO, DATA_RILASCIO_INTEGRAZIONE_BENEFICIARIO, DATA_CONCLUSIONE_BENEFICIARIO, SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO, ID_DOMANDA_PAGAMENTO, DATA_INSERIMENTO_INTEGRAZIONE, DATA_MODIFICA_INTEGRAZIONE, ISTANZA_DOMANDA_PAGAMENTO, INTEGRAZIONE_COMPLETA, NOTE_INTEGRAZIONE_DOMANDA, CF_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_DOMANDA, SEGNATURA_ISTRUTTORE, CF_BENFICIARIO, SEGNATURA_BENEFICIARIO, DATA_CONCLUSIONE_INTEGRAZIONE, DESCRIZIONE_TIPO_INTEGRAZIONE, ID_SPESA, ID_GIUSTIFICATIVO
		FROM VINTEGRAZIONE_SINGOLA_DI_DOMANDA
		WHERE 
			((@IdSingolaIntegrazioneequalthis IS NULL) OR ID_SINGOLA_INTEGRAZIONE = @IdSingolaIntegrazioneequalthis) AND 
			((@IdIntegrazioneDomandaequalthis IS NULL) OR ID_INTEGRAZIONE_DOMANDA = @IdIntegrazioneDomandaequalthis) AND 
			((@CodTipoIntegrazioneequalthis IS NULL) OR COD_TIPO_INTEGRAZIONE = @CodTipoIntegrazioneequalthis) AND 
			((@SingolaIntegrazioneCompletataIstruttoreequalthis IS NULL) OR SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE = @SingolaIntegrazioneCompletataIstruttoreequalthis) AND 
			((@SingolaIntegrazioneCompletataBeneficiarioequalthis IS NULL) OR SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO = @SingolaIntegrazioneCompletataBeneficiarioequalthis) AND 
			((@IntegrazioneCompletaequalthis IS NULL) OR INTEGRAZIONE_COMPLETA = @IntegrazioneCompletaequalthis)
		ORDER BY ID_SINGOLA_INTEGRAZIONE

GO