<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.PagamentoInvestimento" CodeBehind="PagamentoInvestimento.aspx.cs" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/ZoomLoader.ascx" TagName="ZoomLoader" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/ucPagamentoInvestimento.ascx" TagName="ucPagamentoInvestimento" TagPrefix="uc3" %>
<%@ Register Src="~/CONTROLS/CardPagamento.ascx" TagName="CardPagamento" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function ctrlCampiLavoriInEconomia(ev) { if ($('[id$=txtLECImportoRichiesto_text]').val() == '' || $('[id$=txtLECDescrizione_text]').val() == '') { alert('Attenzione! E` necessario inserire sia l`importo che la descrizione dei lavori in economia.'); return stopEvent(ev); } }
    function mostraPagamento(id) { $('[id$=hdnIdPagamentoBeneficiario]').val(id); $('[id$=btnMostraPagamento]').click(); }
    function mostraPopupLavoriInEconomia() { $('[id$=hdnIdPagamentoBeneficiario]').val(''); $('[id$=txtLECImportoRichiesto_text]').val(''); $('[id$=txtLECDescrizione_text]').val(''); $('[id$=chkLECVariazioneInvestimento]')[0].checked = false; $('[id$=btnEliminaLavoriInEconomia]')[0].disabled = true; mostraPopupTemplate('divLavoriInEconomia', 'divBKGMessaggio'); }
    function chiudiPopup() { $('[id$=hdnIdPagamentoBeneficiario]').val(''); chiudiPopupTemplate(); }
    function selezionaGiustificativo(obj, b) { if (obj != null && confirm('Richiedere, in base al giustificativo selezionato, il pagamento per l`investimento?')) $('[id$=btnPost]').click(); }
//--></script>

    <div style="display: none">
        <Siar:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="False" />
        <Siar:Button ID="btnMostraPagamento" runat="server" OnClick="btnMostraPagamento_Click"
            CausesValidation="False" />
        <asp:HiddenField ID="hdnIdPagamentoRichiesto" runat="server" />
        <asp:HiddenField ID="hdnIdPagamentoBeneficiario" runat="server" />
    </div>
    <uc4:CardPagamento ID="ucCardPagamento" runat="server" />
    <nav class="breadcrumb-container" aria-label="Percorso di navigazione">
          <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="../PPagamento/SpeseSostenute.aspx"><svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use></svg>Spese sostenute dal beneficiario</a><span class="separator">/</span></li>            
            <li class="breadcrumb-item active" aria-current="page">Rendicontazione dell'investimento</li>
          </ol>
        </nav>
    <div class="row bd-form pt-5 mx-2">
        <div class="col-sm-12 text-end">
            <a href="../PPagamento/SpeseSostenute.aspx" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                </svg>
                Torna alle Spese sostenute dal beneficiario</a>
        </div>
        <h2 class="pb-5">Rendicontazione dell'investimento</h2>
        <div class="row">
            <div style="display: none;">
                <uc1:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
            </div>
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
                                            <svg id='imgDettaglioInvestimento' runat="server" style='cursor: pointer;' class="icon icon-secondary me-1" aria-hidden="true">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-file-pdf-ext"></use>
                                </svg>
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
                    <!--end card-->
                </div>
            </div>
            <%--            <table class="table table-responsive" id="tbInvestimento" runat="server" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="center"></td>
                    <td align="center"></td>
                    <td align="center"></td>
                    <td align="left"></td>
                </tr>
                <tr>
                    <td colspan="4" valign="middle"></td>
                </tr>
                <tr>
                    <td colspan="4" valign="middle"></td>
                </tr>
                <tr>
                    <td colspan="4" valign="middle"></td>
                </tr>
                <tr>
                    <td colspan="4" valign="middle"></td>
                </tr>
                <tr>
                    <td colspan="4" valign="middle"></td>
                </tr>
                <tr>
                    <td colspan="4" valign="middle"></td>
                </tr>
            </table>--%>
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
                <Siar:CurrencyBox Label="Aiuto %:" ID="txtQuotaAiuto" runat="server" ReadOnly="True" />
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
                <Siar:CurrencyBox Label="% Completamento:" ID="txtCompletamentoInvestimento" runat="server" ReadOnly="True" />
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
                <Siar:CurrencyBox Label="Importo lavori in economia:(**)" ID="txtImportoAmmessoLavoriInEconomia" runat="server" ReadOnly="True" />
                <Siar:CurrencyBox Label="% lavori in economia su totale:" ID="txtQuotaAmmessoLavoriInEconomia" runat="server" ReadOnly="True" />
            </div>
            <div class="col-sm-12 form-group" id="tdAmmessoAltreFonti" runat="server">
                <Siar:CurrencyBox Label="Contributo Altre Fonti:" ID="txtContributoAmmessoAltreFonti" runat="server" ReadOnly="True" />
            </div>
            <p>
                (*) = inserire l'importo da preventivo qualora il c.m. non fosse richiesto
            </p>
            <p>
                (**) = il contributo non puo&#39; superare la differenza tra rendicontato e importo lavori in economia ( T&lt;= M - E )
            </p>
            <div class="row" id="tableValutazione" runat="server" visible="false">
                <h3 class="pb-5">Valutazione dell'istruttore:</h3>
                <div class="col-sm-12 form-group">
                    <Siar:TextArea ID="txtValutazioneLunga" ReadOnly="true" runat="server" Rows="3" ExpandableRows="5" />
                </div>
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnSalva" runat="server" OnClick="btnSaveRichiesto_Click" Text="Salva" CausesValidation="False" />
                <input id="btnBack" class="btn btn-secondary py-1" type="button" value="Indietro"
                    onclick="location = 'PianoInvestimenti.aspx'" />
            </div>
            <div class="col-sm-6 mt-5">
                <p>
                    Elenco giustificativi associati (<asp:Label ID="lblNumeroPagamenti" runat="server"></asp:Label>)
                </p>
            </div>
            <div class="col-sm-6 text-end mt-5">
                <a id="lnkNuovoGiustificativo" runat="server" class="btn btn-primary py-1" href="">
                    <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-plus"></use>
                </svg>
                    Inserisci nuovo giustificativo</a>
                <a visible="false" id="lnkLavoroInEconomia" class="btn btn-primary py-1" runat="server" href="">
                    <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-plus"></use>
                </svg>
                    Inserisci lavoro in economia</a>
            </div>
            <div class="col-sm-12">
                <Siar:DataGridAgid ID="dgPagamenti" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" ShowFooter="true">
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Imponibile" DataFormatString="{0:c}" HeaderText="Imponibile">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoRichiesto" HeaderText="Importo" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <%--                        <asp:BoundColumn HeaderText="Spesa tecnica">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundColumn>--%>
                        <asp:BoundColumn>
                            <ItemStyle CssClass="testoRosso" HorizontalAlign="Center" Width="25px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoAmmesso" HeaderText="Importo" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo" DataField="ContributoAmmesso" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <%--                <asp:BoundColumn HeaderText="Spesa tecnica">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundColumn>--%>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdInvestimento" ButtonType="ImageButton" ButtonText="Richiesta integrazione"
                            JsFunction="" HeaderText="Richiesta integrazione" ButtonImage="warning.png">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
            <div class="col-sm-12 text-end">
                <span class='testoRosso'>(V) </span>= pagamenti che costituiscono un effettiva <strong>variazione</strong> dell'investimento&nbsp;
            </div>
            <div id="divLavoriInEconomia" style="width: 900px; position: absolute; display: none">
                <table class="tableNoTab" width="100%">
                    <tr>
                        <td class="separatore">Dettaglio del lavoro in economia:
                        </td>
                    </tr>
                    <tr>
                        <td class="testo_pagina">Specificare l'<b>importo in euro</b> e la <b>descrizione</b> dei lavori effettuati
                    in tale modalità. E&#39; possibile rendicontare importi fino, e non oltre,
                    <br />
                            ad un ammontare calcolato come la <b>differenza tra il computo metrico e contributo
                        totale</b> attribuito <b>( E &lt;= M - T )</b>.
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px">
                            <table width="100%">
                                <tr>
                                    <td style="width: 200px">
                                        <table width="100%">
                                            <tr>
                                                <td>Importo €:<br />
                                                    <Siar:CurrencyBox ID="txtLECImportoRichiesto" runat="server" Width="120px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Contributo €:<br />
                                                    <Siar:CurrencyBox ID="txtLECContributoRichiesto" runat="server" Width="120px" ReadOnly="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="height: 38px; width: 24px">
                                                                <input id="chkLECVariazioneInvestimento" runat="server" type="checkbox" />
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
                                        <Siar:TextArea ID="txtLECDescrizione" runat="server" Rows="6" Width="610px" />
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
                                                <td>Importo €:<br />
                                                    <Siar:CurrencyBox ID="txtLECImportoAmmesso" runat="server" Width="120px" ReadOnly="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Contributo €:<br />
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
                                                        RepeatDirection="Horizontal" RepeatLayout="Table" Enabled="false">
                                                    </Siar:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Note aggiuntive:<br />
                                                    <Siar:TextArea ID="txtLECNoteAggiuntive" runat="server" Rows="6" Width="610px" ReadOnly="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 70px">
                            <Siar:Button ID="btnSalvaLavoriInEconomia" runat="server" Modifica="true" OnClick="btnSalvaLavoriInEconomia_Click"
                                Text="Salva" Width="130px" CausesValidation="False" OnClientClick="return ctrlCampiLavoriInEconomia(event);" />
                            &nbsp;&nbsp;
                    <Siar:Button ID="btnEliminaLavoriInEconomia" runat="server" Modifica="true" OnClick="btnDel_Click"
                        CausesValidation="False" Text="Elimina" Conferma="Attenzione! Eliminare il pagamento?"
                        Width="130px" />
                            <input class="Button" onclick="chiudiPopup()" style="width: 100px; margin-left: 20px; margin-right: 20px"
                                type="button" value="Chiudi" />
                        </td>
                    </tr>
                </table>
            </div>

            <uc3:ucPagamentoInvestimento ID="modalePagamento" runat="server" />

            <uc2:ZoomLoader ID="ucZoomLoaderGiustificativiPagati" runat="server" AutomaticSearch="True"
                NoSearch="True" SearchMethod="GetGiustificativiDomandaPagamento" KeySearch="Numero:Numero|Data:Data:d"
                ColumnsToBind="nr|Numero:Numero:d|Data:Data:d|Imponibile:Imponibile:c|Descrizione:Descrizione"
                KeyValue="IdGiustificativo" KeyText="Descrizione|Numero|CodTipo|Data|CfFornitore|DataDoctrasporto|DescrizioneFornitore|Imponibile|Iva|IvaNonRecuperabile|NumeroDoctrasporto"
                JsSelectedItemHandler="selezionaGiustificativo" Width="700px" />
        </div>
        <div class="col-sm-12 text-end">
            <a href="../PPagamento/SpeseSostenute.aspx" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                </svg>
                Torna alle Spese sostenute dal beneficiario</a>
        </div>
    </div>
</asp:Content>
