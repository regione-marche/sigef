<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.BusinessPlan" CodeBehind="BusinessPlan.aspx.cs" %>

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
                    <li class="confirmed">
                        <a class="steppers-link" type="button" title="Descrizione dell'iniziativa progettuale" href="../PDomanda/RelazioneTecnica.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-pencil"></use>
                            </svg>
                            <span class="steppers-text">Descrizione progetto<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span>
                        </a>
                    </li>
                    <li class="active">

                        <a class="steppers-link" type="button" title="Business plan" href="../PDomanda/BusinessPlan.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                            </svg>
                            <span class="steppers-text">Business plan<span class="visually-hidden">Attivo</span></span>
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
                <button type="button" onclick="location='RelazioneTecnica.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-prev"><svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro</button>
                <button type="button" onclick="location='RiepilogoDomanda.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-next" onclick="location='Anagrafica.aspx'">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>
            </nav>
            <div class="steppers-content" aria-live="polite">
                <!-- Esempio START -->
                <div class="row pt-5 mx-2">
                    <h2 class="pb-5">Business plan di domanda</h2>
                    <p>
                        Di seguito sono elencate le sezioni da compilare richieste dal bando di gara. Ognuna di tali voci apre le pagine web in cui è possibile inserire e/o aggiornare i dati richiesti.
                    </p>
<%--                    <Siar:DataGridAgid CssClass="table table-striped" ID="dg" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <Siar:ColonnaLink DataField="Quadro" HeaderText="Quadro" IsJavascript="false" LinkFields="Url" LinkFormat="{0}">
                                <ItemStyle HorizontalAlign="Center" />
                            </Siar:ColonnaLink>
                        </Columns>
                    </Siar:DataGridAgid>--%>

                    <div class="col-12">
                        <div class="row bd-form">
                            <asp:Repeater ID="rptBusinessPlan" runat="server">
                                <ItemTemplate>
                                    <div class="col-lg-4">
                                        <!--start card-->
                                        <div class="card-wrapper">
                                            <div class="card">
                                                <div class="card-body">
                                                    <div class="categoryicon-top">
                                                        <svg class="icon">
                                                        <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right-circle"></use>
                                                    </svg>
                                                        <span class="text"><%# Eval("Quadro") %></span>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-6">
                                                            <p>
                                                                <a href="<%# Eval("Url") %>" class="btn btn-outline-primary btn-sm steppers-btn-next">Vai alla sezione<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></a>
                                                            </p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <!-- Esempio END -->
            </div>
            <nav class="steppers-nav">
                <button type="button" onclick="location='RelazioneTecnica.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-prev"><svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro</button>
                <button type="button" onclick="location='RiepilogoDomanda.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-next" onclick="location='Anagrafica.aspx'">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>                
            </nav>
        </div>
    </div>
    <%--    <table class="tableTab" width="800">
        <tr>
            <td align="center">
                <input id="btnPrev" class="ButtonProsegui" onclick="location='RelazioneTecnica.aspx'"
                    type="button" value="<<< (5/7)" runat="server" />
                <input id="btnCurrent" class="ButtonProsegui BPDisabled" style="width: 40px" disabled="disabled"
                    type="button" value="(6/7)" runat="server"/>
                <input id="btnGo" class="ButtonProsegui" onclick="location='RiepilogoDomanda.aspx'"
                    type="button" value="(7/7) >>>" runat="server"/>
            </td>
        </tr>
    </table>--%>
</asp:Content>
