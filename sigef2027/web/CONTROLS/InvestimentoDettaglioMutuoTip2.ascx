<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InvestimentoDettaglioMutuoTip2.ascx.cs"
    Inherits="web.CONTROLS.InvestimentoDettaglioMutuoTip2" %>

<script type="text/javascript"><!--
    function ctrlCheckBox(obj) {
        $(obj).children().children().children(':checkbox')[0].checked=!$(obj).children().children().children(':checkbox')[0].checked;
        $('[id$=btnPostBack]').click();
    }
//--></script>

<table width='100%' cellpadding="0" cellspacing="0">
    <tr>
        <td>
            &nbsp;
            <div style="display: none">
                <Siar:Button ID="btnPostBack" runat="server" OnClick="btnPostBack_Click" CausesValidation="False" /></div>
        </td>
    </tr>
    <tr>
        <td class="paragrafo">
            &nbsp;Selezione ID domanda di aiuto PSR:
        </td>
    </tr>
    <tr>
        <td>
            <Siar:DataGrid ID="dgDomandaPsr" runat="server" Width="100%" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundColumn DataField="Particella" HeaderText="Id domanda"></asp:BoundColumn>
                    <asp:BoundColumn DataField="FoglioCatastale" HeaderText="Misura">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Superficie catastale">
                        <ItemStyle HorizontalAlign="Right" Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Svantaggio" HeaderText="Svantaggio">
                        <ItemStyle Width="200px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Contributo pubblico">
                        <ItemStyle HorizontalAlign="Right" Width="90px" />
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="IdLocalizzazione" Name="chkDomande" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </Siar:CheckColumn>
                </Columns>
            </Siar:DataGrid>&nbsp;
        </td>
    </tr>
    <tr>
        <td align="right" style="padding-right: 50px">
            <input id="btnVisualizzaPianoInvestimentiSelezionata" class="Button" runat="server" style="width: 306px"
                type="button" value="Piano investimenti domanda selezionata" visible="false" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="separatore">
            &nbsp;Dettaglio della spesa:
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td style="width: 18px">
                        &nbsp;
                    </td>
                    <td style="width: 189px">
                        &nbsp;
                    </td>
                    <td style="width: 167px">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 18px">
                    </td>
                    <td style="width: 189px">
                        <strong>&nbsp;Totale spesa di investimento&nbsp;<br />
                            &nbsp;per la domanda selezionata:</strong>
                    </td>
                    <td style="width: 167px">
                        <strong>&nbsp;<br />
                            &nbsp;Ammontare del mutuo:</strong>
                    </td>
                    <td>
                        <strong>
                            <br />
                            &nbsp;Tasso di riferimento %:</strong>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="width: 18px">
                        <strong>&nbsp; €</strong>
                    </td>
                    <td style="width: 189px">
                        <Siar:CurrencyBox ID="txtAmmontareInvestimenti" runat="server" Width="120px" ReadOnly="True" />
                    </td>
                    <td style="width: 167px">
                        <Siar:CurrencyBox ID="txtAmmontare" runat="server" NomeCampo="Ammontare del mutuo"
                            Obbligatorio="True" Width="120px" />
                    </td>
                    <td>
                        <Siar:CurrencyBox ID="txtAttualizzazione" runat="server" NomeCampo="Tasso di riferimento"
                            Obbligatorio="True" Width="55px" />
                        <a href="http://www.abi.it/jhtml/home/prodottiServizi/crediti/crediti.jhtml" target="_blank">
                            visualizza tabella dei tassi attuali</a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 18px">
                        &nbsp;
                    </td>
                    <td style="width: 189px">
                        <strong>
                            <br />
                            &nbsp;Durata anni:</strong>
                    </td>
                    <td style="width: 167px">
                        <strong>
                            <br />
                            &nbsp;Concorso regionale %:</strong>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 18px">
                        &nbsp;
                    </td>
                    <td style="width: 189px">
                        <Siar:ComboBase ID="lstAnni" runat="server" NomeCampo="Durata in anni" Obbligatorio="True">
                        </Siar:ComboBase>
                    </td>
                    <td style="width: 167px">
                        <Siar:CurrencyBox ID="txtTasso" runat="server" Width="55px" ReadOnly="True" />
                    </td>
                    <td>
                        <Siar:Button ID="btnCalcolaContributo" runat="server" CausesValidation="true" Modifica="False"
                            OnClick="btnCalcolaContributo_Click" Text="Calcola contributo" Width="159px" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 18px">
                        &nbsp;
                    </td>
                    <td style="width: 189px">
                        <strong>
                            <br />
                            &nbsp;Numero rate annuali:</strong>
                    </td>
                    <td style="width: 167px">
                        <strong>
                            <br />
                            &nbsp;Contributo ammissibile €:</strong>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 18px">
                    </td>
                    <td style="width: 189px">
                        <Siar:CurrencyBox ID="txtRateAnnuali" runat="server" NomeCampo="NumeroRate" ReadOnly="True"
                            Width="73px" />
                    </td>
                    <td style="width: 167px">
                        <Siar:CurrencyBox ID="txtContributoAmmissibile" runat="server" ReadOnly="True" Width="120px" />
                    </td>
                    <td rowspan="2" style="color: red; font-weight: bold" id="rowContributoMessaggio"
                        runat="server">
                    </td>
                </tr>
                <tr>
                    <td style="width: 18px">
                    </td>
                    <td style="width: 189px">
                        &nbsp;
                    </td>
                    <td style="width: 167px">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="separatore">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" id="tableValutazione" runat="server" visible="false">
                <tr>
                    <td align="center">
                        Valutazione dell`investimento (a cura del funzionario istruttore):
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <Siar:TextArea ID="txtValutazioneLunga" runat="server" NomeCampo="Valutazione investimento"
                            Rows="7" Width="706px" ReadOnly="True" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <input id="btnVisualizzaOriginale" runat="server" class="Button" style="width: 250px"
                            type="button" value="Visualizza investimento originale" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="divStoricoInvestimento" style="display: none; width: 100%">
                            &nbsp;
                        </div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
