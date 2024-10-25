<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SNCRicercaImpresa.ascx.cs"
    Inherits="web.CONTROLS.SNCRicercaImpresa" %>
<table style="width: 550px" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width: 160px">
            C.F./P.Iva:<br />
            <Siar:TextBox ID="txtSNCRICuaa" runat="server" Width="140px" />
        </td>
        <td style="width: 390px">
            <br />
            <input id="btnSNCRICercaImpresa" runat="server" class="ButtonGrid" type="button"
                value="Cerca" style="width: 100px" /><asp:HiddenField ID="hdnSNCRIIdImpresa" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="lblSNCRITestoCustom" runat="server" Text="(ricerca per Codice Fiscale\P.Iva)"></asp:Label>
            <br />
            <Siar:TextArea ID="txtSNCRIRagioneSociale" runat="server" ReadOnly="true" CssClass="readonly" Rows="2" Width="300px" />
        </td>
    </tr>
</table>
