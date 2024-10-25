<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="Cofirmatario.aspx.cs" Inherits="web.Private.PDomanda.Cofirmatario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function checkCF(ev) { if ($('[id$=txtCodFiscale_text]').val() == '') { alert('Digitare il codice fiscale dell`utente.'); return stopEvent(ev); } }
        function ctrlCF(elem, ev) { var cf = $(elem).val(); if (cf != "" && !ctrlCodiceFiscale(cf)) { alert('Attenzione! Codice fiscale non corretto.'); return stopEvent(ev); } }
               //-->
    </script>

    <br />
    <table width="950px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                Insediamento plurimo
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Nel caso di insediamento plurimo, nella domanda di aiuto devono essere indicati
                i dati anagrafici dei giovani che si insediano e che richiedono il premio.
                <br />
                Indicare, qui di seguito, il codice fiscale dell&#39;amministratore che sottoscrive
                la domanda.
            </td>
        </tr>
        <tr>
            <td class="separatore">
                &nbsp; Rappresentante Legale:
            </td>
        </tr>
        <tr>
            <td style="padding-left: 15px">
                <table runat="server" id="tbRappLegale" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 200px">
                            <br />
                            &nbsp; Codice Fiscale:<br />
                            <Siar:TextBox ID="txtRLCodiceFiscale" runat="server" ReadOnly="True" Width="160px" />
                        </td>
                        <td style="width: 23px">
                        </td>
                        <td>
                            <br />
                            &nbsp; Nominativo:<br />
                            <Siar:TextBox ID="txtRLNominativo" runat="server" ReadOnly="True" Width="500px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<br />
            </td>
        </tr>
        <tr>
            <td class="separatore">
                &nbsp; Cofirmatario :
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table style="padding-left: 15px" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width: 185px;">
                            &nbsp;Codice fiscale:  &nbsp;
                            <br />
                            <Siar:TextBox ID="txtRicercaCodFiscale" runat="server" Width="150px" MaxLength="16"
                                NomeCampo="Codice fiscale"></Siar:TextBox>
                        </td>
                        <td>
                            &nbsp;
                            <br />
                            <Siar:Button ID="btnScarica" runat="server" CausesValidation="False" OnClick="btnScarica_Click"
                                Text="Scarica dati anagrafici" OnClientClick="return checkCF(event);" />
                            <asp:HiddenField ID="hdnIdPersonaFisica" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 15px">
                <table runat="server" id="tdDettaglioAmministratore" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 550px">
                            <br />
                            &nbsp; Nominativo:<br />
                            <Siar:TextBox ID="txtNominativo" runat="server" ReadOnly="True" Width="500px" />
                        </td>
                        <td>
                            <br />
                            &nbsp;Data insediamento:<br />
                            <Siar:DateTextBox ID="txtDataInsediamento" runat="server" Width="120px" Obbligatorio="true" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 550px">
                            &nbsp;
                            <br />
                            &nbsp; Comune di nascita:
                            <br />
                            <Siar:TextBox ID="txtComuneNascita" runat="server" ReadOnly="True" Width="500px" />
                        </td>
                        <td>
                            <br />
                            &nbsp;Data di nascita:<br />
                            <Siar:DateTextBox ID="txtDataNascita" runat="server" ReadOnly="True" Width="120px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr id="trButton" runat="server">
            <td align="right">
                <Siar:Button ID="btnSalva" runat="server" CausesValidation="False" OnClick="btnSalva_Click"
                    Width="150px" Text="Salva" />
                &nbsp;
                <Siar:Button ID="btnElimina" runat="server" CausesValidation="False" Width="150px"
                    Text="Elimina" OnClick="btnElimina_Click" />
                &nbsp; &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
