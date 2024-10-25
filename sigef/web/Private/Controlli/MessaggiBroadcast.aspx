<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="MessaggiBroadcast.aspx.cs" Inherits="web.Private.Controlli.MessaggiBroadcast" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
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
            $('[id$=hdnProgettiComunicazione]').val("");
            favorite.forEach(addElementToList);
            $('[id$=hdnProgettiComunicazione]').val($('[id$=hdnProgettiComunicazione]').val().substring(0, $('[id$=hdnProgettiComunicazione]').val().length - 1));
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
            var hdn = $('[id$=hdnProgettiComunicazione]').val();
            if (hdn !== undefined)
                hdn = hdn.concat(favorite[index] + ";");
            else
                hdn = favorite[index] + ";";
            $('[id$=hdnProgettiComunicazione]').val(hdn);
            
        }

        function selezionaComunicazione(idComunicazione) { $('[id$=hdnIdComunicazione]').val(idComunicazione); swapTab(2); }
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
            if ($('[id$=tbNuovaComunicazione]').is(':visible')) {
                selectAll();
                $("#textarea").text("");
                favorite.splice(0, favorite.length);
                var lstBando = $('[id$=lstBandiRup]')[0];
                var txtIdBando = lstBando.options[lstBando.selectedIndex].value;
                var txtIdDomanda = $('[id$=txtIdProgettoRicercaRichiesteAtti]').val();
                var lstStatoProgetto = $('[id$=lstStatoProgetto]')[0];
                var txtStatoProgetto = lstStatoProgetto.options[lstStatoProgetto.selectedIndex].text.toUpperCase();
                var tblGrid = $('[id$=dgDomande]')[0];

                var rows = tblGrid.rows;
                var i = 0, row, cell; count = 0;
                for (i = 1; i < rows.length; i++) {
                    row = rows[i];
                    var found = false;
                    dgIdBando = row.cells[0].innerHTML.toUpperCase();
                    dgIdDomanda = row.cells[2].innerHTML.toUpperCase();
                    dgStatoProgetto = row.cells[3].innerHTML.toUpperCase();

                    if (((txtIdBando != "" && dgIdBando == txtIdBando)) && (txtIdDomanda == "" || (txtIdDomanda != "" && dgIdDomanda == txtIdDomanda))
                        && (txtStatoProgetto == "" || (txtStatoProgetto != "" && dgStatoProgetto == txtStatoProgetto))) {
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
                    $('[id$=lblNrRecordBandiRup]')[0].innerHTML = "Visualizzate " + count + " righe";
                    $('[id$=dgDomande]').show("fast");
                } else {
                    $('[id$=lblNrRecordBandiRup]')[0].innerHTML = "Nessuna domanda trovata";
                    $('[id$=dgDomande]').hide("fast");
                }

                if ($('[id$=hdnIdComunicazione]').value != "") {
                    var res = $('[id$=hdnProgettiComunicazione]').val().split(";");
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

    </script>
    <div style="display: none;">
        <asp:HiddenField ID="hdnIdComunicazione" runat="server" />
        <asp:HiddenField ID="hdnProgettiComunicazione" runat="server" />
        <asp:Button ID="btnNuovoPost" runat="server" OnClick="btnNuovoPost_Click" />
    </div>
    <div class="dBox" id="divRichieste">
        <uc1:SiarNewTab runat="server" ID="ucSiarNewTab" TabNames="Lista comunicazioni|Nuova comunicazione"
            Width="100%" />
        <div id="tbComunicazioni" runat="server" class="tableTab" visible="false" width="100%">
            <div class="separatore" style="padding-bottom: 3px;">
                    Lista comunicazioni massive:
                </div>
            <Siar:DataGrid ID="dgComunicazioni" runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle Width="35px" HorizontalAlign="center" VerticalAlign="Middle"></ItemStyle>
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="IdBando" HeaderText="Bando">
                        <ItemStyle Width="240px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:ColonnaLink IsJavascript="true" LinkFields="Id" LinkFormat="selezionaComunicazione({0});"
                        DataField="Oggetto" HeaderText="Oggetto">
                    </Siar:ColonnaLink>
                    <asp:BoundColumn DataField="DataModifica" HeaderText="Data comunicazione">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Operatore" HeaderText="Operatore">
                        <ItemStyle Width="130px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Segnatura" HeaderText="Segnatura">
                        <ItemStyle Width="130px" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>&nbsp;
        </div>
        <div id="tbNuovaComunicazione" runat="server" class="tableTab" visible="false" width="100%">
            <div>
                <div class="separatore" style="padding-bottom: 3px;">
                    Nuova comunicazione:
                </div>
                <div style="padding: 15px;">
                    <div class="paragrafo_light">DATI COMUNICAZIONE</div>
                    <br />
                    <div>
                        <b>Tipo comunicazione:</b><br />
                        <Siar:ComboTipologiaComunicazione ID="cmbSelTipoComunicazione" NomeCampo="Tipo comunicazione"
                            Obbligatorio="true" Width="300px" runat="server" />
                    </div>
                    <div>
                        <b>Oggetto</b><br />
                        <Siar:TextBox ID="txtOggetto" NomeCampo="Oggetto" MaxLength="250" Obbligatorio="true"
                            runat="server" Width="300px" />
                    </div>
                    <div>
                        <b>Testo comunicazione:</b><br />
                        <Siar:TextArea ID="txtTesto" ExpandableRows="10" runat="server" Width="750px" Rows="10" Obbligatorio="true" NomeCampo="Testo"
                            MaxLength="10000" />
                    </div>
                    <div>
                        <b>Note:</b><br />
                        <Siar:TextArea ID="txtNote" ExpandableRows="10" runat="server" Width="750px" Rows="10"
                            MaxLength="10000" />
                    </div>
                    <div class="paragrafo_light">DATI ALLEGATO ALLA COMUNICAZIONE</div>
                    <br />
                    <div>
                        <uc2:SNCUploadFileControl ID="ufcNAAllegato" AbilitaModifica="true" DimensioneMassima="_500kb" runat="server"
                            Width="600" Text="Selezionare un documento da caricare" />
                    </div>
                    <div>
                        <br />
                        Breve descrizione: (facoltativa, max 255 caratteri)
                           
                <br />
                        <Siar:TextArea ID="txtNADescrizioneBreve" runat="server" Width="600px" Rows="3" MaxLength="200" />
                    </div>
                </div>
                <div style="padding: 15px;" id="divMostraRichieste">
                    <div id="divRicercaRichieste" runat="server">
                        <div class="paragrafo_light">DATI DOMANDE DI AIUTO</div>
                        <br />
                        <div>
                            <b>Bando:</b><br />
                            <Siar:ComboBandiRup ID="lstBandiRup" runat="server" onchange="FiltraRichieste();" NomeCampo="Bando" Obbligatorio="true"></Siar:ComboBandiRup>
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
                                    <b>Stato domanda:</b>
                                    <br />
                                    <Siar:ComboStatoProgetto ID="lstStatoProgetto" runat="server" Height="21px"></Siar:ComboStatoProgetto>
                                </div>
                                <br />
                                <div class="first_elem_block">
                                    <input type="button" value="Filtra" id="Button1" class="Button" style="width: 110px; text-align: center;" onclick="javascript: FiltraRichieste(); return false;" causesvalidation="false" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="first_elem_block">
                            <input onclick="pulisciCampi();" style="width: 130px;" type="button"
                                class="Button" value="Nuovo" />
                            <Siar:Button ID="btnSave" runat="server"
                                Text="Salva" Width="170px" Modifica="True" OnClick="btnSalvaComunicazione_Click" />
                            <Siar:Button ID="btnElimina" runat="server"
                                Text="Elimina" Width="170px" Modifica="True" OnClick="btnElimina_Click" />

                        </div>
                    </div>
                    <br />
                    <div>
                        <span>In questo riquadro compariranno i progetti, e quindi i destinatari, selezionati per l'invio del messaggio. E' possibile inviare un numero massimo di 25 messaggi alla volta.</span><br />
                        <div id="textarea"></div>
                        <div style="text-align: center;">
                            <br />
                            <Siar:Button ID="btnInvia" runat="server" OnClick="btnFirma_Click"
                                Text="Invia" Width="170px" Modifica="True" />
                        </div>
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
                    <asp:Label ID="lblNrRecordBandiRup" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                    <br />
                    <Siar:DataGrid ID="dgDomande" runat="server" Width="100%" AutoGenerateColumns="false">
                        <ItemStyle Height="24px" />
                        <Columns>
                            <asp:BoundColumn DataField="IdBando" HeaderText="Id bando">
                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DescrizioneBando" HeaderText="Descrizione bando">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IdProgetto" HeaderText="Id progetto">
                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="StatoProgetto" HeaderText="Stato progetto">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Impresa" HeaderText="Impresa">
                                <ItemStyle CssClass="company" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IstruttoreProgetto" HeaderText="Istruttore">
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
</asp:Content>
