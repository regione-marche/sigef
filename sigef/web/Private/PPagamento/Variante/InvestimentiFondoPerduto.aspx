<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.Variante.InvestimentiFondoPerduto" CodeBehind="InvestimentiFondoPerduto.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/WorkFlowVarianti.ascx" TagName="WorkFlowVarianti"
    TagPrefix="uc1" %>
<%@ Register Src="../../../CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc1:WorkFlowVarianti ID="ucWorkFlowVarianti" runat="server" />
    <br />
    <asp:HiddenField ID="hdnIdInvestimento" runat="server" />
    <table width='900px' class="tableNoTab">
        <tr>
            <td class="separatore_big">
                Pagina di dettaglio degli investimenti
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 30px">
                <uc2:SiarNewToolTip ID="SiarNewToolTip1" runat="server" Codice="pdomanda_invfperduto" />
            </td>
        </tr>
        <tr>
            <td id="tdInvestimentoComponent" runat="server">
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 104px">
                <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                    Text="Salva le modifiche" Width="200px" />
                &nbsp; &nbsp;
                <Siar:Button ID="btnNuovo" runat="server" CausesValidation="False" Modifica="True"
                    OnClick="btnNuovoInvestimento_Click" Text="Nuovo investimento" Width="160px" />
                &nbsp;&nbsp;
                <Siar:Button ID="Button1" runat="server"  Text="Indietro" CausesValidation="False"
                    OnClick="btnIndietro_Click" Width="149px" />
                <%--<input type="button" class="Button" style="width: 149px" value="Indietro" onclick="location='PianoInvestimenti.aspx'" /><br />--%>
                &nbsp;
                <br /><br />
                <Siar:Button ID="btnAnnullaInvestimento" runat="server" CausesValidation="False"
                    Modifica="True" OnClick="btnAnnullaInvestimento_Click" Text="Annulla investimento"
                    Width="160px" Conferma="Attenzione! Annullare l`investimento?" />
                &nbsp; &nbsp;
                <Siar:Button ID="btnRipristina" runat="server" CausesValidation="False" Modifica="True"
                    OnClick="btnRipristinaInvestimento_Click" Text="Ripristina" Width="160px" Conferma="Attenzione! Ripristinare l`investimento annullato?" />
                &nbsp;&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
