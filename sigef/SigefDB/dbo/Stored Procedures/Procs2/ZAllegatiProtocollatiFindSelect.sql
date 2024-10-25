CREATE PROCEDURE [dbo].[ZAllegatiProtocollatiFindSelect]
(
	@IdAllegatoProtocollatoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdVarianteequalthis INT, 
	@IdIntegrazioneequalthis INT, 
	@IdComunicazioneequalthis INT, 
	@IdFileequalthis INT, 
	@Protocollatoequalthis BIT, 
	@Protocolloequalthis NVARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@DataModificaequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ALLEGATO_PROTOCOLLATO, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, ID_INTEGRAZIONE, ID_COMUNICAZIONE, ID_FILE, PROTOCOLLATO, PROTOCOLLO, DATA_INSERIMENTO, DATA_MODIFICA FROM ALLEGATI_PROTOCOLLATI WHERE 1=1';
	IF (@IdAllegatoProtocollatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ALLEGATO_PROTOCOLLATO = @IdAllegatoProtocollatoequalthis)'; set @lensql=@lensql+len(@IdAllegatoProtocollatoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@IdIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INTEGRAZIONE = @IdIntegrazioneequalthis)'; set @lensql=@lensql+len(@IdIntegrazioneequalthis);end;
	IF (@IdComunicazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNICAZIONE = @IdComunicazioneequalthis)'; set @lensql=@lensql+len(@IdComunicazioneequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE = @IdFileequalthis)'; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@Protocollatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROTOCOLLATO = @Protocollatoequalthis)'; set @lensql=@lensql+len(@Protocollatoequalthis);end;
	IF (@Protocolloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROTOCOLLO = @Protocolloequalthis)'; set @lensql=@lensql+len(@Protocolloequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdAllegatoProtocollatoequalthis INT, @IdProgettoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdVarianteequalthis INT, @IdIntegrazioneequalthis INT, @IdComunicazioneequalthis INT, @IdFileequalthis INT, @Protocollatoequalthis BIT, @Protocolloequalthis NVARCHAR(255), @DataInserimentoequalthis DATETIME, @DataModificaequalthis DATETIME',@IdAllegatoProtocollatoequalthis , @IdProgettoequalthis , @IdDomandaPagamentoequalthis , @IdVarianteequalthis , @IdIntegrazioneequalthis , @IdComunicazioneequalthis , @IdFileequalthis , @Protocollatoequalthis , @Protocolloequalthis , @DataInserimentoequalthis , @DataModificaequalthis ;
	else
		SELECT ID_ALLEGATO_PROTOCOLLATO, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, ID_INTEGRAZIONE, ID_COMUNICAZIONE, ID_FILE, PROTOCOLLATO, PROTOCOLLO, DATA_INSERIMENTO, DATA_MODIFICA
		FROM ALLEGATI_PROTOCOLLATI
		WHERE 
			((@IdAllegatoProtocollatoequalthis IS NULL) OR ID_ALLEGATO_PROTOCOLLATO = @IdAllegatoProtocollatoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@IdIntegrazioneequalthis IS NULL) OR ID_INTEGRAZIONE = @IdIntegrazioneequalthis) AND 
			((@IdComunicazioneequalthis IS NULL) OR ID_COMUNICAZIONE = @IdComunicazioneequalthis) AND 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@Protocollatoequalthis IS NULL) OR PROTOCOLLATO = @Protocollatoequalthis) AND 
			((@Protocolloequalthis IS NULL) OR PROTOCOLLO = @Protocolloequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZAllegatiProtocollatiFindSelect]
(
	@IdAllegatoProtocollatoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdVarianteequalthis INT, 
	@IdIntegrazioneequalthis INT, 
	@IdFileequalthis INT, 
	@Protocollatoequalthis BIT, 
	@Protocolloequalthis NVARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@DataModificaequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_ALLEGATO_PROTOCOLLATO, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, ID_INTEGRAZIONE, ID_FILE, PROTOCOLLATO, PROTOCOLLO, DATA_INSERIMENTO, DATA_MODIFICA FROM ALLEGATI_PROTOCOLLATI WHERE 1=1'';
	IF (@IdAllegatoProtocollatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_ALLEGATO_PROTOCOLLATO = @IdAllegatoProtocollatoequalthis)''; set @lensql=@lensql+len(@IdAllegatoProtocollatoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VARIANTE = @IdVarianteequalthis)''; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@IdIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_INTEGRAZIONE = @IdIntegrazioneequalthis)''; set @lensql=@lensql+len(@IdIntegrazioneequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_FILE = @IdFileequalthis)''; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@Protocollatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PROTOCOLLATO = @Protocollatoequalthis)''; set @lensql=@lensql+len(@Protocollatoequalthis);end;
	IF (@Protocolloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PROTOCOLLO = @Protocolloequalthis)''; set @lensql=@lensql+len(@Protocolloequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)''; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_MODIFICA = @DataModificaequalthis)''; set @lensql=@lensql+len(@DataModificaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdAllegatoProtocollatoequalthis INT, @IdProgettoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdVarianteequalthis INT, @IdIntegrazioneequalthis INT, @IdFileequalthis INT, @Protocollatoequalthis BIT, @Protocolloequalthis NVARCHAR(255), @DataInserimentoequalthis DATETIME, @DataModificaequalthis DATETIME'',@IdAllegatoProtocollatoequalthis , @IdProgettoequalthis , @IdDomandaPagamentoequalthis , @IdVarianteequalthis , @IdIntegrazioneequalthis , @IdFileequalthis , @Protocollatoequalthis , @Protocolloequalthis , @DataInserimentoequalthis , @DataModificaequalthis ;
	else
		SELECT ID_ALLEGATO_PROTOCOLLATO, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, ID_INTEGRAZIONE, ID_FILE, PROTOCOLLATO, PROTOCOLLO, DATA_INSERIMENTO, DATA_MODIFICA
		FROM ALLEGATI_PROTOCOLLATI
		WHERE 
			((@IdAllegatoProtocollatoequalthis IS NULL) OR ID_ALLEGATO_PROTOCOLLATO = @IdAllegatoProtocollatoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@IdIntegrazioneequalthis IS NULL) OR ID_INTEGRAZIONE = @IdIntegrazioneequalthis) AND 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@Protocollatoequalthis IS NULL) OR PROTOCOLLATO = @Protocollatoequalthis) AND 
			((@Protocolloequalthis IS NULL) OR PROTOCOLLO = @Protocolloequalthis) AND 
			((@DataInseriment', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAllegatiProtocollatiFindSelect';

