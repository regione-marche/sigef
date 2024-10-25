CREATE PROCEDURE [dbo].[ZDichiarazioniXDomandaInsert]
(
	@IdDichiarazione INT, 
	@IdDomanda INT, 
	@Ordine INT, 
	@Obbligatorio BIT
)
AS
	INSERT INTO DICHIARAZIONI_X_DOMANDA
	(
		ID_DICHIARAZIONE, 
		ID_DOMANDA, 
		ORDINE, 
		OBBLIGATORIO
	)
	VALUES
	(
		@IdDichiarazione, 
		@IdDomanda, 
		@Ordine, 
		@Obbligatorio
	)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZDichiarazioniXDomandaInsert]
(
	@IdDichiarazione INT, 
	@IdDomanda INT, 
	@Ordine INT, 
	@Obbligatorio BIT
)
AS
	INSERT INTO DICHIARAZIONI_X_DOMANDA
	(
		ID_DICHIARAZIONE, 
		ID_DOMANDA, 
		ORDINE, 
		OBBLIGATORIO
	)
	VALUES
	(
		@IdDichiarazione, 
		@IdDomanda, 
		@Ordine, 
		@Obbligatorio
	)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDichiarazioniXDomandaInsert';

