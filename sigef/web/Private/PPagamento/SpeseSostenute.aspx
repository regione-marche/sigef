<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.SpeseSostenute" CodeBehind="SpeseSostenute.aspx.cs" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento"
    TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/ZoomLoader.ascx" TagName="ZoomLoader" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function caricaSpesa(id) { $('[id$=hdnIdSpesaSostenuta]').val(id); $('[id$=btnCaricaSpesa]').click(); }
        function ctrlCF() { var cf = $('[id$=txtPivaFornitore_text]').val(); if (cf != "" && !ctrlCodiceFiscale(cf) && !ctrlPIVA(cf)) { alert('Attenzione! Codice fiscale/P.Iva formalmente non corretto.'); } }
        function validaImporti(scrivi_importo_netto, e) {
            $('#spErroreImporti').hide();
            var netto_giustificativo = FromCurrencyToNumber($('[id$=txtImportoGiustificativo_text]').val());
            var iva_giustificativo = FromCurrencyToNumber($('[id$=txtIva_text]').val());
            var lordo_pagamento = FromCurrencyToNumber($('[id$=txtImportoLordoPagamento_text]').val());
            var netto_pagamento = FromCurrencyToNumber($('[id$=txtImportoNettoPagamento_text]').val());
            if (iva_giustificativo < 0 || netto_giustificativo < 0 || lordo_pagamento < 0) {
                alert('Attenzione! Inserire dei valori validi sugli importi richiesti.'); return stopEvent(e);
            }
            else {
                var lordo_giustificativo = Arrotonda(netto_giustificativo + netto_giustificativo * iva_giustificativo / 100);
                if (lordo_pagamento > lordo_giustificativo) {
                    if (!confirm('Attenzione! L`importo lordo del pagamento è maggiore a quello del giustificativo.\nSi desidera procedere comunque con la procedura di salvataggio?')) {
                        $('[id$=txtImportoNettoPagamento_text]').val($('[id$=txtImportoGiustificativo_text]').val());
                        $('[id$=txtImportoLordoPagamento_text]').val(FromNumberToCurrency(lordo_giustificativo));
                        return stopEvent(e);
                    } else {
                        if (scrivi_importo_netto) {
                            var scorporo_iva = 1 + iva_giustificativo / 100;
                            $('[id$=txtImportoNettoPagamento_text]').val(FromNumberToCurrency(Arrotonda(lordo_pagamento / scorporo_iva)));
                        }
                    }
                    //alert('Attenzione! L`importo lordo del pagamento non può superare quello del giustificativo.');
                    //$('#spErroreImporti').show(); return stopEvent(e);
                }
                else if (netto_pagamento > lordo_pagamento) {
                    alert('Attenzione! L`importo netto del pagamento non può superare quello lordo. Se necessario correggere l\'importo lordo.');
                    $('#spErroreImporti').show(); return stopEvent(e);
                }
                else {
                    if (scrivi_importo_netto) {
                        var scorporo_iva = 1 + iva_giustificativo / 100;
                        $('[id$=txtImportoNettoPagamento_text]').val(FromNumberToCurrency(Arrotonda(lordo_pagamento / scorporo_iva)));
                    }
                }
            }
            var ok = true;
            if ($('[id$=lstTipoGiustificativo]').val() == "") { ok = false; }
            if ($('[id$=txtDataGiustificativo_text]').val() == "") { ok = false; }
            if ($('[id$=txtImportoGiustificativo_text]').val() == "") { ok = false; }
            if ($('[id$=txtIva_text]').val() == "") { ok = false; }
            if ($('[id$=txtDescGiustificativo_text]').val() == "") { ok = false; }
            if ($('[id$=txtPivaFornitore_text]').val() == "") { ok = false; }
            if ($('[id$=lstPagamento]').val() == "") { ok = false; }
            if ($('[id$=txtDataPagamento_text]').val() == "") { ok = false; }
            if ($('[id$=txtImportoLordoPagamento_text]').val() == "") { ok = false; }
            if ($('[id$=txtImportoNettoPagamento_text]').val() == "") { ok = false; }
            if ($('[id$=txtEstremi_text]').val() == "") { ok = false; }
            if (ok == false) { alert('Tutti i campi con * sono obbligatori.'); return stopEvent(e) }
        }
        function riempiCampiGiustificativo(selectedObject, b) { $('[id$=hdnIdGiustificativo]').val(selectedObject.IdGiustificativo); $('[id$=btnCaricaGiustificativo]').click(); }

        function visualizzaIntegrazioneSingola(id) {
            $('[id$=hdnIdIntegrazioneSingolaSelezionata]').val($('[id$=hdnIdIntegrazioneSingolaSelezionata]').val() == id ? '' : id);
            $('[id$=btnPost]').click();
        }

        function selezionaFileSpese(idFile) {
            $('[id$=hdnIdFileSpesaSostenuta]').val($('[id$=hdnIdFileSpesaSostenuta]').val() == idFile ? '' : idFile);
            $('[id$=btnPost]').click();
        }
        function svuotaCampiFile() {
            $('[id$=hdnIdFileSpesaSostenuta]').val('');
            $('[id$=txtDescrizioneFile]').val('');
            SNCUFTipoFile = 'Documento';
            SNCUFDimensioneMassima = 0;
            SNCUFRimuoviFile('ctl00_cphContenuto_ufFileSpesaSostenuta');
        }
        function rimuoviFileSpesa(id) { $('[id$=hdnIdFileSpesaSostenuta]').val(id); $('[id$=btnRimuoviFileSpesa]').click(); }

        function SNCVZCercaFornitoriProgetto_onselect(obj) {
            stopcf = true;
            if (obj) {
                //$('[id$=hdnIdFornitore]').val(obj.IdGiustificativo);
                $('[id$=txtPivaFornitore_text]').val(obj.CfFornitore);
                $('[id$=txtRSFornitore_text]').val(obj.DescrizioneFornitore);
            }
            else
                alert('L`elemento selezionato non è valido.');
        }

        function PopolaFatturaElettronica(feObj) {
            $('[id$=txtNumGiustificativo_text]').val(feObj.numeroFattura);
            $('[id$=txtDataGiustificativo_text]').val(feObj.dataFattura);
            $('[id$=txtPivaFornitore_text]').val(feObj.partitaIva);
            $('[id$=txtRSFornitore_text]').val(feObj.ragioneSociale);
            $('[id$=txtDescGiustificativo_text]').val(feObj.causaleFattura);

            if (feObj.datiRiepilogo.length === 1) {
                $('[id$=txtImportoGiustificativo_text]').val(FromNumberToCurrency(feObj.datiRiepilogo[0].importoImponibile));
                $('[id$=txtIva_text]').val(feObj.datiRiepilogo[0].aliquotaIva);
                $('[id$=txtImportoLordoPagamento_text]').val(FromNumberToCurrency(feObj.datiRiepilogo[0].importoImponibile + feObj.datiRiepilogo[0].importoImposta));
                $('[id$=txtImportoNettoPagamento_text]').val(FromNumberToCurrency(feObj.datiRiepilogo[0].importoImponibile));
            }
            else {
                PopolaAliquoteIVA(feObj.datiRiepilogo);
                mostraPopupTemplate("ivaModal", "divBKGMessaggio");
            }

        }

        function GetFatturaElettronica(feObj) {
            if (feObj.length === 1) {
                PopolaFatturaElettronica(feObj[0]);
            }
            else {
                    var table = "<div style='float:left;'><table id='tbFattureLotto' style='position: absolute; width:100%;' class='tableNoTab'><tr><td class='separatore' colspan='5'>Selezione Fattura Elettronica</td></tr>";
                    var row = "<tr><td colspan='5' style='padding: 7px 7px 7px 7px;'>Nel tracciato sono presenti più elementi: Selezionare la fattura elettronica di interesse<br/></td></tr>";
                    row += "<tr class='TESTA1'><td>Numero</td><td>Data</td><td>Partita IVA</td><td>Ragione Sociale</td><td>Importo</td></tr>";
                    for (i in feObj) {
                        var rowStyle = ""; 
                        if (i % 2 == 0) {
                            rowStyle = "DataGridRow";
                        }
                        else {
                            rowStyle = "DataGridRowAlt";
                        }
                        for (j in feObj[i].datiRiepilogo) {
                            var imponibile = 0;
                            imponibile += feObj[i].datiRiepilogo[j].importoImponibile;
                        }
                        row += "<tr class='" + rowStyle + "'><td>" + feObj[i].numeroFattura + "</td><td>" + feObj[i].dataFattura + "</td><td>" + feObj[i].partitaIva + "</td><td>" + feObj[i].ragioneSociale + "</td><td>" + FromNumberToCurrency(imponibile) + "</td></tr>";
                
                    }
                    table += row + "</table></div><br/>";
                    $("#fatturaModal").prepend(table);
                    $("#tbFattureLotto").delegate("tr.DataGridRow, tr.DataGridRowAlt", "click", function () {
                        for (k = feObj.length - 1; k >= 0; k--) {
                            if (feObj[k].numeroFattura === $(this).find("td:nth-child(1)").text()) {
                                ChiudiPopupFattura();
                                PopolaFatturaElettronica(feObj[k]);
                            }
	                    }

                    });
                    mostraPopupTemplate("fatturaModal", "divBKGMessaggio");
            }

        }

        function PopolaAliquoteIVA(riepilogoObj) {
            var table = "<div style='float:left;'><table id='tbAliquoteIva' style='position: absolute; width:100%;' class='tableNoTab'><tr><td class='separatore' colspan='3'>Selezione aliquote IVA</td></tr>";
            var row = "<tr><td colspan='3' style='padding: 7px 7px 7px 7px;'>Selezionare l\'aliquota IVA corrispondente alla quota parte del giustificativo da registrare<br/></td></tr>";
            row +=  "<tr class='TESTA1'><td>Aliquota IVA</td><td>Importo Imponibile</td><td>Importo Imposta</td></tr>"
            for (i in riepilogoObj) {
                var rowStyle = ""; 
                if (i % 2 == 0) {
                    rowStyle = "DataGridRow";
                }
                else {
                    rowStyle = "DataGridRowAlt";
                }
                row += "<tr class='" + rowStyle + "'><td>" + riepilogoObj[i].aliquotaIva + "%</td><td>" + FromNumberToCurrency(riepilogoObj[i].importoImponibile) + "</td><td>" + FromNumberToCurrency(riepilogoObj[i].importoImposta) + "</td></tr>";
            }
            table += row + "</table></div><br/>";
            $("#ivaModal").prepend(table);
            $("#tbAliquoteIva").delegate("tr.DataGridRow, tr.DataGridRowAlt", "click", function () {

                $('[id$=txtImportoGiustificativo_text]').val($(this).find("td:nth-child(2)").text());
                $('[id$=txtIva_text]').val($(this).find("td:nth-child(1)").text().replace("%", ""));
                $('[id$=txtImportoLordoPagamento_text]').val(FromNumberToCurrency(FromCurrencyToNumber($(this).find("td:nth-child(2)").text()) + FromCurrencyToNumber($(this).find("td:nth-child(3)").text())));
                $('[id$=txtImportoNettoPagamento_text]').val($(this).find("td:nth-child(2)").text());
                
                ChiudiPopupIva();
            });
        }

        function ChiudiPopupIva(cleanForm) {
            if (cleanForm) {
                ResetFormGiustificativo();
            }
            
            $('#tbAliquoteIva').remove();
            chiudiPopupTemplate();
        }


        function ChiudiPopupFattura(cleanForm) {
            if (cleanForm) {
                ResetFormGiustificativo();
            }
            $('#tbFattureLotto').remove();
            chiudiPopupTemplate();
        }

        function ResetFormGiustificativo() {
            $('[id$=txtDataGiustificativo_text]').val('');
            $('[id$=txtNumGiustificativo_text]').val('');
            $('[id$=txtPivaFornitore_text]').val('');
            $('[id$=txtRSFornitore_text]').val('');
            $('[id$=txtDescGiustificativo_text]').val('');
            $('[id$=txtImportoGiustificativo_text]').val('');
            $('[id$=txtIva_text]').val('');
            $('[id$=txtImportoLordoPagamento_text]').val('');
            $('[id$=txtImportoNettoPagamento_text]').val('');
            //$('[id$=hdnSNCUFDatiFatturaE]').val('');
            SNCUFRimuoviFile('ctl00_cphContenuto_ufGiustificativo');
        }

        //function SNCVZCercaFornitoriProgetto_onprepare() {
        //    $('[id$=hdnIdFornitore]').val('');
        //} 
//--></script>

    <style type="text/css">
        .mrw-table { display: table; table-layout: fixed; width: 100%; padding: 10px; border-style: solid; }
        .mrw-tr { display: table-row; width: 100%; }
        .mrw-header {}
        .mrw-tr > div { display: table-cell; vertical-align: middle; padding: 10px 2px; white-space: nowrap; overflow: hidden; }
        .mrw-th, .mrw-tf { font-weight: bold; }
        .mrw-td { border-bottom-width: 1px; border-bottom-style: solid; }
        .mrw-grid .mrw-td { border-left-width: 1px; border-left-style: solid; }
        .mrw-grid .mrw-td:last-child { border-right-width: 1px; border-right-style: solid; }
        .mrw-width-5 { width: 5%; }
        .mrw-width-10 { width: 10%; }
        .mrw-width-15 { width: 15%; }
        .mrw-width-20 { width: 20%; }
        .mrw-width-25 { width: 25%; }
        .mrw-width-30 { width: 30%; }
        .mrw-width-33 { width: 33%; }
        .mrw-width-34 { width: 34%; }
        .mrw-width-35 { width: 35%; }
        .mrw-width-40 { width: 40%; }
        .mrw-width-45 { width: 45%; }
        .mrw-width-50 { width: 50%; }
        .mrw-width-55 { width: 55%; }
        .mrw-width-60 { width: 60%; }
        .mrw-width-65 { width: 65%; }
        .mrw-width-70 { width: 70%; }
        .mrw-width-75 { width: 75%; }
        .mrw-width-80 { width: 80%; }
        .mrw-width-85 { width: 85%; }
        .mrw-width-90 { width: 90%; }
        .mrw-width-95 { width: 95%; }
        .mrw-width-100 { width: 100%; }
        .mrw-center { vertical-align: top; margin: auto !important; text-align: center; }
        .mrw-right { text-align: right; }
        .dBox-overflow 
        {
	        box-shadow: 2px 3px 10px;
	        border-radius: 5px;
	        background-color:#E6E6EE;        	
	        margin:0px 10px 20px 10px;
	        overflow:hidden;
        }

        #tbAliquoteIva tr:nth-child(n+4):hover {
            background-color:#FEFEEE;
            cursor: pointer;
        }

        #tbFattureLotto tr:nth-child(n+4):hover {
            background-color:#FEFEEE;
            cursor: pointer;
        }

        .positivo {
            color: green;
        }

        .negativo {
            color: red;
        }

    </style>

    <uc2:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
    <div style="display: none">
        <asp:HiddenField ID="hdnIdGiustificativo" runat="server" />
        <asp:Button ID="btnCaricaSpesa" runat="server" CausesValidation="False" OnClick="btnCaricaSpesa_Click" />
        <asp:Button ID="btnCaricaGiustificativo" runat="server" CausesValidation="False"
            OnClick="btnCaricaGiustificativo_Click" />
        <asp:Button ID="btnPost" CausesValidation="false" runat="server" OnClick="btnPost_Click" />
        <asp:HiddenField ID="hdnIdIntegrazioneSingolaSelezionata" runat="server" />
        <asp:HiddenField ID="hdnCompletata" runat="server" />
        <asp:HiddenField ID="hdnIdSpesaSostenuta" runat="server" />
        <asp:HiddenField ID="hdnIdFileSpesaSostenuta" runat="server" />
        <asp:Button ID="btnRimuoviFileSpesa" runat="server" CausesValidation="False" OnClick="btnRimuoviFileSpesa_Click" />
        <%--<asp:HiddenField ID="hdnIdFornitore" runat="server" />--%>
        <asp:HiddenField ID="hdnIdImpresaFornitoreCercato" runat="server" />
    </div>
    <br />
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" Width="800px" TabNames="SPESE SOSTENUTE|Dettaglio della spesa" />
    <table class="tableTab" width="1150px" id="tbElenco" runat="server">
        <tr>
            <td class="testo_pagina">In questa pagina occorre inserire tutte le spese sostenute dal beneficiario per
                le quali<br />
                si richiede il pagamento. Ognuna di esse deve essere corredata dal rispettivo giustificativo
                del fornitore.
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                <br />
                Elementi trovati:
                <asp:Label ID="lblNrRecord" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 90px">Numero:<br />
                            <Siar:TextBox ID="txtFiltroNumero" runat="server" Width="80px" />
                        </td>
                        <td style="width: 90px">Data:<br />
                            <Siar:DateTextBox ID="txtFiltroData" runat="server" Width="80px" />
                        </td>
                        <td style="width: 160px">Tipo giustificativo:<br />
                            <Siar:ComboSql ID="lstFiltroTipoGiustificativo" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_SPESA=1"
                                DataTextField="DESCRIZIONE" DataValueField="COD_TIPO">
                            </Siar:ComboSql>
                        </td>
                        <td style="width: 240px">Oggetto della spesa:<br />
                            <Siar:TextBox ID="txtFiltroOggetto" runat="server" Width="230px" />
                        </td>
                        <td>
                            <br />
                            <asp:CheckBox ID="ckInintegrazione" runat="server" Text="In integrazione" />
                        </td>
                        <td style="width: 120px">
                            <br />
                            <Siar:Button ID="btnCerca" runat="server" Text="Filtra" Width="80px" OnClick="btnCerca_Click" />
                        </td>
                        <td>
                            <br />
                            <input id="btnStampa" runat="server" class="Button" style="width: 180px" type="button"
                                value="Esporta in excel" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 10px">
                <Siar:DataGrid ID="dgSpese" runat="server" AutoGenerateColumns="False" Width="100%"
                    AllowPaging="True" PageSize="10">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="25px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText=" ">
                            <ItemStyle Width="150px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Oggetto della spesa" DataField="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo lordo">
                            <ItemStyle Width="90px" HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo netto" DataField="Imponibile" DataFormatString="{0:c}">
                            <ItemStyle Width="90px" HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo richiesto">
                            <ItemStyle Width="90px" HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo ammesso">
                            <ItemStyle Width="90px" HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText=" "></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo lordo" DataField="Importo" DataFormatString="{0:c}">
                            <ItemStyle Width="90px" HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdSpesa" ButtonType="TextButton" ButtonText="Dettaglio"
                            JsFunction="caricaSpesa">
                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                        <Siar:JsButtonColumn Arguments="IdSpesa" ButtonType="ImageButton" ButtonText="Richiesta integrazione"
                            JsFunction="caricaSpesa" HeaderText="Richiesta integrazione" ButtonImage="warning.png">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <br />
        <tr id="trIntegrazioniRichieste" runat="server" visible="false">
            <td>
                <table width="100%">
                    <tr>
                        <td class="separatore" style="width: 287px">Elenco integrazioni da risolvere:
                        </td>
                    </tr>
                    <br />
                    &nbsp;
                    <tr>
                        <td align="right">
                            <Siar:Button ID="btnAllegati" runat="server" OnClick="btnAllegati_Click" Text="Allegati" Width="180px" />
                            <Siar:Button ID="btnInvestimenti" runat="server" OnClick="btnInvestimenti_Click" Text="Piano Investimenti" Width="180px" />
                            <Siar:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Indietro" Width="180px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <Siar:DataGrid ID="dgIntegrazioni" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                PageSize="15" Width="100%" ShowFooter="true">
                                <ItemStyle Height="28px" />
                                <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                <Columns>
                                    <asp:BoundColumn DataField="IdSingolaIntegrazione" HeaderText="ID singola integrazione">
                                        <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" Width="50px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataRichiestaIntegrazioneIstruttore" HeaderText="Data richiesta">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DescrizioneTipoIntegrazione" HeaderText="Tipo integrazione">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="SingolaIntegrazioneCompletataIstruttore" HeaderText="Completata istruttore">
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataRilascioIntegrazioneBeneficiario" HeaderText="Data rilascio beneficiario">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="SingolaIntegrazioneCompletataBeneficiario" HeaderText="Completata beneficiario">
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="NoteIntegrazioneIstruttore" HeaderText="Dati giustificativo">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="NoteIntegrazioneIstruttore" HeaderText="Dati pagamento">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <Siar:JsButtonColumn Arguments="IdSingolaIntegrazione" ButtonType="TextButton" ButtonText="Apri" JsFunction="visualizzaIntegrazioneSingola" HeaderText="Apri">
                                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                                    </Siar:JsButtonColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <br />
        <tr id="trDettaglioIntegrazioneSingolaSelezionata" runat="server" visible="false">
            <td>
                <table width="100%">
                    <tr>
                        <td class="separatore">Dettaglio singola integrazione selezionata:
                        </td>
                    </tr>
                    <tr>
                        <td class="paragrafo" style="width: 287px">Dati di competenza dell'istruttore:
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px">
                            <table width="100%">
                                <tr>
                                    <td>Data richiesta:<br />
                                        <Siar:DateTextBox ID="txtDataRichiesta" runat="server" Width="120px" ReadOnly="true" />
                                    </td>
                                    <td>Tipo integrazione:
                                        <br />
                                        <Siar:TextBox ID="txtTipoIntegrazione" runat="server" Width="180px" ReadOnly="true" />
                                    </td>
                                    <td>Integrazione completata:
                                        <br />
                                        <asp:DropDownList ID="comboCompletataSingolaIntegrazioneDomandaIstruttore" runat="server"
                                            Enabled="False">
                                            <asp:ListItem Text="No" Value="false"></asp:ListItem>
                                            <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">Note integrazione:
                                        <br />
                                        <Siar:TextArea ID="txtNoteSingolaIntegrazioneIstruttore" runat="server" NomeCampo="Note singola integrazione"
                                            Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" ReadOnly="true"
                                            MaxLength="10000" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="paragrafo" style="width: 287px">Dati di competenza del beneficiario:
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px">
                            <table width="100%">
                                <tr>
                                    <td>Data rilascio:<br />
                                        <Siar:DateTextBox ID="txtDataRilascio" runat="server" Width="120px" />
                                    </td>
                                    <td>Integrazione completata beneficiario:
                                        <br />
                                        <asp:DropDownList ID="comboCompletataSingolaIntegrazioneDomandaBeneficiario" runat="server">
                                            <asp:ListItem Text="No" Value="false"></asp:ListItem>
                                            <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">Note beneficiario:
                                        <br />
                                        <Siar:TextArea ID="txtNoteSingolaIntegrazioneBeneficiario" runat="server" NomeCampo="Note singola integrazione beneficiario"
                                            Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="paragrafo" colspan="2"></td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <Siar:Button ID="btnSalvaSingolaIntegrazione" runat="server" OnClick="btnSalvaSingolaIntegrazione_Click"
                                            Text="Salva dati singola integrazione" Width="190px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" id="tbInformazioniAggiuntive" runat="server">
                                <tr>
                                    <td class="separatore" colspan="2">Informazioni aggiuntive:
                                    </td>
                                </tr>
                                <tr>
                                    <td class="paragrafo" colspan="2">Dati giustificativo:
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Numero giustificativo:<br />
                                        <Siar:TextBox ID="txtNumGiustificativoDgIntegrazione" runat="server" MaxLength="30" Width="127px" ReadOnly="true" />
                                    </td>
                                    <td>Data giustificativo:<br />
                                        <Siar:DateTextBox ID="txtDataGiustificativoDgIntegrazione" runat="server" NomeCampo="Data giustificativo"
                                            Width="100px" ReadOnly="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ragione sociale del Fornitore:<br />
                                        <Siar:TextBox ID="txtRSFornitoreDgIntegrazione" runat="server" Width="520px" ReadOnly="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Oggetto della spesa:<br />
                                        <Siar:TextArea ID="txtDescGiustificativoDgIntegrazione" runat="server" NomeCampo="Oggetto della spesa"
                                            Width="578px" ReadOnly="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="paragrafo" colspan="2">Dati pagamento:
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tipo pagamento:<br />
                                        <Siar:TextBox ID="txtTipoPagamentoDgIntegrazione" runat="server" Width="520px" ReadOnly="true" />
                                    </td>
                                    <td>Estremi pagamento:<br />
                                        <Siar:TextBox ID="txtEstremiPagamentoDgIntegrazione" runat="server" Width="520px" ReadOnly="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table class="tableTab" width="800" id="tbNuovaSpesa" runat="server">
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore_light">Dati del giustificativo:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td>Tipo giustificativo:<br />
                                        <Siar:ComboSql ID="lstTipoGiustificativo" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_SPESA=1"
                                            DataTextField="DESCRIZIONE" DataValueField="COD_TIPO" Obbligatorio="True" NomeCampo="Tipo giustificativo"
                                            Width="280px">
                                        </Siar:ComboSql>
                                    </td>
                                    <td style="height: 25px; font-size: 13px; font-style: italic;" align="right">
                                        <a href="" runat="server" id="lnkGiustificativo">[Richiama un giustificativo precedentemente inserito]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 140px">Numero:<br />
                                        <Siar:TextBox ID="txtNumGiustificativo" runat="server" Width="120px" MaxLength="30" />
                                    </td>
                                    <td style="width: 140px">Data:<br />
                                        <Siar:DateTextBox ID="txtDataGiustificativo" runat="server" NomeCampo="Data giustificativo"
                                            Obbligatorio="True" Width="100px" />
                                    </td>
                                   <%-- campi DAS oscurati perchè non utilizzati --%>
                                    <td style="width: 140px"><%--Numero DAS:--%><br />
                                        <Siar:TextBox ID="txtNumDocTrasporto" runat="server" Width="120px" MaxLength="30" visible ="false"/>
                                    </td>
                                    <td><%--Data DAS:--%><br />
                                        <Siar:DateTextBox ID="txtDataDocTrasporto" runat="server" Width="100px" visible="false"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 130px">Imponibile €:<br />
                                        <Siar:CurrencyBox ID="txtImportoGiustificativo" runat="server" NomeCampo="Importo giustificativo"
                                            Obbligatorio="True" Width="110px" />
                                    </td>
                                    <td style="width: 90px">Iva %:<br />
                                        <Siar:QuotaBox ID="txtIva" runat="server" NomeCampo="Iva" Obbligatorio="True" Width="70px" />
                                    </td>
                                    <td>
                                        <br />
                                        <asp:CheckBox ID="chkNonRecuperabile" runat="server" Text="Iva non recuperabile" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>Oggetto della spesa:<br />
                            <Siar:TextArea ID="txtDescGiustificativo" runat="server" NomeCampo="Oggetto della spesa"
                                Obbligatorio="True" Width="578px" />
                        </td>
                        <td align="center" id="tdRichiestaIntegrazioneGiustificativo" runat="server" visible="false">
                            <img src="../../images/warning.png" alt="Richiesta integrazione" title="Richiesta integrazione" /><br />
                            Richiesta integrazione<br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 235px">
                                        <br />
                                        Fornitore (P.Iva):<br />
                                        <Siar:TextBox ID="txtPivaFornitore" runat="server" Width="190px" NomeCampo="Partita iva del fornitore"
                                            Obbligatorio="True" MaxLength="16" />
                                    </td>
                                    <td>
                                        <br />
                                        <br />
                                        <Siar:Button ID="btnScaricaFornitore" runat="server" CausesValidation="false" Modifica="True"
                                            OnClick="btnScaricaFornitore_Click" Text="Cerca" Width="120px" ToolTip="Inserire la partita iva del fornitore (nel caso di p.iva straniera mettere 12 zeri). Se la ricerca non produce risultati si potrà compilare la ragione sociale in autonomia" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>Ragione sociale:<br />
                            <Siar:TextBox ID="txtRSFornitore" runat="server" Width="576px" ReadOnly="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            Specificare il file digitale relativo al giustificativo:<br />
                            <uc4:SNCUploadFileControl ID="ufGiustificativo" runat="server" TipoFile="DocumentoFE" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore_light">Estremi del pagamento:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td>Tipo pagamento:<br />
                            <Siar:ComboSql ID="lstPagamento" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_PAGAMENTO=1"
                                DataTextField="DESCRIZIONE" DataValueField="COD_TIPO" Obbligatorio="True" NomeCampo="Tipo pagamento">
                            </Siar:ComboSql>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 120px">Data:<br />
                                        <Siar:DateTextBox ID="txtDataPagamento" runat="server" NomeCampo="Data pagamento"
                                            Obbligatorio="True" Width="90px" />
                                    </td>
                                    <td style="width: 140px">Importo Lordo €:<br />
                                        <Siar:CurrencyBox ID="txtImportoLordoPagamento" runat="server" NomeCampo="Importo lordo del pagamento"
                                            Obbligatorio="True" Width="110px" />
                                    </td>
                                    <td>Importo Netto €:<br />
                                        <Siar:CurrencyBox ID="txtImportoNettoPagamento" runat="server" Width="110px" NomeCampo="Importo netto del pagamento"
                                            Obbligatorio="True" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>Estremi:<br />
                            <Siar:TextBox ID="txtEstremi" runat="server" Width="488px" NomeCampo="Estremi del pagamento"
                                Obbligatorio="True" />
                        </td>
                        <td align="center" id="tdRichiestaIntegrazionePagamento" runat="server" visible="false">
                            <img src="../../images/warning.png" alt="Richiesta integrazione" title="Richiesta integrazione" /><br />
                            Richiesta integrazione<br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            Specificare il file digitale relativo al pagamento:<br />
                            <uc4:SNCUploadFileControl ID="ufPagamento" runat="server" TipoFile="Documento" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div class="mrw-table" id="trFileSpesaSostenuta" runat="server" visible="false">
                    <div class="mrw-tr">
                        <div class="mrw-width-100">
                            <div class="paragrafo" style="width: 300px">Ulteriori file digitali a sostegno del pagamento</div>
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-100">
                            <Siar:DataGrid ID="dgFileSpeseSostenute" runat="server" AutoGenerateColumns="false" Visible="true" AllowPaging="true" PageSize="20" Width="90%">
                                <Columns>
                                    <Siar:ColonnaLink DataField="IdFileSpeseSostenute" HeaderText="Id." IsJavascript="true"
                                        LinkFields="IdFileSpeseSostenute" LinkFormat="selezionaFileSpese({0});">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="NomeFile" HeaderText="Nome file"></asp:BoundColumn>
                                    <Siar:JsButtonColumn Arguments="IdFileSpeseSostenute" ButtonType="TextButton" ButtonText="Rimuovi" JsFunction="rimuoviFileSpesa">
                                        <ItemStyle Width="90px" HorizontalAlign="Center" />
                                    </Siar:JsButtonColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </div>
                    </div>
                    <div id="divInserimentoFileSpese" runat="server">
                        <div class="mrw-tr">
                            <div class="mrw-width-100">
                                <div class="paragrafo" style="width: 150px">Dettaglio file</div>
                            </div>
                        </div>
                        <div class="mrw-tr">
                            <div class="mrw-width-100">
                                Descrizione file:
                                <br />
                                <Siar:TextBox ID="txtDescrizioneFile" runat="server" Width="488px" />
                            </div>
                        </div>
                        <div class="mrw-tr">
                            <div class="mrw-width-100">
                                Specificare il file digitale relativo al pagamento:<br />
                                <uc4:SNCUploadFileControl ID="ufFileSpesaSostenuta" runat="server" TipoFile="Documento" />
                            </div>
                        </div>
                        <div class="mrw-tr">
                            <div class="mrw-width-100">
                                <Siar:Button ID="btnAssociaFileSpesa" runat="server" CausesValidation="False"
                                    OnClick="btnAssociaFileSpesa_Click" Text="Associa file al pagamento" />
                                <input type="button" class="Button" value="Svuota campi file" style="width: 140px" onclick="return svuotaCampiFile();" />
                            </div>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">&nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 62px">
                <Siar:Button ID="btnSalva" runat="server" CausesValidation="True" Modifica="True"
                    OnClick="btnSalva_Click" Text="Salva" Width="160px" OnClientClick="return validaImporti(false,event);" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <Siar:Button ID="btnElimina" runat="server" CausesValidation="False" Modifica="True"
                    OnClick="btnElimina_Click" Text="Elimina" Width="160px" Conferma="Attenzione! Eliminare la spesa selezionata?" />
                &nbsp;&nbsp; &nbsp; &nbsp;
                <Siar:Button ID="btnNuovaSpesa" runat="server" CausesValidation="False" Modifica="True"
                    Text="Nuova spesa" Width="160px" OnClick="btnNuovaSpesa_Click" />
                <Siar:Button ID="btnRendicontazioneVeloce" runat="server" CausesValidation="False"
                    Modifica="True" OnClick="btnRendicontazioneVeloce_Click" Text="Rendicontazione veloce"
                    Width="160px" Visible="False" />
            </td>
        </tr>
    </table>
    <br /><br />
    <div class="dBox" id="divElencoPianoInv" runat="server"  visible="false" style="width: 100%; height: 100%;margin:0px">
        <div style="overflow: auto; width: 100%; height: 90%;">
            <div class="separatore_light">
                Associazione del giustificativo al piano investimenti :
            </div>
            <br />

            <div style="padding: 0px 10px 10px 10px;">
                <Siar:DataGrid ID="dgInvestimenti" runat="server" ShowFooter="false" AutoGenerateColumns="False" PageSize="20" Width="100%">
                    <ItemStyle Height="30px" />
                    <Columns>           
                        <asp:BoundColumn HeaderText="Descrizione">
                            <ItemStyle HorizontalAlign="left" Width="1000px" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink HeaderText="Costo totale investimento" DataField="CostoInvestimento" DataFormatString="{0:c}" IsJavascript="false"
                            LinkFields="IdInvestimento" LinkFormat="PagamentoInvestimento.aspx?idinv={0}" >
                            <ItemStyle Width="80px" HorizontalAlign="right" />
                        </Siar:ColonnaLink>
                        <asp:BoundColumn HeaderText="Contributo ammesso" DataField="ContributoRichiesto" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo giustificativo richiesto" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo giustificativo richiesto" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo giustificativo ammissibile" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo giustificativo ammissibile" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="80px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </div>
        </div>
    </div>
    <uc3:ZoomLoader ID="ucZoomLoaderGiustificativo" runat="server" AutomaticSearch="true"
        SearchMethod="GetGiustificativiProgetto" KeySearch="Numero:Numero|Data:Data:d"
        ColumnsToBind="nr|Numero:Numero:d|Data:Data:d|Imponibile:Imponibile:c|Descrizione:Descrizione"
        KeyValue="IdGiustificativo" KeyText="Descrizione|Numero|CodTipo|Data|CfFornitore|DataDoctrasporto|DescrizioneFornitore|Imponibile|Iva|IvaNonRecuperabile|NumeroDoctrasporto"
        NoSearch="true" JsSelectedItemHandler="riempiCampiGiustificativo" Width="700px" />
    
    <div id="ivaModal" class="dBox-overflow" style="width: 30%; height: 25%; position: absolute; display: none; box-shadow: none; overflow:auto; background-color:#E6E6EE;">
        <div style="position:absolute; bottom:5px; left:5px; right:5px;">
            <input type="button" class="Button" style="width: 80px; float:right;" value="Chiudi" onclick="ChiudiPopupIva(true)" />
        </div>
    </div> 

    <div id="fatturaModal" class="dBox-overflow" style="width: 50%; height: 70%; position: absolute; display: none; box-shadow: none; overflow:auto; background-color:#E6E6EE;">
        <div style="position:absolute; bottom:5px; left:5px; right:5px;">
            <input type="button" class="Button" style="width: 80px; float:right;" value="Chiudi" onclick="ChiudiPopupFattura(true)" />
        </div>
    </div> 
</asp:Content>
