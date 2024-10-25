CREATE PROCEDURE [dbo].[ZBandoTipoVariantiInsert]
(
	@IdBando INT, 
	@CodTipo CHAR(2), 
	@NumeroMassimo INT
)
AS
	INSERT INTO BANDO_TIPO_VARIANTI
	(
		ID_BANDO, 
		COD_TIPO, 
		NUMERO_MASSIMO
	)
	VALUES
	(
		@IdBando, 
		@CodTipo, 
		@NumeroMassimo
	)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoTipoVariantiInsert';

