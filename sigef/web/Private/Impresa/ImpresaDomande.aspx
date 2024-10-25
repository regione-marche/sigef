<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Impresa.ImpresaDomande" CodeBehind="ImpresaDomande.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function gestioneLavori(id) { $('[id$=hdnIdProgetto]').val(id);$('[id$=btnGestioneLavori]').click(); }
//--></script>

    <br />
    <table width="1100px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                ELENCO DEI BANDI PUBBLICATI E DOMANDE DI AIUTO DEL BENEFICIARIO
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 199px">
                            <b>Ente emettitore del bando:<br />
                                <Siar:ComboEntiBando ID="lstEntiBando" runat="server" Width="180px">
                                </Siar:ComboEntiBando>
                            </b>
                        </td>
                        <td>
                            <b>Programmazione:<br />
                            </b>
                            <Siar:ComboGroupZProgrammazione ID="lstZProgrammazione" runat="server" Width="500px">
                            </Siar:ComboGroupZProgrammazione>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 199px">
                            &nbsp;Data di scadenza (&lt;=):<br />
                            <Siar:DateTextBox ID="txtScadenza" runat="server" Width="130px" />
                        </td>
                        <td>
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 381px">
                                        <br />
                                        <asp:CheckBox ID="chkAdesioni" runat="server" TextAlign="Left" Text="Solo bandi con adesione:" />
                                    </td>
                                    <td style="width: 179px">
                                        <br />
                                        <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" Width="160px" />
                                    </td>
                                    <td>
                                        <br />
                                        <Siar:Button ID="btnNoFilter" runat="server" OnClick="btnNoFilter_Click" Text="Annulla Ricerca"
                                            Width="180px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                &nbsp;Elementi trovati:
                <Siar:Label ID="lblRisultato" runat="server">
                </Siar:Label>
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Sotto elencati tutti i <strong>bandi pubblicati</strong> dalla Regione Marche (per
                filtrare i risultati utilizzare i campi di ricerca qui sopra, per azzerare i filtri
                cliccare su "Annulla Ricerca").
                <br />
                La griglia indica anche se l'impresa ha presentato&nbsp;<strong>domanda di aiuto</strong>
                per il relativo bando &nbsp;e lo stato procedurale della stessa.
                <br />
                Per iniziare la compilazione di una nuova domanda di aiuto utilizzare il pulsante
                <strong>Presenta domanda </strong>in corrispondenza del bando desiderato.<br />
                Per entrare nella <strong>sezione domanda</strong> ed avere accesso alle pagine
                utilizzare il pulsante nella colonna <strong>Visualizza</strong>.<br />
                Per accedere alla sezione <strong>rendicontazione </strong>della domanda di aiuto
                e quindi entrare nelle pagine di inserimento e gestione delle &nbsp;<strong>domande
                    di pagamento</strong> e<br />
                <strong>varianti/variazioni finanziarie/adeguamenti tecnici</strong> utilizzare il pulsante nella colonna
                <strong>Gestione lavori.</strong>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgBandi" runat="server" AutoGenerateColumns="False" Width="100%"
                    AllowPaging="True" EnableViewState="False">
                    <ItemStyle Height="34px" />
                    <Columns>
                        <Siar:CheckColumn DataField="IdBando" Name="chk">
                            <ItemStyle Width="40px" />
                        </Siar:CheckColumn>
                        <Siar:JsButtonColumn Arguments="IdBando" ButtonImage="Info.ico" ButtonText="Info sul bando"
                            ButtonType="ImageButton">
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </Siar:JsButtonColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione del bando"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DataScadenza" HeaderText="Scadenza">
                            <ItemStyle Width="80px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Numero">
                            <ItemStyle Width="70px" HorizontalAlign="center" Font-Bold="true" Font-Size="14px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Stato">
                            <ItemStyle Width="100px" HorizontalAlign="Center" Font-Bold="true" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Visualizza">
                            <ItemStyle HorizontalAlign="Center" Width="170px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Gestione lavori">
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
    </table>
    <div id="divDocumentiBando" style="width: 700px; position: absolute; display: none">
        <table class="tableNoTab" width="100%">
            <tr>
                <td class="separatore">
                    Elenco documenti relativi al bando selezionato:
                </td>
            </tr>
            <tr>
                <td id="tdGridDocumentiBando" style="padding: 5px">
                </td>
            </tr>
            <tr>
                <td style="height: 40px; padding-right: 40px;" align="right">
                    <input style="width: 155px" type="button" value="Chiudi" class="Button" onclick="chiudiPopupTemplate()" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
