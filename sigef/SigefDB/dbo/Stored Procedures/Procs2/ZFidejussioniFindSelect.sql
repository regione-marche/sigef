CREATE PROCEDURE [dbo].[ZFidejussioniFindSelect]
(
	@IdFidejussioneequalthis INT, 
	@Numeroequalthis VARCHAR(25), 
	@Barcodeequalthis VARCHAR(11), 
	@DataSottoscrizioneequalthis DATETIME, 
	@LuogoSottoscrizioneequalthis VARCHAR(128), 
	@Importoequalthis DECIMAL(18,2), 
	@AmmontareRichiestoequalthis DECIMAL(18,2), 
	@DataFineLavoriequalthis DATETIME, 
	@DataScadenzaequalthis DATETIME, 
	@ProrogaScadenzaequalthis BIT, 
	@PivaGaranteequalthis VARCHAR(11), 
	@RagioneSocialeGaranteequalthis VARCHAR(150), 
	@LocalitaGaranteequalthis VARCHAR(128), 
	@NumeroRegistroImpreseequalthis VARCHAR(10), 
	@CognomeRapplegaleequalthis VARCHAR(30), 
	@NomeRapplegaleequalthis VARCHAR(20), 
	@CfRapplegaleequalthis VARCHAR(16), 
	@DataNascitaRapplegaleequalthis DATETIME, 
	@StampaEffettuataequalthis BIT, 
	@DataRichiestaValiditaequalthis DATETIME, 
	@DataRicevimentoValiditaequalthis DATETIME, 
	@ProtocolloFaxValiditaequalthis VARCHAR(100), 
	@DataDecorrenzaGaranziaequalthis DATETIME, 
	@CodiceAbiEnteGaranteequalthis VARCHAR(5), 
	@CodiceCabEnteGaranteequalthis VARCHAR(5), 
	@BarcodeConfermaValiditaequalthis VARCHAR(11), 
	@CodTipoequalthis CHAR(3), 
	@UfficioApprovazioneequalthis VARCHAR(120), 
	@NumDecretoApprovazioneequalthis INT, 
	@DataDecretoApprovazioneequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_FIDEJUSSIONE, NUMERO, BARCODE, DATA_SOTTOSCRIZIONE, LUOGO_SOTTOSCRIZIONE, IMPORTO, AMMONTARE_RICHIESTO, DATA_FINE_LAVORI, DATA_SCADENZA, PROROGA_SCADENZA, PIVA_GARANTE, RAGIONE_SOCIALE_GARANTE, LOCALITA_GARANTE, NUMERO_REGISTRO_IMPRESE, COGNOME_RAPPLEGALE, NOME_RAPPLEGALE, CF_RAPPLEGALE, DATA_NASCITA_RAPPLEGALE, STAMPA_EFFETTUATA, DATA_RICHIESTA_VALIDITA, DATA_RICEVIMENTO_VALIDITA, PROTOCOLLO_FAX_VALIDITA, DATA_DECORRENZA_GARANZIA, CODICE_ABI_ENTE_GARANTE, CODICE_CAB_ENTE_GARANTE, BARCODE_CONFERMA_VALIDITA, COD_TIPO, UFFICIO_APPROVAZIONE, NUM_DECRETO_APPROVAZIONE, DATA_DECRETO_APPROVAZIONE FROM FIDEJUSSIONI WHERE 1=1';
	IF (@IdFidejussioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FIDEJUSSIONE = @IdFidejussioneequalthis)'; set @lensql=@lensql+len(@IdFidejussioneequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO = @Numeroequalthis)'; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@Barcodeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (BARCODE = @Barcodeequalthis)'; set @lensql=@lensql+len(@Barcodeequalthis);end;
	IF (@DataSottoscrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SOTTOSCRIZIONE = @DataSottoscrizioneequalthis)'; set @lensql=@lensql+len(@DataSottoscrizioneequalthis);end;
	IF (@LuogoSottoscrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (LUOGO_SOTTOSCRIZIONE = @LuogoSottoscrizioneequalthis)'; set @lensql=@lensql+len(@LuogoSottoscrizioneequalthis);end;
	IF (@Importoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO = @Importoequalthis)'; set @lensql=@lensql+len(@Importoequalthis);end;
	IF (@AmmontareRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AMMONTARE_RICHIESTO = @AmmontareRichiestoequalthis)'; set @lensql=@lensql+len(@AmmontareRichiestoequalthis);end;
	IF (@DataFineLavoriequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE_LAVORI = @DataFineLavoriequalthis)'; set @lensql=@lensql+len(@DataFineLavoriequalthis);end;
	IF (@DataScadenzaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SCADENZA = @DataScadenzaequalthis)'; set @lensql=@lensql+len(@DataScadenzaequalthis);end;
	IF (@ProrogaScadenzaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROROGA_SCADENZA = @ProrogaScadenzaequalthis)'; set @lensql=@lensql+len(@ProrogaScadenzaequalthis);end;
	IF (@PivaGaranteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PIVA_GARANTE = @PivaGaranteequalthis)'; set @lensql=@lensql+len(@PivaGaranteequalthis);end;
	IF (@RagioneSocialeGaranteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RAGIONE_SOCIALE_GARANTE = @RagioneSocialeGaranteequalthis)'; set @lensql=@lensql+len(@RagioneSocialeGaranteequalthis);end;
	IF (@LocalitaGaranteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (LOCALITA_GARANTE = @LocalitaGaranteequalthis)'; set @lensql=@lensql+len(@LocalitaGaranteequalthis);end;
	IF (@NumeroRegistroImpreseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_REGISTRO_IMPRESE = @NumeroRegistroImpreseequalthis)'; set @lensql=@lensql+len(@NumeroRegistroImpreseequalthis);end;
	IF (@CognomeRapplegaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COGNOME_RAPPLEGALE = @CognomeRapplegaleequalthis)'; set @lensql=@lensql+len(@CognomeRapplegaleequalthis);end;
	IF (@NomeRapplegaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOME_RAPPLEGALE = @NomeRapplegaleequalthis)'; set @lensql=@lensql+len(@NomeRapplegaleequalthis);end;
	IF (@CfRapplegaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_RAPPLEGALE = @CfRapplegaleequalthis)'; set @lensql=@lensql+len(@CfRapplegaleequalthis);end;
	IF (@DataNascitaRapplegaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_NASCITA_RAPPLEGALE = @DataNascitaRapplegaleequalthis)'; set @lensql=@lensql+len(@DataNascitaRapplegaleequalthis);end;
	IF (@StampaEffettuataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STAMPA_EFFETTUATA = @StampaEffettuataequalthis)'; set @lensql=@lensql+len(@StampaEffettuataequalthis);end;
	IF (@DataRichiestaValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_RICHIESTA_VALIDITA = @DataRichiestaValiditaequalthis)'; set @lensql=@lensql+len(@DataRichiestaValiditaequalthis);end;
	IF (@DataRicevimentoValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_RICEVIMENTO_VALIDITA = @DataRicevimentoValiditaequalthis)'; set @lensql=@lensql+len(@DataRicevimentoValiditaequalthis);end;
	IF (@ProtocolloFaxValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROTOCOLLO_FAX_VALIDITA = @ProtocolloFaxValiditaequalthis)'; set @lensql=@lensql+len(@ProtocolloFaxValiditaequalthis);end;
	IF (@DataDecorrenzaGaranziaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_DECORRENZA_GARANZIA = @DataDecorrenzaGaranziaequalthis)'; set @lensql=@lensql+len(@DataDecorrenzaGaranziaequalthis);end;
	IF (@CodiceAbiEnteGaranteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_ABI_ENTE_GARANTE = @CodiceAbiEnteGaranteequalthis)'; set @lensql=@lensql+len(@CodiceAbiEnteGaranteequalthis);end;
	IF (@CodiceCabEnteGaranteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_CAB_ENTE_GARANTE = @CodiceCabEnteGaranteequalthis)'; set @lensql=@lensql+len(@CodiceCabEnteGaranteequalthis);end;
	IF (@BarcodeConfermaValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (BARCODE_CONFERMA_VALIDITA = @BarcodeConfermaValiditaequalthis)'; set @lensql=@lensql+len(@BarcodeConfermaValiditaequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@UfficioApprovazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (UFFICIO_APPROVAZIONE = @UfficioApprovazioneequalthis)'; set @lensql=@lensql+len(@UfficioApprovazioneequalthis);end;
	IF (@NumDecretoApprovazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUM_DECRETO_APPROVAZIONE = @NumDecretoApprovazioneequalthis)'; set @lensql=@lensql+len(@NumDecretoApprovazioneequalthis);end;
	IF (@DataDecretoApprovazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_DECRETO_APPROVAZIONE = @DataDecretoApprovazioneequalthis)'; set @lensql=@lensql+len(@DataDecretoApprovazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdFidejussioneequalthis INT, @Numeroequalthis VARCHAR(25), @Barcodeequalthis VARCHAR(11), @DataSottoscrizioneequalthis DATETIME, @LuogoSottoscrizioneequalthis VARCHAR(128), @Importoequalthis DECIMAL(18,2), @AmmontareRichiestoequalthis DECIMAL(18,2), @DataFineLavoriequalthis DATETIME, @DataScadenzaequalthis DATETIME, @ProrogaScadenzaequalthis BIT, @PivaGaranteequalthis VARCHAR(11), @RagioneSocialeGaranteequalthis VARCHAR(150), @LocalitaGaranteequalthis VARCHAR(128), @NumeroRegistroImpreseequalthis VARCHAR(10), @CognomeRapplegaleequalthis VARCHAR(30), @NomeRapplegaleequalthis VARCHAR(20), @CfRapplegaleequalthis VARCHAR(16), @DataNascitaRapplegaleequalthis DATETIME, @StampaEffettuataequalthis BIT, @DataRichiestaValiditaequalthis DATETIME, @DataRicevimentoValiditaequalthis DATETIME, @ProtocolloFaxValiditaequalthis VARCHAR(100), @DataDecorrenzaGaranziaequalthis DATETIME, @CodiceAbiEnteGaranteequalthis VARCHAR(5), @CodiceCabEnteGaranteequalthis VARCHAR(5), @BarcodeConfermaValiditaequalthis VARCHAR(11), @CodTipoequalthis CHAR(3), @UfficioApprovazioneequalthis VARCHAR(120), @NumDecretoApprovazioneequalthis INT, @DataDecretoApprovazioneequalthis DATETIME',@IdFidejussioneequalthis , @Numeroequalthis , @Barcodeequalthis , @DataSottoscrizioneequalthis , @LuogoSottoscrizioneequalthis , @Importoequalthis , @AmmontareRichiestoequalthis , @DataFineLavoriequalthis , @DataScadenzaequalthis , @ProrogaScadenzaequalthis , @PivaGaranteequalthis , @RagioneSocialeGaranteequalthis , @LocalitaGaranteequalthis , @NumeroRegistroImpreseequalthis , @CognomeRapplegaleequalthis , @NomeRapplegaleequalthis , @CfRapplegaleequalthis , @DataNascitaRapplegaleequalthis , @StampaEffettuataequalthis , @DataRichiestaValiditaequalthis , @DataRicevimentoValiditaequalthis , @ProtocolloFaxValiditaequalthis , @DataDecorrenzaGaranziaequalthis , @CodiceAbiEnteGaranteequalthis , @CodiceCabEnteGaranteequalthis , @BarcodeConfermaValiditaequalthis , @CodTipoequalthis , @UfficioApprovazioneequalthis , @NumDecretoApprovazioneequalthis , @DataDecretoApprovazioneequalthis ;
	else
		SELECT ID_FIDEJUSSIONE, NUMERO, BARCODE, DATA_SOTTOSCRIZIONE, LUOGO_SOTTOSCRIZIONE, IMPORTO, AMMONTARE_RICHIESTO, DATA_FINE_LAVORI, DATA_SCADENZA, PROROGA_SCADENZA, PIVA_GARANTE, RAGIONE_SOCIALE_GARANTE, LOCALITA_GARANTE, NUMERO_REGISTRO_IMPRESE, COGNOME_RAPPLEGALE, NOME_RAPPLEGALE, CF_RAPPLEGALE, DATA_NASCITA_RAPPLEGALE, STAMPA_EFFETTUATA, DATA_RICHIESTA_VALIDITA, DATA_RICEVIMENTO_VALIDITA, PROTOCOLLO_FAX_VALIDITA, DATA_DECORRENZA_GARANZIA, CODICE_ABI_ENTE_GARANTE, CODICE_CAB_ENTE_GARANTE, BARCODE_CONFERMA_VALIDITA, COD_TIPO, UFFICIO_APPROVAZIONE, NUM_DECRETO_APPROVAZIONE, DATA_DECRETO_APPROVAZIONE
		FROM FIDEJUSSIONI
		WHERE 
			((@IdFidejussioneequalthis IS NULL) OR ID_FIDEJUSSIONE = @IdFidejussioneequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@Barcodeequalthis IS NULL) OR BARCODE = @Barcodeequalthis) AND 
			((@DataSottoscrizioneequalthis IS NULL) OR DATA_SOTTOSCRIZIONE = @DataSottoscrizioneequalthis) AND 
			((@LuogoSottoscrizioneequalthis IS NULL) OR LUOGO_SOTTOSCRIZIONE = @LuogoSottoscrizioneequalthis) AND 
			((@Importoequalthis IS NULL) OR IMPORTO = @Importoequalthis) AND 
			((@AmmontareRichiestoequalthis IS NULL) OR AMMONTARE_RICHIESTO = @AmmontareRichiestoequalthis) AND 
			((@DataFineLavoriequalthis IS NULL) OR DATA_FINE_LAVORI = @DataFineLavoriequalthis) AND 
			((@DataScadenzaequalthis IS NULL) OR DATA_SCADENZA = @DataScadenzaequalthis) AND 
			((@ProrogaScadenzaequalthis IS NULL) OR PROROGA_SCADENZA = @ProrogaScadenzaequalthis) AND 
			((@PivaGaranteequalthis IS NULL) OR PIVA_GARANTE = @PivaGaranteequalthis) AND 
			((@RagioneSocialeGaranteequalthis IS NULL) OR RAGIONE_SOCIALE_GARANTE = @RagioneSocialeGaranteequalthis) AND 
			((@LocalitaGaranteequalthis IS NULL) OR LOCALITA_GARANTE = @LocalitaGaranteequalthis) AND 
			((@NumeroRegistroImpreseequalthis IS NULL) OR NUMERO_REGISTRO_IMPRESE = @NumeroRegistroImpreseequalthis) AND 
			((@CognomeRapplegaleequalthis IS NULL) OR COGNOME_RAPPLEGALE = @CognomeRapplegaleequalthis) AND 
			((@NomeRapplegaleequalthis IS NULL) OR NOME_RAPPLEGALE = @NomeRapplegaleequalthis) AND 
			((@CfRapplegaleequalthis IS NULL) OR CF_RAPPLEGALE = @CfRapplegaleequalthis) AND 
			((@DataNascitaRapplegaleequalthis IS NULL) OR DATA_NASCITA_RAPPLEGALE = @DataNascitaRapplegaleequalthis) AND 
			((@StampaEffettuataequalthis IS NULL) OR STAMPA_EFFETTUATA = @StampaEffettuataequalthis) AND 
			((@DataRichiestaValiditaequalthis IS NULL) OR DATA_RICHIESTA_VALIDITA = @DataRichiestaValiditaequalthis) AND 
			((@DataRicevimentoValiditaequalthis IS NULL) OR DATA_RICEVIMENTO_VALIDITA = @DataRicevimentoValiditaequalthis) AND 
			((@ProtocolloFaxValiditaequalthis IS NULL) OR PROTOCOLLO_FAX_VALIDITA = @ProtocolloFaxValiditaequalthis) AND 
			((@DataDecorrenzaGaranziaequalthis IS NULL) OR DATA_DECORRENZA_GARANZIA = @DataDecorrenzaGaranziaequalthis) AND 
			((@CodiceAbiEnteGaranteequalthis IS NULL) OR CODICE_ABI_ENTE_GARANTE = @CodiceAbiEnteGaranteequalthis) AND 
			((@CodiceCabEnteGaranteequalthis IS NULL) OR CODICE_CAB_ENTE_GARANTE = @CodiceCabEnteGaranteequalthis) AND 
			((@BarcodeConfermaValiditaequalthis IS NULL) OR BARCODE_CONFERMA_VALIDITA = @BarcodeConfermaValiditaequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@UfficioApprovazioneequalthis IS NULL) OR UFFICIO_APPROVAZIONE = @UfficioApprovazioneequalthis) AND 
			((@NumDecretoApprovazioneequalthis IS NULL) OR NUM_DECRETO_APPROVAZIONE = @NumDecretoApprovazioneequalthis) AND 
			((@DataDecretoApprovazioneequalthis IS NULL) OR DATA_DECRETO_APPROVAZIONE = @DataDecretoApprovazioneequalthis)
