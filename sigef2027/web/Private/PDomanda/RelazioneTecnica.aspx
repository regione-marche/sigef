<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.RelazioneTecnica" CodeBehind="RelazioneTecnica.aspx.cs" %>

<%@ Reference Control="~/CONTROLS/QuadroRelazioneTecnica.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <div class="col-sm-12">
        <div class="steppers mt-5">
            <div class="steppers-header">
                <ul>
                    <li class="confirmed">
                        <a class="steppers-link" title="Dati generali" type="button" href="../PDomanda/DatiGenerali.aspx">
                            <svg class="icon icon-lg">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-files"></use>
                            </svg>
                            <span class="steppers-text">Dati generali<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                        </a>
                    </li>
                    <li class="confirmed">
                        <a class="steppers-link" type="button" title='Dati anagrafici dell`impresa' href='../PDomanda/Anagrafica.aspx'>
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-card"></use>
                            </svg>
                            <span class="steppers-text">Dati anagrafici<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                        </a>
                    </li>
                    <li class="confirmed">
                        <a class="steppers-link" type="button" title='Visure dell`impresa' href='../PDomanda/GestioneVisure.aspx'>
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-file"></use>
                            </svg>
                            <span class="steppers-text">Gestione visure<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                        </a>
                    </li>
                    <li style="display: none;">
                        <a class="steppers-link" type="button" href='../PDomanda/FascicoloAziendale.aspx'>
                            <img title='Fascicolo aziendale' src='../../images/fascicolo.gif' />
                            Fascicolo aziendale</a>
                    </li>
                    <li class="confirmed">
                        <a class="steppers-link" type="button" title="Requisiti soggettivi" href="../PDomanda/RequisitiDomanda.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-user"></use>
                            </svg>
                            <span class="steppers-text">Requisiti soggettivi<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                        </a>
                    </li>
                    <li class="confirmed" id="tdAggregazione" runat="server">
                        <a class="steppers-link" type="button" title="Requisiti di impresa/aggregazione di impresa" href="../PDomanda/RequisitiImpresa.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-settings"></use>
                            </svg>
                            <span class="steppers-text">Aggregazione<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                        </a>
                    </li>
                    <li class="active">
                        <a class="steppers-link" type="button" title="Descrizione dell'iniziativa progettuale" href="../PDomanda/RelazioneTecnica.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-pencil"></use>
                            </svg>
                            <span class="steppers-text">Descrizione progetto<span class="visually-hidden">Attivo</span></span>
                        </a>
                    </li>
                    <li>

                        <a class="steppers-link" type="button" title="Business plan" href="../PDomanda/BusinessPlan.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                            </svg>
                            <span class="steppers-text">Business plan</span>
                        </a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Pagina di presentazione" href="../PDomanda/RiepilogoDomanda.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check-circle"></use>
                            </svg>
                            <span class="steppers-text">Presentazione</span>
                        </a>
                    </li>
                </ul>
                <span class="steppers-index" aria-hidden="true">2/6</span>
            </div>
            <nav class="steppers-nav">
                <button type="button" id="btnPrevUp" runat="server" class="btn btn-outline-primary btn-sm steppers-btn-prev"><svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro</button>
                <button type="button" onclick="location='BusinessPlan.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-next" onclick="location='Anagrafica.aspx'">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>                
            </nav>
            <div class="steppers-content" aria-live="polite">
                <!-- Esempio START -->
                <div class="row bd-form pt-5 mx-2">
                    <h2 class="pb-5">Descrizione dell'iniziativa progettuale</h2>
                    <div id="trNoRelazione" runat="server" class="col-sm-12">
                        <p>Il bando non richiede la compilazione della presente sezione.</p>
                    </div>
                    <div class="col-sm-12" id="trSiRelazione" runat="server" visible="false">
                        <div>
                            <div class="row" id="rowEdit" runat="server"></div>
                            <div class="cols-sm-12">
                                <Siar:Button ID="btnSave" runat="server" CausesValidation="True" Modifica="True"
                                    OnClick="btnSave_Click" Text="Salva" />
                            </div>
                        </div>
                    </div>
                    <!-- Esempio END -->
                </div>
                <nav class="steppers-nav">
                <button type="button" id="btnPrev" runat="server" class="btn btn-outline-primary btn-sm steppers-btn-prev"><svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro</button>
                <button type="button" onclick="location='BusinessPlan.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-next" onclick="location='Anagrafica.aspx'">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>                
            </nav>
            </div>
        </div>
        <%--    <table class="tableTab" width="800">
        <tr>
            <td align="center">
                <input id="btnPrev" class="ButtonProsegui" onclick="location = 'RequisitiDomanda.aspx'"
                    type="button" value="<<< (3/6)" runat="server" />
                <input id="btnCurrent" class="ButtonProsegui BPDisabled" style="width: 40px" disabled="disabled"
                    type="button" value="(4/6)" runat="server" />
                <input id="btnGo" class="ButtonProsegui" onclick="location = 'BusinessPlan.aspx'" type="button"
                    value="(5/6) >>>" runat="server" />
            </td>
        </tr>
    </table>--%>
    </div>
</asp:Content>
