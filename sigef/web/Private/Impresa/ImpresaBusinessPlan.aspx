<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Impresa.ImpresaBusinessPlan" CodeBehind="ImpresaBusinessPlan.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <table class="tableNoTab" width="900px">
        <tr>
            <td class="separatore_big">
                GESTIONE FINANZIARIA
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dg" runat="server" AutoGenerateColumns="False" Width="100%">
                    <ItemStyle Height="50px" />
                    <Columns>
                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="ELENCO DELLE SEZIONI" LinkFields="Denominazione"
                            LinkFormat="{0}">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:ColonnaLink>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
    </table>
</asp:Content>
