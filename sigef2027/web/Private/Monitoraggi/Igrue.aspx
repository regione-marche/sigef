<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="Igrue.aspx.cs" Inherits="web.Private.Monitoraggi.Igrue" %>

<%@ Register Src="~/CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaInvioFesr(idInvio) {
            $('[id$=hdnIdInvioFesr]').val($('[id$=hdnIdInvioFesr]').val() == idInvio ? '' : idInvio);
            if ($('[id$=hdnIdInvioFesr]').val() == '') $('[id$=hdnIdLogErroriFesr]').val('');
            $('[id$=btnPost]').click();
        }

        function selezionaFileErroriFesr(idLogErrori) {
            $('[id$=hdnIdLogErroriFesr]').val($('[id$=hdnIdLogErroriFesr]').val() == idLogErrori ? '' : idLogErrori);
            $('[id$=btnPost]').click();
        }

        function estraiInXlsFesr() {
            var id_invio = $('[id$=hdnIdInvioFesr]').val();
            SNCVisualizzaReport('rptLogErroriTrasmissioneIgrue', 2, "IdInvio=" + id_invio);
        }

        function selezionaInvioLeggeStabilita(idInvio) {
            $('[id$=hdnIdInvioLeggeStabilita]').val($('[id$=hdnIdInvioLeggeStabilita]').val() == idInvio ? '' : idInvio);
            if ($('[id$=hdnIdInvioLeggeStabilita]').val() == '') $('[id$=hdnIdLogErroriLeggeStabilita]').val('');
            $('[id$=btnPost]').click();
        }

        function selezionaFileErroriLeggeStabilita(idLogErrori) {
            $('[id$=hdnIdLogErroriLeggeStabilita]').val($('[id$=hdnIdLogErroriLeggeStabilita]').val() == idLogErrori ? '' : idLogErrori);
            $('[id$=btnPost]').click();
        }

        function estraiInXlsLeggeStabilita() {
            var id_invio = $('[id$=hdnIdInvioLeggeStabilita]').val();
            SNCVisualizzaReport('rptLogErroriTrasmissioneIgrue', 2, "IdInvio=" + id_invio);
        }

        function selezionaInvioPsc(idInvio) {
            $('[id$=hdnIdInvioPsc]').val($('[id$=hdnIdInvioPsc]').val() == idInvio ? '' : idInvio);
            if ($('[id$=hdnIdInvioPsc]').val() == '') $('[id$=hdnIdLogErroriPsc]').val('');
            $('[id$=btnPost]').click();
        }

        function selezionaFileErroriPsc(idLogErrori) {
            $('[id$=hdnIdLogErroriPsc]').val($('[id$=hdnIdLogErroriPsc]').val() == idLogErrori ? '' : idLogErrori);
            $('[id$=btnPost]').click();
        }

        function estraiInXlsPsc() {
            var id_invio = $('[id$=hdnIdInvioPsc]').val();
            SNCVisualizzaReport('rptLogErroriTrasmissioneIgrue', 2, "IdInvio=" + id_invio);
        }

        function changeTracciati() {
            var radiovalue = $('[id$=rblTipiTracciati]').find(":checked").val();

            if (radiovalue == "1")
                $('[id$=divSceltaTracciati]').show("fast");
            else
                $('[id$=divSceltaTracciati]').hide("fast");
        }

        function changeTracciatiEliminazione() {
            var radiovalue = $('[id$=rblTipiTracciatiEliminazione]').find(":checked").val();

            if (radiovalue == "1")
                $('[id$=divSceltaTracciatiEliminazione]').show("fast");
            else
                $('[id$=divSceltaTracciatiEliminazione]').hide("fast");
        }

        function changeModalitaEliminazione() {
            var radiovalue = $('[id$=rblTipoEliminazione]').find(":checked").val();

            if (radiovalue == "1") {
                $('[id$=divEliminazioneIdProgetti]').show("fast");
                $('[id$=divEliminazioneFiltroSQL]').hide("fast");
            } else if (radiovalue == "2") {
                $('[id$=divEliminazioneIdProgetti]').hide("fast");
                $('[id$=divEliminazioneFiltroSQL]').show("fast");
            } else {
                $('[id$=divEliminazioneIdProgetti]').hide("fast");
                $('[id$=divEliminazioneFiltroSQL]').hide("fast");
            }
        }

        function readyFn(jQuery) {
            $('[id$=rblTipiTracciati]').change(changeTracciati);
            $('[id$=rblTipiTracciati]').change();

            $('[id$=rblTipiTracciatiEliminazione]').change(changeTracciatiEliminazione);
            $('[id$=rblTipiTracciatiEliminazione]').change();

            $('[id$=rblTipoEliminazione]').change(changeModalitaEliminazione);
            $('[id$=rblTipoEliminazione]').change();
        }

        function pageLoad() {
            readyFn();
        }
    </script>

    <style type="text/css">
        .mrw-table {
            display: table;
            table-layout: fixed;
            width: 100%;
            padding: 10px;
            border-style: solid;
        }

        .mrw-tr {
            display: table-row;
            width: 100%;
        }

        .mrw-header {
        }

        .mrw-tr > div {
            display: table-cell;
            vertical-align: middle;
            padding: 10px 2px;
            white-space: nowrap;
            overflow: hidden;
        }

        .mrw-th, .mrw-tf {
            font-weight: bold;
        }

        .mrw-td {
            border-bottom-width: 1px;
            border-bottom-style: solid;
        }

        .mrw-grid .mrw-td {
            border-left-width: 1px;
            border-left-style: solid;
        }

            .mrw-grid .mrw-td:last-child {
                border-right-width: 1px;
                border-right-style: solid;
            }

        .mrw-width-5 {
            width: 5%;
        }

        .mrw-width-10 {
            width: 10%;
        }

        .mrw-width-15 {
            width: 15%;
        }

        .mrw-width-20 {
            width: 20%;
        }

        .mrw-width-25 {
            width: 25%;
        }

        .mrw-width-30 {
            width: 30%;
        }

        .mrw-width-33 {
            width: 33%;
        }

        .mrw-width-34 {
            width: 34%;
        }

        .mrw-width-35 {
            width: 35%;
        }

        .mrw-width-40 {
            width: 40%;
        }

        .mrw-width-45 {
            width: 45%;
        }

        .mrw-width-50 {
            width: 50%;
        }

        .mrw-width-55 {
            width: 55%;
        }

        .mrw-width-60 {
            width: 60%;
        }

        .mrw-width-65 {
            width: 65%;
        }

        .mrw-width-70 {
            width: 70%;
        }

        .mrw-width-75 {
            width: 75%;
        }

        .mrw-width-80 {
            width: 80%;
        }

        .mrw-width-85 {
            width: 85%;
        }

        .mrw-width-90 {
            width: 90%;
        }

        .mrw-width-95 {
            width: 95%;
        }

        .mrw-width-100 {
            width: 100%;
        }

        .mrw-center {
            vertical-align: top;
            margin: auto !important;
            text-align: center;
        }

        .mrw-right {
            text-align: right;
        }

        .dBox-overflow {
            box-shadow: 2px 3px 10px;
            border-radius: 5px;
            background-color: #E6E6EE;
            /*margin:0px 10px 20px 10px;*/
            overflow: hidden;
        }

        .first_elem_block {
            /*width: 250px;*/
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {
            /*width: 250px;*/
            vertical-align: top;
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-left: 20px;
            padding-bottom: 5px;
        }

        .label {
            display: inline;
            float: left;
            /*min-width: 200px;
            max-width: 200px;
            width: 200px;*/
            text-align: right;
            vertical-align: middle;
        }

        .value {
            float: right;
            margin-left: 5px;
        }
    </style>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdInvioFesr" runat="server" />
        <asp:HiddenField ID="hdnIdLogErroriFesr" runat="server" />
        <asp:HiddenField ID="hdnIdInvioLeggeStabilita" runat="server" />
        <asp:HiddenField ID="hdnIdLogErroriLeggeStabilita" runat="server" />
        <asp:HiddenField ID="hdnIdInvioPsc" runat="server" />
        <asp:HiddenField ID="hdnIdLogErroriPsc" runat="server" />
        <asp:HiddenField ID="hdnDownloadZip" runat="server" />

        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" />
    </div>


    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="POR FESR 2014 - 2020|ITI Aree Interne - Legge di Stabilità 2014-2020|PSC|Gestione avanzata" Titolo="Monitoraggio IGRUE" />

    <div id="divFesr" class="row" runat="server">
        <div class="col-sm-12 mt-5 pb-5">
            <input type="hidden" id="txtFiles" runat="server" value="PA00,PA01,AP00,AP01,AP02,AP03,AP04,AP05,AP06,FN00,FN01,FN02,FN03,FN04,FN05,FN06,FN07,FN09,IN00,IN01,PR00,PR01,SC00" />
            <Siar:Button ID="btnInviaDatiMonitoraggioFesr" runat="server" OnClick="btnInviaDatiMonitoraggioFesr_Click" Text="Invia i dati del monitoraggio all'IGRUE" OnClientClick="return confirm('Inviare i dati di monitoraggio al Sistema Nazionale?')" />
        </div>
        <div class="col-sm-12">
            <asp:Label runat="server" ID="lblErroriInvioFesr"></asp:Label>
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgIgrueInviiFesr" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20">
                <Columns>
                    <Siar:ColonnaLinkAgid DataField="IdInvio" HeaderText="Id invio" IsJavascript="true"
                        LinkFields="IdInvio" LinkFormat="selezionaInvioFesr({0});">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:ColonnaLinkAgid>
                    <asp:BoundColumn DataField="IdTicket" HeaderText="Id ticket">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataInvio" HeaderText="Data invio">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TimestampEsito" HeaderText="Data esito invio">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataRichiesta" HeaderText="Data richiesta trasmissione">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <%--<asp:BoundColumn DataField="DettaglioEsitoLog" HeaderText="Dettaglio esito trasmissione">
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:BoundColumn>--%>
                    <asp:BoundColumn DataField="TimestampEsito" HeaderText="Data esito trasmissione">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:CheckColumnAgid DataField="IdIgrueLogErrori" Name="ErroriPresenti" HeaderText="Errori presenti" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
            <div id="divDettaglioFesr" class="row mt-5" visible="false" runat="server">
                <h3 class="mt-3 pb-3">Dati esito invio
                </h3>
                <div class="col-sm-12 pb-5">
                    <Siar:Button ID="btnRichiediValidazioneFesr" runat="server" OnClick="btnRichiediValidazioneFesr_Click" Text="Verifica esito trasmissione" />
                    <Siar:Button ID="btnDownloadFileInvioFesr" runat="server" OnClick="btnDownloadFileInvioFesr_Click" Text="Download file inviato" />
                </div>
                <div class="col-sm-12">
                    <Siar:DataGridAgid CssClass="table table-striped" ID="dgInvioLogFesr" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20">
                        <Columns>
                            <Siar:ColonnaLinkAgid DataField="IdIgrueLogErrori" HeaderText="Id esito" IsJavascript="true"
                                LinkFields="IdIgrueLogErrori" LinkFormat="selezionaFileErroriFesr({0});">
                                <ItemStyle HorizontalAlign="Center" />
                            </Siar:ColonnaLinkAgid>
                            <asp:BoundColumn DataField="DataRichiesta" HeaderText="Data richiesta">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DescrizioneEsito" HeaderText="Descrizione esito">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DettaglioEsito" HeaderText="Dettaglio esito">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TimestampEsito" HeaderText="Data esito">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IstanzaErrori" HeaderText="Errori presenti">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>

            <div id="divDettaglioErroriFesr" class="row" visible="false" runat="server">
                <h3 class="mt-3 pb-3">Errori dell'invio
                </h3>

                <div class="col-sm-4 form-group">

                    <Siar:TextBox Label="Id invio:" ID="txtIdInvioErroreFesr" runat="server" Enabled="false" />
                </div>
                <div class="col-sm-4 form-group">

                    <Siar:TextBox Label="Id ticket:" ID="txtIdTicketErroreFesr" runat="server" Enabled="false" />
                </div>
                <div class="col-sm-4">
                    <input type="button" class="btn btn-secondary py-1" value="Estrai in xls" onclick="return estraiInXlsFesr();" />
                </div>

            </div>

            <div class="col-sm-12">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgLogErroriFesr" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20">
                    <Columns>
                        <asp:BoundColumn DataField="TipoFile" HeaderText="Tipo file">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdBando" HeaderText="Id bando">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Id progetto">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="NumeroRiga" HeaderText="Numero riga">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CampoTracciato" HeaderText="Campo tracciato">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CodiceGruppo" HeaderText="Codice gruppo">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CodiceErrore" HeaderText="Codice errore">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DescrizioneErrore" HeaderText="Descrizione errore">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>

    <div id="divLeggeStabilita" class="row" runat="server">
        <div class="col-sm-12 mt-5 pb-5">
            <input type="hidden" id="txtFilesLeggeStabilita" runat="server" value="PA00,PA01,AP00,AP01,AP02,AP03,AP04,AP05,AP06,FN00,FN01,FN02,FN03,FN04,FN05,FN06,FN07,IN00,IN01,PR00,PR01,SC00" />
            <Siar:Button ID="btnInviaDatiMonitoraggioLeggeStabilita" runat="server" OnClick="btnInviaDatiMonitoraggioLeggeStabilita_Click" Text="Invia i dati del monitoraggio all'IGRUE" OnClientClick="return confirm('Inviare i dati di monitoraggio al Sistema Nazionale?')" />

        </div>
        <div class="col-sm-12">
            <asp:Label runat="server" ID="lblErroriInvioLeggeStabilita"></asp:Label>

        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgIgrueInviiLeggeStabilita" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%">
                <Columns>
                    <Siar:ColonnaLinkAgid DataField="IdInvio" HeaderText="Id invio" IsJavascript="true"
                        LinkFields="IdInvio" LinkFormat="selezionaInvioLeggeStabilita({0});">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:ColonnaLinkAgid>
                    <asp:BoundColumn DataField="IdTicket" HeaderText="Id ticket">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataInvio" HeaderText="Data invio">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TimestampEsito" HeaderText="Data esito invio">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataRichiesta" HeaderText="Data richiesta trasmissione">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <%--<asp:BoundColumn DataField="DettaglioEsitoLog" HeaderText="Dettaglio esito trasmissione">
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:BoundColumn>--%>
                    <asp:BoundColumn DataField="TimestampEsito" HeaderText="Data esito trasmissione">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:CheckColumnAgid DataField="IdIgrueLogErrori" Name="ErroriPresenti" HeaderText="Errori presenti" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>

            <div id="divDettaglioLeggeStabilita" class="row mt-5" visible="false" runat="server">
                <h3 class="mt-3 pb-3">Dati esito invio
                </h3>

                <div class="col-sm-12">
                    <Siar:Button ID="btnRichiediValidazioneLeggeStabilita" runat="server" OnClick="btnRichiediValidazioneLeggeStabilita_Click" Text="Verifica esito trasmissione" />
                    <Siar:Button ID="btnDownloadFileInvioLeggeStabilita" runat="server" OnClick="btnDownloadFileInvioLeggeStabilita_Click" Text="Download file inviato" />
                </div>

                <div class="col-sm-12">
                    <Siar:DataGridAgid ID="dgInvioLogLeggeStabilita" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%">
                        <Columns>
                            <Siar:ColonnaLinkAgid DataField="IdIgrueLogErrori" HeaderText="Id esito" IsJavascript="true"
                                LinkFields="IdIgrueLogErrori" LinkFormat="selezionaFileErroriLeggeStabilita({0});">
                                <ItemStyle HorizontalAlign="Center" />
                            </Siar:ColonnaLinkAgid>
                            <asp:BoundColumn DataField="DataRichiesta" HeaderText="Data richiesta">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DescrizioneEsito" HeaderText="Descrizione esito">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DettaglioEsito" HeaderText="Dettaglio esito">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TimestampEsito" HeaderText="Data esito">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IstanzaErrori" HeaderText="Errori presenti">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>

            <div id="divDettaglioErroriLeggeStabilita" class="row" visible="false" runat="server">
                <h3 class="mt-3 pb-3">Errori dell'invio    
                </h3>

                <div class="col-sm-4 form-group">
                    <Siar:TextBox Label="Id invio:" ID="txtIdInvioErroreLeggeStabilita" runat="server" Enabled="false" />
                </div>
                <div class="col-sm-4 form-group">

                    <Siar:TextBox Label="Id ticket:" ID="txtIdTicketErroreLeggeStabilita" runat="server" Enabled="false" />
                </div>
                <div class="col-sm-4">
                    <input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return estraiInXlsLeggeStabilita();" />
                </div>


                <div class="col-sm-12">
                    <Siar:DataGridAgid CssClass="table table-striped" ID="dgLogErroriLeggeStabilita" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20">
                        <Columns>
                            <asp:BoundColumn DataField="TipoFile" HeaderText="Tipo file">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IdBando" HeaderText="Id bando">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IdProgetto" HeaderText="Id progetto">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="NumeroRiga" HeaderText="Numero riga">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="CampoTracciato" HeaderText="Campo tracciato">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="CodiceGruppo" HeaderText="Codice gruppo">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="CodiceErrore" HeaderText="Codice errore">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DescrizioneErrore" HeaderText="Descrizione errore">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
        </div>
    </div>

    <div id="divPsc" class="row" runat="server">
        <div class="col-sm-12 mt-5 pb-5">
            <input type="hidden" id="txtFilesPsc" runat="server" value="PA00,PA01,AP00,AP01,AP02,AP03,AP04,AP05,AP06,FN00,FN01,FN02,FN03,FN04,FN05,FN06,FN07,IN00,IN01,PR00,PR01,SC00" />
            <Siar:Button ID="btnInviaDatiMonitoraggioPsc" runat="server" OnClick="btnInviaDatiMonitoraggioPsc_Click" Text="Invia i dati del monitoraggio all'IGRUE" OnClientClick="return confirm('Inviare i dati di monitoraggio al Sistema Nazionale?')" />

        </div>
        <div class="col-sm-12">
            <asp:Label runat="server" ID="lblErroriInvioPsc"></asp:Label>
        </div>

        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgIgrueInviiPsc" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%">
                <Columns>
                    <Siar:ColonnaLinkAgid DataField="IdInvio" HeaderText="Id invio" IsJavascript="true"
                        LinkFields="IdInvio" LinkFormat="selezionaInvioPsc({0});">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:ColonnaLinkAgid>
                    <asp:BoundColumn DataField="IdTicket" HeaderText="Id ticket">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataInvio" HeaderText="Data invio">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TimestampEsito" HeaderText="Data esito invio">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataRichiesta" HeaderText="Data richiesta trasmissione">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <%--<asp:BoundColumn DataField="DettaglioEsitoLog" HeaderText="Dettaglio esito trasmissione">
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:BoundColumn>--%>
                    <asp:BoundColumn DataField="TimestampEsito" HeaderText="Data esito trasmissione">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:CheckColumnAgid DataField="IdIgrueLogErrori" Name="ErroriPresenti" HeaderText="Errori presenti" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>

            <div id="divDettaglioPsc" class="row mt-5" visible="false" runat="server">
                <h3 class="mt-3 pb-3">Dati esito invio
                </h3>

                <div class="col-sm-12 pb-5">
                    <Siar:Button ID="btnRichiediValidazionePsc" runat="server" OnClick="btnRichiediValidazionePsc_Click" Text="Verifica esito trasmissione" />
                    <Siar:Button ID="btnDownloadFileInvioLPsc" runat="server" OnClick="btnDownloadFileInvioPsc_Click" Text="Download file inviato" />
                </div>
                <div class="col-sm-12">
                    <Siar:DataGridAgid CssClass="table table-striped" ID="dgInvioLogPsc" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%">
                        <Columns>
                            <Siar:ColonnaLinkAgid DataField="IdIgrueLogErrori" HeaderText="Id esito" IsJavascript="true"
                                LinkFields="IdIgrueLogErrori" LinkFormat="selezionaFileErroriPsc({0});">
                                <ItemStyle HorizontalAlign="Center" />
                            </Siar:ColonnaLinkAgid>
                            <asp:BoundColumn DataField="DataRichiesta" HeaderText="Data richiesta">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DescrizioneEsito" HeaderText="Descrizione esito">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DettaglioEsito" HeaderText="Dettaglio esito">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TimestampEsito" HeaderText="Data esito">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IstanzaErrori" HeaderText="Errori presenti">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>

            <div id="divDettaglioErroriPsc" class="row" visible="false" runat="server">
                <h3 class="mt-3 pb-3">Errori dell'invio
                </h3>

                <div class="col-sm-4 form-group">
                    <Siar:TextBox Label="Id invio:" ID="txtIdInvioErrorePsc" runat="server" Enabled="false" />
                </div>
                <<div class="col-sm-4 form-group">
                    <Siar:TextBox Label="Id ticket:" ID="txtIdTicketErrorePsc" runat="server" Enabled="false" />
                </div>
                <div class="col-sm-4">
                    <input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return estraiInXlsPsc();" />
                </div>
            </div>

            <div class="col-sm-12">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgLogErroriPsc" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20">
                    <Columns>
                        <asp:BoundColumn DataField="TipoFile" HeaderText="Tipo file">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdBando" HeaderText="Id bando">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Id progetto">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="NumeroRiga" HeaderText="Numero riga">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CampoTracciato" HeaderText="Campo tracciato">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CodiceGruppo" HeaderText="Codice gruppo">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CodiceErrore" HeaderText="Codice errore">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DescrizioneErrore" HeaderText="Descrizione errore">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>

    <div id="divGestioneAvanzate" class="row bd-form" runat="server">
        <h3 class="pb-5">Invio singole domande
        </h3>

        <div class="col-sm-12">
            <p>Selezionare la programmazione:</p>
            <asp:RadioButtonList RepeatDirection="Vertical" ID="rblProgrammazione" runat="server">
                <asp:ListItem Selected="True" Text="POR FESR 2014 - 2020" Value="FESR20142020" />
                <asp:ListItem Text="ITI Aree Interne - Legge di Stabilità 2014-2020" Value="ITIAILS20142020" />
                <asp:ListItem Text="Psc" Value="PSCMARCHE" />
            </asp:RadioButtonList>
        </div>
        <p class="pb-2">Gli id delle domande vanno <b>separati da virgole</b> (esempio: 1,2,3,...)</p>
        <div class="col-sm-12 form-group">
            <Siar:TextBox Label="Id delle domande di aiuto da inviare:" ID="txtIdProgetti" runat="server"></Siar:TextBox>
        </div>
        <div class="col-sm-12">
            <p>Tipi tracciato da inviare:</p>
            <asp:RadioButtonList RepeatDirection="Vertical" ID="rblTipiTracciati" runat="server">
                <asp:ListItem Selected="True" Text="Tutti" Value="0" />
                <asp:ListItem Text="Scegli i tracciati" Value="1" />
            </asp:RadioButtonList>
        </div>

        <div id="divSceltaTracciati" class="row" runat="server" style="display: none;">
            <div class="col-sm-12">
                <asp:CheckBoxList ID="cblTracciatiInvio" runat="server">
                    <asp:ListItem Value="PA00">PA00</asp:ListItem>
                    <asp:ListItem Value="PA01">PA01</asp:ListItem>
                    <asp:ListItem Value="AP00">AP00</asp:ListItem>
                    <asp:ListItem Value="AP01">AP01</asp:ListItem>
                    <asp:ListItem Value="AP02">AP02</asp:ListItem>
                    <asp:ListItem Value="AP03">AP03</asp:ListItem>
                    <asp:ListItem Value="AP04">AP04</asp:ListItem>
                    <asp:ListItem Value="AP05">AP05</asp:ListItem>
                    <asp:ListItem Value="AP06">AP06</asp:ListItem>
                    <asp:ListItem Value="FN00">FN00</asp:ListItem>
                    <asp:ListItem Value="FN01">FN01</asp:ListItem>
                    <asp:ListItem Value="FN02">FN02</asp:ListItem>
                    <asp:ListItem Value="FN03">FN03</asp:ListItem>
                    <asp:ListItem Value="FN04">FN04</asp:ListItem>
                    <asp:ListItem Value="FN05">FN05</asp:ListItem>
                    <asp:ListItem Value="FN06">FN06</asp:ListItem>
                    <asp:ListItem Value="FN07">FN07</asp:ListItem>
                    <asp:ListItem Value="FN08">FN08</asp:ListItem>
                    <asp:ListItem Value="FN09">FN09</asp:ListItem>
                    <asp:ListItem Value="IN00">IN00</asp:ListItem>
                    <asp:ListItem Value="IN01">IN01</asp:ListItem>
                    <asp:ListItem Value="PR00">PR00</asp:ListItem>
                    <asp:ListItem Value="PR01">PR01</asp:ListItem>
                    <asp:ListItem Value="SC00">SC00</asp:ListItem>
                </asp:CheckBoxList>
            </div>
        </div>

        <div class="col-sm-12">
            <Siar:Button ID="btnInviaDatiSingoli" runat="server" OnClick="btnInviaDatiSingoli_Click" Text="Invia i dati del monitoraggio all'IGRUE" OnClientClick="return confirm('Inviare i dati di monitoraggio al Sistema Nazionale?')" />
        </div>
        <div class="col-sm-12">
            <asp:Label runat="server" ID="lblErroriInvioSingolo"></asp:Label>
        </div>

        <div id="divEliminazioneSingoli" class="row" runat="server">
            <h3 class="pb-3 mt-3">Eliminazione singole domande
            </h3>
            <div class="col-sm-12">
                Selezionare la programmazione:
                    <asp:RadioButtonList RepeatDirection="Vertical" ID="rblProgrammazioneEliminazione" runat="server">
                        <asp:ListItem Selected="True" Text="POR FESR 2014 - 2020" Value="FESR20142020" />
                        <asp:ListItem Text="ITI Aree Interne - Legge di Stabilità 2014-2020" Value="ITIAILS20142020" />
                        <asp:ListItem Text="Psc" Value="PSCMARCHE" />
                    </asp:RadioButtonList>
            </div>

            <div class="col-sm-12 form-group mt-3">

                <Siar:TextBox Label="Id invio originale:" ID="txtIdInvioEliminazione" runat="server"></Siar:TextBox>

            </div>

            <div class="col-sm-12">
                <p>Tipi tracciato:</p>
                <asp:RadioButtonList RepeatDirection="Vertical" ID="rblTipiTracciatiEliminazione" runat="server">
                    <asp:ListItem Selected="True" Text="Tutti" Value="0" />
                    <asp:ListItem Text="Scegli i tracciati" Value="1" />
                </asp:RadioButtonList>
            </div>
            <div id="divSceltaTracciatiEliminazione" class="row" runat="server" style="display: none;">
                <div class="col-sm-12">
                    <asp:CheckBoxList ID="cblTracciatiEliminazione" runat="server">
                        <asp:ListItem Value="PA00">PA00</asp:ListItem>
                        <asp:ListItem Value="PA01">PA01</asp:ListItem>
                        <asp:ListItem Value="AP00">AP00</asp:ListItem>
                        <asp:ListItem Value="AP01">AP01</asp:ListItem>
                        <asp:ListItem Value="AP02">AP02</asp:ListItem>
                        <asp:ListItem Value="AP03">AP03</asp:ListItem>
                        <asp:ListItem Value="AP04">AP04</asp:ListItem>
                        <asp:ListItem Value="AP05">AP05</asp:ListItem>
                        <asp:ListItem Value="AP06">AP06</asp:ListItem>
                        <asp:ListItem Value="FN00">FN00</asp:ListItem>
                        <asp:ListItem Value="FN01">FN01</asp:ListItem>
                        <asp:ListItem Value="FN02">FN02</asp:ListItem>
                        <asp:ListItem Value="FN03">FN03</asp:ListItem>
                        <asp:ListItem Value="FN04">FN04</asp:ListItem>
                        <asp:ListItem Value="FN05">FN05</asp:ListItem>
                        <asp:ListItem Value="FN06">FN06</asp:ListItem>
                        <asp:ListItem Value="FN07">FN07</asp:ListItem>
                        <asp:ListItem Value="FN08">FN08</asp:ListItem>
                        <asp:ListItem Value="FN09">FN09</asp:ListItem>
                        <asp:ListItem Value="IN00">IN00</asp:ListItem>
                        <asp:ListItem Value="IN01">IN01</asp:ListItem>
                        <asp:ListItem Value="PR00">PR00</asp:ListItem>
                        <asp:ListItem Value="PR01">PR01</asp:ListItem>
                        <asp:ListItem Value="SC00">SC00</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </div>

            <div class="col-sm-12 mt-5">
                <p>Modalità di eliminazione:</p>
                <asp:RadioButtonList RepeatDirection="Vertical" ID="rblTipoEliminazione" runat="server">
                    <asp:ListItem Selected="True" Text="Tramite file cancellazione" Value="0" />
                    <asp:ListItem Text="Tramite Id domande di aiuto" Value="1" />
                    <asp:ListItem Text="Tramite filtro SQL" Value="2" />
                </asp:RadioButtonList>
            </div>

            <div id="divEliminazioneIdProgetti" class="row" runat="server" style="display: none;">

                <p>Gli id delle domande e i numeri delle righe vanno <b>separati da virgole</b> (esempio: 1,2,3,...)</p>

                <div class="col-sm-12 form-group mt-3">
                    <Siar:TextBox Label="Id domande di aiuto da eliminare:" ID="txtIdProgettiEliminazione" runat="server"></Siar:TextBox>
                </div>

                <div class="col-sm-12 form-group">
                    <Siar:TextBox Label="Numeri righe da eliminare:" ID="txtNumRigheEliminazione" runat="server"></Siar:TextBox>

                </div>
            </div>

            <div id="divEliminazioneFiltroSQL" class="row" runat="server" style="display: none;">
                <div class="col-sm-12 form-group mt-5">
                    <Siar:TextArea Label="Filtro SQL per eliminazione:" ID="txtFiltroSQLEliminazione" runat="server" Rows="4" ExpandableRows="2"
                        MaxLength="8000"></Siar:TextArea>
                </div>
            </div>

            <div class="col-sm-12">
                <Siar:Button ID="btnInviaFileCancellazione" runat="server" OnClick="btnInviaFileCancellazione_Click" Text="Invia file cancellazione" OnClientClick="return confirm('Inviare i dati di cancellazione al Sistema Nazionale?')" />
            </div>
            <div class="col-sm-12">
                <asp:Label runat="server" ID="lblErroriEliminazione"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
