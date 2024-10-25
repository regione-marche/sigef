<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" Inherits="web.Private.PPagamento.FirmaRichiesta" CodeBehind="FirmaRichiesta.aspx.cs" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc4" %>
<%@ Register Src="../../CONTROLS/FirmaDocumentoEsterna.ascx" TagName="ucFirmaEsternaAruba" TagPrefix="uc5" %>

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
//        function VisualizzaProt() {
//            var segnatura = $('[id$=txtSegnaturaIns]').val() ;
//            sncAjaxCallVisualizzaProtocollo(segnatura);
//            mostraPopupTemplate('divPregresso', 'divBKGMessaggio');
//        }
        
//--></script>

    <uc1:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
    <br />
    <div style="display: none">
        <input type="hidden" id="hdnIdAllegato" runat="server" />
        <input type="hidden" id="hdnCodEnte" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
        <asp:Button ID="btnDettaglioPost" runat="server" OnClick="btnDettaglioPost_Click" />
        <asp:Button ID="btnNuovoAllegatoPost" runat="server" OnClick="btnNuovoAllegatoPost_Click" />
        <asp:HiddenField ID="hdnIdIntegrazioneSingolaSelezionata" runat="server" />
    </div>
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                DICHIARAZIONE DEGLI ALLEGATI
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Elenco generale degli allegati alla presente domanda di pagamento. Le <b>categorie di
                    documento</b> indicate sono quelle previste<br />
                dal bando di riferimento e sono suddivise in 3 tipi fondamentali:
                <br />
                <b>Supporto cartaceo (C)</b>: tipo non più valido, vecchia modalità di invio documenti
                in formato cartaceo tramite busta chiusa.<br />
                <b>Supporto digitale (D)</b>: richiede il caricamento di un documento digitale (sottoscritto
                digitalmente per le tipologie previste dal bando di gara).<br />
                <b>Dichiarazione sostitutiva (S)</b>: usata per documenti e/o certificati emessi
                da una pubblica amministrazione, questa tipologia<br />
                sostituisce a tutti gli effetti il caricamento di tali documenti ma richiede la
                specifica dei riferimenti di essi.
                <br />
                <br />
                Per le domande di <b>ANTICIPO</b> si richiede unicamente di inviare l&#39;<b>originale
                    cartaceo della garanzia/polizza fidejussoria</b>, quando questa<br />
                è prevista dal bando di riferimento.
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbAllegati" runat="server" width="100%" cellpadding="0" cellspacing="0"
                    visible="false">
                    <tr>
                        <td class="paragrafo">
                            &nbsp; Nuovo allegato:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="padding-left: 15px" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        Selezionare la categoria del documento:<br />
                                        <Siar:ComboSql ID="lstCategoria" runat="server" OptionalValue="FORMATO" DataTextField="DESCRIZIONE"
                                            DataValueField="CODICE" Width="600px">
                                        </Siar:ComboSql>
                                    </td>
                                </tr>
                                <tr id="trDichiarazioneSostitutiva" style="display: none">
                                    <td>
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 200px">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px">
                                                    Specificare l&#39;ente:<br />
                                                    <Siar:Combo ID="lstNATipoEnte" runat="server">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem Value="CM">Comune</asp:ListItem>
                                                        <asp:ListItem Value="PR">Provincia</asp:ListItem>
                                                    </Siar:Combo>
                                                </td>
                                                <td>
                                                    Denominazione ente:<br />
                                                    <Siar:TextBox ID="txtNAEnte" runat="server" Width="400px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px">
                                                    Data di emissione:<br />
                                                    <Siar:DateTextBox ID="txtNADatadoc" runat="server" Width="130px" />
                                                </td>
                                                <td>
                                                    Numero documento:<br />
                                                    <Siar:TextBox ID="txtNANumeroDoc" runat="server" Width="150px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="trUploadFile" style="display: none">
                                    <td>
                                        <uc4:SNCUploadFileControl ID="ufcNAAllegato" runat="server" Width="600" Text="Selezionare un documento da caricare" />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Breve descrizione: (facoltativa, max 250 caratteri) :<br />
                                        <Siar:TextArea ID="txtDescrizione" runat="server" Height="19px" NomeCampo="Descrizione"
                                            Width="600px" Rows="3" MaxLength="250" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 60px; padding-right: 40px">
                            <Siar:Button ID="btnSalva" Text="Salva" runat="server" CausesValidation="false" Modifica="true"
                                Width="150px" OnClick="btnSalva_Click" OnClientClick="return ctrlCampi(event);" />
                            &nbsp;&nbsp;
                            <Siar:Button ID="btnElimina" Text="Elimina" runat="server" CausesValidation="false"
                                Modifica="true" Width="150px" OnClick="btnDel_Click" OnClientClick="return eliminaAllegato(event);" />
                            <input onclick="pulisciCampi();" style="width: 130px; margin-left: 20px" type="button"
                                class="Button" value="Nuovo" />
                        </td>
                    </tr>
                    <tr>
                        <td class="separatore">
                            Elenco degli allegati inclusi:
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px; padding-bottom: 10px">
                            <div id="divDimTotAllegati" runat="server" style="position: absolute; left: 820px;
                                line-height: 2em; font-weight: bold">
                            </div>
                            <br />
                            &nbsp;
                            <Siar:DataGrid ID="dgAllegati" runat="server" AutoGenerateColumns="False" Width="100%"
                                AllowPaging="true" PageSize="8">
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle HorizontalAlign="center" Width="30px" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="TipoAllegato" HeaderText="Formato">
                                        <ItemStyle Width="130px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="TipologiaDocumento" HeaderText="Categoria">
                                        <ItemStyle Width="190px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="DimensioneFile" HeaderText="Dim. (Kb)" DataFormatString="{0:N0}">
                                        <ItemStyle HorizontalAlign="Right" Width="60px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataInserimento" HeaderText="Data inserimento">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundColumn>
                                    <Siar:JsButtonColumn Arguments="IdFile" ButtonImage="lente.png" ButtonType="ImageButton"
                                        ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </Siar:JsButtonColumn>
                                    <Siar:JsButtonColumn Arguments="IdAllegato" ButtonImage="config.ico" ButtonType="ImageButton"
                                        ButtonText="Visualizza dettaglio" JsFunction="dettaglioAllegato">
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </Siar:JsButtonColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                    <br />
                    <tr id="trIntegrazioniRichieste" runat="server" visible="false">
                        <td>
                            <table width="100%">
                                <tr>
                                    <td class="separatore" style="width: 287px">
                                        Elenco integrazioni da risolvere:
                                    </td>
                                </tr>
                                <br />
                                &nbsp;
                                <tr>
                                    <td align="right">
                                        <Siar:Button ID="btnSpese" runat="server" OnClick="btnSpese_Click" Text="Spese sostenute" Width="180px" />
                                        <Siar:Button ID="btnInvestimenti" runat="server" OnClick="btnInvestimenti_Click" Text="Piano Investimenti" Width="180px" />
                                        <Siar:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Indietro" Width="180px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Siar:DataGrid ID="dgIntegrazioni" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            PageSize="15" Width="100%" ShowFooter="true">
                                            <ItemStyle Height="28px" />
                                            <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                            <Columns>
                                                <asp:BoundColumn DataField="IdSingolaIntegrazione" HeaderText="ID singola integrazione">
                                                    <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" Width="70px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="DataRichiestaIntegrazioneIstruttore" HeaderText="Data richiesta">
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="DescrizioneTipoIntegrazione" HeaderText="Tipo integrazione">
                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="NoteIntegrazioneIstruttore" HeaderText="Note istruttore">
                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="SingolaIntegrazioneCompletataIstruttore" HeaderText="Completata istruttore">
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="DataRilascioIntegrazioneBeneficiario" HeaderText="Data rilascio beneficiario">
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="NoteIntegrazioneBeneficiario" HeaderText="Note beneficiario">
                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="SingolaIntegrazioneCompletataBeneficiario" HeaderText="Completata beneficiario">
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:BoundColumn>
                                                <Siar:JsButtonColumn Arguments="IdSingolaIntegrazione" ButtonType="TextButton" ButtonText="Apri" JsFunction="visualizzaIntegrazioneSingola" HeaderText="Apri">
                                                    <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                </Siar:JsButtonColumn>
                                            </Columns>
                                        </Siar:DataGrid>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <br />
                    <tr id="trDettaglioIntegrazioneSingolaSelezionata" runat="server" visible="false">
                        <td>
                            <table width="100%">
                                <tr>
                                    <td class="separatore">
                                        Dettaglio singola integrazione selezionata:
                                    </td>
                                </tr>
                                <tr>
                                    <td class="paragrafo" style="width: 287px">
                                        Dati di competenza dell'istruttore:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 10px">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    Data richiesta:<br />
                                                    <Siar:DateTextBox ID="txtDataRichiesta" runat="server" Width="120px" ReadOnly="true" />
                                                </td>
                                                <td>
                                                    Tipo integrazione:
                                                    <br />
                                                    <Siar:TextBox ID="txtTipoIntegrazione" runat="server" Width="180px" ReadOnly="true" />
                                                </td>
                                                <td>
                                                    Integrazione completata:
                                                    <br />
                                                    <asp:DropDownList ID="comboCompletataSingolaIntegrazioneDomandaIstruttore" runat="server"
                                                        Enabled="False">
                                                        <asp:ListItem Text="No" Value="false"></asp:ListItem>
                                                        <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    Note integrazione:
                                                    <br />
                                                    <Siar:TextArea ID="txtNoteSingolaIntegrazioneIstruttore" runat="server" NomeCampo="Note singola integrazione"
                                                        Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" ReadOnly="true" MaxLength="10000" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="paragrafo" style="width: 287px">
                                        Dati di competenza del beneficiario:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 10px">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    Data rilascio:<br />
                                                    <Siar:DateTextBox ID="txtDataRilascio" runat="server" Width="120px" />
                                                </td>
                                                <td>
                                                    Integrazione completata beneficiario:
                                                    <br />
                                                    <asp:DropDownList ID="comboCompletataSingolaIntegrazioneDomandaBeneficiario" runat="server">
                                                        <asp:ListItem Text="No" Value="false"></asp:ListItem>
                                                        <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    Note beneficiario:
                                                    <br />
                                                    <Siar:TextArea ID="txtNoteSingolaIntegrazioneBeneficiario" runat="server" NomeCampo="Note singola integrazione beneficiario"
                                                        Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                                                </td>
                                                <td align="left">
                                                    <br />
                                                    <Siar:Button ID="btnSalvaSingolaIntegrazione" runat="server" OnClick="btnSalvaSingolaIntegrazione_Click"
                                                        Text="Salva dati singola integrazione" Width="190px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <table class="tableNoTab" width="900" id="tableRilascioDomandaPagamento" runat="server"
        visible="true">
        <tr id="trPredisposizione" runat="server">
            <td>
                <table width="100%">
                    <tr>
                        <td class="separatore_big">
                            Predisposizione alla firma della domanda:
                        </td>
                    </tr>
                    <tr>
                        <td class="testo_pagina">
                            <b>FACOLTATIVO</b>: la predisposizione alla firma è la modalità di presentazione
                            della domanda di aiuto per i casi di <b>firma differita.</b><br />
                            Ovvero questa modalità prevede il congelamento della domanda in tutte le sue sezioni,
                            quindi non piu&#39; modificabile,
                            <br />
                            in attesa della firma finale da parte del <b>rappresentante legale</b> dell&#39;impresa
                            o di altro soggetto titolato, che potrà eseguire<br />
                            il successivo rilascio da una qualsiasi postazione egli abbia a disposizione. Ciò
                            è utile nei casi in cui il firmatario<br />
                            non può essere presente nella stessa sede in cui si trova l&#39;operatore che compila
                            la domanda.<br />
                            Tale predisposizione può essere sempre annullata <b>prima del rilascio</b> per eseguire
                            correzioni o adeguamenti finali.
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-bottom: 20px;" valign="top">
                            <Siar:Button ID="btnPredisponi" runat="server" Width="220px" Text="Predisponi alla firma"
                                CausesValidation="false" Conferma="Attenzione! Predisporre la domanda di pagamento alla firma da remoto?"
                                OnClick="btnPredisponi_Click" Modifica="False" Enabled="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore_big">
                RILASCIO DELLA DOMANDA DI PAGAMENTO
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Una volta inseriti tutti i dati obbligatori e compilate tutte le sezioni richieste
                sarà&nbsp; possibile <strong>firmare digitamente</strong> e <strong>
                    <br />
                    inviare al protocollo regionale</strong> la presente richiesta di pagamento.
                Tale procedura è definitiva e non sarà più possibile
                <br />
                modificare ulteriormente i dati, è quindi consigliato&nbsp;prima <strong>accertarsi
                    della correttezza</strong> degli stessi.
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 66px">
                <Siar:Button ID="btnFirma" runat="server" CausesValidation="False" Width="210px"
                    Text="Presenta domanda" Enabled="false" OnClick="btnFirma_Click" Conferma="Attenzione, rendere la domanda di pagamento definitiva? Non sarà più possibile modificare i dati"
                    Modifica="True" />
                <Siar:Button ID="btnFirmaEsterna" runat="server" CausesValidation="False" AdditionalStyles="margin-left: 25px;"
                    Text="Scarica e presenta domanda con firma esterna" Enabled="false" OnClick="btnFirmaEsterna_Click" 
                    Modifica="True" />
                <input type="button" class="Button" id="btnStampaRicevuta" runat="server" value="Ricevuta di protocollazione"
                    style="width: 220px; margin-left: 25px" disabled="disabled" />
            </td>
        </tr>
        <tr id="rowProtocolliAllegati" runat="server" visible="false">
            <td align="center" style="height: 66px" >
                <Siar:Button ID="btnProtocollaAllegati" runat="server" CausesValidation="False" Width="210px"
                    Text="Protocolla allegati" Enabled="false" OnClick="btnProtocollaAllegati_Click"
                    Modifica="True" />
            </td>
        </tr>
    </table>
    
    <table class="tableNoTab" width="900" id="tableRilascioDomandaPagamentoPregressa" runat="server" visible="false">
        <tr>
            <td class="separatore_big">
                RILASCIO DELLA DOMANDA DI PAGAMENTO
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 66px">
                <Siar:Button ID="btnInserisciSegnatura" runat="server" CausesValidation="False" Width="200px"
                    Text="Inserisci Segnatura" Enabled="false" OnClick="btnInserisciSegnatura_Click" Conferma="Attenzione, rendere la domanda di pagamento definitiva? Non sarà più possibile modificare i dati"
                    Modifica="true"  />
            </td>
        </tr>
    </table>
    <div id='divPregresso' style="width: 725px; position: absolute; display:none;">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">
                    Dati della segnatura della domanda:
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                           <td style="width: 140px">
								Data:<br />
								<Siar:DateTextBox ID="txtData" runat="server" Width="120px" />
							</td>
							<td style="width: 440px">
								Segnatura:<br />
								<asp:TextBox ID="txtSegnaturaIns" runat="server" Width="400px"  />
<%--								<img id="imgSegnatura" runat="server" height="18" src="../../images/lente.png"
									title="Visualizza documento" width="18" onclick="VisualizzaProt();" />--%>
							</td>
                        </tr>
                        <tr style="display:none">
                            <td></td>
                            <td>
                                <asp:CheckBox ID="ckAttivo" Text ="Segnatura non disponibile" runat="server" />
                            </td>
                        </tr>
                        <tr > 
                            <td align="right" style="height: 70px; " colspan="2">
                                <Siar:Button ID="btnSalvaSegnatura" runat="server" Modifica="true" OnClick="btnSalvaSegnatura_Click"
                                    Text="Salva" Conferma="Attenzione! Una volta resa definitiva, non sarà più possibile modificare i dati. Continuare?" Width="100px" CausesValidation="False"/>
                                <input class="Button" onclick="chiudiPopupTemplate();" style="width: 100px; margin-left: 20px;
                                    margin-right: 20px" type="button" value="Chiudi" />
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
</asp:Content>
