<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" Inherits="web.Private.Controlli.RicercaIrregolaritaErroriRinunce" CodeBehind="RicercaIrregolaritaErroriRinunce.aspx.cs" %>

<%@ Register Src="~/CONTROLS/ucGestioneLavori.ascx" TagName="GestioneLavori" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

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

        function selezionaIrregolarita(idIrregolarita) {
            $('[id$=hdnIdIrregolarita]').val($('[id$=hdnIdIrregolarita]').val() == idIrregolarita ? '' : idIrregolarita);
            $('[id$=btnVisualizzaIrregolarita]').click();
        }

        function FilterRicercaIrregolarita() {
            var txtIdBando = $('[id$=txtRicercaIdBando]').val();
            var txtIdProgetto = $('[id$=txtRicercaIdProgetto]').val();
            var lstStatoProgetto = $('[id$=lstRicercaStatoProgetto]')[0];
            var txtStatoProgetto = lstStatoProgetto.options[lstStatoProgetto.selectedIndex].text;
            var lstImpresaProgetto = $('[id$=lstRicercaImpresaProgetto]')[0];
            var txtImpresaProgetto = lstImpresaProgetto.options[lstImpresaProgetto.selectedIndex].text;
            var txtIdIrregolarita = $('[id$=txtRicercaIdIrregolarita]').val();
            //var lstTipologiaIrregolarita = $('[id$=lstRicercaTipologiaIrregolarita]')[0];
            //alert("8");
            //var txtTipologiaIrregolarita = lstTipologiaIrregolarita.options[lstTipologiaIrregolarita.selectedIndex].text;
            //alert("9");
            var lstSegnalazioneOlaf = $('[id$=lstRicercaSegnalazioneOlaf]')[0];
            var txtSegnalazioneOlaf = lstSegnalazioneOlaf.options[lstSegnalazioneOlaf.selectedIndex].text;
            var tblGrid = $('[id$=dgIrregolarita]')[0];
            var rows = tblGrid.rows;
            var i = 0, row, cell, count = 0;
            for (i = 1; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgBando = row.cells[0].innerHTML;
                dgProgetto = row.cells[1].innerHTML;
                dgIdIrregolarita = row.cells[2].innerHTML;
                dgTipologiaIrregolarita = row.cells[3].innerHTML;
                dgSegnalazioneOlaf = row.cells[8].innerHTML;

                if ((txtIdBando == ""
                        || (txtIdBando != "" && dgBando.indexOf("Id: <b>" + txtIdBando) >= 0))
                    && (txtIdProgetto == ""
                        || (txtIdProgetto != "" && dgProgetto.indexOf("Id: <b>" + txtIdProgetto) >= 0))
                    && (txtStatoProgetto == ""
                        || (txtStatoProgetto != "" && dgProgetto.indexOf("Stato: <b>" + txtStatoProgetto) >= 0))
                    && (txtImpresaProgetto == ""
                        || (txtImpresaProgetto != "" && dgProgetto.indexOf("Impresa: <b>" + txtImpresaProgetto) >= 0))
                    && (txtIdIrregolarita == ""
                        || (txtIdIrregolarita != "" && dgIdIrregolarita == txtIdIrregolarita))
                    //&& (txtTipologiaIrregolarita == ""
                    //    || (txtTipologiaIrregolarita != "" && dgTipologiaIrregolarita == txtTipologiaIrregolarita))
                    && (txtSegnalazioneOlaf == ""
                        || (txtSegnalazioneOlaf == "Sì" && dgSegnalazioneOlaf.indexOf("checked") > 0)
                        || (txtSegnalazioneOlaf == "No" && dgSegnalazioneOlaf.indexOf("checked") == -1))
                ) {
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
                $('[id$=lblNumIrregolarita]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgIrregolarita]').show("fast");
            } else {
                $('[id$=lblNumIrregolarita]')[0].innerHTML = "Nessuna spesa trovata";
                $('[id$=dgIrregolarita]').hide("fast");
            }
            return false;
        }

        function estraiInXls() {
            var parametri = "";
            SNCVisualizzaReport('rptIrregolarita', 2, parametri);
        }

    </script>

    <div style="display: none">

        <asp:HiddenField ID="hdnIdIrregolarita" runat="server" />
        <asp:Button ID="btnVisualizzaIrregolarita" runat="server" OnClick="btnVisualizzaIrregolarita_Click" CausesValidation="false" />

    </div>

    <div class="dBox">
        <div class="separatore">
            RICERCA IRREGOLARITA'
        </div>

        <div style="padding:10px;">
            <div id="divRicercaSpese" runat="server" class="box_ricerca">
                <div class="paragrafo_light">Dati bando</div><br />
                <div class="first_elem_block">
                    <label><b>Id bando:</b></label>
                    <div class="value">
                        <asp:TextBox ID="txtRicercaIdBando" runat="server" Width="100%" />
                    </div>
                </div>
                <br />

                <div class="paragrafo_light">Dati domanda di aiuto</div><br />
                <div class="first_elem_block">
                    <label><b>Id domanda:</b></label>
                    <div class="value">
                        <asp:TextBox ID="txtRicercaIdProgetto" runat="server" Width="100%" />
                    </div>
                </div>

                <div class="elem_block">
                    <label><b>Stato:</b></label>
                    <div class="value">
                        <Siar:ComboBase ID="lstRicercaStatoProgetto" runat="server" Width="100%" Height="21px"></Siar:ComboBase>
                    </div>
                </div>

                <div class="elem_block">
                    <label><b>Impresa:</b></label>
                    <div class="value">
                        <Siar:ComboBase ID="lstRicercaImpresaProgetto" runat="server" Width="100%" Height="21px"></Siar:ComboBase>
                    </div>
                </div>
                <br />

                <div class="paragrafo_light">Dati specifici</div><br />
                <div class="first_elem_block">
                    <label><b>Id:</b></label>
                    <div class="value">
                        <asp:TextBox ID="txtRicercaIdIrregolarita" runat="server" Width="100%" />
                    </div>
                </div>

                <div class="elem_block">
                    <label><b>Segnalazione OLAF:</b></label>
                    <div class="value">
                        <Siar:ComboBase ID="lstRicercaSegnalazioneOlaf" runat="server" Width="100%" Height="21px"></Siar:ComboBase>
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <button id="btnFiltraRicercaIrregolarita" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: return FilterRicercaIrregolarita();" causesvalidation="false">
                        <img id="imgSearchFiltraRicercaIrregolarita" runat="server" />Filtra 
                    </button>
                </div>

                <div class="elem_block">
                    <input type="button" class="Button" value="Estrai in xls" style="width: 110px; height: 30px;" onclick="return estraiInXls();" />
                </div>

            </div>
            <br />

            <asp:Label ID="lblNumIrregolarita" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgIrregolarita" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Dati bando">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Dati domanda di aiuto">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdIrregolarita" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TipoIrregolarita" HeaderText="Tipologia">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneControlloOrigine" HeaderText="Controllo d'origine">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataCostatazioneAmministrativa" HeaderText="Data costatazione amministrativa">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="SospettoFrode" HeaderText="Sospetto frode" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </Siar:CheckColumn>
                    <Siar:CheckColumn DataField="ImportoIrregolareDaRecuperare" HeaderText="Importo da recuperare" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </Siar:CheckColumn>
                    <Siar:CheckColumn DataField="SegnalazioneOlaf" HeaderText="Da segnalare OLAF" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </Siar:CheckColumn>
                    <Siar:JsButtonColumn Arguments="IdIrregolarita" ButtonText="Visualizza elemento" JsFunction="selezionaIrregolarita">
                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
            <br />
        </div>
    </div>
    
</asp:Content>
