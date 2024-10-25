<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="web.CONTROLS.RequisitiMisuraPagamentoControllo" CodeBehind="RequisitiMisuraPagamentoControllo.ascx.cs" %>

<div id="divContenitore" runat="server" class="dBox">
    <h3 id="rowMisura" runat="server" class="separatore"></h3>

    <Siar:DataGridAgid ID="dgRequisiti" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20" Width="100%">
        <PagerStyle CssClass="coda" Mode="NumericPages" />
        <Columns>
            <Siar:NumberColumn HeaderText="Nr.">
                <HeaderStyle Width="35px" />
                <ItemStyle HorizontalAlign="center" />
            </Siar:NumberColumn>
            <asp:BoundColumn DataField="Requisito" HeaderText="Descrizione requisito"></asp:BoundColumn>
            <asp:BoundColumn DataField="Obbligatorio" DataFormatString="{0:SI|NO}" HeaderText="Obbligatorio">
                <ItemStyle HorizontalAlign="center" />
            </asp:BoundColumn>
            <asp:BoundColumn HeaderText="Esito della verifica">
                <ItemStyle HorizontalAlign="center" />
            </asp:BoundColumn>
        </Columns>
    </Siar:DataGridAgid>
    <asp:HiddenField ID="hdnIdDisposizioniMisura" runat="server" />
</div>
