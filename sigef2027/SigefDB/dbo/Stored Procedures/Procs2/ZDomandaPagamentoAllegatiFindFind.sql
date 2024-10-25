CREATE PROCEDURE [dbo].[ZDomandaPagamentoAllegatiFindFind]
(
	@IdDomandaPagamentoequalthis INT, 
	@CodTipoDocumentoequalthis VARCHAR(255), 
	@Formatoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ALLEGATO, ID_DOMANDA_PAGAMENTO, COD_TIPO_DOCUMENTO, ID_FILE, DESCRIZIONE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, COD_ESITO, NOTE_ISTRUTTORE, ESITO, ESITO_POSITIVO, FORMATO, TIPO_ALLEGATO, TIPOLOGIA_DOCUMENTO, ENTE, DIMENSIONE_FILE, IN_INTEGRAZIONE, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA FROM vDOMANDA_PAGAMENTO_ALLEGATI WHERE 1=1';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@CodTipoDocumentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_DOCUMENTO = @CodTipoDocumentoequalthis)'; set @lensql=@lensql+len(@CodTipoDocumentoequalthis);end;
	IF (@Formatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FORMATO = @Formatoequalthis)'; set @lensql=@lensql+len(@Formatoequalthis);end;
	set @sql = @sql + 'ORDER BY ID_ALLEGATO, DATA_INSERIMENTO';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDomandaPagamentoequalthis INT, @CodTipoDocumentoequalthis VARCHAR(255), @Formatoequalthis VARCHAR(255)',@IdDomandaPagamentoequalthis , @CodTipoDocumentoequalthis , @Formatoequalthis ;
	else
		SELECT ID_ALLEGATO, ID_DOMANDA_PAGAMENTO, COD_TIPO_DOCUMENTO, ID_FILE, DESCRIZIONE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, COD_ESITO, NOTE_ISTRUTTORE, ESITO, ESITO_POSITIVO, FORMATO, TIPO_ALLEGATO, TIPOLOGIA_DOCUMENTO, ENTE, DIMENSIONE_FILE, IN_INTEGRAZIONE, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA
		FROM vDOMANDA_PAGAMENTO_ALLEGATI
		WHERE 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@CodTipoDocumentoequalthis IS NULL) OR COD_TIPO_DOCUMENTO = @CodTipoDocumentoequalthis) AND 
			((@Formatoequalthis IS NULL) OR FORMATO = @Formatoequalthis)
		ORDER BY ID_ALLEGATO, DATA_INSERIMENTO

GO