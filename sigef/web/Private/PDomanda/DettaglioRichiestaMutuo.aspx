<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="DettaglioRichiestaMutuo.aspx.cs" Inherits="web.Private.PDomanda.DettaglioRichiestaMutuo" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
     &nbsp;<input id="hdnIdInvestimento" type="hidden" runat="server" />
    <table style="width: 800px" class="tableNoTab">
        <tr>
            <td class="separatore">
                &nbsp;DETTAGLIO DELLA RICHIESTA DI MUTUO: 
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td id="tdInvestimentoComponent" runat="server">
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 68px">
                <Siar:Button ID="btnSalvaInvestimento" runat="server" Modifica="True" Text="Salva"
                    OnClick="btnSalvaInvestimento_Click" Width="160px" />
                &nbsp;&nbsp;&nbsp;
                <input type="button" class="Button" onclick="location='BusinessPlan.aspx'" value="Indietro"
                    style="width: 140px" />
            </td>
        </tr>
    </table>
</asp:Content>
