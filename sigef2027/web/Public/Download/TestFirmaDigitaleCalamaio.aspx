<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="TestFirmaDigitaleCalamaio.aspx.cs" Inherits="web.Public.Download.TestFirmaDigitaleCalamaio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">

        var dataToSignBase64 = '<%# dataToSign%>';
        var hostCalamaio = '<%= System.Configuration.ConfigurationManager.AppSettings["Calamaio.LocalUrl"]  %>';
        var serverCalamaio = '<%= System.Configuration.ConfigurationManager.AppSettings["Calamaio.ServerUrl"] %>';

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

            if ($('[id$=hdnFirmaInCorso]').val() != "true")
                $('#btnFirma').removeAttr('disabled'); // A
        };

        var calamaioError = function (xhr, status, error) {
            calamaioActive = false;
            $('#serviceStatus').text('OFFLINE');
            $('#serviceStatus').css('color', 'red');
            $('#btnFirma').attr('disabled', 'disabled');
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

        function StartCalamaio() {
            window.open(serverCalamaio + '/calamaioresources/calamaio.jnlp');
        };



        function FirmaCalamaio(dataToSign, fnSuccess) {
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
                                $('#<%=hdnSignedData.ClientID%>').val(Base64.encode(result));
                                fnSuccess();
                            } else {
                                var errore = xmlDoc.find('error').text();
                                alert("Si è verificato il seguente errore durante la firma in calamaio: " + errore);
                            }
                        },
                        error: function (xhr, status, error) {
                            alert(status);
                        }
                    });
                return true;
            }
            else {
                alert("nessun file da firmare");
                return false;
            }
        };

        function btnFirmaClick() {
            $('#btnFirma').attr('disabled', 'disabled');
            $('[id$=hdnFirmaInCorso]').val("true");
            $('#<%=divFirmaInCorso.ClientID%>').show();

            FirmaCalamaio(null, function () {
                $('#<%=divBottoni.ClientID%>').show();
                $('#<%=divFirmaInCorso.ClientID%>').hide();
            })
        }

    </script>

    <div style="display: none">
        <input type="hidden" id="hdnFile" value='' />
        <asp:HiddenField runat="server" ID="hdnDataToSign" Value='' />
        <asp:HiddenField runat="server" ID="hdnSignedData" />
        <asp:HiddenField ID="hdnFirmaInCorso" runat="server" />
    </div>

    <div class="row mt-5">
        <h2>TEST DELLA FIRMA DIGITALE</h2>
        <br />

        <p>
            Il test consiste nella firma di un documento pdf predefinito, dello stesso formato di quelli ufficiali generati dal sistema al momento del rilascio delle pratiche. Se il test viene superato comparirà l'avviso "Documento firmato con successo" e successivamente sarà possibile salvare il file sul computer dell'utente. A questo punto sarà possibile aprirlo e prendere visione della sigla apposta in fondo ad esso che mostra le informazioni della firma.
        </p>
        <p>
            Per iniziare inserire il dispositivo per la firma e premere il pulsante in basso a sinistra per avviare l'applicazione Calamaio. Una volta verificato che l'app sia attiva sarà possibile firmare.

        </p>
        <div class="row" id="header">
            <div class="col-sm-2">
                <label>
                    <b>Stato App Calamaio:</b> <span id="serviceStatus" style="color: #FF8C00;">VERIFICA IN CORSO...</span>
                </label>
                <input id="btnStart" type="button" value="Scarica / avvia" onclick="StartCalamaio();" class="btn btn-secondary py-1" /><br />
            </div>
            <div class="col-sm-8">
                <p>
                    Per effettuare la firma attendere che lo stato della applicazione sia <b>ATTIVO</b>. Nel caso in cui lo stato della app di firma sia <b>OFFLINE</b> premere il pulsante <b>Scarica/Avvia</b> per riavviare o installare il tool di firma.
                </p>
            </div>
            <div class="col-sm-2">
                <div class="col" style="float: right;">
                    <input type="button" id="btnFirma" class="btn btn-secondary" disabled="disabled" name="btnFirma" value="Firma documento di test" onclick="btnFirmaClick(); return false;" />
                    <br />
                    <br />

                </div>
            </div>
        </div>
        <div id="divFirmaInCorso" class="col-sm-12" runat="server" style="display: none; padding: 5px; color: red;">
            <b>PROCEDURA DI FIRMA IN CORSO, ATTENDERE</b>
        </div>

        <div class="col-sm-12" align="center" id="divBottoni" runat="server" style="display: none;">
            <h3>
                <asp:Label ID="lblfCorretti" runat="server" Text="Il file è stato firmato correttamente."></asp:Label>
            </h3>
            <br />
            <asp:Button ID="btnSALVA" OnClick="btnSALVA_Click" class="btn btn-secondary py-1" Text="Visualizza" ToolTip="Visualizza la versione firmata del documento." runat="server" Width="150px" />
        </div>
    </div>

</asp:Content>
