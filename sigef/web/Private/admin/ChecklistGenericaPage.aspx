<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" Inherits="web.Private.admin.ChecklistGenericaPage" CodeBehind="ChecklistGenericaPage.aspx.cs" %>

<asp:content id="Content1" contentplaceholderid="cphContenuto" runat="Server">

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

    </style>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/jquery-ui.min.js"></script>

    <script type="text/javascript">

        function OrdinaDatagrid() {
            $("[id$=dgVociChecklist]").sortable({
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

            $("[id$=dgSchede]").sortable({
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
        };

        function pageLoad() {
            OrdinaDatagrid();
        }

        function HHHH(id) { }

    </script>

    <div style="display: none">
    </div>

    <div class="dBox" id="divChecklistGenerica" runat="server">
        <div class="separatore">
            Checklist generica
        </div>

        <div style="padding: 10px;">
            <div class="first_elem_block">
                <div class="label"><b>Descrizione:</b></div>
                <div class="value">
                    <Siar:TextArea ID="txtDescrizioneChecklistGenerica" runat="server" Width="450px" Rows="2" ExpandableRows="2"
                        MaxLength="255" NomeCampo="Descrizione" Obbligatorio="true"></Siar:TextArea>
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Template:</div>
                <div class="value">
                    <asp:CheckBox ID="chkTemplate" runat="server" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label"><b>Tipo:</b></div>
                <div class="value">
                    <Siar:ComboTipoChecklist ID="lstTipoChecklist" runat="server" Obbligatorio="true" NomeCampo="Tipo"></Siar:ComboTipoChecklist>
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label"><b>Filtro:</b></div>
                <div class="value">
                    <Siar:ComboFiltroChecklistVoce ID="lstFiltro" runat="server" NomeCampo="Filtro"></Siar:ComboFiltroChecklistVoce>
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <Siar:Button ID="btnSalvaChecklistGenerica" runat="server" OnClick="btnSalvaChecklistGenerica_Click" Text="Salva checklist" Width="110px" />
            </div>

            <div class="elem_block">
                <Siar:Button ID="btnEliminaChecklistGenerica" runat="server" OnClick="btnEliminaChecklistGenerica_Click" Text="Elimina checklist" Width="110px" />
            </div>

            <div class="elem_block">
                <input type="button" class="Button" value="Indietro" style="width: 110px;" onclick="history.back();" />
            </div>
        </div>
    </div>
    <br />

    <div class="dBox" id="divVociAssociateChecklist" runat="server">
        <div class="separatore">
            Voci associate alla checklist
        </div>
        <br />

        <div style="padding: 10px;">
            <Siar:DataGrid ID="dgVociChecklist" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <Siar:JsButtonColumn Arguments="" HeaderText="Ordina" ButtonType="ImageButton" ButtonImage="hamburger.png" JsFunction="HHHH">
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </Siar:JsButtonColumn>
                    <asp:BoundColumn DataField="IdVoceGenerica" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" Width="40px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdVoceGenerica" HeaderText="Id voce">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" Width="50px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="Automatico" HeaderText="Automatico" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </Siar:CheckColumn>
                    <Siar:IntegerColumn DataField="IdVoceGenerica" HeaderText="Ordine" Valore="IdVoceGenerica" Name="VoceOrdine">
                        <ItemStyle Width="50" HorizontalAlign="center" />
                    </Siar:IntegerColumn>
                    <Siar:CheckColumn DataField="IdVoceGenerica" HeaderText="Obbligatorio" Name="VoceObbligatorio">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </Siar:CheckColumn>
                    <Siar:IntegerColumn DataField="IdVoceGenerica" HeaderText="Peso" Valore="IdVoceGenerica" Name="VocePeso">
                        <ItemStyle Width="50" HorizontalAlign="center" />
                    </Siar:IntegerColumn>
                    <Siar:CheckColumn DataField="IdVoceGenerica" Name="chkVoceIncludi" HeaderText="Includi">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </Siar:CheckColumn>
                </Columns>
            </Siar:DataGrid>
            <br />

            <div class="first_elem_block">
                <Siar:Button ID="btnSalvaVociChecklist" runat="server" OnClick="btnSalvaVociChecklist_Click" Text="Salva voci checklist" Width="150px" />
            </div>

            <div class="elem_block">
                <Siar:Button ID="btnAnnullaCambiamentiVociChecklist" runat="server" OnClick="btnAnnullaCambiamentiVociChecklist_Click" Text="Annulla modifiche" Width="150px" />
            </div>

            <div class="elem_block">
                <input type="button" class="Button" value="Indietro" style="width: 110px;" onclick="history.back();" />
            </div>
        </div>
    </div>

    <div class="dBox" id="divSchedeAssociateChecklist" runat="server">
        <div class="separatore">
            Schede associate alla checklist
        </div>
        <br />

        <div style="padding: 10px;">
            <Siar:DataGrid ID="dgSchede" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <Siar:JsButtonColumn Arguments="" HeaderText="Ordina" ButtonType="ImageButton" ButtonImage="hamburger.png" JsFunction="HHHH">
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </Siar:JsButtonColumn>
                    <asp:BoundColumn DataField="IdChecklistGenerica" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" Width="50px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                    <Siar:CheckColumn DataField="FlagTemplate" HeaderText="Template" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </Siar:CheckColumn>
                    <Siar:IntegerColumn DataField="IdChecklistGenerica" HeaderText="Ordine" Valore="IdChecklistGenerica" Name="SchedaOrdine">
                        <ItemStyle Width="50" HorizontalAlign="center" />
                    </Siar:IntegerColumn>
                    <Siar:CheckColumn DataField="IdChecklistGenerica" HeaderText="Obbligatorio" Name="SchedaObbligatorio">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </Siar:CheckColumn>
                    <Siar:IntegerColumn DataField="IdChecklistGenerica" HeaderText="Peso" Valore="IdChecklistGenerica" Name="SchedaPeso">
                        <ItemStyle Width="50" HorizontalAlign="center" />
                    </Siar:IntegerColumn>
                    <Siar:CheckColumn DataField="IdChecklistGenerica" Name="chkSchedaIncludi" HeaderText="Includi">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </Siar:CheckColumn>
                </Columns>
            </Siar:DataGrid>
            <br />

            <div class="first_elem_block">
                <Siar:Button ID="btnSalvaSchedeChecklist" runat="server" OnClick="btnSalvaSchedeChecklist_Click" Text="Salva schede checklist" Width="150px" />
            </div>

            <div class="elem_block">
                <Siar:Button ID="btnAnnullaCambiamentiSchedeChecklist" runat="server" OnClick="btnAnnullaCambiamentiSchedeChecklist_Click" Text="Annulla modifiche" Width="150px" />
            </div>

            <div class="elem_block">
                <input type="button" class="Button" value="Indietro" style="width: 110px;" onclick="history.back();" />
            </div>
        </div>
    </div>

</asp:content>
