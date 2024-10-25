<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProcureSpeciali.ascx.cs" Inherits="web.CONTROLS.ucProcureSpeciali" %>

<div class="col-sm-12" id="divProcure" runat="server">
    <h3 class="pb-5 mt-5">Elenco delle procure speciali dell'impresa:</h3>
    <Siar:DataGridAgid ID="dgMandatiProcura" CssClass="table table-striped" runat="server" Width="100%" PageSize="15" AllowPaging="True"
        AutoGenerateColumns="False">
        <Columns>
            <Siar:NumberColumn HeaderText="Nr.">
                <ItemStyle Width="35px" HorizontalAlign="center" />
            </Siar:NumberColumn>
            <asp:BoundColumn HeaderText="Codice Fiscale">
                <ItemStyle Width="130px" />
            </asp:BoundColumn>
            <asp:BoundColumn HeaderText="Consulente">
                <ItemStyle Width="200px" />
            </asp:BoundColumn>
            <asp:BoundColumn HeaderText="Bando" DataField="IdBando">
                <ItemStyle Width="200px" />
            </asp:BoundColumn>
            <asp:BoundColumn HeaderText="Attivo" DataField="Attivo">
                <ItemStyle Width="80px" HorizontalAlign="Center" />
            </asp:BoundColumn>
            <asp:BoundColumn>
                <ItemStyle Width="150px" HorizontalAlign="Center" />
            </asp:BoundColumn>
        </Columns>
    </Siar:DataGridAgid>
</div>
