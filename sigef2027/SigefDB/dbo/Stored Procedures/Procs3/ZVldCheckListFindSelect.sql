CREATE PROCEDURE [dbo].[ZVldCheckListFindSelect]
(
	@Idequalthis INT, 
	@Descrizioneequalthis VARCHAR(255), 
	@CodTipoDpagamentoequalthis VARCHAR(255), 
	@Tpappaltoequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@Operatoreequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, DESCRIZIONE, COD_TIPO_DPAGAMENTO, TPAPPALTO, DATA_MODIFICA, OPERATORE FROM VLD_CHECK_LIST WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@CodTipoDpagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_DPAGAMENTO = @CodTipoDpagamentoequalthis)'; set @lensql=@lensql+len(@CodTipoDpagamentoequalthis);end;
	IF (@Tpappaltoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TPAPPALTO = @Tpappaltoequalthis)'; set @lensql=@lensql+len(@Tpappaltoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @Descrizioneequalthis VARCHAR(255), @CodTipoDpagamentoequalthis VARCHAR(255), @Tpappaltoequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @Operatoreequalthis INT',@Idequalthis , @Descrizioneequalthis , @CodTipoDpagamentoequalthis , @Tpappaltoequalthis , @DataModificaequalthis , @Operatoreequalthis ;
	else
		SELECT ID, DESCRIZIONE, COD_TIPO_DPAGAMENTO, TPAPPALTO, DATA_MODIFICA, OPERATORE
		FROM VLD_CHECK_LIST
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@CodTipoDpagamentoequalthis IS NULL) OR COD_TIPO_DPAGAMENTO = @CodTipoDpagamentoequalthis) AND 
			((@Tpappaltoequalthis IS NULL) OR TPAPPALTO = @Tpappaltoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVldCheckListFindSelect';

