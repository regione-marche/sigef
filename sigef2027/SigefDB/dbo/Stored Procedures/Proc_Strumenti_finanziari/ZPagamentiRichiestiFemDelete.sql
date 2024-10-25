CREATE PROCEDURE [dbo].[ZPagamentiRichiestiFemDelete]
(
	@IdPagamentoRichiestoFem INT
)
AS
	DELETE PAGAMENTI_RICHIESTI_FEM
	WHERE 
		(ID_PAGAMENTO_RICHIESTO_FEM = @IdPagamentoRichiestoFem)

GO