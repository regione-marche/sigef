<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="AllegatiDomanda.aspx.cs" Inherits="web.Private.PDomanda.AllegatiDomanda" %>

<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function lstNACategoria_changed() {
            //var items = $(lst).find('option[selected=true]');   : sostituito con riga sotto
            var items = $('[id$=lstNACategoria]').find('option:selected');
            var tipo_allegato = ''; if (items.length > 0) tipo_allegato = $(items).attr('optvalue');
            document.getElementById('trNAUploadFile').style.display = tipo_allegato == 'D' ? '' : 'none'; document.getElementById('trNADichiarazioneSostitutiva').style.display = tipo_allegato == 'S' ? '' : 'none';
        }
        function pulisciCampi() { $('[id$=hdnIdProgettoAllegati]').val(''); $('[id$=lstNACategoria]').val(''); lstNACategoria_changed(); $('[id$=txtNADescrizioneBreve]').val(''); $('[id$=chkNAPresentato]')[0].checked = false; $('[id$=lstNATipoEnte]').val(''); $('[id$=txtNAEnte_text]').val(''); $('[id$=hdnCodEnte]').val(''); $('[id$=txtNADatadoc_text]').val(''); $('[id$=txtNANumeroDoc_text]').val(''); $('[id$=btnNuovoPost]').click(); /*debugger;SNCUFRimuoviFile('ctl00_cphContenuto_ufcNAAllegato');*/ }
        function dettaglioAllegato(idaxp) { $('[id$=hdnIdProgettoAllegati]').val(idaxp); $('[id$=btnDettaglioAllegatoPost]').click(); }
        function eliminaAllegato(ev) { if ($('[id$=hdnIdProgettoAllegati]').val() == '') { alert('Non è stato selezionato nessun allegato da eliminare.'); return stopEvent(ev); } if (!confirm('Attenzione! Eliminare l`allegato selezionato?')) return stopEvent(ev); }
        function ctrlCampi(ev) {
            var lst = $('[id$=lstNACategoria]'),items = $(lst).find('option:selected');/* items = $(lst).find('option[selected=true]');*/ if ($(lst).val() == '' || items.length == 0) { alert('Selezionare una categoria di allegato.'); return stopEvent(ev); }
            else {
                var optvalue = $(items).attr('optvalue');
                if (optvalue == "S" && ($('[id$=lstNATipoEnte]').val() == '' || $('[id$=txtNAEnte_text]').val() == '' || $('[id$=hdnCodEnte]').val() == '' || $('[id$=txtNADatadoc_text]').val() == '' || $('[id$=txtNANumeroDoc_text]').val() == '')) { alert('Per la categoria di allegato selezionata si richiede di specificare gli estremi del documento.'); return stopEvent(ev); }
                if (optvalue == "D" && $('[id$=chkNAPresentato]')[0].checked == false && $('input[type=hidden][id*=ufcNAAllegato]').val() == '') { alert('Per la categoria di allegato selezionata si richiede di carica il documento digitale o di specificare se il documento sia già stato presentato in una domanda di aiuto precedente.'); return stopEvent(ev); }
                if (optvalue == "C") { alert('L`allegato selezionato selezionato appartiene ad una tipologia non più valida, operazione annullata.'); return stopEvent(ev); }
            }
        }
        function lstNATipoEnte_changed() { $('[id$=txtNAEnte_text]').val(''); $('[id$=hdnCodEnte]').val(''); }
        function SNCVZCercaAmministrazione_onprepare(elem) { SNCZVParams = "{'CodTipoEnte':'" + $('[id$=lstNATipoEnte]').val() + "'}"; }
        function SNCVZCercaAmministrazione_onselect(obj) { $('[id$=txtNAEnte_text]').val(obj.Descrizione); $('[id$=hdnCodEnte]').val($('[id$=lstNATipoEnte]').val() == "CM" ? obj.IdComune : obj.CodEnte); }        
    </script>

    <br />
    <div style="display: none">
        <input type="hidden" id="hdnIdProgettoAllegati" runat="server" />
        <input type="hidden" id="hdnCodEnte" runat="server" />
        <asp:Button ID="btnDettaglioAllegatoPost" runat="server" OnClick="btnDettaglioAllegatoPost_Click" />
        <asp:Button ID="btnNuovoPost" runat="server" OnClick="btnNuovoPost_Click" />
    </div>
    <table class="tableNoTab" width="960px">
        <tr>
            <td class="separatore_big">
                DEFINIZIONE DEGLI ALLEGATI
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Elenco generale degli allegati alla presente domanda di aiuto. Le <b>categorie di documento</b>
                indicate sono quelle previste dal bando
                <br />
                di rifermento e sono suddivise in 3 tipi fondamentali:
                <br />
                <b>Supporto cartaceo (C)</b>: tipo non più valido, vecchia modalità di invio documenti
                in formato cartaceo tramite busta chiusa.<br />
                <b>Supporto digitale (D)</b>: tipologia che richiede il caricamento di un documento
                digitale (formato pdf), sottoscritto digitalmente.<br />
                <b>Dichiarazione sostitutiva (S)</b>: usata per documenti e/o certificati emessi
                da una pubblica amministrazione, questa tipologia<br />
                sostituisce a tutti gli effetti il caricamento di tali documenti ma richiede la
                specifica dei riferimenti di essi.
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Nuovo allegato:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            Selezionare la categoria del documento:<br />
                            <Siar:ComboSql ID="lstNACategoria" runat="server" OptionalValue="COD_TIPO" DataTextField="DESCRIZIONE"
                                DataValueField="ID_ALLEGATO" Width="600px">
                            </Siar:ComboSql>
                        </td>
                    </tr>
                    <tr id="trNADichiarazioneSostitutiva" style="display: none">
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 200px">
                                        &nbsp;
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 200px">
                                        Specificare l&#39;ente:<br />
                                        <Siar:Combo ID="lstNATipoEnte" runat="server">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem Value="CM">Comune</asp:ListItem>
                                            <asp:ListItem Value="PR">Provincia</asp:ListItem>
                                        </Siar:Combo>
                                    </td>
                                    <td>
                                        Denominazione ente:<br />
                                        <Siar:TextBox ID="txtNAEnte" runat="server" Width="400px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 200px">
                                        Data di emissione:<br />
                                        <Siar:DateTextBox ID="txtNADatadoc" runat="server" Width="130px" />
                                    </td>
                                    <td>
                                        Numero documento:<br />
                                        <Siar:TextBox ID="txtNANumeroDoc" runat="server" Width="150px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 200px">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 200px">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="trNAUploadFile" style="display: none">
                        <td>
                            <uc2:SNCUploadFileControl ID="ufcNAAllegato" runat="server" Width="600" Text="Selezionare un documento da caricare" />
                            <asp:CheckBox ID="chkNAPresentato" runat="server" Text="L&#39;allegato in questione è stato presentato in una precedente domanda di aiuto" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            Breve descrizione: (facoltativa, max 255 caratteri)
                            <br />
                            <Siar:TextArea ID="txtNADescrizioneBreve" runat="server" Width="600px" Rows="3" MaxLength="200" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 60px; padding-right: 40px">
                <Siar:Button ID="btnSalva" Text="Salva" runat="server" CausesValidation="false" Modifica="true"
                    Width="150px" OnClick="btnSalva_Click" OnClientClick="return ctrlCampi(event);" />
                &nbsp;&nbsp;
                <Siar:Button ID="btnElimina" Text="Elimina" runat="server" CausesValidation="false"
                    Modifica="true" Width="150px" OnClick="btnElimina_Click" OnClientClick="return eliminaAllegato(event);" />
                <input onclick="pulisciCampi();" style="width: 130px; margin-left: 20px" type="button"
                    class="Button" value="Nuovo" /><input onclick="location='RiepilogoDomanda.aspx'"
                        style="width: 130px; margin-left: 20px" type="button" class="Button" value="Indietro" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Elenco degli allegati inclusi:
            </td>
        </tr>
        <tr>
            <td>
                <div id="divDimTotAllegati" runat="server" style="position: absolute; left: 860px;
                    line-height: 2em; font-weight: bold">
                </div>
                <br />
                <Siar:DataGrid ID="dgAllegati" runat="server" AutoGenerateColumns="False" Width="100%"
                    AllowPaging="true" PageSize="10">
                    <ItemStyle Height="40px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="25px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="TipoAllegato" HeaderText="Formato">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Allegato" HeaderText="Categoria"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DescrizioneBreve" HeaderText="Descrizione">
                            <ItemStyle Width="300px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DimensioneFile" HeaderText="Dim. (Kb)" DataFormatString="{0:N0}">
                            <ItemStyle HorizontalAlign="Right" Width="60px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="GiaPresentato" HeaderText="Già presentato" DataFormatString="{0:<img src='../../images/visto.gif' />|}">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdFile" ButtonImage="lente.png" ButtonType="ImageButton"
                            ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:JsButtonColumn>
                        <Siar:JsButtonColumn Arguments="Id" ButtonImage="config.ico" ButtonType="ImageButton"
                            ButtonText="Visualizza dettaglio" JsFunction="dettaglioAllegato">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
