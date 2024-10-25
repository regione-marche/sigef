<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="NewsComunicazioni.aspx.cs" Inherits="web.Public.NewsComunicazioni" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <table class="tableNoTab" width="900px">
        <tr>
            <td class="separatore_big">
                NEWS &amp; COMUNICAZIONI
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td style="height: 80px; width: 640px">
                            <p class="testo_pagina" style="width: 580px">
                                Elenco delle <b>news e comunicazioni</b> agli utenti del portale da parte della
                                Regione Marche.
                                <br />
                                Si consiglia di consultare frequentemente questa sezione per rimanere aggiornati
                                sulle novità che vengono <b>pubblicate periodicamente</b> a scopo informativo. E&#39;
                                possibile inoltre eseguire una ricerca di testo libero per ritrovare una i piu&#39;
                                specifiche pubblicazioni.</p>
                            <p class="testo_pagina" style="width: 580px">
                                <b>FIRMA DIGITALE WEB</b>
                                <br />
                                <b>Avvisiamo tutti gli utenti</b>, che dalla data del 06/06/2019 è stata modificata la modalità di firma digitale, compatibile con quasi <b> tutti i browser</b> (Google Chrome, Edge, Firefox ). 
                                <br />Si consiglia pertanto di<b> non usare </b> il browser<b> Internet explorer v10 e v11.</b>
                        </td>
                        <td style="height: 80px">
                            <br />
                            <br />
                            <b>Ricerca testo:</b><br />
                            <Siar:TextBox ID="txtTestoLibero" runat="server" Width="130px" />
                            &nbsp;
                            <Siar:Button ID="btnCerca" Text="Filtra" runat="server" OnClick="btnCerca_Click"
                                Width="90px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 10px;">
                <Siar:DataGrid ID="dg" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    EnableViewState="False" PageSize="10" Width="100%">
                    <Columns>
                        <asp:BoundColumn></asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
