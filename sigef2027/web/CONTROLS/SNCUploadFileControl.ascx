<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SNCUploadFileControl.ascx.cs"
    Inherits="web.CONTROLS.SNCUploadFileControl" %>
<asp:HiddenField ID="hdnSNCUFUploadFile" runat="server" />
<asp:HiddenField ID="hdnSNCUFDatiFatturaE" runat="server" />
<table id="tableSNCUFUploadFile" runat="server" class="table">
    <tr>
        <td>
            <Siar:TextBox  ID="txtSNCUFPercorsoFile" runat="server" ReadOnly="true" Width="340px"
                NomeCampo="Documento digitale" />
        </td>
        <td>
            <input id="btnSNCUFAggiungiFile" runat="server" type="button" class="btn btn-primary py-1"
                value="Aggiungi" />
        </td>
        <td>
            <input id="btnSNCUFVisualizzaFile" runat="server" type="button" class="btn btn-primary py-1"
                value="Visualizza" />
        </td>
    </tr>
</table>

<%--<div id="Div1" class="row" runat="server">
    <div class="form-group col-sm-6">
        <Siar:TextBox  ID="TextBox1" runat="server" ReadOnly="true" NomeCampo="Documento digitale" />
    </div>
    <div class="col-sm-6">
        <input id="Button1" runat="server" type="button" class="btn btn-primary py-1" value="Aggiungi" />
        <input id="Button2" runat="server" type="button" class="btn btn-primary py-1" value="Visualizza" />
    </div>
</div>--%>

