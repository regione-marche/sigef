﻿CREATE PROCEDURE [dbo].[ZControlliParametriXDomandaDelete]
(
	@IdDomandaPagamento INT, 
	@IdParametro INT, 
	@IdLotto INT
)
AS
	DELETE CONTROLLI_PARAMETRI_X_DOMANDA
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(ID_PARAMETRO = @IdParametro) AND 
		(ID_LOTTO = @IdLotto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliParametriXDomandaDelete';
