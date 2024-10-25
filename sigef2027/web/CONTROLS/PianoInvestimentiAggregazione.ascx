<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PianoInvestimentiAggregazione.ascx.cs"
    Inherits="web.CONTROLS.PianoInvestimentiAggregazione" %>
<%@ Register Src="SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc1" %>

<script type="text/javascript"><!--

    function espandiAggregazionePost() { var codici_espansi = $('[id$=hdnDgAggregazioneEspansione]').val().split('|'); $('[id$=hdnDgAggregazioneEspansione]').val(''); for (var i = 0; i < codici_espansi.length; i++) espandiProgrammazione(codici_espansi[i]); }
    function espandiAggregazione(path_label) {
        var tr = $('[PathLabel=' + path_label + ']'), espandi = !eval($(tr).attr("ElemEspanso")); var arr = $('[PathLabel^=' + path_label + '][PathLabel!=' + path_label + ']');
        for (var i = 0; i < arr.length; i++) { var pl = $(arr[i]).attr('PathLabel'); if (espandi == true) { if (pl.length > path_label.length) arr[i].style.display = ''; } else { arr[i].style.display = 'none'; $(arr[i]).attr("ElemEspanso", false); aggiornaHiddenEspansione($(arr[i]).attr("PathLabel"), false); } }
        $(tr).attr("ElemEspanso", espandi); aggiornaHiddenEspansione(path_label, espandi);
    }
    function aggiornaHiddenEspansione(path_label, insert) { if (path_label != '') { var codici_espansi = $('[id$=hdnDgAggregazioneEspansione]').val().split('|'); if (insert == true) codici_espansi.push(path_label); else if (codici_espansi.indexOf(path_label) >= 0) codici_espansi.splice(codici_espansi.indexOf(path_label), 1); $('[id$=hdnDgAggregazioneEspansione]').val(codici_espansi.join('|')); } }

</script>

<div style="display: none">
    <asp:HiddenField ID="hdnDgAggregazioneEspansione" runat="server" />
</div>
<div class="accordion-item" id="dBoxAggregazione" runat="server">
    <h2 class="accordion-header " id="pianoInvestimentiImpresaHeading">
        <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapsePianoInvestimentiImpresa" aria-expanded="false" aria-controls="collapsePianoInvestimentiImpresa">
            Piano degli investimenti raggruppato per impresa
        </button>
    </h2>
    <div id="collapsePianoInvestimentiImpresa" class="accordion-collapse collapse" role="region" aria-labelledby="pianoInvestimentiImpresaHeading">
        <div class="accordion-body">
            <Siar:DataGridAgid ID="dgAggregazione" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" ShowFooter="true">
                <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                <Columns>
                    <asp:BoundColumn HeaderText="Descrizione"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Costo" DataField="Costo"
                        DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Contributo" DataField="Contributo"
                        DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="% Quota contributo">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <%--<Siar:JsButtonColumn Arguments="Id" JsFunction="mostraDettaglioProgrammazione" ButtonType="ImageButton"
                            ButtonText="Dettaglio elemento" ButtonImage="lente.png">
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>--%>
                </Columns>
            </Siar:DataGridAgid>
            <div class="col-sm-12" runat="server" id="tbLegendaInvestimenti" visible="false">
                <ul>
                    <li><small>(**) = contributo troncato per superamento <b>massimali</b> di domanda</small></li>
                    <li><small>(***) = contributo a <b>quota fissa</b></small></li>
                </ul>
            </div>
        </div>
    </div>
</div>
