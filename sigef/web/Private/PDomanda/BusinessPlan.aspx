<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.BusinessPlan" CodeBehind="BusinessPlan.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <table class="tableTab" width="800">
        <tr>
            <td align="center">
                <input id="btnPrev" class="ButtonProsegui" onclick="location='RelazioneTecnica.aspx'"
                    type="button" value="<<< (5/7)" runat="server" />
                <input id="btnCurrent" class="ButtonProsegui BPDisabled" style="width: 40px" disabled="disabled"
                    type="button" value="(6/7)" runat="server"/>
                <input id="btnGo" class="ButtonProsegui" onclick="location='RiepilogoDomanda.aspx'"
                    type="button" value="(7/7) >>>" runat="server"/>
            </td>
        </tr>
    </table>
    <br />
    <table class="tableNoTab" width="800px">
        <tr>
            <td class="separatore_big">
                BUSINESS PLAN DI DOMANDA
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Di seguito sono elencate le sezioni da compilare richieste dal bando di gara. Ognuna
                di tali voci apre le pagine web<br />
                in cui è possibile inserire e/o aggiornare i dati richiesti.
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px; padding-bottom: 10px">
                <Siar:DataGrid ID="dg" runat="server" AutoGenerateColumns="False" Width="100%">
                    <ItemStyle Height="44px" />
                    <Columns>
                        <Siar:ColonnaLink DataField="Quadro" IsJavascript="false" LinkFields="Url" LinkFormat="{0}">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:ColonnaLink>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
