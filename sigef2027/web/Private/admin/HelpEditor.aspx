<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="HelpEditor.aspx.cs" Inherits="web.Private.admin.HelpEditor" %>

<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaElemento(id) { $('[id$=hdnIdHelp]').val(id);$('[id$=btnPost]').click(); };
    </script>

    <div style="display: none">
        <input type="hidden" id="hdnIdHelp" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" /></div>
    <table class="tableNoTab" width="900px">
        <tr>
            <td class="separatore_big">
                help editor
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;
                <br />
                <br />
                Dettaglio:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            Seleziona la pagina:<br />
                            <Siar:Combo ID="lstPages" runat="server">
                            </Siar:Combo>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Digita i parametri:<br />
                            <Siar:TextArea ID="txtParametri" runat="server" Width="574px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <b>Carica il file di Modifica:</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <uc1:SNCUploadFileControl ID="ucFileModifica" runat="server" AbilitaModifica="true" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <b>Carica il file di Pubblicazione:</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <uc1:SNCUploadFileControl ID="ucFilePubblicazione" runat="server" AbilitaModifica="true" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 70px; padding-right: 50px">
                            <Siar:Button ID="btnSalva" runat="server" OnClick="btnSalva_Click" Text="Salva" Width="180px"
                                Modifica="true" />
                            &nbsp;
                            <Siar:Button ID="btnElimina" runat="server" OnClick="btnElimina_Click" Text="Elimina"
                                Width="180px" Modifica="true" Conferma="Eliminare la voce selezionata?" />
                            <input type="button" value="Nuovo" style="width: 140px; margin-left: 20px" onclick="location='HelpEditor.aspx'"
                                class="Button" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dgHelp" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Page" HeaderText="Titolo pagina">
                            <ItemStyle Width="300px" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Parametri" LinkFields="Id" IsJavascript="true" LinkFormat="selezionaElemento({0});">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="Attivo" HeaderText="Attivo" DataFormatString="{0:SI|NO}">
                            <ItemStyle Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Data" HeaderText="Data">
                            <ItemStyle Width="120px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
    </table>
</asp:Content>
