<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.InvestimentiBrevettiLicenze" CodeBehind="InvestimentiBrevettiLicenze.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <input id="hdnIdInvestimento" type="hidden" name="hdnIdInvestimento" runat="server" />
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
            <td align="center" style="height: 50px">
                <Siar:Button ID="btnSalvaInvestimento" runat="server" Modifica="True" Text="Salva"
                    OnClick="btnSalvaInvestimento_Click" Width="190px" />
                &nbsp;&nbsp;
                <Siar:Button ID="btnDelete" runat="server" Modifica="True" Text="Elimina" OnClick="btnDelete_Click"
                    Width="190px" CausesValidation="False" Conferma="Confermare l`eliminazione di questa spesa?" />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 50px">
                <input type="button" class="Button" onclick="location='PianoInvestimenti.aspx'" value="Indietro"
                    style="width: 140px" />&nbsp;&nbsp;
                <input id="btnNuovo" type="Button" runat="server" class="Button" value="Nuovo" style="width: 140px"
                    disabled="disabled" />
            </td>
        </tr>
    </table>
</asp:Content>
