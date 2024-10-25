<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IVariante.Comunicazioni" CodeBehind="Comunicazioni.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/IVariantiControl.ascx" TagName="IVariantiControl"
    TagPrefix="uc1" %>
<%@ Register Src="../../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function chkSegnatura(e) { if ($('[id$=txtSegnaturaRiesame]').val() == '') { alert('Digitare la segnatura della richiesta.'); stopEvent(e); } }

        function ctrlCampiRicercaNormeMarche(ev) { if ($('[id$=txtAttoNumero_text]').val() == "" || $('[id$=txtAttoData_text]').val() == "" || $('[id$=lstAttoRegistro]').val() == "") { alert('Per la ricerca degli atti è necessario specificare numero, data e registro.'); return stopEvent(ev); } }

        function ctrlTipoAtto(ev) {
            if ($('[id$=hdnIdAtto]').val() == "") { alert('Per proseguire è necessario specificare un atto.'); return stopEvent(ev); }
            else if ($('[id$=lstAttoTipo]').val() == "") { alert('Per proseguire è necessario specificare la tipologia dell`atto.'); return stopEvent(ev); }
            if (!confirm("Si sta per inserire il decreto di pagamento per la domanda selezionata. Continuare?")) return stopEvent(ev);
        }
        function ctrlTipoAttoOrg(ev) {
            if (($('[id$=txtLinkEst]').val() == "") || ($('[id$=txtLinkEst]').val() == "") || ($('[id$=txtLinkEst]').val() == "") || ($('[id$=txtLinkEst]').val() == "")) { alert('Per proseguire è necessario inserire tutti i dati dell atto.'); return stopEvent(ev); }
            if (!confirm("Si sta per inserire il decreto di pagamento per la domanda selezionata. Continuare?")) return stopEvent(ev);
        }
        function visualizzaAttoOrg(link) {
            window.open(link, "_blank");
        }
</script>
    <div style="display: none">
        <asp:HiddenField ID="hdnIdAtto" runat="server" />
    </div>
    <uc1:IVariantiControl ID="ucIVariantiControl" runat="server" />
    &nbsp;
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore">
                &nbsp;COMUNICAZIONI DA/AL BENEFICIARIO:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="paragrafo">Dati Decreto: </td>
        </tr>    
        <tr runat="server" id="trDecreto"> 
            <td>
                <table width="100%">
                    <tr>
                        <td  style="padding: 10px">
                            <table width="100%">
                                <tr>
                                    <td align="center" style="width: 100px">
                                        Definizione:<br />
                                        <Siar:ComboDefinizioneAtto ID="lstAttoDefinizione" runat="server" NoBlankItem="True" Width="80px">
                                        </Siar:ComboDefinizioneAtto>
                                    </td>
                                    <td align="center" style="width: 100px">
                                        Numero:<br />
                                        <Siar:IntegerTextBox NoCurrency="True" ID="txtAttoNumero" runat="server" Width="80px" NomeCampo="Numero decreto" />
                                    </td>
                                    <td align="center" style="width: 100px">
                                        Data:<br />
                                        <Siar:DateTextBox ID="txtAttoData" runat="server" Width="100px" NomeCampo="Data decreto" />
                                    </td>
                                    <td align="center" style="width: 100px">
                                        Registro:<br />
                                        <Siar:ComboRegistriAtto ID="lstAttoRegistro" runat="server" Width="100px">
                                        </Siar:ComboRegistriAtto>
                                    </td>
                                    <td align="center">
                                        <br />
                                        <Siar:Button ID="btnCercaDecreto" runat="server" OnClick="btnCercaDecreto_Click"
                                            Text="Ricerca" Width="109px" OnClientClick="return ctrlCampiRicercaNormeMarche(event);" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-left: 10px" colspan="5">
                                        <table style="width: 100%">
                                            <tr>
                                                <td align="center">
                                                    Descrizione:<br />
                                                    <Siar:TextArea ID="txtAttoDescrizione" runat="server" Width="600px" ReadOnly="True"
                                                        Rows="4" ExpandableRows="5"></Siar:TextArea>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <br />
                                                                <input id="btnVidualizzaDecreto" runat="server" class="Button" style="width: 130px;
                                                                    margin-left: 30px; margin-right: 20px" type="button" disabled="disabled" value="Visualizza atto" />
                                                                <Siar:Button ID="btnAssociaDecreto" runat="server" OnClick="btnAssociaDecreto_Click"
                                                                    Text="Associa decreto" Width="140px" OnClientClick="return ctrlTipoAtto(event);" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr runat="server" id="trDecretoOrg"> 
            <td>
                <table width="100%">
                    <tr>
                        <td  style="padding: 10px">
                            <table width="100%">
                                <tr>
                                    <td class="testo_pagina">
                                        Inserire tutti i dati relativi al decreto/atto ed il link dello stesso presente
                                        nel proprio albo pretorio.
                                    </td>
                                </tr>
                            </table>
                            <table width="100%">
                                <tr >
                                    <td  align="left" style="padding-left: 30px"> 
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 160px">
                                                    Data:<br /> 
								                    <Siar:DateTextBox ID="txtDataDecretoOrg" runat="server" Width="120px" />							</td> 
                                                <td style="width: 160px"> 
								                    Numero:<br /> 
								                    <Siar:IntegerTextBox  NoCurrency="True" ID="txtNumeroDecretoOrg" runat="server" Width="120px" /> 
							                    </td> 
                                                <td style="width: 130px"> 
							                    </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td align="left" style="padding-left: 30px">
                                        <table style="width: 100%">
                                            <tr>
                                                <td >
                                                    Descrizione/titolo:<br /> 
								                    <Siar:TextArea Rows="3" MaxLength="3000" ID="txtDescrizioneDecretoOrg" runat="server" Width="630px"  /> 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Link Esterno:<br /> 
								                    <asp:TextBox CssClass="rounded" ID="txtLinkEst" runat="server" Width="630px"  /> 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <br />
                                                                <input id="btnVisualizzaAttoOrg" runat="server" class="Button" style="width: 130px;
                                                                    margin-left: 30px; margin-right: 20px" type="button" disabled="disabled" value="Visualizza atto" />
                                                                <Siar:Button ID="Button3" runat="server" OnClick="btnAssociaDecretoOrg_Click"
                                                                    Text="Associa decreto" Width="140px" OnClientClick="return ctrlTipoAttoOrg(event);" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
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
            <td class="paragrafo">
                &nbsp;Comunicazione di esito istruttorio:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;Segnatura di protocollo:
                <br />
                <Siar:TextBox  ID="txtSegnaturaComunicazione" runat="server" MaxLength="100" Width="516px"
                    ReadOnly="True" />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 80px">
                <Siar:Button ID="btnFirmaComunicazione" runat="server" CausesValidation="False" OnClick="btnFirmaComunicazione_Click"
                    Text="Firma Comunicazione" Width="200px" Enabled="False"></Siar:Button>&nbsp;&nbsp;
                <Siar:Button ID="btnStampaComunicazione" runat="server" CausesValidation="False"
                    OnClick="btnStampaComunicazione_Click" Text="Stampa Comunicazione" Width="200px"
                    Enabled="False"></Siar:Button>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;Richiesta di riesame Variante/Variazione Finanziaria/A.T.:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <table width="100%">
                    <tr>
                        <td style="width: 407px">
                            &nbsp;Digitare la segnatura di protocollo della richiesta:
                        </td>
                        <td>
                            &nbsp;Motivazione:
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 407px" valign="top">
                            <Siar:TextBox  ID="txtSegnaturaRiesame" runat="server" Width="376px" />
                            &nbsp;<br />
                            <br />
                            &nbsp;Richiesta: &nbsp;<strong><asp:Label ID="lblEsitoRiesame" runat="server"></asp:Label></strong>
                        </td>
                        <td valign="top">
                            <Siar:TextArea ID="txtMotivazioneRiesame" runat="server" Rows="5" Width="450px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 407px">
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 80px">
                &nbsp;&nbsp;
                <Siar:Button ID="btnAccettaRiesame" runat="server" Modifica="False" Text="Ammetti la richiesta"
                    Width="200px" OnClick="btnAmmettiRiesame_Click" CausesValidation="false" OnClientClick="chkSegnatura(event);" />
                &nbsp; &nbsp;
                <Siar:Button ID="btnRifiutaRiesame" runat="server" Modifica="False" Text="Rifiuta la richiesta"
                    Width="200px" OnClick="btnRifiutaRiesame_Click" CausesValidation="false" OnClientClick="chkSegnatura(event);" />
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;Annullamento della richiesta di Variante/Variazione Finanziaria/A.T. presentata:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<br />
                &nbsp;&nbsp; Questa procedura fa seguito ad una <strong>richiesta </strong>del beneficiario,
                occorre quindi digitare la segnatura relativa.<br />
                &nbsp;&nbsp; E` possibile annullare la presente variante/variazione finanziaria/a.t. solo se <strong>non
                
                            
                
                </strong>ancora<strong> istruita </strong>dal funzionario assegnato.
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 123px">
                Segnatura della richiesta di annullamento:<br />
                <Siar:TextBox  ID="txtSegnaturaAnnullamento" runat="server" MaxLength="100" NomeCampo="Segnatura della richiesta"
                    Obbligatorio="True" Width="516px" />
                <br />
                &nbsp;<br />
                <Siar:Button ID="btnAnnullamento" runat="server" Modifica="True" Text="Annulla la Variante/Variazione/A.T."
                    Width="250px" Conferma="Attenzione! La richiesta verrà annullata e non sarà più possibile il ripristino. Continuare?"
                    OnClick="btnAnnullamento_Click" />
            </td>
        </tr>
    </table>
    <uc2:FirmaDocumento ID="ucFirmaDocumento" runat="server" TipoDocumento="COMUNICAZIONE_VARIANTE"
        Titolo="COMUNICAZIONE DI ESITO ISTRUTTORIO DELLA VARIANTE/A.T." />
</asp:Content>
