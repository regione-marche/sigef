<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PianoInvestimentiAggregazioneDomanda.ascx.cs"
    Inherits="web.CONTROLS.PianoInvestimentiAggregazioneDomanda" %>
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
    <h2 class="accordion-header " id="headingAggregazioneDomanda">
        <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseAggregazioneDomanda" aria-expanded="false" aria-controls="collapseAggregazioneDomanda">
            Investimenti ammessi a finanziamento raggruppati per impresa:
        </button>
    </h2>
    <div id="collapseAggregazioneDomanda" class="accordion-collapse collapse" data-bs-parent="#accordionExampleHa" role="region" aria-labelledby="headingAggregazioneDomanda">
        <div class="accordion-body">
            <div class="col-sm-12">
                <Siar:DataGridAgid ID="dgAggregazione" runat="server" AutoGenerateColumns="False" ShowFooter="true" CssClass="table table-striped">                    
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
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo pagamento richiesto" DataField="impRichiestoSum"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right"/>
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
                            <ItemStyle Font-Bold="true" Font-Size="12px" HorizontalAlign="right"/>
                        </asp:BoundColumn>
                        <%--<asp:BoundColumn HeaderText="Disavanzo richiesto/ ammesso (limite 10% costo investimento)"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Disavanzo contributo richiesto/ ammesso (limite 10% costo investimento)"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo extra a copertura economie" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Rimanenza da assegnare/ coprire" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="% rendiconta -zione ammissibile">
                            <ItemStyle Font-Bold="true" Font-Size="12px" HorizontalAlign="right" Width="70px" />
                        </asp:BoundColumn>--%>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdInvestimento" ButtonType="ImageButton" ButtonText="Richiesta integrazione"
                            JsFunction="" HeaderText="Richiesta integrazione" ButtonImage="warning.png">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGridAgid>
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
</div>