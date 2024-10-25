CREATE PROCEDURE [dbo].[ZBancheIstitutiFindSelect]
(
	@Abiequalthis VARCHAR(255), 
	@Denominazioneequalthis VARCHAR(255), 
	@DataInizioValiditaequalthis DATETIME, 
	@DataFineValiditaequalthis DATETIME, 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ABI, DENOMINAZIONE, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ATTIVO FROM BANCHE_ISTITUTI WHERE 1=1';
	IF (@Abiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ABI = @Abiequalthis)'; set @lensql=@lensql+len(@Abiequalthis);end;
	IF (@Denominazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DENOMINAZIONE = @Denominazioneequalthis)'; set @lensql=@lensql+len(@Denominazioneequalthis);end;
	IF (@DataInizioValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis)'; set @lensql=@lensql+len(@DataInizioValiditaequalthis);end;
	IF (@DataFineValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE_VALIDITA = @DataFineValiditaequalthis)'; set @lensql=@lensql+len(@DataFineValiditaequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Abiequalthis VARCHAR(255), @Denominazioneequalthis VARCHAR(255), @DataInizioValiditaequalthis DATETIME, @DataFineValiditaequalthis DATETIME, @Attivoequalthis BIT',@Abiequalthis , @Denominazioneequalthis , @DataInizioValiditaequalthis , @DataFineValiditaequalthis , @Attivoequalthis ;
	else
		SELECT ABI, DENOMINAZIONE, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ATTIVO
		FROM BANCHE_ISTITUTI
		WHERE 
			((@Abiequalthis IS NULL) OR ABI = @Abiequalthis) AND 
			((@Denominazioneequalthis IS NULL) OR DENOMINAZIONE = @Denominazioneequalthis) AND 
			((@DataInizioValiditaequalthis IS NULL) OR DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis) AND 
			((@DataFineValiditaequalthis IS NULL) OR DATA_FINE_VALIDITA = @DataFineValiditaequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBancheIstitutiFindSelect';

