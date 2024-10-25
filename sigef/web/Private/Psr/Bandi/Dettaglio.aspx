<%@ Page Async="true" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="Dettaglio.aspx.cs" Inherits="web.Private.Psr.Bandi.Dettaglio" %>

<%@ Register Src="../../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="../../../CONTROLS/ZoomLoader.ascx" TagName="ZoomLoader" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
    var pv_corrente, tipo, cod_procedura_selezione_atto;
    function SNCVZCercaUtenti_onselect(obj) {
        if (obj) {
            if (tipo == 'resp') { $('[id$=hdnIdResponsabile' + pv_corrente + ']').val(obj.IdUtente); $('[id$=txtResponsabile' + pv_corrente + '_text]').val(obj.Nominativo); }
            if (tipo == 'val') { $('[id$=hdnIdValutatore]').val(obj.IdUtente); $('[id$=txtValutatore_text]').val(obj.Nominativo); }
        } else alert('L`elemento selezionato non è valido.');
    }
    function SNCVZCercaUtenti_onprepare() { if (tipo == 'resp') { $('[id$=hdnIdResponsabile' + pv_corrente + ']').val(''); } if (tipo == 'val') { $('[id$=hdnIdValutatore' + pv_corrente + ']').val(''); } }
    function dettaglioRELParagrafo(id) { $('[id$=hdnIdParagrafo]').val(id); swapTab(5); }
    function zmlDisposizioniAttuativeSelectFn(obj) { if (!obj) alert('La disposizione attuativa selezionata non è valida.'); else if (confirm('La disposizione attuativa selezionata verrà associata la bando. Continuare?')) { $('[id$=hdnIdDisposizioneAttuativa]').val(obj.IdBando); $('[id$=btnPRGDISPATTAssocia]').click(); } }
    function dettaglioDispAttuativa(id) { if (confirm('Attenzione! Si verrà reindirizzati alla pagina di dettaglio della disposizione attuativa. Continuare?')) document.location = 'Dettaglio.aspx?idb=' + id; }
    function eliminaDispAttuativa(id) { if (confirm('Attenzione! Eliminare la disposizione attuativa selezionata?')) { $('[id$=hdnIdDisposizioneAttuativa]').val(id); $('[id$=btnPRGDISPATTElimina]').click(); } }
    function selezioneAtto(id_zoom, messaggio, cod_procedura) { cod_procedura_selezione_atto = cod_procedura; if (messaggio != '' && messaggio != null && !confirm(messaggio)) return false; mostraPopupTemplate(id_zoom + '_tbZoomMain', 'divBKGMessaggio'); runZoomSearch(id_zoom.substr(id_zoom.lastIndexOf('_') + 1), 0); }
    function zmlDecretoBandoSelectFn(obj) { if (!obj) alert('Attenzione! L`atto selezionato non è valido, impossibile continuare.'); else { $('[id$=hdnIdAtto]').val(obj.IdAtto); if (cod_procedura_selezione_atto == 'P') { $('[id$=btnPubblicazioneBando]').click(); } else if (cod_procedura_selezione_atto == 'I') { $('[id$=btnIntegrazione]').click(); } } }
    function aggiungiIntegrazione(id_zoom) { if (confirm("Aggiungere l`integrazione al bando?")) selezioneAtto(id_zoom, '', 'I'); }
    function selezionaMembro(id) { $('[id$=hdnIdValutatorePost').val(id); $('[id$=btnPost]').click(); }
    function selezionaBCPlurivalore(jobj) { if (jobj == null) alert('L`elemento selezionato non è valido.'); else { $('input[id*=dgBandoConfigValore' + jobj.CodTipo + ']').val(jobj.Codice); $('textarea[id*=dgBandoConfigValore' + jobj.CodTipo + ']').val(jobj.Descrizione); } }
    function deselezionaBCPlurivalore(id) { $('input[id*=dgBandoConfigValore' + id + ']').val(''); $('[id*=dgBandoConfigValore' + id + '] textarea').val(''); }

    function DropDownIntervento() {
        $('[id$=hdnIdIntervento]').val($('[id$=ddlInterventi').val());            
    }

        function selezionaBCMultivalore(jobj) {
            var codTipo = jobj.id.substr(jobj.id.lastIndexOf('_') + 1);
            var inputValori = $('input[id*=dgBandoConfigValore' + codTipo + ']');
            var textAreaValori = $('textarea[id*=dgBandoConfigValore' + codTipo + ']');
            inputValori.val('');
            textAreaValori.val('');

            for (var i = 1, row; row = jobj.rows[i]; i++) {
                var check = row.cells[0].firstChild;

                if (check.checked == true) {
                    var codice = row.cells[1].innerText;
                    var descrizione = row.cells[2].innerText;

                    if (inputValori.val() == '')
                        inputValori.val(codice);
                    else if (inputValori.val().indexOf(codice) == -1)
                        inputValori.val(inputValori.val() + ";" + codice);

                    if (textAreaValori.val() == '')
                        textAreaValori.val(descrizione);
                    else if (textAreaValori.val().indexOf(descrizione) == -1)
                        textAreaValori.val(textAreaValori.val() + ";\n" + descrizione);
                }
            }
        }

        function deselezionaBCMultivalore(id) {
            $('input[id*=dgBandoConfigValore' + id + ']').val('');
            $('[id*=dgBandoConfigValore' + id + '] textarea').val('');
        }

        function eliminaIntervento(id_intervento) { $('[id$=hdnIdInterventoDel]').val(id_intervento); $('[id$=btnEliminaIntervento]').click(); }

    //--></script>

    <br />
    <div style="display: none">
        <asp:HiddenField ID="hdnIdValutatorePost" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
    </div>
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Dati generali|Programmazione|Finanziario|Business Plan|Descrizione dell'iniziativa progettuale|Avanzate"
        Width="950px" />
    <table class="tableTab" id="tbDatiGenerali" runat="server" width="950px" visible="false">
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 200px">Codice ente emettitore:<br />
                            <Siar:TextBox ID="txtCodEnteEmettitore" runat="server" Width="80px" ReadOnly="True" />
                            <br />
                        </td>
                        <td>Ente emettitore:<br />
                            <Siar:TextBox ID="txtEnteEmettitore" runat="server" Width="520px" ReadOnly="True" />
                            <br />
                        </td>
                    </tr>
                </table>
                <table width="100%" style="margin-top: 10px">
                    <tr>
                        <td style="width: 200px">Programmazione:<br />
                            <Siar:TextBox ID="txtProgrammazioneCodice" runat="server" Width="180px" ReadOnly="True" />
                            <br />
                        </td>
                        <td>
                            <br />
                            <Siar:TextBox ID="txtProgrammazioneDescrizione" runat="server" Width="520px" ReadOnly="True" />
                            <br />
                        </td>
                        <td>Codice Procedura di Attivazione:
                            <br />
                            <Siar:TextBox ID="txtCodAttivazione" runat="server" Width="80px" ReadOnly="true" />
                            <Siar:Button ID="btnCodAttivazione" runat="server" Text="Richiedi" OnClick="btnCodAttivazione_Click" />
                        </td>
                    </tr>
                </table>
                <table width="100%" style="margin-top: 10px">
                    <tr>
                        <td style="width: 240px">Data apertura:<br />
                            <%--<Siar:DateTextBox ID="txtAperturaData" runat="server" Width="90px" ReadOnly="true" />
                            <Siar:ClockBox ID="txtAperturaOra" runat="server" Width="80px" ReadOnly="true" />--%>
                            <Siar:DateTextBox ID="txtAperturaData" runat="server" Width="90px" Obbligatorio="true" NomeCampo="Data apertura" />
                            <Siar:ClockBox ID="txtAperturaOra" runat="server" Width="80px" Obbligatorio="true" NomeCampo="Ora apertura" />
                        </td>
                        <td style="width: 291px">Data scadenza:<br />
                            <Siar:DateTextBox ID="txtScadenzaData" runat="server" Width="90px" Obbligatorio="true"
                                NomeCampo="Data scadenza" />
                            <Siar:ClockBox ID="txtScadenzaOra" runat="server" Width="80px" Obbligatorio="true"
                                NomeCampo="Ora scadenza" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkMultiProgetto" runat="server" Font-Bold="True" Text="Abilita inserimento di più domande per lo stesso Codice Fiscale" />
                            <br />

                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td style="width: 150px">Importo totale €:<br />
                            <Siar:CurrencyBox ID="txtImportoTotale" runat="server" Width="120px" NomeCampo="Importo totale"
                                Obbligatorio="True" />
                            <br />
                        </td>
                        <td style="width: 150px">Importo di misura €:<br />
                            <Siar:CurrencyBox ID="txtImportoMisura" runat="server" Width="120px" NomeCampo="Importo di misura"
                                Obbligatorio="True" />
                            <br />
                        </td>
                        <td style="width: 210px">Quota riserva %:<br />
                            <Siar:QuotaBox ID="txtQuotaRiserva" runat="server" Width="110px" NomeCampo="Quota riservata"
                                Obbligatorio="True" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkRichiediFascicolo" runat="server" Font-Bold="True" Text="Fascicolo aziendale obbligatorio" />
                            <br />
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td style="width: 535px">Descrizione:<br />
                            <Siar:TextArea ID="txtDescrizione" runat="server" Width="500px" Rows="5" MaxLength="2000"
                                NomeCampo="Descrizione" Obbligatorio="True" />
                            <br />
                        </td>
                        <td style="vertical-align: top">
                            <asp:CheckBox ID="chkMultiMisura" runat="server" Font-Bold="True" Text="Bando Multiprogrammazione"
                                Enabled="false" />
                            <br />
                            <br />
                            <asp:CheckBox ID="chkDispAttuative" runat="server" Font-Bold="True" Text="Disposizione attuativa"
                                Enabled="false" />
                            <br />
                            <br />
                            <asp:CheckBox ID="chkManifInteresse" runat="server" Font-Bold="True" Text="Interesse di Filiera"
                                Enabled="false" Visible="false" />
                            <asp:CheckBox ID="chkAbilitaAggregazioni" runat="server" Font-Bold="True" Text="Abilita Aggregazioni per le imprese" />
                            <br />
                            <br />
                            <asp:CheckBox ID="chkAbilitaValutazione" runat="server" Font-Bold="True" Text="Abilita valutazione" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 535px">Parole chiave:<br />
                            <Siar:TextBox ID="txtParoleChiave" runat="server" Width="500px" MaxLength="100" />
                            <br />
                        </td>
                        <td>&nbsp;
                            <uc2:ZoomLoader ID="zmlDecretoBando" runat="server" ColumnsToBind="Numero:Numero:id|Data:Data:d|Registro:Registro:id|Definizione:DefinizioneAtto:id|Descrizione"
                                KeySearch="Numero|Data:Data:d|Definizione atto:CodDefinizione:lst:ComboDefinizioneAtto"
                                KeyText="Descrizione" KeyValue="IdAtto" SearchMethod="GetDecreti" NoClear="true"
                                AutomaticSearch="false" JsSelectedItemHandler="zmlDecretoBandoSelectFn" Visible="False"
                                Width="1000px" TitoloFinestra="Selezione dell`atto amministrativo" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 535px">
                            <br />
                            Fascicolo Paleo:<br />
                            <Siar:TextBox ID="txtFascicoloPaleo" runat="server" Width="500px" MaxLength="100" />
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding: 10px; height: 100px;" align="center">
                <table>
                    <tr>
                        <td style="width: 200px; height: 40px;">
                            <Siar:Button ID="btnSalva" runat="server" OnClick="btnSalva_Click" Text="Salva" Width="190px"
                                Modifica="True" />
                        </td>
                        <td style="height: 40px">
                            <Siar:Button ID="btnElimina" runat="server" OnClick="btnElimina_Click" Text="Elimina"
                                Width="190px" Conferma="Attenzione! Eliminare il bando?" CausesValidation="False"
                                Modifica="True" />
                        </td>
                        <td style="width: 247px; height: 40px;">
                            <Siar:Button ID="btnPubblica" runat="server" Text="Pubblica" Width="190px" CausesValidation="False"
                                Modifica="true" OnClick="btnPubblica_Click" Conferma="Attenzione! Si sta per pubblicare il bando selezionato, continuare?" />
                            <%--<Siar:Button ID="btnPubblicaOrgInt" runat="server" Width="190px" Text="Pubblica"
                                CausesValidation="true" OnClick="btnPubblicaOrgInt_Click" Modifica="True" Visible="false" 
                                Conferma="Attenzione! Si sta per pubblicare il bando selezionato, continuare?" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            <input type="button" id="btnAggiungiIntegrazione" runat="server" style="width: 190px"
                                value="Aggiungi integrazione" class="Button" />
                        </td>
                        <td style="width: 200px">
                            <Siar:Button ID="btnEliminaIntegrazione" runat="server" OnClick="btnEliminaIntegrazione_Click"
                                Text="Elimina ultima integrazione" Width="190px" CausesValidation="False" Conferma="Attenzione! Eliminare l`ultima integrazione inserita?"
                                Modifica="False" />
                        </td>
                        <td style="width: 200px">
                            <Siar:Button ID="btnRiaperturaBando" runat="server" OnClick="btnRiaperturaBando_Click"
                                Text="Duplica bando" Width="190px" CausesValidation="False" Conferma="Attenzione! Duplicare il bando?"
                                Modifica="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">Storico documentale:
            </td>
        </tr>
        <tr id="trDocumentale" runat="server">
            <td style="padding-top: 10px; padding-bottom: 20px">
                <table width="100%">
                    <tr>
                        <td>
                            <Siar:DataGrid ID="dgDocumenti" runat="server" AllowPaging="true" PageSize="5" Width="100%"
                                AutoGenerateColumns="false">
                                <Columns>
                                    <Siar:NumberColumn>
                                        <ItemStyle Width="30px" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="CodStato">
                                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="NumeroAtto" HeaderText="Numero atto">
                                        <ItemStyle Width="70px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataAtto" HeaderText="Data atto">
                                        <ItemStyle Width="80px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Stato" HeaderText="Descrizione"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Data" HeaderText="Data inserimento">
                                        <ItemStyle Width="80px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <Siar:JsButtonColumn Arguments="IdAtto" ButtonType="ImageButton" ButtonText="Visualizza documento"
                                        JsFunction="visualizzaAtto" ButtonImage="lente.png">
                                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                                    </Siar:JsButtonColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trDocumentaleOrganismi_inter" runat="server" visible="false">
            <td style="padding-top: 10px; padding-bottom: 20px">
                <table width="100%">
                    <tr>
                        <td>
                            <Siar:DataGrid ID="dgDocumentiOrganismi_inter" runat="server" AllowPaging="true" PageSize="5" Width="100%"
                                AutoGenerateColumns="false">
                                <Columns>
                                    <Siar:NumberColumn>
                                        <ItemStyle Width="30px" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="Numero" HeaderText="Numero atto">
                                        <ItemStyle Width="70px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Data" HeaderText="Data atto">
                                        <ItemStyle Width="80px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                    <asp:BoundColumn>
                                        <ItemStyle Width="60px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore">ORGANIGRAMMA
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 370px">
                            <b>Responsabile del bando:</b>
                            <br />
                            <Siar:TextBox ID="txtResponsabileBando" runat="server" Width="335px" />
                            <asp:HiddenField ID="hdnIdResponsabileBando" runat="server" />
                        </td>
                        <td style="height: 60px; padding-right: 50px" align="right">
                            <Siar:Button ID="btnSalvaResponsabili" runat="server" OnClick="btnSalvaResponsabili_Click"
                                Text="Salva Responsabile" Width="200px" Modifica="True" />
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td style="display: none;">Responsabile provincia di ANCONA:<br />
                            <Siar:TextBox ID="txtResponsabileAN" runat="server" Width="335px" />
                            <asp:HiddenField ID="hdnIdResponsabileAN" runat="server" />
                        </td>
                    </tr>
                    <%--<tr>
                        <td style="width: 370px">
                            <b>Responsabile del bando:</b>
                            <br />
                            <Siar:TextBox ID="TextBox1" runat="server" Width="335px" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </td>
                        <td >
                            Responsabile provincia di ANCONA:<br />
                            <Siar:TextBox ID="TextBox2" runat="server" Width="335px" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                        </td>
                    </tr>--%>
                    <tr style="display: none;">
                        <td style="width: 370px">Responsabile provincia di PESARO:<br />
                            <Siar:TextBox ID="txtResponsabilePU" runat="server" Width="335px" />
                            <asp:HiddenField ID="hdnIdResponsabilePU" runat="server" />
                        </td>
                        <td>Responsabile provincia di MACERATA:<br />
                            <Siar:TextBox ID="txtResponsabileMC" runat="server" Width="335px" />
                            <asp:HiddenField ID="hdnIdResponsabileMC" runat="server" />
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td style="width: 370px">Responsabile provincia di ASCOLI PICENO:<br />
                            <Siar:TextBox ID="txtResponsabileAP" runat="server" Width="335px" />
                            <asp:HiddenField ID="hdnIdResponsabileAP" runat="server" />
                        </td>
                        <td>Responsabile provincia di FERMO:<br />
                            <Siar:TextBox ID="txtResponsabileFM" runat="server" Width="335px" />
                            <asp:HiddenField ID="hdnIdResponsabileFM" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td runat="server" id="tdValutatori">
                <table width="100%">
                    <tr>
                        <td class="separatore" colspan="2">DEFINIZIONE DEL COMITATO DI VALUTAZIONE DEL BANDO
                        </td>
                    </tr>
                    <tr>
                        <td class="testo_pagina" colspan="2">La selezione del presidente è obbligatoria. Si consiglia di selezionare il presidente
                            come prima persona dell'elenco dei membri del comitato di valutazione. Inoltre si
                            consiglia di inserire i valutatori in ordine sequenziale: l'ordine viene inserito
                            in modo automatico, per scambiare l'ordine di due valutatori basta selezionarli
                            vicendevolmente dalla griglia e scambiare i nominativi, in questo modo verrà mantenuto
                            l'ordine corretto.
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 500px">
                            <b>Membro del comitato:</b>&nbsp;
                            <Siar:TextBox ID="txtValutatore" runat="server" Width="335px" />
                            <asp:HiddenField ID="hdnIdValutatore" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkPresidente" runat="server" Font-Bold="True" Text="Presidente" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 60px; padding-right: 50px" align="right" colspan="2">
                            <Siar:Button ID="btnAggiungiMembro" runat="server" OnClick="btnAggiungiMembro_Click"
                                Text="Aggiungi membro comitato" Width="200px" Modifica="True" />&nbsp;
                            <Siar:Button ID="btnEliminaMembro" runat="server" OnClick="btnEliminaMembro_Click"
                                Conferma="Attenzione! Eliminare il membro selezionato?" Text="Elimina membro"
                                Width="200px" Modifica="True" />&nbsp;
                            <Siar:Button ID="btnNewMembro" runat="server" Text="Nuovo" OnClick="btnNewMembro_Click"
                                Width="127px" CausesValidation="false" Modifica="true" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <Siar:DataGrid ID="dgValutatori" runat="server" AllowPaging="true" PageSize="10"
                                Width="100%" AutoGenerateColumns="false">
                                <Columns>
                                    <Siar:NumberColumn>
                                        <ItemStyle Width="30px" />
                                    </Siar:NumberColumn>
                                    <Siar:ColonnaLink DataField="Nominativo" HeaderText="Nominativo" LinkFields="IdValutatore"
                                        LinkFormat='javascript:selezionaMembro({0})'>
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn DataField="Presidente" HeaderText="Presidente" DataFormatString="{0:SI|NO}">
                                        <ItemStyle Width="80px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Ordine" HeaderText="Ordine">
                                        <ItemStyle Width="80px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                    <%--<tr>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td style="width: 370px">
                                        <b>Presidente</b>:<br />
                                        <Siar:TextBox ID="txtValutatore1" runat="server" Width="335px" />
                                        <asp:HiddenField ID="hdnIdValutatore1" runat="server" />
                                    </td>
                                    <td>
                                        Membro del comitato:<br />
                                        <Siar:TextBox ID="txtValutatore2" runat="server" Width="335px" />
                                        <asp:HiddenField ID="hdnIdValutatore2" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 370px">
                                        Membro del comitato:<br />
                                        <Siar:TextBox ID="txtValutatore3" runat="server" Width="335px" />
                                        <asp:HiddenField ID="hdnIdValutatore3" runat="server" />
                                    </td>
                                    <td>
                                        Membro del comitato:<br />
                                        <Siar:TextBox ID="txtValutatore4" runat="server" Width="335px" />
                                        <asp:HiddenField ID="hdnIdValutatore4" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 370px">
                                        Membro del comitato:<br />
                                        <Siar:TextBox ID="txtValutatore5" runat="server" Width="335px" />
                                        <asp:HiddenField ID="hdnIdValutatore5" runat="server" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 60px; padding-right: 50px" align="right" colspan="2">
                            <Siar:Button ID="btnSalvaValutatori" runat="server" OnClick="btnSalvaValutatori_Click"
                                Text="Salva valutatori" Width="200px" Modifica="True" />
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
    </table>
    <table class="tableTab" id="tbProgrammazione" runat="server" width="950px" visible="false">
        <tr>
            <td class="paragrafo">
                <br />
                Programmazione principale:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 200px">Codice:<br />
                            <Siar:TextBox ID="txtPRGPREVCodice" runat="server" Width="180px" ReadOnly="True" />
                            <br />
                        </td>
                        <td>Descrizione:<br />
                            <Siar:TextBox ID="txtPRGPREVDescrizione" runat="server" Width="520px" ReadOnly="True" />
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="margin-top: 10px">
                <Siar:DataGrid ID="dgPRGPREVInterventi" runat="server" AllowPaging="true" PageSize="10"
                    Width="100%" AutoGenerateColumns="false">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn>
                            <%-- <ItemStyle Width="30px" /> --%>
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Codice">
                            <%-- <ItemStyle Width="80px" HorizontalAlign="Center" /> --%>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <%--<asp:BoundColumn HeaderText="Sottocategoria">
                             <ItemStyle Width="350px" /> 
                        </asp:BoundColumn>--%>
                        <asp:BoundColumn HeaderText="Dati categorie intervento"></asp:BoundColumn>
                        <Siar:CheckColumn DataField="MisuraPrevalente" HeaderText="Misura prevalente">
                            <%-- <ItemStyle Width="50px" HorizontalAlign="Center" /> --%>
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:CheckColumn>
                        <asp:BoundColumn>
                            <ItemStyle Width="150px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
                <div style="display: none">
                    <asp:HiddenField ID="hdnIdInterventoDel" runat="server" />
                    <asp:Button ID="btnEliminaIntervento" runat="server" OnClick="btnEliminaIntervento_Click"
                        CausesValidation="false" />
                </div>
            </td>
        </tr>
<%--        <tr>
            <td align="right" style="padding-right: 50px; height: 58px;">
                <Siar:Button ID="btnPRGPRELSalva" runat="server" OnClick="btnPRGPRELSalva_Click"
                    Text="Salva tipologie di intervento" Width="230px" Modifica="True" />
            </td>
        </tr>--%>
        <tr>
            <td class="paragrafo">
                <br />
                Aggiungere altri interventi alla programmazione principale:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">Selezionare il Por di riferimento:
                <br />
                <Siar:ComboZPsr ID="lstPsr" runat="server" AutoPostBack="true">
                </Siar:ComboZPsr>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="0" cellspacing="0" id="tbAzioni" runat="server"
                    visible="false">
                    <tr>
                        <td style="padding: 10px">Selezionare l'Azione:
                            <br />
                            <Siar:ComboZProgrammazione ID="lstAzione" runat="server" AutoPostBack="True"
                                Width="700px">
                            </Siar:ComboZProgrammazione>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px">Selezionare l'Intervento:
                            <br />
                            <asp:DropDownList ID="ddlInterventi" runat="server" AppendDataBoundItems="true" AutoPostBack="true" onchange="DropDownIntervento();">
                                <asp:ListItem Selected="True" Text="-- selezionare un valore --" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <asp:HiddenField ID="hdnIdIntervento" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 50px; height: 58px;">
                            <Siar:Button ID="btnAddProgrammazione" runat="server" OnClick="btnAddProgrammazione_Click" Visible="false"
                                Text="Aggiungi intervento" Width="230px" Modifica="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr runat="server" id="trDisposizioniAttuative" visible="false">
            <td>
                <table id="tbsubDisposizioniAttuative" runat="server" visible="false" width="100%"
                    cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="paragrafo">
                            <br />
                            Disposizioni attuative subordinate:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td align="right">
                                        <b>Associa disposizione attuativa:</b>
                                    </td>
                                    <td style="width: 50px; padding-left: 5px">
                                        <uc2:ZoomLoader ID="zmlDisposizioniAttuative" runat="server" AutomaticSearch="True"
                                            ColumnsToBind="Scadenza:DataScadenza:d|Descrizione|Importo:Importo:c" KeySearch="Programmazione:Programmazione:lst:ComboGroupZProgrammazioneShort"
                                            KeyText="Parole chiave" KeyValue="IdBando" SearchMethod="GetDisposizioniAttuative"
                                            NoClear="true" JsSelectedItemHandler="zmlDisposizioniAttuativeSelectFn" IconaPiccola="true"
                                            Width="700px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px; padding-bottom: 10px">
                            <Siar:DataGrid ID="dgPRGDispAttuative" runat="server" AllowPaging="false" Width="100%"
                                AutoGenerateColumns="false">
                                <ItemStyle Height="40px" />
                                <Columns>
                                    <Siar:NumberColumn>
                                        <ItemStyle Width="20px" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn HeaderText="Descrizione">
                                        <ItemStyle Width="450px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Programmazione"></asp:BoundColumn>
                                    <Siar:JsButtonColumn Arguments="IdBando" ButtonText="Dettaglio" ButtonType="TextButton"
                                        JsFunction="dettaglioDispAttuativa">
                                        <ItemStyle Width="90px" HorizontalAlign="Center" />
                                    </Siar:JsButtonColumn>
                                    <Siar:JsButtonColumn Arguments="IdBando" ButtonText="Elimina" ButtonType="TextButton"
                                        JsFunction="eliminaDispAttuativa">
                                        <ItemStyle Width="90px" HorizontalAlign="Center" />
                                    </Siar:JsButtonColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table class="tableTab" id="tbFinanziario" runat="server" width="950px" visible="false">
        <tr>
            <td class="paragrafo">
                <br />
                Dettagli finanziari generali:
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px; padding-bottom: 10px">
                <Siar:DataGrid ID="dgFINTipoInvestimenti" runat="server" Width="100%" AllowPaging="false"
                    AutoGenerateColumns="False">
                    <ItemStyle Height="28px" />
                    <Columns>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Tipologia">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundColumn>
                        <Siar:ImportoColumn DataField="CodTipoInvestimento" Name="ImportoMin" HeaderText="Importo Minimo"
                            Importo="ImportoMin">
                            <ItemStyle HorizontalAlign="center" Width="150px"></ItemStyle>
                        </Siar:ImportoColumn>
                        <Siar:ImportoColumn DataField="CodTipoInvestimento" Name="ImportoMax" HeaderText="Importo Massimo"
                            Importo="ImportoMax">
                            <ItemStyle HorizontalAlign="center" Width="150px"></ItemStyle>
                        </Siar:ImportoColumn>
                        <Siar:PercentualeColumn DataField="CodTipoInvestimento" Name="QuotaMax" Quota="QuotaMax"
                            HeaderText="% Max">
                            <ItemStyle HorizontalAlign="center" Width="100px"></ItemStyle>
                        </Siar:PercentualeColumn>
                        <Siar:TextColumn DataField="CodTipoInvestimento" Name="Note" Testo="Note" HeaderText="Note">
                            <ItemStyle HorizontalAlign="center" Width="200px"></ItemStyle>
                        </Siar:TextColumn>
                        <Siar:CheckColumn DataField="CodTipoInvestimento" Name="chkTipoInvestimento" HeaderSelectAll="true">
                            <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td style="height: 60px; padding-right: 50px" align="right">
                <Siar:Button ID="btnFINTipoInvSalva" runat="server" OnClick="btnFINTipoInvSalva_Click"
                    Text="Salva dettagli finanziari" Width="210px" Modifica="True" />
            </td>
        </tr>
        <tr>
            <td class="paragrafo">Massimali di aiuto per tipologia di intervento:
            </td>
        </tr>
        <tr>
            <td>&nbsp;
                <Siar:DataGrid ID="dgFINMassimali" runat="server" Width="100%" AllowPaging="false"
                    AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Tipologia di intervento">
                            <ItemStyle CssClass="testo_pagina" />
                        </asp:BoundColumn>
                        <Siar:PercentualeColumn DataField="IdProgrammazione" HeaderText="Quota max %" Name="dgtxtQuotaMax"
                            Quota="Quota">
                            <ItemStyle HorizontalAlign="center" Width="100px" />
                        </Siar:PercentualeColumn>
                        <Siar:ImportoColumn DataField="IdProgrammazione" HeaderText="Importo max €" Name="dgtxtImportoMax"
                            Importo="Importo">
                            <ItemStyle HorizontalAlign="center" Width="120px" />
                        </Siar:ImportoColumn>
                        <Siar:CheckColumn DataField="IdProgrammazione" HeaderSelectAll="true" Name="chkIdProgrammazione">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td style="height: 60px; padding-right: 50px" align="right">
                <Siar:Button ID="btnFINMassimaliSalva" runat="server" OnClick="btnFINMassimaliSalva_Click"
                    Text="Salva massimali di aiuto" Width="210px" Modifica="True" />
            </td>
        </tr>
    </table>
    <table class="tableTab" id="tbBusinessPlan" runat="server" width="950px" visible="false">
        <tr>
            <td class="testo_pagina">Selezionare i quadri che sarà obbligatorio compilare alla presentazione della domanda:
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px; padding-bottom: 10px">
                <Siar:DataGrid ID="dgBPQuadri" runat="server" Width="100%" AllowPaging="false" AutoGenerateColumns="False">
                    <ItemStyle Height="26px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="35px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Titolo" HeaderText="Titolo">
                            <ItemStyle Width="350px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Quadro" HeaderText="Descrizione"></asp:BoundColumn>
                        <Siar:CheckColumn DataField="IdQuadro" Name="chkBPQuadro" HeaderSelectAll="true">
                            <ItemStyle Width="60px" HorizontalAlign="Center" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 60px; padding-right: 50px">&nbsp;
                <Siar:Button ID="btnBPSalva" runat="server" Text="Salva" Width="190px" Modifica="True"
                    OnClick="btnBPSalva_Click" CausesValidation="False" />
            </td>
        </tr>
    </table>
    <table class="tableTab" id="tbRelazioneTecnica" runat="server" width="950px" visible="false">
        <tr>
            <td class="paragrafo">
                <br />
                Dettaglio paragrafo:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 540px">Titolo:<br />
                            <Siar:TextBox ID="txtRELTitolo" runat="server" Width="500px" NomeCampo="Titolo paragrafo"
                                Obbligatorio="true" MaxLength="100" />
                        </td>
                        <td>Ordine:<br />
                            <Siar:IntegerTextBox ID="txtRELOrdine" runat="server" NomeCampo="Ordine" Obbligatorio="True"
                                Width="70px" />
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td>Descrizione:<br />
                            <Siar:TextArea ID="txtRELDescrizione" runat="server" NomeCampo="Descrizione paragrafo"
                                Width="612px" Rows="6" Obbligatorio="true" MaxLength="2000" />
                            <asp:HiddenField ID="hdnIdParagrafo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 60px; padding-right: 50px" align="right">
                            <Siar:Button ID="btnRELParagrafoSalva" runat="server" OnClick="btnRELParagrafoSalva_Click"
                                Text="Salva" Width="150px" Modifica="True" />
                            &nbsp;
                            <Siar:Button ID="btnRELParagrafoElimina" runat="server" OnClick="btnRELParagrafoElimina_Click"
                                Text="Elimina" Width="150px" Conferma="Attenzione! Eliminare il paragrafo selezionato?"
                                Modifica="True" CausesValidation="false" />
                            &nbsp;
                            <input class="Button" style="width: 110px" type="button" value="Nuovo" onclick="dettaglioRELParagrafo(null);" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">Elenco paragrafi:
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px; padding-bottom: 10px">
                <Siar:DataGrid ID="dgRELParagrafi" runat="server" Width="100%" AllowPaging="false"
                    AutoGenerateColumns="False">
                    <ItemStyle Height="26px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="25px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Titolo e descrizione">
                            <ItemStyle CssClass="testo_pagina" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Ordine" HeaderText="Ordine">
                            <ItemStyle Width="60px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdParagrafo" ButtonText="Dettaglio" ButtonType="TextButton"
                            JsFunction="dettaglioRELParagrafo">
                            <ItemStyle Width="120px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
    <table class="tableTab" id="tbAvanzate" runat="server" width="950px" visible="false">
        <tr>
            <td class="testo_pagina">Impostazioni avanzate (<b>non modificare</b> se non si sa esattamente cosa si sta
                facendo):
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px; padding-bottom: 10px">
                <Siar:DataGrid ID="dgBandoConfig" runat="server" Width="100%" AllowPaging="false"
                    AutoGenerateColumns="False">
                    <ItemStyle Height="28px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="25px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="CodMacroTipo" HeaderText="Fase">
                            <ItemStyle Width="130px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="CodTipo" HeaderText="Codice">
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Formato" HeaderText="Formato">
                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle Width="300px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 60px; padding-right: 50px">&nbsp;
                <Siar:Button ID="btnSalvaConfig" runat="server" Text="Salva" Width="190px" Modifica="True"
                    OnClick="btnSalvaConfig_Click" CausesValidation="False" />
            </td>
        </tr>
    </table>
    <div style="display: none">
        <asp:Button ID="btnPubblicazioneBando" runat="server" OnClick="btnPubblicazioneBando_Click" />
        <asp:Button ID="btnIntegrazione" runat="server" OnClick="btnIntegrazione_Click" />
        <asp:Button ID="btnPRGDISPATTAssocia" runat="server" OnClick="btnPRGDISPATTAssocia_Click" />
        <asp:Button ID="btnPRGDISPATTElimina" runat="server" OnClick="btnPRGDISPATTElimina_Click" />
        <input type="hidden" id="hdnIdDisposizioneAttuativa" runat="server" />
        <input type="hidden" id="hdnIdAtto" runat="server" />
    </div>
    <div id='divDecretoOrgInt' style="width: 750px; position: absolute; display: none;">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">Dati del decreto/atto:
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td class="testo_pagina" colspan="3">Inserire tutti i dati relativi al decreto/atto ed il link dello stesso presente
                                nel proprio albo pretorio.
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 160px">Data:<br />
                                <Siar:DateTextBox ID="txtDataDecreto" runat="server" Width="120px" />
                            </td>
                            <td style="width: 160px">Numero:<br />
                                <Siar:IntegerTextBox NoCurrency="True" ID="txtNumeroDecreto" runat="server" Width="120px" />
                            </td>
                            <td style="width: 330px"></td>
                        </tr>
                        <tr>
                            <td colspan="3" style="width: 650px">Descrizione/titolo:<br />
                                <Siar:TextArea Rows="3" MaxLength="3000" ID="txtDescrizioneDecreto" runat="server" Width="630px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="width: 650px">Link Esterno:<br />
                                <asp:TextBox ID="txtLinkEst" runat="server" Width="630px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 70px;" colspan="3">
                                <Siar:Button ID="btnAggiungiIntegrazioneOrgInt" runat="server" Visible="false" OnClick="btnAggiungiIntegrazioneOrgInt_Click"
                                    Text="Aggiungi" Conferma="Aggiungere l'integrazione con il decreto/atto inserito?" Width="100px" CausesValidation="False" />

                                <Siar:Button ID="btnSalvaDescretoOrg" runat="server" Modifica="true" OnClick="btnSalvaDescretoOrg_Click"
                                    Text="Pubblica" Conferma="Il bando sarà pubblicato con il decreto/atto inserito. Continuare?" Width="100px" CausesValidation="False" />
                                <input class="Button" onclick="chiudiPopupTemplate();" style="width: 100px; margin-left: 20px; margin-right: 20px"
                                    type="button" value="Chiudi" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
