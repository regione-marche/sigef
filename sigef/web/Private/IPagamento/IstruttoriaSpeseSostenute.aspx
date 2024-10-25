<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IstruttoriaSpeseSostenute" CodeBehind="IstruttoriaSpeseSostenute.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento"
    TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function caricaSpesa(id) { $('[id$=hdnIdSpesaSostenuta]').val(id); $('[id$=btnModifica]').click(); }
        function validaImporti(scrivi_importo_netto, ev) {
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
        function ctrlCF() {
            var cf = document.getElementById("ctl00_cphContenuto_txtPivaFornitore_text").value;
            if (cf != "" && !ctrlCodiceFiscale(cf) && !ctrlPIVA(cf)) {
                alert('Attenzione! Codice fiscale/P.Iva del fornitore inesistente.');
                //document.getElementById("ctl00_cphContenuto_txtPivaFornitore_text").select();
            }
        }
        function selezionaFileSpese(idFile) {
            $('[id$=hdnIdFileSpesaSostenuta]').val($('[id$=hdnIdFileSpesaSostenuta]').val() == idFile ? '' : idFile);
            $('[id$=btnPost]').click();
        }
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
    </style>

    <div style="display: none">
        <asp:Button ID="btnModifica" runat="server" CausesValidation="False" OnClick="btnModifica_Click" />
        <asp:Button ID="btnPost" CausesValidation="false" runat="server" OnClick="btnPost_Click" />
        <input type="hidden" id="hdnIdSpesaSostenuta" runat="server" />
        <asp:HiddenField ID="hdnIdFileSpesaSostenuta" runat="server" />
    </div>
    
    <br />
    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <br />
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" Width="800px" TabNames="ISTRUTTORIA SPESE SOSTENUTE|Dettaglio spesa" />
    <table id="tabElenco" runat="server" class="tableTab" width="1100px">
        <tr>
            <td>
                &nbsp;<table width="100%">
                    <tr>
                        <td style="width: 641px">
                            &nbsp;- In questa pagina vengono elencate tutte le spese sostenute dal beneficiario
                            per le quali si richiede il pagamento.<br />
                            &nbsp;&nbsp; corredate dal rispettivo giustificativo del fornitore. Per l'eventuale
                            modifica dei dati usare il link apposito.
                        </td>
                        <td align="center">
                            <input id="btnStampa" runat="server" class="Button" style="width: 180px" type="button"
                                value="Esporta in excel" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <input id="btnBack" runat="server" class="Button" style="width: 160px" type="button"
                                onclick="location='CheckListPagamento.aspx'" value="Indietro" />
                        </td>
                    </tr>
                </table>
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
            <td>
                <table width="100%">
                    <tr>
                        <td style="width: 90px; height: 52px;">
                            Numero:<br />
                            <Siar:TextBox ID="txtFiltroNumero" runat="server" Width="80px" />
                        </td>
                        <td style="width: 90px; height: 52px;">
                            Data:<br />
                            <Siar:DateTextBox ID="txtFiltroData" runat="server" Width="80px" />
                        </td>
                        <td style="width: 160px; height: 52px;">
                            Tipo giustificativo:<br />
                            <Siar:ComboSql ID="lstFiltroTipoGiustificativo" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_SPESA=1"
                                DataTextField="DESCRIZIONE" DataValueField="COD_TIPO">
                            </Siar:ComboSql>
                        </td>
                        <td style="width: 240px; height: 52px;">
                            Oggetto della spesa:<br />
                            <Siar:TextBox ID="txtFiltroOggetto" runat="server" Width="230px" />
                        </td>
                        <td>
                            <br />
                            <asp:CheckBox ID="ckInintegrazione" runat="server" Text="In integrazione" />
                        </td>
                        <td style="height: 52px">
                            <br />
                            <Siar:Button ID="btnCerca" runat="server" Text="Filtra" Width="80px" OnClick="btnCerca_Click" />
                        </td>
                    </tr>
                </table>
                <Siar:DataGrid ID="dgSpese" runat="server" AutoGenerateColumns="False" Width="100%"
                    AllowPaging="true" PageSize="10">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="center" Width="25px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Riepilogo">
                            <ItemStyle Width="150px" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Oggetto della spesa" IsJavascript="true"
                            LinkFields="IdSpesa" LinkFormat="caricaSpesa({0});">
                        </Siar:ColonnaLink>
                        <Siar:JsButtonColumn Arguments="IdFile" ButtonType="ImageButton" ButtonImage="/print_ico.gif" ButtonText="Visualizza file" JsFunction="SNCUFVisualizzaFile" HeaderText="File">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                        <asp:BoundColumn HeaderText="Importo lordo">
                            <ItemStyle HorizontalAlign="right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Imponibile" DataFormatString="{0:c}" HeaderText="Importo netto">
                            <ItemStyle HorizontalAlign="right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo richiesto">
                            <ItemStyle HorizontalAlign="right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo ammesso">
                            <ItemStyle HorizontalAlign="right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Riepilogo"></asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdFile" ButtonType="ImageButton" ButtonImage="/print_ico.gif" ButtonText="Visualizza file" JsFunction="SNCUFVisualizzaFile" HeaderText="File">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                        <asp:BoundColumn DataField="Importo" DataFormatString="{0:c}" HeaderText="Importo lordo">
                            <ItemStyle HorizontalAlign="right" Width="90px" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="" ButtonType="ImageButton" ButtonText="Integrazione richiesta"
                            JsFunction="" HeaderText="Integrazione richiesta" ButtonImage="warning.png">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid><table style="width: 100%;">
                    <tr>
                        <td align="right" style="width: 815px; height: 22px;">
                            (
                        </td>
                        <td style="width: 15px; height: 22px;">
                            <img alt="Spesa ammessa" src="../../images/visto.gif" />
                        </td>
                        <td style="height: 22px">
                            = spesa sostenuta <b>visionata</b> ed <b>ammessa</b>)
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table id="tabDettaglio" runat="server" class="tableTab" width="800px">
        <tr>
            <td style="height: 8px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;Dati del giustificativo del fornitore:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width: 340px" valign="top">
                            <table>
                                <tr>
                                    <td>
                                        &nbsp;Numero: &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; Data:<br />
                                        <Siar:TextBox ID="txtNumGiustificativo" runat="server" MaxLength="30" Width="127px" />
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        <Siar:DateTextBox ID="txtDataGiustificativo" runat="server" NomeCampo="Data giustificativo"
                                            Obbligatorio="True" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tipo giustificativo:<br />
                                        <Siar:ComboSql ID="lstTipoGiustificativo" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_SPESA=1"
                                            DataTextField="DESCRIZIONE" DataValueField="COD_TIPO" NomeCampo="Tipo giustificativo"
                                            Obbligatorio="True">
                                        </Siar:ComboSql>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="center">
                            <%-- campi DAS oscurati perchè non utilizzati --%>
                            <table style="border-left: black 0px solid; border-bottom: black 0px solid">
                                <tr>
                                    <td align="left" class="">
                                    <%--<td align="left" class="paragrafo">--%>
                                        &nbsp;<%--Dati del documento di trasporto:--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td style="width: 174px; height: 59px">
                                                    &nbsp;&nbsp; <%--Numero:--%><br />
                                                    &nbsp;&nbsp;<Siar:TextBox ID="txtNumDocTrasporto" runat="server" MaxLength="30" Width="150px" visible="false"/>
                                                </td>
                                                <td style="height: 59px">
                                                    &nbsp;<%--Data:--%><br />
                                                    <Siar:DateTextBox ID="txtDataDocTrasporto" runat="server" Width="100px" Visible="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td>
                            &nbsp;Importo Netto €: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Iva
                            %:<br />
                            <Siar:CurrencyBox ID="txtImportoGiustificativo" runat="server" NomeCampo="Importo giustificativo"
                                Obbligatorio="True" Width="165px" />
                            <Siar:QuotaBox ID="txtIva" runat="server" NomeCampo="Iva" Obbligatorio="True" Width="70px" />
                            &nbsp;&nbsp;
                            <asp:CheckBox ID="chkNonRecuperabile" runat="server" Text="Iva non recuperabile" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;Oggetto della spesa:<br />
                            <Siar:TextArea ID="txtDescGiustificativo" runat="server" NomeCampo="Oggetto della spesa"
                                Obbligatorio="True" Width="578px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 8px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;P.Iva del Fornitore: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            Ragione sociale del Fornitore:<br />
                            <Siar:TextBox ID="txtPivaFornitore" runat="server" NomeCampo="Partita iva del fornitore"
                                Obbligatorio="True" Width="190px" />
                            &nbsp; &nbsp;<Siar:TextBox ID="txtRSFornitore" runat="server" Width="520px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            Specificare il file digitale relativo al giustificativo:<br />
                            <uc3:SNCUploadFileControl ID="ufGiustificativo" runat="server" TipoFile="Documento" />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr id="trIntegrazioneGiustificativo" runat="server" visible="false">
                        <td>
                            <table width="100%">
                                <tr>
                                    <td>
                                        Data richiesta integrazione:<br />
                                        <Siar:DateTextBox ID="txtDataRichiestaGiustificativo" runat="server" Width="120px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Richiedi l'integrazione o la modifica del giustificativo:<br />
                                        <Siar:TextArea ID="txtNoteIntegrazioneGiustificativo" runat="server" NomeCampo="Richiedi l'integrazione o la modifica del giustificativo"
                                            Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                                    </td>
                                    <td align="center" id="tdRichiestaIntegrazioneGiustificativo" runat="server" visible="false">
                                        <img src="../../images/warning.png" alt="Integrazione richiesta" title="Integrazione richiesta" /><br />
                                        Integrazione richiesta
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Siar:Button ID="btnRichiediIntegrazioneGiustificativo" runat="server" Modifica="True"
                                            OnClick="btnRichiediIntegrazioneGiustificativo_Click" Text="Richiedi integrazione giustificativo"
                                            Width="220px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;Estremi del pagamento effettuato:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<table width="100%">
                    <tr>
                        <td>
                            &nbsp;Tipo pagamento:<br />
                            <Siar:ComboSql ID="lstPagamento" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_PAGAMENTO=1"
                                DataTextField="DESCRIZIONE" DataValueField="COD_TIPO" NomeCampo="Tipo pagamento"
                                Obbligatorio="True">
                            </Siar:ComboSql>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;Importo Lordo €: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            Importo Netto €:<br />
                            <Siar:CurrencyBox ID="txtImportoLordoPagamento" runat="server" NomeCampo="Importo lordo del pagamento"
                                Obbligatorio="True" Width="165px" />
                            &nbsp;&nbsp; &nbsp;<Siar:CurrencyBox ID="txtImportoNettoPagamento" runat="server"
                                NomeCampo="Importo netto del pagamento" Obbligatorio="True" Width="165px" />
                            <span id="spErroreImporti" style="display: none; color: red">#</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;Data: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            Estremi:<br />
                            <Siar:DateTextBox ID="txtDataPagamento" runat="server" NomeCampo="Data pagamento"
                                Obbligatorio="True" Width="100px" />
                            <Siar:TextBox ID="txtEstremi" runat="server" NomeCampo="Estremi del pagamento" Obbligatorio="True"
                                Width="488px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            Specificare il file digitale relativo al pagamento:<br />
                            <uc3:SNCUploadFileControl ID="ufPagamento" runat="server" TipoFile="Documento" />
                        </td>
                    </tr>
                    <tr runat="server" id="CIAO">
                        <td>
                            <div class="mrw-table" ID="trFileSpesaSostenuta" runat="server" visible="false" >
                                <div class="mrw-tr">
                                    <div class="mrw-width-100">
                                        <div class="paragrafo" style="width:300px">Ulteriori file digitali a sostegno del pagamento</div>
                                    </div>
                                </div>
                                <div class="mrw-tr">
                                    <div class="mrw-width-100">
                                        <Siar:DataGrid ID="dgFileSpeseSostenute" runat="server" AutoGenerateColumns="false" Visible="true" AllowPaging="true" PageSize="20" Width="90%" >
                                            <Columns>
                                                <Siar:ColonnaLink DataField="IdFileSpeseSostenute" HeaderText="Id." IsJavascript="true"
                                                                  LinkFields="IdFileSpeseSostenute" LinkFormat="selezionaFileSpese({0});">
                                                    <ItemStyle HorizontalAlign="Center"/>
                                                </Siar:ColonnaLink>
                                                <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="NomeFile" HeaderText="Nome file">
                                                </asp:BoundColumn>
                                                <Siar:JsButtonColumn Arguments="IdFile" ButtonType="TextButton" ButtonText="Visualizza" JsFunction="SNCUFVisualizzaFile">
                                                    <ItemStyle Width="90px" HorizontalAlign="Center" />
                                                </Siar:JsButtonColumn>
                                            </Columns>
                                        </Siar:DataGrid>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr id="trIntegrazioneSpesa" runat="server" visible="false">
                        <td>
                            <table width="100%">
                                <tr>
                                    <td>
                                        Data richiesta integrazione:<br />
                                        <Siar:DateTextBox ID="txtDataRichiestaSpesa" runat="server" Width="120px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Richiedi l'integrazione o la modifica del pagamento:<br />
                                        <Siar:TextArea ID="txtNoteIntegrazioneSpesa" runat="server" NomeCampo="Richiedi l'integrazione o la modifica del pagamento"
                                            Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                                    </td>
                                    <td align="center" id="tdRichiestaIntegrazionePagamento" runat="server" visible="false">
                                        <img src="../../images/warning.png" alt="Integrazione richiesta" title="Integrazione richiesta" /><br />
                                        Integrazione richiesta
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Siar:Button ID="btnRichiediIntegrazioneSpesa" runat="server" Modifica="True" OnClick="btnRichiediIntegrazioneSpesa_Click"
                                            Text="Richiedi integrazione pagamento" Width="200px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 62px">
                <Siar:Button ID="btnSalva" runat="server" CausesValidation="True" Modifica="True"
                    OnClick="btnSalva_Click" OnClientClick="return validaImporti(false, event);"
                    Text="Salva" Width="190px" />
                <Siar:Button ID="btnIndietro" runat="server" CausesValidation="True" 
                    OnClick="btnIndietro_Click"  Text="Indietro" Width="190px" />
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
                            LinkFields="IdInvestimento" LinkFormat="IstruttoriaInvestimento.aspx?idinv={0}" > 
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
</asp:Content>
