<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" Inherits="web.Private.VisitaAziendale.Ricerca" Codebehind="Ricerca.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <table class="tableNoTab" style="width: 422px">
        <tr>
            <td class="separatore">
                &nbsp;Ricerca controlli aziendali:</td>
        </tr>
        <tr>
            <td style="height: 56px">
                &nbsp;
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width: 97px">
                            N. dom. aiuto:<br />
                            <Siar:IntegerTextBox ID="txtIdProgetto" runat="server" Width="70px" />
                        </td>
                        <td colspan="2">
                            Tipo dom. pagamento:<br />
                            <Siar:Combo ID="lstTipoPagamento" runat="server">
                            </Siar:Combo><br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 97px">
                            &nbsp;N. controllo:<br />
                            <Siar:IntegerTextBox ID="txtIdVisita" runat="server" Width="70px" />
                            <br />
                            &nbsp;</td>
                        <td style="width: 124px">
                            <asp:CheckBox ID="chkControlloConcluso" runat="server" Text="Controllo concluso" /></td>
                        <td align="center">
                            <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" Width="125px" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    &nbsp;
    <table id="tableResult" runat="server" class="tableNoTab" style="width: 900px">
        <tr>
            <td class="separatore">
                &nbsp;Elementi trovati:</td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
