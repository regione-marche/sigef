<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rna.aspx.cs" Inherits="web.Private.Psr.Bandi.Rna" MasterPageFile="~/SigefAgidPrivate.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">

        $('html').bind('keypress', function (e) {
            if (e.keyCode == 13) {
                return false;
            }
        });

        function EstraiXLS(idBando) {
            var parametri = "ID_BANDO=" + idBando;
            SNCVisualizzaReport('rptRnaCovidDettaglio', 2, parametri);
        }


        function filtraBandi() {
            var idBando = $('[id$=txtIdBando]').val();
            var lstEntiBando = $('[id$=lstEntiBando]')[0];
            var txtEntiBando = lstEntiBando.options[lstEntiBando.selectedIndex].text.toUpperCase();
            var apertura = $('[id$=txtApertura]').val();
            var scadenza = $('[id$=txtScadenza]').val();
            var dgIdBando;
            var dgEntiBando;
            var dgApertura;
            var dgScadenza;
            var dgGrid = $('[id$=dgBandi]')[0];
        }

        function fnRNAScaricaVisura(idFile) {
            RNAScaricaVisura(idFile);
        }

        function selezionaBando(idBando) {

            if ($('[id$=hdnBandoSelezionato]').val() == null || $('[id$=hdnBandoSelezionato]').val() == "") {
                $('[id$=hdnBandoSelezionato]').val(idBando);
            }
            else {
                $('[id$=hdnBandoSelezionato]').val("");
                $('[id$=hdnProgettoSelezionato]').val("");
            }
            $('[id$=btnFiltraBandi]').click();
        }

        function selezionaProgetto(idProgetto) {
            var tabella = $('[id$=tabella' + idProgetto + ']')[0];
            var immagine = $('#img' + idProgetto)[0];

            if (tabella.style.display == '') {
                tabella.style.display = 'none';
                var progetti = $('[id$=hdnProgettiAperti]').val().split("|");
                $('[id$=hdnProgettiAperti]').val("");
                for (i = 0; i < progetti.length; i++) {
                    if (progetti[i] != idProgetto && progetti[i] != "")
                        $('[id$=hdnProgettiAperti]').val($('[id$=hdnProgettiAperti]').val() + '|' + progetti[i]);
                }
                immagine.style.transform = 'rotate(180deg)';
            }
            else {
                tabella.style.display = '';
                $('[id$=hdnProgettiAperti]').val($('[id$=hdnProgettiAperti]').val() + '|' + idProgetto);
                immagine.style.transform = '';
            }
        }

        function inviaRichiestaAiuto(idProgetto, idImpresa) {
            $('[id$=hdnImpresaVisura]').val(idImpresa);
            $('[id$=hdnProgettoVisura]').val(idProgetto);
            __doPostBack('btnInviaRichiesta', 'btnInviaRichiesta');
        }

        var tableRow;
        function richiediVisura(idProgetto, idImpresa, obj) {
            tableRow = $(obj).closest('tr');
            $('[id$=hdnImpresaVisura]').val(idImpresa);
            $('[id$=hdnProgettoVisura]').val(idProgetto);
            $('[id$=hdnTipoRichiestaV]').val($('[id$=cmbTipoVisura_' + idProgetto + '_' + idImpresa + ']').val());
            $('[id$=btnRichiediVisura]').click();
        }

        function confermaReinvio() {
            var visuraPresente = false;
            var tipoRichiesta = tableRow.find("td:eq(2)").find("select").val();
            if (tipoRichiesta == "aiuti")
                if (tableRow.find("td:eq(4)").text() != "")
                    visuraPresente = true;
            if (tipoRichiesta == "deminimis")
                if (tableRow.find("td:eq(5)").text() != "")
                    visuraPresente = true;
            if (tipoRichiesta == "deggendorf")
                if (tableRow.find("td:eq(6)").text() != "")
                    visuraPresente = true;
            if (visuraPresente) {
                var r = confirm("Visura già presente, se si procede con la richiesta la visura sarà sovrascritta. Continuare?");
                if (r == true) {
                    return true;
                } else {
                    return false;
                }
            }
            else
                return true;
        }

        function confermaReinvioProgetto() {
            var r = confirm("Se sono già presenti delle visure per questo progetto saranno sovrascritte, continuare?");
            if (r == true) {
                return true;
            } else {
                return false;
            }
        }

        function scaricaVisura(idProgetto, idImpresa, tipoV) {
            //creaModaleCaricamento();
            $('[id$=hdnImpresaVisura]').val(idImpresa);
            $('[id$=hdnProgettoVisura]').val(idProgetto);
            $('[id$=hdnTipoRichiestaV]').val(tipoV);
            $('[id$=btnScaricaVisura]').click();
            //__doPostBack('btnScaricaVisura', 'btnScaricaVisura');
        }

        function inviaRichiesteProgetto(idProgetto) {
            $('[id$=hdnIdProgettoRichiesta]').val(idProgetto);
            __doPostBack('btnInviaRichiesteProgetto', 'btnInviaRichiesteProgetto');
        }

        function richiediVisureProgetto(idProgetto) {
            $('[id$=hdnIdProgettoRichiesta]').val(idProgetto);
            __doPostBack('btnRichiediVisureProgetto', 'btnRichiediVisureProgetto');
        }

        function annullaRichiesta(idRichiesta) {
            $('[id$=hdnIdRichiestaAnnulla]').val(idRichiesta);
            __doPostBack('btnAnnullaRichiesta', 'btnAnnullaRichiesta');
        }
        function eseguiAzioneProgetto(idProgetto) {

            var azione = $('[id$=cmbAzioneProgetto_' + idProgetto + ']').val();
            if (azione == "richiediVisure") {
                var r = confirm("Visura già presente, se si procede con la richiesta la visura sarà sovrascritta. Continuare?");
                if (r == true) {
                    creaModaleCaricamento();

                    $('[id$=hdnAzioneProgetto]').val($('[id$=cmbAzioneProgetto_' + idProgetto + ']').val());
                    $('[id$=hdnIdProgAzioneProgetto]').val(idProgetto);
                    __doPostBack('btnAzioneProgetto', 'btnAzioneProgetto');
                }
                else
                    return false;
            }
        }
        function eseguiAzioneMassiva() {
            $('[id$=hdnAzioneMassiva]').val($('[id$=cmbAzioneMassiva]').val());
        }

        function popolaCampiFiltro() {
            $('[id$=hdnFiltroStatoProgetto]').val($('[id$=cmbStatoRichiestaRNA]').val());
        }
    </script>


    <div style="display: none">
        <asp:HiddenField ID="hdnBandoSelezionato" runat="server" />
        <asp:HiddenField ID="hdnProgettoSelezionato" runat="server" />
        <asp:HiddenField ID="hdnProgettiAperti" runat="server" />
        <asp:HiddenField ID="hdnImpresaVisura" runat="server" />
        <asp:HiddenField ID="hdnProgettoVisura" runat="server" />
        <asp:HiddenField ID="hdnTipoRichiestaV" runat="server" />
        <asp:HiddenField ID="hdnIdProgettoRichiesta" runat="server" />
        <asp:HiddenField ID="hdnIdRichiestaAnnulla" runat="server" />
        <asp:HiddenField ID="hdnAzioneProgetto" runat="server" />
        <asp:HiddenField ID="hdnIdProgAzioneProgetto" runat="server" />
        <asp:HiddenField ID="hdnAzioneMassiva" runat="server" />
        <asp:HiddenField ID="hdnFiltroStatoProgetto" runat="server" />
        <asp:HiddenField ID="hdnTempoSleep" Value="4100" runat="server" />
        <asp:HiddenField ID="hdnMassimoMassivo" Value="5000" runat="server" />
        <asp:Button ID="btnRichiediVisura" runat="server" CssClass="hide" OnClientClick="if(!confermaReinvio()) return false;" OnClick="btnRichiediVisura_Click" />
        <asp:Button ID="btnScaricaVisura" runat="server" CssClass="hide" OnClick="btnScaricaVisura_Click" CausesValidation="true" />
    </div>

    <div style="text-align: center;">
        <div style="display: block; font-size: 2em; margin-top: 0.67em; margin-bottom: 0.67em; margin-left: 10px; margin-right: 0; font-weight: bold;">
            <asp:Label runat="server" ID="lblTitolo">
            Cruscotto RNA</asp:Label>
        </div>
        <div style="display: block; font-size: medium; margin-top: 0.67em; margin-bottom: 0.67em; margin-left: 10px; margin-right: 0;">
            <asp:Label runat="server" ID="lblSottotitolo"></asp:Label>
        </div>
    </div>

    <div class="row" id="divBandi" runat="server">
        <h2 class="pb-1">
            <asp:Label runat="server" ID="Label1">
            Cruscotto RNA</asp:Label></h2>
        <h3 class="pb-1">
            <asp:Label runat="server" ID="Label2"></asp:Label></h3>
        <h3 class="pb-1">Bandi
        </h3>
        <div class="row bd-form pt-5" id="divAccount">
            <div class="col-sm-2 form-group">
                <Siar:ComboBase Label="Selezionare l'ente:" ID="lstEntiRna" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnSelectedIndexChanged"></Siar:ComboBase>
            </div>
            <div class="col-sm-10">
                <Siar:Button ID="btnAggiornaPsw" OnClientClick="mostraPopupTemplate('divModificaPsw','divBKGMessaggio');return false;" runat="server" Text="Aggiorna Password Webservice" CausesValidation="false" />
            </div>
            <p>
                <asp:Label runat="server" Font-Size="Small">*La password per il web service RNA ha una validità di 6 mesi. In caso sia scaduta occorre aggiornarla nell'RNA e poi riportare qui nel SIGEF il cambiamento. </asp:Label>
            </p>
        </div>

        <div id="divFiltraBandi" class="row bd-form pt-5 mt-5" runat="server">
            <div class="col-sm-1 form-group">
                <Siar:TextBox  Label="Id Bando:" ID="txtIdBando" runat="server" />
            </div>
            <div id="divLstEntiBando" runat="server" class="col-sm-2">
                <Siar:ComboEntiBando Label="Ente emettitore:" ID="lstEntiBando" runat="server">
                </Siar:ComboEntiBando>
            </div>
            <div class="form-group col-sm-4">
                <Siar:ComboGroupZProgrammazione Label="Programmazione:" ID="lstProgrammazione" runat="server">
                </Siar:ComboGroupZProgrammazione>
            </div>
            <div class="col-sm-1 form-group">
                <Siar:DateTextBox Label="Data scadenza:" ID="txtScadenza" runat="server" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:ComboSql Label="Stato Procedurale:" ID="lstStatoBando" runat="server" CommandText="SELECT CODICE,DESCRIZIONE FROM BANDO_TIPO_STATO ORDER BY ORDINE"
                    DataTextField="DESCRIZIONE" DataValueField="CODICE">
                </Siar:ComboSql>
            </div>
            <div class="col-sm-2">
                <Siar:Button ID="btnFiltraBandi" OnClick="btnFiltra_Click" runat="server" Text="Filtra Bandi" />
            </div>
        </div>
        <div id="divMostraBandi" class="col-sm-12 mt-5">
            <asp:Label ID="lblTestoBando" runat="server" Text="*Sono visualizzati solamente i bandi configurati per l'invio RNA" Font-Size="Small"></asp:Label>
            <Siar:DataGridAgid ID="dgBandi" CssClass="table table-striped" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <Siar:ColonnaLink DataField="IdBando" HeaderText="ID" LinkFormat="selezionaBando({0});" IsJavascript="true" LinkFields="IdBando">
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </Siar:ColonnaLink>
                    <asp:BoundColumn DataField="Ente" HeaderText="Ente emettitore">
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DataApertura" HeaderText="Data apertura">
                        <ItemStyle Width="95px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataScadenza" HeaderText="Data scadenza">
                        <ItemStyle Width="95px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Importo" HeaderText="Importo €" DataFormatString="{0:N}">
                        <ItemStyle HorizontalAlign="Right" Width="80px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgrammazione" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CodStato" Visible="false"></asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
    <div class="row bd-form pt-5 mt-5" id="divDatiConcessione" runat="server" style="display: none;">
        <h3 class="pb-1">Dati Atto Concessione
        </h3>
        <p style="display: none;">
            Data Prevista Decreto di Concessione:
            <asp:Label ID="lblDataConcessione" runat="server"></asp:Label>
        </p>
        <div class="col-sm-2 form-group mt-5" style="display: none;">
            <Siar:DateTextBox Label="Modifica Data Prevista Decreto di Concessione:" ID="txtDataConcessione" runat="server" />
        </div>
        <div class="col-sm-2 text-start mt-5" style="display: none;">
            <Siar:Button ID="salvaDataConcessione" OnClick="btnSalvaDataConcessione_Click" runat="server" Text="Salva" />
        </div>
    </div>
    <div style="display: none" class="row bd-form pt-5 mt-5" runat="server" id="divDatiBandoGenerali">
        <p>
            <b>Dati decreto di concessione reali associato alla graduatoria</b>
        </p>
        <p>
            Numero Atto:
            <asp:Label ID="lblNumeroAtto" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;Data Atto:
            <asp:Label ID="lblDataAtto" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;Registro:
            <asp:Label ID="lblRegistroAtto" runat="server"></asp:Label>
        </p>
    </div>
    <div class="row bd-form pt-5 mt-5" id="divProgetti" runat="server" style="display: none;">
        <h3 class="pb-3">Progetti
        </h3>
        <div id="filtraRichieste" runat="server" class="row">
            <div class="col-sm-1 form-group">
                <Siar:TextBox  Label="Id Progetto:" ID="txtIdProgettoRNA" runat="server" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:TextBox  Label="Id Richiesta RNA:" ID="txtIdRichiestaRNA" runat="server" />
            </div>
            <div class="col-sm-2 form-group">
                <div class="select-wrapper">
                    <label for="<% =cmbStatoRichiestaRNA.ClientID %>">Stato Richiesta:</label>
                    <asp:DropDownList ID="cmbStatoRichiestaRNA" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-2 form-group">
                <Siar:DateTextBox Label="Data COR da:" ID="dataCorDa" runat="server" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:DateTextBox Label="Data COR a:" ID="dataCorA" runat="server" />
            </div>
            <div class="col-sm-2">
                <Siar:Button ID="btnFiltraProgetti" OnClientClick="popolaCampiFiltro();" OnClick="btnFiltraProgetti_Click" runat="server" Text="Filtra Progetti" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3 form-group">
                <div class="select-wrapper">
                    <label for="cmbAzioneMassiva">Azioni Massive:</label>
                    <asp:DropDownList ID="cmbAzioneMassiva" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-9 text-start">
                <Siar:Button OnClientClick="eseguiAzioneMassiva();" OnClick="btnInvioMassivo_Click" runat="server" Text=" Invio" />
            </div>
            <p>La richiesta massiva dei COR viene eseguita per le richieste in stato "Da inviare" o "Richiesta fallita". Tra ogni richiesta devono decorrere 4 secondi per limiti imposti dal servizio RNA, pertanto la procedura può richiedere diverso tempo.</p>
        </div>
        <div class="col-sm-12">
            <asp:Label ID="lblNrProgetti" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <Siar:DataGridAgid ID="dgProgetti" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
                <Columns>
                    <asp:BoundColumn>
                        <ItemStyle Width="70px" />
                    </asp:BoundColumn>
                    <Siar:ColonnaLink DataField="IdProgetto" HeaderText="Id Progetto" IsJavascript="true" LinkFormat="selezionaProgetto({0});" LinkFields="IdProgetto">
                        <ItemStyle Font-Size="Medium" />
                    </Siar:ColonnaLink>
                    <asp:BoundColumn DataField="IdProgetto" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="">
                        <ItemStyle Font-Size="Smaller" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn>                        
                    </asp:BoundColumn>
                    <Siar:JsButtonColumnAgid ButtonText="Invio" Arguments="IdProgetto" JsFunction="eseguiAzioneProgetto">                        
                    </Siar:JsButtonColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
    <div class="dBox" id="divProgettiContatoriCovid" runat="server" visible="false">
        <div class="separatore" style="padding-bottom: 3px;">
            Progetti
        </div>
        <br />
        <br />
        <div style="font-size: small; margin-left: 20px;">
            La richiesta massiva dei COR viene eseguita per le prime 20 richieste in stato "Da inviare" o "Richiesta fallita".<br />
            Tra ogni richiesta devono decorrere 4 secondi per limiti imposti dal servizio RNA, pertanto la procedura richiede circa 1 minuto e mezzo
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />

        <div style="width: 350px; display: inline-block; margin-bottom: 5px; margin-left: 20px;">
            <asp:Label ID="lblRichiedereCovid" runat="server" Text="Progetti da Richiedere: " Font-Size="Medium"></asp:Label>
            <asp:Label ID="lblNRichiedere" runat="server" Text="0" Font-Size="Medium"></asp:Label>
        </div>
        <div style="display: inline-block; margin-bottom: 5px;">
            <Siar:Button ID="btnRichiediCovid" runat="server" Text="Invia Richieste" OnClick="btnRichiediCovid_Click" />
        </div>
        <br />

        <div style="width: 350px; display: inline-block; margin-bottom: 5px; margin-left: 20px;">
            <asp:Label ID="lblVerificareCovid" runat="server" Text="Progetti da Verificare: " Font-Size="Medium"></asp:Label>
            <asp:Label ID="lblNVerificare" runat="server" Text="0" Font-Size="Medium"></asp:Label>
        </div>
        <div style="display: inline-block; margin-bottom: 5px;">
            <Siar:Button ID="btnVerificaCovid" runat="server" Text="Verifica Richieste" OnClick="btnVerificaCovid_Click" />
        </div>
        <br />

        <div style="width: 350px; display: inline-block; margin-bottom: 5px; margin-left: 20px;">
            <asp:Label ID="lblConfermareCovid" runat="server" Text="Progetti da Confermare: " Font-Size="Medium"></asp:Label>
            <asp:Label ID="lblNConfermare" runat="server" Text="0" Font-Size="Medium"></asp:Label>
        </div>
        <div style="display: inline-block; margin-bottom: 5px;">
            <Siar:Button ID="btnConfermaCovid" runat="server" Text="Conferma Cor" OnClick="btnConfermaCovid_Click" />
        </div>
        <br />

        <div style="width: 350px; display: inline-block; margin-bottom: 5px; margin-left: 20px;">
            <asp:Label ID="lblCompletatiCovid" runat="server" Text="Progetti Completati: " Font-Size="Medium"></asp:Label>
            <asp:Label ID="lblNCompletate" runat="server" Text="0" Font-Size="Medium"></asp:Label>
        </div>
        <br />

        <div style="width: 350px; display: inline-block; margin-bottom: 5px; margin-left: 20px;">
            <asp:Label ID="lblErroriCovid" runat="server" Text="Progetti in Errore: " Font-Size="Medium"></asp:Label>
            <asp:Label ID="lblNErrori" runat="server" Text="0" Font-Size="Medium"></asp:Label>
        </div>
        <br />
        <br />
        <div style="display: inline-block; margin-bottom: 30px; margin-left: 20px;">
            <Siar:Button ID="btnExcelCovid" runat="server" Text="Download Dettaglio" />
        </div>

    </div>
    <div id="divModificaPsw" class="dBox" style="text-align: center; width: 20%; position: absolute; display: none;">
        <div style="float: left; overflow: auto; width: 100%; height: 95%;">
            <div class="separatore" style="padding-bottom: 3px;">
                Aggiorna Password
            </div>
            <div style="padding-top: 10px;">
                <asp:Label ID="lblUsernameWS" runat="server" Text="" Font-Size="small"></asp:Label>
            </div>
            <div style="padding-top: 10px; padding-bottom: 10px">
                Vecchia password:<br />
                <Siar:TextBox  ID="txtVecchiaPsw" runat="server" Width="150px" />
            </div>
            <div style="padding-bottom: 10px">
                Nuova password:<br />
                <Siar:TextBox  ID="txtNuovaPsw" runat="server" Width="150px" />
            </div>
            <div style="padding-bottom: 10px">
                Conferma password:<br />
                <Siar:TextBox  ID="txtConfermaPsw" runat="server" Width="150px" />
            </div>
            <div style="padding-bottom: 10px; display: inline-block;">
                <Siar:Button ID="btnSalvaPsw" runat="server" Text="Salva" Width="130px" OnClick="btnSalvaPsw_Click" />
            </div>
            <div style="padding-bottom: 10px; display: inline-block;">
                <Siar:Button ID="btnChiudiSalva" runat="server" Text="Chiudi" Width="130px" OnClientClick="chiudiPopupTemplate();return false;" CausesValidation="false" />
            </div>
        </div>
    </div>
</asp:Content>
