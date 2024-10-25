<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="ImpresaRiepilogo.aspx.cs" Inherits="web.Private.Impresa.ImpresaRiepilogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <br />
    <table class="tableNoTab" width="900px">
        <tr>
            <td class="separatore_big">
                RIEPILOGO ATTIVITA&#39; DEL BENEFICIARIO
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 140px">
                            &nbsp;Data inizio attività:<br />
                            <Siar:DateTextBox ID="txtDataInizioAttivita" runat="server" ReadOnly="True" Width="100px" />
                        </td>
                        <td>
                            Stato impresa:<br />
                            <Siar:TextBox ID="txtStatoImpresa" runat="server" ReadOnly="True" Width="300px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;Attività FESR e domande di partecipazione:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 140px">
                            Nr. domande presentate:<br />
                            <Siar:IntegerTextBox ID="txtNrPrPresentati" runat="server" ReadOnly="True" Width="100px" />
                        </td>
                        <td style="width: 140px">
                            Nr. domande attive:<br />
                            <Siar:IntegerTextBox ID="txtNrPrAttivi" runat="server" ReadOnly="True" Width="100px" />
                        </td>
                        <td>
                            Ultima domanda attiva:<br />
                            <Siar:IntegerTextBox ID="txtNrPrUltimo" runat="server" ReadOnly="True" Width="80px"
                                NoCurrency="True" />
                            &nbsp;<Siar:TextBox ID="txtStatoPrUltimo" runat="server" ReadOnly="True" Width="300px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="display:none;">
            <td class="paragrafo">
                &nbsp;Attività UMA:
            </td>
        </tr>
        <tr style="display:none;">
            <td style="padding: 10px">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 140px">
                            Primo anno attività(*):<br />
                            <Siar:IntegerTextBox ID="txtUmaPrimoAnno" runat="server" ReadOnly="True" Width="100px"
                                NoCurrency="True" />
                        </td>
                        <td>
                            Ultima&nbsp; pratica avviata:<br />
                            <Siar:IntegerTextBox ID="txtUmaIdUltimo" runat="server" ReadOnly="True" Width="80px"
                                NoCurrency="True" />
                            &nbsp;<Siar:IntegerTextBox ID="txtUmaAnnoUltimo" runat="server" ReadOnly="True" Width="60px"
                                NoCurrency="True" />
                            &nbsp;<Siar:TextBox ID="txtUmaTipoUltimo" runat="server" ReadOnly="True" Width="160px" />
                            <span style="padding-left: 20px">&nbsp;</span><Siar:TextBox ID="txtUmaStatoUltimo"
                                runat="server" ReadOnly="True" Width="160px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;(*) = non si dispongono dei dati antecedenti il 2009
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="display:none;">
            <td class="paragrafo">
                &nbsp;Albo BIO:
            </td>
        </tr>
        <tr style="display:none;">
            <td style="padding: 10px">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 140px">
                            Ultimo anno di notifica:<br />
                            <Siar:IntegerTextBox ID="txtBioAnno" runat="server" ReadOnly="True" Width="100px"
                                NoCurrency="True" />
                        </td>
                        <td style="width: 300px">
                            Tipo di attività:<br />
                            <Siar:TextBox ID="txtBioAttivita" runat="server" ReadOnly="True" Width="270px" />
                        </td>
                        <td>
                            Organismo di controllo:<br />
                            <Siar:TextBox ID="txtBioOdc" runat="server" ReadOnly="True" Width="240px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="display:none;">
            <td>
            </td>
        </tr>
        <tr style="display:none;">
            <td class="paragrafo">
                &nbsp; Elenco EROA:
            </td>
        </tr>
        <tr style="display:none;">
            <td style="padding: 10px">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 140px">
                            Anno iscrizione:<br />
                            <Siar:IntegerTextBox ID="txtEroaAnno" runat="server" ReadOnly="True" Width="100px"
                                NoCurrency="True" />
                        </td>
                        <td style="width: 170px">
                            Nr certificato:<br />
                            <Siar:TextBox ID="txtEroaNumero" runat="server" ReadOnly="True" Width="140px" TextAlign="right" />
                        </td>
                        <td style="width: 200px">
                            Stato:<br />
                            <Siar:TextBox ID="txtEroaStato" runat="server" ReadOnly="True" Width="170px" />
                        </td>
                        <td>
                            <br />
                            <asp:CheckBox ID="chkEroaAttMinima" runat="server" Style="font-weight: 700" Text="Attività Minimale" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore_light">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 63px">
                <input id="btnCessazione" style="width: 170px; display: none" type="button" value="Cessazione attività"
                    class="Button" onclick="location='CessazioneAttivita.aspx'" />
            </td>
        </tr>
    </table>
</asp:Content>
