<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="web.CONTROLS.RequisitiMisuraPagamentoControllo" Codebehind="RequisitiMisuraPagamentoControllo.ascx.cs" %>
&nbsp;<table width="100%">
    <tr>
        <td id="rowMisura" runat="server" class="separatore">
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <Siar:DataGrid ID="dgRequisiti" runat="server" AutoGenerateColumns="False" CssClass="tabella"
                PageSize="15" Width="100%">
                <PagerStyle CssClass="coda" Mode="NumericPages" />
                <ItemStyle CssClass="DataGridRow" Height="24px" />
                <AlternatingItemStyle BackColor="#fff0d2" />
                <HeaderStyle CssClass="TESTA1" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <HeaderStyle Width="35px" />
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="Requisito" HeaderText="Descrizione requisito">                        
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Obbligatorio" DataFormatString="{0:SI|NO}" headertext="Obbligatorio">
                        <itemstyle horizontalalign="center" width="110px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Esito della verifica"><itemstyle horizontalalign="center" width="200px" /></asp:BoundColumn>
                </Columns>
            </Siar:DataGrid></td>
    </tr>
    <tr>
        <td>
            <Siar:Hidden ID="hdnIdDisposizioniMisura" runat="server">
            </Siar:Hidden>
            &nbsp;<br />
            &nbsp;
        </td>
    </tr>
</table>
