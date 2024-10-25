<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="PianoSviluppo.aspx.cs" Inherits="web.Private.PPagamento.PianoSviluppo" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function calc_totals(anno) {
            var a1 = FromCurrencyToNumber($('[id$=txtA1' + anno + '_text]').val());
            var b1 = FromCurrencyToNumber($('[id$=txtB1' + anno + '_text]').val());
            var b2 = FromCurrencyToNumber($('[id$=txtB2' + anno + '_text]').val());
            var b3 = FromCurrencyToNumber($('[id$=txtB3' + anno + '_text]').val());
            var c1 = FromCurrencyToNumber($('[id$=txtC1' + anno + '_text]').val());
            var c2 = FromCurrencyToNumber($('[id$=txtC2' + anno + '_text]').val());
            var d1 = FromCurrencyToNumber($('[id$=txtD1' + anno + '_text]').val());
            var d2 = FromCurrencyToNumber($('[id$=txtD2' + anno + '_text]').val());

            var TotFabbisogno = a1 + c1 + c2;
            $('[id$=txtE' + anno + '_text]').val(FromNumberToCurrency(TotFabbisogno));

            var TotCopertura = b1 + b2 + b3 + d1 + d2;
            $('[id$=txtF' + anno + '_text]').val(FromNumberToCurrency(TotCopertura));

            var SaldoNetto = TotCopertura - TotFabbisogno;
            SaldoNetto = Math.round(SaldoNetto * 100) / 100;
            while (SaldoNetto.toString().indexOf('.') > 0) SaldoNetto = SaldoNetto.toString().replace('.', ',');
            $('[id$=txtI' + anno + '_text]').val(SaldoNetto);
        }

        function TotaleRiga(index) {
            var i = 1;
            var tot = 0;
            while (i <= 5) {
                var a1 = FromCurrencyToNumber($('[id$=txt' + index + 'Anno' + i + '_text]').val());
                tot += a1;
                i++;
            }
            var totale = $('[id$=lbl' + index + 'Anno_text]').text(FromNumberToCurrency(tot));
            var totE = 0;
            var totF = 0;
            var totI = 0;
            var c = 1;
            while (c <= 5) {
                var e = FromCurrencyToNumber($('[id$=txtEAnno' + c + '_text]').val());
                var f = FromCurrencyToNumber($('[id$=txtFAnno' + c + '_text]').val());
                var i = FromCurrencyToNumber($('[id$=txtIAnno' + c + '_text]').val());
                totE += e;
                totF += f;
                totI += i;
                c++;
            }
            $('[id$=lblEAnno_text]').text(FromNumberToCurrency(totE));
            $('[id$=lblFAnno_text]').text(FromNumberToCurrency(totF));
            $('[id$=lblIAnno_text]').text(FromNumberToCurrency(totI));
        }
        function annoinseriti(ev) {
            var c = 0;
            var anno = $('[id*=txtannoPiano][id$=_text]')
            if (anno.length > 0) {
                for (var i = 0; i < anno.length; i++) {
                    if (FromCurrencyToNumber(anno[i].value) != '')
                        c++;
                }
                if (c < 2) {
                    alert("Attenzione! \nImpossibile salvare il piano di sviluppo poichè non sono stati specificati gli anni.")
                    return stopEvent(ev);
                }
            }
            controlloAnno();
       } 
        
        function controlloAnno() {
            var anno = $('[id*=txtannoPiano][id$=_text]')
            var curr = new Date();
            aa = curr.getFullYear() ;
            if (anno.length > 0) {
                for (var i = 0; i < anno.length; i++) {
                    ai = FromCurrencyToNumber(anno[i].value)
                    if (ai != '') {
                        if (ai < aa - 3 || ai > aa + 3) {
                            alert("Attenzione! \nNon è stato definito l'intervallo di tempo correttamente.")
                           event.returnValue=false;
                        }
                    }
                }
            }
        }
    </script>

    <uc1:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
    &nbsp;
    <table class="tableNoTab" id="tbValutazione" runat="server" style="width: 900px;">
        <tr>
            <td>
                <br />
                <table style="width: 100%" runat="server" id="tdPianoSviluppo">
                    <tr>
                        <td class="separatore" style="width: 240px">
                            FABBISOGNI/COPERTURE
                        </td>
                        <td style="text-align: center; width: 110px;" class="separatore">
                            Anno N&nbsp;
                        </td>
                        <td style="text-align: center; width: 110px;" class="separatore">
                            Anno N+1&nbsp;
                        </td>
                        <td style="text-align: center; width: 110px;" class="separatore">
                            Anno N+2&nbsp;
                        </td>
                        <td style="text-align: center; width: 110px;" class="separatore">
                            Anno N+3&nbsp;
                        </td>
                        <td style="text-align: center; width: 110px;" class="separatore">
                            Anno N+4 &nbsp;
                        </td>
                        <td class="separatore" style="text-align: center; width: 110px;" align="right">
                            TOTALE
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 240px">
                        </td>
                        <td style="text-align: center;">
                            <Siar:Hidden ID="hdnIdPiano1" runat="server" />
                            <Siar:TextBox  ID="txtannoPiano1" runat="server" Width="33px" MaxLength="4" />
                        </td>
                        <td style="text-align: center">
                            <Siar:Hidden ID="hdnIdPiano2" runat="server" />
                            <Siar:TextBox  ID="txtannoPiano2" runat="server" Width="33px" MaxLength="4" />
                        </td>
                        <td style="text-align: center">
                            <Siar:Hidden ID="hdnIdPiano3" runat="server" />
                            <Siar:TextBox  ID="txtannoPiano3" runat="server" Width="33px" MaxLength="4" />
                        </td>
                        <td style="text-align: center">
                            <Siar:Hidden ID="hdnIdPiano4" runat="server" />
                            <Siar:TextBox  ID="txtannoPiano4" runat="server" Width="33px" MaxLength="4" />
                        </td>
                        <td style="text-align: center; width: 108px;">
                            <Siar:Hidden ID="hdnIdPiano5" runat="server" />
                            <Siar:TextBox  ID="txtannoPiano5" runat="server" Width="33px" MaxLength="4" />
                        </td>
                        <td style="text-align: center; width: 110px;" align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; width: 240px;">
                            <br />
                            INVESTIMENTO
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-decoration: underline; width: 240px;">
                            A) Fabbisogno
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td style="width: 110px" align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px; width: 240px;">
                            A1) Esborso per l'investimento
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtA1Anno1" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtA1Anno2" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtA1Anno3" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtA1Anno4" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtA1Anno5" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td style="width: 110px" align="right">
                            <b>
                                <Siar:Label ID="lblA1Anno" runat="server" CurrencyFormat="{0:C}">
                                </Siar:Label>
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-decoration: underline; width: 240px;">
                            B) Copertura
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td style="width: 110px" align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px; width: 240px;">
                            B1) Mezzi propri
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtB1Anno1" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtB1Anno2" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtB1Anno3" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtB1Anno4" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtB1Anno5" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td style="width: 110px" align="right">
                            <b>
                                <Siar:Label ID="lblB1Anno" runat="server" CurrencyFormat="{0:C}">
                                </Siar:Label>
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px; width: 240px;">
                            B2) Risorse di terzi
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtB2Anno1" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtB2Anno2" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtB2Anno3" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtB2Anno4" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtB2Anno5" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td style="width: 110px" align="right">
                            <b>
                                <Siar:Label ID="lblB2Anno" runat="server" CurrencyFormat="{0:C}">
                                </Siar:Label>
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px; width: 240px;">
                            B3) Contributi pubblici
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtB3Anno1" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtB3Anno2" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtB3Anno3" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtB3Anno4" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtB3Anno5" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td style="width: 110px" align="right">
                            <b>
                                <Siar:Label ID="lblB3Anno" runat="server">
                                </Siar:Label>
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px; width: 240px;">
                            <br />
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td style="width: 110px" align="right">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="separatore" colspan="7">
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; width: 240px;">
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td style="width: 110px" align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; width: 240px;">
                            <br />
                            FLUSSI DI CASSA DELLA GESTIONE
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td style="width: 110px" align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-decoration: underline; width: 240px;">
                            C) Fabbisogno
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td style="width: 110px" align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px; width: 240px;">
                            C1) Esborsi dovuti alla gestione generati dagli investimenti
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtC1Anno1" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtC1Anno2" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtC1Anno3" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtC1Anno4" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtC1Anno5" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td style="width: 110px" align="right">
                            <b>
                                <Siar:Label ID="lblC1Anno" runat="server">
                                </Siar:Label>
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px; width: 240px;">
                            C2) Rimborso del debito (quota capitale e quota interessi)
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtC2Anno1" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtC2Anno2" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtC2Anno3" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtC2Anno4" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtC2Anno5" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td style="width: 110px" align="right">
                            <b>
                                <Siar:Label ID="lblC2Anno" runat="server">
                                </Siar:Label>
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-decoration: underline; width: 240px;">
                            D) Copertura
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td style="width: 110px" align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 240px">
                            &nbsp;&nbsp; D1) Entrata dalla gestione
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtD1Anno1" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtD1Anno2" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtD1Anno3" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtD1Anno4" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtD1Anno5" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td style="width: 110px" align="right">
                            <b>
                                <Siar:Label ID="lblD1Anno" runat="server">
                                </Siar:Label>
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 240px">
                            &nbsp;&nbsp; D2) Altre coperture
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtD2Anno1" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtD2Anno2" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtD2Anno3" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtD2Anno4" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtD2Anno5" runat="server" Width="90px" Text="0,00" />
                        </td>
                        <td style="width: 110px" align="right">
                            <b>
                                <Siar:Label ID="lblD2Anno" runat="server">
                                </Siar:Label>
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 240px">
                            <br />
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td style="width: 110px" align="right">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="separatore" colspan="7">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 240px">
                            <br />
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td style="width: 110px" align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 240px">
                            E) Totale fabbisogno (A+C)
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtEAnno1" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtEAnno2" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtEAnno3" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtEAnno4" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtEAnno5" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                        </td>
                        <td style="width: 110px" align="right">
                            <Siar:Label ID="lblEAnno" runat="server">
                            </Siar:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 240px">
                            F) Totale copertura (B+D)
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtFAnno1" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtFAnno2" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtFAnno3" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtFAnno4" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtFAnno5" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                        </td>
                        <td style="width: 110px" align="right">
                            <Siar:Label ID="lblFAnno" runat="server">
                            </Siar:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 240px">
                            I) SALDO NETTO (F-E)
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtIAnno1" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtIAnno2" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtIAnno3" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtIAnno4" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                        </td>
                        <td style="width: 110px">
                            <Siar:CurrencyBox ID="txtIAnno5" runat="server" Width="90px" Text="0,00" ReadOnly="True" />
                        </td>
                        <td style="width: 110px" align="right">
                            <Siar:Label ID="lblIAnno" runat="server">
                            </Siar:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 240px">
                            <br />
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td style="width: 110px">
                        </td>
                        <td style="width: 110px">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="separatore" colspan="7">
                        </td>
                    </tr>
                </table>
                <br />
                <div style="text-align: center;">
                    <br />
                    &nbsp; &nbsp;&nbsp;
                    <Siar:Button ID="btnSalva" runat="server" Text="Salva"  Modifica="True" Width="130px" OnClick="btnSalva_Click" OnClientClick="return annoinseriti(event)" />
                    &nbsp;&nbsp;
                    <input id="btnBack" class="Button" style="width: 180px" type="button" value="Indietro"
                        onclick="javascript:location='BusinessPlan.aspx'" /><br />
                    <br />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
