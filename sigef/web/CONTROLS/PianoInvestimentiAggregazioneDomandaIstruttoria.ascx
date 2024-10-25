<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PianoInvestimentiAggregazioneDomandaIstruttoria.ascx.cs"
    Inherits="web.CONTROLS.PianoInvestimentiAggregazioneDomandaIstruttoria" %>
<%@ Register Src="SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc1" %>

<script type="text/javascript"><!--

    function espandiAggregazionePost() { var codici_espansi = $('[id$=hdnDgAggregazioneEspansione]').val().split('|'); $('[id$=hdnDgAggregazioneEspansione]').val(''); for (var i = 0; i < codici_espansi.length; i++) espandiProgrammazione(codici_espansi[i]); }
        function espandiAggregazione(path_label) {
            var tr = $('[PathLabel=' + path_label + ']'), espandi = !eval($(tr).attr("ElemEspanso")); var arr = $('[PathLabel^=' + path_label + '][PathLabel!=' + path_label + ']');
            for (var i = 0; i < arr.length; i++) { var pl = $(arr[i]).attr('PathLabel'); if (espandi == true) { if (pl.length > path_label.length) arr[i].style.display = ''; } else { arr[i].style.display = 'none'; $(arr[i]).attr("ElemEspanso", false); aggiornaHiddenEspansione($(arr[i]).attr("PathLabel"), false); } }
            $(tr).attr("ElemEspanso", espandi); aggiornaHiddenEspansione(path_label, espandi);
        }
    function aggiornaHiddenEspansione(path_label, insert) { if (path_label != '') { var codici_espansi = $('[id$=hdnDgAggregazioneEspansione]').val().split('|'); if (insert == true) codici_espansi.push(path_label); else if (codici_espansi.indexOf(path_label) >= 0) codici_espansi.splice(codici_espansi.indexOf(path_label), 1); $('[id$=hdnDgAggregazioneEspansione]').val(codici_espansi.join('|')); } }

    function MostraNascondiDivAggreg() {
            var div;
            var img;
            div = $('[id$=divMostraAggregazioni]')[0];
            img = $('[id$=imgMostraAggregazioni]')[0];
            

            if (img.style.transform == "")
                img.style.transform = "rotate(180deg)";
            else
                img.style.transform = "";

            if (div.style.display === "none") {
                div.style.display = "block";
            } else {
                div.style.display = "none";
            }
        }

</script>

<div style="display: none">
    <asp:HiddenField ID="hdnDgAggregazioneEspansione" runat="server" />
</div>

<div class="dBox" id="dBoxAggregazione" runat="server">
    <div class="separatore" style="cursor: pointer; padding-bottom:3px;" onclick="MostraNascondiDivAggreg();">
            <img id="imgMostraAggregazioni" runat="server"  style=" width: 23px; height: 23px;" />
            Investimenti ammessi a finanziamento raggruppati per impresa:
        </div>
    <div class="dSezione" id="divMostraAggregazioni">
        <div class="dContenutoFloat">
            <div >
                <Siar:DataGrid ID="dgAggregazione" runat="server" AutoGenerateColumns="False" Width="100%" ShowFooter="true">
                    <ItemStyle Height="32px"  />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <asp:BoundColumn HeaderText="Descrizione"><ItemStyle HorizontalAlign="right" Width="400px" /></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Costo" DataField="Costo"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo" DataField="Contributo"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn   HeaderText="% Quota contributo">
                             <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo pagamento richiesto" DataField="impRichiestoSum"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo pagamento richiesto" DataField="contrRichiestoSum"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo pagamento ammissibile" DataField="impAmmessoSum"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo pagamento ammissibile" DataField="contrAmmessoSum"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="% rendicon- tazione">
                            <ItemStyle Font-Bold="true" Font-Size="12px" HorizontalAlign="right" Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Disavanzo richiesto/ ammesso (limite 10% costo investimento)"
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
                        </asp:BoundColumn>
                        <asp:BoundColumn >
                             <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
                <table width="100%" id="tbLegendaInvestimenti" runat="server" visible="false">
                    <tr>
                        <td>
                            (**) = contributo troncato per superamento <b>massimali</b> di domanda
                        </td>
                        <td align="right">
                            (***) = bando a <b>quota fissa</b>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</div>