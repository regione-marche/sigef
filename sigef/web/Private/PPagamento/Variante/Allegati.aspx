<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.Variante.Allegati" CodeBehind="Allegati.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/WorkFlowVarianti.ascx" TagName="WorkFlowVarianti"
    TagPrefix="uc1" %>
<%@ Register Src="../../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function lstCategoria_changed() {
            var tipo_allegato='';var items=$('[id$=lstCategoria]').find('option:selected');if(items.length>0) tipo_allegato=$(items).attr('optvalue');
            $('[id$=trUploadFile]')[0].style.display=tipo_allegato=='D'?'':'none';
            $('[id$=trDichiarazioneSostitutiva]')[0].style.display=tipo_allegato=='S'?'':'none';
        }
        function pulisciCampi() { $('[id$=hdnIdAllegato]').val('');$('[id$=lstCategoria]').val('');lstCategoria_changed();$('[id$=txtDescrizione]').val('');$('[id$=lstNATipoEnte]').val('');$('[id$=txtNAEnte_text]').val('');$('[id$=hdnCodEnte]').val('');$('[id$=txtNADatadoc_text]').val('');$('[id$=txtNANumeroDoc_text]').val(''); /*debugger;SNCUFRimuoviFile('ctl00_cphContenuto_ufcNAAllegato');*/ }
        function dettaglioAllegato(idaxp) { $('[id$=hdnIdAllegato]').val(idaxp);$('[id$=btnDettaglioPost]').click(); }
        function eliminaAllegato(ev) { if($('[id$=hdnIdAllegato]').val()=='') { alert('Non è stato selezionato nessun allegato da eliminare.');return stopEvent(ev); } if(!confirm('Attenzione! Eliminare l`allegato selezionato?')) return stopEvent(ev); }
        function ctrlCampi(ev) {
            var lst=$('[id$=lstCategoria]'),items=$(lst).find('option:selected');if($(lst).val()==''||items.length==0) { alert('Selezionare una categoria di allegato.');return stopEvent(ev); }
            else {
                var optvalue=$(items).attr('optvalue');
                if(optvalue=="S"&&($('[id$=lstNATipoEnte]').val()==''||$('[id$=txtNAEnte_text]').val()==''||$('[id$=hdnCodEnte]').val()==''||$('[id$=txtNADatadoc_text]').val()==''||$('[id$=txtNANumeroDoc_text]').val()=='')) { alert('Per la categoria di allegato selezionata si richiede di specificare gli estremi del documento.');return stopEvent(ev); }
                if(optvalue=="D"&&$('input[type=hidden][id*=ufcNAAllegato]').val()=='') { alert('Per la categoria di allegato selezionata si richiede di carica il documento digitale o di specificare se il documento sia già stato presentato in una domanda di aiuto precedente.');return stopEvent(ev); }
                if(optvalue=="C") { alert('L`allegato selezionato selezionato appartiene ad una tipologia non più valida, operazione annullata.');return stopEvent(ev); }
            }
        }
        function lstNATipoEnte_changed() { $('[id$=txtNAEnte_text]').val('');$('[id$=hdnCodEnte]').val(''); }
        function SNCVZCercaAmministrazione_onprepare(elem) { SNCZVParams="{'CodTipoEnte':'"+$('[id$=lstNATipoEnte]').val()+"'}"; }
        function SNCVZCercaAmministrazione_onselect(obj) { $('[id$=txtNAEnte_text]').val(obj.Descrizione);$('[id$=hdnCodEnte]').val($('[id$=lstNATipoEnte]').val()=="CM"?obj.IdComune:obj.CodEnte); }        
          
//--></script>

    <uc1:WorkFlowVarianti ID="ucWorkFlowVarianti" runat="server" />
    <br />
    <div style="display: none">
        <input type="hidden" id="hdnIdAllegato" runat="server" />
        <input type="hidden" id="hdnCodEnte" runat="server" />
        <asp:Button ID="btnDettaglioPost" runat="server" OnClick="btnDettaglioPost_Click" />
    </div>
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                DICHIARAZIONE DEGLI ALLEGATI ALLA RICHIESTA
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Elenco generale degli allegati alla presente richiesta di variante/variazione finanziaria. Le <b>categorie
                    di documento</b> indicate sono quelle previste<br />
                dal bando di riferimento e sono suddivise in 3 tipi fondamentali:
                <br />
                <b>Supporto cartaceo (C)</b>: tipo non più valido, vecchia modalità di invio documenti
                in formato cartaceo tramite busta chiusa.<br />
                <b>Supporto digitale (D)</b>: richiede il caricamento di un documento digitale (sottoscritto
                digitalmente per le tipologie previste dal bando di gara).<br />
                <b>Dichiarazione sostitutiva (S)</b>: usata per documenti e/o certificati emessi
                da una pubblica amministrazione, questa tipologia<br />
                sostituisce a tutti gli effetti il caricamento di tali documenti ma richiede la
                specifica dei riferimenti di essi.
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="separatore">
                &nbsp;Nuovo allegato:
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <table style="padding-left: 15px" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            Selezionare la categoria del documento:<br />
                            <Siar:ComboSql ID="lstCategoria" runat="server" OptionalValue="FORMATO" DataTextField="DESCRIZIONE"
                                DataValueField="CODICE" Width="600px">
                            </Siar:ComboSql>
                        </td>
                    </tr>
                    <tr id="trDichiarazioneSostitutiva" style="display: none">
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
                    <tr id="trUploadFile" style="display: none">
                        <td>
                            <uc2:SNCUploadFileControl ID="ufcNAAllegato" runat="server" Width="600" Text="Selezionare un documento da caricare" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Breve descrizione: (facoltativa, max 255 caratteri) :<br />
                            <Siar:TextArea ID="txtDescrizione" runat="server" Height="19px" NomeCampo="Descrizione"
                                Width="600px" Rows="3" MaxLength="255" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            &nbsp;
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
                    Modifica="true" Width="150px" OnClick="btnDel_Click" OnClientClick="return eliminaAllegato(event);" />
                <input onclick="pulisciCampi();" style="width: 130px; margin-left: 20px" type="button"
                    class="Button" value="Nuovo" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore">
                &nbsp;Lista degli allegati inseriti:
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgAllegati" runat="server" AutoGenerateColumns="False" Width="100%"
                    AllowPaging="true" PageSize="15">
                    <PagerStyle CssClass="coda" />
                    <AlternatingItemStyle CssClass="DataGridRow" />
                    <ItemStyle CssClass="DataGridRow" Height="18px" />
                    <HeaderStyle CssClass="TESTA" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="center" Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="TipoAllegato" HeaderText="Formato">
                            <ItemStyle Width="130px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TipologiaDocumento" HeaderText="Categoria">
                            <ItemStyle Width="190px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DimensioneFile" HeaderText="Dim. (Kb)" DataFormatString="{0:N0}">
                            <ItemStyle HorizontalAlign="Right" Width="60px" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdFile" ButtonImage="lente.png" ButtonType="ImageButton"
                            ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:JsButtonColumn>
                        <Siar:JsButtonColumn Arguments="IdAllegato" ButtonImage="config.ico" ButtonType="ImageButton"
                            ButtonText="Visualizza dettaglio" JsFunction="dettaglioAllegato">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
