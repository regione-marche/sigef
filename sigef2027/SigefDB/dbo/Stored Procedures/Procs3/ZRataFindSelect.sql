CREATE PROCEDURE [dbo].[ZRataFindSelect]
(
	@IdRataequalthis INT, 
	@DataInserimentoequalthis DATETIME, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@IdTipoRataequalthis INT, 
	@DataRataequalthis DATETIME, 
	@DataScadenzaequalthis DATETIME, 
	@DataPagamentoequalthis DATETIME, 
	@ImportoRataequalthis DECIMAL(15,2), 
	@Pagataequalthis BIT, 
	@IdRegistroRecuperoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_RATA, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, DATA_RATA, DATA_SCADENZA, DATA_PAGAMENTO, IMPORTO_RATA, PAGATA, ID_REGISTRO_RECUPERO, ID_TIPO_RATA, DESCRIZIONE FROM VRATA WHERE 1=1';
	IF (@IdRataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RATA = @IdRataequalthis)'; set @lensql=@lensql+len(@IdRataequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_INSERIMENTO = @CfInserimentoequalthis)'; set @lensql=@lensql+len(@CfInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_MODIFICA = @CfModificaequalthis)'; set @lensql=@lensql+len(@CfModificaequalthis);end;
	IF (@IdTipoRataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_TIPO_RATA = @IdTipoRataequalthis)'; set @lensql=@lensql+len(@IdTipoRataequalthis);end;
	IF (@DataRataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_RATA = @DataRataequalthis)'; set @lensql=@lensql+len(@DataRataequalthis);end;
	IF (@DataScadenzaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SCADENZA = @DataScadenzaequalthis)'; set @lensql=@lensql+len(@DataScadenzaequalthis);end;
	IF (@DataPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_PAGAMENTO = @DataPagamentoequalthis)'; set @lensql=@lensql+len(@DataPagamentoequalthis);end;
	IF (@ImportoRataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_RATA = @ImportoRataequalthis)'; set @lensql=@lensql+len(@ImportoRataequalthis);end;
	IF (@Pagataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PAGATA = @Pagataequalthis)'; set @lensql=@lensql+len(@Pagataequalthis);end;
	IF (@IdRegistroRecuperoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REGISTRO_RECUPERO = @IdRegistroRecuperoequalthis)'; set @lensql=@lensql+len(@IdRegistroRecuperoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRataequalthis INT, @DataInserimentoequalthis DATETIME, @CfInserimentoequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @CfModificaequalthis VARCHAR(255), @IdTipoRataequalthis INT, @DataRataequalthis DATETIME, @DataScadenzaequalthis DATETIME, @DataPagamentoequalthis DATETIME, @ImportoRataequalthis DECIMAL(15,2), @Pagataequalthis BIT, @IdRegistroRecuperoequalthis INT',@IdRataequalthis , @DataInserimentoequalthis , @CfInserimentoequalthis , @DataModificaequalthis , @CfModificaequalthis , @IdTipoRataequalthis , @DataRataequalthis , @DataScadenzaequalthis , @DataPagamentoequalthis , @ImportoRataequalthis , @Pagataequalthis , @IdRegistroRecuperoequalthis ;
	else
		SELECT ID_RATA, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, DATA_RATA, DATA_SCADENZA, DATA_PAGAMENTO, IMPORTO_RATA, PAGATA, ID_REGISTRO_RECUPERO, ID_TIPO_RATA, DESCRIZIONE
		FROM VRATA
		WHERE 
			((@IdRataequalthis IS NULL) OR ID_RATA = @IdRataequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CfInserimentoequalthis IS NULL) OR CF_INSERIMENTO = @CfInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@CfModificaequalthis IS NULL) OR CF_MODIFICA = @CfModificaequalthis) AND 
			((@IdTipoRataequalthis IS NULL) OR ID_TIPO_RATA = @IdTipoRataequalthis) AND 
			((@DataRataequalthis IS NULL) OR DATA_RATA = @DataRataequalthis) AND 
			((@DataScadenzaequalthis IS NULL) OR DATA_SCADENZA = @DataScadenzaequalthis) AND 
			((@DataPagamentoequalthis IS NULL) OR DATA_PAGAMENTO = @DataPagamentoequalthis) AND 
			((@ImportoRataequalthis IS NULL) OR IMPORTO_RATA = @ImportoRataequalthis) AND 
			((@Pagataequalthis IS NULL) OR PAGATA = @Pagataequalthis) AND 
			((@IdRegistroRecuperoequalthis IS NULL) OR ID_REGISTRO_RECUPERO = @IdRegistroRecuperoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRataFindSelect';

