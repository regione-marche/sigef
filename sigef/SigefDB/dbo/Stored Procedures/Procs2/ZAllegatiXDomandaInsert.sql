CREATE PROCEDURE [dbo].[ZAllegatiXDomandaInsert]
(
	@IdAllegato INT, 
	@IdDomanda INT, 
	@Ordine INT
)
AS
	INSERT INTO ALLEGATI_X_DOMANDA
	(
		ID_ALLEGATO, 
		ID_DOMANDA, 
		ORDINE
	)
	VALUES
	(
		@IdAllegato, 
		@IdDomanda, 
		@Ordine
	)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZAllegatiXDomandaInsert]
(
	@IdAllegato INT, 
	@IdDomanda INT, 
	@Ordine INT
)
AS
	INSERT INTO ALLEGATI_X_DOMANDA
	(
		ID_ALLEGATO, 
		ID_DOMANDA, 
		ORDINE
	)
	VALUES
	(
		@IdAllegato, 
		@IdDomanda, 
		@Ordine
	)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAllegatiXDomandaInsert';

