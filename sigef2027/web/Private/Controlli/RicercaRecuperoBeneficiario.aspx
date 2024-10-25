<%@ Page Title="" Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="RicercaRecuperoBeneficiario.aspx.cs" Inherits="web.Private.Controlli.RicercaRecuperoBeneficiario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <style type="text/css">

        h1 {
            display: block;
            font-size: 22px;/*font-size: 2em;*/
            margin-top: 10px;/*margin-top: 0.67em;*/
            margin-bottom: 10px;/*margin-bottom: 0.67em;*/
            margin-left: 10px;
            margin-right: 0;
            font-weight: bold;
        }

        .first_elem_block {
            /*width: 250px;*/
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {
            /*width: 250px;*/
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

        .nascondi {
            display: none;
        }

    </style>
    <script type="text/javascript">

        $('html').bind('keypress', function (e) {
            if (e.keyCode == 13) {
                return false;
            }
        });

        function selezionaRecupero(idRecupero) {
            $('[id$=hdnIdRecupero]').val($('[id$=hdnIdRecupero]').val() == idRecupero ? '' : idRecupero);
            $('[id$=btnVisualizzaRecupero]').click();
        }

    </script>
    <div style="display: none">

        <asp:HiddenField ID="hdnIdRecupero" runat="server" />
        <asp:Button ID="btnVisualizzaRecupero" runat="server" OnClick="btnVisualizzaRecupero_Click" CausesValidation="false" />

    </div>

    <div class="dBox">
        <div class="separatore">
            RICERCA RECUPERI PRESSO BENEFICIARIO
        </div>
        <br />
        <br />
        <div style="padding: 10px;">
            <div class="elem_block">
                <Siar:Button ID="btnNuovoRecupero" runat="server" Width="200px" Text="Nuova Recupero"
                    OnClick="btnNuovoRecupero_Click" CausesValidation="false"></Siar:Button>
            </div>
            <br />
            <br />
            <asp:Label ID="lblNumRecuperi" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGridAgid ID="dgRecuperi" runat="server" AutoGenerateColumns="False"  CssClass="table table-striped" PageSize="10">                                
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn DataField="IdRecuperoBeneficiario" HeaderText="Id Recupero">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id Progetto">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdImpresa" HeaderText="Beneficiario">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="Definitivo" HeaderText="Definitivo" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </Siar:CheckColumn>
                    <Siar:JsButtonColumn Arguments="IdRecuperoBeneficiario" ButtonText="Visualizza elemento" JsFunction="selezionaRecupero">
                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
</asp:Content>
