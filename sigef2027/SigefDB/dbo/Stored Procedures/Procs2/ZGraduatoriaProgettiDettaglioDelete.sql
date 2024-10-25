CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiDettaglioDelete]
(
	@IdPriorita INT, 
	@IdProgetto INT
)
AS
	DELETE GRADUATORIA_PROGETTI_DETTAGLIO
	WHERE 
		(ID_PRIORITA = @IdPriorita) AND 
		(ID_PROGETTO = @IdProgetto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiDettaglioDelete]
(
	@IdPriorita INT, 
	@IdProgetto INT
)
AS
	DELETE GRADUATORIA_PROGETTI_DETTAGLIO
	WHERE 
		(ID_PRIORITA = @IdPriorita) AND 
		(ID_PROGETTO = @IdProgetto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGraduatoriaProgettiDettaglioDelete';

