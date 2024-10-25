<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" Inherits="web.Private.admin.RicercaFiltroChecklistVoce" CodeBehind="RicercaFiltroChecklistVoce.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <style type="text/css">
        .first_elem_block {
            /*width: 200px;*/
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-left: 20px;
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

        label {
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

        function selezionaFiltro(idFiltro) {
            $('[id$=hdnIdFiltro]').val($('[id$=hdnIdFiltro]').val() == idFiltro ? '' : idFiltro);
            $('[id$=btnSelezionaFiltro]').click();
        }

    </script>

    <div style="display: none">

        <asp:HiddenField ID="hdnIdFiltro" runat="server" />
        <asp:Button ID="btnSelezionaFiltro" runat="server" CausesValidation="False" OnClick="btnSelezionaFiltro_Click" />

    </div>

    <div class="row">
        <div class="col-sm-12">
            <Siar:Button ID="btnInserisciFiltro" runat="server" Text="Inserisci nuovo filtro" OnClick="btnInserisciFiltro_Click" />
        </div>
    </div>
    <div class="row" id="divElencoFiltri" runat="server">
        <h3 class="pb-5 mt-5">Elenco filtri per checklist e voci: 
        </h3>

        <div id="divMostraNascondiElencoFiltri" runat="server" class="col-sm-12">
            <p>
                <asp:Label ID="lblNumFiltri" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            </p>
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgFiltri" runat="server" AutoGenerateColumns="false">                
                <Columns>
                    <asp:BoundColumn DataField="IdFiltro" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                        <ItemStyle Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Ordine" HeaderText="Ordine">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumnAgid Arguments="IdFiltro" ButtonText="Visualizza filtro" JsFunction="selezionaFiltro">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
            <br />
        </div>
    </div>
</asp:Content>
