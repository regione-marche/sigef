CREATE PROCEDURE [dbo].[ZEnteFindSelect]
(
	@CodEnteequalthis VARCHAR(10), 
	@CodTipoEnteequalthis VARCHAR(10), 
	@Descrizioneequalthis VARCHAR(255), 
	@CodSianequalthis VARCHAR(20), 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_ENTE, COD_TIPO_ENTE, DESCRIZIONE, COD_SIAN, ATTIVO FROM ENTE WHERE 1=1';
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE = @CodEnteequalthis)'; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@CodTipoEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_ENTE = @CodTipoEnteequalthis)'; set @lensql=@lensql+len(@CodTipoEnteequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@CodSianequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_SIAN = @CodSianequalthis)'; set @lensql=@lensql+len(@CodSianequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodEnteequalthis VARCHAR(10), @CodTipoEnteequalthis VARCHAR(10), @Descrizioneequalthis VARCHAR(255), @CodSianequalthis VARCHAR(20), @Attivoequalthis BIT',@CodEnteequalthis , @CodTipoEnteequalthis , @Descrizioneequalthis , @CodSianequalthis , @Attivoequalthis ;
	else
		SELECT COD_ENTE, COD_TIPO_ENTE, DESCRIZIONE, COD_SIAN, ATTIVO
		FROM ENTE
		WHERE 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@CodTipoEnteequalthis IS NULL) OR COD_TIPO_ENTE = @CodTipoEnteequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@CodSianequalthis IS NULL) OR COD_SIAN = @CodSianequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'





CREATE PROCEDURE [dbo].[ZEnteFindSelect]
(
	@CodEnteequalthis VARCHAR(10), 
	@CodTipoEnteequalthis VARCHAR(10), 
	@Descrizioneequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT COD_ENTE, COD_TIPO_ENTE, DESCRIZIONE FROM ENTE WHERE 1=1'';
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ENTE = @CodEnteequalthis)''; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@CodTipoEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO_ENTE = @CodTipoEnteequalthis)''; set @lensql=@lensql+len(@CodTipoEnteequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	--	@sql = @sql + '' order by ecc.ecc.''
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@CodEnteequalthis VARCHAR(10), @CodTipoEnteequalthis VARCHAR(10), @Descrizioneequalthis VARCHAR(255)'',@CodEnteequalthis , @CodTipoEnteequalthis , @Descrizioneequalthis ;
	else
		SELECT COD_ENTE, COD_TIPO_ENTE, DESCRIZIONE
		FROM ENTE
		WHERE 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@CodTipoEnteequalthis IS NULL) OR COD_TIPO_ENTE = @CodTipoEnteequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis)
		-- order by ecc.ecc.

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZEnteFindSelect';

