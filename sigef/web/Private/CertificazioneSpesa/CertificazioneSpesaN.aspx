<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="True" 
         CodeBehind="CertificazioneSpesaN.aspx.cs" Inherits="web.Private.CertificazioneSpesa.CertificazioneSpesaN" %>
<%@ Register Src="~/CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <style type="text/css">
        h1 {
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
        } 
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
                if(tipo == 1)
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

    <div style="display:none">
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
        <asp:HiddenField ID="hdnDomandaSelezionata" runat="server"/>
        <asp:HiddenField ID="hdnFascicolo" runat="server" Value="85.30.10/2019/BIT/13" />
        <asp:HiddenField ID="hdnDecertSelezionate" runat="server" />
        <asp:HiddenField ID="hdnTabDecertSelezionate" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click"
                    CausesValidation="false" />
        <asp:Button ID="btnSelezionaDomanda" runat="server" OnClick="btnSelezionaDomanda_Click"
            CausesValidation="false" />
    </div>
    <!-- Testa -->
    <div style="text-align:center;">
        <h1>Certificazione della Spesa</h1>
    </div>
    <div class="dBox">        
        <div class="dSezione">
            <div class="dContenutoFloat">
                <strong>Selezionare il programma:</strong>
                <Siar:ComboZPsr ID="lstPsr" runat="server" AutoPostBack="true"></Siar:ComboZPsr><br /><br />
                <asp:LinkButton ID="btnVisualizza_CreaLotto" runat="server" OnClick="btnVisualizza_CreaLotto_Click">Visualizza crea lotto</asp:LinkButton>
            </div>
        </div>
    </div>
    <!-- Creazione Lotti -->
    <div id="divCreaLotto" class="dBox" style="padding: 15px; min-width: 250px" visible="false" runat="server">
        <strong>Creazione nuovo lotto</strong><br />
        <label for="txtDataInizio" style="white-space: nowrap;">Data Inizio (opzionale)
            <Siar:DateTextBox ID="txtDataInizio" runat="server" Width="104px"/>
        </label>
        <label for="txtDataFine" style="white-space: nowrap;">Data Fine
            <Siar:DateTextBox ID="txtDataFine" runat="server" Width="104px"/>
        </label>
        <label for="ddlTipo" style="white-space: nowrap;">Tipo
            <asp:DropDownList ID="ddlTipo" AutoPostBack="False" runat="server">
                <asp:ListItem Selected="True" Value="I">Intermedio</asp:ListItem>
                <asp:ListItem Value="F">Finale</asp:ListItem>
            </asp:DropDownList>
        </label>
        <Siar:Button ID="btnCreaLotto" runat="server" Text="Crea lotto" Width="140px" 
                     onclick="btnCreaLotto_Click" />
    </div>
    <!-- Lotti -->
    <div id="divTesta" class="dBox" visible="false" runat="server">        
        <div id="divTestaElenco" class="dContenuto" runat="server" visible="false">
            <div style="padding: 15px 7px 15px 5px">
                <input type="button" class="Button" value="Report previsione progetti certificabili" style="width: 250px" onclick="return certificabiliInXls();" />
                <input type="button" class="Button" value="Report importi certificati" style="width: 250px" onclick="return ImportiCertificatiInXls();" />
            </div>

            <div style="padding-bottom: 3px; cursor: pointer; width: 95%;" onclick="MostraNascondiDiv(2); return false;">
                <img id="imgRiepilogoPrevisioneProgettiCertificabili" runat="server" style="width: 23px; height: 23px;" />
                <b>Mostra/nascondi riepilogo previsione progetti certificabili:</b>
                <br />
            </div>

            <div id="divMostraRiepilogoPrevisioneProgettiCertificabili">
                <Siar:DataGrid ID="dgRiepilogoPrevisioneProgettiCertificabili" runat="server" AutoGenerateColumns="false" >
                    <Columns>
                        <asp:BoundColumn DataField="Asse" HeaderText="Asse">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
				        <asp:BoundColumn DataField="DaIstruire" HeaderText="Da istruire" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
				        </asp:BoundColumn>
				        <asp:BoundColumn DataField="DaValidare" HeaderText="Da validare" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
				        </asp:BoundColumn>
				        <asp:BoundColumn DataField="DaCertificare" HeaderText="Da certificare" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
				        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </div>
            <br />

            <Siar:DataGrid ID="dgTesta" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="24px" />
                <Columns>
                    <asp:BoundColumn DataField="Idcertsp" HeaderText="Id Lotto"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Datainizio" HeaderText="Data Inizio"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Datafine" HeaderText="Data Fine"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Tipo" HeaderText="Tipo"></asp:BoundColumn>
                    <Siar:ColonnaLink DataField="Definitivo" HeaderText="Definitivo" IsJavascript="true"
                                      LinkFields="Idcertsp" LinkFormat="selezionaTesta({0});">
                    </Siar:ColonnaLink>
                </Columns>
            </Siar:DataGrid>
        </div>
        <div id="divTestaDati" class="dContenuto" runat="server" visible="false">
        </div>
    </div>
    <!-- Dettaglio -->
    <div id="divDettaglio" class="dBox" visible="false" runat="server">
        <uc2:SiarNewTab ID="tabDettaglio" runat="server" TabNames="Elenco|Dati riassuntivi Lotto|Dati riassuntivi Programma|Dati provvisori Lotto|Dati provvisori Programma|Decertificazioni" Titolo="Certificazione di spesa" />
        <!-- Elenco -->
        <div id="divDettaglioElenco" class="dContenuto" runat="server" visible="false">
            <div class="dContenutoFloat" style="width: 95%">                
                Filtro progetti
                <asp:DropDownList ID="ddlFiltro" AutoPostBack="True" runat="server">
                    <asp:ListItem Selected="True" Value="1">Tutti</asp:ListItem>
                    <asp:ListItem Value="2">Selezionati</asp:ListItem>
                    <asp:ListItem Value="3">Non Selezionati</asp:ListItem>
                    <asp:ListItem Value="4">Con Checklist</asp:ListItem>
                    <asp:ListItem Value="5">Senza Checklist</asp:ListItem>
                </asp:DropDownList>

                
                <Siar:Button ID="btnVisualizza_tstChecklist" runat="server" OnClick="btnVisualizza_tstChecklist_Click" Text="Checklist lotto" Width="100px" />
                <Siar:Button ID="btnCancella" runat="server" OnClick="btnCancella_Click" Text="Cancella lotto" Modifica="True" Width="100px" />
                <Siar:Button ID="btnSalvaElenco" runat="server" OnClick="btnSalvaElenco_Click" Text="Salva" Modifica="true" Width="100px" />
                <input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return estraiInXls(1);" />
                <input type="button" class="Button" value="Estrai Delta in xls" style="width: 140px" onclick="return estraiInXls(2);" />
                <br />
                <br />
                <Siar:Button ID="btnDefinitivo" runat="server" OnClick="btnDefinitivo_Click" Text="Rendi Definitivo" Modifica="True"
                   ToolTip="Rendi il lotto Definitivo." CausesValidation="true" Width="150px" />
                <Siar:TextBox ID="txtSegnaturaCertificazione" runat="server" Width="400px" ReadOnly="True" />
                <img id="imgSegnaturaCertificazione" runat="server" height="20" src="../../images/lente.png" width="20" title="Visualizza documento" style="padding-left:10px;" />
                <br /><br />
                <Siar:Button ID="btnInserisciSegnatura" runat="server" Width="150px" Text="Dichiarazione AdG" OnClick="btnInserisciSegnatura_Click" Modifica="True" />
                <Siar:TextBox ID="txtSegnaturaVerbale" runat="server" Width="400px" ReadOnly="True" />
                <img id="imgSegnaturaVerbale" runat="server" height="20" src="../../images/lente.png" width="20" title="Visualizza documento" style="padding-left:10px;" />
                <br />
                <br />
                <asp:Label ID="lblNrRecordTotale" runat="server" Text="" font-size="Smaller"></asp:Label>
            </div>
            <div id="divCaricaTstCheck" class="dBox" style="padding: 15px; min-width: 500px;" runat="server" visible="false">
                Checklist lotto (per salvare le modifiche cliccare "Salva")
                <uc1:SNCUploadFileControl ID="ufTstChecklist" runat="server" />                
            </div>
            <br />
            <br />

            <div style="padding-bottom: 3px; cursor: pointer; width: 95%;" onclick="MostraNascondiDiv(-1); return false;">
                <img id="imgLegenda" runat="server" style="width: 23px; height: 23px;" />
                <b>Legenda colori:</b>
                <br />

                <div id="divMostraLegenda">
                    <Siar:DataGrid ID="dgLegenda" runat="server" AutoGenerateColumns="False" Width="50%">
                        <Columns>
                            <asp:BoundColumn DataField="Testo" HeaderText="Legenda"></asp:BoundColumn>
                        </Columns>
                    </Siar:DataGrid>
                </div>
            </div>
            <br />
            <br />

            <div style="padding-bottom: 3px; cursor: pointer; width: 95%;" onclick="MostraNascondiDiv(0); return false;">
                <img id="imgDettaglioNuovi" runat="server" style="width: 23px; height: 23px;" />
                <b>Nuovi progetti presenti in certificazione:</b>
            </div>

            <div id="divMostraDettaglioNuovi">
                <asp:Label ID="lblNrRecordNuovi" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                <br />
                <br />

                <Siar:DataGrid ID="dgDettaglioNuovi" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:BoundColumn DataField="Asse" HeaderText="Asse"></asp:BoundColumn>
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
                        <asp:BoundColumn DataField="ImportoAmmesso" HeaderText="Contributo concesso" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoConcesso" HeaderText="Importo rendicontato ammesso (totale periodo contabile)" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoContributoPubblico" HeaderText="Contributo rendicontato concesso (totale periodo contabile)" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="QuotaUe" HeaderText="Ue" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="QuotaStato" HeaderText="Stato" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="QuotaRegione" HeaderText="Regione" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="QuotaPrivato" HeaderText="Quota a carico del privato" DataFormatString="{0:c}" Visible="false"></asp:BoundColumn>
                        <Siar:CheckColumn DataField="IdProgetto" Name="Selezionata" HeaderSelectAll="true"></Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
            </div>
            <br />
            <br />

            <div style="padding-bottom: 3px; cursor: pointer; width: 95%;" onclick="MostraNascondiDiv(1); return false;">
                <img id="imgDettaglio" runat="server" style="width: 23px; height: 23px;" />
                <b>Progetti presenti anche in certificazioni precedenti:</b>
            </div>

            <div id="divMostraDettaglio">
                <asp:Label ID="lblNrRecord" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                <br />
                <br />

                <Siar:DataGrid ID="dgDettaglio" runat="server" AutoGenerateColumns="False" Width="100%"> 
                    <Columns>
                        <asp:BoundColumn DataField="Asse" HeaderText="Asse"></asp:BoundColumn>
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
                        <asp:BoundColumn DataField="ImportoAmmesso" HeaderText="Contributo concesso" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoConcesso" HeaderText="Importo rendicontato ammesso (totale periodo contabile)" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoContributoPubblico" HeaderText="Contributo rendicontato concesso (totale periodo contabile)" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="QuotaUe" HeaderText="Ue" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="QuotaStato" HeaderText="Stato" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="QuotaRegione" HeaderText="Regione" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="QuotaPrivato" HeaderText="Quota a carico del privato" DataFormatString="{0:c}" Visible="false"></asp:BoundColumn>
                        <Siar:CheckColumn DataField="IdProgetto" Name="Selezionata" HeaderSelectAll="true"></Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
            </div>
        </div>

        <!-- Dati riassuntivi Lotto -->
        <div id="divDettaglioDati" class="dContenuto" runat="server" visible="false">
            <h2><asp:Label ID="DatiLotto_Titolo" runat="server"></asp:Label></h2>
            <input type="button" class="Button" value="Estrai in xls 'Dati riassuntivi Lotto'" onclick="return estraiInXlsLotto(1, 0);" />
            <!--Griglia spese -->
            <div class="dContenuto">
                <strong>Spesa suddivisa per priorità e per categoria di regioni, come contabilizzata dall'autorità di certificazione</strong>
                <input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return spesaInXls();" />
                <table id="tblDettaglioDati" width="100%" runat="server">
                <tr class="TESTA1">
                    <th style="text-align:center; min-width:50px;">Asse</th>
                    <th>Base calcolo (solo contributo pubblico o spesa totale compresa quella dei privati o altro pubblico)</th>
                    <th>Importo totale delle spese ammissibili sostenute dai beneficiari e pagate nell'attuazione delle operazioni</th>
                    <th>Importo totale della spesa pubblica relativa all'attuazione delle operazioni</th>
                    <th>Importo totale delle spese ammissibili sostenute dai beneficiari e pagate nell’attuazione delle operazioni – da non certificare</th>
                </tr>
            </table>
            </div>
        </div>
        <!-- Dati rissuntivi programma -->
        <div id="divDettaglioProgramma" class="dContenuto" runat="server" visible="false">
            <h2><asp:Label ID="DatiProgramma_Titolo" runat="server"></asp:Label></h2>
            <input type="button" class="Button" value="Estrai in xls 'Dati riassuntivi Programma'" onclick="return estraiInXlsProgramma(1, 1);" />
            <!--Griglia strumenti finanziari -->
            <div class="dContenuto">
                <strong>Informazioni sugli importi dei contributi per programma erogati agli strumenti finanziari e inclusi nelle domande di pagamento </strong>
                <input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return strumentiFinanziariInXls();" />
                <table id="tblStrumentiFi" width="100%" runat="server">
                    <tr class="TESTA1">
                        <th>&nbsp;</th>
                        <th colspan="2">Importi dei contributi per programma erogati agli strumenti finanziari e inclusi nelle domande di pagamento</th>
                        <th colspan="2">Importi erogati a titolo di spesa ammissibile ai sensi dell'articolo 42, paragrafo 1, lettere a), b) e d), del regolamento (UE) n. 1303/2013</th>
                    </tr>
                    <tr class="TESTA1">
                        <th style="width:10%;">Asse</th>
                        <th style="width:22%;">Importo complessivo dei contributi per programma erogati agli strumenti finanziari</th>
                        <th style="width:22%;">Importo della spesa pubblica corrispondente</th>
                        <th style="width:22%;">Importo complessivo dei contributi del programma effettivamente erogati o, nel caso delle garanzie, impegnati a titolo di spesa ammissibile ai sensi dell'articolo 42, paragrafo 1, lettere a), b) e d), del regolamento (UE) n. 1303/2013</th>
                        <th style="width:22%;">Importo della spesa pubblica corrispondente</th>
                    </tr>
                </table>
            </div>
            <!--Griglia anticipi -->
            <div class="dContenuto">
                <strong>Anticipi versati nel quadro di aiuti di Stato </strong>
                <input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return anticipiInXls();" />
                <table id="tblAnticipi" width="100%" runat="server">
                    <tr class="TESTA1">
                        <th style="width:10%;">Asse</th>
                        <th style="width:30%;">Importo complessivo versato come anticipo dal programma operativo</th>
                        <th style="width:30%;">Importo che è stato coperto dalle spese sostenute dai beneficiari entro tre anni dal pagamento dell'anticipo</th>
                        <th style="width:30%;">Importo che non è stato coperto dalle spese sostenute dai beneficiari e per il quale il periodo di tre anni non è ancora trascorso</th>
                    </tr>
                </table>
            </div>
            <!--Griglia spese complessive-->
            <div class="dContenuto">
                <strong>Spesa complessiva suddivisa per priorità e per categoria di regioni, come contabilizzata dall'autorità di certificazione</strong>
                <input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return spesaInXls(true);" />
                <table id="tblDettaglioDatiComplessivi" width="100%" runat="server">
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
        <!-- Dati provvisori Lotto -->
        <div id="divDettaglioDatiProvv" class="dContenuto" runat="server" visible="false">
            <h2><asp:Label ID="DatiLottoProvv_Titolo" runat="server"></asp:Label></h2>
            <input type="button" class="Button" value="Estrai in xls 'Dati provvisori Lotto'" onclick="return estraiInXlsLotto(0, 0);" />
            <!--Griglia spese -->
            <div class="dContenuto">
                <strong>Spesa suddivisa per priorità e per categoria di regioni, come contabilizzata dall'autorità di certificazione</strong>
                <!-- input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return spesaInXls();" /-->
                <table id="tblDettaglioDatiProvv" width="100%" runat="server">
                <tr class="TESTA1">
                    <th style="text-align:center; min-width:50px;">Asse</th>
                    <th>Base calcolo (solo contributo pubblico o spesa totale compresa quella dei privati o altro pubblico)</th>
                    <th>Importo totale delle spese ammissibili sostenute dai beneficiari e pagate nell'attuazione delle operazioni</th>
                    <th>Importo totale della spesa pubblica relativa all'attuazione delle operazioni</th>
                    <th>Importo totale delle spese ammissibili sostenute dai beneficiari e pagate nell’attuazione delle operazioni – da non certificare</th>
                </tr>
            </table>
            </div>
        </div>
        <!-- Dati provvisori programma -->
        <div id="divDettaglioProgrammaProvv" class="dContenuto" runat="server" visible="false">
            <h2><asp:Label ID="DatiProgrammaProvv_Titolo" runat="server"></asp:Label></h2>
            <input type="button" class="Button" value="Estrai in xls 'Dati provvisori Programma'" onclick="return estraiInXlsProgramma(0, 1);" />
            <!--Griglia strumenti finanziari -->
            <div class="dContenuto">
                <strong>Informazioni sugli importi dei contributi per programma erogati agli strumenti finanziari e inclusi nelle domande di pagamento </strong>
                <!-- input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return strumentiFinanziariInXls();" /-->
                <table id="tblStrumentiFiProvv" width="100%" runat="server">
                    <tr class="TESTA1">
                        <th>&nbsp;</th>
                        <th colspan="2">Importi dei contributi per programma erogati agli strumenti finanziari e inclusi nelle domande di pagamento</th>
                        <th colspan="2">Importi erogati a titolo di spesa ammissibile ai sensi dell'articolo 42, paragrafo 1, lettere a), b) e d), del regolamento (UE) n. 1303/2013</th>
                    </tr>
                    <tr class="TESTA1">
                        <th style="width:10%;">Asse</th>
                        <th style="width:22%;">Importo complessivo dei contributi per programma erogati agli strumenti finanziari</th>
                        <th style="width:22%;">Importo della spesa pubblica corrispondente</th>
                        <th style="width:22%;">Importo complessivo dei contributi del programma effettivamente erogati o, nel caso delle garanzie, impegnati a titolo di spesa ammissibile ai sensi dell'articolo 42, paragrafo 1, lettere a), b) e d), del regolamento (UE) n. 1303/2013</th>
                        <th style="width:22%;">Importo della spesa pubblica corrispondente</th>
                    </tr>
                </table>
            </div>
            <!--Griglia anticipi -->
            <div class="dContenuto">
                <strong>Anticipi versati nel quadro di aiuti di Stato </strong>
                <!--input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return anticipiInXls();" /-->
                <table id="tblAnticipiProvv" width="100%" runat="server">
                    <tr class="TESTA1">
                        <th style="width:10%;">Asse</th>
                        <th style="width:30%;">Importo complessivo versato come anticipo dal programma operativo</th>
                        <th style="width:30%;">Importo che è stato coperto dalle spese sostenute dai beneficiari entro tre anni dal pagamento dell'anticipo</th>
                        <th style="width:30%;">Importo che non è stato coperto dalle spese sostenute dai beneficiari e per il quale il periodo di tre anni non è ancora trascorso</th>
                    </tr>
                </table>
            </div>
            <!--Griglia spese complessive -->
            <div class="dContenuto">
                <strong>Spesa complessiva suddivisa per priorità e per categoria di regioni, come contabilizzata dall'autorità di certificazione</strong>
                <!-- input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return spesaInXls(true);" /-->
                <table id="tblDettaglioDatiComplessiviProvv" width="100%" runat="server">
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

        <!-- Decertificazioni -->
		<div id="divTabDecertificazioni" class="dContenuto" runat="server" visible="false">
            <p>
                Nell'elenco vengono mostrati i progetti non presenti nel lotto selezionato con irregolarità, errori o rinunce con azione "ritiro".<br />
                Selezionare e salvare una decertificazione permette la decertificazione dei progetti creando una "riga negativa".<br />
            </p>
            <br />
            <br />

			<asp:Label ID="lblTabDecertificazioni" Text="Nessuna decertificazione trovata da associare in questa Certificazione di spesa." Font-Size="Small" runat="server"></asp:Label>
            <br />

            <div id="divContenutoTabDecert" runat="server">
                <Siar:DataGrid ID="dgTabDecertificazioni" runat="server"  AutoGenerateColumns="false">
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
                </Siar:DataGrid><br />
                <Siar:Button ID="btnSalvaTabDecert" runat="server" Text="Salva Decertificazioni" OnClientClick="GetTabDecertSelezionati()" OnClick="btnSalvaTabDecert_Click" Modifica="true" />
            </div>
		</div>
    </div>
    <!-- Singola domanda -->
    <div id="divSingolo" class="dBox" visible="false" runat="server">
        <div class="dSezione">
            <div class="dContenuto">
                <asp:Label Text="Selezionare una domanda per associare una o più decertificazioni" Font-Size="Smaller" runat="server"></asp:Label>
                <Siar:DataGrid ID="dgSingolo" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Id Domanda"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Tipodomanda" HeaderText="Tipo Domanda"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoConcesso" HeaderText="Importo rendicontato ammesso (totale periodo contabile)" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoContributoPubblico" HeaderText="Contributo rendicontato concesso (totale periodo contabile)" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="SpesaAmmessa" HeaderText="Importo rendicontato ammesso (delta riferito allo specifico lotto)" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoContributoPubblicoIncrementale" HeaderText="Contributo rendicontato concesso (delta riferito allo specifico lotto)" DataFormatString="{0:c}"></asp:BoundColumn>                        
                        <Siar:JsButtonColumn ButtonText="Decertifica" JsFunction="selezionaDomanda" Arguments="IdDomandaPagamento"></Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
            </div>
            <div id="divDecertificazioni" runat="server" visible="false" class="dContenuto">
                <Siar:DataGrid ID="dgDecertificazioni" runat="server" AutoGenerateColumns="False" Width="80%">
                    <Columns>
                        <asp:BoundColumn DataField="IdDecertificazione" HeaderText="Id Decertificazione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoDecertificazione" HeaderText="Tipo Decertificazione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoDecertificazioneAmmesso" HeaderText="Importo Decertificazione Ammesso" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoDecertificazioneConcesso" HeaderText="Importo Decertificazione Concesso" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DataConstatazioneAmministrativa" HeaderText="Data Rilevazione"></asp:BoundColumn>
                        <Siar:CheckColumn DataField="Assegnata">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </Siar:CheckColumn>
                        <asp:BoundColumn DataField="IdCertDecertificazione" HeaderText="Id Decertificazione">
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
                <br />
                <asp:Label ID="lblNessunaDecert" Text="Nessuna decertificazione trovata per questo progetto" Font-Size="Small" runat="server" Visible="false"/>
                <br />
                <Siar:Button ID="btnSalvaDecertificazioni" runat="server" OnClientClick="GetDecertSelezionati()" OnClick="btnSalvaDecertificazioni_Click" Text="Salva Decertificazioni" Modifica="true" />
                <Siar:Button ID="btnIndietroDecertificazioni" runat="server" OnClick="btnIndietroDecertificazioni_Click" Text="Indietro" Modifica="true" />
            </div>
            <div class="dContenuto">
                <div class="dContenutoFloat">
                    <label for="txtDataInizio" style="white-space: nowrap;">Note</label><br />
                    <asp:TextBox ID="NoteDomanda" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="dContenuto">
                    Checklist domanda (per salvare le modifiche cliccare "Salva Domanda")
                    <uc1:SNCUploadFileControl ID="ufDetChecklist" runat="server" />
                </div>
            </div>
            <div class="dContenuto">
                <Siar:Button ID="btnSalvaSingolo" runat="server" OnClick="btnSalvaSingolo_Click" Text="Salva Domanda" Modifica="true" Width="100px" />
            </div>
        </div>
    </div>    
    <!-- Segnatura -->
    <div id='divSegnatura' style="width: 725px; position: absolute; display:none;">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">
                    Dati della segnatura del verbale:
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                           <td style="width: 140px">
								Data:<br />
								<Siar:DateTextBox ID="txtData" runat="server" Width="120px" />
							</td>
							<td style="width: 440px">
								Segnatura:<br />
								<asp:TextBox ID="txtSegnatura" runat="server" Width="400px"  />
								<img id="imgSegnatura" runat="server" height="18" src="../../images/lente.png"
									title="Visualizza documento" width="18" />
							</td>
                        </tr>
                        <tr > 
                            <td align="right" style="height: 70px; " colspan="2">
                                <Siar:Button ID="btnSalvaSegnatura" runat="server" Modifica="true" OnClick="btnSalvaSegnatura_Click"
                                    Text="Salva"  Width="100px" CausesValidation="False"/>
                                <input class="Button" onclick="chiudiPopupTemplate();" style="width: 100px; margin-left: 20px;
                                    margin-right: 20px" type="button" value="Chiudi" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <uc3:FirmaDocumento ID="ucFirmaDocumento" runat="server" Titolo="Firma Comunicazione Certificazione" TipoDocumento="COMUNICAZIONE_CERTIFICAZIONE" />
</asp:Content>