<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.admin.GestioneCup" CodeBehind="GestioneCup.aspx.cs" %>

<%@ Register Src="~/CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%--<%@ Register Src="~/CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori" TagPrefix="uc1" %>--%>
<%@ Register Src="~/CONTROLS/AdminCUPCategoria.ascx" TagName="AdminCUPCategoria" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/AdminCUPCategoriaSoggetto.ascx" TagName="AdminCUPCategoriaSoggetto" TagPrefix="uc3" %>
<%@ Register Src="~/CONTROLS/Indirizzo.ascx" TagName="Indirizzo" TagPrefix="uc4" %>
<%@ Register Src="~/CONTROLS/AdminAteco2007.ascx" TagName="AdminAteco2007" TagPrefix="uc5" %>
<%@ Register Src="~/CONTROLS/SNCRicercaImpresa.ascx" TagName="SNCRicercaImpresa" TagPrefix="uc6" %>
<%@ Register Src="~/CONTROLS/ImpresaControl.ascx" TagName="ImpresaControl" TagPrefix="uc7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"> 
        function pulisciCampi() {
            $('[id$=hdnSNCRIIdImpresa]').val('');
            $('[id$=txtSNCRICuaa_text]').val('');
            $('[id$=txtSNCRIRagioneSociale_text]').val('');
            $('[id$=hdnIdLocalizzazioneSelezionata]').val('')
            $('[id$=btnNuovo]').click();
        }

        function caricaLocalizzazione(id) {
            $('[id$=hdnIdLocalizzazioneSelezionata]').val(id);
            $('[id$=btnSelezionaLocalizzazione]').click();
        }
        function valorizzaHiddenForSave() {
            $('[id$=hdnSaveDatiMonitoraggio]').val('1');
        }
        function controlloCUP() {
            var lunghezzaCUP = $('[id$=txtCodAgea]').val().length;
            if (lunghezzaCUP != 15) {
                alert('Attenzione, il codice CUP deve essere di 15 caratteri')
                return false;
            }
            return true;
        }
    </script>

    <div class="container-fluid shadow rounded-2 pt-4 bd-form">
        <h3 class="py-3">Ricerca domanda di aiuto</h3>
        <p class="fw-semibold py-2">Indicare il numero identificativo della domanda.</p>
        <div class="row pt-5">
            <div class="form-group col-sm-2">
                <Siar:IntegerTextBox Label="Numero domanda" ID="txtNumDomanda" runat="server" Obbligatorio="true" NoCurrency="true" NomeCampo="Numero domanda" />
            </div>
            <div class="col-sm-2 pt-1">
                <Siar:Button ID="btnCerca" runat="server" Text="Cerca" OnClick="btnCerca_Click" CausesValidation="true"></Siar:Button>       
            </div>
        </div>
    </div>

    <div id="tdDomanda" class="py-1" runat="server" />

    <uc1:SiarNewTab ID="ucSiarNewTab"  runat="server"  Visible="false" TabNames="Gestione CUP|Dati monitoraggio FESR|Localizzazione interventi|Dati anagrafici impresa" />
    <div class="tableTab" id="tabCUP" runat="server" visible="false">
        <div class="row pt-5">
            <div class="form-group col-sm-2">
               <label class="active fw-semibold" for="txtCodAgea">&nbsp;Codice Agea</label>
                <Siar:TextBox ID="txtCodAgea" runat="server" Obbligatorio="true" MaxLength="30" NomeCampo="Codice Agea" />
            </div>
            <div class="col-sm-2">
                <Siar:Button ID="btnSalvaCUP" runat="server" Text="Salva" OnClientClick="if(!controlloCUP()) return false;" OnClick="btnSalvaCUP_Click" Modifica="true"></Siar:Button>
            </div>
        </div>
    </div>

    <div class="tableTab py-2" id="tabMonitoraggioFesr" runat="server" visible="false">
        <div class="container-fluid bd-form">
            <h4 class="py-3 fw-bold">Monitoriaggio FESR</h4>

            <div class="paragrafo_bold">Classificazione CUP</div>
            <div class="row align-items-center py-3">
                <uc2:AdminCUPCategoria ID="ucCUPCategoria" runat="server" CodiceFase="PDOMANDA" />
            </div>
            <div class="paragrafo_bold">Categoria Soggetto</div>
            <div class="row align-items-center py-2">
                <uc3:AdminCUPCategoriaSoggetto ID="ucCUPCategoriaSoggetto" runat="server" CodiceFase="PDOMANDA" />
            </div>
            <asp:HiddenField ID="hdnSaveDatiMonitoraggio" runat="server" />

            <div class="paragrafo_bold">Altre classificazioni</div>
            <div class="row align-items-center py-3">
                <div class="col-sm-6">
                    <label class="active fw-semibold" for="cmbTemaPrior">Tema Prioritario</label>
                    <Siar:ComboTemaPrioritario ID="cmbTemaPrior" runat="server" Obbligatorio="true" NomeCampo="Tema prioritario" onchange="valorizzaHiddenForSave();" />
                </div>
                <uc5:AdminAteco2007 ID="selAteco2007" runat="server" />
            </div>
             <div class="row align-items-center py-3">
                 <div class="col-sm-6">
                     <lable class="active fw-semibold" for="cmbAttivitaEcon">Attività economica</lable>
                     <Siar:ComboAttivitaEcon ID="cmbAttivitaEcon" runat="server" Obbligatorio="true" NomeCampo="Attività economica" onchange="valorizzaHiddenForSave();" />
                 </div>
                  <div class="col-sm-3">
                    <label class="active fw-semibold" for="cmbCPTSettore">Settore CPT</label>
                    <Siar:ComboCPTSettore ID="cmbCPTSettore" runat="server" Obbligatorio="true" NomeCampo="Settore CPT" onchange="valorizzaHiddenForSave();" />
                </div>
            </div>
            <div class="row align-items-center py-3">               
                <div class="col-sm-3">
                    <label class="active fw-semibold" for="cmbCUPDimensioneTerr">Dimensione Territoriale</label>
                    <Siar:ComboCUPDimensioneTerr ID="cmbCUPDimensioneTerr" Obbligatorio="true" NomeCampo="Dimensione territoriale" onchange="valorizzaHiddenForSave();" runat="server"  />
                </div>
                  <div class="col-sm-6">
                      <label class="active fw-semibold">Tipo Operazione</label>
                      <Siar:ComboCUPCategoriaTipoOper ID="ucCmbTipoOper" Obbligatorio="true" NomeCampo="Tipo operazione" onchange="valorizzaHiddenForSave();" runat="server" />
                  </div>
            </div>
            <div class="row align-items-center py-3">
                <div class="col-sm-3">
                    <Siar:Button ID="btnSalvaMonitoraggio" runat="server" Modifica="True" OnClick="btnSalvaMonitoraggio_Click" Text="Salva" Width="200px" />
                </div>
            </div>
        </div>    
    </div>  

    <div id="tabLocalizzazioneInterventi" class="tableTab py-2" runat="server" visible="false">
        <div class="container-fluid bd-form">
            <h4 class="py-3 fw-bold">Localizzazione del progetto</h4>
            <p class="py-3 fw-semibold">
                Per inserire le localizzazioni relative alla domanda è necessario selezionare l'azienda
            di riferimento e scaricare i dati anagrafici, dopo di che sarà possibile inserire
            tutti i dati relativi.<br />
                Di default è selezionata l'azienda capofila della domanda.
            </p>

            <uc4:Indirizzo ID="ucIndirizzo" runat="server" />

            <uc6:SNCRicercaImpresa ID="RicercaImpresa" TestoCustom="Cerca" runat="server" />

            <div class="grid-row px-2">
                <Siar:Button ID="btnSalvaLocalizzazione" class="btn btn-primary py-1" runat="server" Modifica="True" Text="Salva" OnClick="btnSalvaLocalizzazione_Click" />
                <Siar:Button ID="btnElimina" runat="server" class="btn btn-primary py-1" Text="Elimina" CausesValidation="false" Modifica="false" OnClick="btnElimina_Click" Conferma="Attenzione, eliminare questa localizzazione?"></Siar:Button>
                <input type="button" class="btn btn-secondary py-1" value="Nuovo" onclick="pulisciCampi();" />
            </div>

            <div style="display: none">
                <asp:HiddenField ID="hdnIdLocalizzazioneSelezionata" runat="server" />
                <asp:Button ID="btnSelezionaLocalizzazione" runat="server" OnClick="btnSelezionaLocalizzazione_Click"
                    CausesValidation="false" />
            </div>
            <div class="col-sm-12">
                <div class="table-responsive">
                    <Siar:DataGridAgid ID="dgLocalizzazioni" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="30" AllowPaging="true">
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemStyle CssClass="DataGridRow itemStyle" />
                        <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
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
                            <Siar:ColonnaLink DataField="Via" HeaderText="Indirizzo" LinkFields="IdLocalizzazione"
                                IsJavascript="true" LinkFormat='caricaLocalizzazione({0})'>
                                <ItemStyle HorizontalAlign="Center" />
                            </Siar:ColonnaLink>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
            <div style="display: none;">
                <Siar:Button ID="btnNuovo" runat="server" CausesValidation="false"
                    Text="Nuovo" Modifica="False" OnClick="btnNuovo_Click"></Siar:Button>
            </div>
        </div>
    </div>
    <div id="tabDatiAnagraficiImpresa" runat="server" class="tableTab py-2" style="display: none;">
        <div class="container-fluid bd-form">
            <h4 class="py-3 fw-bold">Dati anagrafici impresa</h4>
            <uc7:ImpresaControl ID="ucImpresaControl" runat="server" ContoCorrenteVisibile="True" ClassificazioneUmaVisibile="false" />
        </div>
    </div>

</asp:Content>
