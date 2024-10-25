<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.Variante.InvestimentiContoInteressi" CodeBehind="InvestimentiContoInteressi.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/WorkFlowVarianti.ascx" TagName="WorkFlowVarianti"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc1:WorkFlowVarianti ID="ucWorkFlowVarianti" runat="server" />
    <br />
    <table class="tableNoTab" width="900px">
        <tr>
            <td class="separatore_big">
                Dettaglio spese del Mutuo
            </td>
        </tr>
        <tr>
            <td style="height: 30px">
            </td>
        </tr>
        <tr>
            <td id="tdInvestimentoComponent" runat="server">
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 48px">
                <Siar:Button ID="btnSalvaInvestimento" runat="server" Modifica="True" OnClick="btnSalvaInvestimento_Click"
                    Text="Salva le modifiche" Width="180px" />
                &nbsp; &nbsp;
                <input type="button" class="Button" style="width: 150px" value="Indietro" onclick="location='PianoInvestimenti.aspx'" /><br />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 54px">
                <Siar:Button ID="btnAnnullaInvestimento" runat="server" CausesValidation="False"
                    Modifica="True" OnClick="btnAnnullaInvestimento_Click" Text="Annulla investimento"
                    Width="180px" Conferma="Attenzione! Annullare l`investimento?" />
                &nbsp;&nbsp;&nbsp;
                <Siar:Button ID="btnRipristina" runat="server" CausesValidation="False" Modifica="True"
                    OnClick="btnRipristinaInvestimento_Click" Text="Ripristina" Width="150px" Conferma="Attenzione! Ripristinare l`investimento annullato?" />
            </td>
        </tr>
    </table>
</asp:Content>
