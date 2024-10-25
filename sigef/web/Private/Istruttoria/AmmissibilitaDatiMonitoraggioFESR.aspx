<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="AmmissibilitaDatiMonitoraggioFESR.aspx.cs" Inherits="web.Private.Istruttoria.AmmissibilitaDatiMonitoraggioFESR" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/CUPCategoria.ascx" TagName="CUPCategoria" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/CUPCategoriaSoggetto.ascx" TagName="CUPCategoriaSoggetto"
    TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/Ateco2007.ascx" TagName="Ateco2007" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <uc1:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <br />
    <table class="tableNoTab" width="1050px">
        <tr>
            <td class="separatore_big">
                Ammissibilità dei dati di monitoraggio FESR
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <div class="dtFrm">
                    <div class="dtFrmSeparaBig">
                        DATI DI MONITORAGGIO</div>
                    <uc1:CUPCategoria ID="ucCUPCategoria" runat="server" CodiceFase="PDOMANDA" />
                    <uc1:CUPCategoriaSoggetto ID="ucCUPCategoriaSoggetto" runat="server" CodiceFase="PDOMANDA" />
                    <div class="dtFrmSeparaSmall">
                        Altre classificazioni</div>
                    <div class="dtFrmRG">
                        <span class="dtFrmLabel1">Tema Prioritario:</span>
                        <Siar:ComboTemaPrioritario ID="cmbTemaPrior" runat="server" Obbligatorio="true" NomeCampo="Tema prioritario"
                            CssClass="dtFrmCtrl6" />
                    </div>
                    <uc1:Ateco2007 ID="selAteco2007" runat="server" />
                    <div class="dtFrmRG">
                        <span class="dtFrmLabel1">Attività economica:</span>
                        <Siar:ComboAttivitaEcon ID="cmbAttivitaEcon" runat="server" Obbligatorio="true" NomeCampo="Attività economica"
                            CssClass="dtFrmCtrl6" />
                    </div>
                    <div class="dtFrmRG">
                        <span class="dtFrmLabel1">Settore CPT:</span>
                        <Siar:ComboCPTSettore ID="cmbCPTSettore" runat="server" Obbligatorio="true" NomeCampo="Settore CPT"
                            CssClass="dtFrmCtrl6" />
                    </div>
                    <div class="dtFrmRG">
                        <span class="dtFrmLabel1">Dimensione Territoriale:</span>
                        <Siar:ComboCUPDimensioneTerr ID="cmbCUPDimensioneTerr" Obbligatorio="true" NomeCampo="Dimensione territoriale"
                            runat="server" CssClass="dtFrmCtrl6" />
                    </div>
                    <div class="dtFrmRG">
                        <span class="dtFrmLabel1">Tipo Operazione:</span>
                        <Siar:ComboCUPCategoriaTipoOper ID="ucCmbTipoOper" Obbligatorio="true" NomeCampo="Tipo operazione"
                            runat="server" CssClass="dtFrmCtrl6" />
                    </div>
                    <div class="dtFrmSeparaSmall">
                        Indicatori</div>
                    <uc1:ProgettoIndicatori ID="ucProgettoInd" runat="server" />
                    <div class="dtFrmBottonieraBassa">
                        <Siar:Button ID="btnSalva" runat="server" Modifica="True" Text="Salva" Width="200px"
                            OnClick="btnSalva_Click" />
                        &nbsp;&nbsp;<input id="btnAmmissibilita" runat="server" type="button" class="Button"
                            value="Checklist di ammissibilità" style="width: 160px" />
                    </div>
                </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
