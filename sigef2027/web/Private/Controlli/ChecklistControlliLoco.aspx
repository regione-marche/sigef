<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
         CodeBehind="ChecklistControlliLoco.aspx.cs" Inherits="web.Private.Controlli.ChecklistControlliLoco" %>
         
<%@ Register Src="~/CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/ucChecklistGenerica.ascx" TagName="ChecklistGenerica" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/SNCUploadFileControlAgid.ascx" TagName="SNCUploadFileControl" TagPrefix="uc3" %>
<%--<%@ Register Src="~/CONTROLS/SNCUploadFileControl.ascx" TagName="ufVerbale" TagPrefix="uc5" %>--%>
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
    
    <div class="container-fluid shadow bd-form rounded-3 py-4">
        <h3 class="align-items-center">Checklist - Verifiche in loco</h3>

        <div class="row align-items-center pt-5">
            <div class="form-group col-sm-4">
                <Siar:ComboZPsr Label="Selezionare il programma" ID="lstPsr" runat="server" AutoPostBack="true"></Siar:ComboZPsr>
            </div>
            <div class="col-sm-3 pt-1">
                <input type="button" class="btn btn-secondary py-1" value="Estrai in xls" onclick="return estraiInXls(1);" />
            </div>
        </div>
    </div>
    <%-- <div class="dBox">
        <div class="dSezione">
            <div class="dContenutoFloat">
                <strong>Selezionare il programma: </strong>
                <Siar:ComboZPsr ID="lstPsr" runat="server" AutoPostBack="true"></Siar:ComboZPsr>
            </div>
        </div>
    </div>--%>
    
    <!-- Lotti -->
    <div id="divLotti" class="mt-4 fw-semibold" runat="server" visible="true">
        <div class="col-sm-12">
        <Siar:DataGridAgid ID="dgLotti" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
            <HeaderStyle CssClass="headerStyle" />
            <ItemStyle CssClass="DataGridRow itemStyle" />
            <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
            <Columns>
                <asp:BoundColumn DataField="IdLoco" HeaderText="Id Loco"></asp:BoundColumn>
                <asp:BoundColumn DataField="DataInizio" HeaderText="Data Inizio"></asp:BoundColumn>
                <asp:BoundColumn DataField="DataFine" HeaderText="Data Fine"></asp:BoundColumn>
                <Siar:ColonnaLink DataField="Definitivo" HeaderText="Definitivo" IsJavascript="true"
                    LinkFields="Idloco" LinkFormat="selezionaLotto({0});">
                </Siar:ColonnaLink>
            </Columns>
        </Siar:DataGridAgid>
        </div>
    </div>
   
    <div id="divDettaglio" class="row pt-3" visible="false" runat="server">
        <uc1:SiarNewTab ID="tabDettaglio" runat="server" TabNames="Elenco|Checklist domanda" Titolo="Domande di pagamento" TabClickEvents="cambioScheda();" />
        <div id="divElencoRicerca" class="tableTab" runat="server" visible="false">
            <asp:Label ID="lblNrRecord" runat="server" Font-Size="Smaller"></asp:Label><br />
            <div class="col-sm-12">
                <div class="table-responsive">
                    <Siar:DataGridAgid ID="dgDettaglio" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-sm" PageSize="20">
                         <HeaderStyle CssClass="headerStyle-small" />
                        <ItemStyle CssClass="itemStyle-small DataGridRow" />
                        <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle-small" />
                        <Columns>
                            <asp:BoundColumn  DataField="IdProgetto" HeaderText="Id Progetto"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="Beneficiario" HeaderText="Beneficiario"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="Asse" HeaderText="Asse"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="ObiettivoSpecifico" HeaderText="Obiettivo specifico"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="Azione" HeaderText="Azione"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="Intervento" HeaderText="Intervento"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="NrOperazioniB" HeaderText="Nr. Operazioni Benef."></asp:BoundColumn>
                            <asp:BoundColumn  DataField="SpesaAmmessaIncrementale" HeaderText="Costo investimento richiesto" DataFormatString="{0:c}"></asp:BoundColumn>
                            <Siar:ColonnaLink  DataField="CostoTotale" HeaderText="Costo investimento ammesso" DataFormatString="{0:c}" IsJavascript="true"
                                LinkFields="IdlocoDettaglio" LinkFormat="selezionaLocoDettaglio({0});">
                            </Siar:ColonnaLink>
                            <asp:BoundColumn  DataField="ImportoAmmesso" HeaderText="Contributo concesso" DataFormatString="{0:c}"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="ImportoConcesso" ItemStyle-CssClass="" HeaderText="Importo rendicontato ammesso (totale incrementale)" DataFormatString="{0:c}"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="ImportoContributoPubblico" HeaderText="Contributo rendicontato concesso (totale incrementale)" DataFormatString="{0:c}"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="SpesaAmmessa" HeaderText="Importo rendicontato ammesso (delta riferito allo specifico lotto)" DataFormatString="{0:c}"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="ImportoContributoPubblicoIncrementale" HeaderText="Contributo rendicontato concesso (delta riferito allo specifico lotto)" DataFormatString="{0:c}"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="ImportoConcesso" HeaderText="Importo rendicontato ammesso regolare (totale incrementale)" DataFormatString="{0:c}"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="ImportoContributoPubblico" HeaderText="Contributo rendicontato concesso regolare (totale incrementale)" DataFormatString="{0:c}"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="SpesaAmmessa" HeaderText="Importo rendicontato ammesso regolare (delta riferito allo specifico lotto)" DataFormatString="{0:c}"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="ImportoContributoPubblicoIncrementale" HeaderText="Contributo rendicontato concesso regolare (delta riferito allo specifico lotto)" DataFormatString="{0:c}"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="Selezionata" HeaderText="Selez. per controllo"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="Esclusione" HeaderText="Esclus."></asp:BoundColumn>
                            <asp:BoundColumn  DataField="RischioIR" HeaderText="Rischio IR"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="RischioCR" HeaderText="Rischio CR"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="RischioComp" HeaderText="Rischio Complessivo"></asp:BoundColumn>
                            <asp:BoundColumn  DataField="IdProgetto" HeaderText="Esito checklist"></asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
        </div>
        <div id="divChecklistDomanda" class="tableTab" runat="server" visible="false">
            <div class="row pt-5">
                <div class="col-sm-4">
                    <Siar:DateTextBoxAgid ID="txtDataSopralluogo" Label="Data sopralluogo" runat="server" />
                </div>
                <div class="col-sm-4">
                    <Siar:TextBox   ID="txtLuogoSopralluogo" Label="Luogo sopralluogo" runat="server" />
                </div>
            </div>
            <h4 class="pt-3">Elenco degli step di controllo</h4>
            <uc2:ChecklistGenerica ID="ucChecklistGenerica" runat="server" DefaultRedirect="../PPagamento/GestioneLavori.aspx" /><br />

            <div class="row align-items-center justify-content-start pb-4">
                <div class="col-sm-4 pb-1">
                    <label class="active fw-semibold" for="txtEsitoVerifica">Esito verifica requisiti</label>
                    <Siar:TextBox class="fw-semibold" ID="txtEsitoVerifica" runat="server" ReadOnly="True" />
                </div>
                <div class="col-sm-3 pb-1">
                    <label class="active fw-semibold" for="txtOperatoreCompilatore">Compilatore</label>
                    <asp:TextBox CssClass="rounded" ID="txtOperatoreCompilatore" runat="server" />
                    <asp:HiddenField ID="hdnIdUtenteCompilatore" runat="server" />
                </div>
                <div class="col-sm-3 pb-1">
                    <label class="active fw-semibold" for="txtOperatoreValidatore">Validatore</label>
                    <asp:TextBox CssClass="rounded" ID="txtOperatoreValidatore" runat="server" />
                    <asp:HiddenField ID="hdnIdUtenteValidatore" runat="server" />
                </div>
            </div>

            <h4 class="pt-3">File associati</h4>

            <div class="row align-items-end justify-content-start py-4">
                <div class="col-2">
                    <label class="active fw-semibold" for="txtDataVerbale">Data verbale</label>
                   <%-- <input type="text" id="txtDataVerbale" runat="server">--%>
                       <Siar:DateTextBoxAgid ID="txtDataVerbale" runat="server" />
                </div>
                <div class="col-sm-6 align-self pb-1">                                 
                    <uc3:SNCUploadFileControl ID="ufVerbale"  runat="server" TipoFile="Documento" AbilitaModifica="true" />                   
                </div>
            </div>
            <div class="row align-items-end justify-content-start py-4">
                <div class="col-sm-3">
                    <label class="active fw-semibold" for="txtDataAttestazione">Data attestazione</label>
                    <%--<input type="text" id="txtDataAttestazione" runat="server">--%>
                       <Siar:DateTextBoxAgid ID="txtDataAttestazione" runat="server" />
                </div>
                <div class="col-sm-6 align-self pb-1">                   
                    <uc3:SNCUploadFileControl ID="ufAttestazione" runat="server" TipoFile="Documento" AbilitaModifica="true" />                
                </div>                
            </div>

           <%-- <div style="display:inline-block" >
                 <label for="txtDataVerbale" style="white-space: nowrap; position:relative; top:-8px" >Data verbale:<br />
                        <span style="position:relative;top:10px"><Siar:DateTextBoxAgid ID="txtDataVerbale" runat="server" Width="104px" /></span>
                 </label><br /><br />
             </div>

              <div style="display:inline-block" >
                 <label for="IdFileVerbale" style="white-space:nowrap;">Specificare il file digitale relativo al verbale:<br />
                    <uc5:ufVerbale ID="ufVerbale" runat="server" TipoFile="Documento" AbilitaModifica="true" />
                 </label><br />
             </div>
             <div></div>
             <div style="display:inline-block" >
                 <label for="txtDataAttestazione" style="white-space: nowrap; position:relative; top:-8px" >Data attestazione:<br />
                        <span style="position:relative;top:10px"><Siar:DateTextBoxAgid ID="txtDataAttestazione" runat="server" Width="104px" /></span>
                 </label><br /><br />
            </div>
            <div style="display:inline-block" >
                 <label for="IdFileAttestazione" style="white-space:nowrap;">Specificare il file digitale relativo all'attestazione:<br />
                    <uc3:ufAttestazione ID="ufAttestazione" runat="server" TipoFile="Documento" AbilitaModifica="true" />
                 </label><br />
            </div><br />--%>


            <div class="row py-4">
                <label class="active fw-semibold" for="txtDataAttxtSegnaturaChecklisttestazione">Segnatura checklist verifiche in loco</label>
                <Siar:TextBox ID="txtSegnaturaChecklist" runat="server" Width="400px" ReadOnly="True" />
                <img id="imgSegnaturaChecklist" runat="server" style="margin-left: 10px" height="20" src="../../images/lente.png" width="20" title="Visualizza documento" />
            </div>


            <div class="row align-items-center justify-content-end p-5">              
            <div class="col-sm-3 p-1">
                <Siar:Button ID="btnSalvaChecklist" runat="server" CssClass="py-1" Text="Salva informazioni verifiche in loco e verifica requisiti *" OnClick="btnSalvaChecklist_Click" />
            </div>
             <div class="col-sm-3 p-1">
                <Siar:Button ID="btnFirmaProtocollo" runat="server" CssClass="py-1" Enabled="False" Text="Firma e invia al protocollo" OnClick="btnFirmaProtocollo_Click" />
            </div>

                <div class="col-sm-3 p-1">
                    <Siar:Button ID="btnVerificaRequisiti" runat="server" Text="Verifica requisiti *" OnClick="btnVerificaRequisiti_Click" Visible="false" />
                </div>
            </div>
            <div class="row p-5">
            
                <b>*: è necessario verificare nuovamente i requisiti dopo l'inserimento di un irregolarità.</b><br />
            </div>
        </div>
         </div>
    </div>
  
    <uc4:FirmaDocumento ID="ucFirmaDocumento" runat="server" Titolo="PAGINA DI FIRMA DELLA CHECKLIST DELLE VERIFICHE IN LOCO" TipoDocumento="CKL_CONTROLLI_LOCO" />
</asp:Content>