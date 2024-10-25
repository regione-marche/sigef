<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChecklistNew.ascx.cs"
    Inherits="web.CONTROLS.ChecklistNew" %>
<Siar:DataGrid ID="dgSteps" runat="server" AutoGenerateColumns="False" AllowPaging="false"
    Width="100%" OnItemDataBound="dgSteps_ItemDataBound">
    <ItemStyle Height="24px" />
    <Columns>
        <Siar:NumberColumn HeaderText="Nr.">
            <HeaderStyle Width="25px" />
            <ItemStyle HorizontalAlign="center" />
        </Siar:NumberColumn>
        <asp:BoundColumn HeaderText="Descrizione" DataField="Descrizione"></asp:BoundColumn>
        <asp:BoundColumn HeaderText="Obbligatorio" DataField="Obbligatorio" DataFormatString="{0:SI|NO}">
            <ItemStyle HorizontalAlign="Center" Width="80px" />
        </asp:BoundColumn>
        <asp:TemplateColumn HeaderText="Esito Verifica">
            <ItemStyle HorizontalAlign="Center" Width="100px" />
            <ItemTemplate>
                <Siar:ComboSiNo ID="lstEsitoStep" runat="server" DataColumn="IdStep" NoBlankItem="true">
                </Siar:ComboSiNo>
            </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="Azione">
            <ItemStyle HorizontalAlign="Center" Width="130px" />
        </asp:TemplateColumn>
        <Siar:TextAreaColumn HeaderText="Note" DataField="IdStep" Name="txtAreaLungaCKL">
            <ItemStyle Width="400px" HorizontalAlign="Center" />
        </Siar:TextAreaColumn>
    </Columns>
</Siar:DataGrid>
<div style="display: none">
    <asp:Button ID="btnChkCodeMethodExec" runat="server" OnClick="btnChkCodeMethodExec_Click" />
    <input id="hdnChkCodeMethodIdStep" type="hidden" runat="server" />
</div>
