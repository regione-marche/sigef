<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" Inherits="web.Private.admin.RicercaAziendeAnagrafe" CodeBehind="RicercaAziendeAnagrafe.aspx.cs" %>

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
            min-width: 150px;
            max-width: 150px;
            width: 150px;
            text-align: right;
            vertical-align: middle;
        }

        .value {
            float: right;
            margin-left: 5px;
        }

        .nascondi {
            display: none;
        }

    </style>

    <script type="text/javascript">

        function ctrlCuaaDitta() {
            var text_box_cuaa = $('[id$=txtPivaInserimento]');
            var cuaa = $(text_box_cuaa).val().replace(/\s/g, '');

            if (cuaa != null && cuaa != "" && !ctrlCodiceFiscale(cuaa) && !ctrlPIVA(cuaa)) {
                alert('Attenzione! Il Codice Fiscale inserito per la ricerca della ditta non è valido.');
            }
        }

        function EliminaRicerca(id_ricerca) {
            var domanda = confirm("Sei sicuro di voler eliminare la ricerca?");
            if (domanda === true) {
                $('[id$=hdnIdRicercaEliminazione]').val($('[id$=hdnIdRicercaEliminazione]').val() == id_ricerca ? '' : id_ricerca);
                $('[id$=btnPostEliminaRicerca]').click();
            }
        }

        function ConfermaSvuotaElenco() {
            if (!confirm("Sei sicuro di voler svuotare l'elenco delle p.iva da controllare?"))
                return false;
        }

        function RicercaSingola(id_ricerca) {
            $('[id$=hdnIdRicercaSingola]').val(id_ricerca);
            $('[id$=btnPostRicercaSingola]').click();
        }
        
    </script>

    <div style="display: none">
        <Siar:Button ID="btnPostEliminaRicerca" runat="server" CausesValidation="false" OnClick="btnPostEliminaRicerca_Click" />
        <asp:HiddenField ID="hdnIdRicercaEliminazione" runat="server" />
        <Siar:Button ID="btnPostRicercaSingola" runat="server" CausesValidation="false" OnClick="btnPostRicercaSingola_Click" />
        <asp:HiddenField ID="hdnIdRicercaSingola" runat="server" />
    </div>

    <div id="divElencoRicerche" runat="server" class="dBox" style="margin-top: 30px;">

        <div class="separatore" style="cursor: pointer; padding-bottom: 3px;">
            Elenco ricerche aziende Anagrafe Tributaria
        </div>

        <div id="divMostraElencRicerche" style="margin: 15px;">

            <div class="first_elem_block">
                <div class="label">P.Iva o C.F. Azienza:</div>
                <div class="value">
                    <Siar:TextBox  ID="txtPivaInserimento" runat="server" Width="190px" />
                </div>
            </div>

            <div class="elem_block">
                <div class="value">
                     <Siar:Button ID="btnInserisciPiva" runat="server" Modifica="True"
                        OnClick="btnInserisciPiva_Click" Text="Inserisci P.Iva" Width="150px" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">CF richiesta:</div>
                <asp:RadioButtonList RepeatDirection="Horizontal" ID="rblCfRichiesta" runat="server">
                    <asp:ListItem Selected="True" Text="Web Config" Value="0" />
                    <asp:ListItem Text="Operatore" Value="1" />
                </asp:RadioButtonList>
            </div>

            <div class="elem_block">
                <div class="value">
                     <Siar:Button ID="btnControllaElenco" runat="server" Modifica="True"
                        OnClick="btnControllaElenco_Click" Text="Controlla elenco" Width="150px" />
                </div>
            </div>

            <div class="elem_block">
                <div class="value">
                     <Siar:Button ID="btnControllaElencoSenzaImpresa" runat="server" Modifica="True"
                        OnClick="btnControllaElencoSenzaImpresa_Click" Text="Controlla elenco senza impresa" Width="300px" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="value">
                     <Siar:Button ID="btnSvuotaElenco" runat="server" Modifica="True"
                        OnClick="btnSvuotaElenco_Click" Text="Svuota elenco" 
                        OnClientClick="return ConfermaSvuotaElenco();" Width="150px" />
                </div>
            </div>
            <br />
            <br />

            <asp:Label ID="lblNrRecordRicerche" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgElencoRicerche" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundColumn DataField="IdRicerca" HeaderText="Id Ricerca">
                        <ItemStyle Width="60px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PivaControllo" HeaderText="P.Iva Controllo"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IdImpresa" HeaderText="Impresa">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataUltimoControllo" HeaderText="Data ultimo controllo"></asp:BoundColumn>
                    <Siar:CheckColumn DataField="DaControllare" HeaderText="Da controllare" ReadOnly="true">
                        <ItemStyle Width="80px" />
                    </Siar:CheckColumn>
                    <asp:BoundColumn DataField="Esito" HeaderText="Esito"></asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdRicerca" HeaderText="Ricerca singola" ButtonType="ImageButton" ButtonImage="ifSearch24.png" JsFunction="RicercaSingola">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </Siar:JsButtonColumn>
                    <Siar:JsButtonColumn Arguments="IdRicerca" HeaderText="Elimina" ButtonType="ImageButton" ButtonImage="xdel.gif" JsFunction="EliminaRicerca">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
            <br />

        </div>

    </div>

</asp:Content>