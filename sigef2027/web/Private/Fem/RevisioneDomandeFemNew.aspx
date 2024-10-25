<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" Inherits="web.Private.Fem.RevisioneDomandeFemNew" CodeBehind="RevisioneDomandeFemNew.aspx.cs" %>

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
    <br />

    <uc1:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <br />

    <div class="dBox">
        <div class="separatore_big">
            Validazione dell'istruttoria della domanda di pagamento
        </div>
        <br />

        <div style="padding: 10px;">
            <div id="divValidazioneInviate" runat="server" visible="false">
                <p>
                    Di seguito sono elencate le domande di pagamento già approvate dello stesso lotto per le quali 
                    è possibile riproporre la checklist compilata per la domanda in lavorazione:
                </p>
                <br />

                <Siar:DataGrid ID="dgDomande" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="20">
                    <ItemStyle Height="26px" />
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
                </Siar:DataGrid>
                <br />

                <Siar:Button ID="btnCopia" runat="server" Modifica="True" OnClick="btnCopia_Click" Text="Copia Checklist" Width="200px" />
                <br />
            </div>

            <div id="divSelezioneTestata" runat="server">
                <div class="first_elem_block">
                    <Siar:Button ID="btnAggiungiRevisione" runat="server" CausesValidation="false" Text="Crea nuova validazione" Style="width: 160px;" OnClick="btnAggiungiRevisione_Click" />
                </div>

                <div class="elem_block">
                    <input id="btnBack" runat="server" class="Button" style="width: 120px" type="button" onclick="location='ValidazioneDomandeFemNew.aspx'" value="Indietro" />
                </div>
                <br />
                <br />

                <p>
                    Di seguito sono elencate le validazioni dell'istruttoria della domanda di pagamento. E' da considerarsi valida l'ultima validazione inserita.<br />
                    E' possibile creare una nuova validazione che diventerà quella di riferimento. La nuova validazione avrà la stessa checklist e gli stessi esiti della validazione di riferimento precedente.
                </p>
                <br />

                <Siar:DataGrid ID="dgTestateValidazioni" runat="server" AutoGenerateColumns="false">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <asp:BoundColumn DataField="IdTestata" HeaderText="Id">
                            <ItemStyle Font-Bold="True" HorizontalAlign="Center" Width="40px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Id Domanda aiuto">
                            <ItemStyle Font-Bold="True" HorizontalAlign="Center" Width="40px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Id Domanda pagamento">
                            <ItemStyle Font-Bold="True" HorizontalAlign="Center" Width="40px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoDomandaPagamento" HeaderText="Modalità della richiesta">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataPresentazioneDomandaPagamento" HeaderText="Data di presentazione domanda">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="NominativoValidatore" HeaderText="Validatore">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataInserimento" HeaderText="Data di inizio validazione">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataValidazione" HeaderText="Data validazione">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Approvata" DataFormatString="{0:SI|NO}" HeaderText="Controllo positivo">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SegnaturaRevisione" HeaderText="Protocollo">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdTestata" ButtonType="TextButton" ButtonText="Seleziona validazione" JsFunction="SelezionaTestata">
                            <ItemStyle HorizontalAlign="Center" Width="200px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
                <br />

            </div>

            <div id="divSelezioneIstanza" runat="server" visible="false">
                <p>
                    Di seguito sono elencate le <b>checklist</b> per la validazione dell'istruttoria della domanda di pagamento selezionata.<br />
                    Selezionandone una vengono mostrati gli <b>step operativi</b> e l'esito.
                </p>
                <br />

                <%--<div>
                    <div class="paragrafo">
                        Esiti dei controlli:
                    </div>
                    <br />

                    <div class="first_elem_block">
                        <div class="label">Esito prima validazione:</div>
                        <div class="value">
                            <Siar:TextBox  ID="txtEsitoPrimaRevisione" runat="server" ReadOnly="True" Width="150px" />
                            <img id="imgSegnatura" runat="server" height="20" src="~/images/lente.png" width="20" title="Visualizza documento" alt="Lente di ingradimento" />
                        </div>
                    </div>

                    <div class="elem_block">
                        <div class="label">Esito seconda validazione:</div>
                        <div class="value">
                            <Siar:TextBox  ID="txtEsitoSecondaRevisione" runat="server" ReadOnly="True" Width="150px" />
                            <img id="imgSecondaSegnatura" runat="server" height="20" src="~/images/lente.png" width="20" title="Visualizza documento" alt="Lente di ingradimento" />
                        </div>
                    </div>
                    <br />

                </div>
                <br />--%>

                <div class="paragrafo">
                    Checklist:
                </div>
                <br />

                <div id="divValidazioniPrecedenti" runat="server">
                    <p>
                        E' possibile copiare una validazione usata in una domanda di pagamento precedente.<br />
                        Copiando una validazione precedente si copieranno anche i rispettivi esiti e si elimineranno le eventuali checklist attualmente in compilazione.
                    </p>
                    <br />

                    <Siar:DataGrid ID="dgValidazioniPrecedenti" runat="server" Width="100%" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Id domanda pagamento">
                                <ItemStyle Font-Bold="True" HorizontalAlign="Center" Width="150px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TipoDomandaPagamento" HeaderText="Tipo domanda pagamento">
                                <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <Siar:JsButtonColumn Arguments="IdTestata" HeaderText="Copia validazione" ButtonType="TextButton" ButtonText="Copia" JsFunction="CopiaValidazione">
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </Siar:JsButtonColumn>
                        </Columns>
                    </Siar:DataGrid>
                    <br />
                    <br />
                </div>

                <div class="first_elem_block">
                    <Siar:Button ID="btnAggiungiChecklist" Modifica="true" Visible="false" runat="server" CausesValidation="false" Text="Aggiungi checklist" Style="width: 160px;" OnClick="btnAggiungiChecklist_Click" />
                </div>
                <br />
                <br />

                <Siar:DataGrid ID="dgIstanze" runat="server" Width="100%" AutoGenerateColumns="false">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <asp:BoundColumn DataField="IdTestataValidazioneXIstanza" HeaderText="Id">
                            <ItemStyle Font-Bold="True" HorizontalAlign="Center" Width="40px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DescrizioneChecklist" HeaderText="Descrizione checklist"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Note" HeaderText="Note">
                            <ItemStyle Width="200px" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdTestataValidazioneXIstanza" ButtonType="TextButton" ButtonText="Seleziona checklist" JsFunction="SelezionaIstanza">
                            <ItemStyle HorizontalAlign="Center" Width="200px" />
                        </Siar:JsButtonColumn>
                        <Siar:JsButtonColumn Arguments="IdTestataValidazioneXIstanza" HeaderText="Elimina" ButtonType="ImageButton" ButtonImage="xdel.gif" JsFunction="EliminaChecklist">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
                <br />
                <br />

                <div id="divDettaglioValidazione" runat="server" visible="false">
                    <%--<p>
                        Di seguito sono elencati gli <b>step operativi</b> della checklist di controllo documentale per la validazione dell'istruttoria della domanda di pagamento selezionata.<br />
                        Per ognuno di essi vengono mostrati anche l'esito e la valutazione del funzionario assegnato.
                    </p>
                    <br />

                    <div>
                        <div class="paragrafo">
                            Esiti dei controlli:
                        </div>
                        <br />

                        <div class="first_elem_block">
                            <div class="label">Esito prima validazione:</div>
                            <div class="value">
                                <Siar:TextBox  ID="txtEsitoPrimaRevisione" runat="server" ReadOnly="True" Width="150px" />
                                <img id="imgSegnatura" runat="server" height="20" src="~/images/lente.png" width="20" title="Visualizza documento" alt="Lente di ingradimento" />
                            </div>
                        </div>

                        <div class="elem_block">
                            <div class="label">Esito seconda validazione:</div>
                            <div class="value">
                                <Siar:TextBox  ID="txtEsitoSecondaRevisione" runat="server" ReadOnly="True" Width="150px" />
                                <img id="imgSecondaSegnatura" runat="server" height="20" src="~/images/lente.png" width="20" title="Visualizza documento" alt="Lente di ingradimento" />
                            </div>
                        </div>
                        <br />

                    </div>--%>

                    <br />
                    <uc4:ChecklistGenerica ID="ucChecklistGenerica" runat="server" DefaultRedirect="../Fem/ValidazioneDomandeFemNew.aspx" />
                    <br />

                    <div class="first_elem_block">
                        <div class="label">Note checklist: </div>
                        <div class="value">
                            <Siar:TextArea ID="txtNoteChecklist" runat="server" NomeCampo="Note checklist" Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                        </div>
                    </div>
                    <br />

                    <div class="first_elem_block">
                        <Siar:Button ID="btnSalvaChecklist" runat="server" OnClick="btnSalvaChecklist_Click" Text="Salva checklist" Modifica="true" Style="width: 160px; margin-left: 20px" />
                    </div>
                    <br />
                </div>
                <br />
                <br />

                <div class="paragrafo">
                    Dati validazione:
                </div>
                <br />

                <div class="first_elem_block">
                    <div class="label">Data validazione:</div>
                    <div class="value">
                        <Siar:DateTextBox ID="txtDataValidazione" runat="server" Width="100px" Modifica="True" />
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <div class="label">Esito validazione:</div>
                    <div class="value">
                        <Siar:ComboYesNo ID="lstEsitoValidazione" runat="server" Width="105px" NoBlankItem="true">
                        </Siar:ComboYesNo>
                    </div>
                </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <Siar:Button ID="btnSave" runat="server" Modifica="True" OnClick="btnSave_Click" Text="Salva" Style="width: 160px; margin-left: 20px" />
                </div>

                <div class="elem_block">
                    <Siar:Button ID="btnFirmaRevisione" runat="server" CausesValidation="false" Enabled="false" Text="Rendi definitiva" Style="width: 160px;" OnClick="btnFirmaRevisione_Click" />
                </div>

                <div class="elem_block">
                    <input id="btnVisualizzaAutovalutazione" runat="server" type="button" class="Button" style="width: 160px" value="Visualizza autovalutazione" />
                </div>

                <div class="elem_block">
                    <input type="button" class="Button" value="Indietro" style="width: 160px;" onclick="history.back();" />
                </div>
                <br />
            </div>

        </div>

    </div>

    <uc3:FirmaDocumento ID="ucFirmaRevisione" runat="server" Titolo="PAGINA DI FIRMA DELLA CHECKLIST DI REVISIONE DOMANDA DI PAGAMENTO" TipoDocumento="CKL_REVISIONE_PAGAMENTO" />
    <uc6:ucSceltaChecklist ID="modaleSceltaChecklist" runat="server" />
</asp:Content>
