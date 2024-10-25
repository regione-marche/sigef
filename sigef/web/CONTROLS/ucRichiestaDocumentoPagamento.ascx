<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucRichiestaDocumentoPagamento.ascx.cs" Inherits="web.CONTROLS.ucRichiestaDocumentoPagamento" %>
<br />
<table id="tbMain" runat="server">
    <tr>
        <td class="separatore_light">
            Doc. n.
            <asp:Label ID="lblNrDoc" runat="server"></asp:Label><span id="spEliminaDocumento"
                runat="server" visible="false" style='margin-left: 30px; cursor: pointer; text-decoration: underline'>[Escludi
                dalla richiesta]</span>
        </td>
    </tr>
    <tr>
        <td style="padding-left: 10px">
            Categoria documento:<br />
            <Siar:TextBox ID="txtCategoria" runat="server" Width="600px" ReadOnly="true" />
        </td>
    </tr>
    <tr id="trEstremiDocumento" runat="server" visible="false">
        <td style="padding-left: 10px">
            <table width="100%">
                <tr>
                    <td style="width: 120px">
                        Numero:
                        <br />
                        <Siar:TextBox ID="txtNrDocumento" runat="server" Width="100px" ReadOnly="true" />
                    </td>
                    <td style="width: 120px">
                        Data emissione:
                        <br />
                        <Siar:DateTextBox ID="txtDataDocumento" runat="server" Width="100px" ReadOnly="true" />
                    </td>
                    <td>
                        Amministrazione:
                        <br />
                        <Siar:TextBox ID="txtEnteDocumento" runat="server" ReadOnly="true" Width="320px" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="padding-left: 10px">
            Descrizione del beneficiario:<br />
            <Siar:TextArea ID="txtDescrizione" runat="server" Rows="2" Width="600px" ReadOnly="true" />
        </td>
    </tr>
    <tr>
        <td style="padding-left: 10px">
            Note istruttore: (max 10.000 caratteri)<br />
            <Siar:TextArea ID="txtNoteIstruttore" runat="server" Rows="6" Width="600px" MaxLength="10000"
                ExpandableRows="10" />
        </td>
    </tr>
</table>
