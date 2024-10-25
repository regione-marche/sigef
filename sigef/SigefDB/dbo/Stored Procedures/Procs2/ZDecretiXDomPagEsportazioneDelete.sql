CREATE PROCEDURE [dbo].[ZDecretiXDomPagEsportazioneDelete]
(
	@IdDecretiXDomPagEsportazione INT
)
AS
	DELETE DECRETI_X_DOM_PAG_ESPORTAZIONE
	WHERE 
		(ID_DECRETI_X_DOM_PAG_ESPORTAZIONE = @IdDecretiXDomPagEsportazione)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDecretiXDomPagEsportazioneDelete';

