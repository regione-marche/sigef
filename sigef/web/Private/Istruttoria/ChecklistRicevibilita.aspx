<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    EnableViewState="true" Inherits="web.Private.Istruttoria.ChecklistRicevibilita"
    CodeBehind="ChecklistRicevibilita.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/ChecklistNew.ascx" TagName="ChecklistNew" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc4" %>
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
</script>

    <br />
    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <br />
    <table class="tableNoTab" width="1200px">
        <tr>
            <td class="separatore_big">
                CHECKLIST ISTRUTTORIA DI RICEVIBILITA` DELLA DOMANDA DI AIUTO
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 320px">
                            Funzionario istruttore assegnato:<br />
                            <Siar:TextBox runat="server" ID="txtIstruttore" MaxLength="80" Width="275px" ReadOnly="true" />
                        </td>
                        <td>
                            Segnatura della busta chiusa contenente gli <b>allegati</b> alla domanda:<br />
                            <Siar:TextBox runat="server" ID="txtSegnatura" MaxLength="80" Width="450px" ReadOnly="true" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Elenco degli step di controllo:
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <uc3:ChecklistNew ID="ucChecklist" runat="server" Fase="R" DefaultRedirect="~/Private/Istruttoria/Ricevibilita.aspx" />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 115px">
                <Siar:Button ID="btnVerifica" runat="server" OnClick="btnVerifica_Click" Text="Verifica dei requisiti"
                    Width="200px" Modifica="true" />&nbsp;&nbsp; &nbsp;
                <Siar:Button ID="btnRendiDefinitiva" runat="server" OnClick="btnRendiDefinitiva_Click"
                    Text="Rendi definitiva" Width="200px" Modifica="False" Enabled="False" />
                <Siar:Button ID="btnInserisciSegnatura" runat="server" OnClick="btnInserisciSegnatura_Click"
                    Text="Inserisci Segnatura" Width="200px" Modifica="False" Enabled="False" Visible="false" />
                &nbsp;&nbsp; &nbsp;
                <input id="btnAmmissibilita" runat="server" type="button" class="Button" value="Vai alla ammissibilita della domanda"
                    style="width: 266px" /><br />
                <br />
                <input id="btnBack" type="button" class="Button" value="Indietro" style="width: 140px"
                    onclick="location='Ricevibilita.aspx'" />&nbsp;&nbsp;
                <input id="btnStampa" runat="server" type="button" class="Button" value="Stampa"
                    style="width: 140px" disabled="disabled" />
            </td>
        </tr>
    </table>
    <uc4:FirmaDocumento ID="ucFirmaRicevibilita" TipoDocumento="CHECKLIST" Titolo="PAGINA DI FIRMA DELLA CHECKLIST DI RICEVIBILITA"
        runat="server" />

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
        
</asp:Content>
