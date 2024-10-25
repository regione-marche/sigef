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

    function MostraNascondiDivCodifica() {
        var div;
        var img;
        div = $('[id$=divMostraCodifica]')[0];
        img = $('[id$=imgMostraCodifica]')[0];


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
    <asp:HiddenField ID="hdnDgCodificaEspansione" runat="server" />
</div>

<div class="dBox" id="dBoxCodifica" runat="server">
    <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDivCodifica();">
        <img id="imgMostraCodifica" runat="server" style="width: 23px; height: 23px;" />
        Piano degli investimenti raggruppato per codifica
    </div>
    <div class="dSezione" id="divMostraCodifica">
        <div class="dContenutoFloat">
            <div>
                <Siar:DataGrid ID="dgCodifica" runat="server" AutoGenerateColumns="False" Width="100%" ShowFooter="true">
                    <ItemStyle Height="32px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <asp:BoundColumn HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Costo" DataField="Costo"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo" DataField="Contributo"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="% Quota contributo">
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <%--<Siar:JsButtonColumn Arguments="Id" JsFunction="mostraDettaglioProgrammazione" ButtonType="ImageButton"
                            ButtonText="Dettaglio elemento" ButtonImage="lente.png">
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>--%>
                    </Columns>
                </Siar:DataGrid>
                <table width="100%" id="tbLegendaInvestimenti" runat="server" visible="false">
                    <tr>
                        <td>(**) = contributo troncato per superamento <b>massimali</b> di domanda
                                                </td>
                        <td align="right">(***) = contributo a <b>quota fissa</b>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</div>
