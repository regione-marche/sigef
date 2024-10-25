<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.MonitoraggioStatoProgetto" CodeBehind="MonitoraggioStatoProgetto.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function dettaglioRiesame(accolta, motivazioni) { window.setTimeout("sAjaxMostraTesto(\"<table class=tableNoTab style='width:100%'><tr><td class=separatore_big>DETTAGLIO DELLA RICHIESTA DI RIESAME</td></tr><tr><td class=testo_pagina><b>Accolta:</b> " + accolta + "<br/><b>Motivazioni:</b> " + motivazioni + "</td></tr></table>\",500);", 1); }
//--></script>

    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <div class="row py-5 mx-2">
        <div class="col-sm-12 text-end">
            <a onclick="history.back()" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-left"></use>
                </svg>
                Torna indietro</a>
        </div>
        <h2 class="pb-5">Iter procedurale della domanda di contributo
        </h2>
        <h3 class="pb-5">Elenco dei passaggi di stato e relativa segnatura del documento
        </h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dg" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundColumn DataField="Data" HeaderText="Data">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Stato" HeaderText="Stato procedurale">
                        <ItemStyle Font-Bold="true" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Procedura di attribuzione dello stato">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Ente" HeaderText="Ente">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumnAgid Arguments="Segnatura" ButtonText="Visualizza documento" ButtonImage="it-search" ButtonType="ImageButton"
                        JsFunction="sncAjaxCallVisualizzaProtocollo">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <h3 class="pb-5">Elenco delle comunicazioni effettuate ed altri documenti registrati</h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgSegnature" runat="server" AutoGenerateColumns="False">
                <ItemStyle Height="28px" />
                <Columns>
                    <asp:BoundColumn DataField="Data" HeaderText="Data documento">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Tipo documento" DataField="TipoSegnatura"></asp:BoundColumn>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Ente" HeaderText="Ente">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumnAgid Arguments="Segnatura" ButtonText="Visualizza documento" ButtonImage="it-search" ButtonType="ImageButton"
                        JsFunction="sncAjaxCallVisualizzaProtocollo">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <h3 class="pb-5">Elenco delle domande di pagamento effettuate e relative comunicazioni</h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgDomandePagamento" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundColumn DataField="Data" HeaderText="Data documento">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Tipo documento" DataField="TipoSegnatura"></asp:BoundColumn>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Ente" HeaderText="Ente">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumnAgid Arguments="Segnatura" ButtonText="Visualizza documento" ButtonImage="it-search" ButtonType="ImageButton"
                        JsFunction="sncAjaxCallVisualizzaProtocollo">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <h3 class="pb-5">Elenco delle varianti/variazioni finanziarie/a.t. effettuate e relative comunicazioni</h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgVarianti" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundColumn DataField="Data" HeaderText="Data documento">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Tipo documento" DataField="TipoSegnatura"></asp:BoundColumn>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Ente" HeaderText="Ente">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumnAgid Arguments="Segnatura" ButtonText="Visualizza documento" ButtonImage="it-search" ButtonType="ImageButton"
                        JsFunction="sncAjaxCallVisualizzaProtocollo">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="col-sm-12 text-end">
            <a onclick="history.back()" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-left"></use>
                </svg>
                Torna indietro</a>
        </div>
    </div>
</asp:Content>
