CREATE PROCEDURE [dbo].[ZVariantiEsitiRequisitiUpdate]
(
	@IdVariante INT, 
	@IdRequisito INT, 
	@CodEsito CHAR(2), 
	@Data DATETIME, 
	@CfOperatore VARCHAR(16), 
	@CodEsitoIstruttore CHAR(2), 
	@DataValutazione DATETIME, 
	@Istruttore VARCHAR(16), 
	@Note NTEXT, 
	@EscludiDaComunicazione BIT
)
AS
	UPDATE VARIANTI_ESITI_REQUISITI
	SET
		COD_ESITO = @CodEsito, 
		DATA = @Data, 
		CF_OPERATORE = @CfOperatore, 
		COD_ESITO_ISTRUTTORE = @CodEsitoIstruttore, 
		DATA_VALUTAZIONE = @DataValutazione, 
		ISTRUTTORE = @Istruttore, 
		NOTE = @Note, 
		ESCLUDI_DA_COMUNICAZIONE = @EscludiDaComunicazione
	WHERE 
		(ID_VARIANTE = @IdVariante) AND 
		(ID_REQUISITO = @IdRequisito)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiEsitiRequisitiUpdate';

