<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.admin.GestioneCup" CodeBehind="GestioneCup.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/AdminCUPCategoria.ascx" TagName="AdminCUPCategoria" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/AdminCUPCategoriaSoggetto.ascx" TagName="AdminCUPCategoriaSoggetto" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/Indirizzo.ascx" TagName="Indirizzo" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/AdminAteco2007.ascx" TagName="AdminAteco2007" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/SNCRicercaImpresa.ascx" TagName="SNCRicercaImpresa" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/ImpresaControl.ascx" TagName="ImpresaControl" TagPrefix="uc3" %>

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

    <table class="tableNoTab" style="width: 388px">
        <tr>
            <td class="separatore">RICERCA DOMANDA DI AIUTO
            </td>
        </tr>
        <tr>
            <td style="height: 38px; padding-left: 10px">- Indicare il numero identificativo della domanda.
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbCodRicerca" width="100%" runat="server">
                    <tr>
                        <td style="height: 31px;" valign="top">
                            <strong>&nbsp; Numero domanda:</strong>&nbsp;
                            <Siar:IntegerTextBox ID="txtNumDomanda" runat="server" Width="84px" Obbligatorio="true"
                                NoCurrency="true" NomeCampo="Numero domanda" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 31px" valign="top">
                            <Siar:Button ID="btnCerca" runat="server" Width="133px" Text="Cerca" OnClick="btnCerca_Click"
                                CausesValidation="true"></Siar:Button>&nbsp; &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />

    <table width="800px" class="tableNoTab">
        <tr>
            <td class="separatore_light">Risultato ricerca:
            </td>
        </tr>
        <tr>
            <td id="tdDomanda" runat="server" style="padding-top: 15px; padding-bottom: 15px"></td>
           </tr>
        <tr>
            <td></td>
        </tr>
    </table>
    <table>
        <tr>
            <td>&nbsp;&nbsp;</td>
        </tr>
    </table>
    <uc1:SiarNewTab Width="900px" ID="ucSiarNewTab" runat="server" Visible="false" TabNames="Gestione CUP|Dati monitoraggio FESR|Localizzazione interventi|Dati anagrafici impresa" />
    <table id="tabCUP" class="tableTab" runat="server" visible="false">
        <tr>
            <td class="separatore_light">Dati CUP:
            </td>
        </tr>
        <tr>
            <td>
                <div class="dtFrm">
                    <div class="dtFrmRG">
                        <span>Codice :</span>&nbsp;&nbsp;&nbsp;
                        <Siar:TextBox ID="txtCodAgea" runat="server" Width="200px" Obbligatorio="false"
                            MaxLength="30" NomeCampo="Codice Agea" />
                    </div>
                    <div class="dtFrmBottonieraBassa">
                        <Siar:Button ID="btnSalvaCUP" runat="server" Width="160px" Text="Salva" OnClientClick="if(!controlloCUP()) return false;" OnClick="btnSalvaCUP_Click" Modifica="true"></Siar:Button>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <table  id="tabMonitoraggioFesr" class="tableTab" runat="server" visible="false">
        <tr>
            <td class="separatore_light">Monitoriaggio FESR:
            </td>
        </tr>
        <tr>
            <td>
                <div class="dtFrm">
                    <div class="dtFrmSeparaBig">
                        DATI DI MONITORAGGIO
                    </div>
                    <uc1:AdminCUPCategoria ID="ucCUPCategoria" runat="server" CodiceFase="PDOMANDA" />
                    <uc1:AdminCUPCategoriaSoggetto ID="ucCUPCategoriaSoggetto" runat="server" CodiceFase="PDOMANDA" />
                    <asp:HiddenField ID="hdnSaveDatiMonitoraggio" runat="server" />
                    <div class="dtFrmSeparaSmall">
                        Altre classificazioni
                    </div>
                    <div class="dtFrmRG">
                        <span class="dtFrmLabel1">Tema Prioritario:</span>
                        <Siar:ComboTemaPrioritario ID="cmbTemaPrior" runat="server" Obbligatorio="true" NomeCampo="Tema prioritario" onchange="valorizzaHiddenForSave();"
                            CssClass="dtFrmCtrl6" />
                    </div>
                    <uc1:AdminAteco2007 ID="selAteco2007" runat="server" />
                    <div class="dtFrmRG">
                        <span class="dtFrmLabel1">Attività economica:</span>
                        <Siar:ComboAttivitaEcon ID="cmbAttivitaEcon" runat="server" Obbligatorio="true" NomeCampo="Attività economica" onchange="valorizzaHiddenForSave();"
                            CssClass="dtFrmCtrl6" />
                    </div>
                    <div class="dtFrmRG">
                        <span class="dtFrmLabel1">Settore CPT:</span>
                        <Siar:ComboCPTSettore ID="cmbCPTSettore" runat="server" Obbligatorio="true" NomeCampo="Settore CPT" onchange="valorizzaHiddenForSave();"
                            CssClass="dtFrmCtrl6" />
                    </div>
                    <div class="dtFrmRG">
                        <span class="dtFrmLabel1">Dimensione Territoriale:</span>
                        <Siar:ComboCUPDimensioneTerr ID="cmbCUPDimensioneTerr" Obbligatorio="true" NomeCampo="Dimensione territoriale" onchange="valorizzaHiddenForSave();"
                            runat="server" CssClass="dtFrmCtrl6" />
                    </div>

                    <div class="dtFrmRG">
                        <span class="dtFrmLabel1">Tipo Operazione:</span>
                        <Siar:ComboCUPCategoriaTipoOper ID="ucCmbTipoOper" Obbligatorio="true" NomeCampo="Tipo operazione" onchange="valorizzaHiddenForSave();"
                            runat="server" CssClass="dtFrmCtrl6" />
                    </div>
                    <div class="dtFrmBottonieraBassa">
                        <Siar:Button ID="btnSalvaMonitoraggio" runat="server" Modifica="True" OnClick="btnSalvaMonitoraggio_Click" Text="Salva" Width="200px" />
  
                    </div>
                </div>
             </td>
        </tr>

  
    </table>
    <table  id="tabLocalizzazioneInterventi" class="tableTab" runat="server" visible="false">
        <tr>
            <td>
                <div class="dtFrm">
                    <div class="dtFrmSeparaBig">
                        Localizzazione del progetto
                    </div>
                    <div class="testo_pagina">
                    Per inserire le localizzazioni relative alla domanda è necessario selezionare l'azienda
            di riferimento e scaricare i dati anagrafici, dopo di che sarà possibile inserire
            tutti i dati relativi.
            <br />
                        Di default è selezionata l'azienda capofila della domanda.<br />
                        <br />
                    </div>
                    <uc1:Indirizzo ID="ucIndirizzo" runat="server" />
                    <br />
                    <div>
                        Azienda:
            <br />
                        <uc2:SNCRicercaImpresa ID="RicercaImpresa" TestoCustom="Cerca" runat="server" />
                    </div>
                    <div class="dtFrmBottonieraBassa">
                        <Siar:Button ID="btnSalvaLocalizzazione" runat="server" Modifica="True" Text="Salva" Width="200px" OnClick="btnSalvaLocalizzazione_Click" />
            <Siar:Button ID="btnElimina" runat="server" Width="140px" Text="Elimina" CausesValidation="false"
                Modifica="false" OnClick="btnElimina_Click" Conferma="Attenzione, eliminare questa localizzazione?"></Siar:Button>
                        &nbsp;&nbsp;&nbsp;<input type="button" class="Button" value="Nuovo" style="width: 120px"
                            onclick="pulisciCampi();" />
                    </div>
                    <br />
                    <div>
                        <div style="display: none">
                            <asp:HiddenField ID="hdnIdLocalizzazioneSelezionata" runat="server" /> 
                            <asp:Button ID="btnSelezionaLocalizzazione" runat="server" OnClick="btnSelezionaLocalizzazione_Click"
                                CausesValidation="false" />
                        </div>
                        <Siar:DataGrid ID="dgLocalizzazioni" runat="server" Width="99%" AllowPaging="True"
                            PageSize="30" AutoGenerateColumns="False" EnableViewState="False" ShowShadow="False"
                            CssClass="tabella">
                            <Columns>
                                <Siar:NumberColumn HeaderText="Nr.">
                                    <ItemStyle Width="30px" HorizontalAlign="center" />
                                </Siar:NumberColumn>
                                <asp:BoundColumn DataField="IdImpresa" HeaderText="Impresa">
                                    <ItemStyle Width="250px" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IdComune" HeaderText="Comune">
                                    <ItemStyle Width="250px" HorizontalAlign="left" />
                                </asp:BoundColumn>
                                <Siar:ColonnaLink DataField="Via" HeaderText="Indirizzo" LinkFields="IdLocalizzazione"
                                    IsJavascript="true" LinkFormat='caricaLocalizzazione({0})'>
                                    <ItemStyle Width="250px" HorizontalAlign="Center" />
                                </Siar:ColonnaLink>
                            </Columns>
                        </Siar:DataGrid>&nbsp;
                    </div>
                    <div style="display: none;">
                        <Siar:Button ID="btnNuovo" runat="server" CausesValidation="false" Width="140px"
                            Text="Nuovo" Modifica="False" OnClick="btnNuovo_Click"></Siar:Button>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <table id="tabDatiAnagraficiImpresa" runat="server" class="tableTab" style="display:none;">
        <tr>
            <td class="separatore_light">
                Dati anagrafici impresa
            </td>
        </tr>
        <tr>
            <td>
                <uc3:ImpresaControl ID="ucImpresaControl" runat="server" ContoCorrenteVisibile="True"
                                    ClassificazioneUmaVisibile="false" />
            </td>
        </tr>
    </table>

</asp:Content>
