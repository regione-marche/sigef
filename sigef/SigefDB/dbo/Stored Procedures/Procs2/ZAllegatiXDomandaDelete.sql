CREATE PROCEDURE [dbo].[ZAllegatiXDomandaDelete]
(
	@IdAllegato INT, 
	@IdDomanda INT
)
AS
	DELETE ALLEGATI_X_DOMANDA
	WHERE 
		(ID_ALLEGATO = @IdAllegato) AND 
		(ID_DOMANDA = @IdDomanda)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZAllegatiXDomandaDelete]
(
	@IdAllegato INT, 
	@IdDomanda INT
)
AS
	DELETE ALLEGATI_X_DOMANDA
	WHERE 
		(ID_ALLEGATO = @IdAllegato) AND 
		(ID_DOMANDA = @IdDomanda)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAllegatiXDomandaDelete';

