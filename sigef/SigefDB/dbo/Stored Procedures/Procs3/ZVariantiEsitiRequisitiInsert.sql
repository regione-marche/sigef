CREATE PROCEDURE [dbo].[ZVariantiEsitiRequisitiInsert]
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
	SET @EscludiDaComunicazione = ISNULL(@EscludiDaComunicazione,((0)))
	INSERT INTO VARIANTI_ESITI_REQUISITI
	(
		ID_VARIANTE, 
		ID_REQUISITO, 
		COD_ESITO, 
		DATA, 
		CF_OPERATORE, 
		COD_ESITO_ISTRUTTORE, 
		DATA_VALUTAZIONE, 
		ISTRUTTORE, 
		NOTE, 
		ESCLUDI_DA_COMUNICAZIONE
	)
	VALUES
	(
		@IdVariante, 
		@IdRequisito, 
		@CodEsito, 
		@Data, 
		@CfOperatore, 
		@CodEsitoIstruttore, 
		@DataValutazione, 
		@Istruttore, 
		@Note, 
		@EscludiDaComunicazione
	)
	SELECT @EscludiDaComunicazione AS ESCLUDI_DA_COMUNICAZIONE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiEsitiRequisitiInsert';

