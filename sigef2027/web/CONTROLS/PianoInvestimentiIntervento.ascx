<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PianoInvestimentiIntervento.ascx.cs"
    Inherits="web.CONTROLS.PianoInvestimentiIntervento" %>
<%@ Register Src="SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc1" %>

<script type="text/javascript">

    function espandiInterventiPost() { var codici_espansi = $('[id$=hdnDgInterventiEspansione]').val().split('|'); $('[id$=hdnDgInterventiEspansione]').val(''); for (var i = 0; i < codici_espansi.length; i++) espandiInterventi(codici_espansi[i]); }
    function espandiInterventi(path_label) {
        var tr = $('[PathLabel=' + path_label + ']'), espandi = !eval($(tr).attr("ElemEspanso")); var arr = $('[PathLabel^=' + path_label + '][PathLabel!=' + path_label + ']');
        for (var i = 0; i < arr.length; i++) { var pl = $(arr[i]).attr('PathLabel'); if (espandi == true) { if (pl.length > path_label.length) arr[i].style.display = ''; } else { arr[i].style.display = 'none'; $(arr[i]).attr("ElemEspanso", false); aggiornaHiddenEspansioneInt($(arr[i]).attr("PathLabel"), false); } }
        $(tr).attr("ElemEspanso", espandi); aggiornaHiddenEspansioneInt(path_label, espandi);
    }
    function aggiornaHiddenEspansioneInt(path_label, insert) { if (path_label != '') { var codici_espansi = $('[id$=hdnDgInterventiEspansione]').val().split('|'); if (insert == true) codici_espansi.push(path_label); else if (codici_espansi.indexOf(path_label) >= 0) codici_espansi.splice(codici_espansi.indexOf(path_label), 1); $('[id$=hdnDgInterventiEspansione]').val(codici_espansi.join('|')); } }

</script>

<div style="display: none">
    <asp:HiddenField ID="hdnDgInterventiEspansione" runat="server" />
</div>
<div class="accordion" id="dBoxIntervento" runat="server">
    <div class="accordion-item">
        <h2 class="accordion-header " id="pianoInvestimentiInterventoHeading">
            <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapsePianoInvestimentiIntervento" aria-expanded="false" aria-controls="collapse1c">
                Piano degli investimenti raggruppato per intervento
            </button>
        </h2>
        <div id="collapsePianoInvestimentiIntervento" class="accordion-collapse collapse" role="region" aria-labelledby="pianoInvestimentiInterventoHeading">
            <div class="accordion-body">
                <Siar:DataGrid ID="dgInterventi" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" ShowFooter="true">
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
                </Siar:DataGrid>
                <div class="col-sm-12" runat="server" id="tbLegendaInvestimenti" visible="false">
                    <ul>
                        <li><small>(**) = contributo troncato per superamento <b>massimali</b> di domanda</small></li>
                        <li><small>(***) = contributo a <b>quota fissa</b></small></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>
