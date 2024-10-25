CREATE PROCEDURE [dbo].[ZAggregazioneFindSelect]
(
	@Idequalthis INT, 
	@Denominazioneequalthis VARCHAR(2000), 
	@CodTipoAggregazioneequalthis VARCHAR(255), 
	@DataInizioequalthis DATETIME, 
	@OperatoreInizioequalthis INT, 
	@Attivoequalthis BIT, 
	@DataFineequalthis DATETIME, 
	@OperatoreFineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, DENOMINAZIONE, COD_TIPO_AGGREGAZIONE, DATA_INIZIO, ATTIVO, DATA_FINE, OPERATORE_INIZIO, OPERATORE_FINE, DESCRIZIONE_TIPO_AGGREGAZIONE, ID_IMPRESA, IMPRESA_AGGREGAZIONE_ATTIVA FROM vAGGREGAZIONE WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@Denominazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DENOMINAZIONE = @Denominazioneequalthis)'; set @lensql=@lensql+len(@Denominazioneequalthis);end;
	IF (@CodTipoAggregazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_AGGREGAZIONE = @CodTipoAggregazioneequalthis)'; set @lensql=@lensql+len(@CodTipoAggregazioneequalthis);end;
	IF (@DataInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO = @DataInizioequalthis)'; set @lensql=@lensql+len(@DataInizioequalthis);end;
	IF (@OperatoreInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_INIZIO = @OperatoreInizioequalthis)'; set @lensql=@lensql+len(@OperatoreInizioequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@DataFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE = @DataFineequalthis)'; set @lensql=@lensql+len(@DataFineequalthis);end;
	IF (@OperatoreFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_FINE = @OperatoreFineequalthis)'; set @lensql=@lensql+len(@OperatoreFineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @Denominazioneequalthis VARCHAR(2000), @CodTipoAggregazioneequalthis VARCHAR(255), @DataInizioequalthis DATETIME, @OperatoreInizioequalthis INT, @Attivoequalthis BIT, @DataFineequalthis DATETIME, @OperatoreFineequalthis INT',@Idequalthis , @Denominazioneequalthis , @CodTipoAggregazioneequalthis , @DataInizioequalthis , @OperatoreInizioequalthis , @Attivoequalthis , @DataFineequalthis , @OperatoreFineequalthis ;
	else
		SELECT ID, DENOMINAZIONE, COD_TIPO_AGGREGAZIONE, DATA_INIZIO, ATTIVO, DATA_FINE, OPERATORE_INIZIO, OPERATORE_FINE, DESCRIZIONE_TIPO_AGGREGAZIONE, ID_IMPRESA, IMPRESA_AGGREGAZIONE_ATTIVA
		FROM vAGGREGAZIONE
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@Denominazioneequalthis IS NULL) OR DENOMINAZIONE = @Denominazioneequalthis) AND 
			((@CodTipoAggregazioneequalthis IS NULL) OR COD_TIPO_AGGREGAZIONE = @CodTipoAggregazioneequalthis) AND 
			((@DataInizioequalthis IS NULL) OR DATA_INIZIO = @DataInizioequalthis) AND 
			((@OperatoreInizioequalthis IS NULL) OR OPERATORE_INIZIO = @OperatoreInizioequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@DataFineequalthis IS NULL) OR DATA_FINE = @DataFineequalthis) AND 
			((@OperatoreFineequalthis IS NULL) OR OPERATORE_FINE = @OperatoreFineequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAggregazioneFindSelect';

