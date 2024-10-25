<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IstruttoriaContrattiEPagamenti" CodeBehind="IstruttoriaContrattiEPagamenti.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento"TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/ucContrattiFemEPagamenti.ascx" TagName="ucContrattiFemEPagamenti" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
    </script>

    <style type="text/css">
    </style>

    <div style="display: none">
    </div>
    
    <br />
    <uc1:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <br />

    <div id="divContrattiFem">
        <uc2:ucContrattiFemEPagamenti ID="ucContrattiFemEPagamenti" runat="server" Visible="true" />
    </div>
</asp:Content>
