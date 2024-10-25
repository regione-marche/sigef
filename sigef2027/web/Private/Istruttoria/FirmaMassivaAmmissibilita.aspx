<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="FirmaMassivaAmmissibilita.aspx.cs" Inherits="web.Private.Istruttoria.FirmaMassivaAmmissibilita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <%--    <style type="text/css">
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
    </style>--%>

    <script type="text/javascript">

        var dataToSignBase64 = '<%# dataToSign%>';
        var hostCalamaio = '<%= System.Configuration.ConfigurationManager.AppSettings["Calamaio.LocalUrl"]  %>';
        var serverCalamaio = '<%= System.Configuration.ConfigurationManager.AppSettings["Calamaio.ServerUrl"] %>';
        var runningSign = false;

        var Base64 = {
            characters: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=",

            encode: function (string) {
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

            decode: function (string) {
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
        };

        var calamaioError = function (xhr, status, error) {
            calamaioActive = false;
            $('#serviceStatus').text('OFFLINE');
            $('#serviceStatus').css('color', 'red');
            $('#btnFirma2').attr('disabled', 'disabled');
            $('#btnStart').removeAttr('disabled'); // A
        };

        $(document).ready(function () {

            function CheckCalamaio(async) {
                $.ajax(
                    {
                        async: async, // sincrona perchè devo aspettare di sapere se il servizio è attivo per far partire la firma
                        url: hostCalamaio + '/status',
                        //url: 'http://localhost:10200/status',
                        type: 'POST',
                        contentType: false,
                        cache: false,
                        processData: false,
                        global: false,
                        success: calamaioSuccess,
                        error: calamaioError
                    });
            }

            setInterval(function () {
                CheckCalamaio(true);
            }, 5000);
        });

        function doFirmaDocumentoPostBack() {
            $('#<%=btnPostFirmaDocumento.ClientID%>').click();
            $('#<%=divFirmaInCorso.ClientID%>').hide();
        }

        function StartCalamaio() {
            window.open(serverCalamaio + '/calamaioresources/calamaio.jnlp');
        };

        function LogResult(esito, esitoDetail) {
            var result = Base64.decode($('#<%=hdnDataToSign.ClientID%>').val());
            var xmlDocRes = $($.parseXML(result));
            var user = xmlDocRes.find("userCode").text();
            var tipoDocumento = 'FirmaMassivaAmmissibilita';
            var parametriDocumento = $('#<%=hdnIdProgettiFirma.ClientID%>').val();
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
                        success: function (result) {
                            var xmlDoc = $($.parseXML(result));
                            if (xmlDoc.find('signResult').text() == 'Success') {
                                runningSign = false;
                                $('#<%=hdnSignedData.ClientID%>').val(Base64.encode(result));
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
            $('#btnFirma2').attr('disabled', 'disabled');

            FirmaCalamaio(null, doFirmaDocumentoPostBack);
        }

        function btnFirmaMassivaClick() {
            $('[id$=btnFirmaMassivaAmmissibilita]').click();
        }

        function selezionaProgetto(idProgetto) {
            $('[id$=hdnIdProgetto]').val($('[id$=hdnIdProgetto]').val() == idProgetto ? '' : idProgetto);
            $('[id$=btnVaiAChecklist]').click();
        }

        function switchSign(sign) {
            if (sign === 'r') {
                $('[id$=header]').hide();
                $('[id$=header_remota]').show();
            }
            if (sign === 'c') {
                $('[id$=header]').show();
                $('[id$=header_remota]').hide();
            }
        }

        function annullaFirmaDocumento() {
            jdati_firma = null;
            $('[id$=hdnJsonDatiFirma]').val('');
            $('[id$=hdnDataToSign]').val('');
            $('[id$=hdnSignedData]').val('');
            $('[id$=txtUsernameRS]').val('');
            $('[id$=txtPasswordRS]').val('');
            $('[id$=txtOtpRS]').val('');
            $('[id$=hdnIdProgettiFirma]').val('');
            location.reload();
        }

    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnDataToSign" runat="server" />
        <asp:HiddenField ID="hdnSignedData" runat="server" />
        <asp:HiddenField ID="hdnJsonDatiFirma" runat="server" />
        <asp:HiddenField ID="hdnIdProgetto" runat="server" />
        <asp:HiddenField ID="hdnIdProgettiFirma" runat="server" />
        <Siar:Button ID="btnPostFirmaDocumento" runat="server" OnClick="btnProtocolla_Click" />
        <Siar:Button runat="server" ID="btnFirmaMassivaAmmissibilita" Text="Firma massivamente e invia al protocollo" OnClick="btnFirmaMassivaAmmissibilita_Click" />
        <asp:Button ID="btnVaiAChecklist" runat="server" CausesValidation="False" OnClick="btnVaiAChecklist_Click" />
        <asp:HiddenField runat="server" ID="hdnMaxDocumentiFirma" Value="5" />
        <asp:HiddenField ID="test_locale" runat="server" Value="false" />
    </div>
    <div class="row py-5">
        <h2 class="pb-5">Firma massiva ammissibilità</h2>
        <p>
            L'elenco contiene tutte le domande di competenza dell'operatore in fase di istruttoria di ammissibilità che possono essere firmate.<br />
            Non vengono mostrate le domande per cui è presente un comitato di valutazione e quelle a cui sono stati aggiunti allegati in istruttoria.
            <br />
            I requisiti manuali dovranno essere compilati necessariamente prima di firmare. In caso contrario l'esito della checklist sarà negativo e le domande verranno escluse dalla firma massiva.
            <br />
            <br />
            Per firmare massivamente selezionare una o più domande (<b>massimo <%= hdnMaxDocumentiFirma.Value %></b>) e firmare tramite l'apposito pulsante.
        </p>
        <div class="col-sm-12">
            <Siar:DataGridAgid ID="dgFirmeAmmissibilita" CssClass="table table-striped" runat="server" AutoGenerateColumns="false" OnItemDataBound="dgFirmeAmmissibilita_ItemDataBound">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="IdBando" HeaderText="Id bando">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdBando" HeaderText="Descrizione">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id domanda">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PartitaIva" HeaderText="Partita iva/Codice fiscale">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="RagioneSociale" HeaderText="Ragione sociale"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Comune" HeaderText="Sede">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Esito verifica requisiti">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdProgetto" ButtonText="Vai alla checklist" JsFunction="selezionaProgetto">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumn>
                    <Siar:CheckColumn DataField="IdProgetto" Name="chkDaFirmare" HeaderSelectAll="true">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:CheckColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div id="header" runat="server" class="row">
            <div class="col-sm-12 text-center mb-5">
                <input type="button" id="btnSwitchRs" onclick="switchSign('r')" value="Utilizza Firma Digitale Remota" class="btn btn-success py-1" />
            </div>
            <div class="col-sm-4">
                <span><b>Stato App Calamaio:</b> <span id="serviceStatus" style="color: #FF8C00;">VERIFICA IN CORSO...</span></span>
                <input id="btnStart" type="button" value="Scarica / avvia" onclick="StartCalamaio();" class="btn btn-secondary py-1"/>
            </div>
            <div class="col-sm-4">
                <div class="row">
                    <h4>NOTA PER L'UTILIZZO</h4>
                    <p>
                        Per effettuare la firma attendere che lo stato della applicazione sia <b>ATTIVO</b>.<br />
                        Nel caso in cui lo stato della app di firma sia <b>OFFLINE</b> premere il pulsante <b>Scarica/Avvia</b> per riavviare o installare il tool di firma.<br />
                    </p>
                    <div class="col-sm-12" id="divFirmaInCorso" runat="server" style="display: none;">
                        <h5><b>PROCEDURA DI FIRMA IN CORSO, ATTENDERE</b></h5>
                        <p>La procedura può richiedere dei minuti per l'elaborazione e varia a seconda del numero di domande selezionate.</p>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="row">
                    <div class="col-sm-12 mb-5 text-center">
                        <input type="button" id="btnFirma2" class="btn btn-primary py-1" disabled="disabled" name="btnFirma2" value="Firma e invia al protocollo" onclick="btnFirmaMassivaClick(); return false;" />
                    </div>
                    <div class="col-sm-12 mb-5 text-center">
                        <input type="button" id="btnAnnullaFirma" name="btnAnnullaFirma" class="btn btn-secondary py-1" value="Annulla" onclick="annullaFirmaDocumento();" />
                    </div>
                    <div align="center" class="col-sm-12 text-center" id="divBottoni" runat="server" style="display: none;">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="header_remota" runat="server" class="row" style="display: none;">
        <div class="col-sm-12 text-center mb-5">
            <input type="button" id="btnSwitchCs" onclick="switchSign('c')" class="btn btn-success py-1" value="Utilizza Firma Digitale Smartcard/Token USB" style="width: 270px; height: 30px; background: #3f6f3f;" />
        </div>

        <div class="row bd-form" id="header_remota_dati" runat="server">
            <div class="col-sm-3 form-group">
                <label for="txtUsernameRS" style="font-weight: bold;" id="lblUserRS">Username:</label>
                <input type="text" id="txtUsernameRS" name="txtUsernameRS" runat="server" class="form-control" />
                <span style="color: red;">*</span>
            </div>
            <div class="col-sm-3 form-group">
                <label for="txtPasswordRS" style="font-weight: bold;" id="lblPassRS">Password: </label>
                <input type="password" id="txtPasswordRS" name="txtPasswordRS" runat="server" class="form-control" />
                <span style="color: red;">*</span>
            </div>
            <div class="col-sm-3 form-group">
                <label for="txtOtpRS" style="font-weight: bold;" id="lblOtpRS">OTP: </label>
                <input type="text" id="txtOtpRS" name="txtOtpRS" runat="server" class="form-control" />
                <span style="color: red;">*</span>
            </div>
            <div class="col-sm-3 form-group">
                <label for="txtDominioRS" style="font-weight: bold;">Dominio: </label>
                <input type="text" id="txtDominioRS" name="txtDominioRS" runat="server" class="form-control" />
            </div>
            <div class="col-sm-12">
                <h4>NOTA PER L'UTILIZZO</h4>
                <p>
                    La firma remota attualmente funziona solo ed esclusivamente se rilasciata da <b>Aruba</b>.
                                <br />
                    Nel caso in cui la firma remota sia stata acquistata direttamente da Aruba e non emessa da Regione Marche, utilizzare il dominio rilasciato dal fornitore.<br />
                    Nel caso in cui la firma remota sia stata emessa da Regione Marche, <b>NON</b> è necessario compilare il dominio.<br />
                </p>
            </div>
            <div class="col-sm-12 text-center">
                <Siar:Button ID="btnFirmaMassivaRemotaAmmissibilita" runat="server" Text="Firma e invia al protocollo" OnClick="btnFirmaMassivaRemotaAmmissibilita_Click" />
                <input type="button" id="btnAnnullaFirmaRemota" name="btnAnnullaFirma" class="btn btn-secondary py-1" value="Annulla" onclick="annullaFirmaDocumento();" />
            </div>
        </div>
    </div>
</asp:Content>
