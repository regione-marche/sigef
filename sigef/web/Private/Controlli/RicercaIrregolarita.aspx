<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Controlli.RicercaIrregolarita" CodeBehind="RicercaIrregolarita.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--

        function caricaIrregolarita(id) {
            $('[id$=hdnIdIrregolarita]').val(id);
            $('[id$=btnCaricaIrregolarita]').click();
        }

        function inserisciIrregolarita(id) {
            $('[id$=hdnIdDomanda]').val(id);
            $('[id$=btnInserisciIrregolaritaDomandaPagamento]').click();
        }
        
//--></script>

    <style type="text/css">
        .dBox-overflow 
        {
	        box-shadow: 2px 3px 10px;
	        border-radius: 5px;
	        background-color:#E6E6EE;        	
	        margin:0px 10px 20px 10px;
	        overflow:hidden;
        }
    </style>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdIrregolarita" runat="server" />
        <asp:HiddenField ID="hdnIdDomanda" runat="server" />
        <asp:Button ID="btnCaricaIrregolarita" runat="server" CausesValidation="False" OnClick="btnCaricaIrregolarita_Click" />
        <asp:Button ID="btnInserisciIrregolaritaDomandaPagamento" runat="server" CausesValidation="False" OnClick="btnInserisciIrregolaritaDomandaPagamento_Click" />
    </div>
    
    <div class="dBox">
        <div class="separatore_big">
            RICERCA CONTROLLO IRREGOLARITA'
        </div>
        <div class="dSezione">
            <div class="dContenutoFloat">
                - Indicare il numero identificativo della domanda avente un controllo irregolarità
                associato o a cui associarne uno.
                <br />
                <br />
                <strong>Numero domanda:</strong>
                <Siar:IntegerTextBox ID="txtNumDomanda" runat="server" Width="84px" Obbligatorio="true"
                    NoCurrency="true" NomeCampo="Numero domanda" />
                <Siar:Button ID="btnCerca" runat="server" Width="133px" Text="Cerca" OnClick="btnCerca_Click"
                    CausesValidation="true"></Siar:Button>&nbsp;
            </div>
        </div>
    </div>
    <br />
    <div class="dBox-overflow">
        <table width="100%">
            <tr>
                <td class="separatore_big">
                    Risultato ricerca:
                </td>
            </tr>
            <tr>
                <td id="tdDomanda" runat="server" style="padding-top: 15px; padding-bottom: 15px">
                </td>
            </tr>
            <tr>
                <td id="tdPulsantiBando" runat="server" align="center">
                </td>
            </tr>
            <div id="divElencoDomande" runat="server" visible="false" >
            <tr>
                <td class="separatore">
                    Elenco delle domande di pagamento:
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <Siar:DataGrid ID="dgDomande" runat="server" Width="100%" AutoGenerateColumns="False">
                        <ItemStyle Height="30px" />
                        <Columns>
                            <asp:BoundColumn HeaderText="Richiesto">
                                <ItemStyle HorizontalAlign="center" Width="50px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Modalità di pagamento" DataField="Descrizione">
                                <ItemStyle HorizontalAlign="center" Width="140px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText=" ">
                                <ItemStyle HorizontalAlign="center" Width="190px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Importo richiesto" DataField="ImportoRichiesto" DataFormatString="{0:c}">
                                <ItemStyle HorizontalAlign="right" Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Contributo richiesto" DataField="ContributoRichiesto" DataFormatString="{0:c}">
                                <ItemStyle HorizontalAlign="right" Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Domanda pagamento" >
                                <ItemStyle HorizontalAlign="center" Width="50px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Istruita">
                                <ItemStyle HorizontalAlign="center" Width="50px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText=" ">
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Importo ammesso" DataField="ImportoAmmesso" DataFormatString="{0:c}">
                                <ItemStyle HorizontalAlign="right" Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Contributo ammesso (*)" DataField="ContributoAmmesso" DataFormatString="{0:c}">
                                <ItemStyle HorizontalAlign="right" Width="100px" />
                            </asp:BoundColumn>
                            <Siar:JsButtonColumn Arguments="IdDomandaPagamento" ButtonType="TextButton" ButtonText="Irregolarità"
                                JsFunction="inserisciIrregolarita">
                                <ItemStyle Width="90px" HorizontalAlign="Center" />
                            </Siar:JsButtonColumn>
                        </Columns>
                    </Siar:DataGrid>
                    <div style="width: 100%; text-align: right">
                        (<font style="text-decoration: line-through; font-weight: bold; color: #bc3333">in rosso</font>
                        le domande di pagamento non approvate)
                        <br />
                        (*=importo calcolato al netto delle sanzioni e del recupero anticipo percepito)
                    </div>
                </td>
            </tr>
            </div>
            <tr>
                <td>
                    <table id="tbIrregolarita" runat="server" style="padding-top: 15px; padding-bottom: 15px"
                        width="100%" visible="false">
                        <tr>
                            <td class="separatore_big">
                                IRREGOLARITA' ASSOCIATE ALLA DOMANDA DI AIUTO
                            </td>
                        </tr>
                        <tr>
                            <td><br /></td>
                        </tr>
                        <tr>
                            <td align="center">
                                <Siar:Button ID="btnInserisciIrregolaritaDomandaAiuto" runat="server" Width="400px" Text="Inserisci una nuova irregolarità associata alla domanda di aiuto"
                                    OnClick="btnInserisciIrregolaritaDomandaAiuto_Click" CausesValidation="false"></Siar:Button>&nbsp; &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <Siar:DataGrid ID="dgIrregolarita" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="15" Width="100%" ShowFooter="true">
                                    <ItemStyle Height="28px" />
                                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                    <Columns>
                                        <asp:BoundColumn DataField="IdIrregolarita" HeaderText="ID">
                                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="DataIrregolarita" HeaderText="Data irregolarità">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="IdImpresaCommessaDa" HeaderText="Commessa da">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="CommessaA" HeaderText="Commessa a">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="IdCategoriaIrregolarita" HeaderText="Categoria">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="IdTipoIrregolarita" HeaderText="Tipo">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="IdClassificazioneIrregolarita" HeaderText="Classificazione">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <Siar:CheckColumn DataField="SegnalazioneOlaf" Name="chkSegnalazioneOlaf" HeaderText="Segnalazione Olaf"
                                            ReadOnly="true">
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </Siar:CheckColumn>
                                        <Siar:JsButtonColumn Arguments="IdIrregolarita" ButtonType="TextButton" ButtonText="Dettaglio"
                                            JsFunction="caricaIrregolarita">
                                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                                        </Siar:JsButtonColumn>
                                    </Columns>
                                </Siar:DataGrid>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
