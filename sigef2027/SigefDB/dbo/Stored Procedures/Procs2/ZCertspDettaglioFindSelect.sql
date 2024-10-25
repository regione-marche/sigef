CREATE PROCEDURE [dbo].[ZCertspDettaglioFindSelect]
(
	@IdcertspDettaglioequalthis INT, 
	@Idcertspequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@Asseequalthis VARCHAR(255), 
	@Selezionataequalthis BIT, 
	@Esitoequalthis VARCHAR(255), 
	@Dataesitoequalthis DATETIME, 
	@IdFileequalthis INT, 
	@Costototaleequalthis DECIMAL(18,2), 
	@Importoammessoequalthis DECIMAL(18,2), 
	@Importoconcessoequalthis DECIMAL(18,2), 
	@Beneficiarioequalthis VARCHAR(255), 
	@Spesaammessaequalthis DECIMAL(18,2), 
	@Importocontributopubblicoequalthis DECIMAL(18,2), 
	@SpesaammessaIncrementaleequalthis DECIMAL(18,2), 
	@ImportocontributopubblicoIncrementaleequalthis DECIMAL(18,2), 
	@Noteequalthis VARCHAR(2000), 
	@Operatoreequalthis VARCHAR(255), 
	@Datainserimentoequalthis DATETIME, 
	@Datamodificaequalthis DATETIME, 
	@Quotaueequalthis DECIMAL(18,2), 
	@Quotastatoequalthis DECIMAL(18,2), 
	@Quotaregioneequalthis DECIMAL(18,2), 
	@Quotaprivatoequalthis DECIMAL(18,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT IdCertSp_Dettaglio, IdCertSp, Id_Domanda_Pagamento, Id_Progetto, Asse, Selezionata, Esito, DataEsito, Id_File, CostoTotale, ImportoAmmesso, ImportoConcesso, Beneficiario, SpesaAmmessa, ImportoContributoPubblico, SpesaAmmessa_Incrementale, ImportoContributoPubblico_Incrementale, Note, Operatore, DataInserimento, DataModifica, QuotaUe, QuotaStato, QuotaRegione, QuotaPrivato, CodPsr, DataFine, Definitivo, Tipo, Codice_Cup, Cup_Natura_Codice, Cup_Natura_Descrizione, TitoloProgetto, TipoDomanda, Azione, Intervento, Id_Bando FROM vCertSp_Dettaglio WHERE 1=1';
	IF (@IdcertspDettaglioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IdCertSp_Dettaglio = @IdcertspDettaglioequalthis)'; set @lensql=@lensql+len(@IdcertspDettaglioequalthis);end;
	IF (@Idcertspequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IdCertSp = @Idcertspequalthis)'; set @lensql=@lensql+len(@Idcertspequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Id_Domanda_Pagamento = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Id_Progetto = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Asseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Asse = @Asseequalthis)'; set @lensql=@lensql+len(@Asseequalthis);end;
	IF (@Selezionataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Selezionata = @Selezionataequalthis)'; set @lensql=@lensql+len(@Selezionataequalthis);end;
	IF (@Esitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Esito = @Esitoequalthis)'; set @lensql=@lensql+len(@Esitoequalthis);end;
	IF (@Dataesitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataEsito = @Dataesitoequalthis)'; set @lensql=@lensql+len(@Dataesitoequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Id_File = @IdFileequalthis)'; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@Costototaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CostoTotale = @Costototaleequalthis)'; set @lensql=@lensql+len(@Costototaleequalthis);end;
	IF (@Importoammessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ImportoAmmesso = @Importoammessoequalthis)'; set @lensql=@lensql+len(@Importoammessoequalthis);end;
	IF (@Importoconcessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ImportoConcesso = @Importoconcessoequalthis)'; set @lensql=@lensql+len(@Importoconcessoequalthis);end;
	IF (@Beneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Beneficiario = @Beneficiarioequalthis)'; set @lensql=@lensql+len(@Beneficiarioequalthis);end;
	IF (@Spesaammessaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SpesaAmmessa = @Spesaammessaequalthis)'; set @lensql=@lensql+len(@Spesaammessaequalthis);end;
	IF (@Importocontributopubblicoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ImportoContributoPubblico = @Importocontributopubblicoequalthis)'; set @lensql=@lensql+len(@Importocontributopubblicoequalthis);end;
	IF (@SpesaammessaIncrementaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SpesaAmmessa_Incrementale = @SpesaammessaIncrementaleequalthis)'; set @lensql=@lensql+len(@SpesaammessaIncrementaleequalthis);end;
	IF (@ImportocontributopubblicoIncrementaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ImportoContributoPubblico_Incrementale = @ImportocontributopubblicoIncrementaleequalthis)'; set @lensql=@lensql+len(@ImportocontributopubblicoIncrementaleequalthis);end;
	IF (@Noteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Note = @Noteequalthis)'; set @lensql=@lensql+len(@Noteequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Operatore = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Datainserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataInserimento = @Datainserimentoequalthis)'; set @lensql=@lensql+len(@Datainserimentoequalthis);end;
	IF (@Datamodificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataModifica = @Datamodificaequalthis)'; set @lensql=@lensql+len(@Datamodificaequalthis);end;
	IF (@Quotaueequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QuotaUe = @Quotaueequalthis)'; set @lensql=@lensql+len(@Quotaueequalthis);end;
	IF (@Quotastatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QuotaStato = @Quotastatoequalthis)'; set @lensql=@lensql+len(@Quotastatoequalthis);end;
	IF (@Quotaregioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QuotaRegione = @Quotaregioneequalthis)'; set @lensql=@lensql+len(@Quotaregioneequalthis);end;
	IF (@Quotaprivatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QuotaPrivato = @Quotaprivatoequalthis)'; set @lensql=@lensql+len(@Quotaprivatoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdcertspDettaglioequalthis INT, @Idcertspequalthis INT, @IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT, @Asseequalthis VARCHAR(255), @Selezionataequalthis BIT, @Esitoequalthis VARCHAR(255), @Dataesitoequalthis DATETIME, @IdFileequalthis INT, @Costototaleequalthis DECIMAL(18,2), @Importoammessoequalthis DECIMAL(18,2), @Importoconcessoequalthis DECIMAL(18,2), @Beneficiarioequalthis VARCHAR(255), @Spesaammessaequalthis DECIMAL(18,2), @Importocontributopubblicoequalthis DECIMAL(18,2), @SpesaammessaIncrementaleequalthis DECIMAL(18,2), @ImportocontributopubblicoIncrementaleequalthis DECIMAL(18,2), @Noteequalthis VARCHAR(2000), @Operatoreequalthis VARCHAR(255), @Datainserimentoequalthis DATETIME, @Datamodificaequalthis DATETIME, @Quotaueequalthis DECIMAL(18,2), @Quotastatoequalthis DECIMAL(18,2), @Quotaregioneequalthis DECIMAL(18,2), @Quotaprivatoequalthis DECIMAL(18,2)',@IdcertspDettaglioequalthis , @Idcertspequalthis , @IdDomandaPagamentoequalthis , @IdProgettoequalthis , @Asseequalthis , @Selezionataequalthis , @Esitoequalthis , @Dataesitoequalthis , @IdFileequalthis , @Costototaleequalthis , @Importoammessoequalthis , @Importoconcessoequalthis , @Beneficiarioequalthis , @Spesaammessaequalthis , @Importocontributopubblicoequalthis , @SpesaammessaIncrementaleequalthis , @ImportocontributopubblicoIncrementaleequalthis , @Noteequalthis , @Operatoreequalthis , @Datainserimentoequalthis , @Datamodificaequalthis , @Quotaueequalthis , @Quotastatoequalthis , @Quotaregioneequalthis , @Quotaprivatoequalthis ;
	else
		SELECT IdCertSp_Dettaglio, IdCertSp, Id_Domanda_Pagamento, Id_Progetto, Asse, Selezionata, Esito, DataEsito, Id_File, CostoTotale, ImportoAmmesso, ImportoConcesso, Beneficiario, SpesaAmmessa, ImportoContributoPubblico, SpesaAmmessa_Incrementale, ImportoContributoPubblico_Incrementale, Note, Operatore, DataInserimento, DataModifica, QuotaUe, QuotaStato, QuotaRegione, QuotaPrivato, CodPsr, DataFine, Definitivo, Tipo, Codice_Cup, Cup_Natura_Codice, Cup_Natura_Descrizione, TitoloProgetto, TipoDomanda, Azione, Intervento, Id_Bando
		FROM vCertSp_Dettaglio
		WHERE 
			((@IdcertspDettaglioequalthis IS NULL) OR IdCertSp_Dettaglio = @IdcertspDettaglioequalthis) AND 
			((@Idcertspequalthis IS NULL) OR IdCertSp = @Idcertspequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR Id_Domanda_Pagamento = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR Id_Progetto = @IdProgettoequalthis) AND 
			((@Asseequalthis IS NULL) OR Asse = @Asseequalthis) AND 
			((@Selezionataequalthis IS NULL) OR Selezionata = @Selezionataequalthis) AND 
			((@Esitoequalthis IS NULL) OR Esito = @Esitoequalthis) AND 
			((@Dataesitoequalthis IS NULL) OR DataEsito = @Dataesitoequalthis) AND 
			((@IdFileequalthis IS NULL) OR Id_File = @IdFileequalthis) AND 
			((@Costototaleequalthis IS NULL) OR CostoTotale = @Costototaleequalthis) AND 
			((@Importoammessoequalthis IS NULL) OR ImportoAmmesso = @Importoammessoequalthis) AND 
			((@Importoconcessoequalthis IS NULL) OR ImportoConcesso = @Importoconcessoequalthis) AND 
			((@Beneficiarioequalthis IS NULL) OR Beneficiario = @Beneficiarioequalthis) AND 
			((@Spesaammessaequalthis IS NULL) OR SpesaAmmessa = @Spesaammessaequalthis) AND 
			((@Importocontributopubblicoequalthis IS NULL) OR ImportoContributoPubblico = @Importocontributopubblicoequalthis) AND 
			((@SpesaammessaIncrementaleequalthis IS NULL) OR SpesaAmmessa_Incrementale = @SpesaammessaIncrementaleequalthis) AND 
			((@ImportocontributopubblicoIncrementaleequalthis IS NULL) OR ImportoContributoPubblico_Incrementale = @ImportocontributopubblicoIncrementaleequalthis) AND 
			((@Noteequalthis IS NULL) OR Note = @Noteequalthis) AND 
			((@Operatoreequalthis IS NULL) OR Operatore = @Operatoreequalthis) AND 
			((@Datainserimentoequalthis IS NULL) OR DataInserimento = @Datainserimentoequalthis) AND 
			((@Datamodificaequalthis IS NULL) OR DataModifica = @Datamodificaequalthis) AND 
			((@Quotaueequalthis IS NULL) OR QuotaUe = @Quotaueequalthis) AND 
			((@Quotastatoequalthis IS NULL) OR QuotaStato = @Quotastatoequalthis) AND 
			((@Quotaregioneequalthis IS NULL) OR QuotaRegione = @Quotaregioneequalthis) AND 
			((@Quotaprivatoequalthis IS NULL) OR QuotaPrivato = @Quotaprivatoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCertspDettaglioFindSelect]
(
	@IdcertspDettaglioequalthis INT, 
	@Idcertspequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@Asseequalthis VARCHAR(255), 
	@Selezionataequalthis BIT, 
	@Esitoequalthis VARCHAR(255), 
	@Dataesitoequalthis DATETIME, 
	@IdFileequalthis INT, 
	@Costototaleequalthis DECIMAL(18,2), 
	@Importoammessoequalthis DECIMAL(18,2), 
	@Importoconcessoequalthis DECIMAL(18,2), 
	@Beneficiarioequalthis VARCHAR(255), 
	@Spesaammessaequalthis DECIMAL(18,2), 
	@Importocontributopubblicoequalthis DECIMAL(18,2), 
	@SpesaammessaIncrementaleequalthis DECIMAL(18,2), 
	@ImportocontributopubblicoIncrementaleequalthis DECIMAL(18,2), 
	@Noteequalthis VARCHAR(2000), 
	@Operatoreequalthis VARCHAR(255), 
	@Datainserimentoequalthis DATETIME, 
	@Datamodificaequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT IdCertSp_Dettaglio, IdCertSp, Id_Domanda_Pagamento, Id_Progetto, Asse, Selezionata, Esito, DataEsito, Id_File, CostoTotale, ImportoAmmesso, ImportoConcesso, Beneficiario, SpesaAmmessa, ImportoContributoPubblico, SpesaAmmessa_Incrementale, ImportoContributoPubblico_Incrementale, Note, Operatore, DataInserimento, DataModifica, CodPsr, DataFine, Definitivo, Tipo FROM vCertSp_Dettaglio WHERE 1=1'';
	IF (@IdcertspDettaglioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IdCertSp_Dettaglio = @IdcertspDettaglioequalthis)''; set @lensql=@lensql+len(@IdcertspDettaglioequalthis);end;
	IF (@Idcertspequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IdCertSp = @Idcertspequalthis)''; set @lensql=@lensql+len(@Idcertspequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (Id_Domanda_Pagamento = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (Id_Progetto = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Asseequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (Asse = @Asseequalthis)''; set @lensql=@lensql+len(@Asseequalthis);end;
	IF (@Selezionataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (Selezionata = @Selezionataequalthis)''; set @lensql=@lensql+len(@Selezionataequalthis);end;
	IF (@Esitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (Esito = @Esitoequalthis)''; set @lensql=@lensql+len(@Esitoequalthis);end;
	IF (@Dataesitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DataEsito = @Dataesitoequalthis)''; set @lensql=@lensql+len(@Dataesitoequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (Id_File = @IdFileequalthis)''; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@Costototaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CostoTotale = @Costototaleequalthis)''; set @lensql=@lensql+len(@Costototaleequalthis);end;
	IF (@Importoammessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ImportoAmmesso = @Importoammessoequalthis)''; set @lensql=@lensql+len(@Importoammessoequalthis);end;
	IF (@Importoconcessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ImportoConcesso = @Importoconcessoequalthis)''; set @lensql=@lensql+len(@Importoconcessoequalthis);end;
	IF (@Beneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (Beneficiario = @Beneficiarioequalthis)''; set @lensql=@lensql+len(@Beneficiarioequalthis);end;
	IF (@Spesaammessaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SpesaAmmessa = @Spesaammessaequalthis)''; set @lensql=@lensql+len(@Spesaammessaequalthis);end;
	IF (@Importocontributopubblicoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ImportoContributoPubblico = @Importocontributopubblicoequalthis)''; set @lensql=@lensql+len(@Importocontributopubblicoequalthis);end;
	IF (@SpesaammessaIncrementaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SpesaAmmessa_Incrementale = @SpesaammessaIncrementaleequalth', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCertspDettaglioFindSelect';

