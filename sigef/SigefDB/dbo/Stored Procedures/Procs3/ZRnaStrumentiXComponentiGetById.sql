CREATE PROCEDURE [dbo].[ZRnaStrumentiXComponentiGetById]
(
	@IdStrumentiXComponenti INT
)
AS
	SELECT *
	FROM RNA_STRUMENTI_X_COMPONENTI
	WHERE 
		(ID_STRUMENTI_X_COMPONENTI = @IdStrumentiXComponenti)