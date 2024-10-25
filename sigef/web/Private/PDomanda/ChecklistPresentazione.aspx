<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    EnableViewState="true" Inherits="web.Private.PDomanda.ChecklistPresentazione"
    CodeBehind="ChecklistPresentazione.aspx.cs" %>

<%@ Register Src="../../CONTROLS/ChecklistNew.ascx" TagName="Checklist" TagPrefix="siar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <table class="tableNoTab" width="800px">
        <tr>
            <td class="separatore_big">
                CHECKLIST DI PRESENTAZIONE
            </td>
        </tr>
        <tr>
            <td class="testo_pagina" style="height: 64px">
                Elenco dei requisiti finali: per procedere alla presentazione della domanda è indispensabile
                che
                <br />
                tutti i requisiti <b>obbligatori</b> abbiano esito positivo.
            </td>
        </tr>
        <tr>
            <td>
                <siar:Checklist ID="ucChecklist" runat="server" Fase="P" NoteColumnVisible="false"
                    DefaultRedirect="~/Private/PDomanda/RicercaDomanda.aspx" />
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 60px; padding-right: 50px">
                <siar:Button ID="btnVerifica" runat="server" OnClick="btnVerifica_Click" Text="Verifica dei requisiti"
                    Width="220px" Modifica="true" />
                <input type="button" class="Button" value="Indietro" style="width: 100px; margin-left: 20px"
                    onclick="location='RiepilogoDomanda.aspx'" />
            </td>
        </tr>
    </table>
</asp:Content>
