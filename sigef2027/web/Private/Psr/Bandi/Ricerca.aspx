<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="Ricerca.aspx.cs" Inherits="web.Private.Psr.Bandi.Ricerca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function createUrlDettaglio(id) { createBaseUrl('private/psr/bandi/dettaglio.aspx?idb=' + id); }
        function createUrlIstruttoria(id, filiera, cod_stato) {
            if (cod_stato == 'P') alert('Attenzione! Il bando selezionato non è ancora stato pubblicato, impossibile continuare.');
            else if (filiera) createBaseUrl('private/ManifInteresse/istruttoria/Collaboratori.aspx?idb=' + id);
            else createBaseUrl('private/istruttoria/statistiche.aspx?idb=' + id);
        }
        function createUrlRendicontazione(id, filiera, cod_stato) {
            if (cod_stato == 'P') alert('Attenzione! Il bando selezionato non è ancora stato pubblicato, impossibile continuare.');
            else if (cod_stato == 'L') alert('Attenzione! La graduatoria non è ancora stata resa definitiva, impossibile continuare.');
            else if (filiera) alert('Attenzione! La sezione rendicontazione non è abilitata per le Manifestazioni di Interesse di Filiera.');
            else { createBaseUrl('private/IPagamento/SelezioneDomande.aspx?idb=' + id); }
        }
        function createBaseUrl(url) { document.location = getBaseUrl() + url; }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function changeCodPsr() {
            // Ottengo il valore selezionato in maiuscolo perché su lstProgrammazione è maiuscolo
            var selectedPsr = $('[id$=lstPsr]');
            var selectedGroup = selectedPsr[0].selectedOptions[0].text.toUpperCase();

            // deseleziono su lstProgrammazione se non ho ricercato
            if ($('[id$=hdnRicerca]').val() != 'true') {
                $('[id$=lstProgrammazione]').val('');
            } else if ($('[id$=hdnRicerca]').val() == 'true') {
                $('[id$=hdnRicerca]').val('false');
            }

            // se su lstPsr è selezionato qualcosa, altrimenti mostro tutto
            if (selectedGroup != undefined && selectedGroup != "") {

                // Sostituisco solo l'ultimo trattino senza spazi con " - " (spazio trattino spazio) perchè ha un valore diverso su lstPsr
                // esempio
                // su            lstPsr = 'POR FESR 2021 - 2027 2021 - 2027'
                // su lstProgrammazione = 'POR FESR 2021 - 2027 2021-2027'
                selectedGroup = selectedGroup.replace(/-(?!.*-)/, ' - ');

                var optionsProgrammazione = $('[id$=lstProgrammazione]');

                // Nascondo tutte le opzioni in lstProgrammazione
                $('[id$=<%=lstProgrammazione.ClientID%>] optgroup').each(function () {
                    $(this).hide();  // Nascondo tutti gli optgroup inizialmente
                });

                // Mostra solo l'optgroup che corrisponde alla selezione
                $('[id$=<%=lstProgrammazione.ClientID%>] optgroup[label="' + selectedGroup + '"]').show();
            } else {
                // Mostro tutte le opzioni in lstProgrammazione
                $('[id$=<%=lstProgrammazione.ClientID%>] optgroup').each(function () {
                    $(this).show();  // mostro tutti gli optgroup inizialmente
                });
            }
        }

        function readyFn(jQuery) {
            $('[id$=lstPsr]').change(changeCodPsr);
            $('[id$=lstPsr]').change();
        }

        function pageLoad() {
            readyFn();
        }
    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnRicerca" runat="server" />
    </div>

    <div class="row pt-5 mx-2 bd-form">
        <div class="col-sm-12">
            <h3 class="pb-5">Pagina di selezione del bando</h3>
            <div class="row pt-3">
                <div class="form-group col-sm-3">
                    <Siar:TextBox Label="ID bando:" ID="txtIdBando" runat="server" onkeypress="return isNumberKey(event)" />
                </div>
                <div class="form-group col-sm-9">
                    <Siar:ComboZPsr ID="lstPsr" Label="Selezionare il programma" runat="server"></Siar:ComboZPsr>
                </div>
                <div class="form-group col-sm-3">
                    <Siar:ComboEntiBando Label="Ente emettitore del bando:" ID="lstEntiBando" runat="server"></Siar:ComboEntiBando>
                </div>
                <div class="form-group col-sm-9">
                    <Siar:ComboGroupZProgrammazione Label="Azione" ID="lstProgrammazione" runat="server">
                    </Siar:ComboGroupZProgrammazione>
                </div>
                <div class="form-group col-sm-3">
                    <Siar:DateTextBoxAgid Label="Data di scadenza(<=):" ID="txtScadenza" runat="server" />
                </div>
                <div class="form-group col-sm-3">
                    <Siar:TextBox Label="Ricerca per parole chiave:" ID="txtParoleChiave" runat="server" />
                </div>
                <div class="form-group col-sm-3">
                    <Siar:ComboSql Label="Stato procedurale:" ID="lstStatoBando" runat="server" CommandText="SELECT CODICE,DESCRIZIONE FROM BANDO_TIPO_STATO ORDER BY ORDINE"
                        DataTextField="DESCRIZIONE" DataValueField="CODICE">
                    </Siar:ComboSql>
                </div>
                <div class="form-group col-sm-3">
                </div>
                <div class="form-check col-sm-3">
                    <asp:CheckBox ID="chkMultimisura" runat="server" Text="Cerca bandi multiprogrammazione" />
                </div>
                <div class="form-check col-sm-3">
                    <asp:CheckBox ID="chkMultiprogetto" runat="server" Text="Cerca bandi multiprogetto" />
                </div>
                <div class="form-check col-sm-3">
                    <asp:CheckBox ID="chkDisposizioni" runat="server" Text="Cerca disposizioni attuative" />
                </div>
                <div class="col-sm-3">
                    <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" />
                </div>
            </div>
        </div>
        <div class="col-sm-12 pt-5">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgBandi" runat="server" AllowPaging="True" AutoGenerateColumns="False" ageSize="15">
                <Columns>
                    <Siar:NumberColumn>
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="IdBando" HeaderText="ID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Ente" HeaderText="Ente emettitore">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DataApertura" HeaderText="Data apertura">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataScadenza" HeaderText="Data scadenza">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Importo" HeaderText="Importo €" DataFormatString="{0:N}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumnAgid Arguments="IdBando" ButtonImage="it-pencil" ButtonType="ImageButton"
                        ButtonText="Sezione dettaglio" HeaderText="Sezione dettaglio" JsFunction="createUrlDettaglio">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumnAgid>
                    <Siar:JsButtonColumnAgid Arguments="IdBando|InteresseFiliera|CodStato" ButtonImage="it-piattaforme"
                        ButtonType="ImageButton" ButtonText="Sezione istruttoria" HeaderText="Sezione istruttoria"
                        JsFunction="createUrlIstruttoria">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumnAgid>
                    <Siar:JsButtonColumnAgid Arguments="IdBando|InteresseFiliera|CodStato" ButtonImage="it-note"
                        ButtonType="ImageButton" ButtonText="Sezione rendicontazione" HeaderText="Sezione rendicontazione"
                        JsFunction="createUrlRendicontazione">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
</asp:Content>
