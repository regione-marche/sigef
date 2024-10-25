<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IVariante.RequisitiSoggettivi" CodeBehind="RequisitiSoggettivi.aspx.cs" %>

<%@ Register Src="~/CONTROLS/IVariantiControl.ascx" TagName="IVariantiControl" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function selezionaPlurivalore(jobj) 
        {
            if (jobj == null) 
                alert('L`elemento selezionato non è valido.');
            else 
            {
                $('[id$=lblPlurivaloreSelezionato' + jobj.IdPriorita + ']').text(jobj.Descrizione);
                $('[id$=hdnPlurivaloreSelezionato' + jobj.IdPriorita + ']').val(jobj.IdValore);
            } 
        }
        function deselezionaPlurivalore(id) 
        {
            $('[id$=lblPlurivaloreSelezionato' + id + ']').text('');
            $('[id$=hdnPlurivaloreSelezionato' + id + ']').val(''); 
        }
        function selezionaPlurivaloreSql(jobj) 
        {
            if (jobj == null) 
            alert('L`elemento selezionato non è valido.');
            else 
            {
                $('[id$=lblPlurivaloreSelezionatoSql' + jobj.IdPriorita + ']').text(jobj.Descrizione);
                $('[id$=hdnPlurivaloreSelezionatoSql' + jobj.IdPriorita + ']').val(jobj.Codice);
            } 
        }
        function deselezionaPlurivaloreSql(id) 
        {
            $('[id$=lblPlurivaloreSelezionatoSql' + id + ']').text('');
            $('[id$=hdnPlurivaloreSelezionatoSql' + id + ']').val(''); 
        }
    </script>

    <uc1:IVariantiControl ID="IVariantiControl" runat="server" />
    <br />
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                Requisiti Soggettivi
            </td>
        </tr>
        <tr>
            <td class="testo_pagina" style="height: 84px">
                Elenco dei requisiti soggettivi definiti dal bando di gara: tali requisiti possono
                attribuire sia punti in graduatoria<br />
                che maggiori percentuali di aiuto ammissibile per gli investimenti. Nel caso in
                cui il bando attivi più tipologie di intervento<br />
                si richiedere di specificare tali requisiti per tutte quelle per le quali si intende
                chiedere il finanziamento.
            </td>
        </tr>
        <tr>
            <td id="rowControls" runat="server" style="padding-top: 10px; padding-bottom: 10px">
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ProgettoIndicatori ID="ucProgettoInd" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 60px">
                <Siar:Button ID="btnSalva" Text="Ammetti" runat="server" Modifica="True" OnClick="btnSalva_Click" Width="160px" />
            </td>
        </tr>
    </table>
</asp:Content>
