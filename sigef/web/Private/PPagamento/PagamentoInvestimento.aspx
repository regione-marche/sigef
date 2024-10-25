<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.PagamentoInvestimento" CodeBehind="PagamentoInvestimento.aspx.cs" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/ZoomLoader.ascx" TagName="ZoomLoader" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/ucPagamentoInvestimento.ascx" TagName="ucPagamentoInvestimento" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function ctrlCampiLavoriInEconomia(ev) { if($('[id$=txtLECImportoRichiesto_text]').val()==''||$('[id$=txtLECDescrizione_text]').val()=='') { alert('Attenzione! E` necessario inserire sia l`importo che la descrizione dei lavori in economia.');return stopEvent(ev); } }
        function mostraPagamento(id) { $('[id$=hdnIdPagamentoBeneficiario]').val(id);$('[id$=btnMostraPagamento]').click(); }
        function mostraPopupLavoriInEconomia() { $('[id$=hdnIdPagamentoBeneficiario]').val('');$('[id$=txtLECImportoRichiesto_text]').val('');$('[id$=txtLECDescrizione_text]').val('');$('[id$=chkLECVariazioneInvestimento]')[0].checked=false;$('[id$=btnEliminaLavoriInEconomia]')[0].disabled=true;mostraPopupTemplate('divLavoriInEconomia','divBKGMessaggio'); }
        function chiudiPopup() { $('[id$=hdnIdPagamentoBeneficiario]').val('');chiudiPopupTemplate(); }
        function selezionaGiustificativo(obj,b) { if(obj!=null&&confirm('Richiedere, in base al giustificativo selezionato, il pagamento per l`investimento?')) $('[id$=btnPost]').click(); }
//--></script>

    <div style="display: none">
        <Siar:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="False" />
        <Siar:Button ID="btnMostraPagamento" runat="server" OnClick="btnMostraPagamento_Click"
            CausesValidation="False" />
        <asp:HiddenField ID="hdnIdPagamentoRichiesto" runat="server" />
        <asp:HiddenField ID="hdnIdPagamentoBeneficiario" runat="server" />
    </div>
    <uc1:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
    &nbsp;<table class="tableNoTab" style="width: 900px">
        <tr>
            <td class="separatore_big">
                RENDICONTAZIONE DELL'INVESTIMENTO:
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr class="TESTA1">
            <td valign="middle">
                &nbsp;Dettagli investimento:&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <img id='imgDettaglioInvestimento' runat="server" style='cursor: pointer;' src='../../images/acrobat.gif'
                    alt='Visualizza i dettagli dell`investimento' />
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width: 400px;" valign="top" align="left">
                            <table id="tbInvestimento" runat="server" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="center" style="width: 33px; height: 31px">
                                    </td>
                                    <td align="center" style="width: 33px; height: 31px">
                                    </td>
                                    <td align="center" style="width: 33px; height: 31px;">
                                    </td>
                                    <td style="width: 300px; height: 31px" align="left">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 23px" valign="middle">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 23px" valign="middle">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 23px" valign="middle">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 23px" valign="middle">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 23px" valign="middle">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 23px" valign="middle">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="middle">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 152px; height: 57px;">
                                        <br />
                                        &nbsp; &nbsp; &nbsp;<strong>(A)</strong> Costo investimento:<br />
                                        &nbsp;€
                                        <Siar:CurrencyBox ID="txtCostoInvestimento" runat="server" ReadOnly="True" Width="100px" />
                                    </td>
                                    <td style="width: 132px; height: 57px; display:none;">
                                        <br />
                                        <strong>(B)</strong>&nbsp;<Siar:Label ID="lblSpeseTecniche" runat="server">
                                        </Siar:Label>
                                        <br />
                                        <Siar:CurrencyBox ID="txtSpeseTecniche" runat="server" ReadOnly="True" Width="100px" />
                                    </td>
                                    <td style="width: 132px; height: 57px">
                                        <br />
                                        Contributo:<br />
                                        <Siar:CurrencyBox ID="txtContributoAmmesso" runat="server" ReadOnly="True" Width="100px" />
                                    </td>
                                    <td style="width: 76px; height: 57px">
                                        <br />
                                        Aiuto %:<br />
                                        <Siar:CurrencyBox ID="txtQuotaAiuto" runat="server" ReadOnly="True" Width="50px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="paragrafo" colspan="4" style="height: 31px">
                                        <br />
                                        &nbsp;Totali richiesti fino ad ora per l'investimento:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 152px; height: 57px; border-left: black 1px solid;">
                                        <br />
                                        &nbsp; &nbsp; <strong>(C) </strong>Importo totale:<br />
                                        &nbsp;€
                                        <Siar:CurrencyBox ID="txtStoricoImportoRichiesto" runat="server" ReadOnly="True"
                                            Width="100px" />
                                        <br />
                                        &nbsp;
                                    </td>
                                    <td style="width: 132px; height: 57px">
                                        <br />
                                        Contributo:<br />
                                        <Siar:CurrencyBox ID="txtStoricoContributoRichiesto" runat="server" ReadOnly="True"
                                            Width="100px" />
                                        <br />
                                        &nbsp;
                                    </td>
                                    <td style="height: 57px" colspan="2">
                                        <br />
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td style="width: 79px">
                                                    &nbsp;Aiuto %:&nbsp;<br />
                                                    <Siar:QuotaBox ID="txtStoricoRichiestoQuota" runat="server" ReadOnly="True" Width="50px" />
                                                </td>
                                                <td style="border-left: black 1px solid">
                                                    &nbsp; % Completamento:<br />
                                                    <strong>&nbsp;<asp:Label ID="lblFormulaCompletamento" runat="server" Text="(C/(A+B))"></asp:Label></strong><Siar:CurrencyBox
                                                        ID="txtCompletamentoInvestimento" runat="server" ReadOnly="True" Width="50px" />
                                                </td>
                                            </tr>
                                        </table>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="TESTA1">
            <td valign="middle">
                &nbsp;Totali pagamento richiesto:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" style="width: 33px">
                            <br />
                            <br />
                            &nbsp; &nbsp; &nbsp; €
                        </td>
                        <td style="width: 150px;display:none;" align="left">
                            <br />
                            Importo investimento:<br />
                            <Siar:CurrencyBox ID="txtImportoInvestimento" runat="server" ReadOnly="True" Width="120px" />
                        </td>
                        <td align="left" style="width: 150px;display:none;" >
                            <strong><b>(M) </b></strong>Importo da<br />
                            computo metrico: <strong>(*)&nbsp;&nbsp; </strong>
                            <br />
                            <Siar:CurrencyBox ID="txtImportoComputoMetrico" runat="server" Width="120px" />
                        </td>
                        <td align="left" style="width: 150px;display:none;">
                            <br />
                            Importo spese tecniche:<br />
                            <Siar:CurrencyBox ID="txtImportoSpeseTecniche" runat="server" ReadOnly="True" Width="120px" />
                        </td>
                        <td style="width: 150px" align="left">
                            <br />
                            Importo totale:<br />
                            <Siar:CurrencyBox ID="txtImportoTotaleRichiesto" runat="server" ReadOnly="True" Width="120px" />
                        </td>
                        <td align="left">
                            <br />
                            &nbsp;Contributo totale:
                            <br />
                            <Siar:CurrencyBox ID="txtContributoTotaleRichiesto" runat="server" ReadOnly="True"
                                Width="120px" />
                        </td>
                        <td style="width: 150px" align="left" id="tdRichiestoAltreFonti" runat="server" >
                            <br />
                            Contributo Altre Fonti:<br />
                            <Siar:CurrencyBox ID="txtContributoRichiestoAltreFonti" runat="server" ReadOnly="True" Width="120px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 33px">
                        </td>
                        <td align="left" style="width: 150px">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left" style="width: 150px">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td align="center" style="width: 33px">
                            <br />
                            <br />
                            &nbsp; &nbsp; &nbsp; €
                        </td>
                        <td align="left" style="width: 150px">
                            <b>(E)</b>&nbsp;Importo
                            <br />
                            lavori in economia:&nbsp;<b>(**)</b><br />
                            <Siar:CurrencyBox ID="txtImportoRichiestoLavoriInEconomia" runat="server" ReadOnly="True"
                                Width="120px" />
                        </td>
                        <td align="left" style="width: 150px">
                            % lavori in economia
                            <br />
                            su totale:<br />
                            <Siar:CurrencyBox ID="txtQuotaRichiestoLavoriInEconomia" runat="server" ReadOnly="True"
                                Width="120px" />
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
        <tr class="TESTA1">
            <td valign="middle">
                &nbsp;Totali pagamento ammesso:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" style="width: 33px">
                            <br />
                            <br />
                            &nbsp; &nbsp; &nbsp; €
                        </td>
                        <td style="width: 150px;display:none;" align="left">
                            <br />
                            Importo investimento:<br />
                            <Siar:CurrencyBox ID="txtImportoInvestimentoAmmesso" runat="server" ReadOnly="True"
                                Width="120px" />
                        </td>
                        <td align="left" style="width: 150px; display:none;">
                            Importo da<br />
                            computo metrico: <strong>(*)</strong><br />
                            <Siar:CurrencyBox ID="txtImportoComputoMetricoAmmesso" runat="server" Width="120px"
                                ReadOnly="True" />
                        </td>
                        <td align="left" style="width: 150px; display:none;">
                            <br />
                            Importo spese tecniche:<br />
                            <Siar:CurrencyBox ID="txtImportoSpeseTecnicheAmmesse" runat="server" ReadOnly="True"
                                Width="120px" />
                        </td>
                        <td style="width: 150px" align="left">
                            <br />
                            Importo totale:<br />
                            <Siar:CurrencyBox ID="txtImportoTotaleAmmesso" runat="server" ReadOnly="True" Width="120px" />
                        </td>
                        <td align="left">
                            <br />
                            Contributo totale: &nbsp;&nbsp;&nbsp;<br />
                            <Siar:CurrencyBox ID="txtContributoTotaleAmmesso" runat="server" ReadOnly="True"
                                Width="120px" />
                        </td>
                        <td style="width: 150px" align="left" id="tdAmmessoAltreFonti" runat="server" >
                            <br />
                            Contributo Altre Fonti:<br />
                            <Siar:CurrencyBox ID="txtContributoAmmessoAltreFonti" runat="server" ReadOnly="True" Width="120px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 33px">
                        </td>
                        <td align="left" style="width: 150px">
                            &nbsp;
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td align="center" style="width: 33px">
                            <br />
                            <br />
                            &nbsp; &nbsp; &nbsp; €
                        </td>
                        <td align="left" style="width: 150px">
                            Importo
                            <br />
                            lavori in economia:&nbsp;<b>(**)</b><br />
                            <Siar:CurrencyBox ID="txtImportoAmmessoLavoriInEconomia" runat="server" ReadOnly="True"
                                Width="120px" />
                        </td>
                        <td align="left" style="width: 150px">
                            % lavori in economia
                            <br />
                            su totale:<br />
                            <Siar:CurrencyBox ID="txtQuotaAmmessoLavoriInEconomia" runat="server" ReadOnly="True"
                                Width="120px" />
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left" style="width: 150px">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <b>(*)</b> = inserire l'importo da preventivo qualora il c.m. non fosse richiesto
            </td>
        </tr>
        <tr>
            <td align="right">
                <b>(**)</b> = il contributo non puo&#39; superare la differenza tra rendicontato
                e importo lavori in economia <b>( T&lt;= M - E )</b>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" id="tableValutazione" runat="server" visible="false">
                    <tr class="TESTA1">
                        <td>
                            &nbsp;Valutazione dell'istruttore:
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            &nbsp;<br />
                            <Siar:TextArea ID="txtValutazioneLunga" ReadOnly="true" runat="server" Rows="3" Width="780px"
                                ExpandableRows="5" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="TESTA1">
            <td>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 61px" valign="middle">
                <Siar:Button ID="btnSalva" runat="server" OnClick="btnSaveRichiesto_Click" Text="Salva"
                    Width="180px" CausesValidation="False" />&nbsp; &nbsp;
                <input id="btnBack" class="Button" style="width: 180px" type="button" value="Indietro"
                    onclick="location='PianoInvestimenti.aspx'" />
            </td>
        </tr>
    </table>
    &nbsp;
    <table class="tableNoTab" style="width: 1050px">
        <tr class="TESTA1">
            <td>
                &nbsp;Elenco giustificativi associati (<asp:Label ID="lblNumeroPagamenti" runat="server"></asp:Label>)
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<a id="lnkNuovoGiustificativo"
                    runat="server" href="">[INSERISCI NUOVO GIUSTIFICATIVO]</a> &nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp; &nbsp;&nbsp; <a visible="false" id="lnkLavoroInEconomia" runat="server" href="">[INSERISCI LAVORO
                    IN ECONOMIA]</a>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<br />
                <Siar:DataGrid ID="dgPagamenti" runat="server" AutoGenerateColumns="False" Width="100%" ShowFooter="true">
                    <FooterStyle CssClass="coda" HorizontalAlign="Right"  />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="center" Width="30px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Imponibile" DataFormatString="{0:c}" HeaderText="Imponibile">
                            <ItemStyle HorizontalAlign="right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoRichiesto" HeaderText="Importo" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo">
                            <ItemStyle HorizontalAlign="right" Width="90px" />
                        </asp:BoundColumn>
<%--                        <asp:BoundColumn HeaderText="Spesa tecnica">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundColumn>--%>
                        <asp:BoundColumn>
                            <ItemStyle CssClass="testoRosso" HorizontalAlign="Center" Width="25px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ImportoAmmesso" HeaderText="Importo" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="90px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo" DataField="ContributoAmmesso" DataFormatString="{0:c}" >
                            <ItemStyle HorizontalAlign="right" Width="90px" />
                        </asp:BoundColumn>
        <%--                <asp:BoundColumn HeaderText="Spesa tecnica">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundColumn>--%>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdInvestimento" ButtonType="ImageButton" ButtonText="Richiesta integrazione"
                            JsFunction="" HeaderText="Richiesta integrazione" ButtonImage="warning.png">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
                <div style="width: 100%; text-align: right">
                    <span class='testoRosso'>(V) </span>= pagamenti che costituiscono un effettiva <strong>
                        variazione</strong> dell'investimento&nbsp;
                </div>
                <br />
            </td>
        </tr>
    </table>
    
    <div id="divLavoriInEconomia" style="width: 900px; position: absolute; display: none">
        <table class="tableNoTab" width="100%">
            <tr>
                <td class="separatore">
                    Dettaglio del lavoro in economia:
                </td>
            </tr>
            <tr>
                <td class="testo_pagina">
                    Specificare l'<b>importo in euro</b> e la <b>descrizione</b> dei lavori effettuati
                    in tale modalità. E&#39; possibile rendicontare importi fino, e non oltre,
                    <br />
                    ad un ammontare calcolato come la <b>differenza tra il computo metrico e contributo
                        totale</b> attribuito <b>( E &lt;= M - T )</b>.
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td style="width: 200px">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            Importo €:<br />
                                            <Siar:CurrencyBox ID="txtLECImportoRichiesto" runat="server" Width="120px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Contributo €:<br />
                                            <Siar:CurrencyBox ID="txtLECContributoRichiesto" runat="server" Width="120px" ReadOnly="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td style="height: 38px; width: 24px">
                                                        <input id="chkLECVariazioneInvestimento" runat="server" type="checkbox" />
                                                    </td>
                                                    <td style="height: 38px">
                                                        lavoro costituente effettiva <b>variazione</b> dell'investimento
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="vertical-align: top">
                                Descrizione:<br />
                                <Siar:TextArea ID="txtLECDescrizione" runat="server" Rows="6" Width="610px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="paragrafo">
                    Pagamento ammesso:
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td style="width: 200px; vertical-align: top">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            Importo €:<br />
                                            <Siar:CurrencyBox ID="txtLECImportoAmmesso" runat="server" Width="120px" ReadOnly="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Contributo €:<br />
                                            <Siar:CurrencyBox ID="txtLECContributoAmmesso" runat="server" Width="120px" ReadOnly="true" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td class="paragrafo">
                                            Motivazioni della riduzione:
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 4px">
                                            <Siar:CheckBoxList ID="chklLECMotivazioniRiduzione" runat="server" RepeatColumns="3"
                                                RepeatDirection="Horizontal" RepeatLayout="Table" Enabled="false">
                                            </Siar:CheckBoxList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Note aggiuntive:<br />
                                            <Siar:TextArea ID="txtLECNoteAggiuntive" runat="server" Rows="6" Width="610px" ReadOnly="true" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 70px">
                    <Siar:Button ID="btnSalvaLavoriInEconomia" runat="server" Modifica="true" OnClick="btnSalvaLavoriInEconomia_Click"
                        Text="Salva" Width="130px" CausesValidation="False" OnClientClick="return ctrlCampiLavoriInEconomia(event);" />
                    &nbsp;&nbsp;
                    <Siar:Button ID="btnEliminaLavoriInEconomia" runat="server" Modifica="true" OnClick="btnDel_Click"
                        CausesValidation="False" Text="Elimina" Conferma="Attenzione! Eliminare il pagamento?"
                        Width="130px" />
                    <input class="Button" onclick="chiudiPopup()" style="width: 100px; margin-left: 20px;
                        margin-right: 20px" type="button" value="Chiudi" />
                </td>
            </tr>
        </table>
    </div>
    
    <uc3:ucPagamentoInvestimento ID="modalePagamento" runat="server" />
    
    <uc2:ZoomLoader ID="ucZoomLoaderGiustificativiPagati" runat="server" AutomaticSearch="True"
        NoSearch="True" SearchMethod="GetGiustificativiDomandaPagamento" KeySearch="Numero:Numero|Data:Data:d"
        ColumnsToBind="nr|Numero:Numero:d|Data:Data:d|Imponibile:Imponibile:c|Descrizione:Descrizione"
        KeyValue="IdGiustificativo" KeyText="Descrizione|Numero|CodTipo|Data|CfFornitore|DataDoctrasporto|DescrizioneFornitore|Imponibile|Iva|IvaNonRecuperabile|NumeroDoctrasporto"
        JsSelectedItemHandler="selezionaGiustificativo" Width="700px" />
</asp:Content>
