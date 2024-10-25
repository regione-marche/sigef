<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.Requisiti" CodeBehind="Requisiti.aspx.cs" %>

<%@ Register Src="~/CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento" TagPrefix="uc1" %>
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
            $('[id$=lblPlurivaloreSelezionato' + id + ']').text('');
            $('[id$=hdnPlurivaloreSelezionato' + id + ']').val(''); 
        }
    </script>

    <uc1:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
    <br />
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                REQUISITI SOGGETTIVI
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Di seguito vengono elencati i requisiti soggettivi richiesti dallo specifico bando
                e dalle disposizioni attuative attuative.<br />
                Tali requisiti possono attribuire sia maggior punteggio in graduatoria che una maggior
                pecentuale di contributo pubblico<br />
                sugli investimenti del piano di sviluppo.
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
            <td style="height: 50px" align="center">
                <Siar:Button ID="btnSalva" runat="server" OnClick="btnSalva_Click" Text="Salva i requisiti"
                    Modifica="true" Width="200px" />
            </td>
        </tr>
    </table>
</asp:Content>
