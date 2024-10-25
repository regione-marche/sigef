<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVerbaleUploadFileControl.ascx.cs"
    Inherits="web.CONTROLS.VerbaleUploadFileControl" %>
<asp:HiddenField ID="hdnUploadFile" runat="server" />
<asp:HiddenField ID="hdnDatiFatturaE" runat="server" />

<div id="divVerbaleUploadFileControl" class="table">
<div  class="row align-items-end justify-content-start py-4">
    <div class="col-2">
        <label class="active" for="txtDataVerbale">Data verbale</label>          
        <input type="text" id="txtDataVerbale"  runat="server">
             <%--   <Siar:DateTextBox ID="txtDataVerbale" runat="server" />--%>
    </div>
    <div class="col-5">        
            <label class="active" for="txtPercorsoFile">Specificare il file digitale relativo a verbale</label>
            <input type="text" id="txtPercorsoFile" runat="server">
    </div>
    <div class="col-3 py-1" >
            <input id="btnAggiungiFile" runat="server" type="button" class="btn btn-primary py-1" value="Aggiungi" />
            <input id="btnVisualizzaFile" runat="server" type="button" class="btn btn-primary py-1" value="Visualizza" />        
    </div>
</div>
</div>
