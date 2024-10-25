<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="Ricerca.aspx.cs" Inherits="web.Private.ModificaDati.Ricerca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <style type="text/css">
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
    </style>

    <script type="text/javascript">

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function FiltraDomande() {
            var txtIdBando = $('[id$=txtIdBando]').val();
            var lstStatoBando = $('[id$=lstStatoBando]')[0];
            var txtStatoBando = lstStatoBando.options[lstStatoBando.selectedIndex].text.toUpperCase();
            var lstEnteBando = $('[id$=lstEntiBando]')[0];
            var txtEnteBando = lstEnteBando.options[lstEnteBando.selectedIndex].text.toUpperCase();

            var txtIdProgetto = $('[id$=txtIdProgetto]').val();
            var lstStatoProgetto = $('[id$=lstStatoProgetto]')[0];
            var txtStatoProgetto = lstStatoProgetto.options[lstStatoProgetto.selectedIndex].text.toUpperCase();
            var lstImpresaProgetto = $('[id$=lstImpresa]')[0];
            var txtImpresaProgetto = lstImpresaProgetto.options[lstImpresaProgetto.selectedIndex].text.toUpperCase();
            var lstIstruttoreProgetto = $('[id$=lstIstruttore]')[0];
            var txtIstruttoreProgetto = lstIstruttoreProgetto.options[lstIstruttoreProgetto.selectedIndex].text.toUpperCase();

            var tblGrid = $('[id$=dgDomande]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell; count = 0;
            for (i = 2; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgIdBando = row.cells[1].innerHTML.toUpperCase();
                dgEnteBando = row.cells[2].innerHTML.toUpperCase();
                dgStatoBando = row.cells[4].innerHTML.toUpperCase();

                dgIdProgetto = row.cells[6].innerHTML.toUpperCase();
                dgStatoProgetto = row.cells[7].innerHTML.toUpperCase();
                dgImpresaProgetto = row.cells[8].innerHTML.toUpperCase();
                dgistruttoreProgetto = row.cells[9].innerHTML.toUpperCase();

                if ((txtIdBando == ""
                        || (txtIdBando != "" && dgIdBando == txtIdBando))
                    && (txtEnteBando == ""
                        || (txtEnteBando != "" && dgEnteBando == txtEnteBando))
                    && (txtStatoBando == ""
                        || (txtStatoBando != "" && dgStatoBando == txtStatoBando))

                    && (txtIdProgetto == ""
                        || (txtIdProgetto != "" && dgIdProgetto == txtIdProgetto))
                    && (txtStatoProgetto == ""
                        || (txtStatoProgetto != "" && dgStatoProgetto == txtStatoProgetto))
                    && (txtImpresaProgetto == ""
                        || (txtImpresaProgetto != "" && dgImpresaProgetto == txtImpresaProgetto))
                    && (txtIstruttoreProgetto == ""
                        || (txtIstruttoreProgetto != "" && dgistruttoreProgetto == txtIstruttoreProgetto))) {
                    found = true;
                }

                if (!found) {
                    row.style['display'] = 'none';
                }
                else {
                    row.style.display = '';
                    count++;
                }
            }
            if (count > 0) {
                $('[id$=lblDomande]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgDomande]').show("fast");
            } else {
                $('[id$=lblDomande]')[0].innerHTML = "Nessuna domanda trovata";
                $('[id$=dgDomande]').hide("fast");
            }
            return false;
        }

        function selezionaDettaglioProgetto(idProgetto) {
            $('[id$=hdnIdProgetto]').val($('[id$=hdnIdProgetto]').val() == idProgetto ? '' : idProgetto);
            $('[id$=btnPost]').click();
        }

    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdProgetto" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" />
    </div>

    <div class="dBox">

        <div class="separatore" style="padding-bottom: 3px;">
            Ricerca generale domande di aiuto
        </div>

        <div id="divDomandaAiuto" style="padding: 15px;">
            <div id="divRicercaGeneraleDomandaAiuto" runat="server" class="box_ricerca">
                <div class="paragrafo_light">Dati bando</div>
                <br />
                <div class="first_elem_block">
                    <b>Id Bando:</b>
                    <br />
                    <asp:TextBox ID="txtIdBando" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <div id="divEnte" runat="server" class="elem_block">
                    <b>Ente emettitore:</b>
                    <br />
                    <Siar:ComboEnte ID="lstEntiBando" runat="server" Width="180px" AbilitaModifica="false"></Siar:ComboEnte>
                </div>
                <div id="divStatoBando" runat="server" class="elem_block">
                    <b>Stato bando:</b>
                    <br />
                    <Siar:ComboBase ID="lstStatoBando" runat="server"></Siar:ComboBase>
                </div>
                <br />
                <br />

                <div class="paragrafo_light">Dati domanda di aiuto</div>
                <br />
                <div class="first_elem_block">
                    <b>Id Domanda:</b>
                    <br />
                    <asp:TextBox ID="txtIdProgetto" runat="server" Width="100%" onkeypress="return isNumberKey(event)" />
                </div>
                <div id="divStatoProgetto" runat="server" class="elem_block">
                    <b>Stato Domanda:</b>
                    <br />
                    <Siar:ComboStatoProgetto ID="lstStatoProgetto" runat="server">
                    </Siar:ComboStatoProgetto>
                </div>
                <div id="divImpresa" runat="server" class="elem_block">
                    <b>Impresa: </b>
                    <br />
                    <Siar:ComboBase ID="lstImpresa" runat="server"></Siar:ComboBase>
                </div>
                <div id="divIstruttore" runat="server" class="elem_block">
                    <b>Istruttore assegnato:</b>
                    <br />
                    <Siar:ComboBase ID="lstIstruttore" runat="server"></Siar:ComboBase>
                </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <br />
                    <button id="btnFiltraDomande" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FiltraDomande(); return false;" causesvalidation="false">
                        <img id="imgSearchFilterDomande" runat="server" />Filtra 
                    </button>
                    <Siar:Button ID="btnCercaDomande" runat="server" OnClick="btnCercaDomande_Click" Text="Cerca" Width="100px" />
                </div>
            </div>
            <br />

            <asp:Label ID="lblDomande" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgDomande" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn HeaderText="Info">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdBando" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="EnteBando" HeaderText="Ente">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneBando" HeaderText="Descrizione">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="StatoBando" HeaderText="Stato">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataScadenzaBando" HeaderText="Data scadenza">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="StatoProgetto" HeaderText="Stato">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Impresa" HeaderText="Impresa">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IstruttoreProgetto" HeaderText="Istruttore">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdProgetto" ButtonText="Mostra dettaglio" JsFunction="selezionaDettaglioProgetto" >
                        <ItemStyle HorizontalAlign="Center" Width="160px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
    </div>

</asp:Content>
