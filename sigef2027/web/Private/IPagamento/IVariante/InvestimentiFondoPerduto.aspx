<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IVariante.InvestimentiFondoPerduto" CodeBehind="InvestimentiFondoPerduto.aspx.cs" %>

<%@ Register Src="~/CONTROLS/CardVariantiIstruttoria.ascx" TagName="CardVariantiIstruttoria" TagPrefix="uc1" %>
<%@ Register Src="../../../CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript"><!--
             function tornaIndietro() { $('[id$=Button1]').click(); }
    </script>
     <div style="display: none">
         <asp:HiddenField ID="hdnIdInvestimento" runat="server" />
         <Siar:Button ID="Button1" runat="server" Text="Indietro" CausesValidation="False"
            OnClick="btnIndietro_Click" />
    </div>
    <uc1:CardVariantiIstruttoria ID="ucCardVarianti" runat="server" />
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
    
    <h2 class="pb-5">Pagina di dettaglio degli investimenti</h2>
      <div class="col-sm-12 text-end">
        <a onclick="tornaIndietro();" class="btn btn-secondary py-1">
            <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                <use href="/web/bootstrap-italia/svg/sprites.svg#it-chart-line"></use>
            </svg>
            Torna al piano investimenti</a>
    </div>
     <div id="tdInvestimentoComponent" runat="server"></div> 
   
      <div class="col-sm-12 p-1 mt-5">
             <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                Text="Salva le modifiche" />

                <Siar:Button ID="btnRicarica" runat="server" Conferma="Si è scelto di ricaricare i dati dell`investimento precedentemente ammesso. Questa modifica non è definitiva, continuare?"
                    Modifica="True" OnClick="btnRicarica_Click" Text="Ricarica dati originali"  />

              <Siar:Button ID="btnDuplica" runat="server" Modifica="True" Text="Duplica investimento"
                     Conferma="Si è scelto di duplicare l`investimento. Continuare?"
                    OnClick="btnDuplica_Click" />

                <Siar:Button ID="btnDeleteDuplicato" runat="server" Modifica="True" Text="Elimina investimento duplicato"
                   Conferma="Eliminare l`investimento duplicato?" OnClick="btnDeleteDuplicato_Click" />
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
