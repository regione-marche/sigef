<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SNCUploadFileControlAgid.ascx.cs"
    Inherits="web.CONTROLS.SNCUploadFileControlAgid" %>
<asp:HiddenField ID="hdnSNCUFUploadFile" runat="server" />
<asp:HiddenField ID="hdnSNCUFDatiFatturaE" runat="server" />

<div  class="row align-items-center justify-content-start py-4">
    <div class="col-6 ">        
           <%-- <label class="active" for="txtSNCUFPercorsoFile">Specificare il file digitale</label>--%>
         <%--   <Label type="text" id="txtSNCUFPercorsoFile" runat="server">--%>
            <label class="active" for="txtSNCUFPercorsoFile">Specificare il file digitale</label>
            <asp:TextBox CssClass="rounded" ID="txtSNCUFPercorsoFile" runat="server" ></asp:TextBox>

            <asp:FileUpload ID="SNCUFileUpload" runat="server" />
    </div>
    <div class="col-6 pb-1" >
        <asp:Button ID="btnSNCUFAggiungiFile" runat="server" class="btn btn-primary py-1"  Text="Button" onclick="btnSNCUFAggiungiFile_Click" />       
        <asp:Button ID="btnSNCUFVisualizzaFile" runat="server" class="btn btn-primary py-1" Text="Button" onclick="btnSNCUFVisualizzaFile_Click" />
    
            <%--<input id="btnSNCUFAggiungiFile" runat="server" type="button" class="btn btn-primary py-1" value="Aggiungi" />
            <input id="btnSNCUFVisualizzaFile" runat="server" type="button" class="btn btn-primary py-1" value="Visualizza" />        --%>
    </div>
</div>

