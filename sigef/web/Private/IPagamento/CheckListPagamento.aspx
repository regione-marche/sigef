<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.CheckListPagamento" CodeBehind="CheckListPagamento.aspx.cs" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento"
    TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/Checklist.ascx" TagName="Checklist" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc4" %>
<%@ Register Src="~/CONTROLS/ucVisualizzaProtocollo.ascx" TagName="ucVisualizzaProtocollo" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function modificaSanzione(codTipo) { $('[id$=hdnModificaSanzione]').val(codTipo);$('[id$=btnModificaSanzionePost]').click(); }
        function sceltaParametroSanzione(id_sanzione,cod_tipo_sanzione,cod_tipo_parametro,td) {
            $('#divSelezioneParametro').ajaxStart(function() { $(this).html("<img src='../../images/ajaxroller.gif' />"); })
    .ajaxError(function() { $(this).css({ "background-color": "fefeee","color": "red","text-align": "center" }).html("ATTENZIONE! SI E' VERIFICATO UN ERRORE NELLA RICHIESTA."); })
    .load("../../CONTROLS/ajaxRequest.aspx",{ "type": "getSelezioneParametroSanzioniPagamento","id_sanzione": id_sanzione,"cod_tipo_sanzione": cod_tipo_sanzione,
        "cod_tipo_parametro": cod_tipo_parametro
    }).show();
            $('[id^=tdSelPar]').css({ 'background-color': 'ede2c3' });$('#'+td).css({ 'background-color': 'fefeee' });
        }
        function selezionaParametro(id_sanzione,cod_tipo_parametro,valore_parametro,descrizione) {
            var codtipo=$('[id$=hdnModificaSanzione]').val();
            $('[id$=hdnValoreParametro'+cod_tipo_parametro+codtipo+']')[0].value=valore_parametro;$('[id$=lblValoreParametro'+cod_tipo_parametro+codtipo+']').text("  "+descrizione);
        }
        function ctrlNuovaSanzione(ev) { if($('[id$=chkNuovaSanzione]:checked').length<1) { alert('Selezionare almeno una sanzione.');return stopEvent(ev); } }
        function mostraEsitoVerificaRendicontazione() { mostraPopupTemplate('divEsitoVerificaRendicontazione', 'divBKGMessaggio'); }
        function DisabilitaLabel() {
            if ($('[id$=ckAttivo]').is(':checked')) {
                $('[id$=txtSegnaturaIns]').attr('readonly', true);
                $('[id$=txtSegnaturaIns]').val('');
            }
            else
                $('[id$=txtSegnaturaIns]').removeAttr('readonly');
        }

        function MostraProtocolloNew(segnatura) {
            $('[id$=hdnSegnatura]').val(segnatura);
            $('[id$=btnMostraProtocollo]').click();
        }
        
//--></script>

    <div style="display: none">
        <asp:Button ID="btnMostraProtocollo" runat="server" OnClick="btnMostraProtocollo_Click" CausesValidation="false" />
        <asp:HiddenField ID="hdnSegnatura" runat="server" />
    </div>

    <br />
    <uc3:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <a id="lnkInizioPagina"></a>
    <br />
    <table class="tableNoTab" width="1200px">
        <tr>
            <td class="separatore_big">
                CHECKLIST DI ISTRUTTORIA DOMANDA DI PAGAMENTO
            </td>
        </tr>
        <tr>
            <td style="height: 68px">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width: 500px; height: 89px">
                            <br />
                            <br />
                            &nbsp;&nbsp;Digitare la <b>segnatura</b> della busta pervenuta contenente gli <b>allegati</b>:<br />
                            <Siar:TextBox runat="server" ID="txtSegnaturaAllegati" MaxLength="80" Width="450px"
                                NomeCampo="Segnatura degli allegati" />
                        </td>
                        <td style="height: 89px">
                            <br />
                            Data certificazione <strong>antimafia
                                <br />
                            </strong>(qualora richiesta dal bando):&nbsp;
                            <br />
                            <Siar:DateTextBox ID="txtDataAntimafia" runat="server" Width="174px" ReadOnly="True" />
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
                <table id="tbLinkVeloci" runat="server" style="table-layout: fixed" width="100%">
                    <tr>
                        <td align="center" style="width: 80px; font-weight: bold">
                            LINK VELOCI:
                        </td>
                        <td style="padding: 3px">
                        </td>
                        <td style="width: 48px;" class="selectable" onclick="location='#lnkFondoPagina'">
                            <img src="../../images/arrow_down_big.png" alt="Fondo pagina" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <uc2:Checklist ID="ucChecklist" runat="server" DefaultRedirect="../PPagamento/GestioneLavori.aspx" />
                <br />
                <table id='tableControlli' runat="server" width="100%" cellpadding="0" cellspacing="0"
                    visible="false">
                    <tr>
                        <td class="separatore">
                            Visite di controllo in azienda:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <table class="tabella" cellspacing="0" border="1" style="width: 100%; border-collapse: collapse;">
                                <tr class="TESTA1">
                                    <td style="width: 25px;">
                                        Nr.
                                    </td>
                                    <td>
                                        Descrizione
                                    </td>
                                    <td>
                                        Obbligatorio
                                    </td>
                                    <td>
                                        Esito Verifica
                                    </td>
                                    <td>
                                        Azione
                                    </td>
                                    <td>
                                        Note
                                    </td>
                                </tr>
                                <tr class="DataGridRow" style="height: 24px;">
                                    <td align="center">
                                        1
                                    </td>
                                    <td style='height: 40px'>
                                        VISITA IN SITU EFFETTUATA
                                    </td>
                                    <td align="center" style="width: 80px;">
                                        SI
                                    </td>
                                    <td align="center" style="width: 100px;">
                                        <Siar:ComboSiNo ID="lstEsitoStep" runat="server" DataColumn="IdStep" NoBlankItem="true">
                                        </Siar:ComboSiNo>
                                    </td>
                                    <td align="center" style="width: 130px;">
                                        <a href="riepilogovisiteaziendali.aspx">Riepilogo visite aziendali</a>
                                    </td>
                                    <td align="center" style="width: 400px;">
                                        <Siar:TextArea ID="txtNoteVisitaInSitu" runat="server" Width="400px" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Dati sanzioni e riduzioni:
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <table id="tableSanzioni" runat="server" width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top" style="width: 700px">
                            <Siar:DataGrid ID="dgSanzioni" runat="server" AutoGenerateColumns="False" CssClass="tabella"
                                PageSize="20" Width="100%">
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="Titolo" HeaderText="Descrizione"></asp:BoundColumn>
                                    <asp:BoundColumn>
                                        <ItemStyle HorizontalAlign="Center" Width="160px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Ammontare" HeaderText="Ammontare" DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="right" Width="120px" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                        <td valign='middle' align="center">
                            <img src="../../images/warning.gif" alt="Avviso di applicazione sanzione" />
                            &nbsp;
                            <br />
                            <br />
                            <strong>La presente domanda di pagamento sarà soggetta a sanzione.</strong>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 700px; height: 49px;" valign="middle">
                            <Siar:Button ID="btnNuovaSanzione" runat="server" Modifica="True" OnClick="btnNuovaSanzione_Click"
                                Text="Nuova sanzione" CausesValidation="False" />
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        </td>
                        <td align="center" style="height: 49px" valign="middle">
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Valutazioni finali:
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px">
                <br />
                Funzionario istruttore assegnato:
                <br />
                <Siar:TextBox ID="txtIstruttore" runat="server" Width="350px" ReadOnly="True" />
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px">
                <br />
                <strong>Valutazione dell`istruttore:</strong> (verrà inclusa nella eventuale successiva
                comunicazione di esito istruttorio)
                <br />
                <Siar:TextArea ID="txtValutazioneLunga" runat="server" Rows="6" Width="850px" />
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 475px">
                            <br />
                            ID del <b>documento interno</b> di Paleo (compare solo se resa definitiva):
                            <br />
                            <Siar:TextBox ID="txtSegnatura" runat="server" Width="400px" ReadOnly="True" />
                            <img id="imgSegnatura" runat="server" height="20" src="../../images/lente.png" width="20"
                                title="Visualizza documento" />
                        </td>
                        <td>
                            <br />
                            ID della <b>checklist revisionata</b> di Paleo (solo se istruttoria non confermata
                            in revisione):
                            <br />
                            <Siar:TextBox ID="txtSegnaturaSeconda" runat="server" Width="400px" ReadOnly="True" />
                            <img id="imgSecondaSegnatura" runat="server" height="20" src="../../images/lente.png"
                                width="20" title="Visualizza documento" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center" style="height: 150px; padding-left: 48px">
                            <p id="pInIntegrazione" runat="server" visible="false"><b>Non è possibile firmare e inviare al protocollo 
                                perchè sono presenti delle richieste integrazioni non risolte.</b>
                            </p>
                            <br />
                            <br />
                            <a id="lnkFondoPagina"></a>
                            <Siar:Button ID="btnVerifica" runat="server" Modifica="True" OnClick="btnVerifica_Click"
                                Text="Verifica requisiti" Width="200px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <Siar:Button ID="btnPredisponiAControllo" runat="server" Modifica="False" OnClick="btnPredisponiAControllo_Click"
                                Text="Predisponi a controllo" Width="200px" Enabled="False" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <Siar:Button ID="btnFirma" runat="server" Modifica="False" OnClick="btnFirma_Click"
                                Text="Firma e invia al protocollo" Width="200px" Enabled="False" />
                            <Siar:Button ID="btnInserisciSegnatura" runat="server" Modifica="False" 
                            Text="Inserisci Segnatura" Width="200px" Enabled="false" OnClick="btnInserisciSegnatura_Click" Visible = "false" />
<%--                            &nbsp; &nbsp; &nbsp;
                            <input id="btnCorrettivaRendicontazione" runat="server" class="Button" style="width: 240px"
                                type="button" value="Correttiva di rendicontazione" onclick="location='IstruttoriaCorrettivaRendicontazione.aspx'" /><br />--%>
                            <br /><br />
                            <input id="btnAmmissibilitaRendicontazione" runat="server" class="Button" style="width: 250px"
                                type="button" value="Vedi esito ammissibilita rendicontazione" onclick="location='Comunicazioni.aspx'"
                                disabled="disabled" visible="False" />&nbsp;<input id="Button1" class="Button" style="width: 200px"
                                    type="button" value="Torna alla gestione lavori" onclick="location='../PPagamento/GestioneLavori.aspx'" />
                            &nbsp;&nbsp;
                            <input id="Button2" class="Button" style="width: 200px" type="button"
                                value="Torna alla selezione domande" onclick="location='SelezioneDomande.aspx'" />&nbsp;
                            &nbsp;
                            <input class="Button" style="width: 240px" type="button" value="Comunicazioni al beneficiario"
                                onclick="location='Comunicazioni.aspx'" />
                            &nbsp;    
                            <input id="btnIntegrazioni" runat="server" class="Button" style="width: 240px" type="button" value="Integrazioni domanda"
                                onclick="location='IstruttoriaIntegrazioniDomandaPagamento.aspx'" />
                            <br />
                        </td>
                        <td style="width: 48px" valign="bottom">
                            <div style="width: 48px; height: 48px" class="selectable" onclick="location='#lnkInizioPagina'">
                                <img src="../../images/arrow_up_big.png" alt="Inizio pagina" /></div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trPredisposizione" runat="server">
            <td>
                <table width="100%">
                    <tr>
                        <td class="separatore_big">
                            Predisposizione alla firma della domanda di pagamento/richiesta di integrazione da parte del Responsabile di Misura:
                        </td>
                    </tr>
                    <tr>
                        <td class="testo_pagina">
                            <b>FACOLTATIVO</b>: la predisposizione alla firma è la modalità di presentazione
                            della domanda di pagamento per i casi di <b>firma differita.</b><br />
                            Ovvero questa modalità prevede il congelamento della domanda in tutte le sue sezioni,
                            quindi non piu&#39; modificabile,
                            <br />
                            in attesa della firma finale da parte del <b>RUP Responsabile di misura</b> , che potrà eseguire<br />
                            il successivo rilascio da una qualsiasi postazione egli abbia a disposizione. Ciò
                            è utile nei casi in cui il firmatario<br />
                            non può essere presente nella stessa sede in cui si trova l&#39;istruttore che compila
                            istruisce la pratica.<br />
                            Tale predisposizione può essere sempre annullata <b>prima del rilascio</b> per eseguire
                            correzioni o adeguamenti finali.
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-bottom: 20px;" valign="top">
                            <Siar:Button ID="btnPredisponi" runat="server" Width="220px" Text="Predisponi alla firma"
                                CausesValidation="false" Conferma="Attenzione! Predisporre la domanda di pagamento alla firma da remoto?"
                                OnClick="btnPredisponi_Click" Modifica="False" Enabled="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div style="display: none">
        <Siar:Button ID="btnModificaSanzionePost" runat="server" CausesValidation="False"
            OnClick="btnModificaSanzionePost_Click" />
        <Siar:Hidden ID="hdnModificaSanzione" runat="server">
        </Siar:Hidden>
    </div>
    <div id='divBackGroundForm' style="position: absolute; display: none; background-color: Gray;
        filter: alpha(opacity=60); opacity: 0.75">
    </div>
    <div id='divNuovaSanzione' style="width: 700px; position: absolute; display: none">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">
                    &nbsp;Lista delle sanzioni:
                </td>
            </tr>
            <tr>
                <td style="padding-left: 5px">
                    <br />
                    - Di seguito vengono elencate tutte le sanzioni che possono essere comminate alla
                    domanda di<br />
                    pagamento in esame, previste dalla misura di appartenenza e dal livello di applicazione
                    delle stesse.<br />
                    Selezionare uno o più elementi a seconda delle violazioni degli impegni riscontrate.
                </td>
            </tr>
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px">
                    <Siar:DataGrid ID="dgNuovaSanzione" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </Siar:NumberColumn>
                            <asp:BoundColumn DataField="Titolo" HeaderText="Descrizione"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Livello" HeaderText="Livello applicazione" DataFormatString="{0:D=Domanda|O=Investimento}">
                                <ItemStyle Width="120px" HorizontalAlign="center" />
                            </asp:BoundColumn>
                            <Siar:CheckColumn DataField="CodTipo" Name="chkNuovaSanzione">
                                <ItemStyle Width="80px" HorizontalAlign="center" />
                            </Siar:CheckColumn>
                        </Columns>
                    </Siar:DataGrid>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 49px">
                    <Siar:Button ID="btnAssegnaSanzioni" runat="server" OnClick="btnAssegnaSanzioni_Click"
                        Text="Assegna sanzioni" Width="181px" Modifica="true" CausesValidation="False"
                        OnClientClick="return ctrlNuovaSanzione(event);" />
                    &nbsp; &nbsp; &nbsp;&nbsp;
                    <input id="btnChiudiSanzione" class="Button" style="width: 105px" type="button" value="Chiudi"
                        onclick="chiudiPopupTemplate()" />
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id='divModificaSanzione' style="width: 700px; position: absolute; display: none">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">
                    &nbsp;Modifica della sanzione:
                </td>
            </tr>
            <tr>
                <td style="padding-left: 5px">
                    &nbsp;<table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="width: 528px">
                                &nbsp;<strong>Descrizione:</strong>
                            </td>
                            <td>
                                <strong>&nbsp;Importo €:</strong>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 528px">
                                <Siar:TextBox ID="txtModificaSanzioneDescrizione" runat="server" ReadOnly="True"
                                    Width="495px" />
                            </td>
                            <td>
                                <Siar:CurrencyBox ID="txtImportoSanzione" runat="server" Width="100px" ReadOnly="True" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 5px">
                    <br />
                    <strong>&nbsp;Motivazione:</strong><br />
                    <Siar:TextArea ID="txtModificaSanzioneMotivazioni" runat="server" Rows="4" Width="630px" />
                    <br />
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="paragrafo" style="padding-left: 5px">
                    Selezione dei parametri:
                </td>
            </tr>
            <tr>
                <td style="padding: 5px">
                    <Siar:DataGrid ID="dgModificaSanzione" runat="server" AutoGenerateColumns="False"
                        Width="100%">
                        <Columns>
                            <asp:BoundColumn HeaderText="Entit&#224;">
                                <ItemStyle HorizontalAlign="Center" Width="230px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Gravit&#224;">
                                <ItemStyle HorizontalAlign="Center" Width="230px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Durata">
                                <ItemStyle HorizontalAlign="Center" Width="230px" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGrid>
                </td>
            </tr>
            <tr>
                <td style="padding: 5px">
                    <div id='divSelezioneParametro' style="width: 100%; display: none">
                    </div>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 49px">
                    <Siar:Button ID="btnCalcolaSanzione" runat="server" Text="Calcola sanzione" Width="180px"
                        Modifica="true" CausesValidation="False" OnClick="btnCalcolaSanzione_Click" />
                    &nbsp; &nbsp;&nbsp;
                    <Siar:Button ID="btnEliminaSanzione" runat="server" Text="Elimina sanzione" Width="145px"
                        Modifica="true" CausesValidation="False" OnClick="btnEliminaSanzione_Click" Conferma="Attenzione! Eliminare la sanzione?" />
                    &nbsp; &nbsp;<input id="Button5" class="Button" style="width: 105px" type="button"
                        value="Chiudi" onclick="chiudiPopupTemplate()" />
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id='divEsitoVerificaRendicontazione' style="width: 700px; position: absolute;
        display: none">
        <table width="100%" class="tableNoTab">
            <tr>
                <td class="separatore">
                    &nbsp;Esito della verifica finale degli importi rendicontati:
                </td>
            </tr>
            <tr>
                <td style="padding-left: 5px">
                    <br />
                    - Di seguito viene visualizzato l`esito della verifica finale compiuta dal beneficiario.<br />
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding-left: 5px">
                    <table style="width: 100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 229px">
                                <b>&nbsp; Esito:</b><br />
                                &nbsp;<Siar:TextBox ID="txtEsito" runat="server" Width="171px" />
                            </td>
                            <td>
                                <b>&nbsp;Data esecuzione:</b><br />
                                <Siar:DateTextBox ID="txtEsitoData" runat="server" Width="140px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 5px">
                    <br />
                    <b>&nbsp; Elementi di dettaglio:<br />
                        &nbsp;</b><Siar:TextArea ID="txtEsitoDettaglioLunga" runat="server" Rows="15" Width="660px" />
                    <br />
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding-right: 30px; height: 47px;" align="right">
                    <input id="Button4" class="Button" style="width: 160px" type="button" value="Chiudi"
                        onclick="chiudiPopupTemplate()" />
                </td>
            </tr>
        </table>
    </div>
    
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
<%--								<img id="img1" runat="server" height="18" src="../../images/lente.png"
									title="Visualizza documento" width="18" onclick="VisualizzaProt();" />--%>
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
    
    <uc4:FirmaDocumento ID="ucFirmaDocumento" runat="server" Titolo="PAGINA DI FIRMA DELLA CHECKLIST DI PAGAMENTO"
        DoppiaFirma="true" TipoDocumento="CKL_PAGAMENTO" />
    <uc1:ucVisualizzaProtocollo ID="modaleMostraProtocollo" runat="server" />
</asp:Content>
