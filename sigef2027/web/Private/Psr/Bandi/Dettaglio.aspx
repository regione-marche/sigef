<%@ Page Async="true" Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="Dettaglio.aspx.cs" Inherits="web.Private.Psr.Bandi.Dettaglio" %>

<%@ Register Src="../../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
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
    function selezioneAtto(id_zoom, messaggio, cod_procedura) { cod_procedura_selezione_atto = cod_procedura; if (messaggio != '' && messaggio != null && !confirm(messaggio)) return false; mostraPopupTemplateZoom(id_zoom + '_tbZoomMain', 'divBKGMessaggio'); runZoomSearch(id_zoom.substr(id_zoom.lastIndexOf('_') + 1), 0); }
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

    <div style="display: none">
        <asp:HiddenField ID="hdnIdValutatorePost" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
    </div>
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Dati generali|Programmazione|Finanziario|Business Plan|Descrizione dell'iniziativa progettuale|Avanzate" />
    <div class="tableTab row bd-form" id="tbDatiGenerali" runat="server" visible="false">
        <div class="col-sm-2 form-group mt-5">
            <Siar:TextBox Label="Codice ente emettitore:" ID="txtCodEnteEmettitore" runat="server" ReadOnly="True" />
        </div>
        <div class="col-sm-10 form-group mt-5">
            <Siar:TextBox Label="Ente emettitore:" ID="txtEnteEmettitore" runat="server" ReadOnly="True" />
        </div>
        <div class="col-sm-2 form-group">
            <Siar:TextBox Label="Programmazione:" ID="txtProgrammazioneCodice" runat="server" ReadOnly="True" />
        </div>
        <div class="col-sm-8 form-group">
            <Siar:TextBox Label="Descrizione" ID="txtProgrammazioneDescrizione" runat="server" ReadOnly="True" />
        </div>
        <div class="col-sm-2 form-group">
            <Siar:TextBox Label="Codice Procedura di Attivazione:" ID="txtCodAttivazione" runat="server" ReadOnly="true" />
            <Siar:Button ID="btnCodAttivazione" runat="server" Text="Richiedi" OnClick="btnCodAttivazione_Click" />
        </div>

        <div class="col-sm-8">
            <div class="row">
                <div class="col-sm-4 form-group">
                    <Siar:DateTextBox Label="Data apertura:" ID="txtAperturaData" runat="server" Obbligatorio="true" NomeCampo="Data apertura" />
                </div>
                <div class="col-sm-2 form-group">
                    <Siar:ClockBox Label="Ora:" ID="txtAperturaOra" runat="server" Obbligatorio="true" NomeCampo="Ora apertura" />
                </div>
                <div class="col-sm-4 form-group">
                    <Siar:DateTextBox ID="txtScadenzaData" Label="Data scadenza:" runat="server" Obbligatorio="true"
                        NomeCampo="Data scadenza" />
                </div>
                <div class="col-sm-2 form-group">
                    <Siar:ClockBox ID="txtScadenzaOra" Label="Ora:" runat="server" Obbligatorio="true"
                        NomeCampo="Ora scadenza" />
                </div>
                <div class="col-sm-4 form-group">
                    <Siar:CurrencyBox Label="Importo totale €:" ID="txtImportoTotale" runat="server" NomeCampo="Importo totale"
                        Obbligatorio="True" />
                </div>
                <div class="col-sm-4 form-group">
                    <Siar:CurrencyBox Label="Importo di misura €:" ID="txtImportoMisura" runat="server" NomeCampo="Importo di misura"
                        Obbligatorio="True" />
                </div>
                <div class="col-sm-4 form-group">
                    <Siar:QuotaBox Label="Quota riserva %:" ID="txtQuotaRiserva" runat="server" NomeCampo="Quota riservata"
                        Obbligatorio="True" />
                </div>
                <div class="col-sm-12 form-group">
                    <Siar:TextArea Label="Descrizione:" ID="txtDescrizione" runat="server" Rows="5" MaxLength="2000"
                        NomeCampo="Descrizione" Obbligatorio="True" />
                </div>
                <div class="col-sm-12 form-group">
                    <Siar:TextBox Label="Parole chiave:" ID="txtParoleChiave" runat="server" MaxLength="100" />
                </div>
                <div class="col-sm-12 form-group">
                    <Siar:TextBox Label="Fascicolo Paleo:" ID="txtFascicoloPaleo" runat="server" MaxLength="100" />
                </div>
            </div>
        </div>
        <div class="col-sm-4">
            <div class="row">
                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="chkMultiProgetto" runat="server" Font-Bold="True" Text="Abilita inserimento di più domande per lo stesso Codice Fiscale" />
                </div>

                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="chkRichiediFascicolo" runat="server" Font-Bold="True" Text="Fascicolo aziendale obbligatorio" />
                </div>

                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="chkMultiMisura" runat="server" Font-Bold="True" Text="Bando Multiprogrammazione"
                        Enabled="false" />
                </div>

                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="chkDispAttuative" runat="server" Font-Bold="True" Text="Disposizione attuativa"
                        Enabled="false" />
                </div>

                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="chkManifInteresse" runat="server" Font-Bold="True" Text="Interesse di Filiera"
                        Enabled="false" Visible="false" />
                    <asp:CheckBox ID="chkAbilitaAggregazioni" runat="server" Font-Bold="True" Text="Abilita Aggregazioni per le imprese" />
                </div>

                <div class="col-sm-12 form-check">
                    <asp:CheckBox ID="chkAbilitaValutazione" runat="server" Font-Bold="True" Text="Abilita valutazione" />
                </div>
            </div>
        </div>
        <div class="col-sm-12 text-center pb-5">
            <Siar:Button ID="btnSalva" runat="server" OnClick="btnSalva_Click" Text="Salva"
                Modifica="True" />
            <Siar:Button ID="btnElimina" runat="server" OnClick="btnElimina_Click" Text="Elimina"
                Conferma="Attenzione! Eliminare il bando?" CausesValidation="False"
                Modifica="True" />
            <Siar:Button ID="btnPubblica" runat="server" Text="Pubblica" CausesValidation="False"
                Modifica="true" OnClick="btnPubblica_Click" Conferma="Attenzione! Si sta per pubblicare il bando selezionato, continuare?" />
        </div>
        <div class="col-sm-12 text-center">
            <input type="button" id="btnAggiungiIntegrazione" runat="server"
                value="Aggiungi integrazione" class="btn btn-secondary py-1" />
            <Siar:Button ID="btnEliminaIntegrazione" runat="server" OnClick="btnEliminaIntegrazione_Click"
                Text="Elimina ultima integrazione" CausesValidation="False" Conferma="Attenzione! Eliminare l`ultima integrazione inserita?"
                Modifica="False" />
            <Siar:Button ID="btnRiaperturaBando" runat="server" OnClick="btnRiaperturaBando_Click"
                Text="Duplica bando" CausesValidation="False" Conferma="Attenzione! Duplicare il bando?"
                Modifica="False" />
        </div>
        <div id="trDocumentale" runat="server" class="row">
            <h3 class="pb-5">Storico documentale:
            </h3>
            <div class="col-sm-12">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgDocumenti" runat="server" AllowPaging="true" PageSize="5" AutoGenerateColumns="false">
                    <Columns>
                        <Siar:NumberColumn>
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="CodStato">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="NumeroAtto" HeaderText="Numero atto">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataAtto" HeaderText="Data atto">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Stato" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Data" HeaderText="Data inserimento">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumnAgid Arguments="IdAtto" ButtonType="ImageButton" ButtonText="Visualizza documento"
                            JsFunction="visualizzaAtto" ButtonImage="it-search">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:JsButtonColumnAgid>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
            <div class="col-sm-12">
            </div>
            <td style="padding-top: 10px; padding-bottom: 20px">
                <table width="100%">
                    <tr>
                        <td></td>
                    </tr>
                </table>
            </td>
        </div>
        <div id="trDocumentaleOrganismi_inter" class="row" runat="server" visible="false">
            <div class="col-sm-12">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgDocumentiOrganismi_inter" runat="server" AllowPaging="true" PageSize="5" AutoGenerateColumns="false">
                    <Columns>
                        <Siar:NumberColumn>
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Numero" HeaderText="Numero atto">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Data" HeaderText="Data atto">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
        <div class="row">
            <h3 class="pb-5">Organigramma</h3>
            <div class="col-sm-6 form-group">
                <Siar:TextBox Label="Responsabile del bando:" ID="txtResponsabileBando" runat="server" />
                <asp:HiddenField ID="hdnIdResponsabileBando" runat="server" />
            </div>
            <div class="col-sm-6">
                <Siar:Button ID="btnSalvaResponsabili" runat="server" OnClick="btnSalvaResponsabili_Click"
                    Text="Salva Responsabile" Width="200px" Modifica="True" />
            </div>
            <div class="col-sm-12" style="display: none;">
                <table>
                    <tr style="display: none;">
                        <td style="display: none;">
                            <br />
                            <Siar:TextBox Label="Responsabile provincia di ANCONA:" ID="txtResponsabileAN" runat="server" Width="335px" />
                            <asp:HiddenField ID="hdnIdResponsabileAN" runat="server" />
                        </td>
                    </tr>
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
            </div>
        </div>
        <div class="row" runat="server" id="tdValutatori">
            <h3 class="pb-5">Definizione del comitato di valutazione del bando
            </h3>
            <p>
                La selezione del presidente è obbligatoria. Si consiglia di selezionare il presidente come prima persona dell'elenco dei membri del comitato di valutazione. Inoltre si consiglia di inserire i valutatori in ordine sequenziale: l'ordine viene inserito in modo automatico, per scambiare l'ordine di due valutatori basta selezionarli vicendevolmente dalla griglia e scambiare i nominativi, in questo modo verrà mantenuto l'ordine corretto.
            </p>
            <div class="col-sm-4 form-group">
                <Siar:TextBox Label="Membro del comitato:" ID="txtValutatore" runat="server" />
                <asp:HiddenField ID="hdnIdValutatore" runat="server" />
            </div>
            <div class="col-sm-2 form-check">
                <asp:CheckBox ID="chkPresidente" runat="server" Font-Bold="True" Text="Presidente" />
            </div>
            <div class="col-sm-6">
                <Siar:Button ID="btnAggiungiMembro" runat="server" OnClick="btnAggiungiMembro_Click"
                    Text="Aggiungi membro comitato" Modifica="True" />&nbsp;
                            <Siar:Button ID="btnEliminaMembro" runat="server" OnClick="btnEliminaMembro_Click"
                                Conferma="Attenzione! Eliminare il membro selezionato?" Text="Elimina membro"
                                Modifica="True" />&nbsp;
                            <Siar:Button ID="btnNewMembro" runat="server" Text="Nuovo" OnClick="btnNewMembro_Click"
                                CausesValidation="false" Modifica="true" />
            </div>
            <div class="col-sm-12">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgValutatori" runat="server" AllowPaging="true" PageSize="10"
                    AutoGenerateColumns="false">
                    <Columns>
                        <Siar:NumberColumn>
                        </Siar:NumberColumn>
                        <Siar:ColonnaLink DataField="Nominativo" HeaderText="Nominativo" LinkFields="IdValutatore"
                            LinkFormat='javascript:selezionaMembro({0})'>
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="Presidente" HeaderText="Presidente" DataFormatString="{0:SI|NO}">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Ordine" HeaderText="Ordine">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>
    <div class="tableTab row bd-form" id="tbProgrammazione" runat="server" visible="false">
        <h3 class="pb-5 mt-5">Programmazione principale:</h3>
        <div class="col-sm-4 form-group">
            <Siar:TextBox Label="Codice:" ID="txtPRGPREVCodice" runat="server" ReadOnly="True" />
        </div>
        <div class="col-sm-8 form-group">
            <Siar:TextBox Label="Descrizione:" ID="txtPRGPREVDescrizione" runat="server" ReadOnly="True" />
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgPRGPREVInterventi" runat="server" AllowPaging="true" PageSize="10"
                Width="100%" AutoGenerateColumns="false">
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
                    <Siar:CheckColumnAgid DataField="MisuraPrevalente" HeaderText="Misura prevalente">
                        <%-- <ItemStyle Width="50px" HorizontalAlign="Center" /> --%>
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
            <div style="display: none">
                <asp:HiddenField ID="hdnIdInterventoDel" runat="server" />
                <asp:Button ID="btnEliminaIntervento" runat="server" OnClick="btnEliminaIntervento_Click"
                    CausesValidation="false" />
            </div>
        </div>
        <h3 class="pb-5 mt-5">Aggiungere altri interventi alla programmazione principale:</h3>
        <div class="col-sm-12 form-group">
            <Siar:ComboZPsr Label="Selezionare il Por di riferimento:" ID="lstPsr" runat="server" AutoPostBack="true">
            </Siar:ComboZPsr>
            <div class="row mt-5" id="tbAzioni" runat="server" visible="false">
                <div class="col-sm-12 form-group">
                    <Siar:ComboZProgrammazione Label="Selezionare l'Azione:" ID="lstAzione" runat="server" AutoPostBack="True">
                    </Siar:ComboZProgrammazione>
                </div>
                <div class="col-sm-12">
                    <div class="select-wrapper">
                        <label for="<% =ddlInterventi.ClientID %>">Selezionare l'Intervento:</label>
                        <asp:DropDownList ID="ddlInterventi" runat="server" AppendDataBoundItems="true" AutoPostBack="true" onchange="DropDownIntervento();">
                            <asp:ListItem Selected="True" Text="-- selezionare un valore --" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField ID="hdnIdIntervento" runat="server" />
                    </div>
                </div>
                <div class="col-sm-12 mt-5">
                    <Siar:Button ID="btnAddProgrammazione" runat="server" OnClick="btnAddProgrammazione_Click" Visible="false"
                        Text="Aggiungi intervento" Modifica="True" />
                </div>
            </div>
        </div>
        <div runat="server" id="trDisposizioniAttuative" visible="false">
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
        </div>
    </div>
    <div class="tableTab row" id="tbFinanziario" runat="server" visible="false">
        <h3 class="pb-5">Dettagli finanziari generali:
        </h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgFINTipoInvestimenti" runat="server" AllowPaging="false"
                AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Tipologia">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:BoundColumn>
                    <Siar:ImportoColumn DataField="CodTipoInvestimento" Name="ImportoMin" HeaderText="Importo Minimo"
                        Importo="ImportoMin">
                        <ItemStyle HorizontalAlign="center"></ItemStyle>
                    </Siar:ImportoColumn>
                    <Siar:ImportoColumn DataField="CodTipoInvestimento" Name="ImportoMax" HeaderText="Importo Massimo"
                        Importo="ImportoMax">
                        <ItemStyle HorizontalAlign="center"></ItemStyle>
                    </Siar:ImportoColumn>
                    <Siar:PercentualeColumn DataField="CodTipoInvestimento" Name="QuotaMax" Quota="QuotaMax"
                        HeaderText="% Max">
                        <ItemStyle HorizontalAlign="center"></ItemStyle>
                    </Siar:PercentualeColumn>
                    <Siar:TextColumn DataField="CodTipoInvestimento" Name="Note" Testo="Note" HeaderText="Note">
                        <ItemStyle HorizontalAlign="center"></ItemStyle>
                    </Siar:TextColumn>
                    <Siar:CheckColumnAgid DataField="CodTipoInvestimento" Name="chkTipoInvestimento" HeaderSelectAll="true">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnFINTipoInvSalva" runat="server" OnClick="btnFINTipoInvSalva_Click"
                Text="Salva dettagli finanziari" Modifica="True" />
        </div>
        <div class="col-sm-12">
            <h3 class="pb-5 mt-5">Massimali di aiuto per tipologia di intervento:</h3>
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgFINMassimali" runat="server" AllowPaging="false"
                AutoGenerateColumns="False">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn HeaderText="Tipologia di intervento">
                        <ItemStyle CssClass="testo_pagina" />
                    </asp:BoundColumn>
                    <Siar:PercentualeColumn DataField="IdProgrammazione" HeaderText="Quota max %" Name="dgtxtQuotaMax"
                        Quota="Quota">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:PercentualeColumn>
                    <Siar:ImportoColumn DataField="IdProgrammazione" HeaderText="Importo max €" Name="dgtxtImportoMax"
                        Importo="Importo">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:ImportoColumn>
                    <Siar:CheckColumnAgid DataField="IdProgrammazione" HeaderSelectAll="true" Name="chkIdProgrammazione">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="col-sm-12 pb-5">
            <Siar:Button ID="btnFINMassimaliSalva" runat="server" OnClick="btnFINMassimaliSalva_Click"
                Text="Salva massimali di aiuto" Modifica="True" />
        </div>
    </div>
    <div class="tableTab row" id="tbBusinessPlan" runat="server" visible="false">
        <h3 class="pb-5 mt-5">Selezionare i quadri che sarà obbligatorio compilare alla presentazione della domanda:</h3>
        <div class="col-sm-12">
            <td style="padding-top: 10px; padding-bottom: 10px">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgBPQuadri" runat="server" AllowPaging="false" AutoGenerateColumns="False">
                    <ItemStyle Height="26px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="35px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Titolo" HeaderText="Titolo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Quadro" HeaderText="Descrizione"></asp:BoundColumn>
                        <Siar:CheckColumnAgid DataField="IdQuadro" Name="chkBPQuadro" HeaderSelectAll="true">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:CheckColumnAgid>
                    </Columns>
                </Siar:DataGridAgid>
        </div>
        <div class="col-sm-12 mp-5">
            <Siar:Button ID="btnBPSalva" runat="server" Text="Salva" Modifica="True"
                OnClick="btnBPSalva_Click" CausesValidation="False" />
        </div>
    </div>
    <div class="row bd-form" id="tbRelazioneTecnica" runat="server" visible="false">
        <h3 class="mt-5 pb-5">Dettaglio paragrafo:</h3>
        <div class="col-sm-10 form-group">
            <Siar:TextBox Label="Titolo:" ID="txtRELTitolo" runat="server" NomeCampo="Titolo paragrafo"
                Obbligatorio="true" />
        </div>
        <div class="col-sm-2 form-group">
            <Siar:IntegerTextBox Label="Ordine:" ID="txtRELOrdine" runat="server" NomeCampo="Ordine" Obbligatorio="True" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Descrizione:" ID="txtRELDescrizione" runat="server" NomeCampo="Descrizione paragrafo"
                Rows="6" Obbligatorio="true" MaxLength="2000" />
            <asp:HiddenField ID="hdnIdParagrafo" runat="server" />
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnRELParagrafoSalva" runat="server" OnClick="btnRELParagrafoSalva_Click"
                Text="Salva" Modifica="True" />
            <Siar:Button ID="btnRELParagrafoElimina" runat="server" OnClick="btnRELParagrafoElimina_Click"
                Text="Elimina" Conferma="Attenzione! Eliminare il paragrafo selezionato?"
                Modifica="True" CausesValidation="false" />
            <input class="btn btn-secondary py-1" type="button" value="Nuovo" onclick="dettaglioRELParagrafo(null);" />
        </div>
        <h3 class="mt-5 pb-5">Elenco paragrafi::</h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgRELParagrafi" runat="server" AllowPaging="false"
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
                    <Siar:JsButtonColumnAgid Arguments="IdParagrafo" ButtonText="Dettaglio" ButtonType="TextButton"
                        JsFunction="dettaglioRELParagrafo">
                        <ItemStyle Width="120px" />
                    </Siar:JsButtonColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
    <div class="tableTab row" id="tbAvanzate" runat="server" visible="false">
        <h3 class="mt-5 pb-5">Impostazioni avanzate (<b>non modificare</b> se non si sa esattamente cosa si sta facendo):
        </h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgBandoConfig" runat="server" Width="100%" AllowPaging="false"
                AutoGenerateColumns="False">
                <ItemStyle Height="28px" />
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="CodMacroTipo" HeaderText="Fase">
                        <ItemStyle Width="130px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CodTipo" HeaderText="Codice">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Formato" HeaderText="Formato">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn>
                        <ItemStyle />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="col-sm-12 pb-5">
            <Siar:Button ID="btnSalvaConfig" runat="server" Text="Salva" Width="190px" Modifica="True"
                OnClick="btnSalvaConfig_Click" CausesValidation="False" />
        </div>
    </div>
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
                                <asp:TextBox CssClass="rounded" ID="txtLinkEst" runat="server" Width="630px" />
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
    <uc2:ZoomLoader ID="zmlDecretoBando" runat="server" ColumnsToBind="Numero:Numero:id|Data:Data:d|Registro:Registro:id|Definizione:DefinizioneAtto:id|Descrizione"
        KeySearch="Numero|Data:Data:d|Definizione atto:CodDefinizione:lst:ComboDefinizioneAtto"
        KeyText="Descrizione" KeyValue="IdAtto" SearchMethod="GetDecreti" NoClear="true"
        AutomaticSearch="false" JsSelectedItemHandler="zmlDecretoBandoSelectFn" Visible="False"
        Width="1000px" TitoloFinestra="Selezione dell`atto amministrativo" />
</asp:Content>
