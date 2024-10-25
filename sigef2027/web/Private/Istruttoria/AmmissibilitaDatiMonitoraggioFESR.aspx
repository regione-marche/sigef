<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="AmmissibilitaDatiMonitoraggioFESR.aspx.cs" Inherits="web.Private.Istruttoria.AmmissibilitaDatiMonitoraggioFESR" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/CUPCategoria.ascx" TagName="CUPCategoria" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/CUPCategoriaSoggetto.ascx" TagName="CUPCategoriaSoggetto"
    TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/Ateco2007.ascx" TagName="Ateco2007" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc1:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <nav class="breadcrumb-container" aria-label="Percorso di navigazione">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a onclick="location='Ammissibilita.aspx'">
            <svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true">
                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check""></use>
            </svg>
            Ammissibilità</a><span class="separator">/</span></li>        
        <li class="breadcrumb-item active" aria-current="page">Ammissibilità dei dati di monitoraggio FESR</li>
    </ol>
    </nav>
    <div class="row bd-form py-5">
        <div class="col-sm-12 text-end">
            <a onclick="location='Ammissibilita.aspx'" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna alla checklist di ammissibilità</a>
        </div>
        <h2 class="py-5">Ammissibilità dei dati di monitoraggio FESR:</h2>
        <uc1:CUPCategoria ID="ucCUPCategoria" runat="server" CodiceFase="PDOMANDA" />
        <uc1:CUPCategoriaSoggetto ID="ucCUPCategoriaSoggetto" runat="server" CodiceFase="PDOMANDA" />
        <h3 class="pb-5">
            Altre classificazioni
        </h3>
        <div class="col-sm-12 form-group">            
            <Siar:ComboTemaPrioritario Label="Tema Prioritario:" ID="cmbTemaPrior" runat="server" Obbligatorio="true" NomeCampo="Tema prioritario"
                CssClass="dtFrmCtrl6" />
        </div>
        <uc1:Ateco2007 ID="selAteco2007" runat="server" />
        <div class="col-sm-12 form-group">            
            <Siar:ComboAttivitaEcon Label="Attività economica:" ID="cmbAttivitaEcon" runat="server" Obbligatorio="true" NomeCampo="Attività economica"
                CssClass="dtFrmCtrl6" />
        </div>
        <div class="col-sm-12 form-group">            
            <Siar:ComboCPTSettore Label="Settore CPT:" ID="cmbCPTSettore" runat="server" Obbligatorio="true" NomeCampo="Settore CPT"
                CssClass="dtFrmCtrl6" />
        </div>
        <div class="col-sm-12 form-group">            
            <Siar:ComboCUPDimensioneTerr Label="Dimensione Territoriale:" ID="cmbCUPDimensioneTerr" Obbligatorio="true" NomeCampo="Dimensione territoriale"
                runat="server" CssClass="dtFrmCtrl6" />
        </div>
        <div class="col-sm-12 form-group">            
            <Siar:ComboCUPCategoriaTipoOper Label="Tipo Operazione:" ID="ucCmbTipoOper" Obbligatorio="true" NomeCampo="Tipo operazione"
                runat="server" CssClass="dtFrmCtrl6" />
        </div>
        <h3 class="pb-5">Indicatori
        </h3>
        <uc1:ProgettoIndicatori ID="ucProgettoInd" runat="server" />
        <div class="col-sm-12">
            <Siar:Button ID="btnSalva" runat="server" Modifica="True" Text="Salva"
                OnClick="btnSalva_Click" />
        </div>
        <div class="col-sm-12 text-end">
            <a onclick="location='Ammissibilita.aspx'" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna alla checklist di ammissibilità</a>
        </div>
    </div>
</asp:Content>
