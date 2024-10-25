CREATE PROCEDURE [dbo].[ZProgettoComunicazioniDocumentiFindFind]
(
	@IdComunicazioneequalthis INT, 
	@IdDomandaPagamentoAllegatiequalthis INT, 
	@IdVarianteAllegatiequalthis INT, 
	@CodTipoDocumentoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_COMUNICAZIONE, ID_DOMANDA_PAGAMENTO_ALLEGATI, ID_VARIANTE_ALLEGATI, COD_TIPO_DOCUMENTO, ID_FILE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, DESCRIZIONE, ID_NOTE_COMUNICAZIONE, FORMATO, DESCRIZIONE_DOCUMENTO, ATTIVO, ENTE, COD_TIPO_ENTE, NOTE FROM vPROGETTO_COMUNICAZIONI_DOCUMENTI WHERE 1=1';
	IF (@IdComunicazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNICAZIONE = @IdComunicazioneequalthis)'; set @lensql=@lensql+len(@IdComunicazioneequalthis);end;
	IF (@IdDomandaPagamentoAllegatiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO_ALLEGATI = @IdDomandaPagamentoAllegatiequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoAllegatiequalthis);end;
	IF (@IdVarianteAllegatiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE_ALLEGATI = @IdVarianteAllegatiequalthis)'; set @lensql=@lensql+len(@IdVarianteAllegatiequalthis);end;
	IF (@CodTipoDocumentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_DOCUMENTO = @CodTipoDocumentoequalthis)'; set @lensql=@lensql+len(@CodTipoDocumentoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdComunicazioneequalthis INT, @IdDomandaPagamentoAllegatiequalthis INT, @IdVarianteAllegatiequalthis INT, @CodTipoDocumentoequalthis VARCHAR(255)',@IdComunicazioneequalthis , @IdDomandaPagamentoAllegatiequalthis , @IdVarianteAllegatiequalthis , @CodTipoDocumentoequalthis ;
	else
		SELECT ID, ID_COMUNICAZIONE, ID_DOMANDA_PAGAMENTO_ALLEGATI, ID_VARIANTE_ALLEGATI, COD_TIPO_DOCUMENTO, ID_FILE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, DESCRIZIONE, ID_NOTE_COMUNICAZIONE, FORMATO, DESCRIZIONE_DOCUMENTO, ATTIVO, ENTE, COD_TIPO_ENTE, NOTE
		FROM vPROGETTO_COMUNICAZIONI_DOCUMENTI
		WHERE 
			((@IdComunicazioneequalthis IS NULL) OR ID_COMUNICAZIONE = @IdComunicazioneequalthis) AND 
			((@IdDomandaPagamentoAllegatiequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO_ALLEGATI = @IdDomandaPagamentoAllegatiequalthis) AND 
			((@IdVarianteAllegatiequalthis IS NULL) OR ID_VARIANTE_ALLEGATI = @IdVarianteAllegatiequalthis) AND 
			((@CodTipoDocumentoequalthis IS NULL) OR COD_TIPO_DOCUMENTO = @CodTipoDocumentoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoComunicazioniDocumentiFindFind]
(
	@IdComunicazioneequalthis INT, 
	@CodTipoDocumentoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_COMUNICAZIONE, COD_TIPO_DOCUMENTO, ID_FILE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, DESCRIZIONE, FORMATO, DESCRIZIONE_DOCUMENTO, ATTIVO, ENTE, COD_TIPO_ENTE FROM vPROGETTO_COMUNICAZIONI_DOCUMENTI WHERE 1=1'';
	IF (@IdComunicazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_COMUNICAZIONE = @IdComunicazioneequalthis)''; set @lensql=@lensql+len(@IdComunicazioneequalthis);end;
	IF (@CodTipoDocumentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO_DOCUMENTO = @CodTipoDocumentoequalthis)''; set @lensql=@lensql+len(@CodTipoDocumentoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdComunicazioneequalthis INT, @CodTipoDocumentoequalthis VARCHAR(255)'',@IdComunicazioneequalthis , @CodTipoDocumentoequalthis ;
	else
		SELECT ID, ID_COMUNICAZIONE, COD_TIPO_DOCUMENTO, ID_FILE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, DESCRIZIONE, FORMATO, DESCRIZIONE_DOCUMENTO, ATTIVO, ENTE, COD_TIPO_ENTE
		FROM vPROGETTO_COMUNICAZIONI_DOCUMENTI
		WHERE 
			((@IdComunicazioneequalthis IS NULL) OR ID_COMUNICAZIONE = @IdComunicazioneequalthis) AND 
			((@CodTipoDocumentoequalthis IS NULL) OR COD_TIPO_DOCUMENTO = @CodTipoDocumentoequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioniDocumentiFindFind';

