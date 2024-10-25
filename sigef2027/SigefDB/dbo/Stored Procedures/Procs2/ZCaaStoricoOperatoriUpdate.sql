CREATE PROCEDURE [dbo].[ZCaaStoricoOperatoriUpdate]
(
	@Id INT, 
	@IdOperatore INT, 
	@MandatoPsr BIT, 
	@MandatoUma BIT, 
	@Responsabile BIT, 
	@CodStato VARCHAR(255), 
	@Data DATETIME, 
	@Operatore INT
)
AS
	UPDATE CAA_STORICO_OPERATORI
	SET
		ID_OPERATORE = @IdOperatore, 
		MANDATO_PSR = @MandatoPsr, 
		MANDATO_UMA = @MandatoUma, 
		RESPONSABILE = @Responsabile, 
		COD_STATO = @CodStato, 
		DATA = @Data, 
		OPERATORE = @Operatore
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCaaStoricoOperatoriUpdate';

