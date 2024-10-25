CREATE PROCEDURE [dbo].[ZGiustificativiUpdate]
(
	@IdGiustificativo INT, 
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
	UPDATE GIUSTIFICATIVI
	SET
		ID_PROGETTO = @IdProgetto, 
		NUMERO = @Numero, 
		COD_TIPO = @CodTipo, 
		DATA = @Data, 
		NUMERO_DOCTRASPORTO = @NumeroDoctrasporto, 
		DATA_DOCTRASPORTO = @DataDoctrasporto, 
		IMPONIBILE = @Imponibile, 
		IVA = @Iva, 
		ALTRI_ONERI = @AltriOneri, 
		DESCRIZIONE = @Descrizione, 
		CF_FORNITORE = @CfFornitore, 
		DESCRIZIONE_FORNITORE = @DescrizioneFornitore, 
		IVA_NON_RECUPERABILE = @IvaNonRecuperabile, 
		ID_FILE = @IdFile, 
		IN_INTEGRAZIONE = @InIntegrazione, 
		ID_FILE_MODIFICATO_INTEGRAZIONE = @IdFileModificatoIntegrazione
	WHERE 
		(ID_GIUSTIFICATIVO = @IdGiustificativo)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZGiustificativiUpdate]
(
	@IdGiustificativo INT, 
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
	UPDATE GIUSTIFICATIVI
	SET
		ID_PROGETTO = @IdProgetto, 
		NUMERO = @Numero, 
		COD_TIPO = @CodTipo, 
		DATA = @Data, 
		NUMERO_DOCTRASPORTO = @NumeroDoctrasporto, 
		DATA_DOCTRASPORTO = @DataDoctrasporto, 
		IMPONIBILE = @Imponibile, 
		IVA = @Iva, 
		ALTRI_ONERI = @AltriOneri, 
		DESCRIZIONE = @Descrizione, 
		CF_FORNITORE = @CfFornitore, 
		DESCRIZIONE_FORNITORE = @DescrizioneFornitore, 
		IVA_NON_RECUPERABILE = @IvaNonRecuperabile, 
		ID_FILE = @IdFile, 
		IN_INTEGRAZIONE = @InIntegrazione, 
		ID_FILE_MODIFICATO_INTEGRAZIONE = @IdFileModificatoIntegrazione
	WHERE 
		(ID_GIUSTIFICATIVO = @IdGiustificativo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGiustificativiUpdate';

