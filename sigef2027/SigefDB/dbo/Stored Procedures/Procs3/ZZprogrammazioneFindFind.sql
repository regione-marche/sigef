CREATE PROCEDURE [dbo].[ZZprogrammazioneFindFind]
(
	@Codiceequalthis VARCHAR(255), 
	@CodTipoequalthis VARCHAR(255), 
	@CodPsrequalthis VARCHAR(255), 
	@Descrizionelikethis VARCHAR(2000), 
	@Livelloequalthis INT, 
	@IdPadreequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, COD_TIPO, CODICE, DESCRIZIONE, ID_PADRE, COD_PSR, TIPO, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA, ATTIVAZIONE_INVESTIMENTI, ATTIVAZIONE_FF, IMPORTO_DOTAZIONE FROM vzPROGRAMMAZIONE WHERE 1=1';
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE = @Codiceequalthis)'; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@CodPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_PSR = @CodPsrequalthis)'; set @lensql=@lensql+len(@CodPsrequalthis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE LIKE @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	IF (@Livelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (LIVELLO = @Livelloequalthis)'; set @lensql=@lensql+len(@Livelloequalthis);end;
	IF (@IdPadreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PADRE = @IdPadreequalthis)'; set @lensql=@lensql+len(@IdPadreequalthis);end;
	set @sql = @sql + 'ORDER BY LIVELLO, CODICE, DESCRIZIONE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Codiceequalthis VARCHAR(255), @CodTipoequalthis VARCHAR(255), @CodPsrequalthis VARCHAR(255), @Descrizionelikethis VARCHAR(2000), @Livelloequalthis INT, @IdPadreequalthis INT',@Codiceequalthis , @CodTipoequalthis , @CodPsrequalthis , @Descrizionelikethis , @Livelloequalthis , @IdPadreequalthis ;
	else
		SELECT ID, COD_TIPO, CODICE, DESCRIZIONE, ID_PADRE, COD_PSR, TIPO, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA, ATTIVAZIONE_INVESTIMENTI, ATTIVAZIONE_FF, IMPORTO_DOTAZIONE
		FROM vzPROGRAMMAZIONE
		WHERE 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@CodPsrequalthis IS NULL) OR COD_PSR = @CodPsrequalthis) AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis) AND 
			((@Livelloequalthis IS NULL) OR LIVELLO = @Livelloequalthis) AND 
			((@IdPadreequalthis IS NULL) OR ID_PADRE = @IdPadreequalthis)
		ORDER BY LIVELLO, CODICE, DESCRIZIONE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZprogrammazioneFindFind]
(
	@Codiceequalthis VARCHAR(255), 
	@CodTipoequalthis VARCHAR(255), 
	@CodPsrequalthis VARCHAR(255), 
	@Descrizionelikethis VARCHAR(2000), 
	@Livelloequalthis INT, 
	@IdPadreequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, COD_TIPO, CODICE, DESCRIZIONE, ID_PADRE, COD_PSR, TIPO, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA FROM vzPROGRAMMAZIONE WHERE 1=1'';
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE = @Codiceequalthis)''; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@CodPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_PSR = @CodPsrequalthis)''; set @lensql=@lensql+len(@CodPsrequalthis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE LIKE @Descrizionelikethis)''; set @lensql=@lensql+len(@Descrizionelikethis);end;
	IF (@Livelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (LIVELLO = @Livelloequalthis)''; set @lensql=@lensql+len(@Livelloequalthis);end;
	IF (@IdPadreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PADRE = @IdPadreequalthis)''; set @lensql=@lensql+len(@IdPadreequalthis);end;
	set @sql = @sql + ''ORDER BY LIVELLO, CODICE, DESCRIZIONE'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Codiceequalthis VARCHAR(255), @CodTipoequalthis VARCHAR(255), @CodPsrequalthis VARCHAR(255), @Descrizionelikethis VARCHAR(2000), @Livelloequalthis INT, @IdPadreequalthis INT'',@Codiceequalthis , @CodTipoequalthis , @CodPsrequalthis , @Descrizionelikethis , @Livelloequalthis , @IdPadreequalthis ;
	else
		SELECT ID, COD_TIPO, CODICE, DESCRIZIONE, ID_PADRE, COD_PSR, TIPO, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA
		FROM vzPROGRAMMAZIONE
		WHERE 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@CodPsrequalthis IS NULL) OR COD_PSR = @CodPsrequalthis) AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis) AND 
			((@Livelloequalthis IS NULL) OR LIVELLO = @Livelloequalthis) AND 
			((@IdPadreequalthis IS NULL) OR ID_PADRE = @IdPadreequalthis)
		ORDER BY LIVELLO, CODICE, DESCRIZIONE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZprogrammazioneFindFind';

