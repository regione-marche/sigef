<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.InvestimentiFondoPerduto" CodeBehind="InvestimentiFondoPerduto.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
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
        <li class="breadcrumb-item"><a id="linkBreadcrumb2" runat="server">
            <svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true">
                <use href="/web/bootstrap-italia/svg/sprites.svg#it-card""></use>
            </svg>
            Istruttoria piano investimenti</a><span class="separator">/</span></li>
        <li class="breadcrumb-item active" aria-current="page">Istruttoria investimento</li>
    </ol>
    </nav>
    <input id="hdnIdInvestimento" type="hidden" name="hdnIdInvestimento" runat="server" />
    <div class="row bd-form py-5">
        <div class="col-sm-12 text-end pt-5">
            <a id="btnBack" runat="server" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-card"></use>
                </svg>
                Torna all'istruttoria del piano investimenti</a>
        </div>
        <h2 class="pb-5">Pagina di dettaglio degli investimenti</h2>
        <div class="row" id="tdInvestimentoComponent" runat="server">
        </div>
        <div class="col-sm-12 pt-5 text-center">
            <Siar:Button ID="btnSalvaInvestimento" runat="server" Modifica="True" Text="Ammetti investimento"
                OnClick="btnSalvaInvestimento_Click" />
            <input id="btnIstruttoriaAllegati" runat="server" class="btn btn-secondary py-1"
                type="button" value="Controllo degli allegati" />
        </div>
        <div class="col-sm-12 pt-5 text-center">
            <Siar:Button ID="btnRicarica" runat="server" Conferma="Si è scelto di ricaricare i dati dell`investimento precedentemente ammesso. Questa modifica non è definitiva, continuare?"
                Modifica="True" OnClick="btnRicarica_Click" Text="Ricarica dati originali" />
            <Siar:Button ID="btnDuplica" runat="server" Modifica="True" Text="Duplica investimento"
                OnClick="btnDuplica_Click" Conferma="Si è scelto di duplicare l`investimento. Continuare?" />
            <Siar:Button ID="btnDeleteDuplicato" runat="server" Modifica="True" Text="Elimina investimento duplicato"
                OnClick="btnDeleteDuplicato_Click" Conferma="Eliminare l`investimento duplicato?" />
        </div>
        <div class="col-sm-12 text-end pt-5">
            <a id="btnBackDown" runat="server" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-card"></use>
                </svg>
                Torna all'istruttoria del piano investimenti</a>
        </div>
    </div>
</asp:Content>
