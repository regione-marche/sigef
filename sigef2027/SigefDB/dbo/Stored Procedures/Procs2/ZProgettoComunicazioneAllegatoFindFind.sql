CREATE PROCEDURE [dbo].[ZProgettoComunicazioneAllegatoFindFind]
(
	@IdComunicazioneequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdFileequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_COMUNICAZIONE, ID_PROGETTO, ID_FILE, DESCRIZIONE FROM PROGETTO_COMUNICAZIONE_ALLEGATO WHERE 1=1';
	IF (@IdComunicazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNICAZIONE = @IdComunicazioneequalthis)'; set @lensql=@lensql+len(@IdComunicazioneequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE = @IdFileequalthis)'; set @lensql=@lensql+len(@IdFileequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdComunicazioneequalthis INT, @IdProgettoequalthis INT, @IdFileequalthis INT',@IdComunicazioneequalthis , @IdProgettoequalthis , @IdFileequalthis ;
	else
		SELECT ID, ID_COMUNICAZIONE, ID_PROGETTO, ID_FILE, DESCRIZIONE
		FROM PROGETTO_COMUNICAZIONE_ALLEGATO
		WHERE 
			((@IdComunicazioneequalthis IS NULL) OR ID_COMUNICAZIONE = @IdComunicazioneequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioneAllegatoFindFind';

