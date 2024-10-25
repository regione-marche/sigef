<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SigefAgidPrivate.master"
    EnableViewState="false" Inherits="web.Private.PDomanda.InvestimentiFondoPerduto"
    CodeBehind="InvestimentiFondoPerduto.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript"><!--
    function tornaIndietro() { $('[id$=Button1]').click(); }
//--></script>
    <div style="display: none">
        <Siar:Button ID="Button1" runat="server" Text="Indietro" CausesValidation="False"
            OnClick="btnIndietro_Click" />
    </div>
    <nav class="breadcrumb-container" aria-label="Percorso di navigazione">
          <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="../PDomanda/BusinessPlan.aspx"><svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use></svg>Business plan</a><span class="separator">/</span></li>            
            <li class="breadcrumb-item"><a id="linkPianoInvestimenti" onclick="tornaIndietro();"><svg class="icon icon-breadcrumb icon-secondary align-top me-1" aria-hidden="true"><use href="/web/bootstrap-italia/svg/sprites.svg#it-note"></use></svg>Piano degli investimenti della domanda di aiuto</a><span class="separator">/</span></li>
            <li class="breadcrumb-item active" aria-current="page">Pagina di dettaglio degli investimenti</li>
          </ol>
        </nav>
    <asp:HiddenField ID="hdnIdInvestimento" runat="server" />
    <div class="row bd-form pt-5 mx-2">
        <div class="col-sm-12 text-end">
            <a onclick="tornaIndietro();" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-note"></use>
                </svg>Torna al Piano degli investimenti</a>
        </div>
        <h2 class="pb-5">Pagina di dettaglio degli investimenti</h2>
        <div class="col-sm-12">            
            <div id="tdInvestimentoComponent" runat="server">
            </div>
        </div>
        <div class="col-sm-12 py-3">
            <Siar:Button ID="btnSalvaInvestimento" runat="server" Modifica="True" Text="Salva investimento"
                OnClick="btnSalvaInvestimento_Click" />
            <Siar:Button ID="btnDelete" runat="server" Modifica="True" Text="Elimina investimento"
                OnClick="btnDelete_Click" CausesValidation="False" Conferma="Eliminare l`investimento?" />
            <Siar:Button ID="btnNew" runat="server" CausesValidation="false" Modifica="True"
                OnClick="btnNew_Click" Text="Nuovo investimento" />
        </div>
        <div class="col-sm-12 text-end pt-3">
            <a onclick="tornaIndietro();" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-note"></use>
                </svg>Torna al Piano degli investimenti</a>
        </div>
    </div>
</asp:Content>
