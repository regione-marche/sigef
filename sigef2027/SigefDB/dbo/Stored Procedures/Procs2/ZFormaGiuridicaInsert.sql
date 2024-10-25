CREATE PROCEDURE [dbo].[ZFormaGiuridicaInsert]
(
	@CodIstat VARCHAR(10), 
	@Descrizione VARCHAR(255), 
	@Foglia BIT
)
AS
	INSERT INTO FORMA_GIURIDICA
	(
		COD_ISTAT, 
		DESCRIZIONE, 
		FOGLIA
	)
	VALUES
	(
		@CodIstat, 
		@Descrizione, 
		@Foglia
	)
