<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" Inherits="web.Private.PDomanda.GestioneVisure" CodeBehind="GestioneVisure.aspx.cs" %>

<%@ Register Src="~/CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <style type="text/css">
        h1 {
            display: block;
            font-size: 22px; /*font-size: 2em;*/
            margin-top: 10px; /*margin-top: 0.67em;*/
            margin-bottom: 10px; /*margin-bottom: 0.67em;*/
            margin-left: 10px;
            margin-right: 0;
            font-weight: bold;
        }

        .first_elem_block {
            /*width: 250px;*/
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {
            /*width: 250px;*/
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

        label {
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

        .nascondi {
            display: none;
        }
    </style>

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
                    <li class="active">
                        <a class="steppers-link" type="button" title='Visure dell`impresa' href='../PDomanda/GestioneVisure.aspx'>
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-file"></use>
                            </svg>
                            <span class="steppers-text">Gestione visure<span class="visually-hidden">Attivo</span></span>
                        </a>
                    </li>                    
                    <li style="display: none;">
                        <a class="steppers-link" type="button" href='../PDomanda/FascicoloAziendale.aspx'>
                            <img title='Fascicolo aziendale' src='../../images/fascicolo.gif' />
                            Fascicolo aziendale</a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Requisiti soggettivi" href="../PDomanda/RequisitiDomanda.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-user"></use>
                            </svg>
                            <span class="steppers-text">Requisiti soggettivi</span>
                        </a>
                    </li>
                    <li id="tdAggregazione" runat="server">
                        <a class="steppers-link" type="button" title="Requisiti di impresa/aggregazione di impresa" href="../PDomanda/RequisitiImpresa.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-settings"></use>
                            </svg>
                            <span class="steppers-text">Aggregazione</span>
                        </a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Descrizione dell'iniziativa progettuale" href="../PDomanda/RelazioneTecnica.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-pencil"></use>
                            </svg>
                            <span class="steppers-text">Descrizione progetto</span>
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
                <button id="btnPrevUp" runat="server" type="button" onclick="location = 'Anagrafica.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-prev"><svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro</button>
                <button id="btnGoUp" runat="server" type="button" onclick="location = 'RequisitiDomanda.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-next">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>                
            </nav>
            <div class="steppers-content" aria-live="polite">
                <!-- Esempio START -->
                <div class="row bd-form pt-5 mx-2">
                    <h2 class="pb-5">Gestione visure dell'impresa</h2>
                    <div class="row" id="divInserimentoVisura" runat="server">
                        <h3 class="pb-5">Inserimento nuova visura</h3>
                        <p>E' possibile inserire qui una nuova visura o un altro documento atto a verificare la veridicità dell'anagrafica dell'impresa.</p>

                        <div class="col-sm-12 form-group" style="visibility: hidden;">
                            <Siar:DateTextBox Label="Data visura:" ID="txtDataVisura" runat="server" Width="100px" />
                        </div>
                        <br />

                        <div class="col-sm-12">
                            <uc4:SNCUploadFileControl ID="ufNuovaVisura" runat="server" TipoFile="Documento" Modifica="True" />
                        </div>
                        <div class="col-sm-12">
                            <Siar:Button ID="btnInserisciVisura" runat="server" CausesValidation="False" OnClick="btnInserisciVisura_Click" Text="Inserisci la nuova visura" />
                        </div>
                    </div>

                    <%-- <div id="divVisuraAttuale" runat="server" style="padding: 15px;">
             <div class="paragrafo">
                Visura attuale
            </div>
            <br />

            <div class="first_elem_block">
                <uc4:SNCUploadFileControl ID="ufVisuraAttuale" runat="server" TipoFile="Documento" />
            </div>            
            <br />
        </div>--%>

                    <div class="row" id="divElencoVisure" runat="server">
                        <h3 class="pb-5">Elenco visure</h3>
                        <p>
                            Elenco delle visure o degli atti dell'impresa ordinate per data visura in maniera decrescente. La prima visura dell'elenco dall'alto sarà la più recente e verrà confrontata con i dati dell'anagrafica in fase istruttoria.
                        </p>
                        <div class="col-sm-12">
                            <Siar:DataGridAgid ID="dgElencoVisure" CssClass="table table-striped" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundColumn HeaderText="Data caricamento" DataField="DataVisura">
                                        <ItemStyle Width="100px" HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="File" DataField="IdFileVisura">
                                        <ItemStyle Width="100px" HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Nome file" DataField="NomeFile"></asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                    </div>
                </div>
            </div>
            <nav class="steppers-nav">
                <button runat="server" id="btnPrev" type="button" onclick="location = 'Anagrafica.aspx'" class="btn btn-outline-primary btn-sm steppers-btn-prev">
                    <svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro</button>
                <button id="btnGo" runat="server" type="button" class="btn btn-outline-primary btn-sm steppers-btn-next" onclick="location='RequisitiDomanda.aspx'">Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg></button>                
            </nav>
        </div>
    </div>
</asp:Content>
