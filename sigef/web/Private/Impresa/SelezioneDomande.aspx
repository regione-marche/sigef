<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="SelezioneDomande.aspx.cs" Inherits="web.Private.Impresa.SelezioneDomande" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function redirect(id) { document.location='../PDomanda/DatiGenerali.aspx?iddom='+id; }
    </script>

    <br />
    <table class="tableNoTab" width="850px">
        <tr>
            <td class="separatore_big">
                SELEZIONE DELLA DOMANDA DI AIUTO (solo per bando multiprogetto)
            </td>
        </tr>
        <tr>
            <td style="padding-top: 20px; padding-bottom: 20px">
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
            <td style="height: 83px" align="center">
                <b>ATTENZIONE:</b>
                <br />
                il bando selezionato offre la possibilità di inserire <b>più domande</b> per lo
                stesso Codice Fiscale.
                <br />
                Di seguito sono elencate le domande gia' inserite dall'impresa per questo bando,
                se si intende prendere visione<br />
                di una di tali domande, selezionare quella desiderata altrimenti scegliere "Nuova
                domanda di adesione".
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dgProgetti" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Numero">
                            <ItemStyle Width="60px" HorizontalAlign="center" Font-Bold="true" Font-Size="14px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Stato" HeaderText="Stato">
                            <ItemStyle Width="150px" HorizontalAlign="Center" Font-Bold="true" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Operatore">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Data rilascio">
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn ButtonType="TextButton" ButtonText="Visualizza" Arguments="IdProgetto"
                            JsFunction="redirect">
                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                        </Siar:JsButtonColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 65px">
                <Siar:Button ID="btnNuovaDomanda" runat="server" Text="Nuova domanda di adesione"
                    Modifica="True" OnClick="btnNuovaDomanda_Click" Width="230px" />
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
