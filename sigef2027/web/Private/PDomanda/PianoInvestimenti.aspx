<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.PianoInvestimenti" CodeBehind="PianoInvestimenti.aspx.cs" %>

<%@ Register Src="../../CONTROLS/PianoInvestimenti.ascx" TagName="PianoInvestimenti"
    TagPrefix="uc1" %>

<%@ Register Src="../../CONTROLS/PianoInvestimentiAggregazione.ascx" TagName="PianoInvestimentiAggregazione"
    TagPrefix="uc2" %>

<%@ Register Src="../../CONTROLS/PianoInvestimentiCodifica.ascx" TagName="PianoInvestimentiCodifica"
    TagPrefix="uc3" %>

<%@ Register Src="../../CONTROLS/PianoInvestimentiIntervento.ascx" TagName="PianoInvestimentiIntervento"
    TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <nav class="breadcrumb-container" aria-label="Percorso di navigazione">
          <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="../PDomanda/BusinessPlan.aspx"><svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use></svg>Business plan</a><span class="separator">/</span></li>            
            <li class="breadcrumb-item active" aria-current="page">Piano degli investimenti della domanda di aiuto</li>
          </ol>
        </nav>
    <div class="row bd-form pt-5 mx-2">
        <div class="col-sm-12 text-end">
            <a href="../PDomanda/BusinessPlan.aspx" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                </svg>Torna al Business plan</a>
        </div>
        <h2 class="pb-5">Piano degli investimenti della domanda di aiuto</h2>
        <div class="col-sm-12">            
            <div id="tdButtoniPage" runat="server" class="col-sm-12"></div>
            <uc1:PianoInvestimenti ID="ucPianoInvestimenti" runat="server" CodiceFase="PDOMANDA" />
            <uc2:PianoInvestimentiAggregazione ID="PianoInvestimentiAggregazione" runat="server" CodiceFase="PDOMANDA" />
            <uc3:PianoInvestimentiCodifica ID="PianoInvestimentiCodifica" runat="server" CodiceFase="PDOMANDA" />
            <uc4:PianoInvestimentiIntervento ID="PianoInvestimentiIntervento" runat="server" CodiceFase="PDOMANDA" />
        </div>
        <div class="col-sm-12 text-end pt-3">
            <a href="../PDomanda/BusinessPlan.aspx" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                </svg>Torna al Business plan</a>
        </div>
    </div>
</asp:Content>
