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
            function(msg) {
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

</script>

<div style="display: none">
    <asp:HiddenField ID="hdnIbanImpresa" Value="" runat="server" />
</div>

<table id="tableImpresaControl" runat="server" width="100%">
    <tr>
        <td class="paragrafo">
            <br />
            &nbsp; Generalità del beneficiario:
        </td>
    </tr>
    <tr>
        <td style="padding-left: 10px">
            <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td style="width: 200px">
                                    <br />
                                    &nbsp; Codice Fiscale:<br />
                                    <Siar:TextBox ID="txtCuaa" runat="server" ReadOnly="True" Width="160px" NomeCampo="Codice fiscale" TextAlign="right" />
                                </td>
                                <td style="width: 280px">
                                    <br />
                                    &nbsp; P.Iva:<br />
                                    <Siar:TextBox ID="txtPiva" runat="server" ReadOnly="True" Width="160px" NomeCampo="Partita Iva" TextAlign="right" />
                                </td>
                                <td>
                                    <br />
                                    &nbsp;Data inizio attività:<br />
                                    <Siar:DateTextBox ID="txtDataInizioAttivita" runat="server" ReadOnly="True" NomeCampo="Data inizio attività" Width="120px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        &nbsp; Ragione sociale:<br />
                        <Siar:TextBox ID="txtRagioneSociale" runat="server" ReadOnly="True" NomeCampo="Ragione sociale" Width="600px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        &nbsp; Forma giuridica:<br />
                        <Siar:ComboFormaGiuridica ID="lstFormaGiuridica" runat="server" NoBlankItem="true"
                            NomeCampo="Forma Giuridica">
                        </Siar:ComboFormaGiuridica>
                        <%--<asp:RequiredFieldValidator ID="rfvFormaGiuridica" runat="server" ControlToValidate="lstFormaGiuridica"
                            ErrorMessage="Forma giuridica" ValidationGroup="vgAnagraficaImpresa">*</asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        &nbsp; Codice ATECO:<br />
                        <Siar:Combo runat="server" ID="ComboAteco" NomeCampo="Codice ATECO" Width="700px">
                        </Siar:Combo>
                    </td>
                </tr>
                <tr id="trImpresaTit" runat="server">
                    <td>
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td class="paragrafo">
                                    &nbsp;
                                    <br />
                                    &nbsp;Per beneficiari di tipo impresa:
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trImpresaDim" runat="server">
                    <td>
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td style="width: 200px">
                                    <br />
                                    &nbsp; Dimensione impresa:
                                    <br />
                                    <Siar:ComboDimensioneImpresa ID="lstDimensione" runat="server" NomeCampo="Dimensione Impresa">
                                    </Siar:ComboDimensioneImpresa>
                                    <%--<asp:RequiredFieldValidator ID="rfvDimensioneImpresa" runat="server" ControlToValidate="lstDimensione"
                                        ErrorMessage="Dimensione impresa" ValidationGroup="vgAnagraficaImpresa">*</asp:RequiredFieldValidator>--%>
                                    <uc2:SiarNewToolTip ID="ucSiarNewToolTip" runat="server" Codice="legenda_dimensioneimpresa" />
                                </td>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trImpresaRea" runat="server" >
                    <td>
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td width="200px">
                                    <br />
                                    &nbsp;Nr. Registro Imprese:<br />
                                    <Siar:TextBox ID="txtNumeroRegistroImprese" runat="server" ReadOnly="True" MaxLength="16" Width="160px"
                                        NomeCampo="Numero registro imprese" TextAlign="right" />
                                </td>
                                <td width="200px">
                                    <br />
                                    &nbsp;Nr. REA:<br />
                                    <Siar:TextBox ID="txtNumeroRea" runat="server" MaxLength="7" ReadOnly="True" Width="150px" NomeCampo="Numero REA"
                                        TextAlign="right" />
                                </td>
                                <td>
                                    <br />
                                    &nbsp;Anno di iscrizione REA:<br />
                                    <Siar:IntegerTextBox ID="txtAnnoRea" runat="server" Width="150px" ReadOnly="True" MaxLength="4" NoCurrency="True"
                                        NomeCampo="Anno di iscrizione REA" />
                                    <asp:RangeValidator ID="rvAnnoRea" runat="server" ControlToValidate="txtAnnoRea"
                                        ErrorMessage="Anno di iscrizione rea non valido" MaximumValue="2050" MinimumValue="1900"
                                        ValidationGroup="ValidazioneImpresa">#</asp:RangeValidator>
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
            <br />
            &nbsp;Sede legale:
        </td>
    </tr>
    <tr>
        <td style="padding-left: 10px">
            <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td colspan="2">
                        <br />
                        &nbsp; Indirizzo:<br />
                        <Siar:TextBox ID="txtSLIndirizzo" runat="server" ReadOnly="True" NomeCampo="Indirizzo sede legale" Width="500px" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                        <br />
                        &nbsp; Comune:<br />
                        <Siar:TextBox ID="txtSLComune" runat="server" ReadOnly="True" NomeCampo="Comune sede legale" Width="240px" />
                        <asp:HiddenField ID="IdSLComuneHide" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                        <br />
                        &nbsp; Provincia:
                        <br />
                        <Siar:TextBox ID="txtSLProvincia" runat="server" ReadOnly="True" Width="40px" TextAlign="right" />
                    </td>
                    <td>
                        <br />
                        &nbsp;Cap:<br />
                        <Siar:TextBox ID="txtSLCap" runat="server" ReadOnly="True" Width="80px" TextAlign="right" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 266px">
                        <br />
                        &nbsp;Telefono:<br />
                        <Siar:TextBox ID="txtSLTelefono" runat="server" NomeCampo="Telefono" Width="160px" />
                        &nbsp;
                        <%--<asp:RequiredFieldValidator ID="rfvSLTelefono" runat="server" ControlToValidate="txtSLTelefono"
                            ErrorMessage="Telefono sede legale" ValidationGroup="vgAnagraficaImpresa">*</asp:RequiredFieldValidator>--%>
                    </td>
                    <td style="width: 266px">
                        <br />
                        &nbsp;E-mail:<br />
                        <Siar:TextBox ID="txtSLEmail" runat="server" Width="240px" NomeCampo="Email" />
                        &nbsp;
                        <%--<asp:RequiredFieldValidator ID="rfvSLEmail" runat="server" ControlToValidate="txtSLEmail"
                            ErrorMessage="Email sede legale" ValidationGroup="vgAnagraficaImpresa">*</asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator
                                ID="txtEmailReg" runat="server" ErrorMessage="Indirizzo e-mail non corretto"
                                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtSLEmail"
                                ValidationGroup="ValidazioneImpresa">#</asp:RegularExpressionValidator>
                    </td>
                    <td>
                        &nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
                        &nbsp;Pec:<br />
                        <Siar:TextBox ID="txtSLPec" runat="server" Width="500px" NomeCampo="Pec" />
                        <%--<asp:RequiredFieldValidator ID="rfvSLPec" runat="server" ControlToValidate="txtSLPec"
                            ErrorMessage="PEC" ValidationGroup="vgAnagraficaImpresa">*</asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ID="txtPecReg" runat="server" ErrorMessage="Indirizzo pec non corretto"
                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtSLPec"
                            ValidationGroup="ValidazioneImpresa">#</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trPecUfficio" runat="server" visible ="false">
                    <td colspan="2">
                        <br />
                        Per i progetti presentati da enti pubblici è possibile inserire un'ulteriore indirizzo di PEC relativo all'ufficio dell'ente che gestisce il progetto per poter ricevere le comunicazioni da parte della Regione Marche
                        <br />&nbsp;Pec Ufficio Referente:<br />
                        <Siar:TextBox ID="txtPecUfficio" runat="server" NomeCampo="Pec ufficio referente" Width="500px" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Indirizzo pec non corretto"
                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtPecUfficio"
                            ValidationGroup="ValidazioneImpresa">#</asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="paragrafo">
            <br />
            &nbsp;Rappresentante legale:
        </td>
    </tr>
    <tr>
        <td style="padding-left: 10px">
            <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="width: 266px">
                        <br />
                        &nbsp; Nome:<br />
                        <Siar:TextBox ID="txtRLNome" runat="server" ReadOnly="True" NomeCampo="Nome rappresentante legale" Width="240px" />
                    </td>
                    <td style="width: 266px">
                        <br />
                        &nbsp; Cognome:<br />
                        <Siar:TextBox ID="txtRLCognome" runat="server" ReadOnly="True" NomeCampo="Cognome rappresentante legale" Width="240px" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 266px">
                        <br />
                        &nbsp; Codice Fiscale:<br />
                        <Siar:TextBox ID="txtRLCFiscale" runat="server" ReadOnly="True" NomeCampo="Codice fiscale rappresentante legale" Width="160px" />
                    </td>
                    <td style="width: 266px">
                        <br />
                        &nbsp;Data di nascita:<br />
                        <Siar:DateTextBox ID="txtRLDataNascita" runat="server" ReadOnly="True" NomeCampo="Data di nascita rappresentante legale" Width="120px" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                        <br />
                        &nbsp; Comune di nascita:
                        <br />
                        <Siar:TextBox ID="txtRLComuneNascita" runat="server" ReadOnly="True" NomeCampo="Comune di nascita rappresentante legale" Width="240px" />
                        <asp:HiddenField ID="IdRLComuneNascitaHide" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                        <br />
                        &nbsp; Provincia:
                        <br />
                        <Siar:TextBox ID="txtRLProvinciaNascita" runat="server" ReadOnly="True" Width="40px" TextAlign="right" />
                    </td>
                    <td>
                        <br />
                        &nbsp;Cap:<br />
                        <Siar:TextBox ID="txtRLCapNascita" runat="server" ReadOnly="True" Width="80px" TextAlign="right" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                         &nbsp;
                        <br />
                        &nbsp; <b>Residenza</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
                        &nbsp; Indirizzo:<br />
                        <Siar:TextBox ID="txtRLIndirizzoResidenza" runat="server" ReadOnly="True" NomeCampo="Indirizzo residenza rappresentante legale" Width="500px" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
				<tr>
                    <td>
                        &nbsp;
                        <br />
                        &nbsp; Comune:
                        <br />
                        <Siar:TextBox ID="txtRLComuneResidenza" runat="server" ReadOnly="True" NomeCampo="Comune residenza rappresentante legale" Width="240px" />
                        <asp:HiddenField ID="IdRLComuneResidenzaHide" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                        <br />
                        &nbsp; Provincia:
                        <br />
                        <Siar:TextBox ID="txtRLProvinciaResidenza" runat="server" ReadOnly="True" Width="40px" TextAlign="right" />
                    </td>
                    <td>
                        <br />
                        &nbsp;Cap:<br />
                        <Siar:TextBox ID="txtRLCapResidenza" runat="server" ReadOnly="True" Width="80px" TextAlign="right" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id="trCC1" runat="server">
        <td class="paragrafo">
            <br />
            &nbsp;Conto corrente:
        </td>
    </tr>
    <tr id="trCC2" runat="server">
        <td style="padding-left: 10px">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="height: 76px" valign="middle">
                        &nbsp; IBAN:
                        <br />
                        <Siar:TextBox id="txtCodiceIntero" runat="server" NomeCampo="IBAN" Width="298px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input class="ButtonGrid" onclick="ICtrlControlloIban()" type="button" value="controllo codice IBAN" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="btnNuovo" class="ButtonGrid" onclick="ICtrlNuovoConto()" style="width: 140px"
                            type="button" value="Nuovo conto" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="width: 60px">
                                    &nbsp; Cod.
                                    <br />
                                    &nbsp;Paese:
                                </td>
                                <td style="width: 60px">
                                    <br />
                                    CIN Euro:
                                </td>
                                <td style="width: 55px">
                                    <br />
                                    CIN:
                                </td>
                                <td style="width: 90px">
                                    <br />
                                    ABI:
                                </td>
                                <td style="width: 90px">
                                    <br />
                                    CAB:
                                </td>
                                <td style="width: 191px">
                                    <br />
                                    Numero Conto:
                                </td>
                                <td>
                                    <img id="imgOk" alt="Conto corrente verificato" style="display: none" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 60px">
                                    <Siar:TextBox ID="txtCodPaese" runat="server" MaxLength="2" ReadOnly="True" Width="40px" />
                                </td>
                                <td style="width: 60px">
                                    <Siar:TextBox ID="txtCINeuro" runat="server" MaxLength="2" ReadOnly="True" Width="40px" />
                                </td>
                                <td style="width: 55px">
                                    <Siar:TextBox ID="txtCin" runat="server" MaxLength="1" ReadOnly="True" Width="30px" />
                                    &nbsp; &nbsp;
                                </td>
                                <td style="width: 90px">
                                    <Siar:TextBox ID="txtABI" runat="server" MaxLength="5" NomeCampo="ABI" ReadOnly="True"
                                        Width="62px" />
                                    &nbsp;&nbsp;
                                </td>
                                <td style="width: 90px">
                                    <Siar:TextBox ID="txtCAB" runat="server" MaxLength="5" NomeCampo="CAB" ReadOnly="True"
                                        Width="64px" />
                                    &nbsp; &nbsp;
                                </td>
                                <td style="width: 191px">
                                    <Siar:TextBox ID="txtNumeroConto" runat="server" MaxLength="20" ReadOnly="True" Width="174px" />
                                </td>
                                <td>
                                    <Siar:Button runat="server" ID="btnCopiaIban" Text="Copia IBAN" Width="140px" OnClientClick="return copiaIbanInRam();" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        &nbsp;Istituto:
                        <br />
                        <Siar:TextBox ID="txtIstituto" runat="server" Width="677px" ReadOnly="true" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        &nbsp;Agenzia:<br />
                        <Siar:TextBox ID="txtAgenzia" runat="server" Width="680px" ReadOnly="true" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc3:SNCComuniControl ID="ucSiarNewComuniControl" runat="server" ReadOnly="true" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="paragrafo">
            &nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td align="right" style="height: 73px; padding-right: 50px;">
            <asp:ValidationSummary ID="vsValidazioneImpresa" runat="server" HeaderText="Attenzione! E` obbligatorio specificare i seguenti dati:"
                ShowMessageBox="True" ShowSummary="False" ValidationGroup="ValidazioneImpresa" />
            <Siar:Button ID="btnScaricaAT" Visible="false" runat="server" Modifica="False" OnClick="btnScaricaAT_Click"
                Text="Aggiorna dati da Anagrafe Tributaria" Width="265px" CausesValidation="False" />
            <Siar:Button ID="btnUltimaVisura" runat="server" 
                Visible="false"
                Text="Mostra visura più recente" Width="160px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <%--<Siar:Button ID="btnSalva" runat="server" Modifica="False" OnClick="btnSalva_Click"
                Text="Salva" ValidationGroup="vgAnagraficaImpresa" Width="160px" />
            <Siar:Button ID="btnSalvaIstruttoria" runat="server" Visible="false" Modifica="False" OnClick="btnSalvaIstruttoria_Click"
                Text="Salva e accetta visura" ValidationGroup="vgAnagraficaImpresa" Width="180px" />
            <Siar:Button ID="btnSalvaConDichiarazione" runat="server" Visible="false" Modifica="False" OnClick="btnSalvaConDichiarazione_Click"
                Text="Salva e accetta dichiarazione" ValidationGroup="vgAnagraficaImpresaPresentazione" Width="180px" />--%>
            <Siar:Button ID="btnSalva" runat="server" Modifica="False" OnClick="btnSalva_Click"
                Text="Salva" CausesValidation="true" ValidationGroup="ValidazioneImpresa" Width="160px" />
            <Siar:Button ID="btnSalvaIstruttoria" runat="server" Visible="false" Modifica="False" OnClick="btnSalvaIstruttoria_Click"
                Text="Salva e accetta visura" CausesValidation="true" ValidationGroup="ValidazioneImpresa" Width="180px" />
            <Siar:Button ID="btnSalvaConDichiarazione" runat="server" Visible="false" Modifica="False" OnClick="btnSalvaConDichiarazione_Click"
                Text="Salva e accetta dichiarazione" CausesValidation="true" ValidationGroup="ValidazioneImpresa" Width="180px" />
        </td>
    </tr>
</table>
