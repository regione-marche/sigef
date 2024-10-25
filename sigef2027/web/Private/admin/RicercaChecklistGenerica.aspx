<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" Inherits="web.Private.admin.RicercaChecklistGenerica" CodeBehind="RicercaChecklistGenerica.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript">

        function selezionaChecklist(idChecklist) {
            $('[id$=hdnIdChecklist]').val($('[id$=hdnIdChecklist]').val() == idChecklist ? '' : idChecklist);
            $('[id$=btnSelezionaChecklist]').click();
        }

        function FilterRicercaChecklist() {
            var txtIdChecklist = $('[id$=txtRicercaIdChecklist]').val();
            var lstTipo = $('[id$=lstRicercaTipo]')[0];
            var txtTipo = lstTipo.options[lstTipo.selectedIndex].text;
            var txtDescrizione = $('[id$=txtRicercaDescrizione]').val().toUpperCase();
            var lstFiltro = $('[id$=lstRicercaFiltro]')[0];
            var txtFiltro = lstFiltro.options[lstFiltro.selectedIndex].text;
            var lstTemplate = $('[id$=lstRicercaTemplate]')[0];
            var txtTemplate = lstTemplate.options[lstTemplate.selectedIndex].text;
            var txtNumVociMassimo = $('[id$=txtRicercaNumvociMassimo]').val();

            var tblGrid = $('[id$=dgChecklist]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell, count = 0;
            for (i = 1; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgIdChecklist = row.cells[0].innerHTML;
                dgTipo = row.cells[1].innerHTML;
                dgDescrizione = row.cells[2].innerHTML.toUpperCase();
                dgFiltro = row.cells[3].innerHTML;
                dgTemplate = row.cells[4].innerHTML;
                dgNumUtilizziMassimo = row.cells[5].innerHTML;

                if ((txtIdChecklist == ""
                    || (txtIdChecklist != "" && dgIdChecklist == txtIdChecklist))
                    && (txtTipo == ""
                        || (txtTipo != "" && dgTipo == txtTipo))
                    && (txtDescrizione == ""
                        || (txtDescrizione != "" && dgDescrizione.indexOf(txtDescrizione) > -1))
                    && (txtFiltro == ""
                        || (txtFiltro != "" && dgFiltro == txtFiltro))
                    && (txtTemplate == ""
                        || (txtTemplate == "Sì" && dgTemplate.indexOf("checked") > -1)
                        || (txtTemplate == "No" && dgTemplate.indexOf("checked") == -1))
                    && (txtNumVociMassimo == ""
                        || (txtNumVociMassimo != "" && Number(dgNumUtilizziMassimo) <= Number(txtNumVociMassimo)))
                ) {
                    found = true;
                }

                if (!found) {
                    row.style['display'] = 'none';
                }
                else {
                    row.style.display = '';
                    count++;
                }
            }

            if (count > 0) {
                $('[id$=lblNumChecklist]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgChecklist]').show("fast");
            } else {
                $('[id$=lblNumChecklist]')[0].innerHTML = "Nessuna checklist trovata";
                $('[id$=dgChecklist]').hide("fast");
            }
            return false;
        }

    </script>

    <div style="display: none">

        <asp:HiddenField ID="hdnIdChecklist" runat="server" />
        <asp:Button ID="btnSelezionaChecklist" runat="server" CausesValidation="False" OnClick="btnSelezionaChecklist_Click" />

    </div>
    <div class="row">
        <div class="col-sm-12">
            <Siar:Button ID="btnInserisciChecklist" runat="server" Text="Inserisci nuova checklist" OnClick="btnInserisciChecklist_Click" />
        </div>
    </div>


    <div class="row" id="divElencoChecklist" runat="server">
        <h3 class="mt-5">Ricerca checklist: 
        </h3>
        <div class="row bd-form pt-5">
            <div class="col-sm-4 form-group">
                <Siar:TextBox  Label="Id checklist:" ID="txtRicercaIdChecklist" runat="server" />
            </div>

            <div class="col-sm-4 form-group">
                <Siar:ComboTipoChecklist Label="Tipo:" ID="lstRicercaTipo" runat="server"></Siar:ComboTipoChecklist>
            </div>

            <div class="col-sm-4 form-group">
                <Siar:TextBox  Label="Descrizione:" ID="txtRicercaDescrizione" runat="server" />
            </div>

            <div class="col-sm-4 form-group">
                <Siar:ComboFiltroChecklistVoce Label="Filtro:" ID="lstRicercaFiltro" runat="server"></Siar:ComboFiltroChecklistVoce>
            </div>

            <div class="col-sm-4 form-group">
                <Siar:ComboBase Label="Template:" ID="lstRicercaTemplate" runat="server"></Siar:ComboBase>
            </div>

            <%--<div class="elem_block">
                    <label><b>Numero voci massimo:</b></label>
                    <div class="value">
                        <asp:TextBox CssClass="rounded" ID="txtRicercaNumvociMassimo" runat="server" Width="150px" />
                    </div>
                </div>--%>
            <div class="col-sm-4">
                <%--<button id="btnFiltraRicercaChecklist" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FilterRicercaChecklist(); return false;" causesvalidation="false">
                        <img id="imgSearchFiltraRicercaChecklist" runat="server" />Filtra 
                    </button>--%>
                <Siar:Button ID="btnFiltraRicercaChecklist" runat="server" Text="Filtra" OnClick="btnFiltraRicercaChecklist_Click" CausesValidation="false"></Siar:Button>
            </div>
        </div>
        <div class="col-sm-12">
            <p>
                <asp:Label ID="lblNumChecklist" runat="server" Text="" Font-Size="Smaller"></asp:Label></p>
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgChecklist" runat="server" AutoGenerateColumns="false">                
                <Columns>
                    <asp:BoundColumn DataField="IdChecklistGenerica" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneTipo" HeaderText="Tipo"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                        <ItemStyle Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneFiltro" HeaderText="Filtro"></asp:BoundColumn>
                    <Siar:CheckColumnAgid DataField="FlagTemplate" HeaderText="Template" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center"/>
                    </Siar:CheckColumnAgid>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Elementi associati">
                        <ItemStyle HorizontalAlign="Center"/>
                    </asp:BoundColumn>
                    <Siar:JsButtonColumnAgid Arguments="IdChecklistGenerica" ButtonText="Visualizza checklist" JsFunction="selezionaChecklist">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
</asp:Content>
