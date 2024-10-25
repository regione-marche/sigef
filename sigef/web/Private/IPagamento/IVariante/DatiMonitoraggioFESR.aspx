<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" 
CodeBehind="DatiMonitoraggioFESR.aspx.cs" Inherits="web.Private.IPagamento.IVariante.DatiMonitoraggioFESR" %>

<%@ Register Src="../../../CONTROLS/IVariantiControl.ascx" TagName="IVariantiControl"
    TagPrefix="uc1" %>
<%@ Register Src="../../../CONTROLS/CUPCategoria.ascx" TagName="CUPCategoria" TagPrefix="uc2" %>
<%@ Register Src="../../../CONTROLS/CUPCategoriaSoggetto.ascx" TagName="CUPCategoriaSoggetto" TagPrefix="uc3" %>
<%@ Register Src="../../../CONTROLS/Ateco2007.ascx" TagName="Ateco2007" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc1:IVariantiControl ID="ucWorkFlowVarianti" runat="server" />
    <br />
    <div class="dtFrm">
        <div class="dtFrmSeparaBig">DATI DI MONITORAGGIO</div>
        <uc2:CUPCategoria ID="ucCUPCategoria" runat="server" CodiceFase="PDOMANDA" />
        <uc3:CUPCategoriaSoggetto ID="ucCUPCategoriaSoggetto" runat="server" CodiceFase="PDOMANDA" />
        <div class="dtFrmSeparaSmall">Altre classificazioni</div>
        <div class="dtFrmRG">
            <span class ="dtFrmLabel1">Tema Prioritario:</span>
            <Siar:ComboTemaPrioritario ID="cmbTemaPrior" runat="server" Obbligatorio="true" NomeCampo="Tema prioritario" CssClass="dtFrmCtrl6" />
        </div>
        <uc4:Ateco2007 ID="selAteco2007" runat="server" />
        
        <div class="dtFrmRG">
            <span class ="dtFrmLabel1">Attività economica:</span>
            <Siar:ComboAttivitaEcon ID="cmbAttivitaEcon" runat="server" Obbligatorio="true" NomeCampo="Attività economica" CssClass="dtFrmCtrl6" />
        </div>
        <div class="dtFrmRG">
            <span class ="dtFrmLabel1">Settore CPT:</span>
            <Siar:ComboCPTSettore ID="cmbCPTSettore" runat="server" Obbligatorio="true" NomeCampo="Settore CPT" CssClass="dtFrmCtrl6" />        
        </div>
        <div class="dtFrmRG">
            <span class ="dtFrmLabel1">Dimensione Territoriale:</span>
            <Siar:ComboCUPDimensioneTerr ID="cmbCUPDimensioneTerr" Obbligatorio="true" NomeCampo="Dimensione territoriale" runat="server" CssClass="dtFrmCtrl6" />        
        </div>                
<%--        <div class="dtFrmRG">
            <span class ="dtFrmLabel1">Natura:</span>
            <Siar:ComboCUPNatura ID="cmbCUPNatura" runat="server" CssClass="dtFrmCtrl6" />        
        </div>--%>
        <div class="dtFrmRG">                
            <span class ="dtFrmLabel1">Tipo Operazione:</span>
            <Siar:ComboCUPCategoriaTipoOper ID="ucCmbTipoOper" Obbligatorio="true" NomeCampo="Tipo operazione" runat="server" CssClass="dtFrmCtrl6" />
        </div>
        <div class="dtFrmBottonieraBassa">                
            <Siar:Button ID="btnSalva" runat="server" Modifica="True" Text="Salva" Width="200px" OnClick="btnSalva_Click" />
        </div>
    </div>
</asp:Content>