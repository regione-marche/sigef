<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContrattiFemEPagamenti.aspx.cs" Inherits="web.Private.PPagamento.ContrattiFemEPagamenti" %>--%>

<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.ContrattiFemEPagamenti" CodeBehind="ContrattiFemEPagamenti.aspx.cs" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento" TagPrefix="ucWorkflow" %>
<%@ Register Src="../../CONTROLS/ucContrattiFemEPagamenti.ascx" TagName="ucContrattiFemEPagamenti" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
    </script>

    <div style="display: none">
    </div>

    <ucWorkflow:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
    <br />

    <div id="divContrattiFem">
        <uc1:ucContrattiFemEPagamenti ID="ucContrattiFemEPagamenti" runat="server" Visible="true"/>
    </div>
    
</asp:Content>
