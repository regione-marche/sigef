<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
         CodeBehind="ChecklistControlliLoco.aspx.cs" Inherits="web.Private.Controlli.ChecklistControlliLoco" %>
         
<%@ Register Src="~/CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/ucChecklistGenerica.ascx" TagName="ChecklistGenerica" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc4" %>

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
        function selezionaLotto(idLoco) {
            $('[id$=hdnIdLoco]').val($('[id$=hdnIdLoco]').val() == idLoco ? '' : idLoco);
            $('[id$=btnPost]').click();
        }
        
        function selezionaLocoDettaglio(id) {
            $('[id$=hdnIdLocoDett]').val($('[id$=hdnIdLocoDett]').val() == id ? '' : id);
            $('[id$=btnCaricaDettaglio]').click();
        }

        var tb_corrente;
        function SNCVZCercaUtenti_onselect(obj) {
            if (obj) {
                $('[id$=hdnIdUtente' + tb_corrente + ']').val(obj.IdUtente);
                $('[id$=txtOperatore' + tb_corrente + '_text]').val(obj.Nominativo); 
            } else alert('L`elemento selezionato non è valido.');
        }
        function SNCVZCercaUtenti_onprepare() {
            $('[id$=hdnIdUtente' + tb_corrente + ']').val('');
        }

        function estraiInXls(Definitivo) {
            var parametri = "";

            //per ora vogliono estrarre sempre tutti i lotti
            //var IdLoco = $('[id$=hdnIdLoco]').val();
            //if (IdLoco != null)
            //    parametri = "IdLoco=" + IdLoco + "|Definitivo=" + Definitivo;
            //else
                parametri = "Definitivo=" + Definitivo;

            SNCVisualizzaReport('rptLottiChecklistControlliLoco', 2, parametri);
        }

        function cambioScheda() {
            var schedaDestinazione = $(".SNTUnselected")[0].innerText;

            if (schedaDestinazione == "Elenco")
                $('[id$=hdnIdLocoDett]').val('');
        }
    </script>  
    
    <div style="display: none">
        <asp:HiddenField ID="hdnIdTestata" runat="server" />
        <asp:HiddenField ID="hdnIdLoco" runat="server" />
        <asp:HiddenField ID="hdnIdLocoDett" runat="server" />
        <asp:HiddenField ID="hdnCodPsr" runat="server" />
        <asp:HiddenField ID="hdnVerificaRequisiti" runat="server" />
        <asp:Button ID="btnCaricaDettaglio" runat="server" OnClick="btnCaricaDettaglio_Click" CausesValidation="false" /> 
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" /> 
    </div>
    
    <div style="text-align:center;">
        <h1>Checklist - Controlli in loco</h1>
    </div>
    
    <div class="dBox">
        <div class="dSezione">
            <div class="dContenutoFloat">
                <strong>Selezionare il programma: </strong>
                <Siar:ComboZPsr ID="lstPsr" runat="server" AutoPostBack="true"></Siar:ComboZPsr>
            </div>
        </div>
    </div>
    
    <!-- Lotti -->
    <div class="dBox" visible="false">
        <div id="divLotti" class="dContenuto" runat="server">
            <input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return estraiInXls(1);" />
            <br />
            <Siar:DataGrid ID="dgLotti" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="24px" />
                <Columns>
                    <asp:BoundColumn DataField="IdLoco" HeaderText="Id Loco"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DataInizio" HeaderText="Data Inizio"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DataFine" HeaderText="Data Fine"></asp:BoundColumn>
                    <Siar:ColonnaLink DataField="Definitivo" HeaderText="Definitivo" IsJavascript="true"
                                      LinkFields="Idloco" LinkFormat="selezionaLotto({0});">
                    </Siar:ColonnaLink>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>
    
    <div id="divDettaglio" class="dBox" visible="false" runat="server">
        <uc1:SiarNewTab ID="tabDettaglio" runat="server" TabNames="Elenco|Checklist domanda" Titolo="Domande di pagamento" TabClickEvents="cambioScheda();" />
        <div id="divElencoRicerca" class="dContenuto" runat="server" visible="false">
            <asp:Label ID="lblNrRecord" runat="server" Text="" Font-Size="Smaller"></asp:Label><br /><br />
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
                                      LinkFields="IdlocoDettaglio" LinkFormat="selezionaLocoDettaglio({0});">
                    </Siar:ColonnaLink>
                    <asp:BoundColumn DataField="ImportoAmmesso" HeaderText="Contributo concesso" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoConcesso" HeaderText="Importo rendicontato ammesso (totale incrementale)" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoContributoPubblico" HeaderText="Contributo rendicontato concesso (totale incrementale)" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="SpesaAmmessa" HeaderText="Importo rendicontato ammesso (delta riferito allo specifico lotto)" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoContributoPubblicoIncrementale" HeaderText="Contributo rendicontato concesso (delta riferito allo specifico lotto)" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoConcesso" HeaderText="Importo rendicontato ammesso regolare (totale incrementale)" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoContributoPubblico" HeaderText="Contributo rendicontato concesso regolare (totale incrementale)" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="SpesaAmmessa" HeaderText="Importo rendicontato ammesso regolare (delta riferito allo specifico lotto)" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoContributoPubblicoIncrementale" HeaderText="Contributo rendicontato concesso regolare (delta riferito allo specifico lotto)" DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Selezionata" HeaderText="Selez. per controllo"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Esclusione" HeaderText="Esclusione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="RischioIR" HeaderText="Rischio IR"></asp:BoundColumn>
                    <asp:BoundColumn DataField="RischioCR" HeaderText="Rischio CR"></asp:BoundColumn>
                    <asp:BoundColumn DataField="RischioComp" HeaderText="Rischio Complessivo"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Esito checklist"></asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
        <div id="divChecklistDomanda" class="dContenuto" runat="server" visible="false">
            <label for="txtDataSopralluogo" style="white-space: nowrap;">Data   sopralluogo:<br />
                <Siar:DateTextBox ID="txtDataSopralluogo" runat="server" Width="105px"/>
            </label><br /><br />
            <label for="txtLuogoSopralluogo" style="white-space: nowrap;">Luogo sopralluogo:<br />
                <Siar:TextBox ID="txtLuogoSopralluogo" runat="server" Width="200px" />
             </label><br /><br />
             <div class="paragrafo">Elenco degli step di controllo:</div><br />
             <uc2:ChecklistGenerica ID="ucChecklistGenerica" runat="server" DefaultRedirect="../PPagamento/GestioneLavori.aspx" /><br />
             <label style="white-space:nowrap;">Esito verifica requisiti:<br />
                <Siar:TextBox ID="txtEsitoVerifica" runat="server" Width="700px" ReadOnly="True" />
             </label><br /><br />
             <label style="white-space:nowrap;">Compilatore:<br />
                <Siar:TextBox ID="txtOperatoreCompilatore" runat="server" Width="384px" />
                <asp:HiddenField ID="hdnIdUtenteCompilatore" runat="server" />
             </label><br /><br />
             <label style="white-space:nowrap;">Validatore:<br />
                <Siar:TextBox ID="txtOperatoreValidatore" runat="server" Width="384px" />
                <asp:HiddenField ID="hdnIdUtenteValidatore" runat="server" />
             </label><br /><br /><br />
             <div class="paragrafo">File associati:</div><br />
             <div style="display:inline-block" >
                 <label for="txtDataVerbale" style="white-space: nowrap; position:relative; top:-8px" >Data verbale:<br />
                        <span style="position:relative;top:10px"><Siar:DateTextBox ID="txtDataVerbale" runat="server" Width="104px" /></span>
                 </label><br /><br />
             </div>
             <div style="display:inline-block" >
                 <label for="IdFileVerbale" style="white-space:nowrap;">Specificare il file digitale relativo al verbale:<br />
                    <uc3:SNCUploadFileControl ID="ufVerbale" runat="server" TipoFile="Documento" AbilitaModifica="true" />
                 </label><br />
             </div>
             <div></div>
             <div style="display:inline-block" >
                 <label for="txtDataAttestazione" style="white-space: nowrap; position:relative; top:-8px" >Data attestazione:<br />
                        <span style="position:relative;top:10px"><Siar:DateTextBox ID="txtDataAttestazione" runat="server" Width="104px" /></span>
                 </label><br /><br />
            </div>
            <div style="display:inline-block" >
                 <label for="IdFileAttestazione" style="white-space:nowrap;">Specificare il file digitale relativo all'attestazione:<br />
                    <uc3:SNCUploadFileControl ID="ufAttestazione" runat="server" TipoFile="Documento" AbilitaModifica="true" />
                 </label><br />
            </div><br />
             
             <label style="white-space:nowrap;">Segnatura checklist controlli in loco:<br />
                <Siar:TextBox ID="txtSegnaturaChecklist" runat="server" Width="400px" ReadOnly="True" />
                <img id="imgSegnaturaChecklist" runat="server" style="margin-left: 10px" height="20" src="../../images/lente.png" width="20" title="Visualizza documento" />
             </label><br /><br /><br />
             <div align="center">
                <Siar:Button ID="btnSalvaChecklist" runat="server" Text="Salva informazioni controlli e verifica requisiti *" OnClick="btnSalvaChecklist_Click" Width="400px" />
                <Siar:Button ID="btnVerificaRequisiti" runat="server" Text="Verifica requisiti *" OnClick="btnVerificaRequisiti_Click" Width="200px" Visible="false" />
                <Siar:Button ID="btnFirmaProtocollo" runat="server" Enabled="False" Text="Firma e invia al protocollo" OnClick="btnFirmaProtocollo_Click" Width="200px" />
             </div>
             <br /><b>*: è necessario verificare nuovamente i requisiti dopo l'inserimento di un irregolarità.</b><br />
        </div>
    </div>
    
    <uc4:FirmaDocumento ID="ucFirmaDocumento" runat="server" Titolo="PAGINA DI FIRMA DELLA CHECKLIST DEI CONTROLLI IN LOCO" TipoDocumento="CKL_CONTROLLI_LOCO" />
</asp:Content>