<%@ Page Title="" Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="web.Private.Psr.Programmazione.Report" %>

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

        function stampaRupValidatoriNoAiuti() { SNCVisualizzaReport('rptEstrazioneRupValidatoriXls', 2, 'AIUTI=0'); }

        function stampaRupValidatoriAiuti() { SNCVisualizzaReport('rptEstrazioneRupValidatoriXls', 2, 'AIUTI=1'); }

        function stampaEstrazioneBandiProgettiXAsse() { SNCVisualizzaReport('rptEstrazioneBandiProgettiXAsseXls', 2, ''); }

    </script>
    <div class="row p-5" id="div1" runat="server">
        <div class="col-sm-6 mb-3">
            <p>Elenco dei progetti rilasciati in SIGEF:</p>
            <Siar:Button ID="btnEstraiProgetti" runat="server" Text="Estrai i progetti in XLS" />
        </div>
        <div class="col-sm-6 mb-3">
            <p>Elenco dei beneficiari/aggregazioni dei progetti in SIGEF:</p>
            <Siar:Button ID="btnEstraiBeneficiari" runat="server" Text="Estrai i beneficiari in XLS" />
        </div>
        <div class="col-sm-6">
            <p>Elenco Aziende archivio Infocamere/CCIAA 2015:</p>
            <Siar:Button ID="Button1" OnClientClick="DownloadXls()" runat="server" Text="Estrai Aziende in XLS" />
        </div>
        <div class="col-sm-6">
            <p>Elenco Bandi e progetti per asse:</p>
            <input id="btnstampaEstrazioneBandiProgettiXAsse" class="btn btn-primary py-1" type="button" value="Estrai i bandi e progetti in XLS"
                onclick="stampaEstrazioneBandiProgettiXAsse();" />
        </div>
    </div>
    <div class="row p-5" id="div2" runat="server">
        <div class="col-sm-6">
            <p>Elenco dei progetti Opere Pubbliche PROVVISORI in SIGEF:</p>
            <Siar:Button ID="btnEstraiProgettiProv" runat="server" Text="Estrai i progetti in XLS" />
        </div>
        <div class="col-sm-6">
            <p>Elenco dei beneficiari/aggregazioni dei progetti Opere Pubbliche PROVVISORI in SIGEF:</p>
            <Siar:Button ID="btnEstraiBeneficiariProv" runat="server" Text="Estrai i beneficiari in XLS" />
        </div>
    </div>
    <div class="row p-5" id="div3" runat="server">
        <div class="col-sm-6">
            <p>Report di previsione dei progetti certificabili:</p>
            <Siar:Button ID="btnEstraiCertificabili" runat="server" Text="Estrai i progetti in XLS" />
        </div>
        <div class="col-sm-6">
            <p>Elenco degli importi certificati:</p>
            <Siar:Button ID="btnEstraiCertificati" runat="server" Text="Estrai gli importi in XLS" />
        </div>
    </div>
    <div class="row bd-form" id="div4" runat="server">
        <h5>Registro Controlli:</h5>
        <p class="pb-3">Cliccare sul pulsante estrai per scaricare in formato Excel il dettaglio del <b>registro dei controlli POR FESR MARCHE 2014-2020</b>. E' possibile estrarre i controlli all'interno di un intervallo di date.</p>
        <div class="col-sm-4 form-group">
            <Siar:DateTextBox Label="Data di inizio (opzionale):" ID="txtFiltroDataInizio" runat="server" />
        </div>
        <div class="col-sm-4 form-group">
            <Siar:DateTextBox Label="Data di fine (opzionale):" ID="txtFiltroDataFine" runat="server" />
        </div>
        <div class="col-sm-4">
            <input id="btnStampaRegistroControlli" class="btn btn-secondary py-1" type="button" value="Estrai"
                onclick="stampaRicercaRegistroControlli();" /><br />
        </div>
    </div>
    <div class="row p-5" id="div5" runat="server">
        <div class="col-sm-6">
            <p>Elenco dei Rup e dei Validatori Aiuti:</p>
            <input id="btnstampaRupValidatoriAiuti" class="btn btn-primary py-1" type="button" value="Estrai i nominativi in XLS"
                onclick="stampaRupValidatoriAiuti();" /><br />
        </div>
        <div class="col-sm-6">
            <p>Elenco dei Rup e dei Validatori NON aiuti:</p>
            <input id="btnstampaRupValidatoriNoAiuti" class="btn btn-primary py-1" type="button" value="Estrai i nominativi in XLS"
                onclick="stampaRupValidatoriNoAiuti();" /><br />
        </div>
    </div>
    <div class="row bd-form" id="divEstrazioneAsse" runat="server">
        <p class="mb-3">Elenco degli interventi:</p>
        <div class="col-sm-10">
            <Siar:ComboZProgrammazioneAsseAzInt Label="Selezionare l'asse: " ID="lstProgrammazione" runat="server" AutoPostBack="True">
            </Siar:ComboZProgrammazioneAsseAzInt>
        </div>
        <div class="col-sm-2">
            <Siar:Button ID="btnEstraiXls" runat="server" Text="Estrai in XLS" />
        </div>
        <div class="col-sm-12 mt-3">
            <Siar:DataGridAgid ID="dgInterventi" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
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
            </Siar:DataGridAgid>
        </div>
    </div>
</asp:Content>
