<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.RequisitiDomanda" CodeBehind="RequisitiDomanda.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function selezionaPlurivalore(jobj) { if(jobj==null) alert('L`elemento selezionato non è valido.');else { $('[id$=lblPlurivaloreSelezionato'+jobj.IdPriorita+']').text(jobj.Descrizione);$('[id$=hdnPlurivaloreSelezionato'+jobj.IdPriorita+']').val(jobj.IdValore); } }
        function deselezionaPlurivalore(id) { $('[id$=lblPlurivaloreSelezionato'+id+']').text('');$('[id$=hdnPlurivaloreSelezionato'+id+']').val(''); }
        function selezionaPlurivaloreSql(jobj) { if(jobj==null) alert('L`elemento selezionato non è valido.');else { $('[id$=lblPlurivaloreSelezionatoSql'+jobj.IdPriorita+']').text(jobj.Descrizione);$('[id$=hdnPlurivaloreSelezionatoSql'+jobj.IdPriorita+']').val(jobj.Codice); } }
        function deselezionaPlurivaloreSql(id) { $('[id$=lblPlurivaloreSelezionatoSql'+id+']').text('');$('[id$=hdnPlurivaloreSelezionatoSql'+id+']').val(''); }
    </script>

    <table class="tableTab" width="800">
        <tr>
            <td align="center"><!-- FascicoloAziendale.aspx -->
                <input id="btnPrev" class="ButtonProsegui" onclick="location='GestioneVisure.aspx'"
                    type="button" value="<<< (3/7)" runat="server"/>
                <input id="btnCurrent" class="ButtonProsegui BPDisabled" style="width: 40px" disabled="disabled"
                    type="button" value="(4/7)" runat="server"/>
                <input id="btnGo" class="ButtonProsegui" onclick="location='RelazioneTecnica.aspx'"
                    type="button" value="(5/7) >>>" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <table class="tableNoTab" width="800px">
        <tr>
            <td class="separatore_big">
                REQUISITI SOGGETTIVI
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Elenco dei requisiti soggettivi definiti dal bando di gara: tali&nbsp;requisiti
                possono attribuire sia punti in graduatoria<br />
                che maggiori percentuali di aiuto ammissibile per gli investimenti. Nel caso in
                cui il bando attivi più tipologie di intervento<br />
                si richiedere di specificare tali requisiti per tutte quelle per le quali si intende
                chiedere il finanziamento.
            </td>
        </tr>
        <tr>
            <td id="tdControls" runat="server" style="padding-top: 10px; padding-bottom: 10px">
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 50px; height: 60px;">
                <Siar:Button ID="btnSalva" Text="Salva requisiti" runat="server" Modifica="True"
                    OnClick="btnSalva_Click" Width="196px" />
            </td>
        </tr>
    </table>
</asp:Content>
