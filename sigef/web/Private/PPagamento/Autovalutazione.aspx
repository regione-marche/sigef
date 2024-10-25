<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" Inherits="web.Private.PPagamento.Autovalutazione" CodeBehind="Autovalutazione.aspx.cs" %>

<%@ Register Src="~/CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/ucSceltaChecklistValidazione.ascx" TagName="ucSceltaChecklist" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/ucChecklistGenerica.ascx" TagName="ChecklistGenerica" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <style type="text/css">
        .first_elem_block {
            /*width: 200px;*/
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {
            /*width: 200px;*/
            vertical-align: top;
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-left: 20px;
            padding-bottom: 5px;
        }

        .paragrafo_light {
            border-bottom: solid 1px #084600;
            font-size: 14px;
        }

        .box_ricerca {
            background-color: #cfcfd6;
            padding: 7px;
        }

        .label {
            display: inline;
            float: left;
            min-width: 200px;
            max-width: 200px;
            width: 200px;
            text-align: right;
            vertical-align: middle;
        }

        .value {
            float: right;
            margin-left: 5px;
        }
    </style>

    <script type="text/javascript">

        function SelezionaAutovalutazione(id_autovalutazione) {
            $('[id$=hdnIdAutovalutazione]').val($('[id$=hdnIdAutovalutazione]').val() == id_autovalutazione ? '' : id_autovalutazione);
            $('[id$=btnPost]').click();
        }

        function EliminaAutovalutazione(id_autovalutazione) {
            var domanda = confirm("Sei sicuro di voler eliminare l'autovalutazione?");
            if (domanda === true) {
                $('[id$=hdnIdAutovalutazioneEliminazione]').val($('[id$=hdnIdAutovalutazioneEliminazione]').val() == id_autovalutazione ? '' : id_autovalutazione);
                $('[id$=btnPostElimina]').click();
            }
        }

        function CopiaAutovalutazione(id_autovalutazione) {
            var domanda = confirm("Sei sicuro di voler copiare l'autovalutazione?");
            if (domanda === true) {
                $('[id$=hdnIdAutovalutazioneCopia]').val($('[id$=hdnIdAutovalutazioneCopia]').val() == id_autovalutazione ? '' : id_autovalutazione);
                $('[id$=btnPostCopia]').click();
            }
        }

    </script>

    <div style="display: none">
        <Siar:Button ID="btnPost" runat="server" CausesValidation="False" OnClick="btnPost_Click" />
        <Siar:Button ID="btnPostElimina" runat="server" CausesValidation="false" OnClick="btnPostElimina_Click" />
        <Siar:Button ID="btnPostCopia" runat="server" CausesValidation="false" OnClick="btnPostCopia_Click" />
        <asp:HiddenField ID="hdnIdAutovalutazione" runat="server" />
        <asp:HiddenField ID="hdnIdAutovalutazioneEliminazione" runat="server" />
        <asp:HiddenField ID="hdnIdAutovalutazioneCopia" runat="server" />
    </div>

    <uc1:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
    <br />

    <div class="dBox">
        <div class="separatore">
            Autovalutazione
        </div>
        <br />

        <div style="padding:10px;">
            <div class="first_elem_block">
                <Siar:Button ID="btnAggiungiAutovalutazione" Modifica="true" runat="server" CausesValidation="false" Text="Aggiungi autovalutazione" Style="width: 160px;" OnClick="btnAggiungiAutovalutazione_Click" />
            </div>

            <div class="elem_block">
                <input id="btnVisualizzaAutovalutazione" runat="server" type="button" class="Button" style="width: 160px" value="Visualizza autovalutazione" />
            </div>
            <br />
            <br />

            <div id="divAutovalutazioniPrecedenti" runat="server">
                <p>
                    E' possibile copiare un'autovalutazione presentata in una domanda di pagamento precedente.<br />
                    Copiando un'autovalutazione precedente si copieranno anche i rispettivi esiti e si elimineranno le eventuali autovalutazioni della domanda di pagamento in compilazione.
                </p>
                <br />

                <Siar:DataGrid ID="dgAutovalutazioniPrecedenti" runat="server" Width="100%" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Id domanda pagamento">
                            <ItemStyle Font-Bold="True" HorizontalAlign="Center" Width="150px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoDomandaPagamento" HeaderText="Tipo domanda pagamento">
                            <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdTestata" HeaderText="Copia autovalutazione" ButtonType="TextButton" ButtonText="Copia" JsFunction="CopiaAutovalutazione">
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
                <br />
                <br />
            </div>

            <div class="paragrafo_light">
                Autovalutazioni selezionate:
            </div>
            <br />
            <Siar:DataGrid ID="dgAutovalutazioni" runat="server" Width="100%" AutoGenerateColumns="false" >
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn DataField="IdTestataValidazioneXIstanza" HeaderText="Id">
                        <ItemStyle Font-Bold="True" HorizontalAlign="Center" Width="40px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneChecklist" HeaderText="Descrizione autovalutazione">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Note" HeaderText="Note">
                        <ItemStyle Width="200px" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdTestataValidazioneXIstanza" ButtonType="TextButton" ButtonText="Seleziona autovalutazione" JsFunction="SelezionaAutovalutazione">
                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                    </Siar:JsButtonColumn>
                    <Siar:JsButtonColumn Arguments="IdTestataValidazioneXIstanza" HeaderText="Elimina" ButtonType="ImageButton" ButtonImage="xdel.gif" JsFunction="EliminaAutovalutazione">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
            <br />
            <br />

            <div id="divDettaglioAutovalutazione" runat="server">
                <div class="paragrafo_light">
                    Dettaglio autovalutazione
                </div>
                <br />

                <uc4:ChecklistGenerica ID="ucChecklistGenerica" runat="server" DefaultRedirect="../PPagamento/PianoInvestimenti.aspx" />
                <br />
                <br />

                <div class="first_elem_block">
                    <div class="label">Note autovalutazione: (opzionale)</div>
                    <div class="value">
                        <Siar:TextArea ID="txtNoteAutovalutazione" runat="server" NomeCampo="Note autovalutazione"
                            Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <Siar:Button ID="btnSalvaAutovalutazione" Modifica="true" runat="server" CausesValidation="false" Text="Salva note autovalutazione" Style="width: 170px;" OnClick="btnSalvaAutovalutazione_Click" />
                </div>

                <div class="elem_block">
                    <Siar:Button ID="btnEliminaAutovalutazione" Modifica="true" runat="server" CausesValidation="false" Text="Elimina autovalutazione" Style="width: 170px;" OnClick="btnEliminaAutovalutazione_Click" />
                </div>
                <br />
            </div>
        </div>
    </div>

    <uc2:ucSceltaChecklist ID="modaleSceltaChecklist" runat="server" />
</asp:Content>
