<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IstruttoriaAllegati" CodeBehind="IstruttoriaAllegati.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server"></uc2:IDomandaPagamento>
    <br />
    <table class="tableNoTab" width="1150px">
        <tr>
            <td class="separatore_big">
                ISTRUTTORIA DEGLI ALLEGATI ALLA DOMANDA DI PAGAMENTO
            </td>
        </tr>
        <tr>
            <td style="height: 75px">
                &nbsp;<br />
                &nbsp;Digitare la segnatura della documentazione pervenuta:<br />
                &nbsp;<Siar:TextBox ID="txtNumProtocollo" runat="server" MaxLength="80" NomeCampo="Segnatura degli allegati"
                    Width="590px"></Siar:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<br />
                <Siar:DataGrid ID="dgAllegati" runat="server" AutoGenerateColumns="False" CssClass="tabella"
                    Width="100%">
                    <PagerStyle Mode="NumericPages" CssClass="coda"></PagerStyle>
                    <AlternatingItemStyle BackColor="#FFF0D2" CssClass="DataGridRow"></AlternatingItemStyle>
                    <ItemStyle CssClass="DataGridRow" Height="18px"></ItemStyle>
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
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
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 55px">
                <Siar:Button ID="btnSalva" runat="server" Modifica="true" OnClick="btnSalva_Click"
                    Text="Ammetti" Width="200px"></Siar:Button>
                &nbsp;&nbsp; &nbsp;
                <Siar:Button ID="btnRichiestaCertificazione" runat="server" Text="Richiedi Certificazione"
                    Width="200px" OnClick="btnRichiestaCertificazione_Click" Modifica="true" />
                &nbsp;&nbsp;&nbsp;
                <Siar:Button ID="btnRichiestaDocumentiIntegrativi" runat="server" Text="Richiedi Documentazione Integrativa"
                    Width="220px" OnClick="btnRichiestaDocumentiIntegrativi_Click" Modifica="true" Visible="false"/>
                &nbsp;&nbsp;&nbsp;
                <input id="btnBack" runat="server" class="Button" style="width: 160px" type="button"
                    onclick="javascript:location='CheckListPagamento.aspx'" value="Indietro" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr id="trIntegrazioneDomanda" runat="server" visible="false">
            <td>
                <table>
                    <tr>
                        <td class="paragrafo">
                            &nbsp;Richiedi integrazione di documentazione:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Data richiesta:<br />
                            <Siar:DateTextBox ID="txtDataIntegrazione" runat="server" Width="120px" /><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Richiedi l'integrazione o la modifica della documentazione:<br />
                            <Siar:TextArea ID="txtNoteIntegrazioneAllegati" runat="server" NomeCampo="Richiedi l'integrazione o la modifica della documentazione"
                                Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" MaxLength="10000" /><br />
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                            <Siar:Button ID="btnRichiediIntegrazioneAllegati" runat="server" Modifica="True"
                                OnClick="btnRichiediIntegrazioneAllegati_Click" Text="Richiedi integrazione" Width="190px" />
                        </td>
                    </tr>
                </table>
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
    </table>
    <br />
</asp:Content>
