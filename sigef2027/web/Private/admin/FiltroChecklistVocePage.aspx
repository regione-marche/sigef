<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" Inherits="web.Private.admin.FiltroChecklistVocePage" CodeBehind="FiltroChecklistVocePage.aspx.cs" %>

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

</script>

    <div style="display: none">
    </div>

    <div class="row bd-form" id="divFiltroChecklistVoce" runat="server">
        <h3 class="pb-5 mt-5">Filtro per checklist e voci
        </h3>

        <div class="col-sm-2 form-group">
            <Siar:TextBox  Label="Id:" ID="txtIdFiltro" Obbligatorio="true" NomeCampo="Id filtro" runat="server" />
        </div>
        <div class="col-sm-8 form-group">
            <Siar:TextBox  Label="Descrizione:" ID="txtDescrizione" Obbligatorio="true" NomeCampo="Descrizione" runat="server" />
        </div>
        <div class="col-sm-2 form-group">
            <Siar:IntegerTextBox Label="Ordine:" ID="txtOrdine" Obbligatorio="true" NomeCampo="Ordine" runat="server" />
        </div>

        <div class="col-sm-12">
            <Siar:Button ID="btnSalvaFiltro" runat="server" OnClick="btnSalvaFiltro_Click" Text="Salva filtro" />

            <Siar:Button ID="btnEliminaFiltro" runat="server" OnClick="btnEliminaFiltro_Click" Text="Elimina filtro" />

            <input type="button" class="btn btn-secondary py-1" value="Indietro" onclick="history.back();" />
        </div>
    </div>
</asp:Content>
