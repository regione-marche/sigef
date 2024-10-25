<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="web.Private.Psr.Programmazione.Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript">
        function DownloadXls() {
            var url = window.location.origin
            console.log(url);
            //debugger;
            window.location.assign(url + '/web/public/Download/ELENCO_AZIENDE_iscritte_con_ind_pec_04-10-2019.xlsx');
        }

        function stampaRicercaRegistroControlli() {
            var parametri = [];
            var data_inizio = $('[id$=txtFiltroDataInizio]').val();
            var data_fine = $('[id$=txtFiltroDataFine]').val();

            if (data_inizio == '' && data_fine == '')
                SNCVisualizzaReport('rptRegistroControlli', 2, '');
            else {
                if (data_inizio != '')
                    parametri.push('DataInizio=' + data_inizio);

                if (data_fine != '')
                    parametri.push('DataFine=' + data_fine);

                SNCVisualizzaReport('rptRegistroControlli', 2, parametri.join('|'));
            }
        }

        function stampaRupValidatoriNoAiuti()
        { SNCVisualizzaReport('rptEstrazioneRupValidatoriXls', 2, 'AIUTI=0');}

        function stampaRupValidatoriAiuti()
        { SNCVisualizzaReport('rptEstrazioneRupValidatoriXls', 2, 'AIUTI=1');}

        function stampaEstrazioneBandiProgettiXAsse()
        { SNCVisualizzaReport('rptEstrazioneBandiProgettiXAsseXls', 2, ''); }
        
    </script>

    
    <div class="dBox" id="div1" runat="server">
        <div class="dSezione">
            <div class="dContenutoFloat">
                <div class="paragrafo">Elenco dei progetti rilasciati in SIGEF:</div>
                <br />
                <div id="divEstrazioneProgetti">
                    <div style="display: inline-block; padding-left: 20px;">
                        <Siar:Button ID="btnEstraiProgetti"   runat="server" Text="Estrai i progetti in XLS" Width="200px" />
                    </div>
                </div>
            </div>
            <div class="dContenutoFloat">
                <div class="paragrafo">Elenco dei beneficiari/aggregazioni dei progetti in SIGEF:</div>
                <br />
                <div id="divEstrazioneBeneficiario">
                    <div style="display: inline-block; padding-left: 20px;">
                        <Siar:Button ID="btnEstraiBeneficiari"   runat="server" Text="Estrai i beneficiari in XLS" Width="200px" />
                    </div>
                </div>
            </div>
            <div class="dContenutoFloat">
                <div class="paragrafo">Elenco Aziende archivio Infocamere/CCIAA 2015:</div>
                <br />
                <div>
                    <div style="display: inline-block; padding-left: 20px;">
                        <Siar:Button ID="Button1" OnClientClick="DownloadXls()"  runat="server" Text="Estrai Aziende in XLS" Width="200px" />
                    </div>
                </div>
            </div>
            <div class="dContenutoFloat">
                <div class="paragrafo">Elenco Bandi e progetti per asse:</div>
                <br />
                <div>
                    <div style="display: inline-block; padding-left: 20px;">
                         <input id="btnstampaEstrazioneBandiProgettiXAsse" class="Button" style="width: 200px;" type="button" value="Estrai i bandi e progetti in XLS"
                                    onclick="stampaEstrazioneBandiProgettiXAsse();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="dBox" id="div2" runat="server">
        <div class="dSezione">
            <div class="dContenutoFloat">
                <div class="paragrafo">Elenco dei progetti Opere Pubbliche PROVVISORI in SIGEF:</div>
                <br />
                <div id="divEstrazioneProgettiProv">
                    <div style="display: inline-block; padding-left: 20px;">
                        <Siar:Button ID="btnEstraiProgettiProv"   runat="server" Text="Estrai i progetti in XLS" Width="200px" />
                    </div>
                </div>
            </div>
            <div class="dContenutoFloat">
                <div class="paragrafo">Elenco dei beneficiari/aggregazioni dei progetti Opere Pubbliche PROVVISORI in SIGEF:</div>
                <br />
                <div id="divEstrazioneBeneficiarioProv">
                    <div style="display: inline-block; padding-left: 20px;">
                        <Siar:Button ID="btnEstraiBeneficiariProv"   runat="server" Text="Estrai i beneficiari in XLS" Width="200px" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="dBox" id="div3" runat="server">
        <div class="dSezione">
            <div class="dContenutoFloat">
                <div class="paragrafo">Report di previsione dei progetti certificabili:</div>
                <br />
                <div id="divEstraiCertificabili">
                    <div style="display: inline-block; padding-left: 20px;">
                        <Siar:Button ID="btnEstraiCertificabili"   runat="server" Text="Estrai i progetti in XLS" Width="200px" />
                    </div>
                </div>
            </div>
            <div class="dContenutoFloat">
                <div class="paragrafo">Elenco degli importi certificati:</div>
                <br />
                <div id="divEstraiCertificati">
                    <div style="display: inline-block; padding-left: 20px;">
                        <Siar:Button ID="btnEstraiCertificati"   runat="server" Text="Estrai gli importi in XLS" Width="200px" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="dBox" id="div4" runat="server">
        <div class="dSezione">
            <div class="dContenutoFloat">
                <div class="paragrafo">Registro Controlli:</div>
                <br />
                <div>
                    <table>
                        
                        <tr>
                            <td colspan="3">
                                Cliccare sul pulsante estrai per scaricare in formato Excel il dettaglio del <b>registro dei controlli POR FESR MARCHE 2014-2020</b>.
                                E' possibile estrarre i controlli all'interno di un intervallo di date.
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>Data di inizio (opzionale):
                            </td>
                            <td>
                                <Siar:DateTextBox ID="txtFiltroDataInizio" runat="server" Width="80px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:150px;">Data di fine   (opzionale):
                            </td>
                            <td>
                                <Siar:DateTextBox ID="txtFiltroDataFine" runat="server" Width="80px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <input id="btnStampaRegistroControlli" class="Button" style="width: 130px;" type="button" value="Estrai"
                                    onclick="stampaRicercaRegistroControlli();" /><br />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="dBox" id="div5" runat="server">
        <div class="dSezione">
            <div class="dContenutoFloat">
                <div class="paragrafo">Elenco dei Rup e dei Validatori Aiuti:</div>
                <br />
                <div id="divEstraiCertificabilia">
                    <div style="display: inline-block; padding-left: 20px;">
                        <input id="btnstampaRupValidatoriAiuti" class="Button" style="width: 200px;" type="button" value="Estrai i nominativi in XLS"
                                    onclick="stampaRupValidatoriAiuti();" /><br />
                    </div>
                </div>
            </div>
            <div class="dContenutoFloat">
                <div class="paragrafo">Elenco dei Rup e dei Validatori NON aiuti:</div>
                <br />
                <div id="divEstraiCertificatai">
                    <div style="display: inline-block; padding-left: 20px;">
                        <input id="btnstampaRupValidatoriNoAiuti" class="Button" style="width: 200px;" type="button" value="Estrai i nominativi in XLS"
                                    onclick="stampaRupValidatoriNoAiuti();" /><br />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="dBox" id="divEstrazioneAsse" runat="server">
        <div class="dSezione">
            <div class="dContenutoFloat">
                <div class="paragrafo">Elenco degli interventi:</div>
                <br />
                <div id="divRicercaAsse">
                    <div style="display: inline-block;">
                        Selezionare l'asse: 
                        <Siar:ComboZProgrammazioneAsseAzInt ID="lstProgrammazione" runat="server" AutoPostBack="True"
                                Width="600px">
                        </Siar:ComboZProgrammazioneAsseAzInt>
                    </div>
                    <div style="display: inline-block; padding-left: 20px;">
                        <Siar:Button ID="btnEstraiXls" runat="server" Text="Estrai in XLS" Width="150px" />
                    </div>
                </div>
                <br />
                <div>
                    <Siar:DataGrid ID="dgInterventi" runat="server" AutoGenerateColumns="false" Width="100%">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <asp:BoundColumn DataField="CodAsse" HeaderText="Asse">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CodAzione" HeaderText="Azione">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CodIntervento" HeaderText="Intervento">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DescrizioneIntervento" HeaderText="Descrizione">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoDotazione" HeaderText="Importo Dotazione" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="NumeroBando" HeaderText="Num. Bandi">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoBandi" HeaderText="Importo Bandi" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PercDiAttuazione" HeaderText="% di Attuazione">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PercNonAttuata" HeaderText="% non Attuata">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="NumeroProgetti" HeaderText="Num. Progetti">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CostoComplessivoProgetti" HeaderText="Costo Complessivo Progetti" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ContributoComplessivoProgetti" HeaderText="Contributo Complessivo Progetti" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
