CREATE PROCEDURE [dbo].[ZDomandaPagamentoAllegatiFindGetallegatidomandainintegrazione]
(
	@IdDomandaPagamentoequalthis INT, 
	@InIntegrazioneequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ALLEGATO, ID_DOMANDA_PAGAMENTO, COD_TIPO_DOCUMENTO, ID_FILE, DESCRIZIONE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, COD_ESITO, NOTE_ISTRUTTORE, ESITO, ESITO_POSITIVO, FORMATO, TIPO_ALLEGATO, TIPOLOGIA_DOCUMENTO, ENTE, DIMENSIONE_FILE, IN_INTEGRAZIONE, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA FROM vDOMANDA_PAGAMENTO_ALLEGATI WHERE 1=1';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@InIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IN_INTEGRAZIONE = @InIntegrazioneequalthis)'; set @lensql=@lensql+len(@InIntegrazioneequalthis);end;
	set @sql = @sql + 'ORDER BY ID_ALLEGATO, DATA_INSERIMENTO';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDomandaPagamentoequalthis INT, @InIntegrazioneequalthis BIT',@IdDomandaPagamentoequalthis , @InIntegrazioneequalthis ;
	else
		SELECT ID_ALLEGATO, ID_DOMANDA_PAGAMENTO, COD_TIPO_DOCUMENTO, ID_FILE, DESCRIZIONE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, COD_ESITO, NOTE_ISTRUTTORE, ESITO, ESITO_POSITIVO, FORMATO, TIPO_ALLEGATO, TIPOLOGIA_DOCUMENTO, ENTE, DIMENSIONE_FILE, IN_INTEGRAZIONE, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA
		FROM vDOMANDA_PAGAMENTO_ALLEGATI
		WHERE 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@InIntegrazioneequalthis IS NULL) OR IN_INTEGRAZIONE = @InIntegrazioneequalthis)
		ORDER BY ID_ALLEGATO, DATA_INSERIMENTO

GO