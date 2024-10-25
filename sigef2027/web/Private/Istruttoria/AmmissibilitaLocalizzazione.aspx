<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="AmmissibilitaLocalizzazione.aspx.cs" Inherits="web.Private.Istruttoria.AmmissibilitaLocalizzazione" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/Indirizzo.ascx" TagName="Indirizzo" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/SNCRicercaImpresa.ascx" TagName="SNCRicercaImpresa"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"> 
        function pulisciCampi() {   
            $('[id$=hdnSNCRIIdImpresa]').val('');                 
            $('[id$=txtSNCRICuaa_text]').val('');
            $('[id$=txtSNCRIRagioneSociale_text]').val('');     
            $('[id$=hdnIdLocalizzazioneSelezionata]').val('')       
            $('[id$=btnNuovo]').click();  
        }  

        function VisualizzaStorico(idLocal) {
            $('[id$=hdnIdLocalizzazioneSelezionataPopup]').val(idLocal)
            $('[id$=btnApriPopup]').click();
        }
        
        function caricaLocalizzazione(id) { $('[id$=hdnIdLocalizzazioneSelezionata]').val(id);$('[id$=btnSelezionaLocalizzazione]').click(); } 
    </script>

 
    <uc1:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <br />
    <div style="display: none">
        <asp:HiddenField ID="hdnIdLocalizzazioneSelezionataPopup" runat="server" /> 
        <asp:Button ID="btnApriPopup" runat="server" OnClick="btnApriPopup_Click" CausesValidation="false" />
    </div>

     <h3 class="align-items-center py-3">Ammissibilità della localizzazione del progetto</h3>
      <div class="container-fluid bd-form">
          <div class="row align-items-center pt-5">
              <h4 class="py-3 fw-bold">Localizzazione del progetto</h4>
              <p class="py-3 fw-semibold">
                  Per inserire le localizzazioni relative alla domanda è necessario selezionare l'azienda
                di riferimento e scaricare i dati anagrafici, dopo di che sarà possibile inserire
                tutti i dati relativi.
                <br />
                  Di default è selezionata l'azienda capofila della domanda.                      
              </p>

              <uc3:Indirizzo ID="ucIndirizzo" runat="server" />
              <uc2:SNCRicercaImpresa ID="RicercaImpresa" TestoCustom="Cerca" runat="server" />
          </div>
          <div class="grid-row px-2">
              <Siar:Button ID="btnSalva" runat="server" Modifica="True" Text="Salva" class="btn btn-primary py-1" OnClick="btnSalva_Click" />
              <Siar:Button ID="btnElimina" runat="server" class="btn btn-primary py-1" Text="Elimina" CausesValidation="false"
                  Modifica="false" OnClick="btnElimina_Click" Conferma="Attenzione, eliminare questa localizzazione?"></Siar:Button>
              <input type="button" class="btn btn-secondary py-1" value="Nuovo" onclick="pulisciCampi();" />
              <input id="btnAmmissibilita" runat="server" type="button" class="btn btn-secondary py-1" value="Checklist di ammissibilità" />
          </div>
          <div class="row align-items-center pt-5">
              <div style="display: none">
                  <asp:HiddenField ID="hdnIdLocalizzazioneSelezionata" runat="server" />
                  <asp:Button ID="btnSelezionaLocalizzazione" runat="server" OnClick="btnSelezionaLocalizzazione_Click"
                      CausesValidation="false" />
              </div>
              <div class="col-sm-12">
                  <div class="table-responsive">
                      <Siar:DataGridAgid ID="dgLocalizzazioni" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="30" AllowPaging="true">
                        <headerstyle cssclass="headerStyle" />
                        <itemstyle cssclass="DataGridRow itemStyle" />
                        <alternatingitemstyle cssclass="DataGridRowAlt itemStyle" />
                          <Columns>                             
                              <Siar:NumberColumn HeaderText="Nr.">
                                  <ItemStyle HorizontalAlign="center" />
                              </Siar:NumberColumn>
                              <asp:BoundColumn DataField="IdImpresa" HeaderText="Impresa">
                                  <ItemStyle HorizontalAlign="Center" />
                              </asp:BoundColumn>
                              <asp:BoundColumn DataField="IdComune" HeaderText="Comune">
                                  <ItemStyle HorizontalAlign="left" />
                              </asp:BoundColumn>
                              <Siar:ColonnaLink DataField="CAP" HeaderText="CAP" LinkFields="IdLocalizzazione"
                                  IsJavascript="true" LinkFormat='caricaLocalizzazione({0})'>
                                  <ItemStyle HorizontalAlign="Center" />
                              </Siar:ColonnaLink>
                              <asp:BoundColumn HeaderText="Via">
                                  <ItemStyle HorizontalAlign="left" />
                              </asp:BoundColumn>
                              <asp:BoundColumn HeaderText="Storico">
                                  <ItemStyle HorizontalAlign="Center" />
                              </asp:BoundColumn>
                          </Columns>
                      </Siar:DataGridAgid>
                  </div>
              </div>
          </div>
          <div id="divLocalizzazioneStorico" class="row py-3" style="display: none;">
              <h4 class="fw-bold">Elenco delle storico della localizzazione selezionata modificate</h4>
              <div class="row py-3">
                  <div class="table-responsive">
                      <Siar:DataGridAgid ID="dgLocalizzazioniStorico" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="30" AllowPaging="true">
                          <Columns>
                              <Siar:NumberColumn HeaderText="Nr.">
                                  <ItemStyle HorizontalAlign="center" />
                              </Siar:NumberColumn>
                              <asp:BoundColumn DataField="IdImpresa" HeaderText="Impresa">
                                  <ItemStyle HorizontalAlign="Center" />
                              </asp:BoundColumn>
                              <asp:BoundColumn DataField="IdComune" HeaderText="Comune">
                                  <ItemStyle HorizontalAlign="left" />
                              </asp:BoundColumn>
                              <asp:BoundColumn DataField="Via" HeaderText="Indirizzo">
                                  <ItemStyle HorizontalAlign="Center" />
                              </asp:BoundColumn>
                              <asp:BoundColumn HeaderText="Operatore">
                                  <ItemStyle HorizontalAlign="Center" />
                              </asp:BoundColumn>
                              <asp:BoundColumn DataField="DataModifica" HeaderText="Data Modifica">
                                  <ItemStyle HorizontalAlign="Center" />
                              </asp:BoundColumn>
                          </Columns>
                      </Siar:DataGridAgid>
                  </div>
              </div>

              <div class="row justify-content-center py-3">
                  <input class="Button" onclick="chiudiPopupTemplate();" style="width: 100px; margin-left: 20px; margin-right: 20px"
                      type="button" value="Chiudi" />
              </div>
          </div>
    </div> 
</asp:Content>
