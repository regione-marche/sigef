﻿CREATE PROCEDURE [dbo].[ZBandoRequisitiPagamentoDelete]
(
	@IdBando INT, 
	@CodTipo CHAR(3), 
	@IdRequisito INT
)
AS
	DELETE BANDO_REQUISITI_PAGAMENTO
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(COD_TIPO = @CodTipo) AND 
		(ID_REQUISITO = @IdRequisito)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoRequisitiPagamentoDelete';
