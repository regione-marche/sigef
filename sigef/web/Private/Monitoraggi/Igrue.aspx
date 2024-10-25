<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="Igrue.aspx.cs" Inherits="web.Private.Monitoraggi.Igrue" %>

<%@ Register Src="~/CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>

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

        function selezionaInvioPoc(idInvio) {
            $('[id$=hdnIdInvioPoc]').val($('[id$=hdnIdInvioPoc]').val() == idInvio ? '' : idInvio);
            if ($('[id$=hdnIdInvioPoc]').val() == '') $('[id$=hdnIdLogErroriPoc]').val('');
            $('[id$=btnPost]').click();
        }

        function selezionaFileErroriPoc(idLogErrori) {
            $('[id$=hdnIdLogErroriPoc]').val($('[id$=hdnIdLogErroriPoc]').val() == idLogErrori ? '' : idLogErrori);
            $('[id$=btnPost]').click();
        }

        function estraiInXlsPoc() {
            var id_invio = $('[id$=hdnIdInvioPoc]').val();
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
	        /*margin:0px 10px 20px 10px;*/
	        overflow:hidden;
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
        <asp:HiddenField ID="hdnIdInvioPoc" runat="server" />
        <asp:HiddenField ID="hdnIdLogErroriPoc" runat="server" />
        <asp:HiddenField ID="hdnDownloadZip" runat="server" />

        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" />
    </div>
    
    <div class="dBox" runat="server">
        <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="POR FESR 2014 - 2020|ITI Aree Interne - Legge di Stabilità 2014-2020|PSC|POC|Gestione avanzata" Titolo="Monitoraggio IGRUE" />
        <div >
            <div id="divFesr" runat="server" style="width:95%">
                <div class="mrw-table">
                    <div class="mrw-tr">
                        <div class="mrw-width-50">
                            <input type="hidden" id="txtFiles" runat="server" value="PA00,PA01,AP00,AP01,AP02,AP03,AP04,AP05,AP06,FN00,FN01,FN02,FN03,FN04,FN05,FN06,FN07,FN09,IN00,IN01,PR00,PR01,SC00" />
                            <Siar:Button ID="btnInviaDatiMonitoraggioFesr" runat="server" OnClick="btnInviaDatiMonitoraggioFesr_Click" Text="Invia i dati del monitoraggio all'IGRUE" OnClientClick="return confirm('Inviare i dati di monitoraggio al Sistema Nazionale?')" />
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div>
                            <asp:Label runat="server" ID="lblErroriInvioFesr"></asp:Label>
                        </div>
                    </div>
                </div>
        
                <div style="padding:10px">
                    <Siar:DataGrid ID="dgIgrueInviiFesr" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%">
                        <Columns>
                            <Siar:ColonnaLink DataField="IdInvio" HeaderText="Id invio" IsJavascript="true"
                                LinkFields="IdInvio" LinkFormat="selezionaInvioFesr({0});">
                                <ItemStyle HorizontalAlign="Center"/>
                            </Siar:ColonnaLink>
                            <asp:BoundColumn DataField="IdTicket" HeaderText="Id ticket">
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DataInvio" HeaderText="Data invio">
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TimestampEsito" HeaderText="Data esito invio">
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DataRichiesta" HeaderText="Data richiesta trasmissione">
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:BoundColumn>
                            <%--<asp:BoundColumn DataField="DettaglioEsitoLog" HeaderText="Dettaglio esito trasmissione">
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:BoundColumn>--%>
                            <asp:BoundColumn DataField="TimestampEsito" HeaderText="Data esito trasmissione">
                                <ItemStyle HorizontalAlign="Center"/>
                            </asp:BoundColumn>
                            <Siar:CheckColumn DataField="IdIgrueLogErrori" Name="ErroriPresenti" HeaderText="Errori presenti" ReadOnly="true">
                                <ItemStyle HorizontalAlign="Center"/>
                            </Siar:CheckColumn>
                        </Columns>
                    </Siar:DataGrid>
                    <br />
                    <br />

                    <div id="divDettaglioFesr" visible="false" runat="server">
                        <div class="paragrafo">
                            Dati esito invio
                        </div>

                        <div class="mrw-table">
                            <div class="mrw-tr">
                                <div class="mrw-width-15">
                                    <Siar:Button ID="btnRichiediValidazioneFesr" runat="server" OnClick="btnRichiediValidazioneFesr_Click" Text="Verifica esito trasmissione" />
                                </div>
                                <div class="mrw-width-15">
                                    <Siar:Button ID="btnDownloadFileInvioFesr" runat="server" OnClick="btnDownloadFileInvioFesr_Click" Text="Download file inviato" />
                                </div>
                                <div class="mrw-width-15"></div>
                                <div class="mrw-width-55"></div>
                            </div>
                        </div>

                        <div style="padding: 10px">
                            <Siar:DataGrid ID="dgInvioLogFesr" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%">
                                <Columns>
                                    <Siar:ColonnaLink DataField="IdIgrueLogErrori" HeaderText="Id esito" IsJavascript="true"
                                        LinkFields="IdIgrueLogErrori" LinkFormat="selezionaFileErroriFesr({0});">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </Siar:ColonnaLink>
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
                            </Siar:DataGrid>
                        </div>
                        <br />
                        <br />
                    </div>

                    <div id="divDettaglioErroriFesr" visible="false" runat="server">
                        <div class="paragrafo">
                            Errori dell'invio
                        </div>

                        <div class="mrw-table">
                            <div class="mrw-tr">
                                <div class="mrw-width-20">
                                    Id invio:
                                    <Siar:TextBox ID="txtIdInvioErroreFesr" runat="server" Enabled="false" />
                                </div>
                                <div class="mrw-width-20">
                                    Id ticket:
                                    <Siar:TextBox ID="txtIdTicketErroreFesr" runat="server" Enabled="false" />
                                </div>
                                <div class="mrw-width-20">
                                    <input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return estraiInXlsFesr();" />
                                </div>
                                <div class="mrw-width-40">
                                </div>
                            </div>
                        </div>

                        <div style="padding: 10px">
                            <Siar:DataGrid ID="dgLogErroriFesr" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%">
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
                            </Siar:DataGrid>
                        </div>
                    </div>
                </div>

            </div>

            <div id="divLeggeStabilita" runat="server" style="width: 95%">
                <div class="mrw-table">
                    <div class="mrw-tr">
                        <div class="mrw-width-50">
                            <input type="hidden" id="txtFilesLeggeStabilita" runat="server" value="PA00,PA01,AP00,AP01,AP02,AP03,AP04,AP05,AP06,FN00,FN01,FN02,FN03,FN04,FN05,FN06,FN07,IN00,IN01,PR00,PR01,SC00" />
                            <Siar:Button ID="btnInviaDatiMonitoraggioLeggeStabilita" runat="server" OnClick="btnInviaDatiMonitoraggioLeggeStabilita_Click" Text="Invia i dati del monitoraggio all'IGRUE" OnClientClick="return confirm('Inviare i dati di monitoraggio al Sistema Nazionale?')" />
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div>
                            <asp:Label runat="server" ID="lblErroriInvioLeggeStabilita"></asp:Label>
                        </div>
                    </div>
                </div>

                <div style="padding: 10px">
                    <Siar:DataGrid ID="dgIgrueInviiLeggeStabilita" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%">
                        <Columns>
                            <Siar:ColonnaLink DataField="IdInvio" HeaderText="Id invio" IsJavascript="true"
                                LinkFields="IdInvio" LinkFormat="selezionaInvioLeggeStabilita({0});">
                                <ItemStyle HorizontalAlign="Center" />
                            </Siar:ColonnaLink>
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
                            <Siar:CheckColumn DataField="IdIgrueLogErrori" Name="ErroriPresenti" HeaderText="Errori presenti" ReadOnly="true">
                                <ItemStyle HorizontalAlign="Center" />
                            </Siar:CheckColumn>
                        </Columns>
                    </Siar:DataGrid>
                    <br />
                    <br />

                    <div id="divDettaglioLeggeStabilita" visible="false" runat="server">
                        <div class="paragrafo">
                            Dati esito invio
                        </div>

                        <div class="mrw-table">
                            <div class="mrw-tr">
                                <div class="mrw-width-15">
                                    <Siar:Button ID="btnRichiediValidazioneLeggeStabilita" runat="server" OnClick="btnRichiediValidazioneLeggeStabilita_Click" Text="Verifica esito trasmissione" />
                                </div>
                                <div class="mrw-width-15">
                                    <Siar:Button ID="btnDownloadFileInvioLeggeStabilita" runat="server" OnClick="btnDownloadFileInvioLeggeStabilita_Click" Text="Download file inviato" />
                                </div>
                                <div class="mrw-width-15"></div>
                                <div class="mrw-width-55"></div>
                            </div>
                        </div>

                        <div style="padding: 10px">
                            <Siar:DataGrid ID="dgInvioLogLeggeStabilita" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%">
                                <Columns>
                                    <Siar:ColonnaLink DataField="IdIgrueLogErrori" HeaderText="Id esito" IsJavascript="true"
                                        LinkFields="IdIgrueLogErrori" LinkFormat="selezionaFileErroriLeggeStabilita({0});">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </Siar:ColonnaLink>
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
                            </Siar:DataGrid>
                        </div>
                        <br />
                        <br />
                    </div>

                    <div id="divDettaglioErroriLeggeStabilita" visible="false" runat="server">
                        <div class="paragrafo">
                            Errori dell'invio
                        </div>

                        <div class="mrw-table">
                            <div class="mrw-tr">
                                <div class="mrw-width-20">
                                    Id invio:
                                    <Siar:TextBox ID="txtIdInvioErroreLeggeStabilita" runat="server" Enabled="false" />
                                </div>
                                <div class="mrw-width-20">
                                    Id ticket:
                                    <Siar:TextBox ID="txtIdTicketErroreLeggeStabilita" runat="server" Enabled="false" />
                                </div>
                                <div class="mrw-width-20">
                                    <input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return estraiInXlsLeggeStabilita();" />
                                </div>
                                <div class="mrw-width-40">
                                </div>
                            </div>
                        </div>

                        <div style="padding: 10px">
                            <Siar:DataGrid ID="dgLogErroriLeggeStabilita" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%">
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
                            </Siar:DataGrid>
                        </div>
                    </div>
                </div>
            </div>

            <div id="divPsc" runat="server" style="width: 95%">
                <div class="mrw-table">
                    <div class="mrw-tr">
                        <div class="mrw-width-50">
                            <input type="hidden" id="txtFilesPsc" runat="server" value="PA00,PA01,AP00,AP01,AP02,AP03,AP04,AP05,AP06,FN00,FN01,FN02,FN03,FN04,FN05,FN06,FN07,IN00,IN01,PR00,PR01,SC00" />
                            <Siar:Button ID="btnInviaDatiMonitoraggioPsc" runat="server" OnClick="btnInviaDatiMonitoraggioPsc_Click" Text="Invia i dati del monitoraggio all'IGRUE" OnClientClick="return confirm('Inviare i dati di monitoraggio al Sistema Nazionale?')" />
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div>
                            <asp:Label runat="server" ID="lblErroriInvioPsc"></asp:Label>
                        </div>
                    </div>
                </div>

                <div style="padding: 10px">
                    <Siar:DataGrid ID="dgIgrueInviiPsc" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%">
                        <Columns>
                            <Siar:ColonnaLink DataField="IdInvio" HeaderText="Id invio" IsJavascript="true"
                                LinkFields="IdInvio" LinkFormat="selezionaInvioPsc({0});">
                                <ItemStyle HorizontalAlign="Center" />
                            </Siar:ColonnaLink>
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
                            <Siar:CheckColumn DataField="IdIgrueLogErrori" Name="ErroriPresenti" HeaderText="Errori presenti" ReadOnly="true">
                                <ItemStyle HorizontalAlign="Center" />
                            </Siar:CheckColumn>
                        </Columns>
                    </Siar:DataGrid>
                    <br />
                    <br />

                    <div id="divDettaglioPsc" visible="false" runat="server">
                        <div class="paragrafo">
                            Dati esito invio
                        </div>

                        <div class="mrw-table">
                            <div class="mrw-tr">
                                <div class="mrw-width-15">
                                    <Siar:Button ID="btnRichiediValidazionePsc" runat="server" OnClick="btnRichiediValidazionePsc_Click" Text="Verifica esito trasmissione" />
                                </div>
                                <div class="mrw-width-15">
                                    <Siar:Button ID="btnDownloadFileInvioLPsc" runat="server" OnClick="btnDownloadFileInvioPsc_Click" Text="Download file inviato" />
                                </div>
                                <div class="mrw-width-15"></div>
                                <div class="mrw-width-55"></div>
                            </div>
                        </div>

                        <div style="padding: 10px">
                            <Siar:DataGrid ID="dgInvioLogPsc" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%">
                                <Columns>
                                    <Siar:ColonnaLink DataField="IdIgrueLogErrori" HeaderText="Id esito" IsJavascript="true"
                                        LinkFields="IdIgrueLogErrori" LinkFormat="selezionaFileErroriPsc({0});">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </Siar:ColonnaLink>
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
                            </Siar:DataGrid>
                        </div>
                        <br />
                        <br />
                    </div>

                    <div id="divDettaglioErroriPsc" visible="false" runat="server">
                        <div class="paragrafo">
                            Errori dell'invio
                        </div>

                        <div class="mrw-table">
                            <div class="mrw-tr">
                                <div class="mrw-width-20">
                                    Id invio:
                                    <Siar:TextBox ID="txtIdInvioErrorePsc" runat="server" Enabled="false" />
                                </div>
                                <div class="mrw-width-20">
                                    Id ticket:
                                    <Siar:TextBox ID="txtIdTicketErrorePsc" runat="server" Enabled="false" />
                                </div>
                                <div class="mrw-width-20">
                                    <input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return estraiInXlsPsc();" />
                                </div>
                                <div class="mrw-width-40">
                                </div>
                            </div>
                        </div>

                        <div style="padding: 10px">
                            <Siar:DataGrid ID="dgLogErroriPsc" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%">
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
                            </Siar:DataGrid>
                        </div>
                    </div>
                </div>
            </div>


            <div id="divPoc" runat="server" style="width: 95%">
                <div class="mrw-table">
                    <div class="mrw-tr">
                        <div class="mrw-width-50">
                            <input type="hidden" id="txtFilesPoc" runat="server" value="PA00,PA01,AP00,AP01,AP02,AP03,AP04,AP05,AP06,FN00,FN01,FN02,FN03,FN04,FN05,FN06,FN07,IN00,IN01,PR00,PR01,SC00" />
                            <Siar:Button ID="btnInviaDatiMonitoraggioPoc" runat="server" OnClick="btnInviaDatiMonitoraggioPoc_Click" Text="Invia i dati del monitoraggio all'IGRUE" OnClientClick="return confirm('Inviare i dati di monitoraggio al Sistema Nazionale?')" />
                        </div>
                    </div>
                    <div class="mrw-tr">
                        <div>
                            <asp:Label runat="server" ID="lblErroriInvioPoc"></asp:Label>
                        </div>
                    </div>
                </div>

                <div style="padding: 10px">
                    <Siar:DataGrid ID="dgIgrueInviiPoc" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%">
                        <Columns>
                            <Siar:ColonnaLink DataField="IdInvio" HeaderText="Id invio" IsJavascript="true"
                                LinkFields="IdInvio" LinkFormat="selezionaInvioPoc({0});">
                                <ItemStyle HorizontalAlign="Center" />
                            </Siar:ColonnaLink>
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
                            <Siar:CheckColumn DataField="IdIgrueLogErrori" Name="ErroriPresenti" HeaderText="Errori presenti" ReadOnly="true">
                                <ItemStyle HorizontalAlign="Center" />
                            </Siar:CheckColumn>
                        </Columns>
                    </Siar:DataGrid>
                    <br />
                    <br />

                    <div id="divDettaglioPoc" visible="false" runat="server">
                        <div class="paragrafo">
                            Dati esito invio
                        </div>

                        <div class="mrw-table">
                        <div class="mrw-tr">
                            <div class="mrw-width-15">
                                <Siar:Button ID="btnRichiediValidazionePoc" runat="server" OnClick="btnRichiediValidazionePoc_Click" Text="Verifica esito trasmissione" />
                            </div>
                            <div class="mrw-width-15">
                                <Siar:Button ID="btnDownloadFileInvioPoc" runat="server" OnClick="btnDownloadFileInvioPoc_Click" Text="Download file inviato" />
                            </div>
                            <div class="mrw-width-15"></div>
                            <div class="mrw-width-55"></div>
                        </div>
                    </div>

                        <div style="padding: 10px">
                            <Siar:DataGrid ID="dgInvioLogPoc" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%">
                                <Columns>
                                    <Siar:ColonnaLink DataField="IdIgrueLogErrori" HeaderText="Id esito" IsJavascript="true"
                                        LinkFields="IdIgrueLogErrori" LinkFormat="selezionaFileErroriPoc({0});">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </Siar:ColonnaLink>
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
                            </Siar:DataGrid>
                        </div>
                        <br />
                        <br />
                    </div>

                    <div id="divDettaglioErroriPoc" visible="false" runat="server">
                        <div class="paragrafo">
                            Errori dell'invio
                        </div>

                        <div class="mrw-table">
                            <div class="mrw-tr">
                                <div class="mrw-width-20">
                                    Id invio:
                                    <Siar:TextBox ID="txtIdInvioErrorePoc" runat="server" Enabled="false" />
                                </div>
                                <div class="mrw-width-20">
                                    Id ticket:
                                    <Siar:TextBox ID="txtIdTicketErrorePoc" runat="server" Enabled="false" />
                                </div>
                                <div class="mrw-width-20">
                                    <input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return estraiInXlsPoc();" />
                                </div>
                                <div class="mrw-width-40">
                                </div>
                            </div>
                        </div>

                        <div style="padding: 10px">
                            <Siar:DataGrid ID="dgLogErroriPoc" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%">
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
                            </Siar:DataGrid>
                        </div>
                    </div>
                </div>
            </div>


            <div id="divGestioneAvanzate" runat="server" class="dContenuto">
                <div class="paragrafo">
                    Invio singole domande
                </div>
                <br />

                <div class="first_elem_block">
                    Selezionare la programmazione:
                    <asp:RadioButtonList RepeatDirection="Vertical" ID="rblProgrammazione" runat="server">
                        <asp:ListItem Selected="True" Text="POR FESR 2014 - 2020" Value="FESR20142020" />
                        <asp:ListItem Text="ITI Aree Interne - Legge di Stabilità 2014-2020" Value="ITIAILS20142020" />
                        <asp:ListItem Text="PSC" Value="PSCMARCHE" />
                        <asp:ListItem Text="POC" Value="POCMARCHE" />
                    </asp:RadioButtonList>
                </div>
                <br />
                <br />

                <p>Gli id delle domande vanno <b>separati da virgole</b> (esempio: 1,2,3,...)</p><br />

                <div class="first_elem_block">
                    <div class="label">Id delle domande di aiuto da inviare:</div>
                    <div class="value">
                        <Siar:TextBox ID="txtIdProgetti" runat="server" Width="650px"></Siar:TextBox>
                    </div>
                </div>
                <br />
                <br /> 

                <div class="first_elem_block">
                    Tipi tracciato da inviare:
                    <asp:RadioButtonList RepeatDirection="Vertical" ID="rblTipiTracciati" runat="server">
                        <asp:ListItem Selected="True" Text="Tutti" Value="0" />
                        <asp:ListItem Text="Scegli i tracciati" Value="1" />
                    </asp:RadioButtonList>
                </div>
                <br />
                <br />

                <div id="divSceltaTracciati" runat="server" style="display: none;">
                    <div class="first_elem_block">
                        <div class="value">
                            <asp:CheckBoxList ID="cblTracciatiInvio" runat="server" >
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
                    <br />
                </div>

                <br />
                <br />

                <div class="first_elem_block">
                    <Siar:Button ID="btnInviaDatiSingoli" runat="server" OnClick="btnInviaDatiSingoli_Click" Text="Invia i dati del monitoraggio all'IGRUE" OnClientClick="return confirm('Inviare i dati di monitoraggio al Sistema Nazionale?')" />
                </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <asp:Label runat="server" ID="lblErroriInvioSingolo"></asp:Label>
                </div>
                <br />
                <br />

                <div id="divEliminazioneSingoli" runat="server">
                    <div class="paragrafo">
                        Eliminazione singole domande
                    </div>
                    <br />

                    <div class="first_elem_block">
                        Selezionare la programmazione:
                    <asp:RadioButtonList RepeatDirection="Vertical" ID="rblProgrammazioneEliminazione" runat="server">
                        <asp:ListItem Selected="True" Text="POR FESR 2014 - 2020" Value="FESR20142020" />
                        <asp:ListItem Text="ITI Aree Interne - Legge di Stabilità 2014-2020" Value="ITIAILS20142020" />
                        <asp:ListItem Text="Psc" Value="PSCMARCHE" />
                        <asp:ListItem Text="POC" Value="POCMARCHE" />
                    </asp:RadioButtonList>
                    </div>
                    <br />
                    <br />

                    <div class="first_elem_block">
                        <div class="label">Id invio originale:</div>
                        <div class="value">
                            <Siar:TextBox ID="txtIdInvioEliminazione" runat="server" Width="100px"></Siar:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />

                    <div class="first_elem_block">
                        Tipi tracciato:
                    <asp:RadioButtonList RepeatDirection="Vertical" ID="rblTipiTracciatiEliminazione" runat="server">
                        <asp:ListItem Selected="True" Text="Tutti" Value="0" />
                        <asp:ListItem Text="Scegli i tracciati" Value="1" />
                    </asp:RadioButtonList>
                    </div>
                    <br />
                    <br />

                    <div id="divSceltaTracciatiEliminazione" runat="server" style="display: none;">
                        <div class="first_elem_block">
                            <div class="value">
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
                        <br />
                        <br />
                    </div>

                    <div class="first_elem_block">
                        Modalità di eliminazione:
                        <asp:RadioButtonList RepeatDirection="Vertical" ID="rblTipoEliminazione" runat="server">
                            <asp:ListItem Selected="True" Text="Tramite file cancellazione" Value="0" />
                            <asp:ListItem Text="Tramite Id domande di aiuto" Value="1" />
                            <asp:ListItem Text="Tramite filtro SQL" Value="2" />
                        </asp:RadioButtonList>
                    </div>
                    <br />
                    <br />

                    <div id="divEliminazioneIdProgetti" runat="server" style="display: none;">
                        <div class="first_elem_block">
                            <p>Gli id delle domande e i numeri delle righe vanno <b>separati da virgole</b> (esempio: 1,2,3,...)</p>
                            <br />
                            <div class="label">Id domande di aiuto da eliminare:</div>
                            <div class="value">
                                <Siar:TextBox ID="txtIdProgettiEliminazione" runat="server" Width="650px"></Siar:TextBox>
                            </div>
                        </div>
                        <br />
                        <br />


                        <div class="first_elem_block">
                            <div class="label">Numeri righe da eliminare:</div>
                            <div class="value">
                                <Siar:TextBox ID="txtNumRigheEliminazione" runat="server" Width="650px"></Siar:TextBox>
                            </div>
                        </div>
                        <br />
                    </div>

                    <div id="divEliminazioneFiltroSQL" runat="server" style="display: none;">
                        <div class="first_elem_block">
                            <div class="label">Filtro SQL per eliminazione:</div>
                            <div class="value">
                                <Siar:TextArea ID="txtFiltroSQLEliminazione" runat="server" Width="650px" Rows="4" ExpandableRows="2"
                                    MaxLength="8000"></Siar:TextArea>
                            </div>
                        </div>
                        <br />
                    </div>

                    <div class="first_elem_block">
                        <Siar:Button ID="btnInviaFileCancellazione" runat="server" OnClick="btnInviaFileCancellazione_Click" Text="Invia file cancellazione" OnClientClick="return confirm('Inviare i dati di cancellazione al Sistema Nazionale?')" />
                    </div>
                    <br />
                    <br />

                    <div class="first_elem_block">
                        <asp:Label runat="server" ID="lblErroriEliminazione"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>