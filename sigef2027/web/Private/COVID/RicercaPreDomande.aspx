<%@ Page Title="RicercaPreDomande" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="RicercaPreDomande.aspx.cs" Inherits="web.Private.COVID.RicercaPreDomande" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <style type="text/css">
        .hide {
            display:none;
        }

        h1 {
            display: block;
            font-size: 2em;
            margin-top: 0.67em;
            margin-bottom: 0.67em;
            margin-left: 10px;
            margin-right: 0;
            font-weight: bold;
        }

        .first_elem_block {
            width: 200px;
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {
            width: 200px;
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
    </style>

    <script type="text/javascript">
        function VaiAnagrafica(id) {
            $('[id$=hdnIdPreDomanda]').val(id);
            $('[id$=btnAnagrafica]').click();
        }

        function VaiDichiarazioniRequisiti(id) {
            $('[id$=hdnIdPreDomanda]').val(id);
            $('[id$=btnDichiarazioniRequisiti]').click();
        }

        function VaiPianoInvestimenti(id) {
            $('[id$=hdnIdPreDomanda]').val(id);
            $('[id$=btnPianoInvestimenti]').click();
        }
    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdPreDomanda" runat="server" />
        <asp:Button ID="btnAnagrafica" runat="server" OnClick="btnAnagrafica_Click" />
        <asp:Button ID="btnDichiarazioniRequisiti" runat="server" OnClick="btnDichiarazioniRequisiti_Click" />
        <asp:Button ID="btnPianoInvestimenti" runat="server" OnClick="btnPianoInvestimenti_Click" />
    </div>

    <div style="text-align: center;">
        <h1>Ricerca Domande</h1>
    </div>

    <div class="dBox" id="divRicercaPreDomande" runat="server">

        <%--<div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(6); return false;">
            <img id="imgIstruttoriaDomandaAiuto" runat="server" style="width: 23px; height: 23px;" />
            Domande di aiuto da istruire:
        </div>--%>

        <div id="divMostraRicercaPreDomande" style="padding: 15px;">
            <div id="divRicercaRicercaPreDomande" runat="server" class="box_ricerca">
                <div class="paragrafo_light">Dati domanda</div>
                <br />
                <div class="first_elem_block">
                    <b>Id Domanda:</b>
                    <br />
                    <asp:TextBox CssClass="rounded" ID="txtIdPreDomanda" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <br />

                <div class="paragrafo_light">Dati impresa</div>
                <br />
                <div class="first_elem_block">
                    <b>Ragione Sociale impresa:</b>
                    <br />
                    <asp:TextBox CssClass="rounded" ID="txtRagioneSocialeImpresa" runat="server" Width="100%" />
                </div>

                <div class="elem_block">
                    <b>P.IVA:</b>
                    <br />
                    <asp:TextBox CssClass="rounded" ID="txtPivaImpresa" runat="server" Width="100%" />
                </div>

                <div class="elem_block">
                    <b>Codice Fiscale:</b>
                    <br />
                    <asp:TextBox CssClass="rounded" ID="txtCfImpresa" runat="server" Width="100%" />
                </div>
                <br />

                <div class="paragrafo_light">Dati bando</div>
                <br />
                <div class="first_elem_block">
                    <b>Id Bando:</b>
                    <br />
                    <asp:TextBox CssClass="rounded" ID="txtIdBando" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>

                <div class="elem_block">
                    <b>Descrizione Bando:</b>
                    <br />
                    <asp:TextBox CssClass="rounded" ID="txtDescrizioneBando" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <br />

                <div class="first_elem_block">
                    <br />
                    <Siar:Button ID="btnRicercaPreDomande" runat="server" Text="Cerca" OnClick="btnRicercaPreDomande_Click" />
                </div>
            </div>
            <br />

            <Siar:DataGrid ID="dgPreDomande" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn DataField="Id" HeaderText="ID">
                        <ItemStyle HorizontalAlign="center" Font-Bold="true" Width="40px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Impresa beneficiaria">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Bando">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Definitiva">
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:BoundColumn>
                    <%--<Siar:JsButtonColumn Arguments="Id" ButtonType="TextButton" ButtonText="Anagrafica" HeaderText="Vai a" JsFunction="VaiAnagrafica" >
                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </Siar:JsButtonColumn>
                    <Siar:JsButtonColumn Arguments="Id" ButtonType="TextButton" ButtonText="Dichiarazione/Requisiti" HeaderText="Vai a" JsFunction="VaiDichiarazioniRequisiti">
                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </Siar:JsButtonColumn>
                    <Siar:JsButtonColumn Arguments="Id" ButtonType="TextButton" ButtonText="Piano Investimenti" HeaderText="Vai a" JsFunction="VaiPianoInvestimenti">
                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </Siar:JsButtonColumn>--%>
                    <Siar:JsButtonColumn Arguments="Id" ButtonType="ImageButton" ButtonImage="/codicefiscale.gif" ButtonText="Anagrafica" HeaderText="Vai a" JsFunction="VaiAnagrafica">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumn>
                    <Siar:JsButtonColumn Arguments="Id" ButtonType="ImageButton" ButtonImage="/soggetto.ico" ButtonText="Dichiarazione/Requisiti" HeaderText="Vai a" JsFunction="VaiDichiarazioniRequisiti">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumn>
                    <Siar:JsButtonColumn Arguments="Id" ButtonType="ImageButton" ButtonImage="/euro.gif" ButtonText="Piano Investimenti" HeaderText="Vai a" JsFunction="VaiPianoInvestimenti">
                        <HeaderStyle CssClass="hide" />
                        <ItemStyle HorizontalAlign="Center" CssClass="hide" />
                        <FooterStyle CssClass="hide" />
                    </Siar:JsButtonColumn>
                    <Siar:JsButtonColumn Arguments="IdFileDomanda" ButtonType="ImageButton" ButtonImage="/print_ico.gif" ButtonText="Visualizza file" JsFunction="SNCUFVisualizzaFile" HeaderText="File">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

</asp:Content>