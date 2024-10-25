<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" Inherits="web.Private.admin.RicercaVoceChecklist" CodeBehind="RicercaVoceChecklistGenerica.aspx.cs" %>

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
                    div = $('[id$=divMostraNascondiInserisciVoce]');
                    img = $('[id$=imgMostraInserisciVoce]')[0];
                    break;
                case 1:
                    div = $('[id$=divMostraNascondiElencoVoci]');
                    img = $('[id$=imgMostraElencoVoci]')[0];
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

        function selezionaVoce(idVoce) {
            $('[id$=hdnIdVoce]').val($('[id$=hdnIdVoce]').val() == idVoce ? '' : idVoce);
            $('[id$=btnSelezionaVoce]').click();
        }

        function FilterRicercaVoce() {
            var txtIdVoce = $('[id$=txtRicercaIdVoce]').val();
            var lstFiltro = $('[id$=lstRicercaFiltro]')[0];
            var txtFiltro = lstFiltro.options[lstFiltro.selectedIndex].text;
            var txtDescrizione = $('[id$=txtRicercaDescrizione]').val().toUpperCase(); 
            var txtValoreMinimo = $('[id$=txtRicercaValoreMinimo]').val(); 
            var txtValoreMassimo = $('[id$=txtRicercaValoreMassimo]').val(); 
            var lstAutomatico = $('[id$=lstRicercaAutomatico]')[0];
            var txtAutomatico = lstAutomatico.options[lstAutomatico.selectedIndex].text;
            var txtNumUtilizziMassimo = $('[id$=txtRicercaNumUtilizziMassimo]').val();

            var tblGrid = $('[id$=dgVoci]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell, count = 0;
            for (i = 1; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgIdVoce = row.cells[0].innerHTML;
                dgFiltro = row.cells[1].innerHTML;
                dgDescrizione = row.cells[2].innerHTML.toUpperCase();
                dgValoreMinimo = row.cells[3].innerHTML;
                dgValoreMassimo = row.cells[4].innerHTML;
                dgAutomatico = row.cells[5].innerHTML;
                dgNumUtilizziMassimo = row.cells[6].innerHTML;

                if ((txtIdVoce == ""
                        || (txtIdVoce != "" && dgIdVoce == txtIdVoce))
                    && (txtFiltro == ""
                        || (txtFiltro != "" && dgFiltro == txtFiltro))
                    && (txtDescrizione == ""
                        || (txtDescrizione != "" && dgDescrizione.indexOf(txtDescrizione) > -1))
                    && (txtValoreMinimo == ""
                        || (txtValoreMinimo != "" && dgValoreMinimo == txtValoreMinimo))
                    && (txtValoreMassimo == ""
                        || (txtValoreMassimo != "" && dgValoreMassimo == txtValoreMassimo))
                    && (txtAutomatico == ""
                        || (txtAutomatico == "Sì" && dgAutomatico.indexOf("checked") > -1)
                        || (txtAutomatico == "No" && dgAutomatico.indexOf("checked") == -1))
                    && (txtNumUtilizziMassimo == ""
                        || (txtNumUtilizziMassimo != "" && Number(dgNumUtilizziMassimo) <= Number(txtNumUtilizziMassimo)))
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
                $('[id$=lblNumVoci]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgVoci]').show("fast");
            } else {
                $('[id$=lblNumVoci]')[0].innerHTML = "Nessuna voce trovata";
                $('[id$=dgVoci]').hide("fast");
            }
            return false;
        }

    </script>

    <div style="display: none">

        <asp:HiddenField ID="hdnIdVoce" runat="server" />
        <asp:HiddenField ID="hdnRicerca" runat="server" />
        <asp:Button ID="btnSelezionaVoce" runat="server" CausesValidation="False" OnClick="btnSelezionaVoce_Click" />

    </div>

    <Siar:Button ID="btnInserisciVoce" runat="server" Text="Inserisci nuova voce" OnClick="btnInserisciVoce_Click" />
    <br />
    <br />


    <div class="dBox" id="divElencoVoci" runat="server">
        <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDiv(1);">
            <img id="imgMostraElencoVoci" runat="server" style="width: 23px; height: 23px;" />
            Ricerca voci: 
        </div>

        <div id="divMostraNascondiElencoVoci" runat="server" style="padding: 10px;">
            <div id="divRicercaVoci" runat="server" class="box_ricerca">
                <div class="first_elem_block">
                    <label><b>Id voce:</b></label>
                    <div class="value">
                        <asp:TextBox ID="txtRicercaIdVoce" runat="server" Width="150px" />
                    </div>
                </div>

                <div class="elem_block">
                    <label><b>Filtro:</b></label>
                    <div class="value">
                        <Siar:ComboFiltroVociChecklist ID="lstRicercaFiltro" runat="server" Width="150px" Height="21px"></Siar:ComboFiltroVociChecklist>
                    </div>
                </div>

                <div class="elem_block">
                    <label><b>Descrizione:</b></label>
                    <div class="value">
                        <asp:TextBox ID="txtRicercaDescrizione" runat="server" Width="150px" />
                    </div>
                </div>

                <div class="elem_block">
                    <label><b>Valore minimo:</b></label>
                    <div class="value">
                        <asp:TextBox ID="txtRicercaValoreMinimo" runat="server" Width="150px" />
                    </div>
                </div>

                <div class="elem_block">
                    <label><b>Valore massimo:</b></label>
                    <div class="value">
                        <asp:TextBox ID="txtRicercaValoreMassimo" runat="server" Width="150px" />
                    </div>
                </div>

                <div class="elem_block">
                    <label><b>Automatico:</b></label>
                    <div class="value">
                        <Siar:ComboBase ID="lstRicercaAutomatico" runat="server" Width="50px" Height="21px"></Siar:ComboBase>
                    </div>
                </div>

                <%--<div class="elem_block">
                    <label><b>Numero utilizzi massimo:</b></label>
                    <div class="value">
                        <asp:TextBox ID="txtRicercaNumUtilizziMassimo" runat="server" Width="150px" />
                    </div>
                </div>--%>
                <br />

                <div class="first_elem_block">
                    <%--<button id="btnFiltraRicercaVoci" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FilterRicercaVoce(); return false;" causesvalidation="false">
                        <img id="imgSearchFiltraRicercaVoce" runat="server" />Filtra 
                    </button>--%>
                    <Siar:Button ID="btnFiltraRicercaVoci" runat="server" Width="110px" text="Filtra" OnClick="btnFiltraRicercaVoci_Click" CausesValidation="false">
                    </Siar:Button>
                </div>
            </div>
            <br />

            <asp:Label ID="lblNumVoci" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />

            <Siar:DataGrid ID="dgVoci" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn DataField="IdVoceGenerica" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" Width="50px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneFiltro" HeaderText="Filtro">
                        <ItemStyle HorizontalAlign="Center" Width="250px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ValMinimo" HeaderText="Valore minimo">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ValMassimo" HeaderText="Valore massimo">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="Automatico" HeaderText="Automatico" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </Siar:CheckColumn>
                    <asp:BoundColumn DataField="IdVoceGenerica" HeaderText="Num utilizzi in checklist">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdVoceGenerica" ButtonText="Visualizza voce" JsFunction="selezionaVoce">
                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
            <br />
        </div>
    </div>

</asp:Content>
