CREATE PROCEDURE [dbo].[ZCertspDettaglioInsert]
(
	@Idcertsp INT, 
	@IdDomandaPagamento INT, 
	@IdProgetto INT, 
	@Asse VARCHAR(255), 
	@Selezionata BIT, 
	@Esito VARCHAR(255), 
	@Dataesito DATETIME, 
	@IdFile INT, 
	@Costototale DECIMAL(18,2), 
	@Importoammesso DECIMAL(18,2), 
	@Importoconcesso DECIMAL(18,2), 
	@Beneficiario VARCHAR(255), 
	@Spesaammessa DECIMAL(18,2), 
	@Importocontributopubblico DECIMAL(18,2), 
	@SpesaammessaIncrementale DECIMAL(18,2), 
	@ImportocontributopubblicoIncrementale DECIMAL(18,2), 
	@Note VARCHAR(2000), 
	@Operatore VARCHAR(255), 
	@Datainserimento DATETIME, 
	@Datamodifica DATETIME, 
	@Quotaue DECIMAL(18,2), 
	@Quotastato DECIMAL(18,2), 
	@Quotaregione DECIMAL(18,2), 
	@Quotaprivato DECIMAL(18,2)
)
AS
	INSERT INTO CertSp_Dettaglio
	(
		IdCertSp, 
		Id_Domanda_Pagamento, 
		Id_Progetto, 
		Asse, 
		Selezionata, 
		Esito, 
		DataEsito, 
		Id_File, 
		CostoTotale, 
		ImportoAmmesso, 
		ImportoConcesso, 
		Beneficiario, 
		SpesaAmmessa, 
		ImportoContributoPubblico, 
		SpesaAmmessa_Incrementale, 
		ImportoContributoPubblico_Incrementale, 
		Note, 
		Operatore, 
		DataInserimento, 
		DataModifica, 
		QuotaUe, 
		QuotaStato, 
		QuotaRegione, 
		QuotaPrivato
	)
	VALUES
	(
		@Idcertsp, 
		@IdDomandaPagamento, 
		@IdProgetto, 
		@Asse, 
		@Selezionata, 
		@Esito, 
		@Dataesito, 
		@IdFile, 
		@Costototale, 
		@Importoammesso, 
		@Importoconcesso, 
		@Beneficiario, 
		@Spesaammessa, 
		@Importocontributopubblico, 
		@SpesaammessaIncrementale, 
		@ImportocontributopubblicoIncrementale, 
		@Note, 
		@Operatore, 
		@Datainserimento, 
		@Datamodifica, 
		@Quotaue, 
		@Quotastato, 
		@Quotaregione, 
		@Quotaprivato
	)
	SELECT SCOPE_IDENTITY() AS IdCertSp_Dettaglio


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCertspDettaglioInsert]
(
	@Idcertsp INT, 
	@IdDomandaPagamento INT, 
	@IdProgetto INT, 
	@Asse VARCHAR(255), 
	@Selezionata BIT, 
	@Esito VARCHAR(255), 
	@Dataesito DATETIME, 
	@IdFile INT, 
	@Costototale DECIMAL(18,2), 
	@Importoammesso DECIMAL(18,2), 
	@Importoconcesso DECIMAL(18,2), 
	@Beneficiario VARCHAR(255), 
	@Spesaammessa DECIMAL(18,2), 
	@Importocontributopubblico DECIMAL(18,2), 
	@SpesaammessaIncrementale DECIMAL(18,2), 
	@ImportocontributopubblicoIncrementale DECIMAL(18,2), 
	@Note VARCHAR(2000), 
	@Operatore VARCHAR(255), 
	@Datainserimento DATETIME, 
	@Datamodifica DATETIME
)
AS
	INSERT INTO CertSp_Dettaglio
	(
		IdCertSp, 
		Id_Domanda_Pagamento, 
		Id_Progetto, 
		Asse, 
		Selezionata, 
		Esito, 
		DataEsito, 
		Id_File, 
		CostoTotale, 
		ImportoAmmesso, 
		ImportoConcesso, 
		Beneficiario, 
		SpesaAmmessa, 
		ImportoContributoPubblico, 
		SpesaAmmessa_Incrementale, 
		ImportoContributoPubblico_Incrementale, 
		Note, 
		Operatore, 
		DataInserimento, 
		DataModifica
	)
	VALUES
	(
		@Idcertsp, 
		@IdDomandaPagamento, 
		@IdProgetto, 
		@Asse, 
		@Selezionata, 
		@Esito, 
		@Dataesito, 
		@IdFile, 
		@Costototale, 
		@Importoammesso, 
		@Importoconcesso, 
		@Beneficiario, 
		@Spesaammessa, 
		@Importocontributopubblico, 
		@SpesaammessaIncrementale, 
		@ImportocontributopubblicoIncrementale, 
		@Note, 
		@Operatore, 
		@Datainserimento, 
		@Datamodifica
	)
	SELECT SCOPE_IDENTITY() AS IdCertSp_Dettaglio

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCertspDettaglioInsert';

