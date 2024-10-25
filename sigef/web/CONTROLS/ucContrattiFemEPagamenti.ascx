<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucContrattiFemEPagamenti.ascx.cs" Inherits="web.CONTROLS.ucContrattiFemEPagamenti" %>

<%@ Register Src="ucContrattoFem.ascx" TagName="ucContrattoFem" TagPrefix="ucContratto" %>
<%@ Register Src="ucPagamentoFem.ascx" TagName="ucPagamentoFem" TagPrefix="ucPagamento" %>

<%--<div id="divPagInv" runat="server" style="width: 40%; height: 96%; position: absolute; box-shadow: none;">--%>
<div id="divContrattiEPagamenti"  style="width: 98%; height: 100%; float: left; padding: 10px;">
    
    <style type="text/css">
        .hide {
            display:none;
        }

        .labelStyle {
            width: 100px;
            float: left;
            text-align: right;
            padding-right: 5px;
            display: block;
            clear: left;
        }

        .labelRiepilogo {
            padding-left: 10px;
            display: block;
        }

        .fieldset {
            padding: 5px;
        }
    </style>

    <script type="text/javascript">
        function selezionaContratto(idContratto) {
            var mostraPagamenti = true;
            var divPagamenti = $('[id$=divPagamenti]');
            var inserimentoPagamentoAbilitato = $('[id$=hdnInserimentoPagamentoAbilitato]').val();

            if ($('[id$=hdnIdContrattoFem]').val() == idContratto) {
                $('[id$=hdnIdContrattoFem]').val('');
                mostraPagamenti = !mostraPagamenti;
                divPagamenti.hide("fast");
            } else {
                $('[id$=hdnIdContrattoFem]').val(idContratto);
                divPagamenti.show("fast");

                //filtro i pagamenti
                var tblGridPagamenti = $('[id$=dgPagamenti]')[0];
                if (typeof tblGridPagamenti !== 'undefined') { //aggiunto controllo per evitare errore in caso di datagrid ancora vuoto
                    var rows = tblGridPagamenti.rows;
                    var i = 0, row, cell, count = 0, somma_pagamenti = 0.00;
                    for (i = 1; i < rows.length - 1; i++) {
                        row = rows[i];
                        var found = false;
                        var importo_pagamento = row.cells[4].innerHTML;
                        importo_pagamento = importo_pagamento.replace('€', '').split('.').join('').replace(',', '.');
                        var id_riga = row.cells[6].innerHTML;

                        if (mostraPagamenti && id_riga == idContratto) {
                            found = true;
                            somma_pagamenti = (parseFloat(somma_pagamenti) + parseFloat(importo_pagamento)).toFixed(2);
                        }

                        if (!found) {
                            row.style['display'] = 'none';
                        }
                        else {
                            row.style.display = '';
                            count++;
                        }
                    }

                    var cella_totale = $("td[id*='dgPagamenti_tdTotalFooter']")[0];
                    cella_totale.innerHTML = FromNumberToCurrency(Number(somma_pagamenti)) + " €";

                    var dgPagamentiFem = $('[id$=dgPagamenti]');
                    var lbPagamenti = $('[id$=lblPagamenti]')[0];
                    if (count == 0) {
                        lbPagamenti.innerHTML = "Nessun pagamento trovato";
                        dgPagamentiFem.hide("fast");
                    } else if (count == 1) {
                        lbPagamenti.innerHTML = "Visualizza 1 riga";
                        dgPagamentiFem.show("fast");
                    } else {
                        lbPagamenti.innerHTML = "Visualizzate " + count + " righe";
                        dgPagamentiFem.show("fast");
                    }
                }
            }

            //filtro i contratti
            var tblGridContratti = $('[id$=dgContrattiFem]')[0];
            var rowsContratti = tblGridContratti.rows;
            var i = 0, row, cell, count = 0, somma_contratti = 0.00, somma_pagamenti_contratto = 0.00;
            for (i = 1; i < rowsContratti.length - 1; i++) {
                row = rowsContratti[i];
                var found = false;
                var id_riga = row.cells[0].innerHTML;
                var importo_contratto = row.cells[3].innerHTML;
                importo_contratto = importo_contratto.replace('€', '').split('.').join('').replace(',', '.');
                var pagamenti_contratto = row.cells[4].innerHTML;
                pagamenti_contratto = pagamenti_contratto.replace('€', '').split('.').join('').replace(',', '.');

                if (mostraPagamenti == false || id_riga == idContratto) {
                    found = true;
                    somma_contratti = (parseFloat(somma_contratti) + parseFloat(importo_contratto)).toFixed(2);
                    somma_pagamenti_contratto = (parseFloat(somma_pagamenti_contratto) + parseFloat(pagamenti_contratto)).toFixed(2);

                    if (inserimentoPagamentoAbilitato == 'false' || parseFloat(pagamenti_contratto) >= parseFloat(importo_contratto)) {
                        $('[id$=btnInserisciPagamento]')[0].disabled = true;
                    } else {
                        $('[id$=btnInserisciPagamento]')[0].disabled = false;
                    }
                }
                
                if (!found) {
                    row.style['display'] = 'none';
                }
                else {
                    row.style.display = '';
                    count++;
                }
            }

            var cella_totale_contratto = $("td[id*='dgContrattiFem_tdTotalFooter3']")[0];
            cella_totale_contratto.innerHTML = FromNumberToCurrency(Number(somma_contratti)) + " €";

            var cella_totale_pagamenti = $("td[id*='dgContrattiFem_tdTotalFooter4']")[0];
            cella_totale_pagamenti.innerHTML = FromNumberToCurrency(Number(somma_pagamenti_contratto)) + " €";

            var dgContrattiFem = $('[id$=dgContrattiFem]');
            var lbcContratti = $('[id$=lblContrattiFem]')[0];
            if (count == 0) {
                lbcContratti.innerHTML = "Nessun contratto trovato";
                dgContrattiFem.hide("fast");
            } else if (count == 1) {
                lbcContratti.innerHTML = "Selezionare il contratto per tornare alla lista";
                dgContrattiFem.show("fast");
            } else {
                lbcContratti.innerHTML = "Selezionare un contratto per vederne i pagamenti";
                dgContrattiFem.show("fast");
            }
        }

        function selezionaDettaglioContratto(idContratto) {
            //$('[id$=hdnIdContrattoFemMostra]').val($('[id$=hdnIdContrattoFemMostra]').val() == idContratto ? '' : idContratto);
            $('[id$=hdnIdContrattoFemMostra]').val(idContratto);
            $('[id$=btnPostContratto]').click();
        }

        function selezionaDettaglioPagamento(idPagamento) {
            $('[id$=hdnIdContrattoFemPagamenti]').val($('[id$=hdnIdContrattoFemPagamenti]').val() == idPagamento ? '' : idPagamento);
            $('[id$=btnPostPagamento]').click();
        }

        function goBack() {
          window.history.back();
        }
    </script>
    
    <div style="display: none">
        <asp:HiddenField ID="hdnIdContrattoFem" Value="false" runat="server" />
        <asp:HiddenField ID="hdnIdContrattoFemMostra" Value="false" runat="server" />
        <asp:HiddenField ID="hdnIdContrattoFemPagamenti" Value="false" runat="server" />
        <asp:HiddenField ID="hdnInserimentoPagamentoAbilitato" Value="false" runat="server" />
        <asp:Button ID="btnPostContratto" runat="server" OnClick="btnPostContratto_Click" CausesValidation="false" />
        <asp:Button ID="btnPostPagamento" runat="server" OnClick="btnPostPagamento_Click" CausesValidation="false" />
    </div>

    <div class="dBox" id="divRiepilogo" runat="server" style="width: 98%" >
        <div class="separatore">
            Riepilogo
        </div>
        <br />

        <div class="fieldset">
            <div style="display: inline-block; padding-left: 20px;">
                <b>Importo domanda:</b>
                <Siar:CurrencyBox ID="txtImportoDomanda" runat="server" Width="100px" ReadOnly="true" />
            </div> 

            <div style="display: inline-block; padding-left: 20px;">
                <b>Totale importo contratti:</b>
                <Siar:CurrencyBox ID="txtImportoTotaleContratti" runat="server" Width="100px" ReadOnly="true" />
            </div>

            <div style="display: inline-block; padding-left: 20px;">
                <b>Totale importo pagamenti:</b>
                <Siar:CurrencyBox ID="txtImportoTotalePagamenti" runat="server" Width="100px" ReadOnly="true" />
            </div>

            <div style="display: inline-block; padding-left: 20px;">
                <button class="Button" style="width:100px;" onclick="goBack()">Indietro</button>
            </div>
            <br />
            <br />
        </div>
    </div>

    <div class="dBox" id="divContrattiFem" runat="server" style="width: 48%; float: left;">
        <div class="separatore" >
            Contratti
        </div>
        <br />

        <div class="fieldset">
            <Siar:Button ID="btnInserisciContratto" runat="server" OnClick="btnInserisciContratto_Click" Text="Inserisci contratto" />
            <Siar:Button ID="btnImportaContratti" runat="server" OnClick="btnImportaContratti_Click" Text="Importa contratti da Excel" Enabled="false" />
            <br />
            <br />

            <asp:Label ID="lblContrattiFem" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgContrattiFem" runat="server" AutoGenerateColumns="false" Width="100%" ShowFooter="true">
                <Columns>
                    <asp:BoundColumn HeaderText="Id" DataField="IdContrattoFem">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Riferimenti" DataField="Numero">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn HeaderText="Protocollo" Arguments="Segnatura" ButtonType="ImageButton" ButtonImage="/print_ico.gif" ButtonText="Visualizza protocollo" JsFunction="sncAjaxCallVisualizzaProtocollo">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumn>
                    <Siar:ColonnaLink HeaderText="Importo contratto" DataField="Importo" IsJavascript="true" DataFormatString="{0:c}"
                        LinkFields="IdContrattoFem" LinkFormat="selezionaContratto({0});">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:ColonnaLink>
                    <asp:BoundColumn HeaderText="Importo pagamenti" DataField="Importo" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdContrattoFem" ButtonText="Mostra contratto" JsFunction="selezionaDettaglioContratto">
                        <ItemStyle HorizontalAlign="Center" Width="140px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
            </div>
        <br />
    </div>

    <div class="dBox" id="divPagamenti" runat="server" style="width: 48%; float: left; display: none;">
        <div class="separatore">
            Pagamenti
        </div>
        <br />

        <div style="padding: 5px;">
            <Siar:Button ID="btnInserisciPagamento" runat="server" OnClick="btnInserisciPagamento_Click" Text="Inserisci pagamento" />
            <br />
            <br />

            <asp:Label ID="lblPagamenti" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgPagamenti" runat="server" AutoGenerateColumns="false" Width="100%" ShowFooter="true">
                <Columns>
                    <asp:BoundColumn HeaderText="Id" DataField="IdContrattoFemPagamenti">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Impresa" DataField="ImpresaPagamento"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Tipo" DataField="TipoPagamento">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Data" DataField="Data">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Importo" DataField="Importo" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdContrattoFemPagamenti" ButtonText="Mostra pagamento" JsFunction="selezionaDettaglioPagamento">
                        <ItemStyle HorizontalAlign="Center" Width="140px" />
                    </Siar:JsButtonColumn>
                    <asp:BoundColumn DataField="IdContrattoFem" HeaderText="IdContrattoFem">
                        <HeaderStyle CssClass="hide" />
                        <ItemStyle CssClass="hide" />
                        <FooterStyle CssClass="hide" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
        <br />
    </div>

    <ucContratto:ucContrattoFem id="modaleContratto" runat="server" />
    <ucPagamento:ucPagamentoFem ID="modalePagamento" runat="server" />
</div>