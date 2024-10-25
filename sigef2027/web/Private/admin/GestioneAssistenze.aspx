<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SigefAgidPrivate.master" CodeBehind="GestioneAssistenze.aspx.cs" Inherits="web.Private.admin.GestioneAssistenze" %>

<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript"> 
        function dettaglioAssistenza(idaxp) { $('[id$=hdnAssistenzaSelezionata]').val(idaxp); $('[id$=btnDettaglioAassistenzaPost]').click(); }

        const copyContent = async () => {
            try {
                let text = $('[id$=txtDescrizione]').val();
                await navigator.clipboard.writeText(text);
                console.log('Content copied to clipboard');
            } catch (err) {
                console.error('Failed to copy: ', err);
            }
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

    </script>
    <div style="display: none;">
        <asp:HiddenField ID="hdnAssistenzaSelezionata" runat="server" />
        <asp:Button ID="btnDettaglioAassistenzaPost" runat="server" OnClick="btnDettaglioAassistenzaPost_Click" />
    </div>
    <div class="container-fluid shadow rounded-2 pt-4 bd-form">
        <h4 class="fw-bold py-5">Prima assistenza per gli utenti</h4>
        <h5 class="fw-semibold paragrafo_bold pt-4">Elenco richieste pervenute</h5>
        <div class="row align-items-center pt-5">
            <div class="col-sm-2 form-group">
                <Siar:TextBox ID="txtFilterIdProgettoConsulente" Label="Id Progetto" runat="server" onkeypress="return isNumberKey(event)" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:TextBox CssClass="rounded" label="Id Pass" ID="txtFilterPassId" runat="server" />
            </div>       
            <div class="col-sm-2 form-group">
                <Siar:ComboOperatoriAssistenza ID="cmbOperatoriAssistenza" Label="Operatore" runat="server" NomeCampo="Operatore">
                </Siar:ComboOperatoriAssistenza>
            </div>   
              <div class="col-sm-2 form-check pb-5 px-2">
                <asp:CheckBox ID="chkInLavorazioneFilter" Text="Assistenza in lavorazione" CssClass="fw-semibold" runat="server" />
            </div>
        </div>
         <div class="d-flex flex-row align-items-center py-2">
             <div class="flex-column px-2">
                <Siar:Button ID="btnRicerca" runat="server" Label="Filtra" CausesValidation="False" OnClick="btnRicerca_Click"
                    Text="Filtra" />
            </div>
            <div class="flex-column px-2">
                <Siar:Button ID="btnReset" runat="server" Label="Reset" CausesValidation="False" OnClick="btnReset_Click"
                    Text="Reset" />
            </div>
        </div>

    
         <div class="row align-items-center py-5">  
            <div class="table-responsive">
                <Siar:DataGridAgid ID="dgRichiesteAssistenza" runat="server"   AutoGenerateColumns="False" CssClass="table table-striped" PageSize="5" AllowPaging="true">
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemStyle CssClass="DataGridRow itemStyle" />
                        <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <HeaderStyle Width="35px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="DescrizioneTipologia" HeaderText="Tipologia"></asp:BoundColumn>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Id Progetto"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Titolo" HeaderText="Titolo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Email" HeaderText="Email"></asp:BoundColumn>
                        <asp:BoundColumn DataField="CUAA" HeaderText="Partita IVA"></asp:BoundColumn>
                        <asp:BoundColumn DataField="CodiceFiscale" HeaderText="Codice Fiscale"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DataInserimento" HeaderText="Data">
                            <ItemStyle HorizontalAlign="center"></ItemStyle>
                        </asp:BoundColumn>
                        <Siar:JsButtonColumnAgid Arguments="IdAllegato" HeaderText="Allegati" ButtonImage="it-search" ButtonType="ImageButton"
                            ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                            <ItemStyle HorizontalAlign="Center"  />
                        </Siar:JsButtonColumnAgid>
                        <asp:BoundColumn DataField="NominativoOperatoreGestione" HeaderText="Gestita da"></asp:BoundColumn>
                        <Siar:CheckColumnAgid DataField="Gestita" HeaderText="In lavorazione" ReadOnly="true">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:CheckColumnAgid>
                        <Siar:CheckColumnAgid DataField="Risolta" HeaderText="Risolta" ReadOnly="true">
                            <ItemStyle HorizontalAlign="Center"  />
                        </Siar:CheckColumnAgid>
                        <asp:BoundColumn DataField="NoteHelpDesk" HeaderText="Note help desk"></asp:BoundColumn>
                        <asp:BoundColumn DataField="PassId" HeaderText="Id del PASS"></asp:BoundColumn>
                        <Siar:JsButtonColumnAgid Arguments="Id" ButtonImage="it-pencil" ButtonType="ImageButton"
                            ButtonText="Visualizza dettaglio" JsFunction="dettaglioAssistenza">
                            <ItemStyle HorizontalAlign="Center"  />
                        </Siar:JsButtonColumnAgid>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>
  

   <div class="container-fluid shadow rounded-2 pt-3 my-5 bd-form">
        <h5 class="fw-semibold paragrafo_bold pt-4">Dati della richiesta di assistenza</h5>
         <div class="row py-2 pt-5">
             <div class="col-sm-2 form-group">
                 <Siar:ComboTipoAssistenza ID="cmbSelTipoAssistenza" Label="Tipologia richista" Enabled="false" runat="server" NomeCampo="Tipologia assistenza">
                 </Siar:ComboTipoAssistenza>
             </div>

             <div class="col-sm-2 form-group">
                 <Siar:TextBox ID="txtNome" Label="Nome" runat="server" ReadOnly="true" NomeCampo="Nome" />
             </div>
             <div class="col-sm-2 form-group">
                 <Siar:TextBox ID="txtCognome" Label="Congnome" runat="server" ReadOnly="true" NomeCampo="Cognome" />
             </div>
             
         </div>
        <div class="row">
             <div class="col-sm-2 form-group">
                 <Siar:TextBox  ID="txtEmail" Label="Email di contatto (non PEC)"  runat="server" ReadOnly="true" NomeCampo="Email" />
             </div>
          <div class="col-sm-2 form-group">
                 <Siar:IntegerTextBox ID="txtIdProgetto" Label="id Progetto" runat="server" CssClass="fw-semibold" ReadOnly="true" NomeCampo="Id Progetto" NoCurrency="true" />
             </div>
          <div class="col-sm-2 form-group">
               <Siar:TextBox  ID="txtTitolo" Label="Titolo/Oggetto" runat="server" NomeCampo="Titolo" ReadOnly="true"  />
              </div>
          </div>
      <div class="row">
            <div class="col-sm-2 form-group">
                <Siar:TextBox  ID="txtPiva" Label="Partita Iva Impresa" runat="server" NomeCampo="Partita iva" ReadOnly="true"  />
            </div>
              <div class="col-sm-2 form-group">            
                <Siar:TextBox  ID="txtCf" Label="Codice fiscale impresa" runat="server" NomeCampo="Codice Fiscale" ReadOnly="true"  />
            </div>
       </div>
       <div class="row py-2">
            <div class="col-sm-12">
               <%-- <input type="button" class="btn btn-primary py-1" onclick="copyContent()" value="Copia testo" />--%>
                <Siar:TextArea ID="txtDescrizione" CssClass="fw-semibold" Label="Descrizione problematica e descrizione di eventuali allegati inseriti" ReadOnly="true" runat="server" NomeCampo="Descrizione" Rows="10"  ExpandableRows="5" />
            </div>
        </div>
        <div class="row my-5">
         <div class="col-sm-4">
           <%-- File allegato alla richiesta di assistenza.<br />       --%>                         
                <uc2:SNCUploadFileControl ID="ufcNAAllegato" AbilitaModifica="true"  runat="server" Text="Selezionare un documento da caricare" />
            </div>
        </div>
        <div class="row py-3 pt-5">
             <div class="col-sm-3 form-group">
                <Siar:TextBox  ID="txtPASS" Label="Id del PASS di riferimento" runat="server" NomeCampo="Titolo" />
            </div>
           <div class="col-sm-3 form-check">
            <%--    <label class="px-4" for="chkGesita">Assistenza in lavorazione</label>--%>
                <asp:CheckBox CssClass="px-4 fw-semibold" Text="&nbsp;Assistenza in lavorazione" ID="chkGesita" runat="server" />
            </div>
           <div class="col-sm-3 form-check">                
                <asp:CheckBox ID="chkRisolta" CssClass="px-4 fw-semibold" Text="Problematica risolta" runat="server" />
            </div>
        </div>
         <div class="row py-3">
             <div class="col-sm-12 form-group">
                 <Siar:TextArea ID="txtNoteHelpDesk" Label="Note Help Desk" runat="server" NomeCampo="Note Help Desk" Rows="10" ExpandableRows="5" />
             </div>
         </div>
        <div class="row pb-2">
            <div class="col-sm-2">
                <Siar:Button ID="btnSalva" CssClass="col-sm-2" runat="server" Modifica="True" OnClick="btnSalva_Click"
                    Text="Salva" ValidationGroup="vgAssistenza" />
            </div>
        </div>
    </div>
</asp:Content>
