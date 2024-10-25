CREATE PROCEDURE [dbo].[ZVrnaStrumentiXComponentiFindSelect]
(
	@IdCodificaInvestimentoequalthis INT, 
	@IdComponentiXCodificaequalthis INT, 
	@IdRnaObiettivoequalthis INT, 
	@IdRnaProcedimentiERegolamentiequalthis INT, 
	@CodTipoStrumentoAiutoequalthis INT, 
	@IdStrumentiXComponentiequalthis INT, 
	@Strumentoequalthis VARCHAR(300), 
	@IntensitaStrumentoequalthis DECIMAL(15,12), 
	@Obiettivoequalthis VARCHAR(500), 
	@CodiceRegolamentoequalthis VARCHAR(255), 
	@Settoreequalthis VARCHAR(255), 
	@Investimentoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_CODIFICA_INVESTIMENTO, ID_COMPONENTI_X_CODIFICA, ID_RNA_OBIETTIVO, ID_RNA_PROCEDIMENTI_E_REGOLAMENTI, COD_TIPO_STRUMENTO_AIUTO, ID_STRUMENTI_X_COMPONENTI, STRUMENTO, INTENSITA_STRUMENTO, OBIETTIVO, CODICE_REGOLAMENTO, SETTORE, INVESTIMENTO FROM vRNA_STRUMENTI_X_COMPONENTI WHERE 1=1';
	IF (@IdCodificaInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis)'; set @lensql=@lensql+len(@IdCodificaInvestimentoequalthis);end;
	IF (@IdComponentiXCodificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMPONENTI_X_CODIFICA = @IdComponentiXCodificaequalthis)'; set @lensql=@lensql+len(@IdComponentiXCodificaequalthis);end;
	IF (@IdRnaObiettivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RNA_OBIETTIVO = @IdRnaObiettivoequalthis)'; set @lensql=@lensql+len(@IdRnaObiettivoequalthis);end;
	IF (@IdRnaProcedimentiERegolamentiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RNA_PROCEDIMENTI_E_REGOLAMENTI = @IdRnaProcedimentiERegolamentiequalthis)'; set @lensql=@lensql+len(@IdRnaProcedimentiERegolamentiequalthis);end;
	IF (@CodTipoStrumentoAiutoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_STRUMENTO_AIUTO = @CodTipoStrumentoAiutoequalthis)'; set @lensql=@lensql+len(@CodTipoStrumentoAiutoequalthis);end;
	IF (@IdStrumentiXComponentiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STRUMENTI_X_COMPONENTI = @IdStrumentiXComponentiequalthis)'; set @lensql=@lensql+len(@IdStrumentiXComponentiequalthis);end;
	IF (@Strumentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STRUMENTO = @Strumentoequalthis)'; set @lensql=@lensql+len(@Strumentoequalthis);end;
	IF (@IntensitaStrumentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INTENSITA_STRUMENTO = @IntensitaStrumentoequalthis)'; set @lensql=@lensql+len(@IntensitaStrumentoequalthis);end;
	IF (@Obiettivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OBIETTIVO = @Obiettivoequalthis)'; set @lensql=@lensql+len(@Obiettivoequalthis);end;
	IF (@CodiceRegolamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_REGOLAMENTO = @CodiceRegolamentoequalthis)'; set @lensql=@lensql+len(@CodiceRegolamentoequalthis);end;
	IF (@Settoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SETTORE = @Settoreequalthis)'; set @lensql=@lensql+len(@Settoreequalthis);end;
	IF (@Investimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INVESTIMENTO = @Investimentoequalthis)'; set @lensql=@lensql+len(@Investimentoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdCodificaInvestimentoequalthis INT, @IdComponentiXCodificaequalthis INT, @IdRnaObiettivoequalthis INT, @IdRnaProcedimentiERegolamentiequalthis INT, @CodTipoStrumentoAiutoequalthis INT, @IdStrumentiXComponentiequalthis INT, @Strumentoequalthis VARCHAR(300), @IntensitaStrumentoequalthis DECIMAL(15,12), @Obiettivoequalthis VARCHAR(500), @CodiceRegolamentoequalthis VARCHAR(255), @Settoreequalthis VARCHAR(255), @Investimentoequalthis VARCHAR(255)',@IdCodificaInvestimentoequalthis , @IdComponentiXCodificaequalthis , @IdRnaObiettivoequalthis , @IdRnaProcedimentiERegolamentiequalthis , @CodTipoStrumentoAiutoequalthis , @IdStrumentiXComponentiequalthis , @Strumentoequalthis , @IntensitaStrumentoequalthis , @Obiettivoequalthis , @CodiceRegolamentoequalthis , @Settoreequalthis , @Investimentoequalthis ;
	else
		SELECT ID_CODIFICA_INVESTIMENTO, ID_COMPONENTI_X_CODIFICA, ID_RNA_OBIETTIVO, ID_RNA_PROCEDIMENTI_E_REGOLAMENTI, COD_TIPO_STRUMENTO_AIUTO, ID_STRUMENTI_X_COMPONENTI, STRUMENTO, INTENSITA_STRUMENTO, OBIETTIVO, CODICE_REGOLAMENTO, SETTORE, INVESTIMENTO
		FROM vRNA_STRUMENTI_X_COMPONENTI
		WHERE 
			((@IdCodificaInvestimentoequalthis IS NULL) OR ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis) AND 
			((@IdComponentiXCodificaequalthis IS NULL) OR ID_COMPONENTI_X_CODIFICA = @IdComponentiXCodificaequalthis) AND 
			((@IdRnaObiettivoequalthis IS NULL) OR ID_RNA_OBIETTIVO = @IdRnaObiettivoequalthis) AND 
			((@IdRnaProcedimentiERegolamentiequalthis IS NULL) OR ID_RNA_PROCEDIMENTI_E_REGOLAMENTI = @IdRnaProcedimentiERegolamentiequalthis) AND 
			((@CodTipoStrumentoAiutoequalthis IS NULL) OR COD_TIPO_STRUMENTO_AIUTO = @CodTipoStrumentoAiutoequalthis) AND 
			((@IdStrumentiXComponentiequalthis IS NULL) OR ID_STRUMENTI_X_COMPONENTI = @IdStrumentiXComponentiequalthis) AND 
			((@Strumentoequalthis IS NULL) OR STRUMENTO = @Strumentoequalthis) AND 
			((@IntensitaStrumentoequalthis IS NULL) OR INTENSITA_STRUMENTO = @IntensitaStrumentoequalthis) AND 
			((@Obiettivoequalthis IS NULL) OR OBIETTIVO = @Obiettivoequalthis) AND 
			((@CodiceRegolamentoequalthis IS NULL) OR CODICE_REGOLAMENTO = @CodiceRegolamentoequalthis) AND 
			((@Settoreequalthis IS NULL) OR SETTORE = @Settoreequalthis) AND 
			((@Investimentoequalthis IS NULL) OR INVESTIMENTO = @Investimentoequalthis)