CREATE PROCEDURE [dbo].[ZModellodomandaGetById]
(
	@IdDomanda INT
)
AS
	SELECT *
	FROM MODELLO_DOMANDA
	WHERE 
		(ID_DOMANDA = @IdDomanda)
