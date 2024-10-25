CREATE PROCEDURE [dbo].[ZZprogrammazioneFindSelect]
(
	@Idequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@Codiceequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(2000), 
	@IdPadreequalthis INT, 
	@ImportoDotazioneequalthis DECIMAL(18,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, COD_TIPO, CODICE, DESCRIZIONE, ID_PADRE, COD_PSR, TIPO, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA, ATTIVAZIONE_INVESTIMENTI, ATTIVAZIONE_FF, IMPORTO_DOTAZIONE FROM vzPROGRAMMAZIONE WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE = @Codiceequalthis)'; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@IdPadreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PADRE = @IdPadreequalthis)'; set @lensql=@lensql+len(@IdPadreequalthis);end;
	IF (@ImportoDotazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DOTAZIONE = @ImportoDotazioneequalthis)'; set @lensql=@lensql+len(@ImportoDotazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @CodTipoequalthis VARCHAR(255), @Codiceequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(2000), @IdPadreequalthis INT, @ImportoDotazioneequalthis DECIMAL(18,2)',@Idequalthis , @CodTipoequalthis , @Codiceequalthis , @Descrizioneequalthis , @IdPadreequalthis , @ImportoDotazioneequalthis ;
	else
		SELECT ID, COD_TIPO, CODICE, DESCRIZIONE, ID_PADRE, COD_PSR, TIPO, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA, ATTIVAZIONE_INVESTIMENTI, ATTIVAZIONE_FF, IMPORTO_DOTAZIONE
		FROM vzPROGRAMMAZIONE
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@IdPadreequalthis IS NULL) OR ID_PADRE = @IdPadreequalthis) AND 
			((@ImportoDotazioneequalthis IS NULL) OR IMPORTO_DOTAZIONE = @ImportoDotazioneequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZprogrammazioneFindSelect]
(
	@Idequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@Codiceequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(2000), 
	@IdPadreequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, COD_TIPO, CODICE, DESCRIZIONE, ID_PADRE, COD_PSR, TIPO, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA FROM vzPROGRAMMAZIONE WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE = @Codiceequalthis)''; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@IdPadreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PADRE = @IdPadreequalthis)''; set @lensql=@lensql+len(@IdPadreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idequalthis INT, @CodTipoequalthis VARCHAR(255), @Codiceequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(2000), @IdPadreequalthis INT'',@Idequalthis , @CodTipoequalthis , @Codiceequalthis , @Descrizioneequalthis , @IdPadreequalthis ;
	else
		SELECT ID, COD_TIPO, CODICE, DESCRIZIONE, ID_PADRE, COD_PSR, TIPO, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA
		FROM vzPROGRAMMAZIONE
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@IdPadreequalthis IS NULL) OR ID_PADRE = @IdPadreequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZprogrammazioneFindSelect';

