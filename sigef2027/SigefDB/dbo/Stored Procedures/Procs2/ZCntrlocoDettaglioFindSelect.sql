CREATE PROCEDURE [dbo].[ZCntrlocoDettaglioFindSelect]
(
	@IdlocoDettaglioequalthis INT, 
	@Idlocoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@Asseequalthis VARCHAR(255), 
	@Selezionataequalthis BIT, 
	@Esitoequalthis VARCHAR(255), 
	@Dataesitoequalthis DATETIME, 
	@Costototaleequalthis DECIMAL(18,2), 
	@Importoammessoequalthis DECIMAL(18,2), 
	@Importoconcessoequalthis DECIMAL(18,2), 
	@Nroperazionibequalthis INT, 
	@Beneficiarioequalthis VARCHAR(255), 
	@Spesaammessaequalthis DECIMAL(18,2), 
	@Importocontributopubblicoequalthis DECIMAL(18,2), 
	@SpesaammessaIncrementaleequalthis DECIMAL(18,2), 
	@ImportocontributopubblicoIncrementaleequalthis DECIMAL(18,2), 
	@Esclusioneequalthis VARCHAR(255), 
	@Rischioirequalthis DECIMAL(6,2), 
	@Rischiocrequalthis DECIMAL(6,2), 
	@Rischiocompequalthis VARCHAR(255), 
	@Operatoreequalthis VARCHAR(255), 
	@Datainserimentoequalthis DATETIME, 
	@Datamodificaequalthis DATETIME, 
	@Azioneequalthis VARCHAR(255), 
	@Interventoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT IdLoco_Dettaglio, IdLoco, Id_Domanda_Pagamento, Id_Progetto, Asse, Selezionata, Esito, DataEsito, CostoTotale, ImportoAmmesso, ImportoConcesso, NrOperazioniB, Beneficiario, SpesaAmmessa, ImportoContributoPubblico, SpesaAmmessa_Incrementale, ImportoContributoPubblico_Incrementale, Esclusione, RischioIR, RischioCR, RischioComp, Operatore, DataInserimento, DataModifica, Azione, Intervento, CodPsr, DataFine, Definitivo, Codice_Cup, Cup_Natura_Codice, Cup_Natura_Descrizione, TitoloProgetto, TipoDomanda FROM vCntrLoco_Dettaglio WHERE 1=1';
	IF (@IdlocoDettaglioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IdLoco_Dettaglio = @IdlocoDettaglioequalthis)'; set @lensql=@lensql+len(@IdlocoDettaglioequalthis);end;
	IF (@Idlocoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IdLoco = @Idlocoequalthis)'; set @lensql=@lensql+len(@Idlocoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Id_Domanda_Pagamento = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Id_Progetto = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Asseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Asse = @Asseequalthis)'; set @lensql=@lensql+len(@Asseequalthis);end;
	IF (@Selezionataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Selezionata = @Selezionataequalthis)'; set @lensql=@lensql+len(@Selezionataequalthis);end;
	IF (@Esitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Esito = @Esitoequalthis)'; set @lensql=@lensql+len(@Esitoequalthis);end;
	IF (@Dataesitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataEsito = @Dataesitoequalthis)'; set @lensql=@lensql+len(@Dataesitoequalthis);end;
	IF (@Costototaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CostoTotale = @Costototaleequalthis)'; set @lensql=@lensql+len(@Costototaleequalthis);end;
	IF (@Importoammessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ImportoAmmesso = @Importoammessoequalthis)'; set @lensql=@lensql+len(@Importoammessoequalthis);end;
	IF (@Importoconcessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ImportoConcesso = @Importoconcessoequalthis)'; set @lensql=@lensql+len(@Importoconcessoequalthis);end;
	IF (@Nroperazionibequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NrOperazioniB = @Nroperazionibequalthis)'; set @lensql=@lensql+len(@Nroperazionibequalthis);end;
	IF (@Beneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Beneficiario = @Beneficiarioequalthis)'; set @lensql=@lensql+len(@Beneficiarioequalthis);end;
	IF (@Spesaammessaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SpesaAmmessa = @Spesaammessaequalthis)'; set @lensql=@lensql+len(@Spesaammessaequalthis);end;
	IF (@Importocontributopubblicoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ImportoContributoPubblico = @Importocontributopubblicoequalthis)'; set @lensql=@lensql+len(@Importocontributopubblicoequalthis);end;
	IF (@SpesaammessaIncrementaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SpesaAmmessa_Incrementale = @SpesaammessaIncrementaleequalthis)'; set @lensql=@lensql+len(@SpesaammessaIncrementaleequalthis);end;
	IF (@ImportocontributopubblicoIncrementaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ImportoContributoPubblico_Incrementale = @ImportocontributopubblicoIncrementaleequalthis)'; set @lensql=@lensql+len(@ImportocontributopubblicoIncrementaleequalthis);end;
	IF (@Esclusioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Esclusione = @Esclusioneequalthis)'; set @lensql=@lensql+len(@Esclusioneequalthis);end;
	IF (@Rischioirequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RischioIR = @Rischioirequalthis)'; set @lensql=@lensql+len(@Rischioirequalthis);end;
	IF (@Rischiocrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RischioCR = @Rischiocrequalthis)'; set @lensql=@lensql+len(@Rischiocrequalthis);end;
	IF (@Rischiocompequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RischioComp = @Rischiocompequalthis)'; set @lensql=@lensql+len(@Rischiocompequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Operatore = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Datainserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataInserimento = @Datainserimentoequalthis)'; set @lensql=@lensql+len(@Datainserimentoequalthis);end;
	IF (@Datamodificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataModifica = @Datamodificaequalthis)'; set @lensql=@lensql+len(@Datamodificaequalthis);end;
	IF (@Azioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Azione = @Azioneequalthis)'; set @lensql=@lensql+len(@Azioneequalthis);end;
	IF (@Interventoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Intervento = @Interventoequalthis)'; set @lensql=@lensql+len(@Interventoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdlocoDettaglioequalthis INT, @Idlocoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT, @Asseequalthis VARCHAR(255), @Selezionataequalthis BIT, @Esitoequalthis VARCHAR(255), @Dataesitoequalthis DATETIME, @Costototaleequalthis DECIMAL(18,2), @Importoammessoequalthis DECIMAL(18,2), @Importoconcessoequalthis DECIMAL(18,2), @Nroperazionibequalthis INT, @Beneficiarioequalthis VARCHAR(255), @Spesaammessaequalthis DECIMAL(18,2), @Importocontributopubblicoequalthis DECIMAL(18,2), @SpesaammessaIncrementaleequalthis DECIMAL(18,2), @ImportocontributopubblicoIncrementaleequalthis DECIMAL(18,2), @Esclusioneequalthis VARCHAR(255), @Rischioirequalthis DECIMAL(6,2), @Rischiocrequalthis DECIMAL(6,2), @Rischiocompequalthis VARCHAR(255), @Operatoreequalthis VARCHAR(255), @Datainserimentoequalthis DATETIME, @Datamodificaequalthis DATETIME, @Azioneequalthis VARCHAR(255), @Interventoequalthis VARCHAR(255)',@IdlocoDettaglioequalthis , @Idlocoequalthis , @IdDomandaPagamentoequalthis , @IdProgettoequalthis , @Asseequalthis , @Selezionataequalthis , @Esitoequalthis , @Dataesitoequalthis , @Costototaleequalthis , @Importoammessoequalthis , @Importoconcessoequalthis , @Nroperazionibequalthis , @Beneficiarioequalthis , @Spesaammessaequalthis , @Importocontributopubblicoequalthis , @SpesaammessaIncrementaleequalthis , @ImportocontributopubblicoIncrementaleequalthis , @Esclusioneequalthis , @Rischioirequalthis , @Rischiocrequalthis , @Rischiocompequalthis , @Operatoreequalthis , @Datainserimentoequalthis , @Datamodificaequalthis , @Azioneequalthis , @Interventoequalthis ;
	else
		SELECT IdLoco_Dettaglio, IdLoco, Id_Domanda_Pagamento, Id_Progetto, Asse, Selezionata, Esito, DataEsito, CostoTotale, ImportoAmmesso, ImportoConcesso, NrOperazioniB, Beneficiario, SpesaAmmessa, ImportoContributoPubblico, SpesaAmmessa_Incrementale, ImportoContributoPubblico_Incrementale, Esclusione, RischioIR, RischioCR, RischioComp, Operatore, DataInserimento, DataModifica, Azione, Intervento, CodPsr, DataFine, Definitivo, Codice_Cup, Cup_Natura_Codice, Cup_Natura_Descrizione, TitoloProgetto, TipoDomanda
		FROM vCntrLoco_Dettaglio
		WHERE 
			((@IdlocoDettaglioequalthis IS NULL) OR IdLoco_Dettaglio = @IdlocoDettaglioequalthis) AND 
			((@Idlocoequalthis IS NULL) OR IdLoco = @Idlocoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR Id_Domanda_Pagamento = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR Id_Progetto = @IdProgettoequalthis) AND 
			((@Asseequalthis IS NULL) OR Asse = @Asseequalthis) AND 
			((@Selezionataequalthis IS NULL) OR Selezionata = @Selezionataequalthis) AND 
			((@Esitoequalthis IS NULL) OR Esito = @Esitoequalthis) AND 
			((@Dataesitoequalthis IS NULL) OR DataEsito = @Dataesitoequalthis) AND 
			((@Costototaleequalthis IS NULL) OR CostoTotale = @Costototaleequalthis) AND 
			((@Importoammessoequalthis IS NULL) OR ImportoAmmesso = @Importoammessoequalthis) AND 
			((@Importoconcessoequalthis IS NULL) OR ImportoConcesso = @Importoconcessoequalthis) AND 
			((@Nroperazionibequalthis IS NULL) OR NrOperazioniB = @Nroperazionibequalthis) AND 
			((@Beneficiarioequalthis IS NULL) OR Beneficiario = @Beneficiarioequalthis) AND 
			((@Spesaammessaequalthis IS NULL) OR SpesaAmmessa = @Spesaammessaequalthis) AND 
			((@Importocontributopubblicoequalthis IS NULL) OR ImportoContributoPubblico = @Importocontributopubblicoequalthis) AND 
			((@SpesaammessaIncrementaleequalthis IS NULL) OR SpesaAmmessa_Incrementale = @SpesaammessaIncrementaleequalthis) AND 
			((@ImportocontributopubblicoIncrementaleequalthis IS NULL) OR ImportoContributoPubblico_Incrementale = @ImportocontributopubblicoIncrementaleequalthis) AND 
			((@Esclusioneequalthis IS NULL) OR Esclusione = @Esclusioneequalthis) AND 
			((@Rischioirequalthis IS NULL) OR RischioIR = @Rischioirequalthis) AND 
			((@Rischiocrequalthis IS NULL) OR RischioCR = @Rischiocrequalthis) AND 
			((@Rischiocompequalthis IS NULL) OR RischioComp = @Rischiocompequalthis) AND 
			((@Operatoreequalthis IS NULL) OR Operatore = @Operatoreequalthis) AND 
			((@Datainserimentoequalthis IS NULL) OR DataInserimento = @Datainserimentoequalthis) AND 
			((@Datamodificaequalthis IS NULL) OR DataModifica = @Datamodificaequalthis) AND 
			((@Azioneequalthis IS NULL) OR Azione = @Azioneequalthis) AND 
			((@Interventoequalthis IS NULL) OR Intervento = @Interventoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCntrlocoDettaglioFindSelect]
(
	@IdlocoDettaglioequalthis INT, 
	@Idlocoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@Asseequalthis VARCHAR(255), 
	@Selezionataequalthis BIT, 
	@Esitoequalthis VARCHAR(255), 
	@Dataesitoequalthis DATETIME, 
	@Costototaleequalthis DECIMAL(18,2), 
	@Importoammessoequalthis DECIMAL(18,2), 
	@Importoconcessoequalthis DECIMAL(18,2), 
	@Nroperazionibequalthis INT, 
	@Beneficiarioequalthis VARCHAR(255), 
	@Spesaammessaequalthis DECIMAL(18,2), 
	@Importocontributopubblicoequalthis DECIMAL(18,2), 
	@SpesaammessaIncrementaleequalthis DECIMAL(18,2), 
	@ImportocontributopubblicoIncrementaleequalthis DECIMAL(18,2), 
	@Esclusioneequalthis VARCHAR(255), 
	@Rischioirequalthis DECIMAL(6,2), 
	@Rischiocrequalthis DECIMAL(6,2), 
	@Rischiocompequalthis VARCHAR(255), 
	@Operatoreequalthis VARCHAR(255), 
	@Datainserimentoequalthis DATETIME, 
	@Datamodificaequalthis DATETIME, 
	@Azioneequalthis VARCHAR(255), 
	@Interventoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT IdLoco_Dettaglio, IdLoco, Id_Domanda_Pagamento, Id_Progetto, Asse, Selezionata, Esito, DataEsito, CostoTotale, ImportoAmmesso, ImportoConcesso, NrOperazioniB, Beneficiario, SpesaAmmessa, ImportoContributoPubblico, SpesaAmmessa_Incrementale, ImportoContributoPubblico_Incrementale, Esclusione, RischioIR, RischioCR, RischioComp, Operatore, DataInserimento, DataModifica, Azione, Intervento, CodPsr, DataFine, Definitivo FROM vCntrLoco_Dettaglio WHERE 1=1'';
	IF (@IdlocoDettaglioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IdLoco_Dettaglio = @IdlocoDettaglioequalthis)''; set @lensql=@lensql+len(@IdlocoDettaglioequalthis);end;
	IF (@Idlocoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IdLoco = @Idlocoequalthis)''; set @lensql=@lensql+len(@Idlocoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (Id_Domanda_Pagamento = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (Id_Progetto = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Asseequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (Asse = @Asseequalthis)''; set @lensql=@lensql+len(@Asseequalthis);end;
	IF (@Selezionataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (Selezionata = @Selezionataequalthis)''; set @lensql=@lensql+len(@Selezionataequalthis);end;
	IF (@Esitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (Esito = @Esitoequalthis)''; set @lensql=@lensql+len(@Esitoequalthis);end;
	IF (@Dataesitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DataEsito = @Dataesitoequalthis)''; set @lensql=@lensql+len(@Dataesitoequalthis);end;
	IF (@Costototaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CostoTotale = @Costototaleequalthis)''; set @lensql=@lensql+len(@Costototaleequalthis);end;
	IF (@Importoammessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ImportoAmmesso = @Importoammessoequalthis)''; set @lensql=@lensql+len(@Importoammessoequalthis);end;
	IF (@Importoconcessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ImportoConcesso = @Importoconcessoequalthis)''; set @lensql=@lensql+len(@Importoconcessoequalthis);end;
	IF (@Nroperazionibequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NrOperazioniB = @Nroperazionibequalthis)''; set @lensql=@lensql+len(@Nroperazionibequalthis);end;
	IF (@Beneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (Beneficiario = @Beneficiarioequalthis)''; set @lensql=@lensql+len(@Beneficiarioequalthis);end;
	IF (@Spesaammessaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SpesaAmmessa = @Spesaammessaequalthis)''; set @lensql=@lensql+len(@Spesaammessaequalthis);end;
	IF (@Importocontributopubblicoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ImportoContri', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCntrlocoDettaglioFindSelect';

