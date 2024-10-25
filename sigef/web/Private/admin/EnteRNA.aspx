<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" 
    CodeBehind="EnteRNA.aspx.cs" Inherits="web.Private.admin.EnteRNA" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function dettaglioEnte(cod_ente) { $('[id$=hdnCodEnte]').val(cod_ente);swapTab(2); }
        function pulisciCampi() {
            $('[id$=hdnCodEnte]').val('');$('[id$=txtCodice_text]').val('');$('[id$=txtCodice_text]').removeAttr('readonly');$('[id$=lstTipoEnte]').val('');$('[id$=lstTipoEnte]').removeAttr('disabled');
            $('[id$=txtCodice_text]').css("background-color",'#ffffff');$('[id$=txtDescrizione_text]').val('');$('[id$=txtDescrizione_text]').css("background-color",'#ffffff');
        }
//--></script>

    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco generale|Dettaglio ente" />
    <table class="tableTab" id="tabLista" runat="server" width="750px">
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 46px">Filtra per tipologia:<br />
                <Siar:ComboTipoEnte ID="lstTipoEnteRicerca" runat="server" DataColumn="CodTipoEnte">
                </Siar:ComboTipoEnte>
                &nbsp;&nbsp;&nbsp;
               
                <Siar:Button ID="btnFiltroEnte" runat="server" Modifica="True" OnClick="btnFiltroEnte_Click"
                    Text="Filtra" Width="140px" />
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dg_enti" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <ItemStyle Height="22px" />
                    <Columns>
                        <Siar:NumberColumn>
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="CodEnte" HeaderText="Codice">
                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" LinkFields="CodEnte"
                            LinkFormat="dettaglioEnte('{0}');" IsJavascript="true">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="CodTipoEnte" HeaderText="Codice tipo">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Abilitato" HeaderText="Abilitato" DataFormatString="{0:SI|NO}">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Abilitato" HeaderText="Salvato" DataFormatString="{0:SI|NO}">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
    <table class="tableTab" id="tabNuovo" runat="server" width="650px">
        <tr>
            <td style="width: 94px">&nbsp;
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 94px">Codice:
            </td>
            <td>
                <Siar:TextBox ID="txtCodice" runat="server" DataColumn="CodEnte" Width="120px" 
                    NomeCampo="Codice ente"/>
            </td>
        </tr>
        <tr>
            <td style="width: 94px">Descrizione:
            </td>
            <td>
                <Siar:TextBox ID="txtDescrizione" runat="server" Width="368px" DataColumn="Descrizione"
                    NomeCampo="Descrizione"/>
            </td>
        </tr>
        <tr>
            <td style="width: 94px">Username:
            </td>
            <td>
                <Siar:TextBox ID="txtUsername" runat="server" Width="368px" DataColumn="Username"
                    NomeCampo="Username"/>
            </td>
        </tr>
        <tr>
            <td style="width: 94px">Password:
            </td>
            <td>
                <Siar:TextBox ID="txtPassword" runat="server" Width="368px" DataColumn="Password"
                    NomeCampo="Password"/>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2" style="height: 47px">
                <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click"
                    Text="Salva" Width="140px" />
                &nbsp;&nbsp;&nbsp; &nbsp;
               
                <Siar:Button ID="btnElimina" runat="server" Width="140px" Text="Elimina credenziali" OnClick="btnElimina_Click"
                    Modifica="True" Conferma="Rimuovere le credenziali dell'ente selezionato?"></Siar:Button>&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="separatore">Elenco dei profili associati all'ente
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <Siar:DataGrid ID="dgProfili" runat="server" Width="100%" PageSize="20" AutoGenerateColumns="False">
                    <Columns>
                        <Siar:CheckColumn DataField="IdProfilo" Name="chkProfilo" HeaderText="">
                            <HeaderStyle Width="50px" />
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </Siar:CheckColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2"></td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnCodEnte" runat="server" />
</asp:Content>
