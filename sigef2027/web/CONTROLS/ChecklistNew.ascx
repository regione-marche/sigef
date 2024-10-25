<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChecklistNew.ascx.cs"
    Inherits="web.CONTROLS.ChecklistNew" %>

<Siar:DataGridAgid ID="dgSteps" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" AllowPaging="false" OnItemDataBound="dgSteps_ItemDataBound">    
    <Columns>
        <Siar:NumberColumn HeaderText="Nr.">            
            <ItemStyle HorizontalAlign="center" />
        </Siar:NumberColumn>
        <asp:BoundColumn HeaderText="Descrizione" DataField="Descrizione"></asp:BoundColumn>
        <asp:BoundColumn HeaderText="Obbligatorio" DataField="Obbligatorio" DataFormatString="{0:SI|NO}">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundColumn>
        <asp:TemplateColumn HeaderText="Esito Verifica">
            <ItemStyle HorizontalAlign="Center"/>
            <ItemTemplate>
                <Siar:ComboSiNo ID="lstEsitoStep" runat="server" DataColumn="IdStep" NoBlankItem="true">
                </Siar:ComboSiNo>
            </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="Azione">
            <ItemStyle HorizontalAlign="Center"/>
        </asp:TemplateColumn>
        <Siar:TextAreaColumn HeaderText="Note" DataField="IdStep" Name="txtAreaLungaCKL">
            <ItemStyle HorizontalAlign="Center" />
        </Siar:TextAreaColumn>
    </Columns>
</Siar:DataGridAgid>
<div style="display: none">
    <asp:Button ID="btnChkCodeMethodExec" runat="server" OnClick="btnChkCodeMethodExec_Click" />
    <input id="hdnChkCodeMethodIdStep" type="hidden" runat="server" />
</div>
