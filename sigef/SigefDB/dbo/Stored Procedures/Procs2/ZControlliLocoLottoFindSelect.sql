CREATE PROCEDURE [dbo].[ZControlliLocoLottoFindSelect]
(
	@IdLottoequalthis INT, 
	@DataCreazioneequalthis DATETIME, 
	@DataModificaequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(255), 
	@DataEstrazioneequalthis DATETIME, 
	@NumeroEstrazioniequalthis INT, 
	@ControlloConclusoequalthis BIT, 
	@Segnaturaequalthis VARCHAR(255), 
	@IdProgrammazioneequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_LOTTO, DATA_CREAZIONE, DATA_MODIFICA, OPERATORE, NUMERO_ESTRAZIONI, CONTROLLO_CONCLUSO, SEGNATURA, DATA_ESTRAZIONE, ID_PROGRAMMAZIONE, NOMINATIVO, DOMANDE_ASSEGNATE, DOMANDE_ESTRATTE, PROGRAMMAZIONE FROM vCONTROLLI_LOCO_LOTTO WHERE 1=1';
	IF (@IdLottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOTTO = @IdLottoequalthis)'; set @lensql=@lensql+len(@IdLottoequalthis);end;
	IF (@DataCreazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CREAZIONE = @DataCreazioneequalthis)'; set @lensql=@lensql+len(@DataCreazioneequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@DataEstrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ESTRAZIONE = @DataEstrazioneequalthis)'; set @lensql=@lensql+len(@DataEstrazioneequalthis);end;
	IF (@NumeroEstrazioniequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_ESTRAZIONI = @NumeroEstrazioniequalthis)'; set @lensql=@lensql+len(@NumeroEstrazioniequalthis);end;
	IF (@ControlloConclusoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTROLLO_CONCLUSO = @ControlloConclusoequalthis)'; set @lensql=@lensql+len(@ControlloConclusoequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdLottoequalthis INT, @DataCreazioneequalthis DATETIME, @DataModificaequalthis DATETIME, @Operatoreequalthis VARCHAR(255), @DataEstrazioneequalthis DATETIME, @NumeroEstrazioniequalthis INT, @ControlloConclusoequalthis BIT, @Segnaturaequalthis VARCHAR(255), @IdProgrammazioneequalthis INT',@IdLottoequalthis , @DataCreazioneequalthis , @DataModificaequalthis , @Operatoreequalthis , @DataEstrazioneequalthis , @NumeroEstrazioniequalthis , @ControlloConclusoequalthis , @Segnaturaequalthis , @IdProgrammazioneequalthis ;
	else
		SELECT ID_LOTTO, DATA_CREAZIONE, DATA_MODIFICA, OPERATORE, NUMERO_ESTRAZIONI, CONTROLLO_CONCLUSO, SEGNATURA, DATA_ESTRAZIONE, ID_PROGRAMMAZIONE, NOMINATIVO, DOMANDE_ASSEGNATE, DOMANDE_ESTRATTE, PROGRAMMAZIONE
		FROM vCONTROLLI_LOCO_LOTTO
		WHERE 
			((@IdLottoequalthis IS NULL) OR ID_LOTTO = @IdLottoequalthis) AND 
			((@DataCreazioneequalthis IS NULL) OR DATA_CREAZIONE = @DataCreazioneequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@DataEstrazioneequalthis IS NULL) OR DATA_ESTRAZIONE = @DataEstrazioneequalthis) AND 
			((@NumeroEstrazioniequalthis IS NULL) OR NUMERO_ESTRAZIONI = @NumeroEstrazioniequalthis) AND 
			((@ControlloConclusoequalthis IS NULL) OR CONTROLLO_CONCLUSO = @ControlloConclusoequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliLocoLottoFindSelect';

