<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="Localizzazione.aspx.cs" Inherits="web.Private.PPagamento.Variante.Localizzazione" %>

<%@ Register Src="../../../CONTROLS/WorkFlowVarianti.ascx" TagName="WorkFlowVarianti"     TagPrefix="uc1" %>
<%@ Register Src="../../../CONTROLS/Indirizzo.ascx" TagName="Indirizzo"                   TagPrefix="uc3" %> 
<%@ Register Src="../../../CONTROLS/SNCRicercaImpresa.ascx" TagName="SNCRicercaImpresa"   TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
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

    <uc1:WorkFlowVarianti ID="ucWorkFlowVarianti" runat="server" />
    <br />
    <div style="display: none">
        <asp:HiddenField ID="hdnIdLocalizzazioneSelezionataPopup" runat="server" />
        <asp:Button ID="btnApriPopup" runat="server" OnClick="btnApriPopup_Click" CausesValidation="false" />
    </div>
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                Localizzazione del progetto
            </td>
        </tr>
        <tr>
            <td>
                <div class="testo_pagina">
                    Per inserire le localizzazioni relative alla domanda è necessario selezionare l'azienda
                    di riferimento e scaricare i dati anagrafici, dopo di che sarà possibile inserire
                    tutti i dati relativi.
                    <br />
                    Di default è selezionata l'azienda capofila della domanda.<br />
                    <br />
                </div>
                <uc3:Indirizzo ID="ucIndirizzo" runat="server" />
                <br />
                <div>
                    Azienda:
                    <br />
                    <uc2:SNCRicercaImpresa ID="RicercaImpresa" TestoCustom="Cerca" runat="server" />
                </div>
                <div class="dtFrmBottonieraBassa">
                    <Siar:Button ID="btnSalva" runat="server" Modifica="False" Text="Salva" Width="200px"
                        OnClick="btnSalva_Click" />
                    &nbsp;&nbsp;
                    <Siar:Button ID="btnElimina" runat="server" Width="140px" Text="Elimina" CausesValidation="false"
                        Modifica="false" OnClick="btnElimina_Click" Conferma="Attenzione, eliminare questa localizzazione?">
                    </Siar:Button>
                    &nbsp;&nbsp;&nbsp;<input type="button" class="Button" value="Nuovo" style="width: 120px"
                        onclick="pulisciCampi();" />
                </div>
                <br />
                <div>
                    <div style="display: none">
                        <asp:HiddenField ID="hdnIdLocalizzazioneSelezionata" runat="server" />
                        <asp:Button ID="btnSelezionaLocalizzazione" runat="server" OnClick="btnSelezionaLocalizzazione_Click"
                            CausesValidation="false" /></div>
                    <Siar:DataGrid ID="dgLocalizzazioni" runat="server" Width="99%" AllowPaging="True"
                        PageSize="30" AutoGenerateColumns="False" EnableViewState="False" ShowShadow="False"
                        CssClass="tabella">
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
                    </Siar:DataGrid>&nbsp;
                </div>
                <div style="display: none;">
                    <Siar:Button ID="btnNuovo" runat="server" CausesValidation="false" Width="140px"
                        Text="Nuovo" Modifica="False" OnClick="btnNuovo_Click"></Siar:Button>
                </div>
            </td>
        </tr>
    </table>
    <div id="divLocalizzazioneStorico" style="width: 1100px; position: absolute; display: none;">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">Elenco delle storico della localizzazione selezionata modificate:
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td>
                                <Siar:DataGrid ID="dgLocalizzazioniStorico" runat="server" Width="99%" AllowPaging="True"
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
                                    <asp:BoundColumn DataField="Via" HeaderText="Indirizzo">
                                        <ItemStyle Width="250px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn  HeaderText="Operatore">
                                        <ItemStyle Width="150px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataModifica"  HeaderText="Data Modifica">
                                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    </Columns>
                                </Siar:DataGrid>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 70px;">
                                <input class="Button" onclick="chiudiPopupTemplate();" style="width: 100px; margin-left: 20px; margin-right: 20px"
                                    type="button" value="Chiudi" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
