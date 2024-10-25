<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.RicercaDomanda" CodeBehind="RicercaDomanda.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <table class="tableNoTab" style="width: 388px">
        <tr>
            <td class="separatore">
                RICERCA DOMANDA DI AIUTO
            </td>
        </tr>
        <tr>
            <td style="height: 38px; padding-left: 10px">
                - Indicare il numero identificativo della domanda.
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbCodRicerca" width="100%" runat="server">
                    <tr>
                        <td style="height: 31px;" valign="top">
                            <strong>&nbsp; Numero domanda:</strong>&nbsp;
                            <Siar:IntegerTextBox ID="txtNumDomanda" runat="server" Width="84px" Obbligatorio="true"
                                NoCurrency="true" NomeCampo="Numero domanda" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 31px" valign="top">
                            <Siar:Button ID="btnCerca" runat="server" Width="133px" Text="Cerca" OnClick="btnCerca_Click"
                                CausesValidation="true"></Siar:Button>&nbsp; &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <table width="800px" class="tableNoTab">
        <tr>
            <td class="separatore_light">
                Risultato ricerca:
            </td>
        </tr>
        <tr>
            <td id="tdDomanda" runat="server" style="padding-top: 15px; padding-bottom: 15px">
            </td>
        </tr>
        <tr>
            <td id="tdPulsantiBando" runat="server" align="center">
            </td>
        </tr>
        <tr>
            <td id="tdFase2" runat="server">
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
