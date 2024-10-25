<%@ Page Title="" Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="RicercaRinunce.aspx.cs" Inherits="web.Private.Controlli.RicercaRinunce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <style type="text/css">       

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
                    <Siar:JsButtonColumn Arguments="IdRinuncia" ButtonText="Visualizza elemento" JsFunction="selezionaRinuncia">

    </div> 
    <div class="row"> 
        <h3 class="mt-5 pb-5"> 
            Ricerca rinunce 
        </h3>        
        <div class="col-sm-12"> 
            <p> 
                <asp:Label ID="lblNumRinunce" runat="server" Text="" Font-Size="Smaller"></asp:Label> 
            </p>             
            <Siar:DataGridAgid ID="dgRinunce" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20"> 
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
                    <Siar:JsButtonColumnAgid Arguments="IdRinuncia" ButtonText="Visualizza elemento" JsFunction="selezionaRinuncia"> 
                        <ItemStyle HorizontalAlign="Center"/> 
                    </Siar:JsButtonColumnAgid> 
                </Columns> 
            </Siar:DataGridAgid>             
        </div> 
    </div> 
</asp:Content>