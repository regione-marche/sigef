CREATE PROCEDURE [dbo].[ZZprogrammazioneSanzioniFindGetbyidprogrammazione]
(
	@IdProgrammazioneequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGRAMMAZIONE, COD_SANZIONE, ATTIVA, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, ORDINE, SANZIONE_TITOLO, SANZIONE_DESCRIZIONE, OPINIZIO_NOMINATIVO, OPFINE_NOMINATIVO FROM vZProgrammazione_Sanzioni WHERE 1=1';
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	set @sql = @sql + 'ORDER BY Cod_Sanzione';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgrammazioneequalthis INT',@IdProgrammazioneequalthis ;
	else
		SELECT ID, ID_PROGRAMMAZIONE, COD_SANZIONE, ATTIVA, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, ORDINE, SANZIONE_TITOLO, SANZIONE_DESCRIZIONE, OPINIZIO_NOMINATIVO, OPFINE_NOMINATIVO
		FROM vZProgrammazione_Sanzioni
		WHERE 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)
		ORDER BY Cod_Sanzione


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZprogrammazioneSanzioniFindGetbyidprogrammazione';

