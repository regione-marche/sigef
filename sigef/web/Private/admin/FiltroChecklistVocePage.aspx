<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" Inherits="web.Private.admin.FiltroChecklistVocePage" CodeBehind="FiltroChecklistVocePage.aspx.cs" %>

<asp:content id="Content1" contentplaceholderid="cphContenuto" runat="Server">

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

    </script>

    <div style="display: none">
    </div>

    <div class="dBox" id="divFiltroChecklistVoce" runat="server">
        <div class="separatore">
            Filtro per checklist e voci
        </div>

        <div style="padding: 10px;">
            <div class="first_elem_block">
                <div class="label"><b>Id:</b></div>
                <div class="value">
                    <Siar:TextBox ID="txtIdFiltro" Obbligatorio="true" NomeCampo="Id filtro" runat="server" Width="400px" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label"><b>Descrizione:</b></div>
                <div class="value">
                    <Siar:TextBox ID="txtDescrizione" Obbligatorio="true" NomeCampo="Descrizione" runat="server" Width="400px" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label"><b>Ordine:</b></div>
                <div class="value">
                    <Siar:IntegerTextBox ID="txtOrdine" Obbligatorio="true" NomeCampo="Ordine" runat="server" Width="100px" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <Siar:Button ID="btnSalvaFiltro" runat="server" OnClick="btnSalvaFiltro_Click" Text="Salva filtro" Width="110px" />
            </div>

            <div class="elem_block">
                <Siar:Button ID="btnEliminaFiltro" runat="server" OnClick="btnEliminaFiltro_Click" Text="Elimina filtro" Width="110px" />
            </div>

            <div class="elem_block">
                <input type="button" class="Button" value="Indietro" style="width: 110px;" onclick="history.back();" />
            </div>
        </div>
    </div>

</asp:content>