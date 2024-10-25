<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" Inherits="web.Private.PPagamento.PianoInvestimenti" CodeBehind="PianoInvestimenti.aspx.cs" %>

<%@ Register Src="~/CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/PianoInvestimentiAggregazioneDomanda.ascx" TagName="PianoInvestimentiAggregazioneDomanda" TagPrefix="uc3" %>
<%@ Register Src="~/CONTROLS/PianoInvestimentiCodificaDomanda.ascx" TagName="PianoInvestimentiCodificaDomanda" TagPrefix="uc4" %>
<%@ Register Src="~/CONTROLS/PianoInvestimentiInterventoDomanda.ascx" TagName="PianoInvestimentiInterventoDomanda" TagPrefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <style type="text/css">

        .positivo {
            color: green;
        }

        .negativo {
            color: red;
        }

    </style>
    
    <script type="text/javascript"><!--
        function visualizzaIntegrazioneSingola(id) {
            $('[id$=hdnIdIntegrazioneSingolaSelezionata]').val($('[id$=hdnIdIntegrazioneSingolaSelezionata]').val() == id ? '' : id);
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

//--></script>

    <uc1:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />

    <div style="display: none">
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
        <asp:HiddenField ID="hdnIdIntegrazioneSingolaSelezionata" runat="server" />
    </div>

    <table width="1300" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                PIANO DEGLI INVESTIMENTI
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td style="width: 400px" class="testo_pagina">
                            Di seguito vengono elencati tutti gli investimenti previsti dalla domanda di aiuto
                            nella sua versione più recente, ovvero comprensiva di <b>varianti/variazioni finanziarie</b>. Per richiedere
                            il pagamento delle spese sostenute per uno specifico investimento fare click sulla
                            riga relativa. 
                            <br />
                            <br />
                            <Siar:Button ID="btnEstrai" runat="server" Text="Estrai in XLS" Width="120px" OnClick="btnEstrai_Click" />
                            <br />
                            <br />
                            N.B.: se il piano degli investimenti risultasse grande l'estrazione potrebbe richiedere alcuni minuti.
                            <br />
                            <table id="tbAmmissibilitaRendicontazione" runat="server" style="width: 100%;">
                                <tr>
                                    <td class="paragrafo">
                                        Verifica ammissibilità rendicontazione:
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;&nbsp; Ai fini della validità del controllo accertarsi di aver<br />
                                        completato la rendicontazione richiesta.
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <br />
                                        <input class="ButtonProsegui" style="width: 140px" type="button" value="Prosegui &gt;&gt;"
                                               onclick="location='VerificaFinaleRendicontazione.aspx'" />
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
                                    </td><!--dgInvestimenti-->
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table style="width: 100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;&nbsp; Importo richiesto:<br />
                                                    €
                                                    <Siar:CurrencyBox ID="txtTotaleImportoRichiesto" runat="server" ReadOnly="True" Width="110px" />
                                                    %
                                                    <Siar:QuotaBox ID="txtQuotaImportoRichiesta" runat="server" ReadOnly="True" Width="50px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;&nbsp; Importo ammesso:<br />
                                                    €
                                                    <Siar:CurrencyBox ID="txtTotaleImportoAmmesso" runat="server" ReadOnly="True" Width="110px" />
                                                    %
                                                    <Siar:QuotaBox ID="txtQuotaImportoAmmessa" runat="server" ReadOnly="True" Width="50px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top" style="border-left: solid 1px black; padding-left: 10px">
                                        <table style="width: 100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    &nbsp; &nbsp;Contributo richiesto:<br />
                                                    €
                                                    <Siar:CurrencyBox ID="txtTotaleContributoRichiesto" runat="server" ReadOnly="True" Width="110px" />
                                                    %
                                                    <Siar:QuotaBox ID="txtQuotaContributoRichiesta" runat="server" ReadOnly="True" Width="50px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp; &nbsp;Contributo ammissibile <strong>(A)</strong>:<br />
                                                    €
                                                    <Siar:CurrencyBox ID="txtTotaleContributoAmmissibile" runat="server" ReadOnly="True" Width="110px" />
                                                    %
                                                    <Siar:QuotaBox ID="txtQuotaContributoAmmessa" runat="server" ReadOnly="True" Width="50px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top">
                                        <table style="width: 100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp; &nbsp; Ammontare sanzioni <strong>(B)</strong>:<br />
                                                    €
                                                    <Siar:CurrencyBox ID="txtImportoSanzione" runat="server" ReadOnly="True" Width="140px" />
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp; &nbsp; <strong>Contributo ammesso: (A-B-C)</strong><br />
                                                    €
                                                    <Siar:CurrencyBox ID="txtTotaleContributoAmmesso" runat="server" ReadOnly="True" Width="140px" />
                                                </td>
                                                <td>
                                                    &nbsp; &nbsp; Recupero anticipo <strong>(C)</strong>:<br />
                                                    €
                                                    <Siar:CurrencyBox ID="txtRecuperoAnticipo" runat="server" ReadOnly="True" Width="140px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
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
                                                    €
                                                    <Siar:CurrencyBox ID="txtTotaleInvestimenti" runat="server" ReadOnly="True" Width="140px" />
                                                </td>
                                                <td style="height: 63px; width: 194px;">
                                                    &nbsp;&nbsp;&nbsp; Contributo:<br />
                                                    €
                                                    <Siar:CurrencyBox ID="txtTotaleContributo" runat="server" ReadOnly="True" Width="140px" />
                                                </td>
                                                <td style="height: 63px">
                                                    &nbsp;&nbsp; <b>&nbsp;Contributo erogato fino ad ora:</b><br />
                                                    €
                                                    <Siar:CurrencyBox ID="txtErogato" runat="server" ReadOnly="True" Width="140px" />
                                                    %
                                                    <Siar:QuotaBox ID="txtErogatoQuota" runat="server" ReadOnly="True" Width="60px" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                                            <Siar:DataGrid ID="dgInvestimenti" runat="server" AutoGenerateColumns="False" PageSize="20" Width="100%">
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
                                                                      LinkFields="IdInvestimento" LinkFormat="PagamentoInvestimento.aspx?idinv={0}">
                                                        <ItemStyle Width="100px" HorizontalAlign="center" />
                                                    </Siar:ColonnaLink>
                                    
                                                    <asp:BoundColumn HeaderText="Costo totale investimento" DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" Width="100px" />
                                                        <ItemStyle HorizontalAlign="right" Width="100px" />
                                                    </asp:BoundColumn>
                                    
                                                    <asp:BoundColumn HeaderText="Contributo ammesso" DataField="ContributoRichiesto" DataFormatString="{0:c}">
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
                                                    <asp:BoundColumn HeaderText="Contributo pagamento ammissibile" DataFormatString="{0:c}">
                                                        <FooterStyle HorizontalAlign="right" Width="100px" />
                                                        <ItemStyle HorizontalAlign="right" Width="100px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn HeaderText="% rendicon- tazione">
                                                        <ItemStyle Font-Bold="true" Font-Size="12px" HorizontalAlign="right" Width="70px" />
                                                    </asp:BoundColumn>
                                                    <Siar:JsButtonColumn Arguments="IdInvestimento" ButtonType="ImageButton" ButtonText="Richiesta integrazione"
                                                        JsFunction="" HeaderText="Richiesta integrazione" ButtonImage="warning.png">
                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                    </Siar:JsButtonColumn>
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
                                                        <uc2:SiarNewToolTip ID="SiarNewToolTip1" runat="server" Codice="legenda_pianoinvestimenti" />
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
                                            <Siar:DataGrid ID="dgBrevetti" runat="server" AutoGenerateColumns="False" PageSize="20" Width="100%">
                                                <ItemStyle Height="30px" />
                                                <Columns>
                                                    <asp:BoundColumn DataField="Misura" HeaderText="Programmazione">
                                                        <ItemStyle HorizontalAlign="center" Width="130px" />
                                                    </asp:BoundColumn>
                                                    <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione tecnica" IsJavascript="false"
                                                                      LinkFields="IdInvestimento" LinkFormat="PagamentoInvestimento.aspx?idinv={0}">
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
                                                                      LinkFields="IdInvestimento" LinkFormat="PagamentoInvestimento.aspx?idinv={0}">
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
                                                                      LinkFields="IdInvestimento" LinkFormat="PagamentoInvestimento.aspx?idinv={0}">
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
                                                        Ammontare raggiunto €:<br />
                                                        <Siar:CurrencyBox ID="txtPCCAmmontare" runat="server" Width="130px" ReadOnly="True" />
                                                    </td>
                                                    <td style="width: 150px">
                                                        Anticipo percepito €:<br />
                                                        <Siar:CurrencyBox ID="txtPCCAnticipo" runat="server" Width="130px" ReadOnly="True" />
                                                    </td>
                                                    <td>
                                                        Ammontare rimanente €:<br />
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
                <uc3:PianoInvestimentiAggregazioneDomanda ID="PianoInvestimentiAggregazioneDomanda" runat="server"  />
            </td>
        </tr>
        <br />
        <tr>
            <td>
                <uc4:PianoInvestimentiCodificaDomanda ID="PianoInvestimentiCodificaDomanda" runat="server"  />
            </td>
        </tr>
        <br />
        <tr>
            <td>
                <uc5:PianoInvestimentiInterventoDomanda ID="PianoInvestimentiInterventoDomanda" runat="server"  />
            </td>
        </tr>
        <br />
        <tr id="trIntegrazioniRichieste" runat="server" visible="false">
                        <td>
                            <table width="100%">
                                <tr>
                                    <td class="separatore" style="width: 287px">
                                        Elenco integrazioni da risolvere:
                                    </td>
                                </tr>
                                <br />
                                &nbsp;
                                <tr>
                                    <td align="right">    
                                        <Siar:Button ID="btnAllegati" runat="server" OnClick="btnAllegati_Click" Text="Allegati" Width="180px" />
                                        <Siar:Button ID="btnSpese" runat="server" OnClick="btnSpese_Click" Text="Spese sostenute" Width="180px" />
                                        <Siar:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Indietro" Width="180px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <Siar:DataGrid ID="dgIntegrazioni" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            PageSize="15" Width="100%" ShowFooter="true">
                                            <ItemStyle Height="28px" />
                                            <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                            <Columns>
                                                <asp:BoundColumn DataField="IdSingolaIntegrazione" HeaderText="ID singola integrazione">
                                                    <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" Width="70px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="DataRichiestaIntegrazioneIstruttore" HeaderText="Data richiesta">
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="DescrizioneTipoIntegrazione" HeaderText="Tipo integrazione">
                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="NoteIntegrazioneIstruttore" HeaderText="Note istruttore">
                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="SingolaIntegrazioneCompletataIstruttore" HeaderText="Completata istruttore">
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="DataRilascioIntegrazioneBeneficiario" HeaderText="Data rilascio beneficiario">
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="NoteIntegrazioneBeneficiario" HeaderText="Note beneficiario">
                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="SingolaIntegrazioneCompletataBeneficiario" HeaderText="Completata beneficiario">
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:BoundColumn>
                                                <Siar:JsButtonColumn Arguments="IdSingolaIntegrazione" ButtonType="TextButton" ButtonText="Apri" JsFunction="visualizzaIntegrazioneSingola" HeaderText="Apri">
                                                    <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                </Siar:JsButtonColumn>
                                            </Columns>
                                        </Siar:DataGrid>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <br />
                     <tr id="trDettaglioIntegrazioneSingolaSelezionata" runat="server" visible="false">
                        <td>
                            <table width="100%">
                                <tr>
                                    <td class="separatore">
                                        Dettaglio singola integrazione selezionata:
                                    </td>
                                </tr>
                                <tr>
                                    <td class="paragrafo" style="width: 287px">
                                        Dati di competenza dell'istruttore:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 10px">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    Data richiesta:<br />
                                                    <Siar:DateTextBox ID="txtDataRichiesta" runat="server" Width="120px" ReadOnly="true" />
                                                </td>
                                                <td>
                                                    Tipo integrazione:
                                                    <br />
                                                    <Siar:TextBox ID="txtTipoIntegrazione" runat="server" Width="180px" ReadOnly="true" />
                                                </td>
                                                <td>
                                                    Integrazione completata:
                                                    <br />
                                                    <asp:DropDownList ID="comboCompletataSingolaIntegrazioneDomandaIstruttore" runat="server"
                                                        Enabled="False">
                                                        <asp:ListItem Text="No" Value="false"></asp:ListItem>
                                                        <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    Note integrazione:
                                                    <br />
                                                    <Siar:TextArea ID="txtNoteSingolaIntegrazioneIstruttore" runat="server" NomeCampo="Note singola integrazione"
                                                        Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" ReadOnly="true" MaxLength="10000" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="paragrafo" style="width: 287px">
                                        Dati di competenza del beneficiario:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 10px">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    Data rilascio:<br />
                                                    <Siar:DateTextBox ID="txtDataRilascio" runat="server" Width="120px" />
                                                </td>
                                                <td>
                                                    Integrazione completata beneficiario:
                                                    <br />
                                                    <asp:DropDownList ID="comboCompletataSingolaIntegrazioneDomandaBeneficiario" runat="server">
                                                        <asp:ListItem Text="No" Value="false"></asp:ListItem>
                                                        <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    Note beneficiario:
                                                    <br />
                                                    <Siar:TextArea ID="txtNoteSingolaIntegrazioneBeneficiario" runat="server" NomeCampo="Note singola integrazione beneficiario"
                                                        Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                                                </td>
                                                <td align="left">
                                                    <br />
                                                    <Siar:Button ID="btnSalvaSingolaIntegrazione" runat="server" OnClick="btnSalvaSingolaIntegrazione_Click"
                                                        Text="Salva dati singola integrazione" Width="190px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
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
                    <Siar:DataGrid ID="dgDettaglioMisura" runat="server" AutoGenerateColumns="False" Width="100%">
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
                            <asp:BoundColumn HeaderText="(B) Contributo richiesto" DataFormatString="{0:c}" DataField="ContributoRichiesto">
                                <ItemStyle HorizontalAlign="Right" Width="110px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="% su totale (B/A)" DataFormatString="{0:n}">
                                <ItemStyle HorizontalAlign="Right" Width="110px" Font-Bold="true" Font-Size="12px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Contributo ammissibile" DataFormatString="{0:c}" DataField="ContributoAmmissibile">
                                <ItemStyle HorizontalAlign="Right" Width="110px" />
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
                    <input id="btnChiudi" class="Button" style="width: 105px" type="button" value="Chiudi" onclick="chiudiPopupTemplate()" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
