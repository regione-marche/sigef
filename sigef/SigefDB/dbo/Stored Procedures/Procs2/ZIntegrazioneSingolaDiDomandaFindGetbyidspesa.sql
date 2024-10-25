CREATE PROCEDURE [dbo].[ZIntegrazioneSingolaDiDomandaFindGetbyidspesa]
(
	@IdSpesaequalthis INT, 
	@SingolaIntegrazioneCompletataIstruttoreequalthis BIT, 
	@SingolaIntegrazioneCompletataBeneficiarioequalthis BIT, 
	@IntegrazioneCompletaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SINGOLA_INTEGRAZIONE, ID_INTEGRAZIONE_DOMANDA, COD_TIPO_INTEGRAZIONE, DATA_INSERIMENTO, DATA_MODIFICA, CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE, NOTE_INTEGRAZIONE_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE, DATA_CONCLUSIONE_ISTRUTTORE, SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE, CF_BENEFICIARIO_SINGOLA_INTEGRAZIONE, NOTE_INTEGRAZIONE_BENEFICIARIO, DATA_RILASCIO_INTEGRAZIONE_BENEFICIARIO, DATA_CONCLUSIONE_BENEFICIARIO, SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO, ID_DOMANDA_PAGAMENTO, DATA_INSERIMENTO_INTEGRAZIONE, DATA_MODIFICA_INTEGRAZIONE, ISTANZA_DOMANDA_PAGAMENTO, INTEGRAZIONE_COMPLETA, NOTE_INTEGRAZIONE_DOMANDA, CF_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_DOMANDA, SEGNATURA_ISTRUTTORE, CF_BENFICIARIO, SEGNATURA_BENEFICIARIO, DATA_CONCLUSIONE_INTEGRAZIONE, DESCRIZIONE_TIPO_INTEGRAZIONE, ID_SPESA, ID_GIUSTIFICATIVO FROM VINTEGRAZIONE_SINGOLA_DI_DOMANDA WHERE 1=1';
	IF (@IdSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SPESA = @IdSpesaequalthis)'; set @lensql=@lensql+len(@IdSpesaequalthis);end;
	IF (@SingolaIntegrazioneCompletataIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE = @SingolaIntegrazioneCompletataIstruttoreequalthis)'; set @lensql=@lensql+len(@SingolaIntegrazioneCompletataIstruttoreequalthis);end;
	IF (@SingolaIntegrazioneCompletataBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO = @SingolaIntegrazioneCompletataBeneficiarioequalthis)'; set @lensql=@lensql+len(@SingolaIntegrazioneCompletataBeneficiarioequalthis);end;
	IF (@IntegrazioneCompletaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INTEGRAZIONE_COMPLETA = @IntegrazioneCompletaequalthis)'; set @lensql=@lensql+len(@IntegrazioneCompletaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdSpesaequalthis INT, @SingolaIntegrazioneCompletataIstruttoreequalthis BIT, @SingolaIntegrazioneCompletataBeneficiarioequalthis BIT, @IntegrazioneCompletaequalthis BIT',@IdSpesaequalthis , @SingolaIntegrazioneCompletataIstruttoreequalthis , @SingolaIntegrazioneCompletataBeneficiarioequalthis , @IntegrazioneCompletaequalthis ;
	else
		SELECT ID_SINGOLA_INTEGRAZIONE, ID_INTEGRAZIONE_DOMANDA, COD_TIPO_INTEGRAZIONE, DATA_INSERIMENTO, DATA_MODIFICA, CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE, NOTE_INTEGRAZIONE_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE, DATA_CONCLUSIONE_ISTRUTTORE, SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE, CF_BENEFICIARIO_SINGOLA_INTEGRAZIONE, NOTE_INTEGRAZIONE_BENEFICIARIO, DATA_RILASCIO_INTEGRAZIONE_BENEFICIARIO, DATA_CONCLUSIONE_BENEFICIARIO, SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO, ID_DOMANDA_PAGAMENTO, DATA_INSERIMENTO_INTEGRAZIONE, DATA_MODIFICA_INTEGRAZIONE, ISTANZA_DOMANDA_PAGAMENTO, INTEGRAZIONE_COMPLETA, NOTE_INTEGRAZIONE_DOMANDA, CF_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_DOMANDA, SEGNATURA_ISTRUTTORE, CF_BENFICIARIO, SEGNATURA_BENEFICIARIO, DATA_CONCLUSIONE_INTEGRAZIONE, DESCRIZIONE_TIPO_INTEGRAZIONE, ID_SPESA, ID_GIUSTIFICATIVO
		FROM VINTEGRAZIONE_SINGOLA_DI_DOMANDA
		WHERE 
			((@IdSpesaequalthis IS NULL) OR ID_SPESA = @IdSpesaequalthis) AND 
			((@SingolaIntegrazioneCompletataIstruttoreequalthis IS NULL) OR SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE = @SingolaIntegrazioneCompletataIstruttoreequalthis) AND 
			((@SingolaIntegrazioneCompletataBeneficiarioequalthis IS NULL) OR SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO = @SingolaIntegrazioneCompletataBeneficiarioequalthis) AND 
			((@IntegrazioneCompletaequalthis IS NULL) OR INTEGRAZIONE_COMPLETA = @IntegrazioneCompletaequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZIntegrazioneSingolaDiDomandaFindGetbyidspesa]
(
	@IdSpesaequalthis INT, 
	@SingolaIntegrazioneCompletataIstruttoreequalthis BIT, 
	@SingolaIntegrazioneCompletataBeneficiarioequalthis BIT, 
	@IntegrazioneCompletaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_SINGOLA_INTEGRAZIONE, ID_INTEGRAZIONE_DOMANDA, COD_TIPO_INTEGRAZIONE, DATA_INSERIMENTO, DATA_MODIFICA, CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE, NOTE_INTEGRAZIONE_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE, DATA_CONCLUSIONE_ISTRUTTORE, SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE, CF_BENEFICIARIO_SINGOLA_INTEGRAZIONE, NOTE_INTEGRAZIONE_BENEFICIARIO, DATA_RILASCIO_INTEGRAZIONE_BENEFICIARIO, DATA_CONCLUSIONE_BENEFICIARIO, SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO, ID_DOMANDA_PAGAMENTO, DATA_INSERIMENTO_INTEGRAZIONE, DATA_MODIFICA_INTEGRAZIONE, ISTANZA_DOMANDA_PAGAMENTO, INTEGRAZIONE_COMPLETA, NOTE_INTEGRAZIONE_DOMANDA, CF_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_DOMANDA, SEGNATURA_ISTRUTTORE, CF_BENFICIARIO, SEGNATURA_BENEFICIARIO, DATA_CONCLUSIONE_INTEGRAZIONE, DESCRIZIONE_TIPO_INTEGRAZIONE, ID_SPESA, ID_GIUSTIFICATIVO FROM VINTEGRAZIONE_SINGOLA_DI_DOMANDA WHERE 1=1'';
	IF (@IdSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_SPESA = @IdSpesaequalthis)''; set @lensql=@lensql+len(@IdSpesaequalthis);end;
	IF (@SingolaIntegrazioneCompletataIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE = @SingolaIntegrazioneCompletataIstruttoreequalthis)''; set @lensql=@lensql+len(@SingolaIntegrazioneCompletataIstruttoreequalthis);end;
	IF (@SingolaIntegrazioneCompletataBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO = @SingolaIntegrazioneCompletataBeneficiarioequalthis)''; set @lensql=@lensql+len(@SingolaIntegrazioneCompletataBeneficiarioequalthis);end;
	IF (@IntegrazioneCompletaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (INTEGRAZIONE_COMPLETA = @IntegrazioneCompletaequalthis)''; set @lensql=@lensql+len(@IntegrazioneCompletaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdSpesaequalthis INT, @SingolaIntegrazioneCompletataIstruttoreequalthis BIT, @SingolaIntegrazioneCompletataBeneficiarioequalthis BIT, @IntegrazioneCompletaequalthis BIT'',@IdSpesaequalthis , @SingolaIntegrazioneCompletataIstruttoreequalthis , @SingolaIntegrazioneCompletataBeneficiarioequalthis , @IntegrazioneCompletaequalthis ;
	else
		SELECT ID_SINGOLA_INTEGRAZIONE, ID_INTEGRAZIONE_DOMANDA, COD_TIPO_INTEGRAZIONE, DATA_INSERIMENTO, DATA_MODIFICA, CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE, NOTE_INTEGRAZIONE_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE, DATA_CONCLUSIONE_ISTRUTTORE, SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE, CF_BENEFICIARIO_SINGOLA_INTEGRAZIONE, NOTE_INTEGRAZIONE_BENEFICIARIO, DATA_RILASCIO_INTEGRAZIONE_BENEFICIARIO, DATA_CONCLUSIONE_BENEFICIARIO, SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO, ID_DOMANDA_PAGAMENTO, DATA_INSERIMENTO_INTEGRAZIONE, DATA_MODIFICA_INTEGRAZIONE, ISTANZA_DOMANDA_PAGAMENTO, INTEGRAZIONE_COMPLETA, NOTE_INTEGRAZIONE_DOMANDA, CF_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_DOMANDA, SEGNATURA_ISTRUTTORE, CF_BENFICIARIO, SEGNATURA_BENEFICIARIO, DATA_CONCLUSIONE_INTEGRAZIONE, DESCRIZIONE_TIPO_INTEGRAZIONE, ID_SPESA, ID_GIUSTIFICATIVO
		FROM VINTEGRAZIONE_SINGOLA_DI_DOMANDA
		WHERE 
			((@IdSpesaequalthis IS NULL) OR ID_SPESA = @IdSpesaequalthis) AND 
			((@SingolaIntegrazioneCompletataIstruttoreequalthis IS NULL) OR SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE = @SingolaIntegrazioneCompletataIstruttoreequalthis) AND 
			((@SingolaIntegrazioneCompletataBeneficiarioequalthis IS NULL) OR SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO = @SingolaIntegrazioneCompletataBeneficiarioequalthis) AND 
			((@IntegrazioneCompletaequalthis IS NULL) OR INTEGRAZIONE_COMPLETA = @IntegrazioneCompletaequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIntegrazioneSingolaDiDomandaFindGetbyidspesa';

