<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="ControlliStabilita.aspx.cs" Inherits="web.Private.Controlli.ControlliStabilita" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc2" %>

<asp:content id="Content1" contentplaceholderid="cphContenuto" runat="server">
    <style>
        .box_ricerca {
            background-color: #cfcfd6;
        }

        .paragrafo_light {
            border-bottom: solid 1px #084600;
            font-size: 14px;
        }

        .first_elem_block {
            padding: 7px;
        }

        #textarea {
            width: 99%;
            height: 100px;
            overflow-y: scroll;
            border: 1px solid #ccc;
            padding: 5px;
            background-color: #fff;
        }

        .tag {
            font-weight: bold;
            background: rgba(10,107,177, 0.9);
            color: #fff;
            padding: 3px;
            margin-right: 3px;
            margin-bottom: 3px;
            border-radius: 2px;
            display: inline-block;
        }

        .remove-tag {
            margin-left: 2px;
            cursor: pointer;
        }
    </style>
    <script type="text/javascript">

        var favorite = [];

        function addTag() {
            $.each($("input[name='chkAssocia']:checked"), function () {
                if (!favorite.includes($(this).val())) {
                    var nuovi = [];
                    favorite.push($(this).val());
                    nuovi.push($(this).val());
                    nuovi.forEach(addElementToDiv);
                    updateSelected();
                }
            });
        }

        function updateSelected() {
            $('[id$=hdnProgettiEstrazione]').val("");
            favorite.forEach(addElementToList);
            $('[id$=hdnProgettiEstrazione]').val($('[id$=hdnProgettiEstrazione]').val().substring(0, $('[id$=hdnProgettiEstrazione]').val().length - 1));
        }

        function removeTag(item) {
            const index = favorite.indexOf(item.toString());
            if (index > -1) {
                favorite.splice(index, 1);
                $("#textarea").text("");
                favorite.forEach(addElementToDiv);
                updateSelected();
            }
        }

        function addElementToDiv(item, index) {
            var company = $("input[type='checkbox'][value='" + item + "']").closest('td').siblings(".company").text();
            $("#textarea").append("<span class='tag'>" + item + " - " + company + "<b class='remove-tag' onclick='removeTag(" + item + ");'>✖</b><span>");
        }

        function addElementToList(item, index) {
            var hdn = $('[id$=hdnProgettiEstrazione]').val();
            if (hdn !== undefined)
                hdn = hdn.concat(favorite[index] + ";");
            else
                hdn = favorite[index] + ";";
            $('[id$=hdnProgettiEstrazione]').val(hdn);

        }

        function selezionaEstrazione(idComunicazione) { $('[id$=hdnIdEstrazione]').val(idComunicazione); swapTab(2); }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function selectAll() {
            var chk = $('[id$=chkSelectAll]')[0].checked;
            if (chk) {
                $('[id$=dgDomande] tr:visible td.chkSelect input[type=checkbox]').prop("checked", true);
                $('[id$=dgDomande] tr:hidden td.chkSelect input[type=checkbox]').prop("checked", false);
            }
            else {
                $('[id$=dgDomande] tr td.chkSelect input[type=checkbox]').prop("checked", false);
            }
        }

        function MostraNascondiDiv() {
            var div = $('[id$=boxFilter]');
            var img = $('[id$=imgFilter]')[0];

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

        function pulisciCampi() { $('[id$=hdnAllegatoSelezionato]').val(''); $('[id$=txtNADescrizioneBreve]').val(''); $('[id$=btnNuovoPost]').click(); /*debugger;SNCUFRimuoviFile('ctl00_cphContenuto_ufcNAAllegato');*/ }

        function FiltraRichieste() {
            $('[id$=chkSelectAll]').prop("checked", false);
            if ($('[id$=tbNuovaEstrazione]').is(':visible')) {
                selectAll();
                $("#textarea").text("");
                favorite.splice(0, favorite.length);
                var txtIdDomanda = $('[id$=txtIdProgettoRicercaRichiesteAtti]').val();               
                var tblGrid = $('[id$=dgDomande]')[0];

                var rows = tblGrid.rows;
                var i = 0, row, cell; count = 0;
                for (i = 1; i < rows.length; i++) {
                    row = rows[i];
                    var found = false;
                    dgIdDomanda = row.cells[0].innerHTML.toUpperCase();

                    if ((txtIdDomanda == "" || (txtIdDomanda != "" && dgIdDomanda == txtIdDomanda))) {
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
                    $('[id$=lblNrRecordProgetti]')[0].innerHTML = "Visualizzate " + count + " righe";
                    $('[id$=dgDomande]').show("fast");
                } else {
                    $('[id$=lblNrRecordProgetti]')[0].innerHTML = "Nessuna domanda trovata";
                    $('[id$=dgDomande]').hide("fast");
                }

                if ($('[id$=hdnIdEstrazione]').value != "") {
                    var res = $('[id$=hdnProgettiEstrazione]').val().split(";");
                    res.forEach(checkColumnsProgetti);
                    addTag();
                }

                return false;
            }
        }

        function checkColumnsProgetti(item, index) {
            var chks = document.querySelectorAll("input[type='checkbox'][value='" + item + "']");
            if ($(chks).is(':visible'))
                $(chks).prop('checked', true);
            else
                $(chks).prop('checked', false);
        }

        function ctrlSegnaturaEsterna(ev) {
            if ($('[id$=txtSegnatura]').val() == '') { alert('Attenzione! Digitare la segnatura di riferimento.'); return stopEvent(ev); }
        }

    </script>
    <div style="display: none;">
        <asp:HiddenField ID="hdnIdEstrazione" runat="server" />
        <asp:HiddenField ID="hdnProgettiEstrazione" runat="server" />
        <asp:Button ID="btnNuovoPost" runat="server" OnClick="btnNuovoPost_Click" />
    </div>
    <div class="dBox" id="divRichieste">
        <uc1:SiarNewTab runat="server" ID="ucSiarNewTab" TabNames="Lista estrazioni|Nuova estrazione"
            Width="100%" />
        <div id="tbEstrazioni" runat="server" class="tableTab" visible="false" width="100%">
            <div class="separatore" style="padding-bottom: 3px;">
                    Lista estrazioni:
                </div>
            <Siar:DataGrid ID="dgEstrazioni" runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle Width="35px" HorizontalAlign="center" VerticalAlign="Middle"></ItemStyle>
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="DataApertura" HeaderText="DataApertura">
                        <ItemStyle Width="240px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Operatore" HeaderText="Operatore">
                        <ItemStyle Width="240px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:ColonnaLink IsJavascript="true" LinkFields="Id" LinkFormat="selezionaEstrazione({0});"
                        DataField="Segnatura" HeaderText="Segnatura">
                    </Siar:ColonnaLink>                    
                </Columns>
            </Siar:DataGrid>&nbsp;
        </div>
        <div id="tbNuovaEstrazione" runat="server" class="tableTab" visible="false" width="100%">
            <div>
                <div class="separatore" style="padding-bottom: 3px;">
                    Nuova estrazione:
                </div>
                <div style="padding: 15px;" id="divMostraRichieste">
                    <div id="divRicercaRichieste" runat="server">
                        <div class="paragrafo_light">DATI DOMANDE DI AIUTO</div><br />
                        <div>
                            <b>Data:</b><br />
                            <Siar:DateTextBox ID="txtDataEstrazione" runat="server" NomeCampo="Data" Obbligatorio="true"></Siar:DateTextBox>
                        </div>
                        <div>
                            <b>Segnatura Esterna</b><br />
                            <Siar:TextBox ID="txtSegnatura" runat="server" Obbligatorio="true" Width="300px" />
                            &nbsp;
                           
                            <Siar:Button ID="btnVerifica" runat="server" Modifica="False" Text="Verifica la segnatura"
                                Width="150px" OnClick="btnVerifica_Click" CausesValidation="False" OnClientClick="return ctrlSegnaturaEsterna(event);" />
                        </div>                       
                        <br />
                        <div class="box_ricerca">
                            <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(); return false;">
                                <img id="imgFilter" src="<%=VirtualPathUtility.ToAbsolute("~/Images/ArrowUpSolid.png") %>" style="width: 23px; height: 23px;" />
                                Filtra le domande:
                            </div>
                            <div id="boxFilter" style="display: none;">
                                <br />
                                <div class="first_elem_block">
                                    <b>Id Domanda:</b>
                                    <br />
                                    <asp:TextBox ID="txtIdProgettoRicercaRichiesteAtti" runat="server" onkeypress="return isNumberKey(event)" />
                                </div>
                                <br />
                                <div class="first_elem_block">
                                    <input type="button" value="Filtra" id="Button1" class="Button" style="width: 110px; text-align: center;" onclick="javascript: FiltraRichieste(); return false;" causesvalidation="false" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="first_elem_block">
                            <input onclick="pulisciCampi();" style="width: 130px;" type="button" CausesValidation="false"
                                class="Button" value="Nuovo" />
                            <Siar:Button ID="btnSave" runat="server"
                                Text="Salva" Width="170px" CausesValidation="true" Modifica="True" OnClick="btnSalvaEstrazione_Click" />
                            <Siar:Button ID="btnElimina" runat="server"
                                Text="Elimina" Width="170px" CausesValidation="false" Modifica="True" OnClick="btnElimina_Click" />

                        </div>
                    </div>
                    <br />
                    <div>
                        <span>In questo riquadro compariranno i progetti, e quindi i destinatari, selezionati per l'estrazione.</span><br />
                        <div id="textarea"></div>
                        <div style="margin-top: 20px">
                            <input type="button" id="addtag" class="Button" value="Aggiungi domande selezionate" onclick="addTag();" /><br /><br />
                            <span>Per aggiungere destinatari è necessarion selezionarli dalla griglia sottostante e poi cliccare sul bottone "Aggiungi domande selezionate"</span><br />
                        </div>
                    </div>
                    <div style="float: right; text-align: center;">
                        <label style="font-weight: bold;" for="chkSelectAll">seleziona tutti</label><br />
                        <input id="chkSelectAll" type="checkbox" title="seleziona tutti" value="seleziona tutti" onclick="selectAll();" />
                    </div>
                    <br />
                    <asp:Label ID="lblNrRecordProgetti" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                    <br />
                    <Siar:DataGrid ID="dgDomande" runat="server" Width="100%" AutoGenerateColumns="false">
                        <ItemStyle Height="24px" />
                        <Columns>
                            <asp:BoundColumn DataField="IdProgetto" HeaderText="Id progetto">
                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IdBando" HeaderText="Id bando">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Asse" HeaderText="Asse">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Azione" HeaderText="Azione">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Intervento" HeaderText="Intervento">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DescrizioneIntervento" HeaderText="Descrizione intervento">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="RagioneSociale" HeaderText="Ragione sociale">
                                <ItemStyle CssClass="company" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="CodiceFiscale" HeaderText="Codice fiscale">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="SpesaAmmessaRendicontata" HeaderText="Spesa ammessa rendicontata">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ContributoAmmissibile" HeaderText="Contributo ammissibile">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ImportoLiquidato" HeaderText="Importo liquidato">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DataDecreto" HeaderText="Data decreto">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <Siar:CheckColumn DataField="IdProgetto" Name="chkAssocia" HeaderText="Seleziona il progetto">
                                <ItemStyle CssClass="chkSelect" HorizontalAlign="center" Width="80px" />
                            </Siar:CheckColumn>
                        </Columns>
                    </Siar:DataGrid>
                </div>
            </div>
        </div>
    </div>
    <uc3:FirmaDocumento ID="ucFirmaDocumento" runat="server" TitoloControllo="FIRMA DIGITALE DELLA COMUNICAZIONE" />
</asp:content>
