<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.ProgettoIndicatori" CodeBehind="ProgettoIndicatori.ascx.cs" %>
<div>
    <Siar:DataGrid ID="dgProgrammazione" runat="server" AutoGenerateColumns="False" Width="100%">
        <ItemStyle Height="24px" />
        <Columns>
            <Siar:NumberColumn></Siar:NumberColumn>
            <asp:BoundColumn DataField="ProgrammazioneCodice" HeaderText="Intervento"></asp:BoundColumn>
            <asp:BoundColumn DataField="DimCodice" HeaderText="Indicatore"></asp:BoundColumn>
            <asp:BoundColumn DataField="DimDescrizione" HeaderText="Indicatore"></asp:BoundColumn>
            <asp:BoundColumn DataField="Richiedibile" HeaderText="Calcolo Indicatore"></asp:BoundColumn>
            <Siar:ImportoColumn DataField="IdDimXProgrammazione" Importo="ValoreProgrammatoRichiesto" HeaderText="Val. Programmato Richiesto" Name="ValoreProgrammatoRichiesto" ></Siar:ImportoColumn>
            <Siar:ImportoColumn DataField="IdDimXProgrammazione" Importo="ValoreProgrammatoAmmesso" HeaderText="Val. Programmato Ammesso" Name="ValoreProgrammatoAmmesso" ></Siar:ImportoColumn>
            <Siar:ImportoColumn DataField="IdDimXProgrammazione" Importo="ValoreRealizzatoRichiesto" HeaderText="Val. Realizzato Richiesto" Name="ValoreRealizzatoRichiesto" ></Siar:ImportoColumn>
            <Siar:ImportoColumn DataField="IdDimXProgrammazione" Importo="ValoreRealizzatoAmmesso" HeaderText="Val. Realizzato Ammesso" Name="ValoreRealizzatoAmmesso" ></Siar:ImportoColumn>
            <asp:BoundColumn DataField="DimUm" HeaderText="Unità di misura"></asp:BoundColumn>
            <asp:BoundColumn DataField="Richiedibile" HeaderText="Richiedibile" Visible="false"></asp:BoundColumn>
        </Columns>
    </Siar:DataGrid>
</div>