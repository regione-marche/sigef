<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="TestFirmaDigitaleRemota.aspx.cs" Inherits="web.Public.Download.TestFirmaDigitaleRemota" %>

<%@ Register Src="~/CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc4" %>

<asp:content id="Content1" contentplaceholderid="cphContenuto" runat="Server">

<%--<script type="text/javascript">
    $(document).on("click", '[id$=btnFirmaRemota]', function() {
    var msg = '';
    if ($('[id$=txtUsernameRS]').val().length === 0) {
        msg += 'Username obbligatoria \n';
    }
    if ($('[id$=txtPasswordRS]').val().length === 0) {
        msg += 'Password obbligatoria \n';
    }
    if ($('[id$=txtOtpRS]').val().length === 0) {
        msg += 'OTP obbligatorio \n';            
    }
    if (msg.length > 0) {
        alert(msg);
        return false;
    }
});
</script>--%>
    

    <div style="display: none">
        <input type="hidden" id="hdnFile" value='' />
        <asp:HiddenField runat="server" ID="hdnDataToSign" Value='' />
        <asp:HiddenField runat="server" ID="hdnSignedData" />
        <asp:HiddenField ID="hdnFirmaInCorso" runat="server" />
    </div>

    <div class="dBox" style="width=100%">
            <div class="separatore">TEST DELLA FIRMA DIGITALE</div>
        <br />
        <div style="padding:10px;">
            <div>
                Il test consiste nella firma di un documento pdf predefinito, dello stesso formato di quelli ufficiali generati dal sistema al momento del rilascio delle pratiche.<br />
                Se il test viene superato comparirà l'avviso "Documento firmato con successo" e successivamente sarà possibile salvare il file sul computer dell'utente.<br />
                A questo punto sarà possibile aprirlo e prendere visione delle informazioni della firma.
                <br />
                <br />
                La firma remota attualmente funziona solo ed esclusivamente se rilasciata da <b>Aruba</b>. <br />
                Nel caso in cui la firma remota sia stata acquistata direttamente da Aruba e non emessa da Regione Marche, utilizzare il dominio rilasciato dal fornitore.<br />
                Nel caso in cui la firma remota sia stata emessa da Regione Marche, <b>NON</b> è necessario compilare il dominio.<br />
            </div>
        </div>
        <div style="padding:10px;">
            <div>
                <div style="padding-bottom:5px">
                    <label for="txtUsernameRS" style="font-weight:bold;" id="lblUserRS">Username: </label><br />
                    <input type="text" id="txtUsernameRS" name="txtUsernameRS" runat="server" style="width: 150px;" />
                    <asp:RequiredFieldValidator runat="server" Text="*" ControlToValidate="txtUserNameRS" ID="vldTxtUsernameRS" ErrorMessage="Username obbligatoria" />
                </div>
                <div style="padding-bottom:5px">
                    <label for="txtPasswordRS" style="font-weight:bold;" id="lblPassRS">Password: </label><br />
                    <input type="password" id="txtPasswordRS" name="txtPasswordRS" runat="server" style="width: 120px;" /> 
                    <asp:RequiredFieldValidator runat="server" Text="*" ControlToValidate="txtPasswordRS" ID="vldTxtPasswordRS" ErrorMessage="Password obbligatoria" />
                </div>
                <div style="padding-bottom:5px">
                    <label for="txtOtpRS" style="font-weight:bold;" id="lblOtpRS">OTP: </label><br />
                    <input type="text" id="txtOtpRS" name="txtOtpRS" runat="server" style="width: 120px;" />
                    <asp:RequiredFieldValidator runat="server" Text="*" ControlToValidate="txtOtpRS" ID="vldTxtOtpRS" ErrorMessage="OTP obbligatorio"/>
                </div>
                <div>
                    <label for="txtDominioRS" style="font-weight:bold;">Dominio: </label><br />
                    <input type="text" id="txtDominioRS" name="txtDominioRS" runat="server" style="width: 120px;" />
                </div>
                <div style="padding-top: 10px; padding-bottom: 10px;">
                    <Siar:Button ID="btnFirmaRemota" runat="server" style="width:180px;" Text="Firma documento di test" OnClick="btnFirmaRemota_Click" />
                </div>
                <div align="center" id="divBottoni" runat="server" visible="false">
                    <h3>
                        <asp:Label ID="lblfCorretti" runat="server" Text="Il file è stato firmato correttamente."></asp:Label>
                    </h3>
                    <br />
                    <asp:Button ID="btnSALVA" OnClick="btnSALVA_Click" class="Button" Text="Visualizza" ToolTip="Visualizza la versione firmata del documento." CausesValidation="false" runat="server" Width="150px" />
                </div>
            </div>
        </div>
    </div>
    <br />

    <div class="dBox" style="width=100%">
        <div class="separatore">TEST DELLA FIRMA ESTERNA</div>
        <br />
         <div style="padding:10px;">
             <div>
                Il test consiste nello scaricare un documento con applicato un certificato della Regione Marche, firmarlo con la propria firma digitale e verificare il file. <br />
                La verifica consiste nel controllare che il file abbia il certificato della Regione Marche e un proprio certificato valido. <br />
                Il documento deve essere firmato in modalità PAdES (firma .pdf). Il file prodotto dal proprio tool di firma avrà estensione .pdf. <br />
                Il sistema NON accetta file firmati in modalità CAdES (con estensione .p7m). <br />
            </div>
         </div>
        <div id="divFirmaEsterna" runat="server" style="padding:10px;">
            <Siar:Button ID="btnScaricaDocumentoFirmaEsterna" runat="server" style="width:250px;" CausesValidation="false" Text="Scarica documento di test firma esterna" OnClick="btnScaricaDocumentoFirmaEsterna_Click" />
            <br />
            <uc4:SNCUploadFileControl ID="ufDocumento" runat="server" AbilitaModifica="true" TipoFile="DocumentoFirmato" />
            <Siar:Button ID="btnFirmaEsternaVerifica" runat="server" style="width:180px;" CausesValidation="false" Text="Verifica firma esterna" OnClick="btnFirmaEsternaVerifica_Click" />
        </div>
    </div>
    
</asp:content>

