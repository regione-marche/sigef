CREATE PROCEDURE [dbo].[ZDichiarazioniXDomandaUpdate]
(
	@IdDichiarazione INT, 
	@IdDomanda INT, 
	@Ordine INT, 
	@Obbligatorio BIT
)
AS
	UPDATE DICHIARAZIONI_X_DOMANDA
	SET
		ORDINE = @Ordine, 
		OBBLIGATORIO = @Obbligatorio
	WHERE 
		(ID_DICHIARAZIONE = @IdDichiarazione) AND 
		(ID_DOMANDA = @IdDomanda)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZDichiarazioniXDomandaUpdate]
(
	@IdDichiarazione INT, 
	@IdDomanda INT, 
	@Ordine INT, 
	@Obbligatorio BIT
)
AS
	UPDATE DICHIARAZIONI_X_DOMANDA
	SET
		ORDINE = @Ordine, 
		OBBLIGATORIO = @Obbligatorio
	WHERE 
		(ID_DICHIARAZIONE = @IdDichiarazione) AND 
		(ID_DOMANDA = @IdDomanda)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDichiarazioniXDomandaUpdate';

