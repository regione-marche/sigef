<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
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
    
    <div class="row bd-form">

        <h3 class="pb-5 align-items-center">Ricerca Ritiri e Recuperi</h3>
        <p class="mb-5">
            - Indicare il numero identificativo della domanda avente un registro recuperi/ritiri o a cui associarne uno.
        </p>
        <div class="row">
            <div class="col-sm-6 form-group">
                <Siar:IntegerTextBox Label="Numero domanda" ID="txtNumDomanda" runat="server" Obbligatorio="true" NoCurrency="true" NomeCampo="Numero domanda" />
            </div>
            <div class="col-sm-6">
                <Siar:Button ID="btnCerca" runat="server" Text="Cerca" OnClick="btnCerca_Click" CausesValidation="true" />
            </div>
        </div>
    </div>

    <div class="row mt-5">
        <h4 class="pb-5 align-items-center">Risultato ricerca</h4>

        <div id="tdDomanda" runat="server" class="p-2" />

        <div id="tdPulsantiBando" class="p-2" runat="server" align="center" />

        <div id="tdFase2" class="p-2" runat="server" />

        <div id="tbRecuperi" runat="server" class="container" visible="false">
           
            <div class="row p-2">
                <div class="col-12">
                    <div class="table-responsive">
                        <Siar:DataGridAgid ID="dgRegistroRecuperi" runat="server" AutoGenerateColumns="False" ShowFooter="true" CssClass="table table-striped" PageSize="20">
                            <ItemStyle Height="24px" />
                            <Columns>
                                <asp:BoundColumn DataField="IdRegistroRecupero" HeaderText="Id"></asp:BoundColumn>
                                <asp:BoundColumn DataField="IdTipoRecupero" HeaderText="Tipologia"></asp:BoundColumn>
                                <asp:BoundColumn DataField="DataAvvio" HeaderText="Data avvio"></asp:BoundColumn>
                                <asp:BoundColumn DataField="DataConclusione" HeaderText="Data conclusione"></asp:BoundColumn>
                                <asp:BoundColumn DataField="IdProcedureAvviate" HeaderText="Procedure avviate"></asp:BoundColumn>
                                <asp:BoundColumn DataField="IdTipoProcedureAvviate" HeaderText="Tipo procedure"></asp:BoundColumn>
                                <Siar:CheckColumn DataField="Recuperabile" HeaderText="Recuperabile" ReadOnly="true"></Siar:CheckColumn>
                                <Siar:JsButtonColumnAgid Arguments="IdRegistroRecupero" ButtonType="TextButton" ButtonText="Dettaglio"
                                    JsFunction="caricaRecupero">
                                    <ItemStyle HorizontalAlign="Center" />
                                </Siar:JsButtonColumnAgid>
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnInserisci" runat="server" Text="Inserisci un nuovo recupero o ritiro"
                    OnClick="btnInserisci_Click" CausesValidation="false"></Siar:Button>
            </div>
        </div>
    </div>
</asp:Content>
