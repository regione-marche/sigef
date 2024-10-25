<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="NuovaDomanda.aspx.cs" Inherits="web.Private.Impresa.NuovaDomanda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <br />
    <table class="tableNoTab" width="800">
        <tr>
            <td class="separatore_big">
                CONFERMA DELL&#39;INSERIMENTO DI UNA NUOVA DOMANDA DI AIUTO
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 60px; font-size: 15px; font-weight: bold">
                SI STA PER INSERIRE LA DOMANDA DI ADESIONE AL BANDO:
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgBandi" runat="server" AutoGenerateColumns="False" Width="100%">
                    <ItemStyle Height="50px" />
                    <Columns>
                        <Siar:JsButtonColumn Arguments="IdBando" ButtonImage="Info.ico" ButtonType="ImageButton"
                            ButtonText="Info sul bando" JsFunction="mostraPopupDocumentiBando">
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </Siar:JsButtonColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Ente" HeaderText="Emesso da">
                            <ItemStyle HorizontalAlign="center" Width="130px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Importo" HeaderText="Importo" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="center" Width="130px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataScadenza" HeaderText="Scadenza">
                            <ItemStyle HorizontalAlign="center" Width="110px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 60px; font-size: 15px; font-weight: bold">
                CONTINUARE?
            </td>
        </tr>
        <tr>
            <td style="height: 60px" align="center">
                <Siar:Button ID="btnConferma" runat="server" OnClick="btnConferma_Click" Text="Conferma"
                    Width="180px" Modifica="True" />
                <input class="Button" style="width: 180px; margin-left: 20px" type="button" value="Indietro"
                    onclick="history.back();" />
            </td>
        </tr>
    </table>
    <div id="divDocumentiBando" style="width: 750px; position: absolute; display: none">
        <table class="tableNoTab" width="100%">
            <tr>
                <td class="separatore">
                    Elenco documenti relativi al bando selezionato:
                </td>
            </tr>
            <tr>
                <td id="tdGridDocumentiBando" style="padding: 5px">
                </td>
            </tr>
            <tr>
                <td style="height: 40px; padding-right: 40px;" align="right">
                    <input style="width: 155px" type="button" value="Chiudi" class="Button" onclick="chiudiPopupTemplate()" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
