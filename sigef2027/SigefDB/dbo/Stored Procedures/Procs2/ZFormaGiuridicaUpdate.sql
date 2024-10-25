CREATE PROCEDURE [dbo].[ZFormaGiuridicaUpdate]
(
	@CodIstat VARCHAR(10), 
	@Descrizione VARCHAR(255), 
	@Foglia BIT
)
AS
	UPDATE FORMA_GIURIDICA
	SET
		DESCRIZIONE = @Descrizione, 
		FOGLIA = @Foglia
	WHERE 
		(COD_ISTAT = @CodIstat)
