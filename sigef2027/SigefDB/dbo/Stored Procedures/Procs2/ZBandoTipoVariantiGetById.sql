﻿CREATE PROCEDURE [dbo].[ZBandoTipoVariantiGetById]
(
	@IdBando INT, 
	@CodTipo CHAR(2)
)
AS
	SELECT *
	FROM BANDO_TIPO_VARIANTI
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(COD_TIPO = @CodTipo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoTipoVariantiGetById';
