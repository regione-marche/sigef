<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IstruttoriaRequisiti" CodeBehind="IstruttoriaRequisiti.aspx.cs" %>

<%@ Register Src="~/CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function selezionaPlurivalore(jobj) 
        {
            if (jobj == null) 
                alert('L`elemento selezionato non è valido.');
            else 
            {
                $('[id$=lblPlurivaloreSelezionato' + jobj.IdRequisito + ']').text(jobj.Descrizione);
                $('[id$=hdnPlurivaloreSelezionato' + jobj.IdRequisito + ']').val(jobj.IdValore);
            } 
        }
        function deselezionaPlurivalore(id) 
        {
            $('[id$=lblPlurivaloreSelezionato' + id + ']').text(''); $('[id$=hdnPlurivaloreSelezionato' + id + ']').val(''); 
        }
    </script>
    <div class="row bd-form pt-5 mx-2">

        <div class="col-sm-12 form-group">
            <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
        </div>
        <div class="col-sm-12 text-end">
            <a onclick="location='CheckListPagamento.aspx'" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-note"></use>
                </svg>
                Torna alla CheckList Pagamenti</a>
        </div>

        <h2 class="pb-5">Istruttoria dei requisiti di domanda</h2>
        <p>
            Di seguito sono elencati, suddivisi per misura, i requisiti richiesti dallo specifico
            bando e dalla tipologia di pagamento.
        </p>

        <div class="col-sm-12">
            <div id="tdControls" runat="server"></div>
        </div>

        <div class="col-sm-12 form-group">
            <uc1:ProgettoIndicatori ID="ucProgettoInd" runat="server" />
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalva" runat="server" Modifica="true" OnClick="btnSalva_Click" Text="Ammetti i requisiti" />
            <%--  <input id="btnBack" runat="server" type="button" onclick="location='CheckListPagamento.aspx'" value="Indietro" 
                   class="btn btn-secondary py-1  style="width: 160px; margin-left: 20px"/>--%>
        </div>
        <div class="col-sm-12 text-end">
            <a id="btnBack" onclick="location='CheckListPagamento.aspx'" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-note"></use>
                </svg>Torna alla CheckList Pagamenti</a>
        </div>
    </div>
</asp:Content>
