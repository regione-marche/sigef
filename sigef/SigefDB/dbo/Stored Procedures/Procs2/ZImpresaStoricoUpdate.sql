CREATE PROCEDURE [dbo].[ZImpresaStoricoUpdate]
(
	@IdStoricoImpresa INT, 
	@IdImpresa INT, 
	@DataInizioValidita DATETIME, 
	@DataFineValidita DATETIME, 
	@RagioneSociale VARCHAR(255), 
	@CodiceInps VARCHAR(255), 
	@CodFormaGiuridica VARCHAR(255), 
	@IdDimensione INT, 
	@RegistroImpreseNumero VARCHAR(255), 
	@ReaNumero VARCHAR(255), 
	@ReaAnno INT, 
	@CodClassificazioneUma VARCHAR(255), 
	@Attiva BIT, 
	@DataCessazione DATETIME, 
	@SegnaturaCessazione VARCHAR(255), 
	@CodTipoCessazione VARCHAR(255), 
	@CodAteco2007 VARCHAR(255)
)
AS
	UPDATE IMPRESA_STORICO
	SET
		ID_IMPRESA = @IdImpresa, 
		DATA_INIZIO_VALIDITA = @DataInizioValidita, 
		DATA_FINE_VALIDITA = @DataFineValidita, 
		RAGIONE_SOCIALE = @RagioneSociale, 
		CODICE_INPS = @CodiceInps, 
		COD_FORMA_GIURIDICA = @CodFormaGiuridica, 
		ID_DIMENSIONE = @IdDimensione, 
		REGISTRO_IMPRESE_NUMERO = @RegistroImpreseNumero, 
		REA_NUMERO = @ReaNumero, 
		REA_ANNO = @ReaAnno, 
		COD_CLASSIFICAZIONE_UMA = @CodClassificazioneUma, 
		ATTIVA = @Attiva, 
		DATA_CESSAZIONE = @DataCessazione, 
		SEGNATURA_CESSAZIONE = @SegnaturaCessazione, 
		COD_TIPO_CESSAZIONE = @CodTipoCessazione, 
		COD_ATECO2007 = @CodAteco2007
	WHERE 
		(ID_STORICO_IMPRESA = @IdStoricoImpresa)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZImpresaStoricoUpdate]
(
	@IdStoricoImpresa INT, 
	@IdImpresa INT, 
	@DataInizioValidita DATETIME, 
	@DataFineValidita DATETIME, 
	@RagioneSociale VARCHAR(255), 
	@CodiceInps VARCHAR(255), 
	@CodFormaGiuridica VARCHAR(255), 
	@IdDimensione INT, 
	@RegistroImpreseNumero VARCHAR(255), 
	@ReaNumero VARCHAR(255), 
	@ReaAnno INT, 
	@CodClassificazioneUma VARCHAR(255), 
	@Attiva BIT, 
	@DataCessazione DATETIME, 
	@SegnaturaCessazione VARCHAR(255), 
	@CodTipoCessazione VARCHAR(255), 
	@CodAteco2007 VARCHAR(255)
)
AS
	UPDATE IMPRESA_STORICO
	SET
		ID_IMPRESA = @IdImpresa, 
		DATA_INIZIO_VALIDITA = @DataInizioValidita, 
		DATA_FINE_VALIDITA = @DataFineValidita, 
		RAGIONE_SOCIALE = @RagioneSociale, 
		CODICE_INPS = @CodiceInps, 
		COD_FORMA_GIURIDICA = @CodFormaGiuridica, 
		ID_DIMENSIONE = @IdDimensione, 
		REGISTRO_IMPRESE_NUMERO = @RegistroImpreseNumero, 
		REA_NUMERO = @ReaNumero, 
		REA_ANNO = @ReaAnno, 
		COD_CLASSIFICAZIONE_UMA = @CodClassificazioneUma, 
		ATTIVA = @Attiva, 
		DATA_CESSAZIONE = @DataCessazione, 
		SEGNATURA_CESSAZIONE = @SegnaturaCessazione, 
		COD_TIPO_CESSAZIONE = @CodTipoCessazione, 
		COD_ATECO2007 = @CodAteco2007
	WHERE 
		(ID_STORICO_IMPRESA = @IdStoricoImpresa)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaStoricoUpdate';

