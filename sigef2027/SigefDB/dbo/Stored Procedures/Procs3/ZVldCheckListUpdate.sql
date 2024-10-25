CREATE PROCEDURE [dbo].[ZVldCheckListUpdate]
(
	@Id INT, 
	@Descrizione VARCHAR(255), 
	@CodTipoDpagamento VARCHAR(255), 
	@Tpappalto VARCHAR(255), 
	@DataModifica DATETIME, 
	@Operatore INT
)
AS
	SET @DataModifica=getdate()
	UPDATE VLD_CHECK_LIST
	SET
		DESCRIZIONE = @Descrizione, 
		COD_TIPO_DPAGAMENTO = @CodTipoDpagamento, 
		TPAPPALTO = @Tpappalto, 
		DATA_MODIFICA = @DataModifica, 
		OPERATORE = @Operatore
	WHERE 
		(ID = @Id)
	SELECT @DataModifica;


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVldCheckListUpdate';

