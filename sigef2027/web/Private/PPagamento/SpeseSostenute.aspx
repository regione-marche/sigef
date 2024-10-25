<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.SpeseSostenute" CodeBehind="SpeseSostenute.aspx.cs" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento"
    TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTabAgid" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/ZoomLoader.ascx" TagName="ZoomLoader" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc4" %>
<%@ Register Src="../../CONTROLS/CardPagamento.ascx" TagName="CardPagamento" TagPrefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    $(document).ready(function () {
        let $el = $('.steppers-nav').clone();
        $('#containerCopiaPulsanti').append($el);
    });

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
        row += "<tr class='TESTA1'><td>Aliquota IVA</td><td>Importo Imponibile</td><td>Importo Imposta</td></tr>"
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
        .mrw-table {
            display: table;
            table-layout: fixed;
            width: 100%;
            padding: 10px;
            border-style: solid;
        }

        .mrw-tr {
            display: table-row;
            width: 100%;
        }

        .mrw-header {
        }

        .mrw-tr > div {
            display: table-cell;
            vertical-align: middle;
            padding: 10px 2px;
            white-space: nowrap;
            overflow: hidden;
        }

        .mrw-th, .mrw-tf {
            font-weight: bold;
        }

        .mrw-td {
            border-bottom-width: 1px;
            border-bottom-style: solid;
        }

        .mrw-grid .mrw-td {
            border-left-width: 1px;
            border-left-style: solid;
        }

            .mrw-grid .mrw-td:last-child {
                border-right-width: 1px;
                border-right-style: solid;
            }

        .mrw-width-5 {
            width: 5%;
        }

        .mrw-width-10 {
            width: 10%;
        }

        .mrw-width-15 {
            width: 15%;
        }

        .mrw-width-20 {
            width: 20%;
        }

        .mrw-width-25 {
            width: 25%;
        }

        .mrw-width-30 {
            width: 30%;
        }

        .mrw-width-33 {
            width: 33%;
        }

        .mrw-width-34 {
            width: 34%;
        }

        .mrw-width-35 {
            width: 35%;
        }

        .mrw-width-40 {
            width: 40%;
        }

        .mrw-width-45 {
            width: 45%;
        }

        .mrw-width-50 {
            width: 50%;
        }

        .mrw-width-55 {
            width: 55%;
        }

        .mrw-width-60 {
            width: 60%;
        }

        .mrw-width-65 {
            width: 65%;
        }

        .mrw-width-70 {
            width: 70%;
        }

        .mrw-width-75 {
            width: 75%;
        }

        .mrw-width-80 {
            width: 80%;
        }

        .mrw-width-85 {
            width: 85%;
        }

        .mrw-width-90 {
            width: 90%;
        }

        .mrw-width-95 {
            width: 95%;
        }

        .mrw-width-100 {
            width: 100%;
        }

        .mrw-center {
            vertical-align: top;
            margin: auto !important;
            text-align: center;
        }

        .mrw-right {
            text-align: right;
        }

        .dBox-overflow {
            box-shadow: 2px 3px 10px;
            border-radius: 5px;
            background-color: #E6E6EE;
            margin: 0px 10px 20px 10px;
            overflow: hidden;
        }

        #tbAliquoteIva tr:nth-child(n+4):hover {
            background-color: #FEFEEE;
            cursor: pointer;
        }

        #tbFattureLotto tr:nth-child(n+4):hover {
            background-color: #FEFEEE;
            cursor: pointer;
        }

        .positivo {
            color: green;
        }

        .negativo {
            color: red;
        }
    </style>

    <uc5:CardPagamento ID="ucCardPagamento" runat="server" />
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <uc2:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
            </div>
            <div class="steppers-content" aria-live="polite">
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
                <uc1:SiarNewTabAgid ID="ucSiarNewTab" runat="server" TabNames="SPESE SOSTENUTE|Dettaglio della spesa" />
                <div class="row tableTab py-5 mx-2" id="tbElenco" runat="server">
                    <p>In questa pagina occorre inserire tutte le spese sostenute dal beneficiario per le quali si richiede il pagamento. Ognuna di esse deve essere corredata dal rispettivo giustificativo del fornitore.</p>
                    <p>
                        Elementi trovati:
                        <asp:Label ID="lblNrRecord" runat="server"></asp:Label>
                    </p>
                    <div class="col-sm-1 form-group">
                        <Siar:TextBox  ID="txtFiltroNumero" Label="Numero:" runat="server" />
                    </div>
                    <div class="col-sm-1 form-group">
                        <Siar:DateTextBox Label="Data:" ID="txtFiltroData" runat="server" />
                    </div>
                    <div class="col-sm-2 form-group">
                        <Siar:ComboSql Label="Tipo giustificativo:" ID="lstFiltroTipoGiustificativo" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_SPESA=1"
                            DataTextField="DESCRIZIONE" DataValueField="COD_TIPO">
                        </Siar:ComboSql>
                    </div>
                    <div class="col-sm-2 form-group">
                        <Siar:TextBox  Label="Oggetto della spesa:" ID="txtFiltroOggetto" runat="server" />
                    </div>
                    <div class="col-sm-2 form-check">
                        <asp:CheckBox ID="ckInintegrazione" runat="server" Text="In integrazione" />
                    </div>
                    <div class="col-sm-2">
                        <Siar:Button ID="btnCerca" runat="server" Text="Filtra" OnClick="btnCerca_Click" />
                    </div>
                    <div class="col-sm-2">
                        <input id="btnStampa" runat="server" class="btn btn-secondary py-1" type="button"
                            value="Esporta in excel" />
                    </div>
                    <div class="col-sm-12">
                        <Siar:DataGridAgid ID="dgSpese" CssClass="table table-striped" runat="server" AutoGenerateColumns="False"
                            AllowPaging="True" PageSize="10">
                            <Columns>
                                <Siar:NumberColumn HeaderText="Nr.">
                                </Siar:NumberColumn>
                                <asp:BoundColumn HeaderText=" "></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Oggetto della spesa" DataField="Descrizione"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Importo lordo">
                                    <ItemStyle HorizontalAlign="right" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Importo netto" DataField="Imponibile" DataFormatString="{0:c}">
                                    <ItemStyle Width="90px" HorizontalAlign="right" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Importo richiesto">
                                    <ItemStyle HorizontalAlign="right" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Importo ammesso">
                                    <ItemStyle HorizontalAlign="right" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText=" "></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Importo lordo" DataField="Importo" DataFormatString="{0:c}">
                                    <ItemStyle HorizontalAlign="right" />
                                </asp:BoundColumn>
                                <Siar:JsButtonColumnAgid Arguments="IdSpesa" ButtonType="TextButton" ButtonText="Dettaglio"
                                    JsFunction="caricaSpesa">
                                    <ItemStyle HorizontalAlign="Center" />
                                </Siar:JsButtonColumnAgid>
                                <Siar:JsButtonColumnAgid Arguments="IdSpesa" ButtonType="ImageButton" ButtonText="Richiesta integrazione"
                                    JsFunction="caricaSpesa" HeaderText="Richiesta integrazione" ButtonImage="warning.png">
                                    <ItemStyle HorizontalAlign="Center" />
                                </Siar:JsButtonColumnAgid>
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                    <div id="trIntegrazioniRichieste" runat="server" visible="false">
                        <h3 class="pb-5">Elenco integrazioni da risolvere:</h3>
                        <div class="col-sm-12">
                            <Siar:Button ID="btnAllegati" runat="server" OnClick="btnAllegati_Click" Text="Allegati" />
                            <Siar:Button ID="btnInvestimenti" runat="server" OnClick="btnInvestimenti_Click" Text="Piano Investimenti" />
                            <Siar:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Indietro" />
                        </div>
                        <div class="col-sm-12">
                            <Siar:DataGridAgid CssClass="table table-striped" ID="dgIntegrazioni" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                PageSize="15" ShowFooter="true">
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
                            </Siar:DataGridAgid>
                        </div>
                    </div>
                    <div id="trDettaglioIntegrazioneSingolaSelezionata" class="col-sm-12 bd-form" runat="server" visible="false">
                        <h3 class="pb-5">Dettaglio singola integrazione selezionata:</h3>
                        <h4 class="pb-5">Dati di competenza dell'istruttore:</h4>
                        <div class="col-sm-12 form-group">
                            <Siar:DateTextBox Label="Data richiesta:" ID="txtDataRichiesta" runat="server" Width="120px" ReadOnly="true" />
                        </div>
                        <div class="col-sm-12 form-group">
                            <Siar:TextBox  Label="Tipo integrazione:" ID="txtTipoIntegrazione" runat="server" Width="180px" ReadOnly="true" />
                        </div>
                        <div class="col-sm-12 form-group">
                            <label for="<% =comboCompletataSingolaIntegrazioneDomandaIstruttore.ClientID %>">Integrazione completata:</label>
                            <asp:DropDownList ID="comboCompletataSingolaIntegrazioneDomandaIstruttore" runat="server"
                                Enabled="False">
                                <asp:ListItem Text="No" Value="false"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-12 form-group">
                            <Siar:TextArea Label="Note integrazione:" ID="txtNoteSingolaIntegrazioneIstruttore" runat="server" NomeCampo="Note singola integrazione"
                                Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" ReadOnly="true"
                                MaxLength="10000" />
                        </div>


                        <h4 class="pb-5">Dati di competenza del beneficiario:</h4>
                        <div class="col-sm-12 form-group">
                        </div>
                        <div class="col-sm-12 form-group">
                            <Siar:DateTextBox Label="Data rilascio:" ID="txtDataRilascio" runat="server" />
                        </div>
                        <div class="col-sm-12 form-group">
                            <label for="<% =comboCompletataSingolaIntegrazioneDomandaBeneficiario.ClientID %>">Integrazione completata beneficiario:</label>
                            <asp:DropDownList ID="comboCompletataSingolaIntegrazioneDomandaBeneficiario" runat="server">
                                <asp:ListItem Text="No" Value="false"></asp:ListItem>
                                <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-12 form-group">
                            <Siar:TextArea Label="Note beneficiario:" ID="txtNoteSingolaIntegrazioneBeneficiario" runat="server" NomeCampo="Note singola integrazione beneficiario"
                                Obbligatorio="false" Rows="4" ExpandableRows="5" MaxLength="10000" />
                        </div>
                        <div class="col-sm-12">
                            <Siar:Button ID="btnSalvaSingolaIntegrazione" runat="server" OnClick="btnSalvaSingolaIntegrazione_Click"
                                Text="Salva dati singola integrazione" />
                        </div>

                        <div class="row" id="tbInformazioniAggiuntive" runat="server">
                            <h3 class="pb-5">Informazioni aggiuntive:</h3>
                            <h4 class="pb-5">Dati giustificativo:</h4>
                            <div class="col-sm-12 form-group">
                            </div>
                            <div class="col-sm-12 form-group">
                                <Siar:TextBox  Label="Numero giustificativo:" ID="txtNumGiustificativoDgIntegrazione" runat="server" MaxLength="30" ReadOnly="true" />
                            </div>
                            <div class="col-sm-12 form-group">
                                <Siar:DateTextBox Label="Data giustificativo:" ID="txtDataGiustificativoDgIntegrazione" runat="server" NomeCampo="Data giustificativo"
                                    ReadOnly="true" />
                            </div>
                            <div class="col-sm-12 form-group">
                                <Siar:TextBox  Label="Ragione sociale del Fornitore:" ID="txtRSFornitoreDgIntegrazione" runat="server" ReadOnly="true" />
                            </div>
                            <div class="col-sm-12 form-group">
                                <Siar:TextArea Label="Oggetto della spesa:" ID="txtDescGiustificativoDgIntegrazione" runat="server" NomeCampo="Oggetto della spesa" ReadOnly="true" />
                            </div>
                            <h4 class="pb-5">Dati pagamento:</h4>
                            <div class="col-sm-12 form-group">
                                <Siar:TextBox  Label="Tipo pagamento:" ID="txtTipoPagamentoDgIntegrazione" runat="server" ReadOnly="true" />
                            </div>
                            <div class="col-sm-12 form-group">
                                <Siar:TextBox  Label="Estremi pagamento:" ID="txtEstremiPagamentoDgIntegrazione" runat="server" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row tableTab py-5 mx-2" id="tbNuovaSpesa" runat="server">
                    <div class="bd-form col-sm-12">
                        <div class="row">
                            <h3 class="pb-5">Dati del giustificativo:</h3>
                            <div class="col-sm-12 text-end ">
                                <p>
                                    <i><a href="" runat="server" id="lnkGiustificativo">[Richiama un giustificativo precedentemente inserito]</a></i>
                                </p>
                            </div>
                            <div class="form-group col-sm-12">
                                <Siar:ComboSql Label="Tipo giustificativo:" ID="lstTipoGiustificativo" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_SPESA=1"
                                    DataTextField="DESCRIZIONE" DataValueField="COD_TIPO" Obbligatorio="True" NomeCampo="Tipo giustificativo">
                                </Siar:ComboSql>
                            </div>
                            <div class="form-group col-sm-6">
                                <Siar:TextBox  Label="Numero:" ID="txtNumGiustificativo" runat="server" MaxLength="30" />
                            </div>
                            <div class="form-group col-sm-6">
                                <Siar:DateTextBox Label="Data:" ID="txtDataGiustificativo" runat="server" NomeCampo="Data giustificativo"
                                    Obbligatorio="True" />
                            </div>
                            <div class="form-group col-sm-6" style="display: none;">
                                <Siar:TextBox  Label="Numero DAS:" ID="txtNumDocTrasporto" runat="server" MaxLength="30" Visible="false" />
                            </div>
                            <div class="form-group col-sm-6" style="display: none;">
                                <Siar:DateTextBox Label="Data DAS:" ID="txtDataDocTrasporto" runat="server" Visible="false" />
                            </div>
                            <div class="form-group col-sm-4">
                                <Siar:CurrencyBox Label="Imponibile €:" ID="txtImportoGiustificativo" runat="server" NomeCampo="Importo giustificativo"
                                    Obbligatorio="True" />
                            </div>
                            <div class="form-group col-sm-4">
                                <Siar:QuotaBox Label="Iva %:" ID="txtIva" runat="server" NomeCampo="Iva" Obbligatorio="True" />
                            </div>
                            <div class="form-check col-sm-4">
                                <asp:CheckBox ID="chkNonRecuperabile" runat="server" Text="Iva non recuperabile" />
                            </div>
                            <div class="form-group col-sm-12">
                                <Siar:TextArea Label="Oggetto della spesa:" ID="txtDescGiustificativo" runat="server" NomeCampo="Oggetto della spesa"
                                    Obbligatorio="True" />
                            </div>
                            <div class="text-center col-sm-12" id="tdRichiestaIntegrazioneGiustificativo" runat="server" visible="false">
                                <img src="../../images/warning.png" alt="Richiesta integrazione" title="Richiesta integrazione" />
                                <p>Richiesta integrazione</p>
                            </div>
                            <div class="col-sm-6 form-group">
                                <Siar:TextBox  Label="Fornitore (P.Iva):" ID="txtPivaFornitore" runat="server" NomeCampo="Partita iva del fornitore"
                                    Obbligatorio="True" MaxLength="16" />
                            </div>
                            <div class="col-sm-6">
                                <Siar:Button ID="btnScaricaFornitore" runat="server" CausesValidation="false" Modifica="True"
                                    OnClick="btnScaricaFornitore_Click" Text="Cerca" Width="120px" ToolTip="Inserire la partita iva del fornitore (nel caso di p.iva straniera mettere 12 zeri). Se la ricerca non produce risultati si potrà compilare la ragione sociale in autonomia" />
                            </div>
                            <div class="col-sm-12 form-group">
                                <Siar:TextBox  Label="Ragione sociale:" ID="txtRSFornitore" runat="server" ReadOnly="True" />
                            </div>
                            <h4>Specificare il file digitale relativo al giustificativo:</h4>
                            <div class="col-sm-12">
                                <uc4:SNCUploadFileControl ID="ufGiustificativo" runat="server" TipoFile="DocumentoFE" />
                            </div>
                            <h3 class="pb-5">Estremi del pagamento:
                            </h3>
                            <div class="col-sm-12 form-group">
                                <Siar:ComboSql Label="Tipo pagamento:" ID="lstPagamento" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_PAGAMENTO=1"
                                    DataTextField="DESCRIZIONE" DataValueField="COD_TIPO" Obbligatorio="True" NomeCampo="Tipo pagamento">
                                </Siar:ComboSql>
                            </div>
                            <div class="col-sm-4 form-group">
                                <Siar:DateTextBox Label="Data:" ID="txtDataPagamento" runat="server" NomeCampo="Data pagamento"
                                    Obbligatorio="True" />
                            </div>
                            <div class="col-sm-4 form-group">
                                <Siar:CurrencyBox Label="Importo Lordo €:" ID="txtImportoLordoPagamento" runat="server" NomeCampo="Importo lordo del pagamento"
                                    Obbligatorio="True" />
                            </div>
                            <div class="col-sm-4 form-group">
                                <Siar:CurrencyBox Label="Importo Netto €:" ID="txtImportoNettoPagamento" runat="server" NomeCampo="Importo netto del pagamento"
                                    Obbligatorio="True" />
                            </div>
                            <div class="col-sm-12 form-group">
                                <Siar:TextBox  Label="Estremi:" ID="txtEstremi" runat="server" NomeCampo="Estremi del pagamento"
                                    Obbligatorio="True" />
                            </div>
                            <div class="col-sm-12 form-group" id="tdRichiestaIntegrazionePagamento" runat="server" visible="false">
                                <img src="../../images/warning.png" alt="Richiesta integrazione" title="Richiesta integrazione" />
                                <p>Richiesta integrazione</p>
                            </div>
                            <h4>Specificare il file digitale relativo al pagamento:</h4>
                            <div class="col-sm-12">
                                <uc4:SNCUploadFileControl ID="ufPagamento" runat="server" TipoFile="Documento" />
                            </div>
                            <div class="col-sm-12">
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
                                                <Siar:TextBox  ID="txtDescrizioneFile" runat="server" Width="488px" />
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
                            </div>
                            <div class="col-sm-12">
                                <Siar:Button ID="btnSalva" runat="server" CausesValidation="True" Modifica="True"
                                    OnClick="btnSalva_Click" Text="Salva" OnClientClick="return validaImporti(false,event);" />
                                <Siar:Button ID="btnElimina" runat="server" CausesValidation="False" Modifica="True"
                                    OnClick="btnElimina_Click" Text="Elimina" Conferma="Attenzione! Eliminare la spesa selezionata?" />
                                <Siar:Button ID="btnNuovaSpesa" runat="server" CausesValidation="False" Modifica="True"
                                    Text="Nuova spesa" Width="160px" OnClick="btnNuovaSpesa_Click" />
                                <Siar:Button ID="btnRendicontazioneVeloce" runat="server" CausesValidation="False"
                                    Modifica="True" OnClick="btnRendicontazioneVeloce_Click" Text="Rendicontazione veloce"
                                    Visible="False" />
                            </div>
                        </div>
                    </div>
                    <div class="row" id="divElencoPianoInv" runat="server" visible="false">
                        <h3 class="py-5">Associazione del giustificativo al piano investimenti :</h3>
                        <div class="col-sm-12">
                            <Siar:DataGridAgid ID="dgInvestimenti" runat="server" CssClass="table table-striped" ShowFooter="false" AutoGenerateColumns="False" PageSize="20">
                                <Columns>
                                    <asp:BoundColumn HeaderText="Descrizione"></asp:BoundColumn>
                                    <Siar:ColonnaLink HeaderText="Costo totale investimento" DataField="CostoInvestimento" DataFormatString="{0:c}" IsJavascript="false"
                                        LinkFields="IdInvestimento" LinkFormat="PagamentoInvestimento.aspx?idinv={0}">
                                        <ItemStyle Width="80px" HorizontalAlign="right" />
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn HeaderText="Contributo ammesso" DataField="ContributoRichiesto" DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Importo giustificativo richiesto" DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Contributo giustificativo richiesto" DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Importo giustificativo ammissibile" DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Contributo giustificativo ammissibile" DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="right" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                    </div>
                </div>

                <uc3:ZoomLoader ID="ucZoomLoaderGiustificativo" runat="server" AutomaticSearch="true"
                    SearchMethod="GetGiustificativiProgetto" KeySearch="Numero:Numero|Data:Data:d"
                    ColumnsToBind="nr|Numero:Numero:d|Data:Data:d|Imponibile:Imponibile:c|Descrizione:Descrizione"
                    KeyValue="IdGiustificativo" KeyText="Descrizione|Numero|CodTipo|Data|CfFornitore|DataDoctrasporto|DescrizioneFornitore|Imponibile|Iva|IvaNonRecuperabile|NumeroDoctrasporto"
                    NoSearch="true" JsSelectedItemHandler="riempiCampiGiustificativo" Width="700px" />

                <div id="ivaModal" class="dBox-overflow" style="width: 30%; height: 25%; position: absolute; display: none; box-shadow: none; overflow: auto; background-color: #E6E6EE;">
                    <div style="position: absolute; bottom: 5px; left: 5px; right: 5px;">
                        <input type="button" class="Button" style="width: 80px; float: right;" value="Chiudi" onclick="ChiudiPopupIva(true)" />
                    </div>
                </div>

                <div id="fatturaModal" class="dBox-overflow" style="width: 50%; height: 70%; position: absolute; display: none; box-shadow: none; overflow: auto; background-color: #E6E6EE;">
                    <div style="position: absolute; bottom: 5px; left: 5px; right: 5px;">
                        <input type="button" class="Button" style="width: 80px; float: right;" value="Chiudi" onclick="ChiudiPopupFattura(true)" />
                    </div>
                </div>
                <div id="containerCopiaPulsanti" class="row py-5 steppers">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
