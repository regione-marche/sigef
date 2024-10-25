<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.BilancioAziendale" CodeBehind="BilancioAziendale.aspx.cs" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento"
    TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function dettaglioBil(id) {
            $('#ctl00_cphContenuto_hdnId').val(id); $('#ctl00_cphContenuto_btnModifica').click();
        }
        function StatoPatrimoniale() {

            var CFCFterreni = FromCurrencyToNumber($('[id$=txtCFCFterreni_text]').val());
            var CFCFimpianti = FromCurrencyToNumber($('[id$=txtCFCFimpianti_text]').val());
            var CFCFpiantagioni = FromCurrencyToNumber($('[id$=txtCFCFpiantagioni_text]').val());
            var CFCFmiglioramenti = FromCurrencyToNumber($('[id$=txtCFCFmiglioramenti_text]').val());

            var CFCF = CFCFterreni + CFCFimpianti + CFCFpiantagioni + CFCFmiglioramenti;
            $('[id$=lblCapitaleFondiario_text]').text(FromNumberToCurrency(CFCF));

            var CFCAmacchine = FromCurrencyToNumber($('[id$=txtCFCAmacchine_text]').val());
            var CFCAbestiame = FromCurrencyToNumber($('[id$=txtCFCAbestiame_text]').val());

            var CFCA = CFCAmacchine + CFCAbestiame;
            $('[id$=lblCapitaleAgrario_text]').text(FromNumberToCurrency(CFCA));

            var CFIFpartecipazioni = FromCurrencyToNumber($('[id$=txtCFIFpartecipazioni_text]').val());
            $('[id$=lblImmFinanziarie_text]').text(FromNumberToCurrency(CFIFpartecipazioni));
            var Tot_Capitale_Fisso = CFCF + CFCA + CFIFpartecipazioni;
            $('[id$=lblCapitaleFisso_text]').text(FromNumberToCurrency(Tot_Capitale_Fisso));

            //CAPITALE CIRCOLANTE
            var CCDFrimanenze = FromCurrencyToNumber($('[id$=txtCCDFrimanenza_text]').val());
            var CCDFanticipazioni = FromCurrencyToNumber($('[id$=txtCCDFanticipazioni_text]').val());
            var CCLDcrediti = FromCurrencyToNumber($('[id$=txtCCLDCrediti_text]').val());
            var CCLIbanca = FromCurrencyToNumber($('[id$=txtCCLIbanca_text]').val());
            var CCLIcassa = FromCurrencyToNumber($('[id$=txtCCLIcassa_text]').val());
            var CCDF = CCDFrimanenze + CCDFanticipazioni;
            $('[id$=lblDispFinan_text]').text(FromNumberToCurrency(CCDF));
            $('[id$=lblLiqDifferenti_text]').text(FromNumberToCurrency(CCLDcrediti));

            var CCLI = CCLIbanca + CCLIcassa;
            $('[id$=lblLiqImmediate_text]').text(FromNumberToCurrency(CCLI));
            var Totale_Cap_Circolante = CCDF + CCLDcrediti + CCLI;
            $('[id$=lblCapitaleCircolante_text]').text(FromNumberToCurrency(Totale_Cap_Circolante));
            var totaleImpieghi = Tot_Capitale_Fisso + Totale_Cap_Circolante;
            $('[id$=lblTotImpieghi_text]').text(FromNumberToCurrency(totaleImpieghi));

            //Fontifinanziamento
            var FFPCdebitibrevi = FromCurrencyToNumber($('[id$=txtFFPCdebitibreve_text]').val());
            var FFPCfornitori = FromCurrencyToNumber($('[id$=txtFFPCfornitori_text]').val());
            var FFPCdebitilungo = FromCurrencyToNumber($('[id$=txtFFPCdebitilungo_text]').val());
            var FFPCmutui = FromCurrencyToNumber($('[id$=txtFFPCmutui_text]').val());
            var FFMPcapitalenetto = FromCurrencyToNumber($('[id$=txtFFMPcapitalenetto_text]').val());
            var FFMPriserve = FromCurrencyToNumber($('[id$=txtFFMPriserve_text]').val());
            var FFMPutile = FromCurrencyToNumber($('[id$=txtFFMPutile_text]').val());

            var FFP_COR = FFPCdebitibrevi + FFPCfornitori;
            $('[id$=lblPassCorrenti_text]').text(FromNumberToCurrency(FFP_COR));

            var FFP_CONSOL = FFPCdebitilungo + FFPCmutui;
            $('[id$=lblPassConsolidate_text]').text(FromNumberToCurrency(FFP_CONSOL));

            var FFMP = FFMPcapitalenetto + FFMPriserve + FFMPutile;
            $('[id$=lblMezziPropri_text]').text(FromNumberToCurrency(FFMP));

            var TotaleFF = FFP_CONSOL + FFP_COR + FFMP;
            $('[id$=lblFontiFinanziamento_text]').text(FromNumberToCurrency(TotaleFF));

        }
               //-->
    </script>

    <script type="text/javascript">
		<!--
        function ControlloAnno(ev) {
            var oggi = new Date();
            var anno = oggi.getFullYear();

            var annoInserito = $('[id$=txtAnno_text]').val();
            if (annoInserito >= anno) {
                alert("Attenzione l'anno inserito non è corretto.\nIl bilancio deve riferirsi ad un anno precedente il " + anno);
                $('[id$=txtAnno_text]').val(anno - 1);
                return stopEvent(ev);
            }
        }

        function ContoEconomico() {
            var ricavinetti = FromCurrencyToNumber($('[id$=txtPLVricaviNetti_text]').val());
            var ricaviatt = FromCurrencyToNumber($('[id$=txtPLVRicaviattivita_text]').val());
            var rimanenzefinali = FromCurrencyToNumber($('[id$=txtPLVrimanenzefinali_text]').val());
            var rimanenzeiniziali = FromCurrencyToNumber($('[id$=txtPLVrimanenzeiniziali_text]').val());

            var PLV = ricavinetti + ricaviatt + rimanenzefinali - rimanenzeiniziali;
            PLV = Math.round(PLV * 100) / 100;
            $('[id$=lblPLV_text]').text(FromNumberToCurrency(PLV));

            var costimatprime = FromCurrencyToNumber($('[id$=txtVAcostimaterie_text]').val());
            var costiatt = FromCurrencyToNumber($('[id$=txtVAcostiattivita_text]').val());
            var noleggi = FromCurrencyToNumber($('[id$=txtVAnoleggi_text]').val());
            var manutenzioni = FromCurrencyToNumber($('[id$=txtVAmanutenzioni_text]').val());
            var spesegenerali = FromCurrencyToNumber($('[id$=txtVAspesegenerali_text]').val());
            var affitti = FromCurrencyToNumber($('[id$=txtVAaffitti_text]').val());
            var altricosti = FromCurrencyToNumber($('[id$=txtVAaltricosti_text]').val());

            var VA = PLV - costimatprime - costiatt - noleggi - manutenzioni - spesegenerali - affitti - altricosti;
            VA = Math.round(VA * 100) / 100;
            $('[id$=lblVA_text]').text(FromNumberToCurrency(VA));

            var ammmacchine = FromCurrencyToNumber($('[id$=txtPNmacchine_text]').val());
            var ammfabbricati = FromCurrencyToNumber($('[id$=txtPNfabbricati_text]').val());
            var ammpiantagioni = FromCurrencyToNumber($('[id$=txtPNpiantagioni_text]').val());
            var PN = VA - ammmacchine - ammfabbricati - ammpiantagioni;
            PN = Math.round(PN * 100) / 100;
            $('[id$=lblPN_text]').text(FromNumberToCurrency(PN));

            var salari = FromCurrencyToNumber($('[id$=txtROsalari_text]').val());
            var oneri = FromCurrencyToNumber($('[id$=txtROoneri_text]').val());
            var RO = PN - salari - oneri;
            RO = Math.round(RO * 100);
            RO = RO / 100;
            $('[id$=lblRO_text]').text(FromNumberToCurrency(RO));

            var ricavi = FromCurrencyToNumber($('[id$=txtPACricavi_text]').val());
            var costi = FromCurrencyToNumber($('[id$=txtPACcosti_text]').val());
            var proventi = FromCurrencyToNumber($('[id$=txtPACproventi_text]').val());
            var perdite = FromCurrencyToNumber($('[id$=txtPACperdite_text]').val());
            var interessiattivi = FromCurrencyToNumber($('[id$=txtPACinteressiattivi_text]').val());
            var interessipassivi = FromCurrencyToNumber($('[id$=txtPACinteressipassivi_text]').val());
            var imposte = FromCurrencyToNumber($('[id$=txtPACimposte_text]').val());
            var contributiPAC = FromCurrencyToNumber($('[id$=txtPACcontributi_text]').val());

            var RN_PAC = RO + ricavi - costi + proventi - perdite + interessiattivi - interessipassivi - imposte + contributiPAC;
            RN_PAC = Math.round(RN_PAC * 100) / 100;
            $('[id$=lblRNPAC_text]').text(FromNumberToCurrency(RN_PAC));


            var CASH_FLOW = RN_PAC + ammmacchine + ammfabbricati + ammpiantagioni;
            CASH_FLOW = Math.round(CASH_FLOW * 100) / 100;
            $('[id$=lblCash_text]').text(FromNumberToCurrency(CASH_FLOW));

            var redditifam = FromCurrencyToNumber($('[id$=txtMNLredditifam_text]').val());
            var rimborso = FromCurrencyToNumber($('[id$=txtMNLrimborso_text]').val());
            var prelievi = FromCurrencyToNumber($('[id$=txtMNLprelievi_text]').val());

            var MNL = CASH_FLOW + redditifam - rimborso - prelievi;
            MNL = Math.round(MNL * 100) / 100;
            $('[id$=lblMNL_text]').text(FromNumberToCurrency(MNL));

        }

        function nuovo() {
            $('#ctl00_cphContenuto_hdnId').val(); $('[id$=txtAnno_text]').val();
            $('#ctl00_cphContenuto_btnNuovo').click();
        }

	//-->
    </script>

    <uc1:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
    <br />
    <div style="display: none">
        <asp:HiddenField ID="hdnId" runat="server" />
        <asp:Button ID="btnModifica" runat="server" Text="Button" OnClick="btnModifica_Click" />
        <asp:Button ID="btnNuovo" runat="server" Text="Button" OnClick="btnNuovo_Click" CausesValidation="false" />
    </div>
    <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Bilanci Impresa |Nuovo" />
    <table width="600px" id="tbRiepilogoBilanci" class="tableTab" runat="server" visible="false">
        <tr>
            <td>
                <br />
                &nbsp; - Elenco dei bilanci inseriti per l'impresa specificata.
            </td>
        </tr>
        <tr>
            <td align="right">
                <input id="btnBack" class="Button" style="width: 120px" type="button" value="Indietro"
                    onclick="javascript:location='BusinessPlan.aspx'" />
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr class="separatore">
            <td>
                Elementi trovati :
                <Siar:Label ID="lblRisultato" runat="server" Text="">
                </Siar:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgBilancio" runat="server" Width="100%" PageSize="5" AllowPaging="True"
                    CssClass="tabella" AutoGenerateColumns="False" EnableViewState="False">
                    <PagerStyle CssClass="coda" Mode="NumericPages"></PagerStyle>
                    <AlternatingItemStyle CssClass="DataGridRow"></AlternatingItemStyle>
                    <ItemStyle CssClass="DataGridRow" Height="18px"></ItemStyle>
                    <Columns>
                        <asp:BoundColumn DataField="DataBilancio" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Anno" HeaderText="Anno di riferimento">
                            <HeaderStyle Width="150px" HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <HeaderStyle Width="90px" HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Width="90px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                    <HeaderStyle Font-Bold="True" ForeColor="White" CssClass="TESTA1"></HeaderStyle>
                </Siar:DataGrid>
                <br />
            </td>
        </tr>
    </table>
    <table id="tbBilancio" width="991px" class="tableTab" runat="server" visible="false">
        <tr>
            <td colspan="2">
                &nbsp;
                <br />
                <br />
                - Inserire le informazioni necessarie per definire lo Stato Patrimoniale e il Conto
                Economico
                <br />
                &nbsp;&nbsp;specificando l'anno di riferimento e la data di chiusura dell'esercizio
                finanziario.
                <br />
                <br />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 50%;">
                <strong><em>&nbsp;&nbsp; Anno di riferimento per il bilancio :&nbsp; </em></strong>
            </td>
            <td style="width: 50%">
                <Siar:TextBox ID="txtAnno" runat="server" DataColumn="Anno" MaxLength="4" NomeCampo="Anno di riferimento"
                    Obbligatorio="True" Width="40px" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 50%;">
                <strong><em>&nbsp;&nbsp; Data di chiusura dell'esercizio finanziario :&nbsp; </em>
                </strong>
            </td>
            <td style="width: 50%">
                <Siar:DateTextBox ID="txtDataBilancio" runat="server" Obbligatorio="True" Width="89px"
                    NomeCampo="Data bilancio" DataColumn="DataBilancio" />
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table id="tbStatoPatrimoniale" width="100%" runat="server" style="border: #3f6f3f 1px solid;">
                    <tr>
                        <td style="width: 60%;">
                            &nbsp;
                        </td>
                        <td style="width: 40%;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" rowspan="1" style="text-align: center">
                            <strong><em><span style="text-decoration: underline">STATO PATRIMONIALE RICLASSIFICATO</span></em></strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%;">
                            &nbsp;
                        </td>
                        <td style="width: 40%;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="2">
                            <strong>IMPIEGHI CAPITALE FISSO </strong><b></b><strong>&nbsp; &nbsp;</strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%; text-align: right; font-variant: small-caps">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 40%">
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; font-variant: small-caps; text-align: left;">
                            <span style="font-size: 10pt;"><strong>Capitale fondiario &nbsp; &nbsp;</strong></span>
                        </td>
                        <td align="right" style="width: 40%;">
                            <b>
                                <Siar:Label ID="lblCapitaleFondiario" runat="server">
                                </Siar:Label>
                            </b>&nbsp; &nbsp;
                        </td>
                    </tr>
                    <%-- <tr valign="top">
                                        <td style="width: 60%">
                                            &nbsp;</td>
                                        <td align="right" style="width: 40%">
                                        </td>
                                    </tr>--%>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;<span> <span style="text-decoration: underline">Terreni</span></span>
                        </td>
                        <td align="right" style="width: 40%">
                            <Siar:CurrencyBox ID="txtCFCFterreni" runat="server" Width="100px" DataColumn="CfCfTerreni" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">Impianti e fabbricati rurali</span>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtCFCFimpianti" runat="server" Width="100px" DataColumn="CfCfImpianti" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">Piantagioni</span>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtCFCFpiantagioni" runat="server" Width="100px" DataColumn="CfCfPiantagioni" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">Miglioramenti fondiari</span>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtCFCFmiglioramenti" runat="server" Width="100px" DataColumn="CfCfMiglioramenti" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;&nbsp;&nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; font-variant: small-caps;">
                            <span style="font-size: 10pt;"><strong>Capitale agrario</strong></span>
                        </td>
                        <td align="right" style="width: 40%;">
                            <b>
                                <Siar:Label ID="lblCapitaleAgrario" runat="server">
                                </Siar:Label>
                            </b>&nbsp; &nbsp;
                        </td>
                    </tr>
                    <%--<tr style="background-color: #AAAE80; color: white;">
                                        <td style="text-align: center; width: 60%;">
                                            <strong>TOTALE ATTIVO</strong></td>
                                        <td align="right">
                                            <strong>
                                                <Siar:Label ID="lblTotaleAttivo" runat="server" Text=" ">
                                                </Siar:Label>
                                                &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;</strong></td>
                                    </tr>--%>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;<span> <span style="text-decoration: underline">Macchine e attrezzature</span></span>
                        </td>
                        <td align="right" style="width: 40%">
                            <Siar:CurrencyBox ID="txtCFCAmacchine" runat="server" Width="100px" DataColumn="CfCaMacchine" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;<span> <span style="text-decoration: underline">Bestiame</span></span><br />
                            <span>&nbsp;<span style="text-decoration: underline">(latte/carne/riprod.)</span></span>
                        </td>
                        <td align="right" style="width: 40%">
                            <Siar:CurrencyBox ID="txtCFCAbestiame" runat="server" Width="100px" DataColumn="CfCaBestiame" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; width: 60%;">
                            &nbsp;&nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; font-variant: small-caps;">
                            <span style="font-size: 10pt;"><strong>Immobilitazioni finanziarie</strong></span>
                        </td>
                        <td align="right" style="width: 40%;">
                            <b>
                                <Siar:Label ID="lblImmFinanziarie" runat="server">
                                </Siar:Label>
                            </b>&nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;<span> <span style="text-decoration: underline">Partecipazioni</span></span>
                        </td>
                        <td align="right" style="width: 40%">
                            <Siar:CurrencyBox ID="txtCFIFpartecipazioni" runat="server" Width="100px" DataColumn="CfIfPartecipazioni" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%; text-align: center">
                            &nbsp;&nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; text-align: left">
                            <strong>&nbsp;&nbsp; TOTALE CAPITALE FISSO</strong>
                        </td>
                        <td align="right">
                            <b>
                                <Siar:Label ID="lblCapitaleFisso" runat="server">
                                </Siar:Label>
                            </b>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%; text-align: center">
                            &nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%; text-align: center">
                            &nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="2">
                            <strong>IMPIEGHI CAPITALE CIRCOLANTE</strong>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; font-variant: small-caps;">
                            <span style="font-size: 10pt;"><strong>Disponibilita finanziarie</strong></span>
                        </td>
                        <td align="right" style="width: 40%;">
                            <b>
                                <Siar:Label ID="lblDispFinan" runat="server">
                                </Siar:Label>
                            </b>&nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">Rimanenze finali</span>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtCCDFrimanenza" runat="server" Width="100px" DataColumn="CcDfRimanenze" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">Anticipazioni colturali finali</span>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtCCDFanticipazioni" runat="server" Width="100px" DataColumn="CcDfAnticipazioni" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; font-variant: small-caps;">
                            <span style="text-decoration: underline; font-size: 10pt;"><strong>Liquidità differite</strong></span>
                        </td>
                        <td align="right" style="width: 40%;">
                            <b>
                                <Siar:Label ID="lblLiqDifferenti" runat="server">
                                </Siar:Label>
                            </b>&nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">Crediti</span>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtCCLDCrediti" runat="server" Width="100px" DataColumn="CcLdCrediti" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; font-variant: small-caps;">
                            <span style="text-decoration: underline; font-size: 10pt;"><strong>Liquidità immediate</strong></span>
                        </td>
                        <td align="right" style="width: 40%;">
                            <b>
                                <Siar:Label ID="lblLiqImmediate" runat="server">
                                </Siar:Label>
                            </b>&nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">Banca c/c</span>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtCCLIbanca" runat="server" Width="100px" DataColumn="CcLiBanca" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">Cassa</span>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtCCLIcassa" runat="server" Width="100px" DataColumn="CcLiCassa" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <%--<tr style="background-color: #AAAE80; color: white;">
                                        <td style="text-align: center; width: 60%;">
                                            <strong>TOTALE PASSIVO</strong></td>
                                        <td align="right">
                                            <strong>
                                                <Siar:Label ID="lblTotalePassivo" runat="server">
                                                </Siar:Label>
                                                &nbsp; &nbsp;</strong>&nbsp;
                                        </td>
                                    </tr>--%>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; text-align: left">
                            <strong>&nbsp;&nbsp; TOTALE CAPITALE CIRCOLANTE</strong>
                        </td>
                        <td align="right">
                            <b>
                                <Siar:Label ID="lblCapitaleCircolante" runat="server">
                                </Siar:Label>
                            </b>&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; text-align: left">
                            <strong>&nbsp;&nbsp; TOTALE IMPIEGHI</strong>
                        </td>
                        <td align="right">
                            <b>
                                <Siar:Label ID="lblTotImpieghi" runat="server">
                                </Siar:Label>
                            </b>&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;&nbsp;&nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; height: 17px;" colspan="2">
                            <strong>FONTI DI FINANZIAMENTO</strong>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; font-variant: small-caps;">
                            <span style="text-decoration: underline; font-size: 10pt;"><strong>Passività correnti</strong></span>
                        </td>
                        <td align="right" style="width: 40%;">
                            <b>
                                <Siar:Label ID="lblPassCorrenti" runat="server">
                                </Siar:Label>
                            </b>&nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">Debiti a breve termine </span>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtFFPCdebitibreve" runat="server" Width="100px" DataColumn="FfPcDebitiBreveTermine" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">Fornitori</span>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtFFPCfornitori" runat="server" Width="100px" DataColumn="FfPcFornitori" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; font-variant: small-caps;">
                            <span style="text-decoration: underline; font-size: 10pt;"><strong>Passività consolidate</strong></span>
                        </td>
                        <td align="right" style="width: 40%;">
                            <b>
                                <Siar:Label ID="lblPassConsolidate" runat="server">
                                </Siar:Label>
                            </b>&nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">Debiti a medio e lungo termine</span>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtFFPCdebitilungo" runat="server" Width="100px" DataColumn="FfPcDebiti" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">Mutui</span>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtFFPCmutui" runat="server" Width="100px" DataColumn="FfPcMutui" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; font-variant: small-caps;">
                            <span style="text-decoration: underline; font-size: 10pt;"><strong>Mezzi propri</strong></span>
                        </td>
                        <td align="right" style="width: 40%;">
                            <b>
                                <Siar:Label ID="lblMezziPropri" runat="server">
                                </Siar:Label>
                            </b>&nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">Capitale netto</span>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtFFMPcapitalenetto" runat="server" Width="100px" DataColumn="FfMpCapitale" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">Riserve</span>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtFFMPriserve" runat="server" Width="100px" DataColumn="FfMpRiserve" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">Utile di esercizio</span>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtFFMPutile" runat="server" Width="100px" DataColumn="FfMpUtile" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; text-align: center">
                            <strong>TOTALE FONTI DI FINANZIAMENTO</strong>
                        </td>
                        <td align="right">
                            <b>
                                <Siar:Label ID="lblFontiFinanziamento" runat="server" CurrencyFormat="{0:C}">
                                </Siar:Label>
                            </b>&nbsp; &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table id="tbContoEconomico" width="100%" runat="server" style="border: #3f6f3f 1px solid;">
                    <tr>
                        <td style="width: 60%;">
                            &nbsp;
                        </td>
                        <td style="width: 40%;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <strong><em><span style="text-decoration: underline">RICLASSIFICAZIONE CONTI ECONOMICI</span></em></strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%;">
                            &nbsp;
                        </td>
                        <td style="width: 40%;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%;">
                            &nbsp;
                        </td>
                        <td style="width: 40%;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            <em>&nbsp;ricavi netti di vendita</em>
                        </td>
                        <td align="right" style="width: 40%">
                            (+)<Siar:CurrencyBox ID="txtPLVricaviNetti" runat="server" Width="100px" DataColumn="PlvRicaviNetti" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            <em><span>&nbsp;ricavi da attività connesse</span></em>
                        </td>
                        <td align="right" style="width: 200px">
                            (+)<Siar:CurrencyBox ID="txtPLVRicaviattivita" runat="server" Width="100px" DataColumn="PlvRicaviAttivita" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;<em>anticipazioni colturali e riamnenze finali</em>
                        </td>
                        <td align="right" style="width: 200px">
                            (+)<Siar:CurrencyBox ID="txtPLVrimanenzefinali" runat="server" Width="100px" DataColumn="PlvRimanenzeFinali" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            <em>&nbsp;anticipazioni colturali e rimanenze iniziali</em>
                        </td>
                        <td align="right" style="width: 200px">
                            (-)<Siar:CurrencyBox ID="txtPLVrimanenzeiniziali" runat="server" Width="100px" DataColumn="PlvRimanenzeIniziali" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 200px">
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; text-align: left;" valign="middle">
                            &nbsp;= &nbsp;<strong>PRODUZIONE LORDA VENDIBILE</strong>
                        </td>
                        <td style="width: 200px" align="right">
                            <b>
                                <Siar:Label ID="lblPLV" runat="server" Text=" " />
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td style="width: 40%">
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            <em>&nbsp;costi delle materie prime</em>
                        </td>
                        <td align="right" style="width: 200px">
                            (-)<Siar:CurrencyBox ID="txtVAcostimaterie" runat="server" Width="100px" DataColumn="VaCostiMatPrime" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;costi attività connesse</em>&nbsp;
                        </td>
                        <td align="right" style="width: 200px">
                            (-)<Siar:CurrencyBox ID="txtVAcostiattivita" runat="server" Width="100px" DataColumn="VaCostiAttConnesse" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;noleggi passivi</em>
                        </td>
                        <td align="right" style="width: 200px">
                            (-)<Siar:CurrencyBox ID="txtVAnoleggi" runat="server" Width="100px" DataColumn="VaNoleggi" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;manutenzioni e riparazioni</em>
                        </td>
                        <td align="right" style="width: 200px">
                            (-)<Siar:CurrencyBox ID="txtVAmanutenzioni" runat="server" Width="100px" DataColumn="VaManutenzioni" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp; spese generali</em>&nbsp;
                        </td>
                        <td align="right" style="width: 200px">
                            (-)<Siar:CurrencyBox ID="txtVAspesegenerali" runat="server" Width="100px" DataColumn="VaSpeseGenerali" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;affitti</em>
                        </td>
                        <td align="right" style="width: 200px">
                            (-)<Siar:CurrencyBox ID="txtVAaffitti" runat="server" Width="100px" DataColumn="VaAffitti" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;altri costi caratteristici</em>
                        </td>
                        <td align="right" style="width: 200px">
                            (-)<Siar:CurrencyBox ID="txtVAaltricosti" runat="server" Width="100px" DataColumn="VaAltriCosti" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td style="width: 40%">
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; text-align: left;">
                            <strong>&nbsp;= VALORE AGGIUNTO</strong>
                        </td>
                        <td align="right" style="width: 40%">
                            <strong>
                                <Siar:Label ID="lblVA" runat="server" Text=" " />
                            </strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td style="width: 40%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;ammortamenti (macchine e attrezzi)</em>
                        </td>
                        <td align="right" style="width: 40%">
                            (-)<Siar:CurrencyBox ID="txtPNmacchine" runat="server" Width="100px" DataColumn="PnAmmMacchine" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            <span><em>&nbsp;ammortamenti (fabbricati)</em></span>
                        </td>
                        <td align="right" style="width: 40%">
                            (-)<Siar:CurrencyBox ID="txtPNfabbricati" runat="server" Width="100px" DataColumn="PnAmmFabbricati" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            <span><em>&nbsp;ammortamenti (piantagioni)</em></span>
                        </td>
                        <td align="right" style="width: 40%">
                            (-)<Siar:CurrencyBox ID="txtPNpiantagioni" runat="server" Width="100px" DataColumn="PnAmmPiantagioni" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 40%">
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; text-align: left;" valign="middle">
                            <strong>&nbsp;= PRODOTTO NETTO</strong>
                        </td>
                        <td align="right" valign="middle" style="width: 200px">
                            <b>
                                <Siar:Label ID="lblPN" runat="server" Text=" " />
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td style="width: 40%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;salari e stipendi (dipendenti)</em>
                        </td>
                        <td align="right" style="width: 40%">
                            (-)<Siar:CurrencyBox ID="txtROsalari" runat="server" Width="100px" DataColumn="RoSalari" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <span><em>&nbsp;oneri sociali (titolare e dipendenti)</em></span>
                        </td>
                        <td align="right" style="width: 40%">
                            (-)<Siar:CurrencyBox ID="txtROoneri" runat="server" Width="100px" DataColumn="RoOneri" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 40%">
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; height: 17px; text-align: left;" valign="middle">
                            <strong>&nbsp;= REDDITO OPERATIVO</strong>
                        </td>
                        <td align="right" valign="middle" style="width: 40%">
                            <b>
                                <Siar:Label ID="lblRO" runat="server" Text=" " />
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 200px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;ricavi non caratteristici</em>
                        </td>
                        <td align="right" style="width: 200px">
                            (+)<Siar:CurrencyBox ID="txtPACricavi" runat="server" Width="100px" DataColumn="RnPacRicavi" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;costi non caratteristici</em>
                        </td>
                        <td align="right" style="width: 200px">
                            (-)<Siar:CurrencyBox ID="txtPACcosti" runat="server" Width="100px" DataColumn="RnPacCosti" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;proventi straordinari</em>
                        </td>
                        <td align="right" style="width: 200px">
                            (+)<Siar:CurrencyBox ID="txtPACproventi" runat="server" Width="100px" DataColumn="RnPacProventi" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;perdite</em>
                        </td>
                        <td align="right" style="width: 200px">
                            (-)<Siar:CurrencyBox ID="txtPACperdite" runat="server" Width="100px" DataColumn="RnPacPerdite" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;interessi attivi</em>
                        </td>
                        <td align="right" style="width: 200px">
                            (+)<Siar:CurrencyBox ID="txtPACinteressiattivi" runat="server" Width="100px" DataColumn="RnPacInteressiAttivi" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;interessi passivi</em>
                        </td>
                        <td align="right" style="width: 200px">
                            (-)<Siar:CurrencyBox ID="txtPACinteressipassivi" runat="server" Width="100px" DataColumn="RnPacInteressiPassivi" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;imposte e tasse&nbsp;</em>
                        </td>
                        <td align="right" style="width: 200px">
                            (-)<Siar:CurrencyBox ID="txtPACimposte" runat="server" Width="100px" DataColumn="RnPacImposte" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;contributi PAC</em>
                        </td>
                        <td align="right" style="width: 200px">
                            (+)<Siar:CurrencyBox ID="txtPACcontributi" runat="server" Width="100px" DataColumn="RnPacContributiPac" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 200px">
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; height: 17px; text-align: left;" valign="middle">
                            <strong>&nbsp;= REDDITO NETTO </strong>
                        </td>
                        <td align="right" valign="middle" style="width: 40%">
                            <b>
                                <Siar:Label ID="lblRNPAC" runat="server" Text=" " />
                            </b>
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; height: 17px; text-align: left;" valign="middle">
                            <strong>&nbsp;CASH FLOW = REDDITO NETTO + CONTRIBUTI PAC + AMMORTAMENTI</strong>
                        </td>
                        <td align="right" valign="middle" style="width: 40%">
                            <b>
                                <Siar:Label ID="lblCash" runat="server" Text=" " />
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 200px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;Altri redditi familiari</em>
                        </td>
                        <td align="right" style="width: 200px">
                            (+)<Siar:CurrencyBox ID="txtMNLredditifam" runat="server" Width="100px" DataColumn="MnlRedditiFam" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;rimborso quota capitale finanziamenti in essere</em>
                        </td>
                        <td align="right" style="width: 200px">
                            (-)<Siar:CurrencyBox ID="txtMNLrimborso" runat="server" Width="100px" DataColumn="MnlRimborso" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;prelievi del titolare (remunerazione lavoro familiare)</em>
                        </td>
                        <td align="right" style="width: 200px">
                            (-)<Siar:CurrencyBox ID="txtMNLprelievi" runat="server" Width="100px" DataColumn="MnlPrelievi" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 200px">
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; height: 17px; text-align: left;" valign="middle">
                            <strong>&nbsp;MARGINE NETTO DI LIQUIDITA'</strong>
                        </td>
                        <td align="right" valign="middle" style="width: 40%">
                            <b>
                                <Siar:Label ID="lblMNL" runat="server" Text=" " />
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td style="width: 40%">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="border-bottom: #3f6f3f 1px solid">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <input class="Button" onclick="javascript:nuovo()" type="button" value="Nuovo" style="width: 180px" />&nbsp;
                <Siar:Button ID="btnSalva" Text="Salva" runat="server" OnClientClick="return ControlloAnno(event)"
                    Width="180px" Modifica="true" OnClick="btnSalva_Click" />&nbsp;&nbsp;
                <Siar:Button ID="btnElimina" Text="Elimina" runat="server" CausesValidation="false"
                    Width="180px" Modifica="true" OnClick="btnElimina_Click" />&nbsp;&nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
