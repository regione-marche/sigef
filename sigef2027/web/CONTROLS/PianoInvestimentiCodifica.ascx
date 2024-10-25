<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PianoInvestimentiCodifica.ascx.cs"
    Inherits="web.CONTROLS.PianoInvestimentiCodifica" %>
<%@ Register Src="SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc1" %>

<script type="text/javascript"><!--

    function espandiCodificaPost() { var codici_espansi = $('[id$=hdnDgCodificaEspansione]').val().split('|'); $('[id$=hdnDgCodificaEspansione]').val(''); for (var i = 0; i < codici_espansi.length; i++) espandiProgrammazione(codici_espansi[i]); }
    function espandiCodifica(path_label) {
        var tr = $('[PathLabel=' + path_label + ']'), espandi = !eval($(tr).attr("ElemEspanso")); var arr = $('[PathLabel^=' + path_label + '][PathLabel!=' + path_label + ']');
        for (var i = 0; i < arr.length; i++) { var pl = $(arr[i]).attr('PathLabel'); if (espandi == true) { if (pl.length > path_label.length) arr[i].style.display = ''; } else { arr[i].style.display = 'none'; $(arr[i]).attr("ElemEspanso", false); aggiornaHiddenEspansioneCodifica($(arr[i]).attr("PathLabel"), false); } }
        $(tr).attr("ElemEspanso", espandi); aggiornaHiddenEspansioneCodifica(path_label, espandi);
    }
    function aggiornaHiddenEspansioneCodifica(path_label, insert) { if (path_label != '') { var codici_espansi = $('[id$=hdnDgCodificaEspansione]').val().split('|'); if (insert == true) codici_espansi.push(path_label); else if (codici_espansi.indexOf(path_label) >= 0) codici_espansi.splice(codici_espansi.indexOf(path_label), 1); $('[id$=hdnDgCodificaEspansione]').val(codici_espansi.join('|')); } }

</script>

<div style="display: none">
    <asp:HiddenField ID="hdnDgCodificaEspansione" runat="server" />
</div>

<div class="accordion" id="dBoxCodifica" runat="server">
    <div class="accordion-item">
        <h2 class="accordion-header " id="pianoInvestimentiCodificaHeading">
            <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapsePianoInvestimentiCodifica" aria-expanded="false" aria-controls="collapse1c">
                Piano degli investimenti raggruppato per codifica
            </button>
        </h2>
        <div id="collapsePianoInvestimentiCodifica" class="accordion-collapse collapse" role="region" aria-labelledby="pianoInvestimentiCodificaHeading">
            <div class="accordion-body">
                <Siar:DataGridAgid ID="dgCodifica" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" ShowFooter="true">
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
</div>
