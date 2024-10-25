<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="RicercaRinunce.aspx.cs" Inherits="web.Private.Controlli.RicercaRinunce" %>
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

        function selezionaRinuncia(idRinuncia) {
            $('[id$=hdnIdRinuncia]').val($('[id$=hdnIdinuncia]').val() == idRinuncia ? '' : idRinuncia);
            $('[id$=btnVisualizzaRinuncia]').click();
        }

    </script>
    <div style="display: none">

        <asp:HiddenField ID="hdnIdRinuncia" runat="server" />
        <asp:Button ID="btnVisualizzaRinuncia" runat="server" OnClick="btnVisualizzaRinuncia_Click" CausesValidation="false" />

    </div>

    <div class="dBox">
        <div class="separatore">
            RICERCA RINUNCE
        </div>
        <br />
        <br />
        <div style="padding: 10px;">
            <asp:Label ID="lblNumRinunce" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgRinunce" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn DataField="IdRinuncia" HeaderText="Id Rinuncia">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id Progetto">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataRinuncia" HeaderText="Data Rinuncia">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdRinuncia" ButtonText="Visualizza elemento" JsFunction="selezionaRinuncia">
                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
            <br />
            <br />
        </div>
    </div>
</asp:Content>