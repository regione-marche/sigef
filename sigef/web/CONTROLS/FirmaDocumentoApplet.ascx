<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FirmaDocumentoApplet.ascx.cs" Inherits="web.CONTROLS.FirmaDocumentoApplet" %>

<script type="text/javascript"><!--
    var jdati_firma;
    function initFirmaDocumentoControl() { jdati_firma = eval('(' + $('[id$=hdnJsonDatiFirma]').val() + ')'); if (jdati_firma != null && typeof (jdati_firma) != 'undefined') openFirmaDocumentoControl(); }
    function doFirmaDocumentoPostBack() { $('[id$=hdnJsonDatiFirma]').val(sjsConvertiOggettoToJsonString(jdati_firma)); $('[id$=btnPostFirmaDocumento]').click();}
    function closeFirmaDocumentoControl() { $('#tdFirma').html('');$('#frameDocumento').attr('src','');chiudiPopupTemplate(); }
    function annullaFirmaDocumento() { jdati_firma = null; $('[id$=hdnJsonDatiFirma]').val(''); closeFirmaDocumentoControl(); }
    function openFirmaDocumentoControl() { getDimensioniVisibili(); $('#frameDocumento').attr('src', getBaseUrl() + 'VisualizzaDocumento.aspx').height(clientHeight - 108); mostraPopupTemplate('divFrontFirmaDocumentoControl', 'divBKFirmaDocumentoControl'); if (jdati_firma.FirmaObbligatoria == false) { $('[id$=btnFirmaNuovaApplet]').val('Invia documento al protocollo');} }
    function getDataSignedBase64(dataManagerObject,length) { var dataSignedBase64="",tmp="",partialDataLimitLength=length;do { tmp=dataManagerObject.getPartialDataSignedBase64(partialDataLimitLength);dataSignedBase64+=tmp; } while(tmp!="");dataManagerObject.resetGetPartialDataSignedBase64();return dataSignedBase64; }
    function firmaNuovaApplet() {
        if(jdati_firma.FirmaObbligatoria==false) { jdati_firma.StepFirma=2;closeFirmaDocumentoControl();doFirmaDocumentoPostBack();return; } $('[id$=btnFirmaNuovaApplet]').val('attendere prego...').attr('disabled','disabled');
        var applet_firma=document.getElementById('siarSignApplet');if(!applet_firma||typeof (applet_firma.clearDataToSignBase64)=="undefined") alert('Attenzione! Non è stato possibile caricare l`applet per la firma digitale, si consiglia di ricaricare la pagina (tasto F5).');else {
            applet_firma.clearDataToSignBase64();applet_firma.updateDataToSignBase64(jdati_firma.ContenutoFile);
            if(checkFirmatario(applet_firma)||confirm('Attenzione! La smart card inserita non appartiene al soggetto titolato alla firma del documento. Continuare?')) applet_firma.showSignFrame();
        } $('[id$=btnFirmaNuovaApplet]').val('Firma e invia al protocollo').removeAttr('disabled');
    }
    function checkFirmatario(applet_firma) { if(jdati_firma.CfFirmatario==''||jdati_firma.CfFirmatario==null||jdati_firma.StepFirma==1) return true;var allCertList=applet_firma.getAllCertificateList();for(var i=0;i<allCertList.length;i++) if(allCertList[i].indexOf(jdati_firma.CfFirmatario)>0) return true;return false; }
    function PassaFileFirmato(dataManagerObject) {
        var StringaFilePdf=getDataSignedBase64(dataManagerObject,1000000);jdati_firma.ContenutoFile=StringaFilePdf;jdati_firma.StepFirma++;
        if((!jdati_firma.DoppiaFirma)||(jdati_firma.StepFirma==1&&!confirm('Si vuole procedere alla seconda firma del documento?\nAltrimenti il documento verrà protocollato normalmente.'))) jdati_firma.StepFirma++;
        closeFirmaDocumentoControl();doFirmaDocumentoPostBack();
    }    
//--></script>

<div id="divAppletFirma" runat="server" style="width: 1px; height: 1px">
</div>
<div id="divBKFirmaDocumentoControl" class="divBackGround">
</div>

<div id="divFrontFirmaDocumentoControl" style="width: 900px; position: absolute; display: none">
    <table id="tableIntestazione" class="tableNoTab" style="width: 100%" cellpadding="0"
        cellspacing="0">
        <tr>
            <td class="separatore" colspan="2">
                <asp:Label ID="lblTitolo" runat="server" Text="FIRMA DIGITALE DEL DOCUMENTO"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="testo_pagina" style="padding: 5px;">Nel riquadro in basso compare il documento generato automaticamente dal sistema.
                Prima di firmarlo<br />
                digitalmente è consigliabile assicurarsi della <b>correttezza</b> dello stesso.
                La firma deve essere apposta<br />
                dal <b>soggetto titolato</b> alla sottoscrizione del documento. Inserire la <b>smart
                    card</b> relativa.<br />
                <b>ATTENZIONE!<br />
                LA FIRMA DIGITALE FUNZIONA SOLO CON IL BROWSER INTERNET EXPLORER.</b>
            </td>
            <td align="center" style="height: 80px; width: 250px">
                <table width="100%x" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center">
                            <input id='btnFirmaNuovaApplet' runat="server" type="button" value='Firma e invia al protocollo'
                                class='Button' onclick='firmaNuovaApplet();' style="width: 200px" /><br />
                            <br />
                            <input type="button" class="Button" value="Annulla" onclick="annullaFirmaDocumento();"
                                style="width: 130px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div style="display: none">
        <asp:HiddenField ID="hdnJsonDatiFirma" runat="server" />
        <asp:Button ID="btnPostFirmaDocumento" runat="server" CausesValidation="False" />
    </div>
    <iframe id="frameDocumento" width="900px"></iframe>
</div>
