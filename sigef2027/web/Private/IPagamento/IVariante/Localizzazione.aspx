<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Localizzazione.aspx.cs"
    MasterPageFile="~/SigefAgidPrivate.master" Inherits="web.Private.IPagamento.IVariante.Localizzazione" %>

<%@ Register Src="~/CONTROLS/CardVariantiIstruttoria.ascx" TagName="CardVariantiIstruttoria" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/WorkFlowVariantiIstruttoria.ascx" TagName="WorkFlowVariantiIstruttoria" TagPrefix="uc2" %>

<%@ Register Src="../../../CONTROLS/Indirizzo.ascx" TagName="Indirizzo" TagPrefix="uc3" %>
<%@ Register Src="../../../CONTROLS/SNCRicercaImpresa.ascx" TagName="SNCRicercaImpresa" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript"> 
        $(document).ready(function () {
            let $el = $('.steppers-nav').clone();
            $('#containerCopiaPulsanti').append($el);
        });

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

    <div style="display: none">
        <asp:HiddenField ID="hdnIdLocalizzazioneSelezionataPopup" runat="server" /> 
        <asp:Button ID="btnApriPopup" runat="server" OnClick="btnApriPopup_Click" CausesValidation="false" />       
        <asp:HiddenField ID="hdnIdLocalizzazioneSelezionata" runat="server" />
    </div>
    <uc1:CardVariantiIstruttoria ID="ucCardVarianti" runat="server" />
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <uc2:WorkFlowVariantiIstruttoria ID="ucWorkFlowVarianti" runat="server" />
                <div class="steppers-content" aria-live="polite">
                    <div class="row bd-form pt-5 mx-2">
                        <h2> Ammissibilità della localizzazione del progetto</h2>
                        <p>
                            Per inserire le localizzazioni relative alla domanda è necessario selezionare l'azienda di riferimento e scaricare i dati anagrafici, 
                            dopo di che sarà possibile inserire tutti i dati relativi.
                        </p>
                        <p>
                            Di default è selezionata l'azienda capofila della domanda.
                        </p>
        
                        <uc3:Indirizzo ID="ucIndirizzo" runat="server" />
               
                        <h3 class="pb-5">Azienda:</h3>              
                        <uc4:SNCRicercaImpresa ID="RicercaImpresa" TestoCustom="Cerca" runat="server" />

                        <div class="col-sm-12">
                            <Siar:Button ID="btnSalva" runat="server" Modifica="False" Text="Salva" OnClick="btnSalva_Click" />
                            <Siar:Button ID="btnElimina" runat="server" Width="140px" Text="Elimina" CausesValidation="false"
                                Modifica="false" OnClick="btnElimina_Click" Conferma="Attenzione, eliminare questa localizzazione?"></Siar:Button>
                            <input type="button" class="Button" value="Nuovo" style="width: 120px"
                                onclick="pulisciCampi();" />
                        </div>                      
                </div>
                <div class="col-sm-12">
                    <Siar:DataGridAgid ID="dgLocalizzazioni" runat="server" Width="99%" AllowPaging="True" PageSize="30" AutoGenerateColumns="False" CssClass="table table-striped">
                        <Columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <ItemStyle Width="30px" HorizontalAlign="center" />
                            </Siar:NumberColumn>
                            <asp:BoundColumn DataField="IdImpresa" HeaderText="Impresa">
                                <ItemStyle Width="230px" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IdComune" HeaderText="Comune">
                                <ItemStyle Width="220px" HorizontalAlign="left" />
                            </asp:BoundColumn>
                            <Siar:ColonnaLink DataField="Cap" HeaderText="CAP" LinkFields="IdLocalizzazione"
                                IsJavascript="true" LinkFormat='caricaLocalizzazione({0})'>
                                <ItemStyle Width="50px" HorizontalAlign="Center" />
                            </Siar:ColonnaLink>
                            <asp:BoundColumn HeaderText="Via">
                                <ItemStyle Width="250px" HorizontalAlign="left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Storico"> 
                                <ItemStyle  Width="40px" HorizontalAlign="Center" /> 
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
            
                    <div style="display: none;">
                        <Siar:Button ID="btnNuovo" runat="server" CausesValidation="false" Text="Nuovo" Modifica="False" OnClick="btnNuovo_Click"></Siar:Button>
                    </div>
                    </div>
              </div>
            <div id="containerCopiaPulsanti" class="row py-5 steppers">
             </div>
          </div>
           </div>
        </div>
    </div>
    <div class="modal it-dialog-scrollable" tabindex="-1" role="dialog" style="position: absolute; display: none" id="divLocalizzazioneStorico">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title h5" id="modal1Title">Elenco delle storico della localizzazione selezionata modificate:</h2>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <Siar:DataGridAgid ID="dgLocalizzazioniStorico" CssClass="table table-striped" runat="server" AllowPaging="True"
                            PageSize="30" AutoGenerateColumns="False" EnableViewState="False" ShowShadow="False">
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
                <div class="modal-footer">
                    <input class="btn btn-secondary py-1" onclick="chiudiPopupTemplate();" type="button" value="Chiudi" />
                </div>
            </div>
        </div> 
        </div>
</asp:Content>
