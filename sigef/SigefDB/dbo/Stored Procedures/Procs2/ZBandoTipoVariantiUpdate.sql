CREATE PROCEDURE [dbo].[ZBandoTipoVariantiUpdate]
(
	@IdBando INT, 
	@CodTipo CHAR(2), 
	@NumeroMassimo INT
)
AS
	UPDATE BANDO_TIPO_VARIANTI
	SET
		NUMERO_MASSIMO = @NumeroMassimo
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(COD_TIPO = @CodTipo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoTipoVariantiUpdate';

