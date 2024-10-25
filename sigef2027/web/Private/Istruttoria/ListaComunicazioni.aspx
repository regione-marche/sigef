<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.ListaComunicazioni" CodeBehind="ListaComunicazioni.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function seleziona(id) { $('[id$=hdnIdDocumento]').val(id); swapTab(2); }
        //--></script>

    <br />
    <input type="hidden" id="hdnIdDocumento" runat="server" />
    <table id="tbDocumenti" class="tableNoTab" runat="server" width="1200px">
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="separatore_big">
                            Lista delle richieste di documentazione registrate
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <table cellpadding="0" cellspacing="0" style="border-left: black 1px solid; border-bottom: black 1px solid">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                    </td>
                                    <td align="left" style="width: 77px" valign="top">
                                        Numero:&nbsp;
                                    </td>
                                    <td align="left" valign="top">
                                        Tipo documento:
                                    </td>
                                    <td style="width: 120px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    </td>
                                    <td align="left" style="width: 77px" valign="top">
                                        <Siar:IntegerTextBox ID="txtNumeroDomandaFiltro" runat="server" MaxLength="5" Width="55px"
                                            NoCurrency="true" />
                                    </td>
                                    <td align="left" valign="top">
                                        <Siar:ComboTipoSegnatura ID="lstTipoDocumento" runat="server" NomeCampo="Tipo Documento"
                                            Width="300px" FlagAiuto="true" />
                                        &nbsp;&nbsp;
                                    </td>
                                    <td align="left" style="width: 120px" valign="top">
                                        <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Applica filtro"
                                            Width="109px" CausesValidation="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <Siar:DataGrid ID="dgComunicazioni" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                PageSize="15" Width="100%">
                                <ItemStyle Height="50px" />
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle HorizontalAlign="Center" Width="25px" Font-Bold="true" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Nr. Domanda">
                                        <ItemStyle Width="80px" Font-Bold="true" HorizontalAlign="Center" Font-Size="Medium" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Dati Azienda">
                                        <ItemStyle Width="200px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="TipoSegnatura" HeaderText="Tipo">
                                        <ItemStyle Width="200px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Ente">
                                        <ItemStyle Width="200px" HorizontalAlign="left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Data" HeaderText="Data">
                                        <ItemStyle Width="80px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="NominativoOperatore" HeaderText="Operatore">
                                        <ItemStyle Width="100px" HorizontalAlign="left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Stato">
                                        <ItemStyle Width="130px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn>
                                        <ItemStyle Width="50px" HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right">
                <input type="button" class="Button" value="Indietro" style="width: 120px; margin-left: 20px;"
                    onclick="history.back();" />&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
