CREATE PROCEDURE [dbo].[ZDichiarazioniXDomandaDelete]
(
	@IdDichiarazione INT, 
	@IdDomanda INT
)
AS
	DELETE DICHIARAZIONI_X_DOMANDA
	WHERE 
		(ID_DICHIARAZIONE = @IdDichiarazione) AND 
		(ID_DOMANDA = @IdDomanda)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZDichiarazioniXDomandaDelete]
(
	@IdDichiarazione INT, 
	@IdDomanda INT
)
AS
	DELETE DICHIARAZIONI_X_DOMANDA
	WHERE 
		(ID_DICHIARAZIONE = @IdDichiarazione) AND 
		(ID_DOMANDA = @IdDomanda)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDichiarazioniXDomandaDelete';

