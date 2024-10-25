<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.RichiestaDocumentiIntegrativi" CodeBehind="RichiestaDocumentiIntegrativi.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function pulisciCampi() { $('[id$=lstNACategoria]').val(''); $('[id$=txtNADescrizioneBreve]').val(''); }
        function ctrlCampi(ev) { var lst = $('[id$=lstNACategoria]'), items = $(lst).find('option:selected');/*.find('option[selected=true]');*/if ($(lst).val() == '' || items.length == 0) { alert('Selezionare una categoria di documento.'); return stopEvent(ev); } }
        function chiudiPopup() { pulisciCampi(); chiudiPopupTemplate(); }
        function ucRDocElimina(id) { if (confirm('Escludere il documento dalla presente richiesta?')) { $('[id$=hdnIdPCAllegato]').val(id); $('[id$=btnEliminaAllegato]').click(); } }
    </script>


    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />

    <div style="display: none">
        <input type="hidden" id="hdnIdPCAllegato" runat="server" />
        <asp:Button ID="btnEliminaAllegato" runat="server" OnClick="btnEliminaAllegato_Click" />
    </div>

    <h3 class="fw-bold my-5">Richiesta di documentazione a supporto dell'istruttoria</h3>
    <div class="b">
        <ul>
            <li><b>Fase 1</b> - Il funzionario istruttore definisce la documentazione, corredata da un testo esplicativo,
                             che l'azienda beneficiaria dovrà produrre ai fini della prosecuzione dell'istruttoria della domanda in oggetto.
                <br />
                Questa fase termina non appena la richiesta viene predisposta alla firma .
            </li>
            <li>
                <b>Fase 2</b> - Il responsabile provinciale di istruttoria, dopo aver preso visione del
                documento, firma e invia la richiesta all'indirizzo Pec dell'azienda beneficiaria.
            </li>
            <li>
                <b>Fase 3</b> - Il funzionario istruttore o il responsabile registra la segnatura di protocollo
                in ingresso della risposta pervenuta da parte dell&#39;azienda aggiungendo, qualora lo ritenga necessario, delle note a margine.
            Si ricorda che tale segnatura deve corrispondere ad un protocollo effettivamente acquisito sul sistema di protocollazione regionale.           
            </li>
        </ul>
    </div>
    <h5 class="fw-bold py-5">Fase 1 - Predisposizione (a cura del funzionario istruttore)</h5>
    <div class="row py-3">
        <div id="tdDocumenti" runat="server" />
    </div>

    <div class="grid-row px-2">
        <Siar:Button Text="Aggiungi Documento" runat="server" ID="btnNADettaglio" OnClick="btnNADettaglio_Click" />
        <Siar:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalva_Click" />
        <Siar:Button ID="btnElimina" runat="server" Text="Elimina" OnClick="btnElimina_Click" />
        <Siar:Button ID="btnPredisponi" runat="server" Text="Predisponi alla firma" OnClick="btnPredisponi_Click" Conferma="Procedere con la predisposizione alla firma?" />
        <input type="button" class="btn btn-secondary py-1" value="Indietro" onclick="history.back();" />
    </div>


    <h5 class="fw-bold py-5">Fase 2 - Firma e invio via Pec (a cura del responsabile provinciale)</h5>

    <div class="grid-row py-3 px-2">
        <Siar:Button ID="btnFirma" runat="server" Text="Firma e invia" OnClick="btnFirma_Click" Enabled="false" />
        <input type="button" class="btn btn-secondary py-1" id="btnStampaRichiesta" runat="server" disabled="disabled" value="Visualizza documento" />
    </div>
    <h5 class="fw-bold py-5">Fase 3 - Acquisizione documentazione in ingresso</h5>
    <div class="row py-3 bd-form pt-5">
        <div class="col-sm-12 form-group">
            <Siar:TextBox runat="server" ID="txtSegnaturaRisposta" CssClass="active fw-semibold" Label="Digitare la segnatura del protocollo della risposta in ingresso" MaxLength="80" NomeCampo="Segnatura del Protocollo della risposta" />
        </div>
        <div class="col-sm-12 form-group">
            <label class="active fw-semibold" for="txtNoteRisposta">Note a margine (max 3000 caratteri)</label>
            <Siar:TextArea ID="txtNoteRisposta" runat="server" MaxLength="3000" ExpandableRows="10" />
        </div>
    </div>
    <div class="row py-3">
        <div class="col-sm-3">
            <Siar:Button ID="btnSalvaSegnaturaRisposta" runat="server" Text="Salva" OnClick="btnSalvaSegnaturaRisposta_Click" Enabled="false" />
        </div>
    </div>
    <uc3:FirmaDocumento ID="ucFirmaDocumento" runat="server" Titolo="PAGINA DI FIRMA DELLA RICHIESTA DI DOCUMENTAZIONE INTEGRATIVA" DoppiaFirma="false" TipoDocumento="RICHIESTA_DOCUMENTAZIONE_INTEGRATIVA" />


    <div id="divSchedaForm" class="modal it-dialog" tabindex="-1" role="dialog" style="display: none; position: absolute">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="fw-bold">Nuovo allegato</h5>
                </div>
                <div class="modal-body">
                    <div class="row py-3">
                        <div class="col-sm-12">
                            <Siar:ComboSql ID="lstNACategoria" runat="server" Label="Selezionare la categoria del documento" OptionalValue="COD_TIPO" DataTextField="DESCRIZIONE" DataValueField="ID_ALLEGATO"></Siar:ComboSql>
                        </div>
                    </div>
                    <div class="row py-3">
                        <div class="col-sm-12">
                            <Siar:TextArea ID="txtNADescrizioneBreve" runat="server" Rows="3" MaxLength="3000" />
                        </div>
                    </div>
                    <div class="grid-row py-3 px-2">
                        <Siar:Button ID="btnNASalva" Text="Salva" runat="server" CausesValidation="false" OnClick="btnNASalva_Click" OnClientClick="return ctrlCampi(event);" />
                        <input onclick="pulisciCampi();" type="button" class="btn btn-secondary py-1" value="Nuovo" />
                        <input id="btnNAChiudi" class="btn btn-secondary py-1" onclick="chiudiPopup()" type="button" value="Chiudi" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divPopupDomanda" class='ajaxResp'>
    </div>
</asp:Content>
