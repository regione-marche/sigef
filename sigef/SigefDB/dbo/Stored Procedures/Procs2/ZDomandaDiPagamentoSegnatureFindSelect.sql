CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoSegnatureFindSelect]
(
	@IdDomandaPagamentoequalthis INT, 
	@CodTipoequalthis CHAR(3), 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis CHAR(16), 
	@Segnaturaequalthis VARCHAR(100), 
	@RiapriDomandaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DOMANDA_PAGAMENTO, COD_TIPO, DATA, OPERATORE, SEGNATURA, MOTIVAZIONE, RIAPRI_DOMANDA FROM DOMANDA_DI_PAGAMENTO_SEGNATURE WHERE 1=1';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@RiapriDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RIAPRI_DOMANDA = @RiapriDomandaequalthis)'; set @lensql=@lensql+len(@RiapriDomandaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDomandaPagamentoequalthis INT, @CodTipoequalthis CHAR(3), @Dataequalthis DATETIME, @Operatoreequalthis CHAR(16), @Segnaturaequalthis VARCHAR(100), @RiapriDomandaequalthis BIT',@IdDomandaPagamentoequalthis , @CodTipoequalthis , @Dataequalthis , @Operatoreequalthis , @Segnaturaequalthis , @RiapriDomandaequalthis ;
	else
		SELECT ID_DOMANDA_PAGAMENTO, COD_TIPO, DATA, OPERATORE, SEGNATURA, MOTIVAZIONE, RIAPRI_DOMANDA
		FROM DOMANDA_DI_PAGAMENTO_SEGNATURE
		WHERE 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@RiapriDomandaequalthis IS NULL) OR RIAPRI_DOMANDA = @RiapriDomandaequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaDiPagamentoSegnatureFindSelect';

