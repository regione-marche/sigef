CREATE PROCEDURE [dbo].[ZProgettoComunicazioniDocumentiFindSelect]
(
	@Idequalthis INT, 
	@IdComunicazioneequalthis INT, 
	@IdDomandaPagamentoAllegatiequalthis INT, 
	@IdVarianteAllegatiequalthis INT, 
	@CodTipoDocumentoequalthis VARCHAR(255), 
	@IdFileequalthis INT, 
	@CodEnteEmettitoreequalthis VARCHAR(255), 
	@IdComuneequalthis INT, 
	@Numeroequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@Descrizioneequalthis VARCHAR(255), 
	@IdNoteComunicazioneequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_COMUNICAZIONE, ID_DOMANDA_PAGAMENTO_ALLEGATI, ID_VARIANTE_ALLEGATI, COD_TIPO_DOCUMENTO, ID_FILE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, DESCRIZIONE, ID_NOTE_COMUNICAZIONE, FORMATO, DESCRIZIONE_DOCUMENTO, ATTIVO, ENTE, COD_TIPO_ENTE, NOTE FROM vPROGETTO_COMUNICAZIONI_DOCUMENTI WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdComunicazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNICAZIONE = @IdComunicazioneequalthis)'; set @lensql=@lensql+len(@IdComunicazioneequalthis);end;
	IF (@IdDomandaPagamentoAllegatiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO_ALLEGATI = @IdDomandaPagamentoAllegatiequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoAllegatiequalthis);end;
	IF (@IdVarianteAllegatiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE_ALLEGATI = @IdVarianteAllegatiequalthis)'; set @lensql=@lensql+len(@IdVarianteAllegatiequalthis);end;
	IF (@CodTipoDocumentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_DOCUMENTO = @CodTipoDocumentoequalthis)'; set @lensql=@lensql+len(@CodTipoDocumentoequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE = @IdFileequalthis)'; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@CodEnteEmettitoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE_EMETTITORE = @CodEnteEmettitoreequalthis)'; set @lensql=@lensql+len(@CodEnteEmettitoreequalthis);end;
	IF (@IdComuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNE = @IdComuneequalthis)'; set @lensql=@lensql+len(@IdComuneequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO = @Numeroequalthis)'; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@IdNoteComunicazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_NOTE_COMUNICAZIONE = @IdNoteComunicazioneequalthis)'; set @lensql=@lensql+len(@IdNoteComunicazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdComunicazioneequalthis INT, @IdDomandaPagamentoAllegatiequalthis INT, @IdVarianteAllegatiequalthis INT, @CodTipoDocumentoequalthis VARCHAR(255), @IdFileequalthis INT, @CodEnteEmettitoreequalthis VARCHAR(255), @IdComuneequalthis INT, @Numeroequalthis VARCHAR(255), @Dataequalthis DATETIME, @Descrizioneequalthis VARCHAR(255), @IdNoteComunicazioneequalthis INT',@Idequalthis , @IdComunicazioneequalthis , @IdDomandaPagamentoAllegatiequalthis , @IdVarianteAllegatiequalthis , @CodTipoDocumentoequalthis , @IdFileequalthis , @CodEnteEmettitoreequalthis , @IdComuneequalthis , @Numeroequalthis , @Dataequalthis , @Descrizioneequalthis , @IdNoteComunicazioneequalthis ;
	else
		SELECT ID, ID_COMUNICAZIONE, ID_DOMANDA_PAGAMENTO_ALLEGATI, ID_VARIANTE_ALLEGATI, COD_TIPO_DOCUMENTO, ID_FILE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, DESCRIZIONE, ID_NOTE_COMUNICAZIONE, FORMATO, DESCRIZIONE_DOCUMENTO, ATTIVO, ENTE, COD_TIPO_ENTE, NOTE
		FROM vPROGETTO_COMUNICAZIONI_DOCUMENTI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdComunicazioneequalthis IS NULL) OR ID_COMUNICAZIONE = @IdComunicazioneequalthis) AND 
			((@IdDomandaPagamentoAllegatiequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO_ALLEGATI = @IdDomandaPagamentoAllegatiequalthis) AND 
			((@IdVarianteAllegatiequalthis IS NULL) OR ID_VARIANTE_ALLEGATI = @IdVarianteAllegatiequalthis) AND 
			((@CodTipoDocumentoequalthis IS NULL) OR COD_TIPO_DOCUMENTO = @CodTipoDocumentoequalthis) AND 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@CodEnteEmettitoreequalthis IS NULL) OR COD_ENTE_EMETTITORE = @CodEnteEmettitoreequalthis) AND 
			((@IdComuneequalthis IS NULL) OR ID_COMUNE = @IdComuneequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@IdNoteComunicazioneequalthis IS NULL) OR ID_NOTE_COMUNICAZIONE = @IdNoteComunicazioneequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoComunicazioniDocumentiFindSelect]
(
	@Idequalthis INT, 
	@IdComunicazioneequalthis INT, 
	@CodTipoDocumentoequalthis VARCHAR(255), 
	@IdFileequalthis INT, 
	@CodEnteEmettitoreequalthis VARCHAR(255), 
	@IdComuneequalthis INT, 
	@Numeroequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@Descrizioneequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_COMUNICAZIONE, COD_TIPO_DOCUMENTO, ID_FILE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, DESCRIZIONE, FORMATO, DESCRIZIONE_DOCUMENTO, ATTIVO, ENTE, COD_TIPO_ENTE FROM vPROGETTO_COMUNICAZIONI_DOCUMENTI WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdComunicazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_COMUNICAZIONE = @IdComunicazioneequalthis)''; set @lensql=@lensql+len(@IdComunicazioneequalthis);end;
	IF (@CodTipoDocumentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO_DOCUMENTO = @CodTipoDocumentoequalthis)''; set @lensql=@lensql+len(@CodTipoDocumentoequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_FILE = @IdFileequalthis)''; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@CodEnteEmettitoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ENTE_EMETTITORE = @CodEnteEmettitoreequalthis)''; set @lensql=@lensql+len(@CodEnteEmettitoreequalthis);end;
	IF (@IdComuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_COMUNE = @IdComuneequalthis)''; set @lensql=@lensql+len(@IdComuneequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NUMERO = @Numeroequalthis)''; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA = @Dataequalthis)''; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idequalthis INT, @IdComunicazioneequalthis INT, @CodTipoDocumentoequalthis VARCHAR(255), @IdFileequalthis INT, @CodEnteEmettitoreequalthis VARCHAR(255), @IdComuneequalthis INT, @Numeroequalthis VARCHAR(255), @Dataequalthis DATETIME, @Descrizioneequalthis VARCHAR(255)'',@Idequalthis , @IdComunicazioneequalthis , @CodTipoDocumentoequalthis , @IdFileequalthis , @CodEnteEmettitoreequalthis , @IdComuneequalthis , @Numeroequalthis , @Dataequalthis , @Descrizioneequalthis ;
	else
		SELECT ID, ID_COMUNICAZIONE, COD_TIPO_DOCUMENTO, ID_FILE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, DESCRIZIONE, FORMATO, DESCRIZIONE_DOCUMENTO, ATTIVO, ENTE, COD_TIPO_ENTE
		FROM vPROGETTO_COMUNICAZIONI_DOCUMENTI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdComunicazioneequalthis IS NULL) OR ID_COMUNICAZIONE = @IdComunicazioneequalthis) AND 
			((@CodTipoDocumentoequalthis IS NULL) OR COD_TIPO_DOCUMENTO = @CodTipoDocumentoequalthis) AND 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@CodEnteEmettitoreequalthis IS NULL) OR COD_ENTE_EMETTITORE = @CodEnteEmettitoreequalthis) AND 
			((@IdComuneequalthis IS NULL) OR ID_COMUNE = @IdComuneequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioniDocumentiFindSelect';

