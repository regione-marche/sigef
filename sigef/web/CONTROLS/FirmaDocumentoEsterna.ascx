<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FirmaDocumentoEsterna.ascx.cs" Inherits="web.CONTROLS.FirmaDocumentoEsterna" %>

<%@ Register Src="~/CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc4" %>

<style type="text/css">
    .first_elem_block {
        /*width: 200px;*/
        display: inline-block;
        *display: inline;
        zoom: 1;
        padding-bottom: 5px;
    }

    .elem_block {
        /*width: 200px;*/
        vertical-align: top;
        display: inline-block;
        *display: inline;
        zoom: 1;
        padding-left: 20px;
        padding-bottom: 5px;
    }

    .paragrafo_light {
        border-bottom: solid 1px #084600;
        font-size: 14px;
    }

    .box_ricerca {
        background-color: #cfcfd6;
        padding: 7px;
    }

    .label {
        display: inline;
        float: left;
        min-width: 200px;
        max-width: 200px;
        width: 200px;
        text-align: right;
        vertical-align: middle;
    }

    .value {
        float: right;
        margin-left: 5px;
    }
</style>

<div id="divFirmaEsternaAruba" runat="server" style="width: 50%; height: 40%; position: absolute; display: none; box-shadow: none;">

    <div style="display: none">
        <asp:HiddenField ID="hdnNomeFile" runat="server" />
        <asp:Button ID="btnPostFirmaDocumento" runat="server" CausesValidation="False" />
    </div>
    
     <div class="dBox" id="divModaleFirma" runat="server" style="width: 100%; height: 100%; overflow-y: auto;">
        <div class="separatore">
                <asp:label ID="lblTitolo" runat="server">FIRMA DIGITALE ESTERNA</asp:label>
        </div>
        <br />

         <div style="padding:10px;">
             <p>
                Con la firma esterna è possibile scaricare il documento con il certificato dell'applicativo, firmare il documento con la propria firma digitale con certificato valido e poi caricarlo per farlo elaborare dal sistema. <br />
                Il documento deve essere firmato in modalità PAdES (firma .pdf). Il file prodotto dal proprio tool di firma avrà estensione .pdf. <br />
                Il sistema NON accetta file firmati in modalità CAdES (con estensione .p7m). <br />
                Il sistema NON accetta il caricamento di un file senza il certificato dell'applicativo e/o con la firma dell'utente non valida. <br />
            </p>
            <br />
            <br />

            <div class="first_elem_block">
                <Siar:Button ID="btnScaricaDocumentoFirmaEsterna" runat="server" style="width:250px;" 
                    Text="Scarica documento da firmare" />
            </div>
            <br />
    
            <div class="first_elem_block" style="margin-top: 15px;">
                Caricare il file con il certificato del server e con la propria firma digitale valida:<br />
                <uc4:SNCUploadFileControl ID="ufDocumentoFirmaEsterna" runat="server" AbilitaModifica="true" TipoFile="DocumentoFirmato" />
            </div>

            <div class="elem_block">
                <div style="margin-top: 20px;">
                    <br />
                    <Siar:Button ID="btnFirmaEsternaVerifica" runat="server"  
                        Text="Testo appoggio"
                        Conferma="Conferma appoggio" />
                </div>
                
            </div>
            <br />
            <br />

            <div style="text-align: right; ">
                <input type="button" class="Button" style="width: 130px" value="Chiudi" onclick="chiudiPopupTemplate();" />
            </div>          
         </div>
     </div>
</div>