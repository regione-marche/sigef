<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IVariante.InvestimentiContoInteressi" CodeBehind="InvestimentiContoInteressi.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/IVariantiControl.ascx" TagName="IVariantiControl"
    TagPrefix="uc1" %>
<%@ Register Src="../../../CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc1:IVariantiControl ID="IVariantiControl" runat="server" />
    <br />
    <input id="hdnIdInvestimento" type="hidden" runat="server" />
    <table class="tableNoTab" width="900px">
        <tr>
            <td class="separatore_big">
                Dettaglio spese del Mutuo
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 30px">
                <uc2:SiarNewToolTip ID="ucSiarNewToolTip" runat="server" />
            </td>
        </tr>
        <tr>
            <td id="tdInvestimentoComponent" runat="server">
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 60px">
                <Siar:Button ID="btnSalvaInvestimento" runat="server" Modifica="True" OnClick="btnSalvaInvestimento_Click"
                    Text="Ammetti le modifiche" Width="200px" />
                &nbsp; &nbsp;&nbsp;
                <input type="button" class="Button" style="width: 160px" value="Indietro" onclick="location='PianoInvestimenti.aspx'" /></td>
        </tr>
    </table>
</asp:Content>
