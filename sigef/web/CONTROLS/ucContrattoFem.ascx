<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucContrattoFem.ascx.cs" Inherits="web.CONTROLS.ucContrattoFem" %>

<%@ Register Src="SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="ucFU" %>

<div id="divPagInv" runat="server" style="width: 55%; height: 96%; position: absolute; display: none; box-shadow: none;">

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

        function validaDatiContratto(event) {
            var messaggio_errore = '';
            if ($('[id$=txtDataStipula]').val() == '')
                messaggio_errore += "\n- Indicare la data del contratto.\n";
            if ($('[id$=txtImporto]').val() == '')
                messaggio_errore += "\n- Indicare l'importo del contratto.\n";
            //if ($('[id$=txtDataSegnatura]').val() == '')
            //    messaggio_errore += "\n- Indicare la data della segnatura del contratto.\n";
            //if ($('[id$=txtSegnatura]').val() == '')
            //    messaggio_errore += "\n- Indicare la segnatura del contratto.\n";

            //if ($('[id$=txtImpresa]').val() == ''
            //    && ($('[id$=txtCuaaModaleContratto]').val() == ''
            //        || $('[id$=txtPivaModaleContratto]').val() == ''
            //        || $('[id$=txtRagioneSocialeModaleContratto]').val() == ''))
            //    messaggio_errore += "\n- Indicare l'impresa nell'apposito campo o nell'apposito modulo.\n";

            if (messaggio_errore != '') {
                alert(messaggio_errore);
                return stopEvent(event);
            }
        }

        function chiudiPopup() {
            $('[id$=hdnModaleContrattoIdContrattoFem]').val('');
            $('[id$=hdnModaleContrattoIdProgetto]').val('');
            $('[id$=hdnModaleContrattoIdUtente]').val('');
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
            //$('[id$=hdnModaleContrattoIdImpresa]').val('');
        }

        function MostraNascondiImpresaModaleContratto() {
            var div_impresa = $('[id$=divModaleContrattoDatiImpresa]');
            var btn_mostra = $('[id$=btnMostraNascondiImpresaModaleContratto]')[0];

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
        <asp:HiddenField ID="hdnModaleContrattoIdContrattoFem" Value="false" runat="server" />
        <asp:HiddenField ID="hdnModaleContrattoIdProgetto" Value="false" runat="server" />
        <asp:HiddenField ID="hdnModaleContrattoIdDomanda" Value="false" runat="server" />
        <asp:HiddenField ID="hdnModaleContrattoIdUtente" Value="false" runat="server" />
        <asp:HiddenField ID="hdnModaleContrattoIdImpresa" Value="false" runat="server" />
    </div>

    <div id="divContratto" class="dBox" style="width: 100%; height: 100%;">
        <div style="overflow: auto; width: 100%; height: 90%;">
            <div class="separatore_light">
                Contratto:
            </div>
            <br />

            <div style="padding: 0px 10px 10px 10px;">
                <div class="paragrafo" >
                    Dati contratto:
                </div>
                <br />

                <div class="fieldset">
                    <asp:Label ID="NumeroContrattoLabel" Text="Numero:" runat="server" CssClass="labelStyle" />
                    <Siar:TextBox ID="txtNumeroContratto" runat="server" Width="100px" TextAlign="Right" />
                </div>

                <div class="fieldset">
                    <asp:Label ID="ProgettoRiferimentoLabel" Text="Domanda di aiuto di riferimento:" runat="server" CssClass="labelStyle" />
                    <Siar:TextBox ID="txtProgettoRiferimento" runat="server" Width="100px" TextAlign="Right" />
                </div>

                <div class="fieldset">
                    <asp:Label ID="DataStipulaLabel" Text="Data stipula:" runat="server" CssClass="labelStyle" />
                    <Siar:DateTextBox ID="txtDataStipula" runat="server" Width="100px" />
                </div>

                <div class="fieldset">
                    <asp:Label ID="ImportoLabel" Text="Importo contratto €:" runat="server" CssClass="labelStyle" />
                    <Siar:CurrencyBox ID="txtImporto" runat="server" Width="100px" />
                </div>

                <div class="fieldset">
                    <asp:Label ID="DataSegnaturalabel" Text="Data segnatura:" runat="server" CssClass="labelStyle" />
                    <Siar:DateTextBox ID="txtDataSegnatura" runat="server" Width="100px" />
                </div>

                <div class="fieldset">
                    <asp:Label ID="SegnaturaLabel" Text="Segnatura:" runat="server" CssClass="labelStyle" />
                    <Siar:TextBox ID="txtSegnatura" runat="server" Width="440px" />
                </div>

                <div class="fieldset">
                    <asp:Label ID="DescrizioneContrattoLabel" Text="Descrizione:" runat="server" CssClass="labelStyle" />
                    <Siar:TextBox ID="txtDescrizioneContratto" runat="server" Width="440px" />
                </div>

                <div class="fieldset">
                    <asp:label ID="ufContrattoLabel" Text="File del contratto:" runat="server" CssClass="labelStyle" />
                    <ucFU:sncuploadfilecontrol id="ufContratto" runat="server" tipofile="Documento" />
                </div>

                <div class="fieldset">
                    <asp:Label ID="ImpresaLabel" Text="Impresa:" runat="server" CssClass="labelStyle" />
                    <Siar:TextBox ID="txtImpresaContratto" runat="server" Width="440px" />
                </div>

                <div class="fieldset">
                    <div id="labelModuloImpresaContratto" runat="server">
                        Se si volesse inserire un impresa non presente a sistema, è possibile aggiungerla dal modulo premendo il pulsante sottostante.<br />
                        Se sia il modulo che il campo sono compilato si darà priorità al modulo.
                    </div>
                    <br />
                    <asp:Label ID="MostraLabel" Text=" " runat="server" CssClass="labelStyle" />
                    <asp:Button ID="btnMostraNascondiImpresaModaleContratto" runat="server" CausesValidation="false" CssClass="Button" Width="200px"
                        Text="Mostra aggiungi impresa" OnClientClick="javascript:MostraNascondiImpresaModaleContratto(); return false;" />
                </div>
                <br />

                <div id="divModaleContrattoDatiImpresa" runat="server" style="display: none;">
                    <div class="paragrafo">
                        Dati impresa:
                    </div>
                    <br />

                    <div class="fieldset">
                        <asp:Label ID="CodiceFiscaleLabel" Text="Codice fiscale:" runat="server" CssClass="labelStyle" />
                        <Siar:TextBox ID="txtCuaaModaleContratto" runat="server" Width="160px" TextAlign="right" />
                    </div>

                    <div class="fieldset">
                        <asp:Label ID="PartitaIvaLabel" Text="Partita iva:" runat="server" CssClass="labelStyle" />
                        <Siar:TextBox ID="txtPivaModaleContratto" runat="server" Width="160px" TextAlign="right" />
                    </div>

                    <div class="fieldset">
                        <asp:Label ID="RagioneSocialeLabel" Text="Ragione sociale:" runat="server" CssClass="labelStyle" />
                        <Siar:TextBox ID="txtRagioneSocialeModaleContratto" runat="server" Width="440px" TextAlign="right" />
                    </div>
                </div>
            </div>
        </div>

        <br style="clear: both;" />

        <div id="divButton" style="text-align: center;">
            <Siar:Button ID="btnSalvaContratto" runat="server" Text="Salva" Width="130px" OnClick="btnSalvaContratto_Click" OnClientClick="return validaDatiContratto(event);" />
            <Siar:Button ID="btnEliminaContratto" runat="server" OnClick="btnEliminaContratto_Click" CausesValidation="False"
                Text="Elimina" Width="130px" Conferma="Attenzione! Eliminare il contratto selezionato?" />
            <input type="button" class="Button" style="width: 130px" value="Chiudi" onclick="chiudiPopup();" />
        </div>
    </div>

    <br style="clear: both;" />
</div>
