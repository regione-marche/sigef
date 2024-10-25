CREATE PROCEDURE [dbo].[ZVrnaComponentiXCodificaFindSelect]
(
	@IdComponentiXCodificaequalthis INT, 
	@IdProcedimentiRegolamentiequalthis INT, 
	@IdObiettivoequalthis INT, 
	@IdCodificaInvestimentoequalthis INT, 
	@CodiceRegolamentoequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(max), 
	@Settoreequalthis VARCHAR(255), 
	@Obiettivoequalthis VARCHAR(500)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_COMPONENTI_X_CODIFICA, ID_PROCEDIMENTI_REGOLAMENTI, ID_OBIETTIVO, ID_CODIFICA_INVESTIMENTO, CODICE_REGOLAMENTO, DESCRIZIONE, SETTORE, OBIETTIVO FROM vRNA_COMPONENTI_X_CODIFICA WHERE 1=1';
	IF (@IdComponentiXCodificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMPONENTI_X_CODIFICA = @IdComponentiXCodificaequalthis)'; set @lensql=@lensql+len(@IdComponentiXCodificaequalthis);end;
	IF (@IdProcedimentiRegolamentiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROCEDIMENTI_REGOLAMENTI = @IdProcedimentiRegolamentiequalthis)'; set @lensql=@lensql+len(@IdProcedimentiRegolamentiequalthis);end;
	IF (@IdObiettivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OBIETTIVO = @IdObiettivoequalthis)'; set @lensql=@lensql+len(@IdObiettivoequalthis);end;
	IF (@IdCodificaInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis)'; set @lensql=@lensql+len(@IdCodificaInvestimentoequalthis);end;
	IF (@CodiceRegolamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_REGOLAMENTO = @CodiceRegolamentoequalthis)'; set @lensql=@lensql+len(@CodiceRegolamentoequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Settoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SETTORE = @Settoreequalthis)'; set @lensql=@lensql+len(@Settoreequalthis);end;
	IF (@Obiettivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OBIETTIVO = @Obiettivoequalthis)'; set @lensql=@lensql+len(@Obiettivoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdComponentiXCodificaequalthis INT, @IdProcedimentiRegolamentiequalthis INT, @IdObiettivoequalthis INT, @IdCodificaInvestimentoequalthis INT, @CodiceRegolamentoequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(max), @Settoreequalthis VARCHAR(255), @Obiettivoequalthis VARCHAR(500)',@IdComponentiXCodificaequalthis , @IdProcedimentiRegolamentiequalthis , @IdObiettivoequalthis , @IdCodificaInvestimentoequalthis , @CodiceRegolamentoequalthis , @Descrizioneequalthis , @Settoreequalthis , @Obiettivoequalthis ;
	else
		SELECT ID_COMPONENTI_X_CODIFICA, ID_PROCEDIMENTI_REGOLAMENTI, ID_OBIETTIVO, ID_CODIFICA_INVESTIMENTO, CODICE_REGOLAMENTO, DESCRIZIONE, SETTORE, OBIETTIVO
		FROM vRNA_COMPONENTI_X_CODIFICA
		WHERE 
			((@IdComponentiXCodificaequalthis IS NULL) OR ID_COMPONENTI_X_CODIFICA = @IdComponentiXCodificaequalthis) AND 
			((@IdProcedimentiRegolamentiequalthis IS NULL) OR ID_PROCEDIMENTI_REGOLAMENTI = @IdProcedimentiRegolamentiequalthis) AND 
			((@IdObiettivoequalthis IS NULL) OR ID_OBIETTIVO = @IdObiettivoequalthis) AND 
			((@IdCodificaInvestimentoequalthis IS NULL) OR ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis) AND 
			((@CodiceRegolamentoequalthis IS NULL) OR CODICE_REGOLAMENTO = @CodiceRegolamentoequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Settoreequalthis IS NULL) OR SETTORE = @Settoreequalthis) AND 
			((@Obiettivoequalthis IS NULL) OR OBIETTIVO = @Obiettivoequalthis)