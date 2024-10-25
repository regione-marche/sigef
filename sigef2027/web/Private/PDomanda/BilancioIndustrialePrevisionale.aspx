<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.BilancioIndustrialePrevisionale" CodeBehind="BilancioIndustrialePrevisionale.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
		<!--
        function dettaglioBil(id) {$('#ctl00_cphContenuto_hdnId').val(id); $('#ctl00_cphContenuto_btnModifica').click(); }
        function nuovo() {$('#ctl00_cphContenuto_btnNuovo').click();}

        function PatrimonialeAttivo() {
            //Attivo
            var TaCrediti = FromCurrencyToNumber($('[id$=txtTACrediti_text]').val());
            var TaImmImmateriali = FromCurrencyToNumber($('[id$=txtImmImmateriali_text]').val());
            var TaImmMateriali = FromCurrencyToNumber($('[id$=txtImmMateriali_text]').val());
            var TaImmPartecipazioni = FromCurrencyToNumber($('[id$=txtImmPartecipazioni_text]').val());
            var TaImmCrediti = FromCurrencyToNumber($('[id$=txtImmCrediti_text]').val());

            var totImmFinan = TaImmPartecipazioni + TaImmCrediti;
            totImmFinan = Arrotonda(totImmFinan);
            $('[id$=lblTaImmFinanziarie_text]').text(FromNumberToCurrency(totImmFinan));

            var TotImmobilizzazioni = TaImmImmateriali + TaImmMateriali + totImmFinan;
            TotImmobilizzazioni = Arrotonda(TotImmobilizzazioni);
            $('[id$=lblTAtotImm_text]').text(FromNumberToCurrency(TotImmobilizzazioni));

            //Attivo Circolante
            var AcRimanenze = FromCurrencyToNumber($('[id$=txtACRimanenze_text]').val());
            var AcClienti = FromCurrencyToNumber($('[id$=txtACClienti_text]').val());
            var AcAltri = FromCurrencyToNumber($('[id$=txtACaltri_text]').val());
            var AcDepPostale = FromCurrencyToNumber($('[id$=txtACDepPostale_text]').val());
            var AcDispoLiquide = FromCurrencyToNumber($('[id$=txtACDispoLiquide_text]').val());

            var TotAcCreditiVerso = AcClienti + AcAltri;
            TotAcCreditiVerso = Arrotonda(TotAcCreditiVerso);
            $('[id$=lblACTotCreditiVerso_text]').text(FromNumberToCurrency(TotAcCreditiVerso));

            var TotDispLiquide = AcDepPostale + AcDispoLiquide;
            TotDispLiquide = Arrotonda(TotDispLiquide);
            $('[id$=lblDispLiquide_text]').text(FromNumberToCurrency(TotDispLiquide));


            var TotAttivoCircolante = AcRimanenze + TotAcCreditiVerso + AcDepPostale + AcDispoLiquide;
            TotAttivoCircolante = Arrotonda(TotAttivoCircolante);
            $('[id$=lblTotAttCirc_text]').text(FromNumberToCurrency(TotAttivoCircolante));

            var RateiRisconti = FromCurrencyToNumber($('[id$=txtTARatei_text]').val());

            var TA = TaCrediti + TotImmobilizzazioni + TotAttivoCircolante + RateiRisconti;
            TA = Arrotonda(TA);
            $('[id$=lblTotaleAttivo_text]').text(FromNumberToCurrency(TA));

        }


        function PatrimonialePassivo() {
            //Passivo


            var TpCapitale = FromCurrencyToNumber($('[id$=txtTPCapitale_text]').val());
            var TpRiserve = FromCurrencyToNumber($('[id$=txtTPRiserve_text]').val());
            var TprisRival = FromCurrencyToNumber($('[id$=txtTPriserveRival_text]').val());
            var TpRisLegale = FromCurrencyToNumber($('[id$=txtTPRisLegale_text]').val());
            var TpAzioniProprie = FromCurrencyToNumber($('[id$=txtTPazioniproprie_text]').val());
            var TpRiserve904Stat = FromCurrencyToNumber($('[id$=txtTPRiserva904_text]').val());
            var TpAltreRiserveStat = FromCurrencyToNumber($('[id$=txtTpAltreRiserveStat_text]').val());


            //Tot lblTPtotriserveStat
            var TPtotriserveStat = TpRiserve904Stat + TpAltreRiserveStat;
            TPtotriserveStat = Arrotonda(TPtotriserveStat);
            $('[id$=lblTPtotriserveStat_text]').text(FromNumberToCurrency(TPtotriserveStat));

            var AltreScadenze = FromCurrencyToNumber($('[id$=txtTPaltreRiserve_text]').val());
            var TpUtilePrec = FromCurrencyToNumber($('[id$=txtTPutilePrecedenti_text]').val());
            var TpUtileEsercizio = FromCurrencyToNumber($('[id$=txtTPutiliesercizio_text]').val());

            var TPtotPatrimonioNetto = TpCapitale + TpRiserve + TprisRival + TpRisLegale + TpAzioniProprie + TPtotriserveStat + AltreScadenze + TpUtileEsercizio + TpUtilePrec;
            TPtotPatrimonioNetto = Arrotonda(TPtotPatrimonioNetto);
            $('[id$=lblTPTotPatrNetto_text]').text(FromNumberToCurrency(TPtotPatrimonioNetto));


            var TpFondi = FromCurrencyToNumber($('[id$=txtTPFondi_text]').val());
            var TpFineRapporto = FromCurrencyToNumber($('[id$=txtTPFineRapp_text]').val());

            var TpDebitiBanche = FromCurrencyToNumber($('[id$=txtTPdebBanche_text]').val());
            var TpDebFinanziatori = FromCurrencyToNumber($('[id$=txtTPdebfinanziatori_text]').val());
            var TpDebFornitori = FromCurrencyToNumber($('[id$=txtTPdebFornitori_text]').val());
            var TpDebPrevidenziali = FromCurrencyToNumber($('[id$=txtTPdebPrevidenziali_text]').val());
            var TpAltriDebiti = FromCurrencyToNumber($('[id$=txtTPAltriDebiti_text]').val());

            var TotaleDebiti = TpDebitiBanche + TpDebFinanziatori + TpDebFornitori + TpDebPrevidenziali + TpAltriDebiti;
            TotaleDebiti = Arrotonda(TotaleDebiti);
            $('[id$=lblTPDebiti_text]').text(FromNumberToCurrency(TotaleDebiti));

            var TpRatei = FromCurrencyToNumber($('[id$=txtTPRateiRisconti_text]').val());

            var TotalePassivo = TPtotPatrimonioNetto + TpFondi + TpFineRapporto + TotaleDebiti + TpRatei;
            TotalePassivo = Arrotonda(TotalePassivo);
            $('[id$=lblTotalePassivo_text]').text(FromNumberToCurrency(TotalePassivo));

        }

        function ContoEconomico() {

            var PLVricaviVendite = FromCurrencyToNumber($('[id$=txtPLVricaviVendite_text]').val());
            var PLValtriRicavi = FromCurrencyToNumber($('[id$=txtPLValtriRicavi_text]').val());

            var PLV = PLVricaviVendite + PLValtriRicavi;
            PLV = Arrotonda(PLV);
            $('[id$=lblPLV_text]').text(FromNumberToCurrency(PLV));

            var CPmateriePrime = FromCurrencyToNumber($('[id$=txtCPmaterieprime_text]').val());
            var CpServizi = FromCurrencyToNumber($('[id$=txtCPservizi_text]').val());
            var CpBeniTerzi = FromCurrencyToNumber($('[id$=txtCPbeniterzi_text]').val());
            var CpPersonale = FromCurrencyToNumber($('[id$=txtCPersonale_text]').val());
            var CpAmmortamenti = FromCurrencyToNumber($('[id$=txtCPammortamenti_text]').val());
            var CPvarRimanenze = FromCurrencyToNumber($('[id$=txtCPvarRimanenze_text]').val());
            var CpOneri = FromCurrencyToNumber($('[id$=txtCPoneri_text]').val());

            var TotaleCostiProduzione = CPmateriePrime + CpServizi + CpBeniTerzi + CpPersonale + CpAmmortamenti + CPvarRimanenze + CpOneri;
            TotaleCostiProduzione = Arrotonda(TotaleCostiProduzione);
            $('[id$=lblCPtotale_text]').text(FromNumberToCurrency(TotaleCostiProduzione));

            var DiffPlvCp = PLV - TotaleCostiProduzione;
            DiffPlvCp = Arrotonda(DiffPlvCp);
            $('[id$=lblDiffPlvCp_text]').text(FromNumberToCurrency(DiffPlvCp));

            var POFaltriproventi = FromCurrencyToNumber($('[id$=txtPOFaltriproventi_text]').val());
            var POFinteressi = FromCurrencyToNumber($('[id$=txtPOFinteressi_text]').val());

            var DiffProventi = POFaltriproventi - POFinteressi;
            DiffProventi = Arrotonda(DiffProventi);
            $('[id$=lblPOFtotale_text]').text(FromNumberToCurrency(DiffProventi));

            var RettAttFin = FromCurrencyToNumber($('[id$=txtRettAttFin_text]').val());

            var POSProventiStraor = FromCurrencyToNumber($('[id$=txtPOSProventiStraor_text]').val());
            var POSoneri = FromCurrencyToNumber($('[id$=txtPOSoneri_text]').val());

            var TotalePOS = POSProventiStraor - POSoneri;
            TotalePOS = Arrotonda(TotalePOS);
            $('[id$=lblPOStotale_text]').text(FromNumberToCurrency(TotalePOS));

            var TotPrimaDelleImposte = DiffPlvCp + DiffProventi + RettAttFin + TotalePOS;
            TotPrimaDelleImposte = Arrotonda(TotPrimaDelleImposte);
            $('[id$=lblTotPrimaImposte_text]').text(FromNumberToCurrency(TotPrimaDelleImposte));

            var TotImposte = FromCurrencyToNumber($('[id$=txtTotImposte_text]').val());

            var risultatoesercizio = TotPrimaDelleImposte - TotImposte;
            risultatoesercizio = Arrotonda(risultatoesercizio);
            $('[id$=lblRisutatoEsercizio_text]').text(FromNumberToCurrency(risultatoesercizio));
            $('[id$=lblUtileEsercizio_text]').text(FromNumberToCurrency(risultatoesercizio));

        }

        function ControlloAnno(ev) {
            var oggi = new Date(); var anno = oggi.getFullYear();
            var annoInserito = $('[id$=txtAnno_text]').val();
            if (annoInserito < anno) {
                alert("Attenzione l'anno inserito non è corretto.\nIl bilancio deve riferirsi ad un anno successivo il " + anno);
                $('[id$=txtAnno_text]').val(anno + 1);
                return stopEvent(ev);
            }
        }


		
		//-->
    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnId" runat="server" />
        <asp:Button ID="btnModifica" runat="server" Text="Button" OnClick="btnEdit_Click" />
        <asp:Button ID="btnNuovo" runat="server" Text="Button" OnClick="btnNuovo_Click" CausesValidation="false" />
    </div>
    <br />
    <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Bilanci Impresa |Nuovo" />
    <table width="600px" id="tbRiepilogoBilanci" class="tableTab" runat="server" visible="false">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 500px">
                            &nbsp; - Elenco dei bilanci inseriti per l'impresa specificata.
                        </td>
                        <td>
                            &nbsp;
                            <input type="button" class="Button" style="width: 80px" value="Indietro" onclick="location='BusinessPlan.aspx'" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                &nbsp;
            </td>
        </tr>
           <tr>
            <td class="separatore">
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
                <siar:DataGrid ID="dgBilancio" runat="server" Width="100%" PageSize="5" AllowPaging="True"
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
                </siar:DataGrid>
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
                <Siar:TextBox  ID="txtAnno" runat="server" DataColumn="Anno" MaxLength="4" NomeCampo="Anno di riferimento"
                    Obbligatorio="True" Width="40px" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 50%;">
                <strong><em>&nbsp;&nbsp; Data di chiusura dell'esercizio finanziario :&nbsp; </em>
                </strong>
            </td>
            <td style="width: 50%">
                <siar:DateTextBox ID="txtDataBilancio" runat="server" Obbligatorio="True" Width="89px"
                    NomeCampo="Data bilancio" />
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
        <tr style="vertical-align: top">
            <td>
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
                        <td style="text-align: center" colspan="2">
                            <strong><em><span style="text-decoration: underline">STATO PATRIMONIALE - ATTIVO </span>
                            </em></strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%;">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 40%;">
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; <strong>TOTALE CREDITI V/SOCI<span style="font-size: 8pt"> PER VERSAMENTI DOVUTI</span></strong>
                        </td>
                        <td align="right" style="width: 40%">
                            <siar:CurrencyBox ID="txtTACrediti" runat="server" Width="100px" DataColumn="TaCreditiSoci" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">IMMOBILIZZAZIONI</span>
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <em>Totale Immobilizzazioni immateriali</em>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtImmImmateriali" runat="server" Width="100px" DataColumn="TaImmImmateriali" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <em>Totale Immobilizzazioni materiali</em>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtImmMateriali" runat="server" Width="100px" DataColumn="TaImmobMateriali" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <em>Immobilizzazioni finanziarie</em>
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                            Totale Partecipazioni in
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtImmPartecipazioni" runat="server" Width="100px" DataColumn="TaImmPartecipazioni" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                            Totale Crediti (immob. finanziarie) verso
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtImmCrediti" runat="server" Width="100px" DataColumn="TaImmCrediti" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <em>Totale Immobilizzazioni finanziarie</em>
                        </td>
                        <td align="right">
                            <siar:Label ID="lblTaImmFinanziarie" runat="server">
                            </siar:Label>
                            &nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            <strong>&nbsp;TOTALE IMMOBILIZZAZIONI</strong>
                        </td>
                        <td align="right">
                            <b>
                                <siar:Label ID="lblTAtotImm" runat="server">
                                </siar:Label>
                            </b>&nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">ATTIVO CIRCOLANTE</span>
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <em>Totale Rimanenze</em>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtACRimanenze" runat="server" Width="100px" DataColumn="TaAcRimanenze" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%; height: 17px">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <em>Crediti (att.circ.) Verso:</em>
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                            Totale Clienti
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtACClienti" runat="server" Width="100px" DataColumn="TaAcCreditiClienti" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                            Totale Altri (circ.)
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtACaltri" runat="server" Width="100px" DataColumn="TaAcCreditiAltri" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%; height: 17px">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <em>Totale Crediti Verso</em>
                        </td>
                        <td align="right">
                            <siar:Label ID="lblACTotCreditiVerso" runat="server">
                            </siar:Label>
                            &nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%; height: 17px">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <em>Disponibilità liquide</em>
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%; height: 17px">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; Totale
                            Depositi postali e bancari
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtACDepPostale" runat="server" DataColumn="TaAcDepPostali"
                                Width="100px"></siar:CurrencyBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%; height: 17px">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; Totale
                            Denaro e valori in cassa
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtACDispoLiquide" runat="server" DataColumn="TaAcDispoLiquide"
                                Width="100px"></siar:CurrencyBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%; height: 17px">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <em>Totale Disponibilita liquide</em>
                        </td>
                        <td align="right">
                            <siar:Label ID="lblDispLiquide" runat="server">
                            </siar:Label>
                            &nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <strong>&nbsp;TOTALE ATTIVO CIRCOLANTE</strong>
                        </td>
                        <td align="right">
                            <b>
                                <siar:Label ID="lblTotAttCirc" runat="server">
                                </siar:Label>
                            </b>&nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            <strong>&nbsp;TOTALE RATEI E RISCONTI</strong>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTARatei" runat="server" Width="100px" DataColumn="TaRateiRisconti" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;&nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="text-align: center; width: 60%;">
                            <strong>TOTALE STATO PATRIMONIALE - ATTIVO</strong>
                        </td>
                        <td align="right">
                            <strong>
                                <siar:Label ID="lblTotaleAttivo" runat="server" Text=" ">
                                </siar:Label>
                                &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;</strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; width: 60%;">
                            &nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="2">
                            <strong><em><span style="text-decoration: underline">STATO PATRIMONIALE - PASSIVO </span>
                            </em></strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%; height: 5px;">
                            &nbsp;
                        </td>
                        <td align="right" style="height: 5px">
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">PATRIMONIO NETTO</span>
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; <em>Capitale sociale/fondi propri</em>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTPCapitale" runat="server" Width="100px" DataColumn="TpPnCapitale" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; <em>Riserve da sovrapprezzo delle azioni</em>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTPRiserve" runat="server" Width="100px" DataColumn="TpPnSovrapAzioni" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; <em>Riserve di rivalutazione</em>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTPriserveRival" runat="server" Width="100px" DataColumn="TpPnRisRivalutazione" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; <em>Riserva legale</em>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTPRisLegale" runat="server" Width="100px" DataColumn="TpPnRisLegale" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; <em>Riserva azioni proprie in portafoglio</em>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTPazioniproprie" runat="server" Width="100px" DataColumn="TpPnAzioniProprie" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; <em>Riserve statutarie</em>
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;Riserva indivisibile
                            legge 904
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTPRiserva904" runat="server" Width="100px" DataColumn="TpPnRiserva904" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;Altre riserve statutarie
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTpAltreRiserveStat" runat="server" Width="100px" DataColumn="TpPnRiserveStatutarie" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; <em>Totale Riserve statutarie</em>
                        </td>
                        <td align="right">
                            <siar:Label ID="lblTPtotriserveStat" runat="server">
                            </siar:Label>
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; <em>Totale altre riserve</em>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTPaltreRiserve" runat="server" Width="100px" DataColumn="TpPnAltreRiserve" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; <em>Utili (Perdite-) esercizi precedenti</em>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTPutilePrecedenti" runat="server" Width="100px" DataColumn="TpPnUtiliPrecedenti" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; <em>Utili (Perdita-) dell'esercizio</em>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTPutiliesercizio" runat="server" Width="100px" DataColumn="TpPnUtiliEsercizio" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <strong>&nbsp;TOTALE PATRIMONIO NETTO</strong>
                        </td>
                        <td align="right">
                            <b>
                                <siar:Label ID="lblTPTotPatrNetto" runat="server">
                                </siar:Label>
                            </b>&nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; <strong>FONDI PER RISCHI ED ONERI</strong><span style="text-decoration: underline"></span>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTPFondi" runat="server" Width="100px" DataColumn="TpFondiRischiOneri" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp; <strong>TRATTAMENTO FINE RAPPORTO <span style="font-size: 8pt">LAVORO SUBBOR.</span></strong>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTPFineRapp" runat="server" Width="100px" DataColumn="TpFineRapporto" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; <span style="text-decoration: underline">DEBITI</span>
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; <em>Debiti verso banche</em>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTPdebBanche" runat="server" Width="100px" DataColumn="TpDebitiBanche" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; <em>Debiti verso altri finanziatori</em>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTPdebfinanziatori" runat="server" Width="100px" DataColumn="TpDebitiFinanziatori" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; <em>Debiti verso altri fornitori e soci</em>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTPdebFornitori" runat="server" Width="100px" DataColumn="TpDebitiFornitori" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; <em>Debiti verso istituti previdenziali</em>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTPdebPrevidenziali" runat="server" Width="100px" DataColumn="TpDebitiIstPrevid" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp; <em>Altri debiti</em>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTPAltriDebiti" runat="server" Width="100px" DataColumn="TpAltriDebiti" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <strong>&nbsp;TOTALE DEBITI</strong>
                        </td>
                        <td align="right">
                            <b>
                                <siar:Label ID="lblTPDebiti" runat="server">
                                </siar:Label>
                                &nbsp; &nbsp;</b>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;<strong>RATEI E RISCONTI</strong>
                        </td>
                        <td align="right">
                            <siar:CurrencyBox ID="txtTPRateiRisconti" runat="server" Width="100px" DataColumn="TpRateiRisconti" />
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
                        <td style="text-align: center; width: 60%;">
                            <strong>TOTALE STATO PATRIMONIALE - &nbsp;PASSIVO</strong>
                        </td>
                        <td align="right">
                            <strong>
                                <siar:Label ID="lblTotalePassivo" runat="server">
                                </siar:Label>
                                &nbsp; &nbsp;</strong>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td style="vertical-align: top">
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
                            <strong><em><span style="text-decoration: underline">CONTO ECONOMICO</span></em></strong>
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
                        <td colspan="1" style="width: 60%">
                            <span style="text-decoration: underline">Valore della produzione</span>
                        </td>
                        <td align="right" style="width: 40%">
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
                            <em>&nbsp;&nbsp; <span>Ricavi vendite e prestazioni</span></em>
                        </td>
                        <td align="right" style="width: 40%">
                            <siar:CurrencyBox ID="txtPLVricaviVendite" runat="server" Width="100px" DataColumn="PlvRicaviVendita" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;&nbsp; <em><span>Altri ricavi e proventi (attività ord.)</span></em>
                        </td>
                        <td align="right" style="width: 200px">
                            &nbsp;<siar:CurrencyBox ID="txtPLValtriRicavi" runat="server" Width="100px" DataColumn="PlvAltriRicavi" />
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
                            &nbsp;<strong>TOTALE VALORE DELLA PRODUZIONE</strong>
                        </td>
                        <td style="width: 200px" align="right">
                            <b>
                                <siar:Label ID="lblPLV" runat="server" Text=" " />
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
                            <span style="text-decoration: underline">Costi della produzione</span>
                        </td>
                        <td align="right" style="width: 200px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; <span>Totale Materie prime&nbsp; suss. cons. merci</span></em>
                        </td>
                        <td align="right" style="width: 40%">
                            <siar:CurrencyBox ID="txtCPmaterieprime" runat="server" Width="100px" DataColumn="CpMateriePrime" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; Totale Servizi</em>
                        </td>
                        <td align="right" style="width: 40%">
                            <siar:CurrencyBox ID="txtCPservizi" runat="server" Width="100px" DataColumn="CpServizi" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; Totali per godimento di beni di terzi</em>
                        </td>
                        <td align="right" style="width: 40%">
                            <siar:CurrencyBox ID="txtCPbeniterzi" runat="server" Width="100px" DataColumn="CpBeniTerzi" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; Totale per il personale</em>
                        </td>
                        <td align="right" style="width: 40%">
                            <siar:CurrencyBox ID="txtCPersonale" runat="server" Width="100px" DataColumn="CpPersonale" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; Totale Ammortamenti e svalutazioni</em>
                        </td>
                        <td align="right" style="width: 40%">
                            <siar:CurrencyBox ID="txtCPammortamenti" runat="server" Width="100px" DataColumn="CpAmmSvalutazioni" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; Totale variazioni rimanenze di: materie prime, suss. con.</em>
                        </td>
                        <td align="right" style="width: 40%">
                            <siar:CurrencyBox ID="txtCPvarRimanenze" runat="server" Width="100px" DataColumn="CpVarRimanenze" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; Totale oneri diversi di gestione</em>
                        </td>
                        <td align="right" style="width: 40%">
                            <siar:CurrencyBox ID="txtCPoneri" runat="server" Width="100px" DataColumn="CpOneri" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 40%">
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; text-align: left;">
                            <strong>TOTALE COSTI DELLA PRODUZIONE (attività ord.)</strong>
                        </td>
                        <td align="right" style="width: 40%">
                            <strong>
                                <siar:Label ID="lblCPtotale" runat="server" Text=" " />
                            </strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                        </td>
                        <td align="right" style="width: 40%">
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; text-align: left; height: 13px;">
                            <strong>TOTALE DIFF.TRA VALORI E COSTI DI PRODUZ.</strong>
                        </td>
                        <td align="right" style="width: 40%; height: 13px;">
                            <strong>
                                <siar:Label ID="lblDiffPlvCp" runat="server" Text=" " />
                            </strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;&nbsp;
                        </td>
                        <td style="width: 40%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <span style="text-decoration: underline">Proventi e oneri finanziari</span>
                        </td>
                        <td align="right" style="width: 200px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; <span>Totale altri proventi finanz. (non da partecipaz.)</span></em>
                        </td>
                        <td align="right" style="width: 40%">
                            <siar:CurrencyBox ID="txtPOFaltriproventi" runat="server" Width="100px" DataColumn="PofAltriProventi" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; <span>Totale interessi (pass.) e oneri finanziari</span></em>
                        </td>
                        <td align="right" style="width: 40%">
                            <siar:CurrencyBox ID="txtPOFinteressi" runat="server" Width="100px" DataColumn="PofInteressiOneri" />
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
                            <strong>TOT. DIFF. PROVENTI E ONERI FINANZIARI</strong>
                        </td>
                        <td align="right" valign="middle" style="width: 200px">
                            <b>
                                <siar:Label ID="lblPOFtotale" runat="server" Text=" " />
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
                            <span style="text-decoration: underline">Totale rettifica di valore di attivita Finanziarie&nbsp;</span>
                        </td>
                        <td align="right" style="width: 40%">
                            <siar:CurrencyBox ID="txtRettAttFin" runat="server" Width="100px" DataColumn="RettValAttFinanziarie" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <span style="text-decoration: underline">Proventi e oneri straordinari</span>
                        </td>
                        <td align="right" style="width: 40%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; <span>Totale proventi straordinari (extra attività ord.)</span></em>
                        </td>
                        <td align="right" style="width: 40%">
                            <siar:CurrencyBox ID="txtPOSProventiStraor" runat="server" Width="100px" DataColumn="PosProventiStraord" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; <span>Totale oneri straordinari (extra attività ord.)</span></em>
                        </td>
                        <td align="right" style="width: 40%">
                            <siar:CurrencyBox ID="txtPOSoneri" runat="server" Width="100px" DataColumn="PosOneriStraord" />
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
                            <strong>TOTALE DELLE PARTITE STRAORDINARIE</strong>
                        </td>
                        <td align="right" valign="middle" style="width: 40%">
                            <b>
                                <siar:Label ID="lblPOStotale" runat="server" Text=" " />
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; height: 17px; text-align: left;" valign="middle">
                            <strong>TOTALE RISULTATO PRIMA DELLE IMPOSTE</strong>
                        </td>
                        <td align="right" valign="middle" style="width: 40%">
                            <b>
                                <siar:Label ID="lblTotPrimaImposte" runat="server" Text=" " />
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
                            <span style="text-decoration: underline">Totale Imposte sul reddito di esercizio</span>
                        </td>
                        <td align="right" style="width: 40%">
                            <siar:CurrencyBox ID="txtTotImposte" runat="server" Width="100px" DataColumn="ImposteReddito" />
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
                            <strong>RISULTATO DELL'ESERCIZIO</strong>
                        </td>
                        <td align="right" style="width: 40%">
                            <strong>
                                <siar:Label ID="lblRisutatoEsercizio" runat="server" Text=" " />
                            </strong>
                        </td>
                    </tr>
                    <tr style="background-color: #AAAE80; color: white;">
                        <td style="width: 60%; text-align: left;">
                            <strong>UTILE (PERDITA) DELL'ESERCIZIO</strong>
                        </td>
                        <td align="right" style="width: 40%">
                            <strong>
                                <siar:Label ID="lblUtileEsercizio" runat="server" Text=" " />
                            </strong>
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
                <siar:Button ID="btnSalva" Text="Salva" runat="server" OnClientClick="return ControlloAnno(event)"
                    Width="180px" Modifica="true" OnClick="btnSalva_Click" />&nbsp;&nbsp;
                <siar:Button ID="btnElimina" Text="Elimina" runat="server" CausesValidation="false"
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
