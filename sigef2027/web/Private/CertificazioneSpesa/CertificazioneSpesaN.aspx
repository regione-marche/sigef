<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="True" CodeBehind="CertificazioneSpesaN.aspx.cs" Inherits="web.Private.CertificazioneSpesa.CertificazioneSpesaN" %>

<%@ Register Src="~/CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <style type="text/css">
       /* h1 {
            display: block;
            font-size: 2em;
            margin-top: 0.67em;
            margin-bottom: 0.67em;
            margin-left: 10px;
            margin-right: 0;
            font-weight: bold;
        }

        h2 {
            display: block;
            font-size: 1.5em;
            margin-top: 0.83em;
            margin-bottom: 0.83em;
            margin-left: 0;
            margin-right: 0;
            font-weight: bold;
        }*/
    </style>

    <script type="text/javascript"> 
        function selezionaTesta(idCertSp) {
            $('[id$=hdnIdCertSp]').val($('[id$=hdnIdCertSp]').val() == idCertSp ? '' : idCertSp);
            $('[id$=btnPost]').click();
        }

        function selezionaProgetto(idProgetto) {
            $('[id$=hdnIdProgetto]').val($('[id$=hdnIdProgetto]').val() == idProgetto ? '' : idProgetto);
            $('[id$=hdnDomandaSelezionata]').val("");
            $('[id$=btnPost]').click();
        }

        function selezionaProgettoDec(idProgetto) {
            $('[id$=hdnIdProgettoDecPassate]').val($('[id$=hdnIdProgettoDecPassate]').val() == idProgetto ? '' : idProgetto);
            $('[id$=btnPost]').click();
        }


        function estraiInXls(tipo) {
            var DataFinale = $('[id$=hdnDataFinale]').val();
            var DataLotto = $('[id$=hdnDataLotto]').val();
            var Filtro = $('[id$=hdnDdlFiltro]').val();

            if (DataFinale == null || DataFinale == '')
                alert("Specificare il lotto prima di estrarre.");
            else if (DataLotto == null || DataLotto == '')
                alert("Specificare il lotto prima di estrarre.");
            else if (Filtro == null || Filtro == '')
                alert("Specificare il filtro prima di estrarre.");
            else {
                var parametri = "DataFinale=" + DataFinale + "|DataLotto=" + DataLotto + "|Filtro=" + Filtro;
                if (tipo == 1)
                    SNCVisualizzaReport('rptCertificazioneSpesaDettaglio', 2, parametri);
                else
                    SNCVisualizzaReport('rptCertificazioneSpesaDettaglioDelta', 2, parametri);
            }
        }

        function estraiInXlsLotto(soloDefinitivi, complessivi) {
            var DataLotto = $('[id$=hdnDataLotto]').val().split("/").reverse().join("");
            var codPsr = $('[id$=hdnCodPsr]').val();

            if (DataLotto == null || DataLotto == '')
                alert("Specificare il lotto prima di estrarre.");
            else if (codPsr == null || codPsr == '')
                alert("Specificare il programma prima di estrarre.");
            else {
                var parametri = "dataLotto=" + DataLotto + "|codPsr=" + codPsr + "|soloDefinitivi=" + soloDefinitivi + "|complessivi=" + complessivi;
                SNCVisualizzaReport('rptCertificazioneSpesaLotto', 2, parametri);
            }
        }

        function estraiInXlsProgramma(soloDefinitivi, complessivi) {
            var DataLotto = $('[id$=hdnDataLotto]').val().split("/").reverse().join("");
            var codPsr = $('[id$=hdnCodPsr]').val();

            if (DataLotto == null || DataLotto == '')
                alert("Specificare il lotto prima di estrarre.");
            else if (codPsr == null || codPsr == '')
                alert("Specificare il programma prima di estrarre.");
            else {
                var parametri = "dataLotto=" + DataLotto + "|codPsr=" + codPsr + "|soloDefinitivi=" + soloDefinitivi + "|complessivi=" + complessivi;
                SNCVisualizzaReport('rptCertificazioneSpesaProgramma', 2, parametri);
            }
        }

        function anticipiInXls() {
            var DataLotto = $('[id$=hdnDataLotto]').val();
            if (DataLotto == null || DataLotto == '') {
                alert("Specificare il lotto prima di estrarre.");
                return;
            }
            var parametri = "DataLotto=" + DataLotto;
            SNCVisualizzaReport('rptCertificazioneAnticipiDettaglio', 2, parametri);
        }

        function strumentiFinanziariInXls() {
            var DataLotto = $('[id$=hdnDataLotto]').val();
            if (DataLotto == null || DataLotto == '') {
                alert("Specificare il lotto prima di estrarre.");
                return;
            }
            var parametri = "DataLotto=" + DataLotto;
            SNCVisualizzaReport('rptCertificazioneStrumentiFinanziariDettaglio', 2, parametri);
        }

        function spesaInXls(complessivi) {
            var DataFine;
            if (complessivi == true)
                DataFine = $('[id$=hdnDataFinaleComplessivi]').val(); //"01/01/2014";
            else
                DataFine = $('[id$=hdnDataFinale]').val();
            var DataLotto = $('[id$=hdnDataLotto]').val();
            if (DataFine == null || DataFine == '')
                alert("Specificare il lotto prima di estrarre.");
            else if (DataLotto == null || DataLotto == '')
                alert("Specificare il lotto prima di estrarre.");
            else {
                var parametri = "DataFine=" + DataFine + "|DataLotto=" + DataLotto;
                SNCVisualizzaReport('rptCertificazioneSpeseDettaglio', 2, parametri);
            }
        }

        function certificabiliInXls() {
            SNCVisualizzaReport('rptPrevisioneCertificabili', 2, 'ENTE=%');
        }

        function selezionaDomanda(idDomanda) {
            if ($('[id$=hdnDomandaSelezionata]').val() == null || $('[id$=hdnDomandaSelezionata]').val() == "") {
                $('[id$=hdnDomandaSelezionata]').val(idDomanda);
            }
            else {
                $('[id$=hdnDomandaSelezionata]').val("");
            }
            $('[id$=btnSelezionaDomanda]').click();
        }

        function GetDecertSelezionati() {
            var grid = document.getElementById("<%=dgDecertificazioni.ClientID%>");
            var checkBoxes = grid.getElementsByTagName("INPUT");
            var selezionate = "";
            for (var i = 0; i < checkBoxes.length; i++) {
                if (checkBoxes[i].checked) {
                    var row = checkBoxes[i].parentNode.parentNode.parentNode;
                    selezionate += row.cells[6].innerHTML + "|";
                }
            }
            $('[id$=hdnDecertSelezionate]').val(selezionate);
        }

        function ImportiCertificatiInXls() {
            SNCVisualizzaReport('rptImportiCertificati', 2, 'ENTE=%');
        }

        function MostraNascondiDiv(id) {
            var div;
            var img;
            switch (id) {
                case -1:
                    div = $('[id$=divMostraLegenda]');
                    img = $('[id$=imgLegenda]')[0];
                    break;
                case 0:
                    div = $('[id$=divMostraDettaglioNuovi]');
                    img = $('[id$=imgDettaglioNuovi]')[0];
                    break;
                case 1:
                    div = $('[id$=divMostraDettaglio]');
                    img = $('[id$=imgDettaglio]')[0];
                    break;
                case 2:
                    div = $('[id$=divMostraRiepilogoPrevisioneProgettiCertificabili]');
                    img = $('[id$=imgRiepilogoPrevisioneProgettiCertificabili]')[0];
                    break;
            }

            if (img.style.transform == "")
                img.style.transform = "rotate(180deg)";
            else
                img.style.transform = "";

            if (div[0].style.display === "none") {
                div.show("fast");
            } else {
                div.hide("fast");
            }
        }

        function GetTabDecertSelezionati() {
            var grid = document.getElementById("<%=dgTabDecertificazioni.ClientID%>");
            var checkBoxes = grid.getElementsByTagName("INPUT");
            var selezionate = "";
            for (var i = 0; i < checkBoxes.length; i++) {
                if (checkBoxes[i].checked) {
                    var row = checkBoxes[i].parentNode.parentNode.parentNode;
                    selezionate += row.cells[8].innerHTML + "|";
                }
            }
            $('[id$=hdnTabDecertSelezionate]').val(selezionate);
        }

    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnCodPsr" runat="server" />
        <asp:HiddenField ID="hdnIdCertSp" runat="server" />
        <asp:HiddenField ID="hdnCreaLotto" runat="server" />
        <asp:HiddenField ID="hdnTstCheck" runat="server" />
        <asp:HiddenField ID="hdnIdProgetto" runat="server" />
        <asp:HiddenField ID="hdnDdlFiltro" runat="server" />
        <asp:HiddenField ID="hdnDataFinale" runat="server" />
        <asp:HiddenField ID="hdnDataFinaleComplessivi" runat="server" />
        <asp:HiddenField ID="hdnDataLotto" runat="server" />
        <asp:HiddenField ID="hdnIdDomanda" runat="server" />
        <asp:HiddenField ID="hdnDomandaSelezionata" runat="server" />
        <asp:HiddenField ID="hdnFascicolo" runat="server" Value="85.30.10/2023/PRCN/16" /> 
        <%--        <asp:HiddenField ID="hdnFascicolo" runat="server" Value="150.30.130/2016/INF/409" />--%>
        <asp:HiddenField ID="hdnDecertSelezionate" runat="server" />
        <asp:HiddenField ID="hdnTabDecertSelezionate" runat="server" />
        <asp:HiddenField ID="hdnStrutturaAudit" runat="server" Value="ACSL" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click"
            CausesValidation="false" />
        <asp:Button ID="btnSelezionaDomanda" runat="server" OnClick="btnSelezionaDomanda_Click"
            CausesValidation="false" />
    </div>

    <!-- Creazione Lotti -->
    <div class="modal fade" tabindex="-1" role="dialog" id="divCreaLotto" aria-labelledby="Crea Lotto">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title h5" id="modalCreaLotto">Creazione nuovo lotto</h4>
                    <button class="btn-close" type="button" data-bs-dismiss="modal" aria-label="Chiudi finestra modale">
                        <svg class="icon"></svg>
                        <%--<use href="/bootstrap-italia/svg/sprites.svg#it-close"></use>--%>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-12">
                            <%--<label class="active" for="txtDataInizio">Data Inizio (opz.)</label>
                            <asp:TextBox CssClass="rounded" ID="txtDataInizio" TextMode="Date" runat="server"></asp:TextBox>--%>
                            <Siar:DateTextBoxAgid ID="txtDataInizio" Label="Data inizio lotto" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <%--<label class="active" for="txtDataFine">Data Fine </label>
                            <asp:TextBox CssClass="rounded" ID="txtDataFine" TextMode="Date" runat="server"></asp:TextBox>--%>
                            <Siar:DateTextBoxAgid ID="txtDataFine" Label="Data fine lotto" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <label class="active" for="ddlTipo">Tipo</label>
                            <asp:DropDownList ID="ddlTipo" AutoPostBack="False" runat="server">
                                <asp:ListItem Selected="True" Value="I">Intermedio</asp:ListItem>
                                <asp:ListItem Value="F">Finale</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <Siar:Button ID="btnCreaLotto" runat="server" Text="Crea lotto" data-bs-dismiss="modal" OnClick="btnCreaLotto_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Testa -->
    <%--    <div style="text-align:center;">
        <h1>Certificazione della Spesa</h1>
    </div>--%>
   <div class="container-fluid shadow bd-form rounded-3 py-5">
        <h2 class="align-items-center">Certificazione della Spesa</h2>

        <div class="row align-items-center pt-5">
            <div class="col-sm-4">
                <Siar:ComboZPsr ID="lstPsr"  Label="Selezionare il programma" runat="server" AutoPostBack="true"></Siar:ComboZPsr>
            </div>
            <div class="col-sm-2 pb-1">
                <button type="button" id="btnVisualizza_CreaLotto" class="btn btn-primary py-1" data-bs-toggle="modal" data-bs-target="#divCreaLotto">Crea lotto</button>
            </div>
        </div>
       <%-- <div class="row" />--%>
    
        <!-- Lotti -->
        <div id="divTesta" class="row pt-5" visible="true" runat="server">
            
            <div id="divTestaElenco" class="col-md-12" runat="server" visible="false">
                <div class="row justify-content-start align-content-center py-2">
                    <div class="flex-column">
                        <input type="button" class="btn btn-secondary py-1" value="Report previsione progetti certificabili" onclick="return certificabiliInXls();" />
                        <input type="button" class="btn btn-secondary py-1" value="Report importi certificati" onclick="return ImportiCertificatiInXls();" />
                    </div>
                </div>
                <div  class="d-flex flex-row" id="divMostraRiepilogoPrevisioneProgettiCertificabili" >
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <Siar:DataGridAgid CssClass="table table-striped" ID="dgRiepilogoPrevisioneProgettiCertificabili" runat="server" AutoGenerateColumns="false">
                               <HeaderStyle CssClass="headerStyle" />
                                <ItemStyle CssClass="DataGridRow itemStyle" />
                                <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                                <Columns>
                                    <asp:BoundColumn DataField="Asse" HeaderText="Asse">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DaIstruire" HeaderText="Da istruire" DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DaValidare" HeaderText="Da validare" DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DaCertificare" HeaderText="Da certificare" DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                    </div>
                </div>
                <div class="row pt-5">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <Siar:DataGridAgid ID="dgTesta" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                              <HeaderStyle CssClass="headerStyle" />
                                <ItemStyle CssClass="DataGridRow itemStyle" />
                                <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                                <Columns>
                                    <asp:BoundColumn DataField="Idcertsp" HeaderText="Id Lotto"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Datainizio" HeaderText="Data Inizio"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Datafine" HeaderText="Data Fine"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Tipo" HeaderText="Tipo"></asp:BoundColumn>
                                    <Siar:ColonnaLink DataField="Definitivo" HeaderText="Definitivo" IsJavascript="true"
                                        LinkFields="Idcertsp" LinkFormat="selezionaTesta({0});">
                                    </Siar:ColonnaLink>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                    </div>
                </div>
            </div>
            <div id="divTestaDati" class="col-12" runat="server" visible="true"></div>
        </div>
    </div>
  
        <!-- Dettaglio -->
     <div id="divDettaglio" class="row mx-0" visible="false" runat="server">  
         <div class="container-fluid shadow bd-form rounded-3 py-4">
            <uc2:SiarNewTab ID="tabDettaglio" runat="server" TabNames="Elenco|Dati riassuntivi Lotto|Dati riassuntivi Programma|Dati provvisori Lotto|Dati provvisori Programma|Decertificazioni" Titolo="Certificazione di spesa" />
            <!-- Elenco -->
            <div id="divDettaglioElenco" class="tableTab pt-5" runat="server">
                <div class="row ">
                    <div class="col-md-2 form-group">
                        <div class="select-wrapper">
                            <label class="active" for="<% =ddlFiltro.ClientID %>">Filtro progetti</label>
                            <asp:DropDownList ID="ddlFiltro" AutoPostBack="True" runat="server">
                                <asp:ListItem Selected="True" Value="1">Tutti</asp:ListItem>
                                <asp:ListItem Value="2">Selezionati</asp:ListItem>
                                <asp:ListItem Value="3">Non Selezionati</asp:ListItem>
                                <asp:ListItem Value="4">Con Checklist</asp:ListItem>
                                <asp:ListItem Value="5">Senza Checklist</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-10 align-items-center">
                        <%--Sembra non debba più servire la checklist--%> 
                        <Siar:Button ID="btnVisualizza_tstChecklist" runat="server" OnClick="btnVisualizza_tstChecklist_Click" Text="Checklist lotto" Visible="false" />
                        <Siar:Button ID="btnCancella" runat="server" OnClick="btnCancella_Click" Text="Cancella lotto" Modifica="True" />
                        <Siar:Button ID="btnSalvaElenco" runat="server" OnClick="btnSalvaElenco_Click" Text="Salva" Modifica="true" />
                        <input type="button" class="btn btn-primary py-1 " value="Estrai in xls" onclick="return estraiInXls(1);" />
                        <input type="button" class="btn btn-primary py-1 " value="Estrai Delta in xls" onclick="return estraiInXls(2);" />
                    </div>
                </div>
                <div class="row ">
                    <div class="col-md-2 py-2">
                        <Siar:Button ID="btnDefinitivo" runat="server" OnClick="btnDefinitivo_Click" Text="Rendi Definitivo" Modifica="True"
                            ToolTip="Rendi il lotto Definitivo." CausesValidation="true" />
                    </div>
                    <div class="col-md-4 form-group">
                        <Siar:TextBox ID="txtSegnaturaCertificazione" runat="server" ReadOnly="True" />
                    </div>
                    <div class="col-md-1 form-group pt-2">
                        <img id="imgSegnaturaCertificazione" runat="server" height="20" src="../../images/lente.png" width="20" title="Visualizza documento" />
                    </div>
                </div>
                <div class="row" style="display: none;">
                    <div class="col-md-2 py-2">
                        <Siar:Button ID="btnInserisciSegnatura" runat="server" Text="Dichiarazione AdG" OnClick="btnInserisciSegnatura_Click" Modifica="True" />
                    </div>
                    <div class="col-md-4 form-group">
                        <Siar:TextBox ID="txtSegnaturaVerbale" runat="server" ReadOnly="True" />

                    </div>
                    <div class="col-md-1 form-group pt-2">
                        <img id="imgSegnaturaVerbale" runat="server" height="20" src="../../images/lente.png" width="20" title="Visualizza documento" />
                    </div>
                </div>
                <div class="row justify-content-start">
                    <div class="col-12">
                        <asp:Label ID="lblNrRecordTotale" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                    </div>
                </div>

                <div class="row ">
                    <div id="divCaricaTstCheck" class="col-12" runat="server" visible="false">
                        Checklist lotto (per salvare le modifiche cliccare "Salva")
                    <uc1:SNCUploadFileControl ID="ufTstChecklist" runat="server" />
                    </div>
                </div>

                <div class="row">
                    <div class="accordion" id="legenda">
                        <div class="accordion-item">
                            <h2 class="accordion-header" id="legendaHead">
                                <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#legendaBody" aria-expanded="true" aria-controls="legendaBody">
                                    Legenda colori
                                </button>
                            </h2>
                            <div id="legendaBody" class="accordion-collapse collapse show" role="region" aria-labelledby="legendaHead">
                                <div class="accordion-body">
                                    <div id="col-12">
                                        <Siar:DataGridAgid ID="dgLegenda" runat="server" AutoGenerateColumns="False" Width="50%">
                                            <Columns>
                                                <asp:BoundColumn DataField="Testo" HeaderText="Legenda"></asp:BoundColumn>
                                            </Columns>
                                        </Siar:DataGridAgid>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <%--               
                <div style="padding-bottom: 3px; cursor: pointer; width: 95%;" onclick="MostraNascondiDiv(-1); return false;">
                    <img id="imgLegenda" runat="server" style="width: 23px; height: 23px;" />
                    <b>Legenda colori:</b>
                    
                </div>--%>

                <%-- <div class="row" style="padding-bottom: 3px; cursor: pointer; width: 95%;" onclick="MostraNascondiDiv(0); return false;">
                <img id="imgDettaglioNuovi" runat="server" style="width: 23px; height: 23px;" />
                <b>Nuovi progetti presenti in certificazione:</b>
            </div>--%>

                <div class="row">
                    <div class="accordion" id="newProCert">
                        <div class="accordion-item">
                            <h2 class="accordion-header" id="newProCertHead">
                                <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#newProCertCollapse" aria-expanded="true" aria-controls="newProCertCollapse">
                                    Nuovi progetti presenti in certificazione
                                </button>
                            </h2>
                            <div id="newProCertCollapse" class="accordion-collapse collapse show" role="region" aria-labelledby="newProCertHead">
                                <div class="accordion-body">
                                    <div class="row justify-content-end align-content-center">
                                        <div class="col-12">
                                            <asp:Label ID="lblNrRecordNuovi" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="table-responsive">
                                            <Siar:DataGridAgid ID="dgDettaglioNuovi" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                                             <HeaderStyle CssClass="headerStyle" />
                                             <ItemStyle CssClass="DataGridRow itemStyle" />
                                             <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                                                <Columns>
                                                    <asp:BoundColumn DataField="Asse" HeaderText="Asse"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="ObiettivoSpecifico" HeaderText="Obiettivo Specifico"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Azione" HeaderText="Azione"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Intervento" HeaderText="Intervento"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="IdBando" HeaderText="Bando"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id Progetto"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="CodiceCup" HeaderText="Codice CUP"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="CupNaturaDescrizione" HeaderText="Tipo Operazione"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Beneficiario" HeaderText="Beneficiario"></asp:BoundColumn>
                                                    <Siar:ColonnaLink DataField="CostoTotale" HeaderText="Costo investimento ammesso" DataFormatString="{0:c}" IsJavascript="true"
                                                        LinkFields="IdProgetto" LinkFormat="selezionaProgetto({0});">
                                                    </Siar:ColonnaLink>
                                                    <asp:BoundColumn  DataField="ImportoAmmesso" HeaderText="Contributo concesso" DataFormatString="{0:c}"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="ImportoConcesso" HeaderText="Importo rendicontato ammesso (totale periodo contabile)" DataFormatString="{0:c}"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="ImportoContributoPubblico" HeaderText="Contributo rendicontato concesso (totale periodo contabile)" DataFormatString="{0:c}"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="QuotaUe" HeaderText="Ue" DataFormatString="{0:c}"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="QuotaStato" HeaderText="Stato" DataFormatString="{0:c}"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="QuotaRegione" HeaderText="Regione" DataFormatString="{0:c}"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="QuotaPrivato" HeaderText="Quota a carico del privato" DataFormatString="{0:c}" Visible="false"></asp:BoundColumn>
                                                    <Siar:CheckColumn DataField="IdProgetto" Name="Selezionata" HeaderSelectAll="true"></Siar:CheckColumn>
                                                </Columns>
                                            </Siar:DataGridAgid>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="accordion-item">
                            <h2 class="accordion-header" id="previusProCertHead">
                                <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#previusProCertCollapse" aria-expanded="true" aria-controls="previusProCertCollapse">
                                    Progetti presenti anche in certificazioni precedenti
                                </button>
                            </h2>
                            <div id="previusProCertCollapse" class="accordion-collapse collapse show" role="region" aria-labelledby="previusProCertHead">
                                <div class="accordion-body">
                                    <div class="col-12">
                                        <asp:Label ID="lblNrRecord" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                                    </div>
                                    <div class="col-12">
                                        <div class="table-responsive">
                                            <Siar:DataGridAgid ID="dgDettaglio" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                                             <HeaderStyle CssClass="headerStyle" />
                                             <ItemStyle CssClass="DataGridRow itemStyle" />
                                             <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                                                <Columns>
                                                    <asp:BoundColumn  DataField="Asse" HeaderText="Asse"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="ObiettivoSpecifico" HeaderText="Obiettivo Specifico"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="Azione" HeaderText="Azione"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="Intervento" HeaderText="Intervento"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="IdBando" HeaderText="Bando"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="IdProgetto" HeaderText="Id Progetto"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="CodiceCup" HeaderText="Codice CUP"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="CupNaturaDescrizione" HeaderText="Tipo Operazione"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="Beneficiario" HeaderText="Beneficiario"></asp:BoundColumn>
                                                    <Siar:ColonnaLink DataField="CostoTotale" HeaderText="Costo investimento ammesso" DataFormatString="{0:c}" IsJavascript="true"
                                                        LinkFields="IdProgetto" LinkFormat="selezionaProgetto({0});">
                                                    </Siar:ColonnaLink>
                                                    <asp:BoundColumn  DataField="ImportoAmmesso" HeaderText="Contributo concesso" DataFormatString="{0:c}"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="ImportoConcesso" HeaderText="Importo rendicontato ammesso (totale periodo contabile)" DataFormatString="{0:c}"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="ImportoContributoPubblico" HeaderText="Contributo rendicontato concesso (totale periodo contabile)" DataFormatString="{0:c}"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="QuotaUe" HeaderText="Ue" DataFormatString="{0:c}"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="QuotaStato" HeaderText="Stato" DataFormatString="{0:c}"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="QuotaRegione" HeaderText="Regione" DataFormatString="{0:c}"></asp:BoundColumn>
                                                    <asp:BoundColumn  DataField="QuotaPrivato" HeaderText="Quota a carico del privato" DataFormatString="{0:c}" Visible="false"></asp:BoundColumn>
                                                    <Siar:CheckColumn  DataField="IdProgetto" Name="Selezionata" HeaderSelectAll="true"></Siar:CheckColumn>
                                                </Columns>
                                            </Siar:DataGridAgid>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--    <div class="row" style="padding-bottom: 3px; cursor: pointer; width: 95%;" onclick="MostraNascon<diDiv(1); return false;">
                <img id="imgDettaglio" runat="server" style="width: 23px; height: 23px;" />
                <b>Progetti presenti anche in certificazioni precedenti:</b>
            </div>--%>
            </div>
           
            <!-- Dati riassuntivi Lotto -->
            <div id="divDettaglioDati" class="tableTab" runat="server" visible="false">              
                <div class="d-flex flex-row justify-content-start align-items-center py-3">
                    <div class="p-2">
                        <h5><asp:Label ID="DatiLotto_Titolo" CssClass="fw-semibold" runat="server"></asp:Label></h5>
                    </div>
                </div>
                <div class="d-flex flex-row justify-content-start align-items-center py-2">
                    <div class="p-2">
                        <input type="button" class="btn btn-primary py-2" value="Estrai in xls 'Dati riassuntivi Lotto'" onclick="return estraiInXlsLotto(1, 0);" />
                    </div>
                </div>
                <div class="d-flex flex-row justify-content-between align-items-center py-2">
                    <div class="p-2">
                        <h6>Spesa suddivisa per priorità e per categoria di regioni, come contabilizzata dall'autorità di certificazione</h6>
                    </div>
                    <div class="p-2">
                        <input type="button" class="btn btn-primary py-2" value="Estrai in xls" onclick="return spesaInXls();" />
                    </div>
                </div>
                <div class="d-flex flex-row p-2">
                    <!--Griglia spese -->
                    <div class="col-12">
                        <div class="table-responsive">
                            <table id="tblDettaglioDati" class="table table-striped" runat="server">
                                <tr class="TESTA1">
                                    <th style="text-align: center;">Asse</th>
                                    <th>Base calcolo (solo contributo pubblico o spesa totale compresa quella dei privati o altro pubblico)</th>
                                    <th>Importo totale delle spese ammissibili sostenute dai beneficiari e pagate nell'attuazione delle operazioni</th>
                                    <th>Importo totale della spesa pubblica relativa all'attuazione delle operazioni</th>
                                    <th>Importo totale delle spese ammissibili sostenute dai beneficiari e pagate nell’attuazione delle operazioni – da non certificare</th>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
           
            <!-- Dati rissuntivi programma -->
            <div id="divDettaglioProgramma" class="tableTab" runat="server" visible="false">
              
                <div class="d-flex flex-row justify-content-start align-items-center py-3">
                    <div class="p-2">
                        <h6><asp:Label CssClass="fw-semibold " ID="DatiProgramma_Titolo" runat="server"></asp:Label></h6>
                        <!-- Es. Dati definitivi programma 'POR FESR 2014 - 2020 2014-2020' dall'inizio fino al 24/10/2023 incluso -->
                    </div>
                </div>
                <div class="d-flex flex-row justify-content-start align-items-center py-2">
                    <div class="p-2">
                        <input type="button" class="btn btn-primary py-2" value="Estrai in xls 'Dati riassuntivi Programma'" onclick="return estraiInXlsProgramma(1, 1);" />
                    </div>
                </div>
                <div class="d-flex flex-row justify-content-between align-items-center pt-5">
                    <div class="pt-3">
                        <h6>Informazioni sugli importi dei contributi per programma erogati agli strumenti finanziari e inclusi nelle domande di pagamento</h6>
                    </div>
                    <div class="p-2">
                        <input type="button" class="btn btn-primary py-2" value="Estrai in xls" onclick="return strumentiFinanziariInXls();" />
                    </div>
                </div>
                <!--Griglia strumenti finanziari -->
                <div class="d-flex flex-row p-2">
                    <div class="table-responsive">
                        <table id="tblStrumentiFi" class="table table-striped" runat="server">
                            <tr class="TESTA1">
                                <th>&nbsp;</th>
                                <th colspan="2">Importi dei contributi per programma erogati agli strumenti finanziari e inclusi nelle domande di pagamento</th>
                                <th colspan="2">Importi erogati a titolo di spesa ammissibile ai sensi dell'articolo 42, paragrafo 1, lettere a), b) e d), del regolamento (UE) n. 1303/2013</th>
                            </tr>
                            <tr class="TESTA1">
                             <th style="text-align: center; min-width: 50px;">Asse</th>
                                <th style="width: 22%;">Importo complessivo dei contributi per programma erogati agli strumenti finanziari</th>
                                <th style="width: 22%;">Importo della spesa pubblica corrispondente</th>
                                <th style="width: 22%;">Importo complessivo dei contributi del programma effettivamente erogati o, nel caso delle garanzie, impegnati a titolo di spesa ammissibile ai sensi dell'articolo 42, paragrafo 1, lettere a), b) e d), del regolamento (UE) n. 1303/2013</th>
                                <th style="width: 22%;">Importo della spesa pubblica corrispondente</th>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="d-flex flex-row justify-content-between align-content-center pt-4">
                    <div class="p-2">
                        <h5>Anticipi versati nel quadro di aiuti di Stato</h5>
                    </div>
                    <div class="p-2">
                        <input type="button" class="btn btn-primary py-2" value="Estrai in xls" onclick="return anticipiInXls();" />
                    </div>
                </div>
                <div class="d-flex flex-row">
                    <div class="table-responsive">
                        <table id="tblAnticipi" class="table table-striped" runat="server">
                            <tr class="TESTA1">
                             <th style="text-align: center; min-width: 50px;">Asse</th>
                                <th style="width: 30%;">Importo complessivo versato come anticipo dal programma operativo</th>
                                <th style="width: 30%;">Importo che è stato coperto dalle spese sostenute dai beneficiari entro tre anni dal pagamento dell'anticipo</th>
                                <th style="width: 30%;">Importo che non è stato coperto dalle spese sostenute dai beneficiari e per il quale il periodo di tre anni non è ancora trascorso</th>
                            </tr>
                        </table>
                    </div>
                </div>


                <div class="d-flex flex-row justify-content-start align-items-center pt-4">
                    <div class="p-2">
                        <h5>Spesa complessiva suddivisa per priorità e per categoria di regioni, come contabilizzata dall'autorità di certificazione</h5>
                    </div>
                    <div class="p-2">
                        <input type="button" class="btn btn-primary py-2" value="Estrai in xls" onclick="return spesaInXls(true);" />
                    </div>
                </div>
                <!--Griglia spese complessive-->
                <div class="d-flex flex-row">
                    <div class="table-responsive">
                        <table id="tblDettaglioDatiComplessivi" class="table table-striped" runat="server">
                            <tr class="TESTA1">
                                <th style="text-align: center; min-width: 50px;">Asse</th>
                                <th>Base calcolo (solo contributo pubblico o spesa totale compresa quella dei privati o altro pubblico)</th>
                                <th>Importo totale delle spese ammissibili sostenute dai beneficiari e pagate nell'attuazione delle operazioni</th>
                                <th>Importo totale della spesa pubblica relativa all'attuazione delle operazioni</th>
                                <th>Importo totale delle spese ammissibili sostenute dai beneficiari e pagate nell’attuazione delle operazioni – da non certificare</th>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
          

            <!-- Dati provvisori Lotto -->
            <div id="divDettaglioDatiProvv" class="tableTab" runat="server" visible="false">
                
                <div class="d-flex flex-row justify-content-start align-items-center py-3">
                    <div class="p-2">
                        <h5>
                            <asp:Label ID="DatiLottoProvv_Titolo" runat="server"></asp:Label></h5>
                    </div>
                </div>
                <div class="d-flex flex-row justify-content-start align-items-center py-2">
                    <div class="p-2">
                        <input type="button" class="btn btn-primary py-2" value="Estrai in xls 'Dati provvisori Lotto'" onclick="return estraiInXlsLotto(0, 0);" />
                    </div>
                </div>

                <div class="d-flex flex-row justify-content-start align-items-center py-2">
                    <div class="p-2">
                        <h5>Spesa suddivisa per priorità e per categoria di regioni, come contabilizzata dall'autorità di certificazione</h5>
                    </div>
                </div>
                <!--Griglia spese -->
                <div class="d-flex flex-row">
                    <div class="table-responsive">
                        <table id="tblDettaglioDatiProvv" class="table table-striped" runat="server">
                            <tr class="TESTA1">
                                <th class="text-center">Asse</th>
                                <th class="text-center" >Base calcolo (solo contributo pubblico o spesa totale compresa quella dei privati o altro pubblico)</th>
                                <th class="text-center" >Importo totale delle spese ammissibili sostenute dai beneficiari e pagate nell'attuazione delle operazioni</th>
                                <th class="text-center">Importo totale della spesa pubblica relativa all'attuazione delle operazioni</th>
                                <th class="text-center"  >Importo totale delle spese ammissibili sostenute dai beneficiari e pagate nell’attuazione delle operazioni – da non certificare</th>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
                
        
            <!-- Dati provvisori programma -->
            <div id="divDettaglioProgrammaProvv" class="tableTab" runat="server" visible="false">
           
                <div class="d-flex flex-row justify-content-start align-items-center py-3">
                    <h4>
                        <asp:Label ID="DatiProgrammaProvv_Titolo" runat="server"></asp:Label></h4>
                </div>
                <div class="d-flex flex-row justify-content-start align-items-center py-2">
                    <input type="button" class="btn btn-primary" value="Estrai in xls 'Dati provvisori Programma'" onclick="return estraiInXlsProgramma(0, 1);" />
                </div>
                <!--Griglia strumenti finanziari -->
                <div class="d-flex flex-row justify-content-start align-items-center py-2">
                    <div class="p-2">
                        <h5>Informazioni sugli importi dei contributi per programma erogati agli strumenti finanziari e inclusi nelle domande di pagamento </h5>
                    </div>
                </div>
                <div class="d-flex flex-row">
                    <div class="table-responsive">
                        <!-- input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return strumentiFinanziariInXls();" /-->
                        <table id="tblStrumentiFiProvv" class="table table-striped" runat="server">
                            <tr class="TESTA1">
                                <th>&nbsp;</th>
                                <th colspan="2">Importi dei contributi per programma erogati agli strumenti finanziari e inclusi nelle domande di pagamento</th>
                                <th colspan="2">Importi erogati a titolo di spesa ammissibile ai sensi dell'articolo 42, paragrafo 1, lettere a), b) e d), del regolamento (UE) n. 1303/2013</th>
                            </tr>
                            <tr class="TESTA1">
                                <th class="text-center">Asse</th>
                                <th style="width: 22%;">Importo complessivo dei contributi per programma erogati agli strumenti finanziari</th>
                                <th style="width: 22%;">Importo della spesa pubblica corrispondente</th>
                                <th style="width: 22%;">Importo complessivo dei contributi del programma effettivamente erogati o, nel caso delle garanzie, impegnati a titolo di spesa ammissibile ai sensi dell'articolo 42, paragrafo 1, lettere a), b) e d), del regolamento (UE) n. 1303/2013</th>
                                <th style="width: 22%;">Importo della spesa pubblica corrispondente</th>
                            </tr>
                        </table>
                    </div>
                </div>
                <!--Griglia anticipi -->
                <div class="d-flex flex-row justify-content-start align-items-center py-2">
                    <div class="p-2">
                        <h5>Anticipi versati nel quadro di aiuti di Stato</h5>
                    </div>
                </div>

                <div class="d-flex flex-row">
                    <div class="table-responsive">
                        <!--input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return anticipiInXls();" /-->
                        <table id="tblAnticipiProvv" class="table table-striped" runat="server">
                            <tr class="TESTA1">
                               <th class="text-center">Asse</th>
                                <th style="width: 30%;">Importo complessivo versato come anticipo dal programma operativo</th>
                                <th style="width: 30%;">Importo che è stato coperto dalle spese sostenute dai beneficiari entro tre anni dal pagamento dell'anticipo</th>
                                <th style="width: 30%;">Importo che non è stato coperto dalle spese sostenute dai beneficiari e per il quale il periodo di tre anni non è ancora trascorso</th>
                            </tr>
                        </table>
                    </div>
                </div>
                <!--Griglia spese complessive -->
                <div class="d-flex flex-row justify-content-start align-items-center py-2">
                    <div class="p-2">
                        <h5>Spesa complessiva suddivisa per priorità e per categoria di regioni, come contabilizzata dall'autorità di certificazione</h5>
                    </div>
                </div>
                <div class="d-flex flex-row">
                    <div class="table-responsive">

                        <!-- input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return spesaInXls(true);" /-->
                        <table id="tblDettaglioDatiComplessiviProvv" class="table table-striped" runat="server">
                            <tr class="TESTA1">
                                <th class="text-center">Asse</th>
                                <th>Base calcolo (solo contributo pubblico o spesa totale compresa quella dei privati o altro pubblico)</th>
                                <th>Importo totale delle spese ammissibili sostenute dai beneficiari e pagate nell'attuazione delle operazioni</th>
                                <th>Importo totale della spesa pubblica relativa all'attuazione delle operazioni</th>
                                <th>Importo totale delle spese ammissibili sostenute dai beneficiari e pagate nell’attuazione delle operazioni – da non certificare</th>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
       

            <!-- Decertificazioni -->
            <div id="divTabDecertificazioni" class="tableTab" runat="server" visible="true">
              
                <p>
                    Nell'elenco vengono mostrati i progetti non presenti nel lotto selezionato con irregolarità, errori o rinunce con azione "ritiro".<br />
                    Selezionare e salvare una decertificazione permette la decertificazione dei progetti creando una "riga negativa".<br />
                </p>
                <asp:Label ID="lblTabDecertificazioni" Text="Nessuna decertificazione trovata da associare in questa Certificazione di spesa." Font-Size="Small" runat="server"></asp:Label>
              
                <div class="col-12" id="divContenutoTabDecert" runat="server">
                    <Siar:DataGridAgid ID="dgTabDecertificazioni" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                        <Columns>
                            <asp:BoundColumn DataField="IdProgetto" HeaderText="Id Progetto"></asp:BoundColumn>
                            <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Id Domanda Pagamento"></asp:BoundColumn>
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
                    </Siar:DataGridAgid><br />
                    <Siar:Button ID="btnSalvaTabDecert" runat="server" Text="Salva Decertificazioni" OnClientClick="GetTabDecertSelezionati()" OnClick="btnSalvaTabDecert_Click" Modifica="true" />
                </div>
          

             <!-- Singola domanda -->         
            <div id="divSingolo" class="row pt-4" visible="false" runat="server">

                <asp:Label Text="Selezionare una domanda per associare una o più decertificazioni" Font-Size="Medium" runat="server"></asp:Label>
                <div class="table-responsive">
                    <Siar:DataGridAgid ID="dgSingolo" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemStyle CssClass="DataGridRow itemStyle" />
                        <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                        <Columns>
                            <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Id Domanda"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Tipodomanda" HeaderText="Tipo Domanda"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ImportoConcesso" HeaderText="Importo rendicontato ammesso (totale periodo contabile)" DataFormatString="{0:c}"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ImportoContributoPubblico" HeaderText="Contributo rendicontato concesso (totale periodo contabile)" DataFormatString="{0:c}"></asp:BoundColumn>
                            <asp:BoundColumn DataField="SpesaAmmessa" HeaderText="Importo rendicontato ammesso (delta riferito allo specifico lotto)" DataFormatString="{0:c}"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ImportoContributoPubblicoIncrementale" HeaderText="Contributo rendicontato concesso (delta riferito allo specifico lotto)" DataFormatString="{0:c}"></asp:BoundColumn>
                            <Siar:JsButtonColumn ButtonText="Decertifica" JsFunction="selezionaDomanda" Arguments="IdDomandaPagamento"></Siar:JsButtonColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
           
            <div id="divDecertificazioni" class="row pb-3" runat="server" visible="false">
                <div class="table-responsive">
                    <Siar:DataGridAgid ID="dgDecertificazioni" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemStyle CssClass="DataGridRow itemStyle" />
                        <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                        <Columns>
                            <asp:BoundColumn DataField="IdDecertificazione" HeaderText="Id Decertificazione"></asp:BoundColumn>
                            <asp:BoundColumn DataField="TipoDecertificazione" HeaderText="Tipo Decertificazione"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ImportoDecertificazioneAmmesso" HeaderText="Importo Decertificazione Ammesso" DataFormatString="{0:c}"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ImportoDecertificazioneConcesso" HeaderText="Importo Decertificazione Concesso" DataFormatString="{0:c}"></asp:BoundColumn>
                            <asp:BoundColumn DataField="DataConstatazioneAmministrativa" HeaderText="Data Rilevazione"></asp:BoundColumn>
                            <Siar:CheckColumn DataField="Assegnata">
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                            </Siar:CheckColumn>
                            <asp:BoundColumn DataField="IdCertDecertificazione" HeaderText="Id Decertificazione"></asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
                <div class="row align-items-end justify-content-start py-4">
                    <br />
                    <asp:Label ID="lblNessunaDecert" Text="Nessuna decertificazione trovata per questo progetto" Font-Size="Small" runat="server" Visible="false" />
                    <br />
                    <Siar:Button ID="btnSalvaDecertificazioni" runat="server" OnClientClick="GetDecertSelezionati()" OnClick="btnSalvaDecertificazioni_Click" Text="Salva Decertificazioni" Modifica="true" />
                    <Siar:Button ID="btnIndietroDecertificazioni" runat="server" OnClick="btnIndietroDecertificazioni_Click" Text="Indietro" Modifica="true" />
                </div>
                <div class="row align-items-end justify-content-start py-4">
                    <div class="col-md-6">
                        <label for="txtDataInizio">Note</label>
                        <asp:TextBox CssClass="rounded" ID="NoteDomanda" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="col-6 align-self pb-1">
                        Checklist domanda (per salvare le modifiche cliccare "Salva Domanda")
                <uc1:SNCUploadFileControl ID="ufDetChecklist" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <Siar:Button ID="btnSalvaSingolo" runat="server" OnClick="btnSalvaSingolo_Click" Text="Salva Domanda" Modifica="true" Width="100px" />
                    </div>
                </div>
            </div>

            </div>
            
        <!-- Segnatura -->
        </div>
        </div>
        <div id="divSegnatura" class="modal it-dialog" tabindex="-1" role="dialog" style="position: absolute; display: none">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title h5" id="modalSegnatura">Segnatura</h4>
                        <button class="btn-close" type="button" data-bs-dismiss="modal" aria-label="Chiudi finestra modale" onclick="chiudiPopupTemplate()">
                            <svg class="icon">
                                <use href="/web/bootstrap-italia/svg/sprites.svg#it-close"></use>
                            </svg>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-12">
                                <label class="active" for="txtData">Data</label>
                                <asp:TextBox CssClass="rounded" ID="txtData" TextMode="Date" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <%--<label class="active" for="txtSegnatura">Segnatura</label>         --%>
                                <asp:TextBox CssClass="rounded" ID="txtSegnatura" runat="server" Width="400px" />
                                <img id="imgSegnatura" runat="server" height="18" src="../../images/lente.png"
                                    title="Visualizza documento" width="18" />
                            </div>
                        </div>
                    </div>

                </div>

                <div class="modal-footer">
                    <Siar:Button ID="btnSalvaSegnatura" class="btn btn-primary" runat="server" Modifica="true" OnClick="btnSalvaSegnatura_Click"
                        Text="Salva" Width="100px" data-bs-dismiss="modal" />
                    <input class="btn btn-secondar" text="Chiudi" data-bs-dismiss="modal" />

                </div>
            </div>
        </div>
    <div class="row pb-3">
        <uc3:FirmaDocumento ID="ucFirmaDocumento" runat="server" Titolo="Firma Comunicazione Certificazione" TipoDocumento="COMUNICAZIONE_CERTIFICAZIONE_NEW" />
    </div>

</asp:Content>
