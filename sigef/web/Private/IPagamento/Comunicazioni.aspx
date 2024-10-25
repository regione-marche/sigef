<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.Comunicazioni" CodeBehind="Comunicazioni.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento"
    TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function ctrlSegnaturaAnnullamento(ev) {
            if($('[id$=txtSegnaturaAnnullamento]').val()=='') { alert('Attenzione! Digitare la segnatura della richiesta di annullamento.');return stopEvent(ev); }
            else if(!confirm("Attenzione! La richiesta verrà annullata e non sarà più possibile il ripristino. Continuare?")) return stopEvent(ev);
        }
        function chkSegnaturaRiesame(ev) { if($('[id$=txtSegnaturaRiesame]').val()=='') { alert('Digitare la segnatura della richiesta.');return stopEvent(ev); } }
//--></script>

    <br />
    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <br />
    <table class="tableNoTab" width="900px">
        <tr>
            <td class="separatore_big">
                COMUNICAZIONI DA/AL BENEFICIARIO:
            </td>
        </tr>
        <tr>
            <td style="height: 40px; padding-right: 40px" align="right">
                <input class="Button" style="width: 156px" type="button" value="Indietro" onclick="location='CheckListPagamento.aspx'" />
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Comunicazione di esito istruttorio:
            </td>
        </tr>
        <tr>
            <td align="center">
                <br />
                Segnatura di protocollo:
                <br />
                <Siar:TextBox ID="txtSegnaturaComunicazione" runat="server" MaxLength="100" Width="516px"
                    ReadOnly="True" />
                <div style="display: none">
                    <Siar:Button ID="btnComunicazionePost" runat="server" CausesValidation="False" OnClick="btnComunicazionePost_Click" /></div>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 80px">
                <Siar:Button ID="btnFirmaComunicazione" runat="server" CausesValidation="false" Enabled="False"
                    Width="200px" Text="Firma Comunicazione" OnClick="btnFirmaComunicazione_Click" />
                <input type="button" class="Button" id="btnStampaComunicazione" runat="server" disabled="disabled"
                    style="width: 200px; margin-left: 20px" value="Stampa Comunicazione" /></td>
        </tr>
        <tr>
            <td class="paragrafo">
                Richiesta di riesame della domanda di pagamento:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <table width="100%">
                    <tr>
                        <td style="width: 521px">
                            Digitare la segnatura di protocollo della richiesta:
                        </td>
                        <td>
                            Esito richiesta:
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 521px">
                            <Siar:TextBox ID="txtSegnaturaRiesame" runat="server" Width="476px" />
                        </td>
                        <td>
                            <Siar:TextBox ID="txtEsitoRichiestaRiesame" runat="server" Width="200px" ReadOnly="True" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 521px">
                            <br />
                            &nbsp;Motivazione:
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <Siar:TextArea ID="txtMotivazioneRiesameLunga" runat="server" Rows="5" Width="725px"
                                ExpandableRows="10" />
                            <div style="width: 725px; text-align: right">
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 80px">
                <Siar:Button ID="btnAccettaRiesame" runat="server" Modifica="False" Text="Ammetti la richiesta"
                    Width="200px" OnClick="btnAmmettiRiesame_Click" CausesValidation="false" Enabled="False"
                    OnClientClick="return chkSegnaturaRiesame(event);" />
                &nbsp; &nbsp;
                <Siar:Button ID="btnRifiutaRiesame" runat="server" Modifica="False" Text="Rifiuta la richiesta"
                    Width="200px" OnClick="btnRifiutaRiesame_Click" CausesValidation="false" Enabled="False"
                    OnClientClick="return chkSegnaturaRiesame(event);" />
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Annullamento della domanda di pagamento:
            </td>
        </tr>
        <tr>
            <td style="height: 63px">
                &nbsp;&nbsp; Questa procedura fa seguito ad una <b>richiesta </b>del beneficiario,
                occorre quindi digitare la segnatura relativa.<br />
                &nbsp;&nbsp; E` possibile annullare la presente domanda di pagamento solo se <b>non
                </b>ancora<b> istruita </b>dal funzionario assegnato.<br />
                &nbsp;&nbsp; Gli operatori abilitati sono l`<b>istruttore</b> ed il <b>responsabile
                    provinciale </b>di istruttoria.
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 100px">
                Segnatura della richiesta di annullamento:<br />
                <Siar:TextBox ID="txtSegnaturaAnnullamento" runat="server" MaxLength="100" Width="550px" />
                <br />
                &nbsp;<br />
                <Siar:Button ID="btnAnnullamento" runat="server" Modifica="False" Text="Annulla la domanda"
                    Width="200px" OnClick="btnAnnullamento_Click" CausesValidation="False" OnClientClick="return ctrlSegnaturaAnnullamento(event);"
                    Enabled="False" />
            </td>
        </tr>
    </table>
    <uc3:FirmaDocumento ID="ucFirmaDocumento" runat="server" TipoDocumento="COMUNICAZIONE_PAGAMENTO"
        Titolo="COMUNICAZIONE DI ESITO ISTRUTTORIO DELLA DOMANDA DI PAGAMENTO" />
</asp:Content>
