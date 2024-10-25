CREATE PROCEDURE [dbo].[ZDomandaPagamentoLiquidazioneFindSelect]
(
	@Idequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdImpresaBeneficiariaequalthis INT, 
	@IdDecretoequalthis INT, 
	@RichiestaMandatoImportoequalthis DECIMAL(18,2), 
	@RichiestaMandatoSegnaturaequalthis VARCHAR(255), 
	@RichiestaMandatoDataequalthis DATETIME, 
	@MandatoNumeroequalthis VARCHAR(255), 
	@MandatoDataequalthis DATETIME, 
	@MandatoImportoequalthis DECIMAL(18,2), 
	@MandatoIdFileequalthis INT, 
	@QuietanzaDataequalthis DATETIME, 
	@QuietanzaImportoequalthis DECIMAL(18,2), 
	@Liquidatoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_DOMANDA_PAGAMENTO, ID_PROGETTO, ID_IMPRESA_BENEFICIARIA, ID_DECRETO, RICHIESTA_MANDATO_IMPORTO, RICHIESTA_MANDATO_SEGNATURA, RICHIESTA_MANDATO_DATA, MANDATO_NUMERO, MANDATO_DATA, MANDATO_IMPORTO, MANDATO_ID_FILE, QUIETANZA_DATA, QUIETANZA_IMPORTO, LIQUIDATO FROM DOMANDA_PAGAMENTO_LIQUIDAZIONE WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdImpresaBeneficiariaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA_BENEFICIARIA = @IdImpresaBeneficiariaequalthis)'; set @lensql=@lensql+len(@IdImpresaBeneficiariaequalthis);end;
	IF (@IdDecretoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DECRETO = @IdDecretoequalthis)'; set @lensql=@lensql+len(@IdDecretoequalthis);end;
	IF (@RichiestaMandatoImportoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RICHIESTA_MANDATO_IMPORTO = @RichiestaMandatoImportoequalthis)'; set @lensql=@lensql+len(@RichiestaMandatoImportoequalthis);end;
	IF (@RichiestaMandatoSegnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RICHIESTA_MANDATO_SEGNATURA = @RichiestaMandatoSegnaturaequalthis)'; set @lensql=@lensql+len(@RichiestaMandatoSegnaturaequalthis);end;
	IF (@RichiestaMandatoDataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RICHIESTA_MANDATO_DATA = @RichiestaMandatoDataequalthis)'; set @lensql=@lensql+len(@RichiestaMandatoDataequalthis);end;
	IF (@MandatoNumeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MANDATO_NUMERO = @MandatoNumeroequalthis)'; set @lensql=@lensql+len(@MandatoNumeroequalthis);end;
	IF (@MandatoDataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MANDATO_DATA = @MandatoDataequalthis)'; set @lensql=@lensql+len(@MandatoDataequalthis);end;
	IF (@MandatoImportoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MANDATO_IMPORTO = @MandatoImportoequalthis)'; set @lensql=@lensql+len(@MandatoImportoequalthis);end;
	IF (@MandatoIdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MANDATO_ID_FILE = @MandatoIdFileequalthis)'; set @lensql=@lensql+len(@MandatoIdFileequalthis);end;
	IF (@QuietanzaDataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUIETANZA_DATA = @QuietanzaDataequalthis)'; set @lensql=@lensql+len(@QuietanzaDataequalthis);end;
	IF (@QuietanzaImportoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUIETANZA_IMPORTO = @QuietanzaImportoequalthis)'; set @lensql=@lensql+len(@QuietanzaImportoequalthis);end;
	IF (@Liquidatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (LIQUIDATO = @Liquidatoequalthis)'; set @lensql=@lensql+len(@Liquidatoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT, @IdImpresaBeneficiariaequalthis INT, @IdDecretoequalthis INT, @RichiestaMandatoImportoequalthis DECIMAL(18,2), @RichiestaMandatoSegnaturaequalthis VARCHAR(255), @RichiestaMandatoDataequalthis DATETIME, @MandatoNumeroequalthis VARCHAR(255), @MandatoDataequalthis DATETIME, @MandatoImportoequalthis DECIMAL(18,2), @MandatoIdFileequalthis INT, @QuietanzaDataequalthis DATETIME, @QuietanzaImportoequalthis DECIMAL(18,2), @Liquidatoequalthis BIT',@Idequalthis , @IdDomandaPagamentoequalthis , @IdProgettoequalthis , @IdImpresaBeneficiariaequalthis , @IdDecretoequalthis , @RichiestaMandatoImportoequalthis , @RichiestaMandatoSegnaturaequalthis , @RichiestaMandatoDataequalthis , @MandatoNumeroequalthis , @MandatoDataequalthis , @MandatoImportoequalthis , @MandatoIdFileequalthis , @QuietanzaDataequalthis , @QuietanzaImportoequalthis , @Liquidatoequalthis ;
	else
		SELECT ID, ID_DOMANDA_PAGAMENTO, ID_PROGETTO, ID_IMPRESA_BENEFICIARIA, ID_DECRETO, RICHIESTA_MANDATO_IMPORTO, RICHIESTA_MANDATO_SEGNATURA, RICHIESTA_MANDATO_DATA, MANDATO_NUMERO, MANDATO_DATA, MANDATO_IMPORTO, MANDATO_ID_FILE, QUIETANZA_DATA, QUIETANZA_IMPORTO, LIQUIDATO
		FROM DOMANDA_PAGAMENTO_LIQUIDAZIONE
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdImpresaBeneficiariaequalthis IS NULL) OR ID_IMPRESA_BENEFICIARIA = @IdImpresaBeneficiariaequalthis) AND 
			((@IdDecretoequalthis IS NULL) OR ID_DECRETO = @IdDecretoequalthis) AND 
			((@RichiestaMandatoImportoequalthis IS NULL) OR RICHIESTA_MANDATO_IMPORTO = @RichiestaMandatoImportoequalthis) AND 
			((@RichiestaMandatoSegnaturaequalthis IS NULL) OR RICHIESTA_MANDATO_SEGNATURA = @RichiestaMandatoSegnaturaequalthis) AND 
			((@RichiestaMandatoDataequalthis IS NULL) OR RICHIESTA_MANDATO_DATA = @RichiestaMandatoDataequalthis) AND 
			((@MandatoNumeroequalthis IS NULL) OR MANDATO_NUMERO = @MandatoNumeroequalthis) AND 
			((@MandatoDataequalthis IS NULL) OR MANDATO_DATA = @MandatoDataequalthis) AND 
			((@MandatoImportoequalthis IS NULL) OR MANDATO_IMPORTO = @MandatoImportoequalthis) AND 
			((@MandatoIdFileequalthis IS NULL) OR MANDATO_ID_FILE = @MandatoIdFileequalthis) AND 
			((@QuietanzaDataequalthis IS NULL) OR QUIETANZA_DATA = @QuietanzaDataequalthis) AND 
			((@QuietanzaImportoequalthis IS NULL) OR QUIETANZA_IMPORTO = @QuietanzaImportoequalthis) AND 
			((@Liquidatoequalthis IS NULL) OR LIQUIDATO = @Liquidatoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZDomandaPagamentoLiquidazioneFindSelect]
(
	@Idequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdImpresaBeneficiariaequalthis INT, 
	@IdDecretoequalthis INT, 
	@RichiestaMandatoImportoequalthis DECIMAL(18,2), 
	@RichiestaMandatoSegnaturaequalthis VARCHAR(255), 
	@RichiestaMandatoDataequalthis DATETIME, 
	@MandatoNumeroequalthis VARCHAR(255), 
	@MandatoDataequalthis DATETIME, 
	@MandatoImportoequalthis DECIMAL(18,2), 
	@MandatoIdFileequalthis INT, 
	@QuietanzaDataequalthis DATETIME, 
	@QuietanzaImportoequalthis DECIMAL(18,2), 
	@Liquidatoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_DOMANDA_PAGAMENTO, ID_PROGETTO, ID_IMPRESA_BENEFICIARIA, ID_DECRETO, RICHIESTA_MANDATO_IMPORTO, RICHIESTA_MANDATO_SEGNATURA, RICHIESTA_MANDATO_DATA, MANDATO_NUMERO, MANDATO_DATA, MANDATO_IMPORTO, MANDATO_ID_FILE, QUIETANZA_DATA, QUIETANZA_IMPORTO, LIQUIDATO FROM DOMANDA_PAGAMENTO_LIQUIDAZIONE WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdImpresaBeneficiariaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_IMPRESA_BENEFICIARIA = @IdImpresaBeneficiariaequalthis)''; set @lensql=@lensql+len(@IdImpresaBeneficiariaequalthis);end;
	IF (@IdDecretoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DECRETO = @IdDecretoequalthis)''; set @lensql=@lensql+len(@IdDecretoequalthis);end;
	IF (@RichiestaMandatoImportoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (RICHIESTA_MANDATO_IMPORTO = @RichiestaMandatoImportoequalthis)''; set @lensql=@lensql+len(@RichiestaMandatoImportoequalthis);end;
	IF (@RichiestaMandatoSegnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (RICHIESTA_MANDATO_SEGNATURA = @RichiestaMandatoSegnaturaequalthis)''; set @lensql=@lensql+len(@RichiestaMandatoSegnaturaequalthis);end;
	IF (@RichiestaMandatoDataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (RICHIESTA_MANDATO_DATA = @RichiestaMandatoDataequalthis)''; set @lensql=@lensql+len(@RichiestaMandatoDataequalthis);end;
	IF (@MandatoNumeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MANDATO_NUMERO = @MandatoNumeroequalthis)''; set @lensql=@lensql+len(@MandatoNumeroequalthis);end;
	IF (@MandatoDataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MANDATO_DATA = @MandatoDataequalthis)''; set @lensql=@lensql+len(@MandatoDataequalthis);end;
	IF (@MandatoImportoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MANDATO_IMPORTO = @MandatoImportoequalthis)''; set @lensql=@lensql+len(@MandatoImportoequalthis);end;
	IF (@MandatoIdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MANDATO_ID_FILE = @MandatoIdFileequalthis)''; set @lensql=@lensql+len(@MandatoIdFileequalthis);end;
	IF (@QuietanzaDataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (QUIETANZA_DATA = @QuietanzaDataequalthis)''; set @lensql=@lensql+len(@QuietanzaDataequalthis);end;
	IF (@QuietanzaImportoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (QUIETANZA_IMPORTO = @QuietanzaImportoequalthis)''; set @lensql=@lensql+len(@QuietanzaImportoequalthis);end;
	IF (@Liquidatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (LIQUIDATO = @Liquidatoequalthis)''; set @lensql=@lensql+len(@Liquidatoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idequalthis INT, @IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT, @IdImpresaBeneficiariaequalthis INT, @IdDecretoequalthis INT, @RichiestaMandatoImportoequalthis DECIMAL(18,2), @RichiestaManda', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaPagamentoLiquidazioneFindSelect';

