﻿CREATE PROCEDURE [dbo].[ZPianoInvestimentiUpdate]
(
	@IdInvestimento INT, 
	@IdProgetto INT, 
	@IdProgrammazione INT, 
	@Descrizione VARCHAR(2000), 
	@DataVariazione DATETIME, 
	@OperatoreVariazione VARCHAR(255), 
	@CodStp VARCHAR(255), 
	@IdUnitaMisura INT, 
	@Quantita DECIMAL(10,2), 
	@CostoInvestimento DECIMAL(15,2), 
	@SpeseGenerali DECIMAL(15,2), 
	@ContributoRichiesto DECIMAL(15,2), 
	@QuotaContributoRichiesto DECIMAL(10,2), 
	@IdSettoreProduttivo INT, 
	@IdPrioritaSettoriale INT, 
	@IdObiettivoMisura INT, 
	@Ammesso BIT, 
	@Istruttore VARCHAR(255), 
	@IdInvestimentoOriginale INT, 
	@DataValutazione DATETIME, 
	@IdCodificaInvestimento INT, 
	@IdDettaglioInvestimento INT, 
	@IdSpecificaInvestimento INT, 
	@CodTipoInvestimento INT, 
	@ValutazioneInvestimento NTEXT, 
	@IdVariante INT, 
	@CodVariazione VARCHAR(255), 
	@TassoAbbuono DECIMAL(10,2), 
	@NonCofinanziato BIT, 
	@ContributoAltreFonti DECIMAL(15,2), 
	@QuotaContributoAltreFonti DECIMAL(10,2)
)
AS
	UPDATE PIANO_INVESTIMENTI
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_PROGRAMMAZIONE = @IdProgrammazione, 
		DESCRIZIONE = @Descrizione, 
		DATA_VARIAZIONE = @DataVariazione, 
		OPERATORE_VARIAZIONE = @OperatoreVariazione, 
		COD_STP = @CodStp, 
		ID_UNITA_MISURA = @IdUnitaMisura, 
		QUANTITA = @Quantita, 
		COSTO_INVESTIMENTO = @CostoInvestimento, 
		SPESE_GENERALI = @SpeseGenerali, 
		CONTRIBUTO_RICHIESTO = @ContributoRichiesto, 
		QUOTA_CONTRIBUTO_RICHIESTO = @QuotaContributoRichiesto, 
		ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivo, 
		ID_PRIORITA_SETTORIALE = @IdPrioritaSettoriale, 
		ID_OBIETTIVO_MISURA = @IdObiettivoMisura, 
		AMMESSO = @Ammesso, 
		ISTRUTTORE = @Istruttore, 
		ID_INVESTIMENTO_ORIGINALE = @IdInvestimentoOriginale, 
		DATA_VALUTAZIONE = @DataValutazione, 
		ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimento, 
		ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimento, 
		ID_SPECIFICA_INVESTIMENTO = @IdSpecificaInvestimento, 
		COD_TIPO_INVESTIMENTO = @CodTipoInvestimento, 
		VALUTAZIONE_INVESTIMENTO = @ValutazioneInvestimento, 
		ID_VARIANTE = @IdVariante, 
		COD_VARIAZIONE = @CodVariazione, 
		TASSO_ABBUONO = @TassoAbbuono, 
		NON_COFINANZIATO = @NonCofinanziato, 
		CONTRIBUTO_ALTRE_FONTI = @ContributoAltreFonti, 
		QUOTA_CONTRIBUTO_ALTRE_FONTI = @QuotaContributoAltreFonti
	WHERE 
		(ID_INVESTIMENTO = @IdInvestimento)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPianoInvestimentiUpdate]
(
	@IdInvestimento INT, 
	@IdProgetto INT, 
	@IdProgrammazione INT, 
	@Descrizione VARCHAR(2000), 
	@DataVariazione DATETIME, 
	@OperatoreVariazione VARCHAR(255), 
	@CodStp VARCHAR(255), 
	@IdUnitaMisura INT, 
	@Quantita DECIMAL(10,2), 
	@CostoInvestimento DECIMAL(15,2), 
	@SpeseGenerali DECIMAL(15,2), 
	@ContributoRichiesto DECIMAL(15,2), 
	@QuotaContributoRichiesto DECIMAL(10,2), 
	@IdSettoreProduttivo INT, 
	@IdPrioritaSettoriale INT, 
	@IdObiettivoMisura INT, 
	@Ammesso BIT, 
	@Istruttore VARCHAR(255), 
	@IdInvestimentoOriginale INT, 
	@DataValutazione DATETIME, 
	@IdCodificaInvestimento INT, 
	@IdDettaglioInvestimento INT, 
	@IdSpecificaInvestimento INT, 
	@CodTipoInvestimento INT, 
	@ValutazioneInvestimento NTEXT, 
	@IdVariante INT, 
	@CodVariazione VARCHAR(255), 
	@TassoAbbuono DECIMAL(10,2), 
	@NonCofinanziato BIT, 
	@ContributoAltreFonti DECIMAL(15,2), 
	@QuotaContributoAltreFonti DECIMAL(10,2)
)
AS
	UPDATE PIANO_INVESTIMENTI
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_PROGRAMMAZIONE = @IdProgrammazione, 
		DESCRIZIONE = @Descrizione, 
		DATA_VARIAZIONE = @DataVariazione, 
		OPERATORE_VARIAZIONE = @OperatoreVariazione, 
		COD_STP = @CodStp, 
		ID_UNITA_MISURA = @IdUnitaMisura, 
		QUANTITA = @Quantita, 
		COSTO_INVESTIMENTO = @CostoInvestimento, 
		SPESE_GENERALI = @SpeseGenerali, 
		CONTRIBUTO_RICHIESTO = @ContributoRichiesto, 
		QUOTA_CONTRIBUTO_RICHIESTO = @QuotaContributoRichiesto, 
		ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivo, 
		ID_PRIORITA_SETTORIALE = @IdPrioritaSettoriale, 
		ID_OBIETTIVO_MISURA = @IdObiettivoMisura, 
		AMMESSO = @Ammesso, 
		ISTRUTTORE = @Istruttore, 
		ID_INVESTIMENTO_ORIGINALE = @IdInvestimentoOriginale, 
		DATA_VALUTAZIONE = @DataValutazione, 
		ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimento, 
		ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimento, 
		ID_SPECIFICA_INVESTIMENTO = @IdSpecificaInvestimento, 
		COD_TIPO_INVESTIMENTO = @CodTipoInvestimento, 
		VALUTAZIONE_INVESTIMENTO = @ValutazioneInvestimento, 
		ID_VARIANTE = @IdVariante, 
		COD_VARIAZIONE = @CodVariazione, 
		TASSO_ABBUONO = @TassoAbbuono, 
		NON_COFINANZIATO = @NonCofinanziato, 
		CONTRIBUTO_ALTRE_FONTI = @ContributoAltreFonti, 
		QUOTA_CONTRIBUTO_ALTRE_FONTI = @QuotaContributoAltreFonti
	WHERE 
		(ID_INVESTIMENTO = @IdInvestimento)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPianoInvestimentiUpdate';

