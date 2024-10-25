<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.Variante.PianoInvestimenti" CodeBehind="PianoInvestimenti.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/WorkFlowVarianti.ascx" TagName="WorkFlowVarianti"
    TagPrefix="uc2" %>
<%@ Register Src="../../../CONTROLS/PianoInvestimenti.ascx" TagName="PianoInvestimenti"
    TagPrefix="uc1" %>

<%@ Register Src="../../../CONTROLS/PianoInvestimentiAggregazione.ascx" TagName="PianoInvestimentiAggregazione"
    TagPrefix="uc3" %>

<%@ Register Src="../../../CONTROLS/PianoInvestimentiCodifica.ascx" TagName="PianoInvestimentiCodifica"
    TagPrefix="uc4" %>

<%@ Register Src="../../../CONTROLS/PianoInvestimentiIntervento.ascx" TagName="PianoInvestimentiIntervento"
    TagPrefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc2:WorkFlowVarianti ID="ucWorkFlowVarianti" runat="server" />
    <br />
    <table class="tableNoTab" width="1100px">
        <tr>
            <td class="separatore_big">
                PIANO DEGLI INVESTIMENTI DELLA DOMANDA DI AIUTO
            </td>
        </tr>
         <tr>
            <td id="tdButtoniPage" runat="server" style="height: 60px; padding-right: 30px" align="right">
            </td>
        </tr>
        <tr>
            <td>
                <uc1:pianoinvestimenti id="ucPianoInvestimenti" runat="server" codicefase="PVARIANTE" />
            </td>
        </tr>
        <tr>
            <td>
                <uc3:PianoInvestimentiAggregazione ID="PianoInvestimentiAggregazione" runat="server" CodiceFase="PVARIANTE" />
            </td>
        </tr>
        <tr>
            <td>
                <uc4:PianoInvestimentiCodifica ID="PianoInvestimentiCodifica" runat="server" CodiceFase="PVARIANTE" />
            </td>
        </tr>
        <tr>
            <td>
                <uc5:PianoInvestimentiIntervento ID="PianoInvestimentiIntervento" runat="server" CodiceFase="PVARIANTE" />
            </td>
        </tr>
    </table>
</asp:Content>
