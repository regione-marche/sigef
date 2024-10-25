<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Impresa.ImpresaBilancioIndustriale" CodeBehind="ImpresaBilancioIndustriale.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
		<!--
        function PatrimonialeAttivo() {
            //Attivo
            var TaCrediti=document.getElementById("ctl00_cphContenuto_txtTACrediti_text").value;
            var TaImmImmateriali=document.getElementById("ctl00_cphContenuto_txtImmImmateriali_text").value;
            var TaImmMateriali=document.getElementById("ctl00_cphContenuto_txtImmMateriali_text").value;
            var TaImmPartecipazioni=document.getElementById("ctl00_cphContenuto_txtImmPartecipazioni_text").value;
            var TaImmCrediti=document.getElementById("ctl00_cphContenuto_txtImmCrediti_text").value;


            TaCrediti=decimale(TaCrediti);
            TaImmImmateriali=decimale(TaImmImmateriali);
            TaImmMateriali=decimale(TaImmMateriali);
            TaImmPartecipazioni=decimale(TaImmPartecipazioni);
            TaImmCrediti=decimale(TaImmCrediti);


            var totImmFinan=TaImmPartecipazioni+TaImmCrediti;
            totImmFinan=Math.round(totImmFinan*100);
            totImmFinan=totImmFinan/100;
            if(!isNaN(totImmFinan)) ctl00$cphContenuto$lblTaImmFinanziarie_text.innerHTML='€  '+totImmFinan;
            else { ctl00$cphContenuto$lblTaImmFinanziarie_text.innerHTML='0'; }

            var TotImmobilizzazioni=TaImmImmateriali+TaImmMateriali+totImmFinan;
            TotImmobilizzazioni=Math.round(TotImmobilizzazioni*100);
            TotImmobilizzazioni=TotImmobilizzazioni/100;
            if(!isNaN(TotImmobilizzazioni)) ctl00$cphContenuto$lblTAtotImm_text.innerHTML='€  '+TotImmobilizzazioni;
            else { ctl00$cphContenuto$lblTAtotImm_text.innerHTML='0'; }

            //Attivo Circolante
            var AcRimanenze=document.getElementById("ctl00_cphContenuto_txtACRimanenze_text").value;
            var AcClienti=document.getElementById("ctl00_cphContenuto_txtACClienti_text").value;
            var AcAltri=document.getElementById("ctl00_cphContenuto_txtACaltri_text").value;
            var AcDepPostale=document.getElementById("ctl00_cphContenuto_txtACDepPostale_text").value;
            var AcDispoLiquide=document.getElementById("ctl00_cphContenuto_txtACDispoLiquide_text").value;

            AcRimanenze=decimale(AcRimanenze);
            AcClienti=decimale(AcClienti);
            AcAltri=decimale(AcAltri);
            AcDepPostale=decimale(AcDepPostale);
            AcDispoLiquide=decimale(AcDispoLiquide);


            var TotAcCreditiVerso=AcClienti+AcAltri;
            TotAcCreditiVerso=Math.round(TotAcCreditiVerso*100);
            TotAcCreditiVerso=TotAcCreditiVerso/100;
            if(!isNaN(TotAcCreditiVerso)) ctl00$cphContenuto$lblACTotCreditiVerso_text.innerHTML='€  '+TotAcCreditiVerso;
            else { ctl00$cphContenuto$lblACTotCreditiVerso_text.innerHTML='0'; }

            var TotDispLiquide=AcDepPostale+AcDispoLiquide;
            TotDispLiquide=Math.round(TotDispLiquide*100);
            TotDispLiquide=TotDispLiquide/100;
            if(!isNaN(TotDispLiquide)) ctl00$cphContenuto$lblDispLiquide_text.innerHTML='€  '+TotDispLiquide;
            else { ctl00$cphContenuto$lblDispLiquide_text.innerHTML='0'; }

            var TotAttivoCircolante=AcRimanenze+TotAcCreditiVerso+TotDispLiquide;
            TotAttivoCircolante=Math.round(TotAttivoCircolante*100);
            TotAttivoCircolante=TotAttivoCircolante/100;
            if(!isNaN(TotAttivoCircolante)) ctl00$cphContenuto$lblTotAttCirc_text.innerHTML='€  '+TotAttivoCircolante;
            else { ctl00$cphContenuto$lblTotAttCirc_text.innerHTML='0'; }

            var RateiRisconti=document.getElementById("ctl00_cphContenuto_txtTARatei_text").value;


            var TA=TaCrediti+TotImmobilizzazioni+TotAttivoCircolante+decimale(RateiRisconti);
            TA=Math.round(TA*100);
            TA=TA/100;
            if(!isNaN(TA)) ctl00$cphContenuto$lblTotaleAttivo_text.innerHTML='€  '+TA;
            else { ctl00$cphContenuto$lblTotaleAttivo_text.innerHTML='0'; }

        }


        function PatrimonialePassivo() {
            //Passivo


            var TpCapitale=document.getElementById("ctl00_cphContenuto_txtTPCapitale_text").value;
            var TpRiserve=document.getElementById("ctl00_cphContenuto_txtTPRiserve_text").value;
            var TprisRival=document.getElementById("ctl00_cphContenuto_txtTPriserveRival_text").value;
            var TpRisLegale=document.getElementById("ctl00_cphContenuto_txtTPRisLegale_text").value;
            var TpAzioniProprie=document.getElementById("ctl00_cphContenuto_txtTPazioniproprie_text").value;
            var TpRiserve904Stat=document.getElementById("ctl00_cphContenuto_txtTPRiserva904_text").value;
            var TpAltreRiserveStat=document.getElementById("ctl00_cphContenuto_txtTpAltreRiserveStat_text").value;

            TpCapitale=decimale(TpCapitale);
            TpRiserve=decimale(TpRiserve);
            TprisRival=decimale(TprisRival);
            TpRisLegale=decimale(TpRisLegale);
            TpAzioniProprie=decimale(TpAzioniProprie);
            TpRiserve904Stat=decimale(TpRiserve904Stat);
            TpAltreRiserveStat=decimale(TpAltreRiserveStat);

            //Tot lblTPtotriserveStat
            var TPtotriserveStat=TpRiserve904Stat+TpAltreRiserveStat;
            TPtotriserveStat=Math.round(TPtotriserveStat*100);
            TPtotriserveStat=TPtotriserveStat/100;
            if(!isNaN(TPtotriserveStat)) ctl00$cphContenuto$lblTPtotriserveStat_text.innerHTML='€  '+TPtotriserveStat;
            else { ctl00$cphContenuto$lblTPtotriserveStat_text.innerHTML='0'; }

            var AltreScadenze=document.getElementById("ctl00_cphContenuto_txtTPaltreRiserve_text").value;
            var TpUtilePrec=document.getElementById("ctl00_cphContenuto_txtTPutilePrecedenti_text").value;
            var TpUtileEsercizio=document.getElementById("ctl00_cphContenuto_txtTPutiliesercizio_text").value;


            AltreScadenze=decimale(AltreScadenze);
            TpUtileEsercizio=decimale(TpUtileEsercizio);
            TpUtilePrec=decimale(TpUtilePrec);

            var TPtotPatrimonioNetto=TpCapitale+TpRiserve+TprisRival+TpRisLegale+TpAzioniProprie+TPtotriserveStat+AltreScadenze+TpUtileEsercizio+TpUtilePrec;
            TPtotPatrimonioNetto=Math.round(TPtotPatrimonioNetto*100);
            TPtotPatrimonioNetto=TPtotPatrimonioNetto/100;
            if(!isNaN(TPtotPatrimonioNetto)) ctl00$cphContenuto$lblTPTotPatrNetto_text.innerHTML='€  '+TPtotPatrimonioNetto;
            else { ctl00$cphContenuto$lblTPTotPatrNetto.innerHTML='0'; }



            var TpFondi=document.getElementById("ctl00_cphContenuto_txtTPFondi_text").value;
            var TpFineRapporto=document.getElementById("ctl00_cphContenuto_txtTPFineRapp_text").value;
            TpFondi=decimale(TpFondi);
            TpFineRapporto=decimale(TpFineRapporto);

            var TpDebitiBanche=document.getElementById("ctl00_cphContenuto_txtTPdebBanche_text").value;
            var TpDebFinanziatori=document.getElementById("ctl00_cphContenuto_txtTPdebfinanziatori_text").value;
            var TpDebFornitori=document.getElementById("ctl00_cphContenuto_txtTPdebFornitori_text").value;
            var TpDebPrevidenziali=document.getElementById("ctl00_cphContenuto_txtTPdebPrevidenziali_text").value;
            var TpAltriDebiti=document.getElementById("ctl00_cphContenuto_txtTPAltriDebiti_text").value;

            TpDebitiBanche=decimale(TpDebitiBanche);
            TpDebFinanziatori=decimale(TpDebFinanziatori);
            TpDebFornitori=decimale(TpDebFornitori);
            TpDebPrevidenziali=decimale(TpDebPrevidenziali);
            TpAltriDebiti=decimale(TpAltriDebiti);

            var TotaleDebiti=TpDebitiBanche+TpDebFinanziatori+TpDebFornitori+TpDebPrevidenziali+TpAltriDebiti;
            TotaleDebiti=Math.round(TotaleDebiti*100);
            TotaleDebiti=TotaleDebiti/100;
            if(!isNaN(TotaleDebiti)) ctl00$cphContenuto$lblTPDebiti_text.innerHTML='€  '+TotaleDebiti;
            else { ctl00$cphContenuto$lblTPDebiti.innerHTML='0'; }

            var TpRatei=document.getElementById("ctl00_cphContenuto_txtTPRateiRisconti_text").value;

            var TotalePassivo=TPtotPatrimonioNetto+TpFondi+TpFineRapporto+TotaleDebiti+decimale(TpRatei);
            TotalePassivo=Math.round(TotalePassivo*100);
            TotalePassivo=TotalePassivo/100;
            if(!isNaN(TotalePassivo)) ctl00$cphContenuto$lblTotalePassivo_text.innerHTML='€  '+TotalePassivo;
            else { ctl00$cphContenuto$lblTotalePassivo.innerHTML='0'; }





        }

        function ContoEconomico() {

            var PLVricaviVendite=document.getElementById("ctl00_cphContenuto_txtPLVricaviVendite_text").value;
            var PLValtriRicavi=document.getElementById("ctl00_cphContenuto_txtPLValtriRicavi_text").value;

            PLVricaviVendite=decimale(PLVricaviVendite);
            PLValtriRicavi=decimale(PLValtriRicavi);

            var PLV=PLVricaviVendite+PLValtriRicavi;
            PLV=Math.round(PLV*100);
            PLV=PLV/100;
            if(!isNaN(PLV)) ctl00$cphContenuto$lblPLV_text.innerHTML='€  '+PLV;
            else { ctl00$cphContenuto$lblPLV_text.innerHTML='0'; }


            var CPmateriePrime=document.getElementById("ctl00_cphContenuto_txtCPmaterieprime_text").value;
            var CpServizi=document.getElementById("ctl00_cphContenuto_txtCPservizi_text").value;
            var CpBeniTerzi=document.getElementById("ctl00_cphContenuto_txtCPbeniterzi_text").value;
            var CpPersonale=document.getElementById("ctl00_cphContenuto_txtCPersonale_text").value;
            var CpAmmortamenti=document.getElementById("ctl00_cphContenuto_txtCPammortamenti_text").value;
            var CPvarRimanenze=document.getElementById("ctl00_cphContenuto_txtCPvarRimanenze_text").value;
            var CpOneri=document.getElementById("ctl00_cphContenuto_txtCPoneri_text").value;

            CPmateriePrime=decimale(CPmateriePrime);
            CpServizi=decimale(CpServizi);
            CpBeniTerzi=decimale(CpBeniTerzi);
            CpPersonale=decimale(CpPersonale);
            CpAmmortamenti=decimale(CpAmmortamenti);
            CPvarRimanenze=decimale(CPvarRimanenze);
            CpOneri=decimale(CpOneri);

            var TotaleCostiProduzione=CPmateriePrime+CpServizi+CpBeniTerzi+CpPersonale+CpAmmortamenti+CPvarRimanenze+CpOneri;
            TotaleCostiProduzione=Math.round(TotaleCostiProduzione*100);
            TotaleCostiProduzione=TotaleCostiProduzione/100;
            if(!isNaN(TotaleCostiProduzione)) ctl00$cphContenuto$lblCPtotale_text.innerHTML='€  '+TotaleCostiProduzione;
            else { ctl00$cphContenuto$lblCPtotale_text.innerHTML='0'; }

            var DiffPlvCp=PLV-TotaleCostiProduzione;
            DiffPlvCp=Math.round(DiffPlvCp*100);
            DiffPlvCp=DiffPlvCp/100;
            if(!isNaN(DiffPlvCp)) ctl00$cphContenuto$lblDiffPlvCp_text.innerHTML='€  '+DiffPlvCp;
            else { ctl00$cphContenuto$lblDiffPlvCp_text.innerHTML='0'; }

            var POFaltriproventi=document.getElementById("ctl00_cphContenuto_txtPOFaltriproventi_text").value;
            var POFinteressi=document.getElementById("ctl00_cphContenuto_txtPOFinteressi_text").value;
            POFaltriproventi=decimale(POFaltriproventi);
            POFinteressi=decimale(POFinteressi);

            var DiffProventi=POFaltriproventi-POFinteressi;

            DiffProventi=Math.round(DiffProventi*100);
            DiffProventi=DiffProventi/100;
            if(!isNaN(DiffProventi)) ctl00$cphContenuto$lblPOFtotale_text.innerHTML='€  '+DiffProventi;
            else { ctl00$cphContenuto$lblPOFtotale_text.innerHTML='0'; }



            var RettAttFin=document.getElementById("ctl00_cphContenuto_txtRettAttFin_text").value;

            var POSProventiStraor=document.getElementById("ctl00_cphContenuto_txtPOSProventiStraor_text").value;
            var POSoneri=document.getElementById("ctl00_cphContenuto_txtPOSoneri_text").value;
            POSProventiStraor=decimale(POSProventiStraor);
            POSoneri=decimale(POSoneri);

            var TotalePOS=POSProventiStraor-POSoneri;
            TotalePOS=Math.round(TotalePOS*100);
            TotalePOS=TotalePOS/100;
            if(!isNaN(TotalePOS)) ctl00$cphContenuto$lblPOStotale_text.innerHTML='€  '+TotalePOS;
            else { ctl00$cphContenuto$lblPOStotale_text.innerHTML='0'; }

            var TotPrimaDelleImposte=DiffPlvCp+DiffProventi+decimale(RettAttFin)+TotalePOS;
            TotPrimaDelleImposte=Math.round(TotPrimaDelleImposte*100);
            TotPrimaDelleImposte=TotPrimaDelleImposte/100;
            if(!isNaN(TotPrimaDelleImposte)) {
                ctl00$cphContenuto$lblTotPrimaImposte_text.innerHTML='€  '+TotPrimaDelleImposte;
                document.all.ctl00$cphContenuto$lblTotPrimaImposte.value=TotPrimaDelleImposte;
            }
            else {
                ctl00$cphContenuto$lblTotPrimaImposte_text.innerHTML='0';
            }

            var TotImposte=document.getElementById("ctl00_cphContenuto_txtTotImposte_text").value;

            var risultatoesercizio=TotPrimaDelleImposte-decimale(TotImposte);

            risultatoesercizio=Math.round(risultatoesercizio*100);
            risultatoesercizio=risultatoesercizio/100;

            if(!isNaN(risultatoesercizio)) ctl00$cphContenuto$lblRisutatoEsercizio_text.innerHTML='€  '+risultatoesercizio;
            else { ctl00$cphContenuto$lblRisutatoEsercizio_text.innerHTML='0'; }

            if(!isNaN(risultatoesercizio)) ctl00$cphContenuto$lblUtileEsercizio_text.innerHTML='€  '+risultatoesercizio;
            else { ctl00$cphContenuto$lblUtileEsercizio_text.innerHTML='0'; }

        }

        function decimale(valore) {
            while(valore.indexOf(".")!= -1)
                valore=valore.replace(".","");
            valore=valore.replace(",",".");
            valore=parseFloat(valore);
            if(isNaN(valore)) valore=0;
            return valore;
        }

        function ControlloAnno(ev) {
            var oggi=new Date();var anno=oggi.getFullYear();
            var annoInserito=$('[id$=txtAnno]').val();
            if(annoInserito>=anno) {
                alert("Attenzione l'anno inserito non è corretto.\nIl bilancio deve riferirsi ad un anno precedente il "+anno);
                $('[id$=txtAnno]').val(anno-1);
                return stopEvent(ev);
            }
        }


        function nuovo() {
            $('#ctl00_cphContenuto_hdnId').val();$('[id$=txtAnno_text]').val();
            $('#ctl00_cphContenuto_btnNuovo').click();
        }
        function dettaglioBil(id) {
            $('#ctl00_cphContenuto_hdnId').val(id);$('#ctl00_cphContenuto_btnModifica').click();
        }
	
		
		//-->
    </script>

    <br />
    <div style="display: none">
        <asp:HiddenField ID="hdnId" runat="server" />
        <asp:Button ID="btnModifica" runat="server" Text="Button" OnClick="btnModifica_Click" />
        <asp:Button ID="btnNuovo" runat="server" Text="Button" OnClick="btnNuovo_Click" CausesValidation="false" />
    </div>
    <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Bilanci Impresa |Nuovo"
        FullValidate="True" />
    <table width="600px" id="tbRiepilogoBilanci" class="tableTab" runat="server" visible="false">
        <tr>
            <td>
                <br />
                &nbsp; - Elenco dei bilanci inseriti per l'impresa specificata.
            </td>
        </tr>
        <tr>
            <td>
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
                <Siar:DateTextBox ID="txtDataBilancio" runat="server" Obbligatorio="True" Width="89px"
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
        <tr>
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
                            <Siar:CurrencyBox ID="txtTACrediti" runat="server" Width="100px" DataColumn="TaCreditiSoci" />
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
                            <Siar:CurrencyBox ID="txtImmImmateriali" runat="server" Width="100px" DataColumn="TaImmImmateriali" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <em>Totale Immobilizzazioni materiali</em>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtImmMateriali" runat="server" Width="100px" DataColumn="TaImmobMateriali" />
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
                            <Siar:CurrencyBox ID="txtImmPartecipazioni" runat="server" Width="100px" DataColumn="TaImmPartecipazioni" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                            Totale Crediti (immob. finanziarie) verso
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtImmCrediti" runat="server" Width="100px" DataColumn="TaImmCrediti" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <em>Totale Immobilizzazioni finanziarie</em>
                        </td>
                        <td align="right">
                            <Siar:Label ID="lblTaImmFinanziarie" runat="server">
                            </Siar:Label>
                            &nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            <strong>&nbsp;TOTALE IMMOBILIZZAZIONI</strong>
                        </td>
                        <td align="right">
                            <b>
                                <Siar:Label ID="lblTAtotImm" runat="server">
                                </Siar:Label>
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
                            <Siar:CurrencyBox ID="txtACRimanenze" runat="server" Width="100px" DataColumn="TaAcRimanenze" />
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
                            <Siar:CurrencyBox ID="txtACClienti" runat="server" Width="100px" DataColumn="TaAcCreditiClienti" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                            Totale Altri (circ.)
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtACaltri" runat="server" Width="100px" DataColumn="TaAcCreditiAltri" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%; height: 17px">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <em>Totale Crediti Verso</em>
                        </td>
                        <td align="right">
                            <Siar:Label ID="lblACTotCreditiVerso" runat="server">
                            </Siar:Label>
                            &nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; <em>Disponibilità
                                liquide</em>
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; Totale
                            Depositi postali e bancari
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtACDepPostale" runat="server" Width="100px" DataColumn="TaAcDepPostali" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; Totale
                            Denaro e valori in cassa
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtACDispoLiquide" runat="server" Width="100px" DataColumn="TaAcDispoLiquide" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <em>Totale Disponibilita liquide</em>
                        </td>
                        <td align="right">
                            <Siar:Label ID="lblDispLiquide" runat="server">
                            </Siar:Label>
                            &nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <strong>&nbsp;TOTALE ATTIVO CIRCOLANTE</strong>
                        </td>
                        <td align="right">
                            <b>
                                <Siar:Label ID="lblTotAttCirc" runat="server">
                                </Siar:Label>
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
                            <Siar:CurrencyBox ID="txtTARatei" runat="server" Width="100px" DataColumn="TaRateiRisconti" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;&nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr style="background-color: #89bbdb; color: white;">
                        <td style="text-align: center; width: 60%;">
                            <strong>TOTALE STATO PATRIMONIALE - ATTIVO</strong>
                        </td>
                        <td align="right">
                            <strong>
                                <Siar:Label ID="lblTotaleAttivo" runat="server" Text=" ">
                                </Siar:Label>
                                &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</strong>
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
                            &nbsp; &nbsp; &nbsp;&nbsp; <em>Capitale sociale/fondi propri</em>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtTPCapitale" runat="server" Width="100px" DataColumn="TpPnCapitale" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; <em>Riserve da sovrapprezzo delle azioni</em>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtTPRiserve" runat="server" Width="100px" DataColumn="TpPnSovrapAzioni" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; <em>Riserve di rivalutazione</em>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtTPriserveRival" runat="server" Width="100px" DataColumn="TpPnRisRivalutazione" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; <em>Riserva legale</em>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtTPRisLegale" runat="server" Width="100px" DataColumn="TpPnRisLegale" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; <em>Riserva azioni proprie in portafoglio</em>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtTPazioniproprie" runat="server" Width="100px" DataColumn="TpPnAzioniProprie" />
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
                            <Siar:CurrencyBox ID="txtTPRiserva904" runat="server" Width="100px" DataColumn="TpPnRiserva904" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;Altre riserve statutarie
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtTpAltreRiserveStat" runat="server" Width="100px" DataColumn="TpPnRiserveStatutarie" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; <em>Totale Riserve statutarie</em>
                        </td>
                        <td align="right">
                            <Siar:Label ID="lblTPtotriserveStat" runat="server">
                            </Siar:Label>
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; <em>Totale altre riserve</em>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtTPaltreRiserve" runat="server" Width="100px" DataColumn="TpPnAltreRiserve" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; <em>Utili (Perdite-) esercizi precedenti</em>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtTPutilePrecedenti" runat="server" Width="100px" DataColumn="TpPnUtiliPrecedenti" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px; width: 60%;">
                            &nbsp; &nbsp; &nbsp;&nbsp; <em>Utili (Perdita-) dell'esercizio</em>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtTPutiliesercizio" runat="server" Width="100px" DataColumn="TpPnUtiliEsercizio" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <strong>&nbsp;TOTALE PATRIMONIO NETTO</strong>
                        </td>
                        <td align="right">
                            <b>
                                <Siar:Label ID="lblTPTotPatrNetto" runat="server">
                                </Siar:Label>
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
                            <Siar:CurrencyBox ID="txtTPFondi" runat="server" Width="100px" DataColumn="TpFondiRischiOneri" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp; <strong>TRATTAMENTO FINE RAPPORTO <span style="font-size: 8pt">LAVORO SUBBOR.</span></strong>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtTPFineRapp" runat="server" Width="100px" DataColumn="TpFineRapporto" />
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
                            <Siar:CurrencyBox ID="txtTPdebBanche" runat="server" Width="100px" DataColumn="TpDebitiBanche" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; <em>Debiti verso altri finanziatori</em>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtTPdebfinanziatori" runat="server" Width="100px" DataColumn="TpDebitiFinanziatori" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; <em>Debiti verso altri fornitori e soci</em>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtTPdebFornitori" runat="server" Width="100px" DataColumn="TpDebitiFornitori" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; <em>Debiti verso istituti previdenziali</em>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtTPdebPrevidenziali" runat="server" Width="100px" DataColumn="TpDebitiIstPrevid" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp; <em>Altri debiti</em>
                        </td>
                        <td align="right">
                            <Siar:CurrencyBox ID="txtTPAltriDebiti" runat="server" Width="100px" DataColumn="TpAltriDebiti" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <strong>&nbsp;TOTALE DEBITI</strong>
                        </td>
                        <td align="right">
                            <b>
                                <Siar:Label ID="lblTPDebiti" runat="server">
                                </Siar:Label>
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
                            <Siar:CurrencyBox ID="txtTPRateiRisconti" runat="server" Width="100px" DataColumn="TpRateiRisconti" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                    <tr style="background-color: #89bbdb; color: white;">
                        <td style="text-align: center; width: 60%;">
                            <strong>TOTALE STATO PATRIMONIALE - &nbsp;PASSIVO</strong>
                        </td>
                        <td align="right">
                            <strong>
                                <Siar:Label ID="lblTotalePassivo" runat="server">
                                </Siar:Label>
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
                            <Siar:CurrencyBox ID="txtPLVricaviVendite" runat="server" Width="100px" DataColumn="PlvRicaviVendita" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;&nbsp; <em><span>Altri ricavi e proventi (attività ord.)</span></em>
                        </td>
                        <td align="right" style="width: 200px">
                            &nbsp;<Siar:CurrencyBox ID="txtPLValtriRicavi" runat="server" Width="100px" DataColumn="PlvAltriRicavi" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 200px">
                        </td>
                    </tr>
                    <tr style="background-color: #89bbdb; color: white;">
                        <td style="width: 60%; text-align: left;" valign="middle">
                            &nbsp;<strong>TOTALE VALORE DELLA PRODUZIONE</strong>
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
                            <Siar:CurrencyBox ID="txtCPmaterieprime" runat="server" Width="100px" DataColumn="CpMateriePrime" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; Totale Servizi</em>
                        </td>
                        <td align="right" style="width: 40%">
                            <Siar:CurrencyBox ID="txtCPservizi" runat="server" Width="100px" DataColumn="CpServizi" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; Totali per godimento di beni di terzi</em>
                        </td>
                        <td align="right" style="width: 40%">
                            <Siar:CurrencyBox ID="txtCPbeniterzi" runat="server" Width="100px" DataColumn="CpBeniTerzi" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; Totale per il personale</em>
                        </td>
                        <td align="right" style="width: 40%">
                            <Siar:CurrencyBox ID="txtCPersonale" runat="server" Width="100px" DataColumn="CpPersonale" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; Totale Ammortamenti e svalutazioni</em>
                        </td>
                        <td align="right" style="width: 40%">
                            <Siar:CurrencyBox ID="txtCPammortamenti" runat="server" Width="100px" DataColumn="CpAmmSvalutazioni" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; Totale variazioni rimanenze di: materie prime, suss. con.</em>
                        </td>
                        <td align="right" style="width: 40%">
                            <Siar:CurrencyBox ID="txtCPvarRimanenze" runat="server" Width="100px" DataColumn="CpVarRimanenze" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; Totale oneri diversi di gestione</em>
                        </td>
                        <td align="right" style="width: 40%">
                            <Siar:CurrencyBox ID="txtCPoneri" runat="server" Width="100px" DataColumn="CpOneri" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 40%">
                        </td>
                    </tr>
                    <tr style="background-color: #89bbdb; color: white;">
                        <td style="width: 60%; text-align: left;">
                            <strong>TOTALE COSTI DELLA PRODUZIONE (attività ord.)</strong>
                        </td>
                        <td align="right" style="width: 40%">
                            <strong>
                                <Siar:Label ID="lblCPtotale" runat="server" Text=" " />
                            </strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                        </td>
                        <td align="right" style="width: 40%">
                        </td>
                    </tr>
                    <tr style="background-color: #89bbdb; color: white;">
                        <td style="width: 60%; text-align: left; height: 13px;">
                            <strong>TOTALE DIFF.TRA VALORI E COSTI DI PRODUZ.</strong>
                        </td>
                        <td align="right" style="width: 40%; height: 13px;">
                            <strong>
                                <Siar:Label ID="lblDiffPlvCp" runat="server" Text=" " />
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
                            <Siar:CurrencyBox ID="txtPOFaltriproventi" runat="server" Width="100px" DataColumn="PofAltriProventi" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; <span>Totale interessi (pass.) e oneri finanziari</span></em>
                        </td>
                        <td align="right" style="width: 40%">
                            <Siar:CurrencyBox ID="txtPOFinteressi" runat="server" Width="100px" DataColumn="PofInteressiOneri" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 40%">
                        </td>
                    </tr>
                    <tr style="background-color: #89bbdb; color: white;">
                        <td style="width: 60%; text-align: left;" valign="middle">
                            <strong>TOT. DIFF. PROVENTI E ONERI FINANZIARI</strong>
                        </td>
                        <td align="right" valign="middle" style="width: 200px">
                            <b>
                                <Siar:Label ID="lblPOFtotale" runat="server" Text=" " />
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
                            <Siar:CurrencyBox ID="txtRettAttFin" runat="server" Width="100px" DataColumn="RettValAttFinanziarie" />
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
                            <Siar:CurrencyBox ID="txtPOSProventiStraor" runat="server" Width="100px" DataColumn="PosProventiStraord" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <em>&nbsp;&nbsp; <span>Totale oneri straordinari (extra attività ord.)</span></em>
                        </td>
                        <td align="right" style="width: 40%">
                            <Siar:CurrencyBox ID="txtPOSoneri" runat="server" Width="100px" DataColumn="PosOneriStraord" />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 40%">
                        </td>
                    </tr>
                    <tr style="background-color: #89bbdb; color: white;">
                        <td style="width: 60%; height: 17px; text-align: left;" valign="middle">
                            <strong>TOTALE DELLE PARTITE STRAORDINARIE</strong>
                        </td>
                        <td align="right" valign="middle" style="width: 40%">
                            <b>
                                <Siar:Label ID="lblPOStotale" runat="server" Text=" " />
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
                    <tr style="background-color: #89bbdb; color: white;">
                        <td style="width: 60%; height: 17px; text-align: left;" valign="middle">
                            <strong>TOTALE RISULTATO PRIMA DELLE IMPOSTE</strong>
                        </td>
                        <td align="right" valign="middle" style="width: 40%">
                            <b>
                                <Siar:Label ID="lblTotPrimaImposte" runat="server" Text=" " />
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
                            <Siar:CurrencyBox ID="txtTotImposte" runat="server" Width="100px" DataColumn="ImposteReddito" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            &nbsp;
                        </td>
                        <td style="width: 40%">
                        </td>
                    </tr>
                    <tr style="background-color: #89bbdb; color: white;">
                        <td style="width: 60%; text-align: left;">
                            <strong>RISULTATO DELL'ESERCIZIO</strong>
                        </td>
                        <td align="right" style="width: 40%">
                            <strong>
                                <Siar:Label ID="lblRisutatoEsercizio" runat="server" Text=" " />
                            </strong>
                        </td>
                    </tr>
                    <tr style="background-color: #89bbdb; color: white;">
                        <td style="width: 60%; text-align: left;">
                            <strong>UTILE (PERDITA) DELL'ESERCIZIO</strong>
                        </td>
                        <td align="right" style="width: 40%">
                            <strong>
                                <Siar:Label ID="lblUtileEsercizio" runat="server" Text=" " />
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
            <td colspan ="2">
                <span style ="display:block; font-weight:bold">Nota integrativa:</span>
               <asp:TextBox CssClass="" ID="txtNotaIntegrativa" CssClass="dtFrmCtrl8 dtFrmCtrlScroll" runat="server" TextMode="MultiLine"></asp:TextBox> 
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
                <Siar:Button ID="btnSalva" Text="Salva" runat="server" OnClientClick=" return ControlloAnno(event)"
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
    <br />
</asp:Content>
