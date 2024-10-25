<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    EnableViewState="true" Inherits="web.Private.Istruttoria.ChecklistAmmissibilita"
    CodeBehind="ChecklistAmmissibilita.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/ChecklistNew.ascx" TagName="ChecklistNew" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/SiarNewZoomPunteggio.ascx" TagName="SiarNewZoomPunteggio"  TagPrefix="uc4" %>
<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc5" %>
<%@ Register Src="../../CONTROLS/SiarNewToolTip.ascx" TagName="ToolTip" TagPrefix="uc6" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc7" %>
<%@ Register Src="~/CONTROLS/ucVisure.ascx" TagName="ucVisure" TagPrefix="uc8" %>
<%@ Register Src="~/CONTROLS/ucProcureSpeciali.ascx" TagName="Procure" TagPrefix="uc9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

<script type="text/javascript">
        function DisabilitaLabel() {
            if ($('[id$=ckAttivo]').is(':checked')) {
                $('[id$=txtSegnaturaIns]').attr('readonly', true);
                $('[id$=txtSegnaturaIns]').val('');
            }
            else
                $('[id$=txtSegnaturaIns]').removeAttr('readonly');
        }

    function pulisciCampi() {
        $('[id$=hdnIdProgettoAllegatiIstruttoria]').val('');
        $('[id$=txtNADescrizioneBreve]').val('');
        $('[id$=btnNuovoPost]').click(); 
    }

    function eliminaAllegato(ev) {
        if ($('[id$=hdnIdProgettoAllegatiIstruttoria]').val() == '')
        {
            alert('Non è stato selezionato nessun allegato da eliminare.');
            return stopEvent(ev);
        }
        if (!confirm('Attenzione! Eliminare l`allegato selezionato?'))
            return stopEvent(ev);
    }

    function dettaglioAllegato(idaxp) { $('[id$=hdnIdProgettoAllegatiIstruttoria]').val(idaxp); $('[id$=btnDettaglioAllegatoPost]').click(); }

</script>
    <div style="display: none">
        <input type="hidden" id="hdnIdProgettoAllegatiIstruttoria" runat="server" />
        <asp:Button ID="btnNuovoPost" runat="server" OnClick="btnNuovoPost_Click" />
        <asp:Button ID="btnDettaglioAllegatoPost" runat="server" OnClick="btnDettaglioAllegatoPost_Click" />
    </div>
    <br />
    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <br />
    <a id="lnkInizioPagina"></a>
    <table class="tableNoTab" width="100%">
        <tr>
            <td class="separatore_big">
                CHECKLIST ISTRUTTORIA DI AMMISSIBILITA` DELLA DOMANDA DI AIUTO
            </td>
        </tr>
        <tr>
            <td align="right">
                <uc6:ToolTip ID="ucTooltip" runat="server" />
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbLinkVeloci" runat="server" style="table-layout: fixed">
                    <tr>
                        <td align="center" style="width: 80px; font-weight: bold">
                            LINK VELOCI:
                        </td>
                        <td style="padding: 3px">
                        </td>
                        <td style="width: 48px;" class="selectable" onclick="location='#lnkFondoPagina'">
                            <img id="Img1" src="../../images/arrow_down_big.png" alt="Fondo pagina" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        <tr>
            <td>
                <uc3:ChecklistNew ID="ucChecklist" runat="server" Fase="A" DefaultRedirect="~/Private/Istruttoria/Ammissibilita.aspx" />
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
    </table>
    <br />
    <table class="tableNoTab" width="100%">  
        <tr>
            <td class="separatore">
                DOCUMENTI CONTROLLATI IN FASE ISTRUTTORIA
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px">
                <table width="100%" cellpadding="0" cellspacing="0">
                    
                    <tr id="trNAUploadFile"  >
                        <td>
                            <uc7:SNCUploadFileControl ID="ufcNAAllegato" runat="server" Width="600" Text="Selezionare un documento da caricare" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Breve descrizione: (facoltativa, max 255 caratteri)
                            <br />
                            <Siar:TextArea ID="txtNADescrizioneBreve" runat="server" Width="600px" Rows="2" MaxLength="200" />
                        </td>
                    </tr>
                        <tr>
                        <td align="left" style="height: 60px; padding-left: 40px">
                            <Siar:Button ID="btnSalva" Text="Salva" runat="server" CausesValidation="false" Modifica="true"
                                Width="150px" OnClick="btnSalva_Click" OnClientClick="return ctrlCampi(event);" />
                            &nbsp;&nbsp;
                            <Siar:Button ID="btnElimina" Text="Elimina" runat="server" CausesValidation="false"
                                Modifica="true" Width="150px" OnClick="btnElimina_Click" OnClientClick="return eliminaAllegato(event);" />
                            <input onclick="pulisciCampi();" style="width: 130px; margin-left: 20px" type="button"
                                class="Button" value="Nuovo" />
                        </td>
                    </tr>
                    <tr>
                        <td class="paragrafo">
                            Elenco degli allegati:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="divDimTotAllegati" runat="server" style="position: absolute;
                                line-height: 2em; font-weight: bold"><br /><br />
                            </div>
                            <br />
                            <Siar:DataGrid ID="dgAllegati" runat="server" AutoGenerateColumns="False" Width="100%"
                                AllowPaging="true" PageSize="10">
                                <ItemStyle Height="30px" />
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle Width="25px" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="DescrizioneBreve" HeaderText="Descrizione">
                                        <ItemStyle Width="300px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn  HeaderText="Dim. (Kb)" DataFormatString="{0:N0}">
                                        <ItemStyle HorizontalAlign="Right" Width="60px" />
                                    </asp:BoundColumn>
                                    <Siar:JsButtonColumn Arguments="IdFile" ButtonImage="lente.png" ButtonType="ImageButton"
                                        ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </Siar:JsButtonColumn>
                                    <Siar:JsButtonColumn Arguments="IdProgettoAllegatiIstruttoria" ButtonImage="config.ico" ButtonType="ImageButton"
                                        ButtonText="Visualizza dettaglio" JsFunction="dettaglioAllegato">
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </Siar:JsButtonColumn>
                                </Columns>
                            </Siar:DataGrid>
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <table class="tableNoTab" width="100%">
        <tr>
            <td style="padding-left: 10px">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 400px">
                            <br />
                            Funzionario istruttore assegnato:<br />
                            <Siar:TextBox ID="txtIstruttore" runat="server" Width="350px" ReadOnly="True" />
                        </td>
                        <td>
                            <br /><br />
                            <Siar:Button ID="btnAssegnaRup" runat="server" Modifica="true" OnClick="btnAssegnaRup_Click"
                                    Text="Assegna al Responsabile di misura" Width="250px" />
                        </td>
                        <td>
                            <br />
                            Segnatura del documento interno (ID Paleo):
                            <br />
                            <Siar:TextBox ID="txtSegnatura" runat="server" Width="400px" ReadOnly="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center" style="height: 105px; padding-left: 48px">
                            <a id="lnkFondoPagina"></a>
                            <Siar:Button ID="btnVerifica" runat="server" OnClick="btnVerifica_Click" Text="Verifica dei requisiti"
                                Width="200px" Modifica="true" />&nbsp; &nbsp;<Siar:Button ID="btnPredisponiValutazione" runat="server" OnClick="btnPredisponiValutazione_Click" Text="Predisponi alla valutazione"
                                Width="200px" Modifica="true" />&nbsp; &nbsp;<Siar:Button ID="btnRendiDefinitiva"
                                    runat="server" OnClick="btnRendiDefinitiva_Click" Text="Rendi definitiva" Width="200px"
                                    Modifica="False" Enabled="False" />
                            <Siar:Button ID="btnInserisciSegnatura" runat="server" OnClick="btnInserisciSegnatura_Click"
                                Text="Inserisci Segnatura" Width="200px" Modifica="False" Enabled="False" Visible="false" />
                            &nbsp;&nbsp;
                            <input id="btnPunteggio" runat="server" class="Button" style="width: 200px" type="button"
                                value="Calcola punteggio" />
                            <br />
                            &nbsp;<br />
                            <Siar:Button ID="btnRiapri" runat="server" Width="200px" Text="Riapri Istruttoria"
                                Visible="false" Enabled="false" OnClick="btnRiapri_Click" />&nbsp; &nbsp;
                            <input id="btnBack" class="Button" onclick="location='Ammissibilita.aspx'" style="width: 140px"
                                type="button" value="Indietro" />
                            &nbsp;&nbsp;&nbsp;<input id="btnStampa" runat="server" type="button" class="Button"
                                value="Stampa" style="width: 140px" disabled="disabled" />
                        </td>
                        <td style="width: 48px" valign="bottom">
                            <div style="width: 48px; height: 48px" class="selectable" onclick="location='#lnkInizioPagina'">
                                <img src="../../images/arrow_up_big.png" alt="Inizio pagina" /></div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <uc4:SiarNewZoomPunteggio ID="ucSiarNewZoomPunteggio" runat="server" />
    <uc5:FirmaDocumento ID="ucFirmaAmmissibilita" runat="server" TipoDocumento="ESITO_ISTRUTTORIO"
        Titolo="PAGINA DI FIRMA DELLA CHECKLIST DI AMMISSIBILITA" />
    
    <div id='divPregresso' style="width: 725px; position: absolute; display:none;">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">
                    Dati della segnatura della domanda:
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                           <td style="width: 140px">
								Data:<br />
								<Siar:DateTextBox ID="txtData" runat="server" Width="120px" />
							</td>
							<td style="width: 440px">
								Segnatura:<br />
								<asp:TextBox ID="txtSegnaturaIns" runat="server" Width="400px"  />
								<%--<img id="imgSegnatura" runat="server" height="18" src="../../images/lente.png"
									title="Visualizza documento" width="18" />--%>
							</td>
                        </tr>
                        <tr style="display:none">
                            <td></td>
                            <td>
                                <asp:CheckBox ID="ckAttivo" Text ="Segnatura non disponibile" runat="server" />
                            </td>
                        </tr>
                        <tr > 
                            <td align="right" style="height: 70px; " colspan="2">
                                <Siar:Button ID="btnSalvaSegnatura" runat="server" Modifica="true" OnClick="btnSalvaSegnatura_Click"
                                    Text="Salva" Conferma="Attenzione! Una volta resa definitiva, non sarà più possibile modificare i dati. Continuare?" Width="100px" CausesValidation="False"/>
                                <input class="Button" onclick="chiudiPopupTemplate();" style="width: 100px; margin-left: 20px;
                                    margin-right: 20px" type="button" value="Chiudi" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>     
    <br />
    <uc8:ucVisure ID="ucVisure" runat="server" style="width:inherit"/>
    <br />
    <uc9:Procure ID="ProcureSpeciali" runat="server" />
</asp:Content>
