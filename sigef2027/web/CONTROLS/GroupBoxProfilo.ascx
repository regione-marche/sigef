<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupBoxProfilo.ascx.cs"
    Inherits="web.CONTROLS.GroupBoxProfilo" %>

    <div class="col-sm-3">   
            <Siar:ComboEnte Label="Ente" ID="lstGBPEnte" runat="server" >
            </Siar:ComboEnte>
       </div>
    <div class="col-sm-3">          
            <Siar:ComboBase ID="lstGBPRuolo" runat="server" NomeCampo="Ruolo" Obbligatorio="True"></Siar:ComboBase>
            <div style="display: none">
                <asp:Button ID="btnGBPPost" runat="server" OnClick="btnGBPPost_Click" CausesValidation="false" /></div>
     </div>

