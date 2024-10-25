<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPagamentoFem.ascx.cs" Inherits="web.CONTROLS.ucPagamentoFem" %>

<%@ Register Src="SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="ucUpload" %>

<div id="divPagInv" runat="server" style="width: 57%; height: 96%; position: absolute; display: none; box-shadow: none;">

    <style type="text/css">
        .hide {
            display: none;
        }

        .labelStyle {
            width: 110px;
            float: left;
            text-align: right;
            padding-right: 5px;
            display: block;
            clear: left;
        }

        .fieldset {
            padding: 5px;
        }
    </style>

    <script type="text/javascript">

        function validaDatiPagamento(event) {
            var messaggio_errore = '';
            if ($('[id$=txtData]').val() == '')
                messaggio_errore += "\n- Indicare la data del pagamento.\n";
            if ($('[id$=txtImportoPagamento]').val() == '')
                messaggio_errore += "\n- Indicare l'importo del pagamento.\n";
            if ($('[id$=lstPagamento]').val() == '')
                messaggio_errore += "\n- Indicare il tipo di pagamento.\n";
            if ($('[id$=txtEstremi]').val() == '')
                messaggio_errore += "\n- Indicare gli estremi del pagamento.\n";

            //if ($('[id$=txtImpresaPagamento]').val() == ''
            //    && ($('[id$=txtCuaaModalePagamento]').val() == ''
            //        || $('[id$=txtPivaModalePagamento]').val() == ''
            //        || $('[id$=txtRagioneSocialeModalePagamento]').val() == ''))
            //    messaggio_errore += "\n- Indicare l'impresa nell'apposito campo o nell'apposito modulo.\n";

            if (messaggio_errore != '') {
                alert(messaggio_errore);
                return stopEvent(event);
            }
        }

        function chiudiPopupPagamento() {
            $('[id$=hdnModalePagamentoIdContrattoFem]').val('');
            $('[id$=hdnModalePagamentoIdPagamentoFem]').val('');
            $('[id$=hdnModalePagamentoIdDomanda]').val('');
            $('[id$=hdnModalePagamentoIdUtente]').val('');
            chiudiPopupTemplate();
        }

        function SNCVZCercaImpresa_onselect(obj) {
            if (obj) {
                if (SNCZVElement.id.indexOf('modaleContratto') !== -1) { // se da modale contratto
                    $('[id$=hdnModaleContrattoIdImpresa]').val(obj.IdImpresa);
                    $('[id$=txtImpresaContratto_text]').val(obj.RagioneSociale);
                } else { //se da modale pagamento
                    $('[id$=hdnModalePagamentoIdImpresa]').val(obj.IdImpresa);
                    $('[id$=txtImpresaPagamento_text]').val(obj.RagioneSociale);
                }
            }
            else
                alert('L`elemento selezionato non è valido.');
        }

        function SNCVZCercaImpresa_onprepare() {
            //$('[id$=hdnModalePagamentoIdImpresa]').val('');
        }

        function MostraNascondiImpresaModalePagamento() {
            var div_impresa = $('[id$=divModalePagamentoDatiImpresa]');
            var btn_mostra = $('[id$=btnMostraNascondiImpresaModalePagamento]')[0];

            if (div_impresa[0].style.display === 'none') {
                div_impresa.show("fast");
                btn_mostra.value = 'Nascondi aggiungi impresa';
            } else {
                div_impresa.hide("fast");
                btn_mostra.value = 'Mostra aggiungi impresa';
            }
        }

    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnModalePagamentoIdContrattoFem" Value="false" runat="server" />
        <asp:HiddenField ID="hdnModalePagamentoIdPagamentoFem" Value="false" runat="server" />
        <asp:HiddenField ID="hdnModalePagamentoIdDomanda" Value="false" runat="server" />
        <asp:HiddenField ID="hdnModalePagamentoIdUtente" Value="false" runat="server" />
        <asp:HiddenField ID="hdnModalePagamentoIdImpresa" Value="false" runat="server" />
    </div>

    <div id="divPagamento" class="dBox" style="width: 100%; height: 100%;">
        <div style="overflow: auto; width: 100%; height: 90%;">
            <div class="separatore_light">
                Pagamento:
            </div>
            <br />

            <div style="padding: 0px 10px 10px 10px;">
                <div class="paragrafo">
                    Dati pagamento:
                </div>
                <br />

                <div class="fieldset">
                    <asp:Label ID="IdContrattoLabel" Text="Id contratto:" runat="server" CssClass="labelStyle" />
                    <Siar:IntegerTextBox ID="txtIdContratto" runat="server" Width="100px" ReadOnly="true" />
                </div>

                <div class="fieldset">
                    <asp:Label ID="DataLabel" Text="Data:" runat="server" CssClass="labelStyle" />
                    <Siar:DateTextBox ID="txtData" runat="server" Width="100px" />
                </div>

                <div class="fieldset">
                    <asp:Label ID="ImportoPagamentoLabel" Text="Importo:" runat="server" CssClass="labelStyle" />
                    <Siar:CurrencyBox ID="txtImportoPagamento" runat="server" Width="100px" />
                </div>

                <div class="fieldset">
                    <asp:Label ID="TipoPagamentoLabel" Text="Tipo pagamento:" runat="server" CssClass="labelStyle" />
                    <Siar:ComboSql ID="lstPagamento" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_PAGAMENTO=1"
                        DataTextField="DESCRIZIONE" DataValueField="COD_TIPO" NomeCampo="Tipo pagamento" Width="400px">
                    </Siar:ComboSql>
                </div>

                <div class="fieldset">
                    <asp:Label ID="EstremiLabel" Text="Estremi:" runat="server" CssClass="labelStyle" />
                    <Siar:TextBox ID="txtEstremi" runat="server" Width="400px" />
                </div>

                <div class="fieldset">
                    <asp:Label ID="UfPagamentoLabel" Text="Specificare il file digitale relativo al pagamento:" runat="server" CssClass="labelStyle" />
                    <ucUpload:SNCUploadFileControl ID="ufPagamento" runat="server" TipoFile="Documento" AbilitaModifica="true" />
                </div>

                <div class="fieldset">
                    <asp:Label ID="ImpresaPagamentoLabel" Text="Impresa:" runat="server" CssClass="labelStyle" />
                    <Siar:TextBox ID="txtImpresaPagamento" runat="server" Width="440px" />
                </div>

                <div class="fieldset">
                    <div id="labelModuloImpresaPagamento" runat="server">
                        Se si volesse inserire un impresa non presente a sistema, è possibile aggiungerla dal modulo premendo il pulsante sottostante.<br />
                        Se sia il modulo che il campo sono compilato si darà priorità al modulo.
                    </div>
                    <br />
                    <asp:Label ID="MostraLabelPagamento" Text=" " runat="server" CssClass="labelStyle" />
                    <asp:Button ID="btnMostraNascondiImpresaModalePagamento" runat="server" CausesValidation="false" CssClass="Button" Width="200px"
                        Text="Mostra aggiungi impresa" OnClientClick="javascript:MostraNascondiImpresaModalePagamento(); return false;" />
                </div>
                <br />

                <div id="divModalePagamentoDatiImpresa" runat="server" style="display: none;">
                    <div class="paragrafo">
                        Dati impresa:
                    </div>

                    <div class="fieldset">
                        <asp:Label ID="CodiceFiscaleLabel" Text="Codice fiscale:" runat="server" CssClass="labelStyle" />
                        <Siar:TextBox ID="txtCuaaModalePagamento" runat="server" Width="160px" TextAlign="right" />
                    </div>

                    <div class="fieldset">
                        <asp:Label ID="PartitaIvaLabel" Text="Partita iva:" runat="server" CssClass="labelStyle" />
                        <Siar:TextBox ID="txtPivaModalePagamento" runat="server" Width="160px" TextAlign="right" />
                    </div>

                    <div class="fieldset">
                        <asp:Label ID="RagioneSocialeLabel" Text="Ragione sociale:" runat="server" CssClass="labelStyle" />
                        <Siar:TextBox ID="txtRagioneSocialeModalePagamento" runat="server" Width="440px" TextAlign="right" />
                    </div>
                </div>
            </div>
        </div>

        <br style="clear: both;" />

        <div id="divButton" style="text-align: center;">
            <Siar:Button ID="btnSalvaPagamento" runat="server" Text="Salva" Width="130px" OnClick="btnSalvaPagamento_Click" OnClientClick="return validaDatiPagamento(event);" />
            <Siar:Button ID="btnEliminaPagamento" runat="server" OnClick="btnEliminaPagamento_Click" CausesValidation="False"
                Text="Elimina" Width="130px" Conferma="Attenzione! Eliminare il pagamento selezionato?" />
            <input type="button" class="Button" style="width: 130px" value="Chiudi" onclick="chiudiPopupPagamento();" />
        </div>
    </div>

    <br style="clear: both;" />
</div>
