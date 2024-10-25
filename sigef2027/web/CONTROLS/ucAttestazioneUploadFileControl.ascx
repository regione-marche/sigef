<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAttestazioneUploadFileControl.ascx.cs"
    Inherits="web.CONTROLS.AttestazioneUploadFileControl" %>
<asp:HiddenField ID="hdnUploadFile" runat="server" />
<asp:HiddenField ID="hdnDatiFatturaE" runat="server" />

<div class="row align-items-end justify-content-start py-4">
    <div class="col-2">      
        <label class="active" for="txtDataAttestazione">Data attestazione</label>               
        <input type="text" id="txtDataAttestazione" runat="server">
                    <%--<Siar:DateTextBox ID="txtDataAttestazione" runat="server" />--%>
    </div>
    <div class="col-5">
        <label class="active" for="txtPercorsoFile">Specificare il file digitale relativo all'attestazione</label>
        <input type="text" id="txtPercorsoFile" runat="server">
    </div>
    <div class="col-3 py-1">
        <input id="btnAggiungiFile" runat="server" type="button" class="btn btn-primary py-1" value="Aggiungi" />
        <input id="btnVisualizzaFile" runat="server" type="button" class="btn btn-primary py-1" value="Visualizza" />
    </div>
 </div>

<%--</div>--%>
