CREATE PROCEDURE [dbo].[ZBilancioAgricoloDelete]
(
	@IdBilancioAgricolo INT
)
AS
	DELETE BILANCIO_AGRICOLO
	WHERE 
		(ID_BILANCIO_AGRICOLO = @IdBilancioAgricolo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBilancioAgricoloDelete]
(
	@IdBilancioAgricolo INT
)
AS
	DELETE BILANCIO_AGRICOLO
	WHERE 
		(ID_BILANCIO_AGRICOLO = @IdBilancioAgricolo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBilancioAgricoloDelete';

