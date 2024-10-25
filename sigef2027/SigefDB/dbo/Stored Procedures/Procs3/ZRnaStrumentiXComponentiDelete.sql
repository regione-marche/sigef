CREATE PROCEDURE [dbo].[ZRnaStrumentiXComponentiDelete]
(
	@IdStrumentiXComponenti INT
)
AS
	DELETE RNA_STRUMENTI_X_COMPONENTI
	WHERE 
		(ID_STRUMENTI_X_COMPONENTI = @IdStrumentiXComponenti)