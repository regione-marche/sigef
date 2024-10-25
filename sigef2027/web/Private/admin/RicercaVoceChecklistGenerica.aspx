<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" Inherits="web.Private.admin.RicercaVoceChecklist" CodeBehind="RicercaVoceChecklistGenerica.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript">
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
    <div class="row">
        <div class="col-sm-12">
            <Siar:Button ID="btnInserisciVoce" runat="server" Text="Inserisci nuova voce" OnClick="btnInserisciVoce_Click" />
        </div>
    </div>


    <div class="row" id="divElencoVoci" runat="server">
        <h3 class="mt-5">Ricerca voci:
        </h3>
        <div class="row bd-form pt-5">
            <div class="col-sm-4 form-group">
                <Siar:TextBox  Label="Id voce:" ID="txtRicercaIdVoce" runat="server" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:ComboFiltroVociChecklist Label="Filtro:" ID="lstRicercaFiltro" runat="server"></Siar:ComboFiltroVociChecklist>
            </div>
            <div class="col-sm-4 form-group">
                <Siar:TextBox  Label="Descrizione:" ID="txtRicercaDescrizione" runat="server" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:TextBox  Label="Valore minimo:" ID="txtRicercaValoreMinimo" runat="server" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:TextBox  Label="Valore massimo:" ID="txtRicercaValoreMassimo" runat="server" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:ComboBase Label="Automatico:" ID="lstRicercaAutomatico" runat="server"></Siar:ComboBase>
            </div>

            <%--<div class="elem_block">
                    <label><b>Numero utilizzi massimo:</b></label>
                    <div class="value">
                        <asp:TextBox CssClass="rounded" ID="txtRicercaNumUtilizziMassimo" runat="server" Width="150px" />
                    </div>
                </div>--%>
            <div class="col-sm-4">
                <%--<button id="btnFiltraRicercaVoci" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FilterRicercaVoce(); return false;" causesvalidation="false">
                        <img id="imgSearchFiltraRicercaVoce" runat="server" />Filtra 
                    </button>--%>
                <Siar:Button ID="btnFiltraRicercaVoci" runat="server" Text="Filtra" OnClick="btnFiltraRicercaVoci_Click" CausesValidation="false"></Siar:Button>
            </div>
        </div>
        <div class="col-sm-12">
            <p>
                <asp:Label ID="lblNumVoci" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            </p>
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgVoci" runat="server" AutoGenerateColumns="false">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn DataField="IdVoceGenerica" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneFiltro" HeaderText="Filtro">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ValMinimo" HeaderText="Valore minimo">
                        <ItemStyle HorizontalAlign="Center"  />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ValMassimo" HeaderText="Valore massimo">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:CheckColumnAgid DataField="Automatico" HeaderText="Automatico" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                    <asp:BoundColumn DataField="IdVoceGenerica" HeaderText="Num utilizzi in checklist">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumnAgid Arguments="IdVoceGenerica" ButtonText="Visualizza voce" JsFunction="selezionaVoce">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
</asp:Content>
