CREATE PROCEDURE [dbo].[ZPagamentiRichiestiFemGetById]
(
	@IdPagamentoRichiestoFem INT
)
AS
	SELECT *
	FROM VPAGAMENTI_RICHIESTI_FEM
	WHERE 
		(ID_PAGAMENTO_RICHIESTO_FEM = @IdPagamentoRichiestoFem)

GO