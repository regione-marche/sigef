<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.AmmissibilitaRequisiti" CodeBehind="AmmissibilitaRequisiti.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/SiarNewToolTip.ascx" TagName="SiarNewToolTip" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function selezionaPlurivalore(jobj) { if (jobj == null) alert('L`elemento selezionato non è valido.'); else { $('[id$=lblPlurivaloreSelezionato' + jobj.IdPriorita + ']').text(jobj.Descrizione); $('[id$=hdnPlurivaloreSelezionato' + jobj.IdPriorita + ']').val(jobj.IdValore); } }
        function deselezionaPlurivalore(id) { $('[id$=lblPlurivaloreSelezionato'+id+']').text('');$('[id$=hdnPlurivaloreSelezionato'+id+']').val(''); }
        function selezionaPlurivaloreSql(jobj) { if(jobj==null) alert('L`elemento selezionato non è valido.');else { $('[id$=lblPlurivaloreSelezionatoSql'+jobj.IdPriorita+']').text(jobj.Descrizione);$('[id$=hdnPlurivaloreSelezionatoSql'+jobj.IdPriorita+']').val(jobj.Codice); } }
        function deselezionaPlurivaloreSql(id) { $('[id$=lblPlurivaloreSelezionatoSql'+id+']').text('');$('[id$=hdnPlurivaloreSelezionatoSql'+id+']').val(''); }
    </script>

    <br />
    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <br />
    <table class="tableNoTab" width="800">
        <tr>
            <td class="separatore">
                &nbsp;ISTRUTTORIA DEI REQUISITI SOGGETTIVI:
            </td>
        </tr>
        <tr>
            <td align="right">
                <uc3:SiarNewToolTip ID="ucSiarNewToolTip" runat="server" />
                &nbsp; &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td id="tdControls" runat="server">
            </td>
        </tr>
        <tr>
            <td align="right" style="text-align: center; height: 60px;">
                <Siar:Button ID="btnSalva" Text="Ammetti" runat="server" Modifica="True" OnClick="btnSalva_Click"
                    Width="180px" />
                &nbsp;&nbsp;&nbsp;
                <input id="btnBack" runat="server" class="Button" style="width: 160px" type="button"
                    value="Indietro" />
            </td>
        </tr>
    </table>
</asp:Content>
