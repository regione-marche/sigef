CREATE PROCEDURE [dbo].[ZSanzioniRecuperoFindSelect]
(
	@IdSanzioneRecuperoequalthis INT, 
	@DataInserimentoequalthis DATETIME, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@IdRegistroRecuperoequalthis INT, 
	@IdCategoriaSanzioneequalthis INT, 
	@IdTipoSanzioneequalthis INT, 
	@ImportoSanzioneequalthis DECIMAL(15,2), 
	@DataConclusioneequalthis DATETIME, 
	@IdStatoSanzioneequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SANZIONE_RECUPERO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_REGISTRO_RECUPERO, ID_CATEGORIA_SANZIONE, ID_TIPO_SANZIONE, IMPORTO_SANZIONE, DATA_CONCLUSIONE, ID_STATO_SANZIONE, ID_REGISTRO_IRREGOLARITA FROM VSANZIONI_RECUPERO WHERE 1=1';
	IF (@IdSanzioneRecuperoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SANZIONE_RECUPERO = @IdSanzioneRecuperoequalthis)'; set @lensql=@lensql+len(@IdSanzioneRecuperoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_INSERIMENTO = @CfInserimentoequalthis)'; set @lensql=@lensql+len(@CfInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_MODIFICA = @CfModificaequalthis)'; set @lensql=@lensql+len(@CfModificaequalthis);end;
	IF (@IdRegistroRecuperoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REGISTRO_RECUPERO = @IdRegistroRecuperoequalthis)'; set @lensql=@lensql+len(@IdRegistroRecuperoequalthis);end;
	IF (@IdCategoriaSanzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CATEGORIA_SANZIONE = @IdCategoriaSanzioneequalthis)'; set @lensql=@lensql+len(@IdCategoriaSanzioneequalthis);end;
	IF (@IdTipoSanzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_TIPO_SANZIONE = @IdTipoSanzioneequalthis)'; set @lensql=@lensql+len(@IdTipoSanzioneequalthis);end;
	IF (@ImportoSanzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_SANZIONE = @ImportoSanzioneequalthis)'; set @lensql=@lensql+len(@ImportoSanzioneequalthis);end;
	IF (@DataConclusioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CONCLUSIONE = @DataConclusioneequalthis)'; set @lensql=@lensql+len(@DataConclusioneequalthis);end;
	IF (@IdStatoSanzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STATO_SANZIONE = @IdStatoSanzioneequalthis)'; set @lensql=@lensql+len(@IdStatoSanzioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdSanzioneRecuperoequalthis INT, @DataInserimentoequalthis DATETIME, @CfInserimentoequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @CfModificaequalthis VARCHAR(255), @IdRegistroRecuperoequalthis INT, @IdCategoriaSanzioneequalthis INT, @IdTipoSanzioneequalthis INT, @ImportoSanzioneequalthis DECIMAL(15,2), @DataConclusioneequalthis DATETIME, @IdStatoSanzioneequalthis INT',@IdSanzioneRecuperoequalthis , @DataInserimentoequalthis , @CfInserimentoequalthis , @DataModificaequalthis , @CfModificaequalthis , @IdRegistroRecuperoequalthis , @IdCategoriaSanzioneequalthis , @IdTipoSanzioneequalthis , @ImportoSanzioneequalthis , @DataConclusioneequalthis , @IdStatoSanzioneequalthis ;
	else
		SELECT ID_SANZIONE_RECUPERO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_REGISTRO_RECUPERO, ID_CATEGORIA_SANZIONE, ID_TIPO_SANZIONE, IMPORTO_SANZIONE, DATA_CONCLUSIONE, ID_STATO_SANZIONE, ID_REGISTRO_IRREGOLARITA
		FROM VSANZIONI_RECUPERO
		WHERE 
			((@IdSanzioneRecuperoequalthis IS NULL) OR ID_SANZIONE_RECUPERO = @IdSanzioneRecuperoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CfInserimentoequalthis IS NULL) OR CF_INSERIMENTO = @CfInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@CfModificaequalthis IS NULL) OR CF_MODIFICA = @CfModificaequalthis) AND 
			((@IdRegistroRecuperoequalthis IS NULL) OR ID_REGISTRO_RECUPERO = @IdRegistroRecuperoequalthis) AND 
			((@IdCategoriaSanzioneequalthis IS NULL) OR ID_CATEGORIA_SANZIONE = @IdCategoriaSanzioneequalthis) AND 
			((@IdTipoSanzioneequalthis IS NULL) OR ID_TIPO_SANZIONE = @IdTipoSanzioneequalthis) AND 
			((@ImportoSanzioneequalthis IS NULL) OR IMPORTO_SANZIONE = @ImportoSanzioneequalthis) AND 
			((@DataConclusioneequalthis IS NULL) OR DATA_CONCLUSIONE = @DataConclusioneequalthis) AND 
			((@IdStatoSanzioneequalthis IS NULL) OR ID_STATO_SANZIONE = @IdStatoSanzioneequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSanzioniRecuperoFindSelect';

