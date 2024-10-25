<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="VisualizzaContratti.aspx.cs" Inherits="web.Private.Fem.VisualizzaContratti" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <style type="text/css">

        .first_elem_block {
            /*width: 200px;*/
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {
            /*width: 200px;*/
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

        .label {
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

        function selezionaBando(id, elem) {
            if (elem.checked == false) {
                $('[id$=hdnIdBando]').val('');
            }
            else {
                $('[id$=hdnIdBando]').val(id);
            }

            $('[id$=btnPost]').click();
        }

        function estraiContratti() {
            var idBando = $('[id$=hdnIdBando]').val();

            var param1 = [];
            param1.push("IdBando=" + idBando);
            SNCVisualizzaReport('rptContrattiFem', 2, param1.join('|'));
        }

    </script>

    <div style="display: none">

        <asp:HiddenField ID="hdnIdBando" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />

    </div>

    <div style="text-align: center;">
        <h1>Visualizza contratti</h1>
    </div>

    <div class="dBox">
        <div class="separatore">
            Visualizza contratti associati ad un bando
        </div>
        <br />

        <div style="padding:10px;">
            <p>Seleziona il bando di riferimento per vederne i contratti e i pagamenti associati</p><br />

            <Siar:DataGrid ID="dgBandi" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                AutoGenerateColumns="False" ShowFooter="false">
                <ItemStyle Height="28px" />
                <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                <Columns>
                    <asp:BoundColumn DataField="IdBando" HeaderText="ID">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Oggetto">
                        <ItemStyle HorizontalAlign="left" Width="500px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Importo" HeaderText="Importo" HeaderStyle-HorizontalAlign="Right">
                        <ItemStyle HorizontalAlign="Right" Width="80px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Nominativo" HeaderText="RUP">
                        <ItemStyle HorizontalAlign="left" Width="100px" />
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="IdBando" Name="chkIdBando">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </Siar:CheckColumn>
                </Columns>
            </Siar:DataGrid>
            <br />
            <br />

            <div id="divElencoContratti" runat="server">
                <div class="paragrafo_light">
                    Elenco dei contratti e dei pagamenti associati al bando selezionato
                </div>
                <br />

                <%--<input id="btnEstraiContratti" class="Button" style="width: 130px" type="button" value="Estrai in Excel" onclick="estraiContratti();" />--%>
                <%--<Siar:Button ID="btnEstraiContratti" runat="server" Text="Estrai in Excel" OnClick="btnEstraiContratti_Click" Width="150px" Modifica="true" />--%>
                <input id="btnEstraiContratti" class="Button" runat="server" style="width: 130px" type="button" value="Estrai in Excel" />
                <br />
                <br />

                <Siar:DataGrid ID="dgContrattiPagamenti" runat="server" Width="100%" AllowPaging="true" PageSize="100" AutoGenerateColumns="False">
                    <ItemStyle Height="28px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <asp:BoundColumn DataField="IdContrattoFem" HeaderText="ID">
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Tipo">
                            <ItemStyle HorizontalAlign="left" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Numero Contratto/Giustificativo">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Data Contratto/Giustificativo">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo" HeaderStyle-HorizontalAlign="Right">
                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="File">
                            <ItemStyle HorizontalAlign="center" Width="40px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdContrattoFemPagamenti" HeaderText="ID">
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoPagamento" HeaderText="Tipo">
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Data" HeaderText="Data">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Estremi" DataField="Estremi">
                            <ItemStyle HorizontalAlign="Right" Width="300px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="File">
                            <ItemStyle HorizontalAlign="center" Width="40px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Importo" HeaderStyle-HorizontalAlign="Right" HeaderText="Importo">
                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoAmmesso" HeaderStyle-HorizontalAlign="Right" HeaderText="Importo ammesso">
                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdErogazioneFem" HeaderText="Erogazione">
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </div>
        </div>
    </div>

</asp:Content>
