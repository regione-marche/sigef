CREATE PROCEDURE [dbo].[ZControlliLocoLottoFindFind]
(
	@IdLottoequalthis INT, 
	@IdProgrammazioneequalthis INT, 
	@ControlloConclusoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_LOTTO, DATA_CREAZIONE, DATA_MODIFICA, OPERATORE, NUMERO_ESTRAZIONI, CONTROLLO_CONCLUSO, SEGNATURA, DATA_ESTRAZIONE, ID_PROGRAMMAZIONE, NOMINATIVO, DOMANDE_ASSEGNATE, DOMANDE_ESTRATTE, PROGRAMMAZIONE FROM vCONTROLLI_LOCO_LOTTO WHERE 1=1';
	IF (@IdLottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOTTO = @IdLottoequalthis)'; set @lensql=@lensql+len(@IdLottoequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@ControlloConclusoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTROLLO_CONCLUSO = @ControlloConclusoequalthis)'; set @lensql=@lensql+len(@ControlloConclusoequalthis);end;
	set @sql = @sql + 'ORDER BY ID_LOTTO DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdLottoequalthis INT, @IdProgrammazioneequalthis INT, @ControlloConclusoequalthis BIT',@IdLottoequalthis , @IdProgrammazioneequalthis , @ControlloConclusoequalthis ;
	else
		SELECT ID_LOTTO, DATA_CREAZIONE, DATA_MODIFICA, OPERATORE, NUMERO_ESTRAZIONI, CONTROLLO_CONCLUSO, SEGNATURA, DATA_ESTRAZIONE, ID_PROGRAMMAZIONE, NOMINATIVO, DOMANDE_ASSEGNATE, DOMANDE_ESTRATTE, PROGRAMMAZIONE
		FROM vCONTROLLI_LOCO_LOTTO
		WHERE 
			((@IdLottoequalthis IS NULL) OR ID_LOTTO = @IdLottoequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@ControlloConclusoequalthis IS NULL) OR CONTROLLO_CONCLUSO = @ControlloConclusoequalthis)
		ORDER BY ID_LOTTO DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliLocoLottoFindFind';

