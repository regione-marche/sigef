<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="RichiesteCovid.aspx.cs" Inherits="web.Private.COVID.RichiesteCovid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
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
    <script type="text/javascript">
        function ApriRicevuta(Prog) {
            var parametri = "ID_Domanda=" + Prog
            SNCVisualizzaReport('rptCovidFrontespizio', 1, parametri);
        }

        function ApriReportDomnanda(Id) {
            //var parametri = "IdProgetto=" + Prog
            //SNCVisualizzaReport('rptCovidDomanda', 1, parametri);
            SNCUFVisualizzaFile(Id);
        }
        
    </script>
    <div style="text-align: center">
        <h1>Richieste di Contributo Inviate</h1>
    </div>
    <div class="dBox"  style="padding: 20px">
        <div>
            <h2 style="font-size: larger"><b>Elenco delle Richieste di Contributo Inviate</h2>
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
                    <asp:BoundColumn  HeaderText="Partita IVA">
                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Ragione Sociale">
                        <ItemStyle HorizontalAlign="Left" Width="35%" />
                    </asp:BoundColumn>
                    <asp:BoundColumn  HeaderText="Bando">
                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Data Trasmissione">
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Domanda">
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Ricevuta">
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>

    </div>

</asp:Content>
