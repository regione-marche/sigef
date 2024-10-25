CREATE PROCEDURE [dbo].[ZRnaComponentiXCodificaFindSelect]
(
	@IdComponentiXCodificaequalthis INT, 
	@IdCodificaInvestimentoequalthis INT, 
	@IdRnaProcedimentiERegolamentiequalthis INT, 
	@IdRnaObiettivoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_COMPONENTI_X_CODIFICA, ID_CODIFICA_INVESTIMENTO, ID_RNA_PROCEDIMENTI_E_REGOLAMENTI, ID_RNA_OBIETTIVO FROM RNA_COMPONENTI_X_CODIFICA WHERE 1=1';
	IF (@IdComponentiXCodificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMPONENTI_X_CODIFICA = @IdComponentiXCodificaequalthis)'; set @lensql=@lensql+len(@IdComponentiXCodificaequalthis);end;
	IF (@IdCodificaInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis)'; set @lensql=@lensql+len(@IdCodificaInvestimentoequalthis);end;
	IF (@IdRnaProcedimentiERegolamentiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RNA_PROCEDIMENTI_E_REGOLAMENTI = @IdRnaProcedimentiERegolamentiequalthis)'; set @lensql=@lensql+len(@IdRnaProcedimentiERegolamentiequalthis);end;
	IF (@IdRnaObiettivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RNA_OBIETTIVO = @IdRnaObiettivoequalthis)'; set @lensql=@lensql+len(@IdRnaObiettivoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdComponentiXCodificaequalthis INT, @IdCodificaInvestimentoequalthis INT, @IdRnaProcedimentiERegolamentiequalthis INT, @IdRnaObiettivoequalthis INT',@IdComponentiXCodificaequalthis , @IdCodificaInvestimentoequalthis , @IdRnaProcedimentiERegolamentiequalthis , @IdRnaObiettivoequalthis ;
	else
		SELECT ID_COMPONENTI_X_CODIFICA, ID_CODIFICA_INVESTIMENTO, ID_RNA_PROCEDIMENTI_E_REGOLAMENTI, ID_RNA_OBIETTIVO
		FROM RNA_COMPONENTI_X_CODIFICA
		WHERE 
			((@IdComponentiXCodificaequalthis IS NULL) OR ID_COMPONENTI_X_CODIFICA = @IdComponentiXCodificaequalthis) AND 
			((@IdCodificaInvestimentoequalthis IS NULL) OR ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis) AND 
			((@IdRnaProcedimentiERegolamentiequalthis IS NULL) OR ID_RNA_PROCEDIMENTI_E_REGOLAMENTI = @IdRnaProcedimentiERegolamentiequalthis) AND 
			((@IdRnaObiettivoequalthis IS NULL) OR ID_RNA_OBIETTIVO = @IdRnaObiettivoequalthis)