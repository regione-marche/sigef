<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.InvestimentiContoInteressi" CodeBehind="InvestimentiContoInteressi.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <table class="tableNoTab" width="900px">
        <tr>
            <td class="separatore_big">
                Dettaglio spese del Mutuo
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
                    OnClick="btnSalvaInvestimento_Click" Width="160px" />
                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <Siar:Button ID="btnDelete" runat="server" Modifica="True" Text="Elimina" OnClick="btnDelete_Click"
                    Width="160px" CausesValidation="False" Conferma="Annullare la richiesta del premio in conto interessi?" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" class="Button" onclick="location='PianoInvestimenti.aspx'" value="Indietro"
                    style="width: 140px" />
            </td>
        </tr>
    </table>
</asp:Content>
