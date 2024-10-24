﻿CREATE PROCEDURE [dbo].[ZCntrlocoDettaglioInsert]
(
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
	INSERT INTO CntrLoco_Dettaglio
	(
		IdLoco, 
		Id_Domanda_Pagamento, 
		Id_Progetto, 
		Asse, 
		Selezionata, 
		Esito, 
		DataEsito, 
		CostoTotale, 
		ImportoAmmesso, 
		ImportoConcesso, 
		NrOperazioniB, 
		Beneficiario, 
		SpesaAmmessa, 
		ImportoContributoPubblico, 
		SpesaAmmessa_Incrementale, 
		ImportoContributoPubblico_Incrementale, 
		Esclusione, 
		RischioIR, 
		RischioCR, 
		RischioComp, 
		Operatore, 
		DataInserimento, 
		DataModifica, 
		Azione, 
		Intervento
	)
	VALUES
	(
		@Idloco, 
		@IdDomandaPagamento, 
		@IdProgetto, 
		@Asse, 
		@Selezionata, 
		@Esito, 
		@Dataesito, 
		@Costototale, 
		@Importoammesso, 
		@Importoconcesso, 
		@Nroperazionib, 
		@Beneficiario, 
		@Spesaammessa, 
		@Importocontributopubblico, 
		@SpesaammessaIncrementale, 
		@ImportocontributopubblicoIncrementale, 
		@Esclusione, 
		@Rischioir, 
		@Rischiocr, 
		@Rischiocomp, 
		@Operatore, 
		@Datainserimento, 
		@Datamodifica, 
		@Azione, 
		@Intervento
	)
	SELECT SCOPE_IDENTITY() AS IdLoco_Dettaglio


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCntrlocoDettaglioInsert]
(
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
	INSERT INTO CntrLoco_Dettaglio
	(
		IdLoco, 
		Id_Domanda_Pagamento, 
		Id_Progetto, 
		Asse, 
		Selezionata, 
		Esito, 
		DataEsito, 
		CostoTotale, 
		ImportoAmmesso, 
		ImportoConcesso, 
		NrOperazioniB, 
		Beneficiario, 
		SpesaAmmessa, 
		ImportoContributoPubblico, 
		SpesaAmmessa_Incrementale, 
		ImportoContributoPubblico_Incrementale, 
		Esclusione, 
		RischioIR, 
		RischioCR, 
		RischioComp, 
		Operatore, 
		DataInserimento, 
		DataModifica, 
		Azione, 
		Intervento
	)
	VALUES
	(
		@Idloco, 
		@IdDomandaPagamento, 
		@IdProgetto, 
		@Asse, 
		@Selezionata, 
		@Esito, 
		@Dataesito, 
		@Costototale, 
		@Importoammesso, 
		@Importoconcesso, 
		@Nroperazionib, 
		@Beneficiario, 
		@Spesaammessa, 
		@Importocontributopubblico, 
		@SpesaammessaIncrementale, 
		@ImportocontributopubblicoIncrementale, 
		@Esclusione, 
		@Rischioir, 
		@Rischiocr, 
		@Rischiocomp, 
		@Operatore, 
		@Datainserimento, 
		@Datamodifica, 
		@Azione, 
		@Intervento
	)
	SELECT SCOPE_IDENTITY() AS IdLoco_Dettaglio

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCntrlocoDettaglioInsert';

