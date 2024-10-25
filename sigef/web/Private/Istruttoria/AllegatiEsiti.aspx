<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.AllegatiEsiti" CodeBehind="AllegatiEsiti.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <br />
    <table class="tableNoTab" width="1000">
        <tr>
            <td class="separatore_big">
                ISTRUTTORIA DEGLI ALLEGATI ALLA DOMANDA
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <p>
                    &nbsp;&nbsp;&nbsp; Per predisporre la richiesta di certificazione al comune/provincia
                    è necessario selezionare gli allegati di interesse e poi il pulsante "Richiedi certificazione".
                </p>
                <p>
                    &nbsp;&nbsp;&nbsp; Per predisporre la richiesta di documentazione integrazione è possibile selezionando
                    gli allegati di interesse o meno e poi il pulsante "Richiedi documentazione integrativa".
                </p>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Digitare la segnatura della busta chiusa pervenuta:<br />
                <Siar:TextBox runat="server" ID="txtNumProtocollo" MaxLength="80" Width="514px" NomeCampo="Segnatura degli allegati"
                    ReadOnly="True" />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgAllegato" runat="server" AutoGenerateColumns="False" Width="100%">
                    <ItemStyle Height="40px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="CodTipo" HeaderText="Formato">
                            <ItemStyle HorizontalAlign="Center" Width="50px" Font-Bold="true" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Dettaglio documento"></asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdFile" ButtonImage="lente.png" ButtonText="Visualizza"
                            ButtonType="ImageButton" JsFunction="SNCUFVisualizzaFile">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:JsButtonColumn>
                        <asp:BoundColumn HeaderText="Esito">
                            <ItemStyle Width="130px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Note">
                            <ItemStyle Width="380px" />
                        </asp:BoundColumn>
                        <Siar:CheckColumn Name="chkSelezionaPerRichiedeIntegrazione" HeaderSelectAll="true"
                            DataField="Id">
                            <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 50px; padding-right: 50px">
                <Siar:Button ID="btnSalva" runat="server" Text="Salva" Width="175px" OnClick="btnSalva_Click"
                    Modifica="true" />
                &nbsp;&nbsp;&nbsp;
                <Siar:Button ID="btnRichiestaCertificazione" runat="server" Text="Richiedi Certificazione"
                    Width="200px" OnClick="btnRichiestaCertificazione_Click" Modifica="true" />
                &nbsp;&nbsp;&nbsp;
                <Siar:Button ID="btnRichiestaDocumentiIntegrativi" runat="server" Text="Richiedi Documentazione Integrativa"
                    Width="220px" OnClick="btnRichiestaDocumentiIntegrativi_Click" Modifica="true" />
                &nbsp;&nbsp;&nbsp;
                <input type="button" class="Button" value="Indietro" style="width: 120px; margin-left: 20px"
                    onclick="history.back();" />
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
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
