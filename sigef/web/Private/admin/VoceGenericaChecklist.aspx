<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" Inherits="web.Private.admin.VoceGenericaChecklist" CodeBehind="VoceGenericaChecklist.aspx.cs" %>

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

    <div class="dBox" id="divVoceGenerica" runat="server">
        <div class="separatore">
            Voce generica
        </div>

        <div style="padding: 10px;">
            <div class="first_elem_block">
                <div class="label"><b>Descrizione:</b></div>
                <div class="value">
                    <Siar:TextArea ID="txtDescrizioneVoceGenerica" runat="server" Width="450px" Rows="4" ExpandableRows="4"
                        MaxLength="8000" NomeCampo="Descrizione" Obbligatorio="true"></Siar:TextArea>
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label"><b>Filtro:</b></div>
                <div class="value">
                    <Siar:ComboFiltroChecklistVoce ID="lstFiltro" runat="server" Obbligatorio="true" NomeCampo="Filtro"></Siar:ComboFiltroChecklistVoce>
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Titolo:</div>
                <div class="value">
                    <asp:CheckBox ID="chkTitolo" runat="server" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Commento voce:</div>
                <div class="value">
                    <Siar:TextArea ID="txtCommentoVoceGenerica" runat="server" Width="450px" Rows="4" ExpandableRows="4"
                        MaxLength="8000" NomeCampo="Commento"></Siar:TextArea>
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Valore minimo:</div>
                <div class="value">
                    <Siar:TextBox ID="txtValoreMinimo" runat="server" Width="200px" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Valore massimo:</div>
                <div class="value">
                    <Siar:TextBox ID="txtValoreMassimo" runat="server" Width="200px" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Calcolo automatico:</div>
                <div class="value">
                    <asp:CheckBox ID="chkAutomatico" runat="server" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Query SQL calcolo automatico:</div>
                <div class="value">
                    <Siar:TextArea ID="txtQuerySql" runat="server" Width="450px" Rows="4" ExpandableRows="2"
                        MaxLength="8000"></Siar:TextArea>
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Query SQL post:</div>
                <div class="value">
                    <Siar:TextArea ID="txtQuerySqlPost" runat="server" Width="450px" Rows="4" ExpandableRows="2"
                        MaxLength="8000"></Siar:TextArea>
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Nome metodo:</div>
                <div class="value">
                    <Siar:TextBox ID="txtNomeMetodo" runat="server" Width="450px" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <div class="label">Url:</div>
                <div class="value">
                    <Siar:TextBox ID="txtUrl" runat="server" Width="450px" />
                </div>
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <Siar:Button ID="btnSalvaVoceGenerica" runat="server" OnClick="btnSalvaVoceGenerica_Click" Text="Salva voce" Width="110px" />
            </div>

            <div class="elem_block">
                <Siar:Button ID="btnEliminaVoceGenerica" runat="server" OnClick="btnEliminaVoceGenerica_Click" Text="Elimina voce" Width="110px" />
            </div>

            <div class="elem_block">
                <input type="button" class="Button" value="Indietro" style="width: 110px;" onclick="history.back();" />
            </div>
        </div>
    </div>

</asp:Content>
