<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiarPage.master" CodeBehind="CruscottoCovid.aspx.cs" Inherits="web.Private.COVID.CruscottoCovid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function EstraiXLS(idBando) {
            var report = 'rptCovidEstrazioneBando' + idBando;
            var parametri = "IdUo=0";
            SNCVisualizzaReport(report, 2, parametri);
        }
    </script>

    <style type="text/css">
        .hide {
            display:none;
        }

        h1 {
            display: block;
            font-size: 2em;
            margin-top: 0.67em;
            margin-bottom: 0.67em;
            margin-left: 10px;
            margin-right: 0;
            font-weight: bold;
        }

        .first_elem_block {
            width: 200px;
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {
            width: 200px;
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
    </style>

    <div style="text-align: center;">
        <h1>Cruscotto Covid</h1>
    </div>

    <div class="dBox" style="padding:15px;" >
        <Siar:DataGrid ID="dgCruscotto" runat="server" AutoGenerateColumns="false" Width="100%">
            <ItemStyle Height="30px" />
            <Columns>
                <asp:BoundColumn DataField="IdBando" HeaderText="ID">
                    <ItemStyle HorizontalAlign="center" Width="40px" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Descrizione" HeaderText="Bando">
                    <ItemStyle HorizontalAlign="Left" Font-Bold="true" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Provvisorie" HeaderText="Provvisorie">
                    <ItemStyle HorizontalAlign="Right" Font-Bold="true" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="DefNonProtocollate" HeaderText="Def. Non Protocollate">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="DefProtocollate" HeaderText="Def. Protocollate">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="TotDefinitive" HeaderText="Tot. Definitive">
                    <ItemStyle HorizontalAlign="Right" Font-Bold="true" />
                </asp:BoundColumn>
                <Siar:JsButtonColumn Arguments="IdBando"  ButtonType="ImageButton" ButtonImage="/lente24.png" ButtonText="Estrai in XLS" JsFunction="EstraiXLS" HeaderText="File">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                </Siar:JsButtonColumn>
            </Columns>
        </Siar:DataGrid>
    </div>
</asp:Content>
