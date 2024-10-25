CREATE PROCEDURE [dbo].[ZFormaGiuridicaDelete]
(
	@CodIstat VARCHAR(10)
)
AS
	DELETE FORMA_GIURIDICA
	WHERE 
		(COD_ISTAT = @CodIstat)
