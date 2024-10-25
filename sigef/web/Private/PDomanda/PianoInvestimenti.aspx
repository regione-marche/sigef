<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.PianoInvestimenti" CodeBehind="PianoInvestimenti.aspx.cs" %>

<%@ Register Src="../../CONTROLS/PianoInvestimenti.ascx" TagName="PianoInvestimenti"
    TagPrefix="uc1" %>

<%@ Register Src="../../CONTROLS/PianoInvestimentiAggregazione.ascx" TagName="PianoInvestimentiAggregazione"
    TagPrefix="uc2" %>

<%@ Register Src="../../CONTROLS/PianoInvestimentiCodifica.ascx" TagName="PianoInvestimentiCodifica"
    TagPrefix="uc3" %>

<%@ Register Src="../../CONTROLS/PianoInvestimentiIntervento.ascx" TagName="PianoInvestimentiIntervento"
    TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
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
                <uc1:PianoInvestimenti ID="ucPianoInvestimenti" runat="server" CodiceFase="PDOMANDA" />
            </td>
        </tr>
        <tr>
            <td>
                <uc2:PianoInvestimentiAggregazione ID="PianoInvestimentiAggregazione" runat="server" CodiceFase="PDOMANDA" />
            </td>
        </tr>
        <tr>
            <td>
                <uc3:PianoInvestimentiCodifica ID="PianoInvestimentiCodifica" runat="server" CodiceFase="PDOMANDA" />
            </td>
        </tr>
        <tr>
            <td>
                <uc4:PianoInvestimentiIntervento ID="PianoInvestimentiIntervento" runat="server" CodiceFase="PDOMANDA" />
            </td>
        </tr>
    </table>
</asp:Content>
