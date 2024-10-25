<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.RevisioneDomande" CodeBehind="RevisioneDomande.aspx.cs" %>

<%@ Register Src="../../CONTROLS/FiltroRicercaDomande.ascx" TagName="FiltroRicercaDomande"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <table class="tableNoTab" width="1000px">
        <tr>
            <td class="separatore_big">
                Revisione dell'istruttoria sulle domande di aiuto
            </td>
        </tr>
        <tr>
            <td>
                <br />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                    border-bottom: black 1px solid" width="800">
                    <tr>
                        <td style="border-right: black 1px solid; width: 533px" align="left">
                            &nbsp;La revisione viene effettuata su un campione del 5% di tutte le pratiche che
                            hanno passato con successo o non l'istruttoria di ammissibità e che hanno i seguenti
                            requisiti:<br />
                            &nbsp;- l'ammontare degli investimenti non supera i 700.000 €<br />
                            &nbsp;- il revisore non ha istruito la domanda in ammissiblità.&nbsp;<br />
                            Per estrarre il campione utilizzare il pulsante "Calcola".
                        </td>
                        <td>
                            <Siar:Button ID="btnCalcola" runat="server" Modifica="True" OnClick="btnCalcola_Click"
                                Text="Calcola" Width="144px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    &nbsp;<br />
    <table class="tableNoTab" width="1000">
        <tr>
            <td class="separatore">
                &nbsp;Lista delle domande di aiuto estratte a campione:
            </td>
        </tr>
        <tr>
            <td align="right">
                <uc2:FiltroRicercaDomande ID="ucFiltroRicercaDomande" runat="server" EsportaEnabled="false" />
            </td>
        </tr>
        <tr>
            <td>
                <Siar:Label ID="lblElementi" runat="server">
                </Siar:Label>
                <br />
                &nbsp;<br />
                <Siar:DataGrid ID="dg" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    DataKeyField="IdProgetto" PageSize="15" Width="100%">
                    <ItemStyle Height="50px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Domanda"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Stato" HeaderText="Stato procedurale">
                            <ItemStyle HorizontalAlign="Center" Width="110px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Istruttore" HeaderText="Istruttore assegnato">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ProvinciaAssegnazione" HeaderText="Provincia di assegnazione">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Vai alla checklist di revisione">
                            <ItemStyle HorizontalAlign="Center" Width="110px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Stato della revisione">
                            <ItemStyle HorizontalAlign="Center" Width="110px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Iter procedurale della domanda">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
