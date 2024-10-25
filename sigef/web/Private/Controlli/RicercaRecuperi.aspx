<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Controlli.RicercaRecuperi" CodeBehind="RicercaRecuperi.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    
        function caricaRecupero(id) {
            $('[id$=hdnIdRecupero]').val(id);
            $('[id$=btnCaricaRecupero]').click();
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
        <asp:HiddenField ID="hdnIdRecupero" runat="server" />
        <asp:Button ID="btnCaricaRecupero" runat="server" CausesValidation="False" OnClick="btnCaricaRecupero_Click" />
    </div>
    
    <div class="dBox">
        <div class="separatore_big">
            RICERCA RECUPERI E RITIRI
        </div>
        <div class="dSezione">
            <div class="dContenutoFloat">
                - Indicare il numero identificativo della domanda avente un registro recuperi/ritiri o a cui associarne uno.
                <br /><br />
                <strong>Numero domanda:</strong>
                <Siar:IntegerTextBox ID="txtNumDomanda" runat="server" Width="84px" Obbligatorio="true"
                    NoCurrency="true" NomeCampo="Numero domanda" />
                <Siar:Button ID="btnCerca" runat="server" Width="133px" Text="Cerca" OnClick="btnCerca_Click" CausesValidation="true">
                </Siar:Button>&nbsp; 
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
                <td id="tdDomanda" runat="server" style="padding-top: 15px; padding-bottom: 15px"></td>
            </tr>
            <tr>
                <td id="tdPulsantiBando" runat="server" align="center">
                </td>
            </tr>
            <tr>
                <td id="tdFase2" runat="server">
                </td>
            </tr>
            <tr>
                <td>
                    <table id="tbRecuperi" runat="server" style="padding-top: 15px; padding-bottom: 15px" width="100%" visible="false">
                        <tr>
                            <td class="separatore_big">
                                REGISTRO RECUPERI E RITIRI
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <Siar:DataGrid ID="dgRegistroRecuperi" runat="server" AutoGenerateColumns="false"
                                    Width="100%">
                                    <ItemStyle Height="24px" />
                                    <Columns>
                                        <asp:BoundColumn DataField="IdRegistroRecupero" HeaderText="Id"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="IdTipoRecupero" HeaderText="Tipologia"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="DataAvvio" HeaderText="Data avvio"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="DataConclusione" HeaderText="Data conclusione"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="IdProcedureAvviate" HeaderText="Procedure avviate"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="IdTipoProcedureAvviate" HeaderText="Tipo procedure">
                                        </asp:BoundColumn>
                                        <Siar:CheckColumn DataField="Recuperabile" HeaderText="Recuperabile" ReadOnly="true"></Siar:CheckColumn>
                                        <Siar:JsButtonColumn Arguments="IdRegistroRecupero" ButtonType="TextButton" ButtonText="Dettaglio"
                                            JsFunction="caricaRecupero">
                                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                                        </Siar:JsButtonColumn>
                                    </Columns>
                                </Siar:DataGrid>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <Siar:Button ID="btnInserisci" runat="server" Width="280px" Text="Inserisci un nuovo recupero o ritiro" 
                                    OnClick="btnInserisci_Click" CausesValidation="false" ></Siar:Button>&nbsp; &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
