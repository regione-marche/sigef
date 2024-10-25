<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" Inherits="web.Private.IPagamento.RevisioneDomandeNew" CodeBehind="RevisioneDomandeNew.aspx.cs" %>

<%@ Register Src="~/CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<%@ Register Src="~/CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/ucChecklistGenerica.ascx" TagName="ChecklistGenerica" TagPrefix="uc4" %>
<%@ Register Src="~/CONTROLS/IBandoInfoControl.ascx" TagName="InfoBando" TagPrefix="uc5" %>
<%@ Register Src="~/CONTROLS/ucSceltaChecklistValidazione.ascx" TagName="ucSceltaChecklist" TagPrefix="uc6" %>

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
            min-width: 200px;
            max-width: 200px;
            width: 200px;
            text-align: right;
            vertical-align: middle;
        }

        .value {
            float: right;
            margin-left: 5px;
        }
    </style>

    <script type="text/javascript">

        function selezionaDomandaPagamentoInv(id) {
            $('[id$=hdnIdDomandaPagamentoInv]').val($('[id$=hdnIdDomandaPagamentoInv]').val() == id ? '' : id);
            $('[id$=btnPost]').click();
        }

        function SelezionaTestata(id_testata) {
            $('[id$=hdnIdTestata]').val($('[id$=hdnIdTestata]').val() == id_testata ? '' : id_testata);
            $('[id$=btnPost]').click();
        }

        function SelezionaIstanza(id_istanza) {
            $('[id$=hdnIdTestataXIstanza]').val($('[id$=hdnIdTestataXIstanza]').val() == id_istanza ? '' : id_istanza);
            $('[id$=btnPost]').click();
        }

        function EliminaChecklist(id_istanza) {
            var domanda = confirm("Sei sicuro di voler eliminare la checklist?");
            if (domanda === true) {
                $('[id$=hdnIdIstanzaEliminazione]').val($('[id$=hdnIdIstanzaEliminazione]').val() == id_istanza ? '' : id_istanza);
                $('[id$=btnPostEliminaIstanza]').click();
            }
        }

        function CopiaValidazione(id_validazione) {
            var domanda = confirm("Sei sicuro di voler copiare la validazione?");
            if (domanda === true) {
                $('[id$=hdnIdValidazioneCopia]').val($('[id$=hdnIdValidazioneCopia]').val() == id_validazione ? '' : id_validazione);
                $('[id$=btnPostCopiaValidazione]').click();
            }
        }

        function SNCVZCercaValidatori_onselect(obj) {
            if (obj) {
                $('[id$=hdnIdUtenteValidatore]').val(obj.IdUtente);
                $('[id$=txtOperatoreValidatore_text]').val(obj.Nominativo);
            }
            else
                alert('L`elemento selezionato non è valido.');
        }

        function SNCVZCercaValidatori_onprepare() {
            $('[id$=hdnIdUtenteValidatore]').val('');
        }

        function checkValidatore() {
            var txtOperatoreValidatore = $('[id$=txtOperatoreValidatore]').val();
            var IdUtenteValidatore = $('[id$=hdnIdUtenteValidatore]').val();

            if (txtOperatoreValidatore == "" || IdUtenteValidatore == "") {
                alert("Selezionare un utente valido per assegnare la validazione.");
                return false;
            }

            return true;
        }

    </script>

    <div style="display: none">
        <Siar:Button ID="btnPost" runat="server" CausesValidation="False" OnClick="btnPost_Click" />
        <Siar:Button ID="btnPostEliminaIstanza" runat="server" CausesValidation="false" OnClick="btnPostEliminaIstanza_Click" />
        <Siar:Button ID="btnPostCopiaValidazione" runat="server" CausesValidation="false" OnClick="btnPostCopiaValidazione_Click" />
        <asp:HiddenField ID="hdnIdDomandaPagamentoInv" runat="server" />
        <asp:HiddenField ID="hdnIdTestata" runat="server" />
        <asp:HiddenField ID="hdnIdTestataXIstanza" runat="server" />
        <asp:HiddenField ID="hdnIdIstanzaEliminazione" runat="server" />
        <asp:HiddenField ID="hdnIdValidazioneCopia" runat="server" />
    </div>

    <uc5:InfoBando ID="ucInfoBando" runat="server" />

    <uc1:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />

    <%-- <div class="container-fluid">--%>
    <h3 class="pt-4 pb-1">Validazione dell'istruttoria della domanda di pagamento</h3>

    <%-- <div id="divValidazioneInviate" runat="server" visible="false">
            <p>
                Di seguito sono elencate le domande di pagamento già approvate dello stesso lotto per le quali 
                è possibile riproporre la checklist compilata per la domanda in lavorazione
            </p>

            <Siar:DataGridAgid ID="dgDomande" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="20">
                 <HeaderStyle CssClass="headerStyle" />
                <ItemStyle CssClass="DataGridRow itemStyle" />
                <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                <Columns>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Numero domanda di aiuto">
                        <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" Width="110px" />
                    </asp:BoundColumn>
                    <Siar:ColonnaLink ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Center" DataField="IdDomandaPagamento"
                        HeaderText="Numero domanda di pagamento" IsJavascript="true" ItemStyle-Font-Bold="true"
                        LinkFields="IdDomandaPagamento" LinkFormat="selezionaDomandaPagamentoInv({0});">
                    </Siar:ColonnaLink>
                    <asp:BoundColumn DataField="TipoDomandaPagamento" HeaderText="Modalit&#224; della richiesta">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataPresentazioneDomandaPagamento" HeaderText="Data di presentazione">
                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="IdDomandaPagamento" OnCheckClick="return false;" ReadOnly="true" HeaderText=" ">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </Siar:CheckColumn>
                </Columns>
            </Siar:DataGridAgid>
            <br />

            <Siar:Button ID="btnCopia" runat="server" Modifica="True" OnClick="btnCopia_Click" Text="Copia Checklist" Width="200px" />
            <br />
        </div>--%>

    <div id="divSelezioneTestata" class="container-fluid bg-100">
        <div class="d-flex flex-row justify-content-between pt-4">
            <div class="flex-column">
                <Siar:Button ID="btnAggiungiRevisione" runat="server" CausesValidation="false" CssClass="btn btn-primary" Text="Crea nuova validazione" OnClick="btnAggiungiRevisione_Click" />
            </div>
            <div class="flex-column">
                <input id="btnBack" runat="server" class="btn btn-secondary py-2 " type="button" onclick="location = 'ValidazioneDomandePagamentoNew.aspx'" value="Indietro" />
            </div>
        </div>

        <div class="row pt-3">
            <p class="fw-semibold">
                Di seguito sono elencate le validazioni dell'istruttoria della domanda di pagamento. E' da considerarsi valida l'ultima validazione inserita.<br />
                E' possibile creare una nuova validazione che diventerà quella di riferimento. La nuova validazione avrà la stessa checklist e gli stessi esiti della validazione di riferimento precedente.
            </p>
        </div>
        <div class="row">
            <div class="col-12">
                <div class="table-responsive">
                    <Siar:DataGridAgid ID="dgTestateValidazioni" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemStyle CssClass="DataGridRow itemStyle" />
                        <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                        <Columns>
                            <asp:BoundColumn DataField="IdTestata" HeaderText="Id">
                                <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IdProgetto" HeaderText="Id Domanda aiuto">
                                <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Id Domanda pagamento">
                                <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TipoDomandaPagamento" HeaderText="Modalità della richiesta">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DataPresentazioneDomandaPagamento" HeaderText="Data di presentazione domanda">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="NominativoValidatore" HeaderText="Validatore">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DataInserimento" HeaderText="Data di inizio validazione">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DataValidazione" HeaderText="Data validazione">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Approvata" DataFormatString="{0:SI|NO}" HeaderText="Controllo positivo">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="SegnaturaRevisione" HeaderText="Protocollo">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <Siar:JsButtonColumnAgid Arguments="IdTestata" ButtonType="TextButton" ButtonText="Seleziona validazione" JsFunction="SelezionaTestata">
                                <ItemStyle HorizontalAlign="Left" />
                            </Siar:JsButtonColumnAgid>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
        </div>
    </div>
    
    <div id="divCambioValidatore" runat="server" visible="false" class="container-fluid bg-100 rounded-2">
    <h3 class="mt-5 pb-2">Cambio validatore</h3>
    <div class="row py-2">
        <p class="py-3 fw-semibold">
            Se la validazione non è ancora stata resa definitiva è possibile assegnarla ad un altro validatore del bando.       
        </p>
        <div class="col-sm-5 form-group">
            <Siar:TextBox Label="Seleziona l'operatore" ID="txtOperatoreValidatore" runat="server" />
        </div>
        <div class="col-sm-2">
            <Siar:Button ID="btnValidatore" runat="server" OnClick="btnValidatore_Click" OnClientClick=" return checkValidatore();" Text="Assegna a validatore" />
            <asp:HiddenField ID="hdnIdUtenteValidatore" runat="server" />
        </div>
    </div>
    <div id="divCopiaEsitiAiuti" runat="server" visible="false" class="row py-2">
        <h3 class="mt-5 pb-5">Copia esiti e note</h3>
        <p class="mb-3">
            Se la validazione non è ancora stata resa definitiva è possibile copiare gli esiti e le note da un altra domanda di pagamento purchè 
                    rientri tra gli aiuti e sia già stata approvata e firmata. Inoltre le checklist devono essere dello stesso tipo e non con le vecchie checklist (con nome "Revisione_Old"). Copiare gli esiti permette ancora la modifica della validazione in corso in tutte le sue informazioni. Inserire nella textbox sottostante l'id della domanda di pagamento da cui copiare gli esiti e le note.
       
        </p>
        <div class="col-sm-10 form-group">
            <Siar:TextBox Label="Id domanda di pagamento " ID="txtIdDomandaPagamentoDaCopiare" runat="server" />
        </div>
        <div class="col-sm-2">
            <Siar:Button ID="btnCopiaEsiti" runat="server" OnClick="btnCopiaEsiti_Click" Enabled="false" Text="Copia esiti" />
        </div>
    </div>
    </div>
    <div id="divSelezioneIstanza" runat="server" visible="false">

        <h5 class="paragrafo_bold ms-1">Checklist</h5>

        <div class="container-fluid bg-100">
            <p class="fw-semibold pt-3">
                Di seguito sono elencate le <b>checklist</b> per la validazione dell'istruttoria della domanda di pagamento selezionata. 
                Selezionandone una vengono mostrati gli <b>step operativi</b> e l'esito.
            </p>
            <div id="divValidazioniPrecedenti" runat="server">
                <p>
                    E' possibile copiare una validazione usata in una domanda di pagamento precedente.<br />
                    Copiando una validazione precedente si copieranno anche i rispettivi esiti e si elimineranno le eventuali checklist attualmente in compilazione.
                </p>
                <div class="row">
                    <div class="table-striped">
                        <Siar:DataGridAgid runat="server" CssClass="table table-striped" ID="dgValidazioniPrecedenti" AutoGenerateColumns="False" PageSize="20">
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemStyle CssClass="DataGridRow itemStyle" />
                            <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                            <Columns>
                                <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Id domanda pagamento">
                                    <ItemStyle Font-Bold="True" HorizontalAlign="Center" Width="150px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="TipoDomandaPagamento" HeaderText="Tipo domanda pagamento">
                                    <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <Siar:JsButtonColumnAgid Arguments="IdTestata" HeaderText="Copia validazione" ButtonType="TextButton" ButtonText="Copia" JsFunction="CopiaValidazione">
                                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                                </Siar:JsButtonColumnAgid>
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                </div>
            </div>

            <div class="d-flex flex-row justify-content-start align-items-center py-2">
                <Siar:Button ID="btnAggiungiChecklist" Modifica="true" runat="server" CausesValidation="false" Text="Aggiungi checklist" OnClick="btnAggiungiChecklist_Click" />
            </div>
            <div class="d-flex flex-row">
                <div class="table-striped">
                    <Siar:DataGridAgid CssClass="table table-striped" ID="dgIstanze" runat="server" AutoGenerateColumns="false">
                       <%-- <HeaderStyle CssClass="headerStyle" />--%>
                        <ItemStyle CssClass="DataGridRow itemStyle" />
                        <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                        <Columns>
                            <asp:BoundColumn DataField="IdTestataValidazioneXIstanza" HeaderText="Id">
                                <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DescrizioneChecklist" HeaderText="Descrizione checklist">
                                 <HeaderStyle HorizontalAlign="Left" />
                                 <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Note" HeaderText="Note"></asp:BoundColumn>
                            <Siar:JsButtonColumnAgid Arguments="IdTestataValidazioneXIstanza" ButtonType="TextButton" ButtonText="Seleziona checklist" JsFunction="SelezionaIstanza">
                              <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </Siar:JsButtonColumnAgid>
                            <Siar:JsButtonColumnAgid Arguments="IdTestataValidazioneXIstanza" HeaderText="Elimina" ButtonType="ImageButton" ButtonImage="xdel.gif" JsFunction="EliminaChecklist">
                                <ItemStyle HorizontalAlign="Center" />
                            </Siar:JsButtonColumnAgid>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
            <div id="divDettaglioValidazione" runat="server" visible="false" class="row py-1 bg-100">
                <div class="row mt-1">
                    <uc4:ChecklistGenerica ID="ucChecklistGenerica" runat="server" DefaultRedirect="../IPagamento/ValidazioneDomandePagamentoNew.aspx" />
                </div>
                <div class="col-sm-12 form-group mt-5">
                    <Siar:TextArea Label="Note checklist" ID="txtNoteChecklist" runat="server" NomeCampo="Note checklist" Obbligatorio="false" Rows="4" ExpandableRows="5" MaxLength="10000" />
                </div>
                <div class="col-sm-12">
                    <Siar:Button ID="btnSalvaChecklist" runat="server" OnClick="btnSalvaChecklist_Click" Text="Salva note checklist" Modifica="true" />
                </div>
            </div>
        </div>
        <h5 class="paragrafo_bold ms-1 py-1">Dati validazione</h5>
        <div class="row justify-content-start align-items-center py-4">
            <div class="col-sm-2">
                <Siar:DateTextBoxAgid ID="txtDataValidazione" runat="server" Label="Data validazione" />
            </div>
            <div class="col-sm-2 mb-4">
                <Siar:ComboYesNo  ID="lstEsitoValidazione" Label="Esito validazione" runat="server" NoBlankItem="true"></Siar:ComboYesNo>
            </div>
        </div>
        <div class="row justify-content-start align-items-center py-4">
            <div class="col-sm-12">
                <Siar:Button ID="btnSave" runat="server" Modifica="True" OnClick="btnSave_Click" Text="Salva validazione" />
                <Siar:Button ID="btnFirmaRevisione" runat="server" CausesValidation="false" Enabled="false" Text="Rendi definitiva" OnClick="btnFirmaRevisione_Click" />
                <input id="btnVisualizzaAutovalutazione" runat="server" type="button" class="btn btn-secondary py-1" value="Visualizza autovalutazione" />
                <input type="button" class="btn btn-secondary py-1" value="Indietro" onclick="history.back();" />
            </div>
        </div>

    </div>
    <uc3:FirmaDocumento ID="ucFirmaRevisione" runat="server" Titolo="PAGINA DI FIRMA DELLA CHECKLIST DI REVISIONE DOMANDA DI PAGAMENTO" TipoDocumento="CKL_REVISIONE_PAGAMENTO" />
    <uc6:ucSceltaChecklist ID="modaleSceltaChecklist" runat="server" />
</asp:Content>
