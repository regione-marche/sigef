<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.InvestimentiContoInteressi" CodeBehind="InvestimentiContoInteressi.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <br />
    <table class="tableNoTab" width="900px">
        <tr>
            <td class="separatore_big">
                Dettaglio spese del Mutuo
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 30px">
                <uc3:SiarNewToolTip ID="ucSiarNewToolTip" runat="server" />
            </td>
        </tr>
        <tr>
            <td id="tdInvestimentoComponent" runat="server">
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 51px">
                <Siar:Button ID="btnSalvaInvestimento" runat="server" Modifica="True" Text="Ammetti"
                    OnClick="btnSalvaInvestimento_Click" Width="190px" />
                <input id="btnIstruttoriaAllegati" runat="server" class="Button" style="width: 190px;
                    margin-left: 20px" type="button" value="Controllo degli allegati" />
                <input id="btnBack" runat="server" class="Button" style="width: 140px; margin-left: 20px"
                    type="button" value="Indietro" />
            </td>
        </tr>
    </table>
</asp:Content>
