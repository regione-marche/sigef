<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImpresaControl.ascx.cs"
    Inherits="web.CONTROLS.ImpresaControl" %>
<%@ Register Src="SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc2" %>
<%@ Register Src="SNCComuniControl.ascx" TagName="SNCComuniControl" TagPrefix="uc3" %>

<script type="text/javascript">
    function ICtrlControlloIban() { //IT34X0335901600100000001210
        var iban = $('[id$=txtCodiceIntero]').val().replace(/\s/g, ''); $('[id$=txtCodiceIntero]').val(iban);
        if (ctrlIBAN(iban)) {
            $('[id$=txtCodPaese_text]').val(iban.substr(0, 2)); $('[id$=txtCINeuro_text]').val(iban.substr(2, 2));
            $('[id$=txtCin_text]').val(iban.substr(4, 1)); $('[id$=txtABI_text]').val(iban.substr(5, 5));
            $('[id$=txtCAB_text]').val(iban.substr(10, 5)); $('[id$=txtNumeroConto_text]').val(iban.substr(15));
            $('#imgOk').attr('src', getBaseUrl() + 'images/visto.gif').show(); ICtrlRecuperoDatiBanca(iban.substr(5, 5), iban.substr(10, 5));
        } else ICtrlPulisciCampiNumeroCC();
    }
    function ICtrlPulisciCampiNumeroCC() {
        $('[id$=txtCodPaese_text]').val(''); $('[id$=txtCINeuro_text]').val(''); $('[id$=txtCin_text]').val('');
        $('[id$=txtABI_text]').val(''); $('[id$=txtCAB_text]').val(''); $('[id$=txtNumeroConto_text]').val(''); $('#imgOk').hide();
    }
    function ICtrlNuovoConto() {
        ICtrlPulisciCampiNumeroCC(); $('[id$=txtCodiceIntero]').val(''); $('[id$=txtIstituto_text]').val(''); $('[id$=txtAgenzia_text]').val('');
        $('[id$=txtSNCZCCap_text]').val(''); $('[id$=txtSNCZCProvincia_text]').val(''); $('[id$=txtSNCZCDenominazione_text]').val('');
        $('[id$=txtSNCZCDenominazione_text]').attr('disabled', '');
    }
    function ICtrlControlloDatiCC(ev) {
        if (($('[id$=txtNumeroConto_text]').val() + $('[id$=txtIstituto_text]').val() + $('[id$=txtAgenzia_text]').val() + $('[id$=txtSNCZCProvincia_text]').val()).length > 0 &&
            ($('[id$=txtNumeroConto_text]').val() == '' || $('[id$=txtIstituto_text]').val() == '' || $('[id$=txtAgenzia_text]').val() == '' ||
                $('[id$=txtSNCZCProvincia_text]').val() == '')) { alert('Digitare tutti i campi che specificano il conto corrente.'); return stopEvent(ev); }
    }
    function ICtrlRecuperoDatiBanca(cod_abi, cod_cab) {
        $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', { "type": "ICtrlRecuperoDatiBanca", "cabi": cod_abi, "ccab": cod_cab },
            function (msg) {
                if (Number(msg.RisultatoEsecuzione) == 0) {
                    try {
                        var banca = eval('(' + msg.Html + ')'); if (banca.abi != '') $('[id$=txtIstituto_text]').val(banca.Istituto); if (banca.cab != '') $('[id$=txtAgenzia_text]').val(banca.Agenzia);
                        if (banca.IdComune) {
                            $('[id$=txtSNCZCDenominazione_text]').attr('disabled', 'disabled');
                            $('[id$=hdnSNCZCIdComune]').val(banca.IdComune); $('[id$=txtSNCZCDenominazione_text]').val(banca.Comune);
                            $('[id$=txtSNCZCProvincia_text]').val(banca.Provincia); $('[id$=txtSNCZCCap_text]').val(banca.Cap);
                        }
                    } catch (exc) { }
                }
                else alert(msg.MessaggioEsecuzione);
            }, "json");
    }

    function copiaIbanInRam() {
        var iban = $('[id$=hdnIbanImpresa]').val();

        if (window.clipboardData && clipboardData.setData)
            clipboardData.setData("Text", iban);
        else {
            try {
                var textField = document.createElement('textarea');
                textField.value = iban;
                textField.innerText = iban;
                document.body.appendChild(textField);
                textField.select();
                document.execCommand('copy');
                textField.remove();
            }
            catch (err) {
                alert('Attenzione!\nIl browser che si sta utilizzando non supporta questa funzionalità.');
            }
        }

        /*alert('Iban copiato: ' + iban);*/
        return false;
    }

    $(document).ready(function () {
        $()
        var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
        var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl)
        })
    });    
</script>

<div class="row py-2 bd-form" id="tableImpresaControl" runat="server">
    <div style="display: none">
        <asp:HiddenField ID="hdnIbanImpresa" Value="" runat="server" />
    </div>

    <div class="paragrafo_bold mx-2">Generalità del beneficiario</div>

    <div class="row  pt-5">
        <div class="form-group col-sm-2">
            <Siar:TextBox Label="Codice Fiscale" ID="txtCuaa" runat="server" ReadOnly="True" TextAlign="right" />
        </div>
        <div class="form-group col-sm-2">
            <Siar:TextBox Label="P.Iva" ID="txtPiva" runat="server" ReadOnly="True" TextAlign="right" />
        </div>
        <div class="form-group col-sm-2">            
            <Siar:DateTextBoxAgid Label="Data inizio attività" ID="txtDataInizioAttivita"  runat="server" ReadOnly="True" />
        </div>
        <div class="form-group col-sm-6">
            <Siar:TextBox Label="Ragione sociale" ID="txtRagioneSociale" runat="server" ReadOnly="True" />
        </div>
        <div class="form-group col-sm-6">
            <Siar:ComboFormaGiuridica Label="Forma giuridica" ID="lstFormaGiuridica" runat="server" NoBlankItem="true"
                NomeCampo="Forma Giuridica">
            </Siar:ComboFormaGiuridica>
            <asp:RequiredFieldValidator ID="rfvFormaGiuridica" CssClass="form-feedback" runat="server" ControlToValidate="lstFormaGiuridica"
                ErrorMessage="Forma giuridica" ValidationGroup="vgAnagraficaImpresa"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-sm-6">
            <Siar:Combo Label="Codice ATECO" runat="server" ID="ComboAteco">
            </Siar:Combo>
        </div>
    </div>

    <div id="trImpresaTit" class="paragrafo_bold  mx-2" runat="server">Per beneficiari di tipo impresa</div>
    <div id="trImpresaDim" runat="server" class="row  py-5">
        <div class="col-sm-2">
            <Siar:ComboDimensioneImpresa Label="Dimensione impresa" ID="lstDimensione" runat="server" NomeCampo="Dimensione Impresa"></Siar:ComboDimensioneImpresa>
            <asp:RequiredFieldValidator ID="rfvDimensioneImpresa" CssClass="form-feedback" runat="server" ControlToValidate="lstDimensione"
                ErrorMessage="Dimensione impresa" ValidationGroup="vgAnagraficaImpresa"></asp:RequiredFieldValidator>
        </div>
        <%--<uc2:SiarNewToolTip ID="ucSiarNewToolTip" runat="server" Codice="legenda_dimensioneimpresa" />--%>
        <div class="col-sm-2 pt-2">
            <a data-bs-toggle="tooltip" data-bs-html="true" title="<h5>Dimensione aziendale</h5><p>Descrive la dimensione aziendale secondo la classificazione di cui al Reg. 1698/05 e alla Raccomandazione 2003/361/CE.</p><ul><li><span><strong>Grandi Imprese:</strong> numero degli addetti superiore a 750 persone, fatturato annuo maggiore di 200 milioni di euro;</span></li><li><span><strong>Imprese Semigrandi:</strong> numero degli addetti compreso tra 250 e 750 persone, fatturato annuo minore ai 200 milioni di euro;</span></li><li><span><strong>Medie Imprese:</strong> numero addetti compreso tra 50 e 249 persone, soglia relativa al fatturato di 50 milioni di euro e quella relativa al totale di bilancio di 43 milioni di euro;</span></li><li><span><strong>Piccole imprese:</strong>addetti compreso tra 10 e 49 persone, soglia relativa al fatturato e al totale di bilancio di 10 milioni di euro;</span></li><li><span><strong>Microimprese:</strong>addetti comprendenti meno di 10 persone, soglia relativa al fatturato e al totale di bilancio di 2 milioni di euro.</span></li></ul>">
                <svg class="icon">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-info-circle"></use></svg>
            </a>
        </div>
    </div>
    <div class="row pt-4" id="trImpresaRea" runat="server">
        <div class="form-group col-sm-4">
            <Siar:TextBox Label="Nr. Registro Imprese" ID="txtNumeroRegistroImprese" runat="server" ReadOnly="True" MaxLength="16"
                NomeCampo="Numero registro imprese" TextAlign="right" />
        </div>
        <div class="form-group col-sm-4">
            <Siar:TextBox Label="Nr. REA" ID="txtNumeroRea" runat="server" MaxLength="7" ReadOnly="True" NomeCampo="Numero REA" TextAlign="right" />
        </div>
        <div class="form-group col-sm-4">
            <Siar:IntegerTextBox Label="Anno di iscrizione REA" ID="txtAnnoRea" runat="server" ReadOnly="True" MaxLength="4" NoCurrency="True"
                NomeCampo="Anno di iscrizione REA" />
            <asp:RangeValidator ID="rvAnnoRea" runat="server" CssClass="form-feedback" ControlToValidate="txtAnnoRea"
                ErrorMessage="Anno di iscrizione rea non valido" MaximumValue="2050" MinimumValue="1900"
                ValidationGroup="vgAnagraficaImpresa"></asp:RangeValidator>
        </div>
    </div>

    <div class="paragrafo_bold mx-2">Sede legale</div>
    <div class="row  pt-5" runat="server">
        <div class="form-group col-sm-4">
            <Siar:TextBox Label="Indirizzo" ID="txtSLIndirizzo" runat="server" ReadOnly="True" />
        </div>
        <div class="form-group col-sm-4">
            <Siar:TextBox Label="Comune" ID="txtSLComune" runat="server" ReadOnly="True" />
            <asp:HiddenField ID="IdSLComuneHide" runat="server" />
        </div>
        <div class="form-group col-sm-2">
            <Siar:TextBox Label="Provincia" ID="txtSLProvincia" runat="server" ReadOnly="True" TextAlign="right" />
        </div>
        <div class="form-group col-sm-2">
            <Siar:TextBox Label="Cap" ID="txtSLCap" runat="server" ReadOnly="True" TextAlign="right" />
        </div>
        <div class="form-group col-sm-4">
            <Siar:TextBox Label="Telefono" ID="txtSLTelefono" runat="server" />
            <asp:RequiredFieldValidator CssClass="form-feedback" ID="rfvSLTelefono" runat="server" ControlToValidate="txtSLTelefono"
                ErrorMessage="Telefono sede legale" ValidationGroup="vgAnagraficaImpresa"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-sm-4">
            <Siar:TextBox Label="E-mail" ID="txtSLEmail" runat="server" />
            <asp:RequiredFieldValidator ID="rfvSLEmail" CssClass="form-feedback" runat="server" ControlToValidate="txtSLEmail"
                ErrorMessage="Email sede legale" ValidationGroup="vgAnagraficaImpresa"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                    ID="txtEmailReg" CssClass="form-feedback" runat="server" ErrorMessage="Indirizzo e-mail non corretto"
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtSLEmail"
                    ValidationGroup="vgAnagraficaImpresa"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group col-sm-4">
            <Siar:TextBox Label="Pec" ID="txtSLPec" runat="server" />
            <asp:RequiredFieldValidator CssClass="form-feedback" ID="rfvSLPec" runat="server" ControlToValidate="txtSLPec"
                ErrorMessage="PEC" ValidationGroup="vgAnagraficaImpresa"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="txtPecReg" runat="server" CssClass="form-feedback" ErrorMessage="Indirizzo pec non corretto"
                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtSLPec"
                ValidationGroup="vgAnagraficaImpresa"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group col-sm-4">
            <div id="trPecUfficio" runat="server" visible="false" class="form-group col-sm-12">
                <p>Per i progetti presentati da enti pubblici è possibile inserire un'ulteriore indirizzo di PEC relativo all'ufficio dell'ente che gestisce il progetto per poter ricevere le comunicazioni da parte della Regione Marche.</p>
                <Siar:TextBox Label="Pec Ufficio Referente" ID="txtPecUfficio" runat="server" />
                <asp:RegularExpressionValidator CssClass="form-feedback" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Indirizzo pec non corretto"
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtPecUfficio"
                    ValidationGroup="vgAnagraficaImpresa"></asp:RegularExpressionValidator>
            </div>
        </div>
    </div>

   
    <div class="paragrafo_bold mx-2">Rappresentante legale CUP</div>
     
    <div class="row pt-5">
        <div class="form-group col-sm-3">
            <Siar:TextBox Label="Nome" ID="txtRLNome" runat="server" ReadOnly="True" />
        </div>
        <div class="form-group col-sm-3">
            <Siar:TextBox Label="Cognome" ID="txtRLCognome" runat="server" ReadOnly="True" />
        </div>
        <div class="form-group col-sm-3">
            <Siar:TextBox Label="Codice Fiscale" ID="txtRLCFiscale" runat="server" ReadOnly="True" />
        </div>
        <div class="form-group col-sm-3">
            <Siar:DateTextBoxAgid Label="Data di nascita" ID="txtRLDataNascita" runat="server" />
        </div>
    </div>
    
    <div class="row  py-3">
        <div class="form-group col-sm-4">
            <Siar:TextBox Label="Comune di nascita" ID="txtRLComuneNascita" runat="server" ReadOnly="True" />
            <asp:HiddenField ID="IdRLComuneNascitaHide" runat="server" />
        </div>
        <div class="form-group col-sm-4">
            <Siar:TextBox Label="Provincia" ID="txtRLProvinciaNascita" runat="server" ReadOnly="True" />
        </div>
        <div class="form-group col-sm-4">
            <Siar:TextBox Label="Cap" ID="txtRLCapNascita" runat="server" ReadOnly="True" />
        </div>
    </div>

    <div class="paragrafo_bold mx-2">Residenza</div>
    <div class="row  pt-5">
        <div class="form-group col-sm-3">
            <Siar:TextBox Label="Indirizzo" ID="txtRLIndirizzoResidenza" runat="server" ReadOnly="True" />
        </div>
        <div class="form-group col-sm-3">
            <Siar:TextBox Label="Comune" ID="txtRLComuneResidenza" runat="server" ReadOnly="True" />
            <asp:HiddenField ID="IdRLComuneResidenzaHide" runat="server" />
        </div>
        <div class="form-group col-sm-3">
            <Siar:TextBox Label="Provincia" ID="txtRLProvinciaResidenza" runat="server" ReadOnly="True" />
        </div>
        <div class="form-group col-sm-3">
            <Siar:TextBox ID="txtRLCapResidenza" runat="server" ReadOnly="True" Label="Cap" />
        </div>
    </div>

    <div id="trCC1" runat="server" class="paragrafo_bold mx-2">Conto corrente</div>
    <div class="row  px-2 pt-5" id="trCC2" runat="server">
        <div class="form-group col-sm-3">
            <Siar:TextBox Label="IBAN" ID="txtCodiceIntero" runat="server" NomeCampo="IBAN" />
        </div>
        <div class="col-sm-4 pb-5">
            <input class="btn btn-secondary py-1" onclick="ICtrlControlloIban()" type="button" value="controllo codice IBAN" />
            <input id="btnNuovo" class="btn btn-secondary py-1" onclick="ICtrlNuovoConto()" type="button" value="nuovo conto" />
        </div>
    </div>

    <div class="paragrafo_bold mx-2">Cod.</div>
    <div class="row  pt-5">
        <div class="form-group col-sm-1">
            <Siar:TextBox Label="Paese" ID="txtCodPaese" runat="server" MaxLength="2" ReadOnly="True" />
        </div>
        <div class="form-group col-sm-1">
            <Siar:TextBox Label="CIN Euro" ID="txtCINeuro" runat="server" MaxLength="2" ReadOnly="True" />
        </div>
        <div class="form-group col-sm-1">
            <Siar:TextBox Label="CIN" ID="txtCin" runat="server" MaxLength="1" ReadOnly="True" />
        </div>
        <div class="form-group col-sm-1">
            <Siar:TextBox Label="ABI" ID="txtABI" runat="server" MaxLength="5" NomeCampo="ABI" ReadOnly="True" />
        </div>
        <div class="form-group col-sm-1">
            <Siar:TextBox Label="CAB" ID="txtCAB" runat="server" MaxLength="5" NomeCampo="CAB" ReadOnly="True" />
        </div>
        <div class="form-group col-sm-3">
            <Siar:TextBox Label="Numero Conto" ID="txtNumeroConto" runat="server" MaxLength="20" ReadOnly="True" />
        </div>
        <div class="col-sm-2 pb-5 ">
            <Siar:Button runat="server" ID="btnCopiaIban" CssClass="btn btn-primary" Text="Copia IBAN" OnClientClick="return copiaIbanInRam();" />
        </div>
    </div>

    <div class="row  py-3">
        <div class="form-group col-sm-4">
            <Siar:TextBox Label="Istituto" ID="txtIstituto" runat="server" ReadOnly="true" />
        </div>
        <div class="form-group col-sm-4">
            <Siar:TextBox Label="Agenzia" ID="txtAgenzia" runat="server" ReadOnly="true" />
        </div>
        <div class="form-group col-sm-6">
            <uc3:SNCComuniControl ID="ucSiarNewComuniControl" runat="server" ReadOnly="true" />
        </div>

        <div class="row  py-3">
            <div class="col-sm-12">
                <asp:ValidationSummary ID="vsValidazioneImpresa" runat="server" HeaderText="Attenzione! E` obbligatorio specificare i seguenti dati:"
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="ValidazioneImpresa" />
                <Siar:Button ID="btnScaricaAT" Visible="false" runat="server" Modifica="False" OnClick="btnScaricaAT_Click"
                    Text="Aggiorna dati da Anagrafe Tributaria" CausesValidation="False" />
                <Siar:Button ID="btnUltimaVisura" runat="server"
                    Visible="false"
                    Text="Mostra visura più recente" />
                <%--<Siar:Button ID="btnSalva" runat="server" Modifica="False" OnClick="btnSalva_Click"
                Text="Salva" ValidationGroup="vgAnagraficaImpresa" Width="160px" />
            <Siar:Button ID="btnSalvaIstruttoria" runat="server" Visible="false" Modifica="False" OnClick="btnSalvaIstruttoria_Click"
                Text="Salva e accetta visura" ValidationGroup="vgAnagraficaImpresa" Width="180px" />
            <Siar:Button ID="btnSalvaConDichiarazione" runat="server" Visible="false" Modifica="False" OnClick="btnSalvaConDichiarazione_Click"
                Text="Salva e accetta dichiarazione" ValidationGroup="vgAnagraficaImpresaPresentazione" Width="180px" />--%>
                <Siar:Button ID="btnSalva" runat="server" Modifica="False" OnClick="btnSalva_Click"
                    Text="Salva" CausesValidation="true" ValidationGroup="ValidazioneImpresa" />
                <Siar:Button ID="btnSalvaIstruttoria" runat="server" Visible="false" Modifica="False" OnClick="btnSalvaIstruttoria_Click"
                    Text="Salva e accetta visura" CausesValidation="true" ValidationGroup="ValidazioneImpresa" />
                <Siar:Button ID="btnSalvaConDichiarazione" runat="server" Visible="false" Modifica="False" OnClick="btnSalvaConDichiarazione_Click"
                    Text="Salva e accetta dichiarazione" CausesValidation="true" ValidationGroup="ValidazioneImpresa" />
            </div>
        </div>
    </div>
</div>

