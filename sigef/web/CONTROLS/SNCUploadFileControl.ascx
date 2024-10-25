<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SNCUploadFileControl.ascx.cs"
    Inherits="web.CONTROLS.SNCUploadFileControl" %>
<asp:HiddenField ID="hdnSNCUFUploadFile" runat="server" />
<asp:HiddenField ID="hdnSNCUFDatiFatturaE" runat="server" />
<table id="tableSNCUFUploadFile" runat="server" style="height: 40px" width="560px">
    <tr>
        <td style="padding: 3px; padding-right: 10px; border: 0">
            <Siar:TextBox ID="txtSNCUFPercorsoFile" runat="server" ReadOnly="true" Width="340px"
                NomeCampo="Documento digitale" />
        </td>
        <td style="padding: 3px; border: 0">
            <input id="btnSNCUFAggiungiFile" runat="server" type="button" class="Button" style="width: 90px"
                value="Aggiungi" />
        </td>
        <td style="padding: 3px; border: 0">
            <input id="btnSNCUFVisualizzaFile" runat="server" type="button" class="Button" style="width: 90px"
                value="Visualizza" />
        </td>
    </tr>
</table>
