<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVisualizzaProtocollo.ascx.cs" Inherits="web.CONTROLS.ucVisualizzaProtocollo" %>

<%@ Register Src="~/CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>

<div id="divVisualizzaProtocollo" runat="server" style="width: 850px; height: 475px; position: absolute; display: none; box-shadow: none; overflow: hidden; transition: 1s;">

     <style type="text/css">

        .first_elem_block_protocollo {
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block_protocollo {
            vertical-align: top;
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-left: 20px;
            padding-bottom: 5px;
        }

        .label {
            display: inline;
            float: left;
            min-width: 200px;
            max-width: 200px;
            width: 200px;
            text-align: right;
            vertical-align: middle;
            white-space: normal;
        }

        .value {
            display: inline-block;
            float: right;
            margin-left: 5px;
            white-space: normal;
        }

        .nascondi {
            display: none;
        }

        .switch {
            position: relative;
            display: inline-block;
            width: 30px;
            height: 17px;
        }

        .switch input { 
            opacity: 0;
            width: 0;
            height: 0;
        }

        .slider {
            position: absolute;
            cursor: pointer;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-color: #ccc;
            -webkit-transition: .4s;
            transition: .4s;
        }

        .slider:before {
            position: absolute;
            content: "";
            height: 13px;
            width: 13px;
            left: 2px;
            bottom: 2px;
            background-color: white;
            -webkit-transition: .4s;
            transition: .4s;
        }

        input:checked + .slider {
            background-color: #2196F3;
        }

        input:focus + .slider {
            box-shadow: 0 0 1px #2196F3;
        }

        input:checked + .slider:before {
            -webkit-transform: translateX(13px);
            -ms-transform: translateX(13px);
            transform: translateX(13px);
        }

        /* Rounded sliders */
        .slider.round {
            border-radius: 17px;
        }

        .slider.round:before {
            border-radius: 50%;
        }

        div.scroll {
            /*margin:10px; */
            display: inline-block;
            height: 300px;
            overflow-x: hidden;
            overflow-y: auto;
        }

        .textBold {
            font-weight: bold;
        }

    </style>

    <script type="text/javascript">

        function cambiaVista() {
            var divModale = $('[id$=divVisualizzaProtocollo]');

            var elm = $('[id$=switchVistaAvanzata]')[0];
            elm.click();

            var divSimple = $('[id$=divVistaSemplice]');
            var divAdvanced = $('[id$=divVistaAvanzata]');

            if (elm.checked) {
                divSimple.hide("slow");
                divAdvanced.show("slow");

                divModale[0].style.width = "1300px";
                divModale[0].style.transform = "translate(-200px)";
            } else {
                divSimple.show("slow");
                divAdvanced.hide("slow");

                divModale[0].style.width = "850px";
                divModale[0].style.transform = "translate(100px)";
            }
        }

        function apriDocumentoSemplice(id) {
            var tblGridDocumenti = $('[id$=dgVistaSemplice]')[0];

            if (typeof tblGridDocumenti !== 'undefined') { //aggiunto controllo per evitare errore in caso di datagrid ancora vuoto
                var rows = tblGridDocumenti.rows;
                var i = 0, row;
                for (i = 1; i < rows.length; i++) {
                    row = rows[i];
                    var idRiga = row.cells[3].innerText;
                    var indiceRiga = row.cells[4].innerText;

                    if (idRiga == id) {
                        window.open(getBaseUrl() + "VisualizzaDocumento.aspx?nf=" + indiceRiga);
                    }
                }
            }
        }

        function apriDocumentoAvanzata(id) {
            var tblGridDocumenti = $('[id$=dgVistaAvanzata]')[0];

            if (typeof tblGridDocumenti !== 'undefined') { //aggiunto controllo per evitare errore in caso di datagrid ancora vuoto
                var rows = tblGridDocumenti.rows;
                var i = 0, row;
                for (i = 1; i < rows.length; i++) {
                    row = rows[i];
                    var idRiga = row.cells[3].innerText;
                    var indiceRiga = row.cells[4].innerText;

                    if (idRiga == id) {
                        window.open(getBaseUrl() + "VisualizzaDocumento.aspx?nf=" + indiceRiga);
                    }
                }
            }
        }

        function filtraDocumentiSegnatura(segnaturaSelezionata) {
            $('[id$=hdnSegnaturaSelezionata]').val($('[id$=hdnSegnaturaSelezionata]').val() == segnaturaSelezionata ? '' : segnaturaSelezionata);
            var segnaturaNascosta = $('[id$=hdnSegnaturaSelezionata]').val();

            var tblGridElencoSegnature = $('[id$=dgElencoSegnature]')[0];
            if (typeof tblGridElencoSegnature !== 'undefined') { //aggiunto controllo per evitare errore in caso di datagrid ancora vuoto
                var rows = tblGridElencoSegnature.rows;
                var i = 0, row, count = 0;
                for (i = 1; i < rows.length; i++) {
                    row = rows[i];
                    var found = false;
                    var segnaturaRiga = row.cells[1].innerText;

                    if (segnaturaNascosta == '' || segnaturaRiga == segnaturaSelezionata) {
                        found = true;
                    }

                    if (!found) {
                        row.style['display'] = 'none';
                    } else {
                        row.style.display = '';
                        count++;
                    }
                }

                if (count > 1) {
                    $('[id$=lblNrElencoSegnature]')[0].innerText = 'Selezionare il protocollo per filtrare gli allegati (' + count + ' protocolli)';
                } else {
                    $('[id$=lblNrElencoSegnature]')[0].innerText = 'Selezionare il protocollo per mostrare tutti gli allegati';
                }
            }

            var tblGridDocumenti = $('[id$=dgVistaAvanzata]')[0];
            if (typeof tblGridDocumenti !== 'undefined') { //aggiunto controllo per evitare errore in caso di datagrid ancora vuoto
                var rows = tblGridDocumenti.rows;
                var i = 0, row, count = 0;
                for (i = 1; i < rows.length; i++) {
                    row = rows[i];
                    var found = false;
                    var idRiga = row.cells[3].innerText;
                    var indiceRiga = row.cells[4].innerText;
                    var segnaturaRiga = row.cells[5].innerText;

                    if (segnaturaNascosta == '' || segnaturaRiga == segnaturaSelezionata) {
                        found = true;
                    }

                    if (!found) {
                        row.style['display'] = 'none';
                    } else {
                        row.style.display = '';
                        count++;
                    }
                }

                $('[id$=lblNrVistaAvanzata]')[0].innerText = 'Selezionare il documento desiderato per aprirlo (' + count + ' documenti)';
            }
        }

        function copiaSegnaturaInRam() {
            var segnatura = $('[id$=inputSegnatura]').val();

            if (window.clipboardData && clipboardData.setData)
                clipboardData.setData("Text", segnatura);
            else {
                try {
                    var textField = document.createElement('textarea');
                    textField.value = segnatura;
                    textField.innerText = segnatura;
                    document.body.appendChild(textField);
                    textField.select();
                    document.execCommand('copy');
                    textField.remove();
                }
                catch (err) {
                    alert('Attenzione!\nIl browser che si sta utilizzando non supporta questa funzionalità.');
                }
            } 

            /*alert('Segnatura copiata');*/
            return false;
        }

        function copiaSegnaturaDataGridInRam(segnatura) {
            if (window.clipboardData && clipboardData.setData)
                clipboardData.setData("Text", segnatura);
            else {
                try {
                    var textField = document.createElement('textarea');
                    textField.value = segnatura;
                    textField.innerText = segnatura;
                    document.body.appendChild(textField);
                    textField.select();
                    document.execCommand('copy');
                    textField.remove();
                }
                catch (err) {
                    alert('Attenzione!\nIl browser che si sta utilizzando non supporta questa funzionalità.');
                }
            }

            /*alert('Segnatura copiata');*/
            return false;
        }

    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnSegnaturaSelezionata" Value="" runat="server" />
    </div>

    <div class="dBox" id="divScelta" runat="server" style="width: 100%; height: 100%; overflow-y: auto;">

        <div>
            <div id="pTitolo" runat="server" class="separatore">
                Selezionare il documento desiderato
            </div>
            <br />

            <div style="padding:10px;">
                <div class="first_elem_block_protocollo">
                    <input id="inputSegnatura" runat="server" type="text" disabled="disabled" style='width:450px' />
                </div>

                <div class="elem_block_protocollo">
                    <Siar:Button runat="server" ID="btnCopiaSegnatura" Text="Copia segnatura" Width="140px" OnClientClick="return copiaSegnaturaInRam();" />
                </div>

                <div class="elem_block_protocollo">
                    <Siar:Button ID="btnChiudiValidazione" runat="server" Width="140px" OnClick="btnChiudi_Click" Text="Chiudi" />
                </div>
                <br />

                <div id="divSceltaVistaAvanzata" runat="server" class="first_elem_block_protocollo">
                    Vista avanzata
                    <label class="switch">
                      <input id="switchVistaAvanzata" type="checkbox" onchange="cambiaVista()">
                      <span class="slider round"></span>
                    </label>
                </div>
                <br />
                <input id="txtErrore" runat="server" type="text" visible="false" disabled="disabled" style='width:450px; color: red;' />
                <br />

                <div class="tableTab"  id="divVistaSemplice" runat="server">
                    <asp:Label ID="lblNrVistaSemplice" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                    <br />
                    <div class="scroll">
                        <Siar:DataGrid ID="dgVistaSemplice" runat="server" AutoGenerateColumns="False" Width="730px">
                            <Columns>
                                <asp:BoundColumn HeaderText="Documento">
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <Siar:ColonnaLink HeaderText="Titolo" DataField="NomeFile" IsJavascript="true" 
                                                    LinkFields="Id" LinkFormat="apriDocumentoSemplice({0});">
                                        <ItemStyle Width="550px" />
                                </Siar:ColonnaLink>
                                <asp:BoundColumn HeaderText="Formato" DataField="Tipo">
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Id" DataField="Id">
                                    <HeaderStyle CssClass="nascondi" />
                                    <ItemStyle CssClass="nascondi" />
                                    <FooterStyle CssClass="nascondi" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Indice" DataField="Id">
                                    <HeaderStyle CssClass="nascondi" />
                                    <ItemStyle CssClass="nascondi" />
                                    <FooterStyle CssClass="nascondi" />
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGrid>
                    </div>
                </div>

                <div class="tableTab"  id="divVistaAvanzata" runat="server" style="display: none;">
                    <div style="display: inline-block; vertical-align: top">
                        <asp:Label ID="lblNrElencoSegnature" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                        <br />
                        <Siar:DataGrid ID="dgElencoSegnature" runat="server" AutoGenerateColumns="False" >
                            <Columns>
                                <asp:BoundColumn HeaderText="Nr.">
                                    <ItemStyle Width="60px" HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <Siar:ColonnaLink HeaderText="Protocollo" DataField="SegnaturaSecondaria" IsJavascript="true" MettiApiciInLinkFields="true"
                                                  LinkFields="SegnaturaSecondaria" LinkFormat="filtraDocumentiSegnatura({0});">
                                      <ItemStyle Width="150px" />
                                </Siar:ColonnaLink>
                                <Siar:JsButtonColumn HeaderText="Copia" Arguments="SegnaturaSecondaria" ButtonType="ImageButton" ButtonImage="/copy50.png" ButtonText="Copia segnatura" JsFunction="copiaSegnaturaDataGridInRam">
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                </Siar:JsButtonColumn>
                            </Columns>
                        </Siar:DataGrid>
                    </div>

                    <div style="width: 15px; margin:10px; display: inline-block;">
                    </div>

                    <div style="display: inline-block;">
                        <asp:Label ID="lblNrVistaAvanzata" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                        <br />

                        <div class="scroll">
                            <Siar:DataGrid ID="dgVistaAvanzata" runat="server" AutoGenerateColumns="False" Width="730px" >
                                <Columns>
                                    <asp:BoundColumn HeaderText="Documento">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <Siar:ColonnaLink HeaderText="Titolo" DataField="NomeFile" IsJavascript="true" 
                                                      LinkFields="Id" LinkFormat="apriDocumentoAvanzata({0});">
                                          <ItemStyle Width="550px" />
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn HeaderText="Formato" DataField="Tipo">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Id" DataField="Id">
                                        <HeaderStyle CssClass="nascondi" />
                                        <ItemStyle CssClass="nascondi" />
                                        <FooterStyle CssClass="nascondi" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Indice" DataField="Id">
                                        <HeaderStyle CssClass="nascondi" />
                                        <ItemStyle CssClass="nascondi" />
                                        <FooterStyle CssClass="nascondi" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Segnatura" DataField="Id">
                                        <HeaderStyle CssClass="nascondi" />
                                        <ItemStyle CssClass="nascondi" />
                                        <FooterStyle CssClass="nascondi" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </div>
                    </div>
                    
                </div>
                <br />

            </div>
        </div>
    </div>
</div>
