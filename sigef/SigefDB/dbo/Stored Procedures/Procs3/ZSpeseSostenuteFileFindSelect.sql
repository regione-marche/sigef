CREATE PROCEDURE [dbo].[ZSpeseSostenuteFileFindSelect]
(
	@IdFileSpeseSostenuteequalthis INT, 
	@IdSpesaequalthis INT, 
	@DataInserimentoequalthis DATETIME, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@InIntegrazioneequalthis BIT, 
	@Descrizioneequalthis VARCHAR(255), 
	@IdFileequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_FILE_SPESE_SOSTENUTE, ID_SPESA, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, IN_INTEGRAZIONE, DESCRIZIONE, ID_FILE, NOME_FILE, NOME_COMPLETO FROM VSPESE_SOSTENUTE_FILE WHERE 1=1';
	IF (@IdFileSpeseSostenuteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE_SPESE_SOSTENUTE = @IdFileSpeseSostenuteequalthis)'; set @lensql=@lensql+len(@IdFileSpeseSostenuteequalthis);end;
	IF (@IdSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SPESA = @IdSpesaequalthis)'; set @lensql=@lensql+len(@IdSpesaequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_INSERIMENTO = @CfInserimentoequalthis)'; set @lensql=@lensql+len(@CfInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_MODIFICA = @CfModificaequalthis)'; set @lensql=@lensql+len(@CfModificaequalthis);end;
	IF (@InIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IN_INTEGRAZIONE = @InIntegrazioneequalthis)'; set @lensql=@lensql+len(@InIntegrazioneequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE = @IdFileequalthis)'; set @lensql=@lensql+len(@IdFileequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdFileSpeseSostenuteequalthis INT, @IdSpesaequalthis INT, @DataInserimentoequalthis DATETIME, @CfInserimentoequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @CfModificaequalthis VARCHAR(255), @InIntegrazioneequalthis BIT, @Descrizioneequalthis VARCHAR(255), @IdFileequalthis INT',@IdFileSpeseSostenuteequalthis , @IdSpesaequalthis , @DataInserimentoequalthis , @CfInserimentoequalthis , @DataModificaequalthis , @CfModificaequalthis , @InIntegrazioneequalthis , @Descrizioneequalthis , @IdFileequalthis ;
	else
		SELECT ID_FILE_SPESE_SOSTENUTE, ID_SPESA, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, IN_INTEGRAZIONE, DESCRIZIONE, ID_FILE, NOME_FILE, NOME_COMPLETO
		FROM VSPESE_SOSTENUTE_FILE
		WHERE 
			((@IdFileSpeseSostenuteequalthis IS NULL) OR ID_FILE_SPESE_SOSTENUTE = @IdFileSpeseSostenuteequalthis) AND 
			((@IdSpesaequalthis IS NULL) OR ID_SPESA = @IdSpesaequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CfInserimentoequalthis IS NULL) OR CF_INSERIMENTO = @CfInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@CfModificaequalthis IS NULL) OR CF_MODIFICA = @CfModificaequalthis) AND 
			((@InIntegrazioneequalthis IS NULL) OR IN_INTEGRAZIONE = @InIntegrazioneequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSpeseSostenuteFileFindSelect';

