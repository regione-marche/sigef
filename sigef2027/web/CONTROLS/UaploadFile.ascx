<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UaploadFile.ascx.cs" Inherits="web.CONTROLS.UaploadFile" %>

<div  class="row align-items-end justify-content-start py-4">
    <div class="col-6">        
           <label class="active" for="txtSNCUFPercorsoFile">Specificare il file digitale</label>       
            <asp:FileUpload ID="SNCUFileUpload" runat="server" />
    </div>
    <div class="col-6 pb-1" >
        <asp:Button ID="btnSNCUFAggiungiFile" runat="server" class="btn btn-primary py-1"  Text="Button" onclick="btnSNCUFAggiungiFile_Click" />       
        <asp:Button ID="btnSNCUFVisualizzaFile" runat="server" class="btn btn-primary py-1" Text="Button" onclick="btnSNCUFVisualizzaFile_Click" />
    </div>
</div>
