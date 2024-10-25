<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.Variante.InvestimentiFondoPerduto" CodeBehind="InvestimentiFondoPerduto.aspx.cs" %>

<%--<%@ Register Src="../../../CONTROLS/WorkFlowVarianti.ascx" TagName="WorkFlowVarianti"
    TagPrefix="uc1" %>--%>
<%@ Register Src="~/CONTROLS/CardVarianti.ascx" TagName="CardVarianti" TagPrefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript"><!--
    function tornaIndietro() { $('[id$=Button1]').click(); }
//--></script>
    <%--   <uc1:WorkFlowVarianti ID="ucWorkFlowVarianti" runat="server" />--%>
    <uc6:CardVarianti ID="ucCardVarianti" runat="server" />
    <div style="display: none">
        <asp:HiddenField ID="hdnIdInvestimento" runat="server" />
        <Siar:Button ID="Button1" runat="server" Text="Indietro" CausesValidation="False"
            OnClick="btnIndietro_Click" />
    </div>
    <nav class="breadcrumb-container" aria-label="Percorso di navigazione">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a onclick="tornaIndietro();">
                <svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check""></use>
                </svg>
                Piano Investimenti</a><span class="separator">/</span></li>
            <li class="breadcrumb-item active" aria-current="page">Investimenti Fondo Perduto</li>
        </ol>
    </nav>
    <div class="row bd-form py-5 mx-2">
        <div class="col-sm-12 text-end">
            <a onclick="tornaIndietro();" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                </svg>
                Torna al piano investimenti</a>
        </div>
        <h2 class="pb-5">Pagina di dettaglio degli investimenti</h2>
        <div id="tdInvestimentoComponent" runat="server"></div>
        <div class="col-sm-12 p-1 mt-5">
            <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                Text="Salva le modifiche" />

            <Siar:Button ID="btnNuovo" runat="server" CausesValidation="False" Modifica="True"
                OnClick="btnNuovoInvestimento_Click" Text="Nuovo investimento" />          
            <Siar:Button ID="btnAnnullaInvestimento" runat="server" CausesValidation="False"
                Modifica="True" OnClick="btnAnnullaInvestimento_Click" Text="Annulla investimento" Conferma="Attenzione! Annullare l`investimento?" />
            <Siar:Button ID="btnRipristina" runat="server" CausesValidation="False" Modifica="True"
                OnClick="btnRipristinaInvestimento_Click" Text="Ripristina" Conferma="Attenzione! Ripristinare l`investimento annullato?" />
        </div>
        <div class="col-sm-12 text-end">
            <a onclick="tornaIndietro();" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
                </svg>
                Torna al piano investimenti</a>
        </div>
    </div>
</asp:Content>
