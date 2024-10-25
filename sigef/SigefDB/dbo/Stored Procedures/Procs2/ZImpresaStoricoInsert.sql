CREATE PROCEDURE [dbo].[ZImpresaStoricoInsert]
(
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
	SET @DataInizioValidita = ISNULL(@DataInizioValidita,(getdate()))
	SET @Attiva = ISNULL(@Attiva,((1)))
	INSERT INTO IMPRESA_STORICO
	(
		ID_IMPRESA, 
		DATA_INIZIO_VALIDITA, 
		DATA_FINE_VALIDITA, 
		RAGIONE_SOCIALE, 
		CODICE_INPS, 
		COD_FORMA_GIURIDICA, 
		ID_DIMENSIONE, 
		REGISTRO_IMPRESE_NUMERO, 
		REA_NUMERO, 
		REA_ANNO, 
		COD_CLASSIFICAZIONE_UMA, 
		ATTIVA, 
		DATA_CESSAZIONE, 
		SEGNATURA_CESSAZIONE, 
		COD_TIPO_CESSAZIONE, 
		COD_ATECO2007
	)
	VALUES
	(
		@IdImpresa, 
		@DataInizioValidita, 
		@DataFineValidita, 
		@RagioneSociale, 
		@CodiceInps, 
		@CodFormaGiuridica, 
		@IdDimensione, 
		@RegistroImpreseNumero, 
		@ReaNumero, 
		@ReaAnno, 
		@CodClassificazioneUma, 
		@Attiva, 
		@DataCessazione, 
		@SegnaturaCessazione, 
		@CodTipoCessazione, 
		@CodAteco2007
	)
	SELECT SCOPE_IDENTITY() AS ID_STORICO_IMPRESA, @DataInizioValidita AS DATA_INIZIO_VALIDITA, @Attiva AS ATTIVA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZImpresaStoricoInsert]
(
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
	SET @DataInizioValidita = ISNULL(@DataInizioValidita,(getdate()))
	SET @Attiva = ISNULL(@Attiva,((1)))
	INSERT INTO IMPRESA_STORICO
	(
		ID_IMPRESA, 
		DATA_INIZIO_VALIDITA, 
		DATA_FINE_VALIDITA, 
		RAGIONE_SOCIALE, 
		CODICE_INPS, 
		COD_FORMA_GIURIDICA, 
		ID_DIMENSIONE, 
		REGISTRO_IMPRESE_NUMERO, 
		REA_NUMERO, 
		REA_ANNO, 
		COD_CLASSIFICAZIONE_UMA, 
		ATTIVA, 
		DATA_CESSAZIONE, 
		SEGNATURA_CESSAZIONE, 
		COD_TIPO_CESSAZIONE, 
		COD_ATECO2007
	)
	VALUES
	(
		@IdImpresa, 
		@DataInizioValidita, 
		@DataFineValidita, 
		@RagioneSociale, 
		@CodiceInps, 
		@CodFormaGiuridica, 
		@IdDimensione, 
		@RegistroImpreseNumero, 
		@ReaNumero, 
		@ReaAnno, 
		@CodClassificazioneUma, 
		@Attiva, 
		@DataCessazione, 
		@SegnaturaCessazione, 
		@CodTipoCessazione, 
		@CodAteco2007
	)
	SELECT SCOPE_IDENTITY() AS ID_STORICO_IMPRESA, @DataInizioValidita AS DATA_INIZIO_VALIDITA, @Attiva AS ATTIVA

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaStoricoInsert';

