<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
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

    <table class="tableNoTab" width="1050">
        <tr>
            <td class="separatore_big">PAGINA DI SELEZIONE DEL BANDO:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            <table style="width: 100%;">
                                <tr>
                                    <td>ID bando<br />
                                        <Siar:TextBox ID="txtIdBando" runat="server" Width="104px" onkeypress="return isNumberKey(event)" />
                                    </td>
                                    <td>
                                        <b>Selezionare il programma:</b><br />
                                        <Siar:ComboZPsr ID="lstPsr" runat="server"></Siar:ComboZPsr>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 210px">
                                        <b>Ente emettitore del bando:<br />
                                            <Siar:ComboEntiBando ID="lstEntiBando" runat="server" Width="190px">
                                            </Siar:ComboEntiBando>
                                        </b>
                                    </td>
                                    <td>
                                        <b>Azione:</b>
                                        <br />
                                        <Siar:ComboGroupZProgrammazione ID="lstProgrammazione" runat="server" Width="700px">
                                        </Siar:ComboGroupZProgrammazione>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 210px">&nbsp;Data di scadenza(&lt;=):<br />
                                        <Siar:DateTextBox ID="txtScadenza" runat="server" Width="104px" />
                                    </td>
                                    <td>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 299px">Ricerca per parole chiave:
                                                    <br />
                                                    <Siar:TextBox ID="txtParoleChiave" runat="server" Width="246px" />
                                                </td>
                                                <td>Stato procedurale:<br />
                                                    <Siar:ComboSql ID="lstStatoBando" runat="server" CommandText="SELECT CODICE,DESCRIZIONE FROM BANDO_TIPO_STATO ORDER BY ORDINE"
                                                        DataTextField="DESCRIZIONE" DataValueField="CODICE" Width="200px">
                                                    </Siar:ComboSql>
                                                </td>
                                                <td style="width: 210px">&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 210px">
                                        <asp:CheckBox ID="chkDisposizioni" runat="server" Text="Cerca disposizioni attuative" />
                                    </td>
                                    <td>
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 230px">
                                                    <asp:CheckBox ID="chkMultimisura" runat="server" Text="Cerca bandi multiprogrammazione" />
                                                </td>
                                                <td style="width: 350px">
                                                    <asp:CheckBox ID="chkMultiprogetto" runat="server" Text="Cerca bandi multiprogetto" />
                                                </td>
                                                <td>
                                                    <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" Width="150px" />
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
        <tr>
            <td style="padding-top: 10px; padding-bottom: 10px;">
                <Siar:DataGrid ID="dgBandi" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    ageSize="15" Width="100%">
                    <ItemStyle Height="40px" />
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle Width="25px" HorizontalAlign="Center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="IdBando" HeaderText="ID">
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Ente" HeaderText="Ente emettitore">
                            <ItemStyle Width="120px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DataApertura" HeaderText="Data apertura">
                            <ItemStyle Width="95px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataScadenza" HeaderText="Data scadenza">
                            <ItemStyle Width="95px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Importo" HeaderText="Importo €" DataFormatString="{0:N}">
                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdBando" ButtonImage="config.ico" ButtonType="ImageButton"
                            ButtonText="Sezione dettaglio" HeaderText="Sezione dettaglio" JsFunction="createUrlDettaglio">
                            <ItemStyle Width="70px" HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                        <Siar:JsButtonColumn Arguments="IdBando|InteresseFiliera|CodStato" ButtonImage="lente.ico"
                            ButtonType="ImageButton" ButtonText="Sezione istruttoria" HeaderText="Sezione istruttoria"
                            JsFunction="createUrlIstruttoria">
                            <ItemStyle Width="70px" HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                        <Siar:JsButtonColumn Arguments="IdBando|InteresseFiliera|CodStato" ButtonImage="timbro.gif"
                            ButtonType="ImageButton" ButtonText="Sezione rendicontazione" HeaderText="Sezione rendiconta- zione"
                            JsFunction="createUrlRendicontazione">
                            <ItemStyle Width="70px" HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
