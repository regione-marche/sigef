<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IstruttoriaPianoInvestimentiAccorpamentoInvestimenti"
    CodeBehind="IstruttoriaPianoInvestimentiAccorpamentoInvestimenti.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento"
    TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function controllaAccorpamento() {
            if (confirm('Sei sicuro di voler accorpare le due voci del piano?')) {
                var quotaContributoX, quotaContributoY;
                var impresaX, impresaY;
                var tblGrid = $('[id$=dgInvestimenti]')[0];
                var rows = tblGrid.rows;

                var voceX = $('[id$=txtVoceAccorpamentoX]').val();
                if (voceX == '') {
                    alert('Voce X non inserita.');
                    return false;
                } else if (voceX < 1 || voceX > (rows.length - 2)) {
                    alert('Voce X inesistente.');
                    return false;
                }

                var voceY = $('[id$=txtVoceAccorpamentoY]').val();
                if (voceY == '') {
                    alert('Voce Y non inserita.');
                    return false;
                } else if (voceY < 1 || voceY > (rows.length - 2)) {
                    alert('Voce Y inesistente.');
                    return false;
                }

                if (voceX == voceY) {
                    alert('Voce X e voce Y uguali.');
                    return false;
                }

                var a_capo = "<br><br>";
                var string_impresa = "Impresa:"; // non ho aggiunto <br> perche' altrimenti non trovava correttamente gli indici
                var aggregazione = rows[1].cells[2].innerHTML.indexOf(string_impresa) !== -1 ? true : false;
                var i = 0, row, cell; count = 0;
                for (i = 1; i < (rows.length - 1); i++) {
                    row = rows[i];

                    numeroRiga = row.cells[0].innerHTML;
                    if (numeroRiga.indexOf(a_capo) !== -1) { //se c'e' la stella con gli a capo li tolgo per avere solo il numero
                        numeroRiga = numeroRiga.substring(numeroRiga.indexOf(a_capo) + a_capo.length, numeroRiga.length);
                    }

                    if (aggregazione) {
                        var descrizione = row.cells[2].innerHTML;
                        var imp = descrizione.substring(descrizione.indexOf(string_impresa) + string_impresa.length, descrizione.lastIndexOf("-"));
                        
                        if (numeroRiga == voceX) {
                            impresaX = imp;
                        } else if (numeroRiga == voceY) {
                            impresaY = imp;
                        }
                    }

                    quotaContributo = row.cells[6].innerHTML;
                    
                    if (numeroRiga == voceX) {
                        quotaContributoX = quotaContributo;
                    } else if (numeroRiga == voceY) {
                        quotaContributoY = quotaContributo;
                    }
                }
                
                if (aggregazione && impresaX != impresaY) {
                    alert("Non e' possibile accorpare voci associate a imprese differenti!");
                    return false;
                }

                if (quotaContributoX != quotaContributoY) {
                    if (!confirm('Le due voci del piano hanno una quota contributo differente: continuare comunque?')) {
                        return false;
                    }
                }

                creaModaleCaricamento();
                return true;
            }

            return false;
        }
    </script>

    <br />
    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <br />
    <table width="1300" class="tableNoTab">
        <tr>
            <td class="separatore_big">ACCORPAMENTO INVESTIMENTI
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td style="width: 500px" class="testo_pagina">E' possibile accorpare solamente <strong>due voci</strong> alla volta aventi la <strong>stessa tipologia</strong> (il
                            "Dettaglio" della colonna "Descrizione") e la <strong>stessa impresa</strong>.<br />
                            <strong>L'investimento 'Y' verra' accorpato all'investimento 'X'</strong>: le spese sostenute relative alla voce 'Y' (se presenti) verranno aggiunte a quelle
                            della voce 'X' prima di rimuoverla.<br />
                            Qualora dovesse essere necessario, e' possibile aggiornare la descrizione della voce del piano risultante.<br />
                            La quota di contributo ammesso, la descrizione e altri dettagli della voce 'X' rimarranno invariati: pertanto 
                            <strong>occorre verificare accuratamente i dettagli delle due voci prima di effettuare tale operazione.</strong><br />
                            <br />
                            &nbsp;
                            <input id="btnBack" runat="server" class="Button" style="width: 120px" type="button"
                                onclick="location = 'IstruttoriaPianoInvestimenti.aspx'" value="Indietro" />
                        </td>
                        <td align="center" valign="top" style="width: 875px; text-align: left">
                            <table width="100%">
                                <tr>
                                    <td class="separatore_light" colspan="2">Accorpamento voci del piano investimenti:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px;">Nr. voce del piano (X):<br />
                                        <Siar:IntegerTextBox ID="txtVoceAccorpamentoX" runat="server" Width="50px"></Siar:IntegerTextBox>
                                        <br />
                                        <br />
                                        Nr. voce del piano che verrà rimossa (Y):<br />
                                        <Siar:IntegerTextBox ID="txtVoceAccorpamentoY" runat="server" Width="50px"></Siar:IntegerTextBox>
                                    </td>
                                    <td>
                                        <br />
                                        Nuova descrizione della voce del piano X (opzionale):<br />
                                        <Siar:TextArea ID="txtDescrizioneAccorpamento" runat="server" NomeCampo="Nuova descrizione della voce del piano"
                                            Obbligatorio="false" Width="500px" Rows="5" ExpandableRows="5" MaxLength="10000" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnAccorporaVociPiano" runat="server" Text="Accorpora la voce X alla voce Y"
                                            Width="200px" CssClass="Button" OnClick="btnAccorporaVociPiano_Click"
                                            OnClientClick="if(!controllaAccorpamento()) {return false;}" />
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
                <table id="tableInvestimenti" width="100%" runat="server" visible="false">
                    <tr>
                        <td class="separatore">Investimenti ammessi a finanziamento:
                            <Siar:Label ID="lblNumeroInvestimenti" runat="server">
                            </Siar:Label>
                        </td>
                    </tr>
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
                                    <td style="width: 400px">(*) = investimenti <b>NON</b> cofinanziati
                                    </td>
                                    <td>(**) = contributo troncato per superamento <b>massimali</b> di domanda
                                    </td>
                                    <td align="right">(***) = bando a <b>quota fissa</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-bottom: 20px; width: 400px;">la stella
                                        <img id="imgRedStar" runat="server" />
                                        evidenzia gli <b>investimenti prioritari</b> di settore
                                    </td>
                                    <td style="padding-bottom: 20px;" align="right">per la legenda completa cliccare
                                        <uc3:SiarNewToolTip ID="SiarNewToolTip1" runat="server" Codice="legenda_pianoinvestimenti" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table id="tableBrevetti" width="100%" runat="server" visible="false">
                    <tr>
                        <td class="separatore">Brevetti &amp; licenze:
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
                        <td class="separatore">Dettagli del mutuo:
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
                        <td class="separatore">Polizza fidejussoria:
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
                        <td class="separatore">Premio in conto capitale:
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px">
                            <table width="100%">
                                <tr>
                                    <td style="width: 220px">Programmazione:<br />
                                        <Siar:TextBox  ID="txtPCCProgrammazione" runat="server" ReadOnly="True" Width="190px" />
                                    </td>
                                    <td style="width: 150px">Ammontare raggiunto €:<br />
                                        <Siar:CurrencyBox ID="txtPCCAmmontare" runat="server" Width="130px" ReadOnly="True" />
                                    </td>
                                    <td style="width: 150px">Anticipo percepito €:<br />
                                        <Siar:CurrencyBox ID="txtPCCAnticipo" runat="server" Width="130px" ReadOnly="True" />
                                    </td>
                                    <td>Ammontare rimanente €:<br />
                                        <Siar:CurrencyBox ID="txtPCCRimanente" runat="server" Width="130px" ReadOnly="True" />
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
                <td class="separatore_big">Importi totali della domanda di pagamento dettagliati per misura:
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
                            <td style="width: 20px" align="right">(
                            </td>
                            <td style="width: 10px; background-color: #ccccb3"></td>
                            <td>= misure per cui non è stato richiesto il pagamento)
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
