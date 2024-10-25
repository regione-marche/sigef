<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
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

        function caricaLocalizzazione(id) { $('[id$=hdnIdLocalizzazioneSelezionata]').val(id); $('[id$=btnSelezionaLocalizzazione]').click(); }
    </script>
    <nav class="breadcrumb-container" aria-label="Percorso di navigazione">
          <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="../PDomanda/BusinessPlan.aspx"><svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use></svg>Business plan</a><span class="separator">/</span></li>            
            <li class="breadcrumb-item active" aria-current="page">Localizzazione del progetto</li>
          </ol>
        </nav>
    <%--    <nav class="breadcrumb-container" aria-label="Percorso di navigazione">
  <ol class="breadcrumb dark px-3">
            <li class="breadcrumb-item"><a href="../PDomanda/BusinessPlan.aspx"><svg class="icon icon-white icon-sm icon-secondary align-top me-1" aria-hidden="true"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use></svg>Business plan</a><span class="separator">/</span></li>            
            <li class="breadcrumb-item active" aria-current="page">Localizzazione del progetto</li>
          </ol>
        </nav>--%>
    <div class="row bd-form pt-5 mx-2">
        <div class="col-sm-12 text-end">
            <a href="../PDomanda/BusinessPlan.aspx" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                </svg>Torna al Business plan</a>
        </div>
        <h2 class="pb-5">Localizzazione del progetto</h2>
        <p>
            Per inserire le localizzazioni relative alla domanda è necessario selezionare l'azienda di riferimento e scaricare i dati anagrafici, dopo di che sarà possibile inserire tutti i dati relativi.          
        </p>
        <p>
            Di default è selezionata l'azienda capofila della domanda.<br />
        </p>
        <uc1:Indirizzo ID="ucIndirizzo" runat="server" />        
        <h3 class="pb-5">Azienda:</h3>
        <uc2:SNCRicercaImpresa ID="RicercaImpresa" runat="server" />
        <div class="col-sm-12">
            <Siar:Button ID="btnSalva" runat="server" Modifica="True" Text="Salva" Width="200px"
                OnClick="btnSalva_Click" />
            <Siar:Button ID="btnElimina" runat="server" Width="140px" Text="Elimina" CausesValidation="false"
                Modifica="false" OnClick="btnElimina_Click" Conferma="Attenzione, eliminare questa localizzazione?"></Siar:Button>
            <input type="button" class="btn btn-secondary py-1" value="Nuovo" style="width: 120px"
                onclick="pulisciCampi();" />
        </div>
        <div class="col-sm-12">
            <div style="display: none">
                <asp:HiddenField ID="hdnIdLocalizzazioneSelezionata" runat="server" />
                <asp:Button ID="btnSelezionaLocalizzazione" runat="server" OnClick="btnSelezionaLocalizzazione_Click"
                    CausesValidation="false" />
            </div>
            <Siar:DataGridAgid ID="dgLocalizzazioni" runat="server" AllowPaging="True"
                PageSize="30" AutoGenerateColumns="False" EnableViewState="False" ShowShadow="False"
                CssClass="table table-striped">
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
            </Siar:DataGridAgid>&nbsp;
       
        </div>
        <div style="display: none;">
            <Siar:Button ID="btnNuovo" runat="server" CausesValidation="false" Width="140px"
                Text="Nuovo" Modifica="False" OnClick="btnNuovo_Click"></Siar:Button>
        </div>
        <div class="col-sm-12 text-end">
            <a href="../PDomanda/BusinessPlan.aspx" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                </svg>Torna al Business plan</a>
        </div>
    </div>
</asp:Content>
