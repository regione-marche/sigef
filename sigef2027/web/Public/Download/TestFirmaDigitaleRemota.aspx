<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="TestFirmaDigitaleRemota.aspx.cs" Inherits="web.Public.Download.TestFirmaDigitaleRemota" %>

<%@ Register Src="~/CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

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

    <div class="row mt-5">
        <h2>TEST DELLA FIRMA DIGITALE</h2>

        <p>
            Il test consiste nella firma di un documento pdf predefinito, dello stesso formato di quelli ufficiali generati dal sistema al momento del rilascio delle pratiche. Se il test viene superato comparirà l'avviso "Documento firmato con successo" e successivamente sarà possibile salvare il file sul computer dell'utente. A questo punto sarà possibile aprirlo e prendere visione delle informazioni della firma.
        </p>
        <p>
            La firma remota attualmente funziona solo ed esclusivamente se rilasciata da <b>Aruba</b>.
        </p>
        <p>
            Nel caso in cui la firma remota sia stata acquistata direttamente da Aruba e non emessa da Regione Marche, utilizzare il dominio rilasciato dal fornitore.<br />
        </p>
        <p>
            Nel caso in cui la firma remota sia stata emessa da Regione Marche, <b>NON</b> è necessario compilare il dominio.<br />
        </p>
        <div class="col-sm-3 form-group">
            <span class="text">
                <label for="<% =txtUsernameRS.ClientID %>" id="lblUserRS">Username: </label>
                <input type="text" id="txtUsernameRS" class="form-control rounded" name="txtUsernameRS" runat="server" />
                <asp:RequiredFieldValidator runat="server" Text="*" ControlToValidate="txtUserNameRS" ID="vldTxtUsernameRS" ErrorMessage="Username obbligatoria" />
            </span>
        </div>
        <div class="col-sm-3 form-group">
            <label for="<% =txtPasswordRS.ClientID %>" id="lblPassRS">Password: </label>
            <input type="password" id="txtPasswordRS" class="form-control rounded" name="txtPasswordRS" runat="server" />
            <asp:RequiredFieldValidator runat="server" Text="*" ControlToValidate="txtPasswordRS" ID="vldTxtPasswordRS" ErrorMessage="Password obbligatoria" />
        </div>
        <div class="col-sm-3 form-group">
            <label for="<% =txtOtpRS.ClientID %>" id="lblOtpRS">OTP: </label>
            <input type="text" id="txtOtpRS" class="form-control rounded" name="txtOtpRS" runat="server" />
            <asp:RequiredFieldValidator runat="server" Text="*" ControlToValidate="txtOtpRS" ID="vldTxtOtpRS" ErrorMessage="OTP obbligatorio" />
        </div>
        <div class="col-sm-3 form-group">
            <label for="<% =txtDominioRS.ClientID %>">Dominio: </label>
            <input type="text" id="txtDominioRS" class="form-control rounded" name="txtDominioRS" runat="server" />
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnFirmaRemota" runat="server" Text="Firma documento di test" OnClick="btnFirmaRemota_Click" />
        </div>
        <div class="col-sm-12" align="center" id="divBottoni" runat="server" visible="false">
            <h3>
                <asp:Label ID="lblfCorretti" runat="server" Text="Il file è stato firmato correttamente."></asp:Label>
            </h3>
            <asp:Button ID="btnSALVA" OnClick="btnSALVA_Click" class="Button" Text="Visualizza" ToolTip="Visualizza la versione firmata del documento." CausesValidation="false" runat="server" Width="150px" />
        </div>
    </div>

    <div class="row mt-5">
        <h2>TEST DELLA FIRMA ESTERNA</h2>
        <p>
            Il test consiste nello scaricare un documento con applicato un certificato della Regione Marche, firmarlo con la propria firma digitale e verificare il file.
        </p>
        <p>
            La verifica consiste nel controllare che il file abbia il certificato della Regione Marche e un proprio certificato valido.
        </p>
        <p>
            Il documento deve essere firmato in modalità PAdES (firma .pdf). Il file prodotto dal proprio tool di firma avrà estensione .pdf.
        </p>
        <p>
            Il sistema NON accetta file firmati in modalità CAdES (con estensione .p7m).
        </p>
        <div id="divFirmaEsterna" class="row pb-5" runat="server">
            <div class="col-sm-12">
                <Siar:Button ID="btnScaricaDocumentoFirmaEsterna" runat="server" CausesValidation="false" Text="Scarica documento di test firma esterna" OnClick="btnScaricaDocumentoFirmaEsterna_Click" />
            </div>
            <div class="col-sm-12 mt-3">
                <uc4:SNCUploadFileControl ID="ufDocumento" runat="server" AbilitaModifica="true" TipoFile="DocumentoFirmato" />
            </div>
            <div class="col-sm-12 mt-3">
                <Siar:Button ID="btnFirmaEsternaVerifica" runat="server" CausesValidation="false" Text="Verifica firma esterna" OnClick="btnFirmaEsternaVerifica_Click" />
            </div>
        </div>
    </div>
</asp:Content>

