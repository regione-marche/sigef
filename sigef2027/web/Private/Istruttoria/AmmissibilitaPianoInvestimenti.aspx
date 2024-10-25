<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.AmmissibilitaPianoInvestimenti" CodeBehind="AmmissibilitaPianoInvestimenti.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/PianoInvestimenti.ascx" TagName="PianoInvestimenti"
    TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/PianoInvestimentiAggregazione.ascx" TagName="PianoInvestimentiAggregazione"
    TagPrefix="uc3" %>

<%@ Register Src="../../CONTROLS/PianoInvestimentiCodifica.ascx" TagName="PianoInvestimentiCodifica"
    TagPrefix="uc4" %>

<%@ Register Src="../../CONTROLS/PianoInvestimentiIntervento.ascx" TagName="PianoInvestimentiIntervento"
    TagPrefix="uc5" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc1:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <nav class="breadcrumb-container" aria-label="Percorso di navigazione">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a onclick="location='Ammissibilita.aspx'">
            <svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true">
                <use href="/web/bootstrap-italia/svg/sprites.svg#it-check""></use>
            </svg>
            Ammissibilità</a><span class="separator">/</span></li>
        <li class="breadcrumb-item"><a id="linkBreadcrumb" runat="server">
            <svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true">
                <use href="/web/bootstrap-italia/svg/sprites.svg#it-list""></use>
            </svg>
            Checklist d'istruttoria d'ammissibilità</a><span class="separator">/</span></li>
        <li class="breadcrumb-item active" aria-current="page">Istruttoria piano investimenti</li>
    </ol>
    </nav>
    <div class="row py-5 mx-2">
        <div class="col-sm-12 text-end">
            <a id="btnBack" runat="server" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna alla checklist di ammissibilità</a>
        </div>
        <h2 class="pb-5">Ammissibilità del piano di investimenti della domanda:</h2>
        <div class="col-sm-12 pb-2" id="tdButtoniPage" runat="server"></div>
        <uc2:PianoInvestimenti ID="ucPianoInvestimenti" runat="server" CodiceFase="IDOMANDA" />
        <uc3:PianoInvestimentiAggregazione ID="PianoInvestimentiAggregazione" runat="server" CodiceFase="IDOMANDA" />
        <uc4:PianoInvestimentiCodifica ID="PianoInvestimentiCodifica" runat="server" CodiceFase="IDOMANDA" />
        <uc5:PianoInvestimentiIntervento ID="PianoInvestimentiIntervento" runat="server" CodiceFase="IDOMANDA" />
        <div class="col-sm-12 text-end pt-5">
            <a id="btnBackDown" runat="server" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna alla checklist di ammissibilità</a>
        </div>
    </div>
</asp:Content>
