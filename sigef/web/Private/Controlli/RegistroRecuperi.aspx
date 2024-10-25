<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="RegistroRecuperi.aspx.cs" Inherits="web.Private.Controlli.RegistroRecuperi" %>

<%@ Register Src="~/CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/ZoomLoader.ascx" TagName="ZoomLoader" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function caricaRecupero(id) {
            $('[id$=hdnIdRecupero]').val(id);
            $('[id$=btnPost]').click();
        }
        function caricaSanzione(id) {
            $('[id$=hdnIdSanzione]').val(id);
            $('[id$=btnCaricaSanzione]').click();
        }
        function caricaRata(id) {
            $('[id$=hdnIdRata]').val(id);
            $('[id$=btnCaricaRata]').click();
        }
        function caricaAtto(id) {
            $('[id$=hdnIdAtto]').val(id);
            $('[id$=btnCaricaAtto]').click();
        }
        function selezionaIrregolarita(obj, b) {
            if (obj != null && confirm('Associare il registro irregolarità selezionato al recupero?'))
                $('[id$=btnCaricaIrregolarita]').click();
        }
        function escludiIrregolarita(id) {
            $('[id$=hdnIdIrregolarita]').val(id);
            $('[id$=btnEscludiIrregolarita]').click();
        }
        function checkTipoRecupero() {
            if ($('[id$=lstTipoRecupero]').val() == '28001') {
                $('[id$=divRegistrazioneRitiro]').show();
            }
            else {
                $('[id$=divRegistrazioneRitiro]').hide();
            }
        }
        function checkOrigine() {
            if ($('[id$=lstOrigineRecupero]').val() == '27000') {
                $('[id$=divDettaglioIrregolarita]').show();
                $('[id$=trDgIrregolarita]').show();
                $('[id$=trAssociaIrregolarita]').show();
            }
            else {
                $('[id$=divDettaglioIrregolarita]').hide();
                $('[id$=trDgIrregolarita]').hide();
                $('[id$=trAssociaIrregolarita]').hide();
            }
        }
        function checkAbilitaGestioneRate() {
            if ($('[id$=lstAbilitaGestioneRate]').val() == '1') {
                $('[id$=divGestioneRate]').show();
                $('[id$=divElencoRate]').show();
            }
            else {
                $('[id$=divGestioneRate]').hide();
                $('[id$=divElencoRate]').hide();
            }
        }
        function checkRataPagata() {
            if ($('[id$=lstRataPagata]').val() == '1') {
                $('[id$=divDataPagamentoRata]').show();
            }
            else {
                $('[id$=divDataPagamentoRata]').hide();
            }
        }
        function checkCategoriaSanzione() {
            var oldSel = $('[id$=lstTipoSanzione]').get(0);
            while (oldSel.options.length > 0) {
                oldSel.remove(oldSel.options.length - 1);
            }

            var catsan = $('[id$=lstCategoriaSanzione]').val();
            var i = 0;
            for (i = 0; i < jsonTipiSanzioni.length; i++) {
                if (jsonTipiSanzioni[i].IdPadre == Number(catsan)) {
                    var opt = document.createElement('option');
                    opt.text = jsonTipiSanzioni[i].Descrizione;
                    opt.value = jsonTipiSanzioni[i].Id;
                    oldSel.add(opt, null);
                }
            }
        }
        function ctrlCampiRicercaNormeMarche(ev) { if ($('[id$=txtAttoNumero_text]').val() == "" || $('[id$=txtAttoData_text]').val() == "" || $('[id$=lstAttoRegistro]').val() == "") { alert('Per la ricerca degli atti è necessario specificare numero, data e registro.'); return stopEvent(ev); } }
        function ctrlTipoAtto(ev) {
            if ($('[id$=hdnIdAtto]').val() == "") { alert('Per proseguire è necessario specificare un atto.'); return stopEvent(ev); }
            else if ($('[id$=lstAttoTipo]').val() == "") { alert('Per proseguire è necessario specificare la tipologia dell`atto.'); return stopEvent(ev); }
            if (!confirm("Si sta per associare l'atto. Continuare?")) return stopEvent(ev);
        }
        function convertToNumber(value) {
            return Number(value.split('.').join('').replace(",", "."));
        }
        function sumAndConvertForCurrency(value1, value2) {
            return Number(value1 + value2).toLocaleString("it-IT", { minimumFractionDigits: 2 })
        }
        function aggiornaTotali() {
            //Importo da recuperare
            var importoDaRecuperareQuotaUe = convertToNumber($('[id$=txtImportoDaRecuperareQuotaUe]').val());
            var importoDaRecuperareQuotaNazionale = convertToNumber($('[id$=txtImportoDaRecuperareQuotaNazionale]').val());
            $('[id$=txtImportoDaRecuperareContributoPubblico]').val(sumAndConvertForCurrency(importoDaRecuperareQuotaUe, importoDaRecuperareQuotaNazionale));
            var importoDaRecuperarePubblico = convertToNumber($('[id$=txtImportoDaRecuperareContributoPubblico]').val());
            var importoDaRecuperarePrivato = convertToNumber($('[id$=txtImportoDaRecuperareContributoPrivato]').val());
            $('[id$=txtImportoDaRecuperareTotale]').val(sumAndConvertForCurrency(importoDaRecuperarePubblico, importoDaRecuperarePrivato));

            //Importo detratto
            var importoDetrattoQuotaUe = convertToNumber($('[id$=txtImportoDetrattoQuotaUe]').val());
            var importoDetrattoQuotaNazionale = convertToNumber($('[id$=txtImportoDetrattoQuotaNazionale]').val());
            $('[id$=txtImportoDetrattoContributoPubblico]').val(sumAndConvertForCurrency(importoDetrattoQuotaUe, importoDetrattoQuotaNazionale));
            var importoDetrattoPubblico = convertToNumber($('[id$=txtImportoDetrattoContributoPubblico]').val());
            var importoDetrattoPrivato = convertToNumber($('[id$=txtImportoDetrattoContributoPrivato]').val());
            $('[id$=txtImportoDetrattoTotale]').val(sumAndConvertForCurrency(importoDetrattoPubblico, importoDetrattoPrivato));

            //Importo recuperato
            var importoRecuperatoQuotaUe = convertToNumber($('[id$=txtImportoRecuperatoQuotaUe]').val());
            var importoRecuperatoQuotaNazionale = convertToNumber($('[id$=txtImportoRecuperatoQuotaNazionale]').val());
            $('[id$=txtImportoRecuperatoContributoPubblico]').val(sumAndConvertForCurrency(importoRecuperatoQuotaUe, importoRecuperatoQuotaNazionale));
            var importoRecuperatoPubblico = convertToNumber($('[id$=txtImportoRecuperatoContributoPubblico]').val());
            var importoRecuperatoPrivato = convertToNumber($('[id$=txtImportoRecuperatoContributoPrivato]').val());
            $('[id$=txtImportoRecuperatoTotale]').val(sumAndConvertForCurrency(importoRecuperatoPubblico, importoRecuperatoPrivato));

            //Saldo da recuperare
            var saldoDaRecuperareQuotaUe = convertToNumber($('[id$=txtSaldoDaRecuperareQuotaUe]').val());
            var saldoDaRecuperareQuotaNazionale = convertToNumber($('[id$=txtSaldoDaRecuperareQuotaNazionale]').val());
            $('[id$=txtSaldoDaRecuperareContributoPubblico]').val(sumAndConvertForCurrency(saldoDaRecuperareQuotaUe, saldoDaRecuperareQuotaNazionale));
            var saldoDaRecuperarePubblico = convertToNumber($('[id$=txtSaldoDaRecuperareContributoPubblico]').val());
            var saldoDaRecuperarePrivato = convertToNumber($('[id$=txtSaldoDaRecuperareContributoPrivato]').val());
            $('[id$=txtSaldoDaRecuperareTotale]').val(sumAndConvertForCurrency(saldoDaRecuperarePubblico, saldoDaRecuperarePrivato));
        }
    </script>

    <style type="text/css">
        .mrw-table { display: table; table-layout: fixed; width: 100%; padding: 10px; border-style: solid;}
        .mrw-tr { display: table-row; width: 100%; }
        .mrw-header {}
        .mrw-tr > div { display: table-cell; vertical-align: middle; padding: 10px 2px; white-space: nowrap; overflow: hidden; }
        .mrw-th, .mrw-tf { font-weight: bold; }
        .mrw-td { border-bottom-width: 1px; border-bottom-style: solid; }
        .mrw-grid .mrw-td { border-left-width: 1px; border-left-style: solid; }
        .mrw-grid .mrw-td:last-child { border-right-width: 1px; border-right-style: solid; }
        .mrw-width-5 { width: 5%; }
        .mrw-width-10 { width: 10%; }
        .mrw-width-15 { width: 15%; }
        .mrw-width-16 { width: 16%; }
        .mrw-width-20 { width: 20%; }
        .mrw-width-25 { width: 25%; }
        .mrw-width-30 { width: 30%; }
        .mrw-width-33 { width: 33%; }
        .mrw-width-34 { width: 34%; }
        .mrw-width-35 { width: 35%; }
        .mrw-width-40 { width: 40%; }
        .mrw-width-45 { width: 45%; }
        .mrw-width-50 { width: 50%; }
        .mrw-width-55 { width: 55%; }
        .mrw-width-60 { width: 60%; }
        .mrw-width-65 { width: 65%; }
        .mrw-width-70 { width: 70%; }
        .mrw-width-75 { width: 75%; }
        .mrw-width-80 { width: 80%; }
        .mrw-width-85 { width: 85%; }
        .mrw-width-90 { width: 90%; }
        .mrw-width-95 { width: 95%; }
        .mrw-width-100 { width: 100%; }
        .mrw-center { vertical-align: top; margin: auto !important; text-align: center; }
        .mrw-right { text-align: right; }
        .dBox-overflow 
        {
	        box-shadow: 2px 3px 10px;
	        border-radius: 5px;
	        background-color:#E6E6EE;        	
	        margin:0px 10px 20px 10px;
	        overflow:hidden;
        }
    </style>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdIrregolarita" runat="server" />
        <asp:HiddenField ID="hdnIdRecupero" runat="server" />
        <asp:HiddenField ID="hdnIdSanzione" runat="server" />
        <asp:HiddenField ID="hdnIdOrigine" runat="server" />
        <asp:HiddenField ID="hdnIdRata" runat="server" />
        <asp:HiddenField ID="hdnIdAtto" runat="server" />
        <asp:Button ID="btnPost" runat="server" CausesValidation="False" OnClick="btnPost_Click" />
        <asp:Button ID="btnCaricaIrregolarita" runat="server" CausesValidation="False" OnClick="btnCaricaIrregolarita_Click" />
        <asp:Button ID="btnEscludiIrregolarita" runat="server" OnClick="btnEscludiIrregolarita_Click" />
        <asp:Button ID="btnCaricaSanzione" runat="server" OnClick="btnCaricaSanzione_Click" />
        <asp:Button ID="btnCaricaRata" runat="server" OnClick="btnCaricaRata_Click" />
        <asp:Button ID="btnCaricaAtto" runat="server" OnClick="btnCaricaAtto_Click" />
    </div>

    <div class="dBox-overflow">
        <div class="separatore_big">Ritiri e recuperi</div>
        <div style="padding: 10px">
            <table width="100%">
                <tr>
                    <td id="tdDomanda" runat="server" style="padding-bottom: 15px"></td>
                    <td align="right" style="width: 48px;" class="selectable" onclick="location='#lnkFondoPagina'">
                        <a id="lnkInizioPagina"></a>
                        <img src="../../images/arrow_down_big.png" alt="Fondo pagina" />
                    </td>
                </tr>
                <tr>
                    <td class="paragrafo" colspan="2">Ritiri e recuperi
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <Siar:DataGrid ID="dgRegistroRecuperi" runat="server" AutoGenerateColumns="false"
                            Width="100%">
                            <ItemStyle Height="24px" />
                            <Columns>
                                <asp:BoundColumn DataField="IdRegistroRecupero" HeaderText="Id"></asp:BoundColumn>
                                <asp:BoundColumn DataField="IdTipoRecupero" HeaderText="Tipologia"></asp:BoundColumn>
                                <asp:BoundColumn DataField="DataAvvio" HeaderText="Data avvio"></asp:BoundColumn>
                                <asp:BoundColumn DataField="DataConclusione" HeaderText="Data conclusione"></asp:BoundColumn>
                                <asp:BoundColumn DataField="IdProcedureAvviate" HeaderText="Procedure avviate"></asp:BoundColumn>
                                <asp:BoundColumn DataField="IdTipoProcedureAvviate" HeaderText="Tipo procedure"></asp:BoundColumn>
                                <Siar:CheckColumn DataField="Recuperabile" HeaderText="Recuperabile" ReadOnly="true"></Siar:CheckColumn>
                                <Siar:JsButtonColumn Arguments="IdRegistroRecupero" ButtonType="TextButton" ButtonText="Dettaglio"
                                    JsFunction="caricaRecupero">
                                    <ItemStyle Width="90px" HorizontalAlign="Center" />
                                </Siar:JsButtonColumn>
                            </Columns>
                        </Siar:DataGrid>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <div id="divTab" class="dBox-overflow" runat="server">
        <uc1:SiarNewTab ID="tabRitiriRecuperi" runat="server" Titolo="DETTAGLIO DEL RITIRO/RECUPERO"
            TabNames="Informazioni generali|Impatto finanziario|Atti associati|Sanzioni|Storico" />
        <div style="padding: 10px">
            <div id="divInformazioniGenerali" runat="server" visible="false">
                <div class="mrw-table">
                    <div class="mrw-tr">
                        <div class="mrw-width-50">
                            <Siar:Button ID="btnInserisciSegnatura" runat="server" Text="Inserisci segnatura recupero/ritiro" OnClick="btnInserisciSegnatura_Click" />
                        </div>
                        <div class="mrw-width-50">
                            <Siar:TextBox ID="txtSegnaturaVerbale" runat="server" Width="400px" ReadOnly="True" />
                            <img id="imgSegnaturaVerbale" runat="server" height="20" src="../../images/lente.png" width="20" title="Visualizza documento" style="margin-left: 10px" />
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-50">
                            Data di avvio recupero:<br />
                            <Siar:DateTextBox ID="txtDataAvvio" runat="server" Width="120px" />
                        </div>
                        <div class="mrw-width-50">
                            Probabile data di conclusione:<br />
                            <Siar:DateTextBox ID="txtDataProbabileConclusione" runat="server" Width="120px" />
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-50">
                            Soggetto che ha revocato il finanziamento:<br />
                            <Siar:TextBox ID="txtSoggettoRevocaFinanziamento" runat="server" />
                        </div>
                        <div class="mrw-width-50">
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-50">
                            Tipo:<br />
                            <Siar:ComboBase ID="lstTipoRecupero" runat="server" NomeCampo="TipoRecupero">
                            </Siar:ComboBase>
                            <script type="text/javascript">
                                $(function() {
                                    $('[id$=lstTipoRecupero]').change(checkTipoRecupero);
                                    $('[id$=lstTipoRecupero]').change();
                                });
                            </script>
                        </div>
                        <div class="mrw-width-50">
                            Data certificazione recupero:<br />
                            <Siar:DateTextBox ID="txtDataCertificazioneRecupero" runat="server" Width="120px" Enabled="false" />
                        </div>
                    </div>
                    <div class="mrw-tr" id="divRegistrazioneRitiro" runat="server">
                        <div class="mrw-width-50">
                            Data registrazione ritiro:<br />
                            <Siar:DateTextBox ID="txtDataRegistrazioneRitiro" runat="server" Width="120px" />
                        </div>
                        <div class="mrw-width-50">
                            Data certificazione ritiro:<br />
                            <Siar:DateTextBox ID="txtDataCertificazioneRitiro" runat="server" Width="120px" Enabled="false" />
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-50">
                            Recuperabile:<br />
                            <asp:CheckBox ID="chkRecuperabile" runat="server" Checked="true" />
                        </div>
                        <div class="mrw-width-50">
                            Data certificazione non recuperabilità:<br />
                            <Siar:DateTextBox ID="txtDataCertificazioneNonRecuperabilita" runat="server" Width="120px" Enabled="false" />
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-50">
                            Data conclusione:<br />
                            <Siar:DateTextBox ID="txtDataConclusione" runat="server" Width="120px" />
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-50">
                            Origine:<br />
                            <Siar:ComboBase ID="lstOrigineRecupero" runat="server" NomeCampo="OrigineRecupero">
                            </Siar:ComboBase>

                            <script type="text/javascript">
                                $(function() {
                                    $('[id$=lstOrigineRecupero]').change(checkOrigine);
                                    $('[id$=lstOrigineRecupero]').change();
                                });
                            </script>

                        </div>
                    </div>
                </div>
                <div id="divDettaglioIrregolarita">
                    <div class="paragrafo">Dettaglio registro irregolarità:</div>
                    <div class="mrw-table" style="padding-right: 10px">
                        <div class="mrw-tr" id="trDgIrregolarita">
                            <div class="mrw-width-100">
                                <div id="divDgIrregolarita" class="dContenuto" runat="server">
                                    <Siar:DataGrid ID="dgIrregolarita" runat="server" AutoGenerateColumns="false" Width="80%">
                                        <ItemStyle Height="24px" />
                                        <Columns>
                                            <asp:BoundColumn DataField="IdIrregolarita" HeaderText="Id"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="DataIrregolarita" HeaderText="Data Irregolarita"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="IdImpresaCommessaDa" HeaderText="Commessa Da"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="CommessaA" HeaderText="Commessa A"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="IdCategoriaIrregolarita" HeaderText="Categoria Irregolarita"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="IdTipoIrregolarita" HeaderText="Tipo Irregolarita"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="IdClassificazioneIrregolarita" HeaderText="Classificazione Irregolarita"></asp:BoundColumn>
                                            <Siar:CheckColumn DataField="SegnalazioneOlaf" HeaderText="Segnalazione Olaf" ReadOnly="true">
                                            </Siar:CheckColumn>
                                            <Siar:JsButtonColumn Arguments="IdIrregolarita" ButtonType="TextButton" ButtonText="Escludi"
                                                JsFunction="escludiIrregolarita">
                                                <ItemStyle Width="90px" HorizontalAlign="Center" />
                                            </Siar:JsButtonColumn>
                                        </Columns>
                                    </Siar:DataGrid>
                                </div>
                            </div>
                        </div>
                        <div class="mrw-tr" id="trAssociaIrregolarita">
                            <div class="mrw-width-100">
                                <a id="lnkAssociaIrregolarita" runat="server" href="">[ASSOCIA REGISTRO IRREGOLARITA]</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="mrw-table">
                    <div class="mrw-tr">
                        <div class="mrw-width-100">
                            <Siar:Button ID="btnSalvaInformazioniGenerali" runat="server" OnClick="btnSalvaInformazioniGenerali_Click"
                                Text="Salva informazioni generali" />
                        </div>
                    </div>
                </div>
            </div>
            <div id="divImpattoFinanziario" runat="server" visible="false">
                <div class="mrw-table">
                    <div class="mrw-tr">
                        <div class="mrw-width-20">
                        </div>
                        <div class="mrw-width-16">
                            <b>Quota UE</b>
                        </div>
                        <div class="mrw-width-16">
                            <b>Quota nazionale</b>
                        </div>
                        <div class="mrw-width-16">
                            <b>Contributo pubblico</b>
                        </div>
                        <div class="mrw-width-16">
                            <b>Contributo privato</b>
                        </div>
                        <div class="mrw-width-16">
                            <b>Totale</b>
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-20">
                            Importo da recuperare
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoDaRecuperareQuotaUe" runat="server" Width="120px" />
                            <script type="text/javascript">
                                $(function() {
                                    $('[id$=txtImportoDaRecuperareQuotaUe]').change(aggiornaTotali);
                                    $('[id$=txtImportoDaRecuperareQuotaUe]').change();
                                });
                            </script>
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoDaRecuperareQuotaNazionale" runat="server" Width="120px" />
                            <script type="text/javascript">
                                $(function() {
                                    $('[id$=txtImportoDaRecuperareQuotaNazionale]').change(aggiornaTotali);
                                    $('[id$=txtImportoDaRecuperareQuotaNazionale]').change();
                                });
                            </script>
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoDaRecuperareContributoPubblico" runat="server" ReadOnly="true" Width="120px" />
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoDaRecuperareContributoPrivato" runat="server" Width="120px" />
                            <script type="text/javascript">
                                $(function() {
                                    $('[id$=txtImportoDaRecuperareContributoPrivato]').change(aggiornaTotali);
                                    $('[id$=txtImportoDaRecuperareContributoPrivato]').change();
                                });
                            </script>
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoDaRecuperareTotale" runat="server" ReadOnly="true" Width="120px" />
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-20">
                            Importo detratto in occasione di
                            <br />
                            pagamenti intermedi o finali
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoDetrattoQuotaUe" runat="server" Width="120px" />
                            <script type="text/javascript">
                                $(function() {
                                    $('[id$=txtImportoDetrattoQuotaUe]').change(aggiornaTotali);
                                    $('[id$=txtImportoDetrattoQuotaUe]').change();
                                });
                            </script>
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoDetrattoQuotaNazionale" runat="server" Width="120px" />
                            <script type="text/javascript">
                                $(function() {
                                    $('[id$=txtImportoDetrattoQuotaNazionale]').change(aggiornaTotali);
                                    $('[id$=txtImportoDetrattoQuotaNazionale]').change();
                                });
                            </script>
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoDetrattoContributoPubblico" runat="server" ReadOnly="true" Width="120px" />
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoDetrattoContributoPrivato" runat="server" Width="120px" />
                            <script type="text/javascript">
                                $(function() {
                                    $('[id$=txtImportoDetrattoContributoPrivato]').change(aggiornaTotali);
                                    $('[id$=txtImportoDetrattoContributoPrivato]').change();
                                });
                            </script>
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoDetrattoTotale" runat="server" ReadOnly="true" Width="120px" />
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-20">
                            Importo recuperato
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoRecuperatoQuotaUe" runat="server" Width="120px" />
                            <script type="text/javascript">
                                $(function() {
                                    $('[id$=txtImportoRecuperatoQuotaUe]').change(aggiornaTotali);
                                    $('[id$=txtImportoRecuperatoQuotaUe]').change();
                                });
                            </script>
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoRecuperatoQuotaNazionale" runat="server" Width="120px" />
                            <script type="text/javascript">
                                $(function() {
                                    $('[id$=txtImportoRecuperatoQuotaNazionale]').change(aggiornaTotali);
                                    $('[id$=txtImportoRecuperatoQuotaNazionale]').change();
                                });
                            </script>
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoRecuperatoContributoPubblico" runat="server" ReadOnly="true" Width="120px" />
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoRecuperatoContributoPrivato" runat="server" Width="120px" />
                            <script type="text/javascript">
                                $(function() {
                                    $('[id$=txtImportoRecuperatoContributoPrivato]').change(aggiornaTotali);
                                    $('[id$=txtImportoRecuperatoContributoPrivato]').change();
                                });
                            </script>
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoRecuperatoTotale" runat="server" ReadOnly="true" Width="120px" />
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-20">
                            Saldo ancora da recuperare
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtSaldoDaRecuperareQuotaUe" runat="server" Width="120px" />
                            <script type="text/javascript">
                                $(function() {
                                    $('[id$=txtSaldoDaRecuperareQuotaUe]').change(aggiornaTotali);
                                    $('[id$=txtSaldoDaRecuperareQuotaUe]').change();
                                });
                            </script>
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtSaldoDaRecuperareQuotaNazionale" runat="server" Width="120px" />
                            <script type="text/javascript">
                                $(function() {
                                    $('[id$=txtSaldoDaRecuperareQuotaNazionale]').change(aggiornaTotali);
                                    $('[id$=txtSaldoDaRecuperareQuotaNazionale]').change();
                                });
                            </script>
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtSaldoDaRecuperareContributoPubblico" runat="server" ReadOnly="true" Width="120px" />
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtSaldoDaRecuperareContributoPrivato" runat="server" Width="120px" />
                            <script type="text/javascript">
                                $(function() {
                                    $('[id$=txtSaldoDaRecuperareContributoPrivato]').change(aggiornaTotali);
                                    $('[id$=txtSaldoDaRecuperareContributoPrivato]').change();
                                });
                            </script>
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtSaldoDaRecuperareTotale" runat="server" ReadOnly="true" Width="120px" />
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-20">
                            Importo versato al bilancio UE
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoVersatoQuotaUe" runat="server" Width="120px" />
                        </div>
                        <div class="mrw-width-16"></div>
                        <div class="mrw-width-16"></div>
                        <div class="mrw-width-16"></div>
                        <div class="mrw-width-16"></div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-25">
                            Importo ritenuto dallo Stato membro
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoRitenutoStato" runat="server" Width="120px" />
                        </div>
                        <div class="mrw-width-16"></div>
                        <div class="mrw-width-16"></div>
                        <div class="mrw-width-16"></div>
                        <div class="mrw-width-16"></div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-20">
                            Importo degli interessi legali
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoInteressiLegali" runat="server" Width="120px" />
                        </div>
                        <div class="mrw-width-16"></div>
                        <div class="mrw-width-16"></div>
                        <div class="mrw-width-16"></div>
                        <div class="mrw-width-16"></div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-20">
                            Importo degli interessi di mora
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoInteressiMora" runat="server" Width="120px" />
                        </div>
                        <div class="mrw-width-16"></div>
                        <div class="mrw-width-16"></div>
                        <div class="mrw-width-16"></div>
                        <div class="mrw-width-16"></div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-20">
                            Importo di gestione pratica
                        </div>
                        <div class="mrw-width-16">
                            <Siar:CurrencyBox ID="txtImportoGestionePratica" runat="server" Width="120px" />
                        </div>
                        <div class="mrw-width-16"></div>
                        <div class="mrw-width-16"></div>
                        <div class="mrw-width-16"></div>
                        <div class="mrw-width-16"></div>
                    </div>
                </div>
                <div class="mrw-table">
                    <div class="mrw-tr">
                        <div class="mrw-width-100">
                            Abilita gestione rate recupero:<br />
                            <Siar:ComboBase ID="lstAbilitaGestioneRate" runat="server" NomeCampo="AbilitaGestioneRate">
                            </Siar:ComboBase>
                            <script type="text/javascript">
                                $(function() {
                                    $('[id$=lstAbilitaGestioneRate]').change(checkAbilitaGestioneRate);
                                    $('[id$=lstAbilitaGestioneRate]').change();
                                });
                            </script>
                        </div>
                    </div>
                </div>
                <div id="divGestioneRate" runat="server">
                    <div class="mrw-table">
                        <div class="paragrafo">
                            Gestione rate recupero
                        </div>
                        <div class="mrw-tr">
                            <div class="mrw-width-50">
                                Intervallo rate (in mesi):<br />
                                <Siar:IntegerTextBox ID="txtIntervalloRate" runat="server" />
                            </div>
                            <div class="mrw-width-50">
                                Data inizio rate:<br />
                                <Siar:DateTextBox ID="txtDataInizioRate" runat="server" />
                            </div>
                        </div>
                        <div class="mrw-tr">
                            <div class="mrw-width-50">
                                Importo rata:<br />
                                <Siar:CurrencyBox ID="txtImportoRataRichiesta" runat="server" />
                            </div>
                            <div class="mrw-width-50">
                                Numero rate:<br />
                                <Siar:IntegerTextBox ID="txtNumeroRate" runat="server" />
                            </div>
                        </div>
                        <div class="mrw-tr">
                            <div class="mrw-width-50">
                                <br />
                                <Siar:Button ID="btnGeneraGestioneRate" runat="server" OnClick="btnGeneraGestioneRate_Click"
                                    OnClientClick="return confirm('Sei sicuro di continuare? \r\nSe fossero già presenti delle rate verranno cancellate.');"
                                    Text="Genera piano rate" />
                            </div>
                            <div class="mrw-width-50">
                            </div>
                        </div>
                    </div>
                    <div id="divElencoRate" runat="server">
                        <div class="paragrafo">Elenco rate:</div>
                        <div class="mrw-table">
                            <div class="mrw-tr">
                                <div class="mrw-width-100">
                                    <Siar:DataGrid ID="dgRateRecupero" runat="server" AutoGenerateColumns="false"
                                        Width="100%" ShowFooter="true" PageSize="15">
                                        <ItemStyle Height="24px" />
                                        <FooterStyle CssClass="coda" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:BoundColumn DataField="DataRata" HeaderText="Data rata">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="ImportoRata" HeaderText="Importo">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="DataScadenza" HeaderText="Data scadenza">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <Siar:CheckColumn DataField="Pagata" Name="chkRataPagata" HeaderText="Pagata" ReadOnly="true">
                                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                            </Siar:CheckColumn>
                                            <asp:BoundColumn DataField="DataPagamento" HeaderText="Data pagamento">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <Siar:JsButtonColumn Arguments="IdRata" ButtonType="TextButton" ButtonText="Dettaglio"
                                                JsFunction="caricaRata">
                                                <ItemStyle Width="90px" HorizontalAlign="Center" />
                                            </Siar:JsButtonColumn>
                                        </Columns>
                                    </Siar:DataGrid>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="divDettaglioRata" runat="server" visible="false">
                        <div class="mrw-table">
                            <div class="mrw-tr">
                                <div class="mrw-width-50">
                                    Data rata:<br />
                                    <Siar:DateTextBox ID="txtDataRata" runat="server" />
                                </div>
                                <div class="mrw-width-50">
                                    Data scadenza:<br />
                                    <Siar:DateTextBox ID="txtDataScadenzaRata" runat="server" />
                                </div>
                            </div>
                            <div class="mrw-tr">
                                <div class="mrw-width-50">
                                    Importo rata:<br />
                                    <Siar:CurrencyBox ID="txtImportoRata" runat="server" />
                                </div>
                                <div class="mrw-width-50">
                                </div>
                            </div>
                            <div class="mrw-tr">
                                <div class="mrw-width-50">
                                    Rata pagata:<br />
                                    <Siar:ComboBase ID="lstRataPagata" runat="server" />
                                    <script type="text/javascript">
                                        $(function() {
                                            $('[id$=lstRataPagata]').change(checkRataPagata);
                                            $('[id$=lstRataPagata]').change();
                                        });
                                    </script>
                                </div>
                                <div class="mrw-width-50" id="divDataPagamentoRata" runat="server">
                                    Data pagamento:<br />
                                    <Siar:DateTextBox ID="txtDataPagamentoRata" runat="server" />
                                </div>
                            </div>
                            <div class="mrw-tr">
                                <div class="mrw-width-50">
                                    <Siar:Button ID="btnSalvaRata" runat="server" OnClick="btnSalvaRata_Click" Text="Salva rata" />
                                </div>
                                <div class="mrw-width-50">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="mrw-table">
                    <div class="mrw-tr">
                        <div class="mrw-width-100">
                            <Siar:Button ID="btnSalvaImpattoFinanziario" runat="server" OnClick="btnSalvaImpattoFinanziario_Click"
                                Text="Salva impatto finanziario" />
                        </div>
                    </div>
                </div>
            </div>
            <div id="divAttiAssociati" runat="server" visible="false">
                <div class="paragrafo">Elenco atti associati:</div>
                <div id="divAttoRecupero" runat="server">
                    <div class="mrw-table">
                        <div class="mrw-tr">
                            <div class="mrw-width-100">
                                <Siar:DataGrid ID="dgAtti" runat="server" AutoGenerateColumns="false"
                                    Width="100%" ShowFooter="true" PageSize="15">
                                    <ItemStyle Height="24px" />
                                    <FooterStyle CssClass="coda" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundColumn DataField="IdAtto" HeaderText="Motivo associazione">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Numero" HeaderText="Numero">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Data" HeaderText="Data">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="TipoAtto" HeaderText="Tipo">
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="DefinizioneAtto" HeaderText="Definizione">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Registro" HeaderText="Registro">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <Siar:JsButtonColumn Arguments="IdAtto" ButtonType="TextButton" ButtonText="Dettaglio"
                                            JsFunction="caricaAtto">
                                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                                        </Siar:JsButtonColumn>
                                    </Columns>
                                </Siar:DataGrid>
                            </div>
                        </div>
                    </div>
                    <div class="mrw-table">
                        <div class="mrw-tr">
                            <div class="mrw-width-20">
                                Definizione:<br />
                                <Siar:ComboDefinizioneAtto ID="lstAttoDefinizione" runat="server" NoBlankItem="True" Width="80px"></Siar:ComboDefinizioneAtto>
                            </div>
                            <div class="mrw-width-20">
                                Numero:<br />
                                <Siar:IntegerTextBox ID="txtAttoNumero" NoCurrency="True" runat="server" Width="80px" NomeCampo="Numero decreto" />
                            </div>
                            <div class="mrw-width-20">
                                Data:<br />
                                <Siar:DateTextBox ID="txtAttoData" runat="server" Width="100px" NomeCampo="Data decreto" />
                            </div>
                            <div class="mrw-width-20">
                                Registro:<br />
                                <Siar:ComboRegistriAtto ID="lstAttoRegistro" runat="server" Width="100px"></Siar:ComboRegistriAtto>
                            </div>
                            <div class="mrw-width-20">
                                <br />
                                <Siar:Button ID="btnCercaDecreto" runat="server" OnClick="btnCercaDecreto_Click"
                                    Text="Ricerca" Width="109px" OnClientClick="return ctrlCampiRicercaNormeMarche(event);" />
                            </div>
                        </div>
                    </div>
                    <div class="mrw-table">
                        <div class="mrw-tr">
                            <div class="mrw-width-75">
                                Descrizione:<br />
                                <Siar:TextArea ID="txtAttoDescrizione" runat="server" Width="600px" ReadOnly="True"
                                    Rows="4" ExpandableRows="5"></Siar:TextArea>
                            </div>
                            <div class="mrw-width-25">
                                <br />
                                <input id="btnVidualizzaDecreto" runat="server" class="Button" style="width: 130px; margin-left: 30px; margin-right: 20px"
                                    type="button" disabled="disabled" value="Visualizza atto" />
                            </div>
                        </div>
                    </div>
                    <div class="mrw-table">
                        <div class="mrw-tr">
                            <div class="mrw-width-34" align="right">
                                <Siar:Button ID="btnAssociaDecretoRecupero" runat="server" OnClick="btnAssociaDecretoRecupero_Click"
                                    Text="Associa decreto recupero" OnClientClick="return ctrlTipoAtto(event);" Enabled="false" />
                            </div>
                            <div class="mrw-width-33" align="center">
                                <Siar:Button ID="btnAssociaDecretoRitiro" runat="server" OnClick="btnAssociaDecretoRitiro_Click"
                                    Text="Associa decreto ritiro" OnClientClick="return ctrlTipoAtto(event);" Enabled="false" />
                            </div>
                            <div class="mrw-width-33" align="left">
                                <Siar:Button ID="btnAssociaDecretoNonRecuperabilita" runat="server" OnClick="btnAssociaDecretoNonRecuperabilita_Click"
                                    Text="Associa decreto non recuperabilità" OnClientClick="return ctrlTipoAtto(event);" Enabled="false" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="divSanzioni" runat="server" visible="false">
                <div class="mrw-table">
                    <div class="mrw-tr">
                        <div class="mrw-width-100">
                            Procedure avviate per imporre sanzioni:<br />
                            <Siar:ComboBase ID="lstProcedureAvviate" runat="server" NomeCampo="ProcedureAvviate">
                            </Siar:ComboBase>
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-100">
                            Tipo di procedure:<br />
                            <Siar:ComboBase ID="lstTipoProcedureAvviate" runat="server" NomeCampo="TipoProcedureAvviate">
                            </Siar:ComboBase>
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-100">
                            <Siar:Button ID="btnSalvaProcedureSanzioni" runat="server" OnClick="btnSalvaProcedureSanzioni_Click"
                                Text="Salva informazioni procedure delle sanzioni" />
                        </div>
                    </div>
                </div>
                <div class="paragrafo">Elenco sanzioni:</div>
                <div class="mrw-table">
                    <div class="mrw-tr">
                        <div class="mrw-width-100" style="padding-right: 10px">
                            <Siar:DataGrid ID="dgSanzioniRecuperi" runat="server" AutoGenerateColumns="false" Width="100%" ShowFooter="true">
                                <ItemStyle Height="24px" />
                                <FooterStyle CssClass="coda" HorizontalAlign="Center" />
                                <Columns>
                                    <asp:BoundColumn DataField="IdSanzioneRecupero" HeaderText="Id"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="IdCategoriaSanzione" HeaderText="Categoria"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="IdTipoSanzione" HeaderText="Tipo"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="ImportoSanzione" HeaderText="Importo"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="IdStatoSanzione" HeaderText="Stato"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataConclusione" HeaderText="Data conclusione"></asp:BoundColumn>
                                    <Siar:JsButtonColumn Arguments="IdSanzioneRecupero" ButtonType="TextButton" ButtonText="Dettaglio"
                                        JsFunction="caricaSanzione">
                                        <ItemStyle Width="90px" HorizontalAlign="Center" />
                                    </Siar:JsButtonColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </div>
                    </div>
                </div>
                <div class="mrw-table">
                    <div class="mrw-tr">
                        <div class="mrw-width-50">
                            Categoria:<br />
                            <Siar:ComboBase ID="lstCategoriaSanzione" runat="server" NomeCampo="CategoriaSanzione">
                            </Siar:ComboBase>
                            <script type="text/javascript">
                                $(function() {
                                    $('[id$=lstCategoriaSanzione]').change(checkCategoriaSanzione);
                                    $('[id$=lstCategoriaSanzione]').change();
                                });
                            </script>
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-50">
                            Tipo:<br />
                            <Siar:ComboBase ID="lstTipoSanzione" runat="server" NomeCampo="TipoSanzione">
                            </Siar:ComboBase>
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-50">
                            Importo sanzione:<br />
                            <Siar:CurrencyBox ID="txtImportoSanzione" runat="server" />
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-50">
                            Stato delle procedure:<br />
                            <Siar:ComboBase ID="lstStatoProcedure" runat="server" NomeCampo="StatoProcedure">
                            </Siar:ComboBase>
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-50">
                            Data conclusione sanzione:<br />
                            <Siar:DateTextBox ID="txtDataConclusioneSanzione" runat="server" Width="120px" />
                        </div>
                        <div class="mrw-width-50">
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div class="mrw-width-50">
                            <Siar:Button ID="btnInserisciSanzione" runat="server" OnClick="btnInserisciSanzione_Click"
                                Text="Inserisci sanzione" />
                            <Siar:Button ID="btnAggiornaSanzione" runat="server" OnClick="btnAggiornaSanzione_Click"
                                Text="Aggiorna sanzione" Visible="false" />
                        </div>
                        <div class="mrw-width-50">
                            <Siar:Button ID="btnEliminaSanzione" runat="server" OnClick="btnEliminaSanzione_Click"
                                Text="Elimina sanzione" />
                        </div>
                    </div>
                </div>
            </div>
            <div id="divStorico" runat="server" visible="false">
                <div class="mrw-table">
                    <div class="mrw-tr">
                        <div class="mrw-width-100">
                            <Siar:DataGrid ID="dgRegistroRecuperiStorico" runat="server" AutoGenerateColumns="false"
                                Width="100%">
                                <ItemStyle Height="24px" />
                                <Columns>
                                    <asp:BoundColumn DataField="IdRegistroRecupero" HeaderText="Id"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="IdTipoRecupero" HeaderText="Tipologia"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataAvvio" HeaderText="Data avvio"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataConclusione" HeaderText="Data conclusione"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="IdProcedureAvviate" HeaderText="Procedure avviate"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="IdTipoProcedureAvviate" HeaderText="Tipo procedure"></asp:BoundColumn>
                                    <Siar:JsButtonColumn Arguments="IdRegistroRecupero" ButtonType="TextButton" ButtonText="Dettaglio"
                                        JsFunction="caricaRecupero">
                                        <ItemStyle Width="90px" HorizontalAlign="Center" />
                                    </Siar:JsButtonColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </div>
                    </div>
                </div>
            </div>
            <div class="paragrafo"></div>
            <div id="divButton" class="mrw-table">
                <div class="mrw-tr">
                    <div class="mrw-width-25" align="right">
                        <Siar:Button ID="btnSalvaRegistroRecuperi" runat="server" OnClick="btnSalvaRegistroRecuperi_Click"
                            Text="Salva recupero/ritiro" Visible="false" />
                    </div>
                    <div class="mrw-width-25" align="center">
                        <Siar:Button ID="btnEliminaRegistroRecuperi" runat="server" OnClick="btnEliminaRegistroRecuperi_Click"
                            OnClientClick="return confirm('Sei sicuro di continuare? \r\nVerranno cancellate anche le rate e le sanzioni relative al recupero/ritiro.');"
                            Text="Elimina recupero/ritiro" />
                    </div>
                    <div class="mrw-width-25" align="left">
                        <Siar:Button ID="btnNuovoRegistroRecuperi" runat="server" OnClick="btnNuovoRegistroRecuperi_Click"
                            Text="Nuovo recupero/ritiro" Visible="false" />
                    </div>
                    <div class="mrw-width-25" align="right">
                        <a id="lnkFondoPagina"></a>
                        <div style="width: 48px; height: 48px" class="selectable" onclick="location='#lnkInizioPagina'">
                            <img src="../../images/arrow_up_big.png" alt="Inizio pagina" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id='divSegnatura' style="width: 725px; position: absolute; display: none;">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">Dati della segnatura del recupero/ritiro:
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
                                <asp:TextBox ID="txtSegnatura" runat="server" Width="400px" />
                                <img id="imgSegnatura" runat="server" height="18" src="../../images/lente.png"
                                    title="Visualizza documento" width="18" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 70px;" colspan="2">
                                <Siar:Button ID="btnSalvaSegnatura" runat="server" OnClick="btnSalvaSegnatura_Click"
                                    Text="Salva" Width="100px" CausesValidation="False" />
                                <input class="Button" onclick="chiudiPopupTemplate();" style="width: 100px; margin-left: 20px; margin-right: 20px"
                                    type="button" value="Chiudi" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>

    <uc2:ZoomLoader ID="ucZoomLoaderIrregolaritaProgetto" runat="server" AutomaticSearch="True"
        NoSearch="True" SearchMethod="GetRegistroIrregolaritaProgetto" KeySearch="" ColumnsToBind="IdIrregolarita|DataIrregolarita:DataIrregolarita|CommessaA:CommessaA"
        KeyValue="IdIrregolarita" KeyText="id|DataIrregolarita|CommessaA"
        JsSelectedItemHandler="selezionaIrregolarita" Width="700px" />
</asp:Content>
