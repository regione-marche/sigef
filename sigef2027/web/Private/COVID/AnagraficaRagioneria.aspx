<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="AnagraficaRagioneria.aspx.cs" Inherits="web.Private.COVID.AnagraficaRagioneria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript">
        function DownloadXls(idFile) {
            SNCUFVisualizzaFile(idFile);
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
        <h1>Estrazione Anagrafica Ragioneria
        </h1>
    </div>

    <div class="dBox" style="padding:15px;" >
        <div>
            <div class="first_elem_block">
                 &nbsp; <b>Bando COVID:</b><br />
                <Siar:Combo runat="server" ID="ComboBandi" Width="700px">
                </Siar:Combo>
            </div>
            <br /><br />
            <div class="first_elem_block">
                 &nbsp;<b>Tipo Beneficiario:</b><br />
                <asp:RadioButtonList RepeatDirection="Horizontal" ID="rblTipoBeneficiario" runat="server" Width="300px">
                    <asp:ListItem Selected="True" Text="Forma Giuridica" Value="0" />
                    <asp:ListItem Text="Impresa Individuale" Value="1" />
                </asp:RadioButtonList>
            </div>
            <br />
            <div class="first_elem_block">
                <Siar:Button ID="btnCrea" runat="server" Width="220px" Text="Crea File XLS"
                    CausesValidation="True" OnClick="btnCrea_Click" ></Siar:Button>
            </div>
        </div>
        <div>
            <br />
        </div>
        <div>
            <Siar:DataGrid ID="dgElenco" runat="server" AutoGenerateColumns="false" Width="100%" ShowFooter="false">
                <ItemStyle Height="30px" />
                <Columns>
                    <%--<asp:BoundColumn DataField="IdBando" HeaderText="ID Bando">
                        <ItemStyle HorizontalAlign="center" Width="40px" />
                    </asp:BoundColumn>--%>
                    <asp:BoundColumn DataField="Progressivo" HeaderText="Progressivo">
                        <ItemStyle HorizontalAlign="center" Width="40px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneBando" HeaderText="Bando">
                        <ItemStyle HorizontalAlign="Left"  />
                    </asp:BoundColumn>
                    <asp:BoundColumn  HeaderText="Tipo Impresa" >
                        <ItemStyle HorizontalAlign="Center"/>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataEstrazione" HeaderText="Data Estrazione">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdFile"  ButtonType="ImageButton" ButtonImage="/lente24.png" ButtonText="Download File XLS" JsFunction="DownloadXls" HeaderText="File">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>
</asp:Content>
