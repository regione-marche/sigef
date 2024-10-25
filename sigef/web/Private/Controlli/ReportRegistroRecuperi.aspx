<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="ReportRegistroRecuperi.aspx.cs" Inherits="web.Private.Controlli.ReportRegistroRecuperi" %>

<%@ Register Src="~/CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/ZoomLoader.ascx" TagName="ZoomLoader" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function estraiInXlsRitiri() {
            var prog = $('[id$=lstProgrammazioneNew]').val(),
                id_progetto = $('[id$=txtIdProgetto]').val(),
                origine = $('[id$=lstTipoOrigine]').val(),
                soggetto = $('[id$=lstSoggettoRilevatore]').val();
                detrazione = $('[id$=lstTipoDetrazione]').val(),
                periodo = $('[id$=lstPeriodoContabile]').val();
            var parametri = "";

            if (prog != '')
                parametri += "Programmazione=" + prog;
            if (id_progetto != '') {
                if (parametri != '')
                    parametri = "|IdProgetto=" + id_progetto;
                else
                    parametri = "IdProgetto=" + id_progetto;
            }
            if (origine != '') {
                if (parametri != '')
                    parametri = "|TipoOrigine=" + origine;
                else
                    parametri = "TipoOrigine=" + origine;
            }
            if (soggetto != '') {
                if (parametri != '')
                    parametri = "|SoggettoRilevatore=" + soggetto;
                else
                    parametri = "SoggettoRilevatore=" + soggetto;
            }
            if (detrazione != '') {
                if (parametri != '')
                    parametri = "|TipoDetrazione=" + detrazione;
                else
                    parametri = "TipoDetrazione=" + detrazione;
            }
            if (periodo != '') {
                if (parametri != '')
                    parametri = "|PeriodoContabile=" + periodo;
                else
                    parametri = "PeriodoContabile=" + periodo;
            }

            SNCVisualizzaReport('rptRegistroRitiri', 2, parametri);
        }

        function estraiInXls() {
            var prog = $('[id$=lstProgrammazioneNew]').val(),
                id_progetto = $('[id$=txtIdProgetto]').val(),
                data_inizio = $('[id$=txtDataInizioRicerca]').val(),
                data_fine = $('[id$=txtDataFineRicerca]').val();
            var parametri = "";

            if (prog != '')
                parametri += "Programmazione=" + prog;
            if (id_progetto != '') {
                if (parametri != '')
                    parametri = "|IdProgetto=" + id_progetto;
                else
                    parametri = "IdProgetto=" + id_progetto;
            }
            if (data_inizio != '') {
                if (parametri != '')
                    parametri = "|DataInizio=" + data_inizio;
                else
                    parametri = "DataInizio=" + data_inizio;
            }
            if (data_fine != '') {
                if (parametri != '')
                    parametri = "|DataFine=" + data_fine;
                else
                    parametri = "DataFine=" + data_fine;
            }

            SNCVisualizzaReport('rptRegistroRecuperiRitiri', 2, parametri);
        }
    </script>

    <style type="text/css">
        .mrw-table { display: table; table-layout: fixed; width: 100%; padding: 10px; border-style: solid; }
        .mrw-tr { display: table-row; width: 100%; }
        .mrw-header {}
        .mrw-tr > div { display: table-cell; vertical-align: middle; padding: 10px 2px; white-space: nowrap; overflow: hidden; }
        .mrw-th, .mrw-tf { font-weight: bold; }
        .mrw-td { border-bottom-width: 1px; border-bottom-style: solid; }
        .mrw-grid .mrw-td { border-left-width: 1px; border-left-style: solid; }
        .mrw-grid .mrw-td:last-child { border-right-width: 1px; border-right-style: solid; }
        .mrw-width-5 { width: 5%; }
        .mrw-width-10 { width: 10%; }
        .mrw-width-15 { width: 15%; }
        .mrw-width-20 { width: 20%; }
        .mrw-width-25 { width: 25%; }
        .mrw-width-30 { width: 30%; }
        .mrw-width-33 { width: 33%; }
        .mrw-width-34 { width: 34%; }
        .mrw-width-35 { width: 35%; }
        .mrw-width-40 { width: 40%; }
        .mrw-width-45 { width: 45%; }
        .mrw-width-50 { width: 50%; }
        .mrw-width-55 { width: 55%; }
        .mrw-width-60 { width: 60%; }
        .mrw-width-65 { width: 65%; }
        .mrw-width-70 { width: 70%; }
        .mrw-width-75 { width: 75%; }
        .mrw-width-80 { width: 80%; }
        .mrw-width-85 { width: 85%; }
        .mrw-width-90 { width: 90%; }
        .mrw-width-95 { width: 95%; }
        .mrw-width-100 { width: 100%; }
        .mrw-center { vertical-align: top; margin: auto !important; text-align: center; }
        .mrw-right { text-align: right; }
        .dBox-overflow 
        {
	        box-shadow: 2px 3px 10px;
	        border-radius: 5px;
	        background-color:#E6E6EE;        	
	        margin:0px 10px 20px 10px;
	        overflow:hidden;
        }
    </style>

    <div style="display: none">
        <asp:HiddenField ID="hdnRicercaBool" runat="server" />
        <asp:HiddenField ID="hdnIdProgetto" runat="server" />
        <asp:HiddenField ID="hdnDataInizioRicerca" runat="server" />
        <asp:HiddenField ID="hdnDataFineRicerca" runat="server" />
        <asp:HiddenField ID="hdnTipoOrgine" runat="server" />
        <asp:HiddenField ID="hdnSoggettoRilevatore" runat="server" />
        <asp:HiddenField ID="hdnTipoDetrazione" runat="server" />
        <asp:HiddenField ID="hdnPeriodoContabile" runat="server" />
    </div>

    <div class="dBox-overflow">
        <div class="separatore_big">
            Ricerca ritiri e recuperi
        </div>
        <div style="padding: 15px;">
            Programmazione:<br />
            <Siar:ComboGroupZProgrammazione ID="lstProgrammazioneNew" runat="server" Width="700px"></Siar:ComboGroupZProgrammazione><br />
            <br />

            Nr. domanda:<br />
            <Siar:IntegerTextBox ID="txtIdProgetto" runat="server" NoCurrency="True" Width="80px" />
            <br />
            <br />

            <div style="display: inline-block;">
                Origine:<br />
                <Siar:ComboTipoOrigine ID="lstTipoOrigine" runat="server" Width="150px"></Siar:ComboTipoOrigine><br />
            </div>
            <div style="display: inline-block; padding-left: 20px;">
                Soggetto Rilevatore:<br />
               <Siar:ComboSoggettoRilevatore ID="lstSoggettoRilevatore" runat="server" Width="300px"></Siar:ComboSoggettoRilevatore><br />
            </div>
            <br />
            <br />
            <div style="display: inline-block;">
                Tipo Detrazione:<br />
                <Siar:ComboTipoDetrazione ID="lstTipoDetrazione" runat="server" Width="150px"></Siar:ComboTipoDetrazione><br />
            </div>
            <div style="display: inline-block; padding-left: 20px;">
                Periodo Contabile:<br />
                <Siar:ComboPeriodoContabile ID="lstPeriodoContabile" runat="server" Width="200px"></Siar:ComboPeriodoContabile><br />
            </div>
            <br />
            <br style="clear: both;" />
            <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" Width="140px" />
            <br />
            <br />

            <div id="divElaborazione" runat="server" visible="false">
                <Siar:Button ID="btnSalvaRegistro" runat="server" OnClick="btnSalvaRegistro_Click" Text="Salva registro" Width="140px" />

                <input type="button" class="Button" value="Estrai in xls" style="width: 140px; margin-left: 20px;" onclick="return estraiInXls();" />
            </div>
        </div>
    </div>

    <div id="divReport" class="dBox-overflow" visible="false" runat="server">
        <uc1:SiarNewTab ID="tabReport" runat="server" TabNames="Ritiri|Recuperi|Non recuperabili" Titolo="Registri" />
        <div style="padding: 10px">
            <div id="divRegistroRitiri" runat="server" visible="false">
                <br />
                <input type="button" class="Button" value="Estrai in xls" style="width: 140px; margin-left: 20px;" onclick="return estraiInXlsRitiri();" />
                <br /><br />
                <Siar:DataGrid ID="dgRegistroRitiri" runat="server" AutoGenerateColumns="false" Visible="false" AllowPaging="true" PageSize="40">
                    <Columns>
                        <asp:BoundColumn DataField="CodAssE" HeaderText="Asse">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CodAzione" HeaderText="Azione">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CodIntervento" HeaderText="Intervento">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Id. Prog.">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdRitiro" HeaderText="Id Ritiro">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoRitiro" HeaderText="Tipo Ritiro">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Beneficiario" HeaderText="Beneficiario">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <%--<asp:BoundColumn DataField="BeneficiarioPiva" HeaderText="Beneficiario">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>--%>
                        <asp:BoundColumn DataField="SoggettoRilevatore" HeaderText="<div style='width:150px'>Soggetto che ha rilevato la spesa irregolare</div>">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoDetrazione" HeaderText="Tipo di Detrazione">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdLotto" HeaderText="Id Lotto">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataLotto" HeaderText="Data Lotto">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PeriodoContabile" HeaderText="Periodo contabile di riferimento">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PeriodoContabileSpesa" HeaderText="Periodo contabile di riferimento">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoTotale" DataFormatString="{0:c}" HeaderText="Importo Totale">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemStyle Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Fesr" DataFormatString="{0:c}" HeaderText="FESR">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemStyle Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Stato" DataFormatString="{0:c}" HeaderText="Stato">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemStyle Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Regione" DataFormatString="{0:c}" HeaderText="Regione">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemStyle Width="70px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </div>

            <Siar:DataGrid ID="dgRegistroRecuperi" runat="server" AutoGenerateColumns="false" Visible="false" AllowPaging="true" PageSize="20">
                <Columns>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id. Prog.">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="CodAsse" HeaderText="<div style='width:60px'>Asse Intervento</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescAzione" HeaderText="<div style='width:100px'>Titolo</div>">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdImpresa" HeaderText="<div style='width:60px'>Beneficiario</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="SoggettoRevocaFinanziamento" HeaderText="<div style='width:60px'>Soggetto che ha rilevato la spesa irregolare</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdAttoRecupero" HeaderText="Verbale o Atto che ha determinato il recupero">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="IdRegistroIrregolarita" Name="chkOlaf" HeaderText="Notificato OLAF" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumn>
                    <asp:BoundColumn DataField="DataAvvio" HeaderText="<div style='width:60px'>Periodo contabile di riferimento</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:DatetimeColumn DataField="IdRegistroRecupero" HeaderText="<div style='width:60px'>Data rilevazione</div>"
                        DataFormatString="{0:dd/MM/yyyy}" Name="DataCertificazioneRecupero">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:DatetimeColumn>
                    <asp:BoundColumn DataField="ImportoDaRecuperareUe" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>FESR</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoDaRecuperareNazionale" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Stato</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoDaRecuperareNazionale" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Regione</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoDaRecuperarePubblico" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Totale pubblico</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoDaRecuperarePrivato" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Privati</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoDaRecuperareTotale" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Totale spesa irregolare</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoInteressiLegali" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Eventuali interessi legali</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoInteressiMora" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Eventuali interessi mora</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoGestionePratica" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Spesa gestione pratica</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoDaRecuperareUe" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Sanzioni</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoRecuperatoUe" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>FESR</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoRecuperatoNazionale" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Stato</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoRecuperatoNazionale" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Regione</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoRecuperatoPubblico" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Totale pubblico</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoRecuperatoPrivato" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Privati</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoRecuperatoTotale" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Totale spesa recuperata</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataConclusione" HeaderText="<div style='width:60px'>Data fine recupero</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="IdRegistroIrregolarita" Name="chkArt71" HeaderText="Spesa recuperata a norma dell'art.71 del Reg. (UE) n.1303/2013" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumn>
                    <asp:BoundColumn DataField="ImportoDaRecuperareUe" HeaderText="<div style='width:60px'>Spesa passata alla sezione Ritiri</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>

            <Siar:DataGrid ID="dgRegistroNonRecuperabili" runat="server" AutoGenerateColumns="false" Visible="false" AllowPaging="true" PageSize="20">
                <Columns>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id. Prog.">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="CodAsse" HeaderText="<div style='width:60px'>Asse Intervento</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescAzione" HeaderText="<div style='width:100px'>Titolo</div>">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdImpresa" HeaderText="<div style='width:60px'>Beneficiario</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="SoggettoRevocaFinanziamento" HeaderText="<div style='width:60px'>Soggetto che ha rilevato la spesa irregolare</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdAttoRecupero" HeaderText="Verbale o Atto che ha determinato il recupero">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="IdRegistroIrregolarita" Name="chkOlaf" HeaderText="Notificato OLAF" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumn>
                    <asp:BoundColumn DataField="DataAvvio" HeaderText="<div style='width:60px'>Periodo contabile di riferimento</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:DatetimeColumn DataField="IdRegistroRecupero" HeaderText="<div style='width:60px'>Data rilevazione</div>"
                        DataFormatString="{0:dd/MM/yyyy}" Name="DataCertificazioneNonRecuperabilita">
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:DatetimeColumn>
                    <asp:BoundColumn DataField="ImportoDaRecuperareUe" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>FESR</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoDaRecuperareNazionale" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Stato</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoDaRecuperareNazionale" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Regione</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoDaRecuperarePubblico" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Totale pubblico</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoDaRecuperarePrivato" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Privati</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoDaRecuperareTotale" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Totale spesa irregolare</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoInteressiLegali" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Eventuali interessi legali</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoInteressiMora" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Eventuali interessi mora</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoGestionePratica" DataFormatString="{0:c}" HeaderText="<div style='width:60px'>Spesa gestione pratica</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdAttoNonRecuperabilita" HeaderText="<div style='width:60px'>Atto che ha dichiarato la non recuperabilità</div>">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

</asp:Content>
