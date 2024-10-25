<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="BusinessPlan.aspx.cs" Inherits="web.Private.PPagamento.BusinessPlan" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <uc1:WorkflowPagamento ID="WorkflowPagamento1" runat="server" />
    <br />
    <table class="tableNoTab" width="800px">
        <tr>
            <td class="separatore_big">
                AGGIORNAMENTO DEL BUSINESS PLAN DI DOMANDA DI AIUTO
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Di seguito sono elencate le sezioni, richieste dal bando di gara, da aggiornare
                con i dati più recenti.<br />
                Ognuna di tali voci apre le pagine web in cui è possibile inserire e/o aggiornare
                i dati richiesti.
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dg" runat="server" AutoGenerateColumns="False" CssClass="tabella"
                    EnableViewState="False" Width="100%">
                    <ItemStyle Height="34px" />
                    <Columns>
                        <asp:BoundColumn DataField="Quadro">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
