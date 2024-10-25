<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.PagamentoInvestimentoFem" CodeBehind="PagamentoInvestimentoFem.aspx.cs" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/ZoomLoader.ascx" TagName="ZoomLoader" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/ucPagamentoInvestimento.ascx" TagName="ucPagamentoInvestimento" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function selezionaContratto(obj, b) {
            if (obj != null && confirm('Richiedere, in base al contratto selezionato, il pagamento per l`investimento?'))
                $('[id$=btnAggiungiPagamentoContratto]').click();
        }

        function selezionaGiustificativo(obj, b) {
            if (obj != null && confirm('Richiedere, in base al giustificativo selezionato, il pagamento per l`investimento?'))
                $('[id$=btnAggiungiPagamentoGiustificativo]').click();
        }

        function eliminaPagamento(idPagamento) {
            if (confirm('Eliminare il pagamento del contratto selezionato?')) {
                $('[id$=hdnIdPagamentoFemEliminare]').val(idPagamento);
                $('[id$=btnEliminaPagamento]').click();
            }
        }
    </script>

    <div style="display: none">
        <Siar:Button ID="btnAggiungiPagamentoContratto" runat="server" OnClick="btnAggiungiPagamentoContratto_Click" CausesValidation="False" />
        <Siar:Button ID="btnAggiungiPagamentoGiustificativo" runat="server" OnClick="btnAggiungiPagamentoGiustificativo_Click" CausesValidation="False" />
        <Siar:Button ID="btnEliminaPagamento" runat="server" OnClick="btnEliminaPagamento_Click" CausesValidation="False" />
        <asp:HiddenField ID="hdnIdPagamentoFem" runat="server" />
        <asp:HiddenField ID="hdnIdPagamentoFemEliminare" runat="server" />
    </div>

    <uc1:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />

    &nbsp;
    <table class="tableNoTab" style="width: 900px">
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
            <td>
                <table width="100%" id="tableValutazione" runat="server" visible="false">
                    <tr class="TESTA1">
                        <td>&nbsp;Valutazione dell'istruttore:
                        </td>
                    </tr>
                    <tr>
                        <td align="center">&nbsp;<br />
                            <Siar:TextArea ID="txtValutazioneLunga" ReadOnly="true" runat="server" Rows="3" Width="780px"
                                ExpandableRows="5" />
                        </td>
                    </tr>
                </table>
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
                &nbsp;Elenco pagamenti associati (<asp:Label ID="lblNumeroContratti" runat="server"></asp:Label>)
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<a id="lnkNuovoContratto"
                    runat="server" href="">[INSERISCI NUOVO CONTRATTO]</a> <a id="lnkNuovoGiustificativo"
                        runat="server" href="">[INSERISCI NUOVO GIUSTIFICATIVO]</a>&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp; &nbsp;&nbsp; 
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<br />
                <Siar:DataGrid ID="dgPagamenti" runat="server" AutoGenerateColumns="False" Width="100%" ShowFooter="true">
                    <FooterStyle CssClass="coda" HorizontalAlign="Right"  />
                    <Columns>
                        <asp:BoundColumn HeaderText="Id" DataField="IdPagamentoRichiestoFem">
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Tipologia" DataField="IdPagamentoRichiestoFem">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Riferimenti">
                            <ItemStyle HorizontalAlign="left" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="SegnaturaContratto" ButtonType="ImageButton" ButtonImage="/print_ico.gif" ButtonText="Visualizza protocollo" JsFunction="sncAjaxCallVisualizzaProtocollo">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                        <asp:BoundColumn DataField="ImportoContratto" HeaderText="Importo contratto/giustificativo" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <Siar:NewImportoColumn DataField="IdPagamentoRichiestoFem" Name="ImportoRichiesto" Importo="ImportoRichiesto" HeaderText="Importo richiesto" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </Siar:NewImportoColumn>
                        <asp:BoundColumn DataField="ImportoAmmesso" HeaderText="Importo ammesso" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdPagamentoRichiestoFem" ButtonText="Elimina pagamento" JsFunction="eliminaPagamento" >
                            <ItemStyle HorizontalAlign="Center" Width="140px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
                <br />
            </td>
        </tr>
    </table>
    
    <uc3:ucPagamentoInvestimento ID="modalePagamento" runat="server" />
    
    <uc2:ZoomLoader ID="ucZoomLoaderContrattiPagati" runat="server" AutomaticSearch="True"
        NoSearch="True" SearchMethod="GetContrattiDomandaPagamento" KeySearch="Segnatura:Segnatura|Data stipula contratto:DataStipulaContratto:d"
        ColumnsToBind="Id:IdContrattoFem|Segnatura:Segnatura|Data stipula contratto:DataStipulaContratto:d|Importo:Importo:c"
        KeyValue="IdContrattoFem" KeyText="IdContrattoFem|IdBando|IdProgetto|DataStipulaContratto|Segnatura|DataSegnatura|Importo|DataCreazione|DataAggiornamento|OperatoreCreazione|OperatoreAggiornamento|IdImpresa"
        JsSelectedItemHandler="selezionaContratto" Width="700px" />

    <uc2:ZoomLoader ID="ucZoomLoaderGiustificativiPagati" runat="server" AutomaticSearch="True"
        NoSearch="True" SearchMethod="GetGiustificativiDomandaPagamento" KeySearch="Numero:Numero|Data:Data:d"
        ColumnsToBind="nr|Numero:Numero:d|Data:Data:d|Imponibile:Imponibile:c|Descrizione:Descrizione"
        KeyValue="IdGiustificativo" KeyText="Descrizione|Numero|CodTipo|Data|CfFornitore|DataDoctrasporto|DescrizioneFornitore|Imponibile|Iva|IvaNonRecuperabile|NumeroDoctrasporto"
        JsSelectedItemHandler="selezionaGiustificativo" Width="700px" />
</asp:Content>
