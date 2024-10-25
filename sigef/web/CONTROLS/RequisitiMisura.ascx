<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.RequisitiMisura"
    CodeBehind="RequisitiMisura.ascx.cs" %>
<table width="100%" style="margin-top: 10px">
    <tr>
        <td class="paragrafo" id="rowMisura" visible="false" runat="server">
        </td>
    </tr>
    <tr>
        <td style="padding-top: 10px; padding-bottom: 10px">
            <asp:HiddenField ID="hdnIdDisposizioniMisura" runat="server" />
            <Siar:DataGrid ID="dgPriorita" runat="server" AutoGenerateColumns="False" Width="100%">
                <ItemStyle Height="26px" />
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle Width="35px" HorizontalAlign="center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="Priorita" HeaderText="Descrizione requisito">
                        <ItemStyle Width="330px" />
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="IdPriorita" Name="chkPriorita">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </Siar:CheckColumn>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </td>
    </tr>
</table>
