﻿CREATE PROCEDURE [dbo].[ZPianoInvestimentiInsert]
(
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
	SET @NonCofinanziato = ISNULL(@NonCofinanziato,((0)))
	INSERT INTO PIANO_INVESTIMENTI
	(
		ID_PROGETTO, 
		ID_PROGRAMMAZIONE, 
		DESCRIZIONE, 
		DATA_VARIAZIONE, 
		OPERATORE_VARIAZIONE, 
		COD_STP, 
		ID_UNITA_MISURA, 
		QUANTITA, 
		COSTO_INVESTIMENTO, 
		SPESE_GENERALI, 
		CONTRIBUTO_RICHIESTO, 
		QUOTA_CONTRIBUTO_RICHIESTO, 
		ID_SETTORE_PRODUTTIVO, 
		ID_PRIORITA_SETTORIALE, 
		ID_OBIETTIVO_MISURA, 
		AMMESSO, 
		ISTRUTTORE, 
		ID_INVESTIMENTO_ORIGINALE, 
		DATA_VALUTAZIONE, 
		ID_CODIFICA_INVESTIMENTO, 
		ID_DETTAGLIO_INVESTIMENTO, 
		ID_SPECIFICA_INVESTIMENTO, 
		COD_TIPO_INVESTIMENTO, 
		VALUTAZIONE_INVESTIMENTO, 
		ID_VARIANTE, 
		COD_VARIAZIONE, 
		TASSO_ABBUONO, 
		NON_COFINANZIATO, 
		CONTRIBUTO_ALTRE_FONTI, 
		QUOTA_CONTRIBUTO_ALTRE_FONTI
	)
	VALUES
	(
		@IdProgetto, 
		@IdProgrammazione, 
		@Descrizione, 
		@DataVariazione, 
		@OperatoreVariazione, 
		@CodStp, 
		@IdUnitaMisura, 
		@Quantita, 
		@CostoInvestimento, 
		@SpeseGenerali, 
		@ContributoRichiesto, 
		@QuotaContributoRichiesto, 
		@IdSettoreProduttivo, 
		@IdPrioritaSettoriale, 
		@IdObiettivoMisura, 
		@Ammesso, 
		@Istruttore, 
		@IdInvestimentoOriginale, 
		@DataValutazione, 
		@IdCodificaInvestimento, 
		@IdDettaglioInvestimento, 
		@IdSpecificaInvestimento, 
		@CodTipoInvestimento, 
		@ValutazioneInvestimento, 
		@IdVariante, 
		@CodVariazione, 
		@TassoAbbuono, 
		@NonCofinanziato, 
		@ContributoAltreFonti, 
		@QuotaContributoAltreFonti
	)
	SELECT SCOPE_IDENTITY() AS ID_INVESTIMENTO, @NonCofinanziato AS NON_COFINANZIATO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPianoInvestimentiInsert]
(
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
	SET @NonCofinanziato = ISNULL(@NonCofinanziato,((0)))
	INSERT INTO PIANO_INVESTIMENTI
	(
		ID_PROGETTO, 
		ID_PROGRAMMAZIONE, 
		DESCRIZIONE, 
		DATA_VARIAZIONE, 
		OPERATORE_VARIAZIONE, 
		COD_STP, 
		ID_UNITA_MISURA, 
		QUANTITA, 
		COSTO_INVESTIMENTO, 
		SPESE_GENERALI, 
		CONTRIBUTO_RICHIESTO, 
		QUOTA_CONTRIBUTO_RICHIESTO, 
		ID_SETTORE_PRODUTTIVO, 
		ID_PRIORITA_SETTORIALE, 
		ID_OBIETTIVO_MISURA, 
		AMMESSO, 
		ISTRUTTORE, 
		ID_INVESTIMENTO_ORIGINALE, 
		DATA_VALUTAZIONE, 
		ID_CODIFICA_INVESTIMENTO, 
		ID_DETTAGLIO_INVESTIMENTO, 
		ID_SPECIFICA_INVESTIMENTO, 
		COD_TIPO_INVESTIMENTO, 
		VALUTAZIONE_INVESTIMENTO, 
		ID_VARIANTE, 
		COD_VARIAZIONE, 
		TASSO_ABBUONO, 
		NON_COFINANZIATO, 
		CONTRIBUTO_ALTRE_FONTI, 
		QUOTA_CONTRIBUTO_ALTRE_FONTI
	)
	VALUES
	(
		@IdProgetto, 
		@IdProgrammazione, 
		@Descrizione, 
		@DataVariazione, 
		@OperatoreVariazione, 
		@CodStp, 
		@IdUnitaMisura, 
		@Quantita, 
		@CostoInvestimento, 
		@SpeseGenerali, 
		@ContributoRichiesto, 
		@QuotaContributoRichiesto, 
		@IdSettoreProduttivo, 
		@IdPrioritaSettoriale, 
		@IdObiettivoMisura, 
		@Ammesso, 
		@Istruttore, 
		@IdInvestimentoOriginale, 
		@DataValutazione, 
		@IdCodificaInvestimento, 
		@IdDettaglioInvestimento, 
		@IdSpecificaInvestimento, 
		@CodTipoInvestimento, 
		@ValutazioneInvestimento, 
		@IdVariante, 
		@CodVariazione, 
		@TassoAbbuono, 
		@NonCofinanziato, 
		@ContributoAltreFonti, 
		@QuotaContributoAltreFonti
	)
	SELECT SCOPE_IDENTITY() AS ID_INVESTIMENTO, @NonCofinanziato AS NON_COFINANZIATO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPianoInvestimentiInsert';
