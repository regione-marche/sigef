<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PianoInvestimentiInterventoDomandaIstruttoria.ascx.cs"
    Inherits="web.CONTROLS.PianoInvestimentiInterventoDomandaIstruttoria" %>
<%@ Register Src="SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc1" %>

<script type="text/javascript"><!--

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

<div class="accordion-item" id="dBoxInterventi" runat="server">
    <h2 class="accordion-header " id="pianoInvestimentiInterventoHeading">
        <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapsePianoInvestimentiIntervento" aria-expanded="false" aria-controls="collapsePianoInvestimentiIntervento">
            Investimenti ammessi a finanziamento raggruppati per intervento:
        </button>
    </h2>
    <div id="collapsePianoInvestimentiIntervento" class="accordion-collapse collapse" role="region" aria-labelledby="pianoInvestimentiInterventoHeading">
        <div class="accordion-body">
            <div class="table-responsive">
                <Siar:DataGridAgid ID="dgInterventi" runat="server" AutoGenerateColumns="False" ShowFooter="true"  CssClass="table table-striped">                    
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <asp:BoundColumn HeaderText="Descrizione">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Costo" DataField="Costo"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo" DataField="Contributo"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="% Quota contributo">
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo pagamento richiesto" DataField="impRichiestoSum"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo pagamento richiesto" DataField="contrRichiestoSum"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo pagamento ammissibile" DataField="impAmmessoSum"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo pagamento ammissibile" DataField="contrAmmessoSum"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="% rendicon- tazione">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="false" HeaderText="Disavanzo richiesto/ ammesso (limite 10% costo investimento)"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="false" HeaderText="Disavanzo contributo richiesto/ ammesso (limite 10% costo investimento)"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo extra a copertura economie" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="false" HeaderText="Rimanenza da assegnare/ coprire" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="% rendiconta -zione ammissibile">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
            <table width="100%" id="tbLegendaInvestimenti" runat="server" visible="false">
                <tr>
                    <td>(**) = contributo troncato per superamento <b>massimali</b> di domanda
                        </td>
                    <td align="right">(***) = bando a <b>quota fissa</b>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>

