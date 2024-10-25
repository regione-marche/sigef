<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.LocalizzazioniProgetto" CodeBehind="LocalizzazioniProgetto.aspx.cs" %>

<%@ Register Src="../../CONTROLS/Indirizzo.ascx" TagName="Indirizzo" TagPrefix="uc1" %>
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
        
        function caricaLocalizzazione(id) { $('[id$=hdnIdLocalizzazioneSelezionata]').val(id);$('[id$=btnSelezionaLocalizzazione]').click(); } 
    </script>

    <br />
    <div class="dtFrm">
        <div class="dtFrmSeparaBig">
            Localizzazione del progetto</div>
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
            <Siar:Button ID="btnSalva" runat="server" Modifica="True" Text="Salva" Width="200px"
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
                    <Siar:ColonnaLink DataField="Cap" HeaderText="Cap" LinkFields="IdLocalizzazione"
                        IsJavascript="true" LinkFormat='caricaLocalizzazione({0})'>
                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                    </Siar:ColonnaLink>
                    <asp:BoundColumn HeaderText="Via">
                        <ItemStyle Width="250px" HorizontalAlign="left" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>&nbsp;
        </div>
        <div style="display: none;">
            <Siar:Button ID="btnNuovo" runat="server" CausesValidation="false" Width="140px"
                Text="Nuovo" Modifica="False" OnClick="btnNuovo_Click"></Siar:Button>
        </div>
    </div>
</asp:Content>
