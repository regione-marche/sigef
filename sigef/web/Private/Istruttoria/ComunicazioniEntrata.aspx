<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.ComunicazioniEntrata" CodeBehind="ComunicazioniEntrata.aspx.cs" %>

<%@ Register Src="../../CONTROLS/FiltroRicercaComunicazioni.ascx" TagName="FiltroRicercaComunicazioni"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function modificaMotivazione(idprogetto) {
            $('#divLinkMotivazione'+idprogetto).hide();var div=$('#divMotivazione'+idprogetto);
            $(div).html("<textarea id='txtMotivazione"+idprogetto+"' style='width:96%' rows='7'>"+$(div).text()
                +"</textarea>&nbsp;&nbsp;<input class='Button' style='width:80px' type=button value='salva' onclick='salvaMotivazione("+idprogetto+")' />&nbsp;&nbsp;&nbsp;"
                +"<input class='Button'  style='width:80px' type=button value='annulla' onclick='annullaModifica("+idprogetto+")'/>");
        }
        function annullaModifica(idprogetto) { $('#hdnIdProgetto').value="";$('#hdnMotivazione').value="";$('#divLinkMotivazione'+idprogetto).show();var div=$('#divMotivazione'+idprogetto);$(div).html($(div).text()); }
        function salvaMotivazione(idprogetto) { if(confirm('Attenzione! La modifica delle motivazioni non è reversibile. Continuare?\nLa richiesta verrà spostata in cima alla lista visualizzata.')) { $('[id$=hdnIdProgetto]')[0].value=idprogetto;$('[id$=hdnMotivazione]')[0].value=$('#txtMotivazione'+idprogetto).text();$('[id$=btnSalvaMotivazione]').click(); } }
        function selezionaPulsanti(codice) { $('[id$=btnIntegrazione]').css("display",(codice=="DNT"?"":"none"));$('[id$=btnRinuncia]').css("display",(codice=="RIN"?"":"none"));$('[id$=btnAvvia]').css("display",(codice=="RID"?"":"none"));$('[id$=btnRifiuta]').css("display",(codice=="RID"?"":"none"));$('[id$=btnRicorso]').css("display",(codice=="RIC"?"":"none")); }
        function dettaglioDomanda(id,element) {
            var coords=getElementOffsetCoords(element);$.post(getBaseUrl()+'CONTROLS/ajaxRequest.aspx',{ "type": "getDatiDomanda","iddom": id },function(msg) {
                ajaxComplete=true;$('#divPopupDomanda').html(msg.Html).fadeIn().css({ "top": coords.y,"left": coords.x,"width": 400 });
                $(document).click(function(e) { if(!$(arguments[0].target).hasClass("clickable")&&!$(arguments[0].target.offsetParent).hasClass("clickable")) $('#divPopupDomanda').hide(); });
            },'json');
        }
//--></script>

    <br />
    <table class="tableNoTab" width="1200">
        <tr>
            <td class="separatore_big">
                Registrazione delle comunicazioni in entrata delle domande di aiuto
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td align="left" valign="top" style="width: 420px">
                            <span style="text-decoration: underline">Tipologie di documento:</span><br />
                            <br />
                            - <strong>Richiesta di riesame</strong>: per avviare la procedura di riapertura
                            di una domanda in riesame occorre inserire la segnatura di protocollo del documento
                            con cui&nbsp; &nbsp;è stato richiesto. &nbsp;Il sistema controllerà automaticamente
                            se la domanda esiste e se la segnatura inserita è valida.<br />
                            &nbsp; - Il pulsante rifiuta registrerà solamente il documento senza avviare il
                            riesame.<br />
                            &nbsp;- <strong>Documenti di integrazione</strong>: è possibile registrare questo
                            tipo di documenti solo quando la domanda è in istruttoria, non modifica lo stato
                            attuale della domanda.<br />
                            &nbsp;- <strong>Richiesta di rinuncia</strong>: la registrazione di questo documento
                            imposterà lo stato della domanda in "Rinuncia", dopo di che non sarà piu' possibile
                            modificarla.<br />
                            &nbsp;- <strong>Esito del ricorso</strong>: la registrazione di questo documento
                            avvierà la riapertura dell'struttoria di ammissibilità della domanda di aiuto. Utilizzare
                            questa funzione solo per gli esiti positivi.&nbsp;
                        </td>
                        <td align="left" style="border-right: black 1px solid; border-top: black 1px solid;
                            border-left: black 1px solid; border-bottom: black 1px solid">
                            <br />
                            <table width="100%">
                                <tr>
                                    <td align="center" style="width: 202px">
                                        &nbsp;Selezionare la<br />
                                        tipologia di documento:
                                    </td>
                                    <td>
                                        <Siar:ComboBase ID="lstTipoDoc" runat="server">
                                        </Siar:ComboBase>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 202px">
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 202px">
                                        &nbsp; &nbsp;&nbsp; Numero di domanda:
                                    </td>
                                    <td>
                                        &nbsp;&nbsp; Segnatura del protocollo:
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="width: 202px">
                                        <Siar:IntegerTextBox ID="txtNumero" runat="server" MaxLength="5" NomeCampo="Numero di domanda"
                                            Obbligatorio="True" Width="75px" NoCurrency="True" />
                                    </td>
                                    <td>
                                        <Siar:TextBox ID="txtSegnatura" runat="server" NomeCampo="Segnatura" Obbligatorio="True"
                                            Width="480px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp; &nbsp; &nbsp;&nbsp; Motivazione:
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <Siar:TextArea ID="txtMotivazioneLunga" runat="server" Rows="4" Width="720px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="height: 46px">
                                        <Siar:Button ID="btnRicorso" runat="server" Modifica="True" OnClick="btnRicorso_Click"
                                            Text="Avvio ricorso" Width="144px" />
                                        <Siar:Button ID="btnIntegrazione" runat="server" Modifica="True" OnClick="btnIntegrazione_Click"
                                            Text="Registra" Width="144px" /><Siar:Button ID="btnRinuncia" runat="server" Modifica="True"
                                                OnClick="btnRinuncia_Click" Text="Avvio rinuncia" Width="144px" /><Siar:Button ID="btnAvvia"
                                                    runat="server" Modifica="True" OnClick="btnAvvio_Click" Text="Avvio riesame"
                                                    Width="144px" />&nbsp; &nbsp;<Siar:Button ID="btnRifiuta" runat="server" Modifica="True"
                                                        OnClick="btnRifiuta_Click" Text="Rifiuta" Width="144px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Elenco delle comunicazioni in entrata registrate:
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td valign="bottom">
                            <div style="display: none">
                                <Siar:Button ID="btnSalvaMotivazione" runat="server" OnClick="btnSalvaMotivazione_Click"
                                    CausesValidation="False" />
                                <input type="hidden" id="hdnIdProgetto" runat="server" /><input type="hidden" id="hdnMotivazione"
                                    runat="server" />
                            </div>
                        </td>
                        <td align="right">
                            <uc2:FiltroRicercaComunicazioni ID="ucFiltroRicercaComunicazioni" runat="server" />
                        </td>
                    </tr>
                </table>
                <Siar:DataGrid ID="dg" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="15" Width="100%">
                    <ItemStyle Height="50px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="25px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Nr. Domanda" DataField="IdProgetto">
                            <ItemStyle Width="80px" Font-Bold="True" Font-Size="14px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle Width="160px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Tipo" DataField="TipoSegnatura">
                            <ItemStyle Width="250px" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="Segnatura" JsFunction="sncAjaxCallVisualizzaProtocollo"
                            ButtonType="ImageButton" ButtonText="Visualizza documento" ButtonImage="acrobat.gif">
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Accolta">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Esito">
                            <ItemStyle HorizontalAlign="Center" Width="110px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 60px">
                <input id="btnIndietro" runat="server" type="button" onclick="location='Collaboratori.aspx'"
                    value="Indietro" style="width: 180px" class="Button" />
            </td>
        </tr>
    </table>
    <div id="divPopupDomanda" class='ajaxResp'>
    </div>
</asp:Content>
