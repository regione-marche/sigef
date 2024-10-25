<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.CheckList" CodeBehind="CheckList.aspx.cs" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc1:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
    <br />
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                CHECKLIST DI CONTROLLO DELLA DOMANDA DI PAGAMENTO
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Di seguito vengono elencati tutti i requisiti, suddivisi per misura, che la domanda
                di pagamento deve soddisfare.
                <br />
                Per quelli <b>OBBLIGATORI</b> è richiesto l' <b>esito positivo</b>, in caso contrario
                non sarà possibile presentare la domanda.
            </td>
        </tr>
        <tr>
            <td id="tdControls" runat="server">
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 66px">
                <Siar:Button ID="btnVerifica" runat="server" CausesValidation="False" Modifica="True"
                    OnClick="btnVerifica_Click" Text="Verifica requisiti" Width="210px" />
            </td>
        </tr>
    </table>
</asp:Content>
