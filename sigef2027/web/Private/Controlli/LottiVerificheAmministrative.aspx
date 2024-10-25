<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="LottiVerificheAmministrative.aspx.cs" Inherits="web.Private.Controlli.LottiVerificheAmministrative" %>

<%@ Register Src="~/CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">

        function selezionaDettaglio(idDett) {
            $('[id$=hdnIdLottoDett]').val($('[id$=hdnIdLottoDett]').val() == idDett ? '' : idDett);
            $('[id$=btnProgrammazionePost]').click();
        }

        function selezionaTesta(idLotto) {
            $('[id$=hdnIdLotto]').val($('[id$=hdnIdLotto]').val() == idLotto ? '' : idLotto);
            $('[id$=btnProgrammazionePost]').click();
        }

        function selezionaProgetto(idProgetto) {
            $('[id$=hdnIdProgetto]').val($('[id$=hdnIdProgetto]').val() == idProgetto ? '' : idProgetto);
            $('[id$=btnProgrammazionePost]').click();
        }

        $(document).ready(function () {
            $(document).on("click", ".SNTUnselected", function () {
                creaProgress();
            });
        });

        function creaProgress() {
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
            }).html('<div id="tbUpdateProgressText" align="center" valign="middle" style="padding-top:20px; height: 100px; background-color: white; border: black 1px solid;width:300px">' +
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
                'top': scrollTop + ((clientHeight - 300) / 2),
                'z-index': 1
            });
            $('[id$=hdnIdDomandaDaEscludere]').val(id);
            $('[id$=lblDettagliDomanda]').html(id);

        }

        function chiudiModaleEscludi() {
            $(ajax_progress_bgdiv).css({
                'display': 'none'
            });
            $('[id$=idModaleEscludi]').css({
                'display': 'none'
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
        <asp:HiddenField ID="hdnIdLotto" runat="server" />
        <asp:HiddenField ID="hdnIdLottoDett" runat="server" />
        <asp:HiddenField ID="hdnCreaLotto" runat="server" />
        <asp:HiddenField ID="hdnIdProgetto" runat="server" />
        <asp:HiddenField ID="hdnCodPsr" runat="server" />
        <asp:HiddenField ID="hdnDdlFiltro" runat="server" />
        <asp:HiddenField ID="hdnIdDomandaDaEscludere" runat="server" />
        <asp:Button ID="btnProgrammazionePost" runat="server" OnClick="btnProgrammazionePost_Click" CausesValidation="false" />
    </div>
  
    <div class="container-fluid shadow bd-form rounded-3 py-4">
        <!-- Titolo, selezione programma e creazione lotto -->
        <h2 class="py-2">Lotti verifiche amministrative</h2>
        <div class="row align-items-center py-4 mr-1">
            <div class="col-sm-4">                
                <Siar:ComboZPsr ID="lstPsr" Label="Selezionare il programma" runat="server" AutoPostBack="true"></Siar:ComboZPsr>
            </div>
            <div class="col-sm-2 ">
                <%--<input type="button" class="btn btn-secondary" value="Report anomalie" onclick="return anomalieInXls();" />--%>
                <button type="button" id="btnVisualizza_CreaLotto" class="btn btn-primary py-1" data-bs-toggle="modal" data-bs-target="#divCreaLotto">Crea lotto</button>
            </div>
        </div>
    
    </div>
     <!-- Modal Crea Lotto -->
    <div class="modal fade" tabindex="-1" role="dialog" id="divCreaLotto" aria-labelledby="Crea Lotto">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title h5" id="modalCreaLotto">Creazione nuovo lotto</h4>
                    <button class="btn-close" type="button" data-bs-dismiss="modal" aria-label="Chiudi finestra modale">
                        <svg class="icon">
                        </svg>
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
                        <div>
                            <%--<label class="active" for="txtDataFine">Data Fine </label>
                            <asp:TextBox CssClass="rounded" ID="txtDataFine" TextMode="Date" runat="server"></asp:TextBox>--%>
                            <Siar:DateTextBoxAgid ID="txtDataFine" Label="Data fine lotto" runat="server" />
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <Siar:Button ID="btnCreaLotto" runat="server" Text="Crea lotto" data-bs-dismiss="modal" OnClick="btnCreaLotto_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Lotti -->
    <div id="divTesta" class="row pt-5 mr-1" visible="false" runat="server"> 
        <div id="divTestaElenco" class="col-12" runat="server" visible="true">
            <Siar:DataGridAgid ID="dgTesta" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                <ItemStyle Height="24px" />
                <Columns>
                    <asp:BoundColumn DataField="IdLotto" HeaderText="Id Lotto"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DataInizio" HeaderText="Data Inizio"></asp:BoundColumn>
                    <Siar:ColonnaLink DataField="DataFine" HeaderText="DataFine" IsJavascript="true"
                        LinkFields="IdLotto" LinkFormat="selezionaTesta({0});">
                    </Siar:ColonnaLink>
                    <asp:BoundColumn DataField="Definitivo" HeaderText="Definitivo"></asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>

    <!-- Dettagli -->
    <div id="divDettaglio" class="row mx-0 bd-form" visible="false" runat="server">
        <uc1:SiarNewTab ID="tabDettaglio" runat="server" TabNames="Elenco|Dati riassuntivi" Titolo="Domande di pagamento" />
        <!-- Elenco progetti -->
        <div id="divDettaglioElenco" class="tableTab" runat="server" visible="false">
          <div class="d-flex flex-row justify-content-start align-items-center py-3">
              <div class="d-grid gap-2 d-md-block align-content-center">
                  
                  <label class="active" for="<% =ddlFiltro.ClientID %>">Filtro domande</label>
                  <asp:DropDownList CssClass="form-group" ID="ddlFiltro" AutoPostBack="True" runat="server">
                      <asp:ListItem Selected="True" Value="1">Tutte</asp:ListItem>
                      <asp:ListItem Value="2">Incluse</asp:ListItem>
                      <asp:ListItem Value="3">Escluse</asp:ListItem>
                      <asp:ListItem Value="4">Sempre a controllo</asp:ListItem>
                      <asp:ListItem Value="5">Rischio Alto</asp:ListItem>
                      <asp:ListItem Value="6">Rischio Medio</asp:ListItem>
                      <asp:ListItem Value="7">Rischio Basso</asp:ListItem>
                      <asp:ListItem Value="8">Selezionate</asp:ListItem>
                  </asp:DropDownList>

                  <Siar:Button ID="btnSelezionaAuto" runat="server" OnClick="btnSelezionaAuto_Click" Text="Seleziona per controllo" Modifica="True"
                      ToolTip="Seleziona automaticamente le domande da sottoporre a controllo" />

                  <Siar:Button ID="btnInserisciSegnatura" runat="server" Text="Inserisci Segnatura" OnClick="btnInserisciSegnatura_Click" Modifica="True" />
                  <%--<button type="button" id="btnInserisciSegnatura" runat="server" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#divSegnatura">Inserisci Segnatura</button>--%>
                 
                  <Siar:Button ID="btnDefinitivo" runat="server" OnClick="btnDefinitivo_Click" Text="Rendi Definitivo" Modifica="True"
                      ToolTip="Rendi il lotto Definitivo." CausesValidation="true" />

                  <Siar:Button ID="btnCancella" runat="server" OnClick="btnCancella_Click" Text="Cancella lotto" Modifica="True" OnClientClick="return confirm('Sei sicuro di voler eliminare il lotto delle verifiche amministrative e delle verifiche in loco?')" />
                  <%--<input type="button" class="btn btn-secondary py-1" value="Estrai in xls" onclick="return estraiInXls();" />--%>

                  <label style="white-space: nowrap;">
                      <Siar:TextBox  ID="txtSegnaturaVerbale" Width="300px" runat="server" ReadOnly="True" />
                      <img id="imgSegnaturaVerbale" runat="server" height="20" src="../../images/lente.png" width="20" title="Visualizza documento" />
                  </label>


              </div>
            </div>
            <div class="row justify-content-start align-content-start">
                <div class="col-sm">
                    <asp:Label ID="lblNrRecord" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="table-responsive">
                    <Siar:DataGridAgid ID="dgDettaglio" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                        <HeaderStyle CssClass="headerStyle-small" />
                        <ItemStyle CssClass="DataGridRow itemStyle-small" />
                        <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle-small" />
                        <Columns>
                            <asp:BoundColumn  DataField="IdProgetto" HeaderText="Id Progetto"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="Beneficiario" HeaderText="Beneficiario"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="Asse" HeaderText="Asse"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="ObiettivoSpecifico" HeaderText="Obiettivo Specifico"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="Azione" HeaderText="Azione"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="Intervento" HeaderText="Intervento"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="NrOperazioniB" HeaderText="Nr. Operazioni Benef."></asp:BoundColumn>
                            <asp:BoundColumn  DataField="SpesaAmmessaIncrementale" HeaderText="Costo investimento richiesto" DataFormatString="{0:c}"></asp:BoundColumn>
                            <Siar:ColonnaLink DataField="CostoTotale" HeaderText="Costo investimento ammesso" DataFormatString="{0:c}" IsJavascript="true"
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
                            <asp:BoundColumn DataField="RischioComplessivo" HeaderText="Rischio Complessivo"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Escludi da Selezione per Controllo">
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
          
        </div>
    
        <!-- Dati riassuntivi -->
        <div id="divDettaglioDati" class="tableTab" runat="server" visible="false">
            <!-- Somma colonne -->
            <div class="row align-items-center">
                <div class="table-responsive">
                <Siar:DataGridAgid ID="dgDettaglioDati" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                     <HeaderStyle CssClass="headerStyle" />
                     <ItemStyle CssClass="DataGridRow itemStyle" />
                     <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                    <Columns>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="">
                                <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
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
                        <asp:BoundColumn DataField="Medio" HeaderText="Medio">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Basso" HeaderText="Basso">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
               </div>
            </div>

            <!-- Calcolo percentuali -->
            <div class="row align-items-center">
                <div class="col-sm-12">
                    <Siar:DataGridAgid ID="dgPercentuali" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemStyle CssClass="DataGridRow itemStyle" />
                        <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                        <Columns>
                            <asp:BoundColumn DataField="Descrizione" HeaderText="Importo rendicontato ammesso (delta riferito allo specifico lotto)">
                                  <ItemStyle HorizontalAlign="Left" />                                  
                            </asp:BoundColumn>
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
                    </Siar:DataGridAgid>
                </div>
            </div>
        </div>
    </div>

    <!-- Domande di un progetto -->
    <div id="divSingolo" class="row pt-5" visible="false" runat="server">
        <div class="col-12">
            <Siar:DataGridAgid ID="dgSingolo" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-sm" PageSize="20">
                  <HeaderStyle CssClass="headerStyle" />
                        <ItemStyle CssClass="DataGridRow itemStyle" />
                        <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
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
            </Siar:DataGridAgid>
        </div>
    </div>

     <!-- Segnatura -->
     <div class="modal" tabindex="-1" role="dialog" id="divSegnatura" aria-labelledby="Inserisci segnatura" style="position: absolute; display: none;">
         <div class="modal-dialog" role="document">
             <div class="modal-content">
                 <div class="modal-header">
                     <h4 class="modal-title h5" id="modalSegnatura">Inserisci Segnatura</h4>
                     <button class="btn-close" type="button" data-bs-dismiss="modal" aria-label="Chiudi finestra modale" onclick="chiudiPopupTemplate()">
                         <svg class="icon">
                             <%--<use href="/web/bootstrap-italia/svg/sprites.svg#it-close"></use>--%>
                         </svg>
                     </button>
                 </div>
                 <div class="modal-body">
                     <div class="row">
                         <div class="col-12 form-group">
                             <Siar:DateTextBoxAgid ID="txtData" Label="Data segnatura" runat="server" />
                         </div>
                     </div>
                     <div class="row">
                         <div class="col-12">
                             <asp:TextBox CssClass="rounded" ID="txtSegnatura" runat="server" Width="415px" />
                             <img id="imgSegnatura" runat="server" height="18" src="../../images/lente.png"
                                 title="Visualizza documento" width="18" />
                         </div>
                     </div>
                 </div>
                 <div class="modal-footer">
                    <Siar:Button ID="btnSalvaSegnatura" class="btn btn-primary" runat="server" OnClick="btnSalvaSegnatura_Click"
                        Text="Salva" data-bs-dismiss="modal" CausesValidation="true" />
                </div>
             </div>
         </div>
     </div>

    <div class="row" id="idModaleEscludi" runat="server" style="width: 200px; position: absolute; padding-bottom: 20px; text-align: center; display: none;">
        <div class="separatore">
            Esclusione Progetto
        </div>
        <div style="padding-top: 20px;">
            <strong>Domanda di aiuto:</strong>
            <div style="display: inline-block" id="lblDettagliDomanda"></div>
        </div>
        <div style="padding-top: 20px;">
            Specificare il motivo di esclusione (Max 50 caratteri)<br />
            <Siar:TextArea Width="300px" Rows="4" ID="txtMotivoEsclusione" MaxLength="50" runat="server" Style="padding-top: 5px;" />
        </div>
        <div style="padding-top: 20px; text-align: center;">
            <Siar:Button ID="btnEscludi" OnClick="btnEscludi_Click" OnClientClick="if(!ValidaMotivoEsclusione()) {return false};" runat="server" Text="Escludi Domanda" Width="150px" />
            <input type="button" class="Button" id="btnAnnullaMod" onclick="chiudiModaleEscludi(); return false;" value="Annulla" />
        </div>
    </div>

</asp:Content>