<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FirmaDocumentoCovid.ascx.cs" Inherits="web.CONTROLS.FirmaDocumentoCovid" %>


<script type="text/javascript">
    var jdati_firma;


    function initFirmaDocumentoControl() { openFirmaDocumentoControl(); }
    function doFirmaDocumentoPostBack() {
        $('[id$=btnPostFirmaDocumento]').click();
     }
    function closeFirmaDocumentoControl() { $('#tdFirma').html(''); $('#frameDocumento').attr('src', ''); chiudiPopupTemplate(); }
    function annullaFirmaDocumento() {
        jdati_firma = null;
        $('[id$=hdnJsonDatiFirma]').val('');
        $('[id$=hdnDataToSign]').val('');
        $('[id$=hdnSignedData]').val('');
        $('[id$=hdnNomeFile]').val('');
        closeFirmaDocumentoControl();
    }

    function openFirmaDocumentoControl() { getDimensioniVisibili(); $('#frameDocumento').attr('src', getBaseUrl() + 'VisualizzaDocumento.aspx').height(clientHeight - 150); mostraPopupTemplate('divFrontFirmaDocumentoControl', 'divBKFirmaDocumentoControl'); $('#btnFirma2').val('Presa visione informativa e Invio'); $('#div_status').css("visibility", "hidden"); $('#switch_rs').hide(); $('#btnFirma2').removeAttr('disabled'); }
    function getDataSignedBase64(dataManagerObject, length) { var dataSignedBase64 = "", tmp = "", partialDataLimitLength = length; do { tmp = dataManagerObject.getPartialDataSignedBase64(partialDataLimitLength); dataSignedBase64 += tmp; } while (tmp != ""); dataManagerObject.resetGetPartialDataSignedBase64(); return dataSignedBase64; }
    function firmaNuovaApplet() {
        doFirmaDocumentoPostBack();
    }
    function checkFirmatario(applet_firma) { if (jdati_firma.CfFirmatario == '' || jdati_firma.CfFirmatario == null || jdati_firma.StepFirma == 1) return true; var allCertList = applet_firma.getAllCertificateList(); for (var i = 0; i < allCertList.length; i++) if (allCertList[i].indexOf(jdati_firma.CfFirmatario) > 0) return true; return false; }
    function PassaFileFirmato(dataManagerObject) {
        var StringaFilePdf = getDataSignedBase64(dataManagerObject, 1000000); jdati_firma.ContenutoFile = StringaFilePdf; jdati_firma.StepFirma++;
        if ((!jdati_firma.DoppiaFirma) || (jdati_firma.StepFirma == 1 && !confirm('Si vuole procedere alla seconda firma del documento?\nAltrimenti il documento verrà protocollato normalmente.'))) jdati_firma.StepFirma++;
        closeFirmaDocumentoControl(); doFirmaDocumentoPostBack();
    }  
    
   


    function btnFirmaClick() {
            closeFirmaDocumentoControl();
            doFirmaDocumentoPostBack();
            return;
    }



</script>
<style type="text/css">
.col-container {
    display: table;
    width: 100%;
}
.col {
    display: table-cell;
}

.wrapper {
  width: 100%;
}

.row {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  width: 100%;
}

.column {
  display: flex;
  flex-direction: column;
  flex-basis: 100%;
  flex: 1;
  padding: 5px;
}

</style>

<div id="divAppletFirma" runat="server" style="width: 1px; height: 1px">
</div>
<div id="divBKFirmaDocumentoControl" class="divBackGround">
</div>

<div id="divFrontFirmaDocumentoControl" style="width: 900px; position: absolute; display: none; background-color: #E6E6EE; border: #142952 1px solid;">
    <div class="separatore">
        <asp:Label ID="lblTitolo" runat="server" Text="INVIO DEL DOCUMENTO"></asp:Label>
    </div>
    <div id="header" class="wrapper">
        <div class="row">
            <div id="switch_rs" class="column" style="color: #808080; width: 100%; flex: 3; align-items: center;">
                
            </div>
        </div>
        <div class="row">
            <%--<div id="div_status" class="column" style="flex: 0.5;">
                <div>
                    <br />
                    
                    <br />
                    <br />
                    
                </div>
            </div>--%>
            <div id="div_disclaimer" class="column" style="padding: 5px; text-align: justify;">
                <div style="font-size: large;">
                    ATTENZIONE: per completare la presentazione della domanda occorre selezionare il pulsante <b>"Presa visione informativa ed invio"</b>; 
                    <br />
                    <br />
                    Per tornare alla compilazione della domanda premere Annulla.
                </div>
            </div>
            <asp:HiddenField runat="server" ID="hdnDataToSign" />
            <asp:HiddenField runat="server" ID="hdnSignedData" />
            <asp:HiddenField ID="hdnJsonDatiFirma" runat="server" />
            <asp:HiddenField ID="hdnNomeFile" runat="server" />
            <div class="column" style="flex: 0.5;">
                <br />
                <input type="button" id="btnFirma2" class="Button" disabled name="btnFirma2" style="width: 200px;" value="Invia Richiesta Contributo" onclick="btnFirmaClick(); return false;" />
                <br />
                <input type="button" id="btnAnnullaFirma" name="btnAnnullaFirma" class="Button" value="Annulla" onclick="annullaFirmaDocumento();" style="width: 130px" /><br />
                <div align="center" id="divBottoni" runat="server" style="display: none;">
                </div>
            </div>
        </div>
        <div class="row">
            <div class="column" style="flex: 3;">
                <div id="divFirmaInCorso" runat="server" style="display: none; padding: 5px; color: red; text-align: center;">

                </div>
            </div>
        </div>
    </div>
    <div style="display: none">
        <asp:Button ID="btnPostFirmaDocumento" runat="server" CausesValidation="False" />
    </div>
    <iframe id="frameDocumento" style="width: 900px"></iframe>

</div>
