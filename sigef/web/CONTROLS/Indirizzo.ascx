<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.Indirizzo"
    CodeBehind="Indirizzo.ascx.cs" %>
<table>
    <tr>
        <td>
            Comune:<br />
            <asp:TextBox ID="cmbComune" TabIndex="4" runat="server" CssClass="dtFrmCtrl5" />
        </td>
        <td>
            Prov:<br />
            <asp:TextBox ID="txtProv" TabIndex="20" runat="server" CssClass="dtFrmCtrl0 readonly" />
        </td>
        <td>
            CAP:<br />
            <asp:TextBox ID="txtCAP" TabIndex="6" runat="server" CssClass="dtFrmCtrl0" />
            <asp:HiddenField ID="IdComuneHide" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Indirizzo:<br />
            <Siar:ComboDUG ID="cmbDUG" TabIndex="8" runat="server" CssClass="dtFrmCtrl1" />
            <asp:TextBox TabIndex="10" ID="txtVia" runat="server" CssClass="dtFrmCtrl3" />
        </td>
        <td>
            Num:<br />
            <asp:TextBox TabIndex="12" ID="txtNum" runat="server" CssClass="dtFrmCtrl0" />
        </td>
        <td></td>
    </tr>
</table>
