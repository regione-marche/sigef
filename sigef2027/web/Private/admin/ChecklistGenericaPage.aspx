<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" Inherits="web.Private.admin.ChecklistGenericaPage" CodeBehind="ChecklistGenericaPage.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

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

    <div class="row bg-100" id="divChecklistGenerica" runat="server">
        <h3 class="mt-5 pb-5">Checklist generica
        </h3>

        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Descrizione:" ID="txtDescrizioneChecklistGenerica" runat="server" Rows="2" ExpandableRows="2"
                MaxLength="255" NomeCampo="Descrizione" Obbligatorio="true"></Siar:TextArea>
        </div>

        <div class="col-sm-4 form-check">
            <asp:CheckBox ID="chkTemplate" Text="Template:" runat="server" />
        </div>

        <div class="col-sm-4 form-group">
            <Siar:ComboTipoChecklist Label="Tipo:" ID="lstTipoChecklist" runat="server" Obbligatorio="true" NomeCampo="Tipo"></Siar:ComboTipoChecklist>
        </div>
        <div class="col-sm-4 form-group">
            <Siar:ComboFiltroChecklistVoce Label="Filtro:" ID="lstFiltro" runat="server" NomeCampo="Filtro"></Siar:ComboFiltroChecklistVoce>
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalvaChecklistGenerica" runat="server" OnClick="btnSalvaChecklistGenerica_Click" Text="Salva checklist" />
            <Siar:Button ID="btnEliminaChecklistGenerica" runat="server" OnClick="btnEliminaChecklistGenerica_Click" Text="Elimina checklist" />
            <input type="button" class="btn btn-secondary py-1" value="Indietro" onclick="history.back();" />
        </div>
    </div>
    <br />

    <div class="row" id="divVociAssociateChecklist" runat="server">
        <h3 class="mt-5 pb-5">Voci associate alla checklist
        </h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgVociChecklist" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <Siar:JsButtonColumn Arguments="" HeaderText="Ordina" ButtonType="ImageButton" ButtonImage="hamburger.png" JsFunction="HHHH">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumn>
                    <asp:BoundColumn DataField="IdVoceGenerica" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdVoceGenerica" HeaderText="Id voce">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                    <Siar:CheckColumnAgid DataField="Automatico" HeaderText="Automatico" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                    <Siar:IntegerColumnAgid DataField="IdVoceGenerica" HeaderText="Ordine" Valore="IdVoceGenerica" Name="VoceOrdine">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:IntegerColumnAgid>
                    <Siar:CheckColumnAgid DataField="IdVoceGenerica" HeaderText="Obbligatorio" Name="VoceObbligatorio">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                    <Siar:IntegerColumnAgid DataField="IdVoceGenerica" HeaderText="Peso" Valore="IdVoceGenerica" Name="VocePeso">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:IntegerColumnAgid>
                    <Siar:CheckColumnAgid DataField="IdVoceGenerica" Name="chkVoceIncludi" HeaderText="Includi">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
            <div class="col-sm-12">
                <Siar:Button ID="btnSalvaVociChecklist" runat="server" OnClick="btnSalvaVociChecklist_Click" Text="Salva voci checklist" />
                <Siar:Button ID="btnAnnullaCambiamentiVociChecklist" runat="server" OnClick="btnAnnullaCambiamentiVociChecklist_Click" Text="Annulla modifiche" />
                <input type="button" class="btn btn-secondary py-1" value="Indietro" onclick="history.back();" />
            </div>
        </div>
    </div>
    <div class="row" id="divSchedeAssociateChecklist" runat="server">
        <h3 class="mt-5 pb-5">Schede associate alla checklist
        </h3>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgSchede" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <Siar:JsButtonColumn Arguments="" HeaderText="Ordina" ButtonType="ImageButton" ButtonImage="hamburger.png" JsFunction="HHHH">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumn>
                    <asp:BoundColumn DataField="IdChecklistGenerica" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                    <Siar:CheckColumnAgid DataField="FlagTemplate" HeaderText="Template" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                    <Siar:IntegerColumnAgid DataField="IdChecklistGenerica" HeaderText="Ordine" Valore="IdChecklistGenerica" Name="SchedaOrdine">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:IntegerColumnAgid>
                    <Siar:CheckColumnAgid DataField="IdChecklistGenerica" HeaderText="Obbligatorio" Name="SchedaObbligatorio">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                    <Siar:IntegerColumnAgid DataField="IdChecklistGenerica" HeaderText="Peso" Valore="IdChecklistGenerica" Name="SchedaPeso">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:IntegerColumnAgid>
                    <Siar:CheckColumnAgid DataField="IdChecklistGenerica" Name="chkSchedaIncludi" HeaderText="Includi">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalvaSchedeChecklist" runat="server" OnClick="btnSalvaSchedeChecklist_Click" Text="Salva schede checklist"/>
            <Siar:Button ID="btnAnnullaCambiamentiSchedeChecklist" runat="server" OnClick="btnAnnullaCambiamentiSchedeChecklist_Click" Text="Annulla modifiche" />
            <input type="button" class="btn btn-secondary py-1" value="Indietro" onclick="history.back();" />
        </div>
    </div>
</asp:Content>
