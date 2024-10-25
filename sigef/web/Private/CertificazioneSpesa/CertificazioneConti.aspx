<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"CodeBehind="CertificazioneConti.aspx.cs" Inherits="web.Private.CertificazioneSpesa.CertificazioneConti" %>

<%@ Register Src="~/CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <style type="text/css">

        .nascondi {
            display: none;
        }

    </style>

    <script type="text/javascript">
        function selezionaConto(id) 
        {
            $('[id$=hdnIdConto').val($('[id$=hdnIdConto]').val() == id ? '' : id);;
            $('[id$=btnPost]').click();
        }

        function estraiQuietanzaImportiXls() {
            var DataInizio = $('[id$=hdnPeriodoContabile]').val().substring(0,10);
            var DataFine = $('[id$=hdnPeriodoContabile]').val().substring(13, 23);
            var parametri = "DataInizio=" + DataInizio + "|DataFine=" + DataFine;
            SNCVisualizzaReport('rptCertificazioneQuietanze', 2, parametri);
        }

        function estraiReportCertificazione() {
            var idConto = $('[id$=hdnIdConto]').val()
            var parametri = "IdCertificazioneConti=" + idConto;
            SNCVisualizzaReport('rptCertificazioneConti', 1, parametri);
        }

        function estraiDettaglioAppendice1() {
            var DataFine = $('[id$=hdnPeriodoContabile]').val().substring(13, 23);
            var parametri = "dataLotto=" + DataFine;
            SNCVisualizzaReport('rptCertificazioneContiAppendice1Dettaglio', 2, parametri);
        }

        function estraiDettaglioAppendice2() {
            var DataFine = $('[id$=hdnPeriodoContabile]').val().substring(13, 23);
            var parametri = "dataLotto=" + DataFine;
            SNCVisualizzaReport('rptCertificazioneContiAppendice2Dettaglio', 2, parametri);
        }
         
        function estraiDettaglioAppendice3() {
            var DataFine = $('[id$=hdnPeriodoContabile]').val().substring(13, 23);
            var parametri = "dataLotto=" + DataFine;
            SNCVisualizzaReport('rptCertificazioneContiAppendice3Dettaglio', 2, parametri);
        }

        function estraiDettaglioAppendice4() {
            var DataFine = $('[id$=hdnPeriodoContabile]').val().substring(13, 23);
            var parametri = "dataLotto=" + DataFine;
            SNCVisualizzaReport('rptCertificazioneContiAppendice4Dettaglio', 2, parametri);
        }

        function estraiDettaglioAppendice5() {
            var DataFine = $('[id$=hdnPeriodoContabile]').val().substring(13, 23);
            var parametri = "dataLotto=" + DataFine;
            SNCVisualizzaReport('rptCertificazioneContiAppendice5Dettaglio', 2, parametri);
        }

        function estraiDettaglioAppendice6() {
            var DataFine = $('[id$=hdnPeriodoContabile]').val().substring(13, 23);
            var parametri = "dataLotto=" + DataFine;
            SNCVisualizzaReport('rptCertificazioneContiAppendice6Dettaglio', 2, parametri);
        }

        function estraiDettaglioAppendice7() {
            var DataFine = $('[id$=hdnPeriodoContabile]').val().substring(13, 23);
            var parametri = "dataLotto=" + DataFine;
            SNCVisualizzaReport('rptCertificazioneContiAppendice7Dettaglio', 2, parametri);
        }

        function estraiDettaglioAppendice8() {
            var DataFine = $('[id$=hdnPeriodoContabile]').val().substring(13, 23);
            var parametri = "dataLotto=" + DataFine;
            SNCVisualizzaReport('rptCertificazioneContiAppendice8Dettaglio', 2, parametri);
        }

        function SetSource(SourceID) {
            var hidSourceID = document.getElementById("<%=hidSourceID.ClientID%>");
            hidSourceID.value = SourceID;
        }

        function EmpySource() {
            var hidSourceID = document.getElementById("<%=hidSourceID.ClientID%>");
            hidSourceID.value = null;
        }

        function GetDecertSelezionati() {
            var grid = document.getElementById("<%=dgDecertificazioni.ClientID%>");
            var checkBoxes = grid.getElementsByTagName("INPUT");
            var selezionate = "";
            for (var i = 0; i < checkBoxes.length; i++) {
                if (checkBoxes[i].checked) {
                    var row = checkBoxes[i].parentNode.parentNode.parentNode;
                    selezionate += row.cells[7].innerHTML + "|";
                }
            }
            $('[id$=hdnDecertSelezionate]').val(selezionate);
        }

    </script>

    <div id="divHidden" style="display: none">       
        <asp:HiddenField ID="hdnIdConto" runat="server" />
        <asp:HiddenField ID="hdnPeriodoContabile" runat="server" />
        <asp:HiddenField ID="hidSourceID" runat="server" />
        <asp:HiddenField ID="hdnDecertSelezionate" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" />
    </div>
    
    <div id="divContainerElencoCertificazioni" class="dBox" visible="false" runat="server">
        <div id="divElencoCertificazioni" class="dContenuto" visible="false" runat="server">
           
            <Siar:DataGrid ID="dgElencoCertificazioni" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="24px" />
                <Columns>
                    <asp:BoundColumn DataField="IdCertificazioneConti" HeaderText="Id Certificazione Conti"></asp:BoundColumn>
                    <asp:BoundColumn DataField="AnnoContabileDa" HeaderText="Dal"></asp:BoundColumn>
                    <asp:BoundColumn DataField="AnnoContabileA" HeaderText="Al"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DataPresentazioneConti" HeaderText="Data Presentazione"></asp:BoundColumn>
                    <Siar:ColonnaLink DataField="FlagDefinitivo" HeaderText="Definitivo" IsJavascript="true"
                        LinkFields="IdCertificazioneConti" LinkFormat="selezionaConto({0});">
                    </Siar:ColonnaLink>
                </Columns>
            </Siar:DataGrid>
            <div style="padding: 15px 0 15px 0;">
                <asp:LinkButton ID="lnkNuovaCertificazione" runat="server" Text="Nuova Certificazione" OnClick="lnkNuovaCertificazione_Click" CausesValidation="false"></asp:LinkButton>
            </div>
        </div>
    </div>
    <div id="divTestataNuovaCertificazione" class="dBox" runat="server" style="padding: 15px; min-width: 250px; width: 50%;" visible="false">
        <label for="txtDataInizio" style="white-space: nowrap;">Periodo contabile</label>
        <Siar:Combo ID="cmbAnniContabili" runat="server" NoBlankItem="false">
            <asp:ListItem Text="01/01/2014 - 30/06/2015" Value="01/01/2014 - 30/06/2015" />
            <asp:ListItem Text="01/07/2015 - 30/06/2016" Value="01/07/2015 - 30/06/2016" />
            <asp:ListItem Text="01/07/2016 - 30/06/2017" Value="01/07/2016 - 30/06/2017" />
            <asp:ListItem Text="01/07/2017 - 30/06/2018" Value="01/07/2017 - 30/06/2018" />
            <asp:ListItem Text="01/07/2018 - 30/06/2019" Value="01/07/2018 - 30/06/2019" />
            <asp:ListItem Text="01/07/2019 - 30/06/2020" Value="01/07/2019 - 30/06/2020" />
            <asp:ListItem Text="01/07/2020 - 30/06/2021" Value="01/07/2020 - 30/06/2021" />
            <asp:ListItem Text="01/07/2021 - 30/06/2022" Value="01/07/2021 - 30/06/2022" />
            <asp:ListItem Text="01/07/2022 - 30/06/2023" Value="01/07/2022 - 30/06/2023" />
        </Siar:Combo>
        <Siar:Button ID="btnNuovaCertificazione" runat="server" Text="Crea Nuova Certificazione" OnClick="btnNuovaCertificazione_Click" CausesValidation="false" />
    </div>

    <div id="divDettaglioCertificazione" class="dBox" runat="server" visible="false">
        <uc1:SiarNewTab id="tabDettaglio" runat="server" TabNames="Intestazione|Appendice 1|Appendice 2|Appendice 3|Appendice 4|Appendice 5|Appendice 6|Appendice 7|Appendice 8|Decertificazioni" Titolo="Certificazione Conti"/>
        <!-- Intestazione -->
        <div id="divIntestazione" runat="server" class="dContenuto" visible="false">
            <div>             
                <div style="padding:15px 0 15px 0;">
                    <label for="txtDataCertificazione" style="white-space: nowrap;">Data di presentazione</label>
                    <Siar:DateTextBox ID="txtDataCertificazione" runat="server" Width="90px" />
                </div>
                <div style="padding: 15px 0 15px 0;">
                    CONTI DEL PERIODO CONTABILE <%= hdnPeriodoContabile.Value %> <br />
                    COMMISSIONE EUROPEA <br />
                    Riferimento della Commissione (CCI) 2014IT16RFOP013 <br />
                    Nome del programma operativo POR Marche FESR <br />
                    Decisione della Commissione C(2015)926 Data della decisione della Commissione 12-feb-2015  <br />
                    Data di presentazione dei conti <%= txtDataCertificazione.Text %> Riferimento nazionale ITALIA <br />
                    <div style="padding: 15px 0 0 15px;">L'autorità di certificazione certifica: </div>
                    <div style="width: 70%">
                        1) la completezza, esattezza e veridicità dei conti e che le spese in essi iscritte sono conformi al diritto applicabile e sono state sostenute in rapporto ad operazioni selezionate per il finanziamento conformemente ai criteri applicabili al programma operativo e nel rispetto del diritto applicabile
                    </div> 
                    <div style="width: 70%">2) il rispetto delle norme contenute nei regolamenti specifici dei fondi e il rispetto del vigente Regolamento finanziario UE e dell'articolo 126, lettere d) e f), del regolamento (UE) n. 1303/2013 </div>
                    <div style="width: 70%">3) il rispetto delle disposizioni dell'articolo 140 del regolamento (UE) n. 1303/2013 relative alla disponibilità dei documenti. <br />
                        In rappresentanza dell'autorità di certificazione: Andrea Pellei
                    </div>
                </div>
                <div style="padding: 15px 0 15px 0;">
                    <Siar:Button ID="btnSalvaIntestazione" runat="server" Text="Salva Intestazione" CausesValidation="false" OnClick="btnSalvaIntestazione_Click" />
                    <Siar:Button ID="btnSalvaDefinitivo" runat="server" Text="Rendi Definitivo" CausesValidation="false" OnClick="btnSalvaDefinitivo_Click" OnClientClick="return confirm('Sei sicuro di voler rendere definitiva la certificazione?')" />
                    <Siar:Button ID="btnEliminaCertificazione" runat="server" Text="Elimina Certificazione" CausesValidation="false" OnClick="btnEliminaCertificazione_Click" OnClientClick="return confirm('Sei sicuro di voler eliminare la certificazione?')" />
                    <input type="button" class="Button" value="Report erogazione ai beneficiari (Excel)" style="width: 250px" onclick="return estraiQuietanzaImportiXls();" />
                    <input type="button" class="Button" value="Report certificazione (PDF)" style="width: 200px" onclick="return estraiReportCertificazione();" />
                </div>
            </div>            
        </div>
        <!-- Appendice 1 -->
        <div id="divAppendice1" class="dContenuto" runat="server" visible="false">
            <Siar:DataGrid ID="dgAppendice1" runat="server" Titolo="Appendice 1 Importi registrati nei sistemi contabili dell'autorità di certificazione — articolo 137, paragrafo 1, lettera a), del regolamento (UE) n. 1303/2013" AutoGenerateColumns="false" Width="80%">
                <Columns>
                    <asp:BoundColumn DataField="Asse" HeaderText="Priorità (Assi)">
                    </asp:BoundColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A1ImportoTotaleSpeseAdCToCommissione" Importo="ImportoTotaleSpeseAdCToCommissione" HeaderText="Importo totale di spese ammissibili registrato dall'autorità di certificazione nei propri sistemi contabili e inserito nelle domande di pagamento presentate alla Commissione">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A1ImportoTotaleSpesaPubblica" Importo="ImportoTotaleSpesaPubblica" HeaderText="Importo totale della corrispondente spesa pubblica relativa all'attuazione delle operazioni">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A1ImportoTotaleSpesaPubblicaErogataBeneficiari" Importo="ImportoTotaleSpesaPubblicaErogataBeneficiari" HeaderText="Importo totale dei pagamenti corrispondenti effettuati ai beneficiari a norma dell'articolo 132, paragrafo 1, del regolamento (UE) n. 1303/2013">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn> 
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A1ImportoTotaleSpeseAdCToCommissioneAdA" Importo="ImportoTotaleSpeseAdCToCommissioneAdA" HeaderText="A AdA">
                        <HeaderStyle HorizontalAlign="Center" CssClass="nascondi" />
                        <ItemStyle HorizontalAlign="right" CssClass="nascondi" />
                        <FooterStyle CssClass="nascondi" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A1ImportoTotaleSpesaPubblicaAdA" Importo="ImportoTotaleSpesaPubblicaAdA" HeaderText="B AdA">
                        <HeaderStyle HorizontalAlign="Center" CssClass="nascondi" />
                        <ItemStyle HorizontalAlign="right" CssClass="nascondi" />
                        <FooterStyle CssClass="nascondi" />
                    </Siar:NewImportoColumn>
                </Columns>
            </Siar:DataGrid>
            <div style="padding: 15px 0 15px 0;">
                <Siar:Button ID="btnAggiornaAppendice1" runat="server" Text="Calcola dati Appendice 1" CausesValidation="false" OnClick="btnCalcolaAppendice1_Click" OnClientClick="SetSource(this.id);" />
                <Siar:Button ID="btnSalvaAppendice1" runat="server" Text="Salva Appendice 1" CausesValidation="false" OnClick="btnSalvaAppendice1_Click" />
                <input type="button" id="btnReportAppendice1" runat="server" class="Button" value="Report dettaglio Appendice 1" style="width: 200px" onclick="return estraiDettaglioAppendice1();" />
            </div>
        </div>
        <!-- Appendice 2 -->
        <div id="divAppendice2" class="dContenuto" runat="server" visible="false">
            <Siar:DataGrid ID="dgAppendice2" runat="server" Titolo="Appendice 2 Importi ritirati e recuperati durante il periodo contabile — articolo 137, paragrafo 1, lettera b), del regolamento (UE) n. 1303/2013" AutoGenerateColumns="false" Width="80%">
                <Columns>
                    <asp:BoundColumn DataField="Asse" HeaderText="Priorità (Assi)"></asp:BoundColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A2ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri" Importo="ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri" HeaderText="Importo totale ammissibile delle spese incluse nelle domande di pagamento">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A2ImportoSpesaPubblicaCorrispondenteRitiri" Importo="ImportoSpesaPubblicaCorrispondenteRitiri" HeaderText="Spesa pubblica corrispondente">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A2ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi" Importo="ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi" HeaderText="Importo totale ammissibile delle spese incluse nelle domande di pagamento">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A2ImportoSpesaPubblicaCorrispondenteRecuperi" Importo="ImportoSpesaPubblicaCorrispondenteRecuperi" HeaderText="Spesa pubblica corrispondente">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                </Columns>
            </Siar:DataGrid>
            <!-- Dettaglio Appendice 2 -->
            <div style="padding: 15px 0 0 0;">
                <Siar:DataGrid ID="dgDettaglioAppendice2" runat="server" Titolo="Importi ritirati e recuperati durante il periodo contabile suddivisi per periodo contabile di dichiarazione delle spese corrispondenti" AutoGenerateColumns="false" Width="80%">
                    <Columns>
                        <asp:TemplateColumn ItemStyle-Width="150px">
                            <ItemTemplate>
                            <span><%# (Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "FlagImportiRettificati")) == false ? "per il periodo contabile che si chiude il 30 giugno " + DataBinder.Eval(Container.DataItem, "Anno") + " (totale)" : "di cui importi rettificati in seguito ad audit relativi alle operazioni effettuati a norma dell'articolo 127, paragrafo 1, del regolamento (UE) n. 1303/2013") %></span>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <Siar:NewImportoColumn DataField="IdRecord" Name="AD2ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri" Importo="ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri" HeaderText="Importo totale ammissibile delle spese incluse nelle domande di pagamento">
                            <ItemStyle HorizontalAlign="right" />
                        </Siar:NewImportoColumn>
                        <Siar:NewImportoColumn DataField="IdRecord" Name="AD2ImportoSpesaPubblicaCorrispondenteRitiri" Importo="ImportoSpesaPubblicaCorrispondenteRitiri" HeaderText="Spesa pubblica corrispondente">
                            <ItemStyle HorizontalAlign="right" />
                        </Siar:NewImportoColumn>
                        <Siar:NewImportoColumn DataField="IdRecord" Name="AD2ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi" Importo="ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi" HeaderText="Importo totale ammissibile delle spese incluse nelle domande di pagamento">
                            <ItemStyle HorizontalAlign="right" />
                        </Siar:NewImportoColumn>
                        <Siar:NewImportoColumn DataField="IdRecord" Name="AD2ImportoSpesaPubblicaCorrispondenteRecuperi" Importo="ImportoSpesaPubblicaCorrispondenteRecuperi" HeaderText="Spesa pubblica corrispondente">
                            <ItemStyle HorizontalAlign="right" />
                        </Siar:NewImportoColumn>
                    </Columns>
                </Siar:DataGrid>
            </div>
            <div style="padding: 15px 0 15px 0;">
                    <Siar:Button ID="btnAggiornaAppendice2" runat="server" Text="Calcola dati Appendice 2" CausesValidation="false" OnClick="btnCalcolaAppendice2_Click" OnClientClick="SetSource(this.id);" />
                    <Siar:Button ID="btnSalvaAppendice2" runat="server" Text="Salva Appendice 2" CausesValidation="false" OnClick="btnSalvaAppendice2_Click" />
                    <input type="button" id="btnReportAppendice2" runat="server" class="Button" value="Report dettaglio Appendice 2" style="width: 200px" onclick="return estraiDettaglioAppendice2();" />
            </div>
        </div>
        <!-- Appendice 3 -->
        <div id="divAppendice3" class="dContenuto" runat="server" visible="false">
            <Siar:DataGrid ID="dgAppendice3" runat="server" Titolo="Appendice 3 Importi da recuperare alla chiusura del periodo contabile — articolo 137, paragrafo 1, lettera b), del regolamento (UE) n. 1303/2013" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundColumn DataField="Asse" HeaderText="Priorità (Assi)"></asp:BoundColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A3ImportoTotaleAmmissibileSpese" Importo="ImportoTotaleAmmissibileSpese" HeaderText="Importo totale ammissibile delle spese">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A3ImportoSpesaPubblicaCorrispondente" Importo="ImportoSpesaPubblicaCorrispondente" HeaderText="Spesa pubblica corrispondente">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                </Columns>
            </Siar:DataGrid>
            <!-- Dettaglio Appendice 3 -->
            <div style="padding: 15px 0 0 0;">
                <Siar:DataGrid ID="dgDettaglioAppendice3" runat="server" Titolo="Importi da recuperare alla chiusura del periodo contabile suddivisi per periodo contabile di dichiarazione delle spese corrispondenti" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateColumn ItemStyle-Width="150px">
                            <ItemTemplate>
                                <span><%# (Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "FlagImportiRettificati")) == false ? "per il periodo contabile che si chiude il 30 giugno " + DataBinder.Eval(Container.DataItem, "Anno") + " (totale)" : "di cui importi rettificati in seguito ad audit relativi alle operazioni effettuati a norma dell'articolo 127, paragrafo 1, del regolamento (UE) n. 1303/2013") %></span>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <Siar:NewImportoColumn DataField="IdRecord" Name="AD3ImportoTotaleAmmissibileSpese" Importo="ImportoTotaleAmmissibileSpese" HeaderText="Importo totale ammissibile delle spese">
                            <ItemStyle HorizontalAlign="right" />
                        </Siar:NewImportoColumn>
                        <Siar:NewImportoColumn DataField="IdRecord" Name="AD3ImportoSpesaPubblicaCorrispondente" Importo="ImportoSpesaPubblicaCorrispondente" HeaderText="Spesa pubblica corrispondente">
                            <ItemStyle HorizontalAlign="right" />
                        </Siar:NewImportoColumn>
                    </Columns>
                </Siar:DataGrid>
            </div>
            <div style="padding: 15px 0 15px 0;">
                        <Siar:Button ID="btnAggiornaAppendice3" runat="server" Text="Calcola dati Appendice 3" CausesValidation="false" OnClick="btnCalcolaAppendice3_Click" OnClientClick="SetSource(this.id);" />
                        <Siar:Button ID="btnSalvaAppendice3" runat="server" Text="Salva Appendice 3" CausesValidation="false" OnClick="btnSalvaAppendice3_Click" />
                        <input type="button" id="btnReportAppendice3" runat="server" class="Button" value="Report dettaglio Appendice 3" style="width: 200px" onclick="return estraiDettaglioAppendice3();" />
            </div>
        </div>
        <!-- Appendice 4 -->
        <div id="divAppendice4" class="dContenuto" runat="server" visible="false">
            <Siar:DataGrid ID="dgAppendice4" runat="server" Titolo="Appendice 4 Recuperi effettuati a norma dell'articolo 71 del regolamento (ue) n. 1303/2013 (STABILITA’ DELLE OPERAZIONI) durante il periodo contabile — articolo 137, paragrafo 1, lettera b), del regolamento (UE) n. 1303/2013" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundColumn DataField="Asse" HeaderText="Priorità (Assi)"></asp:BoundColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A4ImportoTotaleAmmissibileSpeseRecuperi" Importo="ImportoTotaleAmmissibileSpeseRecuperi" HeaderText="Importo totale ammissibile delle spese">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A4ImportoSpesaPubblicaCorrispondenteRecuperi" Importo="ImportoSpesaPubblicaCorrispondenteRecuperi" HeaderText="Spesa pubblica corrispondente">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                </Columns>
            </Siar:DataGrid>
            <!-- Dettaglio Appendice 4 -->
            <div style="padding: 15px 0 0 0;">
                <Siar:DataGrid ID="dgDettaglioAppendice4" runat="server" Titolo="Importi recuperati effettuati a norma dell'articolo 71 del regolamento (ue) n. 1303/2013 durante il periodo contabile suddivisi per periodo contabile di dichiarazione delle spese corrispondenti" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateColumn ItemStyle-Width="150px">
                            <ItemTemplate>
                                <span><%# (Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "FlagImportiRettificati")) == false ? "per il periodo contabile che si chiude il 30 giugno " + DataBinder.Eval(Container.DataItem, "Anno") + " (totale)" : "di cui importi rettificati in seguito ad audit relativi alle operazioni effettuati a norma dell'articolo 127, paragrafo 1, del regolamento (UE) n. 1303/2013") %></span>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <Siar:NewImportoColumn DataField="IdRecord" Name="AD4ImportoTotaleAmmissibileSpese" Importo="ImportoTotaleAmmissibileSpese" HeaderText="Importo totale ammissibile delle spese">
                            <ItemStyle HorizontalAlign="right" />
                        </Siar:NewImportoColumn>
                        <Siar:NewImportoColumn DataField="IdRecord" Name="AD4ImportoSpesaPubblicaCorrispondente" Importo="ImportoSpesaPubblicaCorrispondente" HeaderText="Spesa pubblica corrispondente">
                            <ItemStyle HorizontalAlign="right" />
                        </Siar:NewImportoColumn>
                    </Columns>
                </Siar:DataGrid>
            </div>
            <div style="padding: 15px 0 15px 0;">
                            <Siar:Button ID="btnAggiornaAppendice4" runat="server" Text="Calcola dati Appendice 4" CausesValidation="false" OnClick="btnCalcolaAppendice4_Click" OnClientClick="SetSource(this.id);" />
                            <Siar:Button ID="btnSalvaAppendice4" runat="server" Text="Salva Appendice 4" CausesValidation="false" OnClick="btnSalvaAppendice4_Click" />
                            <input type="button" id="btnReportAppendice4" runat="server" class="Button" value="Report dettaglio Appendice 4" style="width: 200px" onclick="return estraiDettaglioAppendice4();" />
            </div>
        </div>
        <!-- Appendice 5 -->
        <div id="divAppendice5" class="dContenuto" runat="server" visible="false">
            <Siar:DataGrid ID="dgAppendice5" runat="server" Titolo="Appendice 5 Importi irrecuperabili alla chiusura del periodo contabile — articolo 137, paragrafo 1, lettera b), del regolamento (UE) n. 1303/2013" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundColumn DataField="Asse" HeaderText="Priorità (Assi)"></asp:BoundColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A5ImportoTotaleAmmissibileSpeseIrrecuperabili" Importo="ImportoTotaleAmmissibileSpeseIrrecuperabili" HeaderText="Importo totale ammissibile delle spese">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A5ImportoSpesaPubblicaCorrispondenteIrrecuperabili" Importo="ImportoSpesaPubblicaCorrispondenteIrrecuperabili" HeaderText="Spesa pubblica corrispondente">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewTextAreaColumn DataField="IdAsse" Name="A5Osservazioni" HeaderText="Osservazioni (obbligatorie)" Testo="Osservazioni"></Siar:NewTextAreaColumn>
                </Columns>
            </Siar:DataGrid>
            <div style="padding: 15px 0 15px 0;">
                <Siar:Button ID="btnAggiornaAppendice5" runat="server" Text="Calcola dati Appendice 5" CausesValidation="false" OnClick="btnCalcolaAppendice5_Click" OnClientClick="SetSource(this.id);" />
                <Siar:Button ID="btnSalvaAppendice5" runat="server" Text="Salva Appendice 5" CausesValidation="false" OnClick="btnSalvaAppendice5_Click" />
                <input type="button" id="btnReportAppendice5" runat="server" class="Button" value="Report dettaglio Appendice 5" style="width: 200px" onclick="return estraiDettaglioAppendice5();" />
            </div>
        </div>
        <!-- Appendice 6 -->
        <div id="divAppendice6" class="dContenuto" runat="server" visible="false">
            <Siar:DataGrid ID="dgAppendice6" runat="server" Titolo="Appendice 6 Importi dei contributi per programma erogati agli strumenti finanziari a norma dell'articolo 41 del regolamento (UE) n. 1303/2013) (dati cumulativi dall'inizio del programma) — articolo 137, paragrafo 1, lettera c), del regolamento (UE) n. 1303/2013" AutoGenerateColumns="false" Width="80%">
                <Columns>
                    <asp:BoundColumn DataField="Asse" HeaderText="Priorità (Assi)"></asp:BoundColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A6ImportoErogatoContributiStrumentiFinanziari" Importo="ImportoErogatoContributiStrumentiFinanziari" HeaderText="Importo complessivo dei contributi per programma erogati agli strumenti finanziari">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A6ImportoErogatoContributiStrumentiFinanziariSpesaPubblicaCorrispondente" Importo="ImportoErogatoContributiStrumentiFinanziariSpesaPubblicaCorrispondente" HeaderText="Spesa pubblica corrispondente">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A6ImportoErogatoSpesaStrumentiFinanziari" Importo="ImportoErogatoSpesaStrumentiFinanziari" HeaderText="Importo complessivo dei contributi del programma effettivamente erogati o, nel caso delle garanzie, impegnati a titolo di spesa ammissibile ai sensi dell'articolo 42, paragrafo 1, lettere a), b) e d), del regolamento (UE) n. 1303/2013">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A6ImportoErogatoSpesaStrumentiFinanziariSpesaPubblicaCorrispondente" Importo="ImportoErogatoSpesaStrumentiFinanziariSpesaPubblicaCorrispondente" HeaderText="Spesa pubblica corrispondente">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                </Columns>
            </Siar:DataGrid>
            <div style="padding: 15px 0 15px 0;">
                <Siar:Button ID="btnAggiornaAppendice6" runat="server" Text="Calcola dati Appendice 6" CausesValidation="false" OnClick="btnCalcolaAppendice6_Click" OnClientClick="SetSource(this.id);" />
                <Siar:Button ID="btnSalvaAppendice6" runat="server" Text="Salva Appendice 6" CausesValidation="false" OnClick="btnSalvaAppendice6_Click" />
                <input type="button" id="btnReportAppendice6" runat="server" class="Button" value="Report dettaglio Appendice 6" style="width: 200px" onclick="return estraiDettaglioAppendice6();" />
            </div>
        </div>
        <!-- Appendice 7 -->
        <div id="divAppendice7" class="dContenuto" runat="server" visible="false">
            <Siar:DataGrid ID="dgAppendice7" runat="server" Titolo="Appendice 7 Anticipi versati nel quadro di aiuti di Stato a norma dell'articolo 131, paragrafo 5, del regolamento (UE) n. 1303/2013 (dati cumulativi dall'inizio del programma) — articolo 137, paragrafo 1, lettera c), del regolamento (UE) n. 1303/2013" AutoGenerateColumns="false" Width="80%">
                <Columns>
                    <asp:BoundColumn DataField="Asse" HeaderText="Priorità (Assi)"></asp:BoundColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A7ImportoComplessivoVersatoAnticipi" Importo="ImportoComplessivoVersatoAnticipi" HeaderText="Importo complessivo versato come anticipo dal programma operativo">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A7ImportoCopertoAnticipiEntro" Importo="ImportoCopertoAnticipiEntro" HeaderText="Importo che è stato coperto dalle spese pagate dai beneficiari entro tre anni dal pagamento dell'anticipo">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A7ImportoNonCopertoAnticipiEntro" Importo="ImportoNonCopertoAnticipiEntro" HeaderText="Importo che non è stato coperto dalle spese sostenute dai beneficiari e per il quale il periodo di tre anni non è ancora trascorso">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                </Columns>
            </Siar:DataGrid>
            <div style="padding: 15px 0 15px 0;">
                <Siar:Button ID="btnAggiornaAppendice7" runat="server" Text="Calcola dati Appendice 7" CausesValidation="false" OnClick="btnCalcolaAppendice7_Click" OnClientClick="SetSource(this.id);" />
                <Siar:Button ID="btnSalvaAppendice7" runat="server" Text="Salva Appendice 7" CausesValidation="false" OnClick="btnSalvaAppendice7_Click" />
                <input type="button" id="btnReportAppendice7" runat="server" class="Button" value="Report dettaglio Appendice 7" style="width: 200px" onclick="return estraiDettaglioAppendice7();" />
            </div>
        </div>
        <!-- Appendice 8 -->
        <div id="divAppendice8" class="dContenuto" runat="server" visible="false">
            <Siar:DataGrid ID="dgAppendice8" runat="server" Titolo="Appendice 8 Riconciliazione delle spese — articolo 137, paragrafo 1, lettera d), del regolamento (UE) n. 1303/2013" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundColumn DataField="Asse" HeaderText="Priorità (Assi)"></asp:BoundColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A8ImportoTotaleSpeseAmmissibiliBeneficiari" Importo="ImportoTotaleSpeseAmmissibiliBeneficiari" HeaderText="Importo totale delle spese ammissibili sostenute dai beneficiari e pagate nell'attuazione delle operazioni <b>(A)</b>">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A8ImportoTotaleSpesaPubblica" Importo="ImportoTotaleSpesaPubblica" HeaderText="Importo totale della spesa pubblica relativa all'attuazione delle operazioni <b>(B)</b>">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A8ImportoTotaleSpeseAmmissibiliAdC" Importo="ImportoTotaleSpeseAmmissibiliAdC" HeaderText="Importo totale di spese ammissibili registrato dall'autorità di certificazione nei propri sistemi contabili e inserito nelle domande di pagamento presentate alla Commissione <b>(C)</b>">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A8ImportoTotaleSpesaPubblicaAdC" Importo="ImportoTotaleSpesaPubblicaAdC" HeaderText="Importo totale della corrispondente spesa pubblica relativa all'attuazione delle operazioni <b>(D)</b>">
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A8DifferenzaSpesaAmmissibile" Importo="DifferenzaSpesaAmmissibile" HeaderText="(E=A-C)" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A8DifferenzaSpesaPubblicaAdC" Importo="DifferenzaSpesaPubblicaAdC" HeaderText="(F=B-D)">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="right" />
                    </Siar:NewImportoColumn>
                    <Siar:NewTextAreaColumn DataField="IdAsse" Name="A8Osservazioni" HeaderText="Osservazioni (obbligatorie in caso di differenza)" Testo="Osservazioni">
                    </Siar:NewTextAreaColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A8DifferenzaSpesaAmmissibileAdA" Importo="DifferenzaSpesaAmmissibileAdA" HeaderText="(E=A-C) ADA" >
                        <HeaderStyle HorizontalAlign="Center" CssClass="nascondi" />
                        <ItemStyle HorizontalAlign="right" CssClass="nascondi" />
                        <FooterStyle CssClass="nascondi" />
                    </Siar:NewImportoColumn>
                    <Siar:NewImportoColumn DataField="IdAsse" Name="A8DifferenzaSpesaPubblicaAdCAdA" Importo="DifferenzaSpesaPubblicaAdCAdA" HeaderText="(F=B-D) ADA">
                        <HeaderStyle HorizontalAlign="Center" CssClass="nascondi" />
                        <ItemStyle HorizontalAlign="right" CssClass="nascondi" />
                        <FooterStyle CssClass="nascondi" />
                    </Siar:NewImportoColumn>
                </Columns>
            </Siar:DataGrid>
            <div style="padding: 15px 0 15px 0;">
                <Siar:Button ID="btnAggiornaAppendice8" runat="server" Text="Calcola dati Appendice 8" CausesValidation="false" OnClick="btnCalcolaAppendice8_Click" OnClientClick="SetSource(this.id);" />
                <Siar:Button ID="btnSalvaAppendice8" runat="server" Text="Salva Appendice 8" CausesValidation="false" OnClick="btnSalvaAppendice8_Click" />
                <input type="button" id="btnReportAppendice8" runat="server" class="Button" value="Report dettaglio Appendice 8" style="width: 200px" onclick="return estraiDettaglioAppendice8();" />
            </div>
        </div>
        <div id="divDecertificazioni" class="dContenuto" runat="server" visible="false">
            <asp:Label ID="lblDecertificazioni" Text="Nessuna decertificazione trovata da associare in questa Certificazione dei Conti." Font-Size="Small" runat="server"></asp:Label><br />
            <div id="divContenutoDecert" runat="server">
                <Siar:DataGrid ID="dgDecertificazioni" runat="server"  AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Id Progetto"></asp:BoundColumn>
                        <asp:BoundColumn DataField="IdDecertificazione" HeaderText="Id Decertificazione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoDecertificazione" HeaderText="Tipo Decertificazione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoDecertificazioneAmmesso" HeaderText="Importo Ammesso Decertificazione" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoDecertificazioneConcesso" HeaderText="Importo Concesso Decertificazione" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DataConstatazioneAmministrativa" HeaderText="Data Rilevazione"></asp:BoundColumn>
                        <Siar:CheckColumn DataField="Assegnata">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </Siar:CheckColumn>
                        <asp:BoundColumn DataField="IdCertDecertificazione" HeaderText="Id Decertificazione"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><br />
                <Siar:Button ID="btnSalvaDecert" runat="server" Text="Salva Decertificazioni" OnClientClick="GetDecertSelezionati()" OnClick="btnSalvaDecert_Click" Modifica="true" />
            </div>
        </div>
    </div>
</asp:Content>
