CREATE PROCEDURE [dbo].[ZModellodomandaDelete]
(
	@IdDomanda INT
)
AS
	DELETE MODELLO_DOMANDA
	WHERE 
		(ID_DOMANDA = @IdDomanda)
