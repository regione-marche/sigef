<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IstruttoriaSpeseSostenute" CodeBehind="IstruttoriaSpeseSostenute.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento"
    TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTabAgid" TagPrefix="uc1" %>
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
    <div style="display: none">
        <asp:Button ID="btnModifica" runat="server" CausesValidation="False" OnClick="btnModifica_Click" />
        <asp:Button ID="btnPost" CausesValidation="false" runat="server" OnClick="btnPost_Click" />
        <input type="hidden" id="hdnIdSpesaSostenuta" runat="server" />
        <asp:HiddenField ID="hdnIdFileSpesaSostenuta" runat="server" />
    </div>
    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <div class="row">
        <div class="col-sm-12 text-end mt-5">
            <a id="btnBack" runat="server" class="btn btn-secondary py-1" onclick="location = 'CheckListPagamento.aspx'">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna alla checklist di pagamento</a>
        </div>
    </div>
    <uc1:SiarNewTabAgid ID="ucSiarNewTab" runat="server" TabNames="Istruttoria spese sostenute|Dettaglio spesa" />
    <div id="tabElenco" runat="server" class="row tableTab p-5">
        <p>
            - In questa pagina vengono elencate tutte le spese sostenute dal beneficiario per le quali si richiede il pagamento. corredate dal rispettivo giustificativo del fornitore. Per l'eventuale modifica dei dati usare il link apposito.
        </p>
        <div class="col-sm-12 text-start mb-3">
            <input id="btnStampa" runat="server" class="btn btn-secondary py-1" type="button" value="Esporta in excel" />
        </div>
        <p>
            Elementi trovati:
            <asp:Label ID="lblNrRecord" runat="server"></asp:Label>
        </p>
        <div class="row bd-form pt-5 mb-5">
            <div class="col-sm-2 form-group">
                <Siar:TextBox  Label="Numero:" ID="txtFiltroNumero" runat="server" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:DateTextBox Label="Data:" ID="txtFiltroData" runat="server" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:ComboSql Label="Tipo giustificativo:" ID="lstFiltroTipoGiustificativo" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_SPESA=1"
                    DataTextField="DESCRIZIONE" DataValueField="COD_TIPO">
                </Siar:ComboSql>
            </div>
            <div class="col-sm-2 form-group">
                <Siar:TextBox  Label="Oggetto della spesa:" ID="txtFiltroOggetto" runat="server" Width="230px" />
            </div>
            <div class="col-sm-2 form-check">
                <asp:CheckBox ID="ckInintegrazione" runat="server" Text="In integrazione" />
            </div>
            <div class="col-sm-2">
                <Siar:Button ID="btnCerca" runat="server" Text="Filtra" OnClick="btnCerca_Click" />
            </div>
        </div>
        <div>
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgSpese" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="10">
                <Columns>
                    <Siar:NumberColumnAgid HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:NumberColumnAgid>
                    <asp:BoundColumn HeaderText="Riepilogo">
                        <ItemStyle Width="150px" />
                    </asp:BoundColumn>
                    <Siar:ColonnaLinkAgid DataField="Descrizione" HeaderText="Oggetto della spesa" IsJavascript="true"
                        LinkFields="IdSpesa" LinkFormat="caricaSpesa({0});">
                    </Siar:ColonnaLinkAgid>
                    <Siar:JsButtonColumnAgid Arguments="IdFile" ButtonType="ImageButton" ButtonImage="it-print" ButtonText="Visualizza file" JsFunction="SNCUFVisualizzaFile" HeaderText="File">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumnAgid>
                    <asp:BoundColumn HeaderText="Importo lordo">
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Imponibile" DataFormatString="{0:c}" HeaderText="Importo netto">
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Importo richiesto">
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Importo ammesso">
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Riepilogo"></asp:BoundColumn>
                    <Siar:JsButtonColumnAgid Arguments="IdFile" ButtonType="ImageButton" ButtonImage="it-print" ButtonText="Visualizza file" JsFunction="SNCUFVisualizzaFile" HeaderText="File">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumnAgid>
                    <asp:BoundColumn DataField="Importo" DataFormatString="{0:c}" HeaderText="Importo lordo">
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumnAgid Arguments="" ButtonType="ImageButton" ButtonText="Integrazione richiesta"
                        JsFunction="" HeaderText="Integrazione richiesta" ButtonImage="it-warning-circle">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="col-sm-12 text-start">
            <p>
                (<svg class="icon icon-breadcrumb icon-secondary me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                = spesa sostenuta <b>visionata</b> ed <b>ammessa</b>)                
            </p>
        </div>
    </div>
    <div id="tabDettaglio" runat="server" class="row bd-form tableTab p-5">
        <h3 class="pb-5">Dati del giustificativo del fornitore:</h3>
        <div class="form-group col-sm-6">
            <Siar:TextBox  Label="Numero:" ID="txtNumGiustificativo" runat="server" MaxLength="30" />
        </div>
        <div class="form-group col-sm-6">
            <Siar:DateTextBox Label="Data:" ID="txtDataGiustificativo" runat="server" NomeCampo="Data giustificativo" Obbligatorio="True" />
        </div>
        <div class="form-group col-sm-12">
            <Siar:ComboSql Label="Tipo giustificativo:" ID="lstTipoGiustificativo" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_SPESA=1"
                DataTextField="DESCRIZIONE" DataValueField="COD_TIPO" NomeCampo="Tipo giustificativo"
                Obbligatorio="True">
            </Siar:ComboSql>
        </div>
        <div class="form-group col-sm-6" style="display: none;">
            <Siar:TextBox  ID="txtNumDocTrasporto" runat="server" MaxLength="30" Visible="false" />
        </div>
        <div class="form-group col-sm-6" style="display: none;">
            <Siar:DateTextBox ID="txtDataDocTrasporto" runat="server" Visible="false" />
        </div>
        <div class="form-group col-sm-4">
            <Siar:CurrencyBox Label="Importo Netto €:" ID="txtImportoGiustificativo" runat="server" NomeCampo="Importo giustificativo" Obbligatorio="True" />
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
        <div class="col-sm-6 form-group">
            <Siar:TextBox  Label="P.Iva del Fornitore:" ID="txtPivaFornitore" runat="server" NomeCampo="Partita iva del fornitore"
                Obbligatorio="True" />
        </div>
        <div class="col-sm-6 form-group">
            <Siar:TextBox  Label="Ragione sociale del Fornitore:" ID="txtRSFornitore" runat="server" />
        </div>
        <h4>Specificare il file digitale relativo al giustificativo:</h4>
        <div class="col-sm-12">
            <uc3:SNCUploadFileControl ID="ufGiustificativo" runat="server" TipoFile="Documento" />
        </div>
        <div class="row" id="trIntegrazioneGiustificativo" runat="server" visible="false">
            <div class="form-group col-sm-2">
                <Siar:DateTextBox Label="Data richiesta integrazione:" ID="txtDataRichiestaGiustificativo" runat="server" Width="120px" />
            </div>
            <div id="tdRichiestaIntegrazioneGiustificativo" runat="server" visible="false" class="text-center col-sm-10">
                <img src="../../images/warning.png" alt="Integrazione richiesta" title="Integrazione richiesta" />
                Integrazione richiesta                                    
            </div>
            <div class="form-group col-sm-12">
                <Siar:TextArea Label="Richiedi l'integrazione o la modifica del giustificativo:" ID="txtNoteIntegrazioneGiustificativo" runat="server" NomeCampo="Richiedi l'integrazione o la modifica del giustificativo"
                    Obbligatorio="false" Rows="4" ExpandableRows="5" MaxLength="10000" />
            </div>
            <div class="form-group col-sm-12 text-start">
                <Siar:Button ID="btnRichiediIntegrazioneGiustificativo" runat="server" Modifica="True"
                    OnClick="btnRichiediIntegrazioneGiustificativo_Click" Text="Richiedi integrazione giustificativo" />
            </div>
        </div>
        <h3 class="pb-5">Estremi del pagamento effettuato:
        </h3>
        <div class="col-sm-12 form-group">
            <Siar:ComboSql Label="Tipo pagamento:" ID="lstPagamento" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_PAGAMENTO=1"
                DataTextField="DESCRIZIONE" DataValueField="COD_TIPO" NomeCampo="Tipo pagamento"
                Obbligatorio="True">
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
            <Siar:CurrencyBox Label="Importo Netto €:" ID="txtImportoNettoPagamento" runat="server"
                NomeCampo="Importo netto del pagamento" Obbligatorio="True" />
            <span id="spErroreImporti" style="display: none; color: red">#</span>
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextBox  Label="Estremi:" ID="txtEstremi" runat="server" NomeCampo="Estremi del pagamento" Obbligatorio="True" />
        </div>
        <div class="col-sm-12 form-group" id="tdRichiestaIntegrazionePagamento" runat="server" visible="false">
            <img src="../../images/warning.png" alt="Richiesta integrazione" title="Richiesta integrazione" />
            <p>Richiesta integrazione</p>
        </div>
        <h4>Specificare il file digitale relativo al pagamento:</h4>
        <div class="col-sm-12">
            <uc3:SNCUploadFileControl ID="ufPagamento" runat="server" TipoFile="Documento" />
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
                        <Siar:DataGridAgid CssClass="table table-striped" ID="dgFileSpeseSostenute" runat="server" AutoGenerateColumns="false" Visible="true" AllowPaging="true" PageSize="20">
                            <Columns>
                                <Siar:ColonnaLink DataField="IdFileSpeseSostenute" HeaderText="Id." IsJavascript="true"
                                    LinkFields="IdFileSpeseSostenute" LinkFormat="selezionaFileSpese({0});">
                                    <ItemStyle HorizontalAlign="Center" />
                                </Siar:ColonnaLink>
                                <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                <asp:BoundColumn DataField="NomeFile" HeaderText="Nome file"></asp:BoundColumn>
                                <Siar:JsButtonColumnAgid Arguments="IdFile" ButtonType="TextButton" ButtonText="Visualizza" JsFunction="SNCUFVisualizzaFile">
                                    <ItemStyle HorizontalAlign="Center" />
                                </Siar:JsButtonColumnAgid>
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                </div>
            </div>
        </div>
        <div class="row" id="trIntegrazioneSpesa" runat="server" visible="false">
            <div class="form-group col-sm-2">
                <Siar:DateTextBox Label="Data richiesta integrazione:" ID="txtDataRichiestaSpesa" runat="server" />
            </div>
            <div id="Div1" runat="server" visible="false" class="text-center col-sm-10">
                <img src="../../images/warning.png" alt="Integrazione richiesta" title="Integrazione richiesta" />Integrazione richiesta                           
            </div>
            <div class="form-group col-sm-12">
                <Siar:TextArea Label="Richiedi l'integrazione o la modifica del pagamento:" ID="txtNoteIntegrazioneSpesa" runat="server" NomeCampo="Richiedi l'integrazione o la modifica del pagamento"
                    Obbligatorio="false" Rows="4" ExpandableRows="5" MaxLength="10000" />
            </div>
            <div class="form-group col-sm-12 text-start">
                <Siar:Button ID="btnRichiediIntegrazioneSpesa" runat="server" Modifica="True" OnClick="btnRichiediIntegrazioneSpesa_Click"
                    Text="Richiedi integrazione pagamento" />
            </div>
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalva" runat="server" CausesValidation="True" Modifica="True"
                OnClick="btnSalva_Click" OnClientClick="return validaImporti(false, event);"
                Text="Salva" />
            <Siar:Button ID="btnIndietro" runat="server" Visible="false" CausesValidation="True"
                OnClick="btnIndietro_Click" Text="Indietro" />
        </div>
    </div>
    <div class="row" id="divElencoPianoInv" runat="server" visible="false">
        <h3 class="pb-5 mt-5">Associazione del giustificativo al piano investimenti:</h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgInvestimenti" runat="server" ShowFooter="false" AutoGenerateColumns="False" PageSize="20">
                <Columns>
                    <asp:BoundColumn HeaderText="Descrizione">
                        <ItemStyle HorizontalAlign="left" />
                    </asp:BoundColumn>
                    <Siar:ColonnaLink HeaderText="Costo totale investimento" DataField="CostoInvestimento" DataFormatString="{0:c}" IsJavascript="false"
                        LinkFields="IdInvestimento" LinkFormat="IstruttoriaInvestimento.aspx?idinv={0}">
                        <ItemStyle HorizontalAlign="right" />
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
    <div class="row">
        <div class="col-sm-12 text-end mt-5">
            <a id="btnBackDown" runat="server" class="btn btn-secondary py-1" onclick="location = 'CheckListPagamento.aspx'">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna alla checklist di pagamento</a>
        </div>
    </div>
</asp:Content>
