<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.admin.DocumentiBackhand" CodeBehind="DocumentiBackhand.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function selezionaDocumento(id) { $('[id$=hdnIdDocumento]').val(id);swapTab(2); }
        function visualizzaFile(id) { $('[id$=hdnIdFile]').val(id);$('[id$=btnVisualizzaFile]').click(); }
        function eliminaFile(id) { if(confirm('Attenzione! Eliminare il file?')) { $('[id$=hdnIdFile]').val(id);$('[id$=btnEliminaFile]').click(); } }
//--></script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdDocumento" runat="server" />
        <asp:HiddenField ID="hdnIdFile" runat="server" />
        <asp:Button ID="btnEliminaFile" runat="server" OnClick="btnEliminaFile_Click" />
        <asp:Button ID="btnVisualizzaFile" runat="server" OnClick="btnVisualizzaFile_Click" />
    </div>
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Documenti di supporto agli utenti|Dettaglio documento"
        Width="800px" />
    <table class="tableTab" id="tbElenco" runat="server" width="800px">
        <tr>
            <td style="padding-bottom: 10px; padding-top: 10px">
                <Siar:DataGrid ID="dgDocumenti" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
                    <ItemStyle Height="50px" />
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Descrizione"></asp:BoundColumn>
                        <Siar:ColonnaLink DataField="DataFineValidita" HeaderText="Fine validita" LinkFields="IdDocumento"
                            IsJavascript="true" LinkFormat="selezionaDocumento({0});">
                            <ItemStyle HorizontalAlign="right" Width="120px" />
                        </Siar:ColonnaLink>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
    <table id="tbDettaglio" runat="server" class="tableTab" width="800px">
        <tr>
            <td style="padding: 10px">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width: 556px">
                            &nbsp;Titolo (max 255 caratteri):<br />
                            <Siar:TextArea ID="txtTitolo" runat="server" DataColumn="Titolo" NomeCampo="Titolo"
                                Width="450px" Rows="3" Obbligatorio="True" />
                        </td>
                        <td valign="bottom">
                            Data fine validita:<br />
                            <Siar:DateTextBox ID="txtDataFineValidita" runat="server" NomeCampo="Data fine validita"
                                Obbligatorio="True" Width="110px" DataColumn="DataFineValidita" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            Descrizione (max 1000 caratteri):<br />
                            <Siar:TextArea ID="txtDescrizioneLunga" runat="server" DataColumn="Descrizione" NomeCampo="News"
                                Width="750px" Rows="6" />
                        </td>
                    </tr>
                    <tr>
                        <td class="paragrafo" colspan="2">
                            <br />
                            Allega un nuovo file al documento:
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            &nbsp;Breve descrizione (max 100 caratteri):<br />
                            &nbsp;<Siar:TextBox ID="txtDescFile" runat="server" Width="378px" MaxLength="100" />
                            <br />
                            <uc2:SNCUploadFileControl ID="ucSNCUploadFileControl" runat="server" Width="600px"
                                TipoFile="NonSpecificato" DimensioneMassima="NoLimit" />
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="border-bottom: #142952 1px solid">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <br />
                <Siar:Button ID="btnSalva" runat="server" Modifica="True" Text="Salva" Width="150px"
                    OnClick="btnSalva_Click" />&nbsp;&nbsp;
                <Siar:Button ID="btnElimina" runat="server" CausesValidation="False" Modifica="True"
                    OnClick="btnElimina_Click" Text="Elimina" Width="150px" Conferma="Attenzione! Eliminare il documento con tutti i file relativi?" />&nbsp;
                &nbsp;&nbsp;
                <Siar:Button ID="btnNuovo" runat="server" CausesValidation="False" Modifica="true"
                    OnClick="btnNuovo_Click" Text="Nuovo" Width="150px" />&nbsp;<br />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore_light">
                Elenco file costitutivi del documento:
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 10px; padding-top: 10px">
                <Siar:DataGrid ID="dgFiles" runat="server" Width="100%" PageSize="10" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <ItemStyle Height="20px" />
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdFile" ButtonText="Visualizza"
                            ButtonType="TextButton" JsFunction="visualizzaFile">
                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                        </Siar:JsButtonColumn>
                        <Siar:JsButtonColumn Arguments="IdFile" ButtonText="Elimina" ButtonType="TextButton"
                            JsFunction="eliminaFile">
                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
