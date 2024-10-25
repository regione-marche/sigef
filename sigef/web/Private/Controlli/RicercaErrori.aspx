<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" Inherits="web.Private.Controlli.RicercaErrori" CodeBehind="RicercaErrori.aspx.cs" %>

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

    </style>

    <script type="text/javascript">

        function MostraNascondiDiv(id) {
            var div;
            var img;
            switch (id) {
                case 0:
                    div = $('[id$=divMostraNascondiInserisciErrore]');
                    img = $('[id$=imgMostraInserisciErrore]')[0];
                    break;
                case 1:
                    div = $('[id$=divMostraNascondiElencoErrori]');
                    img = $('[id$=imgMostraElencoErrori]')[0];
                    break;
            }

            if (img.style.transform == "")
                img.style.transform = "rotate(180deg)";
            else
                img.style.transform = "";

            if (div[0].style.display === "none") {
                div.show("fast");
            } else {
                div.hide("fast");
            }
        }

        function selezionaErrore(idErrore) {
            $('[id$=hdnIdErrore]').val($('[id$=hdnIdErrore]').val() == idErrore ? '' : idErrore);
            $('[id$=btnSelezionaErrore]').click();
        }

        function FilterRicercaErrore() {
            var txtIdBando = $('[id$=txtRicercaIdBando]').val();

			var txtIdProgetto = $('[id$=txtRicercaIdProgetto]').val();
            var lstStatoProgetto = $('[id$=lstRicercaStatoProgetto]')[0];
            var txtStatoProgetto = lstStatoProgetto.options[lstStatoProgetto.selectedIndex].text.toUpperCase();

            var txtIdErrore = $('[id$=txtRicercaIdErrore]').val(); 
            var lstAzione = $('[id$=lstRicercaAzione]')[0];
            var txtAzione = lstAzione.options[lstAzione.selectedIndex].text;

            var tblGrid = $('[id$=dgErrori]')[0];

            var rows = tblGrid.rows;
            var i = 0, row, cell, count = 0;
            for (i = 2; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                dgIdBando = row.cells[1].innerHTML;
                dgIdProgetto = row.cells[3].innerHTML;
                dgStatoProgetto = row.cells[4].innerHTML.toUpperCase();
                dgIdErrore = row.cells[5].innerHTML;
                dgAzione = row.cells[13].innerHTML;

                if ((txtIdBando == ""
                        || (txtIdBando != "" && dgIdBando == txtIdBando))
                    && (txtIdProgetto == ""
                        || (txtIdProgetto != "" && dgIdProgetto == txtIdProgetto))
                    && (txtStatoProgetto == ""
                        || (txtStatoProgetto != "" && dgStatoProgetto == txtStatoProgetto))
                    && (txtIdErrore == ""
                        || (txtIdErrore != "" && dgIdErrore == txtIdErrore))
                    && (txtAzione == ""
                        || (txtAzione != "" && dgAzione == txtAzione))
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
                $('[id$=lblNumErrori]')[0].innerHTML = "Visualizzate " + count + " righe";
                $('[id$=dgErrori]').show("fast");
            } else {
                $('[id$=lblNumErrori]')[0].innerHTML = "Nessun errore trovato";
                $('[id$=dgErrori]').hide("fast");
            }
            return false;
        }

    </script>

    <div style="display: none">

        <asp:HiddenField ID="hdnIdErrore" runat="server" />
        <asp:Button ID="btnSelezionaErrore" runat="server" CausesValidation="False" OnClick="btnSelezionaErrore_Click" />

    </div>

    <div class="dBox" id="divInserisciErrore" runat="server">
        <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDiv(0);">
            <img id="imgMostraInserisciErrore" runat="server" style="width: 23px; height: 23px;" />
            Inserisci errore: 
        </div>

        <div id="divMostraNascondiInserisciErrore" runat="server" style="padding: 10px;">
            <div class="first_elem_block">
                <label><b>Id domanda di aiuto:</b></label>
                <div class="value">
                    <asp:TextBox ID="txtIdProgettoInserisciErrore" runat="server" Width="150px" />
                </div>
            </div>
            <br />
            <br />

            <Siar:Button ID="btnInserisciErrore" runat="server" Text="Inserisci errore" OnClick="btnInserisciErrore_Click" />


        </div>
    </div>
    <br />

    <div class="dBox" id="divElencoErrori" runat="server">
        <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDiv(1);">
            <img id="imgMostraElencoErrori" runat="server" style="width: 23px; height: 23px;" />
            Ricerca errori: 
        </div>

        <div id="divMostraNascondiElencoErrori" runat="server" style="padding: 10px;">
            <div id="divRicercaErrori" runat="server" class="box_ricerca">
                <div class="paragrafo_light">Dati bando</div>
                <br />
                <div class="first_elem_block">
                    <label><b>Id bando:</b></label>
                    <div class="value">
                        <asp:TextBox ID="txtRicercaIdBando" runat="server" Width="150px" />
                    </div>
                </div>
                <br />

                <div class="paragrafo_light">Dati domanda</div>
                <br />
                <div class="first_elem_block">
                    <label><b>Id domanda di aiuto:</b></label>
                    <div class="value">
                        <asp:TextBox ID="txtRicercaIdProgetto" runat="server" Width="150px" />
                    </div>
                </div>

                <div class="elem_block">
                    <label><b>Stato domanda di aiuto:</b></label>
                    <div class="value">
                        <Siar:ComboBase ID="lstRicercaStatoProgetto" runat="server" Width="150px" Height="21px"></Siar:ComboBase>
                    </div>
                </div>
                <br />

                <div class="paragrafo_light">Dati errore</div>
                <br />
                <div class="first_elem_block">
                    <label><b>Id errore:</b></label>
                    <div class="value">
                        <asp:TextBox ID="txtRicercaIdErrore" runat="server" Width="150px" />
                    </div>
                </div>

                <div class="elem_block">
                    <label><b>Azione ai fini della certificazione:</b></label>
                    <div class="value">
                        <Siar:ComboBase ID="lstRicercaAzione" runat="server" Width="150px" Height="21px"></Siar:ComboBase>
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <button id="btnFiltraRicercaErrori" runat="server" class="Button" style="width: 110px; height: 30px; text-align: center;" onclick="javascript: FilterRicercaErrore(); return false;" causesvalidation="false">
                        <img id="imgSearchFiltraRicercaErrore" runat="server" />Filtra 
                    </button>
                </div>
            </div>
            <br />

            <asp:Label ID="lblNumErrori" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />

            <Siar:DataGrid ID="dgErrori" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn DataField="IdAsse" HeaderText="Asse">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdBando" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneBando" HeaderText="Descrizione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="StatoProgetto" HeaderText="Stato">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdErrore" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataRilevazione" HeaderText="Data rilevazione">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="SoggettoRilevazione" HeaderText="Soggetto rilevazione">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="SpesaAmmessaErrore" HeaderText="Spesa ammessa" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ContributoPubblicoErrore" HeaderText="Contributo pubblico" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="Certificato" HeaderText="Certificato" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </Siar:CheckColumn>
                    <Siar:CheckColumn DataField="DaRecuperare" HeaderText="Recuperare c/o beneficiario" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </Siar:CheckColumn>
                    <Siar:CheckColumn DataField="Recuperato" HeaderText="Recuperato c/o beneficiario" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </Siar:CheckColumn>
                    <asp:BoundColumn DataField="AzioneCertificazione" HeaderText="Azione ai fini certificazione"></asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdErrore" ButtonText="Visualizza elemento" JsFunction="selezionaErrore">
                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
            <br />

        </div>
    </div>

</asp:Content>
