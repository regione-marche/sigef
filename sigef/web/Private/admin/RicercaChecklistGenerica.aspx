<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" Inherits="web.Private.admin.RicercaChecklistGenerica" CodeBehind="RicercaChecklistGenerica.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <style type="text/css">

        .first_elem_block {
            /*width: 200px;*/
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-left: 20px;
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

        label {
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

    <script type="text/javascript">

        function MostraNascondiDiv(id) {
            var div;
            var img;
            switch (id) {
                case 0:
                    div = $('[id$=divMostraNascondiInserisciChecklist]');
                    img = $('[id$=imgMostraInserisciChecklist]')[0];
                    break;
                case 1:
                    div = $('[id$=divMostraNascondiElencoChecklist]');
                    img = $('[id$=imgMostraElencoChecklist]')[0];
                    break;
            }

            if (img.style.transform == "")
                img.style.transform = "rotate(180deg)";
            else
                img.style.transform = "";

            if (div[0].style.display === "none") {
                div.show("fast");
            } else {
                div.hide("fast");
            }
        }

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

    <Siar:Button ID="btnInserisciChecklist" runat="server" Text="Inserisci nuova checklist" OnClick="btnInserisciChecklist_Click" />
    <br />
    <br />


    <div class="dBox" id="divElencoChecklist" runat="server">
        <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDiv(1);">
            <img id="imgMostraElencoChecklist" runat="server" style="width: 23px; height: 23px;" />
            Ricerca checklist: 
        </div>

        <div id="divMostraNascondiElencoChecklist" runat="server" style="padding: 10px;">
            <div id="divRicercaChecklist" runat="server" class="box_ricerca">
                <div class="first_elem_block">
                    <label><b>Id checklist:</b></label>
                    <div class="value">
                        <asp:TextBox ID="txtRicercaIdChecklist" runat="server" Width="150px" />
                    </div>
                </div>

                <div class="elem_block">
                    <label><b>Tipo:</b></label>
                    <div class="value">
                        <Siar:ComboTipoChecklist ID="lstRicercaTipo" runat="server" Width="150px" Height="21px"></Siar:ComboTipoChecklist>
                    </div>
                </div>

                <div class="elem_block">
                    <label><b>Descrizione:</b></label>
                    <div class="value">
                        <asp:TextBox ID="txtRicercaDescrizione" runat="server" Width="150px" />
                    </div>
                </div>

                <div class="elem_block">
                    <label><b>Filtro:</b></label>
                    <div class="value">
                        <Siar:ComboFiltroChecklistVoce ID="lstRicercaFiltro" runat="server" Width="150px" Height="21px"></Siar:ComboFiltroChecklistVoce>
                    </div>
                </div>

                <div class="elem_block">
                    <label><b>Template:</b></label>
                    <div class="value">
                        <Siar:ComboBase ID="lstRicercaTemplate" runat="server" Width="50px" Height="21px"></Siar:ComboBase>
                    </div>
                </div>

                <%--<div class="elem_block">
                    <label><b>Numero voci massimo:</b></label>
                    <div class="value">
                        <asp:TextBox ID="txtRicercaNumvociMassimo" runat="server" Width="150px" />
                    </div>
                </div>--%>
                <br />

                <div class="first_elem_block">
                    <%--<button id="btnFiltraRicercaChecklist" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FilterRicercaChecklist(); return false;" causesvalidation="false">
                        <img id="imgSearchFiltraRicercaChecklist" runat="server" />Filtra 
                    </button>--%>
                    <Siar:Button ID="btnFiltraRicercaChecklist" runat="server" Width="110px" Text="Filtra" OnClick="btnFiltraRicercaChecklist_Click" CausesValidation="false"></Siar:Button>
                </div>
            </div>
            <br />

            <asp:Label ID="lblNumChecklist" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />

            <Siar:DataGrid ID="dgChecklist" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn DataField="IdChecklistGenerica" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" Width="50px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneTipo" HeaderText="Tipo"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                        <ItemStyle Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneFiltro" HeaderText="Filtro"></asp:BoundColumn>
                    <Siar:CheckColumn DataField="FlagTemplate" HeaderText="Template" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </Siar:CheckColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Elementi associati">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdChecklistGenerica" ButtonText="Visualizza checklist" JsFunction="selezionaChecklist">
                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
            <br />
        </div>
    </div>

</asp:Content>
