<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IVariante.Riepilogo" CodeBehind="Riepilogo.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/IVariantiControl.ascx" TagName="IVariantiControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc2:IVariantiControl ID="IVariantiControl" runat="server" />
    &nbsp;&nbsp;<table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                Riepilogo dati della richiesta:
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                In questa pagina e' possibile visualizzare la modalità della modifica al piano degli
                investimenti che è stata richiesta<br />
                ed avere una breve descrizione tecnica della stessa.
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            <b>Modalità:</b><br />
                            <Siar:ComboBase ID="lstModalita" runat="server" NomeCampo="Modalita" Obbligatorio="True">
                            </Siar:ComboBase>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Descrizione tecnica\Motivazioni:</b> (max 1000 caratteri)
                            <Siar:TextArea ID="txtDescrizione" runat="server" Rows="7" Width="650px" MaxLength="1000"
                                ExpandableRows="10" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 60px">
                            <Siar:Button ID="btnSalvaMotivazioni" runat="server" CausesValidation="False" Modifica="True"
                                OnClick="btnSalvaMotivazioni_Click" Text="Salva le motivazioni" Conferma="" Visible="False" />
                            &nbsp;&nbsp; &nbsp;
                            <Siar:Button ID="btnEliminaVariazione" runat="server" CausesValidation="False" Modifica="True"
                                OnClick="btnEliminaVariazione_Click" Text="Elimina la variazione" Conferma="Attenzione! Eliminare la variazione di istruttoria?"
                                Visible="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Richiesta di cambio beneficiario dell'aiuto:
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Qualori i campi sottostanti fossero <b>compilati </b>significa che tale variante
                include la richiesta di cambio beneficiario<br />
                della domanda di aiuto relativa e di tutte le domande di pagamento successive.
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Beneficiario uscente:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            Partita iva/Codice fiscale:<br />
                            <Siar:TextBox ID="txtCuaaUscente" runat="server" Width="140px" ReadOnly="True" />
                        </td>
                        <td>
                            Ragione sociale:<br />
                            <Siar:TextBox ID="txtRagSocUscente" runat="server" Width="440px" ReadOnly="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Beneficiario entrante:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 180px">
                            Partita iva/Codice fiscale:<br />
                            <Siar:TextBox ID="txtCuaaEntrante" runat="server" Width="140px" ReadOnly="true" />
                        </td>
                        <td>
                            P.Iva:<br />
                            <Siar:TextBox ID="txtPivaEntrante" runat="server" Width="140px" ReadOnly="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Ragione sociale:<br />
                            <Siar:TextBox ID="txtRagSocEntrante" runat="server" Width="440px" ReadOnly="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Fascicolo aziendale:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 170px">
                            Data validazione:<br />
                            <Siar:DateTextBox ID="txtDataValidazione" runat="server" ReadOnly="True" Width="100px" />
                        </td>
                        <td style="width: 170px">
                            Data scheda validazione:<br />
                            <Siar:DateTextBox ID="txtDataSchedaValidazione" runat="server" ReadOnly="True" Width="100px" />
                        </td>
                        <td>
                            Barcode scheda validazione:<br />
                            <Siar:TextBox ID="txtBarcode" runat="server" Width="140px" ReadOnly="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
