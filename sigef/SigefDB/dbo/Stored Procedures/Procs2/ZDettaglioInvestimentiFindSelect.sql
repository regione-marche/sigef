CREATE PROCEDURE [dbo].[ZDettaglioInvestimentiFindSelect]
(
	@IdDettaglioInvestimentoequalthis INT, 
	@IdCodificaInvestimentoequalthis INT, 
	@CodDettaglioequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(255), 
	@Mobileequalthis BIT, 
	@QuotaSpeseGeneraliequalthis DECIMAL(10,2), 
	@RichiediParticellaequalthis BIT, 
	@IdUdmequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DETTAGLIO_INVESTIMENTO, ID_CODIFICA_INVESTIMENTO, COD_DETTAGLIO, DESCRIZIONE, MOBILE, QUOTA_SPESE_GENERALI, RICHIEDI_PARTICELLA, ID_UDM FROM DETTAGLIO_INVESTIMENTI WHERE 1=1';
	IF (@IdDettaglioInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimentoequalthis)'; set @lensql=@lensql+len(@IdDettaglioInvestimentoequalthis);end;
	IF (@IdCodificaInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis)'; set @lensql=@lensql+len(@IdCodificaInvestimentoequalthis);end;
	IF (@CodDettaglioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_DETTAGLIO = @CodDettaglioequalthis)'; set @lensql=@lensql+len(@CodDettaglioequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Mobileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MOBILE = @Mobileequalthis)'; set @lensql=@lensql+len(@Mobileequalthis);end;
	IF (@QuotaSpeseGeneraliequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUOTA_SPESE_GENERALI = @QuotaSpeseGeneraliequalthis)'; set @lensql=@lensql+len(@QuotaSpeseGeneraliequalthis);end;
	IF (@RichiediParticellaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RICHIEDI_PARTICELLA = @RichiediParticellaequalthis)'; set @lensql=@lensql+len(@RichiediParticellaequalthis);end;
	IF (@IdUdmequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UDM = @IdUdmequalthis)'; set @lensql=@lensql+len(@IdUdmequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDettaglioInvestimentoequalthis INT, @IdCodificaInvestimentoequalthis INT, @CodDettaglioequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(255), @Mobileequalthis BIT, @QuotaSpeseGeneraliequalthis DECIMAL(10,2), @RichiediParticellaequalthis BIT, @IdUdmequalthis INT',@IdDettaglioInvestimentoequalthis , @IdCodificaInvestimentoequalthis , @CodDettaglioequalthis , @Descrizioneequalthis , @Mobileequalthis , @QuotaSpeseGeneraliequalthis , @RichiediParticellaequalthis , @IdUdmequalthis ;
	else
		SELECT ID_DETTAGLIO_INVESTIMENTO, ID_CODIFICA_INVESTIMENTO, COD_DETTAGLIO, DESCRIZIONE, MOBILE, QUOTA_SPESE_GENERALI, RICHIEDI_PARTICELLA, ID_UDM
		FROM DETTAGLIO_INVESTIMENTI
		WHERE 
			((@IdDettaglioInvestimentoequalthis IS NULL) OR ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimentoequalthis) AND 
			((@IdCodificaInvestimentoequalthis IS NULL) OR ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis) AND 
			((@CodDettaglioequalthis IS NULL) OR COD_DETTAGLIO = @CodDettaglioequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Mobileequalthis IS NULL) OR MOBILE = @Mobileequalthis) AND 
			((@QuotaSpeseGeneraliequalthis IS NULL) OR QUOTA_SPESE_GENERALI = @QuotaSpeseGeneraliequalthis) AND 
			((@RichiediParticellaequalthis IS NULL) OR RICHIEDI_PARTICELLA = @RichiediParticellaequalthis) AND 
			((@IdUdmequalthis IS NULL) OR ID_UDM = @IdUdmequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZDettaglioInvestimentiFindSelect]
(
	@IdDettaglioInvestimentoequalthis INT, 
	@IdCodificaInvestimentoequalthis INT, 
	@CodDettaglioequalthis CHAR(2), 
	@Descrizioneequalthis VARCHAR(255), 
	@Mobileequalthis BIT, 
	@QuotaSpeseGeneraliequalthis DECIMAL(10,2), 
	@RichiediParticellaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_DETTAGLIO_INVESTIMENTO, ID_CODIFICA_INVESTIMENTO, COD_DETTAGLIO, DESCRIZIONE, MOBILE, QUOTA_SPESE_GENERALI, RICHIEDI_PARTICELLA FROM DETTAGLIO_INVESTIMENTI WHERE 1=1'';
	IF (@IdDettaglioInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimentoequalthis)''; set @lensql=@lensql+len(@IdDettaglioInvestimentoequalthis);end;
	IF (@IdCodificaInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis)''; set @lensql=@lensql+len(@IdCodificaInvestimentoequalthis);end;
	IF (@CodDettaglioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_DETTAGLIO = @CodDettaglioequalthis)''; set @lensql=@lensql+len(@CodDettaglioequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Mobileequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MOBILE = @Mobileequalthis)''; set @lensql=@lensql+len(@Mobileequalthis);end;
	IF (@QuotaSpeseGeneraliequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (QUOTA_SPESE_GENERALI = @QuotaSpeseGeneraliequalthis)''; set @lensql=@lensql+len(@QuotaSpeseGeneraliequalthis);end;
	IF (@RichiediParticellaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (RICHIEDI_PARTICELLA = @RichiediParticellaequalthis)''; set @lensql=@lensql+len(@RichiediParticellaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdDettaglioInvestimentoequalthis INT, @IdCodificaInvestimentoequalthis INT, @CodDettaglioequalthis CHAR(2), @Descrizioneequalthis VARCHAR(255), @Mobileequalthis BIT, @QuotaSpeseGeneraliequalthis DECIMAL(10,2), @RichiediParticellaequalthis BIT'',@IdDettaglioInvestimentoequalthis , @IdCodificaInvestimentoequalthis , @CodDettaglioequalthis , @Descrizioneequalthis , @Mobileequalthis , @QuotaSpeseGeneraliequalthis , @RichiediParticellaequalthis ;
	else
		SELECT ID_DETTAGLIO_INVESTIMENTO, ID_CODIFICA_INVESTIMENTO, COD_DETTAGLIO, DESCRIZIONE, MOBILE, QUOTA_SPESE_GENERALI, RICHIEDI_PARTICELLA
		FROM DETTAGLIO_INVESTIMENTI
		WHERE 
			((@IdDettaglioInvestimentoequalthis IS NULL) OR ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimentoequalthis) AND 
			((@IdCodificaInvestimentoequalthis IS NULL) OR ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis) AND 
			((@CodDettaglioequalthis IS NULL) OR COD_DETTAGLIO = @CodDettaglioequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Mobileequalthis IS NULL) OR MOBILE = @Mobileequalthis) AND 
			((@QuotaSpeseGeneraliequalthis IS NULL) OR QUOTA_SPESE_GENERALI = @QuotaSpeseGeneraliequalthis) AND 
			((@RichiediParticellaequalthis IS NULL) OR RICHIEDI_PARTICELLA = @RichiediParticellaequalthis)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDettaglioInvestimentiFindSelect';

