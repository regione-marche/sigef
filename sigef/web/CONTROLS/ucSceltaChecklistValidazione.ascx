<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSceltaChecklistValidazione.ascx.cs" Inherits="web.CONTROLS.ucSceltaChecklistValidazione" %>

<div id="divSceltaChecklistValidazione" runat="server" style="width: 90%; height: 96%; position: absolute; display: none; box-shadow: none; overflow: hidden;">

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/jquery-ui.min.js"></script>

    <style type="text/css">

        .first_elem_block {
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {
            vertical-align: top;
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-left: 20px;
            padding-bottom: 5px;
        }

        .label {
            display: inline;
            float: left;
            min-width: 200px;
            max-width: 200px;
            width: 200px;
            text-align: right;
            vertical-align: middle;
            white-space: normal;
        }

        .value {
            display: inline-block;
            float: right;
            margin-left: 5px;
            white-space: normal;
        }

        .nascondi {
            display: none;
        }

    </style>

    <script type="text/javascript">

        function OrdinaDatagridSchede() {
            $("[id$=dgBeneficiario]").sortable({
                items: 'tr:not(tr:first-child)',
                cursor: 'pointer',
                axis: 'y',
                dropOnEmpty: false,
                start: function (e, ui) {
                    ui.item.addClass("selected");
                },
                stop: function (e, ui) {
                    ui.item.removeClass("selected");
                },
                receive: function (e, ui) {
                    $(this).find("tbody").append(ui.item);
                }
            });

            $("[id$=dgValidatore]").sortable({
                items: 'tr:not(tr:first-child)',
                cursor: 'pointer',
                axis: 'y',
                dropOnEmpty: false,
                start: function (e, ui) {
                    ui.item.addClass("selected");
                },
                stop: function (e, ui) {
                    ui.item.removeClass("selected");
                },
                receive: function (e, ui) {
                    $(this).find("tbody").append(ui.item);
                }
            });
        }

        function readyFn(jQuery) {
            OrdinaDatagridSchede();
        }

        function pageLoad() {
            readyFn();
        }

        function HHHH(id) { }

    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdTestata" Value="" runat="server" />
        <asp:HiddenField ID="hdnCreaAutovalutazione" Value="false" runat="server" />
    </div>

    <div class="dBox" id="divScelta" runat="server" style="width: 100%; height: 100%; overflow-y: auto;">
        <div id="pTitolo" runat="server" class="separatore">
            <%--<p id="pTitolo" runat="server">Scelta checklist di validazione</p>--%>
            Scelta checklist di validazione
        </div>

        <div id="content" runat="server" style="padding: 10px;">

                <div class="paragrafo" style="width: 98%;">
                    Quadro sinottico 
                </div>
                <br />

                <table style="width: 98%; white-space: normal;">
                    <thead>
                        <tr class="TESTA1">
                            <th rowspan="2"></th>
                            <th colspan="3">Servizi e forniture</th>
                            <th colspan="4">Lavori</th>
                        </tr>
                        <tr class="TESTA1">

                            <th>< 40.000</th>
                            <th>> 40.000 < soglia comunitaria</th>
                            <th>Sopra soglia</th>

                            <th>< 40.000</th>
                            <th>> 40.000 < 1.000.000</th>
                            <th>> 1.000.000 < soglia comunitaria</th>
                            <th>Sopra soglia</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="DataGridRow" style="color: white;">
                            <td>Affidamento diretto (Art. 36 Comma 2 lett.a)</td>

                            <td style="text-align: center; width: 120px;">Scheda Procedura 7</td>
                            <td></td>
                            <td></td>

                            <td style="text-align: center; width: 120px;">Scheda Procedura 8</td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr class="DataGridRow" style="color: white;">
                            <td>Procedura negoziata (Art. 36 Comma 2 lett.b)</td>

                            <td></td>
                            <td  style="text-align: center;">Scheda Procedura 5</td>
                            <td></td>

                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr class="DataGridRow" style="color: white;">
                            <td>Procedura negoziata (Art. 36 Comma 2 lett.b), c) e c-bis</td>

                            <td></td>
                            <td></td>
                            <td></td>

                            <td></td>
                            <td style="text-align: center; width: 120px;">Scheda Procedura 6</td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr class="DataGridRow" style="color: white;">
                            <td>Procedura negoziata senza previa pubblicazione di un bando di gara (Art. 63)</td>

                            <td  style="text-align: center;" colspan="3">Scheda Procedura 10</td>

                            <td  style="text-align: center;" colspan="4">Scheda Procedura 9</td>
                        </tr>
                        <tr class="DataGridRow" style="color: white;">
                            <td>Procedura aperta</td>

                            <td></td>
                            <td style="text-align: center;">Scheda Procedura 4</td>
                            <td style="text-align: center; width: 120px;">Scheda Procedura 3</td>

                            <td style="text-align: center;" colspan="3">Scheda Procedura 1</td>
                            <td style="text-align: center; width: 120px;">Scheda Procedura 2</td>
                        </tr>
                        <tr class="DataGridRow" style="color: white;">
                            <td>EX d. Lgs 163/2006 </td>

                            <td  style="text-align: center; width: 120px;" colspan="7">Scheda Procedura 12</td>

                          <%--  <td colspan="3">Scheda Procedura 12</td>--%>
                        </tr>
                        <tr class="DataGridRow" style="color: white;">
                            <td>IN HOUSE</td>

                            <td  style="text-align: center; width: 120px;" colspan="7">Scheda Procedura 11</td>

                          <%--  <td colspan="3">Scheda Procedura 12</td>--%>
                        </tr>
                    </tbody>
                </table>
                <br />

                <div class="paragrafo" style="width: 98%;">
                    Scelta schede 
                </div>
                <br />

            <div id="divBeneficiario" runat="server">
                <Siar:DataGrid ID="dgBeneficiario" runat="server" AutoGenerateColumns="False" Width="98%">
                    <Columns>
                        <asp:BoundColumn DataField="IdChecklist" HeaderText="IdChecklist">
                            <HeaderStyle CssClass="nascondi" />
                            <ItemStyle CssClass="nascondi" />
                            <FooterStyle CssClass="nascondi" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="" HeaderText="Ordina" ButtonType="ImageButton" ButtonImage="hamburger.png" JsFunction="HHHH">
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </Siar:JsButtonColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione scheda">
                        </asp:BoundColumn>
                        <Siar:CheckColumn DataField="IdChecklist" Name="chkIncludi" HeaderText="Includi">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </Siar:CheckColumn>
                        <Siar:IntegerColumn DataField="IdChecklist" Name="Conteggio" HeaderText="Conteggio">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:IntegerColumn>
                    </Columns>
                </Siar:DataGrid>
                <br />

                <div class="first_elem_block">
                    <Siar:Button ID="btnCreaAutovalutazioneBeneficiario" runat="server" Width="160px" OnClick="btnCreaAutovalutazioneBeneficiario_Click" Text="Crea autovalutazione" />
                </div>

                <div class="first_elem_block">
                    <Siar:Button ID="btnChiudiAutovalutazione" runat="server" Width="160px" OnClick="btnChiudi_Click" Text="Chiudi" />
                </div>
                <br />
            </div>

            <div id="divValidatore" runat="server">
                <Siar:DataGrid ID="dgValidatore" runat="server" AutoGenerateColumns="False" Width="98%">
                    <Columns>
                        <asp:BoundColumn DataField="IdChecklist" HeaderText="IdChecklist">
                            <HeaderStyle CssClass="nascondi" />
                            <ItemStyle CssClass="nascondi" />
                            <FooterStyle CssClass="nascondi" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="" HeaderText="Ordina" ButtonType="ImageButton" ButtonImage="hamburger.png" JsFunction="HHHH">
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </Siar:JsButtonColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione scheda"></asp:BoundColumn>
                        <Siar:CheckColumn DataField="IdChecklist" Name="chkIncludi" HeaderText="Includi" >
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </Siar:CheckColumn>
                        <Siar:IntegerColumn DataField="IdChecklist" Name="Conteggio" HeaderText="Conteggio">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:IntegerColumn>
                    </Columns>
                </Siar:DataGrid>
                <br />

                <div class="first_elem_block">
                    <Siar:Button ID="btnCreaChecklistValidatore" runat="server" OnClick="btnCreaChecklistValidatore_Click" Text="Crea checklist" Width="160px" />
                </div>

                <div class="elem_block">
                    <Siar:Button ID="btnChiudiValidazione" runat="server" Width="160px" OnClick="btnChiudi_Click" Text="Chiudi" />
                </div>
                <br />
            </div>

            </div>

    </div>

</div>
