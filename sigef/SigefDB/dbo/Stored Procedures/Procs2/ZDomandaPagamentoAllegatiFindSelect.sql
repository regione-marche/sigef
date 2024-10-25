CREATE PROCEDURE [dbo].[ZDomandaPagamentoAllegatiFindSelect]
(
	@IdAllegatoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@Descrizioneequalthis VARCHAR(255), 
	@CodTipoDocumentoequalthis VARCHAR(255), 
	@IdFileequalthis INT, 
	@CodEnteEmettitoreequalthis VARCHAR(255), 
	@IdComuneequalthis INT, 
	@Numeroequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@CodEsitoequalthis VARCHAR(255), 
	@InIntegrazioneequalthis BIT, 
	@DataInserimentoequalthis DATETIME, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ALLEGATO, ID_DOMANDA_PAGAMENTO, COD_TIPO_DOCUMENTO, ID_FILE, DESCRIZIONE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, COD_ESITO, NOTE_ISTRUTTORE, ESITO, ESITO_POSITIVO, FORMATO, TIPO_ALLEGATO, TIPOLOGIA_DOCUMENTO, ENTE, DIMENSIONE_FILE, IN_INTEGRAZIONE, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA FROM vDOMANDA_PAGAMENTO_ALLEGATI WHERE 1=1';
	IF (@IdAllegatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ALLEGATO = @IdAllegatoequalthis)'; set @lensql=@lensql+len(@IdAllegatoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@CodTipoDocumentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_DOCUMENTO = @CodTipoDocumentoequalthis)'; set @lensql=@lensql+len(@CodTipoDocumentoequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE = @IdFileequalthis)'; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@CodEnteEmettitoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE_EMETTITORE = @CodEnteEmettitoreequalthis)'; set @lensql=@lensql+len(@CodEnteEmettitoreequalthis);end;
	IF (@IdComuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNE = @IdComuneequalthis)'; set @lensql=@lensql+len(@IdComuneequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO = @Numeroequalthis)'; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@CodEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ESITO = @CodEsitoequalthis)'; set @lensql=@lensql+len(@CodEsitoequalthis);end;
	IF (@InIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IN_INTEGRAZIONE = @InIntegrazioneequalthis)'; set @lensql=@lensql+len(@InIntegrazioneequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_INSERIMENTO = @CfInserimentoequalthis)'; set @lensql=@lensql+len(@CfInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_MODIFICA = @CfModificaequalthis)'; set @lensql=@lensql+len(@CfModificaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdAllegatoequalthis INT, @IdDomandaPagamentoequalthis INT, @Descrizioneequalthis VARCHAR(255), @CodTipoDocumentoequalthis VARCHAR(255), @IdFileequalthis INT, @CodEnteEmettitoreequalthis VARCHAR(255), @IdComuneequalthis INT, @Numeroequalthis VARCHAR(255), @Dataequalthis DATETIME, @CodEsitoequalthis VARCHAR(255), @InIntegrazioneequalthis BIT, @DataInserimentoequalthis DATETIME, @CfInserimentoequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @CfModificaequalthis VARCHAR(255)',@IdAllegatoequalthis , @IdDomandaPagamentoequalthis , @Descrizioneequalthis , @CodTipoDocumentoequalthis , @IdFileequalthis , @CodEnteEmettitoreequalthis , @IdComuneequalthis , @Numeroequalthis , @Dataequalthis , @CodEsitoequalthis , @InIntegrazioneequalthis , @DataInserimentoequalthis , @CfInserimentoequalthis , @DataModificaequalthis , @CfModificaequalthis ;
	else
		SELECT ID_ALLEGATO, ID_DOMANDA_PAGAMENTO, COD_TIPO_DOCUMENTO, ID_FILE, DESCRIZIONE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, COD_ESITO, NOTE_ISTRUTTORE, ESITO, ESITO_POSITIVO, FORMATO, TIPO_ALLEGATO, TIPOLOGIA_DOCUMENTO, ENTE, DIMENSIONE_FILE, IN_INTEGRAZIONE, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA
		FROM vDOMANDA_PAGAMENTO_ALLEGATI
		WHERE 
			((@IdAllegatoequalthis IS NULL) OR ID_ALLEGATO = @IdAllegatoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@CodTipoDocumentoequalthis IS NULL) OR COD_TIPO_DOCUMENTO = @CodTipoDocumentoequalthis) AND 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@CodEnteEmettitoreequalthis IS NULL) OR COD_ENTE_EMETTITORE = @CodEnteEmettitoreequalthis) AND 
			((@IdComuneequalthis IS NULL) OR ID_COMUNE = @IdComuneequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@CodEsitoequalthis IS NULL) OR COD_ESITO = @CodEsitoequalthis) AND 
			((@InIntegrazioneequalthis IS NULL) OR IN_INTEGRAZIONE = @InIntegrazioneequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CfInserimentoequalthis IS NULL) OR CF_INSERIMENTO = @CfInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@CfModificaequalthis IS NULL) OR CF_MODIFICA = @CfModificaequalthis)
		

GO