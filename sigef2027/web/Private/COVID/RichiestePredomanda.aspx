<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="RichiestePredomanda.aspx.cs" Inherits="web.Private.COVID.RichiestePredomanda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript">

        function SelezionaAutocert(id) {
            $('[id$=hdnIdAutocert]').val(id);
            $('[id$=btnSelect]').click();

        }
        function StampaDomanda(id) {

            var parametri = "IdAutodichiarazione=" + id;
            SNCVisualizzaReport('rptCovidAutodichiarazione', 1, parametri);
        }

    </script>
    <style type="text/css">
        h1 {
            display: block;
            font-size: 2em;
            margin-top: 0.67em;
            margin-bottom: 0.67em;
            margin-left: 10px;
            margin-right: 0;
            font-weight: bold;
        }
    </style>
    <div style="display: none">
        <asp:HiddenField ID="hdnIdAutocert" runat="server" />
        <asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" />
    </div>
    <div style="text-align: center">
        <h1>ELENCO DOMANDE COVID19</h1>
    </div>
    <div class="dBox" id="divTab" style="padding: 20px" runat="server">
        <div>
            <Siar:Button ID="btnNuova" runat="server" Width="220px" Text="Nuova Domanda"
                        CausesValidation="True" OnClick="btnNuova_Click" ></Siar:Button><br />
        </div>
        <div>
            <br />
            <h2 style="font-size: larger"><b>Elenco delle Domande inserite</h2>
            </b>
        </div>
        <div>
            <Siar:DataGrid ID="dgElenco" runat="server" Width="100%" AllowPaging="false"
                AutoGenerateColumns="False" ShowFooter="false">
                <ItemStyle Height="40px" />
                <Columns>
                    <asp:BoundColumn DataField="Id" HeaderText="Nr. Istanza">
                        <ItemStyle HorizontalAlign="center" Width="5%" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PartitaIva" HeaderText="Partita IVA">
                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="RagioneSociale" HeaderText="Ragione Sociale">
                        <ItemStyle HorizontalAlign="Left" Width="40%" />
                    </asp:BoundColumn>
                    <asp:BoundColumn  HeaderText="Bando">
                        <ItemStyle HorizontalAlign="Left" Width="30%" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="Id" ButtonType="TextButton" ButtonText="Modifica" JsFunction="SelezionaAutocert">
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </Siar:JsButtonColumn>
                    <asp:BoundColumn HeaderText="Definitiva">
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>
</asp:Content>
