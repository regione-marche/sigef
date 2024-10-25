<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IstruttoriaInvestimento" CodeBehind="IstruttoriaInvestimento.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/ucPagamentoInvestimento.ascx" TagName="ucPagamentoInvestimento" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--

    function ctrlAmmessoLavoriInEconomia(ev) { if ($('[id$=txtLECImportoAmmesso_text]').val() == '') { alert('Attenzione! Inserire l`importo ammesso per i lavori in economia.'); return stopEvent(ev); } }
    function chiudiPopup() { $('[id$=hdnIdPagamentoBeneficiario]').val(''); chiudiPopupTemplate(); }
    function selezionaParametro(id_sanzione, cod_tipo_parametro, valore_parametro, descrizione) { $('[id$=hdnValoreParametro' + cod_tipo_parametro + id_sanzione + ']').val(valore_parametro); $('[id$=lblValoreParametro' + cod_tipo_parametro + id_sanzione + ']').text("  " + descrizione); chiudiPopupTemplate(); }
    function sceltaParametroSanzione(id_sanzione, cod_tipo_sanzione, cod_tipo_parametro) {
        mostraPopupTemplate('divSelezioneParametro', 'divBKGMessaggio');
        $('#divValoriParametro').ajaxStart(function () { $(this).html("<img src='../../images/ajaxroller.gif' />"); })
            .ajaxError(function () { $(this).css({ "background-color": "fefeee", "color": "red", "text-align": "center" }).html("ATTENZIONE! SI E' VERIFICATO UN ERRORE NELLA RICHIESTA."); })
            .load("../../CONTROLS/ajaxRequest.aspx", {
                "type": "getSelezioneParametroSanzioniPagamento", "id_sanzione": id_sanzione, "cod_tipo_sanzione": cod_tipo_sanzione,
                "cod_tipo_parametro": cod_tipo_parametro
            }).show();
    }


    function btnCalcolaContributoAmmesso_Click() {
        if ($('[id$=txtIPImportoAmmesso]').val() == '') { alert('Attenzione! Inserire l`importo ammesso.'); }
        else {
            var importo = $('[id$=txtIPImportoAmmesso]').val();
            var i;
            for (i = 0; i < 3; i++) {
                importo = importo.replace(".", "");
            }
            importo = importo.replace(",", ".");
            var contributoperc = $('[id$=txtIPContributoQuota]').val();
            contributoperc = contributoperc.replace(",", ".");
            var contributo = importo * contributoperc / 100;
            contributo = contributo.toFixed(2);
            contributo = contributo.replace(".", ",");

            $('[id$=txtIPContributoAmmesso]').val(contributo);
        }
    }

//--></script>
    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />

    <nav class="breadcrumb-container" aria-label="Percorso di navigazione">
          <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="../IPagamento/IstruttoriaPianoInvestimenti.aspx"><svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use></svg>Istruttoria del piano investimenti</a><span class="separator">/</span></li>            
            <li class="breadcrumb-item active" aria-current="page">Istruttoria dell'investimento</li>
          </ol>
        </nav>
    <div class="row bd-form pt-5 mx-2">
        <div class="col-sm-12 text-end">
            <a href="../IPagamento/IstruttoriaPianoInvestimenti.aspx" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                </svg>
                Torna all'istruttoria del piano investimenti</a>
        </div>
        <h2 class="pb-5">Istruttoria dei pagamenti richiesti per l'investimento</h2>
        <div class="row">
            <div class="row mb-3">
                <div class="col-12 col-sm-12">
                    <!--start card-->
                    <div class="card-wrapper card-space">
                        <div class="card card-bg card-big border-bottom-card">
                            <div class="flag-icon"></div>
                            <div class="etichetta">
                                <svg class="icon">
                                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-settings"></use>
                                  </svg>
                                <span>Investimento attuale</span>
                            </div>
                            <div class="card-body">
                                <h3 class="card-title-custom h5 no_toc">Dettagli investimento:
                                </h3>
                                <div class="row">
                                    <div class="col-sm-3">
                                        <span class="fw-bold">Dettaglio:
                                            <a href="" id="lnkInvestimento"
                                                runat="server">
                                                <svg id='imgDettaglioInvestimento' runat="server" style='cursor: pointer;' class="icon icon-secondary me-1" aria-hidden="true">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-file-pdf-ext"></use>                                           
                                            </svg>
                                            </a>
                                        </span>
                                    </div>
                                    <div class="col-sm-3">
                                        <span class="fw-bold">Ammesso: </span><span runat="server" id="imgAmmesso"></span>
                                    </div>
                                    <div class="col-sm-3">
                                        <span class="fw-bold">Tipologia variazione: </span>
                                        <asp:Label ID="lblVariazione" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <span class="fw-bold">Intervento: </span>
                                        <asp:Label ID="lblIntervento" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-sm-6">
                                        <span class="fw-bold">Codifica: </span>
                                        <asp:Label ID="lblCodifica" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-sm-6">
                                        <span class="fw-bold">Dettaglio: </span>
                                        <asp:Label ID="lblDettaglio" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-sm-12">
                                        <span class="fw-bold">Descrizione: </span>
                                        <asp:Label ID="lblDescrizione" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-sm-12" id="investimentoAggregazione" runat="server" visible="false">
                                        <span class="fw-bold">Impresa: </span>
                                        <asp:Label ID="lblImpresaInvestimento" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group col-sm-4">
                <Siar:CurrencyBox Label="Costo investimento:" ID="txtCostoInvestimento" runat="server" ReadOnly="True" />
            </div>
            <div class="col-sm-4 form-group" style="display: none;">
                <Siar:Label ID="lblSpeseTecniche" runat="server"></Siar:Label>
                <Siar:CurrencyBox ID="txtSpeseTecniche" runat="server" ReadOnly="True" />
            </div>
            <div class="form-group col-sm-4">
                <Siar:CurrencyBox Label="Contributo:" ID="txtContributoAmmesso" runat="server" ReadOnly="True" />
            </div>
            <div class="form-group col-sm-4">
                <Siar:QuotaBox Label="Aiuto %:" NrDecimali="12" ID="txtQuotaAiuto" runat="server" ReadOnly="True" />
            </div>
            <h4 class="pb-5">Totali richiesti fino ad ora per l'investimento:</h4>
            <div class="col-sm-4 form-group">
                <Siar:CurrencyBox Label="Importo totale:" ID="txtStoricoImportoRichiesto" runat="server" ReadOnly="True" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:CurrencyBox Label="Contributo:" ID="txtStoricoContributoRichiesto" runat="server" ReadOnly="True" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:QuotaBox Label="Aiuto %:" ID="txtStoricoRichiestoQuota" runat="server" ReadOnly="True" />
            </div>
            <div class="col-sm-4 form-group" style="display: none;">
                <asp:Label ID="lblFormulaCompletamento" runat="server" Text="(C/(A+B))"></asp:Label>
                <Siar:QuotaBox NrDecimali="12" ID="txtCompletamentoInvestimento" runat="server" ReadOnly="True" />
            </div>
            <p class="pb-3">
                Queste cifre definiscono l'ammontare della spesa in eccesso, e del relativo contributo, disponibili per l'investimento corrente per essere assegnati alle economie, nel margine del 10%
            </p>
            <div class="col-sm-6 form-group">
                <Siar:CurrencyBox Label="Spesa Extra disponibile per economie:" ID="txtDisavanzoInvestimento" runat="server" ReadOnly="True" />
            </div>
            <div class="col-sm-6 form-group">
                <Siar:CurrencyBox Label="Contributo Extra disponibile per economie" ID="txtDisavanzoInvestimentoContributo" runat="server" ReadOnly="True" />
            </div>
            <p class="pb-3">
                Queste cifre definiscono l'ammontare totale delle economie presenti per l'intera domanda di contributo, e quelle rimanenti ancora da coprire con il margine del 10%
            </p>
            <div class="col-sm-6 form-group">
                <Siar:CurrencyBox Label="Economie totali da investimenti tagliati:" ID="txtEconomieDaCoprire" runat="server" ReadOnly="true" />
            </div>
            <div class="col-sm-6 form-group">
                <Siar:CurrencyBox Label="Economie rimanenti da coprire:" ID="txtEconomieScoperte" runat="server" ReadOnly="true" />
            </div>
            <p>
                Queste cifre rappresentano quanto, per l'attuale investimento, è stato già riassegnato a coperture delle economie
            </p>
            <p class="pb-3">
                Nella casella di testo editabile è possibile inserire la spesa da riassegnare, il cui contributo verrà calcolato una volta che si ammette l'investimento.
            </p>
            <div class="col-sm-4 form-group">
                <Siar:CurrencyBox Label="Contributi riassegnati in altre domande per l'investimento:" ID="txtImportoRiassegnatoInvestimento" runat="server" ReadOnly="true" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:CurrencyBox Label="Costo spesa extra da assegnare:" ID="txtCostoDaAssegnare" runat="server" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:CurrencyBox Label="Contributo extra da assegnare:" ID="txtContributoDaAssegnare" ReadOnly="true" runat="server" />
            </div>
            <h4 class="pb-5">Totali pagamento richiesto:</h4>
            <div class="col-sm-6 form-group">
                <Siar:CurrencyBox Label="Importo totale:" ID="txtImportoTotaleRichiesto" runat="server" ReadOnly="True" />
            </div>
            <div class="col-sm-6 form-group">
                <Siar:CurrencyBox Label="Contributo totale:" ID="txtContributoTotaleRichiesto" runat="server" ReadOnly="True" />
            </div>
            <div class="col-sm-12" style="display: none;">
                <Siar:CurrencyBox Label="Importo investimento:" ID="txtImportoInvestimento" runat="server" ReadOnly="True" />
                <Siar:CurrencyBox Label="Importo da computo metrico:" ID="txtImportoComputoMetrico" runat="server" />
                <Siar:CurrencyBox Label="Importo spese tecniche:" ID="txtImportoSpeseTecniche" runat="server" ReadOnly="True" />
                <Siar:CurrencyBox Label="Importo lavori in economia: (**)" ID="txtImportoRichiestoLavoriInEconomia" runat="server" ReadOnly="True" />
                <Siar:CurrencyBox Label="% lavori in economia su totale:" ID="txtQuotaRichiestoLavoriInEconomia" runat="server" ReadOnly="True" />
            </div>
            <div class="col-sm-12" id="tdRichiestoAltreFonti" runat="server">
                <Siar:CurrencyBox Label="Contributo Altre Fonti:" ID="txtContributoRichiestoAltreFonti" runat="server" ReadOnly="True" />
            </div>
            <h4 class="pb-5">Totali pagamento ammesso:</h4>
            <div class="col-sm-6 form-group">
                <Siar:CurrencyBox Label="Importo totale:" ID="txtImportoTotaleAmmesso" runat="server" ReadOnly="True" />
            </div>
            <div class="col-sm-6 form-group">
                <Siar:CurrencyBox Label="Contributo totale:" ID="txtContributoTotaleAmmesso" runat="server" ReadOnly="True" />
            </div>
            <div class="col-sm-12 form-group" style="display: none;">
                <Siar:CurrencyBox Label="Importo investimento:" ID="txtImportoInvestimentoAmmesso" runat="server" ReadOnly="True" />
                <Siar:CurrencyBox Label="Importo da computo metrico:(*)" ID="txtImportoComputoMetricoAmmesso" runat="server" Width="120px" />
                <Siar:CurrencyBox Label="Importo spese tecniche:" ID="txtImportoSpeseTecnicheAmmesse" runat="server" ReadOnly="True" />
                <Siar:CurrencyBox Label="Importo lavori in economia:(***)" ID="txtImportoAmmessoLavoriInEconomia" runat="server" ReadOnly="True" />
                <Siar:CurrencyBox Label="% lavori in economia su totale:" ID="txtQuotaAmmessoLavoriInEconomia" runat="server" ReadOnly="True" />
            </div>
            <div class="col-sm-12 form-group" runat="server" visible="false" id="tdAmmessoFinale">
                <Siar:CurrencyBox Label="(**) Contributo finale:" ID="txtContributoAmmessoFinale" runat="server" ReadOnly="True" />
            </div>
            <div class="col-sm-12 form-group" id="tdAmmessoAltreFonti" runat="server">
                <Siar:CurrencyBox Label="Contributo Altre Fonti:" ID="txtContributoAmmessoAltreFonti" runat="server" ReadOnly="True" />
            </div>
        </div>
        <table class="tableNoTab" style="width: 1000px; display: none;">
            <tr class="TESTA1">
                <td>&nbsp;Sanzioni comminate per l'investimento:
                </td>
            </tr>
            <tr>
                <td>&nbsp;<br />
                    <Siar:DataGrid ID="dgSanzioni" runat="server" AutoGenerateColumns="False" Width="100%"
                        ShowFooter="True">
                        <Columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <ItemStyle HorizontalAlign="Center" Width="25px" />
                            </Siar:NumberColumn>
                            <asp:BoundColumn DataField="Titolo" HeaderText="Descrizione">
                                <ItemStyle Width="275px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Entit&#224;">
                                <ItemStyle Width="200px" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Gravit&#224;">
                                <ItemStyle Width="200px" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Durata">
                                <ItemStyle Width="200px" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Ammontare" HeaderText="Ammontare" DataFormatString="{0:c}">
                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                        </Columns>
                        <FooterStyle CssClass="TotaliFooter" />
                        <PagerStyle CssClass="coda" />
                        <AlternatingItemStyle BackColor="#FFF0D2" CssClass="DataGridRow" />
                        <ItemStyle CssClass="DataGridRow" Height="18px" />
                        <HeaderStyle CssClass="TESTA1" Font-Bold="True" ForeColor="White" />
                    </Siar:DataGrid>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 48px">
                    <Siar:Button ID="btnCalcolaSanzioni" runat="server" CausesValidation="False" Modifica="True"
                        OnClick="btnCalcolaSanzioni_Click" Text="Calcola sanzioni" Width="180px" />
                    &nbsp;&nbsp;
                <Siar:Button ID="btnDelSanzioni" runat="server" CausesValidation="False" Modifica="True"
                    OnClick="btnDelSanzioni_Click" Text="Annulla tutte le sanzioni" Conferma="Attenzione! Annullare tutte le sanzioni comminate?"
                    Width="180px" />
                    &nbsp;
                <Siar:Button ID="btnNuovaSanzione" runat="server" CausesValidation="False" Modifica="True"
                    OnClick="btnNuovaSanzione_Click" Text="Nuova sanzione" Width="140px" />
                    &nbsp; &nbsp;
                </td>
            </tr>
        </table>

        <div class="row" id="trIntegrazioneInvestimenti" runat="server" visible="false">
            <h3 class="pb-5">Richiedi integrazione per l'investimento:</h3>
            <div class="col-sm-12 form-group">
                <Siar:DateTextBox Label="Data richiesta:" ID="txtDataRichiesta" runat="server" />
            </div>
            <div class="col-sm-12 form-group">
                <Siar:TextArea Label="Note richiesta:" ID="txtNoteIntegrazioneRichiesta" runat="server"
                    Rows="4" ExpandableRows="5" MaxLength="10000" />
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnNuovaRichiestaIntegrazioneInvestimenti" runat="server" CausesValidation="False"
                    Modifica="True" OnClick="btnNuovaRichiestaIntegrazioneInvestimenti_Click" Text="Nuova richiesta integrazione" />
            </div>
        </div>
        <h3 class="pb-5">Valutazione dell'istruttore:</h3>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Valutazione dell'istruttore" ID="txtValutazioneLunga" runat="server" Rows="3" ExpandableRows="5" />
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalva" runat="server" CausesValidation="False" OnClick="btnSaveRichiesto_Click"
                Text="Ammetti" Modifica="True" />
            <Siar:Button ID="btnVariazioneInvestimento" runat="server" CausesValidation="False"
                Modifica="True" OnClick="btnVariazioneInvestimento_Click" Text="Variazione investimento" />
            <%--                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" class="Button" value="Correttiva rendicontazione" style="width: 180px"
                    onclick="location='IstruttoriaCorrettivaRendicontazione.aspx'" />--%>
            <input id="btnBack" runat="server" class="btn btn-secondary py-1" type="button"
                onclick="location = 'IstruttoriaPianoInvestimenti.aspx'" value="Indietro" /><br />
        </div>
        <h3 class="py-5">Elenco giustificativi associati (<asp:Label ID="lblNumeroPagamenti" runat="server"></asp:Label>)</h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgPagamenti" runat="server" AutoGenerateColumns="False"
                NrColumnSearch="true" ShowFooter="true">
                <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Documento">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Imponibile" DataFormatString="{0:c}" HeaderText="Imponibile">
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoRichiesto" DataFormatString="{0:c}" HeaderText="Importo">
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Contributo">
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn>
                        <ItemStyle CssClass="testoRosso" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Importo" DataField="ImportoAmmesso" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Contributo" DataField="ContributoAmmesso" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
            <div class="col-sm-12 text-end">
                <span class='testoRosso'>(V) </span>= pagamenti che costituiscono un effettiva <strong>variazione</strong> dell'investimento&nbsp;
            </div>
            <div style="display: none">
                <Siar:Hidden ID="hdnIdPagamentoBeneficiario" runat="server">
                </Siar:Hidden>
                <Siar:Button ID="btnPost" runat="server" CausesValidation="False" OnClick="btnPost_Click" />
            </div>
        </div>
        <div id='divIstPagForm' class="modal it-dialog-scrollable" tabindex="-1" role="dialog" style="position: absolute; display: none">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title h5 " id="modal1Title">Istruttoria della spesa richiesta a pagamento:</h2>
                    </div>
                    <div class="modal-body">
                        <table width="100%" class="tableNoTab">
                            <tr>
                                <td class="separatore"></td>
                            </tr>
                            <tr>
                                <td style="padding: 10px">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 400px" rowspan="2">Oggetto di spesa:<br />
                                                <Siar:TextArea ID="txtGSOggetto" runat="server" Width="360px" ReadOnly="true" Rows="4" />
                                            </td>
                                            <td style="width: 130px">Numero giustificativo:<br />
                                                <Siar:TextBox  ID="txtGSNumero" runat="server" Width="100px" TextAlign="right" ReadOnly="true" />
                                            </td>
                                            <td>Data giustificativo:<br />
                                                <Siar:DateTextBox ID="txtGSData" runat="server" Width="100px" ReadOnly="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 130px">Imponibile &euro;:<br />
                                                <Siar:CurrencyBox ID="txtGSImponibile" runat="server" Width="100px" ReadOnly="true" />
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="separatore_light">&nbsp;Pagamento richiesto:
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 10px">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="width: 130px">Importo &euro;:<br />
                                                <Siar:CurrencyBox ID="txtIPImportoRichiesto" runat="server" Width="100px" ReadOnly="true" />
                                            </td>
                                            <td style="width: 130px">Contributo &euro;:<br />
                                                <Siar:CurrencyBox ID="txtIPContributoRichiesto" runat="server" Width="100px" ReadOnly="True" />
                                            </td>
                                            <td style="width: 140px; display: none;">
                                                <br />
                                                <input id="chkIPSpesaTecnicaRichiesta" runat="server" style="width: 24px" type="checkbox"
                                                    disabled="disabled" />Spesa tecnica
                                            </td>
                                            <td></td>
                                            <td style="display: none;">
                                                <br />
                                                <input id="chkIPVariazione" runat="server" style="width: 24px" type="checkbox" disabled="disabled" />Costituisce
                                effettiva <b>variazione</b> di investimento
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="separatore_light">Pagamento ammesso:
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 10px">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 400px; vertical-align: top">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 130px">
                                                            <br />
                                                            Importo &euro;:<br />
                                                            <Siar:CurrencyBox ID="txtIPImportoAmmesso" runat="server" Width="100px" Obbligatorio="True"
                                                                NomeCampo="Importo ammesso" />
                                                        </td>
                                                        <td style="width: 130px">
                                                            <br />

                                                            <input id="btnCalcolaContributoAmmesso" class="ButtonGrid" type="button"
                                                                value="Calcola" onclick="btnCalcolaContributoAmmesso_Click();" />
                                                            <%--<Siar:Button ID="btnCalcolaContributoAmmesso"  onclick="btnCalcolaContributoAmmesso_Click();"
                                            Text="Calcola" Width="90px" Modifica="true" />--%>
                                                        </td>
                                                        <td style="width: 130px">
                                                            <br />
                                                            Non ammesso &euro;:<br />
                                                            <Siar:CurrencyBox ID="txtIPImportoNonAmmesso" runat="server" Width="100px" ReadOnly="True" />
                                                        </td>

                                                        <td style="display: none;">Importo a<br />
                                                            NON responsabilità:<br />
                                                            <Siar:CurrencyBox ID="txtIPImportoNonresp" runat="server" Width="100px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 130px">
                                                            <br />
                                                            Contributo &euro;:<br />
                                                            <Siar:CurrencyBox ID="txtIPContributoAmmesso" runat="server" Width="100px" />
                                                        </td>
                                                        <td style="width: 130px">
                                                            <br />
                                                            Contributo %:<br />
                                                            <Siar:QuotaBox NrDecimali="12" ID="txtIPContributoQuota" runat="server" Width="50px" Obbligatorio="True" />
                                                        </td>
                                                        <td style="width: 130px">
                                                            <br />
                                                            Contr Non ammesso &euro;:<br />
                                                            <Siar:CurrencyBox ID="txtIPContributoNonAmmesso" runat="server" Width="100px" ReadOnly="True" />
                                                        </td>

                                                        <td style="display: none;">Contributo a<br />
                                                            NON responsabilità:<br />
                                                            <Siar:CurrencyBox ID="txtIPContributoNonresp" runat="server" Width="100px" ReadOnly="True" />
                                                        </td>
                                                    </tr>
                                                    <tr style="display: none;">
                                                        <td style="width: 130px; height: 30px;">
                                                            <input id="chkIPSpesaTecnica" runat="server" style="width: 24px" type="checkbox" />Spesa
                                            tecnica
                                                        </td>
                                                        <td style="height: 30px"></td>
                                                        <td style="height: 30px"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td class="paragrafo">Motivazioni riduzione:
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <Siar:CheckBoxList ID="chklIPMotivazioniRiduzione" runat="server" RepeatDirection="Horizontal"
                                                                RepeatColumns="2" RepeatLayout="Flow">
                                                            </Siar:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-top: 5px">Note aggiuntive (max 500 caratteri):<br />
                                                            <Siar:TextArea ID="txtIPNoteAggiuntive" runat="server" Width="440px" Rows="4" MaxLength="500" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td class="paragrafo">Pagamento ammesso: (AdC - Controlli in loco)
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td style="padding: 10px">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 130px">
                                                <br />
                                                Importo &euro;:<br />
                                                <Siar:CurrencyBox ID="txtIPImportoAmmessoInLoco" runat="server" Width="100px" ReadOnly="True" />
                                            </td>
                                            <td style="width: 130px">
                                                <br />
                                                Non ammesso &euro;:<br />
                                                <Siar:CurrencyBox ID="txtIPImportoNonAmmessoContr" runat="server" Width="100px" ReadOnly="True" />
                                            </td>
                                            <td>Importo a<br />
                                                NON responsabilità:<br />
                                                <Siar:CurrencyBox ID="txtIPImportoNonrespInLoco" runat="server" Width="100px" ReadOnly="True" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 130px">
                                                <br />
                                                Contributo &euro;:<br />
                                                <Siar:CurrencyBox ID="txtIPContributoAmmessoInLoco" runat="server" Width="100px"
                                                    ReadOnly="True" />
                                                <br />
                                            </td>
                                            <td style="width: 130px">
                                                <br />
                                                Non ammesso &euro;:<br />
                                                <Siar:CurrencyBox ID="txtIPContributoNonAmmessoContr" runat="server" Width="100px"
                                                    ReadOnly="True" />
                                            </td>
                                            <td>Contributo a<br />
                                                NON responsabilità:<br />
                                                <Siar:CurrencyBox ID="txtIPContributoNonrespInLoco" runat="server" Width="100px"
                                                    ReadOnly="True" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 130px; height: 30px;">
                                                <input id="chkIPSpesaTecnicaInLoco" runat="server" style="width: 24px" type="checkbox"
                                                    disabled="disabled" />Spesa tecnica
                                            </td>
                                            <td style="height: 30px"></td>
                                            <td style="height: 30px"></td>
                                        </tr>
                                    </table>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <Siar:Button ID="btnAmmettiPagamento" runat="server" OnClick="btnAmmettiPagamento_Click"
                            Text="Salva" Modifica="true" />
                        <input id="btnChiudi" class="btn btn-secondary py-1" type="button"
                            value="Chiudi" onclick="chiudiPopup()" />
                    </div>
                </div>
            </div>
        </div>
        <div id='divNuovaSanzione' class="modal it-dialog-scrollable" tabindex="-1" role="dialog" style="position: absolute; display: none">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title h5 " id="modal1Title">Istruttoria della spesa richiesta a pagamento:</h2>
                    </div>
                    <div class="modal-body">
                        <table width="100%" class="tableNoTab">
                            <tr>
                                <td class="separatore">Elenco delle sanzioni:
                                </td>
                            </tr>
                            <tr>
                                <td class="testo_pagina">Di seguito vengono elencate tutte le sanzioni che possono essere comminate all'investimento<br />
                                    in esame, previste dalla programmazione di appartenenza e dal livello di applicazione
                    delle stesse.<br />
                                    Selezionare uno o più elementi a seconda delle violazioni degli impegni riscontrate.
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <Siar:DataGrid ID="dgNuovaSanzione" runat="server" AutoGenerateColumns="False" Width="100%">
                                        <Columns>
                                            <Siar:NumberColumn HeaderText="Nr.">
                                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                                            </Siar:NumberColumn>
                                            <asp:BoundColumn DataField="Titolo" HeaderText="Descrizione"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="Livello" HeaderText="Livello applicazione" DataFormatString="{0:D=Domanda|O=Investimento}">
                                                <ItemStyle Width="120px" HorizontalAlign="center" />
                                            </asp:BoundColumn>
                                            <Siar:CheckColumn DataField="CodTipo" Name="chkNuovaSanzione">
                                                <ItemStyle Width="80px" HorizontalAlign="center" />
                                            </Siar:CheckColumn>
                                        </Columns>
                                    </Siar:DataGrid>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <Siar:Button ID="btnAssegnaSanzioni" runat="server" OnClick="btnAssegnaSanzioni_Click"
                            Text="Assegna sanzioni" Modifica="true" CausesValidation="False" />
                        <input id="btnChiudiSanzione" class="btn btn-secondary py-1"
                            type="button" value="Chiudi" onclick="chiudiPopupTemplate();" />
                    </div>
                </div>
            </div>
        </div>
        <div id='divSelezioneParametro' class="modal it-dialog-scrollable" tabindex="-1" role="dialog" style="position: absolute; display: none">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title h5 " id="modal1Title">Scelta dei valori del parametro:</h2>
                    </div>
                    <div class="modal-body">
                        <table width="100%" class="tableNoTab">
                            <tr>
                                <td class="separatore">Scelta dei valori del parametro:
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;<div id='divValoriParametro' style="width: 100%">
                                </div>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <input id="Button2" class="btn btn-secondary py-1" type="button" value="Chiudi"
                            onclick="chiudiPopupTemplate()" />
                    </div>
                </div>
            </div>
        </div>
        <div id="divLavoriInEconomia" class="modal it-dialog-scrollable" tabindex="-1" role="dialog" style="position: absolute; display: none">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title h5 " id="modal1Title">Istruttoria della spesa richiesta a pagamento:</h2>
                    </div>
                    <div class="modal-body">
                        <table class="tableNoTab" width="100%">
                            <tr>
                                <td class="separatore">Dettaglio del lavoro in economia:
                                </td>
                            </tr>
                            <tr>
                                <td class="testo_pagina">Specificare l'<b>importo in euro</b> e la <b>descrizione</b> dei lavori effettuati
                    in tale modalità. E' possibile rendicontare importi fino, e non oltre,
                    <br />
                                    ad un ammontare calcolato come la <b>differenza tra il computo metrico e contributo
                        totale</b> attribuito <b>( E = M - T )</b>.
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 10px">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 200px">
                                                <table width="100%">
                                                    <tr>
                                                        <td>Importo &euro;:<br />
                                                            <Siar:CurrencyBox ID="txtLECImportoRichiesto" runat="server" Width="120px" ReadOnly="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Contributo &euro;:<br />
                                                            <Siar:CurrencyBox ID="txtLECContributoRichiesto" runat="server" Width="120px" ReadOnly="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="height: 38px; width: 24px">
                                                                        <input id="chkLECVariazioneInvestimento" runat="server" type="checkbox" disabled="disabled" />
                                                                    </td>
                                                                    <td style="height: 38px">lavoro costituente effettiva <b>variazione</b> dell'investimento
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="vertical-align: top">Descrizione:<br />
                                                <Siar:TextArea ID="txtLECDescrizione" runat="server" Rows="6" Width="610px" ReadOnly="true" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="paragrafo">Pagamento ammesso:
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 10px">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 200px; vertical-align: top">
                                                <table width="100%">
                                                    <tr>
                                                        <td>Importo &euro;:<br />
                                                            <Siar:CurrencyBox ID="txtLECImportoAmmesso" runat="server" Width="120px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Contributo &euro;:<br />
                                                            <Siar:CurrencyBox ID="txtLECContributoAmmesso" runat="server" Width="120px" ReadOnly="true" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td class="paragrafo">Motivazioni della riduzione:
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 4px">
                                                            <Siar:CheckBoxList ID="chklLECMotivazioniRiduzione" runat="server" RepeatColumns="3"
                                                                RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                            </Siar:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Note aggiuntive:<br />
                                                            <Siar:TextArea ID="txtLECNoteAggiuntive" runat="server" Rows="6" Width="610px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <Siar:Button ID="btnSalvaLavoriInEconomia" runat="server" Modifica="true" OnClick="btnSalvaLavoriInEconomia_Click"
                            Text="Salva" CausesValidation="False" OnClientClick="return ctrlAmmessoLavoriInEconomia(event);" />
                        <input class="btn btn-secondary py-1" onclick="chiudiPopup()" type="button" value="Chiudi" />
                    </div>
                </div>
            </div>
        </div>
        <uc3:ucPagamentoInvestimento ID="modalePagamento" runat="server" />
        <div class="col-sm-12 text-end mt-5">
            <a href="../IPagamento/IstruttoriaPianoInvestimenti.aspx" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                </svg>
                Torna all'istruttoria del piano investimenti</a>
        </div>
    </div>
</asp:Content>
