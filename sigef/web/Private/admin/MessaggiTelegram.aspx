<%@ Page Async="true" Language="c#" MasterPageFile="~/SiarPage.master" Inherits="web.Private.admin.MessaggiTelegram" CodeBehind="MessaggiTelegram.aspx.cs" %>

<%@ Register Src="~/CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="ucFUC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

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
            min-width: 100px;
            max-width: 100px;
            width: 100px;
            text-align: right;
            vertical-align: middle;
        }

        .value {
            float: right;
            margin-left: 5px;
        }

        .nascondi {
            display: none;
        }

    </style>

    <script type="text/javascript">

        String.prototype.replaceAll = function (search, replacement) {
            var target = this;
            return target.split(search).join(replacement);
        };

        function Encode() {
            var radiovalue = $('[id$=rblTipoMessaggio]').find(":checked").val();

            if (radiovalue == "1") {
                var valueDidascalia = $('[id$=txtDidascalia]').val();
                valueDidascalia = valueDidascalia.replaceAll('<', "&lt;");
                valueDidascalia = valueDidascalia.replaceAll('>', "&gt;");
                $('[id$=txtDidascalia]').val(valueDidascalia);
            }
            else {
                var value = $('[id$=txtMessaggio]').val();
                value = value.replaceAll('<', "&lt;");
                value = value.replaceAll('>', "&gt;");
                $('[id$=txtMessaggio]').val(value);
            }
        }

        function EncodeModifica() {
            var radiovalue = $('[id$=rblTipoModifica]').find(":checked").val();

            if (radiovalue == "1") {
                var valueDidascalia = $('[id$=txtDidascaliaModifica]').val();
                valueDidascalia = valueDidascalia.replaceAll('<', "&lt;");
                valueDidascalia = valueDidascalia.replaceAll('>', "&gt;");
                $('[id$=txtDidascaliaModifica]').val(valueDidascalia);
            }
            else {
                var value = $('[id$=txtTestoModifica]').val();
                value = value.replaceAll('<', "&lt;");
                value = value.replaceAll('>', "&gt;");
                $('[id$=txtTestoModifica]').val(value);
            }
        }

        function changeTipoMessaggio() {
            var radiovalue = $('[id$=rblTipoMessaggio]').find(":checked").val();

            if (radiovalue == "1") {
                $('[id$=divTesto]').hide();
                $('[id$=divFile]').show();
            }
            else {
                $('[id$=divTesto]').show();
                $('[id$=divFile]').hide();
            }
        }

        function changeTipoMessaggioModifica() {
            var radiovalue = $('[id$=rblTipoModifica]').find(":checked").val();

            if (radiovalue == "1") {
                $('[id$=divTestoModifica]').hide();
                $('[id$=divFileModifica]').show();
            }
            else {
                $('[id$=divTestoModifica]').show();
                $('[id$=divFileModifica]').hide();
            }
        }

        function changeFunzione() {
            var radiovalue = $('[id$=rblNuovoModifica]').find(":checked").val();

            if (radiovalue == "1") {
                $('[id$=divNuovo]').hide();
                $('[id$=divModifica]').show();
            }
            else {
                $('[id$=divNuovo]').show();
                $('[id$=divModifica]').hide();
            }
        }

        function readyFn(jQuery) {
            $('[id$=rblTipoMessaggio]').change(changeTipoMessaggio);
            $('[id$=rblTipoMessaggio]').change();

            $('[id$=rblTipoModifica]').change(changeTipoMessaggioModifica);
            $('[id$=rblTipoModifica]').change();

            $('[id$=rblNuovoModifica]').change(changeFunzione);
            $('[id$=rblNuovoModifica]').change();
        }

        function pageLoad() {
            readyFn();
        }

    </script>

    <br />
    <div class="first_elem_block">
        <div class="label"></div>
        <asp:RadioButtonList RepeatDirection="Horizontal" ID="rblNuovoModifica" runat="server">
            <asp:ListItem Selected="True" Text="Nuovo messaggio" Value="0" />
            <asp:ListItem Text="Modifica messaggio" Value="1" />
        </asp:RadioButtonList>
    </div>
    <br />
    <br />

    <div id="divNuovo" runat="server" class="dBox">

        <div class="separatore_big">
            Invia nuovo messaggio
        </div>

        <div style="margin: 15px;">

            <div style="margin-bottom: 15px;">
                E' possibile inviare un messaggio nel canale Telegram del Sigef o nella chat specificata nel campo 'ID Chat' se valorizzato. <br /><br />

                E' possibile invare un messaggio di tipo testuale o di tipo file. <br />
                Il messaggio di testo accetta l'html per formattare il testo (corsivo, grassetto etc).<br />
                Il messaggio di tipo file accetta qualsiasi estensione di file ed è possibile aggiungere una didascalia che accetta l'html per formattare il testo (corsivo, grassetto etc). <br />

                <br />
            </div>

            <div class="first_elem_block">
                <div class="label">ID Chat:</div>
                <div class="value">
                    <Siar:TextBox ID="txtIdChat" runat="server" NomeCampo="ID Chat" Width="190px" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Tipo messaggio:</div>
                <asp:RadioButtonList RepeatDirection="Horizontal" ID="rblTipoMessaggio" runat="server">
                    <asp:ListItem Selected="True" Text="Testo" Value="0" />
                    <asp:ListItem Text="File" Value="1" />
                </asp:RadioButtonList>
            </div>
            <br />

            <div id="divTesto" runat="server">
                <div class="first_elem_block">
                    <div class="label">Testo:</div>
                    <div class="value">
                        <asp:TextBox ID="txtTesto" runat="server" name="Messaggio Telegram" TextMode="MultiLine" Rows="4" Width="500" />
                    </div>
                </div>
            </div>

            <div id="divFile" runat="server">
                <div class="first_elem_block">
                    <div class="label">File:</div>
                    <div class="value">
                        <ucFUC:SNCUploadFileControl ID="ufFileTelegram" runat="server" TipoFile="NonSpecificato" AbilitaModifica="true" />
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <div class="label">Didascalia:</div>
                    <div class="value">
                        <asp:TextBox ID="txtDidascalia" runat="server" name="Didascalia file Telegram" TextMode="MultiLine" Rows="4" Width="500" />
                    </div>
                </div>
            </div>
            
            <br />
            <br />

            <div class="first_elem_block">
                
                <div class="value">
                    <Siar:Button ID="btnInviaMessaggio" runat="server" Modifica="True"
                        OnClick="btnInviaMessaggio_Click" Text="Invia messaggio Telegram"
                        OnClientClick="return Encode();" Width="220px" />
                </div>
            </div>
            <br />

        </div>
    </div>

    <div id="divModifica" runat="server" class="dBox">

        <div class="separatore_big">
            Modifica messaggio 
        </div>

        <div style="margin: 15px;">

            <div style="margin-bottom: 15px;">
                E' possibile modifica un messaggio nel canale Telegram del Sigef o nella chat specificata nel campo 'ID Chat' se valorizzato.
                <br />

                E' possibile modificare un messaggio di tipo testuale o di tipo file. <br />
                Il messaggio di testo accetta l'html per formattare il testo (corsivo, grassetto etc).<br />
                Il messaggio di tipo file accetta qualsiasi estensione di file ed è possibile aggiungere una didascalia che accetta l'html per formattare il testo (corsivo, grassetto etc).
                <br />

                <br />
            </div>

            <div class="first_elem_block">
                <div class="label">ID Chat:</div>
                <div class="value">
                    <Siar:TextBox ID="txtIdChatModifica" runat="server" NomeCampo="ID Chat Modifica" Width="190px" />
                </div>
            </div>
            <br />

            <div class="first_elem_block">
                <div class="label">ID Messaggio:</div>
                <div class="value">
                    <Siar:TextBox ID="txtIdMessageModifica" runat="server" NomeCampo="ID Message Modifica" Width="190px" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Tipo modifica:</div>
                <asp:RadioButtonList RepeatDirection="Horizontal" ID="rblTipoModifica" runat="server">
                    <asp:ListItem Selected="True" Text="Testo" Value="0" />
                    <asp:ListItem Text="File" Value="1" />
                </asp:RadioButtonList>
            </div>
            <br />

            <div id="divTestoModifica" runat="server">
                <div class="first_elem_block">
                    <div class="label">Nuovo testo:</div>
                    <div class="value">
                        <asp:TextBox ID="txtTestoModifica" runat="server" name="Messaggio Telegram Modificato" TextMode="MultiLine" Rows="4" Width="500" />
                    </div>
                </div>
            </div>

            <div id="divFileModifica" runat="server">
                <div class="first_elem_block">
                    <div class="label">File modificato:</div>
                    <div class="value">
                        <ucFUC:SNCUploadFileControl ID="ufFileTelegramModifica" runat="server" TipoFile="NonSpecificato" AbilitaModifica="true" />
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <div class="label">Didascalia modificata:</div>
                    <div class="value">
                        <asp:TextBox ID="txtDidascaliaModifica" runat="server" name="Didascalia file Telegram modificata" TextMode="MultiLine" Rows="4" Width="500" />
                    </div>
                </div>
            </div>

            <br />
            <br />

            <div class="first_elem_block">

                <div class="value">
                    <Siar:Button ID="btnModificaMessaggio" runat="server" Modifica="True"
                        OnClick="btnModificaMessaggio_Click" Text="Modifica messaggio Telegram"
                        OnClientClick="return EncodeModifica();" Width="220px" />
                </div>
            </div>
            <br />

        </div>
    </div>

</asp:Content>
