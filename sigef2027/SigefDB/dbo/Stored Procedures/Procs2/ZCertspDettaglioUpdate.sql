CREATE PROCEDURE [dbo].[ZCertspDettaglioUpdate]
(
	@IdcertspDettaglio INT, 
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
	UPDATE CertSp_Dettaglio
	SET
		IdCertSp = @Idcertsp, 
		Id_Domanda_Pagamento = @IdDomandaPagamento, 
		Id_Progetto = @IdProgetto, 
		Asse = @Asse, 
		Selezionata = @Selezionata, 
		Esito = @Esito, 
		DataEsito = @Dataesito, 
		Id_File = @IdFile, 
		CostoTotale = @Costototale, 
		ImportoAmmesso = @Importoammesso, 
		ImportoConcesso = @Importoconcesso, 
		Beneficiario = @Beneficiario, 
		SpesaAmmessa = @Spesaammessa, 
		ImportoContributoPubblico = @Importocontributopubblico, 
		SpesaAmmessa_Incrementale = @SpesaammessaIncrementale, 
		ImportoContributoPubblico_Incrementale = @ImportocontributopubblicoIncrementale, 
		Note = @Note, 
		Operatore = @Operatore, 
		DataInserimento = @Datainserimento, 
		DataModifica = @Datamodifica, 
		QuotaUe = @Quotaue, 
		QuotaStato = @Quotastato, 
		QuotaRegione = @Quotaregione, 
		QuotaPrivato = @Quotaprivato
	WHERE 
		(IdCertSp_Dettaglio = @IdcertspDettaglio)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCertspDettaglioUpdate]
(
	@IdcertspDettaglio INT, 
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
	UPDATE CertSp_Dettaglio
	SET
		IdCertSp = @Idcertsp, 
		Id_Domanda_Pagamento = @IdDomandaPagamento, 
		Id_Progetto = @IdProgetto, 
		Asse = @Asse, 
		Selezionata = @Selezionata, 
		Esito = @Esito, 
		DataEsito = @Dataesito, 
		Id_File = @IdFile, 
		CostoTotale = @Costototale, 
		ImportoAmmesso = @Importoammesso, 
		ImportoConcesso = @Importoconcesso, 
		Beneficiario = @Beneficiario, 
		SpesaAmmessa = @Spesaammessa, 
		ImportoContributoPubblico = @Importocontributopubblico, 
		SpesaAmmessa_Incrementale = @SpesaammessaIncrementale, 
		ImportoContributoPubblico_Incrementale = @ImportocontributopubblicoIncrementale, 
		Note = @Note, 
		Operatore = @Operatore, 
		DataInserimento = @Datainserimento, 
		DataModifica = @Datamodifica
	WHERE 
		(IdCertSp_Dettaglio = @IdcertspDettaglio)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCertspDettaglioUpdate';

