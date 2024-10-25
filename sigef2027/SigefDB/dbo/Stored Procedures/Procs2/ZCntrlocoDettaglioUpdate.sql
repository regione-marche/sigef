CREATE PROCEDURE [dbo].[ZCntrlocoDettaglioUpdate]
(
	@IdlocoDettaglio INT, 
	@Idloco INT, 
	@IdDomandaPagamento INT, 
	@IdProgetto INT, 
	@Asse VARCHAR(255), 
	@Selezionata BIT, 
	@Esito VARCHAR(255), 
	@Dataesito DATETIME, 
	@Costototale DECIMAL(18,2), 
	@Importoammesso DECIMAL(18,2), 
	@Importoconcesso DECIMAL(18,2), 
	@Nroperazionib INT, 
	@Beneficiario VARCHAR(255), 
	@Spesaammessa DECIMAL(18,2), 
	@Importocontributopubblico DECIMAL(18,2), 
	@SpesaammessaIncrementale DECIMAL(18,2), 
	@ImportocontributopubblicoIncrementale DECIMAL(18,2), 
	@Esclusione VARCHAR(255), 
	@Rischioir DECIMAL(6,2), 
	@Rischiocr DECIMAL(6,2), 
	@Rischiocomp VARCHAR(255), 
	@Operatore VARCHAR(255), 
	@Datainserimento DATETIME, 
	@Datamodifica DATETIME, 
	@Azione VARCHAR(255), 
	@Intervento VARCHAR(255)
)
AS
	UPDATE CntrLoco_Dettaglio
	SET
		IdLoco = @Idloco, 
		Id_Domanda_Pagamento = @IdDomandaPagamento, 
		Id_Progetto = @IdProgetto, 
		Asse = @Asse, 
		Selezionata = @Selezionata, 
		Esito = @Esito, 
		DataEsito = @Dataesito, 
		CostoTotale = @Costototale, 
		ImportoAmmesso = @Importoammesso, 
		ImportoConcesso = @Importoconcesso, 
		NrOperazioniB = @Nroperazionib, 
		Beneficiario = @Beneficiario, 
		SpesaAmmessa = @Spesaammessa, 
		ImportoContributoPubblico = @Importocontributopubblico, 
		SpesaAmmessa_Incrementale = @SpesaammessaIncrementale, 
		ImportoContributoPubblico_Incrementale = @ImportocontributopubblicoIncrementale, 
		Esclusione = @Esclusione, 
		RischioIR = @Rischioir, 
		RischioCR = @Rischiocr, 
		RischioComp = @Rischiocomp, 
		Operatore = @Operatore, 
		DataInserimento = @Datainserimento, 
		DataModifica = @Datamodifica, 
		Azione = @Azione, 
		Intervento = @Intervento
	WHERE 
		(IdLoco_Dettaglio = @IdlocoDettaglio)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCntrlocoDettaglioUpdate]
(
	@IdlocoDettaglio INT, 
	@Idloco INT, 
	@IdDomandaPagamento INT, 
	@IdProgetto INT, 
	@Asse VARCHAR(255), 
	@Selezionata BIT, 
	@Esito VARCHAR(255), 
	@Dataesito DATETIME, 
	@Costototale DECIMAL(18,2), 
	@Importoammesso DECIMAL(18,2), 
	@Importoconcesso DECIMAL(18,2), 
	@Nroperazionib INT, 
	@Beneficiario VARCHAR(255), 
	@Spesaammessa DECIMAL(18,2), 
	@Importocontributopubblico DECIMAL(18,2), 
	@SpesaammessaIncrementale DECIMAL(18,2), 
	@ImportocontributopubblicoIncrementale DECIMAL(18,2), 
	@Esclusione VARCHAR(255), 
	@Rischioir DECIMAL(6,2), 
	@Rischiocr DECIMAL(6,2), 
	@Rischiocomp VARCHAR(255), 
	@Operatore VARCHAR(255), 
	@Datainserimento DATETIME, 
	@Datamodifica DATETIME, 
	@Azione VARCHAR(255), 
	@Intervento VARCHAR(255)
)
AS
	UPDATE CntrLoco_Dettaglio
	SET
		IdLoco = @Idloco, 
		Id_Domanda_Pagamento = @IdDomandaPagamento, 
		Id_Progetto = @IdProgetto, 
		Asse = @Asse, 
		Selezionata = @Selezionata, 
		Esito = @Esito, 
		DataEsito = @Dataesito, 
		CostoTotale = @Costototale, 
		ImportoAmmesso = @Importoammesso, 
		ImportoConcesso = @Importoconcesso, 
		NrOperazioniB = @Nroperazionib, 
		Beneficiario = @Beneficiario, 
		SpesaAmmessa = @Spesaammessa, 
		ImportoContributoPubblico = @Importocontributopubblico, 
		SpesaAmmessa_Incrementale = @SpesaammessaIncrementale, 
		ImportoContributoPubblico_Incrementale = @ImportocontributopubblicoIncrementale, 
		Esclusione = @Esclusione, 
		RischioIR = @Rischioir, 
		RischioCR = @Rischiocr, 
		RischioComp = @Rischiocomp, 
		Operatore = @Operatore, 
		DataInserimento = @Datainserimento, 
		DataModifica = @Datamodifica, 
		Azione = @Azione, 
		Intervento = @Intervento
	WHERE 
		(IdLoco_Dettaglio = @IdlocoDettaglio)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCntrlocoDettaglioUpdate';

