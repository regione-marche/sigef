<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IstruttoriaPianoInvestimentiRettificaSaldo" CodeBehind="IstruttoriaPianoInvestimentiRettificaSaldo.aspx.cs" %>

<%@ Register Src="~/CONTROLS/SNCVisualizzaProtocollo.ascx" TagName="SNCVisualizzaProtocollo"    TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/VisualizzaReport.ascx" TagName="VisualizzaReport" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc3" %>
<%@ Register Src="~/CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
        <script type="text/javascript"><!--
            
            function MostraNascondiDivPiano() {
                var divPiano;
                var imgPiano;
                divPiano = $('[id$=divMostraPiano]')[0];
                imgPiano = $('[id$=imgMostraPiano]')[0];


                if (imgPiano.style.transform == "")
                    imgPiano.style.transform = "rotate(180deg)";
                else
                    imgPiano.style.transform = "";

                if (divPiano.style.display === "none") {
                    divPiano.style.display = "block";
                } else {
                    divPiano.style.display = "none";
                }
            }

            function eliminaRettifica(ev) {
                if (!confirm('Attenzione! Eliminare la domanda di concessione di ulteriori contributi?'))
                    return stopEvent(ev);
                else
                    $('[id$=btnEliminaRettifica]').click();
            }
           
            //nascosta.val("true");
            //} else {
            //        divModale[0].style.width = "40%";
            //    divModale.css({
            //        'left': scrollLeft + ((clientWidth - divModale[0].offsetWidth) / 2),

            //});
            
            //nascosta.val("false");

//--></script>

    <div style="display: none">
        <asp:Button ID="btnEliminaRettifica" runat="server" OnClick="btnEliminaRettifica_Click" />
    </div>
    <table cellpadding="0" cellspacing="0" class="tableNoTab" width="900px">
        <tr>
            <td >
                <table width="100%">
                    <tr>
                        <td align="left">
                            <table border="1" cellspacing="0" style="width: 100%; border-collapse: collapse">
                                <tr class="TESTA1">
                                    <td colspan="4" align="center">
                                        DOMANDA DI AIUTO
                                    </td>
                                    <td align="center" colspan="3">
                                        DOMANDA DI PAGAMENTO
                                    </td>
                                </tr>
                                <tr class="TESTA">
                                    <td style="width: 8%">
                                        Numero
                                    </td>
                                    <td style="width: 16%">
                                        Stato
                                    </td>
                                    <td style="width: 11%">
                                        Visualizza documento firmato
                                    </td>
                                    <td style="width: 11%">
                                        Visualizza situazione attuale
                                    </td>
                                    <td style="width: 11%">
                                        Stato
                                    </td>
                                    <td style="width: 19%">
                                        Operatore
                                    </td>
                                    <td style="width: 12%">
                                        Visualizza documento firmato
                                    </td>
                                </tr>
                                <tr class="DataGridRow" style="height: 26px">
                                    <td align="center" style="font-weight: bold; font-size: 12px; width: 8%">
                                        <asp:Label ID="lblNumero" runat="server">
                                        </asp:Label>
                                    </td>
                                    <td align="center" style="font-weight: bold; width: 16%">
                                        <asp:Label ID="lblStato" runat="server">
                                        </asp:Label>
                                    </td>
                                    <td align="center" style="width: 11%">
                                        <uc1:SNCVisualizzaProtocollo ID="ucSNCVPPDomanda" runat="server" TipoVisualizzazione="Immagine"
                                            VisualizzaMenu="true" />
                                    </td>
                                    <td align="center" style="width: 11%">
                                        <uc2:VisualizzaReport ID="ucVRPDomandaAttuale" runat="server" ReportFormat="PDF"
                                            ReportViewOptions="Immagine" Text="Visualizza situazione attuale" />
                                    </td>
                                    <td align="center" style="width: 11%">
                                        <asp:Label ID="lblStatoPagamento" runat="server"></asp:Label>
                                    </td>
                                    <td align="center" style="width: 19%">
                                        <asp:Label ID="lblOperatore" runat="server"></asp:Label>
                                    </td>
                                    <td align="center" style="width: 12%">
                                        <uc1:SNCVisualizzaProtocollo ID="ucSNCVPPagamento" runat="server" TipoVisualizzazione="Immagine"
                                            VisualizzaMenu="true" />
                                    </td>
                                </tr>
                            </table>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 20px">
                            <table cellpadding="0" cellspacing="0" style="border-top: black 1px solid; border-bottom: black 1px solid"
                                width="100%">
                                <tr style="font-size: 11px; background-color: #fefeee">
                                    <td style="width: 140px; height: 18px">
                                        <strong>&nbsp;C.F./P.Iva:</strong>
                                        <Siar:Label ID="lblCodiceFiscale" runat="server">
                                        </Siar:Label>
                                    </td>
                                    <td>
                                        <strong>&nbsp;Ragione Sociale:</strong>&nbsp;
                                        <Siar:Label ID="lblRagioneSociale" runat="server">
                                        </Siar:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 25px">
                            <table cellpadding="0" cellspacing="0" style="border-top: black 1px solid; border-bottom: black 1px solid"
                                width="100%">
                                <tr style="font-size: 12px; background-color: #fefeee">
                                    <td colspan="2">
                                        DOMANDA DI PAGAMENTO - MODALITA'&nbsp; <strong>
                                            <Siar:Label ID="lblTipoPagamento" runat="server">
                                            </Siar:Label>
                                        </strong>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <input id="btnBack" runat="server" class="Button" style="width: 200px" type="button"
                              onclick="location = '../PPagamento/GestioneLavori.aspx'" value="Torna a Gestioni Lavori" />
                            <Siar:Button ID="btnFirma" runat="server" Modifica="False" OnClick="btnFirma_Click"
                                Text="Firma e invia al protocollo" Width="200px" Enabled="False" />
                            <Siar:Button ID="btnElimina" runat="server" Modifica="False" OnClientClick="return eliminaRettifica(event);"
                                Text="Elimina la richiesta ulteriori contributi" Width="220px" Enabled="False" />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
    <table width="1300" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                ISTRUTTORIA DEL PIANO DEGLI INVESTIMENTI
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td style="width: 400px" class="testo_pagina">
                            Di seguito vengono elencati tutti gli investimenti presenti nella domanda di saldo istruita
                            <br />
                            Per istruire i pagamenti delle spese sostenute per uno specifico investimento fare click sulla riga relativa.
                            <br />
                            &nbsp;
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <Siar:Button ID="btnEstrai" runat="server" Text="Estrai in XLS" Width="120px" OnClick="btnEstrai_Click" />
                                        
                                        <br /><br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="center" valign="top" style="width: 875px; text-align: left">
                            <table width="100%">
                                <tr>
                                    <td class="separatore_light" colspan="3">
                                        Riepilogo degli importi richiesti nell'attuale domanda di pagamento:
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table style="width: 100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;&nbsp; Importo richiesto:<br />
                                                    &euro;
                                                    <Siar:CurrencyBox ID="txtTotaleImportoRichiesto" runat="server" ReadOnly="True" Width="110px" />
                                                    %
                                                    <Siar:QuotaBox ID="txtQuotaImportoRichiesta" runat="server" NrDecimali="12" ReadOnly="True" Width="50px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;&nbsp; Importo ammesso:<br />
                                                    &euro;
                                                    <Siar:CurrencyBox ID="txtTotaleImportoAmmesso" runat="server" ReadOnly="True" Width="110px" />
                                                    %
                                                    <Siar:QuotaBox ID="txtQuotaImportoAmmessa" runat="server" NrDecimali="12" ReadOnly="True" Width="50px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top" style="border-left: solid 1px black; padding-left: 10px">
                                        <table style="width: 100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    &nbsp; &nbsp;Contributo richiesto:<br />
                                                    &euro;
                                                    <Siar:CurrencyBox ID="txtTotaleContributoRichiesto" runat="server" ReadOnly="True"
                                                        Width="110px" />
                                                    %
                                                    <Siar:QuotaBox ID="txtQuotaContributoRichiesta" runat="server" NrDecimali="12" ReadOnly="True" Width="50px" />
                                                </td>
                                                <td>
                                                    &nbsp; &nbsp;Contributo ammissibile <strong>(A)</strong>:<br />
                                                    &euro;
                                                    <Siar:CurrencyBox ID="txtTotaleContributoAmmissibile" runat="server" ReadOnly="True"
                                                        Width="110px" />
                                                    %
                                                    <Siar:QuotaBox ID="txtQuotaContributoAmmessa" runat="server" NrDecimali="12" ReadOnly="True" Width="50px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>&nbsp; &nbsp; Ammontare sanzioni <strong>(B)</strong>:<br />
                                                    &euro;
                                                    <Siar:CurrencyBox ID="txtImportoSanzione" runat="server" ReadOnly="True" Width="110px" />
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                                                    &nbsp; &nbsp; 
                                                </td>
                                                <td>&nbsp; &nbsp; Recupero anticipo <strong>(C)</strong>:<br />
                                                    &euro;
                                                    <Siar:CurrencyBox ID="txtRecuperoAnticipo" runat="server" ReadOnly="True" Width="110px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>&nbsp; &nbsp; <strong>Contributo ammesso: (A-B-C)</strong><br />
                                                    &euro;
                                                    <Siar:CurrencyBox ID="txtTotaleContributoAmmesso" runat="server" ReadOnly="True" Width="110px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <%--<td valign="top">
                                        <table style="width: 100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                
                                                
                                            </tr>
                                            <tr>
                                                
                                                
                                            </tr>
                                        </table>
                                    </td>--%>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        &nbsp;<br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="separatore_light" colspan="3">
                                        Totali domanda di aiuto:
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <table width="100%">
                                            <tr>
                                                <td style="height: 63px; width: 180px;">
                                                    &nbsp;&nbsp;&nbsp; Costo investimenti:<br />
                                                    &euro;
                                                    <Siar:CurrencyBox ID="txtTotaleInvestimenti" runat="server" ReadOnly="True" Width="140px" />
                                                </td>
                                                <td style="height: 63px; width: 194px;">
                                                    &nbsp;&nbsp;&nbsp; Contributo:<br />
                                                    &euro;
                                                    <Siar:CurrencyBox ID="txtTotaleContributo" runat="server" ReadOnly="True" Width="140px" />
                                                </td>
                                                <td style="height: 63px">
                                                    &nbsp;&nbsp; <b>&nbsp;Contributo erogato fino ad ora:</b><br />
                                                    &euro;
                                                    <Siar:CurrencyBox ID="txtErogato" runat="server" ReadOnly="True" Width="140px" />
                                                    %
                                                    <Siar:QuotaBox ID="txtErogatoQuota" runat="server" NrDecimali="12" ReadOnly="True" Width="60px" />
                                                </td>
                                                <td>
                                                    &nbsp;&nbsp;<b>&nbsp;Contributo da adeguamento 10%:</b><br />
                                                    &euro;
                                                    <Siar:CurrencyBox ID="txtErogatoDisavanzo" runat="server" ReadOnly="True" Width="140px" />
                                                    
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <div class="dBox" id="dBoxPiano" runat="server">
                    <div class="separatore" style="cursor: pointer; padding-bottom:3px;" onclick="MostraNascondiDivPiano();">
                            <img id="imgMostraPiano" runat="server"  style=" width: 23px; height: 23px;" />
                            Investimenti ammessi a finanziamento:
                        </div>
                    <div class="dSezione" id="divMostraPiano">
                        <div class="dContenutoFloat">
                            <div >
                                <table id="tableInvestimenti" width="100%" runat="server" visible="false">
                                    <tr>
                                        <td style="padding-bottom: 20px">
                                            <Siar:DataGrid ID="dgInvestimenti" runat="server" AutoGenerateColumns="False" PageSize="20"
                                                Width="100%">
                                                <ItemStyle Height="30px" />
                                                <Columns>
                                                    <Siar:NumberColumn HeaderText="Nr.">
                                                        <FooterStyle HorizontalAlign="center" Width="40px" />
                                                        <ItemStyle HorizontalAlign="center" Width="40px" />
                                                    </Siar:NumberColumn>
                                                    <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                                        <ItemStyle HorizontalAlign="center" Width="100px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Descrizione"></asp:BoundColumn>
                                                    <Siar:ColonnaLink DataField="SettoreProduttivo" HeaderText="Settore produttivo" IsJavascript="false"
                                                        LinkFields="IdInvestimento" LinkFormat="IstruttoriaInvestimentoRettificaSaldo.aspx?idinv={0}">
                                                        <ItemStyle Width="100px" HorizontalAlign="center" />
                                                    </Siar:ColonnaLink>
                                                    <asp:BoundColumn HeaderText="Costo totale investimento" DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" Width="100px" />
                                                        <ItemStyle HorizontalAlign="right" Width="100px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Contributo ammesso" DataField="ContributoRichiesto"
                                                        DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" Width="100px" />
                                                        <ItemStyle HorizontalAlign="right" Width="100px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="QuotaContributoRichiesto" HeaderText="% Quota contributo ammesso">
                                                        <FooterStyle HorizontalAlign="right" Width="80px" />
                                                        <ItemStyle HorizontalAlign="right" Width="80px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Importo pagamento richiesto" DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" Width="100px" />
                                                        <ItemStyle HorizontalAlign="right" Width="100px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Contributo pagamento richiesto" DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" Width="100px" />
                                                        <ItemStyle HorizontalAlign="right" Width="100px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Importo pagamento ammissibile" DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" Width="100px" />
                                                        <ItemStyle HorizontalAlign="right" Width="100px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Contributo pagamento ammissibile" DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" Width="100px" />
                                                        <ItemStyle HorizontalAlign="right" Width="100px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="% rendicon- tazione">
                                                        <ItemStyle Font-Bold="true" Font-Size="12px" HorizontalAlign="right" Width="70px" />
                                                    </asp:BoundColumn>
                                                    <%--<asp:BoundColumn HeaderText="Disavanzo richiesto/ammesso (limite 10% costo investimento)"
                                                        DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" Width="100px" />
                                                        <ItemStyle HorizontalAlign="right" Width="100px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Disavanzo contributo richiesto/ammesso (limite 10% costo investimento)"
                                                        DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" Width="100px" />
                                                        <ItemStyle HorizontalAlign="right" Width="100px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Contributo extra a copertura economie" DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" Width="100px" />
                                                        <ItemStyle HorizontalAlign="right" Width="100px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Rimanenza da assegnare/coprire" DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" Width="100px" />
                                                        <ItemStyle HorizontalAlign="right" Width="100px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="% rendicontazione ammissibile">
                                                        <ItemStyle Font-Bold="true" Font-Size="12px" HorizontalAlign="right" Width="70px" />
                                                    </asp:BoundColumn>--%>
                                                </Columns>
                                            </Siar:DataGrid>
                                            <table width="100%" id="tbLegendaInvestimenti" runat="server" visible="false">
                                                <tr>
                                                    <td style="width: 400px">
                                                        (*) = investimenti <b>NON</b> cofinanziati
                                                    </td>
                                                    <td>
                                                        (**) = contributo troncato per superamento <b>massimali</b> di domanda
                                                    </td>
                                                    <td align="right">
                                                        (***) = bando a <b>quota fissa</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-bottom: 20px; width: 400px;">
                                                        la stella
                                                        <img id="imgRedStar" runat="server" />
                                                        evidenzia gli <b>investimenti prioritari</b> di settore
                                                    </td>
                                                    <td style="padding-bottom: 20px;" align="right">
                                                        per la legenda completa cliccare
                                                        <uc3:SiarNewToolTip ID="SiarNewToolTip1" runat="server" Codice="legenda_pianoinvestimenti" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </td>
        </tr>

        <br />
    </table>
    <uc4:FirmaDocumento ID="ucFirmaDocumento" runat="server" Titolo="PAGINA DI FIRMA DELLA DOMANDA DI ULTERIORI CONTRIBUTI"
        DoppiaFirma="true" TipoDocumento="CKL_PAGAMENTO_RETTIFICA_SALDO" />
</asp:Content>