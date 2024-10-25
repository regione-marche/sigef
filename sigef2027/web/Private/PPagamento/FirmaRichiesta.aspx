<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" Inherits="web.Private.PPagamento.FirmaRichiesta" CodeBehind="FirmaRichiesta.aspx.cs" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc4" %>
<%@ Register Src="../../CONTROLS/FirmaDocumentoEsterna.ascx" TagName="ucFirmaEsternaAruba" TagPrefix="uc5" %>
<%@ Register Src="../../CONTROLS/CardPagamento.ascx" TagName="CardPagamento" TagPrefix="uc6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <style type="text/css">

        .positivo {
            color: green;
        }

        .negativo {
            color: red;
        }

    </style>
    <script type="text/javascript"><!--
    function lstCategoria_changed() {
        var tipo_allegato = ''; var items = $('[id$=lstCategoria]').find('option:selected'); if (items.length > 0) tipo_allegato = $(items).attr('optvalue');
        $('[id$=trUploadFile]')[0].style.display = tipo_allegato == 'D' ? '' : 'none';
        $('[id$=trDichiarazioneSostitutiva]')[0].style.display = tipo_allegato == 'S' ? '' : 'none';
    }
    function pulisciCampi() { $('[id$=hdnIdAllegato]').val(''); $('[id$=lstCategoria]').val(''); lstCategoria_changed(); $('[id$=txtDescrizione]').val(''); $('[id$=lstNATipoEnte]').val(''); $('[id$=txtNAEnte_text]').val(''); $('[id$=hdnCodEnte]').val(''); $('[id$=txtNADatadoc_text]').val(''); $('[id$=txtNANumeroDoc_text]').val(''); $('[id$=btnNuovoAllegatoPost]').click(); /*debugger;SNCUFRimuoviFile('ctl00_cphContenuto_ufcNAAllegato');*/ }
    function dettaglioAllegato(idaxp) { $('[id$=hdnIdAllegato]').val(idaxp); $('[id$=btnDettaglioPost]').click(); }
    function eliminaAllegato(ev) { if ($('[id$=hdnIdAllegato]').val() == '') { alert('Non è stato selezionato nessun allegato da eliminare.'); return stopEvent(ev); } if (!confirm('Attenzione! Eliminare l`allegato selezionato?')) return stopEvent(ev); }
    function ctrlCampi(ev) {
        var lst = $('[id$=lstCategoria]'), items = $(lst).find('option:selected'); if ($(lst).val() == '' || items.length == 0) { alert('Selezionare una categoria di allegato.'); return stopEvent(ev); }
        else {
            var optvalue = $(items).attr('optvalue');
            if (optvalue == "S" && ($('[id$=lstNATipoEnte]').val() == '' || $('[id$=txtNAEnte_text]').val() == '' || $('[id$=hdnCodEnte]').val() == '' || $('[id$=txtNADatadoc_text]').val() == '' || $('[id$=txtNANumeroDoc_text]').val() == '')) { alert('Per la categoria di allegato selezionata si richiede di specificare gli estremi del documento.'); return stopEvent(ev); }
            if (optvalue == "D" && $('input[type=hidden][id*=ufcNAAllegato]').val() == '') { alert('Per la categoria di allegato selezionata si richiede di carica il documento digitale o di specificare se il documento sia già stato presentato in una domanda di aiuto precedente.'); return stopEvent(ev); }
            if (optvalue == "C") { alert('L`allegato selezionato selezionato appartiene ad una tipologia non più valida, operazione annullata.'); return stopEvent(ev); }
        }
    }
    function lstNATipoEnte_changed() { $('[id$=txtNAEnte_text]').val(''); $('[id$=hdnCodEnte]').val(''); }
    function SNCVZCercaAmministrazione_onprepare(elem) { SNCZVParams = "{'CodTipoEnte':'" + $('[id$=lstNATipoEnte]').val() + "'}"; }
    function SNCVZCercaAmministrazione_onselect(obj) { $('[id$=txtNAEnte_text]').val(obj.Descrizione); $('[id$=hdnCodEnte]').val($('[id$=lstNATipoEnte]').val() == "CM" ? obj.IdComune : obj.CodEnte); }

    function visualizzaIntegrazioneSingola(id) {
            $('[id$=hdnIdIntegrazioneSingolaSelezionata]').val($('[id$=hdnIdIntegrazioneSingolaSelezionata]').val() == id ? '' : id);
            $('[id$=btnDettaglioPost]').click();
    }

    function DisabilitaLabel() {
        if ($('[id$=ckAttivo]').is(':checked')) {
            $('[id$=txtSegnaturaIns]').attr('readonly', true);
            $('[id$=txtSegnaturaIns]').val('');
        }
        else
            $('[id$=txtSegnaturaIns]').removeAttr('readonly');
    }

    $(document).ready(function () {
        let $el = $('.steppers-nav').clone();
        $('#containerCopiaPulsanti').append($el);
    });

//        function VisualizzaProt() {
//            var segnatura = $('[id$=txtSegnaturaIns]').val() ;
//            sncAjaxCallVisualizzaProtocollo(segnatura);
//            mostraPopupTemplate('divPregresso', 'divBKGMessaggio');
//        }

//--></script>
    <uc6:CardPagamento ID="ucCardPagamento" runat="server" />
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <uc1:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
            </div>
            <div class="steppers-content" aria-live="polite">
                <div style="display: none">
                    <input type="hidden" id="hdnIdAllegato" runat="server" />
                    <input type="hidden" id="hdnCodEnte" runat="server" />
                    <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
                    <asp:Button ID="btnDettaglioPost" runat="server" OnClick="btnDettaglioPost_Click" />
                    <asp:Button ID="btnNuovoAllegatoPost" runat="server" OnClick="btnNuovoAllegatoPost_Click" />
                    <asp:HiddenField ID="hdnIdIntegrazioneSingolaSelezionata" runat="server" />
                </div>
                <div class="row py-5 mx-2" visible="true">
                    <h3 class="pb-5">Dichiarazione degli allegati</h3>
                    <p>
                        Elenco generale degli allegati alla presente domanda di pagamento. Le <b>categorie di documento</b> indicate sono quelle previste dal bando di riferimento e sono suddivise in 3 tipi fondamentali:<b>Supporto cartaceo (C)</b>: tipo non più valido, vecchia modalità di invio documenti in formato cartaceo tramite busta chiusa.<br />
                        <b>Supporto digitale (D)</b>: richiede il caricamento di un documento digitale (sottoscritto digitalmente per le tipologie previste dal bando di gara).
                    </p>
                    <p>
                        <b>Dichiarazione sostitutiva (S)</b>: usata per documenti e/o certificati emessi da una pubblica amministrazione, questa tipologia sostituisce a tutti gli effetti il caricamento di tali documenti ma richiede la specifica dei riferimenti di essi.
                    </p>
                    <p>
                        Per le domande di <b>ANTICIPO</b> si richiede unicamente di inviare l&#39;<b>originale cartaceo della garanzia/polizza fidejussoria</b>, quando questa è prevista dal bando di riferimento.
                    </p>
                    <div id="tbAllegati" class="row bd-form" runat="server" visible="false">
                        <h4 class="pb-5">Nuovo allegato:</h4>
                        <div class="col-sm-12 form-group">
                            <Siar:ComboSql ID="lstCategoria" Label="Selezionare la categoria del documento:" runat="server" OptionalValue="FORMATO" DataTextField="DESCRIZIONE"
                                DataValueField="CODICE">
                            </Siar:ComboSql>
                        </div>
                        <div id="trDichiarazioneSostitutiva" class="row" style="display: none">
                            <div class="col-sm-12 form-group">
                                <Siar:Combo Label="Specificare l'ente:" ID="lstNATipoEnte" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Value="CM">Comune</asp:ListItem>
                                    <asp:ListItem Value="PR">Provincia</asp:ListItem>
                                </Siar:Combo>
                            </div>
                            <div class="col-sm-12 form-group">
                                <Siar:TextBox  Label="Denominazione ente:" ID="txtNAEnte" runat="server" Width="400px" />
                            </div>
                            <div class="col-sm-12 form-group">
                                <Siar:DateTextBox Label="Data di emissione:" ID="txtNADatadoc" runat="server" Width="130px" />
                            </div>
                            <div class="col-sm-12 form-group">
                                <Siar:TextBox  Label="Numero documento:" ID="txtNANumeroDoc" runat="server" Width="150px" />
                            </div>
                        </div>
                        <div id="trUploadFile" class="row" style="display: none">
                            <div class="col-sm-12 form-group">
                                <uc4:SNCUploadFileControl ID="ufcNAAllegato" runat="server" Width="600" Text="Selezionare un documento da caricare" />
                            </div>
                        </div>
                        <div class="col-sm-12 form-group">
                            <Siar:TextArea Label="Breve descrizione: (facoltativa, max 250 caratteri) :" ID="txtDescrizione" runat="server" NomeCampo="Descrizione" Rows="3" MaxLength="250" />
                        </div>
                        <div class="col-sm-12">
                            <Siar:Button ID="btnSalva" Text="Salva" runat="server" CausesValidation="false" Modifica="true"
                                OnClick="btnSalva_Click" OnClientClick="return ctrlCampi(event);" />
                            <Siar:Button ID="btnElimina" Text="Elimina" runat="server" CausesValidation="false"
                                Modifica="true" OnClick="btnDel_Click" OnClientClick="return eliminaAllegato(event);" />
                            <input onclick="pulisciCampi();" type="button" class="btn btn-secondary py-1 m-1" value="Nuovo" />
                        </div>
                        <div class="col-sm-12">
                            <h4 class="pb-5 mt-5">Elenco degli allegati inclusi:</h4>
                            <div id="divDimTotAllegati" runat="server"></div>
                            <Siar:DataGridAgid ID="dgAllegati" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" AllowPaging="true" PageSize="8">
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="TipoAllegato" HeaderText="Formato"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="TipologiaDocumento" HeaderText="Categoria"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="DimensioneFile" HeaderText="Dim. (Kb)" DataFormatString="{0:N0}"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataInserimento" HeaderText="Data inserimento"></asp:BoundColumn>
                                    <Siar:JsButtonColumn Arguments="IdFile" ButtonImage="lente.png" ButtonType="ImageButton"
                                        ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                                    </Siar:JsButtonColumn>
                                    <Siar:JsButtonColumn Arguments="IdAllegato" ButtonImage="config.ico" ButtonType="ImageButton"
                                        ButtonText="Visualizza dettaglio" JsFunction="dettaglioAllegato">
                                    </Siar:JsButtonColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                        <div id="trIntegrazioniRichieste" class="row" runat="server" visible="false">
                            <h4 class="pb-5">Elenco integrazioni da risolvere:</h4>
                            <div class="col-sm-12">
                                <Siar:Button ID="btnSpese" runat="server" OnClick="btnSpese_Click" Text="Spese sostenute" Width="180px" />
                                <Siar:Button ID="btnInvestimenti" runat="server" OnClick="btnInvestimenti_Click" Text="Piano Investimenti" Width="180px" />
                                <Siar:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Indietro" Width="180px" />
                            </div>
                            <div class="col-sm-12">
                                <Siar:DataGridAgid ID="dgIntegrazioni" CssClass="table table-striped" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="15" ShowFooter="true">
                                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                    <Columns>
                                        <asp:BoundColumn DataField="IdSingolaIntegrazione" HeaderText="ID singola integrazione">
                                            <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="DataRichiestaIntegrazioneIstruttore" HeaderText="Data richiesta"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="DescrizioneTipoIntegrazione" HeaderText="Tipo integrazione"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="NoteIntegrazioneIstruttore" HeaderText="Note istruttore"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="SingolaIntegrazioneCompletataIstruttore" HeaderText="Completata istruttore"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="DataRilascioIntegrazioneBeneficiario" HeaderText="Data rilascio beneficiario"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="NoteIntegrazioneBeneficiario" HeaderText="Note beneficiario"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="SingolaIntegrazioneCompletataBeneficiario" HeaderText="Completata beneficiario"></asp:BoundColumn>
                                        <Siar:JsButtonColumn Arguments="IdSingolaIntegrazione" ButtonType="TextButton" ButtonText="Apri" JsFunction="visualizzaIntegrazioneSingola" HeaderText="Apri">
                                        </Siar:JsButtonColumn>
                                    </Columns>
                                </Siar:DataGridAgid>
                            </div>
                        </div>
                        <div id="trDettaglioIntegrazioneSingolaSelezionata" class="row" runat="server" visible="false">
                            <h4 class="pb-5">Dettaglio singola integrazione selezionata:</h4>
                            <h5 class="pb-5">Dati di competenza dell'istruttore:</h5>
                            <div class="form-group col-sm-12">
                                <Siar:DateTextBox Label="Data richiesta:" ID="txtDataRichiesta" runat="server" ReadOnly="true" />
                            </div>
                            <div class="form-group col-sm-12">
                                <Siar:TextBox  Label="Tipo integrazione:" ID="txtTipoIntegrazione" runat="server" ReadOnly="true" />
                            </div>
                            <div class="form-group col-sm-12">
                                <label for="<% =comboCompletataSingolaIntegrazioneDomandaIstruttore.ClientID %>">Integrazione completata:</label>
                                <asp:DropDownList ID="comboCompletataSingolaIntegrazioneDomandaIstruttore" runat="server"
                                    Enabled="False">
                                    <asp:ListItem Text="No" Value="false"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-sm-12">
                                <Siar:TextArea Label="Note integrazione:" ID="txtNoteSingolaIntegrazioneIstruttore" runat="server" NomeCampo="Note singola integrazione"
                                    Obbligatorio="false" Rows="4" ExpandableRows="5" ReadOnly="true" MaxLength="10000" />
                            </div>
                            <h5 class="pb-5">Dati di competenza del beneficiario:</h5>
                            <div class="form-group col-sm-12">
                                <Siar:DateTextBox Label="Data rilascio:" ID="txtDataRilascio" runat="server" Width="120px" />
                            </div>
                            <div class="form-group col-sm-12">

                                <label for="<% =comboCompletataSingolaIntegrazioneDomandaBeneficiario.ClientID %>">Integrazione completata beneficiario:</label>
                                <asp:DropDownList ID="comboCompletataSingolaIntegrazioneDomandaBeneficiario" runat="server">
                                    <asp:ListItem Text="No" Value="false"></asp:ListItem>
                                    <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-sm-12">

                                <Siar:TextArea Label="Note beneficiario:" ID="txtNoteSingolaIntegrazioneBeneficiario" runat="server" NomeCampo="Note singola integrazione beneficiario"
                                    Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" MaxLength="10000" />

                            </div>
                            <div class="col-sm-12">
                                <Siar:Button ID="btnSalvaSingolaIntegrazione" runat="server" OnClick="btnSalvaSingolaIntegrazione_Click"
                                    Text="Salva dati singola integrazione" Width="190px" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row py-5 mx-2" id="tableRilascioDomandaPagamento" runat="server" visible="true">
                    <div id="trPredisposizione" class="col-sm-12" runat="server">
                        <h4 class="pb-5">Predisposizione alla firma della domanda:</h4>
                        <p>
                            <b>FACOLTATIVO</b>: la predisposizione alla firma è la modalità di presentazione della domanda di aiuto per i casi di <b>firma differita.</b> Ovvero questa modalità prevede il congelamento della domanda in tutte le sue sezioni,
                            quindi non piu&#39; modificabile,  in attesa della firma finale da parte del <b>rappresentante legale</b> dell&#39;impresa o di altro soggetto titolato, che potrà eseguire<br />
                            il successivo rilascio da una qualsiasi postazione egli abbia a disposizione. Ciò è utile nei casi in cui il firmatario non può essere presente nella stessa sede in cui si trova l&#39;operatore che compila
                            la domanda. Tale predisposizione può essere sempre annullata <b>prima del rilascio</b> per eseguire correzioni o adeguamenti finali.
                        </p>
                        <div class="col-sm-12">
                            <Siar:Button ID="btnPredisponi" runat="server" Text="Predisponi alla firma"
                                CausesValidation="false" Conferma="Attenzione! Predisporre la domanda di pagamento alla firma da remoto?"
                                OnClick="btnPredisponi_Click" Modifica="False" Enabled="False" />
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <h4 class="pb-5 mt-5">Rilascio della domanda di pagamento</h4>
                        <p>
                            Una volta inseriti tutti i dati obbligatori e compilate tutte le sezioni richieste sarà&nbsp; possibile <strong>firmare digitamente</strong> e <strong>inviare al protocollo regionale</strong> la presente richiesta di pagamento. Tale procedura è definitiva e non sarà più possibile modificare ulteriormente i dati, è quindi consigliato&nbsp;prima <strong>accertarsi della correttezza</strong> degli stessi.
                        </p>
                    </div>
                    <div class="col-sm-12 text-center">
                        <Siar:Button ID="btnFirma" runat="server" CausesValidation="False" Text="Presenta domanda" Enabled="false" OnClick="btnFirma_Click" Conferma="Attenzione, rendere la domanda di pagamento definitiva? Non sarà più possibile modificare i dati"
                            Modifica="True" />
                        <Siar:Button ID="btnFirmaEsterna" runat="server" CausesValidation="False" Text="Scarica e presenta domanda con firma esterna" Enabled="false" OnClick="btnFirmaEsterna_Click" 
                    Modifica="True" />
                        <input type="button" class="btn btn-secondary py-1 m-1" id="btnStampaRicevuta" runat="server" value="Ricevuta di protocollazione"
                            disabled="disabled" />
                    </div>
                    <div class="col-sm-12 text-center" id="rowProtocolliAllegati" runat="server" visible="false">
                        <Siar:Button ID="btnProtocollaAllegati" runat="server" CausesValidation="False" Width="210px"
                            Text="Protocolla allegati" Enabled="false" OnClick="btnProtocollaAllegati_Click"
                            Modifica="True" />
                    </div>
                </div>
                <div class="row py-5 mx-2" id="tableRilascioDomandaPagamentoPregressa" runat="server" visible="false">
                    <h4>Rilascio della domanda di pagamento</h4>
                    <div class="col-sm-12 form-group">
                        <Siar:Button ID="btnInserisciSegnatura" runat="server" CausesValidation="False" Text="Inserisci Segnatura" Enabled="false" OnClick="btnInserisciSegnatura_Click" Conferma="Attenzione, rendere la domanda di pagamento definitiva? Non sarà più possibile modificare i dati"
                            Modifica="true" />
                    </div>
                </div>
                <div id="divPregresso" style="position: absolute; display: none;">
                    <table width="100%" class="tableNoTab">
                        <tr>
                            <td class="separatore">Dati della segnatura della domanda:
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 10px">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 140px">Data:<br />
                                            <Siar:DateTextBox ID="txtData" runat="server" Width="120px" />
                                        </td>
                                        <td style="width: 440px">Segnatura:<br />
                                            <asp:TextBox CssClass="rounded" ID="txtSegnaturaIns" runat="server" Width="400px" />
                                            <%--								<img id="imgSegnatura" runat="server" height="18" src="../../images/lente.png"
									title="Visualizza documento" width="18" onclick="VisualizzaProt();" />--%>
                                        </td>
                                    </tr>
                                    <tr style="display: none">
                                        <td></td>
                                        <td>
                                            <asp:CheckBox ID="ckAttivo" Text="Segnatura non disponibile" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 70px;" colspan="2">
                                            <Siar:Button ID="btnSalvaSegnatura" runat="server" Modifica="true" OnClick="btnSalvaSegnatura_Click"
                                                Text="Salva" Conferma="Attenzione! Una volta resa definitiva, non sarà più possibile modificare i dati. Continuare?" Width="100px" CausesValidation="False" />
                                            <input class="Button" onclick="chiudiPopupTemplate();" style="width: 100px; margin-left: 20px; margin-right: 20px"
                                                type="button" value="Chiudi" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <uc2:FirmaDocumento ID="ucFirmaDocumento" runat="server" Titolo="FIRMA DIGITALE DELLA DOMANDA DI PAGAMENTO"
                    TipoDocumento="DOMPAGAMENTO" />
                <uc5:ucFirmaEsternaAruba ID="modaleFirmaEsterna" runat="server" TipoDocumento="DOMPAGAMENTO" TitoloControllo="FIRMA DIGITALE ESTERNA DELLA DOMANDA DI PAGAMENTO" />
                <div id="containerCopiaPulsanti" class="row py-5 steppers">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
