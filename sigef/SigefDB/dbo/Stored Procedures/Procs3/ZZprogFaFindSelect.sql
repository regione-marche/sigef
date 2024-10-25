CREATE PROCEDURE [dbo].[ZZprogFaFindSelect]
(
	@Idequalthis INT, 
	@IdProgrammazioneequalthis INT, 
	@CodFaequalthis VARCHAR(255), 
	@TipoContributoequalthis VARCHAR(255), 
	@DotFinanziariaequalthis DECIMAL(18,2), 
	@Attivoequalthis BIT, 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGRAMMAZIONE, COD_FA, TIPO_CONTRIBUTO, DOT_FINANZIARIA, COD_PSR, FA_DESCRIZIONE, FA_DOT_FINANZIARIA, TRASVERSALE, PROG_COD_TIPO, PROG_CODICE, PROG_DESCRIZIONE, ID_PADRE, PROG_TIPO, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA, ATTIVO, DATA, OPERATORE, CF_UTENTE, NOMINATIVO, COD_ENTE FROM vzPROG_FA WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@CodFaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FA = @CodFaequalthis)'; set @lensql=@lensql+len(@CodFaequalthis);end;
	IF (@TipoContributoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_CONTRIBUTO = @TipoContributoequalthis)'; set @lensql=@lensql+len(@TipoContributoequalthis);end;
	IF (@DotFinanziariaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DOT_FINANZIARIA = @DotFinanziariaequalthis)'; set @lensql=@lensql+len(@DotFinanziariaequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdProgrammazioneequalthis INT, @CodFaequalthis VARCHAR(255), @TipoContributoequalthis VARCHAR(255), @DotFinanziariaequalthis DECIMAL(18,2), @Attivoequalthis BIT, @Dataequalthis DATETIME, @Operatoreequalthis INT',@Idequalthis , @IdProgrammazioneequalthis , @CodFaequalthis , @TipoContributoequalthis , @DotFinanziariaequalthis , @Attivoequalthis , @Dataequalthis , @Operatoreequalthis ;
	else
		SELECT ID, ID_PROGRAMMAZIONE, COD_FA, TIPO_CONTRIBUTO, DOT_FINANZIARIA, COD_PSR, FA_DESCRIZIONE, FA_DOT_FINANZIARIA, TRASVERSALE, PROG_COD_TIPO, PROG_CODICE, PROG_DESCRIZIONE, ID_PADRE, PROG_TIPO, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA, ATTIVO, DATA, OPERATORE, CF_UTENTE, NOMINATIVO, COD_ENTE
		FROM vzPROG_FA
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@CodFaequalthis IS NULL) OR COD_FA = @CodFaequalthis) AND 
			((@TipoContributoequalthis IS NULL) OR TIPO_CONTRIBUTO = @TipoContributoequalthis) AND 
			((@DotFinanziariaequalthis IS NULL) OR DOT_FINANZIARIA = @DotFinanziariaequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZprogFaFindSelect]
(
	@Idequalthis INT, 
	@IdProgrammazioneequalthis INT, 
	@CodFaequalthis VARCHAR(255), 
	@TipoContributoequalthis VARCHAR(255), 
	@DotFinanziariaequalthis DECIMAL(18,2), 
	@Attivoequalthis BIT, 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_PROGRAMMAZIONE, COD_FA, TIPO_CONTRIBUTO, DOT_FINANZIARIA, COD_PSR, FA_DESCRIZIONE, FA_DOT_FINANZIARIA, TRASVERSALE, PROG_COD_TIPO, PROG_CODICE, PROG_DESCRIZIONE, ID_PADRE, PROG_TIPO, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA, ATTIVO, DATA, OPERATORE, CF_UTENTE, NOMINATIVO, COD_ENTE FROM vzPROG_FA WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)''; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@CodFaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_FA = @CodFaequalthis)''; set @lensql=@lensql+len(@CodFaequalthis);end;
	IF (@TipoContributoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TIPO_CONTRIBUTO = @TipoContributoequalthis)''; set @lensql=@lensql+len(@TipoContributoequalthis);end;
	IF (@DotFinanziariaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DOT_FINANZIARIA = @DotFinanziariaequalthis)''; set @lensql=@lensql+len(@DotFinanziariaequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ATTIVO = @Attivoequalthis)''; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA = @Dataequalthis)''; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE = @Operatoreequalthis)''; set @lensql=@lensql+len(@Operatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idequalthis INT, @IdProgrammazioneequalthis INT, @CodFaequalthis VARCHAR(255), @TipoContributoequalthis VARCHAR(255), @DotFinanziariaequalthis DECIMAL(18,2), @Attivoequalthis BIT, @Dataequalthis DATETIME, @Operatoreequalthis INT'',@Idequalthis , @IdProgrammazioneequalthis , @CodFaequalthis , @TipoContributoequalthis , @DotFinanziariaequalthis , @Attivoequalthis , @Dataequalthis , @Operatoreequalthis ;
	else
		SELECT ID, ID_PROGRAMMAZIONE, COD_FA, TIPO_CONTRIBUTO, DOT_FINANZIARIA, COD_PSR, FA_DESCRIZIONE, FA_DOT_FINANZIARIA, TRASVERSALE, PROG_COD_TIPO, PROG_CODICE, PROG_DESCRIZIONE, ID_PADRE, PROG_TIPO, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA, ATTIVO, DATA, OPERATORE, CF_UTENTE, NOMINATIVO, COD_ENTE
		FROM vzPROG_FA
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@CodFaequalthis IS NULL) OR COD_FA = @CodFaequalthis) AND 
			((@TipoContributoequalthis IS NULL) OR TIPO_CONTRIBUTO = @TipoContributoequalthis) AND 
			((@DotFinanziariaequalthis IS NULL) OR DOT_FINANZIARIA = @DotFinanziariaequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZprogFaFindSelect';

