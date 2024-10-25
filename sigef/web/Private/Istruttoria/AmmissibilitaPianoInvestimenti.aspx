<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.AmmissibilitaPianoInvestimenti" CodeBehind="AmmissibilitaPianoInvestimenti.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/PianoInvestimenti.ascx" TagName="PianoInvestimenti"
    TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/PianoInvestimentiAggregazione.ascx" TagName="PianoInvestimentiAggregazione"
    TagPrefix="uc3" %>

<%@ Register Src="../../CONTROLS/PianoInvestimentiCodifica.ascx" TagName="PianoInvestimentiCodifica"
    TagPrefix="uc4" %>

<%@ Register Src="../../CONTROLS/PianoInvestimentiIntervento.ascx" TagName="PianoInvestimentiIntervento"
    TagPrefix="uc5" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <uc1:InfoDomanda ID="ucInfoDomanda" runat="server"  />
    <br />
    <table class="tableNoTab" width="1100px">
        <tr>
            <td class="separatore_big">
                Ammissibilità del piano di investimenti della domanda
            </td>
        </tr>
        <tr>
            <td id="tdButtoniPage" runat="server" style="height: 60px; padding-right: 30px" align="right">
            </td>
        </tr>
        <tr>
            <td>
                <uc2:PianoInvestimenti ID="ucPianoInvestimenti" runat="server" CodiceFase="IDOMANDA" />
            </td>
        </tr>
        <tr>
            <td>
                <uc3:PianoInvestimentiAggregazione ID="PianoInvestimentiAggregazione" runat="server" CodiceFase="IDOMANDA" />
            </td>
        </tr>
        <tr>
            <td>
                <uc4:PianoInvestimentiCodifica ID="PianoInvestimentiCodifica" runat="server" CodiceFase="IDOMANDA" />
            </td>
        </tr>
        <tr>
            <td>
                <uc5:PianoInvestimentiIntervento ID="PianoInvestimentiIntervento" runat="server" CodiceFase="IDOMANDA" />
            </td>
        </tr>
    </table>
</asp:Content>
