<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.Variante.InvestimentiBrevettiLicenze" CodeBehind="InvestimentiBrevettiLicenze.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/WorkFlowVarianti.ascx" TagName="WorkFlowVarianti"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
  <%--  <uc1:WorkFlowVarianti ID="ucWorkFlowVarianti" runat="server" />--%>
    <br />
    <asp:HiddenField ID="hdnIdInvestimento" runat="server" />
    <table class="tableNoTab" width="900px">
        <tr>
            <td class="separatore_big">
                Dettaglio dell'acquisto di brevetti e\o licenze
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
            <td align="center" style="height: 54px">
                <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                    Text="Salva le modifiche" Width="200px" />
                &nbsp;&nbsp;&nbsp;
                <input type="button" id="btnNuovo" runat="server" class="Button" value="Nuovo investimento"
                    style="width: 160px" />
                &nbsp;
                <input type="button" class="Button" style="width: 160px" value="Indietro" onclick="location='PianoInvestimenti.aspx'" /></td>
        </tr>
        <tr>
            <td align="center" style="height: 51px">
                <Siar:Button ID="btnAnnullaInvestimento" runat="server" CausesValidation="False"
                    Modifica="True" OnClick="btnAnnullaInvestimento_Click" Text="Annulla investimento"
                    Width="160px" Conferma="Attenzione! Annullare l`investimento?" />
                &nbsp;
                <Siar:Button ID="btnRipristina" runat="server" CausesValidation="False" Modifica="True"
                    OnClick="btnRipristinaInvestimento_Click" Text="Ripristina" Width="160px" Conferma="Attenzione! Ripristinare l`investimento annullato?" />
            </td>
        </tr>
    </table>
</asp:Content>
