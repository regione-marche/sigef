<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" 
    CodeBehind="RicercaRevoche.aspx.cs" Inherits="web.Private.Controlli.RicercaRevoche" %>

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

        function selezionaRevoca(idRevoca) {
            $('[id$=hdnIdRevoca]').val($('[id$=hdnIdRevoca]').val() == idRevoca ? '' : idRevoca);
            $('[id$=btnVisualizzaRevoca]').click();
        }

    </script>
    <div style="display: none">

        <asp:HiddenField ID="hdnIdRevoca" runat="server" />
        <asp:Button ID="btnVisualizzaRevoca" runat="server" OnClick="btnVisualizzaRevoca_Click" CausesValidation="false" />

    </div>

    <div class="dBox">
        <div class="separatore">
            RICERCA REVOCHE
        </div>
        <br />
        <br />
        <div style="padding: 10px;">
            <div class="elem_block">
                <Siar:Button ID="btnNuovaRevoca" runat="server" Width="200px" Text="Nuova Revoca"
                    OnClick="btnNuovaRevoca_Click" CausesValidation="false"></Siar:Button>
            </div>
            <br /><br />
            <div class="first_elem_block" style ="padding-left:20px;">
                ID Progetto:<br />
                <Siar:IntegerTextBox NoCurrency="true"  ID="txtIdProgettoF" runat="server" Width="104px" />
 
                <Siar:Button ID="btnFiltra" runat="server" OnClick="btnFiltra_Click" Text="Filtra"
                    Width="80px" style="    margin-left: 15px;"/>
            </div>
            <br />
            <br />
            <asp:Label ID="lblNumRevoche" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGridAgid ID="dgRevoche" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="15">                                
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn DataField="IdRevoca" HeaderText="Id Revoca">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id Progetto">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdImpresa" HeaderText="Beneficiario">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdRevoca" ButtonText="Visualizza elemento" JsFunction="selezionaRevoca">
                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
</asp:Content>
