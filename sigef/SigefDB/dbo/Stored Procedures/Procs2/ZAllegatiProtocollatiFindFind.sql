CREATE PROCEDURE [dbo].[ZAllegatiProtocollatiFindFind]
(
	@IdProgettoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdVarianteequalthis INT, 
	@IdIntegrazioneequalthis INT, 
	@IdComunicazioneequalthis INT, 
	@IdFileequalthis INT, 
	@Protocollatoequalthis BIT, 
	@Protocolloequalthis NVARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ALLEGATO_PROTOCOLLATO, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, ID_INTEGRAZIONE, ID_COMUNICAZIONE, ID_FILE, PROTOCOLLATO, PROTOCOLLO, DATA_INSERIMENTO, DATA_MODIFICA FROM ALLEGATI_PROTOCOLLATI WHERE 1=1';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@IdIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INTEGRAZIONE = @IdIntegrazioneequalthis)'; set @lensql=@lensql+len(@IdIntegrazioneequalthis);end;
	IF (@IdComunicazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNICAZIONE = @IdComunicazioneequalthis)'; set @lensql=@lensql+len(@IdComunicazioneequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE = @IdFileequalthis)'; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@Protocollatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROTOCOLLATO = @Protocollatoequalthis)'; set @lensql=@lensql+len(@Protocollatoequalthis);end;
	IF (@Protocolloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROTOCOLLO = @Protocolloequalthis)'; set @lensql=@lensql+len(@Protocolloequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdVarianteequalthis INT, @IdIntegrazioneequalthis INT, @IdComunicazioneequalthis INT, @IdFileequalthis INT, @Protocollatoequalthis BIT, @Protocolloequalthis NVARCHAR(255)',@IdProgettoequalthis , @IdDomandaPagamentoequalthis , @IdVarianteequalthis , @IdIntegrazioneequalthis , @IdComunicazioneequalthis , @IdFileequalthis , @Protocollatoequalthis , @Protocolloequalthis ;
	else
		SELECT ID_ALLEGATO_PROTOCOLLATO, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, ID_INTEGRAZIONE, ID_COMUNICAZIONE, ID_FILE, PROTOCOLLATO, PROTOCOLLO, DATA_INSERIMENTO, DATA_MODIFICA
		FROM ALLEGATI_PROTOCOLLATI
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@IdIntegrazioneequalthis IS NULL) OR ID_INTEGRAZIONE = @IdIntegrazioneequalthis) AND 
			((@IdComunicazioneequalthis IS NULL) OR ID_COMUNICAZIONE = @IdComunicazioneequalthis) AND 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@Protocollatoequalthis IS NULL) OR PROTOCOLLATO = @Protocollatoequalthis) AND 
			((@Protocolloequalthis IS NULL) OR PROTOCOLLO = @Protocolloequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZAllegatiProtocollatiFindFind]
(
	@IdProgettoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdVarianteequalthis INT, 
	@IdIntegrazioneequalthis INT, 
	@IdFileequalthis INT, 
	@Protocollatoequalthis BIT, 
	@Protocolloequalthis NVARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_ALLEGATO_PROTOCOLLATO, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, ID_INTEGRAZIONE, ID_FILE, PROTOCOLLATO, PROTOCOLLO, DATA_INSERIMENTO, DATA_MODIFICA FROM ALLEGATI_PROTOCOLLATI WHERE 1=1'';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VARIANTE = @IdVarianteequalthis)''; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@IdIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_INTEGRAZIONE = @IdIntegrazioneequalthis)''; set @lensql=@lensql+len(@IdIntegrazioneequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_FILE = @IdFileequalthis)''; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@Protocollatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PROTOCOLLATO = @Protocollatoequalthis)''; set @lensql=@lensql+len(@Protocollatoequalthis);end;
	IF (@Protocolloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PROTOCOLLO = @Protocolloequalthis)''; set @lensql=@lensql+len(@Protocolloequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdProgettoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdVarianteequalthis INT, @IdIntegrazioneequalthis INT, @IdFileequalthis INT, @Protocollatoequalthis BIT, @Protocolloequalthis NVARCHAR(255)'',@IdProgettoequalthis , @IdDomandaPagamentoequalthis , @IdVarianteequalthis , @IdIntegrazioneequalthis , @IdFileequalthis , @Protocollatoequalthis , @Protocolloequalthis ;
	else
		SELECT ID_ALLEGATO_PROTOCOLLATO, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, ID_INTEGRAZIONE, ID_FILE, PROTOCOLLATO, PROTOCOLLO, DATA_INSERIMENTO, DATA_MODIFICA
		FROM ALLEGATI_PROTOCOLLATI
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@IdIntegrazioneequalthis IS NULL) OR ID_INTEGRAZIONE = @IdIntegrazioneequalthis) AND 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@Protocollatoequalthis IS NULL) OR PROTOCOLLATO = @Protocollatoequalthis) AND 
			((@Protocolloequalthis IS NULL) OR PROTOCOLLO = @Protocolloequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAllegatiProtocollatiFindFind';

