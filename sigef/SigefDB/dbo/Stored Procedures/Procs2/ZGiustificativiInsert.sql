CREATE PROCEDURE [dbo].[ZGiustificativiInsert]
(
	@IdProgetto INT, 
	@Numero VARCHAR(255), 
	@CodTipo VARCHAR(255), 
	@Data DATETIME, 
	@NumeroDoctrasporto VARCHAR(255), 
	@DataDoctrasporto DATETIME, 
	@Imponibile DECIMAL(18,2), 
	@Iva DECIMAL(18,2), 
	@AltriOneri DECIMAL(18,2), 
	@Descrizione VARCHAR(255), 
	@CfFornitore VARCHAR(255), 
	@DescrizioneFornitore VARCHAR(255), 
	@IvaNonRecuperabile BIT, 
	@IdFile INT, 
	@InIntegrazione BIT, 
	@IdFileModificatoIntegrazione BIT
)
AS
	SET @Iva = ISNULL(@Iva,((0)))
	SET @IvaNonRecuperabile = ISNULL(@IvaNonRecuperabile,((0)))
	SET @InIntegrazione = ISNULL(@InIntegrazione,((0)))
	INSERT INTO GIUSTIFICATIVI
	(
		ID_PROGETTO, 
		NUMERO, 
		COD_TIPO, 
		DATA, 
		NUMERO_DOCTRASPORTO, 
		DATA_DOCTRASPORTO, 
		IMPONIBILE, 
		IVA, 
		ALTRI_ONERI, 
		DESCRIZIONE, 
		CF_FORNITORE, 
		DESCRIZIONE_FORNITORE, 
		IVA_NON_RECUPERABILE, 
		ID_FILE, 
		IN_INTEGRAZIONE, 
		ID_FILE_MODIFICATO_INTEGRAZIONE
	)
	VALUES
	(
		@IdProgetto, 
		@Numero, 
		@CodTipo, 
		@Data, 
		@NumeroDoctrasporto, 
		@DataDoctrasporto, 
		@Imponibile, 
		@Iva, 
		@AltriOneri, 
		@Descrizione, 
		@CfFornitore, 
		@DescrizioneFornitore, 
		@IvaNonRecuperabile, 
		@IdFile, 
		@InIntegrazione, 
		@IdFileModificatoIntegrazione
	)
	SELECT SCOPE_IDENTITY() AS ID_GIUSTIFICATIVO, @Iva AS IVA, @IvaNonRecuperabile AS IVA_NON_RECUPERABILE, @InIntegrazione AS IN_INTEGRAZIONE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZGiustificativiInsert]
(
	@IdProgetto INT, 
	@Numero VARCHAR(255), 
	@CodTipo VARCHAR(255), 
	@Data DATETIME, 
	@NumeroDoctrasporto VARCHAR(255), 
	@DataDoctrasporto DATETIME, 
	@Imponibile DECIMAL(18,2), 
	@Iva DECIMAL(18,2), 
	@AltriOneri DECIMAL(18,2), 
	@Descrizione VARCHAR(255), 
	@CfFornitore VARCHAR(255), 
	@DescrizioneFornitore VARCHAR(255), 
	@IvaNonRecuperabile BIT, 
	@IdFile INT, 
	@InIntegrazione BIT, 
	@IdFileModificatoIntegrazione BIT
)
AS
	SET @Iva = ISNULL(@Iva,((0)))
	SET @IvaNonRecuperabile = ISNULL(@IvaNonRecuperabile,((0)))
	SET @InIntegrazione = ISNULL(@InIntegrazione,((0)))
	INSERT INTO GIUSTIFICATIVI
	(
		ID_PROGETTO, 
		NUMERO, 
		COD_TIPO, 
		DATA, 
		NUMERO_DOCTRASPORTO, 
		DATA_DOCTRASPORTO, 
		IMPONIBILE, 
		IVA, 
		ALTRI_ONERI, 
		DESCRIZIONE, 
		CF_FORNITORE, 
		DESCRIZIONE_FORNITORE, 
		IVA_NON_RECUPERABILE, 
		ID_FILE, 
		IN_INTEGRAZIONE, 
		ID_FILE_MODIFICATO_INTEGRAZIONE
	)
	VALUES
	(
		@IdProgetto, 
		@Numero, 
		@CodTipo, 
		@Data, 
		@NumeroDoctrasporto, 
		@DataDoctrasporto, 
		@Imponibile, 
		@Iva, 
		@AltriOneri, 
		@Descrizione, 
		@CfFornitore, 
		@DescrizioneFornitore, 
		@IvaNonRecuperabile, 
		@IdFile, 
		@InIntegrazione, 
		@IdFileModificatoIntegrazione
	)
	SELECT SCOPE_IDENTITY() AS ID_GIUSTIFICATIVO, @Iva AS IVA, @IvaNonRecuperabile AS IVA_NON_RECUPERABILE, @InIntegrazione AS IN_INTEGRAZIONE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGiustificativiInsert';

