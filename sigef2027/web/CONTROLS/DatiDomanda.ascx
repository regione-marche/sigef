<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.DatiDomanda"
    CodeBehind="DatiDomanda.ascx.cs" %>
<%@ Register Src="SNCVisualizzaProtocollo.ascx" TagName="SNCVisualizzaProtocollo"
    TagPrefix="uc1" %>
<%@ Register Src="VisualizzaReport.ascx" TagName="VisualizzaReport" TagPrefix="uc2" %>
<style type="text/css">
    .td_imglnk {
        width: 35px;
        height: 20px;
    }
</style>
<div class="row pt-4">
    <div class="col-sm-12 col-lg-6">
        <!--start card-->
        <div class="card-wrapper card-space">
            <div class="card card-bg-100 card-big rounded-2 bd-form shadow">
                <div class="card-body">
                    <div class="top-icon">
                        <span class="card-title h5 ">
                            <svg class="icon">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-card"></use>
                            </svg>
                            <span>DATI DOMANDA DI CONTRIBUTO</span></span>
                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Informazioni del bando: </span><a title="Visualizza il bando" id="lnkDocumentiBando" runat="server">
                                    <svg class="icon">
                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-info-circle"></use></svg>
                                </a>
                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p runat="server" id="tdComunicazioni">
                                <span class="fw-bold">Comunicazioni:</span><a type="button" title="Comunicazioni con il beneficiario" href="../PDomanda/Comunicazioni.aspx">
                                    <svg class="icon">
                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-mail"></use></svg></a>
                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Numero: </span>
                                <asp:Label ID="lblNumero" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Codice CUP: </span>
                                <asp:Label ID="lblCodiceCUP" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Stato: </span>
                                <asp:Label ID="lblStato" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Versione attuale: </span>
                                <uc2:VisualizzaReport ID="ucVRDomandaAttuale" runat="server" ReportFormat="PDF" Text="Visualizza domanda attuale" />
                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Documento firmato: </span>
                                <uc1:SNCVisualizzaProtocollo ID="ucSNCVisualizzaProtocollo" runat="server" TipoVisualizzazione="Immagine"
                                    VisualizzaMenu="false" />
                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Ricevuta di protocollazione: </span>
                                <uc2:VisualizzaReport ID="ucVRRicevutaProtocollazione" runat="server" ReportFormat="PDF"
                                    Text="Stampa ricevuta di protocollazione" />
                            </p>
                        </div>
                        <div class="col-sm-12" runat="server" id="tdLinks">
                            <a id="btnApriDomanda" runat="server" class="btn btn-secondary py-1" type="button" href="/web/Private/PDomanda/DatiGenerali.aspx">Vai alla domanda</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--end card-->
    </div>
    <div class="col-sm-12 col-lg-6">
        <!--start card-->
        <div class="card-wrapper card-space">
            <div class="card card-bg-100 card-big rounded-2 bd-form shadow">
                <div class="card-body">
                    <div class="top-icon">
                        <span class="card-title h5 ">
                            <svg class="icon">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-user"></use>
                            </svg><span>DATI BENEFICIARIO</span></span>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">C.F./P.Iva: </span>
                                <Siar:Label ID="lblCodiceFiscale" runat="server">
                                </Siar:Label>
                            </p>
                        </div>
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">Ragione Sociale: </span>
                                <Siar:Label ID="lblRagioneSociale" runat="server">
                                </Siar:Label>
                            </p>
                        </div>
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">Ultima modifica dei dati: </span>
                                <Siar:Label ID="lblModifica" runat="server"></Siar:Label>
                            </p>
                        </div>
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">Operatore: </span>
                                <Siar:Label ID="lblOperatore" runat="server"></Siar:Label>
                            </p>
                        </div>
                        <div class="col-sm-12">
                            <input id="btnSezioneImpresa" runat="server" class="btn btn-secondary py-1"
                                type="button" value="Visualizza elenco domande dell'impresa" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--end card-->
    </div>
</div>
<div id="DatiDomanda" class="row">
    <div id="trCupDoppi" class="col-sm-12" runat="server" visible="false">
        <div class="text-start">
            <p>
                <span class="fw-bold">Progetti con lo stesso codice CUP: </span>
                <span class="fw-bold">
                    <Siar:Label ID="lblCupDoppi" runat="server"></Siar:Label>
                </span>
            </p>
        </div>
    </div>
    <%--    <div class="col-sm-12" id="tdLinks" runat="server">
        <div class="row">
            <div class="col-sm-12">
                <div class="row">
                    <div class="col-sm-12 text-center">
                        <span class="fw-bold">Sezioni:</span>
                        <a title="Dati generali" type="button" href="../PDomanda/DatiGenerali.aspx">
                            <svg class="icon icon-lg">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-files"></use></svg></a>

                        <a type="button" title='Dati anagrafici dell`impresa' href='../PDomanda/Anagrafica.aspx'>
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-card"></use></svg></a>
                        <a type="button" style="display: none;" href='../PDomanda/FascicoloAziendale.aspx'>
                            <img title='Fascicolo aziendale' src='../../images/fascicolo.gif' />
                            Fascicolo aziendale</a>
                        <a type="button" title="Requisiti soggettivi" href="../PDomanda/RequisitiDomanda.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-user"></use></svg></a>

                        <a type="button" id="tdAggregazione" runat="server" title="Requisiti di impresa/aggregazione di impresa" href="../PDomanda/RequisitiImpresa.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-settings"></use></svg></a>
                        <a type="button" title="Descrizione dell'iniziativa progettuale" href="../PDomanda/RelazioneTecnica.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-pencil"></use></svg></a>
                        <a type="button" title="Business plan" href="../PDomanda/BusinessPlan.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use></svg></a>
                        <a type="button" title="Pagina di presentazione" href="../PDomanda/RiepilogoDomanda.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check-circle"></use></svg></a>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
</div>
<div id="divDocumentiBando" class="modal it-dialog-scrollable" tabindex="-1" role="dialog" style="position: absolute; display: none">
    <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h2 class="modal-title h5 " id="modal1Title">Elenco dei documenti relativi al bando selezionato:</h2>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-sm-12">
                        <span class="fw-bold">Id: </span>
                        <asp:Label ID="lblIdBando" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-12">
                        <span class="fw-bold">Descrizione: </span>
                        <asp:Label ID="lblDescBando" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-12">
                        <span class="fw-bold">Scadenza: </span>
                        <asp:Label ID="lblScadenzaBando" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-sm-12" id="tdGridDocumentiBando"></div>
            </div>
            <div class="modal-footer">
                <input type="button" value="Chiudi" class="btn btn-primary btn-sm" onclick="chiudiPopupTemplate()" />
            </div>
        </div>
    </div>
</div>
