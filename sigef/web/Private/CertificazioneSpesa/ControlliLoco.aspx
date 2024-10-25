<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
         CodeBehind="ControlliLoco.aspx.cs" Inherits="web.Private.CertificazioneSpesa.ControlliLoco" %>
<%@ Register Src="~/CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>

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
    </style>

    <script type="text/javascript">
            function selezionaDettaglio(idDett) {
                $('[id$=hdnIdLocoDett]').val($('[id$=hdnIdLocoDett]').val() == idDett ? '' : idDett);
                $('[id$=btnProgrammazionePost]').click();
            }
        function selezionaTesta(idLoco) {
                $('[id$=hdnIdLoco]').val($('[id$=hdnIdLoco]').val() == idLoco ? '' : idLoco);
                $('[id$=btnProgrammazionePost]').click();
            }
            function selezionaProgetto(idProgetto) {
                $('[id$=hdnIdProgetto]').val($('[id$=hdnIdProgetto]').val() == idProgetto ? '' : idProgetto);
                $('[id$=btnProgrammazionePost]').click();
            }
            function estraiInXls() {
                var idLoco = $('[id$=hdnIdLoco]').val(), filtroDomande = $('[id$=hdnDdlFiltro]').val();

                if (idLoco == null || idLoco == '')
                    alert("Specificare il lotto prima di estrarre.");
                else if (filtroDomande == null || filtroDomande == '' || (Number(filtroDomande) < 1 && Number(filtroDomande) > 7))
                    alert("Specificare il filtro prima di estrarre.");
                else {
                    var parametri = "IdLoco=" + idLoco + "|FiltroDomande=" + filtroDomande;
                    SNCVisualizzaReport('rptCntrLocoDettaglio', 2, parametri);
                }
            }
            function anomalieInXls() {
                SNCVisualizzaReport('rptCertificazioneAnomalieQuietanza', 2, '');
        }

        $(document).ready(function() {
            $(document).on("click", ".SNTUnselected", function () {
               creaProgress();
            });
        });

        function creaProgress()
        {
            disabilitaScroll();
            scrollLeft = (document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft);
            scrollTop = (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);
            clientWidth = Math.min((window.innerWidth ? window.innerWidth : 100000), document.documentElement.clientWidth);
            clientHeight = Math.min((window.innerHeight ? window.innerHeight : 100000), document.documentElement.clientHeight);
            if (!ajax_progress_bgdiv) {
                ajax_progress_bgdiv = document.createElement('div');
                document.body.appendChild(ajax_progress_bgdiv);
            }
            $(ajax_progress_bgdiv).show().css({
                'width': clientWidth,
                'height': clientHeight,
                'left': scrollLeft,
                'top': scrollTop
            });
            if (!ajax_progress_textdiv) {
                ajax_progress_textdiv = document.createElement('div');
                document.body.appendChild(ajax_progress_textdiv);
            }
            $(ajax_progress_textdiv).css({
                'position': 'absolute',
                'box-shadow': '4px 4px 4px #333333'
            }).html('<div id="tbUpdateProgressText" align="center" valign="middle" style="padding-top:20px; height: 100px; background-color: white; border: black 1px solid;width:300px">'+
                '<div style = " width:77px;" >' +
                ' <img src="' + getBaseUrl() + 'images/ajaxroller.gif" /></div >' +
                '<br><div  style="font-weight:bold;">Operazione in corso...</div></div >');
            $(ajax_progress_textdiv).show().css({
                'left': scrollLeft + ((clientWidth - 300) / 2),
                'top': scrollTop + ((clientHeight - 100) / 2)
            });
            
        }  

        function disabilitaScroll() {
            $('html').css({
                'overflow': 'hidden'
            });
        }

        function abilitaScroll() {
            $('html').css({
                'overflow': 'auto'
            });
        }
        var ajax_progress_bgdiv;
        function mostraDivEscludi(id) {
            disabilitaScroll();
            scrollLeft = (document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft);
            scrollTop = (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);
            clientWidth = Math.min((window.innerWidth ? window.innerWidth : 100000), document.documentElement.clientWidth);
            clientHeight = Math.min((window.innerHeight ? window.innerHeight : 100000), document.documentElement.clientHeight);
            if (!ajax_progress_bgdiv) {
                ajax_progress_bgdiv = document.createElement('div');
                document.body.appendChild(ajax_progress_bgdiv);
            }
            $(ajax_progress_bgdiv).show().css({
                'width': clientWidth,
                'height': clientHeight,
                'left': scrollLeft,
                'top': scrollTop
            });
            var divModale = $('[id$=idModaleEscludi]');
            divModale.css({
                'display': 'block',
                'left': scrollLeft + ((clientWidth - 300) / 2),
                'top': scrollTop + ((clientHeight-300) / 2),
                'z-index':1
            });
            $('[id$=hdnIdDomandaDaEscludere]').val(id);
            $('[id$=lblDettagliDomanda]').html(id);
            
        }

        function chiudiModaleEscludi() {
            $(ajax_progress_bgdiv).css({
                'display':'none'
            });
            $('[id$=idModaleEscludi]').css({
                'display':'none'
            });
            abilitaScroll();
        }

        function ValidaMotivoEsclusione() {
            var textArea = $('[id$=txtMotivoEsclusione]').val();
            if (textArea == null || textArea == "") {
                alert("Inserire un motivo per l'esclusione");
                return false;
            }
            return true;
        }
    </script>  
    <div style="display: none">
        <asp:HiddenField ID="hdnIdLoco" runat="server" />
        <asp:HiddenField ID="hdnIdLocoDett" runat="server" />
        <asp:HiddenField ID="hdnCreaLotto" runat="server" />
        <asp:HiddenField ID="hdnIdProgetto" runat="server" />
        <asp:HiddenField ID="hdnCodPsr" runat="server" />
        <asp:HiddenField ID="hdnDdlFiltro" runat="server" />
        <asp:HiddenField ID="hdnIdDomandaDaEscludere" runat="server" />
        <asp:Button ID="btnProgrammazionePost" runat="server" OnClick="btnProgrammazionePost_Click"
                    CausesValidation="false" /> 
    </div>
    
    <div class="dBox" id="idModaleEscludi" runat="server" style="width:400px; position:absolute; padding-bottom:20px; text-align:center; display:none;">
        <div class="separatore">
            Esclusione Progetto
        </div>
        <div style="padding-top: 20px;">
            <strong>Domanda di aiuto:</strong>
            <div style="display:inline-block" id="lblDettagliDomanda"></div>
        </div>
        <div style="padding-top: 20px;">
            Specificare il motivo di esclusione (Max 50 caratteri)<br />
            <Siar:TextArea Width="300px" Rows="4" ID ="txtMotivoEsclusione" MaxLength="50" runat="server" Style="padding-top: 5px;"  />
        </div>
        <div style="padding-top: 20px; text-align:center;">
            <Siar:Button ID="btnEscludi" OnClick="btnEscludi_Click" OnClientClick="if(!ValidaMotivoEsclusione()) {return false};" runat="server" Text="Escludi Domanda" Width="150px" />
            <input type="button" class="Button" id="btnAnnullaMod" onclick="chiudiModaleEscludi(); return false;" value="Annulla" />
        </div>
    </div>

    <!-- Testa -->
    <div style="text-align:center;">
        <h1>Validazione 1&deg; livello - Controlli in loco</h1>
    </div>
    <div class="dBox">
        <div class="dSezione">
            <div class="dContenutoFloat">
                <strong>Selezionare il programma:</strong>
                <Siar:ComboZPsr ID="lstPsr" runat="server" AutoPostBack="true" style="margin-right: 50px;"></Siar:ComboZPsr>
                <input type="button" class="Button" value="Report anomalie" style="width: 140px;" onclick="return anomalieInXls();" />
            </div>               
        </div>
        <div class="dSezione">
            <div class="dContenutoFloat">
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
        <Siar:Button ID="btnCreaLotto" runat="server" Text="Crea lotto" Width="140px" 
                     OnClick="btnCreaLotto_Click" />
    </div>
    <!-- Lotti -->
    <div class="dBox" visible="false">
        <div id="divTesta" class="dContenuto" runat="server">
            <Siar:DataGrid ID="dgTesta" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="24px" />
                <Columns>
                    <asp:BoundColumn DataField="IdLoco" HeaderText="Id Loco"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DataInizio" HeaderText="Data Inizio"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DataFine" HeaderText="Data Fine"></asp:BoundColumn>
                    <Siar:ColonnaLink DataField="Definitivo" HeaderText="Definitivo" IsJavascript="true"
                                      LinkFields="Idloco" LinkFormat="selezionaTesta({0});">
                    </Siar:ColonnaLink>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>
    <!-- Dettagli -->
    <div id="divDettaglio" class="dBox" visible="false" runat="server">
        <uc1:SiarNewTab ID="tabDettaglio" runat="server" TabNames="Elenco|Dati riassuntivi" Titolo="Domande di pagamento" />
        <!-- Elenco progetti -->
        <div id="divDettaglioElenco" class="dContenuto" runat="server" visible="false">
            <div class="dContenutoFloat">
                Filtro domande
                <asp:DropDownList ID="ddlFiltro" AutoPostBack="True" runat="server">
                    <asp:ListItem Selected="True" Value="1">Tutte</asp:ListItem>
                    <asp:ListItem Value="2">Incluse</asp:ListItem>
                    <asp:ListItem Value="3">Escluse</asp:ListItem>
                    <asp:ListItem Value="4">Rischio Alto</asp:ListItem>
                    <asp:ListItem Value="5">Rischio Medio</asp:ListItem>
                    <asp:ListItem Value="6">Rischio Basso</asp:ListItem>
                    <asp:ListItem Value="7">Selezionate</asp:ListItem>
                </asp:DropDownList>
                <Siar:Button ID="btnSelezionaAuto" runat="server" OnClick="btnSelezionaAuto_Click" Text="Seleziona per controllo" Modifica="True" 
                             ToolTip="Seleziona automaticamente le domande da sottoporre a controllo" Width="200px" />
                <Siar:Button ID="btnInserisciSegnatura" runat="server" Width="180px" Text="Inserisci Segnatura"  OnClick="btnInserisciSegnatura_Click" Modifica="True" />
                <Siar:Button ID="btnDefinitivo" runat="server" OnClick="btnDefinitivo_Click" Text="Rendi Definitivo" Modifica="True" 
                             ToolTip="Rendi il lotto Definitivo." CausesValidation="true" Width="100px" />
                <Siar:Button ID="btnCancella" runat="server" OnClick="btnCancella_Click" Text="Cancella lotto" Modifica="True" Width="100px" OnClientClick="return confirm('Sei sicuro di voler eliminare il lotto?')" />
                <input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return estraiInXls();" />
                <Siar:TextBox ID="txtSegnaturaVerbale" runat="server" Width="400px" ReadOnly="True" />
                <img id="imgSegnaturaVerbale" runat="server" height="20" src="../../images/lente.png" width="20" title="Visualizza documento"  />
                <br />
                <asp:Label ID="lblNrRecord" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            </div>
            <Siar:DataGrid ID="dgDettaglio" runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id Progetto"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Beneficiario" HeaderText="Beneficiario"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Asse" HeaderText="Asse"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Azione" HeaderText="Azione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Intervento" HeaderText="Intervento"></asp:BoundColumn>
                    <asp:BoundColumn DataField="NrOperazioniB" HeaderText="Nr. Operazioni Benef."></asp:BoundColumn>
                    <asp:BoundColumn DataField="SpesaAmmessaIncrementale" HeaderText="Costo investimento richiesto" DataFormatString="{0:c}"></asp:BoundColumn>
                    <Siar:ColonnaLink DataField="CostoTotale" HeaderText="Costo investimento ammesso" DataFormatString="{0:c}"  IsJavascript="true"
                                      LinkFields="IdProgetto" LinkFormat="selezionaProgetto({0});">
                    </Siar:ColonnaLink>
                    <asp:BoundColumn DataField="ImportoAmmesso" HeaderText="Contributo concesso" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoConcesso" HeaderText="Importo rendicontato ammesso (totale incrementale)" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoContributoPubblico" HeaderText="Contributo rendicontato concesso (totale incrementale)" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="SpesaAmmessa" HeaderText="Importo rendicontato ammesso (delta riferito allo specifico lotto)" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoContributoPubblicoIncrementale" HeaderText="Contributo rendicontato concesso (delta riferito allo specifico lotto)" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoConcesso" HeaderText="Importo rendicontato ammesso - ritiro / recupero(totale incrementale)" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoContributoPubblico" HeaderText="Contributo rendicontato concesso - ritiro / recupero (totale incrementale)" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="SpesaAmmessa" HeaderText="Importo rendicontato ammesso - ritiro / recupero (delta riferito allo specifico lotto)" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoContributoPubblicoIncrementale" HeaderText="Contributo rendicontato concesso - ritiro / recupero (delta riferito allo specifico lotto)" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Selezionata" HeaderText="Selez. per controllo"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Esclusione" HeaderText="Esclusione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="RischioIR" HeaderText="Rischio IR"></asp:BoundColumn>
                    <asp:BoundColumn DataField="RischioCR" HeaderText="Rischio CR"></asp:BoundColumn>
                    <asp:BoundColumn DataField="RischioComp" HeaderText="Rischio Complessivo"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Escludi da Selezione per Controllo">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
        <!-- Dati riassuntivi -->
        <div id="divDettaglioDati" class="dContenuto" runat="server" visible="false">
            <!-- Somma colonne -->
            <div class="dContenuto">
                <Siar:DataGrid ID="dgDettaglioDati" runat="server" AutoGenerateColumns="false" Width="100%">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <asp:BoundColumn DataField="Descrizione" HeaderText=""></asp:BoundColumn>
                        <asp:BoundColumn DataField="Tutte" HeaderText="Tutte">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Incluse" HeaderText="Incluse">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Escluse" HeaderText="Escluse">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Alto" HeaderText="Alto">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Medio" HeaderText="Medio" >
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Basso" HeaderText="Basso">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </div>
            <!-- Calcolo percentuali -->
            <div class="dContenuto">
                <Siar:DataGrid ID="dgPercentuali" runat="server" AutoGenerateColumns="false" Width="100%">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Importo rendicontato ammesso (delta riferito allo specifico lotto)"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Teorico" HeaderText="Teorico">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Selezionato" HeaderText="Selezionato">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Definitivo" HeaderText="Definitivo">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </div>
        </div>
    </div>
    <!-- Domande di un progetto -->
    <div id="divSingolo" class="dBox" visible="false" runat="server">
        <div class="dSezione">
            <div class="dContenuto">
                <Siar:DataGrid ID="dgSingolo" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Id Domanda"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Titoloprogetto" HeaderText="Titolo progetto"></asp:BoundColumn>                        
                        <asp:BoundColumn DataField="CodiceCup" HeaderText="Codice Cup"></asp:BoundColumn>
                        <asp:BoundColumn DataField="CupNaturaDescrizione" HeaderText="Natura Cup"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Tipodomanda" HeaderText="Tipo Domanda"></asp:BoundColumn>
                        <asp:BoundColumn DataField="CostoTotale" HeaderText="Costo investimento ammesso" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoConcesso" HeaderText="Importo rendicontato ammesso (totale incrementale)" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoContributoPubblico" HeaderText="Contributo rendicontato concesso (totale incrementale)" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="SpesaAmmessa" HeaderText="Importo rendicontato ammesso (delta riferito allo specifico lotto)" DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoContributoPubblicoIncrementale" HeaderText="Contributo rendicontato concesso (delta riferito allo specifico lotto)" DataFormatString="{0:c}"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
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
</asp:Content>