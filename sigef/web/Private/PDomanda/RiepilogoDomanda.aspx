<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.RiepilogoDomanda" CodeBehind="RiepilogoDomanda.aspx.cs" %>

<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/FirmaDocumentoEsterna.ascx" TagName="ucFirmaEsternaAruba" TagPrefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function presentazione_warnings(messaggio) { if(confirm(messaggio)) $('[id$=btnPresentaPost]').click(); }
        function predisposizione_warnings(messaggio) { if (confirm(messaggio)) $('[id$=btnPredisponiPost]').click(); }
        function presentazione_warningsPregresso(messaggio) { if (confirm(messaggio)) $('[id$=btnInserisciSegnaturaPost]').click(); }
        function DisabilitaLabel() {
            if ($('[id$=ckAttivo]').is(':checked')) {
                $('[id$=txtSegnatura]').attr('readonly', true);
                $('[id$=txtSegnatura]').val('');

            }
            else
                $('[id$=txtSegnatura]').removeAttr('readonly');
        }

//--></script>

    <table class="tableTab" width="800">
        <tr>
            <td align="center">
                <input id="btnPrev" class="ButtonProsegui" onclick="location='BusinessPlan.aspx'"
                    type="button" value="<<< (6/7)" runat="server"/>
                <input id="btnCurrent" class="ButtonProsegui BPDisabled" style="width: 40px" disabled="disabled"
                    type="button" value="(7/7)" runat="server"/>
                <input id="btnGo" class="ButtonProsegui" style="visibility: hidden" type="button"
                    value=" " />
            </td>
        </tr>
    </table>
    <br />
    <table class="tableNoTab" width="800px">
        <tr>
            <td class="separatore_big">
                PAGINA DI PRESENTAZIONE DELLA DOMANDA DI AIUTO
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Elenco delle sezioni da compilare ai fini del rilascio della domanda:
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dg" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                    Width="100%">
                    <ItemStyle Height="40px" />
                    <Columns>
                        <Siar:ColonnaLink DataField="Descrizione" IsJavascript="false" LinkFields="Url" LinkFormat="{0}">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:ColonnaLink>
                    </Columns>
                </Siar:DataGrid>
                <br />
            </td>
        </tr>
        <tr id="trPredisposizione" runat="server">
            <td>
                <table width="100%">
                    <tr>
                        <td class="separatore">
                            Predisposizione alla firma della domanda:
                        </td>
                    </tr>
                    <tr>
                        <td class="testo_pagina">
                            <b>FACOLTATIVO</b>: la predisposizione alla firma è la modalità di presentazione
                            della domanda di aiuto per i casi di <b>firma differita.</b><br />
                            Ovvero questa modalità prevede il congelamento della domanda in tutte le sue sezioni,
                            quindi non piu&#39; modificabile,
                            <br />
                            in attesa della firma finale da parte del <b>rappresentante legale</b> dell&#39;impresa
                            o di altro soggetto titolato, che potrà eseguire<br />
                            il successivo rilascio da una qualsiasi postazione egli abbia a disposizione. Ciò
                            è utile nei casi in cui il firmatario<br />
                            non può essere presente nella stessa sede in cui si trova l&#39;operatore che compila
                            la domanda.<br />
                            Tale predisposizione può essere sempre annullata <b>prima del rilascio</b> per eseguire
                            correzioni o adeguamenti finali.
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-bottom: 20px;" valign="top">
                            <input type="button" class="Button" style="width: 220px; margin-right: 40px" value="Test della firma digitale"
                                onclick="window.open('https://sigef.regione.marche.it/Public/Download/TestFirmaDigitale.html');" /><Siar:Button
                                    ID="btnPredisponi" runat="server" Width="220px" Text="Predisponi alla firma"
                                    CausesValidation="false" Conferma="Attenzione! Predisporre la domanda di aiuto alla firma da remoto?"
                                    OnClick="btnPredisponi_Click" Modifica="False" Enabled="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Presentazione della domanda:
            </td>
        </tr>
        <tr id="trPulsanti" runat="server">
            <td align="center" style="padding: 30px">
                <Siar:Button ID="btnPresenta" runat="server" Width="220px" Text="Presenta domanda"
                    CausesValidation="true" Conferma="Attenzione! Una volta resa definitiva, non sarà più possibile modificare i dati della domanda di aiuto. Continuare?"
                    OnClick="btnPresenta_Click" Modifica="False" Enabled="False" />
                <Siar:Button ID="btnFirmaEsterna" runat="server" CausesValidation="False" AdditionalStyles="margin-left: 25px;"
                    Text="Scarica e presenta domanda con firma esterna" Enabled="false" OnClick="btnFirmaEsterna_Click" 
                    Modifica="True" />
                <input id="btnRicevuta" runat="server" type="button" class="Button" disabled="disabled"
                    value="Ricevuta di protocollazione" style="width: 220px; margin-left: 40px" />
            </td>
        </tr>
            <tr id="rowProtocolliAllegati" runat="server" visible="false">
                <td align="center" style="height: 66px">
                    <Siar:Button ID="btnProtocollaAllegati" runat="server" CausesValidation="False" Width="210px"
                        Text="Protocolla allegati" Enabled="false" OnClick="btnProtocollaAllegati_Click"
                        Modifica="True" />
                </td>
            </tr>
        
        <tr id="trPulsantiPregresso" visible="false" runat="server">
            <td align="center" style="padding: 30px">
                <Siar:Button ID="btnInserisciSegnatura" runat="server" Width="220px" Text="Inserisci Segnatura"
                    CausesValidation="true" 
                    OnClick="btnInserisciSegnatura_Click" Modifica="False" Enabled="False" />
            </td>
        </tr>
    </table>
    <div style="display: none">
        <asp:HiddenField ID="hidSourceID" runat="server" />
        <asp:Button ID="btnPresentaPost" runat="server" OnClick="btnPresentaPost_Click" />
        <asp:Button ID="btnPredisponiPost" runat="server" OnClick="btnPredisponiPost_Click" />
        <asp:Button ID="btnInserisciSegnaturaPost" runat="server" OnClick="btnInserisciSegnaturaPost_Click" />
    </div>
    <uc1:FirmaDocumento ID="ucFirmaDocumento" runat="server" TitoloControllo="FIRMA DIGITALE DELLA DOMANDA DI AIUTO"
        TipoDocumento="PDOMANDA" />
    <uc5:ucFirmaEsternaAruba ID="modaleFirmaEsterna" runat="server" TitoloControllo="FIRMA DIGITALE ESTERNA DELLA DOMANDA DI AIUTO" TipoDocumento="PDOMANDA" />
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
								<asp:TextBox ID="txtSegnatura" runat="server" Width="400px"  />
								<%--<img id="imgSegnatura" runat="server" height="18" src="../../images/lente.png"
									title="Visualizza documento" width="18" />--%>
							</td>
                        </tr>
                        <tr  style="display:none">
                            <td></td>
                            <td>
                                <asp:CheckBox ID="ckAttivo" Text ="Segnatura non disponibile" runat="server" />
                            </td>
                        </tr>
                        <tr > 
                            <td align="right" style="height: 70px; " colspan="2">
                                <Siar:Button ID="btnSalvaSegnatura" runat="server" Modifica="true" OnClick="btnSalvaSegnatura_Click"
                                    Text="Salva" Conferma="Attenzione! Una volta resa definitiva, non sarà più possibile modificare i dati della domanda di aiuto. Continuare?" Width="100px" CausesValidation="False"/>
                                <input class="Button" onclick="chiudiPopupTemplate();" style="width: 100px; margin-left: 20px;
                                    margin-right: 20px" type="button" value="Chiudi" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
