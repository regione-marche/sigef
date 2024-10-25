<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="GraduatoriaIndividuale.aspx.cs" Inherits="web.Private.Istruttoria.GraduatoriaIndividuale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
        function dettaglioDomanda(id, element) {
            var coords = getElementOffsetCoords(element); $.post(getBaseUrl() + 'CONTROLS/ajaxRequest.aspx', { "type": "getDatiDomanda", "iddom": id }, function (msg) {
                ajaxComplete = true; $('#divPopupDomanda').html(msg.Html).fadeIn("fast").css({ "top": coords.y, "left": coords.x, "width": 400 });
                $(document).click(function (e) { if (!$(arguments[0].target).hasClass("clickable") && !$(arguments[0].target.offsetParent).hasClass("clickable")) $('#divPopupDomanda').fadeOut("fast"); });
            }, 'json');
        }
        function ctrlCampiRicercaNormeMarche(ev) { if ($('[id$=txtAttoNumero_text]').val() == "" || $('[id$=txtAttoData_text]').val() == "" || $('[id$=lstAttoRegistro]').val() == "") { alert('Per la ricerca degli atti è necessario specificare numero, data e registro.'); return stopEvent(ev); } }
        function ctrlTipoAtto(ev) {
            if ($('[id$=hdnIdAtto]').val() == "") { alert('Per proseguire è necessario specificare un atto.'); return stopEvent(ev); }
            else if ($('[id$=lstAttoTipo]').val() == "") { alert('Per proseguire è necessario specificare la tipologia dell`atto.'); return stopEvent(ev); }
        }
        function chiudiPopup() { $('[id$=hdnIdAtto]').val(''); $('[id$=txtAttoDescrizione_text]').val(''); $('[id$=lstAttoOrgIstituzionale]').val(''); $('[id$=lstAttoTipo]').val(''); chiudiPopupTemplate(); }

        function cambiaStato(idProgetto) {
            if (confirm("Sei sicuro di voler modificare lo stato della domanda? Verrà riportato allo stato ACQUISITO e dovrà essere rifirmata l'istruttoria di ammissibilità. Procedere solo se si è sicuri di quello che si sta facendo. ")) {
                $('[id$=hdnIdProgettoCambiostato]').val(idProgetto);
                $('[id$=btnCambioStato]').click();
            }
            else {
                $('[id$=hdnIdProgettoCambiostato]').val();
                return stopEvent(ev);
            }

        }

        function modificaProgetto(idProgetto) {
            if (confirm("Sei sicuro di voler modificare la spesa ammessa e/o il contributo ammesso della domanda? Dovrà essere inserito anche un atto a giustificazione della modifica. Procedere solo se si è sicuri di quello che si sta facendo. ")) {
                $('[id$=hdnIdProgettoModifica]').val(idProgetto);
                $('[id$=btnModificaProgetto]').click();
            }
            else {
                $('[id$=hdnIdProgettoModifica]').val();
                return stopEvent(ev);
            }
        }

    //--></script>

    <br />
    <div style="display: none">
        <asp:HiddenField ID="hdnIdAtto" runat="server" />
        <asp:HiddenField ID="hdnIdProgettoCambiostato" runat="server" />
        <asp:HiddenField ID="hdnIdProgettoModifica" runat="server" />
        <asp:Button ID="btnCambioStato" runat="server" OnClick="btnCambioStato_Click" CausesValidation="false" />
        <asp:Button ID="btnModificaProgetto" runat="server" OnClick="btnModificaProgetto_Click" CausesValidation="false" />
    </div>
    <table width="1100px" class="tableNoTab">
        <tr>
            <td class="separatore_big">elenco domande finanziabili
            </td>
        </tr>
        <tr>
            <td>
                <table width="1000px">
                    <tr>
                        <td class="testo_pagina" style="width: 264px">Elenco dei progetti ammissibili.
                        </td>
                        <td>
                            <Siar:Button ID="btnOrdina" runat="server" Text="Ordina e calcola importi" OnClick="btnOrdina_Click"
                                Width="220px" Modifica="true" />
                            <input type="button" id="btnEstraiXls" runat="server" class="Button" value="Estrai in XLS"
                                style='width: 200px; margin-left: 30px' />
                            <Siar:Button ID="btnAggiornaRimanente" runat="server" Text="Aggiorna rimanente" OnClick="btnAggiornaRimanente_Click" Visible="false" />
                        </td>
                        <td>
                            <b>Rimanenza del Bando:</b><br />
                            <input id="lbRimanenzaGrad" name="lbRimanenzaGrad" runat="server" style="text-align: right;" disabled />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 10px; padding-top: 10px">
                <Siar:DataGrid ID="dgProgetti" runat="server" Width="100%" AutoGenerateColumns="False"
                    AllowPaging="False" ShowFooter="true">
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <ItemStyle Height="26px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="35px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="ID">
                            <ItemStyle HorizontalAlign="Center" Width="80px" Font-Bold="true" Font-Size="Small" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Punteggio" HeaderText="Punteggio" DataFormatString="{0:N3}">
                            <ItemStyle HorizontalAlign="center" Width="80px" Font-Bold="true" Font-Size="Small" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CostoTotale" HeaderText="Spesa ammessa" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="110px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ContributoTotale" HeaderText="Contributo ammesso" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="110px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ContributoTotale" HeaderText="Contributo concesso">
                            <ItemStyle HorizontalAlign="right" Width="110px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AmmontareFondiRiservaUtilizzato" HeaderText="Contributo finanziato con fondo di riserva"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="110px" />
                        </asp:BoundColumn>
                        <%--<asp:BoundColumn DataField="ContributoRimanente" HeaderText="Ammontare finanziario rimanente del bando"
                            DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="110px" />
                        </asp:BoundColumn>--%>
                        <asp:BoundColumn HeaderText="Esito">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Decreto">
                            <ItemStyle HorizontalAlign="Center" Width="240px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdProgetto" ButtonType="ImageButton" ButtonText="Riportare la domanda allo stato ACQUISITO"
                            JsFunction="cambiaStato" ButtonImage="ifUndo24.png" HeaderText>
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                        <Siar:CheckColumn DataField="IdProgetto" HeaderSelectAll="true" Name="chkProgSelezione">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </Siar:CheckColumn>
                        <Siar:JsButtonColumn Arguments="IdProgetto" ButtonType="ImageButton" ButtonText="Modifica spesa e contributo ammessi"
                            JsFunction="modificaProgetto" ButtonImage="ifEdit24.png" HeaderText="Modifica">
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td style="height: 53px; padding-right: 50px;" align="right">
                <Siar:Button ID="btnDecreto" runat="server" Text="Carica Decreto" OnClick="btnDecreto_Click"
                    Width="220px" Modifica="true" />
            </td>
        </tr>
    </table>
    <div id="divDecreto" style="width: 850px; position: absolute; display: none">
        <table class="tableNoTab" width="100%">
            <tr>
                <td class="separatore">Caricamento Atto di Concessione/Non Finanziabilità
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td style="width: 100px">Definizione:<br />
                                <Siar:ComboDefinizioneAtto ID="lstAttoDefinizione" runat="server" NoBlankItem="True"
                                    Width="80px">
                                </Siar:ComboDefinizioneAtto>
                            </td>
                            <td style="width: 100px">Numero:<br />
                                <Siar:IntegerTextBox ID="txtAttoNumero" NoCurrency="True" runat="server" Width="80px" NomeCampo="Numero decreto" />
                            </td>
                            <td style="width: 120px">Data:<br />
                                <Siar:DateTextBox ID="txtAttoData" runat="server" Width="100px" NomeCampo="Data decreto" />
                            </td>
                            <td style="width: 155px">Registro:<br />
                                <Siar:ComboRegistriAtto ID="lstAttoRegistro" runat="server" Width="120px">
                                </Siar:ComboRegistriAtto>
                            </td>
                            <td>
                                <br />
                                <Siar:Button ID="btnCercaDecreto" runat="server" OnClick="btnCercaDecreto_Click"
                                    Text="Ricerca" Width="120px" OnClientClick="return ctrlCampiRicercaNormeMarche(event);" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px">
                    <table style="width: 100%">
                        <tr>
                            <td>Descrizione:<br />
                                <Siar:TextArea ID="txtAttoDescrizione" runat="server" Width="650px" ReadOnly="True"
                                    Rows="4" ExpandableRows="5"></Siar:TextArea>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 260px">Organo Istituzionale:<br />
                                            <Siar:ComboOrganoIstituzionale ID="lstAttoOrgIstituzionale" runat="server" Width="210px"
                                                Enabled="False">
                                            </Siar:ComboOrganoIstituzionale>
                                        </td>
                                        <td>Tipo atto:<br />
                                            <Siar:ComboTipoAtto ID="lstAttoTipo" runat="server" NomeCampo="Tipo Atto">
                                            </Siar:ComboTipoAtto>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="350px">
                                    <tr>
                                        <td class="paragrafo" colspan="2">Pubblicazione B.U.R.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 150px">Numero:<br />
                                            <Siar:IntegerTextBox ID="txtAttoBurNumero" runat="server" Width="120px" ReadOnly="True" />
                                        </td>
                                        <td>Data:<br />
                                            <Siar:DateTextBox ID="txtAttoBurData" runat="server" Width="120px" ReadOnly="True" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="trDataComunicazione" runat="server" visible="false">
                <td style="padding-left: 10px">Data del CDA per i GAL / Determina per le Province:<br />
                    <Siar:DateTextBox ID="txtAttoDataXComunicazione" runat="server" Width="100px" NomeCampo="Data per Comunicazione" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="separatore_light">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 58px; padding-right: 40px" align="right">&nbsp;
                    <Siar:Button ID="btnFinanziabilita" runat="server" OnClick="btnFinanziabilita_Click"
                        OnClientClick="return ctrlTipoAtto(event);" Enabled="false" Text="Decreta Finanziabilità"
                        Width="180px" Modifica="true" Conferma="Decretare FINANZIABILI le domande selezionate?" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <Siar:Button ID="btnNonFinanziabilita" runat="server" OnClick="btnNonFinanziabilita_Click"
                        Enabled="false" Text="Decreta Non Finanziabilità" Width="180px" Conferma="Decretare NON finanziabili le domande selezionate?"
                        Modifica="true" />
                    <input class="Button" onclick="chiudiPopup()" style="width: 120px; margin-left: 80px"
                        type="button" value="Chiudi" />
                </td>
            </tr>
        </table>
    </div>
    <div id="divPopupDomanda" class='ajaxResp'>
    </div>
    <div id='divDecretoOrgInt' style="width: 750px; position: absolute; display: none;">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">Dati del decreto/atto:
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td class="testo_pagina" colspan="3">Inserire tutti i dati relativi al decreto/atto ed il link dello stesso presente
                                nel proprio albo pretorio.
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 160px">Data:<br />
                                <Siar:DateTextBox ID="txtDataDecretoOrg" runat="server" Width="120px" />
                            </td>
                            <td style="width: 160px">Numero:<br />
                                <Siar:IntegerTextBox NoCurrency="True" ID="txtNumeroDecretoOrg" runat="server" Width="120px" />
                            </td>
                            <td style="width: 330px"></td>
                        </tr>
                        <tr>
                            <td colspan="3" style="width: 650px">Descrizione/titolo:<br />
                                <Siar:TextArea Rows="3" MaxLength="3000" ID="txtDescrizioneDecretoOrg" runat="server" Width="630px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="width: 650px">Link Esterno:<br />
                                <asp:TextBox ID="txtLinkEst" runat="server" Width="630px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 70px;" colspan="3">
                                <Siar:Button ID="btnSalvaDescretoOrg" runat="server" OnClick="btnSalvaDescretoOrg_Click"
                                    Modifica="true" Text="Salva" Width="100px" CausesValidation="False" />
                                <input class="Button" onclick="chiudiPopupTemplate();" style="width: 100px; margin-left: 20px; margin-right: 20px"
                                    type="button" value="Chiudi" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
