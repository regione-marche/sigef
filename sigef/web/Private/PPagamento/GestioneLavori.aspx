<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.GestioneLavori" CodeBehind="GestioneLavori.aspx.cs" %>
    
<%@ Register Src="../../CONTROLS/SNCVisualizzaProtocollo.ascx" TagName="SNCVisualizzaProtocollo" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/ucGestioneLavori.ascx" TagName="GestioneLavori" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc3" %>
<%@ Register Src="~/CONTROLS/ucProcureSpeciali.ascx" TagName="Procure" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function nsc_post(codice) {
        $('[id$=hdnTipoPagamento]').val(codice);
        $('[id$=btnPost]').click();
    }

    function visualizzaIntegrazioniRichieste(id_domanda) {
    }

    function selezionaModifica(idModifica) {
        $('[id$=hdnIdModifica]').val($('[id$=hdnIdModifica]').val() == idModifica ? '' : idModifica);
        $('[id$=btnVisualizzaModifica]').click();
    }

    function selezionaAtto(Atto) {
        $('[id$=hdnIdAttoDefinizione]').val(Atto);
        $('[id$=btnSelezionaAtto]').click();
    }

    function selezionaDecertificazione(idCertDecertificazione) {
        $('[id$=hdnIdCertDecert]').val($('[id$=hdnIdCertDecert]').val() == idCertDecertificazione ? '' : idCertDecertificazione);
        $('[id$=btnVisualizzaIrregolarita]').click();
    }

    function validaDatiAtto(event) {
        var messaggio_errore = '';
        if ($('[id$=txtCfFornitore]').val() == '') messaggio_errore += "\n- Indicare il fornitore dell'affidamento.\n";
        if ($('[id$=txtNumero]').val() == '') messaggio_errore += "\n- Indicare il numero dell'affidamento.\n";
        if ($('[id$=txtData]').val() == '') messaggio_errore += "\n- Indicare la data dell'affidamento.\n";
        if ($('[id$=txtNewImporto]').val() == '') messaggio_errore += "\n- Indicare l'importo dell'affidamento.\n";

        if (messaggio_errore != '') {
            alert(messaggio_errore);
            return stopEvent(event);
        }
        ctrlCF();
    }

    function NuovoAtto(event) {
        $('[id$=txtCfFornitore]').val('');
        $('[id$=txtNumero]').val('');
        $('[id$=txtData]').val('');
        $('[id$=txtNewImporto]').val('');
        $('[id$=hdnIdAttoDefinizione]').val('');
    }

    function ctrlCF() { var cf = $('[id$=txtCfFornitore]').val(); if (cf != "" && !ctrlCodiceFiscale(cf) && !ctrlPIVA(cf)) { alert('Attenzione! Codice fiscale/P.Iva formalmente non corretto.'); return stopEvent(event) } }

    function ctrlCampi(ev) {
        if ($('input[type=hidden][id*=ufcNAAllegato]').val() == '') { alert('Per la categoria di allegato selezionata si richiede di carica il documento digitale .'); return stopEvent(ev); }

    }

    function eliminaAllegato(ev) { if ($('[id$=hdnIdProgettoAttiAffidamentoAllegato]').val() == '') { alert('Non è stato selezionato nessun allegato da eliminare.'); return stopEvent(ev); } if (!confirm('Attenzione! Eliminare l`allegato selezionato?')) return stopEvent(ev); }

    function pulisciCampi() { $('[id$=hdnIdProgettoAttiAffidamentoAllegato]').val(''); $('[id$=txtNADescrizioneBreve]').val(''); $('[id$=btnNuovoPost]').click(); /*debugger;SNCUFRimuoviFile('ctl00_cphContenuto_ufcNAAllegato');*/ }

    function dettaglioAllegato(idaxp) { $('[id$=hdnIdProgettoAttiAffidamentoAllegato]').val(idaxp); $('[id$=btnIdProgettoAttiAffidamentoAllegato]').click(); }

//--></script>

    <style type="text/css">
        .paragrafo_light {
            border-bottom: solid 1px #084600;
            font-size: 14px;
        }
    </style>   

    <div style="display: none">
        <input type="hidden" id="hdnIdProgettoAttiAffidamentoAllegato" runat="server" />
        <asp:HiddenField ID="hdnIdAttoDefinizione" runat="server" />  
        <asp:Button ID="btnSelezionaAtto" runat="server" OnClick="btnSelezionaAtto_Click" />
        <asp:Button ID="btnNuovoPost" runat="server" OnClick="btnNuovoPost_Click" />
		
		<asp:HiddenField ID="hdnIdModifica" runat="server" />
        <asp:Button ID="btnVisualizzaModifica" runat="server" OnClick="btnVisualizzaModifica_Click" CausesValidation="false" />

        <asp:HiddenField ID="hdnIdCertDecert" runat="server" />
        <asp:Button ID="btnVisualizzaIrregolarita" runat="server" OnClick="btnVisualizzaIrregolarita_Click" CausesValidation="false" />
        <asp:Button ID="btnIdProgettoAttiAffidamentoAllegato" runat="server" OnClick="btnIdProgettoAttiAffidamentoAllegato_Click" CausesValidation="false" />
    </div>

    <uc1:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <br />
    <table class="tableNoTab" width="1050px">
        <tr>
            <td class="separatore_big">
                PAGINA DI GESTIONE LAVORI DELLA DOMANDA DI AIUTO
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="testo_pagina" style="width: 629px">
                            Di seguito vengono elencate, in ordine cronologico crescente, tutte le modalita
                            di pagamento che è possibile<br />
                            richiedere a contributo e le richieste già effettuate per la domanda di aiuto selezionata,
                            inoltre viene visualizzato<br />
                            anche lo stato di avanzamento dell'istruttoria con contributo ammesso per ognuna
                            di tali richieste di pagamento.<br />
                            Gli operatori abiltati all'inserimento e alla modifica delle domande di pagamento
                            devono essere in possesso del<br />
                            mandato dell'impresa beneficiaria della domanda di aiuto.
                        </td>
                        <td>
                            <table width="100%" style="display: none">
                                <tr>
                                    <td class="separatore">
                                        Attestazione di avvio lavori
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <input id="btnAvvioLavori" runat="server" style="width: 200px" type="button" value="Visualizza attestazione"
                                               class="Button" onclick="location = 'comavviolavori.aspx'" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--<tr>
            <td class="separatore">
                Elenco delle domande di pagamento:
            </td>
        </tr>--%>
        <tr>
            <td>
                <br />
                <%--<Siar:DataGrid ID="dg" runat="server" Width="100%" AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <asp:BoundColumn HeaderText="Richiesto">
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Id" DataField="IdDomandaPagamento">
                            <ItemStyle HorizontalAlign="center" Width="40px" Font-Bold="true" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Modalità di pagamento" DataField="Descrizione">
                            <ItemStyle HorizontalAlign="center" Width="140px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText=" ">
                            <ItemStyle HorizontalAlign="center" Width="190px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo richiesto" DataField="ImportoRichiesto" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo richiesto" DataField="ContributoRichiesto" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Domanda pagamento" >
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Istruita">
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText=" ">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo ammesso" DataField="ImportoAmmesso" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo ammesso (*)" DataField="ContributoAmmesso" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
                <div style="width: 100%; text-align: right">
                    (<font style="text-decoration: line-through; font-weight: bold; color: #bc3333">in rosso</font>
                    le domande di pagamento non approvate)
                    <br />
                    (*=importo calcolato al netto delle sanzioni e del recupero anticipo percepito)
                    <br />
                    (** = contributo troncato per superamento massimali di domanda)
                </div>--%>
                &nbsp;
                <div style="display: none">
                    <asp:Button ID="btnPost" runat="server" CausesValidation="False" OnClick="btnPost_Click" />
                    <asp:HiddenField ID="hdnTipoPagamento" runat="server" />
                    &nbsp;
                </div>
                <uc2:GestioneLavori ID="ucGestioneLavori" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Elenco delle richieste di modifica al piano degli investimenti:
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td style="width: 612px" class="testo_pagina">
                            Di seguito vengono listate, in ordine cronologico crescente, &nbsp;tutte le richieste
                            di modifica
                            <br />
                            al piano degli investimenti della &nbsp;domanda di aiuto in questione.<br />
                        Non e' possibile richiedere una variante/variazione finanziaria se sono presenti domande da rilasciare o ancora da istruire.
                            <br />
                            <div style="visibility: hidden;">
                                E' possibile richiedere (in generale) massimo <strong>n.2 &nbsp;varianti/variazioni finanziarie</strong>
                                ma piu' <strong>adeguamenti tecnici</strong>.<br />
                                Gli operatori abiltati all'inserimento e alla modifica delle domande di varianti/variazioni finanziarie
                                devono essere
                                <br />
                                in possesso del mandato dell'impresa&nbsp; beneficiaria della domanda di aiuto.
                            </div>
                        </td>
                        <td>
                            <table width="100%" class="tableNoTab">
                                <tr>
                                    <td class="separatore">
                                        Nuova richiesta:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 46px; padding: 10px">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 240px">
                                                    <b>Modalità:</b><br />
                                                    <Siar:ComboBase ID="lstModalita" runat="server" NomeCampo="Modalita" >
                                                    </Siar:ComboBase>
                                                </td>
                                                <td>
                                                    <br />
                                                    <Siar:Button ID="btnNuovaVariante" runat="server" Modifica="True" OnClick="btnNuovaVariante_Click"
                                                        Text="Richiedi" Width="100px" />
                                                </td>
                                            </tr>
                                        </table>
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
                <Siar:DataGrid ID="dgVarianti" runat="server" Width="100%" AutoGenerateColumns="False">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Data" DataField="DataModifica">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Modalita e descrizione tecnica"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Operatore">
                            <ItemStyle Width="180px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Istruita">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Approvata" DataField="Approvata" DataFormatString="{0:SI|NO}">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Operatore di istruttoria" DataField="NominativoIstruttore">
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText=" ">
                            <ItemStyle HorizontalAlign="Center" Width="160px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="right">
                (
                <img src="../../images/soggetto.ico" alt="Variante/variazione finanziaria con richiesta di cambio beneficiario" />
                = variante/variazione finanziaria con richiesta di cambio beneficiario)
            </td>
        </tr>        
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <div id="divGestioneControlliInLoco" runat="server" visible ="false">
            <tr>
                <td class="separatore">Elenco dei controlli in loco in cui è stata selezionata la domanda di contributo:
                </td>
            </tr>
            <tr>
                <td>
                    <div id="divTestaLoco" class="dContenuto" runat="server" visible="false">
                        <Siar:DataGrid ID="dgTestaLoco" runat="server" AutoGenerateColumns="false" Width="100%">
                            <ItemStyle Height="24px" />
                            <Columns>
                                <asp:BoundColumn DataField="IdLoco" HeaderText="Id Loco"></asp:BoundColumn>
                                <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Id Dom. Pagamento"></asp:BoundColumn>
                                <asp:BoundColumn DataField="DataSopralluogo" HeaderText="Data"></asp:BoundColumn>
                                <asp:BoundColumn DataField="ImportoAmmessoLoco" HeaderText="Importo ammesso" DataFormatString="{0:c}"></asp:BoundColumn>
                                <asp:BoundColumn DataField="ContributoAmmessoLoco" HeaderText="Contributo ammesso" DataFormatString="{0:c}"></asp:BoundColumn>
                                <asp:BoundColumn DataField="EsitoChecklist" HeaderText="Esito checklist"></asp:BoundColumn>
                            </Columns>
                        </Siar:DataGrid>
                    </div>
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
        </div>
        <br />
        <div id="divGestioneCertificazione" runat="server" visible="false">
            <tr>
                <td class="separatore">Elenco delle certificazioni di spesa in cui è presente la domanda di contributo:
                </td>
            </tr>
            <tr>
                <td>
                    <!-- Lotti -->
                    <div id="divTestaElenco" class="dContenuto" runat="server" visible="false">
                        <Siar:DataGrid ID="dgTesta" runat="server" AutoGenerateColumns="false" Width="100%">
                            <ItemStyle Height="24px" />
                            <Columns>
                                <%--<asp:BoundColumn DataField="CodPsr" HeaderText="Programma"></asp:BoundColumn>--%>
                                <asp:BoundColumn DataField="Idcertsp" HeaderText="Id Lotto"></asp:BoundColumn>
                                <asp:BoundColumn DataField="DataFine" HeaderText="Data Inizio"></asp:BoundColumn>
                                <asp:BoundColumn DataField="DataFine" HeaderText="Data Fine"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Tipo" HeaderText="Tipo"></asp:BoundColumn>
                                <asp:BoundColumn DataField="IdcertspDettaglio" HeaderText="Domanda di pagamento"></asp:BoundColumn>
                                <asp:BoundColumn DataField="ImportocontributopubblicoIncrementale" HeaderText="Importo Certifcazione" DataFormatString="{0:c}">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGrid>
                    </div>
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
        </div>
        <div id="divStoricoModifiche" runat="server" visible="false">
            <tr>
                <td class="separatore">Elenco delle modifiche apportate:
                </td>
            </tr>
            <tr>
                <td>
                    <div id="divMostraStoricoModifiche" runat="server" style="padding: 10px;">

                        <div class="testo_pagina">
                            Di seguito vengono listate, in ordine cronologico crescente, tutte le modifiche apportate alla domanda di aiuto in questione.
                        </div>

                        <asp:Label ID="lblNumModifiche" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                        <br />
                        <Siar:DataGrid ID="dgModifiche" runat="server" AutoGenerateColumns="false" Width="100%">
                            <ItemStyle Height="30px" />
                            <Columns>
                                <asp:BoundColumn DataField="IdModifica" HeaderText="Id">
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Target" HeaderText="Target">
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IdDomanda" HeaderText="Id domanda pagamento">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IdVariante" HeaderText="Id variante">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="DataModifica" HeaderText="Data modifica">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="UtenteModifica" HeaderText="Utente modifica">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="TipoModifica" HeaderText="Tipo modifica">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Note" HeaderText="Note">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <Siar:JsButtonColumn Arguments="IdModifica" ButtonText="Visualizza modifica" JsFunction="selezionaModifica">
                                    <ItemStyle HorizontalAlign="Center" Width="160px" />
                                </Siar:JsButtonColumn>
                            </Columns>
                        </Siar:DataGrid>

                    </div>
                </td>
            </tr>
        </div>
        <div id="divAffidamento" runat="server" style="padding-left:20px" visible="false">
                <tr>
                    <td class="separatore">Elenco degli affidamenti tra ente e fornitore:
                    </td>
                </tr>
                <tr>
                    <td  class="testo_pagina">
                        Per tutti i progetti dove il beneficiario è un ente è obbligatorio inserire tutti gli atti di affidamento 
                        stipulati con il proprio fornitore.
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" style="padding-left:20px">
                            <tr>
                                <td style="width: 140px">
					                CF/P.Iva Fornitore:<br />
					                <Siar:TextBox ID="txtCfFornitore" runat="server" Width="160px" />
				                </td>
				                <td style="width: 140px">
					                Numero:<br />
					                <Siar:TextBox ID="txtNumero" runat="server" Width="160px" />
				                </td>
                                <td style="width: 140px">
					                Data:<br />
					                <Siar:DateTextBox ID="txtData" runat="server" Width="120px" />
				                </td>
                                <td style="width: 180px">
					                Importo €:<br />
					                <Siar:CurrencyBox  ID="txtNewImporto" runat="server" Width="160px" />
				                </td> 
                                <td style="width: 180px">
                                    </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
				    <td align="right" style="padding-right:100px">
					    <br />
					    <Siar:Button ID="btnSalvaAtto" runat="server" OnClick="btnSalvaAtto_Click"
						    Text="Salva" Width="160px" OnClientClick="return validaDatiAtto(event);" Enabled="false"/>
                        <Siar:Button ID="btnNuovoAtto" runat="server"
                            Text="Nuovo" Width="160px" OnClientClick="return NuovoAtto(event);" Enabled="false" />
                        <Siar:Button ID="btnElimina" runat="server"
                            Text="Elimina" Width="160px" OnClick="btnEliminaAtto_Click" Enabled="false" />
				    </td>      
			    </tr>
			    <tr>
				    <td>
					    <br />
				    </td>
			    </tr>
                <tr>
                    <td>                   
                        <Siar:DataGrid ID="dgAttiAffidamento" runat="server" AutoGenerateColumns="false" Width="100%"  
                             ShowFooter="true">
                            <ItemStyle Height="24px" />
                            <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                            <Columns>
                                <Siar:ColonnaLink HeaderText="CF/P.IVA Fornitore" DataField="CfFornitore" LinkFields="IdProgettoAttiAffidamento"
                                          ItemStyle-Width = "70px" ItemStyle-HorizontalAlign="Center"  LinkFormat="selezionaAtto({0});" IsJavascript="true">
                                </Siar:ColonnaLink>
                                <asp:BoundColumn HeaderText="Numero" DataField="Numero" >
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Data" DataField="Data">
                                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Importo" HeaderStyle-HorizontalAlign="Right" DataField="Importo">
                                            <ItemStyle HorizontalAlign="Right" Width="70px" />
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGrid>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="paragrafo_light">
                        Documentazione di Gara
                    </td>
                </tr>
                <tr>
                    <td class="testo_pagina">
                        Inserire tutta la documentazione relativa al bando di gara
                    </td>
                </tr> 
                <tr>
                    <td style="padding-left:20px">
                        <uc3:sncuploadfilecontrol ID="ufcNAAllegato" AbilitaModifica="true" runat="server" Width="600" Text="Selezionare un documento da caricare" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:20px">
                        <br />
                        Breve descrizione: (facoltativa, max 255 caratteri)
                        <br />
                        <Siar:TextArea ID="txtNADescrizioneBreve" runat="server" Width="600px" Rows="3" MaxLength="200" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 60px; padding-right: 40px">
                        <Siar:Button ID="btnSalva" Text="Salva" runat="server" CausesValidation="false" 
                            Width="150px" OnClick="btnSalva_Click" OnClientClick="return ctrlCampi(event);" Enabled="false" />
                        &nbsp;&nbsp;
                     <%--   <Siar:Button ID="btnEliminaAllegato" Text="Elimina" runat="server" CausesValidation="false"
                           Width="150px" OnClick="btnEliminaAllegato_Click" OnClientClick="return eliminaAllegato(event);" Enabled="false" />--%>
                        <input onclick="pulisciCampi();" style="width: 130px; margin-left: 20px" type="button"
                            class="Button" value="Nuovo" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <Siar:DataGrid ID="dgAllegati" runat="server" AutoGenerateColumns="False" Width="100%"
                        AllowPaging="true" PageSize="10">
                        <ItemStyle Height="40px" />
                        <Columns>
                        <asp:BoundColumn DataField="TipoAllegatoDescrizione" HeaderText="Formato">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoDocumentoDescrizione" HeaderText="Tipo Allegato">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                            <ItemStyle Width="300px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Dimensione" HeaderText="Dim. (Kb)" DataFormatString="{0:N0}">
                            <ItemStyle HorizontalAlign="Right" Width="60px" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdFile" ButtonImage="lente.png" ButtonType="ImageButton"
                            ButtonText="Visualizza documento" JsFunction="SNCUFVisualizzaFile">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:JsButtonColumn>
                        <Siar:JsButtonColumn Arguments="IdProgettoAttiAffidamentoAllegati" ButtonImage="config.ico" ButtonType="ImageButton"
                            ButtonText="Visualizza dettaglio" JsFunction="dettaglioAllegato">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
                    </td>
                </tr>
        </div>
        <div id="divIrregolaritaErroriRinunce" runat="server" visible="false">
            <tr>
                <td class="separatore">Elenco Decertificazioni: </td>
            </tr>
            <tr>
                <td
                    <div id="divMostraIrregolaritaErroriRinunce" runat="server" style="padding: 10px;">
                        <div class="testo_pagina">
                            Di seguito vengono listate tutte le irregolarità, gli errori, i recuperi e le revoche associate alla domanda di aiuto in questione.
                        </div>

                        <asp:Label ID="lblNumDecertificazioni" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                        <br />
                        <Siar:DataGrid ID="dgDecertificazione" runat="server" AutoGenerateColumns="false" Width="100%">
                            <ItemStyle Height="30px" />
                            <Columns>
                                <asp:BoundColumn DataField="IdProgetto" HeaderText="Id Progetto">
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IdDecertificazione" HeaderText="Id Decertificazione">
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="TipoDecertificazione" HeaderText="Tipo Decertificazione">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="ImportoDecertificazioneAmmesso" HeaderText="Importo Decertificazione Ammesso" DataFormatString="{0:c}">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="ImportoDecertificazioneConcesso" HeaderText="Importo Decertificazione Concesso" DataFormatString="{0:c}">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="DataConstatazioneAmministrativa" HeaderText="Data Constatazione Amministrativa">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Assegnata" HeaderText="In Certificazione">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <Siar:JsButtonColumn Arguments="IdCertDecertificazione" ButtonText="Visualizza elemento" JsFunction="selezionaDecertificazione">
                                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                                </Siar:JsButtonColumn>
                            </Columns>
                        </Siar:DataGrid>
                        <br />

                        <Siar:Button ID="btnInserisciIrregolarita" runat="server" OnClick="btnInserisciIrregolarita_Click" Text="Inserisci Irregolarita" AdditionalStyles="margin-top: 10px; margin-bottom: 10px;" />
                        <Siar:Button ID="btnInserisciErrore" runat="server" OnClick="btnInserisciErrore_Click" Text="Inserisci Errore" AdditionalStyles="margin-top: 10px; margin-bottom: 10px;" />
                        <Siar:Button ID="btnInserisciRevoca" runat="server" OnClick="btnInserisciRevoca_Click" Text="Inserisci Revoca" AdditionalStyles="margin-top: 10px; margin-bottom: 10px;" />
                        <Siar:Button ID="btnInserisciRecupero" runat="server" OnClick="btnInserisciRecupero_Click" Text="Inserisci Recupero" AdditionalStyles="margin-top: 10px; margin-bottom: 10px;" />
                        <Siar:Button ID="btnInserisciRinuncia" runat="server" OnClick="btnInserisciRinuncia_Click" Text="Inserisci Rinuncia" AdditionalStyles="margin-top: 10px; margin-bottom: 10px;" />
                    </div>
                </td>
            </tr>
        </div>
        <div id="divSoccorsoIstrtuttorio" runat="server" visible="false">
            <tr>
                <td class="separatore">Concessione ulteriori contributi: </td>
            </tr>
            <tr>
                <td  class="testo_pagina">
                    Per i progetti rendicontati e in certificazione è possibile istruire qualche fattura precedentemente caricata in modo da assegnare più contributo al progetto.
                </td>
            </tr>
            <tr>
                <td  align="center">
                     <Siar:Button ID="btnProseguiPostSld" runat="server" OnClick="btnProseguiPostSld_Click" Text="Crea" style="width: 160px;" />
                </td>
            </tr>
             <tr>
                <td >
                   <br />
                </td>
            </tr>
            <tr>
                <td >
                   <Siar:DataGrid ID="dgRettificaSaldo" runat="server" AutoGenerateColumns="False" Width="100%"
                        AllowPaging="true" PageSize="10">
                        <ItemStyle Height="40px" />
                        <Columns>
                            <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="ID">
                                <ItemStyle HorizontalAlign="Center" Width="80px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Descrizione" HeaderText="Tipo">
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DataModifica" HeaderText="Data">
                                <ItemStyle Width="80px"  HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Istruttore" HeaderText="Operatore">
                                <ItemStyle HorizontalAlign="center" Width="150px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Contributo Ammesso">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                            <asp:BoundColumn HeaderText=" ">
                                <ItemStyle HorizontalAlign="center" Width="80px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText=" ">
                                <ItemStyle HorizontalAlign="center" Width="250px" />
                            </asp:BoundColumn>
                        </Columns>
                 </Siar:DataGrid>
                </td>
            </tr>
            <tr>
                <td >
                   <br />
                </td>
            </tr>
        </div>
    </table>
    <br />
    <table width="1050px">
        <tr>
            <td>
    <uc4:Procure ID="ProcureSpeciali" runat="server" />
                    </td>
            </tr>        
    </table>

</asp:Content>
