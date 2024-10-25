<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.DatiMonitoraggioFESR" CodeBehind="DatiMonitoraggioFESR.aspx.cs" %>

<%@ Register Src="~/CONTROLS/CUPCategoria.ascx" TagName="CUPCategoria" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/CUPCategoriaSoggetto.ascx" TagName="CUPCategoriaSoggetto" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/Ateco2007.ascx" TagName="Ateco2007" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript">
        function CheckNaturaCup(ev) {
            var natura_cup = $('[id$=ucCmbTipoOper]').val().substring(0, 2);
            var codice_ateco = $('[id$=cmbAteco]').val();
            if (natura_cup == '07'
                && (codice_ateco == '' || codice_ateco.indexOf(' - ') != 8)) {
                alert('Se il tipo operazione è di tipo \'CONCESSIONE DI INCENTIVI AD UNITA\' PRODUTTIVE\' è richiesto un Codice Ateco completo.');
                return false;
            }
            return true;
        }
    </script>
    <nav class="breadcrumb-container" aria-label="Percorso di navigazione">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="../PDomanda/BusinessPlan.aspx">
                <svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                </svg>
                Business plan</a><span class="separator">/</span></li>
            <li class="breadcrumb-item active" aria-current="page">Dati di monitoraggio</li>
        </ol>
    </nav>
    <div class="row bd-form pt-5 mx-2">
        <div class="col-sm-12 text-end">
            <a href="../PDomanda/BusinessPlan.aspx" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                </svg>Torna al Business plan</a>
        </div>
        <h2 class="pb-5">Dati di monitoraggio</h2>        
        <uc1:CUPCategoria ID="ucCUPCategoria" runat="server" CodiceFase="PDOMANDA" />
        <uc1:CUPCategoriaSoggetto ID="ucCUPCategoriaSoggetto" runat="server" CodiceFase="PDOMANDA" />
        <h3 class="pb-5">Altre classificazioni</h3>
        <div class="form-group col-sm-12">
            <Siar:ComboTemaPrioritario Label="Tema Prioritario:" ID="cmbTemaPrior" runat="server" Obbligatorio="true" NomeCampo="Tema prioritario" />
        </div>
        <uc1:Ateco2007 ID="selAteco2007" runat="server" />
        <div class="form-group col-sm-12">
            <Siar:ComboAttivitaEcon ID="cmbAttivitaEcon" Label="Attività economica:" runat="server" Obbligatorio="true" NomeCampo="Attività economica" />
        </div>
        <div class="form-group col-sm-12">
            <Siar:ComboCPTSettore Label="Settore CPT:" ID="cmbCPTSettore" runat="server" Obbligatorio="true" NomeCampo="Settore CPT" />
        </div>
        <div class="form-group col-sm-12">
            <Siar:ComboCUPDimensioneTerr Label="Dimensione Territoriale:" ID="cmbCUPDimensioneTerr" Obbligatorio="true" NomeCampo="Dimensione territoriale"
                runat="server" />
            <%--
        <div class="dtFrmRG">
            <span class ="dtFrmLabel1">Natura:</span>
            <Siar:ComboCUPNatura ID="cmbCUPNatura" runat="server" CssClass="dtFrmCtrl6" />
        </div>
            --%>
        </div>
        <div class="form-group col-sm-12">
            <Siar:ComboCUPCategoriaTipoOper Label="Tipo Operazione:" ID="ucCmbTipoOper" Obbligatorio="true" NomeCampo="Tipo operazione"
                runat="server" />
        </div>
        <h3 class="pb-5">Indicatori</h3>
        <div class="form-group col-sm-12">
            <uc1:ProgettoIndicatori ID="ucProgettoInd" runat="server" />
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalva" runat="server" Modifica="True" Text="Salva" Width="200px"
                OnClick="btnSalva_Click" OnClientClick="if (!CheckNaturaCup(event)) { return false; }" />
        </div>
        <div class="col-sm-12 text-end">
            <a href="../PDomanda/BusinessPlan.aspx" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                </svg>Torna al Business plan</a>
        </div>
    </div>
</asp:Content>
