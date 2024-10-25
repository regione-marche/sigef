<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupBoxProfilo.ascx.cs"
    Inherits="web.CONTROLS.GroupBoxProfilo" %>
<table style="width: 100%" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width: 200px; padding-right: 20px">
            Ente:
            <br />
            <Siar:ComboEnte ID="lstGBPEnte" runat="server" Width="190px">
            </Siar:ComboEnte>
        </td>
        <td>
            Ruolo:<br />
            <Siar:ComboBase ID="lstGBPRuolo" runat="server" NomeCampo="Ruolo" Obbligatorio="True">
            </Siar:ComboBase>
            <div style="display: none">
                <asp:Button ID="btnGBPPost" runat="server" OnClick="btnGBPPost_Click" CausesValidation="false" /></div>
        </td>
    </tr>
</table>
