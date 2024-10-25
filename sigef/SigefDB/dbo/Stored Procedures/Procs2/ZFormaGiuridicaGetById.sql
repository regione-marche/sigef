CREATE PROCEDURE [dbo].[ZFormaGiuridicaGetById]
(
	@CodIstat VARCHAR(10)
)
AS
	SELECT *
	FROM FORMA_GIURIDICA
	WHERE 
		(COD_ISTAT = @CodIstat)
