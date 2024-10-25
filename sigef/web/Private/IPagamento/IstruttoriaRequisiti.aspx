<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IstruttoriaRequisiti" CodeBehind="IstruttoriaRequisiti.aspx.cs" %>

<%@ Register Src="~/CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function selezionaPlurivalore(jobj) 
        {
            if (jobj == null) 
                alert('L`elemento selezionato non è valido.');
            else 
            {
                $('[id$=lblPlurivaloreSelezionato' + jobj.IdRequisito + ']').text(jobj.Descrizione);
                $('[id$=hdnPlurivaloreSelezionato' + jobj.IdRequisito + ']').val(jobj.IdValore);
            } 
        }
        function deselezionaPlurivalore(id) 
        {
            $('[id$=lblPlurivaloreSelezionato' + id + ']').text(''); $('[id$=hdnPlurivaloreSelezionato' + id + ']').val(''); 
        }
    </script>

    <br />
    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <br />
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                ISTRUTTORIA DEI REQUISITI DI DOMANDA
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Di seguito sono elencati, suddivisi per misura, i requisiti richiesti dallo specifico
                bando e dalla tipologia di pagamento.
            </td>
        </tr>
        <tr>
            <td id="tdControls" runat="server">
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ProgettoIndicatori ID="ucProgettoInd" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 50px">
                <Siar:Button ID="btnSalva" runat="server" Modifica="true" OnClick="btnSalva_Click" Text="Ammetti i requisiti" Width="200px" />
                <input id="btnBack" runat="server" type="button" onclick="location='CheckListPagamento.aspx'" value="Indietro" 
                       class="Button" style="width: 160px; margin-left: 20px"/>
            </td>
        </tr>
    </table>
</asp:Content>
