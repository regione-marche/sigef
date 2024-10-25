<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="ReportRegistroRecuperi.aspx.cs" Inherits="web.Private.Controlli.ReportRegistroRecuperi" %>

<%@ Register Src="~/CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/ZoomLoader.ascx" TagName="ZoomLoader" TagPrefix="uc2" %>
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

    <div class="row bg-200">
        <h4 class="pb-5">Ricerca ritiri e recuperi</h4>
        <div class="col-sm-12 form-group">
            <Siar:ComboGroupZProgrammazione CssClass="rounded" Label="Programmazione" ID="lstProgrammazioneNew" runat="server"></Siar:ComboGroupZProgrammazione>
        </div>
        <div class="col-sm-2 form-group">
            <Siar:IntegerTextBox Label="N. Domanda" ID="txtIdProgetto" runat="server" NoCurrency="True" />
        </div>
        <div class="col-sm-2 form-group">
            <label class="active fw-semibold" for="lstTipoOrigine">Origine</label>
            <Siar:ComboTipoOrigine ID="lstTipoOrigine" runat="server" />
        </div>
        <div class="col-sm-2 form-group">
            <label class="active fw-semibold" for="lstSoggettoRilevatore">Soggetto Rilevatore</label>
            <Siar:ComboSoggettoRilevatore CssClass="rounded" ID="lstSoggettoRilevatore" runat="server" />
        </div>
        <div class="col-sm-2 form-group">
            <label class="active fw-semibold" for="lstTipoDetrazione">Tipo Detrazione</label>
            <Siar:ComboTipoDetrazione ID="lstTipoDetrazione" runat="server"></Siar:ComboTipoDetrazione>
        </div>
        <div class="col-sm-2 form-group">
            <label class="active fw-semibold" for="lstPeriodoContabile">Periodo Contabile</label>
            <Siar:ComboPeriodoContabile ID="lstPeriodoContabile" runat="server"></Siar:ComboPeriodoContabile>
        </div>
        <div class="col-sm-2">
            <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" />
        </div>
    </div>

    <div id="divReport" class="container-fluid" visible="false" runat="server">
        <uc1:SiarNewTab ID="tabReport" runat="server" TabNames="Ritiri|Recuperi|Non recuperabili" Titolo="Registri" />
        <div id="divRegistroRitiri" class="tableTab" runat="server" visible="false">
            <div class="d-flex flex-row justify-content-end align-items-center pt-4">
                <input type="button" class="btn btn-primary " value="Estrai in xls" onclick="return estraiInXlsRitiri();" />
            </div>
            <div class="table-responsive p-2">
                <Siar:DataGridAgid ID="dgRegistroRitiri" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                    <Columns>
                        <asp:BoundColumn DataField="CodAssE" HeaderText="Asse">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CodObiettivoSpecifico" HeaderText="Obiettivo Specifico">
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
                </Siar:DataGridAgid>
            </div>
            <div class="table-responsive p-2">
                <Siar:DataGridAgid ID="dgRegistroRecuperi" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
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
                </Siar:DataGridAgid>
            </div>
            <div class="table-responsive p-2">
                <Siar:DataGridAgid ID="dgRegistroNonRecuperabili" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
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
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>

</asp:Content>
