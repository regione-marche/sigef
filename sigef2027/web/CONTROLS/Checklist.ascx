<%@ Control Language="C#" AutoEventWireup="true" Inherits="Checklist" CodeBehind="Checklist.ascx.cs" %>
<Siar:DataGridAgid ID="dgSteps" runat="server" AutoGenerateColumns="False" AllowPaging="false" CssClass="table table-striped"
     OnItemDataBound="dgSteps_ItemDataBound" NrColumnSearch="true">    
    <Columns>
        <Siar:NumberColumn HeaderText="Nr.">            
            <ItemStyle HorizontalAlign="center" />
        </Siar:NumberColumn>
        <asp:BoundColumn HeaderText="Descrizione" DataField="Step"></asp:BoundColumn>
        <asp:BoundColumn HeaderText="Obbligatorio" DataField="Obbligatorio" DataFormatString="{0:SI|NO}">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundColumn>
        <asp:TemplateColumn HeaderText="Esito Verifica">
            <ItemStyle HorizontalAlign="Center" />
            <ItemTemplate>
                <Siar:ComboSiNo ID="lstEsitoStep" runat="server" DataColumn="IdStep" NoBlankItem="true">
                </Siar:ComboSiNo>
            </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="Azione">
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateColumn>
        <Siar:TextAreaColumnAgid HeaderText="Note" DataField="IdStep" Name="txtAreaLungaCKL">
            <ItemStyle HorizontalAlign="Center" />
        </Siar:TextAreaColumnAgid>
    </Columns>
</Siar:DataGridAgid>
