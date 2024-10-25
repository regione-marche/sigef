CREATE PROCEDURE [dbo].[ZRnaProcedimentiERegolamentiFindSelect]
(
	@IdProcedimentiRegolamentiequalthis INT, 
	@CodTipoProcedimentoequalthis INT, 
	@DescrizioneProceduraequalthis VARCHAR(255), 
	@CodiceRegolamentoequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(max), 
	@CodiceSettoreequalthis VARCHAR(255), 
	@Settoreequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PROCEDIMENTI_REGOLAMENTI, COD_TIPO_PROCEDIMENTO, DESCRIZIONE_PROCEDURA, CODICE_REGOLAMENTO, DESCRIZIONE, CODICE_SETTORE, SETTORE FROM RNA_PROCEDIMENTI_E_REGOLAMENTI WHERE 1=1';
	IF (@IdProcedimentiRegolamentiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROCEDIMENTI_REGOLAMENTI = @IdProcedimentiRegolamentiequalthis)'; set @lensql=@lensql+len(@IdProcedimentiRegolamentiequalthis);end;
	IF (@CodTipoProcedimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_PROCEDIMENTO = @CodTipoProcedimentoequalthis)'; set @lensql=@lensql+len(@CodTipoProcedimentoequalthis);end;
	IF (@DescrizioneProceduraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_PROCEDURA = @DescrizioneProceduraequalthis)'; set @lensql=@lensql+len(@DescrizioneProceduraequalthis);end;
	IF (@CodiceRegolamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_REGOLAMENTO = @CodiceRegolamentoequalthis)'; set @lensql=@lensql+len(@CodiceRegolamentoequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@CodiceSettoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_SETTORE = @CodiceSettoreequalthis)'; set @lensql=@lensql+len(@CodiceSettoreequalthis);end;
	IF (@Settoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SETTORE = @Settoreequalthis)'; set @lensql=@lensql+len(@Settoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProcedimentiRegolamentiequalthis INT, @CodTipoProcedimentoequalthis INT, @DescrizioneProceduraequalthis VARCHAR(255), @CodiceRegolamentoequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(max), @CodiceSettoreequalthis VARCHAR(255), @Settoreequalthis VARCHAR(255)',@IdProcedimentiRegolamentiequalthis , @CodTipoProcedimentoequalthis , @DescrizioneProceduraequalthis , @CodiceRegolamentoequalthis , @Descrizioneequalthis , @CodiceSettoreequalthis , @Settoreequalthis ;
	else
		SELECT ID_PROCEDIMENTI_REGOLAMENTI, COD_TIPO_PROCEDIMENTO, DESCRIZIONE_PROCEDURA, CODICE_REGOLAMENTO, DESCRIZIONE, CODICE_SETTORE, SETTORE
		FROM RNA_PROCEDIMENTI_E_REGOLAMENTI
		WHERE 
			((@IdProcedimentiRegolamentiequalthis IS NULL) OR ID_PROCEDIMENTI_REGOLAMENTI = @IdProcedimentiRegolamentiequalthis) AND 
			((@CodTipoProcedimentoequalthis IS NULL) OR COD_TIPO_PROCEDIMENTO = @CodTipoProcedimentoequalthis) AND 
			((@DescrizioneProceduraequalthis IS NULL) OR DESCRIZIONE_PROCEDURA = @DescrizioneProceduraequalthis) AND 
			((@CodiceRegolamentoequalthis IS NULL) OR CODICE_REGOLAMENTO = @CodiceRegolamentoequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@CodiceSettoreequalthis IS NULL) OR CODICE_SETTORE = @CodiceSettoreequalthis) AND 
			((@Settoreequalthis IS NULL) OR SETTORE = @Settoreequalthis)