<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.AmmissibilitaRequisiti" CodeBehind="AmmissibilitaRequisiti.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function selezionaPlurivalore(jobj) { if (jobj == null) alert('L`elemento selezionato non è valido.'); else { $('[id$=lblPlurivaloreSelezionato' + jobj.IdPriorita + ']').text(jobj.Descrizione); $('[id$=hdnPlurivaloreSelezionato' + jobj.IdPriorita + ']').val(jobj.IdValore); } }
        function deselezionaPlurivalore(id) { $('[id$=lblPlurivaloreSelezionato' + id + ']').text(''); $('[id$=hdnPlurivaloreSelezionato' + id + ']').val(''); }
        function selezionaPlurivaloreSql(jobj) { if (jobj == null) alert('L`elemento selezionato non è valido.'); else { $('[id$=lblPlurivaloreSelezionatoSql' + jobj.IdPriorita + ']').text(jobj.Descrizione); $('[id$=hdnPlurivaloreSelezionatoSql' + jobj.IdPriorita + ']').val(jobj.Codice); } }
        function deselezionaPlurivaloreSql(id) { $('[id$=lblPlurivaloreSelezionatoSql' + id + ']').text(''); $('[id$=hdnPlurivaloreSelezionatoSql' + id + ']').val(''); }
    </script>
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
        <li class="breadcrumb-item active" aria-current="page">Istruttoria requisiti soggettivi</li>
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
        <h2 class="pb-2">Istruttoria dei requisiti soggettivi:</h2>
        <div class="row" id="tdControls" runat="server"></div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalva" Text="Ammetti" runat="server" Modifica="True" OnClick="btnSalva_Click" />
        </div>
        <div class="col-sm-12 text-end">
            <a id="btnBackDown" runat="server" class="btn btn-secondary py-1">
                <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
                    <use href="/web/bootstrap-italia/svg/sprites.svg#it-check"></use>
                </svg>
                Torna alla checklist di ammissibilità</a>
        </div>
    </div>
</asp:Content>
