<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="DownloadDocumenti.aspx.cs" Inherits="web.Public.DownloadDocumenti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
        function visualizzaFile(id) { $('[id$=hdnIdFile]').val(id);$('[id$=btnVisualizzaFile]').click(); }
//--></script>

    <table class="tableNoTab" width="800px">
        <tr>
            <td class="separatore_big">
                ELENCO DOCUMENTI E MODULISTICA DISPONIBILI AL DOWNLOAD:
            </td>
        </tr>
        <tr>
            <td>
                <p class="testo_pagina">
                    Di seguito vengono elencati i <b>documenti</b> e la <b>modulistica</b> pubblicati
                    ai fini di una completa ed esaustiva informazione
                    <br />
                    degli utenti del portale. Si consiglia la loro consultazione, relativamente agli
                    argomenti di interesse, <b>prima</b> di avviare
                    <br />
                    una qualsiasi richiesta o domanda tramite le <b>procedure informatiche</b> esposte
                    dal SIGEF.</p>
            </td>
        </tr>
        <tr>
            <td class="separatore_light">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 48px">
                <Siar:TextBox  ID="txtCercaDescrizione" runat="server" Width="250px" />
                <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Filtra"
                    Width="100px" AdditionalStyles="margin-left:20px" />
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 10px; padding-top: 10px">
                <Siar:DataGrid ID="dgDocumenti" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
                    <ItemStyle Height="50px" />
                    <Columns>
                        <asp:BoundColumn DataField="DataModifica" HeaderText="Data pubblicazione">
                            <ItemStyle HorizontalAlign="center" Width="100px" Font-Bold="true" Font-Size="12px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Descrizione documento"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
    <div style="display: none">
        <asp:HiddenField ID="hdnIdFile" runat="server" />
        <asp:Button ID="btnVisualizzaFile" runat="server" OnClick="btnVisualizzaFile_Click" />
    </div>
</asp:Content>
