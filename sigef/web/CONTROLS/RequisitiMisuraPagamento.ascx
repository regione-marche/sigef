<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="web.CONTROLS.RequisitiMisuraPagamento" Codebehind="RequisitiMisuraPagamento.ascx.cs" %>
<table width="100%">
    <tr>
        <td id="rowMisura" class="separatore" runat="server">
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <Siar:DataGrid ID="dgRequisiti" runat="server" Width="100%" PageSize="15" CssClass="tabella"
                AutoGenerateColumns="False">
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
                        <itemstyle width="330px"></itemstyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn headertext="Obbligatorio" DataField="Obbligatorio" DataFormatString="{0:SI|NO}">
                        <itemstyle HorizontalAlign="center" width="70px"></itemstyle>
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="IdRequisito" Name="chkRequisito">
                        <HeaderStyle Width="50px" />
                        <ItemStyle Width="50px" />
                    </Siar:CheckColumn>
                    <asp:BoundColumn></asp:BoundColumn>
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
