<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IVariante.Allegati" CodeBehind="Allegati.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/IVariantiControl.ascx" TagName="IVariantiControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <uc1:IVariantiControl ID="ucWorkFlowVarianti" runat="server" />
    <br />
    <table class="tableNoTab" width="1150px">
        <tr>
            <td class="separatore_big">
                ISTRUTTORIA DEGLI ALLEGATI
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Digitare la segnatura della busta chiusa pervenuta:
                <br />
                &nbsp;&nbsp;<br />
                &nbsp; &nbsp;<Siar:TextBox runat="server" ID="txtNumProtocollo" MaxLength="80" Width="590px"
                    NomeCampo="Segnatura degli allegati" ReadOnly="true" />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgAllegati" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="center" Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Formato" HeaderText="Formato">
                            <ItemStyle HorizontalAlign="Center" Width="50px" Font-Bold="true" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Dettaglio documento"></asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdFile" ButtonImage="lente.png" ButtonText="Visualizza"
                            ButtonType="ImageButton" JsFunction="SNCUFVisualizzaFile">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:JsButtonColumn>
                        <asp:BoundColumn HeaderText="Esito">
                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Note">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:CheckColumn Name="chkSelezionaPerRichiedeIntegrazione" HeaderSelectAll="true"
                            DataField="IdAllegato">
                            <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 55px">
                <Siar:Button ID="btnSalva" runat="server" Modifica="true" OnClick="btnSalva_Click"
                    Text="Ammetti" Width="200px"></Siar:Button>
                &nbsp;&nbsp; &nbsp;
                <Siar:Button ID="btnRichiestaCertificazione" runat="server" Text="Richiedi Certificazione"
                    Width="230px" OnClick="btnRichiestaCertificazione_Click" Modifica="true" />
                &nbsp;&nbsp;&nbsp;
                <Siar:Button ID="btnRichiestaDocumentiIntegrativi" runat="server" Text="Richiedi Documentazione Integrativa"
                    Width="230px" OnClick="btnRichiestaDocumentiIntegrativi_Click" Modifica="true" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Elenco delle richieste di certificazione e comunicazioni inviate
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgComunicazioniInviate" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="15" Width="100%">
                    <ItemStyle Height="50px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="25px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="TipoSegnatura" HeaderText="Tipo">
                            <ItemStyle Width="200px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Ente" DataField="Ente">
                            <ItemStyle Width="100px" HorizontalAlign="left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Data" HeaderText="Data">
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="NominativoOperatore" HeaderText="Operatore">
                            <ItemStyle Width="100px" HorizontalAlign="left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Stato">
                            <ItemStyle Width="100px" HorizontalAlign="left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle Width="50px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
    </table>
</asp:Content>
