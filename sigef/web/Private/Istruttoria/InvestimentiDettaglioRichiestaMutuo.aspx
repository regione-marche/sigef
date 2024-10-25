<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="InvestimentiDettaglioRichiestaMutuo.aspx.cs" Inherits="web.Private.Istruttoria.InvestimentiDettaglioRichiestaMutuo" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    &nbsp;
    <uc1:InfoDomanda ID="ucInfoDomanda" runat="server" />
    &nbsp;
    <table width="900px" class="tableNoTab">
        <tr>
            <td class="separatore">
                &nbsp;DETTAGLIO DELLA RICHIESTA DI MUTUO:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<input id="hdnIdInvestimento" type="hidden" runat="server" />
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
                &nbsp;&nbsp;&nbsp;&nbsp;<input id="btnBack" runat="server" class="Button" style="width: 140px"
                    type="button" value="Indietro" />
            </td>
        </tr>
    </table>
</asp:Content>
