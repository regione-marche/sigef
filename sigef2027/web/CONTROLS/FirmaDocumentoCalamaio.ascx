<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FirmaDocumentoCalamaio.ascx.cs" Inherits="web.CONTROLS.FirmaDocumentoCalamaio" %>

<script type="text/javascript">
    var jdati_firma;

    function initFirmaDocumentoControl() { jdati_firma = eval('(' + $('[id$=hdnJsonDatiFirma]').val() + ')'); if (jdati_firma != null && typeof (jdati_firma) != 'undefined') { openFirmaDocumentoControl(); } }
    function doFirmaDocumentoPostBack() {
        $('[id$=hdnJsonDatiFirma]').val(sjsConvertiOggettoToJsonString(jdati_firma));
        $('[id$=btnPostFirmaDocumento]').click();
     }
    function closeFirmaDocumentoControl() { $('#tdFirma').html(''); $('#frameDocumento').attr('src', ''); chiudiPopupTemplate(); }
    function annullaFirmaDocumento() {
        jdati_firma = null;
        $('[id$=hdnJsonDatiFirma]').val('');
        $('[id$=hdnDataToSign]').val('');
        $('[id$=hdnSignedData]').val('');
        $('[id$=hdnNomeFile]').val('');
        $('[id$=txtUsernameRS]').val('');
        $('[id$=txtPasswordRS]').val('');
        $('[id$=txtOtpRS]').val('');
        closeFirmaDocumentoControl();
    }
    function openFirmaDocumentoControl() { getDimensioniVisibili(); $('#frameDocumento').attr('src', getBaseUrl() + 'VisualizzaDocumento.aspx').height(clientHeight - 250); mostraPopupTemplate('divFrontFirmaDocumentoControl', 'divBKFirmaDocumentoControl'); if (jdati_firma.FirmaObbligatoria == false) { $('#btnFirma2').val('Invia documento al protocollo'); $('#div_status').css("visibility", "hidden"); $('#div_disclaimer').css("visibility", "hidden"); $('#switch_rs').hide(); $('#btnFirma2').removeAttr('disabled');} }
    function getDataSignedBase64(dataManagerObject, length) { var dataSignedBase64 = "", tmp = "", partialDataLimitLength = length; do { tmp = dataManagerObject.getPartialDataSignedBase64(partialDataLimitLength); dataSignedBase64 += tmp; } while (tmp != ""); dataManagerObject.resetGetPartialDataSignedBase64(); return dataSignedBase64; }
    function firmaNuovaApplet() {
        $('[id$=hdnJsonDatiFirma]').val(sjsConvertiOggettoToJsonString(jdati_firma));
        doFirmaDocumentoPostBack();
    }
    function checkFirmatario(applet_firma) { if (jdati_firma.CfFirmatario == '' || jdati_firma.CfFirmatario == null || jdati_firma.StepFirma == 1) return true; var allCertList = applet_firma.getAllCertificateList(); for (var i = 0; i < allCertList.length; i++) if (allCertList[i].indexOf(jdati_firma.CfFirmatario) > 0) return true; return false; }
    function PassaFileFirmato(dataManagerObject) {
        var StringaFilePdf = getDataSignedBase64(dataManagerObject, 1000000); jdati_firma.ContenutoFile = StringaFilePdf; jdati_firma.StepFirma++;
        if ((!jdati_firma.DoppiaFirma) || (jdati_firma.StepFirma == 1 && !confirm('Si vuole procedere alla seconda firma del documento?\nAltrimenti il documento verrà protocollato normalmente.'))) jdati_firma.StepFirma++;
        closeFirmaDocumentoControl(); doFirmaDocumentoPostBack();
    }  
    
    var dataToSignBase64 = '<%# dataToSign%>'; 
    var hostCalamaio = '<%= System.Configuration.ConfigurationManager.AppSettings["Calamaio.LocalUrl"]  %>'; 
    var serverCalamaio = '<%= System.Configuration.ConfigurationManager.AppSettings["Calamaio.ServerUrl"] %>'; 
    var runningSign = false;

    var Base64 = {
        characters: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=",

        encode: function(string) {
            var characters = Base64.characters;
            var result = '';

            var i = 0;
            do {
                var a = string.charCodeAt(i++);
                var b = string.charCodeAt(i++);
                var c = string.charCodeAt(i++);

                a = a ? a : 0;
                b = b ? b : 0;
                c = c ? c : 0;

                var b1 = (a >> 2) & 0x3F;
                var b2 = ((a & 0x3) << 4) | ((b >> 4) & 0xF);
                var b3 = ((b & 0xF) << 2) | ((c >> 6) & 0x3);
                var b4 = c & 0x3F;

                if (!b) {
                    b3 = b4 = 64;
                } else if (!c) {
                    b4 = 64;
                }

                result += Base64.characters.charAt(b1) + Base64.characters.charAt(b2) + Base64.characters.charAt(b3) + Base64.characters.charAt(b4);

            } while (i < string.length);

            return result;
        },

        decode: function(string) {
            var characters = Base64.characters;
            var result = '';

            var i = 0;
            do {
                var b1 = Base64.characters.indexOf(string.charAt(i++));
                var b2 = Base64.characters.indexOf(string.charAt(i++));
                var b3 = Base64.characters.indexOf(string.charAt(i++));
                var b4 = Base64.characters.indexOf(string.charAt(i++));

                var a = ((b1 & 0x3F) << 2) | ((b2 >> 4) & 0x3);
                var b = ((b2 & 0xF) << 4) | ((b3 >> 2) & 0xF);
                var c = ((b3 & 0x3) << 6) | (b4 & 0x3F);

                result += String.fromCharCode(a) + (b ? String.fromCharCode(b) : '') + (c ? String.fromCharCode(c) : '');

            } while (i < string.length);

            return result;
        }
    };
    
    var calamaioActive = false;
    var calamaioSuccess = function (result) {
        calamaioActive = true;
        $('#serviceStatus').text('ATTIVO');
        $('#serviceStatus').css('color', 'green');
        $('#btnStart').attr('disabled', 'disabled');

        if (!runningSign) {
            $('#btnFirma2').removeAttr('disabled');
        }
        //$('#btnFirma2').removeAttr('disabled'); // A
    };

    var calamaioError = function (xhr, status, error) {
        calamaioActive = false;
        $('#serviceStatus').text('OFFLINE');
        $('#serviceStatus').css('color', 'red');
        if (typeof jdati_firma !== 'undefined' && jdati_firma.FirmaObbligatoria == true) {
            $('#btnFirma2').attr('disabled', 'disabled');
        }
        else {
            $('#btnFirma2').removeAttr('disabled');
        }
        $('#btnStart').removeAttr('disabled'); 
    };

    $(document).ready(function() {
       
        function CheckCalamaio(async) {
            if ($('#divFrontFirmaDocumentoControl')[0].style.display !== 'none') {
                $.ajax(
                    {
                        async: async, 
                        url: hostCalamaio + '/status',
                        type: 'POST',
                        contentType: false,
                        cache: false,
                        processData: false,
                        global: false,
                        success: calamaioSuccess,
                        error: calamaioError
                    });
            }
        }

        setInterval(function () {
            CheckCalamaio(true);
        }, 5000);

    });


    function StartCalamaio() {
        window.open(serverCalamaio + '/calamaioresources/calamaio.jnlp');
    };


    function LogResult(esito, esitoDetail) {
        var result = Base64.decode($('#<%=hdnDataToSign.ClientID%>').val());
        var xmlDocRes = $($.parseXML(result));
        var user = xmlDocRes.find("userCode").text();
        var docId = $('#<%=hdnNomeFile.ClientID%>').val();
        var tipoDocumento = docId.substr(0, docId.indexOf('-'));
        var parametriDocumento = docId.substr(docId.indexOf('-') + 1);
        var docObj = '{ "TipoDocumento": "' + tipoDocumento + '", "ParametriDocumento": "' + parametriDocumento + '", "Operatore": "' + user + '", "TipoFirma": "client", "Esito": "' + esito + '", "DettaglioEsito": "' + esitoDetail + '" }';
        var baseUrl = '<%= ResolveUrl("~/") %>' + "controls/SignLogger.aspx";
        $.ajax({
            async: true,
            type: "POST",
            url: baseUrl,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: docObj,
            success: function (msg) {

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    };

    function FirmaCalamaio(dataToSign, fnSuccess) {
        runningSign = true;
        $('#<%=divFirmaInCorso.ClientID%>').show();
        $('#btnSwitchRs').attr('disabled', 'disabled');
        dataToSignBase64 = Base64.decode($('#<%=hdnDataToSign.ClientID%>').val());
        if (dataToSignBase64 != "") {
            $.ajax(
                {
                    url: hostCalamaio + '/sign',
                    type: 'POST',
                    data: dataToSignBase64,
                    contentType: false,
                    cache: false,
                    processData: false,
                    dataType: 'text',
                    success: function(result) {
                        var xmlDoc = $($.parseXML(result));
                        if (xmlDoc.find('signResult').text() == 'Success') {
                            runningSign = false;
                            var signed = $(xmlDoc.find('documentData')[0]).text();
                            jdati_firma.ContenutoFile = signed;
                            jdati_firma.StepFirma = 2;
                            LogResult("OK", "firma effettuata con successo");
                            fnSuccess();
                        } else {
                            runningSign = false;
                            var errore = xmlDoc.find('error').text();
                            LogResult("KO", errore);
                            alert("Si è verificato il seguente errore durante la firma in calamaio: " + errore);
                            $('#btnFirma2').removeAttr('disabled');
                            $('#<%=divFirmaInCorso.ClientID%>').hide();
                            $('#btnSwitchRs').removeAttr('disabled');
                        }
                    },
                    error: function (xhr, status, error) {
                        runningSign = false;
                        LogResult("KO", error);
                        alert(status);
                        $('#btnFirma2').removeAttr('disabled');
                        $('#<%=divFirmaInCorso.ClientID%>').hide();
                        $('#btnSwitchRs').removeAttr('disabled');
                    }
                });
                return true;
            }
            else {
                alert("nessun file da firmare");
                runningSign = false;
                return false;
            }
        };

    function btnFirmaClick() {
        if (jdati_firma.FirmaObbligatoria == false) {
            jdati_firma.StepFirma = 2;
            closeFirmaDocumentoControl();
            doFirmaDocumentoPostBack();
            return;
        }
        $('#btnFirma2').attr('disabled', 'disabled');
            FirmaCalamaio(null, function() {
                firmaNuovaApplet();   
            });
    }

    function closeRS() {
        closeFirmaDocumentoControl();
        doFirmaDocumentoPostBack();
    }

    function switchSign(sign) {
        //$('#header').hidden=sign;
        //$('#header_rs').hidden = !sign;
        if (sign === 'r') {
            $('#header').hide();
            $('#header_rs').show();
        }
        if (sign === 'c') {
            $('#header').show();
            $('#header_rs').hide();
        }
    }


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

.rowFirma {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  width: 100%;
}

.columnFirma {
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
        <asp:Label ID="lblTitolo" runat="server" Text="FIRMA DIGITALE DEL DOCUMENTO"></asp:Label>
    </div>
    <div id="header" class="wrapper">
        <div class="rowFirma">
            <div id="switch_rs" class="columnFirma" style="color: #808080; width: 100%; flex:3;  align-items:center;" >
                <input type="button" id="btnSwitchRs" onclick="switchSign('r')" class="btn btn-primary py-1" value="Utilizza Firma Digitale Remota" style="height:30px; background:#3f6f3f;" />
            </div>
        </div>
        <div class="rowFirma">
        <div id="div_status" class="columnFirma" style="flex:0.5;">
            <div>
                <br />
                <b>Stato App Calamaio:</b> <span id="serviceStatus" style="color: #FF8C00;">VERIFICA IN CORSO...</span>
                <br />
                <br />
                <input id="btnStart" type="button" value="Scarica / avvia" onclick="StartCalamaio();" class="btn btn-primary py-1" /><br />
            </div>
        </div>
        <div id="div_disclaimer" class="columnFirma" style="padding: 5px; text-align:justify;">
            <div>
                Per effettuare la firma attendere che lo stato della applicazione sia <b>ATTIVO</b>.<br />
                Nel caso in cui lo stato della app di firma sia <b>OFFLINE</b> premere il pulsante <b>Scarica/Avvia</b> per riavviare o installare il tool di firma.
            </div>
        </div>
        <asp:HiddenField runat="server" ID="hdnDataToSign" />
        <asp:HiddenField runat="server" ID="hdnSignedData" />
        <asp:HiddenField ID="hdnJsonDatiFirma" runat="server" />
        <asp:HiddenField ID="hdnNomeFile" runat="server" />
        <div class="columnFirma" style="flex:0.5;">
            <br />
            <input type="button" id="btnFirma2" class="btn btn-secondary py-1" disabled name="btnFirma2" value="Firma e invia al protocollo" onclick="btnFirmaClick(); return false;" />
            <br />
            <input type="button" id="btnAnnullaFirma" name="btnAnnullaFirma" class="btn btn-primary py-1" value="Annulla" onclick="annullaFirmaDocumento();" style="width: 130px" /><br />
            <div align="center" id="divBottoni" runat="server" style="display: none;">
            </div>
        </div>
        </div>
        <div class="rowFirma">
            <div class="columnFirma" style="flex:3;">
                <div id="divFirmaInCorso" runat="server" style="display: none; padding: 5px; color: red; text-align: center;">
                    <b>PROCEDURA DI FIRMA IN CORSO, ATTENDERE</b>
                </div>
            </div>
        </div>
    </div>
    <div id="header_rs" class="wrapper" style="display:none;">
        <div class="rowFirma">
            <div id="switch_cs" class="columnFirma" style="color: #808080; width: 100%; flex:3; align-items:center;" >
            <input type="button" id="btnSwitchCs" onclick="switchSign('c')" class="btn btn-secondary py-1" value="Utilizza Firma Digitale Smartcard/Token USB" />
        </div>
        </div>
         <div class="rowFirma">
        <div class="columnFirma" style="flex:0.5;">
            <div style="padding-bottom:5px">
                <label for="txtUsernameRS" style="font-weight:bold;" id="lblUserRS">Username: </label><br />
                <input type="text" id="txtUsernameRS" name="txtUsernameRS" runat="server" style="width: 150px; height: 30px;" />
                <span style="color:red;">*</span>
            </div>
            <div style="padding-bottom:5px">
                <label for="txtPasswordRS" style="font-weight:bold;" id="lblPassRS">Password: </label><br />
                <input type="password" id="txtPasswordRS" name="txtPasswordRS" runat="server" style="width: 150px; height: 30px;" />
                <span style="color:red;">*</span>
            </div>
            <div style="padding-bottom:5px">
                <label for="txtOtpRS" style="font-weight:bold;" id="lblOtpRS">OTP: </label><br />
                <input type="text" id="txtOtpRS" name="txtOtpRS" runat="server" style="width: 150px; height: 30px;" />
                <span style="color:red;">*</span>
            </div>
            <div>
                <label for="txtDominio" style="font-weight:bold;">Dominio: </label><br />
                <input type="text" id="txtDominio" name="txtDominio" runat="server" style="width: 150px; height: 30px;" />
            </div>
        </div>
         <div class="columnFirma">
             <div>
                <div style="font-weight: bold;">NOTA PER L'UTILIZZO</div>
                La firma remota attualmente funziona solo ed esclusivamente se rilasciata da <b>Aruba</b>. <br />
                Nel caso in cui la firma remota sia stata acquistata direttamente da Aruba e non emessa da Regione Marche, utilizzare il dominio rilasciato dal fornitore.<br />
                Nel caso in cui la firma remota sia stata emessa da Regione Marche, <b>NON</b> è necessario compilare il dominio.<br />
            </div>
        </div>
        <div class="columnFirma" style="flex:0.5;">
            <Siar:Button ID="btnFirmaRemota" runat="server" style="width:180px;" Text="Firma e invia al protocollo" OnClick="btnFirmaRemota_Click" />
            <br />
            <input type="button" id="btnAnnullaFirmaRemota" name="btnAnnullaFirma" class="btn btn-secondary py-1" value="Annulla" onclick="annullaFirmaDocumento();" style="width: 130px" />
        </div>
        </div>
    </div>
    <div style="display: none">
        <asp:Button ID="btnPostFirmaDocumento" runat="server" CausesValidation="False" />
    </div>
    <iframe id="frameDocumento" style="width: 900px"></iframe>

</div>
