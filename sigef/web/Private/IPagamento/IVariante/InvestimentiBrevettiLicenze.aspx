<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IVariante.InvestimentiBrevettiLicenze" CodeBehind="InvestimentiBrevettiLicenze.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/IVariantiControl.ascx" TagName="IVariantiControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc1:IVariantiControl ID="IVariantiControl" runat="server" />
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
            <td align="center" style="height: 60px">
                <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                    Text="Salva le modifiche" Width="200px" />
                &nbsp; &nbsp;&nbsp;
                <input type="button" class="Button" style="width: 160px" value="Indietro" onclick="location='PianoInvestimenti.aspx'" />
        </tr>
    </table>
</asp:Content>
