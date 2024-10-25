<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" Inherits="web.Private.Impresa.ImpresaVisure" CodeBehind="ImpresaVisure.aspx.cs" %>

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
        <div class="steppers">
            <div class="steppers-header">
                <ul>
                    <li class="confirmed">
                        <a class="steppers-link" title="Riepilogo attività dell'impresa" type="button" href="ImpresaRiepilogo.aspx">
                            <svg class="icon icon-lg">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-map-marker"></use>
                            </svg>
                        <span class="steppers-text">Riepilogo impresa<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span></a>
                    </li>
                    <li class="confirmed">
                        <a class="steppers-link" type="button" title='Assistenza agli utenti' href='AssistenzaUtenti.aspx'>
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-help-circle"></use>
                            </svg>
                        <span class="steppers-text">Assistenza utenti<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span></a>
                    </li>
                    <li class="confirmed">
                        <a class="steppers-link" type="button" title='Domande' href='ImpresaDomande.aspx'>
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-files"></use>
                            </svg>
                        <span class="steppers-text">Domande<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span></a>
                    </li>
                    <li class="confirmed">
                        <a class="steppers-link" type="button" title="Anagrafe dell'impresa" href="ImpresaAnagrafe.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-card"></use>
                            </svg>
                        <span class="steppers-text">Dati anagrafici<svg class="icon steppers-success"><use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use></svg><span class="visually-hidden">Confermato</span></span></a>
                    </li>
                    <li class="active">
                        <a class="steppers-link" type="button" title="Visure" href="ImpresaVisure.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-file"></use>
                            </svg>
                        <span class="steppers-text">Gestione visure<span class="visually-hidden">Attivo</span></span></a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Gestione delle aggregazioni dell'impresa" href="AggregazioneImprese.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-settings"></use>
                            </svg>
                        <span class="steppers-text">Gestione soci</span></a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Gestione e richieste dei consulenti dell'impresa" href="ImpresaConsulente.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-user"></use>
                            </svg>
                        <span class="steppers-text">Gestione consulenti</span></a>
                    </li>
                    <li style="display: none;">
                        <a class="steppers-link" type="button" title="resentazione e dettagli finanziari dell'impresa" href="ImpresaBusinessPlan.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                            </svg>
                        <span class="steppers-text">Gestione finanziaria</span></a>
                    </li>
                    <li>
                        <a class="steppers-link" type="button" title="Ricerca altre imprese" href="ImpresaFind.aspx">
                            <svg class="icon icon-lg ">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-search"></use>
                            </svg>
                        <span class="steppers-text">Ricerca altre imprese</span></a>
                    </li>
                </ul>
                <span class="steppers-index" aria-hidden="true">2/6</span>
            </div>
            <div class="steppers-content" aria-live="polite">
                <div class="row py-5 mx-2">
                    <h2 class="pb-5">Gestione visure dell'impresa</h2>
                    <div id="divInserimentoVisura" runat="server">
                        <h3 class="pb-5">Inserimento nuova visura</h3>
                        <p>E' possibile inserire qui una nuova visura o un altro documento atto a verificare la veridicità dell'anagrafica dell'impresa.</p>
                        <div class="col-sm-12" style="visibility: hidden;">
                            <Siar:DateTextBox Label="Data visura:" ID="txtDataVisura" runat="server" Width="100px" />
                        </div>
                        <div class="col-sm-12">
                            <uc4:SNCUploadFileControl ID="ufNuovaVisura" runat="server" TipoFile="Documento" Modifica="True" />
                        </div>
                        <div class="col-sm-12">
                            <Siar:Button ID="btnInserisciVisura" runat="server" CausesValidation="False"
                                OnClick="btnInserisciVisura_Click" Text="Inserisci la nuova visura" />
                        </div>
                    </div>
                    <h3 class="pb-5 pt-5">Elenco visure</h3>
                    <p>
                        Elenco delle visure o degli atti dell'impresa ordinate per data visura in maniera decrescente.<br />
                        La prima visura dell'elenco dall'alto sarà la più recente e verrà confrontata con i dati dell'anagrafica in fase istruttoria.
                    </p>
                    <div class="col-sm-12">
                        <Siar:DataGridAgid ID="dgElencoVisure" CssClass="table table-striped" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn HeaderText="Data caricamento" DataField="DataVisura">
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="File" DataField="IdFileVisura">
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Nome file" DataField="NomeFile"></asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>
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
            </div>
        </div>
    </div>
</asp:Content>
