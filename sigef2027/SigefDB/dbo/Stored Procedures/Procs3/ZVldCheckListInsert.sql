CREATE PROCEDURE [dbo].[ZVldCheckListInsert]
(
	@Descrizione VARCHAR(255), 
	@CodTipoDpagamento VARCHAR(255), 
	@Tpappalto VARCHAR(255), 
	@DataModifica DATETIME, 
	@Operatore INT
)
AS
	INSERT INTO VLD_CHECK_LIST
	(
		DESCRIZIONE, 
		COD_TIPO_DPAGAMENTO, 
		TPAPPALTO, 
		DATA_MODIFICA, 
		OPERATORE
	)
	VALUES
	(
		@Descrizione, 
		@CodTipoDpagamento, 
		@Tpappalto, 
		@DataModifica, 
		@Operatore
	)
	SELECT SCOPE_IDENTITY() AS ID


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVldCheckListInsert';

