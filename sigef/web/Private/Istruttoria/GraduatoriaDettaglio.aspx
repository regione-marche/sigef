<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits=" web.Private.Istruttoria.GraduatoriaDettaglio" CodeBehind="GraduatoriaDettaglio.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function ctrlImportiRiserva(ev) {//controlli per IE, per firefox li faccio nel .cs
            var contributo_domanda=FromCurrencyToNumber($('[id$=txtContributoTotaleDomanda]').val());
            var importo_disponibile=FromCurrencyToNumber($('[id$=txtFondoRiservaDisponibile]').val());
            var importo_domanda=FromCurrencyToNumber($('[id$=txtFondoRiservaDomanda]').val());
            if (importo_domanda > contributo_domanda) {
                alert('L`ammontare inserito non può superare il contributo totale di domanda.');
                return stopEvent(ev); 
            }
            if (importo_domanda > importo_disponibile) {
                alert('L`ammontare inserito non può superare il fondo di riserva disponibile.');
                return stopEvent(ev); 
            }
        }
//--></script>

    <br />
    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <br />
    <table class="tableNoTab" width="1000">
        <tr>
            <td class="separatore_big">
                Dettaglio di finanziabilità della domanda
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td style="width: 480px" class="testo_pagina">
                            A destra è illustrato il <b>dettaglio di finanziabilità</b> per ogni misura attivata
                            <br />
                            dalla domanda. Le misure per le quali non sono stati inseriti investimenti<br />
                            &nbsp;<b>non </b>compaiono nello schema.<br />
                            <br />
                            &nbsp;- La domanda è <b>
                                <Siar:Label ID="lblFinanziabilita" runat="server">
                                </Siar:Label>
                            </b>
                        </td>
                        <td>
                            <Siar:DataGrid ID="dg" runat="server" Width="500" CssClass="tabella" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                                        <ItemStyle Font-Bold="true" HorizontalAlign="center" Width="100px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="CostoTotale" HeaderText="Spesa ammessa" DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="right" Width="120px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ContributoDiMisura" HeaderText="Contributo ammesso" DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="right" Width="120px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ContributoRimanente" HeaderText="Ammontare finanziario rimanente di misura"
                                        DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="right" Width="120px" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore_light">
                &nbsp;Finanziabilità parziale
            </td>
        </tr>
        <tr>
            <td style="height: 83px" align="center">
                <Siar:Button ID="btnConferma" runat="server" OnClick="btnConferma_Click" Text="Conferma"
                             Width="180px" Modifica="true" />
                &nbsp; &nbsp;
                <Siar:Button ID="btnAnnullaContributo" Modifica="true" runat="server" OnClick="btnAnnullaContributo_Click" 
                             Text="Annulla contributo" Width="180px" />
                &nbsp; &nbsp;
                <input id="btnRinuncia" class="Button" style="width: 180px" disabled="disabled" type="button" 
                       value="Rinuncia" onclick="location='ComunicazioniEntrata.aspx'" />
            </td>
        </tr>
        <tr>
            <td class="separatore_light">
                &nbsp; Utilizzo fondi di riserva:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <table style="width: 100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 15px">
                            &nbsp;
                        </td>
                        <td style="width: 203px">
                            Ammontare totale da bando:
                        </td>
                        <td style="width: 215px">
                            Ammontare utilizzato:
                        </td>
                        <td>
                            Ammontare ancora disponibile:
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15px" align="center" valign="bottom">
                            <b>€</b>
                        </td>
                        <td style="width: 203px">
                            <Siar:CurrencyBox ID="txtFondoRiservaTotale" runat="server" Width="185px" ReadOnly="True" />
                        </td>
                        <td style="width: 215px">
                            <Siar:CurrencyBox ID="txtFondoRiservaUtilizzato" runat="server" Width="185px" ReadOnly="True" />
                        </td>
                        <td>
                            <Siar:CurrencyBox ID="txtFondoRiservaDisponibile" runat="server" Width="185px" ReadOnly="True" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15px">
                            &nbsp;
                        </td>
                        <td style="width: 203px">
                            &nbsp;<br />
                            Contributo totale domanda:
                        </td>
                        <td style="width: 215px">
                            <b>&nbsp;<br />
                                Contributo domanda da fondi riserva:</b>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15px" align="center" valign="bottom">
                            <b>€</b>
                        </td>
                        <td style="width: 203px">
                            <Siar:CurrencyBox ID="txtContributoTotaleDomanda" runat="server" Width="185px" ReadOnly="True" />
                        </td>
                        <td style="width: 215px">
                            <Siar:CurrencyBox ID="txtFondoRiservaDomanda" runat="server" Width="185px" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 69px" align="center">
                <Siar:Button ID="btnUtilizzaRiserva" runat="server" OnClick="btnUtilizzaRiserva_Click" Text="Utilizza riserva" 
                             Width="180px" Modifica="true" OnClientClick="return ctrlImportiRiserva(event);" />
                &nbsp;&nbsp;&nbsp;
                <Siar:Button ID="btnRevocaRiserva" runat="server" OnClick="btnRevocaRiserva_Click"
                             Text="Revoca riserva" Width="180px" Modifica="true" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input id="btnBack" class="Button" style="width: 161px" type="button" value="Indietro"
                       onclick="location='graduatoria.aspx'" />
            </td>
        </tr>
    </table>
</asp:Content>
