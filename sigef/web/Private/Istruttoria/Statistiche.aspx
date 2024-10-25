<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="Statistiche.aspx.cs" Inherits="web.Private.Istruttoria.Statistiche" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <br />
    <table class="tableNoTab" width="800px">
        <tr>
            <td class="separatore_big">
                STATISTICHE DEL BANDO
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Statistiche del bando
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 10px">
                <Siar:DataGrid ID="dgStatistiche" runat="server" AutoGenerateColumns="False" Width="100%"
                    EnableViewState="False" NrColumnSearch="False">
                    <ItemStyle Height="40px" />
                    <Columns>
                        <asp:BoundColumn DataField="Fase" HeaderText="Fase procedurale">
                            <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Stato" HeaderText="Stato">
                            <ItemStyle Width="200px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Nr.domande">
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SegnaturaAllegati" HeaderText="Stato">
                            <ItemStyle Width="200px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdBando" HeaderText="Nr.domande">
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
