<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.regione.Dichiarazioni" CodeBehind="Dichiarazioni.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
		<!--
        function nuovo() {
            $('[id$=hdnEdit]').val('');
            $('[id$=txtMisura_text]').val('');
            $('[id$=txtDescrizioneLunga_text]').val('');

        }
        function modifica(id) {
            $('[id$=hdnEdit]').val(id);
            $('[id$=btnPost]').click();
        }
		//-->
    </script>

    <div style="display: none">
        <input id="hdnEdit" type="hidden" name="hdnEdit" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
    </div>
    <uc1:SiarNewTab ID="ucSiarNewTab1" runat="server" TabNames="Dichiarazioni|Nuova dichiarazione" />
    <table class="tableTab" id="tblElenco" width="1000px" runat="server">
        <tr>
            <td>
                <table id="Table2" width="100%">
                    <tr>
                        <td>
                            <br />
                            <b>Misura</b>:&nbsp;
                            <asp:TextBox ID="txtMisuraFind" runat="server" Width="100px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <b>Descrizione</b>:&nbsp;
                            <asp:TextBox ID="txtDescrizioneFind" runat="server" Width="350px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" Width="140px" />
                            &nbsp;&nbsp;&nbsp;
                            <Siar:Button ID="btnNoFilter" runat="server" OnClick="btnNoFilter_Click" Text="Annulla Ricerca"
                                Width="140px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <Siar:DataGrid ID="dg" runat="server" Width="100%" ShowShadow="False" PageSize="20"
                                AllowPaging="True" CssClass="tabella" AutoGenerateColumns="False">
                                <AlternatingItemStyle CssClass="DataGridRow"></AlternatingItemStyle>
                                <ItemStyle CssClass="DataGridRow"></ItemStyle>
                                <HeaderStyle Font-Bold="True" ForeColor="White" CssClass="TESTA1"></HeaderStyle>
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <HeaderStyle Width="35px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="center"></ItemStyle>
                                    </Siar:NumberColumn>
                                    <Siar:ColonnaLink DataField="Descrizione" LinkFields="IdDichiarazione|Descrizione|Misura"
                                        HeaderText="Descrizione" LinkFormat="javascript:modifica({0})">
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                                        <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn>
                                        <HeaderStyle Width="50px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" EnableViewState="False" NavigateUrl='<%# getElimina(Container) %>'>Elimina</asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle CssClass="coda" Mode="NumericPages"></PagerStyle>
                            </Siar:DataGrid>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table class="tableTab" id="tblNuovo" width="800px" runat="server">
        <tr>
            <td>
                <table id="Table3" width="100%">
                    <tr>
                        <td style="width: 94px">
                            &nbsp;
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 94px" valign="top">
                            Descrizione:
                        </td>
                        <td>
                            <Siar:TextArea ID="txtDescrizioneLunga" runat="server" Width="480px" NomeCampo="Descrizione"
                                Obbligatorio="True" Rows="10"></Siar:TextArea>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 94px">
                            Misura:
                        </td>
                        <td>
                            <Siar:TextBox ID="txtMisura" runat="server" Width="83px" NomeCampo="Misura" />
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 94px">
                            &nbsp;
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2" style="text-align: center">
                            <Siar:Button ID="btnSalva" runat="server" Width="127px" Text="Salva" OnClick="btnSalva_Click"
                                Modifica="true"></Siar:Button>&nbsp;&nbsp; &nbsp; &nbsp;
                            <input class="Button" onclick="javascript:nuovo()" type="button" value="Nuovo" style="width: 127px" />&nbsp;&nbsp;
                            &nbsp;
                        </td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
