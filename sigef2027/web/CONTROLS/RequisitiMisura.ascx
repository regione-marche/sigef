<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.RequisitiMisura"
    CodeBehind="RequisitiMisura.ascx.cs" %>
<div class="col-sm-12">
    <p id="rowMisura" visible="false" runat="server"></p>
    <asp:HiddenField ID="hdnIdDisposizioniMisura" runat="server" />
    <Siar:DataGridAgid ID="dgPriorita" CssClass="table table-striped" runat="server" AutoGenerateColumns="False">
        <Columns>
            <Siar:NumberColumnAgid HeaderText="Nr.">
                <ItemStyle HorizontalAlign="center" />
            </Siar:NumberColumnAgid>
            <asp:BoundColumn DataField="Priorita" HeaderText="Descrizione requisito">
            </asp:BoundColumn>
            <Siar:CheckColumnAgid DataField="IdPriorita" Name="chkPriorita">
                <ItemStyle HorizontalAlign="Center"/>
            </Siar:CheckColumnAgid>
            <asp:BoundColumn>
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundColumn>
        </Columns>
    </Siar:DataGridAgid>
</div>
