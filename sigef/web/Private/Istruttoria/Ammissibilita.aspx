<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    EnableViewState="true" Inherits="web.Private.Istruttoria.Ammissibilita" CodeBehind="Ammissibilita.aspx.cs" %>

<%@ Register Src="../../CONTROLS/FiltroRicercaDomande.ascx" TagName="FiltroRicercaDomande"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <table width="950px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
            ISTRUTTORIA DI AMMISSIBILITA'
        </tr>
        <tr>
            <td align="right">
                <uc2:FiltroRicercaDomande ID="ucFiltroRicercaDomande" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px; padding-bottom: 10px">
                <Siar:DataGrid ID="dg" DataKeyField="IdProgetto" runat="server" AllowPaging="True"
                    AutoGenerateColumns="False" PageSize="15" Width="100%" OnItemDataBound="dg_ItemDataBound">
                    <ItemStyle Height="50px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Domanda"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Stato" HeaderText="Stato procedurale">
                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Istruttore" HeaderText="Istruttore assegnato">
                            <ItemStyle Width="130px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ProvinciaAssegnazione" HeaderText="Provincia di assegnazione">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Vai alla checklist di ammissibilita">
                            <ItemStyle HorizontalAlign="Center" Width="110px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Iter procedurale della domanda">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
