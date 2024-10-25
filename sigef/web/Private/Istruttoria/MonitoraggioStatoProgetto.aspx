<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.MonitoraggioStatoProgetto" CodeBehind="MonitoraggioStatoProgetto.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function dettaglioRiesame(accolta,motivazioni) { window.setTimeout("sAjaxMostraTesto(\"<table class=tableNoTab style='width:100%'><tr><td class=separatore_big>DETTAGLIO DELLA RICHIESTA DI RIESAME</td></tr><tr><td class=testo_pagina><b>Accolta:</b> "+accolta+"<br/><b>Motivazioni:</b> "+motivazioni+"</td></tr></table>\",500);",1); }
//--></script>

    <br />
    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <br />
    <table class="tableNoTab" width="950px">
        <tr>
            <td class="separatore_big">
                ITER PROCEDURALE DELLA DOMANDA DI AIUTO
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                <br />
                Elenco dei passaggi di stato e relativa segnatura del documento
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dg" runat="server" AutoGenerateColumns="False" Width="100%">
                    <ItemStyle Height="28px" />
                    <Columns>
                        <asp:BoundColumn DataField="Data" HeaderText="Data">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Stato" HeaderText="Stato procedurale">
                            <ItemStyle Font-Bold="true" HorizontalAlign="Center" Width="140px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Procedura di attribuzione dello stato">
                            <ItemStyle HorizontalAlign="Center" Width="140px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Ente" HeaderText="Ente">
                            <ItemStyle HorizontalAlign="Center" Width="160px" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="Segnatura" ButtonText="Visualizza documento" ButtonType="TextButton"
                            JsFunction="sncAjaxCallVisualizzaProtocollo">
                            <ItemStyle HorizontalAlign="Center" Width="160px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                <br />
                Elenco delle comunicazioni effettuate ed altri documenti registrati
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgSegnature" runat="server" AutoGenerateColumns="False" Width="100%">
                    <ItemStyle Height="28px" />
                    <Columns>
                        <asp:BoundColumn DataField="Data" HeaderText="Data documento">
                            <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Tipo documento" DataField="TipoSegnatura">
                            <ItemStyle Width="240px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Ente" HeaderText="Ente">
                            <ItemStyle HorizontalAlign="Center" Width="160px" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="Segnatura" ButtonText="Visualizza documento" ButtonType="TextButton"
                            JsFunction="sncAjaxCallVisualizzaProtocollo">
                            <ItemStyle HorizontalAlign="Center" Width="160px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                <br />
                Elenco delle domande di pagamento effettuate e relative comunicazioni
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgDomandePagamento" runat="server" AutoGenerateColumns="False"
                    Width="100%">
                    <ItemStyle Height="28px" />
                    <Columns>
                        <asp:BoundColumn DataField="Data" HeaderText="Data documento">
                            <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Tipo documento" DataField="TipoSegnatura">
                            <ItemStyle Width="240px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Ente" HeaderText="Ente">
                            <ItemStyle HorizontalAlign="Center" Width="160px" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="Segnatura" ButtonText="Visualizza documento" ButtonType="TextButton"
                            JsFunction="sncAjaxCallVisualizzaProtocollo">
                            <ItemStyle HorizontalAlign="Center" Width="160px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                <br />
                Elenco delle varianti/variazioni finanziarie/a.t. effettuate e relative comunicazioni
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgVarianti" runat="server" AutoGenerateColumns="False" Width="100%">
                    <ItemStyle Height="28px" />
                    <Columns>
                        <asp:BoundColumn DataField="Data" HeaderText="Data documento">
                            <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Tipo documento" DataField="TipoSegnatura">
                            <ItemStyle Width="240px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Ente" HeaderText="Ente">
                            <ItemStyle HorizontalAlign="Center" Width="160px" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="Segnatura" ButtonText="Visualizza documento" ButtonType="TextButton"
                            JsFunction="sncAjaxCallVisualizzaProtocollo">
                            <ItemStyle HorizontalAlign="Center" Width="160px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 70px">
                <input type="button" class="Button" value="Indietro" style="width: 193px" onclick="history.back()" />
            </td>
        </tr>
    </table>
</asp:Content>
