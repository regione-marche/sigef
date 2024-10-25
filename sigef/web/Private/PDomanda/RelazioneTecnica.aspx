<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.RelazioneTecnica" CodeBehind="RelazioneTecnica.aspx.cs" %>

<%@ Reference Control="~/CONTROLS/QuadroRelazioneTecnica.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <table class="tableTab" width="800">
        <tr>
            <td align="center">
                <input id="btnPrev" class="ButtonProsegui" onclick="location='RequisitiDomanda.aspx'"
                       type="button" value="<<< (4/7)" runat="server"/>
                <input id="btnCurrent" class="ButtonProsegui BPDisabled" style="width: 40px" disabled="disabled"
                       type="button" value="(5/7)" runat="server"/>
                <input id="btnGo" class="ButtonProsegui" onclick="location='BusinessPlan.aspx'" type="button"
                       value="(6/7) >>>" runat="server"/>
            </td>
        </tr>
    </table>
    <br />
    <table class="tableNoTab" width="800px">
        <tr>
            <td class="separatore_big">
                DESCRIZIONE DELL'INIZIATIVA PROGETTUALE
            </td>
        </tr>
        <tr id="trNoRelazione" runat="server">
            <td class="testo_pagina">
                Il bando non richiede la compilazione della presente sezione.
            </td>
        </tr>
        <tr id="trSiRelazione" runat="server" visible="false">
            <td>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td id="rowEdit" runat="server" style="padding-top: 10px; padding-bottom: 10px">
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="right" style="padding-right: 50px; height: 60px;">
                            <Siar:Button ID="btnSave" runat="server" CausesValidation="True" Modifica="True"
                                         OnClick="btnSave_Click" Text="Salva" Width="190px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
