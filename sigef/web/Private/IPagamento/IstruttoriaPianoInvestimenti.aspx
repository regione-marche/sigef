<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IstruttoriaPianoInvestimenti" CodeBehind="IstruttoriaPianoInvestimenti.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc3" %>

<%@ Register Src="~/CONTROLS/PianoInvestimentiAggregazioneDomandaIstruttoria.ascx" TagName="PianoInvestimentiAggregazioneDomandaIstruttoria" TagPrefix="uc4" %>
<%@ Register Src="~/CONTROLS/PianoInvestimentiCodificaDomandaIstruttoria.ascx" TagName="PianoInvestimentiCodificaDomandaIstruttoria" TagPrefix="uc5" %>
<%@ Register Src="~/CONTROLS/ucVisure.ascx" TagName="ucVisure" TagPrefix="uc6" %>
<%@ Register Src="~/CONTROLS/PianoInvestimentiInterventoDomandaIstruttoria.ascx" TagName="PianoInvestimentiInterventoDomandaIstruttoria" TagPrefix="uc7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
        <script type="text/javascript"><!--
            function selezionaIntegrazioneSingola(id, elem) {
                if (elem.checked == false) {
                    $('[id$=hdnIdIntegrazioneSingolaSelezionata]').val('');
                }
                else {
                    $('[id$=hdnIdIntegrazioneSingolaSelezionata]').val(id);
                }

                $('[id$=btnPost]').click();
            }

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
           
            //nascosta.val("true");
            //} else {
            //        divModale[0].style.width = "40%";
            //    divModale.css({
            //        'left': scrollLeft + ((clientWidth - divModale[0].offsetWidth) / 2),

            //});
            
            //nascosta.val("false");

//--></script>

    <br />
    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <br />
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
                            Di seguito vengono elencati tutti gli investimenti previsti dalla domanda di aiuto
                            nella sua versione più recente, ovvero
                            <br />
                            comprensiva di varianti. Per istruire i pagamenti delle spese
                            <br />
                            sostenute per uno specifico investimento fare click sulla riga relativa.
                            <br />
                            &nbsp;
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <Siar:Button ID="btnEstrai" runat="server" Text="Estrai in XLS" Width="120px" OnClick="btnEstrai_Click" />
                                        <input id="btnBack" runat="server" class="Button" style="width: 120px" type="button"
                                            onclick="location='CheckListPagamento.aspx'" value="Indietro" />
                                        <br /><br />
                                        <input id="btnAccorpamentoInvestimenti" runat="server" class="Button" style="width: 180px;" type="button" value="Accorpamento investimenti" title="Solo il Responsabile del bando può accorpare gli investimenti."
                                            onclick="location='IstruttoriaPianoInvestimentiAccorpamentoInvestimenti.aspx'" />
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
                                                    <Siar:Button ID="btnModificaRecuperoAnticipo" runat="server" Text="Modifica recupero anticipo" 
                                                        OnClick="btnModificaRecuperoAnticipo_Click" Width="200px" />
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
                                            <tr>
                                                <td colspan="2">
                                                    <div id="divContributoAmmessoRidottoGradutatoria" runat="server" visible="false">
                                                        <b>*Il contributo ammesso è stato ridotto per non superare il contributo concesso in graduatoria</b>
                                                    </div>
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
                                                    <Siar:Button ID="btnDettaglioMisura" runat="server" CausesValidation="False" OnClick="btnDettaglioMisura_Click"
                                                        Text="Dettagli di misura" Width="160px" />
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
                                                        LinkFields="IdInvestimento" LinkFormat="IstruttoriaInvestimento.aspx?idinv={0}">
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
                                                    <asp:BoundColumn HeaderText="Disavanzo richiesto/ammesso (limite 10% costo investimento)"
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
                                                    </asp:BoundColumn>
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
                                <table id="tableBrevetti" width="100%" runat="server" visible="false">
                                    <tr>
                                        <td class="separatore">
                                            Brevetti &amp; licenze:
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-bottom: 20px">
                                            <Siar:DataGrid ID="dgBrevetti" runat="server" AutoGenerateColumns="False" PageSize="20"
                                                Width="100%">
                                                <ItemStyle Height="30px" />
                                                <Columns>
                                                    <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                                        <ItemStyle HorizontalAlign="center" Width="130px" />
                                                    </asp:BoundColumn>
                                                    <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione tecnica" IsJavascript="false"
                                                        LinkFields="IdInvestimento" LinkFormat="IstruttoriaInvestimento.aspx?idinv={0}">
                                                    </Siar:ColonnaLink>
                                                    <asp:BoundColumn DataField="CostoInvestimento" HeaderText="Ammontare spese" DataFormatString="{0:c}">
                                                        <ItemStyle HorizontalAlign="right" Width="120px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Contributo ammesso" DataField="ContributoRichiesto"
                                                        DataFormatString="{0:c}">
                                                        <ItemStyle HorizontalAlign="right" Width="120px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="QuotaContributoRichiesto" HeaderText="% Quota contributo ammesso">
                                                        <ItemStyle HorizontalAlign="right" Width="120px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Importo pagamento richiesto" DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" Width="100px" />
                                                        <ItemStyle HorizontalAlign="right" Width="100px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Contributo pagamento richiesto" DataFormatString="{0:c}">
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
                                                </Columns>
                                            </Siar:DataGrid>
                                        </td>
                                    </tr>
                                </table>
                                <table id="tableMutuo" runat="server" width="100%" visible="false">
                                    <tr>
                                        <td class="separatore">
                                            Dettagli del mutuo:
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-bottom: 20px">
                                            <Siar:DataGrid ID="dgMutuo" runat="server" AutoGenerateColumns="False" PageSize="20"
                                                Width="100%">
                                                <ItemStyle Height="30px" />
                                                <Columns>
                                                    <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                                        <ItemStyle HorizontalAlign="center" Width="90px" />
                                                    </asp:BoundColumn>
                                                    <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione tecnica" IsJavascript="false"
                                                        LinkFields="IdInvestimento" LinkFormat="IstruttoriaInvestimento.aspx?idinv={0}">
                                                    </Siar:ColonnaLink>
                                                    <asp:BoundColumn DataField="SpeseGenerali" HeaderText="Ammontare degli investimenti per cui si richiede il mutuo"
                                                        DataFormatString="{0:c}">
                                                        <ItemStyle HorizontalAlign="right" Width="120px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="CostoInvestimento" HeaderText="Ammontare del mutuo" DataFormatString="{0:c}">
                                                        <ItemStyle HorizontalAlign="right" Width="120px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Contributo ammesso" DataField="ContributoRichiesto"
                                                        DataFormatString="{0:c}">
                                                        <ItemStyle HorizontalAlign="right" Width="100px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Importo pagamento richiesto" DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" Width="100px" />
                                                        <ItemStyle HorizontalAlign="right" Width="100px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Contributo pagamento richiesto" DataFormatString="{0:c}">
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
                                                </Columns>
                                            </Siar:DataGrid>
                                        </td>
                                    </tr>
                                </table>
                                <table id="tableFidejussione" width="100%" runat="server" visible="false">
                                    <tr>
                                        <td class="separatore">
                                            Polizza fidejussoria:
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-bottom: 20px">
                                            <Siar:DataGrid ID="dgFidejussione" runat="server" AutoGenerateColumns="False" Width="100%">
                                                <ItemStyle Height="30px" />
                                                <Columns>
                                                    <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                                        <ItemStyle HorizontalAlign="center" Width="90px" />
                                                    </asp:BoundColumn>
                                                    <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione tecnica" IsJavascript="false"
                                                        LinkFields="IdInvestimento" LinkFormat="IstruttoriaInvestimento.aspx?idinv={0}">
                                                    </Siar:ColonnaLink>
                                                    <asp:BoundColumn DataField="CostoInvestimento" HeaderText="Ammontare spese" DataFormatString="{0:c}">
                                                        <ItemStyle HorizontalAlign="right" Width="120px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Contributo ammesso" DataField="ContributoRichiesto"
                                                        DataFormatString="{0:c}">
                                                        <ItemStyle HorizontalAlign="right" Width="120px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="QuotaContributoRichiesto" HeaderText="% Quota contributo ammesso">
                                                        <ItemStyle HorizontalAlign="right" Width="120px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Importo pagamento richiesto" DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" Width="100px" />
                                                        <ItemStyle HorizontalAlign="right" Width="100px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="Contributo pagamento richiesto" DataFormatString="{0:c}">
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
                                                </Columns>
                                            </Siar:DataGrid>
                                        </td>
                                    </tr>
                                </table>
                                <table id="tablePremio" runat="server" width="100%" visible="false">
                                    <tr>
                                        <td class="separatore">
                                            Premio in conto capitale:
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 10px">
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 220px">
                                                        Programmazione:<br />
                                                        <Siar:TextBox ID="txtPCCProgrammazione" runat="server" ReadOnly="True" Width="190px" />
                                                    </td>
                                                    <td style="width: 150px">
                                                        Ammontare raggiunto &euro;:<br />
                                                        <Siar:CurrencyBox ID="txtPCCAmmontare" runat="server" Width="130px" ReadOnly="True" />
                                                    </td>
                                                    <td style="width: 150px">
                                                        Anticipo percepito &euro;:<br />
                                                        <Siar:CurrencyBox ID="txtPCCAnticipo" runat="server" Width="130px" ReadOnly="True" />
                                                    </td>
                                                    <td>
                                                        Ammontare rimanente &euro;:<br />
                                                        <Siar:CurrencyBox ID="txtPCCRimanente" runat="server" Width="130px" ReadOnly="True" />
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
        <tr>
            <td>
                <uc4:PianoInvestimentiAggregazioneDomandaIstruttoria ID="PianoInvestimentiAggregazioneDomandaIstruttoria" runat="server"  />
            </td>
        </tr>
        <br />
        <tr>
            <td>
                <uc5:PianoInvestimentiCodificaDomandaIstruttoria ID="PianoInvestimentiCodificaDomandaIstruttoria" runat="server"  />
            </td>
        </tr>
        <br />
        <tr>
            <td>
                <uc7:PianoInvestimentiInterventoDomandaIstruttoria ID="PianoInvestimentiInterventoDomandaIstruttoria" runat="server"  />
            </td>
        </tr>
        <br />
        <tr>
            <td>
                <uc6:ucVisure ID="ucVisure" runat="server" />
            </td>
        </tr>
        <br />
    </table>


    <div id='divIstPagForm' style="width: 1150px; position: absolute; display: none">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore_big">
                    Importi totali della domanda di pagamento dettagliati per misura:
                </td>
            </tr>
            <tr>
                <td style="padding-top: 10px">
                    <Siar:DataGrid ID="dgDettaglioMisura" runat="server" AutoGenerateColumns="False"
                        Width="100%">
                        <ItemStyle Height="30px" />
                        <Columns>
                            <asp:BoundColumn HeaderText="Programmazione" DataField="Misura">
                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="12px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText=" " DataFormatString="{0:c}" DataField="CostoTotaleProgettoCorrelato">
                                <ItemStyle HorizontalAlign="Right" Width="110px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="(A) Contributo totale" DataFormatString="{0:c}" DataField="ContributoTotaleProgettoCorrelato">
                                <ItemStyle HorizontalAlign="Right" Width="110px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Importo richiesto" DataFormatString="{0:c}" DataField="ImportoRichiesto">
                                <ItemStyle HorizontalAlign="Right" Width="110px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Contributo richiesto" DataFormatString="{0:c}" DataField="ContributoRichiesto">
                                <ItemStyle HorizontalAlign="Right" Width="110px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="(B) Contributo ammissibile" DataFormatString="{0:c}"
                                DataField="ContributoAmmissibile">
                                <ItemStyle HorizontalAlign="Right" Width="110px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="% su totale (B/A)" DataFormatString="{0:n}">
                                <ItemStyle HorizontalAlign="Right" Width="110px" Font-Bold="true" Font-Size="12px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Totale sanzioni" DataFormatString="{0:c}" DataField="AmmontareSanzione">
                                <ItemStyle HorizontalAlign="Right" Width="110px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Recupero anticipo" DataFormatString="{0:c}" DataField="RecuperoAnticipo">
                                <ItemStyle HorizontalAlign="Right" Width="110px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Contributo ammesso" DataFormatString="{0:c}" DataField="ContributoAmmesso">
                                <ItemStyle HorizontalAlign="Right" Width="110px" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGrid>
                    <table width="100%">
                        <tr>
                            <td style="width: 20px" align="right">
                                (
                            </td>
                            <td style="width: 10px; background-color: #ccccb3">
                            </td>
                            <td>
                                = misure per cui non è stato richiesto il pagamento)
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 40px; padding-right: 80px">
                    <input id="btnChiudi" class="Button" style="width: 105px" type="button" value="Chiudi"
                        onclick="chiudiPopupTemplate()" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>