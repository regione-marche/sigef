<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SNCIndirizzoControl.ascx.cs"
    Inherits="web.CONTROLS.SNCIndirizzoControl" %>
<%@ Register src="SNCComuniControl.ascx" tagname="SNCComuniControl" tagprefix="uc1" %>
<table style="width: 100%;">
    <tr>
        <td style="width: 350px">
            Via:<br />
            <Siar:TextBox ID="txtSNCINDVia" runat="server" Width="325px" />
        </td>
        <td>
            Localita:<br />
            <Siar:TextBox ID="txtSNCINDLocalita" runat="server" Width="290px" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <uc1:SNCComuniControl ID="ucSNCComuniControl" runat="server" />
        </td>
    </tr>
</table>

<asp:HiddenField ID="hdnIdIndirizzo" runat="server" />


