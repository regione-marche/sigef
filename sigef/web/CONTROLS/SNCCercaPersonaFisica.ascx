<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SNCCercaPersonaFisica.ascx.cs"
    Inherits="web.CONTROLS.SNCCercaPersonaFisica" %>
<table style="width: 100%;">
    <tr>
        <td style="width: 180px;">
            &nbsp;Codice fiscale:<br />
            <Siar:TextBox ID="txtSNCCPFCF" runat="server" Width="160px" />
        </td>
        <td style="width: 300px;">
            &nbsp;Nominativo:<br />
            <Siar:TextBox ID="txtSNCCPFNominativo" runat="server" Width="280px" ReadOnly="True" />
        </td>
        <td>
            <br />
            <input id="btnSNCCPFCerca" runat="server" type="button" class="Button" value="Cerca"
                style="width: 90px" />
        </td>
    </tr>
</table>
<input type="hidden" id="hdnSNCCPFIdPersona" runat="server" />
