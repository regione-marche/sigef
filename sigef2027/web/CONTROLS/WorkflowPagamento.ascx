<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WorkflowPagamento.ascx.cs" Inherits="web.CONTROLS.WorkflowPagamento" %>
<%--<div class="row pt-5">--%>
<%--    <div class="col-lg-6">
        <!--start card-->
        <div class="card-wrapper card-space">
            <div class="card card-bg card-big">
                <div class="card-body">
                    <div class="top-icon">
                        <span class="card-title h5 ">
                            <svg class="icon">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-card"></use>
                            </svg>
                            <span>Dati domanda di aiuto</span></span>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">Numero: </span>
                                <asp:Label ID="lblNumero" runat="server">
                                </asp:Label>
                            </p>
                        </div>
                        <div>
                            <p>
                                <span class="fw-bold">Beneficiario: </span>
                                <Siar:Label ID="lblCodiceFiscale" runat="server"></Siar:Label>
                                -
                                <Siar:Label ID="lblRagioneSociale" runat="server"></Siar:Label>
                            </p>
                        </div>
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">Stato: </span>
                                <asp:Label ID="lblStato" runat="server">
                                </asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-12">
                            <p>
                                <span class="fw-bold">Visualizza documento firmato: </span>
                                <uc2:SNCVisualizzaProtocollo ID="ucVPProgetto" runat="server" TipoVisualizzazione="Immagine"
                                    VisualizzaMenu="true" />
                            </p>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <input id="btnAnnulla" class="btn btn-secondary py-1 m-1" type="button" value="Vai alla gestione lavori" onclick="location = 'GestioneLavori.aspx'" /><input id="btnProgetto" class="btn btn-secondary py-1 m-1" type="button" value="Vai alla sezione domanda" onclick="location = '../PDomanda/DatiGenerali.aspx'" />
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-6">
        <!--start card-->
        <div class="card-wrapper card-space">
            <div class="card card-bg card-big">
                <div class="card-body">
                    <div class="top-icon">
                        <span class="card-title h5 ">
                            <svg class="icon">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-bookmark"></use>
                            </svg>
                            <span>Dati domanda di pagamento</span></span>
                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Numero: </span>
                                <asp:Label ID="lblNumeroPagamento" runat="server">
                                </asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Stato: </span>
                                <asp:Label ID="lblStatoPagamento" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Modalità: </span>
                                <Siar:Label ID="lblTipoPagamento" runat="server"></Siar:Label>
                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Operatore: </span>
                                <asp:Label ID="lblOperatore" runat="server"></asp:Label>
                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Visualizza documento firmato: </span>
                                <uc2:SNCVisualizzaProtocollo ID="ucVPPagamento" runat="server" TipoVisualizzazione="Invisibile"
                                    VisualizzaMenu="true" />
                            </p>
                        </div>
                        <div class="col-sm-6">
                            <p>
                                <span class="fw-bold">Ricevuta di protocollazione: </span>
                                <uc1:VisualizzaReport ID="ucVRPagamento" runat="server" ReportFormat="PDF" ReportViewOptions="Invisibile"
                                    Text="Stampa la ricevuta di protocollazione" ReportName="rptRicevutaProtocollazioneDomandaPagamento" />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
<%--    <div class="col-sm-12">
    <div class="steppers">--%>
<div class="steppers-header" id="tableNavigazione" runat="server" visible="false">
    <ul>
        <asp:Repeater ID="rptSteppers" runat="server">
            <ItemTemplate>
                <!-- confirmed -->
                <li class="<%# (WorkflowCorrente.Ordine == int.Parse(Eval("Ordine").ToString())) ? "active" : "confirmed" %>">
                    <a class="steppers-link" type="button" title="<%# Eval("Descrizione") %>" href="<%# Eval("Url") %>">
                        <svg class="icon icon-lg ">
                            <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right"></use>
                        </svg>
                        <span class="steppers-text"><%# Eval("Descrizione") %><%# (WorkflowCorrente.Ordine == int.Parse(Eval("Ordine").ToString())) ? "<span class='visually-hidden'>Attivo</span>" : (WorkflowCorrente.Ordine < int.Parse(Eval("Ordine").ToString())) ? "" : "<svg class='icon steppers-success'><use href='/web/bootstrap-italia/svg/sprites.svg#it-check'></use></svg><span class='visually-hidden'>Confermato</span>" %></span>
                    </a>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <span class="steppers-index" aria-hidden="true">2/6</span>
</div>
<nav class="steppers-nav" id="divSteppersButtons" runat="server" visible="false">
    <button type="button" id="btnPrec" runat="server" class="btn btn-outline-primary btn-sm steppers-btn-prev">
        <svg class="icon icon-primary">
            <use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro
    </button>
    <button type="button" id="btnSucc" runat="server" class="btn btn-outline-primary btn-sm steppers-btn-next">
        Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg>
    </button>
</nav>

<%--<table class="tableTab" width="800" id="tableNavigazione" runat="server" visible="false">
    <tr>
        <td align="center" style="width: 592px">
            <input id="btnPrev" class="ButtonProsegui" runat="server" type="button" />
            <input id="btnCurrent" class="ButtonProsegui BPDisabled" disabled="disabled" style="width: 40px"
                runat="server" type="button" />
            <input id="btnGo" class="ButtonProsegui" runat="server" type="button" />
        </td>
    </tr>
</table>--%>